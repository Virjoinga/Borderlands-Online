using System.Collections.Generic;
using A;
using UnityEngine;
using pumpkin.display;
using pumpkin.events;
using pumpkin.swf;
using pumpkin.text;

public class uniHUDWorldTipsView : HUDWorldTipsView
{
	protected enum VALUE_TYPE
	{
		V_NORMAL = 0,
		V_CRITICAL = 1,
		V_EXP = 2
	}

	private class CriticalPanel : c196099a1254db61d3be10d70e14e7422
	{
		protected MovieClip mcSelf;

		protected MovieClip mcRoot;

		public Vector3 startPosition;

		public bool c150264a18c2cb408479d3f072cac8cc1
		{
			get
			{
				if (mcSelf == null)
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
							return false;
						}
					}
				}
				return mcSelf.visible;
			}
			set
			{
				if (mcSelf == null)
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
					mcSelf.visible = value;
					return;
				}
			}
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			mcSelf = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			if (mcSelf == null)
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
						return;
					}
				}
			}
			mcRoot = mcSelf.getChildByName<MovieClip>("mcRoot");
			mcRoot.stop();
		}

		private void c6dcfe7ddb8c89d68b941555bbf4c7a6e(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			CEvent cEvent = new CEvent(CEvent.COMPLETE);
			cEvent.target = this;
			dispatchEvent(cEvent);
		}

		public void cb124d676649c1c93124dd817b94d753b()
		{
			mcRoot.gotoAndPlay(1);
		}

		public bool c21a593d1ebbfd5b28ce95b41ab6c544d()
		{
			if (mcRoot == null)
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
						return true;
					}
				}
			}
			return mcRoot.currentFrame == mcRoot.totalFrames;
		}
	}

	private class DamageValuePanel : c196099a1254db61d3be10d70e14e7422
	{
		public float fLifeTime;

		public float fTotalLife;

		public float fSpeedX;

		public float fSpeedZ;

		public Vector3 startPosition;

		public float fOrinWidth;

		public float fOrinHeight;

		protected MovieClip mcSelf;

		protected int _value;

		protected VALUE_TYPE _type;

		protected Dictionary<AttackInfo.ElementalType, string> _colorMap;

		public bool c150264a18c2cb408479d3f072cac8cc1
		{
			get
			{
				if (mcSelf == null)
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
							return false;
						}
					}
				}
				return mcSelf.visible;
			}
			set
			{
				if (mcSelf == null)
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
					mcSelf.visible = value;
					return;
				}
			}
		}

		public DamageValuePanel()
		{
			_colorMap = new Dictionary<AttackInfo.ElementalType, string>
			{
				{
					AttackInfo.ElementalType.None,
					"white"
				},
				{
					AttackInfo.ElementalType.Explosive,
					"yellow"
				},
				{
					AttackInfo.ElementalType.Fire,
					"orange"
				},
				{
					AttackInfo.ElementalType.Shock,
					"blue"
				},
				{
					AttackInfo.ElementalType.Corrosive,
					"green"
				},
				{
					AttackInfo.ElementalType.Max,
					"white"
				}
			};
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			mcSelf = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			if (mcSelf == null)
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
			mcSelf.stop();
			mcSelf.addEventListener(CEvent.ENTER_FRAME, ceaa978f6d74827f6e266028ad8f6cb47);
			mcSelf.visible = false;
			fOrinWidth = mcSelf.width;
			fOrinHeight = mcSelf.height;
		}

		private void ceaa978f6d74827f6e266028ad8f6cb47(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			TextField childByName = mcSelf.getChildByName<TextField>("textField");
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
				childByName.text = _value.ToString();
				return;
			}
		}

		public void cc52968d9957c36b0ad40f64c216612ac(int cefda2fdc3ce4e04f38bab77fc7998241, VALUE_TYPE c2b4f43f34e21572af6ab4414f04cee36, AttackInfo.ElementalType ca7d25124c0ec663889619b9b62110bc4)
		{
			_value = cefda2fdc3ce4e04f38bab77fc7998241;
			_type = c2b4f43f34e21572af6ab4414f04cee36;
			if (mcSelf == null)
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
				mcSelf.visible = true;
				if (mcSelf.getCurrentFrame() == mcSelf.getFrameLabel(_colorMap[ca7d25124c0ec663889619b9b62110bc4]))
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
						{
							TextField childByName = mcSelf.getChildByName<TextField>("textField");
							if (childByName != null)
							{
								while (true)
								{
									switch (2)
									{
									case 0:
										break;
									default:
										childByName.text = _value.ToString();
										return;
									}
								}
							}
							return;
						}
						}
					}
				}
				mcSelf.gotoAndStop(_colorMap[ca7d25124c0ec663889619b9b62110bc4]);
				return;
			}
		}
	}

	private const float TIME_DAMAGE_TEXT_LIFE = 1f;

	private const string PATH_VALUE_TEXT = "SightBead.swf:Value";

	private const string PATH_CRITICAL_TEXT = "SightBead.swf:CRITICAL";

	private c196099a1254db61d3be10d70e14e7422 _rootPanel;

	private MovieClip _MovieClipContainer;

	private List<DamageValuePanel> _showingDMGList;

	private List<CriticalPanel> _showingCriticalList;

	private SwfURI _valueTextURI;

	private SwfURI _valueCriticalURI;

	public uniHUDWorldTipsView()
	{
		_showingDMGList = new List<DamageValuePanel>();
		_showingCriticalList = new List<CriticalPanel>();
	}

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		if (_valueTextURI == null)
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
			_valueTextURI = new SwfURI("SightBead.swf:Value");
		}
		if (_valueCriticalURI == null)
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
			_valueCriticalURI = new SwfURI("SightBead.swf:CRITICAL");
		}
		_showingDMGList.Clear();
		_showingCriticalList.Clear();
		_rootPanel = new c196099a1254db61d3be10d70e14e7422();
		_MovieClipContainer = new MovieClip();
		MovieClip movieClipContainer = _MovieClipContainer;
		float num = 0f;
		_MovieClipContainer.y = num;
		movieClipContainer.x = num;
		_MovieClipContainer.width = 1280f;
		_MovieClipContainer.height = 720f;
		_rootPanel.c130648b59a0c8debea60aa153f844879(_MovieClipContainer);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c848674781d88e6f4b9eb89ca2b6f4610(_rootPanel);
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_rootPanel);
		_valueTextURI = c28a8945e6249b177869d20e80c496468.c7088de59e49f7108f520cf7e0bae167e;
		_valueCriticalURI = c28a8945e6249b177869d20e80c496468.c7088de59e49f7108f520cf7e0bae167e;
		_rootPanel = c9c0c8f01d2944aa6e09f167c382ebe52.c7088de59e49f7108f520cf7e0bae167e;
		_MovieClipContainer.removeAllChildren();
		_MovieClipContainer = c656b7be10c614ae4a7eb17c462d2f675.c7088de59e49f7108f520cf7e0bae167e;
		_showingDMGList.Clear();
		_showingCriticalList.Clear();
	}

	public override void c84366760d1fa67e4323e190564d3e406(int cefda2fdc3ce4e04f38bab77fc7998241, WeakPoint.StrengthType ced87b19bf4233f7b0fb7158c2a12135b, Vector3 c330987c4414f384d6c951ab9f68460d8, AttackInfo.ElementalType ca7d25124c0ec663889619b9b62110bc4 = AttackInfo.ElementalType.None, bool c1f8c79cf2bf3779a76233e83e6eff71e = true)
	{
		base.c84366760d1fa67e4323e190564d3e406(cefda2fdc3ce4e04f38bab77fc7998241, ced87b19bf4233f7b0fb7158c2a12135b, c330987c4414f384d6c951ab9f68460d8, ca7d25124c0ec663889619b9b62110bc4, c1f8c79cf2bf3779a76233e83e6eff71e);
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c91fcf132a3585bad3597263bc8937405 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		cea54b4c45c5746d83c86a8f8514466ff(cefda2fdc3ce4e04f38bab77fc7998241, ced87b19bf4233f7b0fb7158c2a12135b, c330987c4414f384d6c951ab9f68460d8, ca7d25124c0ec663889619b9b62110bc4);
		if (!c1f8c79cf2bf3779a76233e83e6eff71e)
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
			int num;
			if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c28b45877056e09d3c4d6fa790a1517aa())
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
				num = ((ced87b19bf4233f7b0fb7158c2a12135b == WeakPoint.StrengthType.Weak) ? 1 : 0);
			}
			else
			{
				num = 0;
			}
			bool flag = (byte)num != 0;
			if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c28b45877056e09d3c4d6fa790a1517aa())
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
				if (ced87b19bf4233f7b0fb7158c2a12135b == WeakPoint.StrengthType.VeryWeak)
				{
					goto IL_00be;
				}
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
			if (!flag)
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
				break;
			}
			goto IL_00be;
			IL_00be:
			c858363e0d3e5f9b313c5fe6c2f9f4ab2(c330987c4414f384d6c951ab9f68460d8);
			return;
		}
	}

	public override void c956bb171c47f265aa4f0da8bbca017bf()
	{
		base.c956bb171c47f265aa4f0da8bbca017bf();
		c65cd28aa6cffad4ad80187a11373c335();
		cf070e2bd0b6185a8a69af4209c7f365f();
	}

	private void c858363e0d3e5f9b313c5fe6c2f9f4ab2(Vector3 c330987c4414f384d6c951ab9f68460d8)
	{
		MovieClip movieClip = new MovieClip(_valueCriticalURI);
		Vector3 vector = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c91fcf132a3585bad3597263bc8937405.WorldToScreenPoint(c330987c4414f384d6c951ab9f68460d8);
		movieClip.x = Mathf.CeilToInt(vector.x / ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.c38416c96b869af0e164ff13994b8aa12);
		movieClip.y = Mathf.CeilToInt(((float)Screen.height - vector.y) / ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.c38416c96b869af0e164ff13994b8aa12);
		CriticalPanel criticalPanel = new CriticalPanel();
		criticalPanel.c130648b59a0c8debea60aa153f844879(movieClip);
		criticalPanel.addEventListener(CEvent.COMPLETE, cacaa4e935d5b069f6c89acc89188d2d8);
		criticalPanel.startPosition = c330987c4414f384d6c951ab9f68460d8;
		criticalPanel.cb124d676649c1c93124dd817b94d753b();
		_MovieClipContainer.addChild(movieClip);
		_showingCriticalList.Add(criticalPanel);
	}

	private void cf070e2bd0b6185a8a69af4209c7f365f()
	{
		Camera c91fcf132a3585bad3597263bc = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c91fcf132a3585bad3597263bc8937405;
		List<CriticalPanel> list = new List<CriticalPanel>();
		int count = _showingCriticalList.Count;
		for (int i = 0; i < count; i++)
		{
			CriticalPanel criticalPanel = _showingCriticalList[i];
			if (criticalPanel.c21a593d1ebbfd5b28ce95b41ab6c544d())
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
				list.Add(criticalPanel);
				continue;
			}
			DisplayObject c89ef242f4744e0f1c4ffea4da8b79bc = criticalPanel.c89ef242f4744e0f1c4ffea4da8b79bc1;
			Vector3 vector = c91fcf132a3585bad3597263bc.WorldToScreenPoint(criticalPanel.startPosition);
			c89ef242f4744e0f1c4ffea4da8b79bc.visible = vector.z >= 0f;
			if (c89ef242f4744e0f1c4ffea4da8b79bc.visible)
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
				c89ef242f4744e0f1c4ffea4da8b79bc.x = Mathf.CeilToInt(vector.x / ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.c38416c96b869af0e164ff13994b8aa12);
				c89ef242f4744e0f1c4ffea4da8b79bc.y = Mathf.CeilToInt(((float)Screen.height - vector.y) / ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.c38416c96b869af0e164ff13994b8aa12);
			}
			c89ef242f4744e0f1c4ffea4da8b79bc = cc7b206340b600c7decc4e7b5711da220.c7088de59e49f7108f520cf7e0bae167e;
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				continue;
			}
			count = list.Count;
			for (int j = 0; j < count; j++)
			{
				cacaa4e935d5b069f6c89acc89188d2d8(list[j]);
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				list.Clear();
				return;
			}
		}
	}

	private void cacaa4e935d5b069f6c89acc89188d2d8(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		CriticalPanel criticalPanel = c3d202dee321219a80026dc3081fb3c86.target as CriticalPanel;
		if (criticalPanel == null)
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
			cacaa4e935d5b069f6c89acc89188d2d8(criticalPanel);
			return;
		}
	}

	private void cacaa4e935d5b069f6c89acc89188d2d8(CriticalPanel cc6599ad24468b65beba8458e042d31d2)
	{
		_MovieClipContainer.removeChild(cc6599ad24468b65beba8458e042d31d2.c89ef242f4744e0f1c4ffea4da8b79bc1);
		_showingCriticalList.Remove(cc6599ad24468b65beba8458e042d31d2);
		cc6599ad24468b65beba8458e042d31d2 = null;
	}

	private void cea54b4c45c5746d83c86a8f8514466ff(int cefda2fdc3ce4e04f38bab77fc7998241, WeakPoint.StrengthType ced87b19bf4233f7b0fb7158c2a12135b, Vector3 cfa8eaa59e47776cc70137e098f306794, AttackInfo.ElementalType ca7d25124c0ec663889619b9b62110bc4)
	{
		float fTotalLife = 1f;
		MovieClip c998c56e5cab278873f1a5722e79733da = new MovieClip(_valueTextURI);
		DamageValuePanel damageValuePanel = new DamageValuePanel();
		damageValuePanel.c130648b59a0c8debea60aa153f844879(c998c56e5cab278873f1a5722e79733da);
		int c2b4f43f34e21572af6ab4414f04cee;
		if (ced87b19bf4233f7b0fb7158c2a12135b == WeakPoint.StrengthType.VeryWeak)
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
			c2b4f43f34e21572af6ab4414f04cee = 1;
		}
		else
		{
			c2b4f43f34e21572af6ab4414f04cee = 0;
		}
		damageValuePanel.cc52968d9957c36b0ad40f64c216612ac(cefda2fdc3ce4e04f38bab77fc7998241, (VALUE_TYPE)c2b4f43f34e21572af6ab4414f04cee, ca7d25124c0ec663889619b9b62110bc4);
		damageValuePanel.fLifeTime = 0f;
		damageValuePanel.fTotalLife = fTotalLife;
		damageValuePanel.startPosition = cfa8eaa59e47776cc70137e098f306794;
		int num;
		if (Random.Range(1f, 3f) > 2f)
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
			num = -1;
		}
		else
		{
			num = 1;
		}
		float num2 = num;
		damageValuePanel.fSpeedX = Random.Range(0.45f, 0.7f) * num2;
		int num3;
		if (Random.Range(6f, 8f) > 7f)
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
			num3 = -1;
		}
		else
		{
			num3 = 1;
		}
		num2 = num3;
		damageValuePanel.fSpeedZ = Random.Range(0.45f, 0.7f) * num2;
		damageValuePanel.c150264a18c2cb408479d3f072cac8cc1 = false;
		_MovieClipContainer.addChild(damageValuePanel.c89ef242f4744e0f1c4ffea4da8b79bc1);
		_showingDMGList.Add(damageValuePanel);
	}

	private void c6c2d87ff1185146fa4fe533584f241c8(DamageValuePanel cc6599ad24468b65beba8458e042d31d2)
	{
		_MovieClipContainer.removeChild(cc6599ad24468b65beba8458e042d31d2.c89ef242f4744e0f1c4ffea4da8b79bc1);
		_showingDMGList.Remove(cc6599ad24468b65beba8458e042d31d2);
		cc6599ad24468b65beba8458e042d31d2 = null;
	}

	private void c65cd28aa6cffad4ad80187a11373c335()
	{
		Camera c91fcf132a3585bad3597263bc = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c91fcf132a3585bad3597263bc8937405;
		List<DamageValuePanel> list = new List<DamageValuePanel>();
		int count = _showingDMGList.Count;
		float num = 0f;
		for (int i = 0; i < count; i++)
		{
			DamageValuePanel damageValuePanel = _showingDMGList[i];
			if (damageValuePanel.fLifeTime < damageValuePanel.fTotalLife)
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
				damageValuePanel.c150264a18c2cb408479d3f072cac8cc1 = true;
				Vector3 zero = Vector3.zero;
				zero.x = damageValuePanel.fSpeedX * damageValuePanel.fLifeTime;
				zero.z = damageValuePanel.fSpeedZ * damageValuePanel.fLifeTime;
				num = damageValuePanel.fTotalLife * 0.45f;
				zero.y = 0.6f - (num - damageValuePanel.fLifeTime) * (num - damageValuePanel.fLifeTime) / (num * num) * 0.6f;
				Vector3 vector = c91fcf132a3585bad3597263bc.WorldToScreenPoint(damageValuePanel.startPosition + zero);
				if (vector.z >= 0f)
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
					damageValuePanel.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = true;
					if (damageValuePanel.fOrinHeight > 0f)
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
						float num2 = Mathf.Min(1.5f, (c91fcf132a3585bad3597263bc.WorldToScreenPoint(damageValuePanel.startPosition + zero + Vector3.up * 0.2f).y - vector.y) / damageValuePanel.fOrinHeight);
						if (damageValuePanel.fLifeTime < 0.3f)
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
							num2 *= 0.6f + 0.5f * damageValuePanel.fLifeTime / 0.3f;
						}
						else if (damageValuePanel.fLifeTime < 0.6f)
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
							num2 *= 1.15f;
						}
						else
						{
							num2 *= 1.15f - 0.6f * (damageValuePanel.fLifeTime - 0.6f) / (damageValuePanel.fTotalLife - 0.6f);
						}
						float alpha = 1f;
						if (damageValuePanel.fLifeTime > damageValuePanel.fTotalLife * 0.7f)
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
							alpha = 1f - 0.8f * (damageValuePanel.fLifeTime - 0.7f) / (damageValuePanel.fTotalLife - 0.7f);
						}
						DisplayObjectContainer c89ef242f4744e0f1c4ffea4da8b79bc = damageValuePanel.c89ef242f4744e0f1c4ffea4da8b79bc1;
						float num3 = num2 * 2f;
						damageValuePanel.c89ef242f4744e0f1c4ffea4da8b79bc1.scaleY = num3;
						c89ef242f4744e0f1c4ffea4da8b79bc.scaleX = num3;
						damageValuePanel.c89ef242f4744e0f1c4ffea4da8b79bc1.alpha = alpha;
					}
					damageValuePanel.c89ef242f4744e0f1c4ffea4da8b79bc1.x = Mathf.CeilToInt(vector.x / ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.c38416c96b869af0e164ff13994b8aa12);
					damageValuePanel.c89ef242f4744e0f1c4ffea4da8b79bc1.y = Mathf.CeilToInt(((float)Screen.height - vector.y) / ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.c38416c96b869af0e164ff13994b8aa12);
				}
				else
				{
					damageValuePanel.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = false;
				}
			}
			else
			{
				list.Add(damageValuePanel);
			}
			damageValuePanel.fLifeTime += Time.deltaTime;
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			count = list.Count;
			for (int j = 0; j < count; j++)
			{
				c6c2d87ff1185146fa4fe533584f241c8(list[j]);
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				list.Clear();
				return;
			}
		}
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
		if (_rootPanel == null)
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
			_rootPanel.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = _bVisible;
			return;
		}
	}
}
