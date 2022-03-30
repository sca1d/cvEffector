#include "include/opening_frames.h"

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