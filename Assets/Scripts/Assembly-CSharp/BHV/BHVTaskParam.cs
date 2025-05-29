using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using A;
using Core;
using UnityEngine;

namespace BHV
{
	public abstract class BHVTaskParam
	{
		public const int c7ec8196829c2c29c71d27dfa8d80260d = -1;

		public const int c2c0425ba9f4ff2eef7ec710121fb04aa = -1;

		public bool c2c95b61a790880f15fa36108f89c3d5d;

		[CompilerGenerated]
		private BHVTaskType c5fe075289bed1dc3d3b7ce50f9864a6e;

		[CompilerGenerated]
		private BHVTaskLayer ca040becaab50c799785f266fb9d20a21;

		[CompilerGenerated]
		private int c6b547746d6ac894efada8f3e94d70ec7;

		public BHVTaskType m_Type
		{
			[CompilerGenerated]
			get
			{
				return c5fe075289bed1dc3d3b7ce50f9864a6e;
			}
			[CompilerGenerated]
			protected set
			{
				c5fe075289bed1dc3d3b7ce50f9864a6e = value;
			}
		}

		public BHVTaskLayer m_Layer
		{
			[CompilerGenerated]
			get
			{
				return ca040becaab50c799785f266fb9d20a21;
			}
			[CompilerGenerated]
			protected set
			{
				ca040becaab50c799785f266fb9d20a21 = value;
			}
		}

		public int m_UID
		{
			[CompilerGenerated]
			get
			{
				return c6b547746d6ac894efada8f3e94d70ec7;
			}
			[CompilerGenerated]
			set
			{
				c6b547746d6ac894efada8f3e94d70ec7 = value;
			}
		}

		public BHVTaskParam()
		{
			m_Type = BHVTaskType.INVALID;
			m_Layer = BHVTaskLayer.FULLBODY;
			m_UID = -1;
			c2c95b61a790880f15fa36108f89c3d5d = false;
		}

		public virtual void c495597d24b447ad725643e71f5a54375()
		{
		}

		public virtual void c9e0f906b8d383cc92cdc6bfdc3266fc2()
		{
		}

		public virtual void c21abc56059d171e999147f26bbf75889(ref BHVTaskParamSync.Data c90756c75001df916758775f95eee6676, bool ca0a690ca94fac43f6d2dd7209319634b)
		{
			if (ca0a690ca94fac43f6d2dd7209319634b)
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
						c90756c75001df916758775f95eee6676.c98eaa1ce1a69490d1c0adebfc5365925 = m_UID;
						c90756c75001df916758775f95eee6676.c9fcab9b0afd057008dc16bd60a2c543a = m_Type;
						c90756c75001df916758775f95eee6676.c204f05b35b1a1f7c7e73b5d38cbc1a5b = m_Layer;
						c90756c75001df916758775f95eee6676.c2c95b61a790880f15fa36108f89c3d5d = c2c95b61a790880f15fa36108f89c3d5d;
						return;
					}
				}
			}
			m_UID = c90756c75001df916758775f95eee6676.c98eaa1ce1a69490d1c0adebfc5365925;
			m_Type = c90756c75001df916758775f95eee6676.c9fcab9b0afd057008dc16bd60a2c543a;
			m_Layer = c90756c75001df916758775f95eee6676.c204f05b35b1a1f7c7e73b5d38cbc1a5b;
			c2c95b61a790880f15fa36108f89c3d5d = c90756c75001df916758775f95eee6676.c2c95b61a790880f15fa36108f89c3d5d;
		}

		protected static GameObject ce24b6cf07e186720ddf2f0f5b8e36db5(int ce57f12a4f7e693a5fe0c4049dc56fa7c)
		{
			if (ce57f12a4f7e693a5fe0c4049dc56fa7c != -1)
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
				BadAssNetworkView badAssNetworkView = BadAssNetworkView.c16cef725419dd5314991ac769ad60eb9(ce57f12a4f7e693a5fe0c4049dc56fa7c);
				if (badAssNetworkView != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							return badAssNetworkView.gameObject;
						}
					}
				}
			}
			return null;
		}

		protected static int cc06b80e952247ccc25281196351a06ea(GameObject c80822505abd04406a7a821211bd77371)
		{
			if (c80822505abd04406a7a821211bd77371 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				Entity component = c80822505abd04406a7a821211bd77371.GetComponent<Entity>();
				if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							return component.cc7403315505256d19a7b92aa614a8f10();
						}
					}
				}
			}
			return -1;
		}

		public static BHVTaskParam cceebb370c5d2f0dd37b8469ac0588298(string c722bbf4e7852fee91180e7106e87ab88)
		{
			BHVTaskParam c7088de59e49f7108f520cf7e0bae167e = c85f33439c924baf0c818a8ff3c1dfbc3.c7088de59e49f7108f520cf7e0bae167e;
			try
			{
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				Type type = executingAssembly.GetType("BHV.BHVTaskParam" + c722bbf4e7852fee91180e7106e87ab88);
				return (BHVTaskParam)Activator.CreateInstance(type);
			}
			catch (Exception ex)
			{
				DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.AI, ex.ToString() + " " + c722bbf4e7852fee91180e7106e87ab88);
				return c85f33439c924baf0c818a8ff3c1dfbc3.c7088de59e49f7108f520cf7e0bae167e;
			}
		}

		public static BHVTaskParam c2e7396c0f3335f5ab21913f26ee80bc8(BHVTaskType c82da4aba736860aef1c9db1e5d8d1a58)
		{
			return cceebb370c5d2f0dd37b8469ac0588298(c82da4aba736860aef1c9db1e5d8d1a58.ToString());
		}
	}
}
