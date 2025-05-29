using A;
using UnityEngine;

public class TextureScale
{
	public class ThreadData
	{
		public int start;

		public int end;

		public ThreadData(int c7c80fef79e3c330ae5014832d44fcd28, int c05f6b47f5e84359168dfe9aaf57b8a79)
		{
			start = c7c80fef79e3c330ae5014832d44fcd28;
			end = c05f6b47f5e84359168dfe9aaf57b8a79;
		}
	}

	private static Color[] texColors;

	private static Color[] newColors;

	private static int w;

	private static float ratioX;

	private static float ratioY;

	private static int w2;

	private static int finishCount;

	private static Rect srcRect;

	public static void c791e90673001750f3122e49fe9932b44(Texture2D cd6102468cd57214a9f3e10633998391b, int cf01641a6adfd03bc7161bee4472c1c87, int c90061dc7b90dbca912ddb9a44926c639)
	{
		cb53379bf734c563f6d0952b6c70b62f9(cd6102468cd57214a9f3e10633998391b, cf01641a6adfd03bc7161bee4472c1c87, c90061dc7b90dbca912ddb9a44926c639, false);
	}

	public static void c03d490a6c4cc2755a5dc03431a9fbb7e(Texture2D cd6102468cd57214a9f3e10633998391b, int cf01641a6adfd03bc7161bee4472c1c87, int c90061dc7b90dbca912ddb9a44926c639, Rect c6ad375458cc678f42d47ee8219ffaa93)
	{
		cb53379bf734c563f6d0952b6c70b62f9(cd6102468cd57214a9f3e10633998391b, cf01641a6adfd03bc7161bee4472c1c87, c90061dc7b90dbca912ddb9a44926c639, true);
	}

	public static void c03d490a6c4cc2755a5dc03431a9fbb7e(Texture2D c0664d7c40df93ed1d6975166ce7e529e, Texture2D c184269162b63e6ddb1e632b86aa0b54a, bool c419eae5e3e5ac90dd80e92e4ab2c1182, Rect c6ad375458cc678f42d47ee8219ffaa93)
	{
		Rect cfd99a7fe87e8f362caebce3be9c0218b = new Rect(0f, 0f, c184269162b63e6ddb1e632b86aa0b54a.width, c184269162b63e6ddb1e632b86aa0b54a.height);
		c03d490a6c4cc2755a5dc03431a9fbb7e(c0664d7c40df93ed1d6975166ce7e529e, c184269162b63e6ddb1e632b86aa0b54a, c419eae5e3e5ac90dd80e92e4ab2c1182, c6ad375458cc678f42d47ee8219ffaa93, cfd99a7fe87e8f362caebce3be9c0218b);
	}

	public static void c03d490a6c4cc2755a5dc03431a9fbb7e(Texture2D c0664d7c40df93ed1d6975166ce7e529e, Texture2D c184269162b63e6ddb1e632b86aa0b54a, bool c419eae5e3e5ac90dd80e92e4ab2c1182, Rect c6ad375458cc678f42d47ee8219ffaa93, Rect cfd99a7fe87e8f362caebce3be9c0218b)
	{
		srcRect = c6ad375458cc678f42d47ee8219ffaa93;
		int width = c184269162b63e6ddb1e632b86aa0b54a.width;
		int height = c184269162b63e6ddb1e632b86aa0b54a.height;
		int num = (int)srcRect.width;
		int num2 = (int)srcRect.height;
		texColors = c0664d7c40df93ed1d6975166ce7e529e.GetPixels();
		newColors = c9f85b5d461e935e3fe059d6462b10a03.c0a0cdf4a196914163f7334d9b0781a04(width * height);
		if (c419eae5e3e5ac90dd80e92e4ab2c1182)
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
			ratioX = 1f / (cfd99a7fe87e8f362caebce3be9c0218b.width / (float)(num - 1));
			ratioY = 1f / (cfd99a7fe87e8f362caebce3be9c0218b.height / (float)(num2 - 1));
		}
		else
		{
			ratioX = (float)num / (float)width;
			ratioY = (float)num2 / (float)height;
		}
		w = c0664d7c40df93ed1d6975166ce7e529e.width;
		w2 = width;
		ThreadData cebae66039aadeac8deb1211786332a = new ThreadData(0, height);
		if (c419eae5e3e5ac90dd80e92e4ab2c1182)
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
			cb04743fe78ffefd07ce08b3bed8534a0(cebae66039aadeac8deb1211786332a, cfd99a7fe87e8f362caebce3be9c0218b);
		}
		else
		{
			c0c30d8d778b51bcb7c1cf4fe7605d099(cebae66039aadeac8deb1211786332a);
		}
		c184269162b63e6ddb1e632b86aa0b54a.Resize(width, height);
		c184269162b63e6ddb1e632b86aa0b54a.SetPixels(newColors);
		c184269162b63e6ddb1e632b86aa0b54a.Apply();
	}

	private static void cb53379bf734c563f6d0952b6c70b62f9(Texture2D cd6102468cd57214a9f3e10633998391b, int cf01641a6adfd03bc7161bee4472c1c87, int c90061dc7b90dbca912ddb9a44926c639, bool c419eae5e3e5ac90dd80e92e4ab2c1182)
	{
		Rect c6ad375458cc678f42d47ee8219ffaa = new Rect(0f, 0f, cd6102468cd57214a9f3e10633998391b.width, cd6102468cd57214a9f3e10633998391b.height);
		c03d490a6c4cc2755a5dc03431a9fbb7e(cd6102468cd57214a9f3e10633998391b, cd6102468cd57214a9f3e10633998391b, c419eae5e3e5ac90dd80e92e4ab2c1182, c6ad375458cc678f42d47ee8219ffaa);
	}

	public static void cb04743fe78ffefd07ce08b3bed8534a0(object cebae66039aadeac8deb1211786332a72, Rect cc5deab9dabc6a5bcf9a32014be4f8877)
	{
		ThreadData threadData = (ThreadData)cebae66039aadeac8deb1211786332a72;
		for (int i = threadData.start; i < threadData.end; i++)
		{
			int num = i * w2;
			for (int j = 0; j < w2; j++)
			{
				if ((float)j >= cc5deab9dabc6a5bcf9a32014be4f8877.x)
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
					if ((float)j <= cc5deab9dabc6a5bcf9a32014be4f8877.x + cc5deab9dabc6a5bcf9a32014be4f8877.width)
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
						if ((float)i >= cc5deab9dabc6a5bcf9a32014be4f8877.y)
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
							if ((float)i <= cc5deab9dabc6a5bcf9a32014be4f8877.y + cc5deab9dabc6a5bcf9a32014be4f8877.height)
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
								int num2 = (int)Mathf.Floor(((float)i - cc5deab9dabc6a5bcf9a32014be4f8877.y) * ratioY);
								int num3 = num2 * w + (int)srcRect.y * w;
								int num4 = (num2 + 1) * w + (int)srcRect.y * w;
								int num5 = (int)Mathf.Floor(((float)j - cc5deab9dabc6a5bcf9a32014be4f8877.x) * ratioX) + (int)srcRect.x;
								float cefda2fdc3ce4e04f38bab77fc = ((float)j - cc5deab9dabc6a5bcf9a32014be4f8877.x) * ratioX - (float)num5 + (float)(int)srcRect.x;
								float cefda2fdc3ce4e04f38bab77fc2 = ((float)i - cc5deab9dabc6a5bcf9a32014be4f8877.y) * ratioY - (float)num2;
								newColors[num + j] = c6b8145e3c8ab247fd3ffd92b7e042dbd(c6b8145e3c8ab247fd3ffd92b7e042dbd(texColors[num3 + num5], texColors[num3 + num5 + 1], cefda2fdc3ce4e04f38bab77fc), c6b8145e3c8ab247fd3ffd92b7e042dbd(texColors[num4 + num5], texColors[num4 + num5 + 1], cefda2fdc3ce4e04f38bab77fc), cefda2fdc3ce4e04f38bab77fc2);
								continue;
							}
						}
					}
				}
				newColors[num + j] = new Color(0f, 0f, 0f, 0f);
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					goto end_IL_0227;
				}
				continue;
				end_IL_0227:
				break;
			}
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

	public static void c0c30d8d778b51bcb7c1cf4fe7605d099(object cebae66039aadeac8deb1211786332a72)
	{
		ThreadData threadData = (ThreadData)cebae66039aadeac8deb1211786332a72;
		int num = threadData.start;
		while (num < threadData.end)
		{
			int num2 = (int)(ratioY * (float)num) * w;
			int num3 = num * w2;
			for (int i = 0; i < w2; i++)
			{
				newColors[num3 + i] = texColors[(int)((float)num2 + ratioX * (float)i)];
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
				num++;
				break;
			}
		}
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

	private static Color c6b8145e3c8ab247fd3ffd92b7e042dbd(Color c5cc1f5f518e73516e27935e0bab85eb3, Color cf177d04055c45d1dd643098f4934e2e5, float cefda2fdc3ce4e04f38bab77fc7998241)
	{
		return new Color(c5cc1f5f518e73516e27935e0bab85eb3.r + (cf177d04055c45d1dd643098f4934e2e5.r - c5cc1f5f518e73516e27935e0bab85eb3.r) * cefda2fdc3ce4e04f38bab77fc7998241, c5cc1f5f518e73516e27935e0bab85eb3.g + (cf177d04055c45d1dd643098f4934e2e5.g - c5cc1f5f518e73516e27935e0bab85eb3.g) * cefda2fdc3ce4e04f38bab77fc7998241, c5cc1f5f518e73516e27935e0bab85eb3.b + (cf177d04055c45d1dd643098f4934e2e5.b - c5cc1f5f518e73516e27935e0bab85eb3.b) * cefda2fdc3ce4e04f38bab77fc7998241, c5cc1f5f518e73516e27935e0bab85eb3.a + (cf177d04055c45d1dd643098f4934e2e5.a - c5cc1f5f518e73516e27935e0bab85eb3.a) * cefda2fdc3ce4e04f38bab77fc7998241);
	}
}
