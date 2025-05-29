using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Serialization;
using A;

namespace BHV
{
	public class BHVTask
	{
		protected BHVTaskManager cfc241af7ab51814fc074e767be1a0bb8;

		[CompilerGenerated]
		private BHVTaskStatus cad8ddc5b41b01a832ec5ddc741cb08da;

		[CompilerGenerated]
		private BHVTaskType c5fe075289bed1dc3d3b7ce50f9864a6e;

		[CompilerGenerated]
		private BHVTaskLayer ca040becaab50c799785f266fb9d20a21;

		[XmlIgnore]
		public BHVTaskStatus m_Status
		{
			[CompilerGenerated]
			get
			{
				return cad8ddc5b41b01a832ec5ddc741cb08da;
			}
			[CompilerGenerated]
			set
			{
				cad8ddc5b41b01a832ec5ddc741cb08da = value;
			}
		}

		[XmlIgnore]
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

		[XmlIgnore]
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

		public BHVTask()
		{
			m_Status = BHVTaskStatus.INVALID;
			m_Type = BHVTaskType.INVALID;
			m_Layer = BHVTaskLayer.FULLBODY;
		}

		public virtual BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			throw new NotImplementedException();
		}

		public static bool cf874cd0b4372e0b1b284963141a5021c(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf, BHVTask cc0d456eb3f56f5d32d23620a7b525dcd)
		{
			int result;
			if (cdbade0534e8f60b8dbad77a5270d9acf.m_Type == cc0d456eb3f56f5d32d23620a7b525dcd.m_Type)
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
				result = ((cdbade0534e8f60b8dbad77a5270d9acf.m_Layer == cc0d456eb3f56f5d32d23620a7b525dcd.m_Layer) ? 1 : 0);
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}

		public virtual void ccc9d3a38966dc10fedb531ea17d24611(BHVTaskManager c9f936100770508e8acd275ff7c1d6641)
		{
			cfc241af7ab51814fc074e767be1a0bb8 = c9f936100770508e8acd275ff7c1d6641;
		}

		public virtual bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			bool flag = cf874cd0b4372e0b1b284963141a5021c(cdbade0534e8f60b8dbad77a5270d9acf, this);
			if (flag)
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
				if (cdbade0534e8f60b8dbad77a5270d9acf != null)
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
					cdbade0534e8f60b8dbad77a5270d9acf.c495597d24b447ad725643e71f5a54375();
				}
			}
			return flag;
		}

		public virtual void Start()
		{
			m_Status = BHVTaskStatus.RUNNING;
		}

		public virtual void Update(float deltaTime)
		{
		}

		public virtual void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(string.Empty);
			if (cdf3fed1b3e2fb4370b5db53be9c44580() != null)
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
				object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
				array[0] = m_Layer.ToString();
				array[1] = cdf3fed1b3e2fb4370b5db53be9c44580().m_UID.ToString();
				array[2] = m_Type.ToString();
				array[3] = m_Status.ToString();
				stringBuilder.Append(string.Format("    {0}: #{1} - Type:{2} - Status:{3}\n", array));
			}
			return stringBuilder.ToString();
		}
	}
}
