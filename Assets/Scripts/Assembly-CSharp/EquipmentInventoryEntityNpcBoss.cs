using System.Collections;
using A;
using Core;
using UnityEngine;

public class EquipmentInventoryEntityNpcBoss : EquipmentInventoryEntityNpc
{
	private enum PouchType
	{
		LIFE = 0,
		ARMORLEFT = 1,
		ARMORRIGHT = 2,
		ARMORBACK = 3,
		ARMORFRONT = 4
	}

	[SerializeField]
	private int m_armorPointLeft = 100;

	[SerializeField]
	private int m_armorPointRight = 100;

	[SerializeField]
	private int m_armorPointBack = 100;

	[SerializeField]
	private int m_armorPointFront;

	protected byte m_curphase = 1;

	protected byte[] m_phaseMax = ce2f159fe707a376b497f666c368f15ed.c0a0cdf4a196914163f7334d9b0781a04(3);

	protected byte[] m_phaseMin = ce2f159fe707a376b497f666c368f15ed.c0a0cdf4a196914163f7334d9b0781a04(3);

	private NPCAnimationManagerFSM m_animationManager;

	public NPCAnimationManagerFSM cb8119a2676bfbd4df00a9ed683eed91a()
	{
		if (m_animationManager == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_animationManager = GetComponent<NPCAnimationManagerFSM>();
		}
		return m_animationManager;
	}

	public override void Start()
	{
		base.Start();
		m_curphase = 1;
	}

	public void cf29d92cf53090f29251f502d8ab0cc05(byte c38fb539d48cc0d19c433f3f34884cef6, byte c3fc3b9578e713766a9eb77f07e308e2f)
	{
		m_curphase = c38fb539d48cc0d19c433f3f34884cef6;
		m_phaseMin[m_curphase - 1] = c3fc3b9578e713766a9eb77f07e308e2f;
		if (m_curphase == 1)
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
					m_phaseMax[0] = 100;
					return;
				}
			}
		}
		if (m_curphase <= 1)
		{
			return;
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				continue;
			}
			if (m_curphase > 3)
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
				m_phaseMax[m_curphase - 1] = m_phaseMin[m_curphase - 2];
				return;
			}
		}
	}

	public byte cd183a5dbb084bdf2992464c044efe530()
	{
		return m_curphase;
	}

	public byte c6681f45fcaa97031091f74fc718c5127()
	{
		return m_phaseMin[m_curphase - 1];
	}

	public byte c69c1bed154b761bdb32ed7f4099fd87f()
	{
		return m_phaseMax[m_curphase - 1];
	}

	public override void cd93285db16841148ed53a5bbeb35cf20(byte cd6bb591c33b2ee3ab93e98aa43a6da63, int cb75bb7e4635f59359605d47e3ee3541b)
	{
		c06ade3733c4658b091be622d9d3b4034();
	}

	private void Awake()
	{
		m_pouchList.Clear();
		m_pouchList.Add(new Utils.PouchNetwork());
		m_pouchList.Add(new Utils.PouchNetwork());
		m_pouchList.Add(new Utils.PouchNetwork());
		m_pouchList.Add(new Utils.PouchNetwork());
		m_pouchList.Add(new Utils.PouchNetwork());
	}

	public override int ccfad1bf47b003333c5ddd084f14d33e7(WeakPoint c38b98045365f4b50a4fbe3f1d89af089)
	{
		if (c38b98045365f4b50a4fbe3f1d89af089 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return base.c0e018ed0ee4ac2592fafd36d256cd617(c38b98045365f4b50a4fbe3f1d89af089);
				}
			}
		}
		if (c38b98045365f4b50a4fbe3f1d89af089.m_damagePropagationType != WeakPoint.DamagePropagationType.ApplyToSelf)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return base.c0e018ed0ee4ac2592fafd36d256cd617(c38b98045365f4b50a4fbe3f1d89af089);
				}
			}
		}
		if (c38b98045365f4b50a4fbe3f1d89af089.m_partInfo == WeakPoint.PartInfo.Armor_Back)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					return m_pouchList[3].c17a506784adea8f822bee98ad9dba710();
				}
			}
		}
		if (c38b98045365f4b50a4fbe3f1d89af089.m_partInfo == WeakPoint.PartInfo.Armor_Front)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return m_pouchList[4].c17a506784adea8f822bee98ad9dba710();
				}
			}
		}
		if (c38b98045365f4b50a4fbe3f1d89af089.m_partInfo == WeakPoint.PartInfo.Armor_Left)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return m_pouchList[1].c17a506784adea8f822bee98ad9dba710();
				}
			}
		}
		if (c38b98045365f4b50a4fbe3f1d89af089.m_partInfo == WeakPoint.PartInfo.Armor_Right)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					return m_pouchList[2].c17a506784adea8f822bee98ad9dba710();
				}
			}
		}
		return base.c0e018ed0ee4ac2592fafd36d256cd617(c38b98045365f4b50a4fbe3f1d89af089);
	}

	public override int c0e018ed0ee4ac2592fafd36d256cd617(WeakPoint c38b98045365f4b50a4fbe3f1d89af089)
	{
		if (c38b98045365f4b50a4fbe3f1d89af089 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return base.c0e018ed0ee4ac2592fafd36d256cd617(c38b98045365f4b50a4fbe3f1d89af089);
				}
			}
		}
		if (c38b98045365f4b50a4fbe3f1d89af089.m_damagePropagationType != WeakPoint.DamagePropagationType.ApplyToSelf)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					return base.c0e018ed0ee4ac2592fafd36d256cd617(c38b98045365f4b50a4fbe3f1d89af089);
				}
			}
		}
		if (c38b98045365f4b50a4fbe3f1d89af089.m_partInfo == WeakPoint.PartInfo.Armor_Back)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					return m_pouchList[3].c4c4b463091d2b6acfdded4fa12b32f25();
				}
			}
		}
		if (c38b98045365f4b50a4fbe3f1d89af089.m_partInfo == WeakPoint.PartInfo.Armor_Front)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return m_pouchList[4].c4c4b463091d2b6acfdded4fa12b32f25();
				}
			}
		}
		if (c38b98045365f4b50a4fbe3f1d89af089.m_partInfo == WeakPoint.PartInfo.Armor_Left)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					return m_pouchList[1].c4c4b463091d2b6acfdded4fa12b32f25();
				}
			}
		}
		if (c38b98045365f4b50a4fbe3f1d89af089.m_partInfo == WeakPoint.PartInfo.Armor_Right)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					return m_pouchList[2].c4c4b463091d2b6acfdded4fa12b32f25();
				}
			}
		}
		return base.c0e018ed0ee4ac2592fafd36d256cd617(c38b98045365f4b50a4fbe3f1d89af089);
	}

	private void c96c73a076a0ebc16cdc7574ba66271f8(WeakPoint c38b98045365f4b50a4fbe3f1d89af089)
	{
		cb8119a2676bfbd4df00a9ed683eed91a().c2fee075e4a1b0f8c507d7c8a821f5719(c38b98045365f4b50a4fbe3f1d89af089.m_partInfo);
		c38b98045365f4b50a4fbe3f1d89af089.gameObject.SetActive(false);
	}

	public override void c15ecef7ebaa3979b9ad1ce64ac8a6c25(WeakPoint c38b98045365f4b50a4fbe3f1d89af089, int c19e024b5bcbd347892bec27154c527de)
	{
		switch (c38b98045365f4b50a4fbe3f1d89af089.m_partInfo)
		{
		case WeakPoint.PartInfo.Armor_Back:
			m_pouchList[3].ca0f7f52805a9c67a892c5b479a17c3aa(c19e024b5bcbd347892bec27154c527de);
			break;
		case WeakPoint.PartInfo.Armor_Front:
			m_pouchList[4].ca0f7f52805a9c67a892c5b479a17c3aa(c19e024b5bcbd347892bec27154c527de);
			break;
		case WeakPoint.PartInfo.Armor_Left:
			m_pouchList[1].ca0f7f52805a9c67a892c5b479a17c3aa(c19e024b5bcbd347892bec27154c527de);
			break;
		case WeakPoint.PartInfo.Armor_Right:
			m_pouchList[2].ca0f7f52805a9c67a892c5b479a17c3aa(c19e024b5bcbd347892bec27154c527de);
			break;
		default:
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, "Unkown WeakPoint PartInfo!");
			break;
		}
		if (c19e024b5bcbd347892bec27154c527de <= 0)
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
			c96c73a076a0ebc16cdc7574ba66271f8(c38b98045365f4b50a4fbe3f1d89af089);
		}
		base.c15ecef7ebaa3979b9ad1ce64ac8a6c25(c38b98045365f4b50a4fbe3f1d89af089, c19e024b5bcbd347892bec27154c527de);
	}

	public override void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		base.OnPhotonSerializeView(stream, info);
		if (stream.c8b2526be2638bb30a29ab8314b369311)
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
					stream.caf7283cc5cd9725a88a9cdfa630d92f8(m_curphase);
					stream.caf7283cc5cd9725a88a9cdfa630d92f8(m_phaseMin[m_curphase - 1]);
					stream.caf7283cc5cd9725a88a9cdfa630d92f8(m_phaseMax[m_curphase - 1]);
					return;
				}
			}
		}
		m_curphase = (byte)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
		m_phaseMin[m_curphase - 1] = (byte)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
		m_phaseMax[m_curphase - 1] = (byte)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
	}

	public override Hashtable c07eadde5914bc707bfda0013beb8972c()
	{
		Hashtable hashtable = new Hashtable();
		int num = 0;
		hashtable[num++] = m_pouchList[3].c17a506784adea8f822bee98ad9dba710();
		hashtable[num++] = m_pouchList[3].c4c4b463091d2b6acfdded4fa12b32f25();
		hashtable[num++] = m_pouchList[4].c17a506784adea8f822bee98ad9dba710();
		hashtable[num++] = m_pouchList[4].c4c4b463091d2b6acfdded4fa12b32f25();
		hashtable[num++] = m_pouchList[1].c17a506784adea8f822bee98ad9dba710();
		hashtable[num++] = m_pouchList[1].c4c4b463091d2b6acfdded4fa12b32f25();
		hashtable[num++] = m_pouchList[2].c17a506784adea8f822bee98ad9dba710();
		hashtable[num++] = m_pouchList[2].c4c4b463091d2b6acfdded4fa12b32f25();
		hashtable[num++] = ccfad1bf47b003333c5ddd084f14d33e7();
		hashtable[num++] = ca2ff7a501878363cb1d5f0472e306620();
		hashtable[num++] = ca937003ba4cbf4130cad1fcc9da2873e();
		hashtable[num++] = ce7804365a7377021025c46a16aa79db4();
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(9);
		array[0] = "Boss.SerializeLifeAndShield life[";
		array[1] = ca2ff7a501878363cb1d5f0472e306620();
		array[2] = "/";
		array[3] = ccfad1bf47b003333c5ddd084f14d33e7();
		array[4] = "] - shield[";
		array[5] = ce7804365a7377021025c46a16aa79db4();
		array[6] = "/";
		array[7] = ca937003ba4cbf4130cad1fcc9da2873e();
		array[8] = "]";
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, string.Concat(array));
		return hashtable;
	}

	public override void caece940d1c226511b3cca16fa8aa6a38(Hashtable c591d56a94543e3559945c497f37126c4)
	{
		c06ade3733c4658b091be622d9d3b4034();
		int num = 0;
		int cefda2fdc3ce4e04f38bab77fc = (int)c591d56a94543e3559945c497f37126c4[num++];
		int cefda2fdc3ce4e04f38bab77fc2 = (int)c591d56a94543e3559945c497f37126c4[num++];
		m_pouchList[3].c82133ff2bb787510ed8585dd3d834b59(cefda2fdc3ce4e04f38bab77fc);
		m_pouchList[3].ca0f7f52805a9c67a892c5b479a17c3aa(cefda2fdc3ce4e04f38bab77fc2);
		cefda2fdc3ce4e04f38bab77fc = (int)c591d56a94543e3559945c497f37126c4[num++];
		cefda2fdc3ce4e04f38bab77fc2 = (int)c591d56a94543e3559945c497f37126c4[num++];
		m_pouchList[4].c82133ff2bb787510ed8585dd3d834b59(cefda2fdc3ce4e04f38bab77fc);
		m_pouchList[4].ca0f7f52805a9c67a892c5b479a17c3aa(cefda2fdc3ce4e04f38bab77fc2);
		cefda2fdc3ce4e04f38bab77fc = (int)c591d56a94543e3559945c497f37126c4[num++];
		cefda2fdc3ce4e04f38bab77fc2 = (int)c591d56a94543e3559945c497f37126c4[num++];
		m_pouchList[1].c82133ff2bb787510ed8585dd3d834b59(cefda2fdc3ce4e04f38bab77fc);
		m_pouchList[1].ca0f7f52805a9c67a892c5b479a17c3aa(cefda2fdc3ce4e04f38bab77fc2);
		cefda2fdc3ce4e04f38bab77fc = (int)c591d56a94543e3559945c497f37126c4[num++];
		cefda2fdc3ce4e04f38bab77fc2 = (int)c591d56a94543e3559945c497f37126c4[num++];
		m_pouchList[2].c82133ff2bb787510ed8585dd3d834b59(cefda2fdc3ce4e04f38bab77fc);
		m_pouchList[2].ca0f7f52805a9c67a892c5b479a17c3aa(cefda2fdc3ce4e04f38bab77fc2);
		int num2 = (int)c591d56a94543e3559945c497f37126c4[num++];
		int num3 = (int)c591d56a94543e3559945c497f37126c4[num++];
		int num4 = (int)c591d56a94543e3559945c497f37126c4[num++];
		int num5 = (int)c591d56a94543e3559945c497f37126c4[num++];
		c9af7b3e5f6626ceef1a0036138121839(num2);
		cf0a63fdc9831dd55ae40ac6a5f5eb7e0(num3);
		c405b3c9891c62259c5917e975ecd6145(num4);
		c521b7affa3889eae158dbd009bbe95cb(num5);
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(9);
		array[0] = "Boss.UnSerializeLifeAndShield life[";
		array[1] = num3;
		array[2] = "/";
		array[3] = num2;
		array[4] = "] - shield[";
		array[5] = num5;
		array[6] = "/";
		array[7] = num4;
		array[8] = "]";
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, string.Concat(array));
	}
}
