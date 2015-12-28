using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrmConverter;
using DatReader;

namespace TestApp
{
	public partial class ucDatReaderTest : UserControl
	{
		public ucDatReaderTest()
		{
			InitializeComponent();
			timer.Enabled = true;
			timer.Interval = 100;
			timer.Tick += new EventHandler(timer_Tick);
			pBox1.Location = new Point(50, 50);

			clientDC = this.CreateGraphics();
		}

		private Bitmap offScreen;
		private Graphics offScreenDC;
		private Graphics clientDC;

		int px = 50;
		int py = 50;

		void timer_Tick(object sender, EventArgs e)
		{
			if (_frames.Count == 0)
				return;

			if (_currentFrame > _frames.Count - 1 || _currentFrame == 0)
			{
				pBox1.Location = new Point(50, 50);
				_currentFrame = 0;
				px = 150;
				py = 150;
			}


           
			Frame frame = _frames[_currentFrame];
			Image image = Indexed2Image(frame.FrameImage, PixelFormat.Format24bppRgb);

			offScreenDC = Graphics.FromImage(image);

			int xp = pBox1.Location.X;
			int yp = pBox1.Location.Y;

			int x = frame.SizeX;
			int y = frame.SizeY;

			int newposX = xp;
			int newposY = yp;

//			pBox1.Location = new Point(xp + frame.XOffset, yp + frame.YOffset);

			pBox1.Location = new Point(xp - (x - px) + frame.XOffset, yp - (y - py) + frame.YOffset);
			clientDC.Clear(Color.Black);
			clientDC.DrawImage(image, xp - (x - px) + frame.XOffset, yp - (y - py) + frame.YOffset);
			px = x;
			py = y;
			pBox1.Visible = false;
			pBox1.Width = image.Width;
			pBox1.Height = image.Height;
			pBox1.Image = image;
			pBox1.Invalidate();
//			pBox1.Visible = true;
			_currentFrame++;
		}

		public static Image Indexed2Image(Image img, System.Drawing.Imaging.PixelFormat fmt)
		{
			Image bmp = new Bitmap(img.Width, img.Height, fmt);
			Graphics gr = Graphics.FromImage(bmp);
			gr.DrawImage(img, 0, 0);
			gr.Dispose();
			return bmp;
		}

		List<Frame> _frames = new List<Frame>();

		private int _currentFrame = 0;

		DatFile dr;
		int currentEntry = 2220;

		Timer timer = new Timer();

		private void button1_Click(object sender, EventArgs e)
		{
			dr = new DatFile(textBox1.Text);
			string currentEntryFileName = dr.Entries[currentEntry].FileName.ToLower();
			while (!currentEntryFileName.EndsWith(".frm"))
			{
				currentEntry++;
				currentEntryFileName = dr.Entries[currentEntry].FileName.ToLower();
			}

			Frame frame = FrmConverter.FrmConverter.GetImage(dr.GetFile(dr.Entries[currentEntry]));

			Image image = frame.FrameImage;
			pBox1.Width = image.Width;
			pBox1.Height = image.Height;
			pBox1.Image = image;
			currentEntry++;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			string currentEntryFileName = dr.Entries[currentEntry].FileName.ToLower();
			while (!currentEntryFileName.EndsWith(".frm"))
			{
				currentEntry++;
				currentEntryFileName = dr.Entries[currentEntry].FileName.ToLower();
			}
			_frames = FrmConverter.FrmConverter.GetImages(dr.GetFile(dr.Entries[currentEntry]));
			_currentFrame = 0;
			currentEntry++;
		}
	}
}
