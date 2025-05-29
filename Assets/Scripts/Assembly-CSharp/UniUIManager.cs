using System;
using System.Collections;
using System.Collections.Generic;
using A;
using Core;
using UnityEngine;
using XsdSettings;
using pumpkin.display;
using pumpkin.events;
using pumpkin.swf;

public class UniUIManager : GameUIManager, c49bb938a37c8524e589afd493c802ea7
{
	public class UniSWFToolClass
	{
		public static Dictionary<WeaponCardDisplayType, Color> _WeaponAddAttColorMap = new Dictionary<WeaponCardDisplayType, Color>
		{
			{
				WeaponCardDisplayType.ManufacturerWord,
				Color.white
			},
			{
				WeaponCardDisplayType.ZoomWord,
				Color.white
			},
			{
				WeaponCardDisplayType.ExtraSlotWord,
				new Color(0f, 0.984314f, 0.913725f)
			},
			{
				WeaponCardDisplayType.CorrosiveWord,
				new Color(0f, 1f, 0.090196f)
			},
			{
				WeaponCardDisplayType.ShockWord,
				new Color(0f, 0.709804f, 1f)
			},
			{
				WeaponCardDisplayType.FireWord,
				new Color(1f, 0.435294f, 0f)
			}
		};

		public static Dictionary<string, Color> _ElementColorMap = new Dictionary<string, Color>
		{
			{
				"Normal",
				new Color(0.843137f, (float)Math.E * 105f / 302f, 1f)
			},
			{
				AttackInfo.ElementalType.Explosive.ToString(),
				new Color(0.756862f, 0.007843f, 0.007843f)
			},
			{
				AttackInfo.ElementalType.Fire.ToString(),
				new Color(1f, 0.6f, 0f)
			},
			{
				AttackInfo.ElementalType.Shock.ToString(),
				new Color(0.190697f, 0.482352f, 0.803921f)
			},
			{
				AttackInfo.ElementalType.Corrosive.ToString(),
				new Color(0.007843f, 241f, 0.007843f)
			},
			{
				"Red",
				new Color(0.756862f, 0.007843f, 0.007843f)
			}
		};

		public static Dictionary<AttackInfo.ElementalType, string> _ElementFrameMap = new Dictionary<AttackInfo.ElementalType, string>
		{
			{
				AttackInfo.ElementalType.None,
				string.Empty
			},
			{
				AttackInfo.ElementalType.Explosive,
				"exp"
			},
			{
				AttackInfo.ElementalType.Fire,
				"fire"
			},
			{
				AttackInfo.ElementalType.Shock,
				"shock"
			},
			{
				AttackInfo.ElementalType.Corrosive,
				"corr"
			},
			{
				AttackInfo.ElementalType.Max,
				string.Empty
			}
		};

		public static string[] _BrandStringMap;

		public static Dictionary<ItemRarity, Color> _RarityColorMap;

		static UniSWFToolClass()
		{
			string[] array = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(5);
			array[0] = "vladop";
			array[1] = "dahl";
			array[2] = "maliwan";
			array[3] = "atlas";
			array[4] = "hyperion";
			_BrandStringMap = array;
			_RarityColorMap = new Dictionary<ItemRarity, Color>
			{
				{
					ItemRarity.Common,
					Color.white
				},
				{
					ItemRarity.Uncommon,
					new Color(0.313725f, (float)Math.E * 105f / 302f, 0.423529f)
				},
				{
					ItemRarity.Rare,
					new Color(0.12549f, 0.168627f, 0.968627f)
				},
				{
					ItemRarity.VeryRare,
					new Color(0.509803f, 0.12549f, 1f)
				},
				{
					ItemRarity.Epic,
					new Color(0.905882f, 0.435294f, 0.90196f)
				},
				{
					ItemRarity.MetaEpic,
					new Color(1f, 0.533333f, 0.16862f)
				}
			};
		}

		public static string c829860ccd1c2bd1526f02a4101640f7a(float c28327e5696c34f96d435cf14f468b287, float ce6bfae16131482731aae4c02fecf7aed, int c4b530a4e4ce10d7440b315772c817880 = 10)
		{
			return c829860ccd1c2bd1526f02a4101640f7a(Mathf.FloorToInt(c28327e5696c34f96d435cf14f468b287 * (float)c4b530a4e4ce10d7440b315772c817880), Mathf.FloorToInt(ce6bfae16131482731aae4c02fecf7aed * (float)c4b530a4e4ce10d7440b315772c817880));
		}

		public static string c829860ccd1c2bd1526f02a4101640f7a(int cb4dd868481f8e5a7d05ab61288fa7cc6, int ca97331706bdf1c4e721f487886a94629)
		{
			int num = cb4dd868481f8e5a7d05ab61288fa7cc6 - ca97331706bdf1c4e721f487886a94629;
			if (num > 0)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						return "up";
					}
				}
			}
			if (num < 0)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						return "down";
					}
				}
			}
			return "same";
		}

		public static string cdb5e1aceb6b2fd7da6a4e3b93ab68865(ItemDNA ca57e1c076c01141c5ce58c7341db7833)
		{
			string text = string.Empty;
			switch (ca57e1c076c01141c5ce58c7341db7833.m_type)
			{
			case ItemType.Weapon:
				text = "_" + ca57e1c076c01141c5ce58c7341db7833.ca79da172938fdc8c067fb64242b6174a().c83e548e5608cd7f222098a6966b16545();
				break;
			case ItemType.Ammo:
				text = "_" + ca57e1c076c01141c5ce58c7341db7833.m_ammoType;
				break;
			}
			return ca57e1c076c01141c5ce58c7341db7833.m_type.ToString() + text;
		}

		public static Color c87015237d139b95339567fd82054be1b(ItemRarity cefda2fdc3ce4e04f38bab77fc7998241)
		{
			return _RarityColorMap[cefda2fdc3ce4e04f38bab77fc7998241];
		}

		public static Color c87015237d139b95339567fd82054be1b(WeaponRarity cefda2fdc3ce4e04f38bab77fc7998241)
		{
			return _RarityColorMap[(ItemRarity)cefda2fdc3ce4e04f38bab77fc7998241];
		}

		public static Color c7fad7b5218f6951e51fe893390ef3e3c(int c6364a1ea73ee58271ff4959f5e56f6ba, int c3c0235d80cd7cc076318dfafad62574d)
		{
			if (c6364a1ea73ee58271ff4959f5e56f6ba >= c3c0235d80cd7cc076318dfafad62574d)
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
						return Color.white;
					}
				}
			}
			return Color.red;
		}

		public static int c001baac049112f025f0375d4fb44e2b0(string c27db047aa304dfb00a82236ee9963324, string cf983b704939790ebd5b011514031b947)
		{
			int result = -1;
			if (c27db047aa304dfb00a82236ee9963324.Length > cf983b704939790ebd5b011514031b947.Length)
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
				string text = c27db047aa304dfb00a82236ee9963324.Substring(0, cf983b704939790ebd5b011514031b947.Length);
				if (text == cf983b704939790ebd5b011514031b947)
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
					result = Convert.ToInt32(c27db047aa304dfb00a82236ee9963324.Substring(cf983b704939790ebd5b011514031b947.Length, c27db047aa304dfb00a82236ee9963324.Length - cf983b704939790ebd5b011514031b947.Length));
				}
			}
			return result;
		}

		public static Color c086651c22e0343f3b0c0e7248aafc15f(AttackInfo.ElementalType ce2b7197da5b5b7b8dc90bf07f2199bea)
		{
			return c086651c22e0343f3b0c0e7248aafc15f(ce2b7197da5b5b7b8dc90bf07f2199bea.ToString());
		}

		public static Color c086651c22e0343f3b0c0e7248aafc15f(string ce2b7197da5b5b7b8dc90bf07f2199bea)
		{
			if (_ElementColorMap.ContainsKey(ce2b7197da5b5b7b8dc90bf07f2199bea))
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
						return _ElementColorMap[ce2b7197da5b5b7b8dc90bf07f2199bea];
					}
				}
			}
			return Color.white;
		}

		public static Color c4e58bbb395c6e7f02f6d88d05f41b180(WeaponCardDisplayType cf39b3e28036216b9dd77b3a379af25ba)
		{
			if (_WeaponAddAttColorMap.ContainsKey(cf39b3e28036216b9dd77b3a379af25ba))
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
						return _WeaponAddAttColorMap[cf39b3e28036216b9dd77b3a379af25ba];
					}
				}
			}
			return Color.white;
		}

		public static Rect ca32a2d214165802d3f1493d30c8bf414(Rect cc538a191e5e347c259afcf42b22c28d8)
		{
			return new Rect(cc538a191e5e347c259afcf42b22c28d8.x, 1f - cc538a191e5e347c259afcf42b22c28d8.y - cc538a191e5e347c259afcf42b22c28d8.height, cc538a191e5e347c259afcf42b22c28d8.width, cc538a191e5e347c259afcf42b22c28d8.height);
		}
	}

	private struct MovieLoadedCaller
	{
		public MovieClip movie;

		public FuncLoad func;
	}

	public class HUDMaskPanel : c196099a1254db61d3be10d70e14e7422
	{
		protected MovieClip _rootMC;

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			_rootMC = base.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
			_rootMC.addFrameScript("last", cd35969f5f2ec82c5e6ec079c9eade914);
			_rootMC.visible = false;
		}

		protected void cd35969f5f2ec82c5e6ec079c9eade914(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			_rootMC.visible = false;
		}

		public void c43cbb41bf755dfa61de619fc6e86ab31(bool c8be1fcd630e5fe96821376d111325750)
		{
			if (c8be1fcd630e5fe96821376d111325750)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						if (!_rootMC.visible)
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
							_rootMC.gotoAndPlay("start");
						}
						_rootMC.visible = true;
						return;
					}
				}
			}
			_rootMC.gotoAndPlay("end");
		}
	}

	public const string URL_PREFAB_2DCAMERA = "UI_uniSWF/2DUICamera";

	public const string URL_PREFAB_PRELOADER = "UI_uniSWF/UIPreLoader";

	public const string URL_PREFAB_UISOUND_TRIG = "UI_uniSWF/UISoundTrigger";

	public const string URL_PREFAB_FONT_SWAP_MANAGER = "UI_uniSWF/fonts/UnityFontManager";

	private const int CAMERA_DEPTH = 100;

	private const string WORLD3D_LAYER_NAME = "world3D";

	private const string FPS_LAYER_NAME = "fps";

	private const string BACKGROUND_LAYER_NAME = "background";

	private const string NORMAL_LAYER_NAME = "normal";

	private const string FRONT_LAYER_NAME = "front";

	private const string COVER_LAYER_NAME = "cover";

	private const string TOP_LAYER_NAME = "top";

	private const string AUDIO_RESOURCES_LIST_NAME = "UIAudioResources";

	private Stage _curStage;

	private BadAssUICameraBehaviour _uniSWFCameraBehaviour;

	private GameObject _2DCamera;

	private GameObject _UIPreLoader;

	private GameObject _FontSwapManager;

	private HUDMaskPanel _HUDMask;

	private MovieClip _CoverMask;

	private GameObject _UISoundTrigger;

	private AudioEventTriggerCtl _AudioTrigger;

	private bool _SoundResourcesLoaded;

	private float lastClickTime = -1f;

	private DisplayObject lastClickObj;

	private c03af373dabef31755c89798fb2c75bbe _dropArea;

	private Queue<MovieLoadedCaller> _queMovieLoadedList = new Queue<MovieLoadedCaller>();

	public c03af373dabef31755c89798fb2c75bbe cbc15476a9112020f8fa67ca3691284d5
	{
		get
		{
			return _dropArea;
		}
	}

	public Stage c0c584b58aa13cc5471c8b4aec04bf8a1
	{
		get
		{
			return _curStage;
		}
	}

	public override bool c4717862155dcb63da4094ee983c75b38
	{
		get
		{
			int result;
			if (_shortCutEnabled)
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
				result = ((!c7faa6f1d3168c8fb9e598b66c8c1c1fd.ccf24681862bae286c19d5c9b16296be5.c2e9cd7194d5ed5215de1bea1b1954592) ? 1 : 0);
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}
		set
		{
			base.c4717862155dcb63da4094ee983c75b38 = value;
		}
	}

	private void Awake()
	{
		base.gameObject.AddComponent<UniResourceManager>();
	}

	protected override void c3ce49ac9f742f8aabdab94a8a84b5bca()
	{
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(cb4a5cdd404af21575e712f84ebae45fb.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c867c69f039c0bd8b7344e67737b39d49.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(cb2a242afbc3fd1cd5f18dea48c781532.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c7dec7334c136cde2a2e03935f42d1af4.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c217f6b676f75d73ff573bf9fa94cc5af.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(cde81e8e522b74c05a6dfd4ab5a7c18b1.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(cf088114bc1198c734457f18f168417e9.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(ccce893fdb6717ea8ff059423c27d5515.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(ca44ecdb762e48e155cfe6e1a2d6cfa45.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c6453f8b385bbbf69beffd29904d1a1c9.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(cff415b3e8872ea0e9d6e41194535ff0d.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c03d6932ae3ad053fac22336e8d955912.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c8664a63dda836468ac250fd8a37bea7f.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c2e279247c4eaf945d6df44aa049a2628.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(cef8257ff5951b9bc14785a762e9ed95b.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(cd7de872563496dcda412d5bb2518f007.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(cb7104a5cdb8b002ff032cc4f1a7034c9.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c4be8e69d85e4aea5904c2ce7e10ec0b7.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c24fbe21ca6e854d0567069f2b48cc534.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c2f885dfffdf78b3a8b81f1812b74b05a.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c3e34d7bd82cd647ef0afcf5e73def934.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c4efd641bc701329b71e283fb97466410.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c6a571677699a38c82ae4d06c4e9e2f93.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c0d5d4d6e8e5957fb2418ab4dea1164fc.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(cb8f3cfa26fc1ff9d47691f65b0e7fe1e.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(cfe71d8295725127d071f9cad487c722c.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c59b3aadf0ba4f0a5227adb5266173f6c.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(cb6885dbee26442248d530a8d10a17f84.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(ce2fd2d8d1565ee5c7c992499caad548b.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(ceb4a86430a9d697e1e6bf8c60ac3a976.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c5cbfa998921f1c87e278ee3e3dbd3ac3.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(ce0ca64dbb5078935a7d1b78bb6f3af5a.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c66f2aa08ef9ffab68d1175b4010d1fe5.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(cd3b3eecd1d08413181492d45c2d5cacc.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c2ba4ca6c382c65b7b65517ceb1aceb86.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c5dd9d83454c8171e74873ac7fc29bc36.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c7b2bea133bf2b28134953106c5a107fa.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(cec43ccc7583c457bac78c6cdf5fd6291.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c908049a42d7c79b78977acad600d2b2f.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(cb87596b1705b782871aec14e4b6fb14a.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c2fd0e0e5181ef3a0c4a8d73bac704813.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(cc8d817b6974781f25443a0f3394d06d0.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c9687de25e41bf6d5c83fc6d67a14d995.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(cd6239defd54812e54ca6b4317f7a7044.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(cf24d70e6794b63fcd5439935ed3de5ad.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c7ede9536f064d8dd5f6f6b763e9ef3d9.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(cf02f01fa05d428f988fc7b74a5aeffac.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c055e6b080d97207ddad3552266d6ecfe.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c0ace980826ba79c438da6bf2a12c98f2.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c808b814b7febaad55ad24693fca4150a.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c6cd9fb035a5cd499328a2aa5dc4b6d47.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c6ec8ae7d2a9b4302697b8da6e7e526ed.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c1a48e3ad6f8ade407f14a992ca514cdd.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c012513b842249f580adf91d8b319cd7d.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(cba275f8c4b44fa9681e0d7a4f6977730.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c2dc9b0cdfbaea0aa91589c27ef11735e.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c1a54dd42bc81b27be6a884c1946edbe3.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c6009a8dab28df4995a4bffb4b6079868.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c576f0382791376cd226f28e9027ff62a.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(cf9ff46b0c76d243c86007d27dcc6c45b.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(ce1c6e7d5c30f0904d8e5ed028407b714.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c19bbdea279d50e8f7280e38bd0f9b80d.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(cf59f278edb373ee7711bd28f66d3dcff.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c2116d7ce5b5f44a6f4cb2933fe05e9b2.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c14f28a0a33177ca1a3294bf0489b47f2.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c11ef2073093b7ea70985a2308dd7451d.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(cb05b42023a4b84e002785e9c4292df12.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(ceba3a830346fdfb5f6fcae428fe92750.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(ca4a6daaf147f142128d1128c1e301072.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c02a67ff8c75dbad097fc4f47f5e580b5.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c80098d4c036cfd84b1369cc2430df40a.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c26f521c324e9728918b49ed7cfd7381b.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(cdbceaea51182e415981ff7f477e18fa0.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c477e46bb9a0b9639b4f487603117b3ad.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c78453e6b49a3881020efd19da56378ae.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(cc463a18465e371cd1b4dd6d091655958.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(cb9072169c5c6854602da22346c14a050.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c83263f44c52ce3facac2f8d27526aef7.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(cbffb91ee2ee5d0002993ca724c0f7341.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(cf1a6017441786427a7c10a890ef4cb3b.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(ceb8d83569215e7047ec75f3fb94ad782.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c42dd16719d2f9eb9569172a92f47cc30.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(cff8bf0af564a12a63dbbb3ead5e04646.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c2a94fe7900c78086e46d318f362493f0.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c911e7f1b388335bb5b1580d9da755ebe.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c363a97a91f61c2618adae5c3208db1ce.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(cbb81b09532259cc99ac179c4cbe64f55.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(cee304aa33272a5c43efe404ada9c1d9b.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(cc6a6f28a01fcbdd7e8035f2a0fb51f59.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c5ffab5752dc0e0ac059f7c45984ed620.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c4f44724cfcf62c6b6721ef81fa654c45.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(ce7a533d72039daef9c3425570cc2a44b.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(ce03b9a4cb67af167b86ec9e20b34b35d.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c58b8dc4774c00f36d7737afddc786f77.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c6b93f794b77541370577a70406cf3b3a.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c0bc6100d204416428146c640d02134ba.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(cd11fcb53b267059435321074d936eb03.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(ccdaa4d654deeb32c13d01aa75373510c.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c4e0ceae6200a1e6d933f5166864fac46.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(cea3ddfd561dfc0678d031a21d68e9852.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(ca2926352accdb38b6260681e4001b759.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c4782486580fd5a4af123b918131ada35.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c9f927f41b21fa1757bdc63c66ba8c2bb.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c762dcbad8ad3b19850db7f485c6dcfdf.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c76eac0c0bf3a5ee0748e25a410901506.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c052a9148744cd2dd1eed146d49028027.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c3f33536c8599ae417be7910bb239cfe4.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c405a98466a50e54d06afda7105dc9a77.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c0e77f90ef22ce306a74fd04a464284c1.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c746ebd59d37b64b24a842db27d6db3f6.cc1720d05c75832f704b87474932341c3()));
	}

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		ca00f4bcde573bcbfcc12adbf29f015cb.c5ee19dc8d4cccf5ae2de225410458b86.cb6d184fc20b0f925a0a263c7daf95878("Movie", Type.GetTypeFromHandle(cac7e769bd9ff3614baa30ee830e71c17.cc1720d05c75832f704b87474932341c3()));
		ca00f4bcde573bcbfcc12adbf29f015cb.c5ee19dc8d4cccf5ae2de225410458b86.cb6d184fc20b0f925a0a263c7daf95878("Panel", Type.GetTypeFromHandle(c2df66c141f0c711430f5acf7cb2a5bf6.cc1720d05c75832f704b87474932341c3()));
		ca00f4bcde573bcbfcc12adbf29f015cb.c5ee19dc8d4cccf5ae2de225410458b86.cb6d184fc20b0f925a0a263c7daf95878("Button", Type.GetTypeFromHandle(ccabee8e1901ea9cb73e59a1557fc98f1.cc1720d05c75832f704b87474932341c3()));
		ca00f4bcde573bcbfcc12adbf29f015cb.c5ee19dc8d4cccf5ae2de225410458b86.cb6d184fc20b0f925a0a263c7daf95878("TextInput", Type.GetTypeFromHandle(c5b33ed661dc52f3a5e69141ad0c4e7c9.cc1720d05c75832f704b87474932341c3()));
		ca00f4bcde573bcbfcc12adbf29f015cb.c5ee19dc8d4cccf5ae2de225410458b86.cb6d184fc20b0f925a0a263c7daf95878("Radio", Type.GetTypeFromHandle(cb1ce8888ef06fb60ee69cf4283c0b660.cc1720d05c75832f704b87474932341c3()));
		ca00f4bcde573bcbfcc12adbf29f015cb.c5ee19dc8d4cccf5ae2de225410458b86.cb6d184fc20b0f925a0a263c7daf95878("StatusIndicator", Type.GetTypeFromHandle(ceeffa59dcc4da250c0f3ab5474660941.cc1720d05c75832f704b87474932341c3()));
		ca00f4bcde573bcbfcc12adbf29f015cb.c5ee19dc8d4cccf5ae2de225410458b86.cb6d184fc20b0f925a0a263c7daf95878("ItemSlot", Type.GetTypeFromHandle(cd82f294d18ce2abf5949956b0a5b94bb.cc1720d05c75832f704b87474932341c3()));
		ca00f4bcde573bcbfcc12adbf29f015cb.c5ee19dc8d4cccf5ae2de225410458b86.cb6d184fc20b0f925a0a263c7daf95878("DragTarget", Type.GetTypeFromHandle(c9f2c9e3f80be49875e84d597855edb3c.cc1720d05c75832f704b87474932341c3()));
		ca00f4bcde573bcbfcc12adbf29f015cb.c5ee19dc8d4cccf5ae2de225410458b86.cb6d184fc20b0f925a0a263c7daf95878("ScrollBar", Type.GetTypeFromHandle(cea6f379a91fdbb26e4276d135b055fab.cc1720d05c75832f704b87474932341c3()));
		ca00f4bcde573bcbfcc12adbf29f015cb.c5ee19dc8d4cccf5ae2de225410458b86.cb6d184fc20b0f925a0a263c7daf95878("ImageLoader", Type.GetTypeFromHandle(ced74216e457380c52850a6f2ef5eea56.cc1720d05c75832f704b87474932341c3()));
		c703c5fded04cda53a7b6b36f5ca11a10.c5ee19dc8d4cccf5ae2de225410458b86.c742b85efc6c77d281bdc450a250ebf71(this);
		c4a380b8e70871ee3aa8030eee921d70a();
		c4d3150c4df6b08823b721d2b422e9673();
		c71c764143de1193004ee488875078a5f();
		c609d586f076fbdf47fcfc5c169f02a94();
		c50277233cfb1a61d4c9ee8ba7117aaa7();
		GameObject gameObject = new GameObject("DNAPortrait");
		gameObject.layer = LayerMask.NameToLayer("UI");
		gameObject.AddComponent<DNAPortrait>();
		c114035b255a7c79daf00b8613364145c(gameObject);
	}

	public override bool c7239543e613e42c603e3f4786aa2ecb7()
	{
		if (_curStage == null)
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
					return false;
				}
			}
		}
		int result;
		if (_curStage.mouseOver != null)
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
			result = ((_curStage.mouseOver.name != "StageMC") ? 1 : 0);
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public override void c758cf934d27a077d85165dce3424bb11(bool c74232243aff1dcbf2e8fc243633bb51a)
	{
		if (_curStage == null)
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
			_curStage.visible = c74232243aff1dcbf2e8fc243633bb51a;
			return;
		}
	}

	private void c4a380b8e70871ee3aa8030eee921d70a()
	{
		ca8a3999646c0089ff3a98776d44baf96();
		cccee174f93fbccef84c007e26aa3ef5a();
		cf971ef1ee6664c05793b23b6270d31c5();
		StartCoroutine(cb1e6f458e4a06317ce1a75ab0fde8946());
		c7df38c3cc75c6c3dafb99603e8875ab4();
	}

	protected void c609d586f076fbdf47fcfc5c169f02a94()
	{
		MovieClip movieClip = new MovieClip("CommonLib.swf:Blank_Fill");
		movieClip.name = "StageMC";
		movieClip.getChildAt(0).name = "StageMC";
		ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.c1a18960a16cc8dc828c90c3843668810(movieClip, "fps");
		float x = (movieClip.y = 0f);
		movieClip.x = x;
		x = (movieClip.scaleY = 256f);
		movieClip.scaleX = x;
		movieClip.alpha = 0f;
	}

	protected void c4d3150c4df6b08823b721d2b422e9673()
	{
		_CoverMask = new MovieClip("CommonLib.swf:black_bg");
		MovieClip coverMask = _CoverMask;
		float num = 512f;
		_CoverMask.scaleY = num;
		coverMask.scaleX = num;
		MovieClip coverMask2 = _CoverMask;
		num = -256f;
		_CoverMask.y = num;
		coverMask2.x = num;
		_CoverMask.visible = false;
		ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.c1a18960a16cc8dc828c90c3843668810(_CoverMask, "cover");
	}

	public override void c5257d6aefccfc702e44803405b9ffab8(bool c74232243aff1dcbf2e8fc243633bb51a)
	{
		if (_CoverMask == null)
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
			_CoverMask.visible = c74232243aff1dcbf2e8fc243633bb51a;
			return;
		}
	}

	protected void c71c764143de1193004ee488875078a5f()
	{
		MovieClip movieClip = new MovieClip("CommonLib.swf:HUDMask");
		float scaleX = (movieClip.scaleY = 512f);
		movieClip.scaleX = scaleX;
		scaleX = (movieClip.y = 0f);
		movieClip.x = scaleX;
		_HUDMask = new HUDMaskPanel();
		_HUDMask.c130648b59a0c8debea60aa153f844879(movieClip);
		c3394fa6fcf7eedce1842a3db0dcb7c9b(_HUDMask);
	}

	public override void c2dc5e286b7faa1029d7be508be9ce924(bool c74232243aff1dcbf2e8fc243633bb51a)
	{
		base.c2dc5e286b7faa1029d7be508be9ce924(c74232243aff1dcbf2e8fc243633bb51a);
		if (NPC_UIFlowController.c71f6ce28731edfd43c976fbd57c57bea().cd885bd4479d20f52c6f209bf46f58b98)
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
			if (c5a9245d284a4186b1df5f04b4559bab8<InstanceView>().c150264a18c2cb408479d3f072cac8cc1)
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
				if (c5a9245d284a4186b1df5f04b4559bab8<WorldMapSelectView>().c150264a18c2cb408479d3f072cac8cc1)
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
				_HUDMask.c43cbb41bf755dfa61de619fc6e86ab31(c74232243aff1dcbf2e8fc243633bb51a);
				return;
			}
		}
	}

	protected void cf92085b7029accabd5506526b87ced44()
	{
		cfee572141c4c64ed54776a1fc0a86d8b c5637318b04f333783d533b8d35151eb = new cfee572141c4c64ed54776a1fc0a86d8b();
		cb499a98793686af339aeb844b7aa3df7.ccf24681862bae286c19d5c9b16296be5.cd93285db16841148ed53a5bbeb35cf20(c5637318b04f333783d533b8d35151eb);
	}

	protected void c50277233cfb1a61d4c9ee8ba7117aaa7()
	{
		_dropArea = new c03af373dabef31755c89798fb2c75bbe();
		MovieClip movieClip = new MovieClip("CommonLib.swf:Blank_Fill");
		_dropArea.c130648b59a0c8debea60aa153f844879(movieClip);
		c3394fa6fcf7eedce1842a3db0dcb7c9b(_dropArea);
		float x = (movieClip.y = 0f);
		movieClip.x = x;
		x = (movieClip.scaleY = 256f);
		movieClip.scaleX = x;
		movieClip.alpha = 0f;
	}

	protected void cf971ef1ee6664c05793b23b6270d31c5()
	{
		if (_FontSwapManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			UnityEngine.Object.Destroy(_FontSwapManager);
			_FontSwapManager = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
		}
		_FontSwapManager = UnityEngine.Object.Instantiate(ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("UI_uniSWF/fonts/UnityFontManager")) as GameObject;
		_FontSwapManager.transform.position = new Vector3(-1000f, -1000f, -1000f);
		c114035b255a7c79daf00b8613364145c(_FontSwapManager);
	}

	public override bool c5383bc84e8cae50fac6d2363cda700d1()
	{
		return _SoundResourcesLoaded;
	}

	public void c7df38c3cc75c6c3dafb99603e8875ab4()
	{
		List<string> list = new List<string>();
		list.Clear();
		StartCoroutine(c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad618dcc0547ebee513a30332046d81f(list, c4dbeec74e2a149376b67d6770916b61c));
	}

	private void c4dbeec74e2a149376b67d6770916b61c(object cd22aa6735988e8e65acbd503f3870e3e = null)
	{
		c06ca0e618478c23eba3419653a19760f<UniResourceManager>.c5ee19dc8d4cccf5ae2de225410458b86.c70b22c09cdc3ef99f97282d52b3acf62();
	}

	public override IEnumerator cb1e6f458e4a06317ce1a75ab0fde8946()
	{
		if (_UISoundTrigger == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			_UISoundTrigger = UnityEngine.Object.Instantiate(ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("UI_uniSWF/UISoundTrigger")) as GameObject;
			_AudioTrigger = _UISoundTrigger.GetComponent<AudioEventTriggerCtl>();
			UnityEngine.Object.DontDestroyOnLoad(_UISoundTrigger);
		}
		if (_AudioTrigger == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.GUI, "UI_uniSWF--> 2D Audio load failed!!");
		}
		yield return c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e;
		if (cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5def92cf2ece25f46fbe9356a28a245b)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
				{
					IEnumerator UIAudioResourceLoader = cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.c9f6a0386ce93c761939b8a4def1e3435.c51989e5eff27ea24d05531bbbf9de22b("UIAudioResources", true);
					while (UIAudioResourceLoader.MoveNext())
					{
						yield return UIAudioResourceLoader.Current;
					}
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							_SoundResourcesLoaded = true;
							yield break;
						}
					}
				}
				}
			}
		}
		DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.GUI, "AudioSystem is not available when trying to load UI resources");
	}

	public override void c1206463c349318a3daf072e855c7eaec()
	{
		if (!(_AudioTrigger != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.c68d5fe96dbd54537a81187198113d273.c3ec6c8a3b3017de44fe7215da4f4ba2d(_AudioTrigger.transform);
			return;
		}
	}

	protected void ca8a3999646c0089ff3a98776d44baf96()
	{
		MovieClipPlayer.enableScale9 = true;
		MovieClipPlayer.rootResourceLoader = c06ca0e618478c23eba3419653a19760f<UniResourceManager>.c5ee19dc8d4cccf5ae2de225410458b86.c4f968fce1aac9ab6a4eedf95fca4e6c9;
		if (_UIPreLoader != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			UnityEngine.Object.Destroy(_UIPreLoader);
			_UIPreLoader = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
		}
		_UIPreLoader = UnityEngine.Object.Instantiate(ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("UI_uniSWF/UIPreLoader")) as GameObject;
		UnityEngine.Object.DontDestroyOnLoad(_UIPreLoader);
		c06ca0e618478c23eba3419653a19760f<UniResourceManager>.c5ee19dc8d4cccf5ae2de225410458b86.c4f968fce1aac9ab6a4eedf95fca4e6c9.AllowSceneLoader();
	}

	protected void cccee174f93fbccef84c007e26aa3ef5a()
	{
		if (_2DCamera != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			UnityEngine.Object.Destroy(_2DCamera);
			_2DCamera = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
		}
		if (_curStage != null)
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
			_curStage.removeEventListener(CEvent.RESIZE, c4a86b79b50c9b7133b4757d2614cccd4);
			_curStage = cf71ff3d1499a6fa4573967c70e12cb87.c7088de59e49f7108f520cf7e0bae167e;
		}
		GameObject gameObject = UnityEngine.Object.Instantiate(ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("UI_uniSWF/2DUICamera")) as GameObject;
		if (gameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.GUI, "UI_uniSWF--> 2D Camera prefab load failed!!");
					return;
				}
			}
		}
		_2DCamera = gameObject;
		_uniSWFCameraBehaviour = _2DCamera.GetComponent<BadAssUICameraBehaviour>();
		_curStage = _uniSWFCameraBehaviour.stage;
		ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.c1e172bfb5184630068d909f8fe1e728c = _curStage;
		_curStage.addEventListener(CEvent.RESIZE, c4a86b79b50c9b7133b4757d2614cccd4);
		_uniSWFCameraBehaviour.camera.depth = 100f;
		c114035b255a7c79daf00b8613364145c(gameObject);
		ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.cbc53582735b798af68be1963fbb04755("world3D");
		ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.cbc53582735b798af68be1963fbb04755("fps");
		ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.cbc53582735b798af68be1963fbb04755("background");
		ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.cbc53582735b798af68be1963fbb04755("normal");
		ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.cbc53582735b798af68be1963fbb04755("front");
		c340ad4e1f1707c51248b1d3b50723a7e.ccf24681862bae286c19d5c9b16296be5.cd93285db16841148ed53a5bbeb35cf20();
		ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.cbc53582735b798af68be1963fbb04755("cover");
		ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.cbc53582735b798af68be1963fbb04755("top");
		cf92085b7029accabd5506526b87ced44();
	}

	public bool cb4341b3564e3d55dc9f38df4b813c5da(c167c0089e0a52ec3a626bca450276515 cc6599ad24468b65beba8458e042d31d2)
	{
		if (_curStage == null)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.GUI, "UniSwf UI stage is null!!!");
					return false;
				}
			}
		}
		ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.c1a18960a16cc8dc828c90c3843668810(cc6599ad24468b65beba8458e042d31d2.c89ef242f4744e0f1c4ffea4da8b79bc1, "normal");
		return true;
	}

	public bool c7d5a91af372c5abe00435cdf71f886ad(c167c0089e0a52ec3a626bca450276515 cc6599ad24468b65beba8458e042d31d2)
	{
		if (_curStage != null)
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
					ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.c1a18960a16cc8dc828c90c3843668810(cc6599ad24468b65beba8458e042d31d2.c89ef242f4744e0f1c4ffea4da8b79bc1, "front");
					return true;
				}
			}
		}
		return false;
	}

	public bool c120a0ab44e69ef682f36041c0b116750(c167c0089e0a52ec3a626bca450276515 cc6599ad24468b65beba8458e042d31d2)
	{
		if (_curStage != null)
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
					ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.c1a18960a16cc8dc828c90c3843668810(cc6599ad24468b65beba8458e042d31d2.c89ef242f4744e0f1c4ffea4da8b79bc1, "top");
					return true;
				}
			}
		}
		return false;
	}

	public bool c561fe037bc737c4c5c91e0ed62eb07b7(c167c0089e0a52ec3a626bca450276515 cc6599ad24468b65beba8458e042d31d2)
	{
		if (_curStage != null)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.c1a18960a16cc8dc828c90c3843668810(cc6599ad24468b65beba8458e042d31d2.c89ef242f4744e0f1c4ffea4da8b79bc1, "world3D");
					return true;
				}
			}
		}
		return false;
	}

	public bool c848674781d88e6f4b9eb89ca2b6f4610(c167c0089e0a52ec3a626bca450276515 cc6599ad24468b65beba8458e042d31d2)
	{
		if (_curStage != null)
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
					ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.c1a18960a16cc8dc828c90c3843668810(cc6599ad24468b65beba8458e042d31d2.c89ef242f4744e0f1c4ffea4da8b79bc1, "fps");
					return true;
				}
			}
		}
		return false;
	}

	public bool c3394fa6fcf7eedce1842a3db0dcb7c9b(c167c0089e0a52ec3a626bca450276515 cc6599ad24468b65beba8458e042d31d2)
	{
		if (_curStage != null)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.c1a18960a16cc8dc828c90c3843668810(cc6599ad24468b65beba8458e042d31d2.c89ef242f4744e0f1c4ffea4da8b79bc1, "background");
					return true;
				}
			}
		}
		return false;
	}

	public void c27542a6dc8f97862ef53db1d4f3a6db8(c167c0089e0a52ec3a626bca450276515 cc6599ad24468b65beba8458e042d31d2)
	{
		if (cc6599ad24468b65beba8458e042d31d2 == null)
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.GUI, "panel is null!!!");
					return;
				}
			}
		}
		cc6599ad24468b65beba8458e042d31d2.OnRemovedFromStage();
		ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.c858d49c3aa8b8f3ea460cdf0aaa021bc(cc6599ad24468b65beba8458e042d31d2.c89ef242f4744e0f1c4ffea4da8b79bc1);
	}

	private void c4a86b79b50c9b7133b4757d2614cccd4(CEvent cd729d94a5b443ac0f1b117450e5f4419)
	{
		ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.OnScreenResize(Screen.width, Screen.height);
		_uniSWFCameraBehaviour.c5f24a0d05e731dfa07ce87cd4b26666b(new Vector2(ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.c38416c96b869af0e164ff13994b8aa12, ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.c38416c96b869af0e164ff13994b8aa12));
		OnScreenResized(Screen.width, Screen.height);
	}

	public void c310b2d257bd8a8197ae0e4f146fb8c8b()
	{
		_uniSWFCameraBehaviour.c5f24a0d05e731dfa07ce87cd4b26666b(new Vector2(ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.c38416c96b869af0e164ff13994b8aa12, ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.c38416c96b869af0e164ff13994b8aa12), true);
	}

	public virtual void c462fe1a64a37daab5e61f688d9a61e7f(string c45fd7f5a766449817c6df573f08ae226)
	{
		if (!(_AudioTrigger != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			_AudioTrigger.TriggerEventByName(c45fd7f5a766449817c6df573f08ae226);
			return;
		}
	}

	public void c24a0f2b5695dcd950edb79b1830693f9(out float c5ebdc65d5cb420faf7ba524809963aa9, out float c9d16e16b57deb9bb1da907451ba1f25b)
	{
		c5ebdc65d5cb420faf7ba524809963aa9 = 0f;
		c9d16e16b57deb9bb1da907451ba1f25b = 0f;
		if (ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.c38416c96b869af0e164ff13994b8aa12 == 0f)
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
			c5ebdc65d5cb420faf7ba524809963aa9 = (float)Screen.width * 0.5f / ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.c38416c96b869af0e164ff13994b8aa12;
			c9d16e16b57deb9bb1da907451ba1f25b = (float)Screen.height * 0.5f / ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.c38416c96b869af0e164ff13994b8aa12;
			return;
		}
	}

	public override void OnLevelLoadingFinish()
	{
		base.OnLevelLoadingFinish();
		ca280218892349592f11b4646f5eafb11();
		c06ca0e618478c23eba3419653a19760f<GUIFontSwapManager>.c5ee19dc8d4cccf5ae2de225410458b86.c0152ca5a8975604e439dc2408c0c7cd9();
		c7faa6f1d3168c8fb9e598b66c8c1c1fd.ccf24681862bae286c19d5c9b16296be5.c73f608275ed778f1b52438ced1f333ef();
	}

	private void ca280218892349592f11b4646f5eafb11()
	{
		while (_queMovieLoadedList.Count > 0)
		{
			MovieLoadedCaller movieLoadedCaller = _queMovieLoadedList.Dequeue();
			movieLoadedCaller.func(movieLoadedCaller.movie);
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
			return;
		}
	}

	public override void c2a7c8d4c8942c3b965a1a3737dabaf3a(bool c3963488969abf1013769eb3dc62d3c39)
	{
		_curStage.visible = c3963488969abf1013769eb3dc62d3c39;
	}

	protected IEnumerator c8fa44ac86695940c4538ed5d6a372410(string c0a1685317ff4c3f52f0ceb4b96592fdb, string c39f5a5cbb885a707e9c84ef87bcff9a2, FuncLoad c65f5e51143ff3b64d4db3d634652facd)
	{
		yield return StartCoroutine(c06ca0e618478c23eba3419653a19760f<UniResourceManager>.c5ee19dc8d4cccf5ae2de225410458b86.ce4bd36f73dbe7cc7c7e521056b6cbcc6(c0a1685317ff4c3f52f0ceb4b96592fdb + ":" + c39f5a5cbb885a707e9c84ef87bcff9a2));
		MovieClip movieClip = c06ca0e618478c23eba3419653a19760f<UniResourceManager>.c5ee19dc8d4cccf5ae2de225410458b86.c62489bc2bccb34a700c765f20e507ead(c0a1685317ff4c3f52f0ceb4b96592fdb + ":" + c39f5a5cbb885a707e9c84ef87bcff9a2);
		if (movieClip != null)
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
					ca0717bcf41cba61fc7c2e20ba79f5ba2(movieClip, c65f5e51143ff3b64d4db3d634652facd);
					yield break;
				}
			}
		}
		DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.GUI, "Can't create movieclip----" + c0a1685317ff4c3f52f0ceb4b96592fdb + ":" + c39f5a5cbb885a707e9c84ef87bcff9a2);
	}

	public void c9a36e6e68967bc69944e0eaf2aa68d73(string c0a1685317ff4c3f52f0ceb4b96592fdb, string c39f5a5cbb885a707e9c84ef87bcff9a2, FuncLoad c65f5e51143ff3b64d4db3d634652facd)
	{
		StartCoroutine(c8fa44ac86695940c4538ed5d6a372410(c0a1685317ff4c3f52f0ceb4b96592fdb, c39f5a5cbb885a707e9c84ef87bcff9a2, c65f5e51143ff3b64d4db3d634652facd));
	}

	private void ca0717bcf41cba61fc7c2e20ba79f5ba2(MovieClip ceeadc1fedbc36762c176deab5162ee0e, FuncLoad c0928a26d68a823b8a5494f2bf244b866)
	{
		if (ceeadc1fedbc36762c176deab5162ee0e == null)
		{
			return;
		}
		MovieLoadedCaller item = default(MovieLoadedCaller);
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
			if (c0928a26d68a823b8a5494f2bf244b866 == null)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			if (_bLevelLoading)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						item.movie = ceeadc1fedbc36762c176deab5162ee0e;
						item.func = c0928a26d68a823b8a5494f2bf244b866;
						_queMovieLoadedList.Enqueue(item);
						return;
					}
				}
			}
			c0928a26d68a823b8a5494f2bf244b866(ceeadc1fedbc36762c176deab5162ee0e);
			return;
		}
	}

	public MovieClip c8fa44ac86695940c4538ed5d6a372410(string c0a1685317ff4c3f52f0ceb4b96592fdb, string c39f5a5cbb885a707e9c84ef87bcff9a2)
	{
		return c06ca0e618478c23eba3419653a19760f<UniResourceManager>.c5ee19dc8d4cccf5ae2de225410458b86.c62489bc2bccb34a700c765f20e507ead(c0a1685317ff4c3f52f0ceb4b96592fdb + ":" + c39f5a5cbb885a707e9c84ef87bcff9a2);
	}

	public override void cabd28572b70d2431f2d4a756756dd491()
	{
		base.cabd28572b70d2431f2d4a756756dd491();
		c06ca0e618478c23eba3419653a19760f<GUIFontSwapManager>.c5ee19dc8d4cccf5ae2de225410458b86.cb6ddb86ff592b855d40e4b6baac609bf();
	}

	public override void cdda1108806b8a31337c338a488b30f1e()
	{
		c06ca0e618478c23eba3419653a19760f<GUIFontSwapManager>.c5ee19dc8d4cccf5ae2de225410458b86.cb6ddb86ff592b855d40e4b6baac609bf();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cc26edc12ccc7060d40b0aaea9f5e22ee(true);
	}

	public void cf7bb4834a40d20c49e6c144062b5916b(string c0a1685317ff4c3f52f0ceb4b96592fdb)
	{
		c06ca0e618478c23eba3419653a19760f<UniResourceManager>.c5ee19dc8d4cccf5ae2de225410458b86.cf7bb4834a40d20c49e6c144062b5916b(c0a1685317ff4c3f52f0ceb4b96592fdb);
	}

	private void Update()
	{
		c7bb86b60f299c950179b9bd1c30a2a68();
		if (Input.GetMouseButtonDown(1))
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
			if (c340ad4e1f1707c51248b1d3b50723a7e.ccf24681862bae286c19d5c9b16296be5.c93fcfbc31b4dd1606b1af2101ee270d0)
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
				c340ad4e1f1707c51248b1d3b50723a7e.ccf24681862bae286c19d5c9b16296be5.c4fdd007303fd7b5c133404b463447e39();
			}
			else if (_curStage.mouseOver != null)
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
				MouseEvent mouseEvent = new MouseEvent(MouseEvent.MOUSE_DOWN, true, false);
				mouseEvent.buttonId = 1;
				_curStage.mouseOver.fireEvent(mouseEvent);
			}
		}
		if (Input.GetMouseButtonDown(0))
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
			if (lastClickTime < 0f)
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
				lastClickObj = _curStage.mouseOver;
				lastClickTime = Time.realtimeSinceStartup;
			}
			else
			{
				if (_curStage.mouseOver != null)
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
					if (_curStage.mouseOver == lastClickObj)
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
						if (Time.realtimeSinceStartup - lastClickTime < 0.5f)
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
							ccee399aceaafcace836a9d2621e66f35 e = new ccee399aceaafcace836a9d2621e66f35(ccee399aceaafcace836a9d2621e66f35.cd58336ed361ce802b5f1a11c492908c2, true, false);
							_curStage.mouseOver.fireEvent(e);
						}
						else
						{
							lastClickTime = Time.realtimeSinceStartup;
						}
						goto IL_017e;
					}
				}
				lastClickTime = Time.realtimeSinceStartup;
				lastClickObj = _curStage.mouseOver;
			}
		}
		goto IL_017e;
		IL_017e:
		if (Time.realtimeSinceStartup - lastClickTime > 2f)
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
			lastClickTime = -1f;
			lastClickObj = cc7b206340b600c7decc4e7b5711da220.c7088de59e49f7108f520cf7e0bae167e;
		}
		if (Input.GetMouseButtonUp(1))
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
			if (_curStage.mouseOver != null)
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
				MouseEvent mouseEvent2 = new MouseEvent(MouseEvent.CLICK, true, false);
				mouseEvent2.buttonId = 1;
				_curStage.mouseOver.fireEvent(mouseEvent2);
			}
		}
		float axis = Input.GetAxis("Mouse ScrollWheel");
		if ((double)axis != 0.0)
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
			if (_curStage.mouseOver != null)
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
				ccee399aceaafcace836a9d2621e66f35 ccee399aceaafcace836a9d2621e66f = new ccee399aceaafcace836a9d2621e66f35(ccee399aceaafcace836a9d2621e66f35.cb995b44f9d3bf68faff261ab2cc8c5b7, true, false);
				ccee399aceaafcace836a9d2621e66f.c46133d1809d6d3227e98e175cb2e7142 = axis;
				_curStage.mouseOver.fireEvent(ccee399aceaafcace836a9d2621e66f);
			}
		}
		c34127589fddffa4d0f80b70f3839f42e();
	}

	protected override bool ce11e07f2061501a16aa108d2f845cc17()
	{
		if (c340ad4e1f1707c51248b1d3b50723a7e.ccf24681862bae286c19d5c9b16296be5.c93fcfbc31b4dd1606b1af2101ee270d0)
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
					c340ad4e1f1707c51248b1d3b50723a7e.ccf24681862bae286c19d5c9b16296be5.c4fdd007303fd7b5c133404b463447e39();
					return true;
				}
			}
		}
		if (c7faa6f1d3168c8fb9e598b66c8c1c1fd.ccf24681862bae286c19d5c9b16296be5.c2e9cd7194d5ed5215de1bea1b1954592)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					c7faa6f1d3168c8fb9e598b66c8c1c1fd.ccf24681862bae286c19d5c9b16296be5.c73f608275ed778f1b52438ced1f333ef();
					return true;
				}
			}
		}
		return base.ce11e07f2061501a16aa108d2f845cc17();
	}
}
