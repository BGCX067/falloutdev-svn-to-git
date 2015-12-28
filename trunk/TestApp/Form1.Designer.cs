namespace TestApp
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tbpDatReader = new System.Windows.Forms.TabPage();
			this.ucDatReaderTest1 = new TestApp.ucDatReaderTest();
			this.tabControl1.SuspendLayout();
			this.tbpDatReader.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tbpDatReader);
			this.tabControl1.Location = new System.Drawing.Point(12, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(872, 463);
			this.tabControl1.TabIndex = 0;
			// 
			// tbpDatReader
			// 
			this.tbpDatReader.Controls.Add(this.ucDatReaderTest1);
			this.tbpDatReader.Location = new System.Drawing.Point(4, 22);
			this.tbpDatReader.Name = "tbpDatReader";
			this.tbpDatReader.Padding = new System.Windows.Forms.Padding(3);
			this.tbpDatReader.Size = new System.Drawing.Size(864, 437);
			this.tbpDatReader.TabIndex = 0;
			this.tbpDatReader.Text = "Dat Reader";
			this.tbpDatReader.UseVisualStyleBackColor = true;
			// 
			// ucDatReaderTest1
			// 
			this.ucDatReaderTest1.Location = new System.Drawing.Point(3, 6);
			this.ucDatReaderTest1.Name = "ucDatReaderTest1";
			this.ucDatReaderTest1.Size = new System.Drawing.Size(422, 329);
			this.ucDatReaderTest1.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(896, 487);
			this.Controls.Add(this.tabControl1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.tabControl1.ResumeLayout(false);
			this.tbpDatReader.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tbpDatReader;
		private ucDatReaderTest ucDatReaderTest1;
	}
}

