using System;
using System.IO;
using System.Text;
using A;
using Core;
using ExitGames.Client.Photon;
using UnityEngine;
using XsdSettings;

public static class BolCustomType
{
	public static int c3201deb4f4d63f1b77df235945b0cdd2(object cebae66039aadeac8deb1211786332a72)
	{
		int result = 0;
		if (cebae66039aadeac8deb1211786332a72 == null)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				break;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
		}
		else if (cebae66039aadeac8deb1211786332a72 is Enum)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				break;
			}
			result = 5;
		}
		else if (cebae66039aadeac8deb1211786332a72 is int)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				break;
			}
			result = 5;
		}
		else if (cebae66039aadeac8deb1211786332a72 is short)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				break;
			}
			result = 3;
		}
		else if (cebae66039aadeac8deb1211786332a72 is ushort)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				break;
			}
			result = 3;
		}
		else if (cebae66039aadeac8deb1211786332a72 is byte)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				break;
			}
			result = 2;
		}
		else if (cebae66039aadeac8deb1211786332a72 is char)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				break;
			}
			result = 3;
		}
		else if (cebae66039aadeac8deb1211786332a72 is bool)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				break;
			}
			result = 2;
		}
		else if (cebae66039aadeac8deb1211786332a72 is double)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				break;
			}
			result = 9;
		}
		else if (cebae66039aadeac8deb1211786332a72 is float)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				break;
			}
			result = 5;
		}
		else if (cebae66039aadeac8deb1211786332a72 is Vector2)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				break;
			}
			result = 10;
		}
		else if (cebae66039aadeac8deb1211786332a72 is Vector3)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				break;
			}
			result = 15;
		}
		else if (cebae66039aadeac8deb1211786332a72 is Transform)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				break;
			}
			result = 30;
		}
		else if (cebae66039aadeac8deb1211786332a72 is Quaternion)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				break;
			}
			result = 16;
		}
		else if (cebae66039aadeac8deb1211786332a72 is PhotonPlayer)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				break;
			}
			result = 4;
		}
		else if (cebae66039aadeac8deb1211786332a72 is WeaponDNA)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				break;
			}
			result = 106;
		}
		else if (cebae66039aadeac8deb1211786332a72 is ItemDNA)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				break;
			}
			result = 98;
		}
		else if (cebae66039aadeac8deb1211786332a72 is ItemInstance)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				break;
			}
			result = 39;
		}
		else if (cebae66039aadeac8deb1211786332a72 is AvatarDNA)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				break;
			}
			result = 14;
		}
		else
		{
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Network, "unknown BOL custom type:" + cebae66039aadeac8deb1211786332a72.GetType().Name);
		}
		return result;
	}

	public static void c57e4d4cd41f3be21d7e24a71aa08c6ba()
	{
		PhotonPeer.RegisterType(Type.GetTypeFromHandle(cf5b3cdfc41f90e0d9a59b89f9ceccb09.cc1720d05c75832f704b87474932341c3()), 65, c02f394ba90598180edc38a4fc5f3040b, c07b6653279a028705d6a0b1841e62b8f);
		PhotonPeer.RegisterType(Type.GetTypeFromHandle(c4ff9e36324cd2548596c440cae8aaecd.cc1720d05c75832f704b87474932341c3()), 66, c038825541993f289583d163829e64410, cfe935a801142da6bca428fe9ff22e184);
		PhotonPeer.RegisterType(Type.GetTypeFromHandle(c19cbd456e62105e5d5430a7ea4638876.cc1720d05c75832f704b87474932341c3()), 67, c553841f3faa82c535f2c14130f00e5b7, cff846c75b6622f3649597bd58a64b54f);
		PhotonPeer.RegisterType(Type.GetTypeFromHandle(c0ce08476e375e7902c09021458376061.cc1720d05c75832f704b87474932341c3()), 68, c5018a6c9ee3723f72655fffeab7a1594, cd3b2d95ae2956f03ae9245607f16985a);
	}

	private static byte[] c02f394ba90598180edc38a4fc5f3040b(object c0b04722613d94555e481aa4a101b9eb0)
	{
		WeaponDNA weaponDNA = (WeaponDNA)c0b04722613d94555e481aa4a101b9eb0;
		byte[] bytes = Encoding.Unicode.GetBytes(weaponDNA.m_name);
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(BitConverter.GetBytes(weaponDNA.m_id), 0, 4);
		memoryStream.Write(BitConverter.GetBytes(weaponDNA.m_level), 0, 4);
		memoryStream.Write(BitConverter.GetBytes((int)weaponDNA.m_type), 0, 4);
		memoryStream.Write(BitConverter.GetBytes((int)weaponDNA.m_rarity), 0, 4);
		memoryStream.Write(BitConverter.GetBytes((int)weaponDNA.m_generationSource), 0, 4);
		memoryStream.Write(BitConverter.GetBytes(weaponDNA.m_starLevel), 0, 4);
		memoryStream.Write(BitConverter.GetBytes(weaponDNA.m_starExperience), 0, 4);
		memoryStream.Write(BitConverter.GetBytes(weaponDNA.m_subPartsCode.Length), 0, 4);
		for (int i = 0; i < weaponDNA.m_subPartsCode.Length; i++)
		{
			memoryStream.Write(BitConverter.GetBytes(weaponDNA.m_subPartsCode[i]), 0, 4);
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			memoryStream.Write(BitConverter.GetBytes(weaponDNA.m_extraEffectCount), 0, 4);
			for (int j = 0; j < weaponDNA.m_extraEffectCount; j++)
			{
				memoryStream.Write(BitConverter.GetBytes(weaponDNA.m_extraEffect[j]), 0, 4);
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				for (int k = 0; k < weaponDNA.m_extraEffectCount; k++)
				{
					memoryStream.Write(BitConverter.GetBytes(weaponDNA.m_extraEffectIndex[k]), 0, 4);
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					memoryStream.Write(BitConverter.GetBytes(bytes.Length), 0, 4);
					memoryStream.Write(bytes, 0, bytes.Length);
					return memoryStream.ToArray();
				}
			}
		}
	}

	private static object c07b6653279a028705d6a0b1841e62b8f(byte[] caaeca6e35667f32ce3da8be21b2cc4b8)
	{
		int num = 0;
		WeaponDNA weaponDNA = new WeaponDNA();
		weaponDNA.m_id = BitConverter.ToInt32(caaeca6e35667f32ce3da8be21b2cc4b8, num);
		num += 4;
		weaponDNA.m_level = BitConverter.ToInt32(caaeca6e35667f32ce3da8be21b2cc4b8, num);
		num += 4;
		weaponDNA.m_type = (WeaponType)(byte)BitConverter.ToChar(caaeca6e35667f32ce3da8be21b2cc4b8, num);
		num += 4;
		weaponDNA.m_rarity = (WeaponRarity)(byte)BitConverter.ToChar(caaeca6e35667f32ce3da8be21b2cc4b8, num);
		num += 4;
		weaponDNA.m_generationSource = (GenerationSource)(byte)BitConverter.ToChar(caaeca6e35667f32ce3da8be21b2cc4b8, num);
		num += 4;
		weaponDNA.m_starLevel = BitConverter.ToInt32(caaeca6e35667f32ce3da8be21b2cc4b8, num);
		num += 4;
		weaponDNA.m_starExperience = BitConverter.ToInt32(caaeca6e35667f32ce3da8be21b2cc4b8, num);
		num += 4;
		int num2 = BitConverter.ToInt32(caaeca6e35667f32ce3da8be21b2cc4b8, num);
		num += 4;
		if (num2 != weaponDNA.m_subPartsCode.Length)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				break;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "DeserializeWeaponDNA subparts num is different");
		}
		for (int i = 0; i < num2; i++)
		{
			weaponDNA.m_subPartsCode[i] = BitConverter.ToInt32(caaeca6e35667f32ce3da8be21b2cc4b8, num);
			num += 4;
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			weaponDNA.m_extraEffectCount = BitConverter.ToInt32(caaeca6e35667f32ce3da8be21b2cc4b8, num);
			num += 4;
			if (weaponDNA.m_extraEffectCount > ItemDNA.m_extraEffectNums)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Network, "m_extraEffectCount number + " + weaponDNA.m_extraEffectCount + " is over max");
			}
			for (int j = 0; j < weaponDNA.m_extraEffectCount; j++)
			{
				weaponDNA.m_extraEffect[j] = BitConverter.ToInt32(caaeca6e35667f32ce3da8be21b2cc4b8, num);
				num += 4;
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				for (int k = 0; k < weaponDNA.m_extraEffectCount; k++)
				{
					weaponDNA.m_extraEffectIndex[k] = BitConverter.ToInt32(caaeca6e35667f32ce3da8be21b2cc4b8, num);
					num += 4;
				}
				while (true)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					int num3 = BitConverter.ToInt32(caaeca6e35667f32ce3da8be21b2cc4b8, num);
					num += 4;
					weaponDNA.m_name = Encoding.Unicode.GetString(caaeca6e35667f32ce3da8be21b2cc4b8, num, num3);
					num += num3;
					weaponDNA.ce6ec0bf2246c7c29dcd48277bcd2f743();
					return weaponDNA;
				}
			}
		}
	}

	private static byte[] c038825541993f289583d163829e64410(object c0b04722613d94555e481aa4a101b9eb0)
	{
		ItemDNA itemDNA = (ItemDNA)c0b04722613d94555e481aa4a101b9eb0;
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(BitConverter.GetBytes((int)itemDNA.m_type), 0, 4);
		if (itemDNA.ca8e8ecb1231bf8cf32c06da446a48681(ItemType.Weapon))
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				break;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			byte[] array = c02f394ba90598180edc38a4fc5f3040b(itemDNA.ca79da172938fdc8c067fb64242b6174a());
			memoryStream.Write(array, 0, array.Length);
		}
		else if (itemDNA.ca8e8ecb1231bf8cf32c06da446a48681(ItemType.Ammo))
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				break;
			}
			memoryStream.Write(BitConverter.GetBytes((int)itemDNA.m_ammoType), 0, 4);
			memoryStream.Write(BitConverter.GetBytes(itemDNA.m_value), 0, 4);
		}
		else if (itemDNA.ca8e8ecb1231bf8cf32c06da446a48681(ItemType.Material))
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				break;
			}
			memoryStream.Write(BitConverter.GetBytes((int)itemDNA.m_materialType), 0, 4);
			memoryStream.Write(BitConverter.GetBytes(itemDNA.m_value), 0, 4);
		}
		else if (itemDNA.ca8e8ecb1231bf8cf32c06da446a48681(ItemType.Shield))
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				break;
			}
			if (itemDNA.m_shiled != null)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
				memoryStream.Write(BitConverter.GetBytes(itemDNA.m_shiled.m_id), 0, 4);
				memoryStream.Write(BitConverter.GetBytes(itemDNA.m_shiled.m_level), 0, 4);
				memoryStream.Write(BitConverter.GetBytes((int)itemDNA.m_shiled.m_shieldManufacturer), 0, 4);
				memoryStream.Write(BitConverter.GetBytes(itemDNA.m_shiled.m_bodyIdx), 0, 4);
				memoryStream.Write(BitConverter.GetBytes(itemDNA.m_shiled.m_batteryIdx), 0, 4);
				memoryStream.Write(BitConverter.GetBytes(itemDNA.m_shiled.m_capacitorIdx), 0, 4);
				memoryStream.Write(BitConverter.GetBytes(itemDNA.m_shiled.m_accessoryIdx), 0, 4);
				memoryStream.Write(BitConverter.GetBytes(itemDNA.m_shiled.m_materialIdx), 0, 4);
				memoryStream.Write(BitConverter.GetBytes((int)itemDNA.m_shiled.m_generationSource), 0, 4);
				memoryStream.Write(BitConverter.GetBytes((int)itemDNA.m_shiled.m_rarity), 0, 4);
				byte[] bytes = Encoding.Unicode.GetBytes(itemDNA.m_shiled.m_name);
				memoryStream.Write(BitConverter.GetBytes(bytes.Length), 0, 4);
				memoryStream.Write(bytes, 0, bytes.Length);
			}
			else
			{
				int value = 0;
				memoryStream.Write(BitConverter.GetBytes(value), 0, 4);
				memoryStream.Write(BitConverter.GetBytes(value), 0, 4);
				memoryStream.Write(BitConverter.GetBytes(value), 0, 4);
				memoryStream.Write(BitConverter.GetBytes(value), 0, 4);
				memoryStream.Write(BitConverter.GetBytes(value), 0, 4);
				memoryStream.Write(BitConverter.GetBytes(value), 0, 4);
				memoryStream.Write(BitConverter.GetBytes(value), 0, 4);
				memoryStream.Write(BitConverter.GetBytes(value), 0, 4);
				memoryStream.Write(BitConverter.GetBytes(value), 0, 4);
				memoryStream.Write(BitConverter.GetBytes(value), 0, 4);
				memoryStream.Write(BitConverter.GetBytes(value), 0, 4);
			}
		}
		else if (itemDNA.ca8e8ecb1231bf8cf32c06da446a48681(ItemType.ClassMode))
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				break;
			}
			memoryStream.Write(BitConverter.GetBytes(itemDNA.m_classMode.m_id), 0, 4);
			memoryStream.Write(BitConverter.GetBytes((int)itemDNA.m_classMode.m_cmType), 0, 4);
			memoryStream.Write(BitConverter.GetBytes((int)itemDNA.m_classMode.m_rarity), 0, 4);
			memoryStream.Write(BitConverter.GetBytes((int)itemDNA.m_classMode.m_generationSource), 0, 4);
			memoryStream.Write(BitConverter.GetBytes(itemDNA.m_classMode.m_adapterIdx), 0, 4);
			memoryStream.Write(BitConverter.GetBytes(itemDNA.m_classMode.m_bodyIdx), 0, 4);
			memoryStream.Write(BitConverter.GetBytes(itemDNA.m_classMode.m_chassisIdx), 0, 4);
			memoryStream.Write(BitConverter.GetBytes(itemDNA.m_classMode.m_drumIdx), 0, 4);
			memoryStream.Write(BitConverter.GetBytes(itemDNA.m_classMode.m_materialIdx), 0, 4);
			memoryStream.Write(BitConverter.GetBytes(itemDNA.m_classMode.m_level), 0, 4);
			byte[] bytes2 = Encoding.Unicode.GetBytes(itemDNA.m_classMode.m_name);
			memoryStream.Write(BitConverter.GetBytes(bytes2.Length), 0, 4);
			memoryStream.Write(bytes2, 0, bytes2.Length);
		}
		else
		{
			memoryStream.Write(BitConverter.GetBytes(itemDNA.m_value), 0, 4);
		}
		return memoryStream.ToArray();
	}

	private static object cfe935a801142da6bca428fe9ff22e184(byte[] caaeca6e35667f32ce3da8be21b2cc4b8)
	{
		ItemDNA itemDNA = c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e;
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(caaeca6e35667f32ce3da8be21b2cc4b8, 0, caaeca6e35667f32ce3da8be21b2cc4b8.Length);
		memoryStream.Seek(0L, SeekOrigin.Begin);
		byte[] array = ce2f159fe707a376b497f666c368f15ed.c0a0cdf4a196914163f7334d9b0781a04(4);
		memoryStream.Read(array, 0, 4);
		int num = BitConverter.ToInt32(caaeca6e35667f32ce3da8be21b2cc4b8, 0);
		if (num == 2)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				break;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			byte[] array2 = ce2f159fe707a376b497f666c368f15ed.c0a0cdf4a196914163f7334d9b0781a04((int)(long)checked((IntPtr)unchecked(memoryStream.Length - memoryStream.Position)));
			memoryStream.Read(array2, 0, array2.Length);
			WeaponDNA weaponDNA = new WeaponDNA();
			weaponDNA = (WeaponDNA)c07b6653279a028705d6a0b1841e62b8f(array2);
			itemDNA = ItemDNA.c8284b9f225995cc6a6e1888c9c037b06(weaponDNA);
		}
		if (num == 1)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				break;
			}
			memoryStream.Read(array, 0, array.Length);
			int cefda2fdc3ce4e04f38bab77fc = BitConverter.ToInt32(array, 0);
			itemDNA = ItemDNA.cc17851d48b488126d6f73578b5780377(cefda2fdc3ce4e04f38bab77fc);
		}
		if (num == 7)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				break;
			}
			memoryStream.Read(array, 0, array.Length);
			int cefda2fdc3ce4e04f38bab77fc2 = BitConverter.ToInt32(array, 0);
			itemDNA = ItemDNA.c2360cbbc495138755199b7da0e6f9841(cefda2fdc3ce4e04f38bab77fc2);
		}
		if (num == 4)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				break;
			}
			memoryStream.Read(array, 0, array.Length);
			int c2b4f43f34e21572af6ab4414f04cee = BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			int cefda2fdc3ce4e04f38bab77fc3 = BitConverter.ToInt32(array, 0);
			itemDNA = ItemDNA.cda992a74324f68bb483f862f7544f742(cefda2fdc3ce4e04f38bab77fc3, (AmmoType)c2b4f43f34e21572af6ab4414f04cee);
		}
		if (num == 6)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				break;
			}
			memoryStream.Read(array, 0, array.Length);
			int c424fafa6354141c1e81d53efca575d8d = BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			int cefda2fdc3ce4e04f38bab77fc4 = BitConverter.ToInt32(array, 0);
			itemDNA = ItemDNA.c172f9d0eb2874d9d30bb9354caf9aab4((MaterialType)c424fafa6354141c1e81d53efca575d8d, cefda2fdc3ce4e04f38bab77fc4);
		}
		if (num == 3)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				break;
			}
			memoryStream.Read(array, 0, array.Length);
			int cefda2fdc3ce4e04f38bab77fc5 = BitConverter.ToInt32(array, 0);
			itemDNA = ItemDNA.cf3cf5ff68c6b242036334f6d3f834e32(cefda2fdc3ce4e04f38bab77fc5);
		}
		if (num == 5)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				break;
			}
			ShieldDNA shieldDNA = new ShieldDNA();
			memoryStream.Read(array, 0, array.Length);
			shieldDNA.m_id = BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			shieldDNA.m_level = BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			shieldDNA.m_shieldManufacturer = (ItemManufacturer)BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			shieldDNA.m_bodyIdx = BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			shieldDNA.m_batteryIdx = BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			shieldDNA.m_capacitorIdx = BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			shieldDNA.m_accessoryIdx = BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			shieldDNA.m_materialIdx = BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			shieldDNA.m_generationSource = (GenerationSource)BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			shieldDNA.m_rarity = (ItemRarity)BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			int num2 = BitConverter.ToInt32(array, 0);
			if (num2 > 0)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
				byte[] array3 = ce2f159fe707a376b497f666c368f15ed.c0a0cdf4a196914163f7334d9b0781a04(num2);
				memoryStream.Read(array3, 0, num2);
				shieldDNA.m_name = Encoding.Unicode.GetString(array3, 0, num2);
			}
			shieldDNA.ce6ec0bf2246c7c29dcd48277bcd2f743();
			itemDNA = ItemDNA.c8f331a9c3beba42f2ccd0923c0c67e0a(shieldDNA);
		}
		if (num == 8)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				break;
			}
			ClassModeDNA classModeDNA = new ClassModeDNA();
			memoryStream.Read(array, 0, array.Length);
			classModeDNA.m_id = BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			int cmType = BitConverter.ToInt32(array, 0);
			classModeDNA.m_cmType = (ClassModeType)cmType;
			memoryStream.Read(array, 0, array.Length);
			int rarity = BitConverter.ToInt32(array, 0);
			classModeDNA.m_rarity = (ItemRarity)rarity;
			memoryStream.Read(array, 0, array.Length);
			int generationSource = BitConverter.ToInt32(array, 0);
			classModeDNA.m_generationSource = (GenerationSource)generationSource;
			memoryStream.Read(array, 0, array.Length);
			classModeDNA.m_adapterIdx = BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			classModeDNA.m_bodyIdx = BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			classModeDNA.m_chassisIdx = BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			classModeDNA.m_drumIdx = BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			classModeDNA.m_materialIdx = BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			classModeDNA.m_level = BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, array.Length);
			int num3 = BitConverter.ToInt32(array, 0);
			if (num3 > 0)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
				byte[] array4 = ce2f159fe707a376b497f666c368f15ed.c0a0cdf4a196914163f7334d9b0781a04(num3);
				memoryStream.Read(array4, 0, num3);
				classModeDNA.m_name = Encoding.Unicode.GetString(array4, 0, num3);
			}
			classModeDNA.ce6ec0bf2246c7c29dcd48277bcd2f743();
			itemDNA = ItemDNA.c7a1e006dac3107ddc09019d735839e9a(classModeDNA);
		}
		if (itemDNA != null)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				break;
			}
			itemDNA.c61424d9a3f10a4d9e905c46e13e1d512(c1ee7921b0c3cce194fb7cae41b5a9d82<ShopServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cea43b56720acf4921bdb69611f03ebdb(itemDNA));
		}
		return itemDNA;
	}

	private static byte[] c553841f3faa82c535f2c14130f00e5b7(object c0b04722613d94555e481aa4a101b9eb0)
	{
		ItemInstance itemInstance = (ItemInstance)c0b04722613d94555e481aa4a101b9eb0;
		MemoryStream memoryStream = new MemoryStream();
		byte[] array = ce2f159fe707a376b497f666c368f15ed.c0a0cdf4a196914163f7334d9b0781a04(39);
		Array.Clear(array, 0, array.Length);
		for (int i = 0; i < itemInstance.m_id.Length; i++)
		{
			array[i] = Convert.ToByte(itemInstance.m_id[i]);
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			memoryStream.Write(array, 0, 39);
			memoryStream.Write(BitConverter.GetBytes(itemInstance.m_exp), 0, 4);
			return memoryStream.ToArray();
		}
	}

	private static object cff846c75b6622f3649597bd58a64b54f(byte[] caaeca6e35667f32ce3da8be21b2cc4b8)
	{
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(caaeca6e35667f32ce3da8be21b2cc4b8, 0, 39);
		memoryStream.Seek(0L, SeekOrigin.Begin);
		byte[] array = ce2f159fe707a376b497f666c368f15ed.c0a0cdf4a196914163f7334d9b0781a04(39);
		memoryStream.Read(array, 0, 39);
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		while (true)
		{
			if (num < array.Length)
			{
				if (array[num] == 0)
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						break;
					}
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					break;
				}
				stringBuilder.Append(Convert.ToChar(array[num]));
				num++;
				continue;
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				break;
			}
			break;
		}
		Array.Clear(array, 0, array.Length);
		memoryStream.Read(array, 0, 4);
		int cf13fd632f93aa296c99679582ff35a = BitConverter.ToInt32(array, 0);
		return new ItemInstance(stringBuilder.ToString(), cf13fd632f93aa296c99679582ff35a);
	}

	private static byte[] c5018a6c9ee3723f72655fffeab7a1594(object c0b04722613d94555e481aa4a101b9eb0)
	{
		AvatarDNA avatarDNA = (AvatarDNA)c0b04722613d94555e481aa4a101b9eb0;
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(BitConverter.GetBytes((char)avatarDNA.m_type), 0, 2);
		memoryStream.Write(BitConverter.GetBytes(avatarDNA.m_buildingUnit.mFBXs.Count), 0, 4);
		memoryStream.Write(BitConverter.GetBytes(avatarDNA.m_buildingUnit.bkID), 0, 4);
		memoryStream.Write(avatarDNA.m_buildingUnit.mFBXs.ToArray(), 0, avatarDNA.m_buildingUnit.mFBXs.Count * 1);
		memoryStream.Write(avatarDNA.m_buildingUnit.mMats.ToArray(), 0, avatarDNA.m_buildingUnit.mMats.Count * 1);
		return memoryStream.ToArray();
	}

	private static object cd3b2d95ae2956f03ae9245607f16985a(byte[] caaeca6e35667f32ce3da8be21b2cc4b8)
	{
		int num = 0;
		AvatarDNA avatarDNA = new AvatarDNA();
		avatarDNA.m_type = (AvatarType)(byte)BitConverter.ToChar(caaeca6e35667f32ce3da8be21b2cc4b8, num);
		num += 2;
		int num2 = BitConverter.ToInt32(caaeca6e35667f32ce3da8be21b2cc4b8, num);
		num += 4;
		avatarDNA.cb2dc67c96c361fca33303dac1fd10e03(num2);
		avatarDNA.m_buildingUnit.bkID = BitConverter.ToUInt32(caaeca6e35667f32ce3da8be21b2cc4b8, num);
		num += 4;
		for (int i = 0; i < num2; i++)
		{
			avatarDNA.m_buildingUnit.mFBXs[i] = caaeca6e35667f32ce3da8be21b2cc4b8[num];
			num++;
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			for (int j = 0; j < num2; j++)
			{
				avatarDNA.m_buildingUnit.mMats[j] = caaeca6e35667f32ce3da8be21b2cc4b8[num];
				num++;
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				return avatarDNA;
			}
		}
	}
}
