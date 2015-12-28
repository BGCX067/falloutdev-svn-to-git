using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace FrmConverter
{
	public class Frame
	{
		public Frame(int offset)
		{
			Offset = offset;
		}

		public Image FrameImage { get; set; }
		public int Offset { get; set; }
		public int SizeX { get; set; }
		public int SizeY { get; set; }
		public int FrameLength { get; set; }
		public int XOffset { get; set; }
		public int YOffset { get; set; }
		public byte[] FrameData { get; set; }
	}
}
