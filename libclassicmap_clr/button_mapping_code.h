#pragma once

#include "button_mapping_header.h"
#include "wii_remote_button_mapping.h"
#include <string>

namespace libclassicmap {
	class button_mapping_code
	{
	private:
		std::string _name;
		uint16_t* _dataStart;
		uint16_t* _dataEnd;
	public:
		button_mapping_code(std::string name, std::string data);
		button_mapping_code(std::string name, const void* data, size_t dataLength);
		std::vector<button_mapping_header*> getButtonMappings();
		std::vector<wii_remote_button_mapping*> getWiiRemoteButtonMappings();
		std::string getName();
		std::string toString();
		~button_mapping_code();
	};
}
