using A;
using UnityEngine;

public class GuardianWraithAnimationManagerFSM : NPCAnimationManagerFSM
{
	private const int UPPERBODY_LAYER = 1;

	private GameObject m_leftSword;

	private GameObject m_rightSword;

	private bool m_isSwordVisible = true;

	public void cb8c810aa2cf841ac66d499ce40d1bd09()
	{
		EntityNpc component = base.gameObject.GetComponent<EntityNpc>();
		m_leftSword = component.m_leftHandWeaponSlot.gameObject;
		m_rightSword = component.m_rightHandWeaponSlot.gameObject;
	}

	public override bool c39997c2d57776ba3c104737021557daf()
	{
		return m_isSwordVisible;
	}

	public override void cd295c889c81e8823ba501a609b868079(bool c909dc6005555f2098b85680918806864)
	{
		if (m_leftSword == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			cb8c810aa2cf841ac66d499ce40d1bd09();
		}
		if (c909dc6005555f2098b85680918806864)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					m_rightSword.SetActive(false);
					m_leftSword.SetActive(false);
					m_isSwordVisible = false;
					return;
				}
			}
		}
		if (m_isSwordVisible)
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
			m_rightSword.SetActive(true);
			m_leftSword.SetActive(true);
			m_isSwordVisible = true;
			if (!(m_VFXManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				m_VFXManager.cabda1e77309d61d99a04e4b57b962f2f(ENPCParticleType.E_WeaponAppear, 10f, false);
				return;
			}
		}
	}

	public override void Start()
	{
		base.Start();
		m_isHumanoid = false;
		m_canUseFacingLogic = true;
		m_deathLayer = 2;
		m_isSwordVisible = true;
		cd295c889c81e8823ba501a609b868079(true);
		m_animEventHandlerList.Add("MeleeHit", base.OnMeleeHit);
	}

	public override int c43e01190c713db1f8a78d1529ae2d2ed(string cb6ecce17c4a10cf4ade445feb45a0355)
	{
		if (cb6ecce17c4a10cf4ade445feb45a0355.ToLower() == "hurtlight")
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
					return 1;
				}
			}
		}
		return 0;
	}

	public override GameObject c8f822dae060543cd85b9b5aa16f48436(int cf304be0caeadea8eea88f52d32c75728)
	{
		bool flag = false;
		GameObject result = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
		if (base.ccaaf181e61e5f9e050ba82237ed111a2.GetFloat("fThrowWeaponCurve") > 0.15f)
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
		}
		else if (0 == 0)
		{
			goto IL_00a6;
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			break;
		}
		result = Object.Instantiate(GetComponent<EntityNpc>().m_spawnObjPrefab, m_skeleton.cb2362c81dda995fcf817a341a4eb3ffb().position + base.gameObject.transform.forward * 0.3f, Quaternion.identity) as GameObject;
		goto IL_00a6;
		IL_00a6:
		return result;
	}

	public override void OnDeath()
	{
		cd295c889c81e8823ba501a609b868079(true);
		if (!(m_VFXManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			m_VFXManager.cb6ddb86ff592b855d40e4b6baac609bf();
			return;
		}
	}

	public override void c6d990a8ab1adfc44722a078a44954178()
	{
		Vector3 vector = default(Vector3);
		vector.x = 0f;
		vector.y = 1f;
		vector.z = 0f;
		m_VFXManager.c930218e437c0501ced1553e08dab14d9(ENPCParticleType.E_Fuse, base.transform.position + vector, Quaternion.identity, true);
	}

	public override void cdd2f24f8d58571ac78fbd3493e1022b2()
	{
		Vector3 vector = default(Vector3);
		vector.x = 0f;
		vector.y = 1f;
		vector.z = 0f;
		m_VFXManager.c930218e437c0501ced1553e08dab14d9(ENPCParticleType.E_Spawn, base.transform.position + vector, Quaternion.identity, true);
	}
}
