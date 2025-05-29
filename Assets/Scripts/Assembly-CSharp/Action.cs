using A;
using UnityEngine;

public class Action
{
	public class ActionMessage
	{
		public bool m_actionOrCut { get; private set; }

		public float m_time { get; private set; }

		public double m_TimeDelayInNetwork { get; private set; }

		public double m_networkTimeStamp { get; private set; }

		public int m_frameNum { get; private set; }

		public int m_param { get; private set; }

		public ActionMessage(bool cdc3280536e376bb9f8bf34e1bc175d87, float cad9f703d862495149cd6bddd080f050b, double cbad8ba0203043c3416d7afaeb775e965, double c6e2e9c86b5afb152bf0dce76c546a4ef, int c437e4713013a8c97d781d2ab51a4b35e, int cd22aa6735988e8e65acbd503f3870e3e)
		{
			m_actionOrCut = cdc3280536e376bb9f8bf34e1bc175d87;
			m_time = cad9f703d862495149cd6bddd080f050b;
			m_TimeDelayInNetwork = c6e2e9c86b5afb152bf0dce76c546a4ef;
			m_frameNum = c437e4713013a8c97d781d2ab51a4b35e;
			m_param = cd22aa6735988e8e65acbd503f3870e3e;
			m_networkTimeStamp = cbad8ba0203043c3416d7afaeb775e965;
		}
	}

	private RingBuffer m_actionBuffer = new RingBuffer(10, false);

	protected Entity m_entity;

	private bool m_isEntityAction;

	private bool m_keepAction;

	private bool m_isActionRunning;

	private bool m_isLocalAction;

	protected ActionMessage LastActionMessage;

	protected int m_param;

	public float m_actionDelay { get; private set; }

	public virtual void Start(Entity entity)
	{
		m_entity = entity;
		m_actionDelay = 0f;
		AuthoritativeActionManager.c5ee19dc8d4cccf5ae2de225410458b86.c1349ec840ae297d0b9eef45794c67d3a(this, entity);
	}

	public virtual void c365a77c63c91e13de4ca19c9a953aa5e(Entity c5d720f6d007abb0c4a21d6a654e405bb)
	{
		AuthoritativeActionManager.c5ee19dc8d4cccf5ae2de225410458b86.c82e3f68cda0201accfeb810a507077d0(this);
		m_entity = c72d1b2b1b60b723ae8df41127652adb5.c7088de59e49f7108f520cf7e0bae167e;
	}

	public void c6c6cbb0045146f9b0a890f787bad6e4d()
	{
		if (!m_keepAction)
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
			if (m_isEntityAction)
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
				cb41ae3ef91dbe45c7cabfc04d71509a6();
			}
		}
		m_keepAction = false;
		c917d205e187ce7fc92dde9b2575c7e91();
	}

	private void c917d205e187ce7fc92dde9b2575c7e91()
	{
		LastActionMessage = (ActionMessage)m_actionBuffer.c588e7dbcd383d8230b2d83d7b44af23b(0);
		if (LastActionMessage != null)
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
			Entity entity = m_entity;
			if (m_entity is EntityWeapon)
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
				entity = (m_entity as EntityWeapon).m_owner;
			}
			EntityPlayer entityPlayer = entity as EntityPlayer;
			if ((bool)entityPlayer)
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
				bool flag = true;
				EntityPlayer relatedPlayer = entityPlayer.m_relatedPlayer;
				if (relatedPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					if (NetworkManager.c449802e708e91a9150466060fbab2ad6())
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
						int frameNum = relatedPlayer.cbe65aaa5561a0ba002aca1f0c8498077().currentInput.m_frameNum;
						int num;
						if (LastActionMessage.m_frameNum > frameNum)
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
							num = ((frameNum == 0) ? 1 : 0);
						}
						else
						{
							num = 1;
						}
						flag = (byte)num != 0;
					}
				}
				if (m_isLocalAction)
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
					flag = true;
				}
				if (flag)
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
					m_actionDelay = 0f;
					if (!m_isLocalAction)
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
						m_actionDelay = Time.time - LastActionMessage.m_time + (float)LastActionMessage.m_TimeDelayInNetwork;
						if ((bool)relatedPlayer)
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
							m_actionDelay += InterpolateManager.c626781f3af95678da9e24a0af671368d() + NetworkManager.c802128e3d024dd79aaf8dc5f4b18f6a0(relatedPlayer.cd95354b53e674ec7dc9594e66e4d316f().m_id) / 2f;
						}
					}
					if (!m_isActionRunning)
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
						if (LastActionMessage.m_actionOrCut)
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
							m_param = LastActionMessage.m_param;
							c413183a79233cd0411af23b0f0c942f4();
						}
					}
					if (m_isActionRunning)
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
						if (!LastActionMessage.m_actionOrCut)
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
							cc69f8e9734cb68d6d47cf096f99df02b();
						}
					}
					m_isActionRunning = LastActionMessage.m_actionOrCut;
					m_actionBuffer.c7605b6a8df360621e4eb06fe0b47814b();
				}
			}
			else
			{
				float num2 = 0f;
				if (m_isLocalAction)
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
					num2 = Mathf.Min(NetworkManager.c339b3c229d7f882ba09af8a661a021e8(), 1f);
				}
				if (Time.time - LastActionMessage.m_time > num2)
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
					if (!m_isActionRunning)
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
						if (LastActionMessage.m_actionOrCut)
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
							m_param = LastActionMessage.m_param;
							c413183a79233cd0411af23b0f0c942f4();
						}
					}
					if (m_isActionRunning)
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
						if (!LastActionMessage.m_actionOrCut)
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
							cc69f8e9734cb68d6d47cf096f99df02b();
						}
					}
					m_isActionRunning = LastActionMessage.m_actionOrCut;
					m_actionBuffer.c7605b6a8df360621e4eb06fe0b47814b();
				}
			}
		}
		if (!m_isActionRunning)
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
			c5c08725571cbae704deb427cb93c8e9b();
			return;
		}
	}

	public virtual void c99ba9c13b5a9e792c3b892f32759fc1c(int cd22aa6735988e8e65acbd503f3870e3e)
	{
		AuthoritativeActionManager.c5ee19dc8d4cccf5ae2de225410458b86.c99ba9c13b5a9e792c3b892f32759fc1c(cedd6df992c20da839c6da89aebf78bea(), m_entity, cd22aa6735988e8e65acbd503f3870e3e);
	}

	public void cd91d39f37531b5cbfdda0b9a40a28e12(int cd22aa6735988e8e65acbd503f3870e3e)
	{
		if (!m_isEntityAction)
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
			AuthoritativeActionManager.c5ee19dc8d4cccf5ae2de225410458b86.cd91d39f37531b5cbfdda0b9a40a28e12(cedd6df992c20da839c6da89aebf78bea(), m_entity, cd22aa6735988e8e65acbd503f3870e3e);
			m_isEntityAction = true;
		}
		m_keepAction = true;
	}

	private void cb41ae3ef91dbe45c7cabfc04d71509a6()
	{
		if (!m_isEntityAction)
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
			AuthoritativeActionManager.c5ee19dc8d4cccf5ae2de225410458b86.cb41ae3ef91dbe45c7cabfc04d71509a6(cedd6df992c20da839c6da89aebf78bea(), m_entity, 0);
			m_isEntityAction = false;
			return;
		}
	}

	public virtual void OnStartAction(bool local, double networkTimestamp, double networkDelayTime, int frameCount, int param)
	{
		m_isLocalAction = local;
		m_actionBuffer.cd6aca5b3793f791cfc489609e675c90b(new ActionMessage(true, Time.time, networkTimestamp, networkDelayTime, frameCount, param));
	}

	public virtual void OnStopAction(bool local, double networkTimestamp, double networkDelayTime, int frameCount, int param)
	{
		m_isLocalAction = local;
		m_actionBuffer.cd6aca5b3793f791cfc489609e675c90b(new ActionMessage(false, Time.time, networkTimestamp, networkDelayTime, frameCount, param));
	}

	public virtual void OnSingleAction(bool local, double networkTimestamp, double networkDelayTime, int frameCount, int param)
	{
		m_isLocalAction = local;
		m_actionBuffer.cd6aca5b3793f791cfc489609e675c90b(new ActionMessage(true, Time.time, networkTimestamp, networkDelayTime, frameCount, param));
		m_actionBuffer.cd6aca5b3793f791cfc489609e675c90b(new ActionMessage(false, Time.time, networkTimestamp, networkDelayTime, frameCount, param));
	}

	public int cedd6df992c20da839c6da89aebf78bea()
	{
		return AuthoritativeActionManager.c5ee19dc8d4cccf5ae2de225410458b86.cedd6df992c20da839c6da89aebf78bea(this);
	}

	protected virtual void c5c08725571cbae704deb427cb93c8e9b()
	{
	}

	protected virtual void cc69f8e9734cb68d6d47cf096f99df02b()
	{
	}

	protected virtual void c413183a79233cd0411af23b0f0c942f4()
	{
	}
}
