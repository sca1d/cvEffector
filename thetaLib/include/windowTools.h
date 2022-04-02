#pragma once
#include <stdio.h>
#include <stdlib.h>
#include <Windows.h>

#ifndef DLL_EXPORT
#define DLL_EXPORT __declspec(dllexport)
#endif

extern "C" {
	DLL_EXPORT inline int PutInOtherWindow(HWND SetOfHandle, HWND Foundation);
}
