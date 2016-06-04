#include <windows.h>
#include <iostream>
#ifdef __cplusplus
extern "C" {
#endif
HHOOK hHKeyBrd = NULL;
LRESULT CALLBACK KeyBrdProc(int nCode, WPARAM wParam, LPARAM lParam)
{
    if (nCode >= 0){
        MessageBox(NULL,"Hook","Information",MB_OK);
    }
    return CallNextHookEx (hHKeyBrd,nCode,wParam,lParam);
}
__declspec(dllexport) bool SetHooks(HINSTANCE hModule)
{
    hHKeyBrd = SetWindowsHookEx(WH_KEYBOARD, KeyBrdProc, (HINSTANCE) hModule, NULL);
    return true; 
}
__declspec(dllexport) bool UnHook()
{
    return true;
}
#ifdef __cplusplus
}
#endif
