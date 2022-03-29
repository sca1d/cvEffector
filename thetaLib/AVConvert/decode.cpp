#include "decode.h"
#include "convert.h"

DLL_EXPORT all_error decode(const char* file_path, std::vector<AVFrame*>* frames, decode_data* data) {

	AVRational time_base;

	// open file
	AVFormatContext* format_context = nullptr;
	if (avformat_open_input(&format_context, file_path, nullptr, nullptr) != 0) {
		return CAN_NOT_OPENED_FILE;
	}

	// get video stream
	if (avformat_find_stream_info(format_context, nullptr) < 0) {
		return CAN_NOT_GET_STREAM;
	}

	// search video stream
	AVStream* video_stream = nullptr;
	for (int i = 0; i < (int)format_context->nb_streams; ++i) {
		if (format_context->streams[i]->codecpar->codec_type == AVMEDIA_TYPE_VIDEO) {
			video_stream = format_context->streams[i];
			break;
		}
	}
	if (video_stream == nullptr) {
		return VIDEO_STREAM_IS_NOT_FOUND;
	}

	// time base
	time_base = video_stream->time_base;

	// make decoder
	const AVCodec* codec = avcodec_find_decoder(video_stream->codecpar->codec_id);
	if (codec == nullptr) {
		return NOT_SUPPORTED_DECODER;
	}
	AVCodecContext* codec_context = avcodec_alloc_context3(codec);
	if (codec_context == nullptr) {
		return CAN_NOT_ALLOCED_CODEC;
	}
	if (avcodec_parameters_to_context(codec_context, video_stream->codecpar) < 0) {
		return CAN_NOT_COPYED_STREAMS;
	}
	if (avcodec_open2(codec_context, codec, nullptr) != 0) {
		return CAN_NOT_OPENED_CODEC;
	}

	// decode frames
	all_error flag = openFrames(format_context, video_stream, codec_context, frames);

	if (flag != NOT_ERROR) return flag;

	// clean up
	avcodec_free_context(&codec_context);
	avformat_close_input(&format_context);

	if (data != nullptr) {
		data->time_base = time_base;
		data->data = frames->at(0);
	}

	return NOT_ERROR;

}

/*
DLL_EXPORT all_error decodeMat(const char* file_path, std::vector<Mat>* frames, decode_data* data) {

	AVRational time_base;

	// open file
	AVFormatContext* format_context = nullptr;
	if (avformat_open_input(&format_context, file_path, nullptr, nullptr) != 0) {
		return CAN_NOT_OPENED_FILE;
	}

	// get video stream
	if (avformat_find_stream_info(format_context, nullptr) < 0) {
		return CAN_NOT_GET_STREAM;
	}

	// search video stream
	AVStream* video_stream = nullptr;
	for (int i = 0; i < (int)format_context->nb_streams; ++i) {
		if (format_context->streams[i]->codecpar->codec_type == AVMEDIA_TYPE_VIDEO) {
			video_stream = format_context->streams[i];
			break;
		}
	}
	if (video_stream == nullptr) {
		return VIDEO_STREAM_IS_NOT_FOUND;
	}

	// time base
	time_base = video_stream->time_base;

	// make decoder
	const AVCodec* codec = avcodec_find_decoder(video_stream->codecpar->codec_id);
	if (codec == nullptr) {
		return NOT_SUPPORTED_DECODER;
	}
	AVCodecContext* codec_context = avcodec_alloc_context3(codec);
	if (codec_context == nullptr) {
		return CAN_NOT_ALLOCED_CODEC;
	}
	if (avcodec_parameters_to_context(codec_context, video_stream->codecpar) < 0) {
		return CAN_NOT_COPYED_STREAMS;
	}
	if (avcodec_open2(codec_context, codec, nullptr) != 0) {
		return CAN_NOT_OPENED_CODEC;
	}

	// decode frames
	AVFrame* frame = av_frame_alloc();
	all_error flag = openFramesMat(format_context, video_stream, codec_context, frame, frames);

	if (flag != NOT_ERROR) return flag;

	// clean up
	avcodec_free_context(&codec_context);
	avformat_close_input(&format_context);

	if (data != nullptr) {
		data->time_base = time_base;
		data->data = frame;
	}

	return NOT_ERROR;

}
*/

DLL_EXPORT all_error openFrames(
	AVFormatContext* format_context,
	AVStream* video_stream,
	AVCodecContext* codec_context,
	std::vector<AVFrame*>* frames
) {

	AVFrame* frame = av_frame_alloc();
	AVPacket packet = AVPacket();
	while (av_read_frame(format_context, &packet) == 0) {
		if (packet.stream_index == video_stream->index) {
			if (avcodec_send_packet(codec_context, &packet) != 0) {
				return CAN_NOT_SEND_PACKET;
			}
			while (avcodec_receive_frame(codec_context, frame) == 0) {

				AVFrame* new_frame = av_frame_alloc();
				av_frame_ref(new_frame, frame);
				frames->push_back(new_frame);
			
			}
		}
		av_packet_unref(&packet);
	}

	av_frame_free(&frame);

	return NOT_ERROR;

}

/*
DLL_EXPORT all_error openFramesMat(
	AVFormatContext* format_context,
	AVStream* video_stream,
	AVCodecContext* codec_context,
	AVFrame* frame,
	std::vector<Mat>* frames
) {

	if (frame == NULL) {
		frame = av_frame_alloc();
	}

	AVPacket packet = AVPacket();
	while (av_read_frame(format_context, &packet) == 0) {
		if (packet.stream_index == video_stream->index) {
			if (avcodec_send_packet(codec_context, &packet) != 0) {
				return CAN_NOT_SEND_PACKET;
			}
			while (avcodec_receive_frame(codec_context, frame) == 0) {

				AVFrame* new_frame = av_frame_alloc();
				av_frame_ref(new_frame, frame);
				Mat dst;
				Frame2Mat(new_frame, &dst);
				frames->push_back(dst);

			}
		}
		av_packet_unref(&packet);
	}

	//av_frame_free(&frame);

	return NOT_ERROR;

}
*/
