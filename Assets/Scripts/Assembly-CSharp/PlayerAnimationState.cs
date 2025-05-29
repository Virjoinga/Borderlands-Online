using A;
using UnityEngine;

public class PlayerAnimationState : AnimationManagerState
{
	public class AnimatorInfoManage
	{
		private PlayerAnimationState m_owner;

		private float m_netLatency;

		private AnimatorStateInfo m_animatorInfo;

		private bool m_bInited;

		private float m_startTime;

		private float m_length_anim;

		public AnimatorInfoManage(PlayerAnimationState cf811c0d5de19d7fe22be8d61350b722d)
		{
			m_owner = cf811c0d5de19d7fe22be8d61350b722d;
		}

		public void Reset(float _netLatency)
		{
			m_bInited = false;
			m_netLatency = _netLatency;
		}

		public float c8d61bc457bf1e08126a3d9d2111b25df(string c48a1f5a040a419463768e79ec76c00e4, int c71343215f125dcae7cc50af15a301fcd)
		{
			m_animatorInfo = m_owner.ca18251f94792b5764ab1a1024333abfb(false, c71343215f125dcae7cc50af15a301fcd);
			if (!m_animatorInfo.IsTag(c48a1f5a040a419463768e79ec76c00e4))
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
						return -1f;
					}
				}
			}
			if (!m_bInited)
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
				ccc9d3a38966dc10fedb531ea17d24611();
			}
			return Mathf.Clamp((Time.time + m_netLatency - m_startTime) / m_length_anim, 0f, 1f);
		}

		private void ccc9d3a38966dc10fedb531ea17d24611()
		{
			m_bInited = true;
			m_startTime = Time.time;
			m_length_anim = m_animatorInfo.length;
		}
	}

	public struct AnimData
	{
		public int m_layer;

		public string m_tag;

		public MecanimAnimationID m_param_1st;

		public string m_param_3rd;

		public AnimData(int c71343215f125dcae7cc50af15a301fcd, string c48a1f5a040a419463768e79ec76c00e4, MecanimAnimationID cd1355ff1287306fd9b2b5d600d3d15d5, string c7697b675af42d67bc784d6af6efb6273)
		{
			m_layer = c71343215f125dcae7cc50af15a301fcd;
			m_tag = c48a1f5a040a419463768e79ec76c00e4;
			m_param_1st = cd1355ff1287306fd9b2b5d600d3d15d5;
			m_param_3rd = c7697b675af42d67bc784d6af6efb6273;
		}
	}

	protected BaseEventTriggerCtl m_AudioCtl;

	protected Animator m_firstPersonAnimator;

	private Animator m_thirdPersonAnimator;

	private EntityPlayer m_entityPlayer;

	protected PlayerThirdPersonAnimationManagerFSM m_playerThirdAnimManager;

	protected AnimatorInfoManage m_animInfoMgr;

	private bool m_enableFirstPerson = true;

	private PlayerWeaponAnimationManagerFSM m_weaponAnimationManager;

	public PlayerWeaponAnimationManagerFSM c6e68afa0a7f820f050de4b96ae1be367
	{
		get
		{
			if (m_weaponAnimationManager == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				m_weaponAnimationManager = m_AnimationManagerFSM.gameObject.GetComponent<PlayerWeaponAnimationManagerFSM>();
			}
			return m_weaponAnimationManager;
		}
		set
		{
			m_weaponAnimationManager = value;
		}
	}

	public bool c90e194560a86112d38f669898a54a249
	{
		get
		{
			if (m_playerThirdAnimManager == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				cd56255baa45e535edc0ee1919542bcd5();
			}
			m_enableFirstPerson = m_playerThirdAnimManager.m_firstPersonAnimator != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e;
			return m_enableFirstPerson;
		}
		set
		{
			m_enableFirstPerson = value;
		}
	}

	public void cd56255baa45e535edc0ee1919542bcd5()
	{
		if (m_playerThirdAnimManager == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_playerThirdAnimManager = m_AnimationManagerFSM.gameObject.GetComponent<PlayerThirdPersonAnimationManagerFSM>();
		}
		if (!(m_firstPersonAnimator == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			m_firstPersonAnimator = m_playerThirdAnimManager.m_firstPersonAnimator;
			return;
		}
	}

	public override void cdd79e3fb9f04672a139ad58f6b3176f7()
	{
		base.cdd79e3fb9f04672a139ad58f6b3176f7();
		cd56255baa45e535edc0ee1919542bcd5();
		if (m_AudioCtl == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_AudioCtl = m_playerThirdAnimManager.m_AudioCtl;
		}
		if (m_AnimationManagerFSM.m_animationEventController != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_AnimationManagerFSM.m_animationEventController.m_pendingLeftHandIK = false;
		}
		if (m_animInfoMgr != null)
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
			m_animInfoMgr = new AnimatorInfoManage(this);
			return;
		}
	}

	public void ce7563fcf3b106cefb47b52f00fced07b(MecanimAnimationID cbd26e39b8b1d5b0abffedcac5d1ecc8f)
	{
		if (m_playerThirdAnimManager == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			cd56255baa45e535edc0ee1919542bcd5();
		}
		m_playerThirdAnimManager.m_AnimatorGraph.c979843b9afa58b1781f5d83769d1e4fb(cbd26e39b8b1d5b0abffedcac5d1ecc8f);
	}

	public void ce828a5281da417bda49f7bd3dcdc3863(MecanimAnimationID cbd26e39b8b1d5b0abffedcac5d1ecc8f)
	{
		if (m_playerThirdAnimManager == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			cd56255baa45e535edc0ee1919542bcd5();
		}
		m_playerThirdAnimManager.m_AnimatorGraph.c21f4463c05bd3111b521d9507363eba0(cbd26e39b8b1d5b0abffedcac5d1ecc8f);
	}

	public bool ccadff0d4c94e9a3efd1c9a959fd4b0b9(string c14f324b46e75f970614639298e7fb508, bool c900d0d686d681543cac68c31d8025cd5)
	{
		if (!(m_playerThirdAnimManager == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (!(m_firstPersonAnimator == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
			{
				goto IL_004b;
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
		cd56255baa45e535edc0ee1919542bcd5();
		goto IL_004b;
		IL_004b:
		if (m_firstPersonAnimator == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		m_firstPersonAnimator.SetBool(c14f324b46e75f970614639298e7fb508, c900d0d686d681543cac68c31d8025cd5);
		return m_firstPersonAnimator.GetBool(c14f324b46e75f970614639298e7fb508) == c900d0d686d681543cac68c31d8025cd5;
	}

	public bool cb306162a8032e25a87c8a3cfc617cc8c(string c14f324b46e75f970614639298e7fb508, float c900d0d686d681543cac68c31d8025cd5)
	{
		if (!(m_playerThirdAnimManager == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (!(m_firstPersonAnimator == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
			{
				goto IL_004b;
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
		}
		cd56255baa45e535edc0ee1919542bcd5();
		goto IL_004b;
		IL_004b:
		if (m_firstPersonAnimator == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		m_firstPersonAnimator.SetFloat(c14f324b46e75f970614639298e7fb508, c900d0d686d681543cac68c31d8025cd5);
		return m_firstPersonAnimator.GetFloat(c14f324b46e75f970614639298e7fb508) == c900d0d686d681543cac68c31d8025cd5;
	}

	public bool c9c32305edac3ba2dd35df159edcc9261(string c14f324b46e75f970614639298e7fb508, int c900d0d686d681543cac68c31d8025cd5)
	{
		if (!(m_playerThirdAnimManager == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (!(m_firstPersonAnimator == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
			{
				goto IL_004b;
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
		}
		cd56255baa45e535edc0ee1919542bcd5();
		goto IL_004b;
		IL_004b:
		if (m_firstPersonAnimator == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		m_firstPersonAnimator.SetInteger(c14f324b46e75f970614639298e7fb508, c900d0d686d681543cac68c31d8025cd5);
		return m_firstPersonAnimator.GetInteger(c14f324b46e75f970614639298e7fb508) == c900d0d686d681543cac68c31d8025cd5;
	}

	public bool c3d9b4eff5870c892f4ddc3194de2a437(int c5e08b87896fbbb40d17a3a54c8c33b79, float cc21ce2443736be6a8bbb1b46a3fcabf1)
	{
		if (!(m_playerThirdAnimManager == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (!(m_firstPersonAnimator == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
			{
				goto IL_004b;
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
		cd56255baa45e535edc0ee1919542bcd5();
		goto IL_004b;
		IL_004b:
		if (m_firstPersonAnimator == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		if (m_firstPersonAnimator.layerCount >= c5e08b87896fbbb40d17a3a54c8c33b79)
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
			if (c5e08b87896fbbb40d17a3a54c8c33b79 >= 0)
			{
				m_firstPersonAnimator.SetLayerWeight(c5e08b87896fbbb40d17a3a54c8c33b79, cc21ce2443736be6a8bbb1b46a3fcabf1);
				return true;
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
		return false;
	}

	public bool ce9377d4ea033ce108a7c8cf1269263fc(int c5e08b87896fbbb40d17a3a54c8c33b79, float cc21ce2443736be6a8bbb1b46a3fcabf1)
	{
		if (m_thirdPersonAnimator == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (5)
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
			m_thirdPersonAnimator = m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2;
		}
		if (m_thirdPersonAnimator == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		if (m_thirdPersonAnimator.layerCount >= c5e08b87896fbbb40d17a3a54c8c33b79)
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
			if (c5e08b87896fbbb40d17a3a54c8c33b79 >= 0)
			{
				m_thirdPersonAnimator.SetLayerWeight(c5e08b87896fbbb40d17a3a54c8c33b79, cc21ce2443736be6a8bbb1b46a3fcabf1);
				return true;
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				break;
			}
		}
		return false;
	}

	public AnimatorStateInfo ca18251f94792b5764ab1a1024333abfb(bool c1f59afd637222208de7bd8abe7465b00, int c5e08b87896fbbb40d17a3a54c8c33b79)
	{
		if (c1f59afd637222208de7bd8abe7465b00)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					{
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						if (!(m_playerThirdAnimManager == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
							if (!(m_firstPersonAnimator == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
							{
								goto IL_0058;
							}
							while (true)
							{
								switch (5)
								{
								case 0:
									continue;
								}
								break;
							}
						}
						cd56255baa45e535edc0ee1919542bcd5();
						goto IL_0058;
					}
					IL_0058:
					return m_firstPersonAnimator.GetCurrentAnimatorStateInfo(c5e08b87896fbbb40d17a3a54c8c33b79);
				}
			}
		}
		if (m_thirdPersonAnimator == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_thirdPersonAnimator = m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2;
		}
		return m_thirdPersonAnimator.GetCurrentAnimatorStateInfo(c5e08b87896fbbb40d17a3a54c8c33b79);
	}

	public bool c06739986a9474e249bf49d8330a68ce0(string c14f324b46e75f970614639298e7fb508, bool c900d0d686d681543cac68c31d8025cd5)
	{
		if (m_thirdPersonAnimator == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_thirdPersonAnimator = m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2;
		}
		if (m_thirdPersonAnimator == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		m_thirdPersonAnimator.SetBool(c14f324b46e75f970614639298e7fb508, c900d0d686d681543cac68c31d8025cd5);
		return m_thirdPersonAnimator.GetBool(c14f324b46e75f970614639298e7fb508) == c900d0d686d681543cac68c31d8025cd5;
	}

	public bool c4363c9ee832d0d0155375ca61d99d853(string c14f324b46e75f970614639298e7fb508, float c900d0d686d681543cac68c31d8025cd5)
	{
		if (m_thirdPersonAnimator == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_thirdPersonAnimator = m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2;
		}
		if (m_thirdPersonAnimator == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		m_thirdPersonAnimator.SetFloat(c14f324b46e75f970614639298e7fb508, c900d0d686d681543cac68c31d8025cd5);
		return m_thirdPersonAnimator.GetFloat(c14f324b46e75f970614639298e7fb508) == c900d0d686d681543cac68c31d8025cd5;
	}

	public bool c465df8067e466589c87295b07efa8e7d(string c14f324b46e75f970614639298e7fb508, int c900d0d686d681543cac68c31d8025cd5)
	{
		if (m_thirdPersonAnimator == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_thirdPersonAnimator = m_AnimationManagerFSM.ccaaf181e61e5f9e050ba82237ed111a2;
		}
		if (m_thirdPersonAnimator == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		m_thirdPersonAnimator.SetInteger(c14f324b46e75f970614639298e7fb508, c900d0d686d681543cac68c31d8025cd5);
		return m_thirdPersonAnimator.GetInteger(c14f324b46e75f970614639298e7fb508) == c900d0d686d681543cac68c31d8025cd5;
	}

	public void c72b3c27a6fa6d78ff19fb51b8ce6fa72(bool c5774dbf644199ba27a198318d2b320cb)
	{
		if (m_playerThirdAnimManager == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			cd56255baa45e535edc0ee1919542bcd5();
		}
		m_playerThirdAnimManager.c72b3c27a6fa6d78ff19fb51b8ce6fa72(c5774dbf644199ba27a198318d2b320cb);
	}

	public virtual void OnMecanimAnimOver(MecanimAnimationID _id)
	{
	}

	public VFXManager ccdbbc6879c7efc53e81b9c2fbaceead9()
	{
		return c4a92afe664b68f75e668116af19e84e9().cb1bc1ed3579c8c5bda5a8a3dbd112ea9;
	}

	public EntityPlayer c4a92afe664b68f75e668116af19e84e9()
	{
		if (m_entityPlayer == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_entityPlayer = m_AnimationManagerFSM.m_entity as EntityPlayer;
		}
		return m_entityPlayer;
	}
}
