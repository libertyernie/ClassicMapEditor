#pragma once

#include "button_mapping_header.h"
#include "Buttons.h"

#include <vector>

using namespace System;
using namespace System::Text;

namespace ClassicMap {
	public ref class ButtonMappingHeader {
	private:
		libclassicmap::button_mapping_header* _ptr;

	public:
		ButtonMappingHeader(libclassicmap::button_mapping_header* ptr) {
			this->_ptr = ptr;
		}

		property ClassicControllerButton ClassicController {
			ClassicControllerButton get() {
				return (ClassicControllerButton)this->_ptr->ccButton;
			}
			void set(ClassicControllerButton value) {
				this->_ptr->ccButton = (uint16_t)value;
			}
		}

		array<uint16_t>^ GetAdditionalData() {
			std::vector<uint16_t> from = _ptr->getAdditionalData();
			array<uint16_t>^ to = gcnew array<uint16_t>(from.size());
			for (int i = 0; i < from.size(); i++) {
				to[i] = from[i];
			}
			return to;
		}

		String^ GetAdditionalDataAsHexString() {
			std::vector<uint16_t> from = _ptr->getAdditionalData();
			StringBuilder^ sb = gcnew StringBuilder();
			for each (uint16_t value in from) {
				sb->Append(((int32_t)value).ToString("X4"));
			}
			return sb->ToString();
		}
	};
}