using A;
using UnityEngine;

[AddComponentMenu("Effects/TKC/Animation Effect")]
public class AnimationEffect : ClonableEffectBase
{
	public Animation m_animation;

	public string m_animationToPlay = string.Empty;

	public bool m_restartWhenPlay = true;

	public bool m_isAdditive;

	public override void cd33dfbcd1852045129d33dc495a0a6fa(EffectTrigger c93dbec96f39444e378558f06afbdd30f)
	{
		if (!(m_animation != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
		{
			return;
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			Animation animation = (Animation)Object.Instantiate(m_animation);
			m_clone = animation.gameObject;
			if (m_isAdditive)
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
				AnimationState animationState = animation[m_animationToPlay];
				animationState.wrapMode = WrapMode.Once;
				animationState.blendMode = AnimationBlendMode.Additive;
			}
			animation.Play(m_animationToPlay);
			return;
		}
	}

	public override void c7990dc799c2f0edbfed99a64aeff9335()
	{
		if (!(m_animation != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (!m_restartWhenPlay)
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
				if (m_animation.isPlaying)
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
					break;
				}
			}
			if (m_isAdditive)
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
				AnimationState animationState = m_animation[m_animationToPlay];
				animationState.wrapMode = WrapMode.Once;
				animationState.blendMode = AnimationBlendMode.Additive;
			}
			m_animation.Play(m_animationToPlay);
			return;
		}
	}

	public override GameObject cae77df3a872437acdd8f9a17a0f5833e()
	{
		if (m_animation == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return null;
				}
			}
		}
		return m_animation.gameObject;
	}
}
