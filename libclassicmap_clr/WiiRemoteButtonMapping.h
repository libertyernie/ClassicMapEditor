#pragma once

#include "button_mapping_header.h"
#include "wii_remote_button_mapping.h"
#include "Buttons.h"
#include "ButtonMappingCode.h"

#include <vector>

using namespace System;

namespace ClassicMap {
	public ref class WiiRemoteButtonMapping : public ButtonMappingHeader {
	private:
		libclassicmap::wii_remote_button_mapping* _ptr;

	public:
		WiiRemoteButtonMapping(libclassicmap::wii_remote_button_mapping* ptr) : ButtonMappingHeader((libclassicmap::button_mapping_header*)ptr) {
			this->_ptr = ptr;
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