#include "Windows.h"
#include "DbgHelp.h"
#include <atlstr.h>
#include<iostream>
using namespace std;

int GenerateMiniDump(PEXCEPTION_POINTERS pExceptionPointers)
{
    // ���庯��ָ��
    typedef BOOL(WINAPI* MiniDumpWriteDumpT)(
        HANDLE,
        DWORD,
        HANDLE,
        MINIDUMP_TYPE,
        PMINIDUMP_EXCEPTION_INFORMATION,
        PMINIDUMP_USER_STREAM_INFORMATION,
        PMINIDUMP_CALLBACK_INFORMATION
        );
    // �� "DbgHelp.dll" ���л�ȡ "MiniDumpWriteDump" ����
    MiniDumpWriteDumpT pfnMiniDumpWriteDump = NULL;

    //HMODULE hDbgHelp = LoadLibrary(("DbgHelp.dll"));
    //LPCWSTR dllName = (LPCWSTR)("dbghelp.dll");
    char* szStr = (char*)"dbghelp.dll";
    WCHAR wszClassName[256];
    memset(wszClassName, 0, sizeof(wszClassName));
    MultiByteToWideChar(CP_ACP, 0, szStr, strlen(szStr) + 1, wszClassName,
        sizeof(wszClassName) / sizeof(wszClassName[0]));

    HMODULE hDbgHelp = LoadLibrary(wszClassName);
    if (NULL == hDbgHelp)
    {
        cout << "not get " << wszClassName << endl;

        return EXCEPTION_CONTINUE_EXECUTION;
    }
    pfnMiniDumpWriteDump = (MiniDumpWriteDumpT)GetProcAddress(hDbgHelp, "MiniDumpWriteDump");

    if (NULL == pfnMiniDumpWriteDump)
    {
        FreeLibrary(hDbgHelp);
        return EXCEPTION_CONTINUE_EXECUTION;
    }
    // ���� dmp �ļ���
    TCHAR szFileName[MAX_PATH] = { 0 };

    SYSTEMTIME stLocalTime;
    GetLocalTime(&stLocalTime);
    wsprintf(szFileName, L"DumpDemo_v1.0-%04d%02d%02d-%02d%02d%02d.dmp", stLocalTime.wYear, stLocalTime.wMonth, stLocalTime.wDay,
        stLocalTime.wHour, stLocalTime.wMinute, stLocalTime.wSecond);
    HANDLE hDumpFile = CreateFile(szFileName, GENERIC_READ | GENERIC_WRITE,
        FILE_SHARE_WRITE | FILE_SHARE_READ, 0, CREATE_ALWAYS, 0, 0);
    if (INVALID_HANDLE_VALUE == hDumpFile)
    {
        FreeLibrary(hDbgHelp);
        return EXCEPTION_CONTINUE_EXECUTION;
    }
    // д�� dmp �ļ�
    MINIDUMP_EXCEPTION_INFORMATION expParam;
    expParam.ThreadId = GetCurrentThreadId();
    expParam.ExceptionPointers = pExceptionPointers;
    expParam.ClientPointers = FALSE;
    pfnMiniDumpWriteDump(GetCurrentProcess(), GetCurrentProcessId(),
        hDumpFile, MiniDumpWithDataSegs, (pExceptionPointers ? &expParam : NULL), NULL, NULL);
    // �ͷ��ļ�
    CloseHandle(hDumpFile);
    FreeLibrary(hDbgHelp);
    return EXCEPTION_EXECUTE_HANDLER;
}

LONG WINAPI ExceptionFilter(LPEXCEPTION_POINTERS lpExceptionInfo)
{
    // ������һЩ�쳣�Ĺ��˻���ʾ
    std::cout << "ExceptionFilter start" << endl;
    if (IsDebuggerPresent())
    {
        std::cout << "IsDebuggerPresent" << endl;
        return EXCEPTION_CONTINUE_SEARCH;
    }
    return GenerateMiniDump(lpExceptionInfo);
}

int main3()
{
    // �������dump�ļ�����
    SetUnhandledExceptionFilter(ExceptionFilter);
    // ʹ����������� Dump �ļ�
    std::cout << "bug start" << endl;
    int* p = nullptr;
    *p = 1;
    std::cout << "bug end" << endl;
    return 0;
}