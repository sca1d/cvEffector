#include <stdio.h>
#include <math.h>

#include <opencv2/opencv.hpp>

#include <iostream>
#include <string>
#include <fstream>
#include <sstream>
#include <vector>
using namespace std;

#include <GL/glew.h>
#include <GL/GL.h>
#include <GLFW/glfw3.h>

#ifdef GL_ES
precision highp float;
#endif


//#include "ShaderInfo.h"

//using namespace glm;

/*
vec3 hsv(float h, float s, float v) {
	vec4 t = vec4(1.0, 2.0 / 3.0, 1.0 / 3.0, 3.0);
	vec3 p = abs(fract(vec3(h) + t.xyz) * 6.0 - vec3(t.w));
	return v * mix(vec3(t.x), clamp(p - vec3(t.x), 0.0, 1.0), s);
}
*/

#ifdef GL_ES
precision highp float;
#endif

/*
uniform float time;
uniform vec2 resolution;

const vec4  kRGBToYPrime = vec4(0.299, 0.587, 0.114, 0.0);
const vec4  kRGBToI = vec4(0.596, -0.275, -0.321, 0.0);
const vec4  kRGBToQ = vec4(0.212, -0.523, 0.311, 0.0);

const vec4  kYIQToR = vec4(1.0, 0.956, 0.621, 0.0);
const vec4  kYIQToG = vec4(1.0, -0.272, -0.647, 0.0);
const vec4  kYIQToB = vec4(1.0, -1.107, 1.704, 0.0);

const float PI = 3.14159265358979323846264;

void adjustHue(inout vec4 color, float hueAdjust) {
	// Convert to YIQ
	float   YPrime = dot(color, kRGBToYPrime);
	float   I = dot(color, kRGBToI);
	float   Q = dot(color, kRGBToQ);

	// Calculate the hue and chroma
	float   hue = atan(Q, I);
	float   chroma = sqrt(I * I + Q * Q);

	// Make the user's adjustments
	hue += hueAdjust;

	// Convert back to YIQ
	Q = chroma * sin(hue);
	I = chroma * cos(hue);

	// Convert back to RGB
	vec4 yIQ = vec4(YPrime, I, Q, 0.0);
	color.r = dot(yIQ, kYIQToR);
	color.g = dot(yIQ, kYIQToG);
	color.b = dot(yIQ, kYIQToB);
}

void main(void)
{
	vec2 p = gl_FragCoord.xy / resolution.xy;
	float gray = 1.0 - p.x;
	float red = p.y;
	vec4 color = vec4(red, gray * red, gray * red, 1.0);
	adjustHue(color, mod(time, 2.0 * PI));
	gl_FragColor = color;
}
*/

void init(void) {
	glClearColor(1.0, 1.0, 1.0, 1.0);
}

void display(void) {
	glClear(GL_COLOR_BUFFER_BIT);
	glBegin(GL_POLYGON);

	glColor3d(0.0, 0.0, 0.0);
	glVertex2d(-1.0, -1.0);

	glColor3d(0.0, 0.0, 0.0);
	glVertex2d(1.0, -1.0);

	glColor3d(1.0, 0.0, 0.0);
	glVertex2d(1.0, 1.0);

	glColor3d(1.0, 1.0, 1.0);
	glVertex2d(-1.0, 1.0);

	glEnd();
	glFlush();
}

/*
int main(int argc, char* argv[]) {

	//test();
	glutInit(&argc, argv);
	glutCreateWindow("Color table");

	glutDisplayFunc(display);
	//glutIdleFunc(idle);

	init();
	glutMainLoop();

	return 0;

}
*/

/*
int main(void) {

	if (glfwInit() == GL_FALSE) return -1;

	// ウィンドウ生成
	GLFWwindow* window = glfwCreateWindow(640, 480, "OpenGL Sample", NULL, NULL);
	if (!window)
	{
		glfwTerminate();
		return -1;
	}

	// バージョン2.1指定
	glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 2);
	glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 1);

	glfwMakeContextCurrent(window);
	glfwSwapInterval(0);

	// GLEW初期化
	if (glewInit() != GLEW_OK)
	{
		return -1;
	}


	GLint shader = makeShader("shader.vert", "shader.frag");

	// フレームループ
	while (glfwWindowShouldClose(window) == GL_FALSE)
	{
		// バッファのクリア
		glClearColor(0.2f, 0.2f, 0.2f, 0.0f);
		glClear(GL_COLOR_BUFFER_BIT);

		glUseProgram(shader);

		// 色指定
		glColor4f(1.0, 0.0, 0.0, 1.0);

		// 3つの頂点座標をGPUに転送
		glBegin(GL_TRIANGLES);
		glVertex2f(0, 0.5);
		glVertex2f(-0.5, -0.5);
		glVertex2f(0.5, -0.5);
		glEnd();

		// ダブルバッファのスワップ
		glfwSwapBuffers(window);
		glfwPollEvents();
	}

	// GLFWの終了処理
	glfwTerminate();

	return 0;

}*/

GLint makeShader() {
	const char* vertex_shader =
		"#version 400\n"
		"layout(location = 0) in vec2 position;\n"
		"layout(location = 1) in vec2 vuv;\n"
		"out vec2 Flag_uv;\n"
		"void main(void) {\n"
		"Flag_uv = vuv;\n"
		"gl_Position =vec4(position, 0.0, 1.0);\n"
		"}\n";


	const char* fragment_shader =
		"#version 400\n"
		"in vec2 Flag_uv;"//頂点シェーダで計算された、テクスチャの残高
		"uniform sampler2D Texture;" //追加：テクスチャを入手
		"out vec4 outFragmentColor; \n"
		"void main(void) {\n"
		//texture2D関数→指定されたUV座標（Flag_uv）のテクスチャの色を返す関数
		"outFragmentColor = texture2D(Texture, Flag_uv); \n"
		"}\n";


	GLuint vs, fs;
	GLuint shader_programme;

	vs = glCreateShader(GL_VERTEX_SHADER);
	glShaderSource(vs, 1, &vertex_shader, NULL);
	glCompileShader(vs);

	fs = glCreateShader(GL_FRAGMENT_SHADER);
	glShaderSource(fs, 1, &fragment_shader, NULL);
	glCompileShader(fs);

	shader_programme = glCreateProgram();
	glAttachShader(shader_programme, fs);
	glAttachShader(shader_programme, vs);
	glLinkProgram(shader_programme);
	return shader_programme;
}

void BindCVMatTexture(cv::Mat* mat, GLuint texID) {
	// color count : rgb -> 3, rgba ->4
	glPixelStorei(GL_UNPACK_ALIGNMENT, 3);

	glBindTexture(GL_TEXTURE_2D, texID);

	glTexImage2D(GL_TEXTURE_2D, 0, GL_RGB, mat->cols, mat->rows, 0, GL_RGB, GL_UNSIGNED_BYTE, mat->ptr());

	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT); // 横方向
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT); // 縦方向

	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_NEAREST); // 拡大時
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_NEAREST); // 縮小時
}

// texture test
int main(void) {

	const char* ch = "F:\\SS\\画像148.jpg";
	printf("%s\n", ch);

	// INITIALIZE OPENCV
	cv::Mat	mat = cv::imread(ch);
	if (mat.empty()) return -1;

	cv::cvtColor(mat, mat, cv::COLOR_BGR2RGB);

	int w = mat.cols;
	int h = mat.rows;
	//cv::imshow("test", mat);
	//

	GLFWwindow* window = NULL;

	GLfloat points[] = { 0.8, 0.8, -0.8, 0.8, -0.8, -0.8f, 0.8, -0.8, };
	GLfloat vertex_uv[] = { 1.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 1.0f, 1.0f };

	if (!glfwInit()) {
		fprintf(stderr, "ERROR: could not start GLFW3\n");
		return -1;
	}

	glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 2);
	glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 1);

	window = glfwCreateWindow(1200, 675, "Texture", NULL, NULL);
	if (!window) {
		fprintf(stderr, "ERROR: could not open window width GLFW3\n");
		glfwTerminate();
		return -1;
	}
	glfwMakeContextCurrent(window);

	glewExperimental = GL_TRUE;
	glewInit();
	glEnable(GL_DEPTH_TEST);
	glDepthFunc(GL_LESS);

	glEnable(GL_BLEND);
	glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);

	GLint shader = makeShader();

	GLuint vao, vertex_vbo, uv_vbo;
	glGenVertexArrays(1, &vao);
	glBindVertexArray(vao);

	glGenBuffers(1, &vertex_vbo);
	glBindBuffer(GL_ARRAY_BUFFER, vertex_vbo);
	glBufferData(GL_ARRAY_BUFFER, sizeof(points), points, GL_STATIC_DRAW);

	glGenBuffers(1, &uv_vbo);
	glBindBuffer(GL_ARRAY_BUFFER, uv_vbo);
	glBufferData(GL_ARRAY_BUFFER, sizeof(vertex_uv), vertex_uv, GL_STATIC_DRAW);



	glEnable(GL_TEXTURE_2D);

	GLuint texID;
	glTexEnvi(GL_TEXTURE_ENV, GL_TEXTURE_ENV_MODE, GL_REPLACE);
	glGenTextures(1, &texID);

	int textureLocation = glGetUniformLocation(shader, "texture");

	while (!glfwWindowShouldClose(window)) {

		glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

		BindCVMatTexture(&mat, texID);

		glUseProgram(shader);

		glEnableVertexAttribArray(0);
		glBindBuffer(GL_ARRAY_BUFFER, vertex_vbo);
		glVertexAttribPointer(0, 2, GL_FLOAT, GL_FALSE, 0, (GLvoid*)0);

		glEnableVertexAttribArray(1);
		glBindBuffer(GL_ARRAY_BUFFER, uv_vbo);
		glVertexAttribPointer(1, 2, GL_FLOAT, GL_FALSE, 0, (GLvoid*)0);

		glUniform1i(textureLocation, 0);
		glBindTexture(GL_TEXTURE_2D, texID);

		glDrawArrays(GL_TRIANGLE_FAN, 0, 4);

		glDisableVertexAttribArray(0);
		glDisableVertexAttribArray(1);

		glfwPollEvents();
		glfwSwapBuffers(window);

	}

	glDeleteTextures(1, &texID);
	glfwTerminate();

	return 0;
}
