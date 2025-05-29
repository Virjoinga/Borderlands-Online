using System;
using Core;
using XsdSettings;

namespace A
{
	internal class cfee0aecb5670cad7845a51e8122c9086 : c18cee71b120332e4267d3dd92c1d4a41
	{
		public int c8c56de6826412494bc38311cdef962d5 = 1;

		public AvatarType cad1d2f5d2e964ba5eed0108fe443b302;

		protected override void cb396a7a5471504026c466f04f6bf5543()
		{
			c06ca0e618478c23eba3419653a19760f<AutoTestManager>.c5ee19dc8d4cccf5ae2de225410458b86.StartCoroutine(AutoTestUtility.c88bf190f463b6c67167742aa8dae7509(cad1d2f5d2e964ba5eed0108fe443b302));
		}

		public override void cc8087ec851edf4386d15e9c58faa66e6(string c99a7965a254b275dcf66f6e1f9a49d18)
		{
			int num = c99a7965a254b275dcf66f6e1f9a49d18.IndexOf('(');
			int num2 = c99a7965a254b275dcf66f6e1f9a49d18.IndexOf(')');
			if (num == -1)
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
				if (num2 == -1)
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
					if (num2 <= num)
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
						string text = c99a7965a254b275dcf66f6e1f9a49d18.Substring(num + 1, num2 - num - 1);
						char[] array = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
						array[0] = ',';
						string[] array2 = text.Split(array);
						if (array2.Length != 2)
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
							try
							{
								cad1d2f5d2e964ba5eed0108fe443b302 = (AvatarType)(int)Enum.Parse(Type.GetTypeFromHandle(c6b6839a04f0eb5690830cb0f6c6e137f.cc1720d05c75832f704b87474932341c3()), array2[0], true);
								c8c56de6826412494bc38311cdef962d5 = int.Parse(array2[1]);
								return;
							}
							catch (Exception ex)
							{
								DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Autotest, "SpawnPlayerAndWait()  invalid parameters.  " + ex.Message);
								return;
							}
						}
					}
				}
			}
		}

		protected override void ce4a5e94169aff4b7286fee3aa834ff1f()
		{
			c2978e4d619055f2147c72ca94df6715a(c8c56de6826412494bc38311cdef962d5);
		}
	}
}
