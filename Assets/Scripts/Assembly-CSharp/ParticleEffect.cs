using A;
using UnityEngine;

[AddComponentMenu("Effects/TKC/Particle Effect")]
public class ParticleEffect : ClonableEffectBase
{
	public ParticleSystem m_effect;

	public bool m_restartWhenPlay = true;

	public override void cd33dfbcd1852045129d33dc495a0a6fa(EffectTrigger c93dbec96f39444e378558f06afbdd30f)
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
			c47ea294efcebae2bc2bb5294de75c907(cae77df3a872437acdd8f9a17a0f5833e().transform, c93dbec96f39444e378558f06afbdd30f);
			ParticleSystem particleSystem = (ParticleSystem)Object.Instantiate(m_effect, cae77df3a872437acdd8f9a17a0f5833e().transform.position, cae77df3a872437acdd8f9a17a0f5833e().transform.rotation);
			m_clone = particleSystem.gameObject;
			if (particleSystem.playOnAwake)
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
				particleSystem.Play();
				return;
			}
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
			switch (5)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (!m_restartWhenPlay)
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
				if (m_effect.isPlaying)
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
					break;
				}
			}
			m_effect.Play();
			return;
		}
	}

	public override GameObject cae77df3a872437acdd8f9a17a0f5833e()
	{
		if (m_effect == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return null;
				}
			}
		}
		return m_effect.gameObject;
	}
}
