#pragma once
#include "deflate.h"

DLL_EXPORT int readShaderSource(GLuint shaderObj, std::string filename);
DLL_EXPORT GLint makeShader(std::string vertex_filename, std::string fragment_filename);
