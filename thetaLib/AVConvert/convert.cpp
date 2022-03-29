#include "convert.h"

DLL_EXPORT void Frame2Mat(AVFrame* frame, Mat* mat) {

	int w = frame->width;
	int h = frame->height;

	*mat = Mat(h, w, CV_8UC3);

	int cvLinesizes[1];
	cvLinesizes[0] = mat->step1();

	SwsContext* conversion = sws_getContext(
		w, h, (AVPixelFormat)frame->format, w, h,
		AVPixelFormat::AV_PIX_FMT_BGR24, SWS_FAST_BILINEAR, NULL, NULL, NULL);

	sws_scale(conversion, frame->data, frame->linesize, 0, h, &mat->data, cvLinesizes);
	sws_freeContext(conversion);

}

DLL_EXPORT void Mat2Frame(Mat* mat, AVFrame* frame) {

	int w = mat->cols;
	int h = mat->rows;

	int cvLinesizes[1];
	cvLinesizes[0] = mat->step1();

	if (frame == NULL) {
		frame = av_frame_alloc();
		av_image_alloc(frame->data, frame->linesize, w, h, AVPixelFormat::AV_PIX_FMT_YUV420P, 1);
	}

	SwsContext* conversion = sws_getContext(
		w, h, AVPixelFormat::AV_PIX_FMT_BGR24, w, h, (AVPixelFormat)frame->format, SWS_FAST_BILINEAR, NULL, NULL, NULL);
	
	sws_scale(conversion, &mat->data, cvLinesizes, 0, h, frame->data, frame->linesize);
	sws_freeContext(conversion);

}
