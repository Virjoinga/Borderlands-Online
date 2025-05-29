using System.Collections.Generic;
using A;
using Core;
using UnityEngine;
using XsdSettings;

public class LootingTable : MonoBehaviour
{
	public ELootingType m_lootingType;

	public ELootingSubType m_lootingSubType;

	public int m_levelOverride;

	public Vector3 m_lootDropOffset;

	public Vector3 m_lootDropVelocity;

	public Vector3 m_lootScatterOffset;

	public bool m_circularScatter;

	public bool m_attach;

	private TreasureBoxTrigger m_treasureBoxTrigger;

	private List<GameObject[]> m_weaponSlots;

	private List<GameObject[]> m_itemSlots;

	public void Start()
	{
		m_treasureBoxTrigger = base.gameObject.GetComponent<TreasureBoxTrigger>();
		if (!m_attach)
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
			if (!(m_treasureBoxTrigger != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
			{
				return;
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				m_weaponSlots = new List<GameObject[]>(0);
				m_itemSlots = new List<GameObject[]>(0);
				LootingSlot[] componentsInChildren = base.gameObject.GetComponentsInChildren<LootingSlot>();
				foreach (LootingSlot lootingSlot in componentsInChildren)
				{
					if (lootingSlot.m_slotType == LootingSlot.LootingSlotType.Item)
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
						cca2e4205d74b7e5579b50ea75e194c35(lootingSlot.gameObject, m_itemSlots, lootingSlot.m_lootNumber, lootingSlot.m_lootIndex - 1);
						continue;
					}
					if (lootingSlot.m_slotType != LootingSlot.LootingSlotType.Weapon)
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
					cca2e4205d74b7e5579b50ea75e194c35(lootingSlot.gameObject, m_weaponSlots, lootingSlot.m_lootNumber, lootingSlot.m_lootIndex - 1);
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

	private void cca2e4205d74b7e5579b50ea75e194c35(GameObject c793014f9fd028450a4a9908376309f26, List<GameObject[]> c4a7b074b42519552d59237ff440adb95, int cfcd7b1b75b0aae42bca51fc3962059ff, int cef32151497ea65cec82db75a87780ed9)
	{
		if (cfcd7b1b75b0aae42bca51fc3962059ff <= 0)
		{
			return;
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			for (int i = c4a7b074b42519552d59237ff440adb95.Count; i < cfcd7b1b75b0aae42bca51fc3962059ff; i++)
			{
				c4a7b074b42519552d59237ff440adb95.Add(null);
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				if (c4a7b074b42519552d59237ff440adb95[cfcd7b1b75b0aae42bca51fc3962059ff - 1] == null)
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
					c4a7b074b42519552d59237ff440adb95[cfcd7b1b75b0aae42bca51fc3962059ff - 1] = cc918c40632f876558345d2b35eb025ba.c0a0cdf4a196914163f7334d9b0781a04(cfcd7b1b75b0aae42bca51fc3962059ff);
				}
				c4a7b074b42519552d59237ff440adb95[cfcd7b1b75b0aae42bca51fc3962059ff - 1][cef32151497ea65cec82db75a87780ed9] = c793014f9fd028450a4a9908376309f26;
				return;
			}
		}
	}

	public GameObject cf0a77cf8ccad134ddd84c16ff1bad050(ItemType c6ca7698352db776b80b27b30e89ff904, int c8b63fe250930737af424a9b28a4dd42b, int c9be873f8d8760501b6f9c6210206b03b)
	{
		GameObject[] c7088de59e49f7108f520cf7e0bae167e = c539980965ebdce22987924c82ba90cca.c7088de59e49f7108f520cf7e0bae167e;
		if (c6ca7698352db776b80b27b30e89ff904 == ItemType.Weapon)
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
			c7088de59e49f7108f520cf7e0bae167e = c57f7b36cba0e323c7b94616ae084cd62(m_weaponSlots, c8b63fe250930737af424a9b28a4dd42b);
		}
		else
		{
			c7088de59e49f7108f520cf7e0bae167e = c57f7b36cba0e323c7b94616ae084cd62(m_itemSlots, c9be873f8d8760501b6f9c6210206b03b);
		}
		if (c7088de59e49f7108f520cf7e0bae167e != null)
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
			for (int i = 0; i < c7088de59e49f7108f520cf7e0bae167e.Length; i++)
			{
				if (c7088de59e49f7108f520cf7e0bae167e[i].transform.childCount != 0)
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
					return c7088de59e49f7108f520cf7e0bae167e[i];
				}
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
		}
		return null;
	}

	private GameObject[] c57f7b36cba0e323c7b94616ae084cd62(List<GameObject[]> c798fd1a8dd83636461fddafe09ce9b3d, int c9c34cd09f87c9b799424dbfc798b4454)
	{
		GameObject[] array = c539980965ebdce22987924c82ba90cca.c7088de59e49f7108f520cf7e0bae167e;
		if (c798fd1a8dd83636461fddafe09ce9b3d != null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			for (int i = c9c34cd09f87c9b799424dbfc798b4454 - 1; i < c798fd1a8dd83636461fddafe09ce9b3d.Count; i++)
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
				if (array == null)
				{
					if (c798fd1a8dd83636461fddafe09ce9b3d[i] == null)
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
					array = c798fd1a8dd83636461fddafe09ce9b3d[i];
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
			if (array == null)
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
				object[] array2 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
				array2[0] = "Loot: No suitable slots found to attach ";
				array2[1] = c9c34cd09f87c9b799424dbfc798b4454;
				array2[2] = " weapons/items on ";
				array2[3] = base.gameObject.name;
				DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Gamelogic, string.Concat(array2));
			}
		}
		return array;
	}
}
