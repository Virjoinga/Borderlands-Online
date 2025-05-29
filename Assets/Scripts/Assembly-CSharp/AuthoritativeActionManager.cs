using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using A;
using UnityEngine;

public class AuthoritativeActionManager : MonoBehaviour, IPhotonView
{
	private Dictionary<Action, Entity> m_ActionModulesToEntity = new Dictionary<Action, Entity>();

	private Dictionary<Type, int> m_ActionDic = new Dictionary<Type, int>();

	private List<string> m_ActionNameList = new List<string>();

	private static AuthoritativeActionManager s_instance;

	public PhotonView photonView { get; set; }

	public static AuthoritativeActionManager c5ee19dc8d4cccf5ae2de225410458b86
	{
		get
		{
			return s_instance;
		}
	}

	private void Awake()
	{
		s_instance = this;
		Type baseType = Type.GetTypeFromHandle(cea8739c674f6d91476391b5908967b66.cc1720d05c75832f704b87474932341c3());
		Assembly assembly = baseType.Assembly;
		IEnumerable<Type> enumerable = from c892246130fbeaf4178cac23e3076494d in assembly.GetTypes()
			where c892246130fbeaf4178cac23e3076494d.IsSubclassOf(baseType)
			select c892246130fbeaf4178cac23e3076494d;
		IEnumerator<Type> enumerator = enumerable.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Type current = enumerator.Current;
				if (m_ActionDic.ContainsKey(current))
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				m_ActionDic[current] = 0;
				m_ActionNameList.Clear();
				using (Dictionary<Type, int>.KeyCollection.Enumerator enumerator2 = m_ActionDic.Keys.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						Type current2 = enumerator2.Current;
						m_ActionNameList.Add(current2.Name);
					}
					while (true)
					{
						switch (5)
						{
						case 0:
							break;
						default:
							goto end_IL_00e5;
						}
						continue;
						end_IL_00e5:
						break;
					}
				}
				m_ActionNameList.Sort();
				int count = m_ActionNameList.Count;
				for (int i = 0; i < count; i++)
				{
					m_ActionDic[Type.GetType(m_ActionNameList[i])] = i;
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
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		finally
		{
			if (enumerator == null)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						goto end_IL_0172;
					}
					continue;
					end_IL_0172:
					break;
				}
			}
			else
			{
				enumerator.Dispose();
			}
		}
	}

	private void Start()
	{
	}

	private void Update()
	{
		using (Dictionary<Action, Entity>.KeyCollection.Enumerator enumerator = m_ActionModulesToEntity.Keys.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Action current = enumerator.Current;
				current.c6c6cbb0045146f9b0a890f787bad6e4d();
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
				break;
			}
		}
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
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
			if (!c06ca0e618478c23eba3419653a19760f<AttackManager>.c5ee19dc8d4cccf5ae2de225410458b86)
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
				c06ca0e618478c23eba3419653a19760f<AttackManager>.c5ee19dc8d4cccf5ae2de225410458b86.c6c6cbb0045146f9b0a890f787bad6e4d();
				return;
			}
		}
	}

	public void c1349ec840ae297d0b9eef45794c67d3a(Action c60fce398a2227505f8a828de03f1d8cf, Entity c5d720f6d007abb0c4a21d6a654e405bb)
	{
		m_ActionModulesToEntity.Add(c60fce398a2227505f8a828de03f1d8cf, c5d720f6d007abb0c4a21d6a654e405bb);
	}

	public void c82e3f68cda0201accfeb810a507077d0(Action c60fce398a2227505f8a828de03f1d8cf)
	{
		m_ActionModulesToEntity.Remove(c60fce398a2227505f8a828de03f1d8cf);
	}

	public int cedd6df992c20da839c6da89aebf78bea(Action c861de212c63da4e42109937e3cac1a44)
	{
		return m_ActionDic[c861de212c63da4e42109937e3cac1a44.GetType()];
	}

	public void c0411698b20c1e5ea7a3daa619b2a2b43(Entity c5e373b32ca983159dcbae27fd5eec6b9)
	{
	}

	public void c1fc97d9000793496ac114d06521f85a0(Entity c5e373b32ca983159dcbae27fd5eec6b9)
	{
	}

	public void c47fa63701b95de9c2d5b15acbc53f5ad(Entity c5e373b32ca983159dcbae27fd5eec6b9)
	{
	}

	public void c7d976d891f5d2e6dd16e6835f9e0d55f(Entity c5e373b32ca983159dcbae27fd5eec6b9)
	{
	}

	public void c1131a115e8f9ffcae5cec76e1aa6b920(EntityWeapon c5e373b32ca983159dcbae27fd5eec6b9)
	{
	}

	public void c6d501022836dfc1a044707b794e3a5e3(EntityWeapon c5e373b32ca983159dcbae27fd5eec6b9)
	{
	}

	public void ccfac8a798bb86233f3723631df4f2cdb(EntityWeapon c5e373b32ca983159dcbae27fd5eec6b9)
	{
	}

	public void cc05957ad6bd31701b0f8398ecacfc92a(EntityWeapon c5e373b32ca983159dcbae27fd5eec6b9)
	{
	}

	public void cd91d39f37531b5cbfdda0b9a40a28e12(int c2b4f43f34e21572af6ab4414f04cee36, Entity c5d720f6d007abb0c4a21d6a654e405bb, int cd22aa6735988e8e65acbd503f3870e3e)
	{
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(3);
		array[0] = cd22aa6735988e8e65acbd503f3870e3e * 1000 + c2b4f43f34e21572af6ab4414f04cee36;
		array[1] = c5d720f6d007abb0c4a21d6a654e405bb.cc7403315505256d19a7b92aa614a8f10();
		int num = Time.frameCount;
		if (c5d720f6d007abb0c4a21d6a654e405bb.m_relatedPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			EntityPlayer relatedPlayer = c5d720f6d007abb0c4a21d6a654e405bb.m_relatedPlayer;
			if (relatedPlayer.cbe65aaa5561a0ba002aca1f0c8498077() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				num = relatedPlayer.cbe65aaa5561a0ba002aca1f0c8498077().currentInput.m_frameNum;
			}
		}
		array[2] = num;
		if (!NetworkManager.c449802e708e91a9150466060fbab2ad6())
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					photonView.c19fd12ed98be2a9174d53644dc9757c8("RPC_SA", PhotonTargets.All, array);
					return;
				}
			}
		}
		photonView.c19fd12ed98be2a9174d53644dc9757c8("RPC_SA", PhotonTargets.MasterClient, array);
	}

	[RPC]
	private void RPC_SA(int type, int entityID, int frameCount, PhotonMessageInfo info)
	{
		BadAssNetworkView badAssNetworkView = BadAssNetworkView.c16cef725419dd5314991ac769ad60eb9(entityID);
		if (!badAssNetworkView)
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
			EntityAbility component = badAssNetworkView.GetComponent<EntityAbility>();
			if (!component)
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
				int num = type / 1000;
				type -= num * 1000;
				Action action = component.c663d11c8834305590100229866ab1cbc(type);
				if (action == null)
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
					if (info.sender.c29a834d12d3895f5680e69a30e6cd9a3 == NetworkManager.cf6124bd5254101846a57acc03f545846())
					{
						while (true)
						{
							switch (3)
							{
							case 0:
								break;
							default:
								action.OnStartAction(true, info.c24d168bafd94cfd3e438faef12da2b5c, 0.0, frameCount, num);
								return;
							}
						}
					}
					action.OnStartAction(false, info.c24d168bafd94cfd3e438faef12da2b5c, NetworkManager.c0001f5085e474065d3cb214356d1ba19() - info.c24d168bafd94cfd3e438faef12da2b5c, frameCount, num);
					return;
				}
			}
		}
	}

	public void cb41ae3ef91dbe45c7cabfc04d71509a6(int c2b4f43f34e21572af6ab4414f04cee36, Entity c5d720f6d007abb0c4a21d6a654e405bb, int cd22aa6735988e8e65acbd503f3870e3e)
	{
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(3);
		array[0] = cd22aa6735988e8e65acbd503f3870e3e * 1000 + c2b4f43f34e21572af6ab4414f04cee36;
		array[1] = c5d720f6d007abb0c4a21d6a654e405bb.cc7403315505256d19a7b92aa614a8f10();
		int num = Time.frameCount;
		if (c5d720f6d007abb0c4a21d6a654e405bb.m_relatedPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			EntityPlayer relatedPlayer = c5d720f6d007abb0c4a21d6a654e405bb.m_relatedPlayer;
			if (relatedPlayer.cbe65aaa5561a0ba002aca1f0c8498077() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				num = relatedPlayer.cbe65aaa5561a0ba002aca1f0c8498077().currentInput.m_frameNum;
			}
		}
		array[2] = num;
		if (!NetworkManager.c449802e708e91a9150466060fbab2ad6())
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					photonView.c19fd12ed98be2a9174d53644dc9757c8("RPC_SO", PhotonTargets.All, array);
					return;
				}
			}
		}
		photonView.c19fd12ed98be2a9174d53644dc9757c8("RPC_SO", PhotonTargets.MasterClient, array);
	}

	[RPC]
	private void RPC_SO(int type, int entityID, int frameCount, PhotonMessageInfo info)
	{
		BadAssNetworkView badAssNetworkView = BadAssNetworkView.c16cef725419dd5314991ac769ad60eb9(entityID);
		if (!badAssNetworkView)
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
			EntityAbility component = badAssNetworkView.GetComponent<EntityAbility>();
			if (!component)
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
				int num = type / 1000;
				type -= num * 1000;
				Action action = component.c663d11c8834305590100229866ab1cbc(type);
				if (action == null)
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
					if (info.sender.c29a834d12d3895f5680e69a30e6cd9a3 == NetworkManager.cf6124bd5254101846a57acc03f545846())
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								break;
							default:
								action.OnStopAction(true, info.c24d168bafd94cfd3e438faef12da2b5c, 0.0, frameCount, num);
								return;
							}
						}
					}
					action.OnStopAction(false, info.c24d168bafd94cfd3e438faef12da2b5c, NetworkManager.c0001f5085e474065d3cb214356d1ba19() - info.c24d168bafd94cfd3e438faef12da2b5c, frameCount, num);
					return;
				}
			}
		}
	}

	public void c99ba9c13b5a9e792c3b892f32759fc1c(int c2b4f43f34e21572af6ab4414f04cee36, Entity c5d720f6d007abb0c4a21d6a654e405bb, int cd22aa6735988e8e65acbd503f3870e3e)
	{
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(3);
		array[0] = cd22aa6735988e8e65acbd503f3870e3e * 1000 + c2b4f43f34e21572af6ab4414f04cee36;
		array[1] = c5d720f6d007abb0c4a21d6a654e405bb.cc7403315505256d19a7b92aa614a8f10();
		int num = Time.frameCount;
		if (c5d720f6d007abb0c4a21d6a654e405bb.m_relatedPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			EntityPlayer relatedPlayer = c5d720f6d007abb0c4a21d6a654e405bb.m_relatedPlayer;
			if (relatedPlayer.cbe65aaa5561a0ba002aca1f0c8498077() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				num = relatedPlayer.cbe65aaa5561a0ba002aca1f0c8498077().currentInput.m_frameNum;
			}
		}
		array[2] = num;
		if (!NetworkManager.c449802e708e91a9150466060fbab2ad6())
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					photonView.c19fd12ed98be2a9174d53644dc9757c8("RPC_SI", PhotonTargets.All, array);
					return;
				}
			}
		}
		photonView.c19fd12ed98be2a9174d53644dc9757c8("RPC_SI", PhotonTargets.MasterClient, array);
	}

	[RPC]
	private void RPC_SI(int type, int entityID, int frameCount, PhotonMessageInfo info)
	{
		BadAssNetworkView badAssNetworkView = BadAssNetworkView.c16cef725419dd5314991ac769ad60eb9(entityID);
		if (!badAssNetworkView)
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
			EntityAbility component = badAssNetworkView.GetComponent<EntityAbility>();
			if (!component)
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
				int num = type / 1000;
				type -= num * 1000;
				Action action = component.c663d11c8834305590100229866ab1cbc(type);
				if (action == null)
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
					if (info.sender.c29a834d12d3895f5680e69a30e6cd9a3 == NetworkManager.cf6124bd5254101846a57acc03f545846())
					{
						while (true)
						{
							switch (6)
							{
							case 0:
								break;
							default:
								action.OnSingleAction(true, info.c24d168bafd94cfd3e438faef12da2b5c, 0.0, frameCount, num);
								return;
							}
						}
					}
					action.OnSingleAction(false, info.c24d168bafd94cfd3e438faef12da2b5c, NetworkManager.c0001f5085e474065d3cb214356d1ba19() - info.c24d168bafd94cfd3e438faef12da2b5c, frameCount, num);
					return;
				}
			}
		}
	}

	public void c0b8a6b24b08ec246c6e203ae79ba593e(int c2b4f43f34e21572af6ab4414f04cee36, Entity c5d720f6d007abb0c4a21d6a654e405bb, int cd22aa6735988e8e65acbd503f3870e3e)
	{
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(3);
		array[0] = cd22aa6735988e8e65acbd503f3870e3e * 1000 + c2b4f43f34e21572af6ab4414f04cee36;
		array[1] = c5d720f6d007abb0c4a21d6a654e405bb.cc7403315505256d19a7b92aa614a8f10();
		int num = Time.frameCount;
		if (c5d720f6d007abb0c4a21d6a654e405bb.m_relatedPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			EntityPlayer relatedPlayer = c5d720f6d007abb0c4a21d6a654e405bb.m_relatedPlayer;
			if (relatedPlayer.cbe65aaa5561a0ba002aca1f0c8498077() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				num = relatedPlayer.cbe65aaa5561a0ba002aca1f0c8498077().currentInput.m_frameNum;
			}
		}
		array[2] = num;
		photonView.c19fd12ed98be2a9174d53644dc9757c8("RPC_SI", PhotonTargets.All, array);
	}
}
