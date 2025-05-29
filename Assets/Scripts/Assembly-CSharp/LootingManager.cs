using System.Collections.Generic;
using A;
using XsdSettings;

public class LootingManager : c06ca0e618478c23eba3419653a19760f<LootingManager>, Arbitrator.ArbitratorClient
{
	private List<ILootListener> m_lootListeners = new List<ILootListener>();

	public ItemGeneratorService m_itemGeneratorService;

	public LootSetup m_lootSetup { get; private set; }

	public int[] m_lootingTypesIndexInSetup { get; private set; }

	public int[] m_lootDefaultQuantityPerItemType { get; private set; }

	public int[] m_lootDefaultQuantityPerAmmoType { get; private set; }

	public void cc7c09df5a4a467ee40cdda5047fd18d0(ILootListener c472a3b7c9dbd0d177f87c4386db7570d)
	{
		m_lootListeners.Add(c472a3b7c9dbd0d177f87c4386db7570d);
	}

	public void cd178f4fb7e34eae260792cefd4140db9(ILootListener c472a3b7c9dbd0d177f87c4386db7570d)
	{
		m_lootListeners.Remove(c472a3b7c9dbd0d177f87c4386db7570d);
	}

	public void OnArbitrated(Arbitrator.ArbitrableData data)
	{
	}

	public int cae816a5b35dd33a6b1dfb5d0f344978e(ItemType c6ca7698352db776b80b27b30e89ff904, AmmoType c1e73ae4c18ab95639cb0c7604f21dc2b = AmmoType.SMG)
	{
		if (c6ca7698352db776b80b27b30e89ff904 == ItemType.Ammo)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return m_lootDefaultQuantityPerAmmoType[(int)c1e73ae4c18ab95639cb0c7604f21dc2b];
				}
			}
		}
		return m_lootDefaultQuantityPerItemType[(int)c6ca7698352db776b80b27b30e89ff904];
	}
}
