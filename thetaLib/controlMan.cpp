#include "include\controlMan.h"

namespace thetaLib {

	ControlManager::ControlManager(System::Windows::Forms::Control^ control) {

		this->hwnd = (HWND)control->Handle.ToInt32();

	}

	void ControlManager::OpenVideo(void) {

		char* f = "F:\\����ҏW�Ɏg�����\\����Ɏg������\\";
		c_str filepath(f, sizeof(f) / sizeof(f[0]));

		char* got_file = ShowFileFialog(this->hwnd, filepath);

		

	}

}