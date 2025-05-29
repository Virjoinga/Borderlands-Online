using A;
using UnityEngine;
using XsdSettings;
using pumpkin.display;

public class uniHUDFeedbackView : HUDFeedbackView
{
	private class SkageMeleePanel : c196099a1254db61d3be10d70e14e7422
	{
		protected MovieClip mcSelf;

		protected MovieClip mcPaw;

		protected MovieClip mcBite;

		protected MovieClip mcAxe;

		protected MovieClip mcClaw;

		protected Vector2 _PawOriPos;

		protected Vector2 _BiteOriPos;

		protected Vector2 _AxeOriPos;

		protected Vector2 _ClawOriPos;

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			mcPaw = ca37fcdce7d4937b60735f4033eb55695.getChildByName<MovieClip>("mcAttack1");
			mcBite = ca37fcdce7d4937b60735f4033eb55695.getChildByName<MovieClip>("mcAttack2");
			mcClaw = ca37fcdce7d4937b60735f4033eb55695.getChildByName<MovieClip>("mcAttack3");
			mcAxe = ca37fcdce7d4937b60735f4033eb55695.getChildByName<MovieClip>("mcAttack4");
			if (mcPaw != null)
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
				mcPaw.stop();
				_PawOriPos.x = mcPaw.x;
				_PawOriPos.y = mcPaw.y;
			}
			if (mcBite != null)
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
				mcBite.stop();
				_BiteOriPos.x = mcBite.x;
				_BiteOriPos.y = mcBite.y;
			}
			if (mcAxe != null)
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
				mcAxe.stop();
				_AxeOriPos.x = mcAxe.x;
				_AxeOriPos.y = mcAxe.y;
			}
			if (mcClaw == null)
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
				mcClaw.stop();
				_ClawOriPos.x = mcClaw.x;
				_ClawOriPos.y = mcClaw.y;
				return;
			}
		}

		public void cd8646cc0280a1c057b3796af4d282e84()
		{
			if (mcBite == null)
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
			if (mcBite.isPlaying)
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
			int num = Random.Range(-300, 100);
			int num2 = Random.Range(-400, 100);
			mcBite.x = _BiteOriPos.x + (float)num2;
			mcBite.y = _BiteOriPos.y + (float)num;
			mcBite.rotation = Random.Range(-45f, 45f);
			mcBite.gotoAndPlay("start");
		}

		public void ca8ea8a3ff05ed42349c0638293416142()
		{
			if (mcPaw == null)
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
			if (mcPaw.isPlaying)
			{
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
			int num = Random.Range(-50, 200);
			int num2 = Random.Range(-80, 100);
			mcPaw.x = _PawOriPos.x + (float)num2;
			mcPaw.y = _PawOriPos.y + (float)num;
			mcPaw.rotation = Random.Range(-10f, 10f);
			mcPaw.gotoAndPlay("start");
		}

		public void cad781e205fe445d83cc9dd8ae928c3ef()
		{
			if (mcAxe == null)
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
			if (mcAxe.isPlaying)
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
			int num = Random.Range(-50, 200);
			int num2 = Random.Range(-80, 100);
			mcAxe.x = _AxeOriPos.x + (float)num2;
			mcAxe.y = _AxeOriPos.y + (float)num;
			mcAxe.rotation = Random.Range(-10f, 10f);
			mcAxe.gotoAndPlay("start");
		}

		public void c790f5ecddce096d793668e4f636cc9db()
		{
			if (mcClaw == null)
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
			if (mcClaw.isPlaying)
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
			int num = Random.Range(-50, 200);
			int num2 = Random.Range(-80, 100);
			mcClaw.x = _ClawOriPos.x + (float)num2;
			mcClaw.y = _ClawOriPos.y + (float)num;
			mcClaw.rotation = Random.Range(-10f, 10f);
			mcClaw.gotoAndPlay("start");
		}
	}

	private class AttackFeedbackPanel : c196099a1254db61d3be10d70e14e7422
	{
		private const string SHIELD_NAME = "shield_";

		private const string HP_NAME = "dmg_";

		private const string FRAME_START = "fadein";

		private const string FRAME_END = "fadeout";

		private string[] _directMap;

		public AttackFeedbackPanel()
		{
			string[] array = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(4);
			array[0] = "u";
			array[1] = "d";
			array[2] = "l";
			array[3] = "r";
			_directMap = array;
			base._002Ector();
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			MovieClip c7088de59e49f7108f520cf7e0bae167e = c656b7be10c614ae4a7eb17c462d2f675.c7088de59e49f7108f520cf7e0bae167e;
			for (int i = 0; i < _directMap.Length; i++)
			{
				c7088de59e49f7108f520cf7e0bae167e = base.c89ef242f4744e0f1c4ffea4da8b79bc1.getChildByName<MovieClip>("shield_" + _directMap[i]);
				if (c7088de59e49f7108f520cf7e0bae167e != null)
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
					c7088de59e49f7108f520cf7e0bae167e.stop();
				}
				c7088de59e49f7108f520cf7e0bae167e = base.c89ef242f4744e0f1c4ffea4da8b79bc1.getChildByName<MovieClip>("dmg_" + _directMap[i]);
				if (c7088de59e49f7108f520cf7e0bae167e == null)
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
				c7088de59e49f7108f520cf7e0bae167e.stop();
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

		public void c0e3f77bf0be2b3f0e55911072aee6430(Direction c1a9559709f1b5e7a60a6a0bfbcee7536)
		{
			MovieClip childByName = base.c89ef242f4744e0f1c4ffea4da8b79bc1.getChildByName<MovieClip>("shield_" + _directMap[(int)c1a9559709f1b5e7a60a6a0bfbcee7536]);
			if (childByName == null)
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
				childByName.gotoAndPlay("fadein");
				return;
			}
		}

		public void ccc3a4e4ffdac3e7fcb5f35e5012c37ae(Direction c1a9559709f1b5e7a60a6a0bfbcee7536)
		{
			MovieClip childByName = base.c89ef242f4744e0f1c4ffea4da8b79bc1.getChildByName<MovieClip>("dmg_" + _directMap[(int)c1a9559709f1b5e7a60a6a0bfbcee7536]);
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
				childByName.gotoAndPlay("fadein");
				return;
			}
		}
	}

	private AttackFeedbackPanel _feedBackPanel;

	private SkageMeleePanel _skageMeleePanel;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("Skages_melee.swf", "Panel_Damage", c1141a8fde9aa0f410bc4a7fdd2e3ef7c);
	}

	private void c1141a8fde9aa0f410bc4a7fdd2e3ef7c(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		float c9d16e16b57deb9bb1da907451ba1f25b = 0f;
		float c5ebdc65d5cb420faf7ba524809963aa;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c24a0f2b5695dcd950edb79b1830693f9(out c5ebdc65d5cb420faf7ba524809963aa, out c9d16e16b57deb9bb1da907451ba1f25b);
		_feedBackPanel = new AttackFeedbackPanel();
		cbe9ca8ddb3cdc2312e6ff8411b2db2c8.x = c5ebdc65d5cb420faf7ba524809963aa;
		cbe9ca8ddb3cdc2312e6ff8411b2db2c8.y = c9d16e16b57deb9bb1da907451ba1f25b;
		_feedBackPanel.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c848674781d88e6f4b9eb89ca2b6f4610(_feedBackPanel);
		_skageMeleePanel = new SkageMeleePanel();
		MovieClip movieClip = new MovieClip("Skages_melee.swf:Panel_Skage_Melee");
		movieClip.x = c5ebdc65d5cb420faf7ba524809963aa;
		movieClip.y = c9d16e16b57deb9bb1da907451ba1f25b;
		_skageMeleePanel.c130648b59a0c8debea60aa153f844879(movieClip);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c848674781d88e6f4b9eb89ca2b6f4610(_skageMeleePanel);
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_skageMeleePanel);
		_skageMeleePanel = null;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_feedBackPanel);
		_feedBackPanel = null;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("Skages_melee.swf");
	}

	public override void ca9e5e4b6111ffdc3b0b4d8368c5c2046(DamageInfo c7a58c08f49a0d62fda3d0fda4b15109a)
	{
		base.ca9e5e4b6111ffdc3b0b4d8368c5c2046(c7a58c08f49a0d62fda3d0fda4b15109a);
		switch (c7a58c08f49a0d62fda3d0fda4b15109a.m_attackSubType)
		{
		case AttackSubType.MeleeBite:
			_skageMeleePanel.cd8646cc0280a1c057b3796af4d282e84();
			break;
		case AttackSubType.MeleePaw:
			_skageMeleePanel.ca8ea8a3ff05ed42349c0638293416142();
			break;
		case AttackSubType.MeleeAxe:
			_skageMeleePanel.cad781e205fe445d83cc9dd8ae928c3ef();
			break;
		case AttackSubType.MeleeClaw:
			_skageMeleePanel.c790f5ecddce096d793668e4f636cc9db();
			break;
		}
	}

	protected override void c0e3f77bf0be2b3f0e55911072aee6430(Direction c1a9559709f1b5e7a60a6a0bfbcee7536)
	{
		_feedBackPanel.c0e3f77bf0be2b3f0e55911072aee6430(c1a9559709f1b5e7a60a6a0bfbcee7536);
		c703c5fded04cda53a7b6b36f5ca11a10.c5ee19dc8d4cccf5ae2de225410458b86.ceb41162a7cd2a1d5c4a03830e02b4198.c462fe1a64a37daab5e61f688d9a61e7f("Chr_Shr_Shield_Impact_Rnd");
	}

	protected override void ccc3a4e4ffdac3e7fcb5f35e5012c37ae(Direction c1a9559709f1b5e7a60a6a0bfbcee7536)
	{
		_feedBackPanel.ccc3a4e4ffdac3e7fcb5f35e5012c37ae(c1a9559709f1b5e7a60a6a0bfbcee7536);
		c06ca0e618478c23eba3419653a19760f<AudioManager>.c5ee19dc8d4cccf5ae2de225410458b86.cd366b61ae0481f13c86f0ddbf0a11b55("Chr_Hurt_Rnd");
	}
}
