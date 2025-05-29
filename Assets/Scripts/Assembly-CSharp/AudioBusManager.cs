using System.Collections.Generic;
using A;
using Core;
using UnityEngine;

[ExecuteInEditMode]
public class AudioBusManager : UniqueAudioObjectManager<AudioBus>
{
	public enum BusDescriptor
	{
		Master = 0,
		BEGIN = 0,
		Music = 1,
		SFX = 2,
		END = 3
	}

	private AudioBus m_master;

	private AudioBus[] m_accessibleBuses;

	private static readonly string DEFAULT_RESOURCE_NAME = "BusConfig/AudioBusConfigure";

	public string c9d7e015f91b017512a821ca8c7a969a1
	{
		get
		{
			return AudioResourceHelper.cbd60f3731d2ac132cb80b0c363564a68(DEFAULT_RESOURCE_NAME);
		}
	}

	public AudioBus cf545464dc99cdf36da32313ba7325675()
	{
		return m_master;
	}

	public override void c89e353632385d799ae18926f4d1896ab()
	{
		AudioBusConfigureData.c89e353632385d799ae18926f4d1896ab(m_master, c9d7e015f91b017512a821ca8c7a969a1);
		c776419f3a108ab6d0bafb6b0ec259e3d();
	}

	public override void c38aeacc59bd560b59403945ae7996d79()
	{
		base.c38aeacc59bd560b59403945ae7996d79();
		m_master = AudioBusConfigureData.c38aeacc59bd560b59403945ae7996d79(DEFAULT_RESOURCE_NAME);
		OnBusStructureUpdated();
		c776419f3a108ab6d0bafb6b0ec259e3d();
	}

	public void OnBusStructureUpdated()
	{
		base.c1805d5170a48b3a8510e57fd9095ce11.Clear();
		base.c2541c04c6cdfaab2b924200fcd93b628.Clear();
		if (m_master == null)
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
			c6f49409b2929e4f0c4160ced1e7704fb(m_master, string.Empty);
			return;
		}
	}

	private void c776419f3a108ab6d0bafb6b0ec259e3d()
	{
		if (m_accessibleBuses == null)
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
			m_accessibleBuses = c32f72ca3c9fbc3e7725a72da40c5ad36.c0a0cdf4a196914163f7334d9b0781a04(3);
		}
		m_accessibleBuses[0] = m_master;
		for (int i = 1; i < 3; i++)
		{
			BusDescriptor busDescriptor = (BusDescriptor)i;
			int num = base.c2541c04c6cdfaab2b924200fcd93b628.IndexOf(busDescriptor.ToString());
			bool flag = -1 != num;
			if (!flag)
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
				DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Audio, "Can't find accessible audio bus: " + busDescriptor);
			}
			AudioBus audioBus;
			if (flag)
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
				audioBus = base.c1805d5170a48b3a8510e57fd9095ce11[num];
			}
			else
			{
				audioBus = c6e355047dbabc7cd22746ab16419c015.c7088de59e49f7108f520cf7e0bae167e;
			}
			AudioBus audioBus2 = audioBus;
			m_accessibleBuses[i] = audioBus2;
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	protected override void c6f49409b2929e4f0c4160ced1e7704fb(AudioBus cfd5a27176a32d67f3d4a39549a377bf8, string c26bc9278762c84e1e76177f085674c7e)
	{
		base.c6f49409b2929e4f0c4160ced1e7704fb(cfd5a27176a32d67f3d4a39549a377bf8, c26bc9278762c84e1e76177f085674c7e);
		List<AudioBus> list = cfd5a27176a32d67f3d4a39549a377bf8.c2a74db806bdb8dc576986b17d992fbe5();
		for (int i = 0; i < list.Count; i++)
		{
			c6f49409b2929e4f0c4160ced1e7704fb(list[i], c26bc9278762c84e1e76177f085674c7e);
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
			return;
		}
	}

	public void cdd38a19c1260df758b2e7faf25fbd945()
	{
		for (int i = 0; i < base.c1805d5170a48b3a8510e57fd9095ce11.Count; i++)
		{
			base.c1805d5170a48b3a8510e57fd9095ce11[i].c62213f4b2fedcce92a97dec5ed56d6b0();
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
			return;
		}
	}

	private AudioBus c3facc767beb8d74f5ad31823245234b3(BusDescriptor c67dfa8ca0787e85c2023f11366be8833)
	{
		AudioBus audioBus = m_accessibleBuses[(int)c67dfa8ca0787e85c2023f11366be8833];
		if (audioBus == null)
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
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Audio, "Can't find accessible audio bus: " + c67dfa8ca0787e85c2023f11366be8833);
		}
		return audioBus;
	}

	public void cdec556f45be085037f7dd85ddc1b9e24(BusDescriptor c67dfa8ca0787e85c2023f11366be8833, float c0bafcaa72bb4a6f68c94c91e9a95f5f3)
	{
		AudioBus audioBus = c3facc767beb8d74f5ad31823245234b3(c67dfa8ca0787e85c2023f11366be8833);
		if (audioBus == null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			audioBus.c29d0bac2e9f266c244ba1ee8613309ba().c26262bae53d5c2c52bddfedd7d419779(c0bafcaa72bb4a6f68c94c91e9a95f5f3);
			return;
		}
	}

	public float c745e95942654d117331a1dbd87b29fe1(BusDescriptor c67dfa8ca0787e85c2023f11366be8833)
	{
		AudioBus audioBus = c3facc767beb8d74f5ad31823245234b3(c67dfa8ca0787e85c2023f11366be8833);
		float result;
		if (audioBus != null)
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
			result = audioBus.c29d0bac2e9f266c244ba1ee8613309ba().cc0a42a0f0722f4d51045b776d01ec4fc();
		}
		else
		{
			result = 0f;
		}
		return result;
	}
}
