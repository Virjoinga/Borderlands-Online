using System;
using Core;
using UnityEngine;
using XsdSettings;

namespace A
{
	internal class cf4a7aba28a67375f2701f02e7d10f3ac : c42fd94d5e4ecc5b63c9599a942b208fe
	{
		private int cad6bce5c5701428b1bd1c9ff3c7f72a8 = -1;

		private cba4c10d24396bf9e556e061418d97837 ce486bbb7b72a128ad5409b92e2eda813 = new cba4c10d24396bf9e556e061418d97837();

		private float c6f67d4d05e2cc6025551586db1449f54;

		public int c92d39090ca44def0a7613356508e3e37()
		{
			if (cad6bce5c5701428b1bd1c9ff3c7f72a8 < 0)
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
				string environmentVariable = Environment.GetEnvironmentVariable("maxplayer");
				cad6bce5c5701428b1bd1c9ff3c7f72a8 = int.Parse(environmentVariable);
			}
			return cad6bce5c5701428b1bd1c9ff3c7f72a8;
		}

		private void c46753de6739a2dc647f5abab06259a00()
		{
			if (!(c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c64f58cc60811857c739035f7a63f475c() != 0)
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
					break;
				}
			}
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Autotest, "Reconnect");
			AvatarType c2bfb3fe48ffea6949a5d0843b8d4e = (AvatarType)UnityEngine.Random.Range(0, 4);
			c06ca0e618478c23eba3419653a19760f<AutoTestManager>.c5ee19dc8d4cccf5ae2de225410458b86.StartCoroutine(AutoTestUtility.c88bf190f463b6c67167742aa8dae7509(c2bfb3fe48ffea6949a5d0843b8d4e));
		}

		protected override void cb396a7a5471504026c466f04f6bf5543()
		{
			c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.c3f0d9cf7bb65072c8cb6a400c2468eea(ce486bbb7b72a128ad5409b92e2eda813);
			AvatarType c2bfb3fe48ffea6949a5d0843b8d4e = (AvatarType)UnityEngine.Random.Range(0, 4);
			c06ca0e618478c23eba3419653a19760f<AutoTestManager>.c5ee19dc8d4cccf5ae2de225410458b86.StartCoroutine(AutoTestUtility.c88bf190f463b6c67167742aa8dae7509(c2bfb3fe48ffea6949a5d0843b8d4e));
		}

		protected override void ce4a5e94169aff4b7286fee3aa834ff1f()
		{
			ce486bbb7b72a128ad5409b92e2eda813.c554a78394e6a5d391ce1d86e3d161dab(base.m_timeElapsed);
			c6f67d4d05e2cc6025551586db1449f54 += Time.deltaTime;
			if ((int)c6f67d4d05e2cc6025551586db1449f54 >= 10)
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
				c6f67d4d05e2cc6025551586db1449f54 = 0f;
				c46753de6739a2dc647f5abab06259a00();
			}
			if (!(base.m_timeElapsed >= 600f))
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
				c5bc8bb6c6b44d3d5bf9249765a5d8e27(true, string.Empty);
				return;
			}
		}

		protected override void cc50a91c65114be893ed477cd81b8f8bb()
		{
			c60b02bdf837d0489317f1a34b8e80071 = true;
		}
	}
}
