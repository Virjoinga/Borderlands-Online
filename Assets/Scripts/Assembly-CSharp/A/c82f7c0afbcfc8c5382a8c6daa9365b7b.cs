using System.Collections.Generic;
using Core;
using UnityEngine;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

namespace A
{
	public class c82f7c0afbcfc8c5382a8c6daa9365b7b : ceaa621c569baf012ce466a5c368364e3
	{
		protected const float c726711b64d0d5ffce217f265c5369eda = 0.2f;

		public bool cb36f536645b2e8c5ed48e90b8357f0f9;

		public bool ce84b930a12a1d06512c79320b3f0d3f4 = true;

		protected object cc1e82e2b19483af134612fb0c24142e3;

		protected bool cb584fcfb755c3acbd1f63566a65d04ee;

		protected string c8b24514933da61f4fae114de5154e38a;

		protected string c3ed0ad8a8d1c09345604daf49571678d;

		protected cab925e8b02dc39594f255a86a0d7c5e1 c8e36dcffb0a53df4f15205590476e97d;

		protected string c7a96af3bb01aec7b11dd702aff2823ab;

		protected bool c3a7bb1f394b95e261698859f9998aa83;

		private Dictionary<string, string[]> c03901b649403b2006ecf0d01b1db1786;

		protected string c4ba613640f8a02ea367516f0b9e2ed36 = string.Empty;

		public TextField ca08748e235f2abf925ebb3dfb3b858e8;

		protected float c80f319608c74f921612c6827ae99b036;

		protected string[] c4c7526414579675a2ef5ea57c4341384;

		protected string[] c92a176a56262a74108ced1a4010d1aa3;

		public object c591d56a94543e3559945c497f37126c4
		{
			get
			{
				return cc1e82e2b19483af134612fb0c24142e3;
			}
			set
			{
				cc1e82e2b19483af134612fb0c24142e3 = value;
			}
		}

		public override bool cbf402c82d0fffee7c8f37c98e456b8f8
		{
			set
			{
				base.cbf402c82d0fffee7c8f37c98e456b8f8 = value;
				if (c0ffd7f3b3dfe86849f698f744e296ad3 != null)
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
					c0ffd7f3b3dfe86849f698f744e296ad3.mouseChildrenEnabled = false;
				}
				object obj;
				if (base.cbf402c82d0fffee7c8f37c98e456b8f8)
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
					obj = "up";
				}
				else
				{
					obj = "disabled";
				}
				string ca7b177d7a2c24bd047a7ade7e642aa4d = (string)obj;
				cb42dff485771448e06580bb8e8423337(ca7b177d7a2c24bd047a7ade7e642aa4d);
			}
		}

		public virtual bool c7012333eca6b837775bc288cc43ca1c4
		{
			get
			{
				return cb584fcfb755c3acbd1f63566a65d04ee;
			}
			set
			{
				cb584fcfb755c3acbd1f63566a65d04ee = value;
			}
		}

		public string c17fcd0ed1024ad7689991a96ed60deb1
		{
			get
			{
				return c3ed0ad8a8d1c09345604daf49571678d;
			}
		}

		public virtual bool c9c364a8fd1f013589fea518a3924e711
		{
			get
			{
				return c3a7bb1f394b95e261698859f9998aa83;
			}
			set
			{
				c3a7bb1f394b95e261698859f9998aa83 = value;
				if (cbf402c82d0fffee7c8f37c98e456b8f8)
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
					if (c3a7bb1f394b95e261698859f9998aa83)
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
						cb42dff485771448e06580bb8e8423337("selecting");
					}
					else
					{
						cb42dff485771448e06580bb8e8423337("toggle");
					}
				}
				else
				{
					cb42dff485771448e06580bb8e8423337("disabled");
				}
				c9a4115e2f37e3c94e97c40de948fc839();
				dispatchEvent(new c649b5d45cf350f685c56c4bd02800198(c649b5d45cf350f685c56c4bd02800198.c7f4ba2ffb076e0e5be86154a13705fe9));
			}
		}

		public virtual cab925e8b02dc39594f255a86a0d7c5e1 c6279c42b47398c5e401c1cff54ce61c2
		{
			get
			{
				return c8e36dcffb0a53df4f15205590476e97d;
			}
			set
			{
				if (c8e36dcffb0a53df4f15205590476e97d != null)
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
					c8e36dcffb0a53df4f15205590476e97d.cae286eca4fc7200a84038485c394f478(this);
				}
				c8e36dcffb0a53df4f15205590476e97d = value;
				if (c8e36dcffb0a53df4f15205590476e97d == null)
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
					c8e36dcffb0a53df4f15205590476e97d.c944ce396befee000aaf19ada19b929c3(this);
					return;
				}
			}
		}

		public virtual string cec024da8c099380cfe1334bfe4c8f30f
		{
			get
			{
				return c7a96af3bb01aec7b11dd702aff2823ab;
			}
			set
			{
				if (c7a96af3bb01aec7b11dd702aff2823ab == value)
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
				c7a96af3bb01aec7b11dd702aff2823ab = value;
				c2f084bfb2f773291c470ba64b791473d();
			}
		}

		public virtual string cf798cedf450c3ad2a08ce2d2fd00d464
		{
			get
			{
				return c8b24514933da61f4fae114de5154e38a;
			}
			set
			{
				if (c8b24514933da61f4fae114de5154e38a == value)
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
				c8b24514933da61f4fae114de5154e38a = value;
				cb26f782d2da94f98c5f8438bfa655373();
			}
		}

		public c82f7c0afbcfc8c5382a8c6daa9365b7b()
		{
			string[] array = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(1);
			array[0] = string.Empty;
			c4c7526414579675a2ef5ea57c4341384 = array;
			string[] array2 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(2);
			array2[0] = "selected_";
			array2[1] = string.Empty;
			c92a176a56262a74108ced1a4010d1aa3 = array2;
			base._002Ector();
			c03901b649403b2006ecf0d01b1db1786 = new Dictionary<string, string[]>();
			Dictionary<string, string[]> dictionary = c03901b649403b2006ecf0d01b1db1786;
			string[] array3 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(1);
			array3[0] = "up";
			dictionary.Add("up", array3);
			Dictionary<string, string[]> dictionary2 = c03901b649403b2006ecf0d01b1db1786;
			string[] array4 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(1);
			array4[0] = "over";
			dictionary2.Add("over", array4);
			Dictionary<string, string[]> dictionary3 = c03901b649403b2006ecf0d01b1db1786;
			string[] array5 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(1);
			array5[0] = "down";
			dictionary3.Add("down", array5);
			Dictionary<string, string[]> dictionary4 = c03901b649403b2006ecf0d01b1db1786;
			string[] array6 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(2);
			array6[0] = "release";
			array6[1] = "over";
			dictionary4.Add("release", array6);
			Dictionary<string, string[]> dictionary5 = c03901b649403b2006ecf0d01b1db1786;
			string[] array7 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(2);
			array7[0] = "out";
			array7[1] = "up";
			dictionary5.Add("out", array7);
			Dictionary<string, string[]> dictionary6 = c03901b649403b2006ecf0d01b1db1786;
			string[] array8 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(1);
			array8[0] = "disabled";
			dictionary6.Add("disabled", array8);
			Dictionary<string, string[]> dictionary7 = c03901b649403b2006ecf0d01b1db1786;
			string[] array9 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(2);
			array9[0] = "selecting";
			array9[1] = "over";
			dictionary7.Add("selecting", array9);
			Dictionary<string, string[]> dictionary8 = c03901b649403b2006ecf0d01b1db1786;
			string[] array10 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(2);
			array10[0] = "toggle";
			array10[1] = "up";
			dictionary8.Add("toggle", array10);
			cfc6bd34fd239451eaab78d7296f8d40f.Add(MouseEvent.CLICK, "UI_Select");
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			if (c0ffd7f3b3dfe86849f698f744e296ad3 == null)
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
				c0ffd7f3b3dfe86849f698f744e296ad3.removeEventListener(CEvent.ENTER_FRAME, ca593c832e33a35a94e0dc4e5cb9f5252, false);
				c0ffd7f3b3dfe86849f698f744e296ad3.addEventListener(CEvent.ENTER_FRAME, ca593c832e33a35a94e0dc4e5cb9f5252, false);
				return;
			}
		}

		protected override void c16dd84132166e8847948a375ec27d1d9()
		{
			base.c16dd84132166e8847948a375ec27d1d9();
			if (c0ffd7f3b3dfe86849f698f744e296ad3 == null)
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
				DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: Button onConfiUI() 'controlMC' is null! UIComponent won't work!!!");
			}
			c0ffd7f3b3dfe86849f698f744e296ad3.mouseChildrenEnabled = false;
			c0ffd7f3b3dfe86849f698f744e296ad3.addEventListener(MouseEvent.MOUSE_ENTER, c0d0edd197df0dbfa38010e2ce6112850, false);
			c0ffd7f3b3dfe86849f698f744e296ad3.addEventListener(MouseEvent.MOUSE_LEAVE, cabaa8cbfd9da30988bae3a6c5a4b14d2, false);
			c0ffd7f3b3dfe86849f698f744e296ad3.addEventListener(MouseEvent.MOUSE_DOWN, cca1346a71f7b492d4c1bbe3a95e31557, false);
			c0ffd7f3b3dfe86849f698f744e296ad3.addEventListener(MouseEvent.CLICK, ca2c8ad477a1a8ef2c6efd2087707b4b0, false);
			c0ffd7f3b3dfe86849f698f744e296ad3.addEventListener(ccee399aceaafcace836a9d2621e66f35.cd58336ed361ce802b5f1a11c492908c2, c7b7728da1e249960027a430df97b597a, false);
			ca08748e235f2abf925ebb3dfb3b858e8 = c0ffd7f3b3dfe86849f698f744e296ad3.getChildByName("textField") as TextField;
		}

		protected override void c146b4c165c8d635e38ccda9d949a8a36()
		{
			string[] array = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(1);
			array[0] = c1a8845a28f42676a15a04367f2b275b0.cdc8ba5127f1b277edc6e3aee68abe7e3;
			if (c288d18cfaa40a235a1bd29fc44b519b5(array))
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
				if (c4ba613640f8a02ea367516f0b9e2ed36 != string.Empty)
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
					if (c0ffd7f3b3dfe86849f698f744e296ad3 != null)
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
						c0ffd7f3b3dfe86849f698f744e296ad3.gotoAndPlay(c4ba613640f8a02ea367516f0b9e2ed36);
						c4ba613640f8a02ea367516f0b9e2ed36 = string.Empty;
					}
				}
				c9f8eeb310eab54c590c996dd8e63e346();
				dispatchEvent(new cab2f86763d523d403495740f472b326b(cab2f86763d523d403495740f472b326b.cdad50184a105a463ca658bfde4f535d3));
				cb26f782d2da94f98c5f8438bfa655373();
			}
			string[] array2 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(1);
			array2[0] = c1a8845a28f42676a15a04367f2b275b0.c1d64c67f1771316f9fbe412dd72c6cde;
			if (!c288d18cfaa40a235a1bd29fc44b519b5(array2))
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
				c521641d7216a0be9dad8c7a8b29a8791();
				return;
			}
		}

		protected virtual void c2f084bfb2f773291c470ba64b791473d()
		{
			cab925e8b02dc39594f255a86a0d7c5e1 cab925e8b02dc39594f255a86a0d7c5e2 = cab925e8b02dc39594f255a86a0d7c5e1.cd4833052cc4daf5b269e37eb1d8262d9(c7a96af3bb01aec7b11dd702aff2823ab);
			if (cab925e8b02dc39594f255a86a0d7c5e2 == c6279c42b47398c5e401c1cff54ce61c2)
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
			c6279c42b47398c5e401c1cff54ce61c2 = cab925e8b02dc39594f255a86a0d7c5e2;
		}

		protected virtual void c521641d7216a0be9dad8c7a8b29a8791()
		{
			if (c8b24514933da61f4fae114de5154e38a == null)
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
				if (ca08748e235f2abf925ebb3dfb3b858e8 == null)
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
					if (!(ca08748e235f2abf925ebb3dfb3b858e8.text != c8b24514933da61f4fae114de5154e38a))
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
						ca08748e235f2abf925ebb3dfb3b858e8.text = c8b24514933da61f4fae114de5154e38a;
						return;
					}
				}
			}
		}

		protected virtual void c634c06ece1946e6b25a9cfc813fdddbd(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			ca08748e235f2abf925ebb3dfb3b858e8 = c0ffd7f3b3dfe86849f698f744e296ad3.getChildByName("textField") as TextField;
			c521641d7216a0be9dad8c7a8b29a8791();
		}

		protected virtual void c9f8eeb310eab54c590c996dd8e63e346()
		{
			if (!c9909140b72f3c9b83a007c6919994e3d)
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
			ca08748e235f2abf925ebb3dfb3b858e8 = c0ffd7f3b3dfe86849f698f744e296ad3.getChildByName("textField") as TextField;
		}

		protected void ca593c832e33a35a94e0dc4e5cb9f5252(CEvent c47881dc580ee2e5fe1effdd795900a78)
		{
			TextField textField = c0ffd7f3b3dfe86849f698f744e296ad3.getChildByName("textField") as TextField;
			if (ca08748e235f2abf925ebb3dfb3b858e8 == textField)
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
				ca08748e235f2abf925ebb3dfb3b858e8 = textField;
				c521641d7216a0be9dad8c7a8b29a8791();
				return;
			}
		}

		protected void c7b7728da1e249960027a430df97b597a(CEvent cd729d94a5b443ac0f1b117450e5f4419)
		{
			string cd58336ed361ce802b5f1a11c492908c = c649b5d45cf350f685c56c4bd02800198.cd58336ed361ce802b5f1a11c492908c2;
			if (!cbf402c82d0fffee7c8f37c98e456b8f8)
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
				cb42dff485771448e06580bb8e8423337("down");
				c649b5d45cf350f685c56c4bd02800198 e = new c649b5d45cf350f685c56c4bd02800198(cd58336ed361ce802b5f1a11c492908c);
				dispatchEvent(e);
				return;
			}
		}

		protected void c0d0edd197df0dbfa38010e2ce6112850(CEvent cd729d94a5b443ac0f1b117450e5f4419)
		{
			MouseEvent mouseEvent = cd729d94a5b443ac0f1b117450e5f4419 as MouseEvent;
			if (mouseEvent == null)
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
			if (!cbf402c82d0fffee7c8f37c98e456b8f8)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			cb42dff485771448e06580bb8e8423337("over");
			mouseEvent.target = this;
			dispatchEvent(mouseEvent);
		}

		protected void cabaa8cbfd9da30988bae3a6c5a4b14d2(CEvent cd729d94a5b443ac0f1b117450e5f4419)
		{
			MouseEvent mouseEvent = cd729d94a5b443ac0f1b117450e5f4419 as MouseEvent;
			if (mouseEvent == null)
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
			if (!cbf402c82d0fffee7c8f37c98e456b8f8)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			cb42dff485771448e06580bb8e8423337("out");
			mouseEvent.target = this;
			dispatchEvent(mouseEvent);
		}

		protected void cca1346a71f7b492d4c1bbe3a95e31557(CEvent cd729d94a5b443ac0f1b117450e5f4419)
		{
			MouseEvent mouseEvent = cd729d94a5b443ac0f1b117450e5f4419 as MouseEvent;
			if (mouseEvent == null)
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
			int buttonId = mouseEvent.buttonId;
			string text;
			if (buttonId == 1)
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
				text = c649b5d45cf350f685c56c4bd02800198.c36fc4e8f618164c0d61345dd0cc58fcb;
			}
			else
			{
				text = c649b5d45cf350f685c56c4bd02800198.cfb118d69d579b2fbde25fa8127b213f3;
			}
			string c2b4f43f34e21572af6ab4414f04cee = text;
			if (!cbf402c82d0fffee7c8f37c98e456b8f8)
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
				cb42dff485771448e06580bb8e8423337("down");
				c649b5d45cf350f685c56c4bd02800198 e = new c649b5d45cf350f685c56c4bd02800198(c2b4f43f34e21572af6ab4414f04cee, true, false, buttonId);
				dispatchEvent(e);
				return;
			}
		}

		protected void ca2c8ad477a1a8ef2c6efd2087707b4b0(CEvent cd729d94a5b443ac0f1b117450e5f4419)
		{
			MouseEvent mouseEvent = cd729d94a5b443ac0f1b117450e5f4419 as MouseEvent;
			if (mouseEvent == null)
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
			if (!cbf402c82d0fffee7c8f37c98e456b8f8)
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
			int buttonId = mouseEvent.buttonId;
			cb42dff485771448e06580bb8e8423337("release");
			if (buttonId == 1)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
					{
						c649b5d45cf350f685c56c4bd02800198 c3d202dee321219a80026dc3081fb3c = new c649b5d45cf350f685c56c4bd02800198(c649b5d45cf350f685c56c4bd02800198.c4c735ed0f7d81b376e20a84473c72a44, true, false, buttonId);
						cec642abaa4614915fda9fe47ce4414ab(c3d202dee321219a80026dc3081fb3c);
						return;
					}
					}
				}
			}
			c150a5f7ef9e027d1fbcbf9d51dd4bb8c();
			float time = Time.time;
			if (!(time - c80f319608c74f921612c6827ae99b036 > 0.2f))
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
				c649b5d45cf350f685c56c4bd02800198 c3d202dee321219a80026dc3081fb3c2 = new c649b5d45cf350f685c56c4bd02800198(MouseEvent.CLICK, true, false, buttonId);
				cec642abaa4614915fda9fe47ce4414ab(c3d202dee321219a80026dc3081fb3c2);
				c80f319608c74f921612c6827ae99b036 = time;
				return;
			}
		}

		protected void cc70aab67c07ea904f01f0513bb5e23db(CEvent cd729d94a5b443ac0f1b117450e5f4419)
		{
			MouseEvent mouseEvent = cd729d94a5b443ac0f1b117450e5f4419 as MouseEvent;
			if (mouseEvent == null)
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
			if (c0ffd7f3b3dfe86849f698f744e296ad3 == null)
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
			if (c0ffd7f3b3dfe86849f698f744e296ad3 != null)
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
				if (c0ffd7f3b3dfe86849f698f744e296ad3.contains(mouseEvent.target as DisplayObject))
				{
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
			int buttonId = mouseEvent.buttonId;
			if (buttonId != 0)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			c0ffd7f3b3dfe86849f698f744e296ad3.stage.removeEventListener(MouseEvent.MOUSE_UP, cc70aab67c07ea904f01f0513bb5e23db, false);
			c649b5d45cf350f685c56c4bd02800198 e = new c649b5d45cf350f685c56c4bd02800198(c649b5d45cf350f685c56c4bd02800198.ca402a9e0fe9df670714b50e5c72a12d0, true, false, buttonId);
			dispatchEvent(e);
			if (!cbf402c82d0fffee7c8f37c98e456b8f8)
			{
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
			if (!cb36f536645b2e8c5ed48e90b8357f0f9)
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
				cb42dff485771448e06580bb8e8423337("release");
				return;
			}
		}

		protected virtual void c150a5f7ef9e027d1fbcbf9d51dd4bb8c()
		{
			if (!c7012333eca6b837775bc288cc43ca1c4)
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
				if (c9c364a8fd1f013589fea518a3924e711)
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
					if (!ce84b930a12a1d06512c79320b3f0d3f4)
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
						break;
					}
				}
				c9c364a8fd1f013589fea518a3924e711 = !c9c364a8fd1f013589fea518a3924e711;
				return;
			}
		}

		protected void cb42dff485771448e06580bb8e8423337(string ca7b177d7a2c24bd047a7ade7e642aa4d)
		{
			c3ed0ad8a8d1c09345604daf49571678d = ca7b177d7a2c24bd047a7ade7e642aa4d;
			string[] array = cafeab66b1a29ea26a6d9fcb253394ddc();
			string[] array2 = c03901b649403b2006ecf0d01b1db1786[ca7b177d7a2c24bd047a7ade7e642aa4d];
			if (array2 == null)
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
				if (array2.Length == 0)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							return;
						}
					}
				}
				string[] array3 = array;
				foreach (string text in array3)
				{
					string[] array4 = array2;
					foreach (string text2 in array4)
					{
						string label = text + text2;
						if (c0ffd7f3b3dfe86849f698f744e296ad3.getFrameLabel(label) == 0)
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
							c4ba613640f8a02ea367516f0b9e2ed36 = label;
							c04940ea9c469b0f2ad16aed11e9f0ef8();
							return;
						}
					}
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							goto end_IL_00a4;
						}
						continue;
						end_IL_00a4:
						break;
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

		protected string[] cafeab66b1a29ea26a6d9fcb253394ddc()
		{
			string[] result;
			if (c3a7bb1f394b95e261698859f9998aa83)
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
				result = c92a176a56262a74108ced1a4010d1aa3;
			}
			else
			{
				result = c4c7526414579675a2ef5ea57c4341384;
			}
			return result;
		}
	}
}
