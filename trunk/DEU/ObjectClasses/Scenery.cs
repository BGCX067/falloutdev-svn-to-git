using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace fallserv.ObjectClasses
{
	class Scenery : ProtoObject
	{
		// Конструктор объекта с заданием типа объекта и его ID
		public Scenery(ObjectType objectType, int objectId) : base(objectType, objectId)
		{
			ObjectType = objectType; // Тип объекта
			ObjectId = objectId; // ID объекта
		}

		private int _scriptId;
		private int _sceneryType;
		private int _materialType;
		private int _soundId;
		private int _availability;

		public int ScriptId
		{
			get { return _scriptId; }
			set { _scriptId = value; }
		}

		public int SceneryType
		{
			get { return _sceneryType; }
			set { _sceneryType = value; }
		}

		public int MaterialType
		{
			get { return _materialType; }
			set { _materialType = value; }
		}

		public int SoundId
		{
			get { return _soundId; }
			set { _soundId = value; }
		}

		public int Availability
		{
			get { return _availability; }
			set { _availability = value; }
		}

		// Процедура получения свойств объекта
		public void GetObjectProperties()
		{
			// Путь к базовому файлу
			string baseFile;
			// Путь к файлу списка протофайлов
			string listFile;
			// Пусть к файлам прототипа
			string pathToProto;
			// Путь к файлу списка графики
			string artListFile;
			// Путь к файлам графики
			string pathToArt;
			// Временная строка №1
			string tempString = " ";
			// Временная строка №2
			string tempString1 = " ";

			// Определение путей для объекта
			baseFile = GamePath + @"\MASTER.DAT\text\english\game\pro_scen.msg";
			listFile = GamePath + @"\MASTER.DAT\proto\scenery\scenery.lst";
			pathToProto = GamePath + @"\MASTER.DAT\proto\scenery\";
			pathToArt = @".\MASTER.DAT\art\scenery\";
			artListFile = GamePath + @"\MASTER.DAT\art\scenery\scenery.lst";

			// Получение файла прототипа объекта
			System.IO.TextReader fListFile = System.IO.File.OpenText(listFile);
			for (int i = 1; i <= ObjectId; i++)
				tempString = fListFile.ReadLine();
			fListFile.Close();

			// Путь к файлу прототипа объекта
			ObjectProto = pathToProto + tempString;

			//Загоняем весь прото-файл в байтовый массив

			FileStream fProtoFile = new FileStream(ObjectProto, FileMode.Open);

			byte[] buffer = new byte[Convert.ToInt32(fProtoFile.Length)];
			fProtoFile.Read(buffer, 0, Convert.ToInt16(fProtoFile.Length));
			fProtoFile.Close();

			System.IO.TextReader fArtListFile = System.IO.File.OpenText(artListFile);
			for (int i = 0; i <= (buffer[10] * 256 + buffer[11]); i++)
				tempString = fArtListFile.ReadLine();
			fListFile.Close();
			// Путь к файлу с графикой объекта
			ObjectFrame = tempString.Replace(".FRM", "");

			// Открытие базового файла объектов
			System.IO.TextReader fBaseFile = System.IO.File.OpenText(baseFile);
			if (!(fBaseFile.Peek() == -1))
			{
				do
				{
					tempString = fBaseFile.ReadLine();
				}
				while (!(tempString.Substring(1, ObjectId.ToString().Length + 2) == (ObjectId * 100).ToString()) && !((fBaseFile.Peek() == -1)));
				if (!(tempString.Substring(1, ObjectId.ToString().Length) == ObjectId.ToString())) tempString = "      ";
			}
			else
			{
				tempString = "     ";
			}
			if ((tempString.Substring(1, ObjectId.ToString().Length) == ObjectId.ToString()) && !(tempString == " "))
			{
				char[] aStrSplit = { '{', '}' };
				// Получение наименования объекта
				ObjectName = tempString.Split(aStrSplit)[5];
				if (!(fBaseFile.Peek() == -1))
				{
					tempString1 = fBaseFile.ReadLine();
					if (tempString1.Substring(1, tempString.Split(aStrSplit)[1].Length) == (ObjectId.ToString() + "01"))
						// Получение описания объекта
						ObjectDesc = tempString1.Split(aStrSplit)[5];
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
			FrameIdType = buffer[8];
			FrameIdOffset = buffer[9];
			FrameId = buffer[10] * 256 + buffer[11];
			LightDistance = (buffer[12] << 24) + (buffer[13] << 16) + (buffer[14] << 8) + buffer[15];
			LightIntensity = (buffer[16] << 24) + (buffer[17] << 16) + (buffer[18] << 8) + buffer[19];
			ScriptId = (buffer[28] << 24) + (buffer[29] << 16) + (buffer[30] << 8) + buffer[31];
			SceneryType = (buffer[32] << 24) + (buffer[33] << 16) + (buffer[34] << 8) + buffer[35];
			MaterialType = (buffer[36] << 24) + (buffer[37] << 16) + (buffer[38] << 8) + buffer[39];
			SoundId = buffer[40];
			Availability = (buffer[44] << 24) + (buffer[43] << 16) + (buffer[42] << 8) + buffer[41];
		}
	}
}
