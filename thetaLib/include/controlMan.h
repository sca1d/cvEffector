#pragma once
#include "thetaLib.h"
#include "AllMemory.h"

using namespace System;
using namespace System::Windows;
using namespace System::Windows::Forms;

namespace thetaLib {
namespace MemoryScope {
namespace Controls {

	public ref class ControlManager {

	private:
		Control^ control = nullptr;
		HWND hwnd = nullptr;

		int video_frame_length = 0;

	public:

		ControlManager(Control^ control);

		void OpenVideo(void);
		System::Int32 GetVideoFrames(void);

		void ShowMat(int framenum);

	};

}
}
}
