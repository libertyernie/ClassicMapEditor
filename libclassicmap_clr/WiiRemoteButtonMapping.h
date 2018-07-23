#pragma once

#include "wii_remote_button_mapping.h"
#include "Buttons.h"

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

		property ClassicControllerButton ClassicController {
			ClassicControllerButton get() {
				return (ClassicControllerButton)this->_ptr->ccButton;
			}
			void set(ClassicControllerButton value) {
				this->_ptr->ccButton = (uint16_t)value;
			}
		}

		property WiiRemoteButton WiiRemote {
			WiiRemoteButton get() {
				return (WiiRemoteButton)this->_ptr->wiiButton;
			}
			void set(WiiRemoteButton value) {
				this->_ptr->wiiButton = (uint16_t)value;
			}
		}
	};
}