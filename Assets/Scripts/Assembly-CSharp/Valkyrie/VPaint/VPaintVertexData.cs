using System;
using A;
using UnityEngine;

namespace Valkyrie.VPaint
{
	[Serializable]
	public class VPaintVertexData
	{
		public UnityEngine.Object colorer;

		public Color[] colors;

		public float[] transparency;

		public IVPaintIdentifier identifier
		{
			get
			{
				return colorer as IVPaintIdentifier;
			}
			set
			{
				colorer = value as UnityEngine.Object;
			}
		}

		public VPaintObject vpaintObject
		{
			get
			{
				return colorer as VPaintObject;
			}
			set
			{
				colorer = value;
			}
		}

		public VPaintVertexData Clone()
		{
			VPaintVertexData vPaintVertexData = new VPaintVertexData();
			vPaintVertexData.colorer = colorer;
			vPaintVertexData.colors = c9f85b5d461e935e3fe059d6462b10a03.c0a0cdf4a196914163f7334d9b0781a04(colors.Length);
			vPaintVertexData.transparency = c45a99a14f737cada4caa361b45034f4d.c0a0cdf4a196914163f7334d9b0781a04(colors.Length);
			for (int i = 0; i < colors.Length; i++)
			{
				vPaintVertexData.colors[i] = colors[i];
				vPaintVertexData.transparency[i] = transparency[i];
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
				return vPaintVertexData;
			}
		}
	}
}
