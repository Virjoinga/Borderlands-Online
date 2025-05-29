using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using A;
using UnityEngine;
using XsdSettings;

[Serializable]
public class WeaponStore
{
	public const string AssetPath = "Assets/Resources/WeaponEditor/Weapon.XML";

	public const string ResourcesAssetPath = "WeaponEditor/Bin/Weapon";

	[SerializeField]
	public List<WeaponAttribute> m_weaponDic = new List<WeaponAttribute>();

	private AttributeType[] m_attributePriority;

	private WeaponSubPart[] m_subpartPriority;

	private static WeaponStore s_weaponStore;

	public AttributeType[] AttributePriority
	{
		get
		{
			return m_attributePriority;
		}
	}

	public WeaponSubPart[] SubpartPriority
	{
		get
		{
			return m_subpartPriority;
		}
	}

	public static WeaponStore weaponStore
	{
		get
		{
			if (s_weaponStore == null)
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
				c599ef15da60b8dda61f4bda7adc851b3();
				s_weaponStore.c44f9e79fa85546625edd2986a4083fbf();
			}
			return s_weaponStore;
		}
		protected set
		{
			s_weaponStore = value;
		}
	}

	public WeaponStore()
	{
		AttributeType[] array = cb436ffcd486d98311073755445d226f2.c0a0cdf4a196914163f7334d9b0781a04(14);
		array[0] = AttributeType.AccuracyDecrease;
		array[1] = AttributeType.AmmoRegenerationRate;
		array[2] = AttributeType.ShotCost;
		array[3] = AttributeType.WeaponProjectilesPerShot;
		array[4] = AttributeType.ZoomEndFOV;
		array[5] = AttributeType.EquipTime;
		array[6] = AttributeType.CriticalHitScale;
		array[7] = AttributeType.WeaponDamage;
		array[8] = AttributeType.AccuracyMax;
		array[9] = AttributeType.FireRate;
		array[10] = AttributeType.ReloadTime;
		array[11] = AttributeType.ClipSize;
		array[12] = AttributeType.WeaponElementalDamage;
		array[13] = AttributeType.ElementalProcCoef;
		m_attributePriority = array;
		WeaponSubPart[] array2 = c4f65c6e9a88c4ce22f0245c63fed9d19.c0a0cdf4a196914163f7334d9b0781a04(8);
		array2[0] = WeaponSubPart.MATERIAL;
		array2[2] = WeaponSubPart.ACTION;
		array2[3] = WeaponSubPart.BODY;
		array2[4] = WeaponSubPart.BARREL;
		array2[5] = WeaponSubPart.MAG;
		array2[6] = WeaponSubPart.STOCK;
		array2[7] = WeaponSubPart.GRIP;
		m_subpartPriority = array2;
		base._002Ector();
	}

	public WeaponStore(bool ccb88cc9ce41c4f9df0c68fa9f9360ffc)
	{
		AttributeType[] array = cb436ffcd486d98311073755445d226f2.c0a0cdf4a196914163f7334d9b0781a04(14);
		array[0] = AttributeType.AccuracyDecrease;
		array[1] = AttributeType.AmmoRegenerationRate;
		array[2] = AttributeType.ShotCost;
		array[3] = AttributeType.WeaponProjectilesPerShot;
		array[4] = AttributeType.ZoomEndFOV;
		array[5] = AttributeType.EquipTime;
		array[6] = AttributeType.CriticalHitScale;
		array[7] = AttributeType.WeaponDamage;
		array[8] = AttributeType.AccuracyMax;
		array[9] = AttributeType.FireRate;
		array[10] = AttributeType.ReloadTime;
		array[11] = AttributeType.ClipSize;
		array[12] = AttributeType.WeaponElementalDamage;
		array[13] = AttributeType.ElementalProcCoef;
		m_attributePriority = array;
		WeaponSubPart[] array2 = c4f65c6e9a88c4ce22f0245c63fed9d19.c0a0cdf4a196914163f7334d9b0781a04(8);
		array2[0] = WeaponSubPart.MATERIAL;
		array2[2] = WeaponSubPart.ACTION;
		array2[3] = WeaponSubPart.BODY;
		array2[4] = WeaponSubPart.BARREL;
		array2[5] = WeaponSubPart.MAG;
		array2[6] = WeaponSubPart.STOCK;
		array2[7] = WeaponSubPart.GRIP;
		m_subpartPriority = array2;
		base._002Ector();
		if (!ccb88cc9ce41c4f9df0c68fa9f9360ffc)
		{
			return;
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_weaponDic.Clear();
			IEnumerator enumerator = Enum.GetValues(Type.GetTypeFromHandle(cb69030d5cbca58447fc871be9aade1a0.cc1720d05c75832f704b87474932341c3())).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					WeaponType c2b4f43f34e21572af6ab4414f04cee = (WeaponType)(int)enumerator.Current;
					m_weaponDic.Add(new WeaponAttribute(true, c2b4f43f34e21572af6ab4414f04cee));
				}
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable == null)
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							goto end_IL_0116;
						}
						continue;
						end_IL_0116:
						break;
					}
				}
				else
				{
					disposable.Dispose();
				}
			}
		}
	}

	public void c44f9e79fa85546625edd2986a4083fbf()
	{
		List<WeaponAttribute> list = new List<WeaponAttribute>();
		IEnumerator enumerator = Enum.GetValues(Type.GetTypeFromHandle(cb69030d5cbca58447fc871be9aade1a0.cc1720d05c75832f704b87474932341c3())).GetEnumerator();
		try
		{
			WeaponType weaponType;
			while (enumerator.MoveNext())
			{
				weaponType = (WeaponType)(int)enumerator.Current;
				int num = m_weaponDic.FindIndex((WeaponAttribute c8afd0d53d6687bf18e0654bc7cf43a65) => c8afd0d53d6687bf18e0654bc7cf43a65.m_weaponType == weaponType);
				if (num >= 0)
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
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					list.Add(m_weaponDic[num]);
				}
				else
				{
					list.Add(new WeaponAttribute(true, weaponType));
				}
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					goto end_IL_00a5;
				}
				continue;
				end_IL_00a5:
				break;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable == null)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						goto end_IL_00bd;
					}
					continue;
					end_IL_00bd:
					break;
				}
			}
			else
			{
				disposable.Dispose();
			}
		}
		m_weaponDic = list;
		using (List<WeaponAttribute>.Enumerator enumerator2 = m_weaponDic.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				WeaponAttribute current = enumerator2.Current;
				current.c7a3a9c22cd95b108e71a40ce2ee85008();
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
	}

	public static void c8247be8931d105f752fb9d8392ea62dc()
	{
		XmlSerializer xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(c062fd1b7d7315b9283a174e4056160be.cc1720d05c75832f704b87474932341c3()));
		TextWriter textWriter = new StreamWriter("Assets/Resources/WeaponEditor/Weapon.XML");
		try
		{
			xmlSerializer.Serialize(textWriter, s_weaponStore);
			textWriter.Close();
		}
		finally
		{
			if (textWriter != null)
			{
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
					((IDisposable)textWriter).Dispose();
					break;
				}
			}
		}
	}

	private static void c6171fdabcac1940c1e7ef3f68862086f()
	{
		XmlSerializer xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(c062fd1b7d7315b9283a174e4056160be.cc1720d05c75832f704b87474932341c3()));
		if (!File.Exists("Assets/Resources/WeaponEditor/Weapon.XML"))
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					s_weaponStore = new WeaponStore(true);
					c8247be8931d105f752fb9d8392ea62dc();
					return;
				}
			}
		}
		FileStream fileStream = File.OpenRead("Assets/Resources/WeaponEditor/Weapon.XML");
		try
		{
			s_weaponStore = (WeaponStore)xmlSerializer.Deserialize(fileStream);
			fileStream.Close();
		}
		finally
		{
			if (fileStream != null)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					((IDisposable)fileStream).Dispose();
					break;
				}
			}
		}
	}

	private static void c599ef15da60b8dda61f4bda7adc851b3()
	{
		TextAsset textAsset = ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("WeaponEditor/Bin/Weapon") as TextAsset;
		Stream stream = new MemoryStream(textAsset.bytes);
		BinaryReader binaryReader = new BinaryReader(stream);
		try
		{
			s_weaponStore = new WeaponStore(true);
			for (int i = 0; i <= 5; i++)
			{
				int count = s_weaponStore.m_weaponDic[i].m_weaponAttribute.Count;
				for (int j = 0; j < count; j++)
				{
					s_weaponStore.m_weaponDic[i].m_weaponAttribute[j].m_attributeType = (AttributeType)binaryReader.ReadByte();
					s_weaponStore.m_weaponDic[i].m_weaponAttribute[j].m_attributeValue.m_type = (AttributeValueType)binaryReader.ReadByte();
					s_weaponStore.m_weaponDic[i].m_weaponAttribute[j].m_attributeValue.m_affectType = (AffectType)binaryReader.ReadByte();
					if (!binaryReader.ReadBoolean())
					{
						continue;
					}
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
					s_weaponStore.m_weaponDic[i].m_weaponAttribute[j].m_attributeValue.cd1109b7ea29846a9735888dcb26a97fe(binaryReader.ReadSingle());
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						goto end_IL_0156;
					}
					continue;
					end_IL_0156:
					break;
				}
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				stream.Dispose();
				binaryReader.Close();
				break;
			}
		}
		finally
		{
			if (binaryReader != null)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					((IDisposable)binaryReader).Dispose();
					break;
				}
			}
		}
		Resources.UnloadAsset(textAsset);
	}

	public void cdd58bfa360277cc6ddc52e4331895d20()
	{
		PlayerInfoSync playerInfoSync = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56();
		if (!(playerInfoSync != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
		{
			return;
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			EntityWeapon c7088de59e49f7108f520cf7e0bae167e = ceaa467e9f01cebcf620c4729a7dcef3f.c7088de59e49f7108f520cf7e0bae167e;
			EntityPlayer entityPlayer = (EntityPlayer)playerInfoSync.c66b232dbebded7c7e9a89c1e8bd84689();
			c7088de59e49f7108f520cf7e0bae167e = entityPlayer.c3941dac8608f650ceb15dc36294a741c();
			c7088de59e49f7108f520cf7e0bae167e.c729ce3b5f48e0eac3a7ead97b1d02f8d().ce6ec0bf2246c7c29dcd48277bcd2f743();
			c7088de59e49f7108f520cf7e0bae167e.c729ce3b5f48e0eac3a7ead97b1d02f8d().c769c0065a21eb531d8917d0dd358768f();
			c7088de59e49f7108f520cf7e0bae167e.c8fb765ceb375501f00e7dc41af21c7ea(c7088de59e49f7108f520cf7e0bae167e.c729ce3b5f48e0eac3a7ead97b1d02f8d());
			c7088de59e49f7108f520cf7e0bae167e.c7449b87b4abb9e33cf179f366346aa7c();
			return;
		}
	}
}
