using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using A;
using UnityEngine;

[ExecuteInEditMode]
public class AudioBus : NamedUniqueAudioObject
{
	private const string TAG_NAME = "Bus";

	private const string VOLUME_ATTR_NAME = "MixerScale";

	private const string VOICELIMIT_ATTR_NAME = "VoiceLimit";

	private AudioMixer m_mixer = new AudioMixer();

	private List<AudioBus> m_children = new List<AudioBus>();

	private AudioBus m_parent;

	public override string Name
	{
		set
		{
			if (!(base.Name != value))
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
				base.Name = value;
				cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.cc6e3847a57e10af584d6f85377557e52.OnBusStructureUpdated();
				return;
			}
		}
	}

	public AudioBus c141689acdf1323e4aa9be9049d24b40d
	{
		get
		{
			return m_parent;
		}
	}

	public AudioBus()
	{
	}

	protected AudioBus(string cd99af21e22e356018b8f72d4a7e4872a)
		: base(cd99af21e22e356018b8f72d4a7e4872a)
	{
	}

	protected AudioBus(Guid c35f98ccbfa8c6bf09319c620b21b5dc5, string cd99af21e22e356018b8f72d4a7e4872a)
		: base(c35f98ccbfa8c6bf09319c620b21b5dc5, cd99af21e22e356018b8f72d4a7e4872a)
	{
	}

	public AudioMixer c29d0bac2e9f266c244ba1ee8613309ba()
	{
		return m_mixer;
	}

	public void c62213f4b2fedcce92a97dec5ed56d6b0()
	{
		if (m_mixer == null)
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
			m_mixer.c3c97153ecd62d38c6885ab2ee963730c();
			return;
		}
	}

	public List<AudioBus> c2a74db806bdb8dc576986b17d992fbe5()
	{
		return m_children;
	}

	public AudioBus c1bbda114cc0fbe218361680ba80effcb(string cd99af21e22e356018b8f72d4a7e4872a)
	{
		AudioBus audioBus = new AudioBus(cd99af21e22e356018b8f72d4a7e4872a);
		cbc2043af955b1cabffda097815c8f49b(audioBus);
		return audioBus;
	}

	public void cbc2043af955b1cabffda097815c8f49b(AudioBus ca3706854b3073a0804de98d5202b25f4, bool c99308396eb447428d0665b71867cfbd4 = true)
	{
		ca3706854b3073a0804de98d5202b25f4.caf709be2040c20ed0379d3bc2305fbf2();
		m_children.Add(ca3706854b3073a0804de98d5202b25f4);
		ca3706854b3073a0804de98d5202b25f4.m_parent = this;
		ca3706854b3073a0804de98d5202b25f4.OnParentHierarchyUpdated(c99308396eb447428d0665b71867cfbd4);
	}

	public void caf709be2040c20ed0379d3bc2305fbf2()
	{
		if (m_parent == null)
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
			bool flag = m_parent.m_children.Remove(this);
			m_parent = c6e355047dbabc7cd22746ab16419c015.c7088de59e49f7108f520cf7e0bae167e;
			OnParentHierarchyUpdated(true);
			return;
		}
	}

	protected void OnParentHierarchyUpdated(bool updateManager)
	{
		AudioMixer audioMixer;
		if (m_parent != null)
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
			audioMixer = m_parent.c29d0bac2e9f266c244ba1ee8613309ba();
		}
		else
		{
			audioMixer = c82f2cd5e77a8fc507de12a3e40be717a.c7088de59e49f7108f520cf7e0bae167e;
		}
		AudioMixer c0b8b4f11377b8a222dc728ff2c = audioMixer;
		m_mixer.c3cbb887eeba52f2125aa47b794ceeb5e(c0b8b4f11377b8a222dc728ff2c);
		if (!updateManager)
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
			cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.cc6e3847a57e10af584d6f85377557e52.OnBusStructureUpdated();
			return;
		}
	}

	public void cd7ec3c3d315215baa32be83f43e88843(XmlNode cab83bba925e6355b7d0df9fe7c31c6e1)
	{
		base.cc09306479ed0f9f54a5e4e8dd8d72b99(cab83bba925e6355b7d0df9fe7c31c6e1);
		XmlElement xmlElement = cab83bba925e6355b7d0df9fe7c31c6e1 as XmlElement;
		if (xmlElement.HasAttribute("MixerScale"))
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
			m_mixer.m_scale = Convert.ToSingle(cab83bba925e6355b7d0df9fe7c31c6e1.Attributes["MixerScale"].Value);
		}
		if (xmlElement.HasAttribute("VoiceLimit"))
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
			m_mixer.cfbed0abcdee56ed3111d1d2756add2d7(Convert.ToInt32(cab83bba925e6355b7d0df9fe7c31c6e1.Attributes["VoiceLimit"].Value));
		}
		IEnumerator enumerator = cab83bba925e6355b7d0df9fe7c31c6e1.ChildNodes.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				XmlNode cab83bba925e6355b7d0df9fe7c31c6e2 = (XmlNode)enumerator.Current;
				AudioBus audioBus = new AudioBus();
				cbc2043af955b1cabffda097815c8f49b(audioBus, false);
				audioBus.cd7ec3c3d315215baa32be83f43e88843(cab83bba925e6355b7d0df9fe7c31c6e2);
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
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable == null)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						goto end_IL_00fa;
					}
					continue;
					end_IL_00fa:
					break;
				}
			}
			else
			{
				disposable.Dispose();
			}
		}
	}

	public void cf25b199c4a97f4ad49b976f44b213869(XmlNode c58a9e7c9769e81ee686c128461470bec)
	{
		XmlElement xmlElement = c58a9e7c9769e81ee686c128461470bec.OwnerDocument.CreateElement("Bus");
		c58a9e7c9769e81ee686c128461470bec.AppendChild(xmlElement);
		ce362f58a4cb16d37823ce93db86b3ea5(xmlElement);
		for (int i = 0; i < m_children.Count; i++)
		{
			m_children[i].cf25b199c4a97f4ad49b976f44b213869(xmlElement);
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
			return;
		}
	}

	protected void ce362f58a4cb16d37823ce93db86b3ea5(XmlElement cab83bba925e6355b7d0df9fe7c31c6e1)
	{
		base.c9742307d0830ac7381f2acd66ed5a6e2(cab83bba925e6355b7d0df9fe7c31c6e1);
		cab83bba925e6355b7d0df9fe7c31c6e1.SetAttribute("MixerScale", m_mixer.m_scale.ToString());
		cab83bba925e6355b7d0df9fe7c31c6e1.SetAttribute("VoiceLimit", m_mixer.c2f90d8ac0668f5966e81a74935ffdeda().ToString());
	}
}
