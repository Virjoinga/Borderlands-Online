using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using A;
using Core;
using UnityEngine;
using XsdSettings;

public class GuidanceTipsManager : c06ca0e618478c23eba3419653a19760f<GuidanceTipsManager>, ICharacterServiceNotificationListerner
{
	private bool m_needSave;

	private static float s_repeatTime = 30f;

	private bool m_isTimeToShine;

	private GuidanceTipsSetup m_guidanceTipsSetup;

	private List<GuidanceTip> m_teachableTips = new List<GuidanceTip>();

	private List<GuidanceTip> m_activeTips = new List<GuidanceTip>();

	private Utils.Timer m_tipTimer = new Utils.Timer();

	void ICharacterServiceNotificationListerner.OnGotMyCurrencies(CurrencyInfo currency)
	{
	}

	void ICharacterServiceNotificationListerner.OnExperienceUpdated(int experience)
	{
	}

	void ICharacterServiceNotificationListerner.OnSetPersonalSettings(int iResult)
	{
	}

	void ICharacterServiceNotificationListerner.OnGetPersonalSettings(string strSettings)
	{
		ce4a59aab1c8e596f63cca5764bb1ccd2(c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c5266987abcd60f99a820999013f389f4("learned"), c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c5266987abcd60f99a820999013f389f4("activetips"));
	}

	private void Start()
	{
		TextAsset textAsset = (TextAsset)ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Settings/GuidanceTips");
		XmlSerializer xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(cdf5ce8733e97fd020555aae4eaf55a4c.cc1720d05c75832f704b87474932341c3()));
		m_guidanceTipsSetup = xmlSerializer.Deserialize(new StringReader(textAsset.text)) as GuidanceTipsSetup;
		Resources.UnloadAsset(textAsset);
		Reset();
		c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c28e7fb4a7d03eef0acca90b1bd76a2c9(this);
	}

	private void Reset()
	{
		m_teachableTips.Clear();
		m_activeTips.Clear();
		for (int i = 0; i < m_guidanceTipsSetup.m_tips.Length; i++)
		{
			m_teachableTips.Add(m_guidanceTipsSetup.m_tips[i]);
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
			return;
		}
	}

	private void cd7d618c85c6c5867f76614537ade188d()
	{
		List<int> list = new List<int>();
		List<int> list2 = new List<int>();
		int num = 0;
		while (num < m_guidanceTipsSetup.m_tips.Length)
		{
			bool flag = true;
			GuidanceTip guidanceTip = m_guidanceTipsSetup.m_tips[num];
			for (int i = 0; i < m_teachableTips.Count; i++)
			{
				if (!(guidanceTip.m_id == m_teachableTips[i].m_id))
				{
					continue;
				}
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
				flag = false;
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				for (int j = 0; j < m_activeTips.Count; j++)
				{
					if (!(guidanceTip.m_id == m_activeTips[j].m_id))
					{
						continue;
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
					list2.Add(num);
					flag = false;
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					if (flag)
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
						list.Add(num);
					}
					num++;
					break;
				}
				break;
			}
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(5);
			array[0] = "GuidanceTipsManager.SaveLearnings[";
			array[1] = list2.Count;
			array[2] = "][";
			array[3] = list.Count;
			array[4] = "]";
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, string.Concat(array));
			c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c477993f7df71f5e855c29bbb49da309a("learned", list);
			c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c477993f7df71f5e855c29bbb49da309a("activetips", list2);
			m_needSave = false;
			return;
		}
	}

	public void ce4a59aab1c8e596f63cca5764bb1ccd2(List<int> c7e84c3de8aae350531f1025c731168ed, List<int> c9f3e2f41114a7b8ce4c8068fc43b56af)
	{
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(5);
		array[0] = "GuidanceTipsManager.LoadLearnings[";
		array[1] = c9f3e2f41114a7b8ce4c8068fc43b56af.Count;
		array[2] = "][";
		array[3] = c7e84c3de8aae350531f1025c731168ed.Count;
		array[4] = "]";
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, string.Concat(array));
		Reset();
		for (int i = 0; i < c7e84c3de8aae350531f1025c731168ed.Count; i++)
		{
			m_teachableTips.Remove(m_guidanceTipsSetup.m_tips[c7e84c3de8aae350531f1025c731168ed[i]]);
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			for (int j = 0; j < c9f3e2f41114a7b8ce4c8068fc43b56af.Count; j++)
			{
				m_teachableTips.Remove(m_guidanceTipsSetup.m_tips[c9f3e2f41114a7b8ce4c8068fc43b56af[j]]);
				m_activeTips.Add(m_guidanceTipsSetup.m_tips[c9f3e2f41114a7b8ce4c8068fc43b56af[j]]);
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
	}

	private void Update()
	{
		if (m_needSave)
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
			cd7d618c85c6c5867f76614537ade188d();
		}
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
		{
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
		if (m_activeTips.Count > 0)
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
			if (m_isTimeToShine)
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
				object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(7);
				array[0] = "GuidanceTipsManager.Show Tip[";
				array[1] = m_activeTips[0].m_id;
				array[2] = "][";
				array[3] = m_activeTips.Count;
				array[4] = "][";
				array[5] = m_teachableTips.Count;
				array[6] = "]";
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, string.Concat(array));
				c06ca0e618478c23eba3419653a19760f<ca3a00e0940eecb5ec7ffca2967d5423a>.c5ee19dc8d4cccf5ae2de225410458b86.cba86f338d46d74a8d7beba9c6f0a3fa5(m_activeTips[0].m_echoMsgId);
				m_tipTimer.Start(s_repeatTime);
				m_isTimeToShine = false;
				if (m_activeTips[0].m_id == "guidance_friend")
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
					c06ca0e618478c23eba3419653a19760f<GuidanceTipsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c93a582e07019617943999be8717d5134(m_activeTips[0].m_id);
				}
			}
		}
		if (!m_tipTimer.cf928603d375f06225f9eb5213fb17bd4())
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
			if (m_tipTimer.cb261500372fa488b369e9159a002977a())
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
				break;
			}
		}
		m_isTimeToShine = true;
	}

	public void c93a582e07019617943999be8717d5134(string c386ee9661658441ed65b836731aa0708)
	{
		for (int num = m_activeTips.Count; num > 0; num--)
		{
			GuidanceTip guidanceTip = m_activeTips[num - 1];
			if (guidanceTip.m_id == c386ee9661658441ed65b836731aa0708)
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
						m_activeTips.RemoveAt(num - 1);
						object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(7);
						array[0] = "GuidanceTipsManager.CloseTip[";
						array[1] = guidanceTip.m_id;
						array[2] = "][";
						array[3] = m_activeTips.Count;
						array[4] = "][";
						array[5] = m_teachableTips.Count;
						array[6] = "]";
						DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, string.Concat(array));
						m_needSave |= true;
						m_isTimeToShine = true;
						return;
					}
					}
				}
			}
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	private bool cd11684b84937640655891a9e4fa74630(GuidanceTip c557daf59b28a8589f8396e829d780ea0, TipTrigger c43f66656df32eb3880245dfb3da98a41, int cefda2fdc3ce4e04f38bab77fc7998241)
	{
		if (c557daf59b28a8589f8396e829d780ea0.m_trigger == c43f66656df32eb3880245dfb3da98a41)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					switch (c43f66656df32eb3880245dfb3da98a41)
					{
					case TipTrigger.LevelUp:
					case TipTrigger.SpentSkillPoint:
						return c557daf59b28a8589f8396e829d780ea0.m_value == cefda2fdc3ce4e04f38bab77fc7998241;
					case TipTrigger.ObtainWeapon:
					case TipTrigger.ObtainShield:
					case TipTrigger.ObtainClassMod:
					case TipTrigger.CanInteractWithPlayer:
					case TipTrigger.ReceiveMail:
					case TipTrigger.UnlockNewInstance:
						return true;
					default:
						return false;
					}
				}
			}
		}
		return false;
	}

	private void OnTipTrigger(TipTrigger tipTriggerType, int value = 0)
	{
		for (int num = m_teachableTips.Count; num > 0; num--)
		{
			GuidanceTip guidanceTip = m_teachableTips[num - 1];
			if (cd11684b84937640655891a9e4fa74630(guidanceTip, tipTriggerType, value))
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
				m_activeTips.Add(guidanceTip);
				m_teachableTips.RemoveAt(num - 1);
				object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(7);
				array[0] = "GuidanceTipsManager.OnTipTrigger[";
				array[1] = guidanceTip.m_id;
				array[2] = "][";
				array[3] = m_activeTips.Count;
				array[4] = "][";
				array[5] = m_teachableTips.Count;
				array[6] = "]";
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, string.Concat(array));
				m_needSave |= true;
				m_isTimeToShine = true;
			}
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	private void OnLevelUp(PlayerInfoSync player)
	{
		if (!player.c16d1154aec91a0f8f4a52d77fc081194())
		{
			while (true)
			{
				switch (4)
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
		int value = c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1ee9148b69b784ee94cf0d54409c8ee0(player.m_avatarDna.c071244a19e2d9f70f4d2d6d38677162a(), player.m_exp);
		OnTipTrigger(TipTrigger.LevelUp, value);
	}

	public void OnObtainItem(ItemDNA item)
	{
		if (item == null)
		{
			while (true)
			{
				switch (2)
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
		if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
		{
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
		if (item.ca8e8ecb1231bf8cf32c06da446a48681(ItemType.Weapon))
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					OnTipTrigger(TipTrigger.ObtainWeapon);
					return;
				}
			}
		}
		if (item.ca8e8ecb1231bf8cf32c06da446a48681(ItemType.Shield))
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					OnTipTrigger(TipTrigger.ObtainShield);
					return;
				}
			}
		}
		if (!item.ca8e8ecb1231bf8cf32c06da446a48681(ItemType.ClassMode))
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
			OnTipTrigger(TipTrigger.ObtainClassMod);
			return;
		}
	}

	public void OnCanInteractWithPlayer()
	{
		OnTipTrigger(TipTrigger.CanInteractWithPlayer);
	}

	public void OnReceiveMail()
	{
		OnTipTrigger(TipTrigger.ReceiveMail);
	}

	public void OnUnlockNewInstance()
	{
		OnTipTrigger(TipTrigger.UnlockNewInstance);
	}

	public void OnSpentSkillPoint(int value)
	{
		OnTipTrigger(TipTrigger.SpentSkillPoint, value);
	}
}
