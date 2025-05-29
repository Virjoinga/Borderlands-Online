using A;
using Core;
using Photon;
using UnityEngine;

public class ShootingTestMenu : Photon.MonoBehaviour, IDamageListener
{
	public Rect m_WindowRect = new Rect(0f, 100f, 120f, 100f);

	public int m_WindowId = 102;

	public bool m_Visible = true;

	public bool m_autoAiming = true;

	public bool m_autoShooting = true;

	public bool m_noBulletSpray = true;

	public bool m_started;

	public int m_maxShot = 10;

	public int m_bulletShot;

	public float m_feedback;

	private int m_hitcount;

	private double interval = 1.0;

	private double lastshot;

	private EntityPlayer m_entityPlayer;

	private EntityWeapon m_weapon;

	private TargetingManager m_targeting;

	private PlayerController m_playerController;

	private DamageManager m_DamageManager;

	public void Start()
	{
	}

	public void c6c6cbb0045146f9b0a890f787bad6e4d()
	{
		if (m_DamageManager == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (DamageManager.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				m_DamageManager = DamageManager.c5ee19dc8d4cccf5ae2de225410458b86;
				m_DamageManager.c5c5b57d23b5b73637a6ed6524fed2be5(this);
			}
		}
		if (m_targeting == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_targeting = c06ca0e618478c23eba3419653a19760f<TargetingManager>.c5ee19dc8d4cccf5ae2de225410458b86;
		}
		if (m_entityPlayer == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().c66b232dbebded7c7e9a89c1e8bd84689() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						m_entityPlayer = (EntityPlayer)c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().c66b232dbebded7c7e9a89c1e8bd84689();
					}
				}
			}
		}
		if (m_playerController == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (m_entityPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				m_playerController = m_entityPlayer.GetComponent<PlayerController>();
			}
		}
		if (m_entityPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_weapon = m_entityPlayer.c3941dac8608f650ceb15dc36294a741c();
		}
		if (!m_started)
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
			if (!(m_playerController != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (!m_autoShooting)
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
					if (!((double)Time.time > lastshot + interval))
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
						if (m_bulletShot == m_maxShot)
						{
							while (true)
							{
								switch (6)
								{
								case 0:
									break;
								default:
								{
									object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(7);
									array[0] = "shooting Auto Testing finished bulletShot:";
									array[1] = m_bulletShot;
									array[2] = " hitRate:";
									array[3] = (float)m_hitcount / (float)m_bulletShot * 100f;
									array[4] = "% feedback:";
									array[5] = m_feedback;
									array[6] = "s";
									DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, string.Concat(array));
									Reset();
									return;
								}
								}
							}
						}
						lastshot = Time.time;
						if (!m_playerController.c8a149fd030504a4c5ee8f69d01a26c52())
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
							m_bulletShot++;
							return;
						}
					}
				}
			}
		}
	}

	private void Reset()
	{
		m_started = false;
		m_bulletShot = 0;
		m_feedback = 0f;
		m_hitcount = 0;
	}

	private void c4bd5a8f1ab252d8d652aff399a8dc225(int c97b150c6da90934b2c22938f6cd271c1)
	{
		m_autoAiming = GUILayout.Toggle(m_autoAiming, "AutoAiming", c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		m_autoShooting = GUILayout.Toggle(m_autoShooting, "AutoShooting", c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		m_noBulletSpray = GUILayout.Toggle(m_noBulletSpray, "NoBulletSpray", c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		GUILayout.Label(string.Format("maxShot: {0}", m_maxShot), c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		if (!m_started)
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
			m_started = GUILayout.Button("Start", c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		}
		else
		{
			m_started ^= GUILayout.Button("Stop", c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		}
		if (GUILayout.Button("Reset", c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0)))
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
			Reset();
		}
		GUILayout.Label(string.Format("bulletShot: {0}", m_bulletShot), c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		float num;
		if (m_bulletShot == 0)
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
			num = 0f;
		}
		else
		{
			num = (float)m_hitcount / (float)m_bulletShot * 100f;
		}
		GUILayout.Label(string.Format("hitRate: {0}%", num), c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		GUILayout.Label(string.Format("feedback: {0}s", m_feedback), c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		if (m_targeting != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_targeting.m_autoAiming = m_autoAiming;
		}
		if (m_weapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (m_weapon.m_noBulletSpray != m_noBulletSpray)
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
				m_weapon.m_noBulletSpray = m_noBulletSpray;
				object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(2);
				array[0] = m_weapon.cc7403315505256d19a7b92aa614a8f10();
				array[1] = m_noBulletSpray;
				base.photonView.c19fd12ed98be2a9174d53644dc9757c8("RPC_RequestWeaponNoSpray", PhotonTargets.MasterClient, array);
			}
		}
		if (GUI.changed)
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
			m_WindowRect.height = 100f;
		}
		GUI.DragWindow();
	}

	public void OnDamaged(DamageContext context)
	{
		if (!m_started)
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
			if (context.m_damageInfo.m_from != m_weapon.m_owner.cc7403315505256d19a7b92aa614a8f10())
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
				m_hitcount++;
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, "SbGetDamage time:" + ((double)Time.time - lastshot));
				m_feedback += ((float)((double)Time.time - lastshot) - m_feedback) / (float)m_hitcount;
				return;
			}
		}
	}

	public void OnEntityKill(KillContext context)
	{
	}
}
