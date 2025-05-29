using System.Collections.Generic;
using UnityEngine;
using XsdSettings;

namespace A
{
	internal class c18cee71b120332e4267d3dd92c1d4a41 : c42fd94d5e4ecc5b63c9599a942b208fe
	{
		private int c55a3e1c9cf6d5ed0ed32a652f3c8ad99;

		protected override void cb396a7a5471504026c466f04f6bf5543()
		{
			AvatarType c2bfb3fe48ffea6949a5d0843b8d4e = (AvatarType)Random.Range(0, 4);
			c06ca0e618478c23eba3419653a19760f<AutoTestManager>.c5ee19dc8d4cccf5ae2de225410458b86.StartCoroutine(AutoTestUtility.c88bf190f463b6c67167742aa8dae7509(c2bfb3fe48ffea6949a5d0843b8d4e));
		}

		protected override void cc50a91c65114be893ed477cd81b8f8bb()
		{
			c60b02bdf837d0489317f1a34b8e80071 = true;
		}

		protected void c2978e4d619055f2147c72ca94df6715a(int ceaa76a1629d9c1cce1f363253816ebda)
		{
			if (c55a3e1c9cf6d5ed0ed32a652f3c8ad99++ % 10 != 0)
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
				Session c5ee19dc8d4cccf5ae2de225410458b = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86;
				if (c5ee19dc8d4cccf5ae2de225410458b != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					List<PlayerInfoSync> c9c8de68aa0982db2bbd496692c37e;
					c5ee19dc8d4cccf5ae2de225410458b.c7822eacaa3505f8c170e4316704ac984(out c9c8de68aa0982db2bbd496692c37e);
					if (c9c8de68aa0982db2bbd496692c37e.Count >= ceaa76a1629d9c1cce1f363253816ebda)
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
						GameObject gameObject = GameObject.Find("/AppManager/Entities");
						GameObject gameObject2 = GameObject.Find("FpsCamera(Clone)");
						if (gameObject2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							if (gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
								c5bc8bb6c6b44d3d5bf9249765a5d8e27(true, string.Empty);
							}
						}
					}
				}
				if (!(base.m_timeElapsed >= 80f))
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
					c5bc8bb6c6b44d3d5bf9249765a5d8e27(false, string.Empty);
					return;
				}
			}
		}
	}
}
