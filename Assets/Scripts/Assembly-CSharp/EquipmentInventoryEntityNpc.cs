using System.Collections;
using A;
using UnityEngine;
using XsdSettings;

public class EquipmentInventoryEntityNpc : EquipmentInventoryEntity
{
	private enum PouchType
	{
		LIFE = 0
	}

	protected byte m_level;

	protected byte m_isHealing;

	private bool m_hasBerserkAura;

	public bool m_bMissionNpc;

	protected InventorySlot m_shieldSlot = new InventorySlot();

	protected InventorySlot m_weaponSlot = new InventorySlot();

	protected short m_lastShieldPointReceived;

	private NPCShieldSetup m_shieldSetup;

	public bool cdf295658fa3a6f2070241c6edf06aef2
	{
		get
		{
			return m_hasBerserkAura;
		}
		set
		{
			m_hasBerserkAura = value;
		}
	}

	public override int ca2ff7a501878363cb1d5f0472e306620()
	{
		return m_pouchList[0].c4c4b463091d2b6acfdded4fa12b32f25();
	}

	public override int ccfad1bf47b003333c5ddd084f14d33e7()
	{
		return m_pouchList[0].c17a506784adea8f822bee98ad9dba710();
	}

	public override int c19b70ea6e4db0802bb7cae385cc85109(AmmoType c1e73ae4c18ab95639cb0c7604f21dc2b = AmmoType.SMG)
	{
		return 1000;
	}

	public override int c8a605fa1a9c2a71cfb141d9433f2f958(AmmoType c1e73ae4c18ab95639cb0c7604f21dc2b = AmmoType.SMG)
	{
		return 1000;
	}

	public override byte c7513e66c4e0fc55e6fea9dd9cb8b9943()
	{
		return m_level;
	}

	public override int c5c30fc221fd2805f9535a08995b34b98(WeaponType c2b4f43f34e21572af6ab4414f04cee36)
	{
		return 1000;
	}

	public void cb6ceb78f36080a0ffcced8be849ad7f3(bool c30fa0a1fc4105a66991fbee1faedfe2d)
	{
		int isHealing;
		if (c30fa0a1fc4105a66991fbee1faedfe2d)
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
			isHealing = 1;
		}
		else
		{
			isHealing = 0;
		}
		m_isHealing = (byte)isHealing;
	}

	public override int ce7804365a7377021025c46a16aa79db4()
	{
		if (cb4633378bdf6d47c409332e395d58c7a() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return cb4633378bdf6d47c409332e395d58c7a().m_shieldPoints.c4c4b463091d2b6acfdded4fa12b32f25();
				}
			}
		}
		return 0;
	}

	public override int ca937003ba4cbf4130cad1fcc9da2873e()
	{
		if (cb4633378bdf6d47c409332e395d58c7a() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return cb4633378bdf6d47c409332e395d58c7a().m_shieldPoints.c17a506784adea8f822bee98ad9dba710();
				}
			}
		}
		return 0;
	}

	public override EntityShield cb4633378bdf6d47c409332e395d58c7a()
	{
		return m_shieldSlot.c66b232dbebded7c7e9a89c1e8bd84689() as EntityShield;
	}

	public override EntityWeapon cdda217ef6662acf86a5584ba19758192()
	{
		return m_weaponSlot.c66b232dbebded7c7e9a89c1e8bd84689() as EntityWeapon;
	}

	public override EntityWeapon c4e0dae6a16a8a80ddb5214a896b9df58(byte ccdfba09818795b7154978e955acab94a)
	{
		return m_weaponSlot.c66b232dbebded7c7e9a89c1e8bd84689() as EntityWeapon;
	}

	public override void c9af7b3e5f6626ceef1a0036138121839(int c19e024b5bcbd347892bec27154c527de)
	{
		m_pouchList[0].c82133ff2bb787510ed8585dd3d834b59(c19e024b5bcbd347892bec27154c527de);
	}

	public override void cf0a63fdc9831dd55ae40ac6a5f5eb7e0(int c19e024b5bcbd347892bec27154c527de)
	{
		m_pouchList[0].ca0f7f52805a9c67a892c5b479a17c3aa(c19e024b5bcbd347892bec27154c527de);
	}

	private void Awake()
	{
		m_pouchList.Clear();
		m_pouchList.Add(new Utils.PouchNetwork());
	}

	public override void cd93285db16841148ed53a5bbeb35cf20(byte cd6bb591c33b2ee3ab93e98aa43a6da63, int cb75bb7e4635f59359605d47e3ee3541b)
	{
	}

	public override void cd93285db16841148ed53a5bbeb35cf20(byte cd6bb591c33b2ee3ab93e98aa43a6da63)
	{
		m_level = cd6bb591c33b2ee3ab93e98aa43a6da63;
		m_isHealing = 0;
	}

	[RPC]
	public void RPC_ApplyShieldSetup(int maxShieldPoint, float regenerationCD, float regenerationRate)
	{
		m_shieldSetup = new NPCShieldSetup();
		m_shieldSetup.m_maxShieldPoints = maxShieldPoint;
		m_shieldSetup.m_regenerationCooldown = regenerationCD;
		m_shieldSetup.m_regenerationRate = regenerationRate;
		StartCoroutine(c4b228fd9697167791787c011873ca86e());
	}

	public IEnumerator c4b228fd9697167791787c011873ca86e()
	{
		while (cb4633378bdf6d47c409332e395d58c7a() == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			yield return 0;
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
			EntityShield shield = cb4633378bdf6d47c409332e395d58c7a();
			shield.m_maxShieldPoints = m_shieldSetup.m_maxShieldPoints;
			shield.m_regenerationCooldown = m_shieldSetup.m_regenerationCooldown;
			shield.m_regenerationRate = m_shieldSetup.m_regenerationRate;
			shield.c1c5a947f5f8c009fe6fac45c9e29ad1d(GetComponent<EntityNpc>());
			yield break;
		}
	}

	public virtual void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		c06ade3733c4658b091be622d9d3b4034();
		if (stream.c8b2526be2638bb30a29ab8314b369311)
		{
			while (true)
			{
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
					stream.caf7283cc5cd9725a88a9cdfa630d92f8(m_level);
					stream.caf7283cc5cd9725a88a9cdfa630d92f8(m_isHealing);
					stream.caf7283cc5cd9725a88a9cdfa630d92f8(m_bMissionNpc);
					stream.caf7283cc5cd9725a88a9cdfa630d92f8(m_hasBerserkAura);
					int num = 0;
					if (cb4633378bdf6d47c409332e395d58c7a() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						num = m_shieldSlot.c66b232dbebded7c7e9a89c1e8bd84689().cc7403315505256d19a7b92aa614a8f10();
					}
					stream.caf7283cc5cd9725a88a9cdfa630d92f8(num);
					if (num != 0)
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
					}
					num = 0;
					if ((bool)m_weaponSlot.c66b232dbebded7c7e9a89c1e8bd84689())
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
						num = m_weaponSlot.c66b232dbebded7c7e9a89c1e8bd84689().cc7403315505256d19a7b92aa614a8f10();
					}
					stream.caf7283cc5cd9725a88a9cdfa630d92f8(num);
					return;
				}
				}
			}
		}
		m_level = (byte)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
		m_isHealing = (byte)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
		m_bMissionNpc = (bool)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
		m_hasBerserkAura = (bool)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
		int c35f98ccbfa8c6bf09319c620b21b5dc = (int)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
		m_shieldSlot.c7cd2e714b90259c7cbaa0bd226fe8435(c35f98ccbfa8c6bf09319c620b21b5dc, c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e);
		m_weaponSlot.c7cd2e714b90259c7cbaa0bd226fe8435((int)stream.cbc3e6f46d26c8fb00a98f05fc700248a(), c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e);
	}

	public override void c06ade3733c4658b091be622d9d3b4034()
	{
		base.c06ade3733c4658b091be622d9d3b4034();
		if (!cb4633378bdf6d47c409332e395d58c7a())
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			cb4633378bdf6d47c409332e395d58c7a().m_shieldPoints.c06ade3733c4658b091be622d9d3b4034();
			return;
		}
	}

	public override void cdfac57bd798072bd71a801c00909ad5c()
	{
		base.cdfac57bd798072bd71a801c00909ad5c();
		if (!cb4633378bdf6d47c409332e395d58c7a())
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
			cb4633378bdf6d47c409332e395d58c7a().m_shieldPoints.cdfac57bd798072bd71a801c00909ad5c();
			return;
		}
	}
}
