using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatReader
{
	public class DirTreeEntry : IComparable<DirTreeEntry>
    {
		public DirTreeEntry() { }

		public DirTreeEntry(string fileName)
		{
			FileName = fileName;
		}

		public int FileNameSize { get; set; }
		public string FileName { get; set; }
		public bool IsCompressed { get; set; }
		public int RealSize { get; set; }
		public int PackedSize { get; set; }
		public int Offset { get; set; }
		public int EndOffset { get; set; }
		
		public override string ToString()
		{
			return FileName;
		}

		public int CompareTo(DirTreeEntry other)
		{
			return this.FileName.CompareTo(other.FileName);
		}
    }
}
