#include "include\controlMan.h"

namespace thetaLib {
namespace MemoryScope {
namespace Controls {

	ControlManager::ControlManager(Control^ control) {

		this->control = control;
		this->hwnd = (HWND)control->Handle.ToInt32();

	}

	std::vector<Mat> video_data;

	void ControlManager::OpenVideo(void) {

		char* f = "E:\\";
		c_str filepath(f, sizeof(f) / sizeof(f[0]));

		char* got_file = ShowFileFialog(this->hwnd, filepath);
		if (got_file == nullptr) return;

		std::vector<AVFrame*> frames;
		decode_data data;
		
		all_error err = decode(got_file, &frames, &data);
		if (err != NOT_ERROR) return;

		//std::vector<Mat> mats;

		video_frame_length = frames.size();

		for each (auto i in frames) {

			Mat dst;
			Frame2Mat(i, &dst);
			video_data.push_back(dst);
			av_frame_free(&i);
			dst.release();

		}

		ShowMat(0);

	}
	System::Int32 ControlManager::GetVideoFrames(void) {
		printf("length : %d\n", video_frame_length);
		return video_frame_length;
	}

	void ControlManager::ShowMat(int framenum) {

		HDC hdc = GetDC(this->hwnd);

		const int x = video_data[framenum].cols;
		const int y = video_data[framenum].rows;

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
			video_data[framenum].cols, video_data[framenum].rows,
			video_data[framenum].data,
			&bitInfo,
			DIB_RGB_COLORS,
			SRCCOPY
		);

	}

}
}
}
