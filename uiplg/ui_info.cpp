#include "ui_info.h"

using namespace System;
using namespace System::Drawing;
using namespace System::ComponentModel;

using System::String;

namespace uiplg {

	System::String^ Sample::HelloWorld(System::String^ name) {

		return "Hello World!! " + this->name;

	}

}