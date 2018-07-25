using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ClassicMapLib {
	public unsafe class ButtonMappingCode : IDisposable {
		public readonly string Name;

		private readonly IntPtr _allocatedMemory;
		private readonly ushort* _dataStart;
		private readonly ushort* _dataEnd;

		public unsafe long LengthInBytes => (byte*)_dataEnd - (byte*)_dataStart;

		public ButtonMappingCode(string name, string data) : this(name, StringToBytes.ParseHexString(data).ToArray()) { }

		public ButtonMappingCode(string name, byte[] data) {
			this.Name = name;

			_allocatedMemory = Marshal.AllocHGlobal(data.Length);
			this._dataStart = (ushort*)_allocatedMemory;
			this._dataEnd = (ushort*)(_allocatedMemory + data.Length);

			for (int i = 0; i + 1 < data.Length; i += 2) {
				this._dataStart[i / 2] = (ushort)(data[i] << 8 | data[i + 1]);
			}

			bool gct = LengthInBytes >= 16
				&& _dataStart[0] == 0x00d0
				&& _dataStart[1] == 0xc0de
				&& _dataStart[2] == 0x00d0
				&& _dataStart[3] == 0xc0de;
			if (gct) {
				this._dataStart += 4;
				for (ushort* ptr = _dataStart; ptr + 3 < _dataEnd; ptr++) {
					bool end = ptr[0] == 0xf000
						&& ptr[1] == 0x0000
						&& ptr[2] == 0x0000
						&& ptr[3] == 0x0000;
					if (end) {
						this._dataEnd = ptr;
						break;
					}
				}
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

		public unsafe byte[] ExportToGCT() {
			byte[] data = new byte[LengthInBytes + 16];
			data[0] = 0x00;
			data[1] = 0xd0;
			data[2] = 0xc0;
			data[3] = 0xde;
			data[4] = 0x00;
			data[5] = 0xd0;
			data[6] = 0xc0;
			data[7] = 0xde;
			for (int i = 0; i < LengthInBytes; i += 2) {
				data[8 + i] = (byte)(_dataStart[i / 2] >> 8);
				data[8 + i + 1] = (byte)(_dataStart[i / 2]);
			}
			data[data.Length - 8] = 0xf0;
			data[data.Length - 7] = 0x00;
			data[data.Length - 6] = 0x00;
			data[data.Length - 5] = 0x00;
			data[data.Length - 4] = 0x00;
			data[data.Length - 3] = 0x00;
			data[data.Length - 2] = 0x00;
			data[data.Length - 1] = 0x00;
			return data;
		}

		public unsafe override string ToString() {
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(Name);
			
			ushort* ptr = _dataStart;
			int i = 0;
			while (ptr < _dataEnd) {
				sb.Append((*ptr).ToHexString());
				if (i % 4 == 1) sb.Append(' ');
				if (i % 4 == 3) sb.Append(Environment.NewLine);
				ptr++;
				i++;
			}

			return sb.ToString().Trim();
		}

		#region IDisposable Support
		private bool disposedValue = false;

		protected virtual void Dispose(bool disposing) {
			if (!disposedValue) {
				Marshal.FreeHGlobal(_allocatedMemory);
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
