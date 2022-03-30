#pragma once
#include "thetaLib.h"
#include "AllMemory.h"
#include "opening_frames.h"

using namespace System;
//using namespace System::Windows;
using namespace System::Windows::Forms;

class ControlManagerBase {

private:
	std::vector<Mat> preview_video_data;

public:
	~ControlManagerBase(void);

	std::vector<Mat>* GetPreviewVideoData(void);

};

namespace thetaLib {
namespace MemoryScope {
namespace Controls {

	public ref class ControlManager {

	private:
		ControlManagerBase* cmBase;

		Control^ control = nullptr;
		HWND hwnd = nullptr;

		int video_frame_length = 0;
		//stream_data sdata = (stream_data*)malloc(sizeof(stream_data));
		//decoder_data ddata = (decoder_data*)malloc(sizeof(decoder_data));

	public:

		ControlManager(Control^ control);
		~ControlManager(void);

		int OpenVideo(double opening_size);
		System::Int32 GetVideoFrames(void);

		void ShowMat(int framenum);

	};

}
}
}
