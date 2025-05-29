using A;
using UnityEngine;

[AddComponentMenu("Effects/TKC/Legacy Particle Effect")]
public class LegacyParticleEffect : ClonableEffectBase
{
	public ParticleEmitter m_effect;

	public override void cd33dfbcd1852045129d33dc495a0a6fa(EffectTrigger c93dbec96f39444e378558f06afbdd30f)
	{
		if (!(m_effect != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			ParticleEmitter particleEmitter = (ParticleEmitter)Object.Instantiate(m_effect);
			m_clone = particleEmitter.gameObject;
			particleEmitter.Emit();
			return;
		}
	}

	public override void c7990dc799c2f0edbfed99a64aeff9335()
	{
		if (!(m_effect != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_effect.Emit();
			return;
		}
	}

	public override GameObject cae77df3a872437acdd8f9a17a0f5833e()
	{
		if (m_effect == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return null;
				}
			}
		}
		return m_effect.gameObject;
	}
}
