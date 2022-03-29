#include "encode.h"

DLL_EXPORT all_error encode(const char* output_filepath, std::vector<AVFrame*>* frames, decode_data* data) {

	AVIOContext* io_context = nullptr;
	if (avio_open(&io_context, output_filepath, AVIO_FLAG_WRITE) < 0) {
		return CAN_NOT_OPENED_AVIO;
	}

	// muxer alloc
	AVFormatContext* format_context = nullptr;
	if (avformat_alloc_output_context2(
		&format_context, nullptr, "mp4", nullptr) < 0) {
		return CAN_NOT_MAKE_FORMAT;
	}

	// set io_context to format_context
	format_context->pb = io_context;

	// search codec
	const AVCodec* codec = avcodec_find_encoder(AV_CODEC_ID_H264);
	if (codec == nullptr) {
		return ENCODER_IS_NOT_FOUND;
	}

	// codec context alloc
	AVCodecContext* codec_context = avcodec_alloc_context3(codec);
	if (codec_context == nullptr) {
		return CAN_NOT_MAKE_CODEC;
	}

	// set picture properties
	SetProperties(codec_context, frames->at(0) , data->time_base);

	// generate global header when the format requires it
	if (format_context->oformat->flags & AVFMT_GLOBALHEADER) {
		codec_context->flags |= AV_CODEC_FLAG_GLOBAL_HEADER;
	}

	// make codec options
	AVDictionary* codec_options = nullptr;
	av_dict_set(&codec_options, "preset", "medium", 0);
	av_dict_set(&codec_options, "crf", "22", 0);
	av_dict_set(&codec_options, "profile", "high", 0);
	av_dict_set(&codec_options, "level", "4.0", 0);

	// open codec
	if (avcodec_open2(codec_context, codec_context->codec, &codec_options) != 0) {
		return CAN_NOT_OPEN_CODEC;
	}

	// add stream
	AVStream* stream = avformat_new_stream(format_context, codec);
	if (stream == NULL) {
		return CAN_NOT_GET_NEW_STREAM;
	}

	// copy params by codec_context
	stream->sample_aspect_ratio = codec_context->sample_aspect_ratio;
	stream->time_base = codec_context->time_base;
	if (avcodec_parameters_from_context(stream->codecpar, codec_context) < 0) {
		return CAN_NOT_GET_PARAMETERS;
	}

	// last setup for call av_format_write_header
	if (avformat_write_header(format_context, nullptr) < 0) {
		return CAN_NOT_WRITE_HEADER;
	}

	// encode
	all_error err = writeFrames(codec_context, stream, format_context, data, frames);
	if (err != NOT_ERROR) return err;

	// flush encoder
	if (avcodec_send_frame(codec_context, nullptr) != 0) {
		return CAN_NOT_SEND_FRAMES;
	}
	AVPacket packet = AVPacket();
	while (avcodec_receive_packet(codec_context, &packet) == 0) {
		packet.stream_index = 0;
		av_packet_rescale_ts(&packet, codec_context->time_base, stream->time_base);
		if (av_interleaved_write_frame(format_context, &packet) != 0) {
			return CAN_NOT_WROTE_FRAME;
		}
	}
	
	if (av_write_trailer(format_context) != 0) {
		return NOT_WROTE_TRAILER;
	}

	avcodec_free_context(&codec_context);
	avformat_free_context(format_context);
	avio_closep(&io_context);

	return NOT_ERROR;

}

DLL_EXPORT void SetProperties(AVCodecContext* codec_context, AVFrame* frame, AVRational time_base) {

	codec_context->pix_fmt = (AVPixelFormat)frame->format;
	codec_context->width = frame->width;
	codec_context->height = frame->height;
	codec_context->field_order = AV_FIELD_PROGRESSIVE;
	codec_context->color_range = frame->color_range;
	codec_context->color_primaries = frame->color_primaries;
	codec_context->color_trc = frame->color_trc;
	codec_context->colorspace = frame->colorspace;
	codec_context->chroma_sample_location = frame->chroma_location;
	codec_context->sample_aspect_ratio = frame->sample_aspect_ratio;
	codec_context->time_base = time_base;

}

DLL_EXPORT all_error writeFrames(
	AVCodecContext* codec_context,
	AVStream* stream,
	AVFormatContext* format_context,
	decode_data* data,
	std::vector<AVFrame*>* frames
) {

	while (frames->size() > 0) {
		AVFrame* frame = frames->front();
		frames->erase(frames->begin());
		int64_t pts = frame->best_effort_timestamp;
		frame->pts = av_rescale_q(pts, data->time_base, codec_context->time_base);
		frame->key_frame = 0;
		frame->pict_type = AV_PICTURE_TYPE_NONE;
		if (avcodec_send_frame(codec_context, frame) != 0) {
			return CAN_NOT_SEND_FRAMES;
		}
		av_frame_free(&frame);
		AVPacket packet = AVPacket();
		while (avcodec_receive_packet(codec_context, &packet) == 0) {
			packet.stream_index = 0;
			av_packet_rescale_ts(&packet, codec_context->time_base, stream->time_base);
			if (av_interleaved_write_frame(format_context, &packet) != 0) {
				return CAN_NOT_WROTE_FRAME;
			}
		}
	}

	return NOT_ERROR;

}
