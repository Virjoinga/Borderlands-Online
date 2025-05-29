using A;
using UnityEngine;

public class CrimsonMechaKnoxxAnimationManagerFSM : NPCAnimationManagerFSM
{
	public LineRenderer m_laserRender;

	public Transform m_laserTransform;

	public bool m_bShowRightLaser;

	public bool m_bShowLeftLaser;

	public bool m_bLaserSweepStart;

	public float m_sweepSpeed = 180f;

	public Vector3 m_vLaserDir;

	public Vector3 m_vLaserDir_Pre;

	private Quaternion m_rotIdentity = Quaternion.identity;

	public override void Start()
	{
		base.Start();
		m_movementSync = GetComponent<MovementSync>();
		m_isHumanoid = false;
		m_deathLayer = 1;
		AnimationSpacingState animationSpacingState = c059bb29245b8e57e3b793798ddfdb249("Spacing") as AnimationSpacingState;
		if (animationSpacingState != null)
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
			animationSpacingState.m_normalizeTurnAngle = true;
		}
		m_animEventHandlerList.Add("MeleeHit", base.OnMeleeHit);
		m_animEventHandlerList.Add("RightLaserSweepStart", cca46241afadf6c87c79cae4989ab3350);
		m_animEventHandlerList.Add("RightLaserSweepEnd", cf92b766e7d91cab682055f264093a281);
		m_animEventHandlerList.Add("LeftLaserSweepStart", c06f512bb3cee5b2bb3d4a319ee11a662);
		m_animEventHandlerList.Add("LeftLaserSweepEnd", caf725283d5fff82791624827b131c5eb);
		m_bShowRightLaser = false;
		m_bShowLeftLaser = false;
		m_bLaserSweepStart = false;
		m_laserRender = m_entity.GetComponent<LineRenderer>();
	}

	public override void Update()
	{
		base.Update();
		cb0b82f61b1dcc95d17f5f58e47460729();
	}

	public void cca46241afadf6c87c79cae4989ab3350()
	{
		if (!m_bLaserSweepStart)
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
					return;
				}
			}
		}
		m_bShowRightLaser = true;
		m_vLaserDir = -m_entity.transform.right;
		m_vLaserDir_Pre = m_vLaserDir;
		m_laserTransform = (m_entity as EntityNpc).m_rightHandWeaponSlot;
		m_VFXManager.c930218e437c0501ced1553e08dab14d9(ENPCParticleType.E_KnoxxLaserGuns, m_entity, m_laserTransform, m_vZero, m_rotIdentity, 2f);
	}

	public void cf92b766e7d91cab682055f264093a281()
	{
		m_bShowRightLaser = false;
	}

	public void c06f512bb3cee5b2bb3d4a319ee11a662()
	{
		if (!m_bLaserSweepStart)
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
					return;
				}
			}
		}
		m_bShowLeftLaser = true;
		m_vLaserDir = m_entity.transform.right;
		m_vLaserDir_Pre = m_vLaserDir;
		m_laserTransform = (m_entity as EntityNpc).m_leftHandWeaponSlot;
		m_VFXManager.c930218e437c0501ced1553e08dab14d9(ENPCParticleType.E_KnoxxLaserGuns, m_entity, m_laserTransform, m_vZero, m_rotIdentity, 2f);
	}

	public void caf725283d5fff82791624827b131c5eb()
	{
		m_bShowLeftLaser = false;
	}

	public void cb0b82f61b1dcc95d17f5f58e47460729()
	{
		if (!m_bLaserSweepStart)
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
			if (m_laserRender == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (m_laserTransform == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							return;
						}
					}
				}
				if (!m_bShowLeftLaser)
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
					if (!m_bShowRightLaser)
					{
						while (true)
						{
							switch (5)
							{
							case 0:
								break;
							default:
								m_laserRender.SetPosition(0, m_laserTransform.position);
								m_laserRender.SetPosition(1, m_laserTransform.position);
								m_laserTransform = ce1fb4d774e60a964105c162513d97b38.c7088de59e49f7108f520cf7e0bae167e;
								return;
							}
						}
					}
				}
				m_vLaserDir_Pre = m_vLaserDir;
				m_laserRender.SetPosition(0, m_laserTransform.position);
				if (m_bShowRightLaser)
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
					m_vLaserDir = Quaternion.Euler(0f, m_sweepSpeed * Time.deltaTime, 0f) * m_vLaserDir;
				}
				else
				{
					m_vLaserDir = Quaternion.Euler(0f, (0f - m_sweepSpeed) * Time.deltaTime, 0f) * m_vLaserDir;
				}
				m_vLaserDir.y = 0f;
				m_laserRender.SetPosition(1, m_laserTransform.position + m_vLaserDir * 100f);
				return;
			}
		}
	}
}
