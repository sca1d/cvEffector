#include "empty.h"

DLL_EXPORT AVFrame* CreateEmpty(AVFrame* src) {

	AVFrame* dst = av_frame_alloc();

	av_frame_copy_props(dst, src);

	dst->format = src->format;
	dst->width = src->width;
	dst->height = src->height;

	if (av_frame_get_buffer(dst, 32) != 0) return nullptr;

	return dst;

}
