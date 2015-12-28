using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Timers;
using System.Threading;
namespace ObjectEditor
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.TabPage Items;
		private System.Windows.Forms.TabPage Critters;
		private System.Windows.Forms.TabPage Scenery;
		private System.Windows.Forms.TabPage Walls;
		private System.Windows.Forms.TabPage Tiles;
		private System.Windows.Forms.TabPage Misc;
		private System.Windows.Forms.Button button1;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Windows.Forms.TabPage Armor;
		private System.Windows.Forms.TabPage Container;
		private System.Windows.Forms.TabPage Drug;
		private System.Windows.Forms.TabPage Weapon;
		private System.Windows.Forms.TabPage Ammo;
		private System.Windows.Forms.TabPage Misc1;
		private System.Windows.Forms.TabPage Key;
		private System.Windows.Forms.TabControl ItemsChild;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.TextBox ObjectFullIDsce;
		private System.Windows.Forms.TextBox ObjectIDsce;
		private System.Windows.Forms.RichTextBox Descsce;
		private System.Windows.Forms.TextBox FrameIDTypeS;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.TextBox LightDistanceS;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.TextBox LightIntensityS;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.TextBox SceneryTypeS;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.TextBox MaterialTypeS;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.ListBox comboBoxsce;
		private System.Windows.Forms.Label label30;
		private static string[] dir;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TextBox FrameNameS;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.ListBox comboBoxtil;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.TextBox FrameNametil;
		private System.Windows.Forms.TextBox LightIntensitytil;
		private System.Windows.Forms.TextBox LightDistancetil;
		private System.Windows.Forms.TextBox ObjectFullIDtil;
		private System.Windows.Forms.TextBox ObjectIDtil;
		private System.Windows.Forms.RichTextBox Desctil;
		private System.Windows.Forms.TextBox FrameIDTypetil;
		private System.Windows.Forms.TextBox FrameNamewal;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.ListBox comboBoxwal;
		private System.Windows.Forms.TextBox LightIntensitywal;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.TextBox LightDistancewal;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.TextBox FrameIDTypewal;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.TextBox ObjectFullIDwal;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.TextBox ObjectIDwal;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.RichTextBox Descwal;
		private System.Windows.Forms.Label label47;
		private System.Windows.Forms.TextBox MaterialTypewal;
		private System.Windows.Forms.Label label48;
		private System.Windows.Forms.TextBox Sidewal;
		private System.Windows.Forms.Label label49;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox FrameNamemis;
		private System.Windows.Forms.ListBox comboBoxmis;
		private System.Windows.Forms.TextBox LightIntensitymis;
		private System.Windows.Forms.TextBox LightDistancemis;
		private System.Windows.Forms.TextBox FrameIDTypemis;
		private System.Windows.Forms.TextBox ObjectFullIDmis;
		private System.Windows.Forms.TextBox ObjectIDmis;
		private System.Windows.Forms.RichTextBox Descmis;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox FrameNamecri;
		private System.Windows.Forms.ListBox comboBoxcri;
		private System.Windows.Forms.TextBox LightIntensitycri;
		private System.Windows.Forms.TextBox LightDistancecri;
		private System.Windows.Forms.TextBox FrameIDTypecri;
		private System.Windows.Forms.TextBox ObjectFullIDcri;
		private System.Windows.Forms.TextBox ObjectIDcri;
		private System.Windows.Forms.RichTextBox Desccri;
		private System.Windows.Forms.Label FramePath;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.Items = new System.Windows.Forms.TabPage();
			this.ItemsChild = new System.Windows.Forms.TabControl();
			this.Armor = new System.Windows.Forms.TabPage();
			this.Container = new System.Windows.Forms.TabPage();
			this.Drug = new System.Windows.Forms.TabPage();
			this.Weapon = new System.Windows.Forms.TabPage();
			this.Ammo = new System.Windows.Forms.TabPage();
			this.Misc1 = new System.Windows.Forms.TabPage();
			this.Key = new System.Windows.Forms.TabPage();
			this.Critters = new System.Windows.Forms.TabPage();
			this.Scenery = new System.Windows.Forms.TabPage();
			this.FrameNameS = new System.Windows.Forms.TextBox();
			this.label30 = new System.Windows.Forms.Label();
			this.comboBoxsce = new System.Windows.Forms.ListBox();
			this.MaterialTypeS = new System.Windows.Forms.TextBox();
			this.label29 = new System.Windows.Forms.Label();
			this.SceneryTypeS = new System.Windows.Forms.TextBox();
			this.label28 = new System.Windows.Forms.Label();
			this.LightIntensityS = new System.Windows.Forms.TextBox();
			this.label27 = new System.Windows.Forms.Label();
			this.LightDistanceS = new System.Windows.Forms.TextBox();
			this.label26 = new System.Windows.Forms.Label();
			this.FrameIDTypeS = new System.Windows.Forms.TextBox();
			this.label25 = new System.Windows.Forms.Label();
			this.ObjectFullIDsce = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.ObjectIDsce = new System.Windows.Forms.TextBox();
			this.label22 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.Descsce = new System.Windows.Forms.RichTextBox();
			this.label24 = new System.Windows.Forms.Label();
			this.Misc = new System.Windows.Forms.TabPage();
			this.FrameNamemis = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBoxmis = new System.Windows.Forms.ListBox();
			this.LightIntensitymis = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.LightDistancemis = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.FrameIDTypemis = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.ObjectFullIDmis = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.ObjectIDmis = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.Descmis = new System.Windows.Forms.RichTextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.Tiles = new System.Windows.Forms.TabPage();
			this.FrameNametil = new System.Windows.Forms.TextBox();
			this.label32 = new System.Windows.Forms.Label();
			this.comboBoxtil = new System.Windows.Forms.ListBox();
			this.LightIntensitytil = new System.Windows.Forms.TextBox();
			this.label35 = new System.Windows.Forms.Label();
			this.LightDistancetil = new System.Windows.Forms.TextBox();
			this.label36 = new System.Windows.Forms.Label();
			this.FrameIDTypetil = new System.Windows.Forms.TextBox();
			this.label37 = new System.Windows.Forms.Label();
			this.ObjectFullIDtil = new System.Windows.Forms.TextBox();
			this.label38 = new System.Windows.Forms.Label();
			this.ObjectIDtil = new System.Windows.Forms.TextBox();
			this.label39 = new System.Windows.Forms.Label();
			this.label40 = new System.Windows.Forms.Label();
			this.Desctil = new System.Windows.Forms.RichTextBox();
			this.label41 = new System.Windows.Forms.Label();
			this.Walls = new System.Windows.Forms.TabPage();
			this.MaterialTypewal = new System.Windows.Forms.TextBox();
			this.label48 = new System.Windows.Forms.Label();
			this.Sidewal = new System.Windows.Forms.TextBox();
			this.label49 = new System.Windows.Forms.Label();
			this.FrameNamewal = new System.Windows.Forms.TextBox();
			this.label33 = new System.Windows.Forms.Label();
			this.comboBoxwal = new System.Windows.Forms.ListBox();
			this.LightIntensitywal = new System.Windows.Forms.TextBox();
			this.label34 = new System.Windows.Forms.Label();
			this.LightDistancewal = new System.Windows.Forms.TextBox();
			this.label42 = new System.Windows.Forms.Label();
			this.FrameIDTypewal = new System.Windows.Forms.TextBox();
			this.label43 = new System.Windows.Forms.Label();
			this.ObjectFullIDwal = new System.Windows.Forms.TextBox();
			this.label44 = new System.Windows.Forms.Label();
			this.ObjectIDwal = new System.Windows.Forms.TextBox();
			this.label45 = new System.Windows.Forms.Label();
			this.label46 = new System.Windows.Forms.Label();
			this.Descwal = new System.Windows.Forms.RichTextBox();
			this.label47 = new System.Windows.Forms.Label();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.button1 = new System.Windows.Forms.Button();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.button2 = new System.Windows.Forms.Button();
			this.label31 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.FrameNamecri = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.comboBoxcri = new System.Windows.Forms.ListBox();
			this.LightIntensitycri = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.LightDistancecri = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.FrameIDTypecri = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.ObjectFullIDcri = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.ObjectIDcri = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.Desccri = new System.Windows.Forms.RichTextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.FramePath = new System.Windows.Forms.Label();
			this.tabControl1.SuspendLayout();
			this.Items.SuspendLayout();
			this.ItemsChild.SuspendLayout();
			this.Critters.SuspendLayout();
			this.Scenery.SuspendLayout();
			this.Misc.SuspendLayout();
			this.Tiles.SuspendLayout();
			this.Walls.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.Items,
																					  this.Critters,
																					  this.Scenery,
																					  this.Misc,
																					  this.Tiles,
																					  this.Walls});
			this.tabControl1.Location = new System.Drawing.Point(8, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(472, 544);
			this.tabControl1.TabIndex = 0;
			// 
			// Items
			// 
			this.Items.Controls.AddRange(new System.Windows.Forms.Control[] {
																				this.ItemsChild});
			this.Items.Location = new System.Drawing.Point(4, 22);
			this.Items.Name = "Items";
			this.Items.Size = new System.Drawing.Size(464, 518);
			this.Items.TabIndex = 0;
			this.Items.Text = "Items";
			// 
			// ItemsChild
			// 
			this.ItemsChild.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.Armor,
																					 this.Container,
																					 this.Drug,
																					 this.Weapon,
																					 this.Ammo,
																					 this.Misc1,
																					 this.Key});
			this.ItemsChild.Location = new System.Drawing.Point(8, 8);
			this.ItemsChild.Name = "ItemsChild";
			this.ItemsChild.SelectedIndex = 0;
			this.ItemsChild.Size = new System.Drawing.Size(448, 504);
			this.ItemsChild.TabIndex = 0;
			// 
			// Armor
			// 
			this.Armor.Location = new System.Drawing.Point(4, 22);
			this.Armor.Name = "Armor";
			this.Armor.Size = new System.Drawing.Size(440, 478);
			this.Armor.TabIndex = 0;
			this.Armor.Text = "Armor";
			// 
			// Container
			// 
			this.Container.Location = new System.Drawing.Point(4, 22);
			this.Container.Name = "Container";
			this.Container.Size = new System.Drawing.Size(720, 286);
			this.Container.TabIndex = 1;
			this.Container.Text = "Container";
			// 
			// Drug
			// 
			this.Drug.Location = new System.Drawing.Point(4, 22);
			this.Drug.Name = "Drug";
			this.Drug.Size = new System.Drawing.Size(720, 286);
			this.Drug.TabIndex = 2;
			this.Drug.Text = "Drug";
			// 
			// Weapon
			// 
			this.Weapon.Location = new System.Drawing.Point(4, 22);
			this.Weapon.Name = "Weapon";
			this.Weapon.Size = new System.Drawing.Size(720, 286);
			this.Weapon.TabIndex = 3;
			this.Weapon.Text = "Weapon";
			// 
			// Ammo
			// 
			this.Ammo.Location = new System.Drawing.Point(4, 22);
			this.Ammo.Name = "Ammo";
			this.Ammo.Size = new System.Drawing.Size(720, 286);
			this.Ammo.TabIndex = 4;
			this.Ammo.Text = "Ammo";
			// 
			// Misc1
			// 
			this.Misc1.Location = new System.Drawing.Point(4, 22);
			this.Misc1.Name = "Misc1";
			this.Misc1.Size = new System.Drawing.Size(720, 286);
			this.Misc1.TabIndex = 5;
			this.Misc1.Text = "Misc";
			// 
			// Key
			// 
			this.Key.Location = new System.Drawing.Point(4, 22);
			this.Key.Name = "Key";
			this.Key.Size = new System.Drawing.Size(720, 286);
			this.Key.TabIndex = 6;
			this.Key.Text = "Key";
			// 
			// Critters
			// 
			this.Critters.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.FrameNamecri,
																				   this.label9,
																				   this.comboBoxcri,
																				   this.LightIntensitycri,
																				   this.label10,
																				   this.LightDistancecri,
																				   this.label11,
																				   this.FrameIDTypecri,
																				   this.label12,
																				   this.ObjectFullIDcri,
																				   this.label13,
																				   this.ObjectIDcri,
																				   this.label14,
																				   this.label15,
																				   this.Desccri,
																				   this.label16});
			this.Critters.Location = new System.Drawing.Point(4, 22);
			this.Critters.Name = "Critters";
			this.Critters.Size = new System.Drawing.Size(464, 518);
			this.Critters.TabIndex = 1;
			this.Critters.Text = "Critters";
			this.Critters.Paint += new System.Windows.Forms.PaintEventHandler(this.Critters_Paint);
			// 
			// Scenery
			// 
			this.Scenery.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.FrameNameS,
																				  this.label30,
																				  this.comboBoxsce,
																				  this.MaterialTypeS,
																				  this.label29,
																				  this.SceneryTypeS,
																				  this.label28,
																				  this.LightIntensityS,
																				  this.label27,
																				  this.LightDistanceS,
																				  this.label26,
																				  this.FrameIDTypeS,
																				  this.label25,
																				  this.ObjectFullIDsce,
																				  this.label21,
																				  this.ObjectIDsce,
																				  this.label22,
																				  this.label23,
																				  this.Descsce,
																				  this.label24});
			this.Scenery.Location = new System.Drawing.Point(4, 22);
			this.Scenery.Name = "Scenery";
			this.Scenery.Size = new System.Drawing.Size(464, 518);
			this.Scenery.TabIndex = 2;
			this.Scenery.Text = "Scenery";
			this.Scenery.Paint += new System.Windows.Forms.PaintEventHandler(this.Scenery_Paint);
			// 
			// FrameNameS
			// 
			this.FrameNameS.Location = new System.Drawing.Point(200, 280);
			this.FrameNameS.Name = "FrameNameS";
			this.FrameNameS.Size = new System.Drawing.Size(72, 20);
			this.FrameNameS.TabIndex = 40;
			this.FrameNameS.Text = "";
			// 
			// label30
			// 
			this.label30.Location = new System.Drawing.Point(128, 280);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(80, 16);
			this.label30.TabIndex = 39;
			this.label30.Text = "FrameName";
			// 
			// comboBoxsce
			// 
			this.comboBoxsce.Location = new System.Drawing.Point(8, 24);
			this.comboBoxsce.Name = "comboBoxsce";
			this.comboBoxsce.Size = new System.Drawing.Size(112, 485);
			this.comboBoxsce.TabIndex = 36;
			this.comboBoxsce.SelectedIndexChanged += new System.EventHandler(this.comboBoxsce_SelectedIndexChanged_1);
			// 
			// MaterialTypeS
			// 
			this.MaterialTypeS.Location = new System.Drawing.Point(200, 256);
			this.MaterialTypeS.Name = "MaterialTypeS";
			this.MaterialTypeS.Size = new System.Drawing.Size(168, 20);
			this.MaterialTypeS.TabIndex = 35;
			this.MaterialTypeS.Text = "";
			// 
			// label29
			// 
			this.label29.Location = new System.Drawing.Point(128, 256);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(80, 16);
			this.label29.TabIndex = 34;
			this.label29.Text = "MaterialType";
			// 
			// SceneryTypeS
			// 
			this.SceneryTypeS.Location = new System.Drawing.Point(200, 232);
			this.SceneryTypeS.Name = "SceneryTypeS";
			this.SceneryTypeS.Size = new System.Drawing.Size(168, 20);
			this.SceneryTypeS.TabIndex = 33;
			this.SceneryTypeS.Text = "";
			// 
			// label28
			// 
			this.label28.Location = new System.Drawing.Point(128, 232);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(80, 16);
			this.label28.TabIndex = 32;
			this.label28.Text = "SceneryType";
			// 
			// LightIntensityS
			// 
			this.LightIntensityS.Location = new System.Drawing.Point(200, 208);
			this.LightIntensityS.Name = "LightIntensityS";
			this.LightIntensityS.Size = new System.Drawing.Size(32, 20);
			this.LightIntensityS.TabIndex = 31;
			this.LightIntensityS.Text = "";
			// 
			// label27
			// 
			this.label27.Location = new System.Drawing.Point(128, 208);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(80, 16);
			this.label27.TabIndex = 30;
			this.label27.Text = "LightIntensity";
			// 
			// LightDistanceS
			// 
			this.LightDistanceS.Location = new System.Drawing.Point(200, 184);
			this.LightDistanceS.Name = "LightDistanceS";
			this.LightDistanceS.Size = new System.Drawing.Size(32, 20);
			this.LightDistanceS.TabIndex = 29;
			this.LightDistanceS.Text = "";
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(128, 184);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(80, 16);
			this.label26.TabIndex = 28;
			this.label26.Text = "LightDistance";
			// 
			// FrameIDTypeS
			// 
			this.FrameIDTypeS.Location = new System.Drawing.Point(200, 160);
			this.FrameIDTypeS.Name = "FrameIDTypeS";
			this.FrameIDTypeS.Size = new System.Drawing.Size(72, 20);
			this.FrameIDTypeS.TabIndex = 27;
			this.FrameIDTypeS.Text = "";
			// 
			// label25
			// 
			this.label25.Location = new System.Drawing.Point(128, 160);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(80, 16);
			this.label25.TabIndex = 26;
			this.label25.Text = "FrameIDType";
			// 
			// ObjectFullIDsce
			// 
			this.ObjectFullIDsce.Location = new System.Drawing.Point(192, 24);
			this.ObjectFullIDsce.Name = "ObjectFullIDsce";
			this.ObjectFullIDsce.Size = new System.Drawing.Size(48, 20);
			this.ObjectFullIDsce.TabIndex = 25;
			this.ObjectFullIDsce.Text = "";
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(192, 8);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(72, 16);
			this.label21.TabIndex = 24;
			this.label21.Text = "ObjectFullID";
			// 
			// ObjectIDsce
			// 
			this.ObjectIDsce.Location = new System.Drawing.Point(128, 24);
			this.ObjectIDsce.Name = "ObjectIDsce";
			this.ObjectIDsce.Size = new System.Drawing.Size(48, 20);
			this.ObjectIDsce.TabIndex = 23;
			this.ObjectIDsce.Text = "";
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(128, 8);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(48, 16);
			this.label22.TabIndex = 22;
			this.label22.Text = "ObjectID";
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(128, 48);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(100, 16);
			this.label23.TabIndex = 21;
			this.label23.Text = "Object Description";
			// 
			// Descsce
			// 
			this.Descsce.Location = new System.Drawing.Point(128, 64);
			this.Descsce.Name = "Descsce";
			this.Descsce.Size = new System.Drawing.Size(240, 88);
			this.Descsce.TabIndex = 20;
			this.Descsce.Text = "";
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(8, 8);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(72, 16);
			this.label24.TabIndex = 18;
			this.label24.Text = "Object Name";
			// 
			// Misc
			// 
			this.Misc.Controls.AddRange(new System.Windows.Forms.Control[] {
																			   this.FrameNamemis,
																			   this.label1,
																			   this.comboBoxmis,
																			   this.LightIntensitymis,
																			   this.label2,
																			   this.LightDistancemis,
																			   this.label3,
																			   this.FrameIDTypemis,
																			   this.label4,
																			   this.ObjectFullIDmis,
																			   this.label5,
																			   this.ObjectIDmis,
																			   this.label6,
																			   this.label7,
																			   this.Descmis,
																			   this.label8});
			this.Misc.Location = new System.Drawing.Point(4, 22);
			this.Misc.Name = "Misc";
			this.Misc.Size = new System.Drawing.Size(464, 518);
			this.Misc.TabIndex = 6;
			this.Misc.Text = "Misc";
			this.Misc.Paint += new System.Windows.Forms.PaintEventHandler(this.Misc_Paint);
			// 
			// FrameNamemis
			// 
			this.FrameNamemis.Location = new System.Drawing.Point(200, 232);
			this.FrameNamemis.Name = "FrameNamemis";
			this.FrameNamemis.Size = new System.Drawing.Size(72, 20);
			this.FrameNamemis.TabIndex = 76;
			this.FrameNamemis.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(128, 232);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 16);
			this.label1.TabIndex = 75;
			this.label1.Text = "FrameName";
			// 
			// comboBoxmis
			// 
			this.comboBoxmis.Location = new System.Drawing.Point(8, 24);
			this.comboBoxmis.Name = "comboBoxmis";
			this.comboBoxmis.Size = new System.Drawing.Size(112, 485);
			this.comboBoxmis.TabIndex = 74;
			this.comboBoxmis.SelectedIndexChanged += new System.EventHandler(this.comboBoxmis_SelectedIndexChanged);
			// 
			// LightIntensitymis
			// 
			this.LightIntensitymis.Location = new System.Drawing.Point(200, 208);
			this.LightIntensitymis.Name = "LightIntensitymis";
			this.LightIntensitymis.Size = new System.Drawing.Size(32, 20);
			this.LightIntensitymis.TabIndex = 73;
			this.LightIntensitymis.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(128, 208);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 16);
			this.label2.TabIndex = 72;
			this.label2.Text = "LightIntensity";
			// 
			// LightDistancemis
			// 
			this.LightDistancemis.Location = new System.Drawing.Point(200, 184);
			this.LightDistancemis.Name = "LightDistancemis";
			this.LightDistancemis.Size = new System.Drawing.Size(32, 20);
			this.LightDistancemis.TabIndex = 71;
			this.LightDistancemis.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(128, 184);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 16);
			this.label3.TabIndex = 70;
			this.label3.Text = "LightDistance";
			// 
			// FrameIDTypemis
			// 
			this.FrameIDTypemis.Location = new System.Drawing.Point(200, 160);
			this.FrameIDTypemis.Name = "FrameIDTypemis";
			this.FrameIDTypemis.Size = new System.Drawing.Size(72, 20);
			this.FrameIDTypemis.TabIndex = 69;
			this.FrameIDTypemis.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(128, 160);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 16);
			this.label4.TabIndex = 68;
			this.label4.Text = "FrameIDType";
			// 
			// ObjectFullIDmis
			// 
			this.ObjectFullIDmis.Location = new System.Drawing.Point(192, 24);
			this.ObjectFullIDmis.Name = "ObjectFullIDmis";
			this.ObjectFullIDmis.Size = new System.Drawing.Size(48, 20);
			this.ObjectFullIDmis.TabIndex = 67;
			this.ObjectFullIDmis.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(192, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 16);
			this.label5.TabIndex = 66;
			this.label5.Text = "ObjectFullID";
			// 
			// ObjectIDmis
			// 
			this.ObjectIDmis.Location = new System.Drawing.Point(128, 24);
			this.ObjectIDmis.Name = "ObjectIDmis";
			this.ObjectIDmis.Size = new System.Drawing.Size(48, 20);
			this.ObjectIDmis.TabIndex = 65;
			this.ObjectIDmis.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(128, 8);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(48, 16);
			this.label6.TabIndex = 64;
			this.label6.Text = "ObjectID";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(128, 48);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 16);
			this.label7.TabIndex = 63;
			this.label7.Text = "Object Description";
			// 
			// Descmis
			// 
			this.Descmis.Location = new System.Drawing.Point(128, 64);
			this.Descmis.Name = "Descmis";
			this.Descmis.Size = new System.Drawing.Size(240, 88);
			this.Descmis.TabIndex = 62;
			this.Descmis.Text = "";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(8, 8);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(72, 16);
			this.label8.TabIndex = 61;
			this.label8.Text = "Object Name";
			// 
			// Tiles
			// 
			this.Tiles.Controls.AddRange(new System.Windows.Forms.Control[] {
																				this.FrameNametil,
																				this.label32,
																				this.comboBoxtil,
																				this.LightIntensitytil,
																				this.label35,
																				this.LightDistancetil,
																				this.label36,
																				this.FrameIDTypetil,
																				this.label37,
																				this.ObjectFullIDtil,
																				this.label38,
																				this.ObjectIDtil,
																				this.label39,
																				this.label40,
																				this.Desctil,
																				this.label41});
			this.Tiles.Location = new System.Drawing.Point(4, 22);
			this.Tiles.Name = "Tiles";
			this.Tiles.Size = new System.Drawing.Size(464, 518);
			this.Tiles.TabIndex = 4;
			this.Tiles.Text = "Tiles";
			this.Tiles.Paint += new System.Windows.Forms.PaintEventHandler(this.Tiles_Paint);
			// 
			// FrameNametil
			// 
			this.FrameNametil.Location = new System.Drawing.Point(200, 232);
			this.FrameNametil.Name = "FrameNametil";
			this.FrameNametil.Size = new System.Drawing.Size(72, 20);
			this.FrameNametil.TabIndex = 60;
			this.FrameNametil.Text = "";
			// 
			// label32
			// 
			this.label32.Location = new System.Drawing.Point(128, 232);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(80, 16);
			this.label32.TabIndex = 59;
			this.label32.Text = "FrameName";
			// 
			// comboBoxtil
			// 
			this.comboBoxtil.Location = new System.Drawing.Point(8, 24);
			this.comboBoxtil.Name = "comboBoxtil";
			this.comboBoxtil.Size = new System.Drawing.Size(112, 485);
			this.comboBoxtil.TabIndex = 58;
			this.comboBoxtil.SelectedIndexChanged += new System.EventHandler(this.comboBoxtil_SelectedIndexChanged);
			// 
			// LightIntensitytil
			// 
			this.LightIntensitytil.Location = new System.Drawing.Point(200, 208);
			this.LightIntensitytil.Name = "LightIntensitytil";
			this.LightIntensitytil.Size = new System.Drawing.Size(32, 20);
			this.LightIntensitytil.TabIndex = 53;
			this.LightIntensitytil.Text = "";
			// 
			// label35
			// 
			this.label35.Location = new System.Drawing.Point(128, 208);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(80, 16);
			this.label35.TabIndex = 52;
			this.label35.Text = "LightIntensity";
			// 
			// LightDistancetil
			// 
			this.LightDistancetil.Location = new System.Drawing.Point(200, 184);
			this.LightDistancetil.Name = "LightDistancetil";
			this.LightDistancetil.Size = new System.Drawing.Size(32, 20);
			this.LightDistancetil.TabIndex = 51;
			this.LightDistancetil.Text = "";
			// 
			// label36
			// 
			this.label36.Location = new System.Drawing.Point(128, 184);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(80, 16);
			this.label36.TabIndex = 50;
			this.label36.Text = "LightDistance";
			// 
			// FrameIDTypetil
			// 
			this.FrameIDTypetil.Location = new System.Drawing.Point(200, 160);
			this.FrameIDTypetil.Name = "FrameIDTypetil";
			this.FrameIDTypetil.Size = new System.Drawing.Size(72, 20);
			this.FrameIDTypetil.TabIndex = 49;
			this.FrameIDTypetil.Text = "";
			// 
			// label37
			// 
			this.label37.Location = new System.Drawing.Point(128, 160);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(80, 16);
			this.label37.TabIndex = 48;
			this.label37.Text = "FrameIDType";
			// 
			// ObjectFullIDtil
			// 
			this.ObjectFullIDtil.Location = new System.Drawing.Point(192, 24);
			this.ObjectFullIDtil.Name = "ObjectFullIDtil";
			this.ObjectFullIDtil.Size = new System.Drawing.Size(48, 20);
			this.ObjectFullIDtil.TabIndex = 47;
			this.ObjectFullIDtil.Text = "";
			// 
			// label38
			// 
			this.label38.Location = new System.Drawing.Point(192, 8);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(72, 16);
			this.label38.TabIndex = 46;
			this.label38.Text = "ObjectFullID";
			// 
			// ObjectIDtil
			// 
			this.ObjectIDtil.Location = new System.Drawing.Point(128, 24);
			this.ObjectIDtil.Name = "ObjectIDtil";
			this.ObjectIDtil.Size = new System.Drawing.Size(48, 20);
			this.ObjectIDtil.TabIndex = 45;
			this.ObjectIDtil.Text = "";
			// 
			// label39
			// 
			this.label39.Location = new System.Drawing.Point(128, 8);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(48, 16);
			this.label39.TabIndex = 44;
			this.label39.Text = "ObjectID";
			// 
			// label40
			// 
			this.label40.Location = new System.Drawing.Point(128, 48);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(100, 16);
			this.label40.TabIndex = 43;
			this.label40.Text = "Object Description";
			// 
			// Desctil
			// 
			this.Desctil.Location = new System.Drawing.Point(128, 64);
			this.Desctil.Name = "Desctil";
			this.Desctil.Size = new System.Drawing.Size(240, 88);
			this.Desctil.TabIndex = 42;
			this.Desctil.Text = "";
			// 
			// label41
			// 
			this.label41.Location = new System.Drawing.Point(8, 8);
			this.label41.Name = "label41";
			this.label41.Size = new System.Drawing.Size(72, 16);
			this.label41.TabIndex = 41;
			this.label41.Text = "Object Name";
			// 
			// Walls
			// 
			this.Walls.Controls.AddRange(new System.Windows.Forms.Control[] {
																				this.MaterialTypewal,
																				this.label48,
																				this.Sidewal,
																				this.label49,
																				this.FrameNamewal,
																				this.label33,
																				this.comboBoxwal,
																				this.LightIntensitywal,
																				this.label34,
																				this.LightDistancewal,
																				this.label42,
																				this.FrameIDTypewal,
																				this.label43,
																				this.ObjectFullIDwal,
																				this.label44,
																				this.ObjectIDwal,
																				this.label45,
																				this.label46,
																				this.Descwal,
																				this.label47});
			this.Walls.Location = new System.Drawing.Point(4, 22);
			this.Walls.Name = "Walls";
			this.Walls.Size = new System.Drawing.Size(464, 518);
			this.Walls.TabIndex = 3;
			this.Walls.Text = "Walls";
			this.Walls.Paint += new System.Windows.Forms.PaintEventHandler(this.Walls_Paint);
			// 
			// MaterialTypewal
			// 
			this.MaterialTypewal.Location = new System.Drawing.Point(200, 280);
			this.MaterialTypewal.Name = "MaterialTypewal";
			this.MaterialTypewal.Size = new System.Drawing.Size(168, 20);
			this.MaterialTypewal.TabIndex = 80;
			this.MaterialTypewal.Text = "";
			// 
			// label48
			// 
			this.label48.Location = new System.Drawing.Point(128, 280);
			this.label48.Name = "label48";
			this.label48.Size = new System.Drawing.Size(80, 16);
			this.label48.TabIndex = 79;
			this.label48.Text = "MaterialType";
			// 
			// Sidewal
			// 
			this.Sidewal.Location = new System.Drawing.Point(200, 256);
			this.Sidewal.Name = "Sidewal";
			this.Sidewal.Size = new System.Drawing.Size(168, 20);
			this.Sidewal.TabIndex = 78;
			this.Sidewal.Text = "";
			// 
			// label49
			// 
			this.label49.Location = new System.Drawing.Point(128, 256);
			this.label49.Name = "label49";
			this.label49.Size = new System.Drawing.Size(80, 16);
			this.label49.TabIndex = 77;
			this.label49.Text = "Side";
			// 
			// FrameNamewal
			// 
			this.FrameNamewal.Location = new System.Drawing.Point(200, 232);
			this.FrameNamewal.Name = "FrameNamewal";
			this.FrameNamewal.Size = new System.Drawing.Size(72, 20);
			this.FrameNamewal.TabIndex = 76;
			this.FrameNamewal.Text = "";
			// 
			// label33
			// 
			this.label33.Location = new System.Drawing.Point(128, 232);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(80, 16);
			this.label33.TabIndex = 75;
			this.label33.Text = "FrameName";
			// 
			// comboBoxwal
			// 
			this.comboBoxwal.Location = new System.Drawing.Point(8, 24);
			this.comboBoxwal.Name = "comboBoxwal";
			this.comboBoxwal.Size = new System.Drawing.Size(112, 485);
			this.comboBoxwal.TabIndex = 74;
			this.comboBoxwal.SelectedIndexChanged += new System.EventHandler(this.comboBoxwal_SelectedIndexChanged);
			// 
			// LightIntensitywal
			// 
			this.LightIntensitywal.Location = new System.Drawing.Point(200, 208);
			this.LightIntensitywal.Name = "LightIntensitywal";
			this.LightIntensitywal.Size = new System.Drawing.Size(32, 20);
			this.LightIntensitywal.TabIndex = 73;
			this.LightIntensitywal.Text = "";
			// 
			// label34
			// 
			this.label34.Location = new System.Drawing.Point(128, 208);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(80, 16);
			this.label34.TabIndex = 72;
			this.label34.Text = "LightIntensity";
			// 
			// LightDistancewal
			// 
			this.LightDistancewal.Location = new System.Drawing.Point(200, 184);
			this.LightDistancewal.Name = "LightDistancewal";
			this.LightDistancewal.Size = new System.Drawing.Size(32, 20);
			this.LightDistancewal.TabIndex = 71;
			this.LightDistancewal.Text = "";
			// 
			// label42
			// 
			this.label42.Location = new System.Drawing.Point(128, 184);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(80, 16);
			this.label42.TabIndex = 70;
			this.label42.Text = "LightDistance";
			// 
			// FrameIDTypewal
			// 
			this.FrameIDTypewal.Location = new System.Drawing.Point(200, 160);
			this.FrameIDTypewal.Name = "FrameIDTypewal";
			this.FrameIDTypewal.Size = new System.Drawing.Size(72, 20);
			this.FrameIDTypewal.TabIndex = 69;
			this.FrameIDTypewal.Text = "";
			// 
			// label43
			// 
			this.label43.Location = new System.Drawing.Point(128, 160);
			this.label43.Name = "label43";
			this.label43.Size = new System.Drawing.Size(80, 16);
			this.label43.TabIndex = 68;
			this.label43.Text = "FrameIDType";
			// 
			// ObjectFullIDwal
			// 
			this.ObjectFullIDwal.Location = new System.Drawing.Point(192, 24);
			this.ObjectFullIDwal.Name = "ObjectFullIDwal";
			this.ObjectFullIDwal.Size = new System.Drawing.Size(48, 20);
			this.ObjectFullIDwal.TabIndex = 67;
			this.ObjectFullIDwal.Text = "";
			// 
			// label44
			// 
			this.label44.Location = new System.Drawing.Point(192, 8);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(72, 16);
			this.label44.TabIndex = 66;
			this.label44.Text = "ObjectFullID";
			// 
			// ObjectIDwal
			// 
			this.ObjectIDwal.Location = new System.Drawing.Point(128, 24);
			this.ObjectIDwal.Name = "ObjectIDwal";
			this.ObjectIDwal.Size = new System.Drawing.Size(48, 20);
			this.ObjectIDwal.TabIndex = 65;
			this.ObjectIDwal.Text = "";
			// 
			// label45
			// 
			this.label45.Location = new System.Drawing.Point(128, 8);
			this.label45.Name = "label45";
			this.label45.Size = new System.Drawing.Size(48, 16);
			this.label45.TabIndex = 64;
			this.label45.Text = "ObjectID";
			// 
			// label46
			// 
			this.label46.Location = new System.Drawing.Point(128, 48);
			this.label46.Name = "label46";
			this.label46.Size = new System.Drawing.Size(100, 16);
			this.label46.TabIndex = 63;
			this.label46.Text = "Object Description";
			// 
			// Descwal
			// 
			this.Descwal.Location = new System.Drawing.Point(128, 64);
			this.Descwal.Name = "Descwal";
			this.Descwal.Size = new System.Drawing.Size(240, 88);
			this.Descwal.TabIndex = 62;
			this.Descwal.Text = "";
			// 
			// label47
			// 
			this.label47.Location = new System.Drawing.Point(8, 8);
			this.label47.Name = "label47";
			this.label47.Size = new System.Drawing.Size(72, 16);
			this.label47.TabIndex = 61;
			this.label47.Text = "Object Name";
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem3});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem2});
			this.menuItem1.Text = "&File";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "&Exit";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem4});
			this.menuItem3.Text = "&Help";
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 0;
			this.menuItem4.Text = "&About";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(768, 520);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 24);
			this.button1.TabIndex = 1;
			this.button1.Text = "Exit";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "items", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("ObjectType", "ObjectType"),
																																																			   new System.Data.Common.DataColumnMapping("ObjectID", "ObjectID"),
																																																			   new System.Data.Common.DataColumnMapping("ObjectFullID", "ObjectFullID"),
																																																			   new System.Data.Common.DataColumnMapping("FrameIDType", "FrameIDType"),
																																																			   new System.Data.Common.DataColumnMapping("FrameIDOffset", "FrameIDOffset"),
																																																			   new System.Data.Common.DataColumnMapping("FrameID", "FrameID"),
																																																			   new System.Data.Common.DataColumnMapping("ItemMapValue", "ItemMapValue"),
																																																			   new System.Data.Common.DataColumnMapping("WeaponComplexity", "WeaponComplexity"),
																																																			   new System.Data.Common.DataColumnMapping("AttackMode1", "AttackMode1"),
																																																			   new System.Data.Common.DataColumnMapping("AttackMode2", "AttackMode2"),
																																																			   new System.Data.Common.DataColumnMapping("ObjectSubtype", "ObjectSubtype"),
																																																			   new System.Data.Common.DataColumnMapping("MaterialType", "MaterialType"),
																																																			   new System.Data.Common.DataColumnMapping("MinStr", "MinStr"),
																																																			   new System.Data.Common.DataColumnMapping("Weight", "Weight"),
																																																			   new System.Data.Common.DataColumnMapping("BasePrice", "BasePrice"),
																																																			   new System.Data.Common.DataColumnMapping("FrameInventID", "FrameInventID"),
																																																			   new System.Data.Common.DataColumnMapping("ObjectType1", "ObjectType1"),
																																																			   new System.Data.Common.DataColumnMapping("ObjectID1", "ObjectID1"),
																																																			   new System.Data.Common.DataColumnMapping("ObjectFullID1", "ObjectFullID1"),
																																																			   new System.Data.Common.DataColumnMapping("ObjectName", "ObjectName"),
																																																			   new System.Data.Common.DataColumnMapping("ObjectDesc", "ObjectDesc")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT proto.ObjectType, proto.ObjectID, proto.ObjectFullID, proto.FrameIDType, proto.FrameIDOffset, proto.FrameID, proto.ItemMapValue, proto.WeaponComplexity, proto.AttackMode1, proto.AttackMode2, proto.ObjectSubtype, proto.MaterialType, proto.MinStr, proto.Weight, proto.BasePrice, proto.FrameInventID, items.ObjectType AS Expr1, items.ObjectID AS Expr2, items.ObjectFullID AS Expr3, items.ObjectName, items.ObjectDesc FROM items INNER JOIN proto ON items.ObjectType = proto.ObjectType AND items.ObjectID = proto.ObjectID";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "data source=ARTEM;initial catalog=fallout;integrated security=SSPI;persist securi" +
				"ty info=False;workstation id=ARTEM;packet size=4096";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(496, 16);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 24);
			this.button2.TabIndex = 46;
			this.button2.Text = "Play";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label31
			// 
			this.label31.Location = new System.Drawing.Point(600, 16);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(88, 16);
			this.label31.TabIndex = 45;
			this.label31.Text = "Num_of_Frames";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(688, 16);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(80, 20);
			this.textBox1.TabIndex = 44;
			this.textBox1.Text = "textBox1";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Black;
			this.pictureBox1.Location = new System.Drawing.Point(488, 48);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(352, 272);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pictureBox1.TabIndex = 43;
			this.pictureBox1.TabStop = false;
			// 
			// FrameNamecri
			// 
			this.FrameNamecri.Location = new System.Drawing.Point(256, 24);
			this.FrameNamecri.Name = "FrameNamecri";
			this.FrameNamecri.Size = new System.Drawing.Size(72, 20);
			this.FrameNamecri.TabIndex = 56;
			this.FrameNamecri.Text = "";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(256, 8);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(80, 16);
			this.label9.TabIndex = 55;
			this.label9.Text = "FrameName";
			// 
			// comboBoxcri
			// 
			this.comboBoxcri.Location = new System.Drawing.Point(8, 24);
			this.comboBoxcri.Name = "comboBoxcri";
			this.comboBoxcri.Size = new System.Drawing.Size(112, 485);
			this.comboBoxcri.TabIndex = 54;
			this.comboBoxcri.SelectedIndexChanged += new System.EventHandler(this.comboBoxcri_SelectedIndexChanged);
			// 
			// LightIntensitycri
			// 
			this.LightIntensitycri.Location = new System.Drawing.Point(200, 144);
			this.LightIntensitycri.Name = "LightIntensitycri";
			this.LightIntensitycri.Size = new System.Drawing.Size(32, 20);
			this.LightIntensitycri.TabIndex = 53;
			this.LightIntensitycri.Text = "";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(128, 144);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(80, 16);
			this.label10.TabIndex = 52;
			this.label10.Text = "LightIntensity";
			// 
			// LightDistancecri
			// 
			this.LightDistancecri.Location = new System.Drawing.Point(200, 120);
			this.LightDistancecri.Name = "LightDistancecri";
			this.LightDistancecri.Size = new System.Drawing.Size(32, 20);
			this.LightDistancecri.TabIndex = 51;
			this.LightDistancecri.Text = "";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(128, 120);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(80, 16);
			this.label11.TabIndex = 50;
			this.label11.Text = "LightDistance";
			// 
			// FrameIDTypecri
			// 
			this.FrameIDTypecri.Location = new System.Drawing.Point(336, 24);
			this.FrameIDTypecri.Name = "FrameIDTypecri";
			this.FrameIDTypecri.Size = new System.Drawing.Size(72, 20);
			this.FrameIDTypecri.TabIndex = 49;
			this.FrameIDTypecri.Text = "";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(336, 8);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(80, 16);
			this.label12.TabIndex = 48;
			this.label12.Text = "FrameIDType";
			// 
			// ObjectFullIDcri
			// 
			this.ObjectFullIDcri.Location = new System.Drawing.Point(192, 24);
			this.ObjectFullIDcri.Name = "ObjectFullIDcri";
			this.ObjectFullIDcri.Size = new System.Drawing.Size(56, 20);
			this.ObjectFullIDcri.TabIndex = 47;
			this.ObjectFullIDcri.Text = "";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(192, 8);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(72, 16);
			this.label13.TabIndex = 46;
			this.label13.Text = "ObjectFullID";
			// 
			// ObjectIDcri
			// 
			this.ObjectIDcri.Location = new System.Drawing.Point(128, 24);
			this.ObjectIDcri.Name = "ObjectIDcri";
			this.ObjectIDcri.Size = new System.Drawing.Size(56, 20);
			this.ObjectIDcri.TabIndex = 45;
			this.ObjectIDcri.Text = "";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(128, 8);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(48, 16);
			this.label14.TabIndex = 44;
			this.label14.Text = "ObjectID";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(128, 48);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(100, 16);
			this.label15.TabIndex = 43;
			this.label15.Text = "Object Description";
			// 
			// Desccri
			// 
			this.Desccri.Location = new System.Drawing.Point(128, 64);
			this.Desccri.Name = "Desccri";
			this.Desccri.Size = new System.Drawing.Size(328, 48);
			this.Desccri.TabIndex = 42;
			this.Desccri.Text = "";
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(8, 8);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(72, 16);
			this.label16.TabIndex = 41;
			this.label16.Text = "Object Name";
			// 
			// FramePath
			// 
			this.FramePath.Location = new System.Drawing.Point(496, 344);
			this.FramePath.Name = "FramePath";
			this.FramePath.Size = new System.Drawing.Size(336, 88);
			this.FramePath.TabIndex = 47;
			this.FramePath.Text = "label17";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(848, 553);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.FramePath,
																		  this.button2,
																		  this.label31,
																		  this.textBox1,
																		  this.pictureBox1,
																		  this.button1,
																		  this.tabControl1});
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Object Editor";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.tabControl1.ResumeLayout(false);
			this.Items.ResumeLayout(false);
			this.ItemsChild.ResumeLayout(false);
			this.Critters.ResumeLayout(false);
			this.Scenery.ResumeLayout(false);
			this.Misc.ResumeLayout(false);
			this.Tiles.ResumeLayout(false);
			this.Walls.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			Application.Exit();		
		}
		
		private void GetObjectsList(int ObjType, int ObjSubtype, System.Windows.Forms.ComboBox ComboBox)
		{
			DataSet ds = new DataSet();
			string k;
			switch(ObjType)
			{
				case 0: 
					k="items";
					break;
				case 1: 
					k="critters";
					break;
				case 2: 
					k="scenery";
					break;
				case 3: 
					k="walls";
					break;
				case 4: 
					k="tiles";
					break;
				case 5: 
					k="misc";
					break;
				default:
					k="items";
					break;
			}

			sqlDataAdapter1.SelectCommand.CommandText = @"SELECT * FROM "+k+" WHERE ObjectType="+Convert.ToString(ObjType);
			//+" AND ObjectSubtype="+Convert.ToString(ObjSubtype);
			sqlDataAdapter1.Fill(ds, k);
			DataTable dt = ds.Tables[k];
			ComboBox.Items.Clear();
			foreach (DataRow dataRow in dt.Rows)
			{
				ComboBox.Items.Add(dataRow["ObjectName"]);
			}
		}

		private void GetObjectsList1(int ObjType, int ObjSubtype, System.Windows.Forms.ListBox ComboBox)
		{
			DataSet ds = new DataSet();
			string k;
			switch(ObjType)
			{
				case 0: 
					k="items";
					break;
				case 1: 
					k="critters";
					break;
				case 2: 
					k="scenery";
					break;
				case 3: 
					k="walls";
					break;
				case 4: 
					k="tiles";
					break;
				case 5: 
					k="misc";
					break;
				default:
					k="items";
					break;
			}

			sqlDataAdapter1.SelectCommand.CommandText = @"SELECT * FROM "+k+" WHERE ObjectType="+Convert.ToString(ObjType)+"ORDER BY ObjectName";
			//+" AND ObjectSubtype="+Convert.ToString(ObjSubtype);
			sqlDataAdapter1.Fill(ds, k);
			DataTable dt = ds.Tables[k];
			ComboBox.Items.Clear();
			foreach (DataRow dataRow in dt.Rows)
			{
				ComboBox.Items.Add(dataRow["ObjectName"]);
			}
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		}

		private void GetStatsOfObject(int ObjType, int ObjSubtype)
		{
		}

		private void Scenery_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			GetObjectsList1(2, 0, comboBoxsce);
		}

		private void comboBoxsce_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DataSet ds = new DataSet();
			sqlDataAdapter1.SelectCommand.CommandText = @"SELECT * FROM scenery ORDER BY ObjectName";
			sqlDataAdapter1.Fill(ds, "scenery");
			DataTable dt = ds.Tables["scenery"];
			DataRow dataRow = dt.Rows[comboBoxsce.SelectedIndex];
			Descsce.Text = (string) dataRow["ObjectDescription"];
			ObjectIDsce.Text = Convert.ToString(dataRow["ObjectID"]);
			ObjectFullIDsce.Text = Convert.ToString(dataRow["ObjectFullID"]);
			FrameIDTypeS.Text = GetType("frameidtype", Convert.ToInt16(dataRow["FrameIDType"]));
			LightDistanceS.Text = Convert.ToString(dataRow["LightDistance"]);
			LightIntensityS.Text = Convert.ToString(dataRow["LightIntensity"]);
			SceneryTypeS.Text = GetType("scenerytype", Convert.ToInt16(dataRow["SceneryType"]));
			MaterialTypeS.Text = GetType("materialtype", Convert.ToInt16(dataRow["MaterialType"]));
			ds.Dispose();
			dt.Dispose();
		}
		private string GetType(string Table, int Type)
		{
			string s;
			DataSet ds = new DataSet();
			sqlDataAdapter1.SelectCommand.CommandText = @"SELECT * FROM "+Table+" WHERE id="+Convert.ToString(Type);
			sqlDataAdapter1.Fill(ds, Table);
			DataTable dt = ds.Tables[Table];
			DataRow dataRow = dt.Rows[0];
			s = (string) dataRow["type"];
			ds.Dispose();
			dt.Dispose();
			return s;
		}

		private void comboBoxsce_SelectedIndexChanged_1(object sender, System.EventArgs e)
		{
			DataSet ds = new DataSet();
			sqlDataAdapter1.SelectCommand.CommandText = @"SELECT * FROM scenery ORDER BY ObjectName";
			sqlDataAdapter1.Fill(ds, "scenery");
			DataTable dt = ds.Tables["scenery"];
			DataRow dataRow = dt.Rows[comboBoxsce.SelectedIndex];
			Descsce.Text = (string) dataRow["ObjectDescription"];
			ObjectIDsce.Text = Convert.ToString(dataRow["ObjectID"]);
			ObjectFullIDsce.Text = Convert.ToString(dataRow["ObjectFullID"]);
			FrameIDTypeS.Text = GetType("frameidtype", Convert.ToInt16(dataRow["FrameIDType"]));
			LightDistanceS.Text = Convert.ToString(dataRow["LightDistance"]);
			LightIntensityS.Text = Convert.ToString(dataRow["LightIntensity"]);
			SceneryTypeS.Text = GetType("scenerytype", Convert.ToInt16(dataRow["SceneryType"]));
			MaterialTypeS.Text = GetType("materialtype", Convert.ToInt16(dataRow["MaterialType"]));
			string imgpath = Convert.ToString(dataRow["FrameID"]);
			FrameNameS.Text = imgpath;
			string path = @".\MASTER.DAT\art\scenery\";
			dir = Directory.GetFileSystemEntries(path, imgpath+"*.*");
			textBox1.Text = Convert.ToString(dir.Length);
			pictureBox1.Image = System.Drawing.Image.FromFile(dir[0]);
			ds.Dispose();
			dt.Dispose();
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
				foreach (string str in dir)
				{
					pictureBox1.Image = System.Drawing.Image.FromFile(str);
					FramePath.Text = str;
					FramePath.Refresh();
					pictureBox1.Refresh();
					for (int i=0; i<=6500000; i++)
					{
					}
				}
/*			for (int u = dir.Length; u>0; u--)
			{
				pictureBox1.Image = System.Drawing.Image.FromFile(dir[u-1]);
				pictureBox1.Refresh();
				for (int i=0; i<=65000000; i++)
				{
				}
			}*/
		}

		private void comboBoxtil_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DataSet ds = new DataSet();
			sqlDataAdapter1.SelectCommand.CommandText = @"SELECT * FROM tiles ORDER BY ObjectName";
			sqlDataAdapter1.Fill(ds, "tiles");
			DataTable dt = ds.Tables["tiles"];
			DataRow dataRow = dt.Rows[comboBoxtil.SelectedIndex];
			Desctil.Text = (string) dataRow["ObjectDescription"];
			ObjectIDtil.Text = Convert.ToString(dataRow["ObjectID"]);
			ObjectFullIDtil.Text = Convert.ToString(dataRow["ObjectFullID"]);
			FrameIDTypetil.Text = GetType("frameidtype", Convert.ToInt16(dataRow["FrameIDType"]));
			LightDistancetil.Text = Convert.ToString(dataRow["LightDistance"]);
			LightIntensitytil.Text = Convert.ToString(dataRow["LightIntensity"]);
			string imgpath = Convert.ToString(dataRow["FrameID"]);
			FrameNametil.Text = imgpath;
			string path = @".\MASTER.DAT\art\tiles\";
			dir = Directory.GetFileSystemEntries(path, imgpath+"*.*");
			textBox1.Text = Convert.ToString(dir.Length);
			pictureBox1.Image = System.Drawing.Image.FromFile(dir[0]);
			ds.Dispose();
			dt.Dispose();
		}

		private void Tiles_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			GetObjectsList1(4, 0, comboBoxtil);
		}

		private void comboBoxwal_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DataSet ds = new DataSet();
			sqlDataAdapter1.SelectCommand.CommandText = @"SELECT * FROM walls ORDER BY ObjectName";
			sqlDataAdapter1.Fill(ds, "walls");
			DataTable dt = ds.Tables["walls"];
			DataRow dataRow = dt.Rows[comboBoxwal.SelectedIndex];
			Descwal.Text = (string) dataRow["ObjectDescription"];
			ObjectIDwal.Text = Convert.ToString(dataRow["ObjectID"]);
			ObjectFullIDwal.Text = Convert.ToString(dataRow["ObjectFullID"]);
			FrameIDTypewal.Text = GetType("frameidtype", Convert.ToInt16(dataRow["FrameIDType"]));
			LightDistancewal.Text = Convert.ToString(dataRow["LightDistance"]);
			LightIntensitywal.Text = Convert.ToString(dataRow["LightIntensity"]);
			MaterialTypewal.Text = GetType("materialtype", Convert.ToInt16(dataRow["MaterialType"]));
			Sidewal.Text = GetType("wallside", Convert.ToInt32(dataRow["Side"]));
			string imgpath = Convert.ToString(dataRow["FrameID"]);
			FrameNamewal.Text = imgpath;
			string path = @".\MASTER.DAT\art\walls\";
			dir = Directory.GetFileSystemEntries(path, imgpath+"*.*");
			textBox1.Text = Convert.ToString(dir.Length);
			pictureBox1.Image = System.Drawing.Image.FromFile(dir[0]);
			ds.Dispose();
			dt.Dispose();
		}

		private void Walls_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			GetObjectsList1(3, 0, comboBoxwal);
		}

		private void comboBoxmis_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DataSet ds = new DataSet();
			sqlDataAdapter1.SelectCommand.CommandText = @"SELECT * FROM misc ORDER BY ObjectName";
			sqlDataAdapter1.Fill(ds, "misc");
			DataTable dt = ds.Tables["misc"];
			DataRow dataRow = dt.Rows[comboBoxmis.SelectedIndex];
			Descmis.Text = (string) dataRow["ObjectDescription"];
			ObjectIDmis.Text = Convert.ToString(dataRow["ObjectID"]);
			ObjectFullIDmis.Text = Convert.ToString(dataRow["ObjectFullID"]);
			FrameIDTypemis.Text = GetType("frameidtype", Convert.ToInt16(dataRow["FrameIDType"]));
			LightDistancemis.Text = Convert.ToString(dataRow["LightDistance"]);
			LightIntensitymis.Text = Convert.ToString(dataRow["LightIntensity"]);
			string imgpath = Convert.ToString(dataRow["FrameID"]);
			FrameNamemis.Text = imgpath;
			string path = @".\MASTER.DAT\art\misc\";
			dir = Directory.GetFileSystemEntries(path, imgpath+"*.*");
			textBox1.Text = Convert.ToString(dir.Length);
			pictureBox1.Image = System.Drawing.Image.FromFile(dir[0]);
			ds.Dispose();
			dt.Dispose();
		}

		private void Misc_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			GetObjectsList1(5, 0, comboBoxmis);
		}

		private void Critters_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			GetObjectsList1(1, 0, comboBoxcri);
		}

		private void comboBoxcri_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DataSet ds = new DataSet();
			sqlDataAdapter1.SelectCommand.CommandText = @"SELECT * FROM critters ORDER BY ObjectName";
			sqlDataAdapter1.Fill(ds, "critters");
			DataTable dt = ds.Tables["critters"];
			DataRow dataRow = dt.Rows[comboBoxcri.SelectedIndex];
			Desccri.Text = (string) dataRow["ObjectDescription"];
			ObjectIDcri.Text = Convert.ToString(dataRow["ObjectID"]);
			ObjectFullIDcri.Text = Convert.ToString(dataRow["ObjectFullID"]);
			FrameIDTypecri.Text = GetType("frameidtype", Convert.ToInt16(dataRow["FrameIDType"]));
			LightDistancecri.Text = Convert.ToString(dataRow["LightDistance"]);
			LightIntensitycri.Text = Convert.ToString(dataRow["LightIntensity"]);
			string imgpath = Convert.ToString(dataRow["FrameID"]).Substring(0,6);
			FrameNamecri.Text = imgpath;
			string path = @".\CRITTER.DAT\art\critters\";
			dir = Directory.GetFileSystemEntries(path, imgpath+"*.*");
			textBox1.Text = Convert.ToString(dir.Length);
			pictureBox1.Image = System.Drawing.Image.FromFile(dir[0]);
			FramePath.Text = dir[0];
			ds.Dispose();
			dt.Dispose();
		}
	}
}
