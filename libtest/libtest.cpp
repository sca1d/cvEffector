#include <stdio.h>
//#include <stdlib.h>
#include <math.h>

//#include <GL/glut.h>
//#include <GL/glew.h>
//#include <GLFW/glfw3.h>
//#include <glm/glm.hpp>

#ifdef GL_ES
precision highp float;
#endif


//#include "ColorPicker.h"
#include "ShaderInfo.h"

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

}
