#pragma once
#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <Windows.h>

#include "deflate.h"

extern "C" {

	DLL_EXPORT wide_str Char2Cstr(c_str str);
	DLL_EXPORT c_str Cstr2Char(wide_str str);

	DLL_EXPORT char* ShowFileFialog(HWND hwnd, c_str filepath);

}
