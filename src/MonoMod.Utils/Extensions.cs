﻿using System;
using System.Reflection;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MonoMod.Utils {
    /// <summary>
    /// Collection of extensions used by MonoMod and other projects.
    /// </summary>
    public static partial class Extensions {

        // Use this source file for any extensions which don't deserve their own source files.

        private static readonly Dictionary<Type, FieldInfo> fmap_mono_assembly = new Dictionary<Type, FieldInfo>();
        // Old versions of Mono which lack the arch field in MonoAssemblyName don't parse ProcessorArchitecture.
        private static readonly bool _MonoAssemblyNameHasArch =
#pragma warning disable SYSLIB0037 // Type or member is obsolete
            new AssemblyName("Dummy, ProcessorArchitecture=MSIL").ProcessorArchitecture == ProcessorArchitecture.MSIL;
#pragma warning restore SYSLIB0037 // Type or member is obsolete

        private static readonly Type? _RTDynamicMethod =
            typeof(DynamicMethod).GetNestedType("RTDynamicMethod", BindingFlags.NonPublic | BindingFlags.Public);

        /// <summary>
        /// Determine if two types are compatible with each other (f.e. object with string, or enums with their underlying integer type).
        /// </summary>
        /// <param name="type">The first type.</param>
        /// <param name="other">The second type.</param>
        /// <returns>True if both types are compatible with each other, false otherwise.</returns>
        public static bool IsCompatible(this Type type, Type other)
            => _IsCompatible(Helpers.ThrowIfNull(type), Helpers.ThrowIfNull(other)) || _IsCompatible(other, type);
        private static bool _IsCompatible(this Type type, Type other) {
            if (type == other)
                return true;

            if (type.IsAssignableFrom(other))
                return true;

            if (other.IsEnum && IsCompatible(type, Enum.GetUnderlyingType(other)))
                return true;

            if ((other.IsPointer || other.IsByRef) && type == typeof(IntPtr))
                return true;

            // If both types are pointers, we'll assume the user knows what they're doing since they're using unsafe anyway
            if (type.IsPointer && other.IsPointer)
                return true;

            // if one is a pointer, and the other is a byref, then we can forgo underlying type checks for the same reason as above
            if (type.IsByRef && other.IsPointer)
                return true;

            return false;
        }

        public static T GetDeclaredMember<T>(this T member) where T : MemberInfo {
            Helpers.ThrowIfArgumentNull(member);
            if (member.DeclaringType == member.ReflectedType)
                return member;

            if (member.DeclaringType is not null) {
                var mt = member.MetadataToken;
                foreach (MemberInfo other in member.DeclaringType.GetMembers((BindingFlags) (-1))) {
                    if (other.MetadataToken == mt)
                        return (T) other;
                }
            }

            return member;
        }

        public static unsafe void SetMonoCorlibInternal(this Assembly asm, bool value) {
            // TODO: try to move this impl into MM.Core's platform abstraction
            // it already has this for CoreCLR, which needs it for *other* reasons
            if (PlatformDetection.Runtime is not RuntimeKind.Mono)
                return;

            Helpers.ThrowIfArgumentNull(asm);

            // Mono doesn't know about IgnoresAccessChecksToAttribute,
            // but it lets some assemblies have unrestricted access.

            // https://github.com/mono/mono/blob/df846bcbc9706e325f3b5dca4d09530b80e9db83/mono/metadata/metadata-internals.h#L207
            // https://github.com/mono/mono/blob/1af992a5ffa46e20dd61a64b6dcecef0edb5c459/mono/metadata/appdomain.c#L1286
            // https://github.com/mono/mono/blob/beb81d3deb068f03efa72be986c96f9c3ab66275/mono/metadata/class.c#L5748
            // https://github.com/mono/mono/blob/83fc1456dbbd3a789c68fe0f3875820c901b1bd6/mcs/class/corlib/System.Reflection/Assembly.cs#L96
            // https://github.com/mono/mono/blob/cf69b4725976e51416bfdff22f3e1834006af00a/mcs/class/corlib/System.Reflection/RuntimeAssembly.cs#L59
            // https://github.com/mono/mono/blob/cf69b4725976e51416bfdff22f3e1834006af00a/mcs/class/corlib/System.Reflection.Emit/AssemblyBuilder.cs#L247
            // https://github.com/mono/mono/blob/ee3a669dc30689af8c8919afc61d226683a1aaa3/mcs/class/corlib/System.Reflection.Emit/AssemblyBuilder.cs#L258
            
            var asmType = asm.GetType();
            if (asmType == null)
                return;

            // _mono_assembly has changed places between Mono versions.
            FieldInfo? f_mono_assembly;
            lock (fmap_mono_assembly) {
                if (!fmap_mono_assembly.TryGetValue(asmType, out f_mono_assembly)) {
                    f_mono_assembly =
                        asmType.GetField("_mono_assembly", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance) ??
                        asmType.GetField("dynamic_assembly", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                        ?? throw new InvalidOperationException("Could not find assembly field for Mono");
                    fmap_mono_assembly[asmType] = f_mono_assembly;
                }
            }
            if (f_mono_assembly == null)
                return;

            // Assemblies marked as corlib_internal are hidden from AppDomain.GetAssemblies()
            // Make sure that at least the ReflectionHelper can find anything inside of them.
            var name = asm.GetName();
            lock (ReflectionHelper.AssemblyCache) {
                var asmRef = new WeakReference(asm);
                ReflectionHelper.AssemblyCache[asm.GetRuntimeHashedFullName()] = asmRef;
                ReflectionHelper.AssemblyCache[name.FullName] = asmRef;
                if (name.Name is not null) {
                    ReflectionHelper.AssemblyCache[name.Name] = asmRef;
                }
            }
            
            var asmPtr = 0L;
            // For AssemblyBuilders, dynamic_assembly is of type UIntPtr which doesn't cast to IntPtr
            switch (f_mono_assembly.GetValue(asm)) {
                case IntPtr i:
                    asmPtr = (long) i;
                    break;
                case UIntPtr u:
                    asmPtr = (long) u;
                    break;
            }
            
            var offs =
                // ref_count (4 + padding)
                IntPtr.Size +
                // basedir
                IntPtr.Size +

                // aname
                // name
                IntPtr.Size +
                // culture
                IntPtr.Size +
                // hash_value
                IntPtr.Size +
                // public_key
                IntPtr.Size +
                // public_key_token (17 + padding)
                20 +
                // hash_alg
                4 +
                // hash_len
                4 +
                // flags
                4 +

                // major, minor, build, revision[, arch] (10 framework / 20 core + padding)
                (
                    !_MonoAssemblyNameHasArch ? (
                        ReflectionHelper.IsCoreBCL ?
                        16 :
                        8
                    ) : (
                        ReflectionHelper.IsCoreBCL ?
                        (IntPtr.Size == 4 ? 20 : 24) :
                        (IntPtr.Size == 4 ? 12 : 16)
                    )
                ) +

                // image
                IntPtr.Size +
                // friend_assembly_names
                IntPtr.Size +
                // friend_assembly_names_inited
                1 +
                // in_gac
                1 +
                // dynamic
                1;
            var corlibInternalPtr = (byte*) (asmPtr + offs);
            *corlibInternalPtr = value ? (byte) 1 : (byte) 0;
        }

        public static bool IsDynamicMethod(this MethodBase method) {
            Helpers.ThrowIfArgumentNull(method);
            // .NET throws when trying to get metadata like the token / handle, but has got RTDynamicMethod.
            if (_RTDynamicMethod != null)
                return method is DynamicMethod || method.GetType() == _RTDynamicMethod;

            // Mono doesn't throw and instead returns 0 on its fake RuntimeMethodInfo.
            // Note that other runtime-internal methods (such as int[,].Get) are still resolvable yet have a token of 0.
            if (method is DynamicMethod)
                return true;

            // Fake DynamicMethods MUST have those.
            if (method.MetadataToken != 0 ||
                !method.IsStatic ||
                !method.IsPublic ||
                (method.Attributes & System.Reflection.MethodAttributes.ReuseSlot) != System.Reflection.MethodAttributes.ReuseSlot)
                return false;

            // Fake DynamicMethods aren't part of their declaring type.
            // Sounds obvious, but seems like the only real method to verify that it's a fake DynamicMethod.
            if (method.DeclaringType is not null) {
                foreach (MethodInfo other in method.DeclaringType.GetMethods(BindingFlags.Public | BindingFlags.Static))
                    if (method == other)
                        return false;
            }
            return true;
        }

        public static object? SafeGetTarget(this WeakReference weak) {
            Helpers.ThrowIfArgumentNull(weak);
            try {
                return weak.Target;
            } catch (InvalidOperationException) {
                // FUCK OLD UNITY MONO
                // https://github.com/Unity-Technologies/mono/blob/unity-2017.4/mcs/class/corlib/System/WeakReference.cs#L96
                // https://github.com/Unity-Technologies/mono/blob/unity-2017.4-mbe/mcs/class/corlib/System/WeakReference.cs#L94
                // https://docs.microsoft.com/en-us/archive/blogs/yunjin/trivial-debugging-note-using-weakreference-in-finalizer
                // "So on CLR V2.0 offical released build, you could safely use WeakReference in finalizer."
                return null;
            }
        }

        public static bool SafeGetIsAlive(this WeakReference weak) {
            Helpers.ThrowIfArgumentNull(weak);
            try {
                return weak.IsAlive;
            } catch (InvalidOperationException) {
                // See above FUCK OLD UNITY MONO note.
                return false;
            }
        }

    }
}
