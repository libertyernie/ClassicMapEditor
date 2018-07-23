#pragma once

#include <cstdint>
#include <vector>

#pragma pack(push)

#pragma pack(2)
namespace libclassicmap {
	struct wii_remote_button_mapping
	{
		uint16_t _00;
		uint16_t ccButton;
		uint16_t _04;
		uint16_t _06;
		uint16_t _08;
		uint16_t _lengthParam;
		uint16_t _0c;
		uint16_t wiiButton;
	};
}

#pragma pack(pop)