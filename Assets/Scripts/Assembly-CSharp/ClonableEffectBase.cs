using System.Collections.Generic;
using A;
using UnityEngine;

public abstract class ClonableEffectBase : EffectBase
{
	private struct NextEffectToPlay
	{
		public EffectTrigger trigger;

		public float timeToPlay;
	}

	public bool m_useCloneWhenPlayEffect;

	public bool m_rotateClone = true;

	public bool m_destroyCloneAfterEffect = true;

	public int m_durationForDestroyClone = 5;

	public float m_delay;

	public Vector3 m_offsetToMoveClone = new Vector3(0f, 0f, 0f);

	public Vector3 m_eulerAnglesToRotateClone = new Vector3(0f, 0f, 0f);

	protected bool m_usingClone;

	protected GameObject m_clone;

	private bool m_needUpdate;

	private List<NextEffectToPlay> m_nextToPlay = new List<NextEffectToPlay>();

	public void c47ea294efcebae2bc2bb5294de75c907(Transform c9e386404f6707c9ca0359c519546bee6, EffectTrigger c93dbec96f39444e378558f06afbdd30f)
	{
		if (!(c9e386404f6707c9ca0359c519546bee6 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (!(c93dbec96f39444e378558f06afbdd30f != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				Transform transform = c93dbec96f39444e378558f06afbdd30f.m_gameObject.transform;
				if (c93dbec96f39444e378558f06afbdd30f.m_location == EffectLocationType.GameObject)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							if (m_usingClone)
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
								if (m_rotateClone)
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
									c9e386404f6707c9ca0359c519546bee6.rotation = transform.rotation;
								}
							}
							c9e386404f6707c9ca0359c519546bee6.parent = transform;
							if (m_usingClone)
							{
								while (true)
								{
									switch (4)
									{
									case 0:
										break;
									default:
										c9e386404f6707c9ca0359c519546bee6.Rotate(m_eulerAnglesToRotateClone, Space.Self);
										c9e386404f6707c9ca0359c519546bee6.localPosition = m_offsetToMoveClone;
										return;
									}
								}
							}
							return;
						}
					}
				}
				if (c93dbec96f39444e378558f06afbdd30f.m_location != EffectLocationType.Raycast)
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
					Quaternion quaternion = Quaternion.FromToRotation(Vector3.up, c93dbec96f39444e378558f06afbdd30f.m_raycastHit.normal);
					c9e386404f6707c9ca0359c519546bee6.position = c93dbec96f39444e378558f06afbdd30f.m_raycastHit.point + quaternion * m_offsetToMoveClone;
					if (m_rotateClone)
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
						Vector3 toDirection = Vector3.Reflect(c93dbec96f39444e378558f06afbdd30f.m_specifiedRaycastDirection, c93dbec96f39444e378558f06afbdd30f.m_raycastHit.normal);
						c9e386404f6707c9ca0359c519546bee6.rotation = Quaternion.FromToRotation(Vector3.up, toDirection);
					}
					if (!(c93dbec96f39444e378558f06afbdd30f.m_raycastHit.collider != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
						c9e386404f6707c9ca0359c519546bee6.Rotate(m_eulerAnglesToRotateClone, Space.Self);
						return;
					}
				}
			}
		}
	}

	public override void PlayEffect(EffectTrigger trigger)
	{
		if (cae77df3a872437acdd8f9a17a0f5833e() == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return;
				}
			}
		}
		m_clone = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
		if (!m_useCloneWhenPlayEffect)
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
			if (cae77df3a872437acdd8f9a17a0f5833e().activeSelf)
			{
				m_usingClone = false;
				c7990dc799c2f0edbfed99a64aeff9335();
				c47ea294efcebae2bc2bb5294de75c907(cae77df3a872437acdd8f9a17a0f5833e().transform, trigger);
				return;
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
		m_usingClone = true;
		if (m_delay > 0f)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
				{
					m_needUpdate = true;
					NextEffectToPlay item = default(NextEffectToPlay);
					item.trigger = trigger;
					item.timeToPlay = Time.realtimeSinceStartup + m_delay;
					m_nextToPlay.Add(item);
					return;
				}
				}
			}
		}
		c84b59f89785d215aa3c3f172301d649c(trigger);
	}

	private void c84b59f89785d215aa3c3f172301d649c(EffectTrigger c93dbec96f39444e378558f06afbdd30f)
	{
		cd33dfbcd1852045129d33dc495a0a6fa(c93dbec96f39444e378558f06afbdd30f);
		if (!(m_clone != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (!m_destroyCloneAfterEffect)
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
				Object.Destroy(m_clone, m_durationForDestroyClone);
				return;
			}
		}
	}

	private void Update()
	{
		if (!m_needUpdate)
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
					return;
				}
			}
		}
		while (m_nextToPlay.Count > 0)
		{
			NextEffectToPlay item = m_nextToPlay[0];
			if (!(Time.realtimeSinceStartup > item.timeToPlay))
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
				break;
			}
			c84b59f89785d215aa3c3f172301d649c(item.trigger);
			m_nextToPlay.Remove(item);
			if (m_nextToPlay.Count != 0)
			{
				continue;
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
			m_needUpdate = false;
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	public abstract GameObject cae77df3a872437acdd8f9a17a0f5833e();

	public abstract void cd33dfbcd1852045129d33dc495a0a6fa(EffectTrigger c93dbec96f39444e378558f06afbdd30f);

	public abstract void c7990dc799c2f0edbfed99a64aeff9335();
}
