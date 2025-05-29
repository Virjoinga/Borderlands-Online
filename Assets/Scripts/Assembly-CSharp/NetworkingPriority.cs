using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;

public class NetworkingPriority
{
	private class PriorityValue
	{
		public int evaluated;

		public int runtime;

		public PriorityValue(int c4f41a27a094ce0546f1a50b0fe77248f, int ce160171088689e058d452106bc9e252c)
		{
			evaluated = c4f41a27a094ce0546f1a50b0fe77248f;
			runtime = ce160171088689e058d452106bc9e252c;
		}
	}

	private static NetworkingPriority s_instance;

	public PhotonPlayer priorityInspector;

	private Dictionary<PhotonPlayer, Dictionary<PhotonView, PriorityValue>> priorityPerPlayer;

	private Dictionary<PhotonPlayer, List<PhotonView>> orderedPhotonViewPerPlayer;

	private int evaluatedPlayer;

	private PhotonPriority m_priority;

	[CompilerGenerated]
	private static Func<KeyValuePair<PhotonView, PriorityValue>, int> _003C_003Ef__am_0024cache6;

	public static NetworkingPriority c5ee19dc8d4cccf5ae2de225410458b86
	{
		get
		{
			if (s_instance == null)
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
				s_instance = new NetworkingPriority();
			}
			return s_instance;
		}
	}

	private NetworkingPriority()
	{
		PhotonPriority c36964cf41281414170f34ee68bef6c = default(PhotonPriority);
		c1d0b843fec37126c6b4b115d81b241f8.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
		m_priority = c36964cf41281414170f34ee68bef6c;
		base._002Ector();
		priorityPerPlayer = new Dictionary<PhotonPlayer, Dictionary<PhotonView, PriorityValue>>();
		orderedPhotonViewPerPlayer = new Dictionary<PhotonPlayer, List<PhotonView>>();
	}

	public void c6c6cbb0045146f9b0a890f787bad6e4d()
	{
		c848b83091aec1d2f4e6a0b802aeab3f6();
	}

	public List<PhotonView> c19f7095c6fdcb36d0b945dd757043fbe(PhotonPlayer cbc409c28882b371b394d25bd4774efa0)
	{
		if (priorityPerPlayer.ContainsKey(cbc409c28882b371b394d25bd4774efa0))
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					Dictionary<PhotonView, PriorityValue> source = priorityPerPlayer[cbc409c28882b371b394d25bd4774efa0];
					if (_003C_003Ef__am_0024cache6 == null)
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
						_003C_003Ef__am_0024cache6 = (KeyValuePair<PhotonView, PriorityValue> c9865517a0bb5b7f200aaa1a34e1890c6) => c9865517a0bb5b7f200aaa1a34e1890c6.Value.runtime;
					}
					IOrderedEnumerable<KeyValuePair<PhotonView, PriorityValue>> orderedEnumerable = source.OrderBy(_003C_003Ef__am_0024cache6);
					List<PhotonView> c7088de59e49f7108f520cf7e0bae167e = c74ea18673f006964a9c0815ab9d11915.c7088de59e49f7108f520cf7e0bae167e;
					if (!orderedPhotonViewPerPlayer.ContainsKey(cbc409c28882b371b394d25bd4774efa0))
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
						c7088de59e49f7108f520cf7e0bae167e = new List<PhotonView>();
						orderedPhotonViewPerPlayer[cbc409c28882b371b394d25bd4774efa0] = c7088de59e49f7108f520cf7e0bae167e;
					}
					else
					{
						c7088de59e49f7108f520cf7e0bae167e = orderedPhotonViewPerPlayer[cbc409c28882b371b394d25bd4774efa0];
					}
					c7088de59e49f7108f520cf7e0bae167e.Clear();
					IEnumerator<KeyValuePair<PhotonView, PriorityValue>> enumerator = orderedEnumerable.GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							c7088de59e49f7108f520cf7e0bae167e.Add(enumerator.Current.Key);
						}
						while (true)
						{
							switch (7)
							{
							case 0:
								break;
							default:
								return c7088de59e49f7108f520cf7e0bae167e;
							}
						}
					}
					finally
					{
						if (enumerator == null)
						{
							while (true)
							{
								switch (4)
								{
								case 0:
									break;
								default:
									goto end_IL_00e9;
								}
								continue;
								end_IL_00e9:
								break;
							}
						}
						else
						{
							enumerator.Dispose();
						}
					}
				}
				}
			}
		}
		return null;
	}

	public void cb89e07214016d9bbd73aa8e8589a34d4(PhotonView ca4187010cdd35921f11dd5df8ccc23e3, PhotonPlayer cbc409c28882b371b394d25bd4774efa0)
	{
		Dictionary<PhotonView, PriorityValue> value = c1847bd8b12e4b4a179593991b5820af5.c7088de59e49f7108f520cf7e0bae167e;
		priorityPerPlayer.TryGetValue(cbc409c28882b371b394d25bd4774efa0, out value);
		if (value == null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			int num = value[ca4187010cdd35921f11dd5df8ccc23e3].runtime - 66;
			if (num < 0)
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
				num = 0;
			}
			value[ca4187010cdd35921f11dd5df8ccc23e3].runtime = num;
			return;
		}
	}

	public void ca8318c9648d918e3470bd193031f5434(PhotonView ca4187010cdd35921f11dd5df8ccc23e3, PhotonPlayer cbc409c28882b371b394d25bd4774efa0)
	{
		Dictionary<PhotonView, PriorityValue> value = c1847bd8b12e4b4a179593991b5820af5.c7088de59e49f7108f520cf7e0bae167e;
		priorityPerPlayer.TryGetValue(cbc409c28882b371b394d25bd4774efa0, out value);
		if (value == null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			value[ca4187010cdd35921f11dd5df8ccc23e3].runtime = value[ca4187010cdd35921f11dd5df8ccc23e3].evaluated;
			return;
		}
	}

	public void OnRemovePhotonView(PhotonView view)
	{
		using (Dictionary<PhotonPlayer, Dictionary<PhotonView, PriorityValue>>.ValueCollection.Enumerator enumerator = priorityPerPlayer.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Dictionary<PhotonView, PriorityValue> current = enumerator.Current;
				current.Remove(view);
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
				break;
			}
		}
		using (Dictionary<PhotonPlayer, List<PhotonView>>.ValueCollection.Enumerator enumerator2 = orderedPhotonViewPerPlayer.Values.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				List<PhotonView> current2 = enumerator2.Current;
				current2.Remove(view);
			}
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
	}

	public void cac7688b05e921e2be3f92479ba44b4a8()
	{
		priorityPerPlayer.Clear();
		orderedPhotonViewPerPlayer.Clear();
	}

	public void c45d6ce1eabe3a9e89281a38caea5e87e(PhotonPlayer ceb41162a7cd2a1d5c4a03830e02b4198)
	{
		priorityPerPlayer.Remove(ceb41162a7cd2a1d5c4a03830e02b4198);
		orderedPhotonViewPerPlayer.Remove(ceb41162a7cd2a1d5c4a03830e02b4198);
	}

	private void c848b83091aec1d2f4e6a0b802aeab3f6()
	{
		c44a92495902d1d02d8b8590059ecf7c7(PhotonNetwork.ceb41162a7cd2a1d5c4a03830e02b4198);
	}

	private void c44a92495902d1d02d8b8590059ecf7c7(PhotonPlayer ceb41162a7cd2a1d5c4a03830e02b4198)
	{
		m_priority.priority = 0;
		Dictionary<PhotonView, PriorityValue> value = c1847bd8b12e4b4a179593991b5820af5.c7088de59e49f7108f520cf7e0bae167e;
		if (!priorityPerPlayer.TryGetValue(ceb41162a7cd2a1d5c4a03830e02b4198, out value))
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
			value = new Dictionary<PhotonView, PriorityValue>();
			priorityPerPlayer.Add(ceb41162a7cd2a1d5c4a03830e02b4198, value);
		}
		if (value == null)
		{
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
		if (PhotonNetwork.networkingPeer == null)
		{
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
		List<PhotonView> cf6759adb49f9f5b7c419697ac8bd0f;
		PhotonNetwork.networkingPeer.c7a16247bc5d88b42dbabe627f5962c2e(out cf6759adb49f9f5b7c419697ac8bd0f);
		for (int i = 0; i < cf6759adb49f9f5b7c419697ac8bd0f.Count; i++)
		{
			PhotonView photonView = cf6759adb49f9f5b7c419697ac8bd0f[i];
			if (photonView.observed is IPhotonEvaluate)
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
				IPhotonEvaluate photonEvaluate = (IPhotonEvaluate)photonView.observed;
				photonEvaluate.OnPhotonEvaluate(ceb41162a7cd2a1d5c4a03830e02b4198, ref m_priority);
				m_priority.priority += photonView.m_priority;
			}
			else
			{
				m_priority.priority = photonView.m_priority;
			}
			PriorityValue value2 = null;
			if (value.TryGetValue(photonView, out value2))
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
				value2.evaluated = m_priority.priority;
			}
			else
			{
				value.Add(photonView, new PriorityValue(m_priority.priority, 0));
			}
			if (ceb41162a7cd2a1d5c4a03830e02b4198 != priorityInspector)
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
			photonView.m_priorityRunTime = m_priority.priority;
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

	public bool c0dd8ec7f4d10a80d5f8db7a9561ed115(PhotonView ca4187010cdd35921f11dd5df8ccc23e3, PhotonPlayer ceb41162a7cd2a1d5c4a03830e02b4198, PhotonChannel cbbf6a50cf64ad859e4e83fe948579fd0)
	{
		PriorityValue value = null;
		Dictionary<PhotonView, PriorityValue> value2 = c1847bd8b12e4b4a179593991b5820af5.c7088de59e49f7108f520cf7e0bae167e;
		priorityPerPlayer.TryGetValue(ceb41162a7cd2a1d5c4a03830e02b4198, out value2);
		if (value2 != null)
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
			if (!value2.TryGetValue(ca4187010cdd35921f11dd5df8ccc23e3, out value))
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
				value.runtime = ca4187010cdd35921f11dd5df8ccc23e3.m_priority;
			}
		}
		if (value.runtime > cbbf6a50cf64ad859e4e83fe948579fd0.m_priorityCeil.priority)
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
		return true;
	}

	public int c9f0427d35dc233bd7b8a42190cf6c521(PhotonView ca4187010cdd35921f11dd5df8ccc23e3, PhotonPlayer ceb41162a7cd2a1d5c4a03830e02b4198)
	{
		if (ceb41162a7cd2a1d5c4a03830e02b4198 == null)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return -1;
				}
			}
		}
		PriorityValue value = null;
		Dictionary<PhotonView, PriorityValue> value2 = c1847bd8b12e4b4a179593991b5820af5.c7088de59e49f7108f520cf7e0bae167e;
		priorityPerPlayer.TryGetValue(ceb41162a7cd2a1d5c4a03830e02b4198, out value2);
		if (value2 != null)
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
			if (value2.TryGetValue(ca4187010cdd35921f11dd5df8ccc23e3, out value))
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						return value.runtime;
					}
				}
			}
		}
		return -1;
	}

	[CompilerGenerated]
	private static int ce29a359882de58d5b8b2ff7f01c8ef7b(KeyValuePair<PhotonView, PriorityValue> c9865517a0bb5b7f200aaa1a34e1890c6)
	{
		return c9865517a0bb5b7f200aaa1a34e1890c6.Value.runtime;
	}
}
