using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using A;
using UnityEngine;

public class MarkManager : MonoBehaviour
{
	public enum MarkPhase
	{
		Marking = 0,
		Holding = 1,
		Decay = 2
	}

	public enum ESlowdownType
	{
		BeingMarking = 0,
		InMarkState = 1
	}

	public class BroadcastMarkedInfo
	{
		public int m_entity_id;

		public int m_mark_level;

		public float m_progress_mark;

		public MarkPhase m_phase = MarkPhase.Decay;

		private Entity m_entity;

		public BroadcastMarkedInfo(int cbd26e39b8b1d5b0abffedcac5d1ecc8f, int cc94be3685c24bbbca06b26f5dc51a92c, float ca30f1ce8175fcc366fda26a89783560a, MarkPhase cedbe4529e02a385561d13fa067c5b14e)
		{
			m_entity_id = cbd26e39b8b1d5b0abffedcac5d1ecc8f;
			m_mark_level = cc94be3685c24bbbca06b26f5dc51a92c;
			m_progress_mark = ca30f1ce8175fcc366fda26a89783560a;
			m_phase = cedbe4529e02a385561d13fa067c5b14e;
		}

		public static int c5c3c145d54edc727770887f87bea1217()
		{
			return 16;
		}

		public Entity c66b232dbebded7c7e9a89c1e8bd84689()
		{
			if (m_entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				m_entity = BadAssNetworkView.cd45cbc6284a89fa5c2b29c7ad9718528(m_entity_id);
			}
			return m_entity;
		}

		[SpecialName]
		public static byte[] c00ae05b9ced94c9fc5f4be4892e6192b(BroadcastMarkedInfo c00bb86ffbeb6764fbe60d7b64859db7f)
		{
			MemoryStream memoryStream = new MemoryStream();
			memoryStream.Write(BitConverter.GetBytes(c00bb86ffbeb6764fbe60d7b64859db7f.m_entity_id), 0, 4);
			memoryStream.Write(BitConverter.GetBytes(c00bb86ffbeb6764fbe60d7b64859db7f.m_mark_level), 0, 4);
			memoryStream.Write(BitConverter.GetBytes(c00bb86ffbeb6764fbe60d7b64859db7f.m_progress_mark), 0, 4);
			memoryStream.Write(BitConverter.GetBytes((int)c00bb86ffbeb6764fbe60d7b64859db7f.m_phase), 0, 4);
			return memoryStream.ToArray();
		}

		[SpecialName]
		public static BroadcastMarkedInfo c00ae05b9ced94c9fc5f4be4892e6192b(byte[] c591d56a94543e3559945c497f37126c4)
		{
			BroadcastMarkedInfo broadcastMarkedInfo = new BroadcastMarkedInfo(0, 0, 0f, MarkPhase.Marking);
			MemoryStream memoryStream = new MemoryStream();
			memoryStream.Write(c591d56a94543e3559945c497f37126c4, 0, c591d56a94543e3559945c497f37126c4.Length);
			memoryStream.Seek(0L, SeekOrigin.Begin);
			byte[] array = ce2f159fe707a376b497f666c368f15ed.c0a0cdf4a196914163f7334d9b0781a04(4);
			memoryStream.Read(array, 0, 4);
			broadcastMarkedInfo.m_entity_id = BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, 4);
			broadcastMarkedInfo.m_mark_level = BitConverter.ToInt32(array, 0);
			memoryStream.Read(array, 0, 4);
			broadcastMarkedInfo.m_progress_mark = BitConverter.ToSingle(array, 0);
			memoryStream.Read(array, 0, 4);
			broadcastMarkedInfo.m_phase = (MarkPhase)BitConverter.ToInt32(array, 0);
			return broadcastMarkedInfo;
		}
	}

	private static MarkManager s_instance;

	public MarkTitleController m_titleCrl;

	private MarkBroadcast m_broadcast;

	public ESlowdownType m_slowdown_type;

	public Dictionary<int, BroadcastMarkedInfo> m_broadcastBuffer = new Dictionary<int, BroadcastMarkedInfo>();

	[HideInInspector]
	public float m_hold_duration = 5f;

	[HideInInspector]
	public float m_decay_duration = 5f;

	[HideInInspector]
	public float m_baseMarkLength = 1f;

	[HideInInspector]
	public float m_powercoeff_markvelocity = 1.15f;

	[HideInInspector]
	public float m_dmgbonus_perlevel = 0.2f;

	private Dictionary<int, BroadcastMarkedInfo> m_receiveBuffer = new Dictionary<int, BroadcastMarkedInfo>();

	public static MarkManager c5ee19dc8d4cccf5ae2de225410458b86
	{
		get
		{
			return s_instance;
		}
	}

	public MarkBroadcast c014acbe8ef686a449993ded4048fbb8f
	{
		get
		{
			return m_broadcast;
		}
	}

	private void Awake()
	{
		s_instance = this;
		m_titleCrl = new MarkTitleController();
		m_broadcast = GetComponent<MarkBroadcast>();
	}

	private void LateUpdate()
	{
		m_titleCrl.OnLateUpdate();
	}

	public void OnGetMarkedInfo(BroadcastMarkedInfo _info)
	{
		m_receiveBuffer[_info.m_entity_id] = _info;
		m_titleCrl.OnGetTitleInfo(_info);
	}

	public bool cbab2dad8aaf1583a05752c4116f9b8c4(Entity c6e853f452cc819532893b63942b8ed3d)
	{
		return false;
	}

	public BroadcastMarkedInfo cbc9dccee600d372155410dce2062bf8d()
	{
		BroadcastMarkedInfo result = null;
		if (MarkCollect.c5ee19dc8d4cccf5ae2de225410458b86.c1368da069da66a9f601698db875daa18())
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
			int key = c06ca0e618478c23eba3419653a19760f<TargetingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_aimedEntity.cc7403315505256d19a7b92aa614a8f10();
			if (m_receiveBuffer.ContainsKey(key))
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
				result = m_receiveBuffer[key];
			}
		}
		return result;
	}
}
