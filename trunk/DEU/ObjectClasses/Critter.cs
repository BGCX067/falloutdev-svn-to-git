using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace fallserv.ObjectClasses
{
	class Critter : ProtoObject
	{
		// Конструктор объекта с заданием типа объекта и его ID
		public Critter(ObjectType objectType, int objectId)
			: base(objectType, objectId)
		{
			ObjectType = objectType; // Тип объекта
			ObjectId = objectId; // ID объекта
		}

		// Массив типов объектов
		public enum eObjectType { items, critters, scenery, walls, tiles, misc, intrface, inven };

		#region Public Variables
		public int ScriptId;
		public int TalkingHeadFrame;
		public int AIPaket_num;
		public int TeamNumber;
		public int Strength;
		public int Perception;
		public int Endurance;
		public int Charisma;
		public int Intelligence;
		public int Agility;
		public int Luck;
		public int HP;
		public int AP;
		public int AC;
		public int UnarmedDamage;
		public int MeleeDamage;
		public int CarryWeight;
		public int Sequence;
		public int HealingRate;
		public int CriticalChance;
		public int BetterCriticals;
		public int DT_Normal;
		public int DT_Laser;
		public int DT_Fire;
		public int DT_Plasma;
		public int DT_Electrical;
		public int DT_EMP;
		public int DT_Explode;
		public int DR_Normal;
		public int DR_Laser;
		public int DR_Fire;
		public int DR_Plasma;
		public int DR_Electrical;
		public int DR_EMP;
		public int DR_Explode;
		public int DR_Radiation;
		public int DR_Poison;
		public int BaseAge;
		public int BaseSex;
		public int ExtraStrenght;
		public int ExtraPerception;
		public int ExtraEndurance;
		public int ExtraCharisma;
		public int ExtraIntelligence;
		public int ExtraAgility;
		public int ExtraLuck;
		public int ExtraHP;
		public int ExtraAP;
		public int ExtraAC;
		public int ExtraUnarmedDamage;
		public int ExtraMeleeDamage;
		public int ExtraCarryWeight;
		public int ExtraSequence;
		public int ExtraHealingRate;
		public int ExtraCriticalChance;
		public int ExtraBetterCriticals;
		public int ExtraDT_Normal;
		public int ExtraDT_Laser;
		public int ExtraDT_Fire;
		public int ExtraDT_Plasma;
		public int ExtraDT_Electrical;
		public int ExtraDT_EMP;
		public int ExtraDT_Explode;
		public int ExtraDR_Normal;
		public int ExtraDR_Laser;
		public int ExtraDR_Fire;
		public int ExtraDR_Plasma;
		public int ExtraDR_Electrical;
		public int ExtraDR_EMP;
		public int ExtraDR_Explode;
		public int ExtraDR_Radiation;
		public int ExtraDR_Poison;
		public int ExtraAge;
		public int ExtraSex;
		public int Skill_SmallGuns;
		public int Skill_BigGuns;
		public int Skill_EnergyWeapons;
		public int Skill_Unarmed;
		public int Skill_Melee;
		public int Skill_Throwing;
		public int Skill_FirstAid;
		public int Skill_Doctor;
		public int Skill_Sneak;
		public int Skill_Lockpick;
		public int Skill_Steal;
		public int Skill_Traps;
		public int Skill_Science;
		public int Skill_Repair;
		public int Skill_Speech;
		public int Skill_Barter;
		public int Skill_Gambling;
		public int Skill_Outdoorsmanship;
		public int BodyType;
		public int XPForKill;
		public int KillType;
		public int DamageType;
		#endregion

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
			baseFile = GamePath + @"\MASTER.DAT\text\english\game\pro_crit.msg";
			listFile = GamePath + @"\MASTER.DAT\proto\critters\critters.lst";
			pathToProto = GamePath + @"\MASTER.DAT\proto\critters\";
			pathToArt = @".\CRITTER.DAT\art\critters\";
			artListFile = GamePath + @"\CRITTER.DAT\art\critters\critters.lst";
			
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
			int offset = 0xc;
			LightDistance = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x10;
			LightIntensity = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x1C;
			ScriptId = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x20;
			TalkingHeadFrame = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x24;
			AIPaket_num = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x28;
			TeamNumber = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			// Базовые основные параметры
			offset = 0x30;
			Strength = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x34;
			Perception = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x38;
			Endurance = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x3C;
			Charisma = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x40;
			Intelligence = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x44;
			Agility = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x48;
			Luck = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x4C;
			HP = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x50;
			AP = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x54;
			AC = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x58;
			UnarmedDamage = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x5C;
			MeleeDamage = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x60;
			CarryWeight = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x64;
			Sequence = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x68;
			HealingRate = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x6C;
			CriticalChance = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x70;
			BetterCriticals = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			// Базовые сопротивления и трешхолды(Tresholds)
			offset = 0x74;
			DT_Normal = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x78;
			DT_Laser = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x7C;
			DT_Fire = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x80;
			DT_Plasma = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x84;
			DT_Electrical = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x88;
			DT_EMP = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x8C;
			DT_Explode = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x90;
			DR_Normal = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x94;
			DR_Laser = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x98;
			DR_Fire = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x9C;
			DR_Plasma = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xA0;
			DR_Electrical = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xA4;
			DR_EMP = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xA8;
			DR_Explode = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xAC;
			DR_Radiation = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xB0;
			DR_Poison = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			//Базовое разное
			offset = 0xB4;
			BaseAge = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xB8;
			BaseSex = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			//Дополнительные основные параметры
			offset = 0xBC;
			ExtraStrenght = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xC0;
			ExtraPerception = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xC4;
			ExtraEndurance = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xC8;
			ExtraCharisma = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xCC;
			ExtraIntelligence = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xD0;
			ExtraAgility = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xD4;
			ExtraLuck = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xD8;
			ExtraHP = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xDC;
			ExtraAP = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xE0;
			ExtraAC = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xE4;
			ExtraUnarmedDamage = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xE8;
			ExtraMeleeDamage = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xEC;
			ExtraCarryWeight = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xF0;
			ExtraSequence = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xF4;
			ExtraHealingRate = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xF8;
			ExtraCriticalChance = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0xFC;
			ExtraBetterCriticals = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			//Дополнительные сопротивления и трешхолды(Tresholds)
			offset = 0x100;
			ExtraDT_Normal = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x104;
			ExtraDT_Laser = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x108;
			ExtraDT_Fire = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x10C;
			ExtraDT_Plasma = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x110;
			ExtraDT_Electrical = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x114;
			ExtraDT_EMP = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x118;
			ExtraDT_Explode = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x11C;
			ExtraDR_Normal = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x120;
			ExtraDR_Laser = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x124;
			ExtraDR_Fire = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x128;
			ExtraDR_Plasma = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x12C;
			ExtraDR_Electrical = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x130;
			ExtraDR_EMP = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x134;
			ExtraDR_Explode = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x138;
			ExtraDR_Radiation = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x13C;
			ExtraDR_Poison = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			// Дополнительное разное
			offset = 0x140;
			ExtraAge = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x144;
			ExtraSex = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			// Навыки
			offset = 0x148;
			Skill_SmallGuns = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x14C;
			Skill_BigGuns = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x150;
			Skill_EnergyWeapons = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x154;
			Skill_Unarmed = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x158;
			Skill_Melee = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x15C;
			Skill_Throwing = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x160;
			Skill_FirstAid = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x164;
			Skill_Doctor = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x168;
			Skill_Sneak = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x16C;
			Skill_Lockpick = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x170;
			Skill_Steal = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x174;
			Skill_Traps = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x178;
			Skill_Science = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x17C;
			Skill_Repair = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x180;
			Skill_Speech = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x184;
			Skill_Barter = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x188;
			Skill_Gambling = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x18C;
			Skill_Outdoorsmanship = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			// Остальное
			offset = 0x190;
			BodyType = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x194;
			XPForKill = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x198;
			KillType = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];
			offset = 0x19C;
			DamageType = (buffer[offset] << 24) + (buffer[offset + 1] << 16) + (buffer[offset + 2] << 8) + buffer[offset + 3];

		}
	}
}
