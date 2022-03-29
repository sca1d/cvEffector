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

DLL_EXPORT void Frame2Mat(AVFrame* frame, Mat* mat);
DLL_EXPORT void Mat2Frame(Mat* mat, AVFrame* frame);
