#pragma once
#include <stdio.h>
#include <vector>

extern "C" {
#include <libavutil/imgutils.h>
#include <libavcodec/avcodec.h>
#include <libavformat/avformat.h>
};

#include <opencv2/opencv.hpp>
using namespace cv;

#include "deflate.h"

DLL_EXPORT all_error decode(const char* file_path, std::vector<AVFrame*>* frames, decode_data* data);
//DLL_EXPORT all_error decodeMat(const char* file_path, std::vector<Mat>* frames, decode_data* data);

DLL_EXPORT all_error openFrames(
	AVFormatContext* format_context,
	AVStream* video_stream,
	AVCodecContext* codec_context,
	std::vector<AVFrame*>* frames );

/*
DLL_EXPORT all_error openFramesMat(
	AVFormatContext* format_context,
	AVStream* video_stream,
	AVCodecContext* codec_context,
	AVFrame* frame,
	std::vector<Mat>* frames);
*/
