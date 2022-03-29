#pragma once
#include <stdio.h>

extern "C" {
#include <libavutil/imgutils.h>
#include <libavcodec/avcodec.h>
#include <libavformat/avformat.h>
};

#include "deflate.h"

DLL_EXPORT AVFrame* CreateEmpty(AVFrame* src);
