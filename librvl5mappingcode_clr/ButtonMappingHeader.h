#pragma once

#include <cstdint>
#include <vector>

#pragma pack(push)

#pragma pack(2)
namespace librvl5mappingcode {
	struct ButtonMappingHeader
	{
		uint16_t _00;
		uint16_t ccButton;
		uint16_t _04;
		uint16_t _08;
		uint16_t _0a;
		uint16_t _lengthParam;

		std::vector<uint16_t> getAdditionalData();
	};
}

#pragma pack(pop)