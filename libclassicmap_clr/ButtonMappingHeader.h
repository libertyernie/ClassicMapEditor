#pragma once

#include "button_mapping_header.h"
#include <vector>

using namespace System;

namespace ClassicMap {
	public ref class ButtonMappingHeader {
	private:
		libclassicmap::button_mapping_header* _ptr;

	public:
		ButtonMappingHeader(libclassicmap::button_mapping_header* ptr) {
			this->_ptr = ptr;
		}

		property uint16_t ClassicControllerButton {
			uint16_t get() {
				return this->_ptr->ccButton;
			}
			void set(uint16_t value) {
				this->_ptr->ccButton = value;
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
	};
}