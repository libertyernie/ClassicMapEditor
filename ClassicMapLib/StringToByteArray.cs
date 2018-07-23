using System;
using System.Collections.Generic;
using System.Text;

namespace ClassicMapLib {
    public static class StringToBytes {
		// Given a character that represents an ASCII letter or number, get the character's hexadecimal value.
		// Returns -1 if the character is not one of: 0123456789ABCDEFabcdef
		public static int ValueOfCharacter(char c) {
			if (c >= '0' && c <= '9') {
				return c - '0';
			} else if (c >= 'a' && c <= 'f') {
				return c - 'a' + 10;
			} else if (c >= 'A' && c <= 'F') {
				return c - 'A' + 10;
			} else {
				return -1;
			}
		}

		// Given a string, extracts and parses all hexadecimal characters (ignoring other characters).
		public static IEnumerable<byte> ParseHexString(string str) {
			bool tens = true;
			int current = 0;
			foreach (char c in str) {
				int value = ValueOfCharacter(c);
				if (value < 0) continue;

				if (tens) {
					current |= value << 4;
					tens = false;
				} else {
					current |= value;
					yield return (byte)current;
					current = 0;
					tens = true;
				}
			}
		}
	}
}
