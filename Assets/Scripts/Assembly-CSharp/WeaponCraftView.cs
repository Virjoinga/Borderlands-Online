using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using A;
using UnityEngine;
using XsdSettings;

public class WeaponCraftView : BaseView
{
	protected class currencyUpdateListener : ICharacterServiceNotificationListerner
	{
		public WeaponCraftView RootView;

		void ICharacterServiceNotificationListerner.OnExperienceUpdated(int experience)
		{
		}

		void ICharacterServiceNotificationListerner.OnGotMyCurrencies(CurrencyInfo currency)
		{
			if (RootView == null)
			{
				while (true)
				{
					switch (3)
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
			RootView.c870d65a8957f7a97cafef5aacb0597ed(currency.BondCurrency);
		}

		void ICharacterServiceNotificationListerner.OnGetPersonalSettings(string strSettings)
		{
		}

		void ICharacterServiceNotificationListerner.OnSetPersonalSettings(int iResult)
		{
		}
	}

	protected Dictionary<int, UICraftData> _craftUIDataDic = new Dictionary<int, UICraftData>();

	protected List<UI_WeaponCraftConfig> _craftUIConfigList = new List<UI_WeaponCraftConfig>();

	protected currencyUpdateListener _currencyListener;

	protected int _iOnCraftWeaponID;

	protected bool _bIsCrafting;

	protected int _iMyCurrency = -1;

	protected List<int> m_pistolIDs = new List<int>();

	protected List<int> m_shotgunIDs = new List<int>();

	protected List<int> m_SMGIDs = new List<int>();

	protected List<int> m_sniperIDs = new List<int>();

	protected ParticleManager m_particleManager;

	private GameObject m_parentModel;

	public ParticleManager c451f04a91206cc21efd84192906fe8e3
	{
		get
		{
			return m_particleManager;
		}
		set
		{
			m_particleManager = value;
		}
	}

	protected GameObject c4faeec55f2ffcf5aba0dce86db47aa54
	{
		get
		{
			if (m_parentModel == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				m_parentModel = GameObject.Find("UI");
			}
			return m_parentModel;
		}
	}

	public bool c1b62101e70571561497611e5e1f074d4
	{
		get
		{
			return _bIsCrafting;
		}
	}

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		c13b5cbde8cdfbbcce0eef62d154cba66();
		_currencyListener = new currencyUpdateListener();
		_currencyListener.RootView = this;
		c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c28e7fb4a7d03eef0acca90b1bd76a2c9(_currencyListener);
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			_iMyCurrency = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().m_bondCurrency;
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().cbfdeda957ab87de3d0acf25194e61c4c(this);
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		_craftUIDataDic.Clear();
		_craftUIDataDic = ca92f7861d897701b7da0142e8c72331d.c7088de59e49f7108f520cf7e0bae167e;
		_craftUIConfigList.Clear();
		_craftUIConfigList = cb81e651e0bd5ec15159334424008a588.c7088de59e49f7108f520cf7e0bae167e;
		_currencyListener = null;
		if (m_particleManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_particleManager.c0bc4c65d4c28a31ec7a86abfb1230a81();
			UnityEngine.Object.DestroyObject(m_particleManager.gameObject);
			m_particleManager = cdf6841adbd4c48d1529ac5b42bd58b0a.c7088de59e49f7108f520cf7e0bae167e;
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().cfdafa122fc114376585cbb27b8811a86(this);
	}

	public virtual void c870d65a8957f7a97cafef5aacb0597ed(int c81c4edb577343e7a08c2082fd02230a0)
	{
		_iMyCurrency = c81c4edb577343e7a08c2082fd02230a0;
	}

	protected virtual void c648457d88d15dfd9c7a783596344e20b(bool c74232243aff1dcbf2e8fc243633bb51a)
	{
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
		if (!(m_particleManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			m_particleManager.c4ecc5a6775d113af396f25277e85adec();
			return;
		}
	}

	protected void c13b5cbde8cdfbbcce0eef62d154cba66()
	{
		_craftUIDataDic = new Dictionary<int, UICraftData>();
		TextAsset textAsset = (TextAsset)ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Settings/UI_WeaponCraft");
		XmlSerializer xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(c69f99076ae245e5a9cf955c6648abdcb.cc1720d05c75832f704b87474932341c3()));
		UI_WeaponCraftConfigContainer uI_WeaponCraftConfigContainer = xmlSerializer.Deserialize(new StringReader(textAsset.text)) as UI_WeaponCraftConfigContainer;
		Resources.UnloadAsset(textAsset);
		_craftUIConfigList = new List<UI_WeaponCraftConfig>(uI_WeaponCraftConfigContainer.UI_WeaponCraftConfigList);
		_craftUIConfigList.Sort(c912b7e7c7c572914695102035accb2a8);
	}

	protected int c912b7e7c7c572914695102035accb2a8(UI_WeaponCraftConfig cb23757880698a65db256be0a48f561b3, UI_WeaponCraftConfig cc1fa3171fa0e7211805389773c23a296)
	{
		return cb23757880698a65db256be0a48f561b3.Stage - cc1fa3171fa0e7211805389773c23a296.Stage;
	}

	public UICraftData ce6e2dc9c1406cba84a4b91e0eb344f4f(int cee9c68ec0b3bbdb423337b0d9c31b93e)
	{
		UICraftData value = c772ed908ea58c7248e7eabbd90a5992b.c7088de59e49f7108f520cf7e0bae167e;
		_craftUIDataDic.TryGetValue(cee9c68ec0b3bbdb423337b0d9c31b93e, out value);
		return value;
	}

	protected bool ce61597d466e52760ab41b5edd3ccd36b(UICraftData c6887d67d8a0ccf1b733f90ce230cfbc1)
	{
		return false;
	}
}
