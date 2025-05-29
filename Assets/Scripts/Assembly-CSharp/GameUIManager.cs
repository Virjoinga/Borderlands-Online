using System;
using System.Collections;
using System.Collections.Generic;
using A;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
	public class UIViewCreator
	{
		protected Dictionary<Type, Type> _mapClasses = new Dictionary<Type, Type>();

		protected Dictionary<Type, BaseView> _mapViewPool = new Dictionary<Type, BaseView>();

		public Dictionary<Type, BaseView> cdedc5bc9e949a111fe373551fa333f75()
		{
			return _mapViewPool;
		}

		public virtual BaseView cca63fb39fc4b78e05b12f72dd3bf6db1(Type c6faaf6fa37aadba99ba1748bc0bd4cd6)
		{
			if (_mapViewPool.ContainsKey(c6faaf6fa37aadba99ba1748bc0bd4cd6))
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
						return _mapViewPool[c6faaf6fa37aadba99ba1748bc0bd4cd6];
					}
				}
			}
			if (_mapClasses.ContainsKey(c6faaf6fa37aadba99ba1748bc0bd4cd6))
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
					{
						BaseView baseView = Activator.CreateInstance(_mapClasses[c6faaf6fa37aadba99ba1748bc0bd4cd6]) as BaseView;
						if (baseView != null)
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
							_mapViewPool.Add(c6faaf6fa37aadba99ba1748bc0bd4cd6, baseView);
						}
						return baseView;
					}
					}
				}
			}
			return null;
		}

		public void c4dba6cc32c10b0e24ae2bd61020460ef(Type c2e2c340fecc3679efb7d1a872cc55f90, Type cf736b5623b5250ce7444d05e4261cb87)
		{
			if (_mapClasses.ContainsKey(c2e2c340fecc3679efb7d1a872cc55f90))
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
						_mapClasses[c2e2c340fecc3679efb7d1a872cc55f90] = cf736b5623b5250ce7444d05e4261cb87;
						return;
					}
				}
			}
			_mapClasses.Add(c2e2c340fecc3679efb7d1a872cc55f90, cf736b5623b5250ce7444d05e4261cb87);
		}
	}

	public class CursorManager
	{
		public enum CursorType
		{
			DefaultCursor = 1,
			HandSelected = 2,
			HandClosed = 3,
			HammerLift = 4,
			HammerKnock = 5,
			HammerForbid = 6,
			HandOpen = 7,
			HandClose = 8,
			Money = 9
		}

		protected CursorType _currentCursorType = CursorType.DefaultCursor;

		protected Dictionary<CursorType, string> _mapTexturePath = new Dictionary<CursorType, string>();

		protected Dictionary<CursorType, Texture2D> _mapTexture = new Dictionary<CursorType, Texture2D>();

		public CursorManager()
		{
			_mapTexturePath[CursorType.HandSelected] = "UI_uniSWF/Effects/Cursors/Cursor_Select";
			_mapTexturePath[CursorType.HandClosed] = "UI_uniSWF/Effects/Cursors/Cursor_HandClosed";
			_mapTexturePath[CursorType.HammerLift] = "UI_uniSWF/Effects/Cursors/Harmmer_1";
			_mapTexturePath[CursorType.HammerKnock] = "UI_uniSWF/Effects/Cursors/Harmmer_2";
			_mapTexturePath[CursorType.HammerForbid] = "UI_uniSWF/Effects/Cursors/Harmmer_3";
			_mapTexturePath[CursorType.HandOpen] = "UI_uniSWF/Effects/Cursors/Hand_1";
			_mapTexturePath[CursorType.HandClose] = "UI_uniSWF/Effects/Cursors/Hand_2";
			_mapTexturePath[CursorType.Money] = "UI_uniSWF/Effects/Cursors/money";
			_mapTexture.Add(CursorType.DefaultCursor, null);
		}

		public void c4614712875423a743006a8bf2f2b3ec8(CursorType c6de715717a660431b466566175fe3dcf)
		{
			if (c6de715717a660431b466566175fe3dcf == _currentCursorType)
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
			_currentCursorType = c6de715717a660431b466566175fe3dcf;
			CursorMode cursorMode = CursorMode.Auto;
			Vector2 hotspot = new Vector2(0f, 0f);
			if (!_mapTexture.ContainsKey(c6de715717a660431b466566175fe3dcf))
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
				Texture2D value = (Texture2D)ResourcesLoader.c38aeacc59bd560b59403945ae7996d79(_mapTexturePath[c6de715717a660431b466566175fe3dcf]);
				_mapTexture.Add(c6de715717a660431b466566175fe3dcf, value);
			}
			Cursor.SetCursor(_mapTexture[c6de715717a660431b466566175fe3dcf], hotspot, cursorMode);
		}
	}

	public class EngineUIInputReader : RegularInputReader
	{
		private GameUIManager _UIManager;

		public EngineUIInputReader(GameUIManager c8ab13c72b91cdb104f1f6167a4408ffe)
		{
			_UIManager = c8ab13c72b91cdb104f1f6167a4408ffe;
		}

		public override bool cf444c2ed32312476a266d34e37bfd02f(int cc5b2a83f0ff489309eb5bc89970fb973, bool cb4545d0934b9eb94d684000578dcd1ac = false)
		{
			if (cb4545d0934b9eb94d684000578dcd1ac)
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
				if (_UIManager.c7239543e613e42c603e3f4786aa2ecb7())
				{
					while (true)
					{
						switch (5)
						{
						case 0:
							break;
						default:
							return false;
						}
					}
				}
			}
			return Input.GetMouseButton(cc5b2a83f0ff489309eb5bc89970fb973);
		}

		public override bool ca561485909b8620867b83991201b70d3(int cc5b2a83f0ff489309eb5bc89970fb973, bool cb4545d0934b9eb94d684000578dcd1ac = false)
		{
			if (cb4545d0934b9eb94d684000578dcd1ac)
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
				if (_UIManager.c7239543e613e42c603e3f4786aa2ecb7())
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							return false;
						}
					}
				}
			}
			return Input.GetMouseButtonDown(cc5b2a83f0ff489309eb5bc89970fb973);
		}

		public override bool c5adfffc6150c77758b5ca44b059aee74(int cc5b2a83f0ff489309eb5bc89970fb973, bool cb4545d0934b9eb94d684000578dcd1ac = false)
		{
			if (cb4545d0934b9eb94d684000578dcd1ac)
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
				if (_UIManager.c7239543e613e42c603e3f4786aa2ecb7())
				{
					while (true)
					{
						switch (5)
						{
						case 0:
							break;
						default:
							return false;
						}
					}
				}
			}
			return Input.GetMouseButtonUp(cc5b2a83f0ff489309eb5bc89970fb973);
		}
	}

	public delegate void ViewUpdateCB();

	private bool m_bIsMatchMaking;

	protected GameObject _UIRootObject;

	protected UIViewCreator _viewCreator = new UIViewCreator();

	protected CursorManager _cursorManager = new CursorManager();

	protected EngineUIInputReader _InputReader;

	protected ViewUpdateCB _funcUpdateList;

	protected List<ViewUpdateCB> _arrNextUpdate = new List<ViewUpdateCB>();

	protected Camera _gameCamera;

	protected bool _bLevelLoading;

	protected bool _bHudVisible = true;

	private List<BaseView> _arrOccupyMenuList = new List<BaseView>();

	private List<BaseView> _arrConflictMenuList = new List<BaseView>();

	private List<BaseView> _arrFPSHideList = new List<BaseView>();

	protected Dictionary<BaseView, Vector2> _dicInventoryBind = new Dictionary<BaseView, Vector2>();

	private Dictionary<string, List<BaseView>> _mapShortCutCMD = new Dictionary<string, List<BaseView>>();

	protected bool _shortCutEnabled = true;

	public bool USING_TEST_GUI = true;

	public bool c9d057c2188e7d2872aa3ec71517e92ae
	{
		get
		{
			return m_bIsMatchMaking;
		}
		set
		{
			m_bIsMatchMaking = value;
		}
	}

	public Camera c91fcf132a3585bad3597263bc8937405
	{
		get
		{
			return _gameCamera;
		}
		set
		{
			_gameCamera = value;
		}
	}

	public virtual bool c4717862155dcb63da4094ee983c75b38
	{
		get
		{
			return _shortCutEnabled;
		}
		set
		{
			_shortCutEnabled = value;
		}
	}

	public GameUIManager()
	{
		_InputReader = new EngineUIInputReader(this);
	}

	public virtual void cd93285db16841148ed53a5bbeb35cf20()
	{
		c55d2da2e78e1c76d6c30073b7cae5d02();
		if (_UIRootObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			_UIRootObject = new GameObject("UIRootObject");
			UnityEngine.Object.DontDestroyOnLoad(_UIRootObject);
		}
		c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.c3f0d9cf7bb65072c8cb6a400c2468eea(_InputReader);
	}

	public virtual void cb6ddb86ff592b855d40e4b6baac609bf()
	{
		cabd28572b70d2431f2d4a756756dd491();
		if (!(_UIRootObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			UnityEngine.Object.DestroyObject(_UIRootObject);
			return;
		}
	}

	public virtual void cabd28572b70d2431f2d4a756756dd491()
	{
		using (Dictionary<Type, BaseView>.Enumerator enumerator = _viewCreator.cdedc5bc9e949a111fe373551fa333f75().GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				enumerator.Current.Value.cac7688b05e921e2be3f92479ba44b4a8();
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
		_viewCreator.cdedc5bc9e949a111fe373551fa333f75().Clear();
	}

	public virtual void cdda1108806b8a31337c338a488b30f1e()
	{
	}

	public virtual void OnScreenResized(int width, int height)
	{
		using (Dictionary<Type, BaseView>.Enumerator enumerator = _viewCreator.cdedc5bc9e949a111fe373551fa333f75().GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				KeyValuePair<Type, BaseView> current = enumerator.Current;
				if (!current.Value.cd0069281ff5290a7e6c484b6aed3933d)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				current.Value.OnScreenResized();
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

	public virtual void OnLevelLoadingFinish()
	{
		_bLevelLoading = false;
	}

	public virtual void OnLevelLoadingStart()
	{
		_bLevelLoading = true;
	}

	public virtual void c114035b255a7c79daf00b8613364145c(GameObject c80250549d88c55755428dffb4096f9e6)
	{
		if (!(c80250549d88c55755428dffb4096f9e6 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			c80250549d88c55755428dffb4096f9e6.transform.parent = _UIRootObject.transform;
			return;
		}
	}

	public virtual c272566d4edbf24bb8c4df6114a524ac9 c5a9245d284a4186b1df5f04b4559bab8<c272566d4edbf24bb8c4df6114a524ac9>() where c272566d4edbf24bb8c4df6114a524ac9 : BaseView
	{
		return _viewCreator.cca63fb39fc4b78e05b12f72dd3bf6db1(typeof(c272566d4edbf24bb8c4df6114a524ac9)) as c272566d4edbf24bb8c4df6114a524ac9;
	}

	public virtual c272566d4edbf24bb8c4df6114a524ac9 ce22458c51b34b4a5bbda40331bde92e6<c272566d4edbf24bb8c4df6114a524ac9>() where c272566d4edbf24bb8c4df6114a524ac9 : BaseView
	{
		c272566d4edbf24bb8c4df6114a524ac9 val = _viewCreator.cca63fb39fc4b78e05b12f72dd3bf6db1(typeof(c272566d4edbf24bb8c4df6114a524ac9)) as c272566d4edbf24bb8c4df6114a524ac9;
		if (val != (c272566d4edbf24bb8c4df6114a524ac9)null)
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
			val.cd93285db16841148ed53a5bbeb35cf20();
			val.cc4d8eea4e06ec8ec2e166a7004d3700e(OnViewVisibleChange);
		}
		return val;
	}

	public virtual c272566d4edbf24bb8c4df6114a524ac9 c6f01b5fa13c603e61975e008f5f3dce8<c272566d4edbf24bb8c4df6114a524ac9>() where c272566d4edbf24bb8c4df6114a524ac9 : BaseView
	{
		c272566d4edbf24bb8c4df6114a524ac9 val = _viewCreator.cca63fb39fc4b78e05b12f72dd3bf6db1(typeof(c272566d4edbf24bb8c4df6114a524ac9)) as c272566d4edbf24bb8c4df6114a524ac9;
		if (val != (c272566d4edbf24bb8c4df6114a524ac9)null)
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
			val.cac7688b05e921e2be3f92479ba44b4a8();
			val.cee6e47a3f2472df3eece01f53b58beea(OnViewVisibleChange);
		}
		return val;
	}

	public virtual void c6de47bc48c49266d84e5e8e380c32550()
	{
	}

	public virtual bool c5383bc84e8cae50fac6d2363cda700d1()
	{
		return false;
	}

	public virtual void c2a7c8d4c8942c3b965a1a3737dabaf3a(bool c3963488969abf1013769eb3dc62d3c39)
	{
	}

	public virtual bool c7239543e613e42c603e3f4786aa2ecb7()
	{
		return false;
	}

	public void c239889f6079aa61647e3c4b8f3627d00(ViewUpdateCB cb24ea666f3f25bc975f1e84effd63cad, bool c961f19386711e97bd8222889003bb49b = false)
	{
		if (c961f19386711e97bd8222889003bb49b)
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
					_arrNextUpdate.Add(cb24ea666f3f25bc975f1e84effd63cad);
					return;
				}
			}
		}
		_funcUpdateList = (ViewUpdateCB)Delegate.Combine(_funcUpdateList, cb24ea666f3f25bc975f1e84effd63cad);
	}

	public void c0bd653723f77fd78e6c7d4d25ed14dcd(ViewUpdateCB cb24ea666f3f25bc975f1e84effd63cad)
	{
		_funcUpdateList = (ViewUpdateCB)Delegate.Remove(_funcUpdateList, cb24ea666f3f25bc975f1e84effd63cad);
	}

	public virtual void c758cf934d27a077d85165dce3424bb11(bool c74232243aff1dcbf2e8fc243633bb51a)
	{
	}

	private void c55d2da2e78e1c76d6c30073b7cae5d02()
	{
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(cb4a5cdd404af21575e712f84ebae45fb.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(cb4a5cdd404af21575e712f84ebae45fb.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(cb2a242afbc3fd1cd5f18dea48c781532.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(cb2a242afbc3fd1cd5f18dea48c781532.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(cf088114bc1198c734457f18f168417e9.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(cf088114bc1198c734457f18f168417e9.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c217f6b676f75d73ff573bf9fa94cc5af.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c217f6b676f75d73ff573bf9fa94cc5af.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(ca44ecdb762e48e155cfe6e1a2d6cfa45.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(ca44ecdb762e48e155cfe6e1a2d6cfa45.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(cff415b3e8872ea0e9d6e41194535ff0d.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(cff415b3e8872ea0e9d6e41194535ff0d.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c51a68bd251bfd832a7bc6d8c202645b3.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c51a68bd251bfd832a7bc6d8c202645b3.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c8664a63dda836468ac250fd8a37bea7f.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c8664a63dda836468ac250fd8a37bea7f.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(cef8257ff5951b9bc14785a762e9ed95b.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(cef8257ff5951b9bc14785a762e9ed95b.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(cb7104a5cdb8b002ff032cc4f1a7034c9.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(cb7104a5cdb8b002ff032cc4f1a7034c9.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c24fbe21ca6e854d0567069f2b48cc534.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c24fbe21ca6e854d0567069f2b48cc534.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c3e34d7bd82cd647ef0afcf5e73def934.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c3e34d7bd82cd647ef0afcf5e73def934.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(cb8f3cfa26fc1ff9d47691f65b0e7fe1e.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(cb8f3cfa26fc1ff9d47691f65b0e7fe1e.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c6a571677699a38c82ae4d06c4e9e2f93.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c6a571677699a38c82ae4d06c4e9e2f93.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c59b3aadf0ba4f0a5227adb5266173f6c.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c59b3aadf0ba4f0a5227adb5266173f6c.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(ce2fd2d8d1565ee5c7c992499caad548b.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(ce2fd2d8d1565ee5c7c992499caad548b.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c5cbfa998921f1c87e278ee3e3dbd3ac3.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c5cbfa998921f1c87e278ee3e3dbd3ac3.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c66f2aa08ef9ffab68d1175b4010d1fe5.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c66f2aa08ef9ffab68d1175b4010d1fe5.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c2ba4ca6c382c65b7b65517ceb1aceb86.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c2ba4ca6c382c65b7b65517ceb1aceb86.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c7b2bea133bf2b28134953106c5a107fa.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c7b2bea133bf2b28134953106c5a107fa.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c908049a42d7c79b78977acad600d2b2f.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c908049a42d7c79b78977acad600d2b2f.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c1a48e3ad6f8ade407f14a992ca514cdd.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c1a48e3ad6f8ade407f14a992ca514cdd.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c14f28a0a33177ca1a3294bf0489b47f2.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c14f28a0a33177ca1a3294bf0489b47f2.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(cb05b42023a4b84e002785e9c4292df12.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(cb05b42023a4b84e002785e9c4292df12.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(cd11fcb53b267059435321074d936eb03.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(cd11fcb53b267059435321074d936eb03.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c9687de25e41bf6d5c83fc6d67a14d995.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c9687de25e41bf6d5c83fc6d67a14d995.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c2fd0e0e5181ef3a0c4a8d73bac704813.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c2fd0e0e5181ef3a0c4a8d73bac704813.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(cf24d70e6794b63fcd5439935ed3de5ad.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(cf24d70e6794b63fcd5439935ed3de5ad.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(cf02f01fa05d428f988fc7b74a5aeffac.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(cf02f01fa05d428f988fc7b74a5aeffac.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c0ace980826ba79c438da6bf2a12c98f2.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c0ace980826ba79c438da6bf2a12c98f2.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c6cd9fb035a5cd499328a2aa5dc4b6d47.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c6cd9fb035a5cd499328a2aa5dc4b6d47.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(cba275f8c4b44fa9681e0d7a4f6977730.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(cba275f8c4b44fa9681e0d7a4f6977730.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c1a54dd42bc81b27be6a884c1946edbe3.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c1a54dd42bc81b27be6a884c1946edbe3.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(ce1c6e7d5c30f0904d8e5ed028407b714.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(ce1c6e7d5c30f0904d8e5ed028407b714.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(cf59f278edb373ee7711bd28f66d3dcff.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(cf59f278edb373ee7711bd28f66d3dcff.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(ca4a6daaf147f142128d1128c1e301072.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(ca4a6daaf147f142128d1128c1e301072.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c80098d4c036cfd84b1369cc2430df40a.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c80098d4c036cfd84b1369cc2430df40a.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c78453e6b49a3881020efd19da56378ae.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c78453e6b49a3881020efd19da56378ae.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(cb9072169c5c6854602da22346c14a050.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(cb9072169c5c6854602da22346c14a050.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c911e7f1b388335bb5b1580d9da755ebe.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c911e7f1b388335bb5b1580d9da755ebe.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(ceb8d83569215e7047ec75f3fb94ad782.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(ceb8d83569215e7047ec75f3fb94ad782.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(cbffb91ee2ee5d0002993ca724c0f7341.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(cbffb91ee2ee5d0002993ca724c0f7341.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(cff8bf0af564a12a63dbbb3ead5e04646.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(cff8bf0af564a12a63dbbb3ead5e04646.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(cbb81b09532259cc99ac179c4cbe64f55.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(cbb81b09532259cc99ac179c4cbe64f55.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(cc6a6f28a01fcbdd7e8035f2a0fb51f59.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(cc6a6f28a01fcbdd7e8035f2a0fb51f59.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c4f44724cfcf62c6b6721ef81fa654c45.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c4f44724cfcf62c6b6721ef81fa654c45.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(ce03b9a4cb67af167b86ec9e20b34b35d.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(ce03b9a4cb67af167b86ec9e20b34b35d.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c6b93f794b77541370577a70406cf3b3a.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c6b93f794b77541370577a70406cf3b3a.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c4e0ceae6200a1e6d933f5166864fac46.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c4e0ceae6200a1e6d933f5166864fac46.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c9f927f41b21fa1757bdc63c66ba8c2bb.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c9f927f41b21fa1757bdc63c66ba8c2bb.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(ca2926352accdb38b6260681e4001b759.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(ca2926352accdb38b6260681e4001b759.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c76eac0c0bf3a5ee0748e25a410901506.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c76eac0c0bf3a5ee0748e25a410901506.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c3f33536c8599ae417be7910bb239cfe4.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c3f33536c8599ae417be7910bb239cfe4.cc1720d05c75832f704b87474932341c3()));
		_viewCreator.c4dba6cc32c10b0e24ae2bd61020460ef(Type.GetTypeFromHandle(c0e77f90ef22ce306a74fd04a464284c1.cc1720d05c75832f704b87474932341c3()), Type.GetTypeFromHandle(c0e77f90ef22ce306a74fd04a464284c1.cc1720d05c75832f704b87474932341c3()));
		c3ce49ac9f742f8aabdab94a8a84b5bca();
	}

	protected virtual void c3ce49ac9f742f8aabdab94a8a84b5bca()
	{
	}

	public virtual IEnumerator cb1e6f458e4a06317ce1a75ab0fde8946()
	{
		yield return c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e;
	}

	public virtual void c1206463c349318a3daf072e855c7eaec()
	{
	}

	private void Start()
	{
	}

	private void FixedUpdate()
	{
	}

	private void Update()
	{
		c7bb86b60f299c950179b9bd1c30a2a68();
		c34127589fddffa4d0f80b70f3839f42e();
	}

	protected virtual void c34127589fddffa4d0f80b70f3839f42e()
	{
		if (_funcUpdateList != null)
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
			_funcUpdateList();
		}
		for (int i = 0; i < _arrNextUpdate.Count; i++)
		{
			_funcUpdateList = (ViewUpdateCB)Delegate.Combine(_funcUpdateList, _arrNextUpdate[i]);
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			_arrNextUpdate.Clear();
			return;
		}
	}

	public void c968ae3f7ba22e4826b18039ba36f33ce(BaseView c9a85ff2711c2961a05290e37234c8b9c, Vector2 c8e8d70bd36ceb58462269a0cf1045921)
	{
		if (_dicInventoryBind.ContainsKey(c9a85ff2711c2961a05290e37234c8b9c))
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
					_dicInventoryBind[c9a85ff2711c2961a05290e37234c8b9c] = c8e8d70bd36ceb58462269a0cf1045921;
					return;
				}
			}
		}
		_dicInventoryBind.Add(c9a85ff2711c2961a05290e37234c8b9c, c8e8d70bd36ceb58462269a0cf1045921);
	}

	public void c858f0c33158b659215d28b3c0548a38a(BaseView ca4187010cdd35921f11dd5df8ccc23e3)
	{
		if (_arrFPSHideList.Contains(ca4187010cdd35921f11dd5df8ccc23e3))
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
			_arrFPSHideList.Add(ca4187010cdd35921f11dd5df8ccc23e3);
			return;
		}
	}

	public void ceb073876b67631e82266e224318dc9de(BaseView ca4187010cdd35921f11dd5df8ccc23e3)
	{
		if (!_arrFPSHideList.Contains(ca4187010cdd35921f11dd5df8ccc23e3))
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
			_arrFPSHideList.Remove(ca4187010cdd35921f11dd5df8ccc23e3);
			return;
		}
	}

	public void cbfdeda957ab87de3d0acf25194e61c4c(BaseView ca4187010cdd35921f11dd5df8ccc23e3)
	{
		if (_arrOccupyMenuList.Contains(ca4187010cdd35921f11dd5df8ccc23e3))
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
			_arrOccupyMenuList.Add(ca4187010cdd35921f11dd5df8ccc23e3);
			return;
		}
	}

	public void cfdafa122fc114376585cbb27b8811a86(BaseView ca4187010cdd35921f11dd5df8ccc23e3)
	{
		if (!_arrOccupyMenuList.Contains(ca4187010cdd35921f11dd5df8ccc23e3))
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
			_arrOccupyMenuList.Remove(ca4187010cdd35921f11dd5df8ccc23e3);
			return;
		}
	}

	public void c914f3898d0cb85fdb88383c5a243cded(BaseView ca4187010cdd35921f11dd5df8ccc23e3)
	{
		if (_arrConflictMenuList.Contains(ca4187010cdd35921f11dd5df8ccc23e3))
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
			_arrConflictMenuList.Add(ca4187010cdd35921f11dd5df8ccc23e3);
			return;
		}
	}

	public void c0f8db058f30b85298d876c68b2ca7053(BaseView ca4187010cdd35921f11dd5df8ccc23e3)
	{
		if (!_arrConflictMenuList.Contains(ca4187010cdd35921f11dd5df8ccc23e3))
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
			_arrConflictMenuList.Remove(ca4187010cdd35921f11dd5df8ccc23e3);
			return;
		}
	}

	public void OnViewVisibleChange(BaseView view, bool visible, bool bInner = false)
	{
		c74e374fe56840b31e518648ddb469a6b(view, visible);
		if (bInner)
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
			if (visible)
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
				ceb83f46d7c644613929b036d7449a803(view);
			}
			c8099059cff7540d9700340b38d565ec3();
			return;
		}
	}

	protected void c74e374fe56840b31e518648ddb469a6b(BaseView ca4187010cdd35921f11dd5df8ccc23e3, bool c150264a18c2cb408479d3f072cac8cc1)
	{
		if (ca4187010cdd35921f11dd5df8ccc23e3 is InventoryView)
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
					if (!c150264a18c2cb408479d3f072cac8cc1)
					{
						while (true)
						{
							switch (2)
							{
							case 0:
								break;
							default:
							{
								using (Dictionary<BaseView, Vector2>.KeyCollection.Enumerator enumerator = _dicInventoryBind.Keys.GetEnumerator())
								{
									while (enumerator.MoveNext())
									{
										BaseView current = enumerator.Current;
										if (current.c150264a18c2cb408479d3f072cac8cc1)
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
											current.cd709174be42fda430a2bdb7ad8549098(false);
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
					}
					return;
				}
			}
		}
		if (!_dicInventoryBind.ContainsKey(ca4187010cdd35921f11dd5df8ccc23e3))
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
			if (!c5a9245d284a4186b1df5f04b4559bab8<InventoryView>().cd0069281ff5290a7e6c484b6aed3933d)
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
				if (c150264a18c2cb408479d3f072cac8cc1)
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
					c5a9245d284a4186b1df5f04b4559bab8<InventoryView>().cc70485d0f318bdcb115a41bc918cae44(_dicInventoryBind[ca4187010cdd35921f11dd5df8ccc23e3]);
				}
				c5a9245d284a4186b1df5f04b4559bab8<InventoryView>().c150264a18c2cb408479d3f072cac8cc1 = c150264a18c2cb408479d3f072cac8cc1;
				return;
			}
		}
	}

	protected void ceb83f46d7c644613929b036d7449a803(BaseView ca4187010cdd35921f11dd5df8ccc23e3)
	{
		if (!_arrConflictMenuList.Contains(ca4187010cdd35921f11dd5df8ccc23e3))
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
			using (List<BaseView>.Enumerator enumerator = _arrConflictMenuList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					BaseView current = enumerator.Current;
					if (current == ca4187010cdd35921f11dd5df8ccc23e3)
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
					if (!current.c150264a18c2cb408479d3f072cac8cc1)
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
						break;
					}
					current.cd709174be42fda430a2bdb7ad8549098(false);
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
		}
	}

	protected void c8099059cff7540d9700340b38d565ec3()
	{
		bool flag = c57029091e9f8eb6af56cc0ef28a7ac3f();
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.c117524158ae198f8e66c3d5e543aeb9b() != FrontEndStepManager.StepState.WorldMap)
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
			if (flag)
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
				c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1bdd1e7aa891de56d871ae24289f5f8b();
				c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.cca84ca4deababdecf8f3d8cc7a45edb9();
			}
			else
			{
				c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1570506bf0b326e191d0406037cb4fef();
				c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.c0888ee52497af70d4cc14624cbd11269();
			}
		}
		c06326d0c295575336bc4e5c2f994ab8e(!flag);
	}

	protected bool c57029091e9f8eb6af56cc0ef28a7ac3f()
	{
		bool flag = false;
		using (List<BaseView>.Enumerator enumerator = _arrOccupyMenuList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				BaseView current = enumerator.Current;
				int num;
				if (!flag)
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
					num = (current.c150264a18c2cb408479d3f072cac8cc1 ? 1 : 0);
				}
				else
				{
					num = 1;
				}
				flag = (byte)num != 0;
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				return flag;
			}
		}
	}

	protected virtual void c71fead1fa881e4ec35ca5789f4b7b596(bool c74232243aff1dcbf2e8fc243633bb51a)
	{
		using (List<BaseView>.Enumerator enumerator = _arrFPSHideList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				BaseView current = enumerator.Current;
				current.cd709174be42fda430a2bdb7ad8549098(c74232243aff1dcbf2e8fc243633bb51a);
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
				return;
			}
		}
	}

	public virtual void c2dc5e286b7faa1029d7be508be9ce924(bool c74232243aff1dcbf2e8fc243633bb51a)
	{
		c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.ca5bd80f5ff7a2e9ca939a6283399ec2d().cbdb542073b311fc24f36e1573abfa7d6(!c74232243aff1dcbf2e8fc243633bb51a);
	}

	public virtual void c5257d6aefccfc702e44803405b9ffab8(bool c74232243aff1dcbf2e8fc243633bb51a)
	{
	}

	public virtual void c06326d0c295575336bc4e5c2f994ab8e(bool c74232243aff1dcbf2e8fc243633bb51a)
	{
		c71fead1fa881e4ec35ca5789f4b7b596(c74232243aff1dcbf2e8fc243633bb51a);
		c2dc5e286b7faa1029d7be508be9ce924(!c74232243aff1dcbf2e8fc243633bb51a);
	}

	public void c3ee3ae9c8e9d7863fc24390827b6193f(BaseView ca4187010cdd35921f11dd5df8ccc23e3, string ce7f9759b9399b283bb11f85f6ee7d4e5)
	{
		if (_mapShortCutCMD.ContainsKey(ce7f9759b9399b283bb11f85f6ee7d4e5))
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
			if (_mapShortCutCMD[ce7f9759b9399b283bb11f85f6ee7d4e5].Contains(ca4187010cdd35921f11dd5df8ccc23e3))
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
		}
		else
		{
			_mapShortCutCMD.Add(ce7f9759b9399b283bb11f85f6ee7d4e5, new List<BaseView>());
		}
		_mapShortCutCMD[ce7f9759b9399b283bb11f85f6ee7d4e5].Add(ca4187010cdd35921f11dd5df8ccc23e3);
	}

	public void cee8cde4410c30a1ff6fab848a28cf88f(BaseView ca4187010cdd35921f11dd5df8ccc23e3, string ce7f9759b9399b283bb11f85f6ee7d4e5 = "")
	{
		if (!_mapShortCutCMD.ContainsKey(ce7f9759b9399b283bb11f85f6ee7d4e5))
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
			if (!_mapShortCutCMD[ce7f9759b9399b283bb11f85f6ee7d4e5].Contains(ca4187010cdd35921f11dd5df8ccc23e3))
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
				_mapShortCutCMD[ce7f9759b9399b283bb11f85f6ee7d4e5].Remove(ca4187010cdd35921f11dd5df8ccc23e3);
				return;
			}
		}
	}

	protected virtual void c7bb86b60f299c950179b9bd1c30a2a68()
	{
		Dictionary<string, List<BaseView>>.Enumerator enumerator = _mapShortCutCMD.GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (!c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.cd9a869e29c4cce44fbee025f63774fa9(enumerator.Current.Key))
			{
				continue;
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (!c4717862155dcb63da4094ee983c75b38)
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
			List<BaseView> value = enumerator.Current.Value;
			int num = 0;
			while (true)
			{
				if (num < value.Count)
				{
					if (value[num].OnShortCutCMD(enumerator.Current.Key))
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
						break;
					}
					num++;
					continue;
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
			if (c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.cd9a869e29c4cce44fbee025f63774fa9("Escape"))
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
				ce11e07f2061501a16aa108d2f845cc17();
			}
			if (!c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.cd9a869e29c4cce44fbee025f63774fa9("HideHUD"))
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
				if (!c4717862155dcb63da4094ee983c75b38)
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
					_bHudVisible = !_bHudVisible;
					c2a7c8d4c8942c3b965a1a3737dabaf3a(_bHudVisible);
					return;
				}
			}
		}
	}

	protected virtual bool ce11e07f2061501a16aa108d2f845cc17()
	{
		if (c5a9245d284a4186b1df5f04b4559bab8<HUDWarningView>().c150264a18c2cb408479d3f072cac8cc1)
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
					c5a9245d284a4186b1df5f04b4559bab8<HUDWarningView>().cfd58c94350618be817cfdb449a158aad();
					return true;
				}
			}
		}
		if (c5a9245d284a4186b1df5f04b4559bab8<PlayerListView>().cc130a2d46a451dc54b61a8f0d60794ae())
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					return true;
				}
			}
		}
		if (c5a9245d284a4186b1df5f04b4559bab8<PopupMenuView>().cd0069281ff5290a7e6c484b6aed3933d)
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
			if (c5a9245d284a4186b1df5f04b4559bab8<PopupMenuView>().c150264a18c2cb408479d3f072cac8cc1)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						c5a9245d284a4186b1df5f04b4559bab8<PopupMenuView>().c5bc8bb6c6b44d3d5bf9249765a5d8e27();
						return true;
					}
				}
			}
		}
		using (Dictionary<Type, BaseView>.Enumerator enumerator = _viewCreator.cdedc5bc9e949a111fe373551fa333f75().GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				KeyValuePair<Type, BaseView> current = enumerator.Current;
				if (current.Value is PauseMenuView)
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
				if (!current.Value.cd0069281ff5290a7e6c484b6aed3933d)
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
					break;
				}
				if (!current.Value.cc130a2d46a451dc54b61a8f0d60794ae())
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
					return true;
				}
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					goto end_IL_0118;
				}
				continue;
				end_IL_0118:
				break;
			}
		}
		if (c5a9245d284a4186b1df5f04b4559bab8<PauseMenuView>().cd0069281ff5290a7e6c484b6aed3933d)
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
			if (c5a9245d284a4186b1df5f04b4559bab8<PauseMenuView>().cc130a2d46a451dc54b61a8f0d60794ae())
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						return true;
					}
				}
			}
		}
		return false;
	}

	public virtual void cff2b0374fa4093a26652f81f964f8e9f(CursorManager.CursorType c6de715717a660431b466566175fe3dcf)
	{
		_cursorManager.c4614712875423a743006a8bf2f2b3ec8(c6de715717a660431b466566175fe3dcf);
	}
}
