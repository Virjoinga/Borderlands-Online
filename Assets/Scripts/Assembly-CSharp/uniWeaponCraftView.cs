using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using Core;
using UnityEngine;
using XsdSettings;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

public class uniWeaponCraftView : WeaponCraftView
{
	protected class MoneyCostPanel : c196099a1254db61d3be10d70e14e7422
	{
		protected int _iCurCnt;

		protected int _iRequireCnt;

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			(base.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip).addEventListener(CEvent.ENTER_FRAME, c77de347f5cc9efb7b4cb59c10d1fcbd9);
		}

		private void c77de347f5cc9efb7b4cb59c10d1fcbd9(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			MovieClip movieClip = base.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
			UnityTextField childByName = movieClip.getChildByName<UnityTextField>("txMoney");
			if (childByName == null)
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
				childByName.text = _iRequireCnt.ToString();
				return;
			}
		}

		public void ca422f6f2e66465eb697c47f8f5c61516(int c8414e0eb8ea69b29bd441ff486deb409, int c37a998b7f6684507f156c13f6d150b29)
		{
			_iCurCnt = c8414e0eb8ea69b29bd441ff486deb409;
			_iRequireCnt = c37a998b7f6684507f156c13f6d150b29;
			MovieClip movieClip = base.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
			if (c37a998b7f6684507f156c13f6d150b29 <= c8414e0eb8ea69b29bd441ff486deb409)
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
						movieClip.gotoAndStop("normal");
						return;
					}
				}
			}
			movieClip.gotoAndStop("missing point");
		}
	}

	protected class CraftConditionPanel : c196099a1254db61d3be10d70e14e7422
	{
		private Color ENOUGH_COLOR = Color.white;

		private Color LACK_COLOR = new Color(0.8901961f, 8f / 85f, 19f / 85f);

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			(ca37fcdce7d4937b60735f4033eb55695 as MovieClip).stopAll();
			ca37fcdce7d4937b60735f4033eb55695.visible = false;
		}

		public void c2135b02be5b1d8a550cec82f51f167ca(int c8414e0eb8ea69b29bd441ff486deb409, int c37a998b7f6684507f156c13f6d150b29, bool cac429d29f63fba3c46bd866666e6bdc8 = false)
		{
			ca37fcdce7d4937b60735f4033eb55695.visible = true;
			MovieClip movieClip = base.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
			UnityTextField childByName = movieClip.getChildByName<UnityTextField>("textRequired");
			if (childByName != null)
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
				childByName.text = Convert.ToString(c37a998b7f6684507f156c13f6d150b29);
			}
			UnityTextField childByName2 = movieClip.getChildByName<UnityTextField>("textGot");
			if (childByName2 == null)
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
				childByName2.text = Convert.ToString(c8414e0eb8ea69b29bd441ff486deb409);
				Color colorTransform;
				if (c37a998b7f6684507f156c13f6d150b29 <= c8414e0eb8ea69b29bd441ff486deb409)
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
					colorTransform = ENOUGH_COLOR;
				}
				else
				{
					colorTransform = LACK_COLOR;
				}
				childByName2.colorTransform = colorTransform;
				return;
			}
		}

		public void c70ac13a4e47735d080f5872abb7cb930(MaterialType c424fafa6354141c1e81d53efca575d8d)
		{
			ca37fcdce7d4937b60735f4033eb55695.visible = true;
			MovieClip childByName = base.c89ef242f4744e0f1c4ffea4da8b79bc1.getChildByName<MovieClip>("mcMaterialIcon");
			if (childByName == null)
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
				childByName.gotoAndStop(c424fafa6354141c1e81d53efca575d8d.ToString());
				return;
			}
		}
	}

	private class CraftScreen : c196099a1254db61d3be10d70e14e7422
	{
		private enum CraftState
		{
			CRAFT_INIT = 0,
			CRAFT_PREVIEW = 1,
			CRAFT = 2,
			CRAFT_OVERVIEW = 3,
			CRAFT_MELTING = 4,
			CRAFT_AGAIN = 5
		}

		private const string OPTION_NAME = "mcOptionButton";

		private const string GUN_PISTOL = "Weapon_Pistol";

		private const string GUN_SMG = "Weapon_SMG";

		private const string GUN_SHOTGUN = "Weapon_Shotgun";

		private const string GUN_SNIPER = "Weapon_Sniper";

		private const string GUN_COMBAT_RIFLE = "Weapon_Combat_Rifle";

		private const int NUM_OF_OPTIONBUTTON = 5;

		private const int NUM_OF_STARS = 9;

		private const float ANIM_TRIGGER_TIME = 1.75f;

		private const float m_rotateSpeed = 100f;

		private uniWeaponCraftView rootView;

		private string[] OPTION_LABEL;

		private MovieClip m_optionPanel;

		private MovieClip m_luckyPanel;

		private MovieClip m_conditionPanel;

		private MovieClip m_craftInfoPanel;

		private MovieClip m_meltInfoPanel;

		private MovieClip m_weaponCardPanel;

		private MovieClip m_topPanel;

		private MovieClip m_succAnim;

		private MovieClip m_buttons;

		private MovieClip mcCardPosition;

		private c82f7c0afbcfc8c5382a8c6daa9365b7b m_craftButton;

		private c82f7c0afbcfc8c5382a8c6daa9365b7b m_againButton;

		private c82f7c0afbcfc8c5382a8c6daa9365b7b m_meltButton;

		private c82f7c0afbcfc8c5382a8c6daa9365b7b m_backButton;

		private TextField m_weaponName;

		private CraftCardPanel mcRealWeaponCard;

		private bool m_isCraftable;

		private List<MovieClip> m_displayItems;

		private List<MovieClip> m_fadeInList;

		private List<MovieClip> m_fadeOutList;

		private List<CraftConditionPanel> m_conditionPanels;

		private MovieClip m_displayMC;

		private MovieClip m_weaponPortaitMC;

		private c7beefc397f483dc0b72dcd3e6bdcf929 m_weaponPortait;

		protected CraftConditionPanel m_materialPanelA;

		protected CraftConditionPanel m_materialPanelB;

		protected MoneyCostPanel m_currencyPanel;

		protected CraftConditionPanel m_materialPanelC;

		protected List<c82f7c0afbcfc8c5382a8c6daa9365b7b> m_optionButtons;

		protected string TYPE_CRAFT;

		protected string TYPE_PISTOL;

		protected string TYPE_SHOTGUN;

		protected string TYPE_GARBAGE;

		protected string TYPE_SNIPER;

		protected string TYPE_SMG;

		protected string TYPE_CombatRifle;

		protected string TYPE_MELTING;

		public MovieClip rootMC;

		private ItemDNA m_currentWeaponDNA;

		private WeaponType m_selectedWeaponType;

		private WeaponCraftConfig m_selectedCraftConfig;

		protected GameObject m_ShowingModel;

		private CraftState m_currentState;

		private string m_selectedType;

		protected int _iLastCraftedIndex;

		[CompilerGenerated]
		private static Dictionary<string, int> _003C_003Ef__switch_0024map2E;

		[CompilerGenerated]
		private static Dictionary<string, int> _003C_003Ef__switch_0024map2F;

		[CompilerGenerated]
		private static Dictionary<string, int> _003C_003Ef__switch_0024map30;

		public uniWeaponCraftView cc00077a05e4b169dfcc8322da5a9e637
		{
			set
			{
				rootView = value;
			}
		}

		public bool c150264a18c2cb408479d3f072cac8cc1
		{
			get
			{
				if (rootMC != null)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							if (1 == 0)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							return rootMC.visible;
						}
					}
				}
				return false;
			}
			set
			{
				if (rootMC == null)
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
					rootMC.visible = value;
					if (value)
					{
						while (true)
						{
							switch (2)
							{
							case 0:
								break;
							default:
								cb3e48ccaf8abc1bc092a8187bac63375();
								return;
							}
						}
					}
					cfcf3bf47eca22fed5cce1fa2a9e3ab69();
					return;
				}
			}
		}

		public CraftScreen()
		{
			string[] array = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(5);
			array[0] = "Weapon_Pistol";
			array[1] = "Weapon_SMG";
			array[2] = "Weapon_Shotgun";
			array[3] = "Weapon_Sniper";
			array[4] = "Weapon_Combat_Rifle";
			OPTION_LABEL = array;
			m_displayItems = new List<MovieClip>();
			m_fadeInList = new List<MovieClip>();
			m_fadeOutList = new List<MovieClip>();
			m_conditionPanels = new List<CraftConditionPanel>();
			m_materialPanelA = new CraftConditionPanel();
			m_materialPanelB = new CraftConditionPanel();
			m_currencyPanel = new MoneyCostPanel();
			m_materialPanelC = new CraftConditionPanel();
			m_optionButtons = new List<c82f7c0afbcfc8c5382a8c6daa9365b7b>();
			TYPE_CRAFT = "PTL_Weapon_Synthesis";
			TYPE_PISTOL = "PTL_Weapon_Crafting_Pistol";
			TYPE_SHOTGUN = "PTL_Weapon_Crafting_Shotgun";
			TYPE_GARBAGE = string.Empty;
			TYPE_SNIPER = "PTL_Weapon_Crafting_Sniper";
			TYPE_SMG = "PTL_Weapon_Crafting_Smg";
			TYPE_CombatRifle = "PTL_Weapon_Crafting_CombatRifle";
			TYPE_MELTING = "PTL_Weapon_Melting";
			_iLastCraftedIndex = -1;
			base._002Ector();
		}

		public void ce98dce90cf6af36b03b15c38773ab815()
		{
			m_currentState = CraftState.CRAFT_PREVIEW;
		}

		private void cb3e48ccaf8abc1bc092a8187bac63375()
		{
			if (m_displayMC != null)
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
				if (rootMC.contains(m_displayMC))
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
					rootMC.removeChild(m_displayMC);
				}
			}
			m_displayMC = new MovieClip();
			switch (m_currentState)
			{
			case CraftState.CRAFT_PREVIEW:
				cfce1db26c738386631c2292fb284aedb(c656b7be10c614ae4a7eb17c462d2f675.c7088de59e49f7108f520cf7e0bae167e);
				m_displayMC.addChild(m_topPanel);
				m_displayMC.addChild(m_optionPanel);
				m_fadeInList.Add(m_optionPanel);
				m_fadeInList.Add(m_luckyPanel);
				cfcf3bf47eca22fed5cce1fa2a9e3ab69();
				break;
			case CraftState.CRAFT:
				m_displayMC.addChild(m_topPanel);
				m_displayMC.addChild(m_optionPanel);
				m_displayMC.addChild(m_buttons);
				m_displayMC.addChild(m_conditionPanel);
				cfce1db26c738386631c2292fb284aedb(m_craftInfoPanel);
				m_meltButton.c150264a18c2cb408479d3f072cac8cc1 = false;
				m_againButton.c150264a18c2cb408479d3f072cac8cc1 = false;
				m_craftButton.c150264a18c2cb408479d3f072cac8cc1 = true;
				m_fadeInList.Add(m_conditionPanel);
				break;
			case CraftState.CRAFT_OVERVIEW:
				m_displayMC.addChild(m_topPanel);
				m_displayMC.addChild(m_weaponCardPanel);
				m_displayMC.addChild(mcRealWeaponCard.c89ef242f4744e0f1c4ffea4da8b79bc1);
				m_displayMC.addChild(m_buttons);
				m_displayMC.addChild(m_succAnim);
				m_fadeInList.Add(m_weaponCardPanel);
				m_displayMC.addChild(m_weaponPortaitMC);
				cfce1db26c738386631c2292fb284aedb(c656b7be10c614ae4a7eb17c462d2f675.c7088de59e49f7108f520cf7e0bae167e);
				m_succAnim.play();
				m_meltButton.c150264a18c2cb408479d3f072cac8cc1 = true;
				m_againButton.c150264a18c2cb408479d3f072cac8cc1 = true;
				m_craftButton.c150264a18c2cb408479d3f072cac8cc1 = false;
				break;
			case CraftState.CRAFT_AGAIN:
				m_meltButton.c150264a18c2cb408479d3f072cac8cc1 = true;
				m_againButton.c150264a18c2cb408479d3f072cac8cc1 = true;
				m_craftButton.c150264a18c2cb408479d3f072cac8cc1 = false;
				m_displayMC.addChild(m_weaponCardPanel);
				m_fadeOutList.Add(m_weaponCardPanel);
				cfce1db26c738386631c2292fb284aedb(c656b7be10c614ae4a7eb17c462d2f675.c7088de59e49f7108f520cf7e0bae167e);
				break;
			}
			c3914a0899c6599f083a698bc959f1479();
			rootMC.addChildAt(m_displayMC, 0);
		}

		private void cfcf3bf47eca22fed5cce1fa2a9e3ab69()
		{
			_iLastCraftedIndex = -1;
			if (!(m_ShowingModel != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				m_ShowingModel.SetActive(false);
				UnityEngine.Object.DestroyImmediate(m_ShowingModel);
				m_ShowingModel = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c0bd653723f77fd78e6c7d4d25ed14dcd(c7bb86b60f299c950179b9bd1c30a2a68);
				return;
			}
		}

		private void c3914a0899c6599f083a698bc959f1479()
		{
			for (int i = 0; i < m_displayItems.Count; i++)
			{
				if (m_displayMC.contains(m_displayItems[i]))
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
					m_displayItems[i].visible = true;
				}
				else
				{
					m_displayItems[i].visible = false;
				}
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				using (List<MovieClip>.Enumerator enumerator = m_fadeInList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						MovieClip current = enumerator.Current;
						current.gotoAndPlay("fadein");
					}
					while (true)
					{
						switch (5)
						{
						case 0:
							break;
						default:
							goto end_IL_00ac;
						}
						continue;
						end_IL_00ac:
						break;
					}
				}
				using (List<MovieClip>.Enumerator enumerator2 = m_fadeOutList.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						MovieClip current2 = enumerator2.Current;
						current2.gotoAndPlay("fadeout");
					}
					while (true)
					{
						switch (7)
						{
						case 0:
							break;
						default:
							goto end_IL_00f5;
						}
						continue;
						end_IL_00f5:
						break;
					}
				}
				m_fadeInList.Clear();
				m_fadeOutList.Clear();
				return;
			}
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			rootMC = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			rootMC.visible = false;
			cb3e48ccaf8abc1bc092a8187bac63375();
			m_currentState = CraftState.CRAFT_PREVIEW;
			if (rootMC != null)
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
				DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: CraftScreen onInit() 'rootMC' is null! InstancePanel won't work!!!");
				return;
			}
		}

		protected override bool OnWidgetInitialized(ref MovieClip mc, Type widgetType)
		{
			bool flag = false;
			flag = c543f1da1dd7682ad49f6823145387ff0(mc);
			string name = mc.name;
			if (name != null)
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
				if (_003C_003Ef__switch_0024map2E == null)
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
					Dictionary<string, int> dictionary = new Dictionary<string, int>(13);
					dictionary.Add("mcCardPosition", 0);
					dictionary.Add("mcBackButton", 1);
					dictionary.Add("mcWeaponCard", 2);
					dictionary.Add("mcOptionList", 3);
					dictionary.Add("mcTopBar", 4);
					dictionary.Add("mcLuckyPanel", 5);
					dictionary.Add("mcButtons", 6);
					dictionary.Add("mcSuccAnim", 7);
					dictionary.Add("mcCraftCondition", 8);
					dictionary.Add("mcImage", 9);
					dictionary.Add("mcButtonMelting", 10);
					dictionary.Add("mcButtonAgain", 11);
					dictionary.Add("mcButtonCraft", 12);
					_003C_003Ef__switch_0024map2E = dictionary;
				}
				int value;
				if (_003C_003Ef__switch_0024map2E.TryGetValue(name, out value))
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
					switch (value)
					{
					case 0:
						mcCardPosition = mc;
						flag = true;
						break;
					case 1:
						m_backButton = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
						m_backButton.c130648b59a0c8debea60aa153f844879(mc);
						m_backButton.addEventListener(MouseEvent.CLICK, c43a8328bc396b048a4e4073fefe1454e);
						break;
					case 2:
						m_weaponCardPanel = mc;
						m_weaponCardPanel.addEventListener(CEvent.ENTER_FRAME, cb6fbf8a462f8f0cb2ab60e8f51e244f3);
						m_displayItems.Add(m_weaponCardPanel);
						flag = false;
						break;
					case 3:
						m_optionPanel = mc;
						m_displayItems.Add(m_optionPanel);
						m_optionButtons.Clear();
						flag = false;
						break;
					case 4:
						m_topPanel = mc;
						m_displayItems.Add(m_topPanel);
						flag = true;
						break;
					case 5:
						m_luckyPanel = mc;
						m_displayItems.Add(m_luckyPanel);
						flag = true;
						break;
					case 6:
						m_buttons = mc;
						m_displayItems.Add(m_buttons);
						flag = false;
						break;
					case 7:
						m_succAnim = mc;
						m_succAnim.addFrameScript("animEnd", cd35969f5f2ec82c5e6ec079c9eade914);
						m_displayItems.Add(m_succAnim);
						flag = true;
						break;
					case 8:
					{
						m_conditionPanel = mc;
						m_conditionPanel.mouseEnabled = false;
						MovieClip childByName = m_conditionPanel.getChildByName<MovieClip>("mc");
						m_craftInfoPanel = childByName.getChildByName<MovieClip>("mcCraftInfo");
						m_meltInfoPanel = childByName.getChildByName<MovieClip>("mcMeltInfo");
						cfce1db26c738386631c2292fb284aedb(c656b7be10c614ae4a7eb17c462d2f675.c7088de59e49f7108f520cf7e0bae167e);
						m_displayItems.Add(m_conditionPanel);
						flag = true;
						break;
					}
					case 9:
						m_weaponPortaitMC = mc;
						m_displayItems.Add(m_weaponPortaitMC);
						m_weaponPortait = new c7beefc397f483dc0b72dcd3e6bdcf929();
						m_weaponPortait.c130648b59a0c8debea60aa153f844879(m_weaponPortaitMC);
						flag = true;
						break;
					case 10:
						m_meltButton = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
						m_meltButton.c130648b59a0c8debea60aa153f844879(mc);
						m_meltButton.addEventListener(MouseEvent.CLICK, c43a8328bc396b048a4e4073fefe1454e);
						m_meltButton.addEventListener(MouseEvent.MOUSE_ENTER, c9d22ac214a408a68188112805cc0c9f2);
						m_meltButton.addEventListener(MouseEvent.MOUSE_LEAVE, c1685fe5fcb785454a2e1dcbe4151aa0c);
						break;
					case 11:
						m_againButton = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
						m_againButton.c130648b59a0c8debea60aa153f844879(mc);
						m_againButton.addEventListener(MouseEvent.CLICK, c43a8328bc396b048a4e4073fefe1454e);
						m_againButton.addEventListener(MouseEvent.MOUSE_ENTER, c9d22ac214a408a68188112805cc0c9f2);
						m_againButton.addEventListener(MouseEvent.MOUSE_LEAVE, c1685fe5fcb785454a2e1dcbe4151aa0c);
						break;
					case 12:
						m_craftButton = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
						m_craftButton.c130648b59a0c8debea60aa153f844879(mc);
						m_craftButton.addEventListener(MouseEvent.CLICK, c43a8328bc396b048a4e4073fefe1454e);
						m_currencyPanel.c130648b59a0c8debea60aa153f844879(mc.getChildByName<MovieClip>("mcMoneyInfo"));
						break;
					}
				}
			}
			return flag;
		}

		private void cd35969f5f2ec82c5e6ec079c9eade914(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			m_succAnim.visible = false;
			if (m_displayMC == null)
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
				if (!m_displayMC.contains(m_succAnim))
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
					m_displayMC.removeChild(m_succAnim);
					return;
				}
			}
		}

		private bool c543f1da1dd7682ad49f6823145387ff0(MovieClip c998c56e5cab278873f1a5722e79733da)
		{
			if (c998c56e5cab278873f1a5722e79733da.name.Length > "mcOptionButton".Length)
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
				string text = c998c56e5cab278873f1a5722e79733da.name.Substring(0, "mcOptionButton".Length);
				if (text == "mcOptionButton")
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
						{
							int num = Convert.ToInt32(c998c56e5cab278873f1a5722e79733da.name.Substring("mcOptionButton".Length, c998c56e5cab278873f1a5722e79733da.name.Length - "mcOptionButton".Length));
							if (num < OPTION_LABEL.Length)
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
								if (num >= 0)
								{
									c82f7c0afbcfc8c5382a8c6daa9365b7b c82f7c0afbcfc8c5382a8c6daa9365b7b = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
									c82f7c0afbcfc8c5382a8c6daa9365b7b.c130648b59a0c8debea60aa153f844879(c998c56e5cab278873f1a5722e79733da);
									c82f7c0afbcfc8c5382a8c6daa9365b7b.cf798cedf450c3ad2a08ce2d2fd00d464 = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(OPTION_LABEL[num]));
									c82f7c0afbcfc8c5382a8c6daa9365b7b.addEventListener(MouseEvent.CLICK, c3474c8c00006814da1fb4174f81214fc);
									m_optionButtons.Add(c82f7c0afbcfc8c5382a8c6daa9365b7b);
									return true;
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
							object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
							array[0] = "Weapon Craft button name wrong! Index:";
							array[1] = num;
							array[2] = " is bigger than sum: ";
							array[3] = OPTION_LABEL.Length;
							DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, string.Concat(array));
							return true;
						}
						}
					}
				}
			}
			return false;
		}

		private void cfce1db26c738386631c2292fb284aedb(MovieClip c82fcbab5e578dc3a31c1f662916bd87e = null)
		{
			if (m_craftInfoPanel != null)
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
				m_craftInfoPanel.visible = false;
			}
			if (m_meltInfoPanel != null)
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
				m_meltInfoPanel.visible = false;
			}
			if (c82fcbab5e578dc3a31c1f662916bd87e != m_craftInfoPanel)
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
				if (c82fcbab5e578dc3a31c1f662916bd87e != m_meltInfoPanel)
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
					break;
				}
			}
			c82fcbab5e578dc3a31c1f662916bd87e.visible = true;
		}

		public void c2e3926d56cbdeac5e198ad8264e13fb5(CraftCardPanel cc6599ad24468b65beba8458e042d31d2)
		{
			mcRealWeaponCard = cc6599ad24468b65beba8458e042d31d2;
			if (m_displayMC == null)
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
				m_displayMC.addChild(mcRealWeaponCard.c89ef242f4744e0f1c4ffea4da8b79bc1);
				c8d84c77787484e4ab2ab5feed26df217();
				return;
			}
		}

		private void ca07b6998f91656fc5e0dc88b0f5ce6e3()
		{
			if (m_currentWeaponDNA == null)
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
				ItemDNA cd7c0d36f2c73807ca9525013ef = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<CharInfoView>().ccd0f6bcfcd12e28d498bb8d9a3a245c0();
				if (mcRealWeaponCard == null)
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
					mcRealWeaponCard.c58de56793cb96a279858c7b68a326d17(m_currentWeaponDNA, cd7c0d36f2c73807ca9525013ef);
					return;
				}
			}
		}

		private void c3474c8c00006814da1fb4174f81214fc(CEvent c05f6b47f5e84359168dfe9aaf57b8a79)
		{
			if (rootView.m_particleManager.c60e71916893de2f43e9cca97bd0edb64)
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
						return;
					}
				}
			}
			c82f7c0afbcfc8c5382a8c6daa9365b7b c82f7c0afbcfc8c5382a8c6daa9365b7b = c05f6b47f5e84359168dfe9aaf57b8a79.currentTarget as c82f7c0afbcfc8c5382a8c6daa9365b7b;
			if (c82f7c0afbcfc8c5382a8c6daa9365b7b == null)
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
				c26eeb16ee58ce88da9c77927275011e3(c82f7c0afbcfc8c5382a8c6daa9365b7b.cf798cedf450c3ad2a08ce2d2fd00d464);
				m_selectedType = c82f7c0afbcfc8c5382a8c6daa9365b7b.cf798cedf450c3ad2a08ce2d2fd00d464;
				m_selectedWeaponType = c527c6ad4774a0942e69962faef714d44(c82f7c0afbcfc8c5382a8c6daa9365b7b.cf798cedf450c3ad2a08ce2d2fd00d464);
				m_currentState = CraftState.CRAFT;
				c9b859eb2848c180afbb4a492123d7b39(m_craftInfoPanel);
				cb3e48ccaf8abc1bc092a8187bac63375();
				return;
			}
		}

		private void c9b859eb2848c180afbb4a492123d7b39(MovieClip c82fcbab5e578dc3a31c1f662916bd87e)
		{
			int num = c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c7513e66c4e0fc55e6fea9dd9cb8b9943();
			m_selectedCraftConfig = c907bc497a8a9036389f10fd2fed43d80.c7088de59e49f7108f520cf7e0bae167e;
			int num2 = 0;
			while (true)
			{
				if (num2 < c1ee7921b0c3cce194fb7cae41b5a9d82<CraftingServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.m_craftMgr.m_WeaponCraftConfigs.Length)
				{
					if (num >= c1ee7921b0c3cce194fb7cae41b5a9d82<CraftingServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.m_craftMgr.m_WeaponCraftConfigs[num2].m_MinLevel)
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
						if (num <= c1ee7921b0c3cce194fb7cae41b5a9d82<CraftingServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.m_craftMgr.m_WeaponCraftConfigs[num2].m_MaxLevel)
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
							if (c1ee7921b0c3cce194fb7cae41b5a9d82<CraftingServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.m_craftMgr.m_WeaponCraftConfigs[num2].m_WeaponType == m_selectedWeaponType)
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
								m_selectedCraftConfig = c1ee7921b0c3cce194fb7cae41b5a9d82<CraftingServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.m_craftMgr.m_WeaponCraftConfigs[num2];
								break;
							}
						}
					}
					num2++;
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
				break;
			}
			if (m_selectedCraftConfig != null)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						ca6b669f2ceb4fb386ba78c88f1602d97(c82fcbab5e578dc3a31c1f662916bd87e, m_selectedCraftConfig, c61748f02dbf9c81bf0e2b31b40e2fd38.c7088de59e49f7108f520cf7e0bae167e);
						return;
					}
				}
			}
			object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
			array[0] = "UIWarning: [WeaponCraft]: Can't find the corresponding weapon with Level: ";
			array[1] = num;
			array[2] = " with Type: ";
			array[3] = m_selectedWeaponType;
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, string.Concat(array));
		}

		private void ca6b669f2ceb4fb386ba78c88f1602d97(MovieClip c82fcbab5e578dc3a31c1f662916bd87e, WeaponCraftConfig c7c8d1f67065c3ebdd981dabe7d2ea2cb = null, AcquiredMaterial[] c6e7076514ab6e826d0e046d6e3700b64 = null)
		{
			m_conditionPanels.Clear();
			bool flag = true;
			bool flag2 = c82fcbab5e578dc3a31c1f662916bd87e == m_craftInfoPanel;
			m_conditionPanels.Clear();
			m_materialPanelA.c130648b59a0c8debea60aa153f844879(c82fcbab5e578dc3a31c1f662916bd87e.getChildByName<MovieClip>("mcMaterialInfoA"));
			m_materialPanelB.c130648b59a0c8debea60aa153f844879(c82fcbab5e578dc3a31c1f662916bd87e.getChildByName<MovieClip>("mcMaterialInfoB"));
			m_materialPanelC.c130648b59a0c8debea60aa153f844879(c82fcbab5e578dc3a31c1f662916bd87e.getChildByName<MovieClip>("mcMaterialInfoC"));
			m_conditionPanels.Add(m_materialPanelA);
			m_conditionPanels.Add(m_materialPanelB);
			m_conditionPanels.Add(m_materialPanelC);
			if (flag2)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
					{
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						m_craftButton.cbf402c82d0fffee7c8f37c98e456b8f8 = flag;
						int currency = c7c8d1f67065c3ebdd981dabe7d2ea2cb.m_Currency;
						int iMyCurrency = rootView._iMyCurrency;
						m_currencyPanel.c130648b59a0c8debea60aa153f844879(m_craftButton.c89ef242f4744e0f1c4ffea4da8b79bc1.getChildByName<MovieClip>("mcMoneyInfo"));
						m_currencyPanel.ca422f6f2e66465eb697c47f8f5c61516(iMyCurrency, currency);
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
							flag = c42129f4134f5048a9abb2fe44d5fd9cd(iMyCurrency, currency);
						}
						m_isCraftable = flag;
						if (c7c8d1f67065c3ebdd981dabe7d2ea2cb != null)
						{
							while (true)
							{
								switch (5)
								{
								case 0:
									break;
								default:
								{
									for (int i = 0; i < c7c8d1f67065c3ebdd981dabe7d2ea2cb.m_CraftConditions.Length; i++)
									{
										if (m_conditionPanels[i] != null)
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
											MaterialType matCondition = c7c8d1f67065c3ebdd981dabe7d2ea2cb.m_CraftConditions[i].m_MatCondition;
											currency = c7c8d1f67065c3ebdd981dabe7d2ea2cb.m_CraftConditions[i].m_MatConditionQuantity;
											iMyCurrency = c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cdff08bd623e04fdde40092784eebdeec(matCondition);
											m_conditionPanels[i].c2135b02be5b1d8a550cec82f51f167ca(iMyCurrency, currency);
											m_conditionPanels[i].c70ac13a4e47735d080f5872abb7cb930(matCondition);
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
												if (flag2)
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
													flag = c42129f4134f5048a9abb2fe44d5fd9cd(iMyCurrency, currency);
												}
											}
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
								}
							}
						}
						return;
					}
					}
				}
			}
			if (c6e7076514ab6e826d0e046d6e3700b64 == null)
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
				for (int j = 0; j < c6e7076514ab6e826d0e046d6e3700b64.Length; j++)
				{
					if (m_conditionPanels[j] == null)
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
					MaterialType matCondition = c6e7076514ab6e826d0e046d6e3700b64[j].m_MaterialType;
					int currency = c6e7076514ab6e826d0e046d6e3700b64[j].m_MaterialNums;
					int iMyCurrency = c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cdff08bd623e04fdde40092784eebdeec(matCondition);
					m_conditionPanels[j].c2135b02be5b1d8a550cec82f51f167ca(currency, currency);
					m_conditionPanels[j].c70ac13a4e47735d080f5872abb7cb930(matCondition);
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
		}

		private bool c42129f4134f5048a9abb2fe44d5fd9cd(int c8506fa521f2b6bb69f425337620c6cf4, int cfce8375024afda0aa6e4e2c5e4474370)
		{
			return cfce8375024afda0aa6e4e2c5e4474370 <= c8506fa521f2b6bb69f425337620c6cf4;
		}

		private void c26eeb16ee58ce88da9c77927275011e3(string cf798cedf450c3ad2a08ce2d2fd00d464)
		{
			cf798cedf450c3ad2a08ce2d2fd00d464 = caaeb0ad088b157aac080fc0cab62557b(cf798cedf450c3ad2a08ce2d2fd00d464);
			rootView.m_particleManager.ce4c6859b04b271fe37b2049334c686b7(c5ab3608d518618070a44683447edb4fe(cf798cedf450c3ad2a08ce2d2fd00d464), false, true);
		}

		private string c5ab3608d518618070a44683447edb4fe(string cf798cedf450c3ad2a08ce2d2fd00d464)
		{
			string result = string.Empty;
			if (cf798cedf450c3ad2a08ce2d2fd00d464 != null)
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
				if (_003C_003Ef__switch_0024map2F == null)
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
					Dictionary<string, int> dictionary = new Dictionary<string, int>(5);
					dictionary.Add("Weapon_Pistol", 0);
					dictionary.Add("Weapon_Shotgun", 1);
					dictionary.Add("Weapon_Sniper", 2);
					dictionary.Add("Weapon_SMG", 3);
					dictionary.Add("Weapon_Combat_Rifle", 4);
					_003C_003Ef__switch_0024map2F = dictionary;
				}
				int value;
				if (_003C_003Ef__switch_0024map2F.TryGetValue(cf798cedf450c3ad2a08ce2d2fd00d464, out value))
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
					switch (value)
					{
					case 0:
						result = TYPE_PISTOL;
						break;
					case 1:
						result = TYPE_SHOTGUN;
						break;
					case 2:
						result = TYPE_SNIPER;
						break;
					case 3:
						result = TYPE_SMG;
						break;
					case 4:
						result = TYPE_CombatRifle;
						break;
					}
				}
			}
			return result;
		}

		private string caaeb0ad088b157aac080fc0cab62557b(string cf798cedf450c3ad2a08ce2d2fd00d464)
		{
			string result = string.Empty;
			string[] oPTION_LABEL = OPTION_LABEL;
			int num = 0;
			while (true)
			{
				if (num < oPTION_LABEL.Length)
				{
					string text = oPTION_LABEL[num];
					if (LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(text)) == cf798cedf450c3ad2a08ce2d2fd00d464)
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
						result = text;
						break;
					}
					num++;
					continue;
				}
				while (true)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					break;
				}
				break;
			}
			return result;
		}

		private void c4f4b6827d56ded8e5b1ee74066bcc906()
		{
			m_weaponPortaitMC.visible = false;
			m_weaponPortait.c150264a18c2cb408479d3f072cac8cc1 = false;
			TexPostEffectMgr.POST_EFFECT_TYPE cd3f028c57829f7f55d1c76f674c82eac = TexPostEffectMgr.POST_EFFECT_TYPE.POST_EFFECT_BlUEPRINT;
			m_weaponPortait.c533af2b08173b7c2e3e5405efc254ee3(c06ca0e618478c23eba3419653a19760f<DNAPortrait>.c5ee19dc8d4cccf5ae2de225410458b86.c6965e945a09324a9af86f14518e0a697(m_currentWeaponDNA, (int)m_weaponPortaitMC.width, (int)m_weaponPortaitMC.height, cd3f028c57829f7f55d1c76f674c82eac));
			m_weaponPortaitMC.visible = true;
			m_weaponPortait.c150264a18c2cb408479d3f072cac8cc1 = true;
		}

		private WeaponType c527c6ad4774a0942e69962faef714d44(string c27b7430edc94b8f5b543605119ec4a72)
		{
			WeaponType result = WeaponType.RepeaterPistol;
			c27b7430edc94b8f5b543605119ec4a72 = caaeb0ad088b157aac080fc0cab62557b(c27b7430edc94b8f5b543605119ec4a72);
			string text = c27b7430edc94b8f5b543605119ec4a72;
			if (text != null)
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
				if (_003C_003Ef__switch_0024map30 == null)
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
					Dictionary<string, int> dictionary = new Dictionary<string, int>(5);
					dictionary.Add("Weapon_Pistol", 0);
					dictionary.Add("Weapon_Shotgun", 1);
					dictionary.Add("Weapon_SMG", 2);
					dictionary.Add("Weapon_Sniper", 3);
					dictionary.Add("Weapon_Combat_Rifle", 4);
					_003C_003Ef__switch_0024map30 = dictionary;
				}
				int value;
				if (_003C_003Ef__switch_0024map30.TryGetValue(text, out value))
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
					switch (value)
					{
					case 0:
						result = WeaponType.RepeaterPistol;
						break;
					case 1:
						result = WeaponType.ShotGun;
						break;
					case 2:
						result = WeaponType.SMG;
						break;
					case 3:
						result = WeaponType.SniperRifle;
						break;
					case 4:
						result = WeaponType.CombatRifle;
						break;
					}
				}
			}
			return result;
		}

		private void cb6fbf8a462f8f0cb2ab60e8f51e244f3(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			c8d84c77787484e4ab2ab5feed26df217();
		}

		private void c8d84c77787484e4ab2ab5feed26df217()
		{
			if (mcRealWeaponCard == null)
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
				Vector2 zero = Vector2.zero;
				zero = ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.c46e387bea9111b07d3d0e2e52548626c(mcCardPosition, zero);
				zero = ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.c88ec770b25554e17182648d69403ceb1(mcRealWeaponCard.c89ef242f4744e0f1c4ffea4da8b79bc1.parent, zero);
				mcRealWeaponCard.c89ef242f4744e0f1c4ffea4da8b79bc1.x = zero.x;
				mcRealWeaponCard.c89ef242f4744e0f1c4ffea4da8b79bc1.y = zero.y;
				return;
			}
		}

		private void c2dae6d5808c9fc581247a70e09746ffd(bool ce789f9c3fe56ee71c44c6992c4b590bb)
		{
		}

		private void c43a8328bc396b048a4e4073fefe1454e(CEvent c05f6b47f5e84359168dfe9aaf57b8a79)
		{
			c82f7c0afbcfc8c5382a8c6daa9365b7b c82f7c0afbcfc8c5382a8c6daa9365b7b = c05f6b47f5e84359168dfe9aaf57b8a79.currentTarget as c82f7c0afbcfc8c5382a8c6daa9365b7b;
			if (rootView.m_particleManager.c60e71916893de2f43e9cca97bd0edb64)
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
				if (!c82f7c0afbcfc8c5382a8c6daa9365b7b.cbf402c82d0fffee7c8f37c98e456b8f8)
				{
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
				if (c05f6b47f5e84359168dfe9aaf57b8a79.currentTarget == m_meltButton)
				{
					while (true)
					{
						switch (4)
						{
						case 0:
							break;
						default:
							if (!c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c6facc64e2d5edf33221db1a902d2ccf3(c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e))
							{
								while (true)
								{
									switch (7)
									{
									case 0:
										break;
									default:
										if (_iLastCraftedIndex >= 0)
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
											c1ee7921b0c3cce194fb7cae41b5a9d82<CraftingServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c2b738a0787415710b9ab86768a28207d(c2dae6d5808c9fc581247a70e09746ffd, _iLastCraftedIndex);
										}
										m_currentState = CraftState.CRAFT_MELTING;
										rootView.m_particleManager.cd4e7c1b68eb7ce6b3b5b73c4784f6a7b = 0.2f;
										rootView.m_particleManager.cfcebba48dc2e80dc073a4b69fb28025c += c587531823733f1a08c78dbf3118d0930;
										rootView.m_particleManager.ce4c6859b04b271fe37b2049334c686b7(TYPE_MELTING, true, true, ce17e500712c426223dfe0a41e7753421);
										return;
									}
								}
							}
							return;
						}
					}
				}
				if (c05f6b47f5e84359168dfe9aaf57b8a79.currentTarget == m_againButton)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							if (m_isCraftable)
							{
								while (true)
								{
									switch (7)
									{
									case 0:
										break;
									default:
										if (!c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c6facc64e2d5edf33221db1a902d2ccf3(c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e))
										{
											while (true)
											{
												switch (3)
												{
												case 0:
													break;
												default:
													cfcf3bf47eca22fed5cce1fa2a9e3ab69();
													m_currentState = CraftState.CRAFT_AGAIN;
													c1ee7921b0c3cce194fb7cae41b5a9d82<CraftingServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c99dc1247f2835cc10ef79f23e75449c8(c99ae92f389544e2a4f291bfb6b8812db, m_selectedWeaponType);
													c06ca0e618478c23eba3419653a19760f<GuidanceTipsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c93a582e07019617943999be8717d5134("guidance_craft");
													return;
												}
											}
										}
										return;
									}
								}
							}
							return;
						}
					}
				}
				if (c05f6b47f5e84359168dfe9aaf57b8a79.currentTarget == m_craftButton)
				{
					while (true)
					{
						switch (5)
						{
						case 0:
							break;
						default:
							if (m_currentState == CraftState.CRAFT)
							{
								while (true)
								{
									switch (4)
									{
									case 0:
										break;
									default:
										if (m_isCraftable)
										{
											while (true)
											{
												switch (5)
												{
												case 0:
													break;
												default:
													if (!c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c6facc64e2d5edf33221db1a902d2ccf3(c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e))
													{
														while (true)
														{
															switch (6)
															{
															case 0:
																break;
															default:
																c1ee7921b0c3cce194fb7cae41b5a9d82<CraftingServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c99dc1247f2835cc10ef79f23e75449c8(c99ae92f389544e2a4f291bfb6b8812db, m_selectedWeaponType);
																c06ca0e618478c23eba3419653a19760f<GuidanceTipsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c93a582e07019617943999be8717d5134("guidance_craft");
																return;
															}
														}
													}
													return;
												}
											}
										}
										return;
									}
								}
							}
							return;
						}
					}
				}
				if (c05f6b47f5e84359168dfe9aaf57b8a79.currentTarget != m_backButton)
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
					if (m_currentState <= CraftState.CRAFT_INIT)
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
						m_currentState = CraftState.CRAFT_PREVIEW;
						rootView.m_particleManager.c4ecc5a6775d113af396f25277e85adec();
						cb3e48ccaf8abc1bc092a8187bac63375();
						return;
					}
				}
			}
		}

		public void c99ae92f389544e2a4f291bfb6b8812db(bool c52f5e366c8290ecf393023808a31b2d0, int ca29859f37633e432643818b81cb7dd0d, ItemDNA c6887d67d8a0ccf1b733f90ce230cfbc1)
		{
			if (c52f5e366c8290ecf393023808a31b2d0)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						_iLastCraftedIndex = ca29859f37633e432643818b81cb7dd0d;
						m_currentWeaponDNA = c6887d67d8a0ccf1b733f90ce230cfbc1;
						ca07b6998f91656fc5e0dc88b0f5ce6e3();
						if (m_currentState == CraftState.CRAFT)
						{
							while (true)
							{
								switch (1)
								{
								case 0:
									break;
								default:
									rootView.m_particleManager.cd4e7c1b68eb7ce6b3b5b73c4784f6a7b = 1.75f;
									rootView.m_particleManager.cfcebba48dc2e80dc073a4b69fb28025c += c587531823733f1a08c78dbf3118d0930;
									rootView.m_particleManager.ce4c6859b04b271fe37b2049334c686b7(TYPE_CRAFT, true, false, ce17e500712c426223dfe0a41e7753421);
									return;
								}
							}
						}
						if (m_currentState == CraftState.CRAFT_AGAIN)
						{
							while (true)
							{
								switch (2)
								{
								case 0:
									break;
								default:
									cb3e48ccaf8abc1bc092a8187bac63375();
									c26eeb16ee58ce88da9c77927275011e3(m_selectedType);
									rootView.m_particleManager.cd4e7c1b68eb7ce6b3b5b73c4784f6a7b = 1.75f;
									rootView.m_particleManager.cfcebba48dc2e80dc073a4b69fb28025c += c587531823733f1a08c78dbf3118d0930;
									rootView.m_particleManager.ce4c6859b04b271fe37b2049334c686b7(TYPE_CRAFT, true, false, ce17e500712c426223dfe0a41e7753421);
									return;
								}
							}
						}
						return;
					}
				}
			}
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "can't generate weapon type: " + m_selectedWeaponType);
		}

		private void c9e471fe202309e11da473179548f3874(string c0776ef3d9221a4a4962a4559b0e35bdd, bool ced0c442e7caee66f81925eab644ba898 = false)
		{
			rootView.m_particleManager.cd4e7c1b68eb7ce6b3b5b73c4784f6a7b = 1.75f;
			rootView.m_particleManager.cfcebba48dc2e80dc073a4b69fb28025c += c587531823733f1a08c78dbf3118d0930;
			rootView.m_particleManager.ce4c6859b04b271fe37b2049334c686b7(c0776ef3d9221a4a4962a4559b0e35bdd, true, ced0c442e7caee66f81925eab644ba898, ce17e500712c426223dfe0a41e7753421);
		}

		public void ce17e500712c426223dfe0a41e7753421()
		{
			switch (m_currentState)
			{
			case CraftState.CRAFT_MELTING:
				m_currentState = CraftState.CRAFT_PREVIEW;
				cb3e48ccaf8abc1bc092a8187bac63375();
				break;
			}
			rootView.m_particleManager.c6c0ce637fe6b1e45f54d3bcdb7c3219c -= ce17e500712c426223dfe0a41e7753421;
		}

		public void c587531823733f1a08c78dbf3118d0930()
		{
			switch (m_currentState)
			{
			case CraftState.CRAFT:
			case CraftState.CRAFT_AGAIN:
				if (m_weaponPortait != null)
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
					if (m_currentWeaponDNA != null)
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
						rootView.m_particleManager.c3a0100e580804bee1cfac6fe64194ce6(0);
						(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c462fe1a64a37daab5e61f688d9a61e7f("UI_Wep_Upgrade_Glow_Success");
						c06ca0e618478c23eba3419653a19760f<WeaponFactory>.c5ee19dc8d4cccf5ae2de225410458b86.cc5bc70567710d6a69882bdd6416a1db9(m_currentWeaponDNA.ca79da172938fdc8c067fb64242b6174a(), c55f17871c3376b87483caf11ac9597a8);
						m_currentState = CraftState.CRAFT_OVERVIEW;
						goto IL_00b7;
					}
				}
				m_currentState = CraftState.CRAFT;
				goto IL_00b7;
			case CraftState.CRAFT_MELTING:
				{
					cfcf3bf47eca22fed5cce1fa2a9e3ab69();
					rootView.m_particleManager.ce4c6859b04b271fe37b2049334c686b7(TYPE_GARBAGE, true);
					break;
				}
				IL_00b7:
				cb3e48ccaf8abc1bc092a8187bac63375();
				break;
			}
			rootView.m_particleManager.cfcebba48dc2e80dc073a4b69fb28025c -= c587531823733f1a08c78dbf3118d0930;
		}

		public void c55f17871c3376b87483caf11ac9597a8(ref GameObject cd1505a8bc35681ef0fed8cd958a8b539, WeaponDNA caedbc1db6c28d44eab6021e7d674eab3)
		{
			m_ShowingModel = cd1505a8bc35681ef0fed8cd958a8b539;
			SkinnedMeshRenderer skinnedMeshRenderer = BuildingKitGenerator.cc9bfa7a11dd9e2e916f75a4eb41a63ab(cd1505a8bc35681ef0fed8cd958a8b539);
			skinnedMeshRenderer.material.SetTexture("_Cube", c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_levelCubemap);
			EntityWeapon.c1395e48881f07b054bc50fabaea80b76(cd1505a8bc35681ef0fed8cd958a8b539, EntityWeapon.c338e1019b68c1ba415414bd8d6cd4cae(caedbc1db6c28d44eab6021e7d674eab3.m_attribute));
			m_ShowingModel.transform.parent = rootView.c4faeec55f2ffcf5aba0dce86db47aa54.transform;
			m_ShowingModel.transform.localPosition = rootView.c4faeec55f2ffcf5aba0dce86db47aa54.transform.FindChild("PTL_Weapon_Crafting").localPosition;
			m_ShowingModel.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
			m_ShowingModel.transform.RotateAround(skinnedMeshRenderer.bounds.center, Vector3.up, 90f);
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c239889f6079aa61647e3c4b8f3627d00(c7bb86b60f299c950179b9bd1c30a2a68);
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c462fe1a64a37daab5e61f688d9a61e7f("Itm_Pickup_Gun");
		}

		private void c7bb86b60f299c950179b9bd1c30a2a68()
		{
			if (!(m_ShowingModel != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				SkinnedMeshRenderer skinnedMeshRenderer = BuildingKitGenerator.cc9bfa7a11dd9e2e916f75a4eb41a63ab(m_ShowingModel);
				Vector3 center = skinnedMeshRenderer.bounds.center;
				if (!c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.c0c86fb4d044c654b1e26019953887548("Fire1"))
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
					float num = 100f;
					float num2 = (0f - Input.GetAxis("Mouse X")) * num;
					float num3 = Math.Abs(num2);
					if (!(num3 > 0.01f))
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
						if (num2 < 0f)
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
							num *= -1f;
						}
						m_ShowingModel.transform.RotateAround(center, Vector3.up, num * Time.deltaTime);
						return;
					}
				}
			}
		}

		private void c9d22ac214a408a68188112805cc0c9f2(CEvent c05f6b47f5e84359168dfe9aaf57b8a79)
		{
			if (m_currentState != CraftState.CRAFT_OVERVIEW)
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
				if (m_displayMC.contains(m_succAnim))
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
					m_succAnim.visible = false;
					m_displayMC.removeChild(m_succAnim);
				}
				if (c05f6b47f5e84359168dfe9aaf57b8a79.currentTarget == m_meltButton.c3514472a8118f64bd85e108dfb38ab5b)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							m_displayMC.addChild(m_conditionPanel);
							m_conditionPanel.gotoAndPlay("fadein");
							cfce1db26c738386631c2292fb284aedb(m_meltInfoPanel);
							ca6b669f2ceb4fb386ba78c88f1602d97(m_meltInfoPanel, null, c1ee7921b0c3cce194fb7cae41b5a9d82<CraftingServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c8f918c4274c34c1d3e8adb2ea8dd8022(m_currentWeaponDNA.ca79da172938fdc8c067fb64242b6174a()));
							c3914a0899c6599f083a698bc959f1479();
							return;
						}
					}
				}
				if (c05f6b47f5e84359168dfe9aaf57b8a79.currentTarget != m_againButton.c3514472a8118f64bd85e108dfb38ab5b)
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
					m_displayMC.addChild(m_conditionPanel);
					m_conditionPanel.gotoAndPlay("fadein");
					cfce1db26c738386631c2292fb284aedb(m_craftInfoPanel);
					ca6b669f2ceb4fb386ba78c88f1602d97(m_craftInfoPanel, m_selectedCraftConfig, c61748f02dbf9c81bf0e2b31b40e2fd38.c7088de59e49f7108f520cf7e0bae167e);
					c3914a0899c6599f083a698bc959f1479();
					return;
				}
			}
		}

		private void c1685fe5fcb785454a2e1dcbe4151aa0c(CEvent c05f6b47f5e84359168dfe9aaf57b8a79)
		{
			if (m_currentState != CraftState.CRAFT_OVERVIEW)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (c05f6b47f5e84359168dfe9aaf57b8a79.currentTarget == null)
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
					if (!m_displayMC.contains(m_conditionPanel))
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
						m_displayMC.removeChild(m_conditionPanel);
						c3914a0899c6599f083a698bc959f1479();
						return;
					}
				}
			}
		}
	}

	private class CraftCardPanel : ItemCardPanel
	{
		public override void c58de56793cb96a279858c7b68a326d17(ItemDNA ca57e1c076c01141c5ce58c7341db7833, ItemDNA cd7c0d36f2c73807ca9525013ef524075)
		{
			base.c58de56793cb96a279858c7b68a326d17(ca57e1c076c01141c5ce58c7341db7833, cd7c0d36f2c73807ca9525013ef524075);
			_comparePanel.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = false;
		}
	}

	private CraftScreen _craftScreen;

	private CraftCardPanel _weaponPanel;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("WeaponCraft-2014.swf", "Movie_Whole", cfe9a4ad63de24ecb7e1e47656cd80cb2);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("Tips.swf", "Panel_Tips_Card", c2848be988d8375963ba50b523c39d160);
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_craftScreen);
		_craftScreen = null;
		_weaponPanel = null;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("WeaponCraft-2014.swf");
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("Tips.swf");
	}

	private void cfe9a4ad63de24ecb7e1e47656cd80cb2(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_craftScreen = new CraftScreen();
		_craftScreen.cc00077a05e4b169dfcc8322da5a9e637 = this;
		_craftScreen.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		if (_weaponPanel == null)
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
			_craftScreen.c2e3926d56cbdeac5e198ad8264e13fb5(_weaponPanel);
			return;
		}
	}

	private void c2848be988d8375963ba50b523c39d160(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_weaponPanel = new CraftCardPanel();
		_weaponPanel.c130648b59a0c8debea60aa153f844879(new MovieClip());
		_weaponPanel.cd351226c5175db6eab2a3dd9ec9ff57c(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		if (_craftScreen == null)
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
			_craftScreen.c2e3926d56cbdeac5e198ad8264e13fb5(_weaponPanel);
			return;
		}
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
		if (_bVisible)
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
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cb4341b3564e3d55dc9f38df4b813c5da(_craftScreen);
		}
		_craftScreen.c150264a18c2cb408479d3f072cac8cc1 = _bVisible;
		if (_bVisible)
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
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_craftScreen);
			return;
		}
	}

	public override bool cc130a2d46a451dc54b61a8f0d60794ae()
	{
		if (c150264a18c2cb408479d3f072cac8cc1)
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
					_craftScreen.ce98dce90cf6af36b03b15c38773ab815();
					NPC_UIFlowController.c71f6ce28731edfd43c976fbd57c57bea().cfdf90c86b56eee510f610ea962abe27b(NPC_UIFlowController.NPC_UIFlowState.None);
					return true;
				}
			}
		}
		return base.cc130a2d46a451dc54b61a8f0d60794ae();
	}
}
