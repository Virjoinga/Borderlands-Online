using UnityEngine;

namespace BHV
{
	public sealed class BHVTaskParamSync
	{
		public class Data
		{
			public BHVTaskType c9fcab9b0afd057008dc16bd60a2c543a;

			public BHVTaskLayer c204f05b35b1a1f7c7e73b5d38cbc1a5b;

			public int c98eaa1ce1a69490d1c0adebfc5365925;

			public bool c2c95b61a790880f15fa36108f89c3d5d;

			public CoverSlot.CoverHeight c717e5cc6398513ae1b501fafdc23be53;

			public BHVFireStyle c7e51fddad5ba955e865c93444ce9bf84;

			public BHVStance cabd31980fc78efe17153b1acf216a763;

			public BHVStressLevel c49fa7495bf59da1fbd770224875a9971;

			public BHVMovementSpeed c034f614b05c66464092b15f427ea086d;

			public AnimationStateFSM cd4c6f5bc0ffba00956fa80fc2758673f;

			public float c8d6d0618a619c5377bfa2192b652bb59;

			public int caa1b18212b31f179824db0c752e81263;

			public int c4dc17c8c736f97081413efcc43072ab4;

			public int c53325e7ea8d9b49f3e07c9ded47fa5f6;

			public Vector3 cc42106392aa3350c9aa3f1157cd1bce4;

			public Vector3 c86de8be02f13b9351daaa3dee22fedd1;

			public Vector3 c1d766887e94dca7977e3a4b88558c892;

			public bool c690ae2dd8233a5203502a2edad03714b;

			public bool ccab717fa769c738ea9dcdf8b3947ebaa;

			public bool c937a4043abfbb9e35551be34a32d3f73;

			public int ced9a270aeae5659c2bbbc8d0499be56c;

			public void Reset()
			{
				c98eaa1ce1a69490d1c0adebfc5365925 = -1;
				c9fcab9b0afd057008dc16bd60a2c543a = BHVTaskType.INVALID;
				c2c95b61a790880f15fa36108f89c3d5d = false;
				c204f05b35b1a1f7c7e73b5d38cbc1a5b = BHVTaskLayer.INVALID;
				c717e5cc6398513ae1b501fafdc23be53 = CoverSlot.CoverHeight.INVALID;
				c7e51fddad5ba955e865c93444ce9bf84 = BHVFireStyle.INVALID;
				cabd31980fc78efe17153b1acf216a763 = BHVStance.INVALID;
				c49fa7495bf59da1fbd770224875a9971 = BHVStressLevel.INVALID;
				c034f614b05c66464092b15f427ea086d = BHVMovementSpeed.INVALID;
				cd4c6f5bc0ffba00956fa80fc2758673f = AnimationStateFSM.Invalid;
				c8d6d0618a619c5377bfa2192b652bb59 = -1f;
				caa1b18212b31f179824db0c752e81263 = -1;
				c4dc17c8c736f97081413efcc43072ab4 = -1;
				c53325e7ea8d9b49f3e07c9ded47fa5f6 = -1;
				c690ae2dd8233a5203502a2edad03714b = false;
				ccab717fa769c738ea9dcdf8b3947ebaa = false;
				c937a4043abfbb9e35551be34a32d3f73 = false;
				ced9a270aeae5659c2bbbc8d0499be56c = 0;
			}

			internal bool c943bc6a18586b3e0e6f0214717aca479()
			{
				return c9fcab9b0afd057008dc16bd60a2c543a != BHVTaskType.INVALID;
			}

			internal void c21abc56059d171e999147f26bbf75889(PhotonStream c4f572e677246eb1a0cf92afc8682dc7b)
			{
				if (c4f572e677246eb1a0cf92afc8682dc7b.c8b2526be2638bb30a29ab8314b369311)
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
							c4f572e677246eb1a0cf92afc8682dc7b.caf7283cc5cd9725a88a9cdfa630d92f8(c98eaa1ce1a69490d1c0adebfc5365925);
							c4f572e677246eb1a0cf92afc8682dc7b.caf7283cc5cd9725a88a9cdfa630d92f8(c9fcab9b0afd057008dc16bd60a2c543a);
							c4f572e677246eb1a0cf92afc8682dc7b.caf7283cc5cd9725a88a9cdfa630d92f8(c204f05b35b1a1f7c7e73b5d38cbc1a5b);
							c4f572e677246eb1a0cf92afc8682dc7b.caf7283cc5cd9725a88a9cdfa630d92f8(c2c95b61a790880f15fa36108f89c3d5d);
							c4f572e677246eb1a0cf92afc8682dc7b.caf7283cc5cd9725a88a9cdfa630d92f8(c717e5cc6398513ae1b501fafdc23be53);
							c4f572e677246eb1a0cf92afc8682dc7b.caf7283cc5cd9725a88a9cdfa630d92f8(c7e51fddad5ba955e865c93444ce9bf84);
							c4f572e677246eb1a0cf92afc8682dc7b.caf7283cc5cd9725a88a9cdfa630d92f8(cabd31980fc78efe17153b1acf216a763);
							c4f572e677246eb1a0cf92afc8682dc7b.caf7283cc5cd9725a88a9cdfa630d92f8(c49fa7495bf59da1fbd770224875a9971);
							c4f572e677246eb1a0cf92afc8682dc7b.caf7283cc5cd9725a88a9cdfa630d92f8(c034f614b05c66464092b15f427ea086d);
							c4f572e677246eb1a0cf92afc8682dc7b.caf7283cc5cd9725a88a9cdfa630d92f8(cd4c6f5bc0ffba00956fa80fc2758673f);
							c4f572e677246eb1a0cf92afc8682dc7b.caf7283cc5cd9725a88a9cdfa630d92f8(c8d6d0618a619c5377bfa2192b652bb59);
							c4f572e677246eb1a0cf92afc8682dc7b.caf7283cc5cd9725a88a9cdfa630d92f8(caa1b18212b31f179824db0c752e81263);
							c4f572e677246eb1a0cf92afc8682dc7b.caf7283cc5cd9725a88a9cdfa630d92f8(c4dc17c8c736f97081413efcc43072ab4);
							c4f572e677246eb1a0cf92afc8682dc7b.caf7283cc5cd9725a88a9cdfa630d92f8(c53325e7ea8d9b49f3e07c9ded47fa5f6);
							c4f572e677246eb1a0cf92afc8682dc7b.caf7283cc5cd9725a88a9cdfa630d92f8(c690ae2dd8233a5203502a2edad03714b);
							c4f572e677246eb1a0cf92afc8682dc7b.caf7283cc5cd9725a88a9cdfa630d92f8(ccab717fa769c738ea9dcdf8b3947ebaa);
							c4f572e677246eb1a0cf92afc8682dc7b.caf7283cc5cd9725a88a9cdfa630d92f8(c937a4043abfbb9e35551be34a32d3f73);
							c4f572e677246eb1a0cf92afc8682dc7b.caf7283cc5cd9725a88a9cdfa630d92f8(cc42106392aa3350c9aa3f1157cd1bce4);
							c4f572e677246eb1a0cf92afc8682dc7b.caf7283cc5cd9725a88a9cdfa630d92f8(c86de8be02f13b9351daaa3dee22fedd1);
							c4f572e677246eb1a0cf92afc8682dc7b.caf7283cc5cd9725a88a9cdfa630d92f8(c1d766887e94dca7977e3a4b88558c892);
							c4f572e677246eb1a0cf92afc8682dc7b.caf7283cc5cd9725a88a9cdfa630d92f8(ced9a270aeae5659c2bbbc8d0499be56c);
							return;
						}
					}
				}
				c98eaa1ce1a69490d1c0adebfc5365925 = (int)c4f572e677246eb1a0cf92afc8682dc7b.cbc3e6f46d26c8fb00a98f05fc700248a();
				c9fcab9b0afd057008dc16bd60a2c543a = (BHVTaskType)(int)c4f572e677246eb1a0cf92afc8682dc7b.cbc3e6f46d26c8fb00a98f05fc700248a();
				c204f05b35b1a1f7c7e73b5d38cbc1a5b = (BHVTaskLayer)(int)c4f572e677246eb1a0cf92afc8682dc7b.cbc3e6f46d26c8fb00a98f05fc700248a();
				c2c95b61a790880f15fa36108f89c3d5d = (bool)c4f572e677246eb1a0cf92afc8682dc7b.cbc3e6f46d26c8fb00a98f05fc700248a();
				c717e5cc6398513ae1b501fafdc23be53 = (CoverSlot.CoverHeight)(int)c4f572e677246eb1a0cf92afc8682dc7b.cbc3e6f46d26c8fb00a98f05fc700248a();
				c7e51fddad5ba955e865c93444ce9bf84 = (BHVFireStyle)(int)c4f572e677246eb1a0cf92afc8682dc7b.cbc3e6f46d26c8fb00a98f05fc700248a();
				cabd31980fc78efe17153b1acf216a763 = (BHVStance)(int)c4f572e677246eb1a0cf92afc8682dc7b.cbc3e6f46d26c8fb00a98f05fc700248a();
				c49fa7495bf59da1fbd770224875a9971 = (BHVStressLevel)(int)c4f572e677246eb1a0cf92afc8682dc7b.cbc3e6f46d26c8fb00a98f05fc700248a();
				c034f614b05c66464092b15f427ea086d = (BHVMovementSpeed)(int)c4f572e677246eb1a0cf92afc8682dc7b.cbc3e6f46d26c8fb00a98f05fc700248a();
				cd4c6f5bc0ffba00956fa80fc2758673f = (AnimationStateFSM)(int)c4f572e677246eb1a0cf92afc8682dc7b.cbc3e6f46d26c8fb00a98f05fc700248a();
				c8d6d0618a619c5377bfa2192b652bb59 = (float)c4f572e677246eb1a0cf92afc8682dc7b.cbc3e6f46d26c8fb00a98f05fc700248a();
				caa1b18212b31f179824db0c752e81263 = (int)c4f572e677246eb1a0cf92afc8682dc7b.cbc3e6f46d26c8fb00a98f05fc700248a();
				c4dc17c8c736f97081413efcc43072ab4 = (int)c4f572e677246eb1a0cf92afc8682dc7b.cbc3e6f46d26c8fb00a98f05fc700248a();
				c53325e7ea8d9b49f3e07c9ded47fa5f6 = (int)c4f572e677246eb1a0cf92afc8682dc7b.cbc3e6f46d26c8fb00a98f05fc700248a();
				c690ae2dd8233a5203502a2edad03714b = (bool)c4f572e677246eb1a0cf92afc8682dc7b.cbc3e6f46d26c8fb00a98f05fc700248a();
				ccab717fa769c738ea9dcdf8b3947ebaa = (bool)c4f572e677246eb1a0cf92afc8682dc7b.cbc3e6f46d26c8fb00a98f05fc700248a();
				c937a4043abfbb9e35551be34a32d3f73 = (bool)c4f572e677246eb1a0cf92afc8682dc7b.cbc3e6f46d26c8fb00a98f05fc700248a();
				cc42106392aa3350c9aa3f1157cd1bce4 = (Vector3)c4f572e677246eb1a0cf92afc8682dc7b.cbc3e6f46d26c8fb00a98f05fc700248a();
				c86de8be02f13b9351daaa3dee22fedd1 = (Vector3)c4f572e677246eb1a0cf92afc8682dc7b.cbc3e6f46d26c8fb00a98f05fc700248a();
				c1d766887e94dca7977e3a4b88558c892 = (Vector3)c4f572e677246eb1a0cf92afc8682dc7b.cbc3e6f46d26c8fb00a98f05fc700248a();
				ced9a270aeae5659c2bbbc8d0499be56c = (int)c4f572e677246eb1a0cf92afc8682dc7b.cbc3e6f46d26c8fb00a98f05fc700248a();
			}
		}

		public Data cbfdd09e23f07797bcbd0a2c7c5a5c717;

		public BHVTaskParamSync()
		{
			cbfdd09e23f07797bcbd0a2c7c5a5c717 = new Data();
			cbfdd09e23f07797bcbd0a2c7c5a5c717.Reset();
		}

		internal bool c943bc6a18586b3e0e6f0214717aca479()
		{
			int result;
			if (cbfdd09e23f07797bcbd0a2c7c5a5c717 != null)
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
				result = (cbfdd09e23f07797bcbd0a2c7c5a5c717.c943bc6a18586b3e0e6f0214717aca479() ? 1 : 0);
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}

		internal void c21abc56059d171e999147f26bbf75889(PhotonStream c4f572e677246eb1a0cf92afc8682dc7b)
		{
			if (cbfdd09e23f07797bcbd0a2c7c5a5c717 == null)
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
				cbfdd09e23f07797bcbd0a2c7c5a5c717.c21abc56059d171e999147f26bbf75889(c4f572e677246eb1a0cf92afc8682dc7b);
				return;
			}
		}

		internal BHVTaskParam cefa2d3e106cf4ac2c9aa4706d7b89260()
		{
			if (c943bc6a18586b3e0e6f0214717aca479())
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
				BHVTaskParam bHVTaskParam = BHVTaskParam.c2e7396c0f3335f5ab21913f26ee80bc8(cbfdd09e23f07797bcbd0a2c7c5a5c717.c9fcab9b0afd057008dc16bd60a2c543a);
				if (bHVTaskParam != null)
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							bHVTaskParam.c21abc56059d171e999147f26bbf75889(ref cbfdd09e23f07797bcbd0a2c7c5a5c717, false);
							return bHVTaskParam;
						}
					}
				}
			}
			return null;
		}
	}
}
