#pragma once
#include "thetaLib.h"

using namespace System;
using namespace System::Windows;
using namespace System::Windows::Forms;

namespace thetaLib {

	public ref class ControlManager {

	private:
		Control^ control = nullptr;
		HWND hwnd = nullptr;

	public:

		ControlManager(Control^ control);

		void OpenVideo(void);

		void ShowMath(cv::Mat* mat);

	};

}
