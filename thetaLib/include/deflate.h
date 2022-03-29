#pragma once

#define DLL_EXPORT __declspec(dllexport)
#define ARRAY_SIZE(A) ( (A) / (A[0]) )

extern "C" {

	typedef struct _c_str {

		char* string;
		int length;

	public:
		_c_str(char* str, int len) {
			string = str;
			length = len;
		}

	}c_str;
	typedef struct _wide_str {

		TCHAR* string;
		int length;

	public:
		_wide_str(TCHAR* str, int len) {
			string = str;
			length = len;
		}

	}wide_str;

}
