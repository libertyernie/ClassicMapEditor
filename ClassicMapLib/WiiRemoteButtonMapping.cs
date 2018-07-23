using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ClassicMapLib {
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	internal struct WiiRemoteButtonMappingStructure {
		[FieldOffset(2)]
		public ushort classicControllerButton;
		[FieldOffset(14)]
		public ushort wiiRemoteButton;
	}

	public unsafe class WiiRemoteButtonMapping : ButtonMappingHeader {
		private readonly WiiRemoteButtonMappingStructure* _ptr;

		public WiiRemoteButtonMapping(void* ptr) : base(ptr) {
			_ptr = (WiiRemoteButtonMappingStructure*)ptr;
		}

		public WiiRemoteButton WiiRemoteButton {
			get {
				return (WiiRemoteButton)_ptr->wiiRemoteButton;
			}
			set {
				_ptr->wiiRemoteButton = (ushort)value;
			}
		}
	}
}
