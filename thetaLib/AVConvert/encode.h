#pragma once
#include <stdio.h>

extern "C" {
#include <libavutil/imgutils.h>
#include <libavcodec/avcodec.h>
#include <libavformat/avformat.h>
#include <libavutil/avutil.h>
#include <libswscale/swscale.h>
};

#include <opencv2/opencv.hpp>
using namespace cv;

#include "deflate.h"

DLL_EXPORT all_error encode(const char* output_filepath, std::vector<AVFrame*>* frames, decode_data* data);

DLL_EXPORT void SetProperties(AVCodecContext* codec_context, AVFrame* frame, AVRational time_base);

DLL_EXPORT all_error writeFrames(
	AVCodecContext* codec_context,
	AVStream* stream,
	AVFormatContext* format_context,
	decode_data* data,
	std::vector<AVFrame*>* frames );
