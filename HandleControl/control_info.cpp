#include "control_info.h"

/*
Mat ui_info::hwnd2mat(HWND hwnd) {

	HDC hDC, hCompatibleDC;

	int w, h, src_w, src_h;
	HBITMAP hbWin;
	Mat src;
	BITMAPINFOHEADER bi;

	hDC = GetDC(hwnd);
	hCompatibleDC = CreateCompatibleDC(hDC);
	SetStretchBltMode(hCompatibleDC, COLORONCOLOR);

	RECT winSize;
	GetClientRect(hwnd, &winSize);

	src_w = winSize.right;
	src_h = winSize.bottom;
	h = winSize.bottom / 2;
	w = winSize.right / 2;

	src.create(h, w, CV_8UC4);

	hbWin = CreateCompatibleBitmap(hDC, w, h);
	bi.biSize = sizeof(BITMAPINFOHEADER);
	bi.biWidth = w;
	bi.biHeight = -h;
	bi.biPlanes = 1;
	bi.biBitCount = 32;
	bi.biCompression = BI_RGB;
	bi.biSizeImage = 0;
	bi.biXPelsPerMeter = 0;
	bi.biYPelsPerMeter = 0;
	bi.biClrUsed = 0;
	bi.biClrImportant = 0;

	SelectObject(hCompatibleDC, hbWin);

	StretchBlt(hCompatibleDC, 0, 0, w, h, hDC, 0, 0, src_w, src_h, SRCCOPY);
	GetDIBits(hCompatibleDC, hbWin, 0, h, src.data, (BITMAPINFO*)&bi, DIB_RGB_COLORS);

	DeleteObject(hbWin);

	return src;

}
*/
