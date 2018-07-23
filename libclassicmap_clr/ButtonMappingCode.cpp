#pragma once

#include "ButtonMappingCode.h"

#include <set>

using namespace System;
using namespace System::Collections::Generic;

namespace ClassicMap {
	ButtonMappingCode::ButtonMappingCode(String^ name, String^ data) {
		std::string n = msclr::interop::marshal_as<std::string>(name);
		std::string d = msclr::interop::marshal_as<std::string>(data);
		_code = new button_mapping_code(n, d);
	}

	ButtonMappingCode::ButtonMappingCode(String^ name, array<uint8_t>^ data) {
		std::string n = msclr::interop::marshal_as<std::string>(name);
		pin_ptr<uint8_t> d(&data[0]);
		_code = new button_mapping_code(n, d, data->Length);
	}

	IEnumerable<ButtonMappingHeader^>^ ButtonMappingCode::GetButtonMappings() {
		std::set<void*> used;
		auto list = gcnew List<ButtonMappingHeader^>();

		for each (wii_remote_button_mapping* ptr in this->_code->getWiiRemoteButtonMappings())
		{
			if (used.find(ptr) != used.end()) continue;
			list->Add(gcnew WiiRemoteButtonMapping(ptr));
			used.insert(ptr);
		}

		for each (button_mapping_header* ptr in this->_code->getAllButtonMappings())
		{
			if (used.find(ptr) != used.end()) continue;
			list->Add(gcnew ButtonMappingHeader(ptr));
			used.insert(ptr);
		}

		return list;
	}

	String^ ButtonMappingCode::Name::get() {
		return msclr::interop::marshal_as<String^>(this->_code->getName());
	}

	String^ ButtonMappingCode::ToString() {
		return msclr::interop::marshal_as<String^>(this->_code->toString());
	}

	ButtonMappingCode::~ButtonMappingCode() {
		this->!ButtonMappingCode();
	}

	ButtonMappingCode::!ButtonMappingCode() {
		if (this->_code) {
			delete this->_code;
			this->_code = nullptr;
		}
	}
}