#include "ButtonMappingHeader.h"

#include <vector>
using std::vector;

namespace libclassicmap {
	vector<uint16_t> ButtonMappingHeader::getAdditionalData() {
		vector<uint16_t> vec;

		uint16_t* ptr_from_header_end = (uint16_t*)(this + 1);
		size_t size = (this->_lengthParam - 4) / sizeof(uint16_t);

		for (size_t i = 0; i < size; i++) {
			vec.push_back(ptr_from_header_end[i]);
		}
		return vec;
	}
}