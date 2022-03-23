#include "ui_info.h"

using namespace System;
using namespace System::Drawing;
//using namespace System::ComponentModel;
//using namespace System::Windows;
//using namespace System::Windows::Forms;

using System::String;

namespace uiplg {

	ui_info::ui_info(System::Windows::Forms::Control^ c) {

		this->control = c;
		Mat src;
		hwnd2mat((HWND)c->Handle.ToInt32(), &src);
		cv::randn(src, 200, 200);
		imshow("test", src);
		mat2hwnd(&src, (HWND)c->Handle.ToInt32());

	}

	void ui_info::hwnd2mat(HWND hwnd, Mat* src) {

		HDC hDC, hCompatibleDC;

		int w, h, src_w, src_h;
		HBITMAP hbWin;
		BITMAPINFOHEADER bi;

		hDC = GetDC(hwnd);
		hCompatibleDC = CreateCompatibleDC(hDC);
		SetStretchBltMode(hCompatibleDC, COLORONCOLOR);

		RECT winSize;
		GetClientRect(hwnd, &winSize);

		src_w = winSize.right;
		src_h = winSize.bottom;
		h = winSize.bottom;
		w = winSize.right;

		src->create(h, w, CV_8UC4);

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
		GetDIBits(hCompatibleDC, hbWin, 0, h, src->data, (BITMAPINFO*)&bi, DIB_RGB_COLORS);

		DeleteObject(hbWin);

		/*
		TextOut(hDC, 0, 0, TEXT("test"), lstrlen(TEXT("test")));
		//SetBkColor(hDC, RGB(0xFF, 0, 0));
		SetWindowText(hwnd, TEXT("TEST"));
		*/

	}

	void ui_info::mat2hwnd(Mat* src, HWND hwnd) {

		HDC hdc = GetDC(hwnd);

		const int x = src->cols;
		const int y = src->rows;

		BITMAPINFO bitInfo;
		bitInfo.bmiHeader.biBitCount = 24;
		bitInfo.bmiHeader.biWidth = x;
		bitInfo.bmiHeader.biHeight = -y;
		bitInfo.bmiHeader.biPlanes = 1;
		bitInfo.bmiHeader.biSize = sizeof(BITMAPINFOHEADER);
		bitInfo.bmiHeader.biCompression = BI_RGB;
		bitInfo.bmiHeader.biClrImportant = 0;
		bitInfo.bmiHeader.biClrUsed = 0;
		bitInfo.bmiHeader.biSizeImage = 0;
		bitInfo.bmiHeader.biXPelsPerMeter = 0;
		bitInfo.bmiHeader.biYPelsPerMeter = 0;

		StretchDIBits(
			hdc,
			0, 0,
			this->control->Size.Width, this->control->Size.Height,
			0, 0,
			x, y,
			src->data,
			&bitInfo,
			DIB_RGB_COLORS,
			SRCCOPY
		);

	}

}