#include "include\controlMan.h"

namespace thetaLib {

	ControlManager::ControlManager(System::Windows::Forms::Control^ control) {

		this->hwnd = (HWND)control->Handle.ToInt32();

	}

}