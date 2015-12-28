using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace fallserv.ObjectClasses
{
	class ProtoObject
	{
		private readonly string _gamePath;

		public ProtoObject(ObjectType objectType, int objectId)
		{
			_gamePath = ConfigurationSettings.AppSettings["ResourcesPath"];
			_objectType = objectType; // Тип объекта
			_objectId = objectId; // ID объекта
		}
		// Тип объекта
		private ObjectType _objectType;
		// ID объекта
		private int _objectId;
		// Наименование объекта
		private string _objectName;
		// Описание объекта
		private string _objectDesc;
		// Путь к файлу прототипа объекта
		private string _objectProto;
		// Путь к файлу графики объекта
		private string _objectFrame;
		// Тип объекта фрейм файла
		private int _frameIdType;
		// Второй байт - если в нем записано отличное от 0 значение, 
		// то при выводе карты данный фрейм сдвигается на несколько пикселов 
		// вдоль одной из осей. Вдоль какой - зависит от самого фрейма.
		private int _frameIdOffset;
		// Собственно FrameID - номер строки в lst-файле master.dat\\art\items\items.lst
		private int _frameId;
		// Дистанция  света в игровых единицах(hexes) для данного объекта
		private int _lightDistance;
		// Интенсивность света в процентах для данного объекта.
		// Высчитывается в процентах от 256(01 00). 
		// Например если интенсивность света 80% то значение будет 205(CD).
		private int _lightIntensity;

		public string GamePath
		{
			get { return _gamePath; }
		}

		public ObjectType ObjectType
		{
			get { return _objectType; }
			set { _objectType = value; }
		}

		public int ObjectId
		{
			get { return _objectId; }
			set { _objectId = value; }
		}

		public string ObjectName
		{
			get { return _objectName; }
			set { _objectName = value; }
		}

		public string ObjectDesc
		{
			get { return _objectDesc; }
			set { _objectDesc = value; }
		}

		public string ObjectProto
		{
			get { return _objectProto; }
			set { _objectProto = value; }
		}

		public string ObjectFrame
		{
			get { return _objectFrame; }
			set { _objectFrame = value; }
		}

		public int FrameIdType
		{
			get { return _frameIdType; }
			set { _frameIdType = value; }
		}

		public int FrameIdOffset
		{
			get { return _frameIdOffset; }
			set { _frameIdOffset = value; }
		}

		public int FrameId
		{
			get { return _frameId; }
			set { _frameId = value; }
		}

		public int LightDistance
		{
			get { return _lightDistance; }
			set { _lightDistance = value; }
		}

		public int LightIntensity
		{
			get { return _lightIntensity; }
			set { _lightIntensity = value; }
		}
	}
}
