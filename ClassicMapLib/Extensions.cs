using System;
using System.Collections.Generic;
using System.Text;

namespace ClassicMapLib {
	public static class Extensions {
		public static string ToHexString(this ushort x) {
			return ((int)x).ToString("X4");
		}
	}
}
