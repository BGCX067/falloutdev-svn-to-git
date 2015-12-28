using System;
using System.IO;
using System.Data.SqlClient;
using System.Reflection.Emit;

namespace DataExtractorUtility
{
	public enum eObjectType
	{
		items,
		critters,
		scenery,
		walls,
		tiles,
		misc,
		intrface,
		inven
	}

	class ProtoObject
	{
		public static string vGamePath = @"D:\Games\Fallout2\Resource";

		public ProtoObject(int ObjectType, int ObjectID)
		{
			vObjectType = ObjectType; // Тип объекта
			vObjectID = ObjectID; // ID объекта
		}
		#region Public variables
		// Тип объекта
		public int vObjectType;
		// ID объекта
		public int vObjectID;
		// Наименование объекта
		public string vObjectName;
		// Описание объекта
		public string vObjectDesc;
		// Путь к файлу прототипа объекта
		public string vObjectProto;
		// Путь к файлу графики объекта
		public string vObjectFrame;
		// Тип объекта фрейм файла
		public int vFrameIDType;
		// Второй байт - если в нем записано отличное от 0 значение, 
		// то при выводе карты данный фрейм сдвигается на несколько пикселов 
		// вдоль одной из осей. Вдоль какой - зависит от самого фрейма.
		public int vFrameIDOffset;
		// Собственно FrameID - номер строки в lst-файле master.dat\\art\items\items.lst
		public int vFrameID;
		// Дистанция  света в игровых единицах(hexes) для данного объекта
		public int vLightDistance;
		// Интенсивность света в процентах для данного объекта.
		// Высчитывается в процентах от 256(01 00). 
		// Например если интенсивность света 80% то значение будет 205(CD).
		public int vLightIntensity;
		#endregion
	}

	class Scenery : ProtoObject
	{
		// Конструктор объекта с заданием типа объекта и его ID
		public Scenery(int ObjectType, int ObjectID)
			: base(ObjectType, ObjectID)
		{
			vObjectType = ObjectType; // Тип объекта
			vObjectID = ObjectID; // ID объекта
		}

		// Массив типов объектов

		public int vScriptID;
		public int vSceneryType;
		public int vMaterialType;
		public int vSoundID;
		public int vAvailability;

		// Процедура получения свойств объекта
		public void mGetObjProps()
		{
			// Путь к базовому файлу
			string vBaseFile;
			// Путь к файлу списка протофайлов
			string vListFile;
			// Пусть к файлам прототипа
			string vPathToProto;
			// Путь к файлу списка графики
			string vArtListFile;
			// Путь к файлам графики
			string vPathToArt;
			// Временная строка №1
			string vTempString = " ";
			// Временная строка №2
			string vTempString1 = " ";

			// Определение путей для объекта
			// Case-вариант для многих типов
			switch (vObjectType)
			{
				case 0:
					vBaseFile = vGamePath + @"\MASTER.DAT\text\english\game\pro_item.msg";
					vListFile = vGamePath + @"\MASTER.DAT\proto\items\items.lst";
					vPathToProto = vGamePath + @"\MASTER.DAT\proto\items\";
					vPathToArt = vGamePath + @"\MASTER.DAT\art\items\";
					vArtListFile = vGamePath + @"\MASTER.DAT\art\items\items.lst";
					break;
				case 1:
					vBaseFile = vGamePath + @"\MASTER.DAT\text\english\game\pro_crit.msg";
					vListFile = vGamePath + @"\MASTER.DAT\proto\critters\critters.lst";
					vPathToProto = vGamePath + @"\MASTER.DAT\proto\critters\";
					vPathToArt = vGamePath + @"\CRITTER.DAT\art\critters\";
					vArtListFile = vGamePath + @"\CRITTER.DAT\art\critters\critters.lst";
					break;
				case 2:
					vBaseFile = vGamePath + @"\MASTER.DAT\text\english\game\pro_scen.msg";
					vListFile = vGamePath + @"\MASTER.DAT\proto\scenery\scenery.lst";
					vPathToProto = vGamePath + @"\MASTER.DAT\proto\scenery\";
					vPathToArt = @".\MASTER.DAT\art\scenery\";
					vArtListFile = vGamePath + @"\MASTER.DAT\art\scenery\scenery.lst";
					break;
				case 3:
					vBaseFile = vGamePath + @"\MASTER.DAT\text\english\game\pro_wall.msg";
					vListFile = vGamePath + @"\MASTER.DAT\proto\walls\walls.lst";
					vPathToProto = vGamePath + @"\MASTER.DAT\proto\walls\";
					vPathToArt = vGamePath + @"\MASTER.DAT\art\walls\";
					vArtListFile = vGamePath + @"\MASTER.DAT\art\walls\walls.lst";
					break;
				case 4:
					vBaseFile = vGamePath + @"\MASTER.DAT\text\english\game\pro_tile.msg";
					vListFile = vGamePath + @"\MASTER.DAT\proto\tiles\tiles.lst";
					vPathToProto = vGamePath + @"\MASTER.DAT\proto\tiles\";
					vPathToArt = vGamePath + @"\MASTER.DAT\art\tiles\";
					vArtListFile = vGamePath + @"\MASTER.DAT\art\tiles\tiles.lst";
					break;
				case 5:
					vBaseFile = vGamePath + @"\MASTER.DAT\text\english\game\pro_misc.msg";
					vListFile = vGamePath + @"\MASTER.DAT\proto\misc\misc.lst";
					vPathToProto = vGamePath + @"\MASTER.DAT\proto\misc\";
					vPathToArt = vGamePath + @"\MASTER.DAT\art\misc\";
					vArtListFile = vGamePath + @"\MASTER.DAT\art\misc\misc.lst";
					break;
				default:
					vBaseFile = vGamePath + @"\MASTER.DAT\text\english\game\pro_item.msg";
					vListFile = vGamePath + @"\MASTER.DAT\proto\items\items.lst";
					vPathToProto = vGamePath + @"\MASTER.DAT\proto\items\";
					vPathToArt = vGamePath + @"\MASTER.DAT\art\items\";
					vArtListFile = vGamePath + @"\MASTER.DAT\art\items\items.lst";
					break;
			}

			// Получение файла прототипа объекта
			System.IO.TextReader fListFile = System.IO.File.OpenText(vListFile);
			for (int i = 1; i <= vObjectID; i++)
				vTempString = fListFile.ReadLine();
			fListFile.Close();

			// Путь к файлу прототипа объекта
			vObjectProto = vPathToProto + vTempString;

			//Загоняем весь прото-файл в байтовый массив

			FileStream fProtoFile = new FileStream(vObjectProto, FileMode.Open);

			byte[] buffer = new byte[Convert.ToInt32(fProtoFile.Length)];
			fProtoFile.Read(buffer, 0, Convert.ToInt16(fProtoFile.Length));
			fProtoFile.Close();

			System.IO.TextReader fArtListFile = System.IO.File.OpenText(vArtListFile);
			for (int i = 0; i <= (buffer[10] * 256 + buffer[11]); i++)
				vTempString = fArtListFile.ReadLine();
			fListFile.Close();
			// Путь к файлу с графикой объекта
			vObjectFrame = vTempString.Replace(".FRM", "");

			// Открытие базового файла объектов
			System.IO.TextReader fBaseFile = System.IO.File.OpenText(vBaseFile);
			if (!(fBaseFile.Peek() == -1))
			{
				do
				{
					vTempString = fBaseFile.ReadLine();
				}
				while (!(vTempString.Substring(1, vObjectID.ToString().Length + 2) == (vObjectID * 100).ToString()) && !((fBaseFile.Peek() == -1)));
				if (!(vTempString.Substring(1, vObjectID.ToString().Length) == vObjectID.ToString())) vTempString = "      ";
			}
			else
			{
				vTempString = "     ";
			}
			if ((vTempString.Substring(1, vObjectID.ToString().Length) == vObjectID.ToString()) && !(vTempString == " "))
			{
				char[] aStrSplit = { '{', '}' };
				// Получение наименования объекта
				vObjectName = vTempString.Split(aStrSplit)[5];
				if (!(fBaseFile.Peek() == -1))
				{
					vTempString1 = fBaseFile.ReadLine();
					if (vTempString1.Substring(1, vTempString.Split(aStrSplit)[1].Length) == (vObjectID.ToString() + "01"))
						// Получение описания объекта
						vObjectDesc = vTempString1.Split(aStrSplit)[5];
					else vObjectDesc = " ";
					fBaseFile.Close();
				}
				else
				{
					vObjectDesc = " ";
				}
			}
			else
			{
				vObjectDesc = " ";
				vObjectName = " ";
			}
			vFrameIDType = buffer[8];
			vFrameIDOffset = buffer[9];
			vFrameID = buffer[10] * 256 + buffer[11];
			vLightDistance = (buffer[12] << 24) + (buffer[13] << 16) + (buffer[14] << 8) + buffer[15];
			vLightIntensity = (buffer[16] << 24) + (buffer[17] << 16) + (buffer[18] << 8) + buffer[19];
			vScriptID = (buffer[28] << 24) + (buffer[29] << 16) + (buffer[30] << 8) + buffer[31];
			vSceneryType = (buffer[32] << 24) + (buffer[33] << 16) + (buffer[34] << 8) + buffer[35];
			vMaterialType = (buffer[36] << 24) + (buffer[37] << 16) + (buffer[38] << 8) + buffer[39];
			vSoundID = buffer[40];
			vAvailability = (buffer[44] << 24) + (buffer[43] << 16) + (buffer[42] << 8) + buffer[41];
		}
	}
	class Wall : ProtoObject
	{
		// Конструктор объекта с заданием типа объекта и его ID
		public Wall(int ObjectType, int ObjectID)
			: base(ObjectType, ObjectID)
		{
			vObjectType = ObjectType; // Тип объекта
			vObjectID = ObjectID; // ID объекта
		}

		// Массив типов объектов
		public int vScriptID;
		public int vMaterialType;
		public int vWallSide;

		// Процедура получения свойств объекта
		public void mGetObjProps()
		{
			// Путь к базовому файлу
			string vBaseFile;
			// Путь к файлу списка протофайлов
			string vListFile;
			// Пусть к файлам прототипа
			string vPathToProto;
			// Путь к файлу списка графики
			string vArtListFile;
			// Путь к файлам графики
			string vPathToArt;
			// Временная строка №1
			string vTempString = " ";
			// Временная строка №2
			string vTempString1 = " ";

			// Определение путей для объекта
			// Case-вариант для многих типов
			switch (vObjectType)
			{
				case 0:
					vBaseFile = vGamePath + @"\MASTER.DAT\text\english\game\pro_item.msg";
					vListFile = vGamePath + @"\MASTER.DAT\proto\items\items.lst";
					vPathToProto = vGamePath + @"\MASTER.DAT\proto\items\";
					vPathToArt = vGamePath + @"\MASTER.DAT\art\items\";
					vArtListFile = vGamePath + @"\MASTER.DAT\art\items\items.lst";
					break;
				case 1:
					vBaseFile = vGamePath + @"\MASTER.DAT\text\english\game\pro_crit.msg";
					vListFile = vGamePath + @"\MASTER.DAT\proto\critters\critters.lst";
					vPathToProto = vGamePath + @"\MASTER.DAT\proto\critters\";
					vPathToArt = vGamePath + @"\CRITTER.DAT\art\critters\";
					vArtListFile = vGamePath + @"\CRITTER.DAT\art\critters\critters.lst";
					break;
				case 2:
					vBaseFile = vGamePath + @"\MASTER.DAT\text\english\game\pro_scen.msg";
					vListFile = vGamePath + @"\MASTER.DAT\proto\scenery\scenery.lst";
					vPathToProto = vGamePath + @"\MASTER.DAT\proto\scenery\";
					vPathToArt = vGamePath + @"\MASTER.DAT\art\scenery\";
					vArtListFile = vGamePath + @"\MASTER.DAT\art\scenery\scenery.lst";
					break;
				case 3:
					vBaseFile = vGamePath + @"\MASTER.DAT\text\english\game\pro_wall.msg";
					vListFile = vGamePath + @"\MASTER.DAT\proto\walls\walls.lst";
					vPathToProto = vGamePath + @"\MASTER.DAT\proto\walls\";
					vPathToArt = @".\MASTER.DAT\art\walls\";
					vArtListFile = vGamePath + @"\MASTER.DAT\art\walls\walls.lst";
					break;
				case 4:
					vBaseFile = vGamePath + @"\MASTER.DAT\text\english\game\pro_tile.msg";
					vListFile = vGamePath + @"\MASTER.DAT\proto\tiles\tiles.lst";
					vPathToProto = vGamePath + @"\MASTER.DAT\proto\tiles\";
					vPathToArt = vGamePath + @"\MASTER.DAT\art\tiles\";
					vArtListFile = vGamePath + @"\MASTER.DAT\art\tiles\tiles.lst";
					break;
				case 5:
					vBaseFile = vGamePath + @"\MASTER.DAT\text\english\game\pro_misc.msg";
					vListFile = vGamePath + @"\MASTER.DAT\proto\misc\misc.lst";
					vPathToProto = vGamePath + @"\MASTER.DAT\proto\misc\";
					vPathToArt = vGamePath + @"\MASTER.DAT\art\misc\";
					vArtListFile = vGamePath + @"\MASTER.DAT\art\misc\misc.lst";
					break;
				default:
					vBaseFile = vGamePath + @"\MASTER.DAT\text\english\game\pro_item.msg";
					vListFile = vGamePath + @"\MASTER.DAT\proto\items\items.lst";
					vPathToProto = vGamePath + @"\MASTER.DAT\proto\items\";
					vPathToArt = vGamePath + @"\MASTER.DAT\art\items\";
					vArtListFile = vGamePath + @"\MASTER.DAT\art\items\items.lst";
					break;
			}

			// Получение файла прототипа объекта
			System.IO.TextReader fListFile = System.IO.File.OpenText(vListFile);
			for (int i = 1; i <= vObjectID; i++)
				vTempString = fListFile.ReadLine();
			fListFile.Close();

			// Путь к файлу прототипа объекта
			vObjectProto = vPathToProto + vTempString;

			//Загоняем весь прото-файл в байтовый массив

			FileStream fProtoFile = new FileStream(vObjectProto, FileMode.Open);

			byte[] buffer = new byte[Convert.ToInt32(fProtoFile.Length)];
			fProtoFile.Read(buffer, 0, Convert.ToInt16(fProtoFile.Length));
			fProtoFile.Close();

			System.IO.TextReader fArtListFile = System.IO.File.OpenText(vArtListFile);
			for (int i = 0; i <= (buffer[10] * 256 + buffer[11]); i++)
				vTempString = fArtListFile.ReadLine();
			fListFile.Close();
			// Путь к файлу с графикой объекта
			vObjectFrame = vTempString.Replace(".FRM", "");

			// Открытие базового файла объектов
			System.IO.TextReader fBaseFile = System.IO.File.OpenText(vBaseFile);
			if (!(fBaseFile.Peek() == -1))
			{
				do
				{
					vTempString = fBaseFile.ReadLine();
				}
				while (!(vTempString.Substring(1, vObjectID.ToString().Length + 2) == (vObjectID * 100).ToString()) && !((fBaseFile.Peek() == -1)));
				if (!(vTempString.Substring(1, vObjectID.ToString().Length) == vObjectID.ToString())) vTempString = "      ";
			}
			else
			{
				vTempString = "     ";
			}
			if ((vTempString.Substring(1, vObjectID.ToString().Length) == vObjectID.ToString()) && !(vTempString == " "))
			{
				char[] aStrSplit = { '{', '}' };
				// Получение наименования объекта
				vObjectName = vTempString.Split(aStrSplit)[5];
				if (!(fBaseFile.Peek() == -1))
				{
					vTempString1 = fBaseFile.ReadLine();
					if (vTempString1.Substring(1, vTempString.Split(aStrSplit)[1].Length) == (vObjectID.ToString() + "01"))
						// Получение описания объекта
						vObjectDesc = vTempString1.Split(aStrSplit)[5];
					else vObjectDesc = " ";
					fBaseFile.Close();
				}
				else
				{
					vObjectDesc = " ";
				}
			}
			else
			{
				vObjectDesc = " ";
				vObjectName = " ";
			}
			vFrameIDType = buffer[8];
			vFrameIDOffset = buffer[9];
			vFrameID = buffer[10] * 256 + buffer[11];
			vLightDistance = (buffer[12] << 24) + (buffer[13] << 16) + (buffer[14] << 8) + buffer[15];
			vLightIntensity = (buffer[16] << 24) + (buffer[17] << 16) + (buffer[18] << 8) + buffer[19];
			vWallSide = buffer[25] * 256 + buffer[24];
			vScriptID = (buffer[28] << 24) + (buffer[29] << 16) + (buffer[30] << 8) + buffer[31];
			vMaterialType = (buffer[32] << 24) + (buffer[33] << 16) + (buffer[34] << 8) + buffer[35];
		}
	}
	class Tile : ProtoObject
	{
		// Конструктор объекта с заданием типа объекта и его ID
		public Tile(int ObjectType, int ObjectID)
			: base(ObjectType, ObjectID)
		{
			vObjectType = ObjectType; // Тип объекта
			vObjectID = ObjectID; // ID объекта
		}
		// Массив типов объектов
		public enum eObjectType { items, critters, scenery, walls, tiles, misc, intrface, inven };

		// Процедура получения свойств объекта
		public void mGetObjProps()
		{
			// Путь к базовому файлу
			string vBaseFile;
			// Путь к файлу списка протофайлов
			string vListFile;
			// Пусть к файлам прототипа
			string vPathToProto;
			// Путь к файлу списка графики
			string vArtListFile;
			// Путь к файлам графики
			string vPathToArt;
			// Временная строка №1
			string vTempString = " ";
			// Временная строка №2
			string vTempString1 = " ";

			// Определение путей для объекта
			// Case-вариант для многих типов
			switch (vObjectType)
			{
				case 0:
					vBaseFile = vGamePath + @"\MASTER.DAT\text\english\game\pro_item.msg";
					vListFile = vGamePath + @"\MASTER.DAT\proto\items\items.lst";
					vPathToProto = vGamePath + @"\MASTER.DAT\proto\items\";
					vPathToArt = vGamePath + @"\MASTER.DAT\art\items\";
					vArtListFile = vGamePath + @"\MASTER.DAT\art\items\items.lst";
					break;
				case 1:
					vBaseFile = vGamePath + @"\MASTER.DAT\text\english\game\pro_crit.msg";
					vListFile = vGamePath + @"\MASTER.DAT\proto\critters\critters.lst";
					vPathToProto = vGamePath + @"\MASTER.DAT\proto\critters\";
					vPathToArt = vGamePath + @"\CRITTER.DAT\art\critters\";
					vArtListFile = vGamePath + @"\CRITTER.DAT\art\critters\critters.lst";
					break;
				case 2:
					vBaseFile = vGamePath + @"\MASTER.DAT\text\english\game\pro_scen.msg";
					vListFile = vGamePath + @"\MASTER.DAT\proto\scenery\scenery.lst";
					vPathToProto = vGamePath + @"\MASTER.DAT\proto\scenery\";
					vPathToArt = vGamePath + @"\MASTER.DAT\art\scenery\";
					vArtListFile = vGamePath + @"\MASTER.DAT\art\scenery\scenery.lst";
					break;
				case 3:
					vBaseFile = vGamePath + @"\MASTER.DAT\text\english\game\pro_wall.msg";
					vListFile = vGamePath + @"\MASTER.DAT\proto\walls\walls.lst";
					vPathToProto = vGamePath + @"\MASTER.DAT\proto\walls\";
					vPathToArt = vGamePath + @"\MASTER.DAT\art\walls\";
					vArtListFile = vGamePath + @"\MASTER.DAT\art\walls\walls.lst";
					break;
				case 4:
					vBaseFile = vGamePath + @"\MASTER.DAT\text\english\game\pro_tile.msg";
					vListFile = vGamePath + @"\MASTER.DAT\proto\tiles\tiles.lst";
					vPathToProto = vGamePath + @"\MASTER.DAT\proto\tiles\";
					vPathToArt = @".\MASTER.DAT\art\tiles\";
					vArtListFile = vGamePath + @"\MASTER.DAT\art\tiles\tiles.lst";
					break;
				case 5:
					vBaseFile = vGamePath + @"\MASTER.DAT\text\english\game\pro_misc.msg";
					vListFile = vGamePath + @"\MASTER.DAT\proto\misc\misc.lst";
					vPathToProto = vGamePath + @"\MASTER.DAT\proto\misc\";
					vPathToArt = vGamePath + @"\MASTER.DAT\art\misc\";
					vArtListFile = vGamePath + @"\MASTER.DAT\art\misc\misc.lst";
					break;
				default:
					vBaseFile = vGamePath + @"\MASTER.DAT\text\english\game\pro_item.msg";
					vListFile = vGamePath + @"\MASTER.DAT\proto\items\items.lst";
					vPathToProto = vGamePath + @"\MASTER.DAT\proto\items\";
					vPathToArt = vGamePath + @"\MASTER.DAT\art\items\";
					vArtListFile = vGamePath + @"\MASTER.DAT\art\items\items.lst";
					break;
			}

			// Получение файла прототипа объекта
			System.IO.TextReader fListFile = System.IO.File.OpenText(vListFile);
			for (int i = 1; i <= vObjectID; i++)
				vTempString = fListFile.ReadLine();
			fListFile.Close();

			// Путь к файлу прототипа объекта
			vObjectProto = vPathToProto + vTempString;

			//Загоняем весь прото-файл в байтовый массив

			FileStream fProtoFile = new FileStream(vObjectProto, FileMode.Open);

			byte[] buffer = new byte[Convert.ToInt32(fProtoFile.Length)];
			fProtoFile.Read(buffer, 0, Convert.ToInt16(fProtoFile.Length));
			fProtoFile.Close();

			System.IO.TextReader fArtListFile = System.IO.File.OpenText(vArtListFile);
			for (int i = 0; i <= (buffer[10] * 256 + buffer[11]); i++)
				vTempString = fArtListFile.ReadLine();
			fListFile.Close();
			// Путь к файлу с графикой объекта
			vObjectFrame = vTempString.Replace(".FRM", "");

			// Открытие базового файла объектов
			System.IO.TextReader fBaseFile = System.IO.File.OpenText(vBaseFile);
			if (!(fBaseFile.Peek() == -1))
			{
				do
				{
					vTempString = fBaseFile.ReadLine();
				}
				while (!(vTempString.Substring(1, vObjectID.ToString().Length + 2) == (vObjectID * 100).ToString()) && !((fBaseFile.Peek() == -1)));
				if (!(vTempString.Substring(1, vObjectID.ToString().Length) == vObjectID.ToString())) vTempString = "      ";
			}
			else
			{
				vTempString = "     ";
			}
			if ((vTempString.Substring(1, vObjectID.ToString().Length) == vObjectID.ToString()) && !(vTempString == " "))
			{
				char[] aStrSplit = { '{', '}' };
				// Получение наименования объекта
				vObjectName = vTempString.Split(aStrSplit)[5];
				if (!(fBaseFile.Peek() == -1))
				{
					vTempString1 = fBaseFile.ReadLine();
					if (vTempString1.Substring(1, vTempString.Split(aStrSplit)[1].Length) == (vObjectID.ToString() + "01"))
						// Получение описания объекта
						vObjectDesc = vTempString1.Split(aStrSplit)[5];
					else vObjectDesc = " ";
					fBaseFile.Close();
				}
				else
				{
					vObjectDesc = " ";
				}
			}
			else
			{
				vObjectDesc = " ";
				vObjectName = " ";
			}
			vFrameIDType = buffer[8];
			vFrameIDOffset = buffer[9];
			vFrameID = buffer[10] * 256 + buffer[11];
			vLightDistance = (buffer[12] << 24) + (buffer[13] << 16) + (buffer[14] << 8) + buffer[15];
			vLightIntensity = (buffer[16] << 24) + (buffer[17] << 16) + (buffer[18] << 8) + buffer[19];
		}
	}
	class Critter : ProtoObject
	{
		// Конструктор объекта с заданием типа объекта и его ID
		public Critter(int ObjectType, int ObjectID)
			: base(ObjectType, ObjectID)
		{
			vObjectType = ObjectType; // Тип объекта
			vObjectID = ObjectID; // ID объекта
		}

		// Массив типов объектов
		public enum eObjectType { items, critters, scenery, walls, tiles, misc, intrface, inven };

		#region Public Variables
		public int vScriptID;
		public int vTalkingHeadFrame;
		public int vAIPaket_num;
		public int vTeamNumber;
		public int vStrenght;
		public int vPerception;
		public int vEndurance;
		public int vCharisma;
		public int vIntelligence;
		public int vAgility;
		public int vLuck;
		public int vHP;
		public int vAP;
		public int vAC;
		public int vUnarmedDamage;
		public int vMeleeDamage;
		public int vCarryWeight;
		public int vSequence;
		public int vHealingRate;
		public int vCriticalChance;
		public int vBetterCriticals;
		public int vDT_Normal;
		public int vDT_Laser;
		public int vDT_Fire;
		public int vDT_Plasma;
		public int vDT_Electrical;
		public int vDT_EMP;
		public int vDT_Explode;
		public int vDR_Normal;
		public int vDR_Laser;
		public int vDR_Fire;
		public int vDR_Plasma;
		public int vDR_Electrical;
		public int vDR_EMP;
		public int vDR_Explode;
		public int vDR_Radiation;
		public int vDR_Poison;
		public int vBaseAge;
		public int vBaseSex;
		public int vExtraStrenght;
		public int vExtraPerception;
		public int vExtraEndurance;
		public int vExtraCharisma;
		public int vExtraIntelligence;
		public int vExtraAgility;
		public int vExtraLuck;
		public int vExtraHP;
		public int vExtraAP;
		public int vExtraAC;
		public int vExtraUnarmedDamage;
		public int vExtraMeleeDamage;
		public int vExtraCarryWeight;
		public int vExtraSequence;
		public int vExtraHealingRate;
		public int vExtraCriticalChance;
		public int vExtraBetterCriticals;
		public int vExtraDT_Normal;
		public int vExtraDT_Laser;
		public int vExtraDT_Fire;
		public int vExtraDT_Plasma;
		public int vExtraDT_Electrical;
		public int vExtraDT_EMP;
		public int vExtraDT_Explode;
		public int vExtraDR_Normal;
		public int vExtraDR_Laser;
		public int vExtraDR_Fire;
		public int vExtraDR_Plasma;
		public int vExtraDR_Electrical;
		public int vExtraDR_EMP;
		public int vExtraDR_Explode;
		public int vExtraDR_Radiation;
		public int vExtraDR_Poison;
		public int vExtraAge;
		public int vExtraSex;
		public int vSkill_SmallGuns;
		public int vSkill_BigGuns;
		public int vSkill_EnergyWeapons;
		public int vSkill_Unarmed;
		public int vSkill_Melee;
		public int vSkill_Throwing;
		public int vSkill_FirstAid;
		public int vSkill_Doctor;
		public int vSkill_Sneak;
		public int vSkill_Lockpick;
		public int vSkill_Steal;
		public int vSkill_Traps;
		public int vSkill_Science;
		public int vSkill_Repair;
		public int vSkill_Speech;
		public int vSkill_Barter;
		public int vSkill_Gambling;
		public int vSkill_Outdoorsmanship;
		public int vBodyType;
		public int vXPForKill;
		public int vKillType;
		public int vDamageType;
		#endregion

		// Процедура получения свойств объекта
		public void mGetObjProps()
		{
			// Путь к базовому файлу
			string vBaseFile;
			// Путь к файлу списка протофайлов
			string vListFile;
			// Пусть к файлам прототипа
			string vPathToProto;
			// Путь к файлу списка графики
			string vArtListFile;
			// Путь к файлам графики
			string vPathToArt;
			// Временная строка №1
			string vTempString = " ";
			// Временная строка №2
			string vTempString1 = " ";

			// Определение путей для объекта
			// Case-вариант для многих типов
			switch (vObjectType)
			{
				case 0:
					vBaseFile = vGamePath + @"\MASTER.DAT\text\english\game\pro_item.msg";
					vListFile = vGamePath + @"\MASTER.DAT\proto\items\items.lst";
					vPathToProto = vGamePath + @"\MASTER.DAT\proto\items\";
					vPathToArt = vGamePath + @"\MASTER.DAT\art\items\";
					vArtListFile = vGamePath + @"\MASTER.DAT\art\items\items.lst";
					break;
				case 1:
					vBaseFile = vGamePath + @"\MASTER.DAT\text\english\game\pro_crit.msg";
					vListFile = vGamePath + @"\MASTER.DAT\proto\critters\critters.lst";
					vPathToProto = vGamePath + @"\MASTER.DAT\proto\critters\";
					vPathToArt = @".\CRITTER.DAT\art\critters\";
					vArtListFile = vGamePath + @"\CRITTER.DAT\art\critters\critters.lst";
					break;
				case 2:
					vBaseFile = vGamePath + @"\MASTER.DAT\text\english\game\pro_scen.msg";
					vListFile = vGamePath + @"\MASTER.DAT\proto\scenery\scenery.lst";
					vPathToProto = vGamePath + @"\MASTER.DAT\proto\scenery\";
					vPathToArt = vGamePath + @"\MASTER.DAT\art\scenery\";
					vArtListFile = vGamePath + @"\MASTER.DAT\art\scenery\scenery.lst";
					break;
				case 3:
					vBaseFile = vGamePath + @"\MASTER.DAT\text\english\game\pro_wall.msg";
					vListFile = vGamePath + @"\MASTER.DAT\proto\walls\walls.lst";
					vPathToProto = vGamePath + @"\MASTER.DAT\proto\walls\";
					vPathToArt = vGamePath + @"\MASTER.DAT\art\walls\";
					vArtListFile = vGamePath + @"\MASTER.DAT\art\walls\walls.lst";
					break;
				case 4:
					vBaseFile = vGamePath + @"\MASTER.DAT\text\english\game\pro_tile.msg";
					vListFile = vGamePath + @"\MASTER.DAT\proto\tiles\tiles.lst";
					vPathToProto = vGamePath + @"\MASTER.DAT\proto\tiles\";
					vPathToArt = vGamePath + @"\MASTER.DAT\art\tiles\";
					vArtListFile = vGamePath + @"\MASTER.DAT\art\tiles\tiles.lst";
					break;
				case 5:
					vBaseFile = vGamePath + @"\MASTER.DAT\text\english\game\pro_misc.msg";
					vListFile = vGamePath + @"\MASTER.DAT\proto\misc\misc.lst";
					vPathToProto = vGamePath + @"\MASTER.DAT\proto\misc\";
					vPathToArt = vGamePath + @"\MASTER.DAT\art\misc\";
					vArtListFile = vGamePath + @"\MASTER.DAT\art\misc\misc.lst";
					break;
				default:
					vBaseFile = vGamePath + @"\MASTER.DAT\text\english\game\pro_item.msg";
					vListFile = vGamePath + @"\MASTER.DAT\proto\items\items.lst";
					vPathToProto = vGamePath + @"\MASTER.DAT\proto\items\";
					vPathToArt = vGamePath + @"\MASTER.DAT\art\items\";
					vArtListFile = vGamePath + @"\MASTER.DAT\art\items\items.lst";
					break;
			}

			// Получение файла прототипа объекта
			System.IO.TextReader fListFile = System.IO.File.OpenText(vListFile);
			for (int i = 1; i <= vObjectID; i++)
				vTempString = fListFile.ReadLine();
			fListFile.Close();

			// Путь к файлу прототипа объекта
			vObjectProto = vPathToProto + vTempString;

			//Загоняем весь прото-файл в байтовый массив

			FileStream fProtoFile = new FileStream(vObjectProto, FileMode.Open);

			byte[] buffer = new byte[Convert.ToInt32(fProtoFile.Length)];
			fProtoFile.Read(buffer, 0, Convert.ToInt16(fProtoFile.Length));
			fProtoFile.Close();

			System.IO.TextReader fArtListFile = System.IO.File.OpenText(vArtListFile);
			for (int i = 0; i <= (buffer[10] * 256 + buffer[11]); i++)
				vTempString = fArtListFile.ReadLine();
			fListFile.Close();
			// Путь к файлу с графикой объекта
			vObjectFrame = vTempString.Replace(".FRM", "");

			// Открытие базового файла объектов
			System.IO.TextReader fBaseFile = System.IO.File.OpenText(vBaseFile);
			if (!(fBaseFile.Peek() == -1))
			{
				do
				{
					vTempString = fBaseFile.ReadLine();
				}
				while (!(vTempString.Substring(1, vObjectID.ToString().Length + 2) == (vObjectID * 100).ToString()) && !((fBaseFile.Peek() == -1)));
				if (!(vTempString.Substring(1, vObjectID.ToString().Length) == vObjectID.ToString())) vTempString = "      ";
			}
			else
			{
				vTempString = "     ";
			}
			if ((vTempString.Substring(1, vObjectID.ToString().Length) == vObjectID.ToString()) && !(vTempString == " "))
			{
				char[] aStrSplit = { '{', '}' };
				// Получение наименования объекта
				vObjectName = vTempString.Split(aStrSplit)[5];
				if (!(fBaseFile.Peek() == -1))
				{
					vTempString1 = fBaseFile.ReadLine();
					if (vTempString1.Substring(1, vTempString.Split(aStrSplit)[1].Length) == (vObjectID.ToString() + "01"))
						// Получение описания объекта
						vObjectDesc = vTempString1.Split(aStrSplit)[5];
					else vObjectDesc = " ";
					fBaseFile.Close();
				}
				else
				{
					vObjectDesc = " ";
				}
			}
			else
			{
				vObjectDesc = " ";
				vObjectName = " ";
			}
			vFrameIDType = buffer[8];
			vFrameIDOffset = buffer[9];
			vFrameID = buffer[10] * 256 + buffer[11];
			int offset = 0xc;
			vLightDistance = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x10;
			vLightIntensity = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x1C;
			vScriptID = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x20;
			vTalkingHeadFrame = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x24;
			vAIPaket_num = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x28;
			vTeamNumber = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			// Базовые основные параметры
			offset = 0x30;
			vStrenght = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x34;
			vPerception = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x38;
			vEndurance = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x3C;
			vCharisma = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x40;
			vIntelligence = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x44;
			vAgility = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x48;
			vLuck = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x4C;
			vHP = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x50;
			vAP = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x54;
			vAC = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x58;
			vUnarmedDamage = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x5C;
			vMeleeDamage = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x60;
			vCarryWeight = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x64;
			vSequence = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x68;
			vHealingRate = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x6C;
			vCriticalChance = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x70;
			vBetterCriticals = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			// Базовые сопротивления и трешхолды(Tresholds)
			offset = 0x74;
			vDT_Normal = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x78;
			vDT_Laser = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x7C;
			vDT_Fire = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x80;
			vDT_Plasma = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x84;
			vDT_Electrical = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x88;
			vDT_EMP = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x8C;
			vDT_Explode = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x90;
			vDR_Normal = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x94;
			vDR_Laser = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x98;
			vDR_Fire = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x9C;
			vDR_Plasma = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xA0;
			vDR_Electrical = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xA4;
			vDR_EMP = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xA8;
			vDR_Explode = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xAC;
			vDR_Radiation = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xB0;
			vDR_Poison = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			//Базовое разное
			offset = 0xB4;
			vBaseAge = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xB8;
			vBaseSex = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			//Дополнительные основные параметры
			offset = 0xBC;
			vExtraStrenght = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xC0;
			vExtraPerception = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xC4;
			vExtraEndurance = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xC8;
			vExtraCharisma = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xCC;
			vExtraIntelligence = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xD0;
			vExtraAgility = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xD4;
			vExtraLuck = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xD8;
			vExtraHP = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xDC;
			vExtraAP = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xE0;
			vExtraAC = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xE4;
			vExtraUnarmedDamage = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xE8;
			vExtraMeleeDamage = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xEC;
			vExtraCarryWeight = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xF0;
			vExtraSequence = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xF4;
			vExtraHealingRate = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xF8;
			vExtraCriticalChance = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xFC;
			vExtraBetterCriticals = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			//Дополнительные сопротивления и трешхолды(Tresholds)
			offset = 0x100;
			vExtraDT_Normal = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x104;
			vExtraDT_Laser = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x108;
			vExtraDT_Fire = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x10C;
			vExtraDT_Plasma = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x110;
			vExtraDT_Electrical = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x114;
			vExtraDT_EMP = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x118;
			vExtraDT_Explode = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x11C;
			vExtraDR_Normal = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x120;
			vExtraDR_Laser = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x124;
			vExtraDR_Fire = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x128;
			vExtraDR_Plasma = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x12C;
			vExtraDR_Electrical = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x130;
			vExtraDR_EMP = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x134;
			vExtraDR_Explode = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x138;
			vExtraDR_Radiation = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x13C;
			vExtraDR_Poison = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			// Дополнительное разное
			offset = 0x140;
			vExtraAge = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x144;
			vExtraSex = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			// Навыки
			offset = 0x148;
			vSkill_SmallGuns = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x14C;
			vSkill_BigGuns = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x150;
			vSkill_EnergyWeapons = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x154;
			vSkill_Unarmed = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x158;
			vSkill_Melee = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x15C;
			vSkill_Throwing = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x160;
			vSkill_FirstAid = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x164;
			vSkill_Doctor = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x168;
			vSkill_Sneak = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x16C;
			vSkill_Lockpick = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x170;
			vSkill_Steal = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x174;
			vSkill_Traps = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x178;
			vSkill_Science = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x17C;
			vSkill_Repair = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x180;
			vSkill_Speech = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x184;
			vSkill_Barter = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x188;
			vSkill_Gambling = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x18C;
			vSkill_Outdoorsmanship = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			// Остальное
			offset = 0x190;
			vBodyType = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x194;
			vXPForKill = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x198;
			vKillType = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x19C;
			vDamageType = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];

		}
	}

	class Item : ProtoObject
	{
		public static byte[] buffer;
		public Item(int ObjectType, int ObjectID)
			: base(ObjectType, ObjectID)
		{
			vObjectType = ObjectType; // Тип объекта
			vObjectID = ObjectID; // ID объекта
		}

		#region Public variables
		public int vAttackMode1;

		public int vAttackMode2;

		public int vScriptID;

		public int vObjectSubtype;

		public int vMaterialType;

		public int vVolume;

		public int vWeight;

		public int vBasePrice;

		public int vInvenID;

		public int vInvenFrame;

		public string vInvenPath;

		public int vSoundID;
		#endregion

		public void mGetObjProps()
		{
			// Путь к базовому файлу
			string vBaseFile;
			// Путь к файлу списка протофайлов
			string vListFile;
			// Пусть к файлам прототипа
			string vPathToProto;
			// Путь к файлу списка графики
			string vArtListFile;
			// Путь к файлам графики
			string vPathToArt;
			// Временная строка №1
			string vTempString = " ";
			// Временная строка №2
			string vTempString1 = " ";

			// Определение путей для объекта
			// Case-вариант для многих типов
			switch (vObjectType)
			{
				case 0:
					vBaseFile = vGamePath + @"\MASTER.DAT\text\english\game\pro_item.msg";
					vListFile = vGamePath + @"\MASTER.DAT\proto\items\items.lst";
					vPathToProto = vGamePath + @"\MASTER.DAT\proto\items\";
					vPathToArt = vGamePath + @"\MASTER.DAT\art\items\";
					vArtListFile = vGamePath + @"\MASTER.DAT\art\items\items.lst";
					break;
				case 1:
					vBaseFile = vGamePath + @"\MASTER.DAT\text\english\game\pro_crit.msg";
					vListFile = vGamePath + @"\MASTER.DAT\proto\critters\critters.lst";
					vPathToProto = vGamePath + @"\MASTER.DAT\proto\critters\";
					vPathToArt = vGamePath + @"\CRITTER.DAT\art\critters\";
					vArtListFile = vGamePath + @"\CRITTER.DAT\art\critters\critters.lst";
					break;
				case 2:
					vBaseFile = vGamePath + @"\MASTER.DAT\text\english\game\pro_scen.msg";
					vListFile = vGamePath + @"\MASTER.DAT\proto\scenery\scenery.lst";
					vPathToProto = vGamePath + @"\MASTER.DAT\proto\scenery\";
					vPathToArt = vGamePath + @"\MASTER.DAT\art\scenery\";
					vArtListFile = vGamePath + @"\MASTER.DAT\art\scenery\scenery.lst";
					break;
				case 3:
					vBaseFile = vGamePath + @"\MASTER.DAT\text\english\game\pro_wall.msg";
					vListFile = vGamePath + @"\MASTER.DAT\proto\walls\walls.lst";
					vPathToProto = vGamePath + @"\MASTER.DAT\proto\walls\";
					vPathToArt = vGamePath + @"\MASTER.DAT\art\walls\";
					vArtListFile = vGamePath + @"\MASTER.DAT\art\walls\walls.lst";
					break;
				case 4:
					vBaseFile = vGamePath + @"\MASTER.DAT\text\english\game\pro_tile.msg";
					vListFile = vGamePath + @"\MASTER.DAT\proto\tiles\tiles.lst";
					vPathToProto = vGamePath + @"\MASTER.DAT\proto\tiles\";
					vPathToArt = @".\MASTER.DAT\art\tiles\";
					vArtListFile = vGamePath + @"\MASTER.DAT\art\tiles\tiles.lst";
					break;
				case 5:
					vBaseFile = vGamePath + @"\MASTER.DAT\text\english\game\pro_misc.msg";
					vListFile = vGamePath + @"\MASTER.DAT\proto\misc\misc.lst";
					vPathToProto = vGamePath + @"\MASTER.DAT\proto\misc\";
					vPathToArt = vGamePath + @"\MASTER.DAT\art\misc\";
					vArtListFile = vGamePath + @"\MASTER.DAT\art\misc\misc.lst";
					break;
				default:
					vBaseFile = vGamePath + @"\MASTER.DAT\text\english\game\pro_item.msg";
					vListFile = vGamePath + @"\MASTER.DAT\proto\items\items.lst";
					vPathToProto = vGamePath + @"\MASTER.DAT\proto\items\";
					vPathToArt = vGamePath + @"\MASTER.DAT\art\items\";
					vArtListFile = vGamePath + @"\MASTER.DAT\art\items\items.lst";
					break;
			}

			// Получение файла прототипа объекта
			System.IO.TextReader fListFile = System.IO.File.OpenText(vListFile);
			for (int i = 1; i <= vObjectID; i++)
				vTempString = fListFile.ReadLine();
			fListFile.Close();

			// Путь к файлу прототипа объекта
			vObjectProto = vPathToProto + vTempString;

			//Загоняем весь прото-файл в байтовый массив

			FileStream fProtoFile = new FileStream(vObjectProto, FileMode.Open);

			buffer = new byte[Convert.ToInt32(fProtoFile.Length)];
			fProtoFile.Read(buffer, 0, Convert.ToInt16(fProtoFile.Length));
			fProtoFile.Close();

			System.IO.TextReader fArtListFile = System.IO.File.OpenText(vArtListFile);
			for (int i = 0; i <= (buffer[10] * 256 + buffer[11]); i++)
				vTempString = fArtListFile.ReadLine();
			fListFile.Close();
			// Путь к файлу с графикой объекта
			vObjectFrame = vTempString.Replace(".FRM", "");

			// Открытие базового файла объектов
			System.IO.TextReader fBaseFile = System.IO.File.OpenText(vBaseFile);
			if (!(fBaseFile.Peek() == -1))
			{
				do
				{
					vTempString = fBaseFile.ReadLine();
				}
				while (!(vTempString.Substring(1, vObjectID.ToString().Length + 2) == (vObjectID * 100).ToString()) && !((fBaseFile.Peek() == -1)));
				if (!(vTempString.Substring(1, vObjectID.ToString().Length) == vObjectID.ToString())) vTempString = "      ";
			}
			else
			{
				vTempString = "     ";
			}
			if ((vTempString.Substring(1, vObjectID.ToString().Length) == vObjectID.ToString()) && !(vTempString == " "))
			{
				char[] aStrSplit = { '{', '}' };
				// Получение наименования объекта
				vObjectName = vTempString.Split(aStrSplit)[5];
				if (!(fBaseFile.Peek() == -1))
				{
					vTempString1 = fBaseFile.ReadLine();
					if (vTempString1.Substring(1, vTempString.Split(aStrSplit)[1].Length) == (vObjectID.ToString() + "01"))
						// Получение описания объекта
						vObjectDesc = vTempString1.Split(aStrSplit)[5];
					else vObjectDesc = " ";
					fBaseFile.Close();
				}
				else
				{
					vObjectDesc = " ";
				}
			}
			else
			{
				vObjectDesc = " ";
				vObjectName = " ";
			}
			vFrameIDType = buffer[8];
			vFrameIDOffset = buffer[9];
			vFrameID = buffer[10] * 256 + buffer[11];
			vLightDistance = (buffer[12] << 24) + (buffer[13] << 16) + (buffer[14] << 8) + buffer[15];
			vLightIntensity = (buffer[16] << 24) + (buffer[17] << 16) + (buffer[18] << 8) + buffer[19];
			vAttackMode1 = (buffer[27] & 240) >> 4;
			vAttackMode2 = (buffer[27] & 15);
			int offset = 0x1C;
			vScriptID = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x20;
			vObjectSubtype = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x24;
			vMaterialType = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x28;
			vVolume = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x2C;
			vWeight = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x30;
			vBasePrice = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x34;
			vInvenID = buffer[offset];
			offset = 0x36;
			vInvenFrame = (buffer[offset] << 8) + buffer[offset + 1];
			offset = 0x38;
			vSoundID = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
		}

	}
	class cItemWeapon : Item
	{
		public cItemWeapon(int ObjectType, int ObjectID)
			: base(ObjectType, ObjectID)
		{
			vObjectType = ObjectType; // Тип объекта
			vObjectID = ObjectID; // ID объекта
		}
		public int vCharSprite;
		public int vMinimumDamage;
		public int vMaximumDamage;
		public int vDamageType;
		public int vRange1;
		public int vRange2;
		public int vFireFXType;
		public int vFireFX;
		public int vMinStr;
		public int vAP1;
		public int vAP2;
		public int vCriticalFaultMod;
		public int vPerk;
		public int vBurstFire;
		public int vCaliberType;
		public int vBulletID;
		public int vMagCapacity;
	}
	class cItemAmmo : Item
	{
		public cItemAmmo(int ObjectType, int ObjectID)
			: base(ObjectType, ObjectID)
		{
			vObjectType = ObjectType; // Тип объекта
			vObjectID = ObjectID; // ID объекта
		}
		public int vSoundIDAmmo;
		public int vCaliberType;
		public int vMagCapacity;
		public int vACMod;
		public int vDRMod;
		public int vDamageMultiplier;
		public int vDamageDevisor;

	}
	class cItemArmor : Item
	{
		public cItemArmor(int ObjectType, int ObjectID)
			: base(ObjectType, ObjectID)
		{
			vObjectType = ObjectType; // Тип объекта
			vObjectID = ObjectID; // ID объекта
		}
		public int vTesla;
		public int vAC;
		public int vDRNormal;
		public int vDRLaser;
		public int vDRFire;
		public int vDRPlasma;
		public int vDRElectrical;
		public int vDREMP;
		public int vDRExplosion;
		public int vDTNormal;
		public int vDTLaser;
		public int vDTFire;
		public int vDTPlasma;
		public int vDTElectrical;
		public int vDTEMP;
		public int vDTExplosion;
		public int vPerk;
		public int vMaleFrame;
		public int vFemaleFrame;
	}
	class cItemDrug : Item
	{
		public cItemDrug(int ObjectType, int ObjectID)
			: base(ObjectType, ObjectID)
		{
			vObjectType = ObjectType; // Тип объекта
			vObjectID = ObjectID; // ID объекта
		}
		public int vStatID1;
		public int vStatID2;
		public int vStatID3;
		public int vStatID1_Mod_Fast;
		public int vStatID2_Mod_Fast;
		public int vStatID3_Mod_Fast;
		public int vMidTimeout;
		public int vStatID1_Mod_Mid;
		public int vStatID2_Mod_Mid;
		public int vStatID3_Mod_Mid;
		public int vLongTimeout;
		public int vStatID1_Mod_Long;
		public int vStatID2_Mod_Long;
		public int vStatID3_Mod_Long;
		public int vAddictionRate;
		public int vPerk;
		public int vAddictTime;
	}
	class cItemContainer : Item
	{
		public cItemContainer(int ObjectType, int ObjectID)
			: base(ObjectType, ObjectID)
		{
			vObjectType = ObjectType; // Тип объекта
			vObjectID = ObjectID; // ID объекта
		}
		public int vSoundIDCont;
		public int vTotalVolume;
	}
	class cItemMisc : Item
	{
		public cItemMisc(int ObjectType, int ObjectID)
			: base(ObjectType, ObjectID)
		{
			vObjectType = ObjectType; // Тип объекта
			vObjectID = ObjectID; // ID объекта
		}
		public int vSoundIDMisc;
		public int vAmmoID;
		public int vCaliberType;
		public int vCharge;
	}
}