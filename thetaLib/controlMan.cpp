#include "include\controlMan.h"

#pragma region ControlManagerBase
ControlManagerBase::ControlManagerBase(void) {

}
ControlManagerBase::~ControlManagerBase(void) {
	this->preview_video_data.clear();
}

void ControlManagerBase::MatToGL(Mat* mat, HWND hwnd) {

}

std::vector<Mat>* ControlManagerBase::GetPreviewVideoData(void) {
	return &this->preview_video_data;
}

Mat* ControlManagerBase::GetFrameMat(int frame) {
	return 0 <= frame ? frame < this->preview_video_data.size() ? &this->preview_video_data[frame] : nullptr : nullptr;
}
#pragma endregion

namespace thetaLib {
namespace MemoryScope {
namespace Controls {

	ControlManager::ControlManager(Control^ control) {

		this->control = control;
		this->hwnd = (HWND)control->Handle.ToInt32();

		this->cmBase = new ControlManagerBase();
		this->pWin = new PreviewWindow(control);

	}
	ControlManager::ControlManager(Control^ control, Control^ parent_window) {

		this->control = control;
		this->hwnd = (HWND)parent_window->Handle.ToInt32();

		this->cmBase = new ControlManagerBase();
		this->pWin = new PreviewWindow(control);

	}
	ControlManager::~ControlManager(void) {
		//video_data.clear();
		delete this->cmBase;
		delete this->pWin;
	}

	int ControlManager::OpenVideo(double opening_size) {

		opening_size = opening_size <= 0.0 ? 1.0 : 1.0 < opening_size ? 1.0 : opening_size;

		char* f = "E:\\";
		c_str filepath(f, sizeof(f) / sizeof(f[0]));

		char* got_file = ShowFileFialog(this->hwnd, filepath);
		if (got_file == nullptr) return all_error::CAN_NOT_OPENED_FILE;
		
		decode_data data;
		std::vector<Mat>* preview_video_data = this->cmBase->GetPreviewVideoData();

		all_error err = decodeMat(got_file, preview_video_data, &data, opening_frames, (void*)(&opening_size));
		CHECK_ERR(err);

		//std::vector<Mat> mats;

		video_frame_length = preview_video_data->size();

		ShowMat(0);

		return 0;

	}
	
	System::Int32 ControlManager::GetVideoFrames(void) {
		//AVRational t = this->cmBase->get_stream_data().time_base;
		return this->video_frame_length;//t.den / t.num;
	}

	void ControlManager::Update(void) {
		this->pWin->WindowUpdate();
	}
	void ControlManager::ShowMat(int framenum) {

		/*
		HDC hdc = GetDC(this->hwnd);
		cv::Mat* mat = this->cmBase->GetFrameMat(framenum);
		if (mat == nullptr) return;

		const int x = mat->cols;
		const int y = mat->rows;

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
			mat->cols, mat->rows,
			mat->data,
			&bitInfo,
			DIB_RGB_COLORS,
			SRCCOPY
		);
		*/

		cv::Mat* mat = this->cmBase->GetFrameMat(framenum);
		if (mat == nullptr) return;

		this->pWin->ReDraw(mat);

	}

}
}
}
