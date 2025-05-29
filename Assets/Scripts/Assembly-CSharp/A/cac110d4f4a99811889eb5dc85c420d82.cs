using Core;

namespace A
{
	public class cac110d4f4a99811889eb5dc85c420d82
	{
		private int ca1f36842e9ce493c20001e0671b7cd15;

		private c2597280f86604f98f89309a4de95dd62 cbedd54868e0b17bc946103f5c90446f1 = c2597280f86604f98f89309a4de95dd62.Success;

		public float c8d33f2e7558bca950c40f30d01315401;

		public float c92c7f03b81b92c00ce0b49a2b9058106;

		public cac110d4f4a99811889eb5dc85c420d82()
		{
			ca1f36842e9ce493c20001e0671b7cd15 = c06ca0e618478c23eba3419653a19760f<cc3d8f9888524f253f9d1a8618103803b>.c5ee19dc8d4cccf5ae2de225410458b86.c546b078517bbddc588c60bba985ab09c();
		}

		public int ca632e188a7ed5dd870769fd22c125ebc()
		{
			return ca1f36842e9ce493c20001e0671b7cd15;
		}

		public virtual void Start()
		{
			c27b389b7bd08230f8586d5ac4896cc41(c2597280f86604f98f89309a4de95dd62.Proceeding);
		}

		public bool c762acfd9de32c566fab82e7bbfb0e93f()
		{
			return ccbba85a67aa095895787b6d432c194b3() != c2597280f86604f98f89309a4de95dd62.Proceeding;
		}

		public virtual void Update(float time)
		{
			if (!(c92c7f03b81b92c00ce0b49a2b9058106 > 0f))
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
				if (!(time - c8d33f2e7558bca950c40f30d01315401 > c92c7f03b81b92c00ce0b49a2b9058106))
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
					DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Framework, GetType().ToString() + "[AsyncTaskResult.Error_Timeout]");
					c27b389b7bd08230f8586d5ac4896cc41(c2597280f86604f98f89309a4de95dd62.Error_Timeout);
					return;
				}
			}
		}

		public virtual void cdada4c3678c9c23c38aaf0754a94a620()
		{
		}

		protected void c27b389b7bd08230f8586d5ac4896cc41(c2597280f86604f98f89309a4de95dd62 c72943404493c5c9abc349e4b65bfe91b)
		{
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, GetType().ToString() + "[" + c72943404493c5c9abc349e4b65bfe91b.ToString() + "]");
			cbedd54868e0b17bc946103f5c90446f1 = c72943404493c5c9abc349e4b65bfe91b;
		}

		public c2597280f86604f98f89309a4de95dd62 ccbba85a67aa095895787b6d432c194b3()
		{
			return cbedd54868e0b17bc946103f5c90446f1;
		}
	}
}
