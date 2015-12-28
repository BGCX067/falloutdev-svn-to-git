using System;
using System.Collections.Generic;
using System.Text;

namespace fallserv.ObjectClasses
{
	class ItemAmmo : Item
	{
		public ItemAmmo(ObjectType objectType, int objectId)
			: base(objectType, objectId)
		{
			ObjectType = objectType; // Тип объекта
			ObjectId = objectId; // ID объекта
		}
		private int _soundIdAmmo;
		private int _caliberType;
		private int _magCapacity;
		private int _acMod;
		private int _drMod;
		private int _damageMultiplier;
		private int _damageDevisor;

		public int SoundIdAmmo
		{
			get { return _soundIdAmmo; }
			set { _soundIdAmmo = value; }
		}

		public int CaliberType
		{
			get { return _caliberType; }
			set { _caliberType = value; }
		}

		public int MagCapacity
		{
			get { return _magCapacity; }
			set { _magCapacity = value; }
		}

		public int AcMod
		{
			get { return _acMod; }
			set { _acMod = value; }
		}

		public int DrMod
		{
			get { return _drMod; }
			set { _drMod = value; }
		}

		public int DamageMultiplier
		{
			get { return _damageMultiplier; }
			set { _damageMultiplier = value; }
		}

		public int DamageDevisor
		{
			get { return _damageDevisor; }
			set { _damageDevisor = value; }
		}
	}
}
