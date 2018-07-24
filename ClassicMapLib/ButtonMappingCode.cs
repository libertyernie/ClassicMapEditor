using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ClassicMapLib {
	public unsafe class ButtonMappingCode : IDisposable {
		public readonly string Name;

		private ushort* _dataStart;
		private ushort* _dataEnd;

		public ButtonMappingCode(string name, string data) : this(name, StringToBytes.ParseHexString(data).ToArray()) { }

		public ButtonMappingCode(string name, byte[] data) {
			this.Name = name;

			IntPtr ptr = Marshal.AllocHGlobal(data.Length);
			this._dataStart = (ushort*)ptr;
			this._dataEnd = (ushort*)(ptr + data.Length);

			for (int i = 0; i < data.Length; i += 2) {
				this._dataStart[i / 2] = (ushort)(data[i] << 8 | data[i + 1]);
			}
		}

		public IEnumerable<ButtonMappingHeader> GetButtonMappings() {
			var list = new List<ButtonMappingHeader>();
			for (ushort* ptr = _dataStart; ptr + 6 < _dataEnd; ptr++) {
				bool match1 =
					ptr[0] == 0x70A4 &&
					ptr[2] == 0x2C04 &&
					ptr[3] == 0x0000 &&
					ptr[4] == 0x4182;
				if (match1) {
					bool match2 = ptr[5] == 0x0008 && ptr[6] == 0x60C6;
					if (match2) {
						list.Add(new WiiRemoteButtonMapping(ptr));
					} else {
						list.Add(new ButtonMappingHeader(ptr));
					}
				}
			}
			return list;
		}

		public unsafe override string ToString() {
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(Name);

			bool gct = _dataStart[0] == 0x00d0
				&& _dataStart[1] == 0xc0de
				&& _dataStart[2] == 0x00d0
				&& _dataStart[3] == 0xc0de;

			if (!gct) {
				ushort* ptr = _dataStart;
				int i = 0;
				while (ptr < _dataEnd) {
					sb.Append((*ptr).ToHexString());
					if (i % 4 == 1) sb.Append(' ');
					if (i % 4 == 3) sb.Append(Environment.NewLine);
					ptr++;
					i++;
				}
			}

			return sb.ToString().Trim();
		}

		#region IDisposable Support
		private bool disposedValue = false;

		protected virtual void Dispose(bool disposing) {
			if (!disposedValue) {
				Marshal.FreeHGlobal((IntPtr)_dataStart);
				disposedValue = true;
			}
		}

		~ButtonMappingCode() {
			Dispose(false);
		}
		
		public void Dispose() {
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		#endregion
	}
}
