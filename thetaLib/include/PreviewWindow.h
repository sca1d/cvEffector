#pragma once
//#include "thetaLib.h"
#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <windows.h>

#include <iostream>
#include <string>
#include <vector>
using namespace std;

#include <opencv2/opencv.hpp>
using namespace cv;

#include <GL/glew.h>
#include <GL/GL.h>
#include <GLFW/glfw3.h>

using namespace System;

class PreviewWindow {

private:
	HWND hwnd;
	HDC hdc;

	GLFWwindow* window = NULL;
	GLint shader;
	GLuint vao, vertex_vbo, uv_vbo;
	GLuint texID;

	int textureLocation;

	GLint makeShader(void);
	void BindCVMatTexture(cv::Mat* mat, GLuint texID);
	void ResetPoints(GLfloat w, GLfloat h);
	int MatInit(cv::Mat* src, cv::Mat* dst);

public:
	PreviewWindow(System::Windows::Forms::Control^ control);
	~PreviewWindow(void);

	void ReDraw(cv::Mat* mat);

};
