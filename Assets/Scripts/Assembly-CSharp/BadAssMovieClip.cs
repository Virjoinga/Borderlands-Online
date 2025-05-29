using System;
using A;
using UnityEngine;
using pumpkin.display;
using pumpkin.swf;

public class BadAssMovieClip : MovieClip
{
	private bool _b9Scaled;

	protected Rect _scale9Rect;

	protected float _fInnerScaleX = 1f;

	protected float _fInnerScaleY = 1f;

	protected int _iGridRenderSum = 9;

	public int cafa7da0299ba59f683e3c6bda7d0b9be
	{
		set
		{
			_iGridRenderSum = Math.Max(0, Math.Min(value, 9));
		}
	}

	public float c93e718634f0a0a9662e4e62dc1b5d8a5
	{
		get
		{
			return base.width;
		}
		set
		{
			if (!_b9Scaled)
			{
				return;
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
				float num = 0f;
				if (m_CachedSliceSprite != null)
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
					num = m_CachedSliceSprite.width - base.scale9Grid.width;
				}
				value = Math.Max(value, num);
				_fInnerScaleX = (value - num) / _scale9Rect.width;
				rebuildScale9Grid();
				return;
			}
		}
	}

	public float cf7772a1df19641cd211b92f3f6b89005
	{
		get
		{
			return base.height;
		}
		set
		{
			if (!_b9Scaled)
			{
				return;
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
				float num = 0f;
				if (m_CachedSliceSprite != null)
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
					num = m_CachedSliceSprite.height - base.scale9Grid.height;
				}
				value = Math.Max(value, num);
				_fInnerScaleY = (value - num) / _scale9Rect.height;
				rebuildScale9Grid();
				return;
			}
		}
	}

	public Rect cfabc3c8bcdc7aefeb82c36f62545ce91
	{
		get
		{
			return _scale9Rect;
		}
	}

	public BadAssMovieClip()
	{
	}

	public BadAssMovieClip(string c16a9c4b6ebd140704504ceb31e20a289)
		: base(c16a9c4b6ebd140704504ceb31e20a289)
	{
	}

	public BadAssMovieClip(SwfURI c9984e9e46d0c2883bea611837bfbaca4)
		: base(c9984e9e46d0c2883bea611837bfbaca4)
	{
	}

	public BadAssMovieClip(ISwfResourceLoader c9a6c1a5c8cbae667fea97d762b7b66a5, string c16a9c4b6ebd140704504ceb31e20a289)
		: base(c9a6c1a5c8cbae667fea97d762b7b66a5, c16a9c4b6ebd140704504ceb31e20a289)
	{
	}

	public BadAssMovieClip(string cd2906b360fbd3e338c46bb9cd6e4c92e, string c4f4fb0b7a5af44705b4c3845ceaa0706)
		: base(cd2906b360fbd3e338c46bb9cd6e4c92e, c4f4fb0b7a5af44705b4c3845ceaa0706)
	{
	}

	protected override BitmapTextField onInstanceBitmapTextField(BitmapFontAssetInfo bmpAssetInfo, int depthSlot)
	{
		return new UnityTextField();
	}

	protected override MovieClip onInstanceChildMovieClip(DisplayObjectInfo dispInfo, int depthSlot)
	{
		MovieClipAssetInfo movieInfoByCid = base.assetContext.getMovieInfoByCid(dispInfo.cid);
		MovieClipPlayer.registerGlobalLinkage(movieInfoByCid.className, Type.GetTypeFromHandle(c64d98389c229efec10f9d9c80458b9ea.cc1720d05c75832f704b87474932341c3()));
		MovieClip movieClip = base.onInstanceChildMovieClip(dispInfo, depthSlot);
		if (movieClip != null)
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
			if (dispInfo.name != null)
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
				if (dispInfo.name.Contains(MaskPad.MASKPAD_PREFIX))
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
					MaskPad maskPad = new MaskPad();
					maskPad.c9736b290a6efcb7524d4bedda677c9dc(movieClip, dispInfo.name);
				}
			}
		}
		return movieClip;
	}

	protected override void OnSetScale9Grid(Rect rect)
	{
		base.OnSetScale9Grid(rect);
		if (!MovieClipPlayer.enableScale9)
		{
			return;
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
			_scale9Rect = rect;
			_b9Scaled = true;
			return;
		}
	}

	public static Rect c619503b0e3d35f51104b3a1116bed7d4(Material c4b37d539f2c2303a31bf314f3f555bef, Rect cccaafe469d2d0a643376fe730e63bfc8, Rect c6b72c110fddc4c1bda8dc60ed61a81cc)
	{
		Vector2 vector = TextureManager.MaterialPixelSpaceToUVSpace(c4b37d539f2c2303a31bf314f3f555bef, new Vector2(cccaafe469d2d0a643376fe730e63bfc8.x, cccaafe469d2d0a643376fe730e63bfc8.y));
		Vector2 vector2 = TextureManager.MaterialPixelSpaceToUVSpace(c4b37d539f2c2303a31bf314f3f555bef, new Vector2(cccaafe469d2d0a643376fe730e63bfc8.width, cccaafe469d2d0a643376fe730e63bfc8.height));
		return new Rect(vector.x + c6b72c110fddc4c1bda8dc60ed61a81cc.x * vector2.x, vector.y + c6b72c110fddc4c1bda8dc60ed61a81cc.y * vector2.y, vector2.x * c6b72c110fddc4c1bda8dc60ed61a81cc.width, vector2.y * c6b72c110fddc4c1bda8dc60ed61a81cc.height);
	}

	protected override void rebuildScale9Grid()
	{
		if (base.numChildren < 1)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return;
				}
			}
		}
		m_CachedSliceSprite = getChildAt(0) as pumpkin.display.Sprite;
		AssetBaseInfo assetBaseInfo = m_AssetContext.exports[m_CachedSliceSprite.cachedCid];
		BitmapAssetInfo bitmapAssetInfo = assetBaseInfo as BitmapAssetInfo;
		if (m_CachedSliceSprite == null)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		if (m_CachedSliceSprite.graphics.drawOPs.Count == 0)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		if (bitmapAssetInfo == null)
		{
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
		m_CachedSliceSprite.visible = true;
		graphics.clear();
		float num = base.height;
		float num2 = base.width;
		GraphicsDrawOP graphicsDrawOP = m_CachedSliceSprite.graphics.drawOPs[0];
		Material material = graphicsDrawOP.material;
		Rect srcRect = bitmapAssetInfo.srcRect;
		float[] array = c45a99a14f737cada4caa361b45034f4d.c0a0cdf4a196914163f7334d9b0781a04(4);
		array[1] = _scale9Rect.x / num2;
		array[2] = (_scale9Rect.x + _scale9Rect.width) / num2;
		array[3] = 1f;
		float[] array2 = array;
		float[] array3 = c45a99a14f737cada4caa361b45034f4d.c0a0cdf4a196914163f7334d9b0781a04(4);
		array3[1] = _scale9Rect.y / num;
		array3[2] = (_scale9Rect.y + _scale9Rect.height) / num;
		array3[3] = 1f;
		float[] array4 = array3;
		float[] array5 = c45a99a14f737cada4caa361b45034f4d.c0a0cdf4a196914163f7334d9b0781a04(4);
		array5[1] = _scale9Rect.x;
		array5[2] = _scale9Rect.x + _scale9Rect.width * _fInnerScaleX;
		array5[3] = num2 + _scale9Rect.width * (_fInnerScaleX - 1f);
		float[] array6 = array5;
		float[] array7 = c45a99a14f737cada4caa361b45034f4d.c0a0cdf4a196914163f7334d9b0781a04(4);
		array7[1] = _scale9Rect.y;
		array7[2] = _scale9Rect.y + _scale9Rect.height * _fInnerScaleY;
		array7[3] = num + _scale9Rect.height * (_fInnerScaleY - 1f);
		float[] array8 = array7;
		for (int i = 0; i < _iGridRenderSum; i++)
		{
			int num3 = Mathf.FloorToInt(i / 3);
			int num4 = i % 3;
			Rect drawRect = Rect.MinMaxRect(array6[num4], array8[num3], array6[num4 + 1], array8[num3 + 1]);
			Rect c6b72c110fddc4c1bda8dc60ed61a81cc = Rect.MinMaxRect(array2[num4], array4[num3], array2[num4 + 1], array4[num3 + 1]);
			c6b72c110fddc4c1bda8dc60ed61a81cc = c619503b0e3d35f51104b3a1116bed7d4(material, srcRect, c6b72c110fddc4c1bda8dc60ed61a81cc);
			graphics.drawRectUV(material, c6b72c110fddc4c1bda8dc60ed61a81cc, drawRect);
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			m_CachedSliceSprite.visible = false;
			return;
		}
	}
}
