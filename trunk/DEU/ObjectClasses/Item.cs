using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace fallserv.ObjectClasses
{
	class Item : ProtoObject
	{
		private static byte[] _buffer;
		public Item(ObjectType objectType, int objectId) : base(objectType, objectId)
		{
			ObjectType = objectType; // Тип объекта
			ObjectId = objectId; // ID объекта
		}

		#region Public variables
		private int _attackMode1;
		private int _attackMode2;
		private int _scriptId;
		private ItemSubtype _itemSubtype;
		private int _materialType;
		private int _volume;
		private int _weight;
		private int _basePrice;
		private int _invenId;
		private int _invenFrame;
		private string _invenPath;
		private int _soundId;

		public ItemSubtype ItemSubtype
		{
			get { return _itemSubtype; }
			set { _itemSubtype = value; }
		}

		public int ScriptId
		{
			get { return _scriptId; }
			set { _scriptId = value; }
		}

		public int AttackMode1
		{
			get { return _attackMode1; }
			set { _attackMode1 = value; }
		}

		public int AttackMode2
		{
			get { return _attackMode2; }
			set { _attackMode2 = value; }
		}

		public int MaterialType
		{
			get { return _materialType; }
			set { _materialType = value; }
		}

		public int Volume
		{
			get { return _volume; }
			set { _volume = value; }
		}

		public int Weight
		{
			get { return _weight; }
			set { _weight = value; }
		}

		public int BasePrice
		{
			get { return _basePrice; }
			set { _basePrice = value; }
		}

		public int InvenId
		{
			get { return _invenId; }
			set { _invenId = value; }
		}

		public int InvenFrame
		{
			get { return _invenFrame; }
			set { _invenFrame = value; }
		}

		public string InvenPath
		{
			get { return _invenPath; }
			set { _invenPath = value; }
		}

		public int SoundId
		{
			get { return _soundId; }
			set { _soundId = value; }
		}

		#endregion

		public void GetObjectProperties()
		{
			// Путь к базовому файлу
			// Путь к файлу списка протофайлов
			// Пусть к файлам прототипа
			// Путь к файлу списка графики
			// Путь к файлам графики
			// Временная строка №1
			string TempString = " ";
			// Временная строка №2
			string TempString1 = " ";

			string baseFile = GamePath + @"\MASTER.DAT\text\english\game\pro_item.msg";
			string listFile = GamePath + @"\MASTER.DAT\proto\items\items.lst";
			string pathToProto = GamePath + @"\MASTER.DAT\proto\items\";
			string pathToArt = string.Format(@"{0}\MASTER.DAT\art\items\", GamePath);
			string artListFile = GamePath + @"\MASTER.DAT\art\items\items.lst";

			// Получение файла прототипа объекта
			System.IO.TextReader fListFile = System.IO.File.OpenText(listFile);
			for (int i = 1; i <= ObjectId; i++)
				TempString = fListFile.ReadLine();
			fListFile.Close();

			// Путь к файлу прототипа объекта
			ObjectProto = pathToProto + TempString;

			//Загоняем весь прото-файл в байтовый массив

			FileStream fProtoFile = new FileStream(ObjectProto, FileMode.Open);

			_buffer = new byte[Convert.ToInt32(fProtoFile.Length)];
			fProtoFile.Read(_buffer, 0, Convert.ToInt16(fProtoFile.Length));
			fProtoFile.Close();

			System.IO.TextReader fArtListFile = System.IO.File.OpenText(artListFile);
			for (int i = 0; i <= (_buffer[10] * 256 + _buffer[11]); i++)
				TempString = fArtListFile.ReadLine();
			fListFile.Close();
			// Путь к файлу с графикой объекта
			ObjectFrame = TempString.Replace(".FRM", "");

			// Открытие базового файла объектов
			System.IO.TextReader fBaseFile = System.IO.File.OpenText(baseFile);
			if (!(fBaseFile.Peek() == -1))
			{
				do
				{
					TempString = fBaseFile.ReadLine();
				}
				while (!(TempString.Substring(1, ObjectId.ToString().Length + 2) == (ObjectId * 100).ToString()) && !((fBaseFile.Peek() == -1)));
				if (!(TempString.Substring(1, ObjectId.ToString().Length) == ObjectId.ToString()))
					TempString = "      ";
			}
			else
			{
				TempString = "     ";
			}
			if ((TempString.Substring(1, ObjectId.ToString().Length) == ObjectId.ToString()) && !(TempString == " "))
			{
				char[] aStrSplit = { '{', '}' };
				// Получение наименования объекта
				ObjectName = TempString.Split(aStrSplit)[5];
				if (!(fBaseFile.Peek() == -1))
				{
					TempString1 = fBaseFile.ReadLine();
					if (TempString1.Substring(1, TempString.Split(aStrSplit)[1].Length) == (ObjectId.ToString() + "01"))
						// Получение описания объекта
						ObjectDesc = TempString1.Split(aStrSplit)[5];
					else ObjectDesc = " ";
					fBaseFile.Close();
				}
				else
				{
					ObjectDesc = " ";
				}
			}
			else
			{
				ObjectDesc = " ";
				ObjectName = " ";
			}
			FrameIdType = _buffer[8];
			FrameIdOffset = _buffer[9];
			FrameId = _buffer[10] * 256 + _buffer[11];
			LightDistance = (_buffer[12] << 24) + (_buffer[13] << 16) + (_buffer[14] << 8) + _buffer[15];
			LightIntensity = (_buffer[16] << 24) + (_buffer[17] << 16) + (_buffer[18] << 8) + _buffer[19];
			AttackMode1 = (_buffer[27] & 15);
			AttackMode2 = (_buffer[27] & 240) >> 4;
			int offset = 0x1C;
			ScriptId = (_buffer[offset] << 24) + (_buffer[offset + 1] << 16) + (_buffer[offset + 2] << 8) + _buffer[offset + 3];
			offset = 0x20;
			ItemSubtype = (ItemSubtype) (_buffer[offset] << 24) + (_buffer[offset + 1] << 16) + (_buffer[offset + 2] << 8) + _buffer[offset + 3];
			offset = 0x24;
			MaterialType = (_buffer[offset] << 24) + (_buffer[offset + 1] << 16) + (_buffer[offset + 2] << 8) + _buffer[offset + 3];
			offset = 0x28;
			Volume = (_buffer[offset] << 24) + (_buffer[offset + 1] << 16) + (_buffer[offset + 2] << 8) + _buffer[offset + 3];
			offset = 0x2C;
			Weight = (_buffer[offset] << 24) + (_buffer[offset + 1] << 16) + (_buffer[offset + 2] << 8) + _buffer[offset + 3];
			offset = 0x30;
			BasePrice = (_buffer[offset] << 24) + (_buffer[offset + 1] << 16) + (_buffer[offset + 2] << 8) + _buffer[offset + 3];
			offset = 0x34;
			InvenId = _buffer[offset];
			offset = 0x36;
			InvenFrame = (_buffer[offset] << 8) + _buffer[offset + 1];
			offset = 0x38;
			SoundId = (_buffer[offset] << 24) + (_buffer[offset + 1] << 16) + (_buffer[offset + 2] << 8) + _buffer[offset + 3];
		}

	}
}
