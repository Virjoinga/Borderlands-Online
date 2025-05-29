using System.Collections;
using A;
using UnityEngine;
using XsdSettings;

public class EntityNpcSoldierTurret : EntityNpc
{
	public Transform m_SMGHolder;

	public Transform cf40f1411a71635238075b839a6650d91(WeaponType ceccaa67e17deb18ec7c67b2cb86757de)
	{
		if (ceccaa67e17deb18ec7c67b2cb86757de == WeaponType.SMG)
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
					return m_SMGHolder;
				}
			}
		}
		return m_rightHandWeaponSlot;
	}

	public override void Start()
	{
		base.Start();
		if (base.photonView.c332524fa6b5f6c2dfdb5f39c56de7f45 == null)
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
			m_teamID = (int)base.photonView.c332524fa6b5f6c2dfdb5f39c56de7f45[2];
			StartCoroutine(cef47d29b3a46f71f2ac58a1d308356dc());
			return;
		}
	}

	private IEnumerator cef47d29b3a46f71f2ac58a1d308356dc()
	{
		while (true)
		{
			if (!(c5ca38fad98337fc5c7255384b2cd1a86() == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (ccfad1bf47b003333c5ddd084f14d33e7() > 0)
				{
					break;
				}
			}
			yield return c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e;
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			for (int i = 0; i < 10; i++)
			{
				yield return c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e;
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				float hpModifier = (float)base.photonView.c332524fa6b5f6c2dfdb5f39c56de7f45[3];
				if (!(hpModifier > 1f))
				{
					yield break;
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					c9af7b3e5f6626ceef1a0036138121839((int)((float)ccfad1bf47b003333c5ddd084f14d33e7() * hpModifier));
					cf0a63fdc9831dd55ae40ac6a5f5eb7e0(ccfad1bf47b003333c5ddd084f14d33e7());
					yield break;
				}
			}
		}
	}

	public override void c3bf54d312726877e5f77b6d475aef510()
	{
		int c71343215f125dcae7cc50af15a301fcd = (1 << LayerMask.NameToLayer("Walkable")) | (1 << LayerMask.NameToLayer("Default"));
		c90772582c2a384501f1dec50d90e2afe(c71343215f125dcae7cc50af15a301fcd);
	}

	public string c5a054719a5eca237f11fd9762d98ca82()
	{
		string text = c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e;
		if (m_relatedPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			text = m_relatedPlayer.ca6bcee369aa6d4cdf126ebaeef6f6c73();
		}
		if (string.IsNullOrEmpty(text))
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
			text = "Soldier";
		}
		return "[" + text + "]";
	}

	public override float c150748569f6883ea4267194e6e3271e7(EntityWeapon c63e77db49ee63186e474d32152b9912c, int cfba4197b705c13c9466d9b0559d75d4b)
	{
		float num = base.c150748569f6883ea4267194e6e3271e7(c63e77db49ee63186e474d32152b9912c, cfba4197b705c13c9466d9b0559d75d4b);
		if (c63e77db49ee63186e474d32152b9912c != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (m_relatedPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				num = PlayerSkillManage.c2dd18403fa78b17c55fa02287de38e78(m_relatedPlayer.c7513e66c4e0fc55e6fea9dd9cb8b9943(), num);
				num *= m_relatedPlayer.c2386b82d4bb271e437af2a55537b8ff7();
			}
		}
		return num;
	}
}
