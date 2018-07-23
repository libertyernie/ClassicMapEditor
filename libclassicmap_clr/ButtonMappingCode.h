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
		ButtonMappingCode(String^ name, String^ data) {
			std::string n = msclr::interop::marshal_as<std::string>(name);
			std::string d = msclr::interop::marshal_as<std::string>(data);
			_code = new button_mapping_code(n, d);
		}

		ButtonMappingCode(String^ name, array<uint8_t>^ data) {
			std::string n = msclr::interop::marshal_as<std::string>(name);
			pin_ptr<uint8_t> d(&data[0]);
			_code = new button_mapping_code(n, d, data->Length);
		}

		IEnumerable<ButtonMappingHeader^>^ GetButtonMappings() {
			auto list = gcnew List<ButtonMappingHeader^>();
			for each (button_mapping_header* ptr in this->_code->getButtonMappings())
			{
				list->Add(gcnew ButtonMappingHeader(ptr));
			}
			return list;
		}

		IEnumerable<WiiRemoteButtonMapping^>^ GetWiiRemoteButtonMappings() {
			auto list = gcnew List<WiiRemoteButtonMapping^>();
			for each (wii_remote_button_mapping* ptr in this->_code->getWiiRemoteButtonMappings())
			{
				list->Add(gcnew WiiRemoteButtonMapping(ptr));
			}
			return list;
		}

		property String^ Name {
			String^ get();
		}

		String^ ToString() override {
			return msclr::interop::marshal_as<String^>(this->_code->getName());
		}

		~ButtonMappingCode() {
			this->!ButtonMappingCode();
		}

		!ButtonMappingCode() {
			if (this->_code) {
				delete this->_code;
				this->_code = nullptr;
			}
		}
	};
}