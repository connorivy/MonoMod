using System.Diagnostics.CodeAnalysis;

namespace MonoMod.Core.Interop
{
    internal static unsafe partial class CoreCLR
    {
        [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes",
            Justification = "It must be non-static to be able to inherit others, as it does. This allows the Core*Runtime types " +
            "to each reference exactly the version they represent, and the compiler automatically resolves the correct one without " +
            "needing duplicates.")]
        [SuppressMessage("Performance", "CA1852", Justification = "This type will be derived for .NET 8.")]
        public class V90 : V80
        {
            public new static class ICorJitInfoVtable
            {
                // This listing is generated by build/extract-corjit-vtable.

                //
                // src\coreclr\inc\corinfo.h:1960
                // class ICorStaticInfo
                // 00: bool isIntrinsic(CORINFO_METHOD_HANDLE)
                // 01: bool notifyMethodInfoUsage(CORINFO_METHOD_HANDLE)
                // 02: uint32_t getMethodAttribs(CORINFO_METHOD_HANDLE)
                // 03: void setMethodAttribs(CORINFO_METHOD_HANDLE, CorInfoMethodRuntimeFlags)
                // 04: void getMethodSig(CORINFO_METHOD_HANDLE, CORINFO_SIG_INFO *, CORINFO_CLASS_HANDLE)
                // 05: bool getMethodInfo(CORINFO_METHOD_HANDLE, CORINFO_METHOD_INFO *, CORINFO_CONTEXT_HANDLE)
                // 06: bool haveSameMethodDefinition(CORINFO_METHOD_HANDLE, CORINFO_METHOD_HANDLE)
                // 07: CORINFO_CLASS_HANDLE getTypeDefinition(CORINFO_CLASS_HANDLE)
                // 08: CorInfoInline canInline(CORINFO_METHOD_HANDLE, CORINFO_METHOD_HANDLE)
                // 09: void beginInlining(CORINFO_METHOD_HANDLE, CORINFO_METHOD_HANDLE)
                // 0A: void reportInliningDecision(CORINFO_METHOD_HANDLE, CORINFO_METHOD_HANDLE, CorInfoInline, const char *)
                // 0B: bool canTailCall(CORINFO_METHOD_HANDLE, CORINFO_METHOD_HANDLE, CORINFO_METHOD_HANDLE, bool)
                // 0C: void reportTailCallDecision(CORINFO_METHOD_HANDLE, CORINFO_METHOD_HANDLE, bool, CorInfoTailCall, const char *)
                // 0D: void getEHinfo(CORINFO_METHOD_HANDLE, unsigned int, CORINFO_EH_CLAUSE *)
                // 0E: CORINFO_CLASS_HANDLE getMethodClass(CORINFO_METHOD_HANDLE)
                // 0F: void getMethodVTableOffset(CORINFO_METHOD_HANDLE, unsigned int *, unsigned int *, bool *)
                // 10: bool resolveVirtualMethod(CORINFO_DEVIRTUALIZATION_INFO *)
                // 11: CORINFO_METHOD_HANDLE getUnboxedEntry(CORINFO_METHOD_HANDLE, bool *)
                // 12: CORINFO_CLASS_HANDLE getDefaultComparerClass(CORINFO_CLASS_HANDLE)
                // 13: CORINFO_CLASS_HANDLE getDefaultEqualityComparerClass(CORINFO_CLASS_HANDLE)
                // 14: void expandRawHandleIntrinsic(CORINFO_RESOLVED_TOKEN *, CORINFO_METHOD_HANDLE, CORINFO_GENERICHANDLE_RESULT *)
                // 15: bool isIntrinsicType(CORINFO_CLASS_HANDLE)
                // 16: CorInfoCallConvExtension getUnmanagedCallConv(CORINFO_METHOD_HANDLE, CORINFO_SIG_INFO *, bool *)
                // 17: bool pInvokeMarshalingRequired(CORINFO_METHOD_HANDLE, CORINFO_SIG_INFO *)
                // 18: bool satisfiesMethodConstraints(CORINFO_CLASS_HANDLE, CORINFO_METHOD_HANDLE)
                // 19: void methodMustBeLoadedBeforeCodeIsRun(CORINFO_METHOD_HANDLE)
                // 1A: void getGSCookie(GSCookie *, GSCookie **)
                // 1B: void setPatchpointInfo(PatchpointInfo *)
                // 1C: PatchpointInfo * getOSRInfo(unsigned int *)
                // 1D: void resolveToken(CORINFO_RESOLVED_TOKEN *)
                // 1E: void findSig(CORINFO_MODULE_HANDLE, unsigned int, CORINFO_CONTEXT_HANDLE, CORINFO_SIG_INFO *)
                // 1F: void findCallSiteSig(CORINFO_MODULE_HANDLE, unsigned int, CORINFO_CONTEXT_HANDLE, CORINFO_SIG_INFO *)
                // 20: CORINFO_CLASS_HANDLE getTokenTypeAsHandle(CORINFO_RESOLVED_TOKEN *)
                // 21: int getStringLiteral(CORINFO_MODULE_HANDLE, unsigned int, char16_t *, int, int)
                // 22: size_t printObjectDescription(CORINFO_OBJECT_HANDLE, char *, size_t, size_t *)
                // 23: CorInfoType asCorInfoType(CORINFO_CLASS_HANDLE)
                // 24: const char * getClassNameFromMetadata(CORINFO_CLASS_HANDLE, const char **)
                // 25: CORINFO_CLASS_HANDLE getTypeInstantiationArgument(CORINFO_CLASS_HANDLE, unsigned int)
                // 26: size_t printClassName(CORINFO_CLASS_HANDLE, char *, size_t, size_t *)
                // 27: bool isValueClass(CORINFO_CLASS_HANDLE)
                // 28: uint32_t getClassAttribs(CORINFO_CLASS_HANDLE)
                // 29: const char * getClassAssemblyName(CORINFO_CLASS_HANDLE)
                // 2A: void * LongLifetimeMalloc(size_t)
                // 2B: void LongLifetimeFree(void *)
                // 2C: bool getIsClassInitedFlagAddress(CORINFO_CLASS_HANDLE, CORINFO_CONST_LOOKUP *, int *)
                // 2D: size_t getClassStaticDynamicInfo(CORINFO_CLASS_HANDLE)
                // 2E: size_t getClassThreadStaticDynamicInfo(CORINFO_CLASS_HANDLE)
                // 2F: bool getStaticBaseAddress(CORINFO_CLASS_HANDLE, bool, CORINFO_CONST_LOOKUP *)
                // 30: unsigned int getClassSize(CORINFO_CLASS_HANDLE)
                // 31: unsigned int getHeapClassSize(CORINFO_CLASS_HANDLE)
                // 32: bool canAllocateOnStack(CORINFO_CLASS_HANDLE)
                // 33: unsigned int getClassAlignmentRequirement(CORINFO_CLASS_HANDLE, bool)
                // 34: unsigned int getClassGClayout(CORINFO_CLASS_HANDLE, uint8_t *)
                // 35: unsigned int getClassNumInstanceFields(CORINFO_CLASS_HANDLE)
                // 36: CORINFO_FIELD_HANDLE getFieldInClass(CORINFO_CLASS_HANDLE, int32_t)
                // 37: GetTypeLayoutResult getTypeLayout(CORINFO_CLASS_HANDLE, CORINFO_TYPE_LAYOUT_NODE *, size_t *)
                // 38: bool checkMethodModifier(CORINFO_METHOD_HANDLE, const char *, bool)
                // 39: CorInfoHelpFunc getNewHelper(CORINFO_CLASS_HANDLE, bool *)
                // 3A: CorInfoHelpFunc getNewArrHelper(CORINFO_CLASS_HANDLE)
                // 3B: CorInfoHelpFunc getCastingHelper(CORINFO_RESOLVED_TOKEN *, bool)
                // 3C: CorInfoHelpFunc getSharedCCtorHelper(CORINFO_CLASS_HANDLE)
                // 3D: CORINFO_CLASS_HANDLE getTypeForBox(CORINFO_CLASS_HANDLE)
                // 3E: CORINFO_CLASS_HANDLE getTypeForBoxOnStack(CORINFO_CLASS_HANDLE)
                // 3F: CorInfoHelpFunc getBoxHelper(CORINFO_CLASS_HANDLE)
                // 40: CorInfoHelpFunc getUnBoxHelper(CORINFO_CLASS_HANDLE)
                // 41: CORINFO_OBJECT_HANDLE getRuntimeTypePointer(CORINFO_CLASS_HANDLE)
                // 42: bool isObjectImmutable(CORINFO_OBJECT_HANDLE)
                // 43: bool getStringChar(CORINFO_OBJECT_HANDLE, int, uint16_t *)
                // 44: CORINFO_CLASS_HANDLE getObjectType(CORINFO_OBJECT_HANDLE)
                // 45: bool getReadyToRunHelper(CORINFO_RESOLVED_TOKEN *, CORINFO_LOOKUP_KIND *, CorInfoHelpFunc, CORINFO_METHOD_HANDLE, CORINFO_CONST_LOOKUP *)
                // 46: void getReadyToRunDelegateCtorHelper(CORINFO_RESOLVED_TOKEN *, mdToken, CORINFO_CLASS_HANDLE, CORINFO_METHOD_HANDLE, CORINFO_LOOKUP *)
                // 47: CorInfoInitClassResult initClass(CORINFO_FIELD_HANDLE, CORINFO_METHOD_HANDLE, CORINFO_CONTEXT_HANDLE)
                // 48: void classMustBeLoadedBeforeCodeIsRun(CORINFO_CLASS_HANDLE)
                // 49: CORINFO_CLASS_HANDLE getBuiltinClass(CorInfoClassId)
                // 4A: CorInfoType getTypeForPrimitiveValueClass(CORINFO_CLASS_HANDLE)
                // 4B: CorInfoType getTypeForPrimitiveNumericClass(CORINFO_CLASS_HANDLE)
                // 4C: bool canCast(CORINFO_CLASS_HANDLE, CORINFO_CLASS_HANDLE)
                // 4D: TypeCompareState compareTypesForCast(CORINFO_CLASS_HANDLE, CORINFO_CLASS_HANDLE)
                // 4E: TypeCompareState compareTypesForEquality(CORINFO_CLASS_HANDLE, CORINFO_CLASS_HANDLE)
                // 4F: bool isMoreSpecificType(CORINFO_CLASS_HANDLE, CORINFO_CLASS_HANDLE)
                // 50: bool isExactType(CORINFO_CLASS_HANDLE)
                // 51: TypeCompareState isGenericType(CORINFO_CLASS_HANDLE)
                // 52: TypeCompareState isNullableType(CORINFO_CLASS_HANDLE)
                // 53: TypeCompareState isEnum(CORINFO_CLASS_HANDLE, CORINFO_CLASS_HANDLE *)
                // 54: CORINFO_CLASS_HANDLE getParentType(CORINFO_CLASS_HANDLE)
                // 55: CorInfoType getChildType(CORINFO_CLASS_HANDLE, CORINFO_CLASS_HANDLE *)
                // 56: bool isSDArray(CORINFO_CLASS_HANDLE)
                // 57: unsigned int getArrayRank(CORINFO_CLASS_HANDLE)
                // 58: CorInfoArrayIntrinsic getArrayIntrinsicID(CORINFO_METHOD_HANDLE)
                // 59: void * getArrayInitializationData(CORINFO_FIELD_HANDLE, uint32_t)
                // 5A: CorInfoIsAccessAllowedResult canAccessClass(CORINFO_RESOLVED_TOKEN *, CORINFO_METHOD_HANDLE, CORINFO_HELPER_DESC *)
                // 5B: size_t printFieldName(CORINFO_FIELD_HANDLE, char *, size_t, size_t *)
                // 5C: CORINFO_CLASS_HANDLE getFieldClass(CORINFO_FIELD_HANDLE)
                // 5D: CorInfoType getFieldType(CORINFO_FIELD_HANDLE, CORINFO_CLASS_HANDLE *, CORINFO_CLASS_HANDLE)
                // 5E: unsigned int getFieldOffset(CORINFO_FIELD_HANDLE)
                // 5F: void getFieldInfo(CORINFO_RESOLVED_TOKEN *, CORINFO_METHOD_HANDLE, CORINFO_ACCESS_FLAGS, CORINFO_FIELD_INFO *)
                // 60: uint32_t getThreadLocalFieldInfo(CORINFO_FIELD_HANDLE, bool)
                // 61: void getThreadLocalStaticBlocksInfo(CORINFO_THREAD_STATIC_BLOCKS_INFO *)
                // 62: void getThreadLocalStaticInfo_NativeAOT(CORINFO_THREAD_STATIC_INFO_NATIVEAOT *)
                // 63: bool isFieldStatic(CORINFO_FIELD_HANDLE)
                // 64: int getArrayOrStringLength(CORINFO_OBJECT_HANDLE)
                // 65: void getBoundaries(CORINFO_METHOD_HANDLE, unsigned int *, uint32_t **, ICorDebugInfo::BoundaryTypes *)
                // 66: void setBoundaries(CORINFO_METHOD_HANDLE, uint32_t, ICorDebugInfo::OffsetMapping *)
                // 67: void getVars(CORINFO_METHOD_HANDLE, uint32_t *, ICorDebugInfo::ILVarInfo **, bool *)
                // 68: void setVars(CORINFO_METHOD_HANDLE, uint32_t, ICorDebugInfo::NativeVarInfo *)
                // 69: void reportRichMappings(ICorDebugInfo::InlineTreeNode *, uint32_t, ICorDebugInfo::RichOffsetMapping *, uint32_t)
                // 6A: void reportMetadata(const char *, const void *, size_t)
                // 6B: void * allocateArray(size_t)
                // 6C: void freeArray(void *)
                // 6D: CORINFO_ARG_LIST_HANDLE getArgNext(CORINFO_ARG_LIST_HANDLE)
                // 6E: CorInfoTypeWithMod getArgType(CORINFO_SIG_INFO *, CORINFO_ARG_LIST_HANDLE, CORINFO_CLASS_HANDLE *)
                // 6F: int getExactClasses(CORINFO_CLASS_HANDLE, int, CORINFO_CLASS_HANDLE *)
                // 70: CORINFO_CLASS_HANDLE getArgClass(CORINFO_SIG_INFO *, CORINFO_ARG_LIST_HANDLE)
                // 71: CorInfoHFAElemType getHFAType(CORINFO_CLASS_HANDLE)
                // 72: bool runWithErrorTrap(errorTrapFunction, void *)
                // 73: bool runWithSPMIErrorTrap(errorTrapFunction, void *)
                // 74: void getEEInfo(CORINFO_EE_INFO *)
                // 75: const char16_t * getJitTimeLogFilename()
                // 76: mdMethodDef getMethodDefFromMethod(CORINFO_METHOD_HANDLE)
                // 77: size_t printMethodName(CORINFO_METHOD_HANDLE, char *, size_t, size_t *)
                // 78: const char * getMethodNameFromMetadata(CORINFO_METHOD_HANDLE, const char **, const char **, const char **, size_t)
                // 79: unsigned int getMethodHash(CORINFO_METHOD_HANDLE)
                // 7A: bool getSystemVAmd64PassStructInRegisterDescriptor(CORINFO_CLASS_HANDLE, SYSTEMV_AMD64_CORINFO_STRUCT_REG_PASSING_DESCRIPTOR *)
                // 7B: void getSwiftLowering(CORINFO_CLASS_HANDLE, CORINFO_SWIFT_LOWERING *)
                // 7C: void getFpStructLowering(CORINFO_CLASS_HANDLE, CORINFO_FPSTRUCT_LOWERING *)
                //
                // src\coreclr\inc\corinfo.h:3029
                // class ICorDynamicInfo
                // 7D: uint32_t getThreadTLSIndex(void **)
                // 7E: int32_t * getAddrOfCaptureThreadGlobal(void **)
                // 7F: void * getHelperFtn(CorInfoHelpFunc, void **)
                // 80: void getFunctionEntryPoint(CORINFO_METHOD_HANDLE, CORINFO_CONST_LOOKUP *, CORINFO_ACCESS_FLAGS)
                // 81: void getFunctionFixedEntryPoint(CORINFO_METHOD_HANDLE, bool, CORINFO_CONST_LOOKUP *)
                // 82: void * getMethodSync(CORINFO_METHOD_HANDLE, void **)
                // 83: CorInfoHelpFunc getLazyStringLiteralHelper(CORINFO_MODULE_HANDLE)
                // 84: CORINFO_MODULE_HANDLE embedModuleHandle(CORINFO_MODULE_HANDLE, void **)
                // 85: CORINFO_CLASS_HANDLE embedClassHandle(CORINFO_CLASS_HANDLE, void **)
                // 86: CORINFO_METHOD_HANDLE embedMethodHandle(CORINFO_METHOD_HANDLE, void **)
                // 87: CORINFO_FIELD_HANDLE embedFieldHandle(CORINFO_FIELD_HANDLE, void **)
                // 88: void embedGenericHandle(CORINFO_RESOLVED_TOKEN *, bool, CORINFO_METHOD_HANDLE, CORINFO_GENERICHANDLE_RESULT *)
                // 89: void getLocationOfThisType(CORINFO_METHOD_HANDLE, CORINFO_LOOKUP_KIND *)
                // 8A: void getAddressOfPInvokeTarget(CORINFO_METHOD_HANDLE, CORINFO_CONST_LOOKUP *)
                // 8B: void * GetCookieForPInvokeCalliSig(CORINFO_SIG_INFO *, void **)
                // 8C: bool canGetCookieForPInvokeCalliSig(CORINFO_SIG_INFO *)
                // 8D: CORINFO_JUST_MY_CODE_HANDLE getJustMyCodeHandle(CORINFO_METHOD_HANDLE, CORINFO_JUST_MY_CODE_HANDLE **)
                // 8E: void GetProfilingHandle(bool *, void **, bool *)
                // 8F: void getCallInfo(CORINFO_RESOLVED_TOKEN *, CORINFO_RESOLVED_TOKEN *, CORINFO_METHOD_HANDLE, CORINFO_CALLINFO_FLAGS, CORINFO_CALL_INFO *)
                // 90: bool getStaticFieldContent(CORINFO_FIELD_HANDLE, uint8_t *, int, int, bool)
                // 91: bool getObjectContent(CORINFO_OBJECT_HANDLE, uint8_t *, int, int)
                // 92: CORINFO_CLASS_HANDLE getStaticFieldCurrentClass(CORINFO_FIELD_HANDLE, bool *)
                // 93: CORINFO_VARARGS_HANDLE getVarArgsHandle(CORINFO_SIG_INFO *, void **)
                // 94: bool canGetVarArgsHandle(CORINFO_SIG_INFO *)
                // 95: InfoAccessType constructStringLiteral(CORINFO_MODULE_HANDLE, mdToken, void **)
                // 96: InfoAccessType emptyStringLiteral(void **)
                // 97: uint32_t getFieldThreadLocalStoreID(CORINFO_FIELD_HANDLE, void **)
                // 98: CORINFO_METHOD_HANDLE GetDelegateCtor(CORINFO_METHOD_HANDLE, CORINFO_CLASS_HANDLE, CORINFO_METHOD_HANDLE, DelegateCtorArgs *)
                // 99: void MethodCompileComplete(CORINFO_METHOD_HANDLE)
                // 9A: bool getTailCallHelpers(CORINFO_RESOLVED_TOKEN *, CORINFO_SIG_INFO *, CORINFO_GET_TAILCALL_HELPERS_FLAGS, CORINFO_TAILCALL_HELPERS *)
                // 9B: bool convertPInvokeCalliToCall(CORINFO_RESOLVED_TOKEN *, bool)
                // 9C: bool notifyInstructionSetUsage(CORINFO_InstructionSet, bool)
                // 9D: void updateEntryPointForTailCall(CORINFO_CONST_LOOKUP *)
                //
                // src\coreclr\inc\corjit.h:166
                // class ICorJitInfo
                // 9E: void allocMem(AllocMemArgs *)
                public const int AllocMemIndex = 0x9E;
                // 9F: void reserveUnwindInfo(bool, bool, uint32_t)
                // A0: void allocUnwindInfo(uint8_t *, uint8_t *, uint32_t, uint32_t, uint32_t, uint8_t *, CorJitFuncKind)
                // A1: void * allocGCInfo(size_t)
                // A2: void setEHcount(unsigned int)
                // A3: void setEHinfo(unsigned int, const CORINFO_EH_CLAUSE *)
                // A4: bool logMsg(unsigned int, const char *, va_list)
                // A5: int doAssert(const char *, int, const char *)
                // A6: void reportFatalError(CorJitResult)
                // A7: JITINTERFACE_HRESULT getPgoInstrumentationResults(CORINFO_METHOD_HANDLE, PgoInstrumentationSchema **, uint32_t *, uint8_t **, PgoSource *, bool *)
                // A8: JITINTERFACE_HRESULT allocPgoInstrumentationBySchema(CORINFO_METHOD_HANDLE, PgoInstrumentationSchema *, uint32_t, uint8_t **)
                // A9: void recordCallSite(uint32_t, CORINFO_SIG_INFO *, CORINFO_METHOD_HANDLE)
                // AA: void recordRelocation(void *, void *, void *, uint16_t, int32_t)
                // AB: uint16_t getRelocTypeHint(void *)
                // AC: uint32_t getExpectedTargetArchitecture()
                // AD: uint32_t getJitFlags(CORJIT_FLAGS *, uint32_t)

                public const int TotalVtableCount = 0xAE;
            }
        }
    }
}
