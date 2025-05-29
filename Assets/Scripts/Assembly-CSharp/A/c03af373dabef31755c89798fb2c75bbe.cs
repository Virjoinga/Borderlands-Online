using System;
using System.Collections.Generic;
using Core;
using pumpkin.events;

namespace A
{
	public class c03af373dabef31755c89798fb2c75bbe : ceaa621c569baf012ce466a5c368364e3
	{
		private List<string> c1725a717efba615ea3c89ec4cbd237f1;

		private float ccf7d1bc34a5d6b76f263731a59423cc5;

		private float c2ca6fd668a2dcf2b6d279ac4c91682aa;

		private int c542202326c871bd2d29f3fdd8b63c197 = 2;

		public string[] ce034e2d2b52cb24d752094523b9e5c67
		{
			get
			{
				return c1725a717efba615ea3c89ec4cbd237f1.ToArray();
			}
			set
			{
				if (value == null)
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
					c1725a717efba615ea3c89ec4cbd237f1 = new List<string>(value);
					return;
				}
			}
		}

		public c03af373dabef31755c89798fb2c75bbe()
		{
			cafbbef33d1cd0d1a2f0610a49f2aafad = false;
		}

		~c03af373dabef31755c89798fb2c75bbe()
		{
			c340ad4e1f1707c51248b1d3b50723a7e.ccf24681862bae286c19d5c9b16296be5.removeEventListener("dragBegin", c05ec55cb8f521b4d957dac78232b943c);
			c340ad4e1f1707c51248b1d3b50723a7e.ccf24681862bae286c19d5c9b16296be5.removeEventListener("dragEnd", cdbc1141a89f7bca5b7a9bcf787eab6cc);
		}

		public bool cc58ffcc97a15d4040f80ffd31964d278(object c591d56a94543e3559945c497f37126c4)
		{
			int result;
			if (c591d56a94543e3559945c497f37126c4 != null)
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
				if (c1725a717efba615ea3c89ec4cbd237f1 != null)
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
					result = (c1725a717efba615ea3c89ec4cbd237f1.Contains(string.Empty) ? 1 : 0);
					goto IL_003d;
				}
			}
			result = 1;
			goto IL_003d;
			IL_003d:
			return (byte)result != 0;
		}

		public void ca5d5ab81da68c7871bdff74abfa3f68f(object c591d56a94543e3559945c497f37126c4)
		{
			dispatchEvent(new cdd9021d4f44808fce2ab49c52f0db6f7("drop", c591d56a94543e3559945c497f37126c4));
		}

		protected override void c16dd84132166e8847948a375ec27d1d9()
		{
			base.c16dd84132166e8847948a375ec27d1d9();
			if (c0ffd7f3b3dfe86849f698f744e296ad3 == null)
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
				DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: Button onConfiUI() 'controlMC' is null! UIComponent won't work!!!");
			}
			c0ffd7f3b3dfe86849f698f744e296ad3.addEventListener(MouseEvent.MOUSE_ENTER, cc9106b6b99fb1fddd5d68a097e9c7b32, false);
			c0ffd7f3b3dfe86849f698f744e296ad3.addEventListener(MouseEvent.MOUSE_LEAVE, c245fa1778dd0a65bbc7143f38ccd4638, false);
			c0ffd7f3b3dfe86849f698f744e296ad3.addEventListener(MouseEvent.MOUSE_DOWN, cc456d3c6534f82911e2170a48a3954e1, false);
			c340ad4e1f1707c51248b1d3b50723a7e.ccf24681862bae286c19d5c9b16296be5.addEventListener("dragBegin", c05ec55cb8f521b4d957dac78232b943c);
			c340ad4e1f1707c51248b1d3b50723a7e.ccf24681862bae286c19d5c9b16296be5.addEventListener("dragEnd", cdbc1141a89f7bca5b7a9bcf787eab6cc);
		}

		private void c05ec55cb8f521b4d957dac78232b943c(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			cdd9021d4f44808fce2ab49c52f0db6f7 c591d56a94543e3559945c497f37126c = c3d202dee321219a80026dc3081fb3c86 as cdd9021d4f44808fce2ab49c52f0db6f7;
			if (!cc58ffcc97a15d4040f80ffd31964d278(c591d56a94543e3559945c497f37126c))
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
			c150264a18c2cb408479d3f072cac8cc1 = true;
		}

		private void cdbc1141a89f7bca5b7a9bcf787eab6cc(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			c150264a18c2cb408479d3f072cac8cc1 = false;
			c0ffd7f3b3dfe86849f698f744e296ad3.gotoAndStop("dragUp");
			c0ffd7f3b3dfe86849f698f744e296ad3.gotoAndStop("up");
			cdd9021d4f44808fce2ab49c52f0db6f7 cdd9021d4f44808fce2ab49c52f0db6f8 = c3d202dee321219a80026dc3081fb3c86 as cdd9021d4f44808fce2ab49c52f0db6f7;
			if (cdd9021d4f44808fce2ab49c52f0db6f8 == null)
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
				cdaa8be71633914d75e27ba7c238d88d3 cdaa8be71633914d75e27ba7c238d88d4 = (cdaa8be71633914d75e27ba7c238d88d3)cdd9021d4f44808fce2ab49c52f0db6f8.c591d56a94543e3559945c497f37126c4;
				if (cdaa8be71633914d75e27ba7c238d88d4.c23b4e0b18658b25fecb7b4ea24320303 != this)
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
					if (cdaa8be71633914d75e27ba7c238d88d4.c45f4ff3e52769613f7fe87136374eecf)
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
						ca5d5ab81da68c7871bdff74abfa3f68f(cdaa8be71633914d75e27ba7c238d88d4.c591d56a94543e3559945c497f37126c4);
						return;
					}
				}
			}
		}

		private void cc456d3c6534f82911e2170a48a3954e1(CEvent cd729d94a5b443ac0f1b117450e5f4419)
		{
			c340ad4e1f1707c51248b1d3b50723a7e.ccf24681862bae286c19d5c9b16296be5.c23b4e0b18658b25fecb7b4ea24320303 = this;
			c340ad4e1f1707c51248b1d3b50723a7e.ccf24681862bae286c19d5c9b16296be5.c6ae7f7e977a53956ec405b6f612a3c3d();
			ccf7d1bc34a5d6b76f263731a59423cc5 = c0ffd7f3b3dfe86849f698f744e296ad3.mouseX;
			c2ca6fd668a2dcf2b6d279ac4c91682aa = c0ffd7f3b3dfe86849f698f744e296ad3.mouseY;
			c0ffd7f3b3dfe86849f698f744e296ad3.addEventListener(MouseEvent.MOUSE_MOVE, c8ff46c1cdb11463f09f4904598884596, false);
		}

		private void c8ff46c1cdb11463f09f4904598884596(CEvent cd729d94a5b443ac0f1b117450e5f4419)
		{
			if (!(Math.Abs(c0ffd7f3b3dfe86849f698f744e296ad3.mouseX - ccf7d1bc34a5d6b76f263731a59423cc5) > (float)c542202326c871bd2d29f3fdd8b63c197))
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
				if (!(Math.Abs(c0ffd7f3b3dfe86849f698f744e296ad3.mouseY - c2ca6fd668a2dcf2b6d279ac4c91682aa) > (float)c542202326c871bd2d29f3fdd8b63c197))
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
					break;
				}
			}
			ccc71c4e82a93081f2aa26108f058c3c0();
		}

		private void ccc71c4e82a93081f2aa26108f058c3c0()
		{
			c340ad4e1f1707c51248b1d3b50723a7e.ccf24681862bae286c19d5c9b16296be5.c23b4e0b18658b25fecb7b4ea24320303 = c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e;
			c340ad4e1f1707c51248b1d3b50723a7e.ccf24681862bae286c19d5c9b16296be5.c6ae7f7e977a53956ec405b6f612a3c3d();
			c0ffd7f3b3dfe86849f698f744e296ad3.removeAllEventListeners(MouseEvent.MOUSE_MOVE);
		}

		private void cc9106b6b99fb1fddd5d68a097e9c7b32(CEvent cd729d94a5b443ac0f1b117450e5f4419)
		{
			c0ffd7f3b3dfe86849f698f744e296ad3.gotoAndPlay("over");
		}

		private void c245fa1778dd0a65bbc7143f38ccd4638(CEvent cd729d94a5b443ac0f1b117450e5f4419)
		{
			MouseEvent mouseEvent = cd729d94a5b443ac0f1b117450e5f4419 as MouseEvent;
			if (mouseEvent == null)
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
			c0ffd7f3b3dfe86849f698f744e296ad3.gotoAndPlay("up");
			c0ffd7f3b3dfe86849f698f744e296ad3.gotoAndPlay("out");
			c340ad4e1f1707c51248b1d3b50723a7e.ccf24681862bae286c19d5c9b16296be5.c23b4e0b18658b25fecb7b4ea24320303 = c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e;
			c340ad4e1f1707c51248b1d3b50723a7e.ccf24681862bae286c19d5c9b16296be5.c6ae7f7e977a53956ec405b6f612a3c3d();
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			c0ffd7f3b3dfe86849f698f744e296ad3.visible = false;
		}
	}
}
