using System;
using System.IO;
using A;
using Photon;

public class MarkCollect : MonoBehaviour
{
	public enum SyncType
	{
		Unknown = 0,
		Never = 1,
		Sync = 2
	}

	public class MarkInfoLocal
	{
		public int m_networkId;

		public float m_deltatime;

		public int m_frame;

		private static byte[] buff_int = ce2f159fe707a376b497f666c368f15ed.c0a0cdf4a196914163f7334d9b0781a04(4);

		private static byte[] buff_float = ce2f159fe707a376b497f666c368f15ed.c0a0cdf4a196914163f7334d9b0781a04(4);

		public MarkInfoLocal(int cbd26e39b8b1d5b0abffedcac5d1ecc8f, float c60c59086c805e1f2f51383ae30aa35bd, int c667e506ce7560efccdfc69a890e335af)
		{
			m_networkId = cbd26e39b8b1d5b0abffedcac5d1ecc8f;
			m_deltatime = c60c59086c805e1f2f51383ae30aa35bd;
			m_frame = c667e506ce7560efccdfc69a890e335af;
		}

		public byte[] c20939e41275dcfbb9a656b750e368707()
		{
			MemoryStream memoryStream = new MemoryStream();
			memoryStream.Write(BitConverter.GetBytes(m_networkId), 0, 4);
			memoryStream.Write(BitConverter.GetBytes(m_deltatime), 0, 4);
			memoryStream.Write(BitConverter.GetBytes(m_frame), 0, 4);
			return memoryStream.ToArray();
		}

		public static MarkInfoLocal ce5a3dff44878e0c3e9705ed6d8afe9e1(byte[] c08aa2bc5ca9e8cbf786b2856f142bb58)
		{
			MarkInfoLocal markInfoLocal = new MarkInfoLocal(0, 0f, 0);
			MemoryStream memoryStream = new MemoryStream();
			memoryStream.Write(c08aa2bc5ca9e8cbf786b2856f142bb58, 0, c08aa2bc5ca9e8cbf786b2856f142bb58.Length);
			memoryStream.Seek(0L, SeekOrigin.Begin);
			memoryStream.Read(buff_int, 0, 4);
			markInfoLocal.m_networkId = BitConverter.ToInt32(buff_int, 0);
			memoryStream.Read(buff_float, 0, 4);
			markInfoLocal.m_deltatime = BitConverter.ToSingle(buff_float, 0);
			memoryStream.Read(buff_int, 0, 4);
			markInfoLocal.m_frame = BitConverter.ToInt32(buff_int, 0);
			return markInfoLocal;
		}
	}

	private static MarkCollect s_instance;

	private SyncType m_synctype;

	private EntityPlayer m_localplayer;

	private HunterManage m_skill;

	private bool m_marked_lasttick;

	private int m_marked_id_lasttick;

	public static MarkCollect c5ee19dc8d4cccf5ae2de225410458b86
	{
		get
		{
			return s_instance;
		}
	}

	private void Awake()
	{
		s_instance = this;
	}

	private void Start()
	{
	}

	private void Update()
	{
		c3eed27616bd47fea0d458bc6f71bc54a();
		c7203199dacc247951e13b50d789d0c5b();
	}

	private void c3eed27616bd47fea0d458bc6f71bc54a()
	{
		if (m_synctype != 0)
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
			if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					m_localplayer = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().c66b232dbebded7c7e9a89c1e8bd84689() as EntityPlayer;
				}
			}
			if (!(m_localplayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
				{
					while (true)
					{
						switch (5)
						{
						case 0:
							break;
						default:
							m_synctype = SyncType.Never;
							return;
						}
					}
				}
				m_skill = m_localplayer.ccaf53be8b86b7016efd6970ff8c92ad3 as HunterManage;
				int synctype;
				if (m_skill != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					synctype = 2;
				}
				else
				{
					synctype = 1;
				}
				m_synctype = (SyncType)synctype;
				return;
			}
		}
	}

	private void c7203199dacc247951e13b50d789d0c5b()
	{
		bool flag = c1368da069da66a9f601698db875daa18();
		if (flag != m_marked_lasttick)
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
			int num;
			if (flag)
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
				num = c06ca0e618478c23eba3419653a19760f<TargetingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_aimedEntity.cc7403315505256d19a7b92aa614a8f10();
			}
			else
			{
				num = m_marked_id_lasttick;
			}
			int id = num;
			OnMarkStateChanged(id, flag);
		}
		else if (flag)
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
			if (m_marked_lasttick)
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
				if (c06ca0e618478c23eba3419653a19760f<TargetingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_aimedEntity.cc7403315505256d19a7b92aa614a8f10() != m_marked_id_lasttick)
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
					OnMarkStateChanged(m_marked_id_lasttick, false);
					OnMarkStateChanged(c06ca0e618478c23eba3419653a19760f<TargetingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_aimedEntity.cc7403315505256d19a7b92aa614a8f10(), true);
				}
			}
		}
		m_marked_lasttick = flag;
		int marked_id_lasttick;
		if (flag)
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
			marked_id_lasttick = c06ca0e618478c23eba3419653a19760f<TargetingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_aimedEntity.cc7403315505256d19a7b92aa614a8f10();
		}
		else
		{
			marked_id_lasttick = 0;
		}
		m_marked_id_lasttick = marked_id_lasttick;
		if (!flag)
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
			c462fe1a64a37daab5e61f688d9a61e7f("HunterSkill_Plane_Aiming");
			return;
		}
	}

	public bool c1368da069da66a9f601698db875daa18()
	{
		bool result = false;
		if (m_synctype == SyncType.Sync)
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
			if (m_skill.c41b7b1203f98ea7135c9a65278b49c7f())
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
				if ((bool)c06ca0e618478c23eba3419653a19760f<TargetingManager>.c5ee19dc8d4cccf5ae2de225410458b86)
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
					if ((bool)c06ca0e618478c23eba3419653a19760f<TargetingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_aimedEntity)
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
						if (c06ca0e618478c23eba3419653a19760f<TargetingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_aimedEntity.ceb10167333758220ffb9bc66317ad763() != m_localplayer.ceb10167333758220ffb9bc66317ad763())
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
							result = true;
						}
					}
				}
			}
		}
		return result;
	}

	public bool c1368da069da66a9f601698db875daa18(Entity ce4a0d48c7734206432c9cc9470156e6f)
	{
		int result;
		if (c1368da069da66a9f601698db875daa18())
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
			result = ((c06ca0e618478c23eba3419653a19760f<TargetingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_aimedEntity == ce4a0d48c7734206432c9cc9470156e6f) ? 1 : 0);
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public void OnMarkStateChanged(int _id, bool _ismark)
	{
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(2);
		array[0] = _id;
		array[1] = _ismark;
		base.photonView.c19fd12ed98be2a9174d53644dc9757c8("RPC_L2H_MarkCollect", PhotonTargets.MasterClient, array);
	}

	public void OnMarkLevelChanged(Entity _marked)
	{
		if (!c1368da069da66a9f601698db875daa18(_marked))
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
			c462fe1a64a37daab5e61f688d9a61e7f("HunterSkill_Plane_Mark");
			return;
		}
	}

	private void c462fe1a64a37daab5e61f688d9a61e7f(string c0533a124055b814acfb94c1fd590de66)
	{
		if (m_localplayer == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_localplayer = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().c66b232dbebded7c7e9a89c1e8bd84689() as EntityPlayer;
		}
		m_localplayer.ccdbbc6879c7efc53e81b9c2fbaceead9().m_audioCtl.TriggerEventByName(c0533a124055b814acfb94c1fd590de66);
	}

	public void cedc6ad9f42294f43a5568d1e54f44ea7(Entity c6e853f452cc819532893b63942b8ed3d)
	{
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c6e853f452cc819532893b63942b8ed3d.cc7403315505256d19a7b92aa614a8f10();
		base.photonView.c19fd12ed98be2a9174d53644dc9757c8("RPC_L2H_AutoMark", PhotonTargets.MasterClient, array);
	}
}
