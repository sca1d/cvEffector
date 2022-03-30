#pragma once
#include "thetaLib.h"

all_error opening_frames(AVFormatContext* format_context, AVStream* video_stream, AVCodecContext* codec_context, AVFrame* frame, std::vector<Mat>* frames, void* custom);
