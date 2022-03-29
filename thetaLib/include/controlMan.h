#pragma once
#include "thetaLib.h"
#include "AllMemory.h"

using namespace System;
//using namespace System::Windows;
using namespace System::Windows::Forms;

/*
class ControlManagerBase {

private:
	stream_data sdata;
	decoder_data ddata;

public:
	~ControlManagerBase(void);

	all_error get_video_headers(char* filepath);
	AVFrame* get_video_frame(int framenum);
	void free_data(void);

	stream_data get_stream_data(void);
	decoder_data get_decoder_data(void);

};
*/

namespace thetaLib {
namespace MemoryScope {
namespace Controls {

	public ref class ControlManager {

	private:
		//ControlManagerBase* cmBase;

		Control^ control = nullptr;
		HWND hwnd = nullptr;

		int video_frame_length = 0;
		//stream_data sdata = (stream_data*)malloc(sizeof(stream_data));
		//decoder_data ddata = (decoder_data*)malloc(sizeof(decoder_data));

	public:

		ControlManager(Control^ control);
		~ControlManager(void);

		int OpenVideo(void);
		System::Int32 GetVideoFrames(void);

		void ShowMat(int framenum);

	};

}
}
}
