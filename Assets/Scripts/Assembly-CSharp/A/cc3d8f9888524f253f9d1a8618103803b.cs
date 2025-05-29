using System;
using System.Collections.Generic;
using UnityEngine;

namespace A
{
	public class cc3d8f9888524f253f9d1a8618103803b : c06ca0e618478c23eba3419653a19760f<cc3d8f9888524f253f9d1a8618103803b>
	{
		public static int c4d1fdfc31b9d037625e277af1c39273b = 3;

		private static int cb8314e9121686bb7b4adeef0d396be74;

		private List<Pair<cac110d4f4a99811889eb5dc85c420d82, c8d81d95cb783eac2dfad3c9ecd8f86ca>> cfd53921997de5244b61493e0560f73f9 = new List<Pair<cac110d4f4a99811889eb5dc85c420d82, c8d81d95cb783eac2dfad3c9ecd8f86ca>>();

		private Dictionary<Type, int> c65d1bea7b845438980e3f90abf4701b5 = new Dictionary<Type, int>();

		private List<Pair<cac110d4f4a99811889eb5dc85c420d82, c8d81d95cb783eac2dfad3c9ecd8f86ca>> c1cee3f4c65a06baaee709b598ec1fdcd = new List<Pair<cac110d4f4a99811889eb5dc85c420d82, c8d81d95cb783eac2dfad3c9ecd8f86ca>>();

		public int c546b078517bbddc588c60bba985ab09c()
		{
			return cb8314e9121686bb7b4adeef0d396be74++;
		}

		public void c7a2810eafd8052b783f9446b7d4c9494(cac110d4f4a99811889eb5dc85c420d82 cc0d456eb3f56f5d32d23620a7b525dcd, c8d81d95cb783eac2dfad3c9ecd8f86ca c2db84530ef366a6deb001d449d4aa151 = null)
		{
			cc0d456eb3f56f5d32d23620a7b525dcd.c8d33f2e7558bca950c40f30d01315401 = Time.time;
			cc0d456eb3f56f5d32d23620a7b525dcd.Start();
			cfd53921997de5244b61493e0560f73f9.Add(new Pair<cac110d4f4a99811889eb5dc85c420d82, c8d81d95cb783eac2dfad3c9ecd8f86ca>(cc0d456eb3f56f5d32d23620a7b525dcd, c2db84530ef366a6deb001d449d4aa151));
		}

		public int cfbe783a80499212c9287a449e44179c6()
		{
			return cfd53921997de5244b61493e0560f73f9.Count;
		}

		public bool cc7546c39b55f02aaff02b116c0479818<c272566d4edbf24bb8c4df6114a524ac9>()
		{
			for (int i = 0; i < cfd53921997de5244b61493e0560f73f9.Count; i++)
			{
				if (cfd53921997de5244b61493e0560f73f9[i].GetType() != typeof(c272566d4edbf24bb8c4df6114a524ac9))
				{
					continue;
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
					return true;
				}
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				return false;
			}
		}

		private void Update()
		{
			c1cee3f4c65a06baaee709b598ec1fdcd.Clear();
			float time = Time.time;
			for (int i = 0; i < cfd53921997de5244b61493e0560f73f9.Count; i++)
			{
				cfd53921997de5244b61493e0560f73f9[i].Left.Update(time);
				if (!cfd53921997de5244b61493e0560f73f9[i].Left.c762acfd9de32c566fab82e7bbfb0e93f())
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (cfd53921997de5244b61493e0560f73f9[i].Left.ccbba85a67aa095895787b6d432c194b3() != c2597280f86604f98f89309a4de95dd62.Success)
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
					int value = 1;
					if (c65d1bea7b845438980e3f90abf4701b5.TryGetValue(cfd53921997de5244b61493e0560f73f9[i].Left.GetType(), out value))
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
						c65d1bea7b845438980e3f90abf4701b5[cfd53921997de5244b61493e0560f73f9[i].Left.GetType()] = value + 1;
					}
					else
					{
						c65d1bea7b845438980e3f90abf4701b5.Add(cfd53921997de5244b61493e0560f73f9[i].Left.GetType(), value);
					}
				}
				else
				{
					c65d1bea7b845438980e3f90abf4701b5.Remove(cfd53921997de5244b61493e0560f73f9[i].Left.GetType());
				}
				if (cfd53921997de5244b61493e0560f73f9[i].Right != null)
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
					cfd53921997de5244b61493e0560f73f9[i].Right(cfd53921997de5244b61493e0560f73f9[i].Left, cfd53921997de5244b61493e0560f73f9[i].Left.ccbba85a67aa095895787b6d432c194b3());
				}
				c1cee3f4c65a06baaee709b598ec1fdcd.Add(cfd53921997de5244b61493e0560f73f9[i]);
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				for (int j = 0; j < c1cee3f4c65a06baaee709b598ec1fdcd.Count; j++)
				{
					cfd53921997de5244b61493e0560f73f9.Remove(c1cee3f4c65a06baaee709b598ec1fdcd[j]);
				}
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

		public int c510e6568d214058bf0da03967a0dfa78(Type c2b4f43f34e21572af6ab4414f04cee36)
		{
			int value = 0;
			c65d1bea7b845438980e3f90abf4701b5.TryGetValue(c2b4f43f34e21572af6ab4414f04cee36, out value);
			return value;
		}

		public bool c3baaa4a6dea0fa0c8840ad6ec2f669bb(Type c2b4f43f34e21572af6ab4414f04cee36)
		{
			return c510e6568d214058bf0da03967a0dfa78(c2b4f43f34e21572af6ab4414f04cee36) > c4d1fdfc31b9d037625e277af1c39273b;
		}

		public void c7a17840ca5832714e97cc912e5552600(Type c2b4f43f34e21572af6ab4414f04cee36)
		{
			c65d1bea7b845438980e3f90abf4701b5.Remove(c2b4f43f34e21572af6ab4414f04cee36);
		}
	}
}
