using System;
using System.Runtime.CompilerServices;
using A;
using UnityEngine;
using XsdSettings;

public class FireTiming
{
	public delegate void Handler_BurstFire();

	public delegate void Handler_SingleFire(float _freq);

	public delegate void Handler_NoFire();

	private PlayerThirdPersonAnimationManagerFSM m_Owner;

	private float m_weapon_fireperiod;

	private float m_weapon_firefrequency = 1f;

	private float m_weapon_firestarttime;

	private bool m_ShotPending_last;

	private bool m_ShotPending_current;

	private bool m_firedInPreviousCycle;

	private Handler_BurstFire burstfire_handler;

	private Handler_SingleFire singlefire_handler;

	private Handler_NoFire nofire_handler;

	public event Handler_BurstFire c9a389dd79eaea383a5e989d84c81999e
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			burstfire_handler = (Handler_BurstFire)Delegate.Combine(burstfire_handler, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			burstfire_handler = (Handler_BurstFire)Delegate.Remove(burstfire_handler, value);
		}
	}

	public event Handler_SingleFire c749853ab2b0cf1752d83b5b74e1b5c8b
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			singlefire_handler = (Handler_SingleFire)Delegate.Combine(singlefire_handler, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			singlefire_handler = (Handler_SingleFire)Delegate.Remove(singlefire_handler, value);
		}
	}

	public event Handler_NoFire c8051c5853c2fcf9140b211bece88cbe8
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			nofire_handler = (Handler_NoFire)Delegate.Combine(nofire_handler, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			nofire_handler = (Handler_NoFire)Delegate.Remove(nofire_handler, value);
		}
	}

	public FireTiming(PlayerThirdPersonAnimationManagerFSM cf811c0d5de19d7fe22be8d61350b722d)
	{
		m_Owner = cf811c0d5de19d7fe22be8d61350b722d;
	}

	public void OnTriggerFire(float fireSpeed)
	{
		m_weapon_firefrequency = fireSpeed;
		m_weapon_fireperiod = 1f / m_weapon_firefrequency;
		m_ShotPending_current = true;
	}

	public void Update()
	{
		EntityWeapon entityWeapon = m_Owner.m_entity.c3941dac8608f650ceb15dc36294a741c();
		if (entityWeapon == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (1)
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
		WeaponType weaponType = entityWeapon.c83e548e5608cd7f222098a6966b16545();
		if (weaponType != 0)
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
			if (weaponType != WeaponType.CombatRifle)
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
				if (weaponType != WeaponType.RepeaterPistol)
				{
					cd5d2f7375439250bb1aaa7693391aa5e();
					return;
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
			}
		}
		bool flag = cced93747afb14e2409f7c3ac686f5ec7();
		if (m_firedInPreviousCycle)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					if (!flag)
					{
						while (true)
						{
							switch (2)
							{
							case 0:
								break;
							default:
								if (!c7e777222e47f1ee4717fef2f2dbc3ad9())
								{
									while (true)
									{
										switch (1)
										{
										case 0:
											break;
										default:
											m_Owner.cbcc9f13feb69381a684afb37e7174b1b();
											m_firedInPreviousCycle = false;
											return;
										}
									}
								}
								return;
							}
						}
					}
					return;
				}
			}
		}
		m_firedInPreviousCycle = flag;
	}

	public bool c7e777222e47f1ee4717fef2f2dbc3ad9()
	{
		return Time.time - m_weapon_firestarttime < m_weapon_fireperiod;
	}

	private void cd5d2f7375439250bb1aaa7693391aa5e()
	{
		if (!c7e777222e47f1ee4717fef2f2dbc3ad9())
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
			if (!m_ShotPending_last)
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
				if (!m_ShotPending_current)
				{
					if (nofire_handler != null)
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
						nofire_handler();
					}
					goto IL_009f;
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			m_weapon_firestarttime = Time.time;
			if (singlefire_handler != null)
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
				singlefire_handler(m_weapon_firefrequency);
			}
			m_Owner.cb9e2a49dfad452a80cafd1443a4c8914(false);
		}
		goto IL_009f;
		IL_009f:
		m_ShotPending_last = m_ShotPending_current;
		m_ShotPending_current = false;
	}

	private bool cced93747afb14e2409f7c3ac686f5ec7()
	{
		bool result = false;
		if (!c7e777222e47f1ee4717fef2f2dbc3ad9())
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
			if (m_ShotPending_last)
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
				m_weapon_firestarttime = Time.time;
				if (burstfire_handler != null)
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
					burstfire_handler();
				}
				m_Owner.cb9e2a49dfad452a80cafd1443a4c8914(true);
				result = true;
			}
			else if (m_ShotPending_current)
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
				if (m_Owner.m_entity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					EntityWeapon entityWeapon = ((EntityPlayer)m_Owner.m_entity).c3941dac8608f650ceb15dc36294a741c();
					if (entityWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						if (entityWeapon.c729ce3b5f48e0eac3a7ead97b1d02f8d().m_type != WeaponType.ShotGun)
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
							if (entityWeapon.c729ce3b5f48e0eac3a7ead97b1d02f8d().m_type != WeaponType.SniperRifle)
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
								m_weapon_firestarttime = Time.time;
								if (singlefire_handler != null)
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
									singlefire_handler(m_weapon_firefrequency);
								}
								m_Owner.cb9e2a49dfad452a80cafd1443a4c8914(false);
								result = true;
							}
						}
					}
				}
			}
			else if (nofire_handler != null)
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
				nofire_handler();
			}
		}
		m_ShotPending_last = m_ShotPending_current;
		m_ShotPending_current = false;
		return result;
	}
}
