using System.Collections.Generic;
using A;
using Photon;
using UnityEngine;
using XsdSettings;

public class InteractionManager : Photon.MonoBehaviour
{
	private static InteractionManager s_instance;

	private List<InteractionClient> m_interactionClinets = new List<InteractionClient>();

	public static InteractionManager c5ee19dc8d4cccf5ae2de225410458b86
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

	public void c57e4d4cd41f3be21d7e24a71aa08c6ba(InteractionClient c216d4a479b607c6ae8cfa43347dd34d0)
	{
		m_interactionClinets.Add(c216d4a479b607c6ae8cfa43347dd34d0);
	}

	public void cf5212e6903ec0c0b27816142c32a2d13(InteractionClient c216d4a479b607c6ae8cfa43347dd34d0)
	{
		m_interactionClinets.Remove(c216d4a479b607c6ae8cfa43347dd34d0);
	}

	public List<InteractionClient> c20942eebb8297c02d80277ca67073728()
	{
		return m_interactionClinets;
	}

	public bool c54f7becd6f38edcaefd7d35cc9d49e83(Entity c5d720f6d007abb0c4a21d6a654e405bb, ref InteractionClient c38a5a12997c9bd05a4616a5ae16e2f76, ref InteractionClient cd09bb1399261bd246ac4a49e9e4219a9, ref float c3b8493e0eaa99ba0eb14a1a14105961f)
	{
		c38a5a12997c9bd05a4616a5ae16e2f76 = null;
		cd09bb1399261bd246ac4a49e9e4219a9 = null;
		float num = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_globalSettings.m_visualInteractionDistance;
		Ray cdb5cb253ef1339831696a37475f7233f = new Ray(c5d720f6d007abb0c4a21d6a654e405bb.cad7880776eb7b2ddfb106102d4c51bbf(), c5d720f6d007abb0c4a21d6a654e405bb.c56fad5727ffebf48f3df62074cd1bbe6());
		List<InteractionClient> list = c5ee19dc8d4cccf5ae2de225410458b86.c20942eebb8297c02d80277ca67073728();
		int num2 = 0;
		while (true)
		{
			if (num2 < list.Count)
			{
				InteractionClient interactionClient = list[num2];
				if (interactionClient.cab69fd15e36704ccac7469787a1570a0(c5d720f6d007abb0c4a21d6a654e405bb))
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
					float num3;
					if (interactionClient.cafe5e3051445e4e581a42f13d84472ee())
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
						num3 = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_globalSettings.m_visualInteractionDistance;
					}
					else
					{
						num3 = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_globalSettings.m_interactionDistance;
					}
					float c85645ac328a4c6e6c17d3da3be1e11f = num3;
					if (interactionClient.c0c9ccf9f6d8cef1e33079d8eaf757b12(cdb5cb253ef1339831696a37475f7233f, ref c85645ac328a4c6e6c17d3da3be1e11f))
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
						if (interactionClient is TownNpc)
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
							if (c85645ac328a4c6e6c17d3da3be1e11f <= c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_globalSettings.m_interactionDistance)
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
								c38a5a12997c9bd05a4616a5ae16e2f76 = interactionClient;
								c3b8493e0eaa99ba0eb14a1a14105961f = c85645ac328a4c6e6c17d3da3be1e11f;
								cd09bb1399261bd246ac4a49e9e4219a9 = null;
							}
							else
							{
								c38a5a12997c9bd05a4616a5ae16e2f76 = null;
							}
							break;
						}
						if (c85645ac328a4c6e6c17d3da3be1e11f <= num)
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
							if (!interactionClient.cafe5e3051445e4e581a42f13d84472ee())
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
								if (!(c85645ac328a4c6e6c17d3da3be1e11f <= c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_globalSettings.m_interactionDistance))
								{
									goto IL_01b7;
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
							num = c85645ac328a4c6e6c17d3da3be1e11f;
							if (c85645ac328a4c6e6c17d3da3be1e11f <= c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_globalSettings.m_interactionDistance)
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
								c38a5a12997c9bd05a4616a5ae16e2f76 = interactionClient;
							}
							else
							{
								c38a5a12997c9bd05a4616a5ae16e2f76 = null;
							}
							if (interactionClient.cafe5e3051445e4e581a42f13d84472ee())
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
								cd09bb1399261bd246ac4a49e9e4219a9 = interactionClient;
							}
							else
							{
								cd09bb1399261bd246ac4a49e9e4219a9 = null;
							}
						}
					}
				}
				goto IL_01b7;
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
			break;
			IL_01b7:
			num2++;
		}
		return c38a5a12997c9bd05a4616a5ae16e2f76 != null;
	}

	public void c36467fe517a0f42347fb7d43c24ab6b1(InteractionClient c38a5a12997c9bd05a4616a5ae16e2f76, ref List<InteractionClient> cb49867fd869e7be0b00af7cf29240f1d)
	{
		cb49867fd869e7be0b00af7cf29240f1d.Clear();
		cb49867fd869e7be0b00af7cf29240f1d.Add(c38a5a12997c9bd05a4616a5ae16e2f76);
		List<InteractionClient> list = c5ee19dc8d4cccf5ae2de225410458b86.c20942eebb8297c02d80277ca67073728();
		for (int i = 0; i < list.Count; i++)
		{
			if (c38a5a12997c9bd05a4616a5ae16e2f76 == list[i])
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
			}
			else
			{
				if (!(Vector3.Distance(c38a5a12997c9bd05a4616a5ae16e2f76.c4cf00ced2bc60ae908904eb73692869f(), list[i].c4cf00ced2bc60ae908904eb73692869f()) < 0.3f))
				{
					continue;
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
				cb49867fd869e7be0b00af7cf29240f1d.Add(list[i]);
			}
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	public bool c6f2d419a4cc4b7bbd6ab53caca787949(Entity c5d720f6d007abb0c4a21d6a654e405bb, ItemDNA ca57e1c076c01141c5ce58c7341db7833)
	{
		bool result = true;
		if (ca57e1c076c01141c5ce58c7341db7833.ca8e8ecb1231bf8cf32c06da446a48681(ItemType.Ammo))
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
			AmmoType ammoType = ca57e1c076c01141c5ce58c7341db7833.m_ammoType;
			if (ammoType != AmmoType.Grenade)
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
				result = c5d720f6d007abb0c4a21d6a654e405bb.c5ca38fad98337fc5c7255384b2cd1a86().c19b70ea6e4db0802bb7cae385cc85109(ca57e1c076c01141c5ce58c7341db7833.m_ammoType) < c5d720f6d007abb0c4a21d6a654e405bb.c5ca38fad98337fc5c7255384b2cd1a86().c8a605fa1a9c2a71cfb141d9433f2f958(ca57e1c076c01141c5ce58c7341db7833.m_ammoType);
			}
			else
			{
				result = c5d720f6d007abb0c4a21d6a654e405bb.c5ca38fad98337fc5c7255384b2cd1a86().cc0b9d3080e1a0c182204b250d657b977() < c5d720f6d007abb0c4a21d6a654e405bb.c5ca38fad98337fc5c7255384b2cd1a86().c4864359b53f3eb339247aab4edeb1fe5();
			}
		}
		else if (ca57e1c076c01141c5ce58c7341db7833.ca8e8ecb1231bf8cf32c06da446a48681(ItemType.Material))
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
		}
		return result;
	}

	public void cccb56495987b6a4ebab7b225fb1af261(int c480f0ca5d2a35c04d6998393dfb53217, byte c793014f9fd028450a4a9908376309f26)
	{
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(2);
		array[0] = c480f0ca5d2a35c04d6998393dfb53217;
		array[1] = c793014f9fd028450a4a9908376309f26;
		base.photonView.c19fd12ed98be2a9174d53644dc9757c8("RPC_C2H_DropItem", PhotonTargets.MasterClient, array);
	}

	[RPC]
	private void RPC_C2H_DropItem(int droperId, byte slot, PhotonMessageInfo info)
	{
	}

	[RPC]
	private void RPC_H2C_OnDropItem(int droperId, int itemId, PhotonMessageInfo info)
	{
		EntityPlayer component = BadAssNetworkView.c16cef725419dd5314991ac769ad60eb9(droperId).GetComponent<EntityPlayer>();
		if (!(component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			StartCoroutine(component.cccb56495987b6a4ebab7b225fb1af261(itemId));
			return;
		}
	}

	[RPC]
	public void RPC_H2C_OnPickUpItem(int pickerId, int itemId, PhotonMessageInfo info)
	{
		Entity entity = BadAssNetworkView.cd45cbc6284a89fa5c2b29c7ad9718528(pickerId);
		EntityObject entityObject = BadAssNetworkView.cd45cbc6284a89fa5c2b29c7ad9718528(itemId) as EntityObject;
		if (!entityObject)
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
			entityObject.m_pickable.c22785b57afeece46810fee1b68ee29a4(entity as EntityPlayer);
			return;
		}
	}
}
