#include "include/windowTools.h"

DLL_EXPORT int PutInOtherWindow(HWND SetOfHandle, HWND Foundation) {
	LONG_PTR ws = ::GetWindowLongPtr(Foundation, GWL_STYLE);
	ws &= ~(WS_CAPTION | WS_SIZEBOX);
	::SetWindowLongPtr(Foundation, GWL_STYLE, ws);
	HWND res = ::SetParent(Foundation, SetOfHandle);
	if (res == NULL) return 1;
	RECT rc;
	::GetClientRect(SetOfHandle, &rc);
	int width = rc.right - rc.left;
	int height = rc.bottom - rc.top;
	::SetWindowPos(Foundation, NULL, 0, 0, width, height, SWP_NOZORDER);

	return 0;
}
