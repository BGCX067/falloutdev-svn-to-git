using System;
using System.Collections.Generic;
using System.Text;

namespace fallserv.ObjectClasses
{
	class ItemWeapon : Item
	{
		public ItemWeapon(ObjectType objectType, int objectId) : base(objectType, objectId)
		{
			ObjectType = objectType; // Тип объекта
			ObjectId = objectId; // ID объекта
		}
		private int _charSprite;
		private int _minimumDamage;
		private int _maximumDamage;
		private int _damageType;
		private int _range1;
		private int _range2;
		private int _fireFxType;
		private int _fireFx;
		private int _minStr;
		private int _ap1;
		private int _ap2;
		private int _criticalFaultMod;
		private int _perk;
		private int _burstFire;
		private int _caliberType;
		private int _bulletId;
		private int _magCapacity;

		public int CharSprite
		{
			get { return _charSprite; }
			set { _charSprite = value; }
		}

		public int MinimumDamage
		{
			get { return _minimumDamage; }
			set { _minimumDamage = value; }
		}

		public int MaximumDamage
		{
			get { return _maximumDamage; }
			set { _maximumDamage = value; }
		}

		public int DamageType
		{
			get { return _damageType; }
			set { _damageType = value; }
		}

		public int Range1
		{
			get { return _range1; }
			set { _range1 = value; }
		}

		public int Range2
		{
			get { return _range2; }
			set { _range2 = value; }
		}

		public int FireFxType
		{
			get { return _fireFxType; }
			set { _fireFxType = value; }
		}

		public int FireFx
		{
			get { return _fireFx; }
			set { _fireFx = value; }
		}

		public int MinStr
		{
			get { return _minStr; }
			set { _minStr = value; }
		}

		public int Ap1
		{
			get { return _ap1; }
			set { _ap1 = value; }
		}

		public int Ap2
		{
			get { return _ap2; }
			set { _ap2 = value; }
		}

		public int CriticalFaultMod
		{
			get { return _criticalFaultMod; }
			set { _criticalFaultMod = value; }
		}

		public int Perk
		{
			get { return _perk; }
			set { _perk = value; }
		}

		public int BurstFire
		{
			get { return _burstFire; }
			set { _burstFire = value; }
		}

		public int CaliberType
		{
			get { return _caliberType; }
			set { _caliberType = value; }
		}

		public int BulletId
		{
			get { return _bulletId; }
			set { _bulletId = value; }
		}

		public int MagCapacity
		{
			get { return _magCapacity; }
			set { _magCapacity = value; }
		}
	}
}
