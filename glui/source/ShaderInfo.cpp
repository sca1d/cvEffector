#include "..\include\ShaderInfo.h"

DLL_EXPORT int readShaderSource(GLuint shaderObj, std::string filename) {

	std::ifstream ifs(filename);
	if (!ifs) {
		printf("error\n");
		return -1;
	}

	std::string source;
	std::string line;
	while (getline(ifs, line)) {
		source += line + "\n";
	}

	// shader_source to shader_object
	const GLchar* sourceptr = (const GLchar*)source.c_str();
	GLint length = source.length();
	glShaderSource(shaderObj, 1, &sourceptr, &length);
	
	return 0;

}

DLL_EXPORT GLint makeShader(std::string vertex_filename, std::string fragment_filename) {

	// create shader objects
	GLuint vertShaderObj = glCreateShader(GL_VERTEX_SHADER);
	GLuint fragShaderObj = glCreateShader(GL_FRAGMENT_SHADER);
	GLuint shader;

	// compile shader and link variable
	GLint compiled, linked;

	// get shader source
	if (readShaderSource(vertShaderObj, vertex_filename) || readShaderSource(fragShaderObj, fragment_filename))
		return -1;

	// compile shaders program
	glCompileShader(vertShaderObj);
	glGetShaderiv(vertShaderObj, GL_COMPILE_STATUS, &compiled);
	if (compiled == GL_FALSE) {
		fprintf(stderr, "Compile error in vertx shader.\n");
		return -1;
	}

	// compile fragment shaders program
	glCompileShader(fragShaderObj);
	glGetShaderiv(fragShaderObj, GL_COMPILE_STATUS, &compiled);
	if (compiled == GL_FALSE) {
		fprintf(stderr, "Compile error in fragmen shader.\n");
		return -1;
	}

	// create program object
	shader = glCreateProgram();

	// registration shader programs
	glAttachShader(shader, vertShaderObj);
	glAttachShader(shader, fragShaderObj);

	// delete shader object
	glDeleteShader(vertShaderObj);
	glDeleteShader(fragShaderObj);

	// link shader programs
	glLinkProgram(shader);
	glGetProgramiv(shader, GL_LINK_STATUS, &linked);
	if (linked == GL_FALSE) {
		fprintf(stderr, "Link error.\n");
		return -1;
	}

	return shader;

}
