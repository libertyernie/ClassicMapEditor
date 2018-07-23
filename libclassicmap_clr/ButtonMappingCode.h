#pragma once

#include <msclr\marshal_cppstd.h>

#include "button_mapping_code.h"

#include "ButtonMappingHeader.h"
#include "WiiRemoteButtonMapping.h"

using namespace System;
using namespace System::Collections::Generic;

using namespace libclassicmap;

namespace ClassicMap {
	public ref class ButtonMappingCode {
	private:
		button_mapping_code* _code;

	public:
		ButtonMappingCode(String^ name, String^ data);
		ButtonMappingCode(String^ name, array<uint8_t>^ data);
		IEnumerable<ButtonMappingHeader^>^ GetButtonMappings();
		IEnumerable<WiiRemoteButtonMapping^>^ GetWiiRemoteButtonMappings();
		property String^ Name {
			String^ get();
		}
		String^ ToString() override;
		~ButtonMappingCode();
		!ButtonMappingCode();
	};
}