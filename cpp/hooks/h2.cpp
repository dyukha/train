#include <windows.h>
#include <iostream>
#include <tchar.h>
#include <cstdio>
HHOOK hH;
typedef bool(*dllProc)(HINSTANCE);
int _tmain(int argc, _TCHAR* argv[])
{    
    HINSTANCE hDll;
    dllProc prAddr;
    const char *DllFile = "HookDll.dll";
    HINSTANCE  hModule = GetModuleHandle(DllFile);
    if ((hDll = LoadLibrary(DllFile))!=NULL){
        prAddr = (dllProc)GetProcAddress(hDll,"SetHooks");
    }else{
        printf("Can't load DLL");
        Sleep(3000);
        return 0;
    }
    (prAddr)(hDll);
    MSG msg;
    while (GetMessage(&msg, NULL, 0, 0))
    {
        TranslateMessage(&msg);
        DispatchMessage(&msg);
    }
    return 0;
}
