using System.Collections;
using A;
using Core;
using XsdSettings;

public class ItemDNA
{
	private WeaponDNA m_weapon;

	public static int m_extraEffectNums = 8;

	public int m_itemId { get; set; }

	public ItemType m_type { get; private set; }

	public AmmoType m_ammoType { get; private set; }

	public MaterialType m_materialType { get; private set; }

	public ShieldDNA m_shiled { get; private set; }

	public ClassModeDNA m_classMode { get; private set; }

	public int m_value { get; set; }

	public int m_price { get; private set; }

	public ItemRarity cdb37a58b3efd54adcd5545eac569695f
	{
		get
		{
			switch (m_type)
			{
			case ItemType.Material:
				return ItemRarity.Common;
			case ItemType.Weapon:
				return (ItemRarity)m_weapon.m_rarity;
			case ItemType.Shield:
				return m_shiled.m_rarity;
			case ItemType.ClassMode:
				return m_classMode.m_rarity;
			default:
				return ItemRarity.Common;
			}
		}
	}

	private ItemDNA()
	{
		m_itemId = -1;
		m_type = ItemType.TOTAL;
		m_weapon = cc607e9943fa3c5044ada833720c23c9a.c7088de59e49f7108f520cf7e0bae167e;
		m_value = 0;
		m_shiled = c26b1d577ac9c0da502ba2980efb9fbde.c7088de59e49f7108f520cf7e0bae167e;
		m_classMode = c6fa4f42bf72c2dd1857080a6c791c70f.c7088de59e49f7108f520cf7e0bae167e;
	}

	public int c7513e66c4e0fc55e6fea9dd9cb8b9943()
	{
		switch (m_type)
		{
		default:
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
				return 1;
			}
		case ItemType.Weapon:
			return m_weapon.m_level;
		case ItemType.Shield:
			return m_shiled.m_level;
		case ItemType.ClassMode:
			return m_classMode.m_level;
		}
	}

	public void c61424d9a3f10a4d9e905c46e13e1d512(int c8a9af37d3ec00a4fe8efce068d4cd684)
	{
		m_price = c8a9af37d3ec00a4fe8efce068d4cd684;
	}

	public static ItemDNA cc17851d48b488126d6f73578b5780377(int cefda2fdc3ce4e04f38bab77fc7998241)
	{
		ItemDNA itemDNA = new ItemDNA();
		itemDNA.m_type = ItemType.HealthPack;
		itemDNA.m_value = cefda2fdc3ce4e04f38bab77fc7998241;
		return itemDNA;
	}

	public static ItemDNA c2360cbbc495138755199b7da0e6f9841(int cefda2fdc3ce4e04f38bab77fc7998241)
	{
		ItemDNA itemDNA = new ItemDNA();
		itemDNA.m_type = ItemType.AmmoPack;
		itemDNA.m_value = cefda2fdc3ce4e04f38bab77fc7998241;
		return itemDNA;
	}

	public static ItemDNA c8284b9f225995cc6a6e1888c9c037b06(WeaponDNA c39409683a32e09391d094314ffeae2b5)
	{
		ItemDNA itemDNA = new ItemDNA();
		itemDNA.m_type = ItemType.Weapon;
		itemDNA.m_weapon = c39409683a32e09391d094314ffeae2b5;
		itemDNA.m_itemId = c39409683a32e09391d094314ffeae2b5.m_id;
		return itemDNA;
	}

	public static ItemDNA c172f9d0eb2874d9d30bb9354caf9aab4(MaterialType c424fafa6354141c1e81d53efca575d8d, int cefda2fdc3ce4e04f38bab77fc7998241)
	{
		ItemDNA itemDNA = new ItemDNA();
		itemDNA.m_type = ItemType.Material;
		itemDNA.m_materialType = c424fafa6354141c1e81d53efca575d8d;
		itemDNA.m_value = cefda2fdc3ce4e04f38bab77fc7998241;
		return itemDNA;
	}

	public static ItemDNA cda992a74324f68bb483f862f7544f742(int cefda2fdc3ce4e04f38bab77fc7998241, AmmoType c2b4f43f34e21572af6ab4414f04cee36)
	{
		ItemDNA itemDNA = new ItemDNA();
		itemDNA.m_type = ItemType.Ammo;
		itemDNA.m_ammoType = c2b4f43f34e21572af6ab4414f04cee36;
		itemDNA.m_value = cefda2fdc3ce4e04f38bab77fc7998241;
		return itemDNA;
	}

	public static ItemDNA cf3cf5ff68c6b242036334f6d3f834e32(int cefda2fdc3ce4e04f38bab77fc7998241)
	{
		ItemDNA itemDNA = new ItemDNA();
		itemDNA.m_type = ItemType.Money;
		itemDNA.m_value = cefda2fdc3ce4e04f38bab77fc7998241;
		return itemDNA;
	}

	public static ItemDNA c8f331a9c3beba42f2ccd0923c0c67e0a()
	{
		ItemDNA itemDNA = new ItemDNA();
		itemDNA.m_type = ItemType.Shield;
		return itemDNA;
	}

	public static ItemDNA c8f331a9c3beba42f2ccd0923c0c67e0a(ShieldDNA c6e05265144de15ae76ef2beadf5b2390)
	{
		ItemDNA itemDNA = new ItemDNA();
		itemDNA.m_type = ItemType.Shield;
		itemDNA.m_shiled = c6e05265144de15ae76ef2beadf5b2390;
		itemDNA.m_itemId = c6e05265144de15ae76ef2beadf5b2390.m_id;
		return itemDNA;
	}

	public static ItemDNA c7a1e006dac3107ddc09019d735839e9a(ClassModeDNA c498ff81f8ab3e0654c2a1ef994384fb9)
	{
		ItemDNA itemDNA = new ItemDNA();
		itemDNA.m_type = ItemType.ClassMode;
		itemDNA.m_classMode = c498ff81f8ab3e0654c2a1ef994384fb9;
		itemDNA.m_itemId = c498ff81f8ab3e0654c2a1ef994384fb9.m_id;
		return itemDNA;
	}

	public bool ca8e8ecb1231bf8cf32c06da446a48681(ItemType c2b4f43f34e21572af6ab4414f04cee36)
	{
		return m_type == c2b4f43f34e21572af6ab4414f04cee36;
	}

	public bool ced1a24617421c162b3c986ffdc1eb4d3()
	{
		bool result = false;
		if (m_type == ItemType.Weapon)
		{
			while (true)
			{
				int result2;
				switch (4)
				{
				case 0:
					break;
				default:
					{
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						if (cdb37a58b3efd54adcd5545eac569695f != ItemRarity.VeryRare)
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
							if (cdb37a58b3efd54adcd5545eac569695f != ItemRarity.Epic)
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
								result2 = ((cdb37a58b3efd54adcd5545eac569695f == ItemRarity.MetaEpic) ? 1 : 0);
								goto IL_0058;
							}
						}
						result2 = 1;
						goto IL_0058;
					}
					IL_0058:
					return (byte)result2 != 0;
				}
			}
		}
		if (m_type == ItemType.Material)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return m_materialType == MaterialType.MT_Purple_Crystal;
				}
			}
		}
		return result;
	}

	public bool ce30d65b28e5e27287812b940c39aacf7(int cb9aa9404220b2b81c6745ac8d6bdabc6)
	{
		switch (m_type)
		{
		default:
			while (true)
			{
				switch (5)
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
		case ItemType.Weapon:
		{
			WeaponDNA weaponDNA = ca79da172938fdc8c067fb64242b6174a();
			if (weaponDNA != null)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						return cb9aa9404220b2b81c6745ac8d6bdabc6 >= weaponDNA.m_level;
					}
				}
			}
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Gamelogic, "it should be a type of weapon, but it's dna is null");
			break;
		}
		case ItemType.Shield:
		{
			ShieldDNA shieldDNA = c8e074b9d0135ff808166cc324407f74c();
			if (shieldDNA != null)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						return cb9aa9404220b2b81c6745ac8d6bdabc6 >= shieldDNA.m_level;
					}
				}
			}
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Gamelogic, "it should be a type of Shield, but it's dna is null");
			break;
		}
		case ItemType.ClassMode:
		{
			ClassModeDNA classModeDNA = c253c28f3a59bc5e5a528dfbb463a8a45();
			if (classModeDNA != null)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						return cb9aa9404220b2b81c6745ac8d6bdabc6 >= classModeDNA.m_level;
					}
				}
			}
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Gamelogic, "it should be a type of ClassMode, but it's dna is null");
			break;
		}
		}
		return false;
	}

	public WeaponDNA ca79da172938fdc8c067fb64242b6174a()
	{
		return m_weapon;
	}

	public ShieldDNA c8e074b9d0135ff808166cc324407f74c()
	{
		return m_shiled;
	}

	public ClassModeDNA c253c28f3a59bc5e5a528dfbb463a8a45()
	{
		return m_classMode;
	}

	public override string ToString()
	{
		if (m_type == ItemType.Weapon)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return m_type.ToString() + m_weapon.ToString();
				}
			}
		}
		if (m_type == ItemType.Ammo)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return m_type.ToString() + m_ammoType.ToString() + m_value;
				}
			}
		}
		return m_type.ToString() + m_value;
	}

	public override bool Equals(object obj)
	{
		ItemDNA itemDNA = obj as ItemDNA;
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (m_type == itemDNA.m_type)
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
				if (m_type == ItemType.Weapon)
				{
					while (true)
					{
						switch (4)
						{
						case 0:
							continue;
						}
						return m_weapon.Equals(itemDNA.m_weapon);
					}
				}
				if (m_type != ItemType.Ammo)
				{
					return m_value == itemDNA.m_value;
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				if (m_ammoType == itemDNA.m_ammoType)
				{
					while (true)
					{
						switch (2)
						{
						case 0:
							break;
						default:
							return m_value == itemDNA.m_value;
						}
					}
				}
			}
		}
		return false;
	}

	public override int GetHashCode()
	{
		if (m_type == ItemType.Weapon)
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
					return m_weapon.GetHashCode();
				}
			}
		}
		if (m_type == ItemType.Shield)
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
			if (m_shiled != null)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						return m_shiled.GetHashCode();
					}
				}
			}
		}
		if (m_type == ItemType.ClassMode)
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
			if (m_classMode != null)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						return m_classMode.GetHashCode();
					}
				}
			}
		}
		return m_value.GetHashCode();
	}

	public static ItemDNA cc95f1fbaa3f9e0533900d0e3a5e0bfa2(Hashtable ca57e1c076c01141c5ce58c7341db7833)
	{
		ItemType itemType = (ItemType)(int)ca57e1c076c01141c5ce58c7341db7833[0];
		ItemDNA c7088de59e49f7108f520cf7e0bae167e = c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e;
		switch (itemType)
		{
		case ItemType.Weapon:
		{
			WeaponDNA c39409683a32e09391d094314ffeae2b = WeaponDNA.cc95f1fbaa3f9e0533900d0e3a5e0bfa2(ca57e1c076c01141c5ce58c7341db7833);
			c7088de59e49f7108f520cf7e0bae167e = c8284b9f225995cc6a6e1888c9c037b06(c39409683a32e09391d094314ffeae2b);
			c649d3133e0e04e1a755cff7a639aec59(ref c7088de59e49f7108f520cf7e0bae167e, ca57e1c076c01141c5ce58c7341db7833, 19);
			break;
		}
		case ItemType.Material:
			c7088de59e49f7108f520cf7e0bae167e = c172f9d0eb2874d9d30bb9354caf9aab4((MaterialType)(int)ca57e1c076c01141c5ce58c7341db7833[6], (int)ca57e1c076c01141c5ce58c7341db7833[7]);
			break;
		case ItemType.Shield:
		{
			ShieldDNA c6e05265144de15ae76ef2beadf5b = ShieldDNA.cc95f1fbaa3f9e0533900d0e3a5e0bfa2(ca57e1c076c01141c5ce58c7341db7833);
			c7088de59e49f7108f520cf7e0bae167e = c8f331a9c3beba42f2ccd0923c0c67e0a(c6e05265144de15ae76ef2beadf5b);
			c649d3133e0e04e1a755cff7a639aec59(ref c7088de59e49f7108f520cf7e0bae167e, ca57e1c076c01141c5ce58c7341db7833, 14);
			break;
		}
		case ItemType.ClassMode:
		{
			ClassModeDNA c498ff81f8ab3e0654c2a1ef994384fb = ClassModeDNA.cc95f1fbaa3f9e0533900d0e3a5e0bfa2(ca57e1c076c01141c5ce58c7341db7833);
			c7088de59e49f7108f520cf7e0bae167e = c7a1e006dac3107ddc09019d735839e9a(c498ff81f8ab3e0654c2a1ef994384fb);
			break;
		}
		case ItemType.Money:
		{
			int cefda2fdc3ce4e04f38bab77fc = (int)ca57e1c076c01141c5ce58c7341db7833[6];
			c7088de59e49f7108f520cf7e0bae167e = cf3cf5ff68c6b242036334f6d3f834e32(cefda2fdc3ce4e04f38bab77fc);
			break;
		}
		default:
			return null;
		}
		c7088de59e49f7108f520cf7e0bae167e.m_price = (int)ca57e1c076c01141c5ce58c7341db7833[5];
		return c7088de59e49f7108f520cf7e0bae167e;
	}

	public Hashtable c2785337dcd6da152ea623eabc85b6d49()
	{
		switch (m_type)
		{
		case ItemType.Weapon:
		{
			Hashtable hashtable = new Hashtable();
			hashtable.Add(0, (int)m_type);
			hashtable.Add(1, m_weapon.m_level);
			hashtable.Add(2, (int)m_weapon.m_rarity);
			hashtable.Add(3, (int)m_weapon.m_generationSource);
			hashtable.Add(4, m_weapon.m_id);
			hashtable.Add(5, m_weapon.m_name);
			hashtable.Add(6, (int)m_weapon.m_type);
			Hashtable c28cf3d24e3067ef54895f824fad7fcef2 = hashtable;
			int count = c28cf3d24e3067ef54895f824fad7fcef2.Count;
			int[] subPartsCode = m_weapon.m_subPartsCode;
			foreach (int cc584cc0d388b61d19d26e1dcdd9be in subPartsCode)
			{
				SubPartWpn subPartWpn = SubPartStore.c2468dbf91d056d864da750fa5576bbef.cdbf696aded5fd1b462c05fbd81522f65(cc584cc0d388b61d19d26e1dcdd9be);
				if (subPartWpn != null)
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
					c28cf3d24e3067ef54895f824fad7fcef2[count++] = subPartWpn.m_Index;
				}
				else
				{
					c28cf3d24e3067ef54895f824fad7fcef2[count++] = -1;
				}
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				c28cf3d24e3067ef54895f824fad7fcef2[count++] = m_weapon.m_starLevel;
				c28cf3d24e3067ef54895f824fad7fcef2[count++] = m_weapon.m_starExperience;
				c6a20998ba65988cd960b72bdcdd3d3ab(ref c28cf3d24e3067ef54895f824fad7fcef2);
				return c28cf3d24e3067ef54895f824fad7fcef2;
			}
		}
		case ItemType.Material:
		{
			Hashtable hashtable = new Hashtable();
			hashtable.Add(0, (int)m_type);
			hashtable.Add(1, 1);
			hashtable.Add(2, 0);
			hashtable.Add(3, 0);
			hashtable.Add(4, 0);
			hashtable.Add(5, m_materialType);
			hashtable.Add(6, m_value);
			return hashtable;
		}
		case ItemType.Shield:
		{
			Hashtable hashtable = new Hashtable();
			hashtable.Add(0, (int)m_type);
			hashtable.Add(1, m_shiled.m_level);
			hashtable.Add(2, (int)m_shiled.m_rarity);
			hashtable.Add(3, (int)m_shiled.m_generationSource);
			hashtable.Add(4, m_shiled.m_id);
			hashtable.Add(5, m_shiled.m_name);
			hashtable.Add(6, 0);
			hashtable.Add(7, (int)m_shiled.m_shieldManufacturer);
			hashtable.Add(8, m_shiled.m_bodyIdx);
			hashtable.Add(9, m_shiled.m_batteryIdx);
			hashtable.Add(10, m_shiled.m_capacitorIdx);
			hashtable.Add(11, m_shiled.m_accessoryIdx);
			hashtable.Add(12, m_shiled.m_materialIdx);
			Hashtable c28cf3d24e3067ef54895f824fad7fcef = hashtable;
			c6a20998ba65988cd960b72bdcdd3d3ab(ref c28cf3d24e3067ef54895f824fad7fcef);
			return c28cf3d24e3067ef54895f824fad7fcef;
		}
		case ItemType.ClassMode:
		{
			Hashtable hashtable = new Hashtable();
			hashtable.Add(0, (int)m_type);
			hashtable.Add(1, m_classMode.m_level);
			hashtable.Add(2, (int)m_classMode.m_rarity);
			hashtable.Add(3, (int)m_classMode.m_generationSource);
			hashtable.Add(4, m_classMode.m_id);
			hashtable.Add(5, m_classMode.m_name);
			hashtable.Add(6, (int)m_classMode.m_cmType);
			hashtable.Add(7, m_classMode.m_adapterIdx);
			hashtable.Add(8, m_classMode.m_bodyIdx);
			hashtable.Add(9, m_classMode.m_chassisIdx);
			hashtable.Add(10, m_classMode.m_drumIdx);
			hashtable.Add(11, m_classMode.m_materialIdx);
			return hashtable;
		}
		default:
			return null;
		}
	}

	private void c6a20998ba65988cd960b72bdcdd3d3ab(ref Hashtable c28cf3d24e3067ef54895f824fad7fcef)
	{
		int count = c28cf3d24e3067ef54895f824fad7fcef.Count;
		if (ca8e8ecb1231bf8cf32c06da446a48681(ItemType.Weapon))
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					WeaponDNA weaponDNA = ca79da172938fdc8c067fb64242b6174a();
					if (weaponDNA != null)
					{
						while (true)
						{
							switch (7)
							{
							case 0:
								break;
							default:
							{
								c28cf3d24e3067ef54895f824fad7fcef[count++] = weaponDNA.m_extraEffectCount;
								for (int i = 0; i < weaponDNA.m_extraEffectCount; i++)
								{
									c28cf3d24e3067ef54895f824fad7fcef[count++] = weaponDNA.m_extraEffect[i];
									c28cf3d24e3067ef54895f824fad7fcef[count++] = weaponDNA.m_extraEffectIndex[i];
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
						}
					}
					return;
				}
				}
			}
		}
		c28cf3d24e3067ef54895f824fad7fcef[count++] = 0;
	}

	private static void c649d3133e0e04e1a755cff7a639aec59(ref ItemDNA ca57e1c076c01141c5ce58c7341db7833, Hashtable c28cf3d24e3067ef54895f824fad7fcef, int c7449b521d72ce29986987c9180f2668c)
	{
		int num = c7449b521d72ce29986987c9180f2668c;
		if (!ca57e1c076c01141c5ce58c7341db7833.ca8e8ecb1231bf8cf32c06da446a48681(ItemType.Weapon))
		{
			return;
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
			WeaponDNA weaponDNA = ca57e1c076c01141c5ce58c7341db7833.ca79da172938fdc8c067fb64242b6174a();
			if (weaponDNA == null)
			{
				return;
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				weaponDNA.m_extraEffectCount = (int)c28cf3d24e3067ef54895f824fad7fcef[num++];
				for (int i = 0; i < ca57e1c076c01141c5ce58c7341db7833.ca79da172938fdc8c067fb64242b6174a().m_extraEffectCount; i++)
				{
					weaponDNA.m_extraEffect[i] = (int)c28cf3d24e3067ef54895f824fad7fcef[num++];
					weaponDNA.m_extraEffectIndex[i] = (int)c28cf3d24e3067ef54895f824fad7fcef[num++];
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
		}
	}
}
