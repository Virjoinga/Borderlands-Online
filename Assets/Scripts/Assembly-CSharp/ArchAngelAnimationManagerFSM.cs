using A;
using UnityEngine;

public class ArchAngelAnimationManagerFSM : NPCAnimationManagerFSM
{
	public Transform[] m_missileLunchPoints = cf8fd77ab791dc633b20ecce3257da033.c0a0cdf4a196914163f7334d9b0781a04(0);

	public override int c43e01190c713db1f8a78d1529ae2d2ed(string cb6ecce17c4a10cf4ade445feb45a0355)
	{
		if (cb6ecce17c4a10cf4ade445feb45a0355.ToLower() == "hurtlight")
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
					return 1;
				}
			}
		}
		return 0;
	}

	public override void c6d990a8ab1adfc44722a078a44954178()
	{
		Vector3 vector = default(Vector3);
		vector.x = 0f;
		vector.y = 2.5f;
		vector.z = 0f;
		m_VFXManager.c930218e437c0501ced1553e08dab14d9(ENPCParticleType.E_archangelTeleport, base.transform.position + vector, Quaternion.identity, true);
	}

	public override void cdd2f24f8d58571ac78fbd3493e1022b2()
	{
		Vector3 vector = default(Vector3);
		vector.x = 0f;
		vector.y = 2.5f;
		vector.z = 0f;
		m_VFXManager.c930218e437c0501ced1553e08dab14d9(ENPCParticleType.E_archangelTeleport, base.transform.position + vector, Quaternion.identity, true);
	}

	private void OnDestroy()
	{
		if (!(m_VFXManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			m_VFXManager.c61965fdbaf3e5bcda81d0af5a65e1ac8(ENPCParticleType.E_archangelDeathStruggle);
			return;
		}
	}
}
