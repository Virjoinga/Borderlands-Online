using System;
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace A
{
	internal class c7feba50ec333bdc3f1f40147c56d9e10 : c42fd94d5e4ecc5b63c9599a942b208fe
	{
		private c138fe6793dafd77598263497ada6289e ce486bbb7b72a128ad5409b92e2eda813 = new c138fe6793dafd77598263497ada6289e();

		private Entity cee14137582fd411ba02ca400c4442f16;

		private Vector3 cdc38149781563898bbbf00d1826dcba4;

		private bool c6f12cfadfda5ef5f8a75f692e4e2f39e;

		private Entity c359da35c664e32aef23dc0bd5e9d560a;

		private Vector3 cd9af021a6a31d3c708e9837383838cfb;

		private bool c7e085d42bd8ba2deba989753162b5631;

		public c7feba50ec333bdc3f1f40147c56d9e10()
		{
			Vector3 c36964cf41281414170f34ee68bef6c = default(Vector3);
			ced819f907a00cbfa6286c200338b520d.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
			cdc38149781563898bbbf00d1826dcba4 = c36964cf41281414170f34ee68bef6c;
			Vector3 c36964cf41281414170f34ee68bef6c2 = default(Vector3);
			ced819f907a00cbfa6286c200338b520d.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c2);
			cd9af021a6a31d3c708e9837383838cfb = c36964cf41281414170f34ee68bef6c2;
			base._002Ector();
		}

		private bool ccba551dd07becb4b08ce13f6f00b62de()
		{
			UnityEngine.Object[] array = UnityEngine.Object.FindObjectsOfType(Type.GetTypeFromHandle(cc30ad18d9004f6c9825d2221f535b10a.cc1720d05c75832f704b87474932341c3()));
			for (int i = 0; i < array.Length; i++)
			{
				GameObject gameObject = (GameObject)array[i];
				if (!(gameObject.GetComponent<Cluster>() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
				{
					continue;
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
					return true;
				}
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				return false;
			}
		}

		protected override void cb396a7a5471504026c466f04f6bf5543()
		{
			c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.c3f0d9cf7bb65072c8cb6a400c2468eea(ce486bbb7b72a128ad5409b92e2eda813);
			PhotonStatsGui componentInChildren = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponentInChildren<PhotonStatsGui>();
			componentInChildren.statsOn = true;
			componentInChildren.statsWindowOn = true;
			componentInChildren.trafficDetailStatsOn = true;
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_logNetworkProfile = true;
			PhotonNetwork.c01fb44a84b234955e072426cda6b8914 = true;
		}

		protected override void ce4a5e94169aff4b7286fee3aa834ff1f()
		{
			if (cee14137582fd411ba02ca400c4442f16 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (c06ca0e618478c23eba3419653a19760f<EntityManager>.c5ee19dc8d4cccf5ae2de225410458b86.c6d037f57d903e6bcdcc24348eeefb88c(Entity.EntityType.Npc) > 0)
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
					List<Entity> c0c2a548e7e20a141e7763c365a4d;
					c06ca0e618478c23eba3419653a19760f<EntityManager>.c5ee19dc8d4cccf5ae2de225410458b86.c87ecafd3dda798dbf216aaf5316d45f6(Entity.EntityType.Npc, out c0c2a548e7e20a141e7763c365a4d);
					cee14137582fd411ba02ca400c4442f16 = c0c2a548e7e20a141e7763c365a4d[0];
					cdc38149781563898bbbf00d1826dcba4 = cee14137582fd411ba02ca400c4442f16.transform.position;
				}
			}
			else if (cdc38149781563898bbbf00d1826dcba4 != cee14137582fd411ba02ca400c4442f16.transform.position)
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
				c6f12cfadfda5ef5f8a75f692e4e2f39e = true;
			}
			if (c359da35c664e32aef23dc0bd5e9d560a == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (c06ca0e618478c23eba3419653a19760f<EntityManager>.c5ee19dc8d4cccf5ae2de225410458b86.c6d037f57d903e6bcdcc24348eeefb88c(Entity.EntityType.Player) > 0)
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
					List<Entity> c0c2a548e7e20a141e7763c365a4d2;
					c06ca0e618478c23eba3419653a19760f<EntityManager>.c5ee19dc8d4cccf5ae2de225410458b86.c87ecafd3dda798dbf216aaf5316d45f6(Entity.EntityType.Player, out c0c2a548e7e20a141e7763c365a4d2);
					c359da35c664e32aef23dc0bd5e9d560a = c0c2a548e7e20a141e7763c365a4d2[0];
					cd9af021a6a31d3c708e9837383838cfb = c359da35c664e32aef23dc0bd5e9d560a.transform.position;
				}
			}
			else if (cd9af021a6a31d3c708e9837383838cfb != c359da35c664e32aef23dc0bd5e9d560a.transform.position)
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
				c7e085d42bd8ba2deba989753162b5631 = true;
			}
			ce486bbb7b72a128ad5409b92e2eda813.c3917b78016e4da1ffd561f6b04f01d0c = base.m_timeElapsed;
			if (!(base.m_timeElapsed >= 60f))
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
				PhotonStatsGui componentInChildren = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponentInChildren<PhotonStatsGui>();
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Autotest, componentInChildren.lastStats);
				if (ccba551dd07becb4b08ce13f6f00b62de())
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
					if (!c6f12cfadfda5ef5f8a75f692e4e2f39e)
					{
						while (true)
						{
							switch (5)
							{
							case 0:
								break;
							default:
								c5bc8bb6c6b44d3d5bf9249765a5d8e27(false, "NPC not moving");
								return;
							}
						}
					}
				}
				if (!c7e085d42bd8ba2deba989753162b5631)
				{
					while (true)
					{
						switch (4)
						{
						case 0:
							break;
						default:
							c5bc8bb6c6b44d3d5bf9249765a5d8e27(false, "Player not moving");
							return;
						}
					}
				}
				c5bc8bb6c6b44d3d5bf9249765a5d8e27(true, string.Empty);
				return;
			}
		}
	}
}
