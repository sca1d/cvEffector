#pragma once

#include <stdio.h>
#include <Windows.h>

#include "opencv2/opencv.hpp"

using namespace cv;

using namespace System;
using namespace System::Drawing;
//using namespace System::ComponentModel;
//using namespace System::Windows;
//using namespace System::Windows::Forms;

namespace uiplg {

	public ref class ui_info {

	private:
		System::Windows::Forms::Control^ control;

		void hwnd2mat(HWND hwnd, Mat* src);
		void mat2hwnd(Mat* src, HWND hwnd);

	public:
		ui_info(System::Windows::Forms::Control^ c);

	};

}