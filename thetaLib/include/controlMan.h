#pragma once
#include "thetaLib.h"
#include "AllMemory.h"
#include "opening_frames.h"
#include "PreviewWindow.h"

using namespace System;
//using namespace System::Windows;
using namespace System::Windows::Forms;

class ControlManagerBase {

private:
	std::vector<Mat> preview_video_data;

public:
	ControlManagerBase(void);
	~ControlManagerBase(void);

	void MatToGL(Mat* mat, HWND hwnd);

	std::vector<Mat>* GetPreviewVideoData(void);
	Mat* GetFrameMat(int frame);

};

namespace thetaLib {
namespace MemoryScope {
namespace Controls {

	public ref class ControlManager {

	private:
		// memorys management
		ControlManagerBase* cmBase;
		PreviewWindow* pWin;

		Control^ control = nullptr;
		HWND hwnd = nullptr;

		int video_frame_length = 0;

	public:

		#pragma region Constructor and Destructor
		ControlManager(Control^ control);
		~ControlManager(void);
		#pragma endregion

		int OpenVideo(double opening_size);
		
		#pragma region Getter
		System::Int32 GetVideoFrames(void);
		#pragma endregion

		void ShowMat(int framenum);

	};

}
}
}
