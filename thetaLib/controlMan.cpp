#include "include\controlMan.h"

all_error opening_frames(AVFormatContext* format_context, AVStream* video_stream, AVCodecContext* codec_context, AVFrame* frame, std::vector<Mat>* frames, void* custom) {

	if (frame == NULL) {
		frame = av_frame_alloc();
	}

	double* d = reinterpret_cast<double*>(custom);

	AVPacket packet = AVPacket();
	Mat dst;
	while (av_read_frame(format_context, &packet) == 0) {
		if (packet.stream_index == video_stream->index) {
			if (avcodec_send_packet(codec_context, &packet) != 0) {
				return CAN_NOT_SEND_PACKET;
			}
			while (avcodec_receive_frame(codec_context, frame) == 0) {

				AVFrame* new_frame = av_frame_alloc();
				av_frame_ref(new_frame, frame);
				Frame2Mat(new_frame, &dst);
				cv::resize(dst, dst, cv::Size(), *d, *d);
				frames->push_back(dst);
				av_frame_free(&new_frame);

			}
		}
		av_packet_unref(&packet);
	}
	dst.release();

	//av_frame_free(&frame);

	return NOT_ERROR;

}

#pragma region ControlManagerBase
/*
ControlManagerBase::~ControlManagerBase(void) {
	free_data();
}

all_error ControlManagerBase::get_video_headers(char* filepath) {

	all_error err = NOT_ERROR;

	err = get_streams(filepath, &sdata);
	CHECK_ERR(err);

	printf("den:%d, num:%d\n", sdata.time_base.den, sdata.time_base.num);

	err = make_decoder(&sdata, &ddata);
	CHECK_ERR(err);

}

AVFrame* ControlManagerBase::get_video_frame(int framenum) {

	all_error err = NOT_ERROR;

	AVFrame* frame = av_frame_alloc();
	err = seekFrame(&sdata, ddata.codec_context, framenum * this->sdata.time_base.den, frame);
	if (err != NOT_ERROR) return nullptr;

	return frame;

}

void ControlManagerBase::free_data(void) {

	avcodec_free_context(&ddata.codec_context);
	avformat_close_input(&sdata.format_context);

}

stream_data ControlManagerBase::get_stream_data(void) {
	return this->sdata;
}

decoder_data ControlManagerBase::get_decoder_data(void) {
	return this->ddata;
}
*/
#pragma endregion

namespace thetaLib {
namespace MemoryScope {
namespace Controls {

	std::vector<Mat> video_data;

	ControlManager::ControlManager(Control^ control) {

		//this->cmBase = new ControlManagerBase();

		this->control = control;
		this->hwnd = (HWND)control->Handle.ToInt32();

	}
	ControlManager::~ControlManager(void) {
		video_data.clear();
		//this->cmBase->~ControlManagerBase();
	}

	int ControlManager::OpenVideo(double opening_size) {

		opening_size = opening_size <= 0.0 ? 1.0 : 1.0 < opening_size ? 1.0 : opening_size;

		char* f = "E:\\";
		c_str filepath(f, sizeof(f) / sizeof(f[0]));

		char* got_file = ShowFileFialog(this->hwnd, filepath);
		if (got_file == nullptr) return all_error::CAN_NOT_OPENED_FILE;
		
		decode_data data;

		all_error err = decodeMat(got_file, &video_data, &data, opening_frames, (void*)(&opening_size));
		CHECK_ERR(err);

		//std::vector<Mat> mats;

		video_frame_length = video_data.size();

		ShowMat(0);

		return 0;

	}
	
	System::Int32 ControlManager::GetVideoFrames(void) {
		//AVRational t = this->cmBase->get_stream_data().time_base;
		return this->video_frame_length;//t.den / t.num;
	}

	void ControlManager::ShowMat(int framenum) {

		HDC hdc = GetDC(this->hwnd);
		cv::Mat* mat = &video_data[framenum];

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

	}

}
}
}
