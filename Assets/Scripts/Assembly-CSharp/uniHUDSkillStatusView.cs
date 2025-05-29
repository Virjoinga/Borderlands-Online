using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

public class uniHUDSkillStatusView : HUDSkillStatusView
{
	public class SkillRoot : c196099a1254db61d3be10d70e14e7422
	{
		protected SmallSkillIconAnimation _coolDownPhaseIcon;

		protected SmallSkillIconAnimation _onGoingPhaseIcon;

		protected LargeSkillIconAnimation _largeSkillIcon;

		protected DurationBar _durationBar;

		protected BoomOutCombo _upperBoomAnimation;

		protected BoomOutCombo _lowerBoomAnimation;

		protected SkillID _curSKillID;

		protected eCurState _curSKillPhase;

		protected MovieClip _rootMC;

		protected float _f1stSkillRateWhenCallBack;

		protected float _fCurProgressRate;

		protected int _iUnSpentSkillPt;

		protected int _iEarnedSkillPt;

		protected bool _bSecondSkillUnlocked;

		protected bool _bSecondSkillUsed;

		public SkillID c48dc9de69f206a4a07b8c9785fe4114c
		{
			set
			{
				_curSKillID = value;
			}
		}

		public eCurState c52fe0be0bbca52c9b3c54236cd434f4a
		{
			set
			{
				_curSKillPhase = value;
			}
		}

		public float c67e98f116f5984230addc26c6a854794
		{
			set
			{
				_fCurProgressRate = value;
			}
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			_rootMC = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			_coolDownPhaseIcon = new SmallSkillIconAnimation();
			_onGoingPhaseIcon = new SmallSkillIconAnimation();
			_largeSkillIcon = new LargeSkillIconAnimation();
			_durationBar = new DurationBar();
			_upperBoomAnimation = new BoomOutCombo();
			_lowerBoomAnimation = new BoomOutCombo();
			_rootMC.addFrameScript("fade in", c1cc0d9854aee3ae81092f51d078a700a);
			_rootMC.addFrameScript("BarFadeIn", caa96a5829b8a24dab1a3314017f07436);
			_rootMC.addFrameScript("LoopEnd", c7b841ee249585075a7282f595b88b38d);
			_rootMC.addFrameScript("ActiveAnima", cba1dd1cc49c6a912ef19732a23ed0479);
		}

		public void cdd6bdb37541f370f33d365ef8857218e(bool c9d4adcb664bf2e6d70b72459bf47a4ee)
		{
			_bSecondSkillUnlocked = c9d4adcb664bf2e6d70b72459bf47a4ee;
		}

		protected void cba1dd1cc49c6a912ef19732a23ed0479(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			MovieClip childByName = _rootMC.getChildByName<MovieClip>("mcSmallMask");
			MovieClip childByName2 = _rootMC.getChildByName<MovieClip>("mcCoolDownPhaseIcon");
			if (childByName == null)
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
				if (childByName2 == null)
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
					childByName.visible = false;
					childByName2.removeAllEventListeners(CEvent.ENTER_FRAME);
					childByName2.addEventListener(CEvent.ENTER_FRAME, ce24795b8ffc783d8ab818d49d735c682);
					return;
				}
			}
		}

		protected void ce24795b8ffc783d8ab818d49d735c682(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			MovieClip childByName = _rootMC.getChildByName<MovieClip>("mcSmallMask");
			MovieClip childByName2 = _rootMC.getChildByName<MovieClip>("mcCoolDownPhaseIcon");
			if (childByName == null)
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
				if (childByName2 == null)
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
					childByName2.clipRect = childByName.getBounds(childByName2).rect;
					childByName.visible = false;
					return;
				}
			}
		}

		protected void c2eaabbc183361c66da93ecb410092e66()
		{
			MovieClip childByName = _rootMC.getChildByName<MovieClip>("mcLargeMaskCover");
			if (childByName != null)
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
				childByName.addEventListener(CEvent.ENTER_FRAME, c3ed62873a2020ab1e786db0e7a2f6b59);
			}
			MovieClip childByName2 = _rootMC.getChildByName<MovieClip>("mcLargeMask");
			if (childByName2 == null)
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
				childByName2.visible = false;
				return;
			}
		}

		protected void c3ed62873a2020ab1e786db0e7a2f6b59(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			MovieClip childByName = _rootMC.getChildByName<MovieClip>("mcLargeMask");
			if (childByName == null)
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
				childByName.visible = false;
				MovieClip childByName2 = _rootMC.getChildByName<MovieClip>("mcLargeSkillIconAnimation");
				if (childByName2 != null)
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
					childByName2.clipRect = childByName.getBounds(childByName2).rect;
				}
				MovieClip childByName3 = _rootMC.getChildByName<MovieClip>("mcOnGoingPhaseIcon");
				if (childByName3 != null)
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
					childByName3.clipRect = childByName.getBounds(childByName3).rect;
				}
				MovieClip childByName4 = _rootMC.getChildByName<MovieClip>("mcDurationBar");
				if (childByName4 == null)
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
					childByName4.clipRect = childByName.getBounds(childByName4).rect;
					return;
				}
			}
		}

		public void c1d51e33bf2f5c865e5a00507c3bb2561()
		{
			_rootMC.removeAllEventListeners(CEvent.ENTER_FRAME);
			_rootMC.gotoAndPlay("normal");
			_bSecondSkillUsed = false;
			_f1stSkillRateWhenCallBack = 0f;
			_coolDownPhaseIcon.c130648b59a0c8debea60aa153f844879(_rootMC.getChildByName<MovieClip>("mcCoolDownPhaseIcon"));
			_coolDownPhaseIcon.c977b3c017d485b77f8b10d0ce5f7a6b8(true);
			_coolDownPhaseIcon.c0a322a4be25fd65f73ae57229d5ab62f(eCurState.FirstAction, _curSKillID);
			_coolDownPhaseIcon.c75beedbc49efe0ed7c07873eaeeb0a25(_iUnSpentSkillPt);
		}

		public void c04198fa437b0e2de3f89bec4259839ac()
		{
			_rootMC.removeAllEventListeners(CEvent.ENTER_FRAME);
			_rootMC.gotoAndPlay("ActiveAnima");
			_rootMC.addEventListener(CEvent.ENTER_FRAME, c8dbc499e9808f4fcb7e81bc36bf25daf);
			MovieClip childByName = _rootMC.getChildByName<MovieClip>("mcCoolDownPhaseIcon");
			_coolDownPhaseIcon.c130648b59a0c8debea60aa153f844879(childByName);
			_coolDownPhaseIcon.c0a322a4be25fd65f73ae57229d5ab62f(eCurState.FirstAction, _curSKillID);
			_coolDownPhaseIcon.c977b3c017d485b77f8b10d0ce5f7a6b8(true);
			_coolDownPhaseIcon.c75beedbc49efe0ed7c07873eaeeb0a25(_iUnSpentSkillPt);
			_coolDownPhaseIcon.cc145bfe353f3fbbce8d272ab96c1f1d0(0f);
		}

		protected void c8dbc499e9808f4fcb7e81bc36bf25daf(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			_onGoingPhaseIcon.c43cbb41bf755dfa61de619fc6e86ab31(_bSecondSkillUnlocked);
			_durationBar.c99595b74276138cc095f9087059d16e3((int)((1f - _fCurProgressRate) * 100f));
		}

		protected void caa96a5829b8a24dab1a3314017f07436(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			_largeSkillIcon.c130648b59a0c8debea60aa153f844879(_rootMC.getChildByName<MovieClip>("mcLargeSkillIconAnimation"));
			_largeSkillIcon.c8c03a36f3b37a55d9ab8debd92769a44(eCurState.FirstAction, _curSKillID);
			_onGoingPhaseIcon.c130648b59a0c8debea60aa153f844879(_rootMC.getChildByName<MovieClip>("mcOnGoingPhaseIcon"));
			_onGoingPhaseIcon.c977b3c017d485b77f8b10d0ce5f7a6b8(true);
			_onGoingPhaseIcon.c0a322a4be25fd65f73ae57229d5ab62f(eCurState.SecondAction, _curSKillID);
			_onGoingPhaseIcon.c43cbb41bf755dfa61de619fc6e86ab31(_bSecondSkillUnlocked);
			_durationBar.c130648b59a0c8debea60aa153f844879(_rootMC.getChildByName<MovieClip>("mcDurationBar"));
			_durationBar.c99595b74276138cc095f9087059d16e3(0);
			_durationBar.cf9d846fb097cbe1976cbe5bc26d57c0c(false);
			c2eaabbc183361c66da93ecb410092e66();
		}

		public void c8824c5c1c52bff2a141f509944017ce1()
		{
			_rootMC.removeAllEventListeners(CEvent.ENTER_FRAME);
			_rootMC.addEventListener(CEvent.ENTER_FRAME, c69c61e70be5fcb0b04f42e506384b7d8);
			MovieClip childByName = _rootMC.getChildByName<MovieClip>("mcLargeSkillIconAnimation");
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
				_largeSkillIcon.c130648b59a0c8debea60aa153f844879(childByName);
				_largeSkillIcon.c8c03a36f3b37a55d9ab8debd92769a44(eCurState.FirstAction, _curSKillID);
			}
			MovieClip childByName2 = _rootMC.getChildByName<MovieClip>("mcOnGoingPhaseIcon");
			if (childByName2 != null)
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
				_onGoingPhaseIcon.c130648b59a0c8debea60aa153f844879(_rootMC.getChildByName<MovieClip>("mcOnGoingPhaseIcon"));
				_onGoingPhaseIcon.c977b3c017d485b77f8b10d0ce5f7a6b8(true);
				_onGoingPhaseIcon.c0a322a4be25fd65f73ae57229d5ab62f(eCurState.SecondAction, _curSKillID);
			}
			MovieClip childByName3 = _rootMC.getChildByName<MovieClip>("mcDurationBar");
			if (childByName3 == null)
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
				_durationBar.c130648b59a0c8debea60aa153f844879(_rootMC.getChildByName<MovieClip>("mcDurationBar"));
				_durationBar.c99595b74276138cc095f9087059d16e3(0);
				_durationBar.cf9d846fb097cbe1976cbe5bc26d57c0c(false);
				return;
			}
		}

		protected void c7b841ee249585075a7282f595b88b38d(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			_rootMC.gotoAndPlay("LoopStart");
		}

		protected void c69c61e70be5fcb0b04f42e506384b7d8(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			_onGoingPhaseIcon.c43cbb41bf755dfa61de619fc6e86ab31(_bSecondSkillUnlocked);
			int num = (int)(_fCurProgressRate * 100f);
			if (_fCurProgressRate == 0f)
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
				if (_fCurProgressRate == 1f)
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
					if (!(_f1stSkillRateWhenCallBack <= _fCurProgressRate))
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
						num = 100 - num;
						_durationBar.c99595b74276138cc095f9087059d16e3(num);
						return;
					}
				}
			}
		}

		public void c406aef905d0dafd1f4c223dec53a6130()
		{
			_rootMC.removeAllEventListeners(CEvent.ENTER_FRAME);
			_rootMC.addEventListener(CEvent.ENTER_FRAME, c31dcd108558836cfd3b04c6b70c2a025);
			_onGoingPhaseIcon.c43cbb41bf755dfa61de619fc6e86ab31(false);
			_largeSkillIcon.cb573bcf93999ed848462a45cd5cfadac(_curSKillID);
			_bSecondSkillUsed = true;
			if (_curSKillID != SkillID.Berserk)
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
				_durationBar.cf9d846fb097cbe1976cbe5bc26d57c0c(true);
				return;
			}
		}

		protected void c31dcd108558836cfd3b04c6b70c2a025(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			_onGoingPhaseIcon.c43cbb41bf755dfa61de619fc6e86ab31(false);
		}

		public void c6db6e7bbcc22d06ecb4c98646536ecf4()
		{
			_durationBar.c99595b74276138cc095f9087059d16e3(0);
			_rootMC.removeAllEventListeners(CEvent.ENTER_FRAME);
			_rootMC.addEventListener(CEvent.ENTER_FRAME, cc5e087ca280326dba8d7bb4bdb150b03);
			_rootMC.gotoAndPlay("boom out");
			int num = 0;
			num = 100 - (int)(_fCurProgressRate * 100f);
			_upperBoomAnimation.c130648b59a0c8debea60aa153f844879(_rootMC.getChildByName<MovieClip>("mcUpperBoomAni"));
			_upperBoomAnimation.c4339a0460981803ffc66837d5c477430(_bSecondSkillUsed, _curSKillID);
			_upperBoomAnimation.c99595b74276138cc095f9087059d16e3(num);
			BoomOutCombo upperBoomAnimation = _upperBoomAnimation;
			int c887b65c1f71afd083faa23b5a9d45c6b;
			if (!_bSecondSkillUsed)
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
				c887b65c1f71afd083faa23b5a9d45c6b = (_bSecondSkillUnlocked ? 1 : 0);
			}
			else
			{
				c887b65c1f71afd083faa23b5a9d45c6b = 0;
			}
			upperBoomAnimation.c887b65c1f71afd083faa23b5a9d45c6b = (byte)c887b65c1f71afd083faa23b5a9d45c6b != 0;
			_lowerBoomAnimation.c130648b59a0c8debea60aa153f844879(_rootMC.getChildByName<MovieClip>("mcLowerBoomAni"));
			_lowerBoomAnimation.c99595b74276138cc095f9087059d16e3(num);
			_lowerBoomAnimation.c4339a0460981803ffc66837d5c477430(_bSecondSkillUsed, _curSKillID);
			BoomOutCombo lowerBoomAnimation = _lowerBoomAnimation;
			int c887b65c1f71afd083faa23b5a9d45c6b2;
			if (!_bSecondSkillUsed)
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
				c887b65c1f71afd083faa23b5a9d45c6b2 = (_bSecondSkillUnlocked ? 1 : 0);
			}
			else
			{
				c887b65c1f71afd083faa23b5a9d45c6b2 = 0;
			}
			lowerBoomAnimation.c887b65c1f71afd083faa23b5a9d45c6b = (byte)c887b65c1f71afd083faa23b5a9d45c6b2 != 0;
			_coolDownPhaseIcon.c75beedbc49efe0ed7c07873eaeeb0a25(_iUnSpentSkillPt);
		}

		protected void cc5e087ca280326dba8d7bb4bdb150b03(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			_coolDownPhaseIcon.cc145bfe353f3fbbce8d272ab96c1f1d0(_fCurProgressRate);
			_coolDownPhaseIcon.c0a322a4be25fd65f73ae57229d5ab62f(eCurState.FirstAction, _curSKillID);
			_coolDownPhaseIcon.c977b3c017d485b77f8b10d0ce5f7a6b8(false);
		}

		protected void c1cc0d9854aee3ae81092f51d078a700a(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			_coolDownPhaseIcon.c130648b59a0c8debea60aa153f844879(_rootMC.getChildByName<MovieClip>("mcCoolDownPhaseIcon"));
			_coolDownPhaseIcon.cc145bfe353f3fbbce8d272ab96c1f1d0(_fCurProgressRate);
			_coolDownPhaseIcon.c0a322a4be25fd65f73ae57229d5ab62f(eCurState.FirstAction, _curSKillID);
			_coolDownPhaseIcon.c977b3c017d485b77f8b10d0ce5f7a6b8(false);
			_coolDownPhaseIcon.c75beedbc49efe0ed7c07873eaeeb0a25(_iUnSpentSkillPt);
		}

		public void cdb85fb3ed6aa9ab4e56c7df9b2224044()
		{
			_durationBar.cf9d846fb097cbe1976cbe5bc26d57c0c(true);
		}

		public void ca99d83562046345488d42e3917afb097(int cbd4e5e5da398a32e402d5dd43895538c, int c6c0c0bc7a36df7e2e1890230e95489a4)
		{
			_iUnSpentSkillPt = c6c0c0bc7a36df7e2e1890230e95489a4;
			_iEarnedSkillPt = cbd4e5e5da398a32e402d5dd43895538c;
			if (_coolDownPhaseIcon == null)
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
				_coolDownPhaseIcon.c75beedbc49efe0ed7c07873eaeeb0a25(c6c0c0bc7a36df7e2e1890230e95489a4);
				return;
			}
		}

		public void ce85db71804aa56e2fd9331211692bf94()
		{
			c703c5fded04cda53a7b6b36f5ca11a10.c5ee19dc8d4cccf5ae2de225410458b86.ceb41162a7cd2a1d5c4a03830e02b4198.c462fe1a64a37daab5e61f688d9a61e7f("UI_Skill_Ready");
			c1d51e33bf2f5c865e5a00507c3bb2561();
			_coolDownPhaseIcon.cc881d693440edb7821152ca69b5f4bca();
		}
	}

	public class SmallSkillIconAnimation : c196099a1254db61d3be10d70e14e7422
	{
		protected TextField _textKeyTip;

		protected TextField _textSkillPont;

		protected SkillIcon _skillIcon;

		protected MovieClip _rootMC;

		protected int _iUnspentPt;

		protected eCurState _eCurState;

		protected SkillID _skillID;

		[CompilerGenerated]
		private static Dictionary<string, int> _003C_003Ef__switch_0024map1A;

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool result = false;
			string name = movieClip.name;
			if (name != null)
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
				if (_003C_003Ef__switch_0024map1A == null)
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
					Dictionary<string, int> dictionary = new Dictionary<string, int>(1);
					dictionary.Add("mcIcon", 0);
					_003C_003Ef__switch_0024map1A = dictionary;
				}
				int value;
				if (_003C_003Ef__switch_0024map1A.TryGetValue(name, out value))
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
					if (value != 0)
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
					}
					else
					{
						_skillIcon = new SkillIcon();
						_skillIcon.c130648b59a0c8debea60aa153f844879(movieClip);
						result = true;
					}
				}
			}
			return result;
		}

		public void c3bccf0982c5ad5515ebf5807ee539e99(bool c74232243aff1dcbf2e8fc243633bb51a)
		{
			TextField childByName = _rootMC.getChildByName<TextField>("SkillPoint");
			if (childByName == null)
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
				childByName.visible = c74232243aff1dcbf2e8fc243633bb51a;
				return;
			}
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			_rootMC = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			_rootMC.visible = false;
			_rootMC.addFrameScript("animaEnd", c0557e8269e607e5f9deb4c4b77cea40a);
			c977b3c017d485b77f8b10d0ce5f7a6b8(false);
		}

		public void c977b3c017d485b77f8b10d0ce5f7a6b8(bool c74232243aff1dcbf2e8fc243633bb51a)
		{
			TextField childByName = _rootMC.getChildByName<TextField>("KeyTip");
			if (childByName == null)
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
				childByName.visible = c74232243aff1dcbf2e8fc243633bb51a;
				return;
			}
		}

		public void c75beedbc49efe0ed7c07873eaeeb0a25(int c6c0c0bc7a36df7e2e1890230e95489a4)
		{
			_iUnspentPt = c6c0c0bc7a36df7e2e1890230e95489a4;
			if (_rootMC == null)
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
				TextField childByName = _rootMC.getChildByName<TextField>("SkillPoint");
				if (childByName == null)
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
					string text = c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e;
					if (c6c0c0bc7a36df7e2e1890230e95489a4 > 0)
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
						text = Convert.ToString(c6c0c0bc7a36df7e2e1890230e95489a4);
					}
					childByName.text = text;
					return;
				}
			}
		}

		public void c43cbb41bf755dfa61de619fc6e86ab31(bool c74232243aff1dcbf2e8fc243633bb51a)
		{
			if (_rootMC == null)
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
				_rootMC.visible = c74232243aff1dcbf2e8fc243633bb51a;
				return;
			}
		}

		public void c0a322a4be25fd65f73ae57229d5ab62f(eCurState c18c332dd86801e9800e3e4443a06d4f2, SkillID cec2361c8c6c5b0a36e34e8a479ff74ad)
		{
			_eCurState = c18c332dd86801e9800e3e4443a06d4f2;
			_skillID = cec2361c8c6c5b0a36e34e8a479ff74ad;
			if (_skillIcon == null)
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
				_skillIcon.c8c03a36f3b37a55d9ab8debd92769a44(c18c332dd86801e9800e3e4443a06d4f2, cec2361c8c6c5b0a36e34e8a479ff74ad);
				return;
			}
		}

		public void cc145bfe353f3fbbce8d272ab96c1f1d0(float c32e0e6207ac89ce45f0302861859f7b1)
		{
			int num = (int)(c32e0e6207ac89ce45f0302861859f7b1 * 50f);
			MovieClip movieClip = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			if (movieClip == null)
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
				(ca37fcdce7d4937b60735f4033eb55695 as MovieClip).gotoAndStop(num + 3);
				return;
			}
		}

		public void cc881d693440edb7821152ca69b5f4bca()
		{
			_rootMC.gotoAndPlay("coolDownEnd");
		}

		protected void c0557e8269e607e5f9deb4c4b77cea40a(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			_rootMC.gotoAndStop("normal");
		}
	}

	public class LargeSkillIconAnimation : c196099a1254db61d3be10d70e14e7422
	{
		protected SkillIcon _skillIcon;

		protected SkillID _skillID;

		[CompilerGenerated]
		private static Dictionary<string, int> _003C_003Ef__switch_0024map1B;

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool result = false;
			string name = movieClip.name;
			if (name != null)
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
				if (_003C_003Ef__switch_0024map1B == null)
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
					Dictionary<string, int> dictionary = new Dictionary<string, int>(1);
					dictionary.Add("mcSkillIcon", 0);
					_003C_003Ef__switch_0024map1B = dictionary;
				}
				int value;
				if (_003C_003Ef__switch_0024map1B.TryGetValue(name, out value))
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
					if (value != 0)
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
					}
					else
					{
						_skillIcon = new SkillIcon();
						_skillIcon.c130648b59a0c8debea60aa153f844879(movieClip, "normal", cbe803aa457a8311ef24963f141c06f73.c7088de59e49f7108f520cf7e0bae167e);
						_skillIcon.c130648b59a0c8debea60aa153f844879(movieClip, "iconA", cbe803aa457a8311ef24963f141c06f73.c7088de59e49f7108f520cf7e0bae167e);
						_skillIcon.c130648b59a0c8debea60aa153f844879(movieClip, "iconAEnd", cbe803aa457a8311ef24963f141c06f73.c7088de59e49f7108f520cf7e0bae167e);
						_skillIcon.c130648b59a0c8debea60aa153f844879(movieClip, "iconB", cbe803aa457a8311ef24963f141c06f73.c7088de59e49f7108f520cf7e0bae167e);
						_skillIcon.c130648b59a0c8debea60aa153f844879(movieClip, "iconBEnd", cbe803aa457a8311ef24963f141c06f73.c7088de59e49f7108f520cf7e0bae167e);
						result = true;
					}
				}
			}
			return result;
		}

		public void c8c03a36f3b37a55d9ab8debd92769a44(eCurState c18c332dd86801e9800e3e4443a06d4f2, SkillID cec2361c8c6c5b0a36e34e8a479ff74ad)
		{
			if (_skillIcon == null)
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
				_skillIcon.c8c03a36f3b37a55d9ab8debd92769a44(c18c332dd86801e9800e3e4443a06d4f2, cec2361c8c6c5b0a36e34e8a479ff74ad);
				return;
			}
		}

		public void cb573bcf93999ed848462a45cd5cfadac(SkillID cec2361c8c6c5b0a36e34e8a479ff74ad)
		{
			MovieClip movieClip = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			if (movieClip == null)
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
			movieClip.gotoAndPlay("iconA");
			movieClip.addFrameScript("iconB", c9d66ef5d477bfc5b94afef84a22863c6);
			_skillID = cec2361c8c6c5b0a36e34e8a479ff74ad;
		}

		protected void c9d66ef5d477bfc5b94afef84a22863c6(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			_skillIcon.c8c03a36f3b37a55d9ab8debd92769a44(eCurState.SecondAction, _skillID);
		}
	}

	public class SkillIcon : c196099a1254db61d3be10d70e14e7422
	{
		public void c8c03a36f3b37a55d9ab8debd92769a44(eCurState c0bb32bee3cf6dd96e41e00dc5a4ae21a, SkillID cec2361c8c6c5b0a36e34e8a479ff74ad)
		{
			MovieClip movieClip = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			string to = cec2361c8c6c5b0a36e34e8a479ff74ad.ToString() + c0bb32bee3cf6dd96e41e00dc5a4ae21a;
			movieClip.gotoAndStop(to);
		}
	}

	public class DurationBar : c196099a1254db61d3be10d70e14e7422
	{
		protected MovieClip m_shakeEffect;

		protected MovieClip _rootMC;

		protected MovieClip _maskMC;

		protected MovieClip _slaveMC;

		[CompilerGenerated]
		private static Dictionary<string, int> _003C_003Ef__switch_0024map1C;

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool result = false;
			string name = movieClip.name;
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
				if (_003C_003Ef__switch_0024map1C == null)
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
					Dictionary<string, int> dictionary = new Dictionary<string, int>(1);
					dictionary.Add("mcShakeEffect", 0);
					_003C_003Ef__switch_0024map1C = dictionary;
				}
				int value;
				if (_003C_003Ef__switch_0024map1C.TryGetValue(name, out value))
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
					if (value != 0)
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
					}
					else
					{
						m_shakeEffect = movieClip;
						result = true;
					}
				}
			}
			return result;
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			_rootMC = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			_rootMC.addEventListener(CEvent.ENTER_FRAME, cdec6d9ae9920a2e719225dc49eb925bc);
			_rootMC.gotoAndStop(1);
			_maskMC = _rootMC.getChildByName<MovieClip>("mcMask");
			_slaveMC = _rootMC.getChildByName<MovieClip>("mcSlave");
			if (_maskMC == null)
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
				_maskMC.visible = false;
				return;
			}
		}

		protected void cdec6d9ae9920a2e719225dc49eb925bc(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			if (_slaveMC == null)
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
				_slaveMC = _rootMC.getChildByName<MovieClip>("mcSlave");
			}
			if (_maskMC == null)
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
				_maskMC = _rootMC.getChildByName<MovieClip>("mcMask");
			}
			if (_maskMC == null)
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
				if (_slaveMC == null)
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
					_slaveMC.clipRect = _maskMC.getBounds(_slaveMC).rect;
					return;
				}
			}
		}

		public void c99595b74276138cc095f9087059d16e3(int c05a87f1785349aab1f16f495be4124ec)
		{
			if (_rootMC == null)
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
				_rootMC.gotoAndStop(c05a87f1785349aab1f16f495be4124ec + 1);
				return;
			}
		}

		public void cf9d846fb097cbe1976cbe5bc26d57c0c(bool c42c6a9a524abb82ddacdacef9c8046df)
		{
			if (m_shakeEffect == null)
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
				if (c42c6a9a524abb82ddacdacef9c8046df)
				{
					while (true)
					{
						switch (7)
						{
						case 0:
							break;
						default:
							m_shakeEffect.gotoAndPlay("shake");
							m_shakeEffect.addFrameScript("shakeEnd", c5dba8700db367b5ab513b4ce128d5aeb);
							return;
						}
					}
				}
				m_shakeEffect.gotoAndPlay("normal");
				return;
			}
		}

		protected void c5dba8700db367b5ab513b4ce128d5aeb(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			m_shakeEffect.gotoAndPlay("shake");
		}
	}

	public class BoomOutCombo : c196099a1254db61d3be10d70e14e7422
	{
		protected LargeSkillIconAnimation _largeIcon;

		protected SmallSkillIconAnimation _smallIcon;

		protected DurationBar _durationBar;

		protected bool _bSmallIconVisible;

		[CompilerGenerated]
		private static Dictionary<string, int> _003C_003Ef__switch_0024map1D;

		public bool c887b65c1f71afd083faa23b5a9d45c6b
		{
			set
			{
				_bSmallIconVisible = value;
				if (_smallIcon == null)
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
					MovieClip movieClip = _smallIcon.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
					if (movieClip == null)
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
						movieClip.visible = _bSmallIconVisible;
						return;
					}
				}
			}
		}

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool result = false;
			string name = movieClip.name;
			if (name != null)
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
				if (_003C_003Ef__switch_0024map1D == null)
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
					Dictionary<string, int> dictionary = new Dictionary<string, int>(3);
					dictionary.Add("mcLargeIcon", 0);
					dictionary.Add("mcDurationBar", 1);
					dictionary.Add("mcSmallIcon", 2);
					_003C_003Ef__switch_0024map1D = dictionary;
				}
				int value;
				if (_003C_003Ef__switch_0024map1D.TryGetValue(name, out value))
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
						_largeIcon = new LargeSkillIconAnimation();
						_largeIcon.c130648b59a0c8debea60aa153f844879(movieClip);
						result = true;
						break;
					case 1:
						_durationBar = new DurationBar();
						_durationBar.c130648b59a0c8debea60aa153f844879(movieClip);
						result = true;
						break;
					case 2:
						_smallIcon = new SmallSkillIconAnimation();
						_smallIcon.c130648b59a0c8debea60aa153f844879(movieClip);
						result = true;
						break;
					}
				}
			}
			return result;
		}

		public void c99595b74276138cc095f9087059d16e3(int c05a87f1785349aab1f16f495be4124ec)
		{
			_durationBar.c99595b74276138cc095f9087059d16e3(c05a87f1785349aab1f16f495be4124ec);
		}

		public void c4339a0460981803ffc66837d5c477430(bool c29dfff0138122212b573594dbca512f1, SkillID cec2361c8c6c5b0a36e34e8a479ff74ad)
		{
			if (c29dfff0138122212b573594dbca512f1)
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
						_largeIcon.c8c03a36f3b37a55d9ab8debd92769a44(eCurState.SecondAction, cec2361c8c6c5b0a36e34e8a479ff74ad);
						_smallIcon.c43cbb41bf755dfa61de619fc6e86ab31(false);
						return;
					}
				}
			}
			_largeIcon.c8c03a36f3b37a55d9ab8debd92769a44(eCurState.FirstAction, cec2361c8c6c5b0a36e34e8a479ff74ad);
			_smallIcon.c43cbb41bf755dfa61de619fc6e86ab31(true);
			_smallIcon.c0a322a4be25fd65f73ae57229d5ab62f(eCurState.SecondAction, cec2361c8c6c5b0a36e34e8a479ff74ad);
		}
	}

	public class HunterSkillPanel : c196099a1254db61d3be10d70e14e7422
	{
		protected class BarMask : c196099a1254db61d3be10d70e14e7422
		{
			protected MovieClip _mcMask;

			protected MovieClip _mcSlave;

			protected override void c969016383f47c249932cc75475f00ae1()
			{
				base.c969016383f47c249932cc75475f00ae1();
				_mcMask = base.c89ef242f4744e0f1c4ffea4da8b79bc1.getChildByName<MovieClip>("mcMask");
				_mcSlave = base.c89ef242f4744e0f1c4ffea4da8b79bc1.getChildByName<MovieClip>("mcSlave");
				if (_mcSlave == null)
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
					_mcSlave.removeAllEventListeners(CEvent.ENTER_FRAME);
					_mcSlave.addEventListener(CEvent.ENTER_FRAME, ce24795b8ffc783d8ab818d49d735c682);
					return;
				}
			}

			protected void ce24795b8ffc783d8ab818d49d735c682(CEvent c3d202dee321219a80026dc3081fb3c86)
			{
				if (_mcSlave == null)
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
					if (_mcMask == null)
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
						_mcSlave.clipRect = _mcMask.getBounds(_mcSlave).rect;
						_mcMask.visible = false;
						return;
					}
				}
			}

			public void c99595b74276138cc095f9087059d16e3(float c05a87f1785349aab1f16f495be4124ec)
			{
				if (base.c89ef242f4744e0f1c4ffea4da8b79bc1 == null)
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
					MovieClip movieClip = base.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
					if (movieClip == null)
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
						int num = (int)(c05a87f1785349aab1f16f495be4124ec * 30f);
						movieClip.gotoAndStop(num);
						return;
					}
				}
			}
		}

		protected MovieClip _rootMC;

		protected MovieClip _aniRootMC;

		protected BarMask _processBarLeft = new BarMask();

		protected BarMask _processBarRight = new BarMask();

		protected bool _bOnAnimation;

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			_rootMC = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			if (_rootMC == null)
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
				_aniRootMC = _rootMC.getChildByName<MovieClip>("mcAniRoot");
				if (_aniRootMC == null)
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
					_aniRootMC.addFrameScript("fadeinEnd", c6dfd7b7cfc60ded0e30353da0a9d17b5);
					_aniRootMC.addFrameScript("fadeoutEnd", c90b8f3c7c55511377f8b8d0554b881be);
					_aniRootMC.addFrameScript("appear", c2d4b6616c5d13a240f0d050133a6a00b);
					_aniRootMC.addFrameScript("normal", c2d4b6616c5d13a240f0d050133a6a00b);
					return;
				}
			}
		}

		public void c583e7aff4ddb8435bf4619e4bda9dac8()
		{
			if (_rootMC != null)
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
				_rootMC.visible = true;
			}
			if (_aniRootMC == null)
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
				_aniRootMC.gotoAndPlay(1);
				_bOnAnimation = true;
				return;
			}
		}

		public void c602edc6d49b521b6ad4c9397b537211b()
		{
			if (_rootMC != null)
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
				_rootMC.visible = true;
			}
			if (_aniRootMC == null)
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
				_aniRootMC.gotoAndPlay("fadeout");
				_bOnAnimation = true;
				return;
			}
		}

		protected void c6dfd7b7cfc60ded0e30353da0a9d17b5(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			_bOnAnimation = false;
		}

		protected void c90b8f3c7c55511377f8b8d0554b881be(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			_rootMC.visible = false;
			_bOnAnimation = false;
		}

		protected void c2d4b6616c5d13a240f0d050133a6a00b(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			if (_aniRootMC == null)
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
				MovieClip childByName = _aniRootMC.getChildByName<MovieClip>("mcPowerFrame_Left");
				MovieClip childByName2 = _aniRootMC.getChildByName<MovieClip>("mcPowerFrame_Right");
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
					_processBarLeft.c130648b59a0c8debea60aa153f844879(childByName);
				}
				if (childByName2 == null)
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
					_processBarRight.c130648b59a0c8debea60aa153f844879(childByName2);
					return;
				}
			}
		}

		public void ca3167e3caecd5d1f4a543536d38fe8f7(MarkManager.BroadcastMarkedInfo c178d0974a3625c1550e2fc8c4a9ab46a)
		{
			if (_aniRootMC == null)
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
				if (_bOnAnimation)
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
				float c05a87f1785349aab1f16f495be4124ec = 0f;
				if (c178d0974a3625c1550e2fc8c4a9ab46a != null)
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
					c05a87f1785349aab1f16f495be4124ec = c178d0974a3625c1550e2fc8c4a9ab46a.m_progress_mark;
				}
				_processBarLeft.c99595b74276138cc095f9087059d16e3(c05a87f1785349aab1f16f495be4124ec);
				_processBarRight.c99595b74276138cc095f9087059d16e3(c05a87f1785349aab1f16f495be4124ec);
				return;
			}
		}
	}

	protected SkillRoot m_SkillPanel;

	protected c196099a1254db61d3be10d70e14e7422 _root;

	protected HunterSkillPanel _hunterSkillRoot;

	protected MovieClip _skillStatusRootMC;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("HUD.swf", "Skill", c121b64c17f0fff12d1a1a4236a40c7e7);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("HunterSkill.swf", "Panel_Whole", c4b73bf5206aa0ffb259d8eee6f662f1b);
	}

	private void c121b64c17f0fff12d1a1a4236a40c7e7(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_root = new c196099a1254db61d3be10d70e14e7422();
		_root.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c848674781d88e6f4b9eb89ca2b6f4610(_root);
		ca99d83562046345488d42e3917afb097(SkillTreeDataManager.c71f6ce28731edfd43c976fbd57c57bea().cd2a5c391c1d46ff36a39370815c88946, SkillTreeDataManager.c71f6ce28731edfd43c976fbd57c57bea().c4d24a9cadafffc413bf9c8df83bdec2d);
	}

	private void c4b73bf5206aa0ffb259d8eee6f662f1b(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		cbe9ca8ddb3cdc2312e6ff8411b2db2c8.visible = false;
		_hunterSkillRoot = new HunterSkillPanel();
		_hunterSkillRoot.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c848674781d88e6f4b9eb89ca2b6f4610(_hunterSkillRoot);
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_root);
		_root = c9c0c8f01d2944aa6e09f167c382ebe52.c7088de59e49f7108f520cf7e0bae167e;
		m_SkillPanel = null;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_hunterSkillRoot);
		_hunterSkillRoot = null;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("HUD.swf");
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("HunterSkill.swf");
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		if (_root == null)
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
		base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
		DisplayObjectContainer c89ef242f4744e0f1c4ffea4da8b79bc = _root.c89ef242f4744e0f1c4ffea4da8b79bc1;
		int visible;
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
			visible = ((_iEarnedSkillPt > 0) ? 1 : 0);
		}
		else
		{
			visible = 0;
		}
		c89ef242f4744e0f1c4ffea4da8b79bc.visible = (byte)visible != 0;
	}

	protected override void c06849da5ccfc56f96a6b2185a29653d6(List<InvestedSkill> c2a84e1af1999f8830e06d6fd6cb8ebb9)
	{
		base.c06849da5ccfc56f96a6b2185a29653d6(c2a84e1af1999f8830e06d6fd6cb8ebb9);
		if (m_SkillPanel == null)
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
			m_SkillPanel.cdd6bdb37541f370f33d365ef8857218e(_bSecActionUnlocked);
			return;
		}
	}

	protected override void cb524d3624c5f1725ff22bdc4cc78c3ce()
	{
		base.cb524d3624c5f1725ff22bdc4cc78c3ce();
		if (m_SkillPanel == null)
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
		m_SkillPanel.c1d51e33bf2f5c865e5a00507c3bb2561();
	}

	protected override void c33e0d6a16ca598fe0a5efac6a4501b86()
	{
		base.c33e0d6a16ca598fe0a5efac6a4501b86();
		if (m_SkillPanel != null)
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
			m_SkillPanel.c04198fa437b0e2de3f89bec4259839ac();
		}
		if (_curCharacterSkillID != SkillID.Hunter)
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
			if (_hunterSkillRoot == null)
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
				_hunterSkillRoot.c583e7aff4ddb8435bf4619e4bda9dac8();
				return;
			}
		}
	}

	protected override void c5b87f18653eabd4e44743a6d81126088()
	{
		base.c5b87f18653eabd4e44743a6d81126088();
		if (m_SkillPanel == null)
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
					return;
				}
			}
		}
		m_SkillPanel.c8824c5c1c52bff2a141f509944017ce1();
	}

	protected override void cb6db4663b8a403fb17de5e7062aad56c()
	{
		base.cb6db4663b8a403fb17de5e7062aad56c();
		if (m_SkillPanel == null)
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
		m_SkillPanel.c406aef905d0dafd1f4c223dec53a6130();
	}

	protected override void c17a51851547cf76fd3f481284c811a01()
	{
		base.c17a51851547cf76fd3f481284c811a01();
		if (m_SkillPanel != null)
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
			m_SkillPanel.c6db6e7bbcc22d06ecb4c98646536ecf4();
		}
		if (_curCharacterSkillID != SkillID.Hunter)
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
			if (_hunterSkillRoot == null)
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
				_hunterSkillRoot.c602edc6d49b521b6ad4c9397b537211b();
				return;
			}
		}
	}

	protected override void ccb413e2cca8f18b5041ee18ab96e729e()
	{
		base.ccb413e2cca8f18b5041ee18ab96e729e();
		if (m_SkillPanel == null)
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
		m_SkillPanel.cdb85fb3ed6aa9ab4e56c7df9b2224044();
	}

	protected override void cb7f9721277f1652ea629c68bc6538c74()
	{
		base.cb7f9721277f1652ea629c68bc6538c74();
		if (m_SkillPanel == null)
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
					return;
				}
			}
		}
		m_SkillPanel.ce85db71804aa56e2fd9331211692bf94();
	}

	public override void Update(SkillInfo CurSkillInfo)
	{
		base.Update(CurSkillInfo);
		if (!_bInitialised)
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
			if (m_SkillPanel != null)
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
				m_SkillPanel.c48dc9de69f206a4a07b8c9785fe4114c = CurSkillInfo.m_current_skillID;
				m_SkillPanel.c1d51e33bf2f5c865e5a00507c3bb2561();
				_bInitialised = true;
			}
		}
		if (m_SkillPanel != null)
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
			m_SkillPanel.c48dc9de69f206a4a07b8c9785fe4114c = CurSkillInfo.m_current_skillID;
			m_SkillPanel.c52fe0be0bbca52c9b3c54236cd434f4a = _curState;
			if (_curState == eCurState.Cooldown)
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
				m_SkillPanel.c67e98f116f5984230addc26c6a854794 = CurSkillInfo.m_cooldownProgress;
			}
			else
			{
				m_SkillPanel.c67e98f116f5984230addc26c6a854794 = CurSkillInfo.m_skillProgress;
			}
		}
		if (_curCharacterSkillID != SkillID.Hunter)
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
			if (_hunterSkillRoot == null)
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
				_hunterSkillRoot.ca3167e3caecd5d1f4a543536d38fe8f7(_hunterMarkInfo);
				return;
			}
		}
	}

	public override void ca99d83562046345488d42e3917afb097(int c8939189c1c9b16ae9037abd7790c7dba, int c87d6075ee471733370e7bb9406d2a685)
	{
		base.ca99d83562046345488d42e3917afb097(c8939189c1c9b16ae9037abd7790c7dba, c87d6075ee471733370e7bb9406d2a685);
		if (_root == null)
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
		MovieClip movieClip = _root.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
		bool visible = _iEarnedSkillPt != 0;
		movieClip.visible = visible;
		if (c8939189c1c9b16ae9037abd7790c7dba > 0)
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
			if (c8939189c1c9b16ae9037abd7790c7dba == c87d6075ee471733370e7bb9406d2a685)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
					{
						movieClip.gotoAndStop("SkillPtEarned");
						MovieClip childByName = movieClip.getChildByName<MovieClip>("mcSkillPtAvailableIcon");
						if (childByName != null)
						{
							while (true)
							{
								switch (4)
								{
								case 0:
									break;
								default:
								{
									UnityTextField unityTextField = (UnityTextField)childByName.getChildByName<TextField>("SkillPoint");
									if (unityTextField != null)
									{
										while (true)
										{
											switch (5)
											{
											case 0:
												break;
											default:
											{
												string text = c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e;
												if (c87d6075ee471733370e7bb9406d2a685 > 0)
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
													text = c87d6075ee471733370e7bb9406d2a685.ToString();
												}
												unityTextField.text = text;
												return;
											}
											}
										}
									}
									return;
								}
								}
							}
						}
						return;
					}
					}
				}
			}
		}
		movieClip.gotoAndStop("SkillAvailable");
		if (m_SkillPanel == null)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					_skillStatusRootMC = movieClip.getChildByName<MovieClip>("mcSkill");
					if (_skillStatusRootMC != null)
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								_skillStatusRootMC.visible = true;
								m_SkillPanel = new SkillRoot();
								m_SkillPanel.c130648b59a0c8debea60aa153f844879(_skillStatusRootMC);
								m_SkillPanel.c1d51e33bf2f5c865e5a00507c3bb2561();
								m_SkillPanel.cdd6bdb37541f370f33d365ef8857218e(_bSecActionUnlocked);
								m_SkillPanel.ca99d83562046345488d42e3917afb097(c8939189c1c9b16ae9037abd7790c7dba, c87d6075ee471733370e7bb9406d2a685);
								return;
							}
						}
					}
					return;
				}
			}
		}
		m_SkillPanel.ca99d83562046345488d42e3917afb097(c8939189c1c9b16ae9037abd7790c7dba, c87d6075ee471733370e7bb9406d2a685);
	}
}
