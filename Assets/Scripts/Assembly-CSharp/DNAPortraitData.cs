using A;
using UnityEngine;

public class DNAPortraitData
{
	public Texture2D tex;

	public ItemDNA dna;

	public GameObject model;

	private int TEXTURE_WIDTH = 156;

	private int TEXTURE_HIGHT = 52;

	public TexPostEffectMgr.POST_EFFECT_TYPE boundPostEffect;

	protected static Color32[] defaultColor;

	public DNAPortraitData()
	{
		c88ae0a4e10de32acff772192d821ef9a(TEXTURE_WIDTH, TEXTURE_HIGHT);
		tex = new Texture2D(TEXTURE_WIDTH, TEXTURE_HIGHT, TextureFormat.ARGB32, false);
		tex.name = "DNAPortraitData_tex";
		tex.SetPixels32(defaultColor);
		tex.Apply();
	}

	public DNAPortraitData(int c1dc62a9f1323a11caf8c414033dd8664, int cdfb3569b5c3a736a4b6dd8e7dc1efcab)
	{
		c88ae0a4e10de32acff772192d821ef9a(c1dc62a9f1323a11caf8c414033dd8664, cdfb3569b5c3a736a4b6dd8e7dc1efcab);
		TEXTURE_WIDTH = c1dc62a9f1323a11caf8c414033dd8664;
		TEXTURE_HIGHT = cdfb3569b5c3a736a4b6dd8e7dc1efcab;
		tex = new Texture2D(TEXTURE_WIDTH, TEXTURE_HIGHT, TextureFormat.ARGB32, false);
		tex.name = "DNAPortraitData_tex";
		tex.SetPixels32(defaultColor);
		tex.Apply();
	}

	protected void c88ae0a4e10de32acff772192d821ef9a(int c1dc62a9f1323a11caf8c414033dd8664, int cdfb3569b5c3a736a4b6dd8e7dc1efcab)
	{
		int num = c1dc62a9f1323a11caf8c414033dd8664 * cdfb3569b5c3a736a4b6dd8e7dc1efcab;
		if (defaultColor != null)
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
			if (TEXTURE_WIDTH * TEXTURE_HIGHT == num)
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
				break;
			}
		}
		defaultColor = c4c5e2b72910f1d0c2c7c4afec09fe3cb.c0a0cdf4a196914163f7334d9b0781a04(num);
		for (int i = 0; i < num; i++)
		{
			defaultColor[i] = Color.clear;
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
