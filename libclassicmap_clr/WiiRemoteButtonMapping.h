#pragma once

#include "wii_remote_button_mapping.h"
#include <vector>

using namespace System;

namespace ClassicMap {
	public ref class WiiRemoteButtonMapping {
	private:
		libclassicmap::wii_remote_button_mapping* _ptr;

	public:
		WiiRemoteButtonMapping(libclassicmap::wii_remote_button_mapping* ptr) {
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

		property uint16_t WiiRemoteButton {
			uint16_t get() {
				return this->_ptr->wiiButton;
			}
			void set(uint16_t value) {
				this->_ptr->wiiButton = value;
			}
		}
	};
}