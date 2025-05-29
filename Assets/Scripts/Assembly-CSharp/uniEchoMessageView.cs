using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using Core;
using UnityEngine;
using XsdSettings;
using pumpkin.display;
using pumpkin.events;

public class uniEchoMessageView : EchoMessageView
{
	protected class EchoMsgHandlerDashBorad : c196099a1254db61d3be10d70e14e7422, c59dffb97d0323f1c7e2cf13f91eec1ce
	{
		protected float DISPLAY_TIME = 5f;

		public virtual void cba86f338d46d74a8d7beba9c6f0a3fa5(EchoMessage c709b291ceac9f97f0c78f269054fa014)
		{
		}

		public virtual void Update()
		{
		}

		public virtual void c138a9bf6f68646f1b362f208658268f1(float c97bcd44f562f0e86731bf6c2530b8962)
		{
			if (c97bcd44f562f0e86731bf6c2530b8962 > 0f)
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
						DISPLAY_TIME = c97bcd44f562f0e86731bf6c2530b8962;
						return;
					}
				}
			}
			DISPLAY_TIME = 5f;
		}
	}

	protected class CountdownHandler : EchoMsgHandlerDashBorad
	{
		protected const string START_FRAME = "fadein";

		protected const string END_FRAME = "fadeout";

		protected const string LAST_FRAME = "AnimationEnd";

		protected MovieClip mcSelf;

		protected MovieClip mcRoot;

		protected UnityTextField textField;

		protected double m_totalTimer;

		[CompilerGenerated]
		private static Dictionary<string, int> _003C_003Ef__switch_0024map10;

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			mcSelf = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			mcSelf.gotoAndStop("fadein");
		}

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool result = false;
			string name = movieClip.name;
			if (name != null)
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
				if (_003C_003Ef__switch_0024map10 == null)
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
					Dictionary<string, int> dictionary = new Dictionary<string, int>(1);
					dictionary.Add("mcRoot", 0);
					_003C_003Ef__switch_0024map10 = dictionary;
				}
				int value;
				if (_003C_003Ef__switch_0024map10.TryGetValue(name, out value))
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
						mcRoot = movieClip;
						textField = mcRoot.getChildByName<UnityTextField>("textField");
						result = false;
					}
				}
			}
			return result;
		}

		public override void cba86f338d46d74a8d7beba9c6f0a3fa5(EchoMessage c709b291ceac9f97f0c78f269054fa014)
		{
			try
			{
				m_totalTimer = double.Parse(c709b291ceac9f97f0c78f269054fa014.m_localizedText);
			}
			catch (Exception ex)
			{
				DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Gamelogic, ex.ToString());
			}
			mcSelf.gotoAndPlay("fadein");
			mcSelf.visible = true;
			c23ffb495db7c9da62404f1cc24a67351();
		}

		private void c23ffb495db7c9da62404f1cc24a67351()
		{
			textField.text = Math.Ceiling(m_totalTimer).ToString();
		}

		private void cce6adadf40a70610ce3ae5dd40479620()
		{
			mcSelf.addFrameScript("AnimationEnd", cd35969f5f2ec82c5e6ec079c9eade914);
			mcSelf.gotoAndPlay("fadeout");
		}

		protected void cd35969f5f2ec82c5e6ec079c9eade914(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			mcSelf.removeFrameScript("AnimationEnd", cd35969f5f2ec82c5e6ec079c9eade914);
			mcSelf.visible = false;
		}

		public override void Update()
		{
			if (!(m_totalTimer > 0.0))
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
				m_totalTimer -= Time.deltaTime;
				if (m_totalTimer <= 0.0)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							m_totalTimer = 0.0;
							cce6adadf40a70610ce3ae5dd40479620();
							return;
						}
					}
				}
				c23ffb495db7c9da62404f1cc24a67351();
				return;
			}
		}
	}

	protected class EchoSingleTextPanel : EchoMsgHandlerDashBorad
	{
		protected const string START_FRAME = "fadein";

		protected const string END_FRAME = "fadeout";

		protected const string LAST_FRAME = "AnimationEnd";

		protected const string NORMAL_FRAME = "normal";

		protected MovieClip mcSelf;

		protected MovieClip mcRoot;

		protected UnityTextField textField;

		[CompilerGenerated]
		private static Dictionary<string, int> _003C_003Ef__switch_0024map11;

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			mcSelf = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			mcSelf.gotoAndStop("AnimationEnd");
		}

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool result = false;
			string name = movieClip.name;
			if (name != null)
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
				if (_003C_003Ef__switch_0024map11 == null)
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
					dictionary.Add("mcRoot", 0);
					_003C_003Ef__switch_0024map11 = dictionary;
				}
				int value;
				if (_003C_003Ef__switch_0024map11.TryGetValue(name, out value))
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
					if (value != 0)
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
					}
					else
					{
						mcRoot = movieClip;
						textField = mcRoot.getChildByName<UnityTextField>("textField");
						result = false;
					}
				}
			}
			return result;
		}

		public void c23ffb495db7c9da62404f1cc24a67351(string ca04b8fe5d43144ba3361431c00741486)
		{
			mcSelf.gotoAndPlay("fadein");
			textField.text = ca04b8fe5d43144ba3361431c00741486;
		}

		public void cce6adadf40a70610ce3ae5dd40479620()
		{
			mcSelf.gotoAndPlay("fadeout");
		}
	}

	protected class LoopingSingleLineTextPanel : EchoMsgHandlerDashBorad
	{
		protected const string START_FRAME = "start";

		protected const string END_FRAME = "end";

		protected MovieClip mcSelf;

		protected MovieClip mcRoot;

		protected MovieClip mcMask;

		protected UnityTextField textField;

		[CompilerGenerated]
		private static Dictionary<string, int> _003C_003Ef__switch_0024map12;

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			mcSelf = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			mcSelf.gotoAndStop("start");
			mcSelf.addEventListener(CEvent.ENTER_FRAME, cc5ccfb07a7c9032fc2093f57c4502371);
		}

		protected void cc5ccfb07a7c9032fc2093f57c4502371(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			if (mcMask == null)
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
				mcRoot.clipRect = mcMask.getBounds(mcRoot).rect;
				return;
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
				if (_003C_003Ef__switch_0024map12 == null)
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
					Dictionary<string, int> dictionary = new Dictionary<string, int>(2);
					dictionary.Add("mcRoot", 0);
					dictionary.Add("mcMask", 1);
					_003C_003Ef__switch_0024map12 = dictionary;
				}
				int value;
				if (_003C_003Ef__switch_0024map12.TryGetValue(name, out value))
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
						if (value != 1)
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
							mcMask = movieClip;
							if (mcRoot != null)
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
								mcRoot.clipRect = mcMask.getBounds(mcRoot).rect;
							}
							result = false;
						}
					}
					else
					{
						mcRoot = movieClip;
						textField = mcRoot.getChildByName<UnityTextField>("textField");
						if (mcMask != null)
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
							mcRoot.clipRect = mcMask.getBounds(mcRoot).rect;
						}
						result = false;
					}
				}
			}
			return result;
		}

		public void c23ffb495db7c9da62404f1cc24a67351(string ca04b8fe5d43144ba3361431c00741486)
		{
			mcSelf.gotoAndPlay("start");
			textField.text = ca04b8fe5d43144ba3361431c00741486;
		}

		public void cce6adadf40a70610ce3ae5dd40479620()
		{
			mcSelf.gotoAndStop("end");
		}
	}

	protected class EventEchoHandler : LoopingSingleLineTextPanel
	{
		protected class EventMsg
		{
			public EchoMessage message;

			public int _loopingTime;
		}

		protected const int DEFAULT_LOOP_TIMES = 3;

		protected List<EventMsg> _arrEventList = new List<EventMsg>();

		protected int _currentIndex = -1;

		public override void cba86f338d46d74a8d7beba9c6f0a3fa5(EchoMessage c709b291ceac9f97f0c78f269054fa014)
		{
			EventMsg eventMsg = new EventMsg();
			eventMsg.message = c709b291ceac9f97f0c78f269054fa014;
			eventMsg._loopingTime = 3;
			EventMsg item = eventMsg;
			_arrEventList.Add(item);
			if (_currentIndex >= 0)
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
				_currentIndex = 0;
				c05d0945cab1b30268a0161566d525bac();
				return;
			}
		}

		public void c05d0945cab1b30268a0161566d525bac()
		{
			if (_arrEventList[_currentIndex]._loopingTime <= 0)
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
				_arrEventList.RemoveAt(_currentIndex--);
			}
			if (_arrEventList.Count > 0)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						_currentIndex = (_currentIndex + 1) % _arrEventList.Count;
						_arrEventList[_currentIndex]._loopingTime--;
						c23ffb495db7c9da62404f1cc24a67351(_arrEventList[_currentIndex].message.m_localizedText);
						return;
					}
				}
			}
			cce6adadf40a70610ce3ae5dd40479620();
			_currentIndex = -1;
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			mcSelf.addFrameScript("end", c7b841ee249585075a7282f595b88b38d);
		}

		protected void c7b841ee249585075a7282f595b88b38d(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			c05d0945cab1b30268a0161566d525bac();
		}
	}

	protected class BroadcastHandler : EchoMsgHandlerDashBorad
	{
		protected class BroadcastMsg
		{
			public EchoMessage message;

			public float lifeTimeLeft;

			public bool bFirst;
		}

		protected const int NUM_TOTAL_MSG = 3;

		protected Queue<BroadcastMsg> _queEventList = new Queue<BroadcastMsg>(3);

		protected List<EchoSingleTextPanel> _arrSingleTextPanel = new List<EchoSingleTextPanel>(3);

		[CompilerGenerated]
		private static Dictionary<string, int> _003C_003Ef__switch_0024map13;

		public BroadcastHandler()
		{
			DISPLAY_TIME = 5f;
			BroadcastMsg item = new BroadcastMsg
			{
				lifeTimeLeft = -1f
			};
			int num = 0;
			while (num++ < 3)
			{
				_arrSingleTextPanel.Add(null);
				_queEventList.Enqueue(item);
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
				return;
			}
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
		}

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool result = false;
			string name = movieClip.name;
			if (name != null)
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
				if (_003C_003Ef__switch_0024map13 == null)
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
					Dictionary<string, int> dictionary = new Dictionary<string, int>(4);
					dictionary.Add("mcItem0", 0);
					dictionary.Add("mcItem1", 1);
					dictionary.Add("mcItem2", 2);
					dictionary.Add("mcItem3", 3);
					_003C_003Ef__switch_0024map13 = dictionary;
				}
				int value;
				if (_003C_003Ef__switch_0024map13.TryGetValue(name, out value))
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
					switch (value)
					{
					case 0:
					{
						EchoSingleTextPanel echoSingleTextPanel3 = new EchoSingleTextPanel();
						echoSingleTextPanel3.c130648b59a0c8debea60aa153f844879(movieClip);
						_arrSingleTextPanel[0] = echoSingleTextPanel3;
						result = true;
						break;
					}
					case 1:
					{
						EchoSingleTextPanel echoSingleTextPanel2 = new EchoSingleTextPanel();
						echoSingleTextPanel2.c130648b59a0c8debea60aa153f844879(movieClip);
						_arrSingleTextPanel[1] = echoSingleTextPanel2;
						result = true;
						break;
					}
					case 2:
					{
						EchoSingleTextPanel echoSingleTextPanel = new EchoSingleTextPanel();
						echoSingleTextPanel.c130648b59a0c8debea60aa153f844879(movieClip);
						_arrSingleTextPanel[2] = echoSingleTextPanel;
						result = true;
						break;
					}
					case 3:
						movieClip.visible = false;
						result = true;
						break;
					}
				}
			}
			return result;
		}

		public override void cba86f338d46d74a8d7beba9c6f0a3fa5(EchoMessage c709b291ceac9f97f0c78f269054fa014)
		{
			using (Queue<BroadcastMsg>.Enumerator enumerator = _queEventList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					BroadcastMsg current = enumerator.Current;
					current.bFirst = true;
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
					break;
				}
			}
			_queEventList.Dequeue();
			BroadcastMsg broadcastMsg = new BroadcastMsg();
			broadcastMsg.message = c709b291ceac9f97f0c78f269054fa014;
			broadcastMsg.lifeTimeLeft = DISPLAY_TIME;
			broadcastMsg.bFirst = true;
			BroadcastMsg item = broadcastMsg;
			_queEventList.Enqueue(item);
		}

		public override void Update()
		{
			int num = 0;
			Queue<BroadcastMsg>.Enumerator enumerator = _queEventList.GetEnumerator();
			while (enumerator.MoveNext())
			{
				BroadcastMsg current = enumerator.Current;
				if (current.lifeTimeLeft > 0f)
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
					current.lifeTimeLeft -= Time.deltaTime;
					if (current.lifeTimeLeft < 0f)
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
						_arrSingleTextPanel[num].cce6adadf40a70610ce3ae5dd40479620();
					}
					else if (current.bFirst)
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
						current.bFirst = false;
						_arrSingleTextPanel[num].c23ffb495db7c9da62404f1cc24a67351(current.message.m_localizedText);
					}
				}
				num++;
			}
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
	}

	protected class DialogEchoHandler : EchoSingleTextPanel
	{
		protected EchoMessage _curMessage;

		protected float _fTimter;

		public DialogEchoHandler()
		{
			DISPLAY_TIME = 5f;
		}

		public override void cba86f338d46d74a8d7beba9c6f0a3fa5(EchoMessage c709b291ceac9f97f0c78f269054fa014)
		{
			_fTimter = DISPLAY_TIME;
			_curMessage = c709b291ceac9f97f0c78f269054fa014;
			c23ffb495db7c9da62404f1cc24a67351(_curMessage.m_localizedText);
		}

		public override void Update()
		{
			if (!(_fTimter > 0f))
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
				_fTimter -= Time.deltaTime;
				if (!(_fTimter < 0f))
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
					cce6adadf40a70610ce3ae5dd40479620();
					return;
				}
			}
		}
	}

	protected class LevelNotificationHandler : EchoSingleTextPanel
	{
		protected float _fDisplayTime;

		protected Queue<EchoMessage> _queEventList = new Queue<EchoMessage>();

		public LevelNotificationHandler()
		{
			DISPLAY_TIME = 5f;
		}

		public override void cba86f338d46d74a8d7beba9c6f0a3fa5(EchoMessage c709b291ceac9f97f0c78f269054fa014)
		{
			bool flag = _queEventList.Count == 0;
			_queEventList.Enqueue(c709b291ceac9f97f0c78f269054fa014);
			if (!flag)
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
				c730842a7bb48fe7d0c0584c2470c67ad();
				return;
			}
		}

		public override void Update()
		{
			if (!(_fDisplayTime > 0f))
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
				_fDisplayTime -= Time.deltaTime;
				if (!(_fDisplayTime < 0f))
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
					_queEventList.Dequeue();
					if (_queEventList.Count > 0)
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								break;
							default:
								c730842a7bb48fe7d0c0584c2470c67ad();
								return;
							}
						}
					}
					cce6adadf40a70610ce3ae5dd40479620();
					return;
				}
			}
		}

		protected void c730842a7bb48fe7d0c0584c2470c67ad()
		{
			_fDisplayTime = DISPLAY_TIME;
			EchoMessage echoMessage = _queEventList.Peek();
			c23ffb495db7c9da62404f1cc24a67351(echoMessage.m_localizedText);
		}
	}

	protected class NPCPortraitHandler : EchoMsgHandlerDashBorad
	{
		protected const string START_FRAME = "in";

		protected const string END_FRAME = "out";

		protected const string LAST_FRAME = "end";

		protected const string NPC_FRAME_NAME = "NPC_";

		protected MovieClip mcSelf;

		protected MovieClip mcRoot;

		protected MovieClip mcNPCPortrait;

		protected MovieClip mcMaskedBg;

		protected EchoMessage _curMessage;

		protected float _fTimter;

		protected string _npcName = string.Empty;

		[CompilerGenerated]
		private static Dictionary<string, int> _003C_003Ef__switch_0024map14;

		public NPCPortraitHandler()
		{
			DISPLAY_TIME = 5f;
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			mcSelf = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			mcSelf.gotoAndStop("in");
		}

		public override void cba86f338d46d74a8d7beba9c6f0a3fa5(EchoMessage c709b291ceac9f97f0c78f269054fa014)
		{
			_fTimter = DISPLAY_TIME;
			_curMessage = c709b291ceac9f97f0c78f269054fa014;
			c23ffb495db7c9da62404f1cc24a67351(_curMessage.m_npcIcon);
		}

		public override void Update()
		{
			if (!(_fTimter > 0f))
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
				_fTimter -= Time.deltaTime;
				if (!(_fTimter < 0f))
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
					cce6adadf40a70610ce3ae5dd40479620();
					return;
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
				if (_003C_003Ef__switch_0024map14 == null)
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
					Dictionary<string, int> dictionary = new Dictionary<string, int>(3);
					dictionary.Add("mcRoot", 0);
					dictionary.Add("mcNPC", 1);
					dictionary.Add("mcMaskedBg", 2);
					_003C_003Ef__switch_0024map14 = dictionary;
				}
				int value;
				if (_003C_003Ef__switch_0024map14.TryGetValue(name, out value))
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
					switch (value)
					{
					case 0:
						mcRoot = movieClip;
						break;
					case 1:
						mcNPCPortrait = movieClip;
						mcNPCPortrait.gotoAndStop("NPC_" + _npcName);
						result = true;
						break;
					case 2:
					{
						mcMaskedBg = movieClip;
						MovieClip childByName = mcMaskedBg.getChildByName<MovieClip>("mcMask");
						mcMaskedBg.addEventListener(CEvent.ENTER_FRAME, cc5ccfb07a7c9032fc2093f57c4502371);
						mcMaskedBg.clipRect = childByName.getBounds(mcMaskedBg).rect;
						result = true;
						break;
					}
					}
				}
			}
			return result;
		}

		protected void cc5ccfb07a7c9032fc2093f57c4502371(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			MovieClip childByName = mcMaskedBg.getChildByName<MovieClip>("mcMask");
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
				mcMaskedBg.clipRect = childByName.getBounds(mcMaskedBg).rect;
				return;
			}
		}

		protected void c23ffb495db7c9da62404f1cc24a67351(string c8b480b269dc59bb22f355a3b15e7e04f)
		{
			if (!(c8b480b269dc59bb22f355a3b15e7e04f != _npcName))
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
				_npcName = c8b480b269dc59bb22f355a3b15e7e04f;
				mcSelf.visible = true;
				mcSelf.gotoAndPlay("in");
				if (mcNPCPortrait != null)
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
					mcNPCPortrait.gotoAndStop("NPC_" + _npcName);
				}
				if (mcMaskedBg == null)
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
					mcMaskedBg.play();
					return;
				}
			}
		}

		protected void cce6adadf40a70610ce3ae5dd40479620()
		{
			_npcName = string.Empty;
			mcSelf.addFrameScript("end", cd35969f5f2ec82c5e6ec079c9eade914);
			mcSelf.gotoAndPlay("out");
		}

		protected void cd35969f5f2ec82c5e6ec079c9eade914(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			mcSelf.removeFrameScript("end", cd35969f5f2ec82c5e6ec079c9eade914);
			mcSelf.visible = false;
		}
	}

	private c196099a1254db61d3be10d70e14e7422 _rootPanel;

	private List<EchoMsgHandlerDashBorad> _arrEchoMsgHandler = new List<EchoMsgHandlerDashBorad>();

	[CompilerGenerated]
	private static Dictionary<string, int> _003C_003Ef__switch_0024mapF;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		_arrEchoMsgHandler.Clear();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("Echo.swf", "RootEchoPanel", c1141a8fde9aa0f410bc4a7fdd2e3ef7c);
	}

	private void c1141a8fde9aa0f410bc4a7fdd2e3ef7c(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_rootPanel = new c196099a1254db61d3be10d70e14e7422();
		_rootPanel.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8, OnWidgetInitialized);
		cbe9ca8ddb3cdc2312e6ff8411b2db2c8.mouseEnabled = false;
		float num = c06ca0e618478c23eba3419653a19760f<GameSettingMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c93a361c45829617f798f69b2d0c74a59(SettingFunctionType.EchoDuration);
		float num2;
		if (num > 0f)
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
			num2 = num;
		}
		else
		{
			num2 = EchoMessageView.DEFAUL_DURATION;
		}
		num = num2;
		c138a9bf6f68646f1b362f208658268f1(num);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c120a0ab44e69ef682f36041c0b116750(_rootPanel);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c310b2d257bd8a8197ae0e4f146fb8c8b();
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_rootPanel);
		_rootPanel = c9c0c8f01d2944aa6e09f167c382ebe52.c7088de59e49f7108f520cf7e0bae167e;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("Echo.swf");
	}

	public override void c138a9bf6f68646f1b362f208658268f1(float c97bcd44f562f0e86731bf6c2530b8962)
	{
		base.c138a9bf6f68646f1b362f208658268f1(c97bcd44f562f0e86731bf6c2530b8962);
		using (List<EchoMsgHandlerDashBorad>.Enumerator enumerator = _arrEchoMsgHandler.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				EchoMsgHandlerDashBorad current = enumerator.Current;
				current.c138a9bf6f68646f1b362f208658268f1(c97bcd44f562f0e86731bf6c2530b8962);
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
				return;
			}
		}
	}

	protected bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
	{
		bool result = false;
		string name = movieClip.name;
		if (name != null)
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
			if (_003C_003Ef__switch_0024mapF == null)
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
				Dictionary<string, int> dictionary = new Dictionary<string, int>(6);
				dictionary.Add("mcEventPanel", 0);
				dictionary.Add("mcBroadcastPanel", 1);
				dictionary.Add("mcLevelNotifPanel", 2);
				dictionary.Add("mcDialogPanel", 3);
				dictionary.Add("mcNPCPortrait", 4);
				dictionary.Add("mcCountdownPanel", 5);
				_003C_003Ef__switch_0024mapF = dictionary;
			}
			int value;
			if (_003C_003Ef__switch_0024mapF.TryGetValue(name, out value))
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
				switch (value)
				{
				case 0:
				{
					EventEchoHandler eventEchoHandler = new EventEchoHandler();
					eventEchoHandler.c130648b59a0c8debea60aa153f844879(movieClip);
					c06ca0e618478c23eba3419653a19760f<ca3a00e0940eecb5ec7ffca2967d5423a>.c5ee19dc8d4cccf5ae2de225410458b86.c668f19c1f6a9b228c2058ac3956d5a3e(DisplayTarget.Event, eventEchoHandler);
					_arrEchoMsgHandler.Add(eventEchoHandler);
					result = true;
					break;
				}
				case 1:
				{
					BroadcastHandler broadcastHandler = new BroadcastHandler();
					broadcastHandler.c130648b59a0c8debea60aa153f844879(movieClip);
					c06ca0e618478c23eba3419653a19760f<ca3a00e0940eecb5ec7ffca2967d5423a>.c5ee19dc8d4cccf5ae2de225410458b86.c668f19c1f6a9b228c2058ac3956d5a3e(DisplayTarget.Broadcast, broadcastHandler);
					_arrEchoMsgHandler.Add(broadcastHandler);
					result = true;
					break;
				}
				case 2:
				{
					LevelNotificationHandler levelNotificationHandler2 = new LevelNotificationHandler();
					levelNotificationHandler2.c130648b59a0c8debea60aa153f844879(movieClip);
					c06ca0e618478c23eba3419653a19760f<ca3a00e0940eecb5ec7ffca2967d5423a>.c5ee19dc8d4cccf5ae2de225410458b86.c668f19c1f6a9b228c2058ac3956d5a3e(DisplayTarget.LevelNotification, levelNotificationHandler2);
					_arrEchoMsgHandler.Add(levelNotificationHandler2);
					result = true;
					break;
				}
				case 3:
				{
					LevelNotificationHandler levelNotificationHandler = new LevelNotificationHandler();
					levelNotificationHandler.c138a9bf6f68646f1b362f208658268f1(3f);
					levelNotificationHandler.c130648b59a0c8debea60aa153f844879(movieClip);
					c06ca0e618478c23eba3419653a19760f<ca3a00e0940eecb5ec7ffca2967d5423a>.c5ee19dc8d4cccf5ae2de225410458b86.c668f19c1f6a9b228c2058ac3956d5a3e(DisplayTarget.Dialog, levelNotificationHandler);
					_arrEchoMsgHandler.Add(levelNotificationHandler);
					result = true;
					break;
				}
				case 4:
				{
					NPCPortraitHandler nPCPortraitHandler = new NPCPortraitHandler();
					nPCPortraitHandler.c130648b59a0c8debea60aa153f844879(movieClip);
					movieClip.stopAll();
					c06ca0e618478c23eba3419653a19760f<ca3a00e0940eecb5ec7ffca2967d5423a>.c5ee19dc8d4cccf5ae2de225410458b86.c668f19c1f6a9b228c2058ac3956d5a3e(DisplayTarget.Dialog, nPCPortraitHandler);
					c06ca0e618478c23eba3419653a19760f<ca3a00e0940eecb5ec7ffca2967d5423a>.c5ee19dc8d4cccf5ae2de225410458b86.c668f19c1f6a9b228c2058ac3956d5a3e(DisplayTarget.Broadcast, nPCPortraitHandler);
					movieClip.visible = false;
					_arrEchoMsgHandler.Add(nPCPortraitHandler);
					result = true;
					break;
				}
				case 5:
				{
					CountdownHandler countdownHandler = new CountdownHandler();
					countdownHandler.c130648b59a0c8debea60aa153f844879(movieClip);
					movieClip.stopAll();
					c06ca0e618478c23eba3419653a19760f<ca3a00e0940eecb5ec7ffca2967d5423a>.c5ee19dc8d4cccf5ae2de225410458b86.c668f19c1f6a9b228c2058ac3956d5a3e(DisplayTarget.Countdown, countdownHandler);
					movieClip.visible = false;
					_arrEchoMsgHandler.Add(countdownHandler);
					result = true;
					break;
				}
				}
			}
		}
		return result;
	}
}
