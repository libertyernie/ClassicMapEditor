using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ClassicMapLib {
	[StructLayout(LayoutKind.Explicit, Size = 12)]
	internal struct ButtonMappingHeaderStructure {
		[FieldOffset(2)]
		public ushort classicControllerButton;
		[FieldOffset(10)]
		private ushort _lengthParam;

		public unsafe ushort[] GetAdditionalData() {
			fixed (ButtonMappingHeaderStructure* this_start = &this) {
				void* this_end = this_start + 1;
				ushort* ptr = (ushort*)this_end;
				ushort[] arr = new ushort[(_lengthParam - 4) / sizeof(ushort)];
				for (int i = 0; i < arr.Length; i++) {
					arr[i] = ptr[i];
				}
				return arr;
			}
		}
	}

	public unsafe class ButtonMappingHeader {
		private readonly ButtonMappingHeaderStructure* _ptr;

		public ButtonMappingHeader(void* ptr) {
			_ptr = (ButtonMappingHeaderStructure*)ptr;
		}

		public ClassicControllerButton ClassicControllerButton {
			get {
				return (ClassicControllerButton)_ptr->classicControllerButton;
			}
			set {
				_ptr->classicControllerButton = (ushort)value;
			}
		}

		public IEnumerable<ushort> GetAdditionalData() {
			return _ptr->GetAdditionalData();
		}

		public string GetAdditionalDataAsHexString() {
			return string.Join("", GetAdditionalData().Select(u => u.ToHexString()));
		}
	}
}
