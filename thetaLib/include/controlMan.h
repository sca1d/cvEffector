#pragma once
#include "thetaLib.h"

namespace thetaLib {

	public ref class ControlManager {

	private:
		HWND hwnd = nullptr;

	public:
		ControlManager(System::Windows::Forms::Control^ control);
		void OpenVideo(void);

	};

}
