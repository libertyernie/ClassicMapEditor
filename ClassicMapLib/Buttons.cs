using System;
using System.Collections.Generic;
using System.Text;

namespace ClassicMapLib
{
	public enum WiiRemoteButton {
		SidewaysDown = 0x0001,
		SidewaysUp = 0x0002,
		SidewaysRight = 0x0004,
		SidewaysLeft = 0x0008,
		Plus = 0x0010,
		Two = 0x0100,
		One = 0x0200,
		B = 0x0400,
		A = 0x0800,
		Minus = 0x1000,
		Z = 0x2000,
		C = 0x4000,
		Home = 0x8000,
	}

	public enum ClassicControllerButton {
		Up = 0x0001,
		Left = 0x0002,
		ZR = 0x0004,
		X = 0x0008,
		A = 0x0010,
		Y = 0x0020,
		B = 0x0040,
		ZL = 0x0080,
		R = 0x0200,
		Plus = 0x0400,
		Home = 0x0800,
		Minus = 0x1000,
		L = 0x2000,
		Down = 0x4000,
		Right = 0x8000,
	}
}
