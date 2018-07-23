#pragma once

#include <cstdint>
#include <vector>

#pragma pack(push)

#pragma pack(2)
namespace libclassicmap {
	struct button_mapping_header
	{
		uint16_t _00;
		uint16_t ccButton;
		uint16_t _04;
		uint16_t _06;
		uint16_t _08;
		uint16_t _lengthParam;

		std::vector<uint16_t> getAdditionalData();
	};
}

#pragma pack(pop)