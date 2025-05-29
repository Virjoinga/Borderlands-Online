using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using Core;
using XsdSettings;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

public class uniClassSelectView : ClassSelectView
{
	private class IntroPanel : c196099a1254db61d3be10d70e14e7422
	{
		private const string CHECK_FRAME_PRENAME = "checkPoint_";

		private const string FRAME_LABEL_START = "jdFadein";

		private const string FRAME_LABEL_END = "jafadeout";

		private const string FRAME_LABEL_NORMAL = "jdNormal";

		private const string CLASS_NAME_PREFIX = "CLASS_";

		private const string CLASS_DES_PREFIX = "CLASS_DESC_";

		private MovieClip mcContent;

		private MovieClip mcSelf;

		private AvatarType _ClassID = AvatarType.TOTAL;

		public void c4398b6346dc91dc3750ab5a14e5935dd(AvatarType ce7ebdda72d3a53b6c018dba545518e8c)
		{
			_ClassID = ce7ebdda72d3a53b6c018dba545518e8c;
			cc4285acec701717f9b767c346d1d70ee();
		}

		public void c79eb2fc29b57101e0937546b9a5e1fe7()
		{
			mcSelf.gotoAndPlay("jdFadein");
		}

		public void cc75696f04d6b93dcc80ae4a7d0c65ef0()
		{
			mcSelf.gotoAndPlay("jafadeout");
		}

		public void c1b4321addfcd17a6390661b7654a6659()
		{
			mcSelf.gotoAndStop("jdNormal");
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			mcSelf = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			if (mcSelf == null)
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
			for (int i = 1; i < 4; i++)
			{
				mcSelf.addFrameScript("checkPoint_" + i, ca8a8742ba129e261bd150150479d90f6);
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				c2ec550882a9732613397e87de7a0f682();
				return;
			}
		}

		protected virtual void ca8a8742ba129e261bd150150479d90f6(CEvent cd729d94a5b443ac0f1b117450e5f4419)
		{
			c2ec550882a9732613397e87de7a0f682();
			cc4285acec701717f9b767c346d1d70ee();
		}

		private void c2ec550882a9732613397e87de7a0f682()
		{
			mcContent = mcSelf.getChildByName("mcContent") as MovieClip;
		}

		private void cc4285acec701717f9b767c346d1d70ee()
		{
			if (mcContent == null)
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
				UnityTextField unityTextField = (UnityTextField)mcContent.getChildByName<TextField>("textClassName");
				if (unityTextField != null)
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
					unityTextField.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("CLASS_" + _ClassID));
				}
				UnityTextField unityTextField2 = (UnityTextField)mcContent.getChildByName<TextField>("textClassDes");
				if (unityTextField2 == null)
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
					unityTextField2.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("CLASS_DESC_" + _ClassID));
					return;
				}
			}
		}

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			return true;
		}
	}

	private class ClassPanel : ExpandPanel
	{
		private const string START_FRAME_LABEL = "frameFadeIN";

		private AvatarType[] _arrAvatarTypeList;

		private c6425d3761c85e65e3530cc19d085d446[] _arrRadioBtn;

		public ClassChangeEvent classChangeCB;

		public ClassChangeEvent descChangeCB;

		public ClassPanel()
		{
			_arrRadioBtn = c67757306f9d6b6a8778a67ebe6597c57.c0a0cdf4a196914163f7334d9b0781a04(4);
			_arrAvatarTypeList = ca16b084112ef26a4bd93564281f7e0c0.c0a0cdf4a196914163f7334d9b0781a04(4);
			_arrAvatarTypeList[0] = AvatarType.BERSERKER;
			_arrAvatarTypeList[1] = AvatarType.SIREN;
			_arrAvatarTypeList[2] = AvatarType.SOLDIER;
			_arrAvatarTypeList[3] = AvatarType.HUNTER;
			c3fb55599d4047226010e75d667d65f43("maskMC", "mcClassBtn");
		}

		public void ca767eddc3ed421758e150f927ef620f9()
		{
			mcSelf.gotoAndPlay("frameFadeIN");
		}

		public void cc7fa43e9bd8fd461250ccf66a4c85f47(AvatarType cf5ba148a098c23b65a37f8a31abed165)
		{
			int num = 0;
			int num2 = 0;
			while (true)
			{
				if (num2 < _arrAvatarTypeList.Length)
				{
					if (_arrAvatarTypeList[num2] == cf5ba148a098c23b65a37f8a31abed165)
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
						num = num2;
						break;
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
			if (_arrRadioBtn[num] == null)
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
				_arrRadioBtn[num].c9c364a8fd1f013589fea518a3924e711 = true;
				return;
			}
		}

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool result = false;
			if (movieClip.name.Length > "element".Length)
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
				string text = movieClip.name.Substring(0, "element".Length);
				if (text == "element")
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
					int num = Convert.ToInt32(movieClip.name.Substring("element".Length, 1));
					MovieClip c7088de59e49f7108f520cf7e0bae167e = c656b7be10c614ae4a7eb17c462d2f675.c7088de59e49f7108f520cf7e0bae167e;
					_arrRadioBtn[num] = null;
					c7088de59e49f7108f520cf7e0bae167e = movieClip.getChildByName<MovieClip>("mcClassBtn");
					if (c7088de59e49f7108f520cf7e0bae167e != null)
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
						_arrRadioBtn[num] = new c6425d3761c85e65e3530cc19d085d446();
						_arrRadioBtn[num].c130648b59a0c8debea60aa153f844879(c7088de59e49f7108f520cf7e0bae167e);
						_arrRadioBtn[num].addEventListener(c649b5d45cf350f685c56c4bd02800198.c7f4ba2ffb076e0e5be86154a13705fe9, ce6339c56d641da0fbe7f6951a1fd295a);
						_arrRadioBtn[num].addEventListener(cab2f86763d523d403495740f472b326b.cdad50184a105a463ca658bfde4f535d3, c9938ce8631685f55e4372c421fd1a56f);
						_arrRadioBtn[num].ce84b930a12a1d06512c79320b3f0d3f4 = false;
						_arrRadioBtn[num].cec024da8c099380cfe1334bfe4c8f30f = "classSelectView";
						_arrRadioBtn[num].c591d56a94543e3559945c497f37126c4 = num;
						_arrRadioBtn[num].c9c364a8fd1f013589fea518a3924e711 = num == 0;
						_arrRadioBtn[num].cbf402c82d0fffee7c8f37c98e456b8f8 = num < 4;
						MovieClip childByName = c7088de59e49f7108f520cf7e0bae167e.getChildByName<MovieClip>("mcIcon");
						MovieClip childByName2 = c7088de59e49f7108f520cf7e0bae167e.getChildByName<MovieClip>("mcBigIcon");
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
							childByName.gotoAndStop(_arrAvatarTypeList[num].ToString());
						}
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
							childByName2.mouseEnabled = false;
							childByName2.gotoAndStop(_arrAvatarTypeList[num].ToString());
						}
					}
					result = true;
				}
			}
			return result;
		}

		protected void cb8cc2ee81b097ca42e6b4697ef8c2dc0(CEvent c05f6b47f5e84359168dfe9aaf57b8a79)
		{
			int num = 0;
			while (true)
			{
				if (num < _arrRadioBtn.Length)
				{
					if (_arrRadioBtn[num].c9c364a8fd1f013589fea518a3924e711)
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
			if (descChangeCB == null)
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
				descChangeCB(_arrAvatarTypeList[num]);
				return;
			}
		}

		protected void cfe1f62f6b0fad72d689d4935778b9284(CEvent c05f6b47f5e84359168dfe9aaf57b8a79)
		{
			c6425d3761c85e65e3530cc19d085d446 c6425d3761c85e65e3530cc19d085d = c05f6b47f5e84359168dfe9aaf57b8a79.target as c6425d3761c85e65e3530cc19d085d446;
			if (c6425d3761c85e65e3530cc19d085d.c591d56a94543e3559945c497f37126c4 == null)
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
				if (descChangeCB == null)
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
					descChangeCB(_arrAvatarTypeList[(int)c6425d3761c85e65e3530cc19d085d.c591d56a94543e3559945c497f37126c4]);
					return;
				}
			}
		}

		protected virtual void c9938ce8631685f55e4372c421fd1a56f(CEvent cd729d94a5b443ac0f1b117450e5f4419)
		{
			c6425d3761c85e65e3530cc19d085d446 c6425d3761c85e65e3530cc19d085d = cd729d94a5b443ac0f1b117450e5f4419.target as c6425d3761c85e65e3530cc19d085d446;
			if (c6425d3761c85e65e3530cc19d085d == null)
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
				MovieClip childByName = c6425d3761c85e65e3530cc19d085d.c89ef242f4744e0f1c4ffea4da8b79bc1.getChildByName<MovieClip>("mcIcon");
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
					childByName = childByName.getChildByName<MovieClip>("mcIcon");
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
						childByName.gotoAndStop("class" + (int)c6425d3761c85e65e3530cc19d085d.c591d56a94543e3559945c497f37126c4);
						return;
					}
				}
			}
		}

		protected virtual void ce6339c56d641da0fbe7f6951a1fd295a(CEvent cd729d94a5b443ac0f1b117450e5f4419)
		{
			c82f7c0afbcfc8c5382a8c6daa9365b7b c82f7c0afbcfc8c5382a8c6daa9365b7b = cd729d94a5b443ac0f1b117450e5f4419.target as c82f7c0afbcfc8c5382a8c6daa9365b7b;
			if (c82f7c0afbcfc8c5382a8c6daa9365b7b == null)
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
			if (!c82f7c0afbcfc8c5382a8c6daa9365b7b.c9c364a8fd1f013589fea518a3924e711)
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
				if (classChangeCB == null)
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
					int num = (int)c82f7c0afbcfc8c5382a8c6daa9365b7b.c591d56a94543e3559945c497f37126c4;
					c6e9df472ca5f99cfa7a405bcfed3cc2b(num);
					classChangeCB(_arrAvatarTypeList[num]);
					return;
				}
			}
		}
	}

	private c196099a1254db61d3be10d70e14e7422 _panel;

	private c82f7c0afbcfc8c5382a8c6daa9365b7b mcPrevBtn;

	private c82f7c0afbcfc8c5382a8c6daa9365b7b mcNextBtn;

	private IntroPanel mcDescView;

	private ClassPanel mcSelectView;

	private AvatarType _iClassID = AvatarType.TOTAL;

	[CompilerGenerated]
	private static Dictionary<string, int> _003C_003Ef__switch_0024mapE;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		_panel = new c196099a1254db61d3be10d70e14e7422();
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, "UI Base: class select view initializing!");
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("CharacterClass.swf", "ClassSelectionPanel", c1141a8fde9aa0f410bc4a7fdd2e3ef7c);
	}

	private void c1141a8fde9aa0f410bc4a7fdd2e3ef7c(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_panel.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8, OnWidgetInitialized);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cb4341b3564e3d55dc9f38df4b813c5da(_panel);
		mcSelectView.cc7fa43e9bd8fd461250ccf66a4c85f47(_iClassID);
		mcSelectView.c6e9df472ca5f99cfa7a405bcfed3cc2b();
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_panel);
		_panel = c9c0c8f01d2944aa6e09f167c382ebe52.c7088de59e49f7108f520cf7e0bae167e;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("CharacterClass.swf");
	}

	protected bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
	{
		bool result = false;
		string name = movieClip.name;
		if (name != null)
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
			if (_003C_003Ef__switch_0024mapE == null)
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
				Dictionary<string, int> dictionary = new Dictionary<string, int>(4);
				dictionary.Add("mcPrevBtn", 0);
				dictionary.Add("mcNextBtn", 1);
				dictionary.Add("mcDescView", 2);
				dictionary.Add("mcSelectView", 3);
				_003C_003Ef__switch_0024mapE = dictionary;
			}
			int value;
			if (_003C_003Ef__switch_0024mapE.TryGetValue(name, out value))
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
				switch (value)
				{
				case 0:
					mcPrevBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
					mcPrevBtn.c130648b59a0c8debea60aa153f844879(movieClip);
					mcPrevBtn.addEventListener(MouseEvent.CLICK, c8e60fb4f81068550dfc04c72900be46e);
					mcPrevBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<FrontEndStepManager>().c7c80683fbe2a8ba978d53115286c4c8a;
					result = true;
					break;
				case 1:
					mcNextBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
					mcNextBtn.c130648b59a0c8debea60aa153f844879(movieClip);
					mcNextBtn.addEventListener(MouseEvent.CLICK, cfc5920a5bb9bf351536e2ca4aea54e54);
					result = true;
					break;
				case 2:
					mcDescView = new IntroPanel();
					mcDescView.c130648b59a0c8debea60aa153f844879(movieClip);
					result = true;
					break;
				case 3:
				{
					mcSelectView = new ClassPanel();
					ClassPanel classPanel = mcSelectView;
					classPanel.classChangeCB = (ClassChangeEvent)Delegate.Combine(classPanel.classChangeCB, classChangeCB);
					mcSelectView.c130648b59a0c8debea60aa153f844879(movieClip);
					result = true;
					break;
				}
				}
			}
		}
		return result;
	}

	public override void ce4bf9718485f72643b662cd66d5c4e8e(AvatarType cf5ba148a098c23b65a37f8a31abed165, string c682d9c5b8f0b6928c6d5849c0aaf023a, string c0ce45a37bb03b4f4f7562d4c32aaaac9, bool c35adbebab5b5b1c36c32e991f0208c00 = false)
	{
		if (mcDescView == null)
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
					return;
				}
			}
		}
		mcDescView.c4398b6346dc91dc3750ab5a14e5935dd(cf5ba148a098c23b65a37f8a31abed165);
		if (c35adbebab5b5b1c36c32e991f0208c00)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					mcDescView.c79eb2fc29b57101e0937546b9a5e1fe7();
					return;
				}
			}
		}
		mcDescView.c1b4321addfcd17a6390661b7654a6659();
	}

	public override void cb061addc09fac4adf6f6700b27e998d9()
	{
		if (mcDescView == null)
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
		mcDescView.c79eb2fc29b57101e0937546b9a5e1fe7();
	}

	public override void cc7fa43e9bd8fd461250ccf66a4c85f47(AvatarType cf5ba148a098c23b65a37f8a31abed165)
	{
		_iClassID = cf5ba148a098c23b65a37f8a31abed165;
		if (mcSelectView == null)
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
		mcSelectView.cc7fa43e9bd8fd461250ccf66a4c85f47(cf5ba148a098c23b65a37f8a31abed165);
	}

	public override void c8ce27f07ad125dcd5d8f638ce54309f8(ClassChangeEvent cb24ea666f3f25bc975f1e84effd63cad)
	{
		base.c8ce27f07ad125dcd5d8f638ce54309f8(cb24ea666f3f25bc975f1e84effd63cad);
		if (mcSelectView == null)
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
			ClassPanel classPanel = mcSelectView;
			classPanel.classChangeCB = (ClassChangeEvent)Delegate.Combine(classPanel.classChangeCB, classChangeCB);
			return;
		}
	}

	public override void c578cb264f55b4d0af9261c41a382b885(ClassChangeEvent cb24ea666f3f25bc975f1e84effd63cad)
	{
		base.c578cb264f55b4d0af9261c41a382b885(cb24ea666f3f25bc975f1e84effd63cad);
		if (mcSelectView == null)
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
			ClassPanel classPanel = mcSelectView;
			classPanel.descChangeCB = (ClassChangeEvent)Delegate.Combine(classPanel.descChangeCB, descChangeCB);
			return;
		}
	}

	protected void c8e60fb4f81068550dfc04c72900be46e(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
	{
		c8e60fb4f81068550dfc04c72900be46e();
	}

	protected void cfc5920a5bb9bf351536e2ca4aea54e54(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
	{
		cfc5920a5bb9bf351536e2ca4aea54e54();
	}
}
