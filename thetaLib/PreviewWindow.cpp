#include "include/PreviewWindow.h"

GLfloat points[] = { 0.8, 0.8, -0.8, 0.8, -0.8, -0.8f, 0.8, -0.8, };
GLfloat vertex_uv[] = { 1.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 1.0f, 1.0f };

#pragma region PRIATE FUNC
GLint PreviewWindow::makeShader(void) {

	const char* vert =
		"#version 400\n"
		"layout(location = 0) in vec2 position;\n"
		"layout(location = 1) in vec2 vuv;\n"
		"out vec2 Flag_uv;\n"
		"void main(void) {\n"
		"Flag_uv = vuv;\n"
		"gl_Position =vec4(position, 0.0, 1.0);\n"
		"}\n";

	const char* frag =
		"#version 400\n"
		"in vec2 Flag_uv;"
		"uniform sampler2D Texture;"
		"out vec4 outFragmentColor; \n"
		"void main(void) {\n"
		"outFragmentColor = texture2D(Texture, Flag_uv); \n"
		"}\n";

	GLuint vs, fs;
	GLuint shader_program;

	vs = glCreateShader(GL_VERTEX_SHADER);
	glShaderSource(vs, 1, &vert, NULL);
	glCompileShader(vs);

	fs = glCreateShader(GL_FRAGMENT_SHADER);
	glShaderSource(fs, 1, &frag, NULL);
	glCompileShader(fs);

	shader_program = glCreateProgram();
	glAttachShader(shader_program, fs);
	glAttachShader(shader_program, vs);
	glLinkProgram(shader_program);

	return shader_program;

}
void PreviewWindow::BindCVMatTexture(cv::Mat* mat, GLuint texID) {

	glPixelStorei(GL_UNPACK_ALIGNMENT, mat->channels());

	glBindTexture(GL_TEXTURE_2D, texID);

	glTexImage2D(GL_TEXTURE_2D, 0, GL_RGB, mat->cols, mat->rows, 0, GL_RGB, GL_UNSIGNED_BYTE, mat->ptr());

	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT); // ‰¡•ûŒü
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT); // c•ûŒü

	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_NEAREST); // Šg‘åŽž
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_NEAREST); // k¬Žž

}
void PreviewWindow::ResetPoints(GLfloat w, GLfloat h) {
	
	points[0] = w;	points[1] = h;	// ‰Eã
	points[2] = -w;	points[3] = h;	// ¶ã
	points[4] = -w;	points[5] = -h;	// ¶‰º
	points[6] = w;	points[7] = -h;	// ‰E‰º

}
int PreviewWindow::MatInit(cv::Mat* src, cv::Mat* dst) {

	if (src->empty()) return 1;

	int type = COLOR_BGR2RGB;

	switch (src->channels()) {
	case 1:
		type = COLOR_GRAY2RGB;
		break;
	case 3:
		type = COLOR_BGR2RGB;
		break;
	case 4:
		type = COLOR_BGRA2RGBA;
		break;
	default:
		return 2;
	}

	cvtColor(*src, *dst, type);

	return 0;

}
#pragma endregion

PreviewWindow::PreviewWindow(System::Windows::Forms::Control^ control) {

	this->hwnd = (HWND)control->Handle.ToInt32();
	this->hdc = GetDC(this->hwnd);

	if (!glfwInit()) {
		fprintf(stderr, "ERROR: could not start GLFW3\n");
		exit(1);
	}

	glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 2);
	glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 1);

	this->window = glfwCreateWindow(control->Width, control->Height, "texture", NULL, NULL);
	if (!this->window) {
		fprintf(stderr, "ERROR: could not open window width GLFW3\n");
		glfwTerminate();
		exit(2);
	}
	glfwMakeContextCurrent(this->window);

	PutInOtherWindow(this->hwnd, WindowFromDC(wglGetCurrentDC()));

	glewExperimental = GL_TRUE;
	glewInit();
	glEnable(GL_DEPTH_TEST);
	glDepthFunc(GL_LESS);

	glEnable(GL_BLEND);
	glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);

	ResetPoints(0.9, 0.9);

	this->shader = makeShader();

	glGenVertexArrays(1, &this->vao);
	glBindVertexArray(this->vao);

	glGenBuffers(1, &this->vertex_vbo);
	glBindBuffer(GL_ARRAY_BUFFER, this->vertex_vbo);
	glBufferData(GL_ARRAY_BUFFER, sizeof(points), points, GL_STATIC_DRAW);

	glGenBuffers(1, &this->uv_vbo);
	glBindBuffer(GL_ARRAY_BUFFER, this->uv_vbo);
	glBufferData(GL_ARRAY_BUFFER, sizeof(vertex_uv), vertex_uv, GL_STATIC_DRAW);

	glEnable(GL_TEXTURE_2D);

	glTexEnvi(GL_TEXTURE_ENV, GL_TEXTURE_ENV_MODE, GL_REPLACE);
	glGenTextures(1, &this->texID);

	this->textureLocation = glGetUniformLocation(this->shader, "texture");

	glfwSwapInterval(0);

}
PreviewWindow::~PreviewWindow(void) {

	glDeleteTextures(1, &this->texID);
	glfwTerminate();

}

void PreviewWindow::ReDraw(cv::Mat* mat) {

	//Mat dst;
	if (MatInit(mat, &this->dst) != 0) { printf("error init mat.\n"); return; }

	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

	BindCVMatTexture(&this->dst, this->texID);

	glUseProgram(this->shader);

	glEnableVertexAttribArray(0);
	glBindBuffer(GL_ARRAY_BUFFER, this->vertex_vbo);
	glVertexAttribPointer(0, 2, GL_FLOAT, GL_FALSE, 0, (GLvoid*)0);

	glEnableVertexAttribArray(1);
	glBindBuffer(GL_ARRAY_BUFFER, this->uv_vbo);
	glVertexAttribPointer(1, 2, GL_FLOAT, GL_FALSE, 0, (GLvoid*)0);

	glUniform1i(this->textureLocation, 0);
	glBindTexture(GL_TEXTURE_2D, this->texID);

	glDrawArrays(GL_TRIANGLE_FAN, 0, 4);

	glDisableVertexAttribArray(0);
	glDisableVertexAttribArray(1);

	glfwPollEvents();
	glfwSwapBuffers(this->window);

	dst.release();

}
