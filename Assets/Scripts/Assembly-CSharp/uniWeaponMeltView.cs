using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using UnityEngine;
using XsdSettings;
using pumpkin.display;
using pumpkin.events;

public class uniWeaponMeltView : WeaponMeltView
{
	public class MeltingPanel : c196099a1254db61d3be10d70e14e7422
	{
		protected MovieClip mcRootMovie;

		protected MovieClip mcRoot;

		protected MovieClip mcAnimation;

		protected MovieClip mcMaterialInfoA;

		protected MovieClip mcMaterialInfoB;

		protected MovieClip mcMaterialInfoC;

		[CompilerGenerated]
		private static Dictionary<string, int> _003C_003Ef__switch_0024map31;

		public bool c150264a18c2cb408479d3f072cac8cc1
		{
			get
			{
				return mcRootMovie.visible;
			}
			set
			{
				mcRootMovie.visible = value;
			}
		}

		public bool c27b8b8f2b26d9420fc1ac46dcae468c9
		{
			get
			{
				return mcRootMovie.isPlaying;
			}
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			mcRootMovie = base.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
			if (mcRootMovie == null)
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
			mcRoot = mcRootMovie.getChildByName<MovieClip>("mcRoot");
		}

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool result = false;
			string name = movieClip.name;
			if (name != null)
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
				if (_003C_003Ef__switch_0024map31 == null)
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
					Dictionary<string, int> dictionary = new Dictionary<string, int>(4);
					dictionary.Add("mcAnimation", 0);
					dictionary.Add("mcMaterialInfoA", 1);
					dictionary.Add("mcMaterialInfoB", 2);
					dictionary.Add("mcMaterialInfoC", 3);
					_003C_003Ef__switch_0024map31 = dictionary;
				}
				int value;
				if (_003C_003Ef__switch_0024map31.TryGetValue(name, out value))
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
						mcAnimation = movieClip;
						mcAnimation.gotoAndStop("end");
						mcAnimation.addFrameScript("fadein", c77de347f5cc9efb7b4cb59c10d1fcbd9);
						mcAnimation.addFrameScript("normal", c77de347f5cc9efb7b4cb59c10d1fcbd9);
						mcAnimation.addFrameScript("fadeout", c77de347f5cc9efb7b4cb59c10d1fcbd9);
						mcAnimation.addFrameScript("end", c77de347f5cc9efb7b4cb59c10d1fcbd9);
						result = true;
						break;
					case 1:
						mcMaterialInfoA = movieClip;
						result = true;
						break;
					case 2:
						mcMaterialInfoB = movieClip;
						result = true;
						break;
					case 3:
						mcMaterialInfoC = movieClip;
						result = true;
						break;
					}
				}
			}
			return result;
		}

		private void c77de347f5cc9efb7b4cb59c10d1fcbd9(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			MovieClip childByName = mcAnimation.getChildByName("mcMaterialInfo").getChildByName<MovieClip>("mcMaterialInfoChild");
			mcMaterialInfoA = childByName.getChildByName<MovieClip>("mcMaterialInfoA");
			mcMaterialInfoA.visible = false;
			mcMaterialInfoB = childByName.getChildByName<MovieClip>("mcMaterialInfoB");
			mcMaterialInfoB.visible = false;
			mcMaterialInfoC = childByName.getChildByName<MovieClip>("mcMaterialInfoC");
			mcMaterialInfoC.visible = false;
		}

		public void ca8cd836c3dd2f9b178aa20356400254d(AcquiredMaterial[] c90e9d2d3391813a63a01f3e10bba6cb7)
		{
			mcAnimation.gotoAndPlay("fadein");
			if (c90e9d2d3391813a63a01f3e10bba6cb7 == null)
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
			if (mcMaterialInfoA != null)
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
				if (c90e9d2d3391813a63a01f3e10bba6cb7.Length > 0)
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
					mcMaterialInfoA.visible = true;
					cffa0c876c65d2f37a32ab578720a8401(c90e9d2d3391813a63a01f3e10bba6cb7[0], mcMaterialInfoA);
				}
				else
				{
					mcMaterialInfoA.visible = false;
				}
			}
			if (mcMaterialInfoB != null)
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
				if (c90e9d2d3391813a63a01f3e10bba6cb7.Length > 1)
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
					mcMaterialInfoB.visible = true;
					cffa0c876c65d2f37a32ab578720a8401(c90e9d2d3391813a63a01f3e10bba6cb7[1], mcMaterialInfoB);
				}
				else
				{
					mcMaterialInfoB.visible = false;
				}
			}
			if (mcMaterialInfoC == null)
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
				if (c90e9d2d3391813a63a01f3e10bba6cb7.Length > 2)
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							mcMaterialInfoC.visible = true;
							cffa0c876c65d2f37a32ab578720a8401(c90e9d2d3391813a63a01f3e10bba6cb7[2], mcMaterialInfoC);
							return;
						}
					}
				}
				mcMaterialInfoC.visible = false;
				return;
			}
		}

		private void cffa0c876c65d2f37a32ab578720a8401(AcquiredMaterial c09dee3cbfac84d71d5bd0414feaa4fe3, MovieClip c76072b70b68a15567d4cbe70087b6b85)
		{
			UnityTextField childByName = c76072b70b68a15567d4cbe70087b6b85.getChildByName<UnityTextField>("textField");
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
				childByName.text = "x" + c09dee3cbfac84d71d5bd0414feaa4fe3.m_MaterialNums;
			}
			MovieClip childByName2 = c76072b70b68a15567d4cbe70087b6b85.getChildByName<MovieClip>("mcMaterialIcon");
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
				childByName2.gotoAndStop(c09dee3cbfac84d71d5bd0414feaa4fe3.m_MaterialType.ToString());
				return;
			}
		}

		public void c7898a7da02dc53fde2d5fb0144f48bce()
		{
			if (!(mcAnimation.currentLabel != "end"))
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
				mcAnimation.gotoAndPlay("fadeout");
				return;
			}
		}
	}

	private MeltingPanel _meltingPanel;

	private uniInventoryView.InventoryPanel _inventoryPanel;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c968ae3f7ba22e4826b18039ba36f33ce(this, new Vector2(800f, 52f));
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("WeaponMelting-2014.swf", "Whole", c1141a8fde9aa0f410bc4a7fdd2e3ef7c);
		_inventoryPanel = (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InventoryView>() as uniInventoryView).c796c173865ebd0e0606dad33b499db0b;
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		_inventoryPanel = null;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_meltingPanel);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("WeaponMelting-2014.swf");
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
		if (_inventoryPanel == null)
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
			_inventoryPanel = (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InventoryView>() as uniInventoryView).c796c173865ebd0e0606dad33b499db0b;
		}
		if (_inventoryPanel != null)
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
			if (_bVisible)
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
				(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cb4341b3564e3d55dc9f38df4b813c5da(_meltingPanel);
				cdb61fd817ac27166903b9ffc008ad1dd();
				_inventoryPanel.addEventListener("Item" + MouseEvent.CLICK, c3f07aa998bf303194d0f7ebe96fc957c);
				_inventoryPanel.addEventListener("Item" + c649b5d45cf350f685c56c4bd02800198.cfb118d69d579b2fbde25fa8127b213f3, c41b74e095a2dce69351faa913502b0b5);
				_inventoryPanel.addEventListener("Item" + MouseEvent.MOUSE_ENTER, c958c3ac0a1c5a32823ec17487f74f1b5);
				_inventoryPanel.addEventListener("Item" + MouseEvent.MOUSE_LEAVE, cb7fe6f7819f02ed4cfb952c1e0a2b0ec);
			}
			else
			{
				(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_meltingPanel);
				_inventoryPanel.removeEventListener("Item" + MouseEvent.CLICK, c3f07aa998bf303194d0f7ebe96fc957c);
				_inventoryPanel.removeEventListener("Item" + c649b5d45cf350f685c56c4bd02800198.cfb118d69d579b2fbde25fa8127b213f3, c41b74e095a2dce69351faa913502b0b5);
				_inventoryPanel.removeEventListener("Item" + MouseEvent.MOUSE_ENTER, c958c3ac0a1c5a32823ec17487f74f1b5);
				_inventoryPanel.removeEventListener("Item" + MouseEvent.MOUSE_LEAVE, cb7fe6f7819f02ed4cfb952c1e0a2b0ec);
			}
		}
		_meltingPanel.c150264a18c2cb408479d3f072cac8cc1 = _bVisible;
	}

	private void c1141a8fde9aa0f410bc4a7fdd2e3ef7c(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_meltingPanel = new MeltingPanel();
		_meltingPanel.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		_meltingPanel.addEventListener("XBtnClicked", c33d802bc86e36d426896b838a8f61e31);
		cbe9ca8ddb3cdc2312e6ff8411b2db2c8.visible = _bVisible;
		DisplayObject childByName = cbe9ca8ddb3cdc2312e6ff8411b2db2c8.getChildByName("mcInventoryPosition");
		if (childByName == null)
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
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c968ae3f7ba22e4826b18039ba36f33ce(this, ca34081ace93927b1656a62bbab14a6f3.ccf24681862bae286c19d5c9b16296be5.c46e387bea9111b07d3d0e2e52548626c(childByName, Vector2.zero));
			return;
		}
	}

	protected override void cdb61fd817ac27166903b9ffc008ad1dd()
	{
		if (_meltWeapon != null)
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
					_meltingPanel.ca8cd836c3dd2f9b178aa20356400254d(_arrMaterialList);
					return;
				}
			}
		}
		_meltingPanel.c7898a7da02dc53fde2d5fb0144f48bce();
	}

	protected void c3f07aa998bf303194d0f7ebe96fc957c(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		cdd9021d4f44808fce2ab49c52f0db6f7 cdd9021d4f44808fce2ab49c52f0db6f = c3d202dee321219a80026dc3081fb3c86 as cdd9021d4f44808fce2ab49c52f0db6f7;
		UIItemSlotData uIItemSlotData = (UIItemSlotData)cdd9021d4f44808fce2ab49c52f0db6f.c591d56a94543e3559945c497f37126c4;
		if (!uIItemSlotData.item.ca8e8ecb1231bf8cf32c06da446a48681(ItemType.Weapon))
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
			c2d912a7f9ac2a871043051cfa59c20c8(uIItemSlotData.item, uIItemSlotData.index);
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().cff2b0374fa4093a26652f81f964f8e9f(GameUIManager.CursorManager.CursorType.HammerLift);
			cbd17533d988e0766ca8ea8becca77b78();
			return;
		}
	}

	protected void c41b74e095a2dce69351faa913502b0b5(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		cdd9021d4f44808fce2ab49c52f0db6f7 cdd9021d4f44808fce2ab49c52f0db6f = c3d202dee321219a80026dc3081fb3c86 as cdd9021d4f44808fce2ab49c52f0db6f7;
		if (((UIItemSlotData)cdd9021d4f44808fce2ab49c52f0db6f.c591d56a94543e3559945c497f37126c4).item.m_type == ItemType.Weapon)
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
					(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c462fe1a64a37daab5e61f688d9a61e7f("UI_Wep_Melting_Hammer_Hit_Rnd");
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().cff2b0374fa4093a26652f81f964f8e9f(GameUIManager.CursorManager.CursorType.HammerKnock);
					return;
				}
			}
		}
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c462fe1a64a37daab5e61f688d9a61e7f("UI_select");
	}

	protected void c958c3ac0a1c5a32823ec17487f74f1b5(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		cdd9021d4f44808fce2ab49c52f0db6f7 cdd9021d4f44808fce2ab49c52f0db6f = c3d202dee321219a80026dc3081fb3c86 as cdd9021d4f44808fce2ab49c52f0db6f7;
		UIItemSlotData uIItemSlotData = (UIItemSlotData)cdd9021d4f44808fce2ab49c52f0db6f.c591d56a94543e3559945c497f37126c4;
		if (uIItemSlotData.item.m_type == ItemType.Weapon)
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
					c2d912a7f9ac2a871043051cfa59c20c8(uIItemSlotData.item, uIItemSlotData.index);
					return;
				}
			}
		}
		c2d912a7f9ac2a871043051cfa59c20c8(null, -1);
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<GameUIManager>().cff2b0374fa4093a26652f81f964f8e9f(GameUIManager.CursorManager.CursorType.HammerForbid);
	}

	protected void cb7fe6f7819f02ed4cfb952c1e0a2b0ec(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<GameUIManager>().cff2b0374fa4093a26652f81f964f8e9f(GameUIManager.CursorManager.CursorType.HammerLift);
		c2d912a7f9ac2a871043051cfa59c20c8(null, -1);
	}

	protected void c6a8ab05be9d7a10599093f98d4070666(UIItemSlotData c82fcbab5e578dc3a31c1f662916bd87e, UIItemSlotData cae5fea398599f41bfafc9b6bb6f4559b)
	{
		if (!(cae5fea398599f41bfafc9b6bb6f4559b.identifier == "inventory"))
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
			c2d912a7f9ac2a871043051cfa59c20c8(cae5fea398599f41bfafc9b6bb6f4559b.item, cae5fea398599f41bfafc9b6bb6f4559b.index);
			return;
		}
	}

	protected void c33d802bc86e36d426896b838a8f61e31(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		c150264a18c2cb408479d3f072cac8cc1 = false;
	}

	protected void c21ea88b3b3445262aef52822879b81de(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		base.cbe11bd46110bca91fb5268e91350dc31();
	}

	protected override void c51c797c62accc8fc47deb91ab4fc68ce(bool cc76b4d742c039cbe828e163818855cc2)
	{
		base.c51c797c62accc8fc47deb91ab4fc68ce(cc76b4d742c039cbe828e163818855cc2);
	}
}
