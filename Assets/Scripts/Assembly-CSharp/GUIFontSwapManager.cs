using System;
using System.Collections.Generic;
using A;
using Core;
using UnityEngine;
using pumpkin.display;
using pumpkin.swf;

internal class GUIFontSwapManager : c06ca0e618478c23eba3419653a19760f<GUIFontSwapManager>
{
	public class GUITextElement
	{
		public UnityTextField _textField;

		public Rect rect;

		public int iTextureID;

		public bool bLarge;

		public FontStyle fontStyle;

		public TextAnchor alignment;

		public string fontName;

		public GUITextElement(UnityTextField c3a93568e0f033263d093913b18d1f42c)
		{
			_textField = c3a93568e0f033263d093913b18d1f42c;
			rect = new Rect(0f, 0f, _textField.c5966fc7f2f1243425ba932fa3223e264(), _textField.c4d9308ce196d48f1d1782f14331cbae6());
			fontStyle = FontStyle.Normal;
			if (_textField.c21a96789c15a7f0c78c3584bd463637d.italic > 0)
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
				fontStyle |= FontStyle.Italic;
			}
			if (_textField.c21a96789c15a7f0c78c3584bd463637d.bold > 0)
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
				fontStyle |= FontStyle.Bold;
			}
			if (_textField.textFormat.align == 0)
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
				alignment = TextAnchor.UpperLeft;
			}
			else
			{
				if (_textField.textFormat.align != 1)
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
					if (_textField.textFormat.align != 4)
					{
						if (_textField.textFormat.align == 2)
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
							alignment = TextAnchor.UpperRight;
						}
						goto IL_013a;
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
				}
				alignment = TextAnchor.UpperCenter;
			}
			goto IL_013a;
			IL_013a:
			cf382d7cc348c9e607dbab0a1fc0974b3();
		}

		public void cf382d7cc348c9e607dbab0a1fc0974b3()
		{
			rect.width = Mathf.CeilToInt(_textField.c5966fc7f2f1243425ba932fa3223e264());
			rect.height = Mathf.CeilToInt(_textField.c4d9308ce196d48f1d1782f14331cbae6());
			fontName = _textField.textFormat.font;
		}

		public void cb6ddb86ff592b855d40e4b6baac609bf()
		{
		}

		public Vector2 cd3571daf3839f19446d9bf1d2ae15d0a()
		{
			return new Vector2(rect.width, rect.height);
		}
	}

	protected struct IntVec4
	{
		public int x;

		public int y;

		public int z;

		public int a;

		public IntVec4(int c3eb603505638011637c0a9f684569d95, int c6725a1e4c7f38417d2fb352556181fe5, int c9374227fb515d722669fc52f9ba5fad8, int c4f065f637e7f5b4afc3da5533c5ac9c3)
		{
			x = c3eb603505638011637c0a9f684569d95;
			y = c6725a1e4c7f38417d2fb352556181fe5;
			z = c9374227fb515d722669fc52f9ba5fad8;
			a = c4f065f637e7f5b4afc3da5533c5ac9c3;
		}

		public void c29e4b089788dccb4b3add6f9076b772d(int c3eb603505638011637c0a9f684569d95, int c6725a1e4c7f38417d2fb352556181fe5, int c9374227fb515d722669fc52f9ba5fad8, int c4f065f637e7f5b4afc3da5533c5ac9c3)
		{
			x = c3eb603505638011637c0a9f684569d95;
			y = c6725a1e4c7f38417d2fb352556181fe5;
			z = c9374227fb515d722669fc52f9ba5fad8;
			a = c4f065f637e7f5b4afc3da5533c5ac9c3;
		}
	}

	[Serializable]
	public class FontNameID
	{
		public string fontName = string.Empty;

		public int index;
	}

	protected class RenderElement
	{
		public RenderTexture renderTexture;

		public Texture2D cachedTexture;

		public bool bRenderFlag;

		public Material material;

		public RenderElement(RenderTexture c619f1ccb945254bec1f5f1073515b5be, bool cf18436935b04ada8f6af62fe2166a3a7)
		{
			renderTexture = c619f1ccb945254bec1f5f1073515b5be;
			cachedTexture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false, true);
			material = new Material(TextureManager.baseBitmapShader);
			material.mainTexture = renderTexture;
			bRenderFlag = cf18436935b04ada8f6af62fe2166a3a7;
		}

		public void cb69996122f9a1632563ad838f8f3f9a9()
		{
			material.mainTexture = cachedTexture;
		}

		public void cba4f21ce49d62bd9d803212eca2ca73e()
		{
			material.mainTexture = renderTexture;
		}

		public void c67915f2da62d83244da1e904f44dcc85()
		{
			RenderTexture.active = renderTexture;
			cachedTexture.ReadPixels(new Rect(0f, 0f, renderTexture.width, renderTexture.height), 0, 0);
			cachedTexture.Apply();
		}

		public void cac7688b05e921e2be3f92479ba44b4a8()
		{
			renderTexture.Release();
			UnityEngine.Object.Destroy(renderTexture);
			UnityEngine.Object.Destroy(cachedTexture);
			UnityEngine.Object.Destroy(material);
		}
	}

	protected class Counter
	{
		private float target;

		private float current;

		public Counter(float c2002bb238c228cf502166e05c0d89311)
		{
			current = 0f;
			target = c2002bb238c228cf502166e05c0d89311;
		}

		public void c102ce7625ed9c1844814aaae6e81b4e5(float cf0ecbb9b13151932b8293691a84d1c24)
		{
			current += cf0ecbb9b13151932b8293691a84d1c24;
		}

		public bool caaa3a651479be7a9184481340fe588df()
		{
			return current >= target;
		}

		public void Reset()
		{
			current = 0f;
		}
	}

	private const int TEXTURE_SIZE = 1024;

	private const int HORIZONTAL_SPACE = 2;

	private const int VERTICAL_SPACE = 4;

	private const int LARGE_SIZE_DEFINE = 40;

	public Shader edgeDetectShader;

	public uniSWFFontOutline _fontOutline;

	protected bool _bNeedRender;

	protected List<List<GUITextElement>> _arrSmallList;

	protected List<List<GUITextElement>> _arrLargeList;

	protected IntVec4 _SmallVec = new IntVec4(1024, 0, 0, 0);

	protected IntVec4 _LargeVec = new IntVec4(1024, 0, 0, 0);

	protected List<RenderElement> _arrSmallTex = new List<RenderElement>();

	protected List<RenderElement> _arrLargeTex = new List<RenderElement>();

	protected Dictionary<UnityTextField, GUITextElement> _arrRenderList;

	public List<GUIStyle> _fontList;

	public List<FontNameID> FLASH_FONT_NAME;

	protected Dictionary<string, int> FLASH_FONT_NAME_MAP;

	protected MovieClip mcCursor;

	protected bool _dirty;

	protected Counter _cachedCounter;

	public MovieClip c5606a4cc3e40f37e543dde9ae004c3e0
	{
		get
		{
			return mcCursor;
		}
		set
		{
			mcCursor = value;
		}
	}

	public GUIFontSwapManager()
	{
		_arrRenderList = new Dictionary<UnityTextField, GUITextElement>();
		_arrSmallList = new List<List<GUITextElement>>();
		_arrLargeList = new List<List<GUITextElement>>();
		_cachedCounter = new Counter(3f);
		FLASH_FONT_NAME_MAP = new Dictionary<string, int>();
	}

	protected override void Awake()
	{
		base.Awake();
		if (_fontOutline == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			_fontOutline = base.gameObject.AddComponent<uniSWFFontOutline>();
			_fontOutline.edgeDetectShader = edgeDetectShader;
		}
		using (List<FontNameID>.Enumerator enumerator = FLASH_FONT_NAME.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				FontNameID current = enumerator.Current;
				FLASH_FONT_NAME_MAP[current.fontName] = current.index;
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
	}

	protected void c331d7ea166d4de3086b762d2ab26a499(List<GUITextElement> cbe0b4bfba182574e9098eb8a07c48c4d)
	{
		for (int i = 0; i < cbe0b4bfba182574e9098eb8a07c48c4d.Count; i++)
		{
			cbe0b4bfba182574e9098eb8a07c48c4d[i]._textField.cab0bb682ae5fcb74dec34d839a21ea45();
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
			return;
		}
	}

	protected void ca551118ef22dda451cb3dfec5f9bd20d()
	{
		_dirty = false;
		for (int i = 0; i < _arrSmallTex.Count; i++)
		{
			if (!_arrSmallTex[i].bRenderFlag)
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
				break;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			_arrSmallTex[i].c67915f2da62d83244da1e904f44dcc85();
			_arrSmallTex[i].bRenderFlag = false;
			c331d7ea166d4de3086b762d2ab26a499(_arrSmallList[i]);
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				continue;
			}
			for (int j = 0; j < _arrLargeTex.Count; j++)
			{
				if (!_arrLargeTex[j].bRenderFlag)
				{
					continue;
				}
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
				_arrLargeTex[j].c67915f2da62d83244da1e904f44dcc85();
				_arrLargeTex[j].bRenderFlag = false;
				c331d7ea166d4de3086b762d2ab26a499(_arrLargeList[j]);
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
	}

	private void Update()
	{
		_cachedCounter.c102ce7625ed9c1844814aaae6e81b4e5(Time.deltaTime);
		if (!_cachedCounter.caaa3a651479be7a9184481340fe588df())
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
			if (!_dirty)
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
				ca551118ef22dda451cb3dfec5f9bd20d();
				return;
			}
		}
	}

	private void OnGUI()
	{
		GUI.depth = -100;
		if (!Event.current.type.Equals(EventType.Repaint))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (!_bNeedRender)
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
				c8f5fcfe32092ef34cb9f06d08aaab120();
				_bNeedRender = false;
				return;
			}
		}
	}

	public void c0152ca5a8975604e439dc2408c0c7cd9()
	{
		_bNeedRender = true;
		_dirty = true;
		_cachedCounter.Reset();
		for (int i = 0; i < _arrSmallTex.Count; i++)
		{
			_arrSmallTex[i].bRenderFlag = true;
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			for (int j = 0; j < _arrLargeTex.Count; j++)
			{
				_arrLargeTex[j].bRenderFlag = true;
			}
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
	}

	private void c8f5fcfe32092ef34cb9f06d08aaab120()
	{
		Matrix4x4 matrix = GUI.matrix;
		GUI.matrix = Matrix4x4.Scale(new Vector3((float)Screen.width / 1024f, (float)Screen.height / 1024f, 1f));
		for (int i = 0; i < _arrSmallTex.Count; i++)
		{
			if (!_arrSmallTex[i].bRenderFlag)
			{
				continue;
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			cc65f16ba1b728aed24bf7dbd09585e87(_arrSmallTex[i], _arrSmallList[i]);
			c331d7ea166d4de3086b762d2ab26a499(_arrSmallList[i]);
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			for (int j = 0; j < _arrLargeTex.Count; j++)
			{
				if (!_arrLargeTex[j].bRenderFlag)
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
				cc65f16ba1b728aed24bf7dbd09585e87(_arrLargeTex[j], _arrLargeList[j]);
				c331d7ea166d4de3086b762d2ab26a499(_arrLargeList[j]);
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				GUI.matrix = matrix;
				return;
			}
		}
	}

	protected void cc65f16ba1b728aed24bf7dbd09585e87(RenderElement c3c77d1b79f5486df0a157f2b7f0eef13, List<GUITextElement> c17806e5b5db2842968b9e1bb69900755)
	{
		if (c3c77d1b79f5486df0a157f2b7f0eef13 == null)
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
			if (c17806e5b5db2842968b9e1bb69900755 == null)
			{
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
			RenderTexture renderTexture2 = (RenderTexture.active = c3c77d1b79f5486df0a157f2b7f0eef13.renderTexture);
			GL.Clear(true, true, new Color(0f, 0f, 0f, 0f));
			using (List<GUITextElement>.Enumerator enumerator = c17806e5b5db2842968b9e1bb69900755.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					GUITextElement current = enumerator.Current;
					GUIStyle c212ab883d9dc0cd0bef9252cc6077e7b = c6976ae25e0316ab286f515471c60fbec(current.fontName);
					cf9603b43db49aa226abbde5217a86126(current, ref c212ab883d9dc0cd0bef9252cc6077e7b);
					GUI.Label(current.rect, current._textField.text, c212ab883d9dc0cd0bef9252cc6077e7b);
				}
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						goto end_IL_00a2;
					}
					continue;
					end_IL_00a2:
					break;
				}
			}
			_fontOutline.c62ef01b9ff5defc3f7fb88c46b15e6f3(renderTexture2, renderTexture2);
			return;
		}
	}

	private void cf9603b43db49aa226abbde5217a86126(GUITextElement ca8e918e533e403a8fe694304cedc48ca, ref GUIStyle c212ab883d9dc0cd0bef9252cc6077e7b)
	{
		c212ab883d9dc0cd0bef9252cc6077e7b.richText = true;
		c212ab883d9dc0cd0bef9252cc6077e7b.fontStyle = ca8e918e533e403a8fe694304cedc48ca.fontStyle;
		c212ab883d9dc0cd0bef9252cc6077e7b.alignment = ca8e918e533e403a8fe694304cedc48ca.alignment;
		c212ab883d9dc0cd0bef9252cc6077e7b.normal.textColor = ca8e918e533e403a8fe694304cedc48ca._textField.c34fce3bccfffc6feb3579939c6d9a057;
		c212ab883d9dc0cd0bef9252cc6077e7b.fontSize = Mathf.RoundToInt(ca8e918e533e403a8fe694304cedc48ca._textField.textFormat.size);
		c212ab883d9dc0cd0bef9252cc6077e7b.wordWrap = ca8e918e533e403a8fe694304cedc48ca._textField.multiline;
		c212ab883d9dc0cd0bef9252cc6077e7b.clipping = TextClipping.Clip;
	}

	public GUIStyle c6976ae25e0316ab286f515471c60fbec(string c788fd9dcc3019037fca4471ff2560b70)
	{
		if (FLASH_FONT_NAME_MAP.ContainsKey(c788fd9dcc3019037fca4471ff2560b70))
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return _fontList[FLASH_FONT_NAME_MAP[c788fd9dcc3019037fca4471ff2560b70]];
				}
			}
		}
		return new GUIStyle(GUI.skin.textField);
	}

	public Font c247d079cbd276539a42b66ea2e660690(string c788fd9dcc3019037fca4471ff2560b70)
	{
		return c6976ae25e0316ab286f515471c60fbec(c788fd9dcc3019037fca4471ff2560b70).font;
	}

	public void c475e42fd982df7e1ed0631603fe72193(GUITextElement cc0aeb66eb3857e6773bfe62e53d3410a)
	{
		List<RenderElement> list;
		if (cc0aeb66eb3857e6773bfe62e53d3410a.bLarge)
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
			list = _arrLargeTex;
		}
		else
		{
			list = _arrSmallTex;
		}
		if (cc0aeb66eb3857e6773bfe62e53d3410a.iTextureID < list.Count)
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
			list[cc0aeb66eb3857e6773bfe62e53d3410a.iTextureID].bRenderFlag = true;
		}
		_bNeedRender = true;
		_dirty = true;
		_cachedCounter.Reset();
	}

	public void c7c180d3766c7861a208cfd3dc537208c(UnityTextField c3884c3ced21ce048872e27ce1e157e99)
	{
		if (_arrRenderList.ContainsKey(c3884c3ced21ce048872e27ce1e157e99))
		{
			while (true)
			{
				switch (7)
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
		GUITextElement value = new GUITextElement(c3884c3ced21ce048872e27ce1e157e99);
		_arrRenderList.Add(c3884c3ced21ce048872e27ce1e157e99, value);
	}

	protected int c09e659bf1816e056174cac2fcb1eecfd(GUITextElement c05c30406d103d9050e1b02d554f40b62, ref IntVec4 caa8a0579ebd9d72fe1a0bd79b151dc42, List<List<GUITextElement>> c75c8089815ecc300738c4119e4494e28, List<RenderElement> c13780c93b1d26368158bfdf62a0f843e)
	{
		c428c955354bdaa71cfb514cda19dc7bd(c05c30406d103d9050e1b02d554f40b62, ref caa8a0579ebd9d72fe1a0bd79b151dc42);
		if (caa8a0579ebd9d72fe1a0bd79b151dc42.z == c75c8089815ecc300738c4119e4494e28.Count)
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
			c13780c93b1d26368158bfdf62a0f843e.Add(new RenderElement(new RenderTexture(1024, 1024, 0, RenderTextureFormat.Default, RenderTextureReadWrite.Linear), true));
			c75c8089815ecc300738c4119e4494e28.Add(new List<GUITextElement>());
		}
		int num = c75c8089815ecc300738c4119e4494e28.Count - 1;
		c75c8089815ecc300738c4119e4494e28[num].Add(c05c30406d103d9050e1b02d554f40b62);
		return num;
	}

	protected void c428c955354bdaa71cfb514cda19dc7bd(GUITextElement c05c30406d103d9050e1b02d554f40b62, ref IntVec4 caa8a0579ebd9d72fe1a0bd79b151dc42)
	{
		caa8a0579ebd9d72fe1a0bd79b151dc42.x = caa8a0579ebd9d72fe1a0bd79b151dc42.x - Mathf.CeilToInt(c05c30406d103d9050e1b02d554f40b62.rect.width) - 2;
		if (caa8a0579ebd9d72fe1a0bd79b151dc42.x < 0)
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
			caa8a0579ebd9d72fe1a0bd79b151dc42.x = 1024 - Mathf.CeilToInt(c05c30406d103d9050e1b02d554f40b62.rect.width);
			caa8a0579ebd9d72fe1a0bd79b151dc42.y = caa8a0579ebd9d72fe1a0bd79b151dc42.y + caa8a0579ebd9d72fe1a0bd79b151dc42.a + 4;
			if ((float)caa8a0579ebd9d72fe1a0bd79b151dc42.y + c05c30406d103d9050e1b02d554f40b62.rect.height + 4f >= 1024f)
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
				caa8a0579ebd9d72fe1a0bd79b151dc42.y = 0;
				caa8a0579ebd9d72fe1a0bd79b151dc42.z++;
			}
		}
		caa8a0579ebd9d72fe1a0bd79b151dc42.a = Mathf.Max(caa8a0579ebd9d72fe1a0bd79b151dc42.a, Mathf.CeilToInt(c05c30406d103d9050e1b02d554f40b62.rect.height));
		c05c30406d103d9050e1b02d554f40b62.rect.x = caa8a0579ebd9d72fe1a0bd79b151dc42.x;
		c05c30406d103d9050e1b02d554f40b62.rect.y = caa8a0579ebd9d72fe1a0bd79b151dc42.y;
		c05c30406d103d9050e1b02d554f40b62.iTextureID = caa8a0579ebd9d72fe1a0bd79b151dc42.z;
	}

	public void c5269337dd37446a5b02beed784c874e0(UnityTextField c78f76199df3b01b565c14f17fe0235ae, out Rect cadc118b5c81bb89bf38380c9747869ba, out Vector3 cb25294f966b28cdf44d1bc2462c479c1, out Material c7eee70227d1080f1380b85d2d75607ad)
	{
		Vector2 c73ab8fbcc72afbd787a3dd69ddc;
		c5269337dd37446a5b02beed784c874e0(c78f76199df3b01b565c14f17fe0235ae, out cadc118b5c81bb89bf38380c9747869ba, out cb25294f966b28cdf44d1bc2462c479c1, out c7eee70227d1080f1380b85d2d75607ad, 0, out c73ab8fbcc72afbd787a3dd69ddc);
	}

	public void c5269337dd37446a5b02beed784c874e0(UnityTextField c78f76199df3b01b565c14f17fe0235ae, out Rect cadc118b5c81bb89bf38380c9747869ba, out Vector3 cb25294f966b28cdf44d1bc2462c479c1, out Material c7eee70227d1080f1380b85d2d75607ad, int c5612a459a84ffdb41c885401433cd62d, out Vector2 c73ab8fbcc72afbd787a3dd69ddc69496)
	{
		if (_arrRenderList.ContainsKey(c78f76199df3b01b565c14f17fe0235ae))
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					GUITextElement gUITextElement = _arrRenderList[c78f76199df3b01b565c14f17fe0235ae];
					Vector2 vector = gUITextElement.cd3571daf3839f19446d9bf1d2ae15d0a();
					cadc118b5c81bb89bf38380c9747869ba = new Rect(gUITextElement.rect.x / 1024f, gUITextElement.rect.y / 1024f, gUITextElement.rect.width / 1024f, gUITextElement.rect.height / 1024f);
					cb25294f966b28cdf44d1bc2462c479c1 = new Vector3(vector.x, vector.y, 0f);
					if (gUITextElement.bLarge)
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
						if (_dirty)
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
							_arrLargeTex[gUITextElement.iTextureID].cba4f21ce49d62bd9d803212eca2ca73e();
						}
						else
						{
							_arrLargeTex[gUITextElement.iTextureID].cb69996122f9a1632563ad838f8f3f9a9();
						}
						c7eee70227d1080f1380b85d2d75607ad = _arrLargeTex[gUITextElement.iTextureID].material;
					}
					else
					{
						if (_dirty)
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
							_arrSmallTex[gUITextElement.iTextureID].cba4f21ce49d62bd9d803212eca2ca73e();
						}
						else
						{
							_arrSmallTex[gUITextElement.iTextureID].cb69996122f9a1632563ad838f8f3f9a9();
						}
						c7eee70227d1080f1380b85d2d75607ad = _arrSmallTex[gUITextElement.iTextureID].material;
					}
					GUIStyle c212ab883d9dc0cd0bef9252cc6077e7b = c6976ae25e0316ab286f515471c60fbec(gUITextElement.fontName);
					cf9603b43db49aa226abbde5217a86126(gUITextElement, ref c212ab883d9dc0cd0bef9252cc6077e7b);
					c73ab8fbcc72afbd787a3dd69ddc69496 = c212ab883d9dc0cd0bef9252cc6077e7b.GetCursorPixelPosition(gUITextElement.rect, new GUIContent(c78f76199df3b01b565c14f17fe0235ae.text), c5612a459a84ffdb41c885401433cd62d);
					c73ab8fbcc72afbd787a3dd69ddc69496.x -= gUITextElement.rect.x;
					c73ab8fbcc72afbd787a3dd69ddc69496.y -= gUITextElement.rect.y;
					return;
				}
				}
			}
		}
		cb3c9a6938f5f6d2ba586599d5e174fcf.c61f14727dc2b99c6844722ff39d0543a(ref cadc118b5c81bb89bf38380c9747869ba);
		ced819f907a00cbfa6286c200338b520d.c61f14727dc2b99c6844722ff39d0543a(ref cb25294f966b28cdf44d1bc2462c479c1);
		c7eee70227d1080f1380b85d2d75607ad = null;
		c9ef4b269732f6eff7b215dc57e5e252c.c61f14727dc2b99c6844722ff39d0543a(ref c73ab8fbcc72afbd787a3dd69ddc69496);
	}

	public void c88f5bae060324fb84669348fec1dcf3b(UnityTextField c78f76199df3b01b565c14f17fe0235ae)
	{
		GUITextElement value;
		if (!_arrRenderList.TryGetValue(c78f76199df3b01b565c14f17fe0235ae, out value))
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
			value.cf382d7cc348c9e607dbab0a1fc0974b3();
			if (!(value.rect.width >= 1024f))
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
				if (!(value.rect.height >= 1024f))
				{
					if (value.rect.height < 40f)
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
						c09e659bf1816e056174cac2fcb1eecfd(value, ref _SmallVec, _arrSmallList, _arrSmallTex);
						value.bLarge = false;
					}
					else
					{
						c09e659bf1816e056174cac2fcb1eecfd(value, ref _LargeVec, _arrLargeList, _arrLargeTex);
						value.bLarge = true;
					}
					c475e42fd982df7e1ed0631603fe72193(value);
					return;
				}
				while (true)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "Textfield too big!!" + c78f76199df3b01b565c14f17fe0235ae.name);
			return;
		}
	}

	public void cba23612a1580080a6189ff33fe2e2d9c(UnityTextField c78f76199df3b01b565c14f17fe0235ae)
	{
		GUITextElement value;
		if (!_arrRenderList.TryGetValue(c78f76199df3b01b565c14f17fe0235ae, out value))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			value.cf382d7cc348c9e607dbab0a1fc0974b3();
			c475e42fd982df7e1ed0631603fe72193(value);
			return;
		}
	}

	private void Start()
	{
		mcCursor = new MovieClip("CommonLib.swf:TextFieldCursor");
	}

	public void cb6ddb86ff592b855d40e4b6baac609bf()
	{
		using (Dictionary<UnityTextField, GUITextElement>.Enumerator enumerator = _arrRenderList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				enumerator.Current.Value.cb6ddb86ff592b855d40e4b6baac609bf();
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
				break;
			}
		}
		_arrRenderList.Clear();
		using (List<RenderElement>.Enumerator enumerator2 = _arrSmallTex.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				RenderElement current = enumerator2.Current;
				if (RenderTexture.active == current.renderTexture)
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
					RenderTexture.active = ccb647d35893b403a66083910531a6e7e.c7088de59e49f7108f520cf7e0bae167e;
				}
				current.cac7688b05e921e2be3f92479ba44b4a8();
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					goto end_IL_00b4;
				}
				continue;
				end_IL_00b4:
				break;
			}
		}
		_arrSmallTex.Clear();
		using (List<RenderElement>.Enumerator enumerator3 = _arrLargeTex.GetEnumerator())
		{
			while (enumerator3.MoveNext())
			{
				RenderElement current2 = enumerator3.Current;
				if (RenderTexture.active == current2.renderTexture)
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
					RenderTexture.active = ccb647d35893b403a66083910531a6e7e.c7088de59e49f7108f520cf7e0bae167e;
				}
				current2.cac7688b05e921e2be3f92479ba44b4a8();
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					goto end_IL_0130;
				}
				continue;
				end_IL_0130:
				break;
			}
		}
		_arrLargeTex.Clear();
		using (List<List<GUITextElement>>.Enumerator enumerator4 = _arrSmallList.GetEnumerator())
		{
			while (enumerator4.MoveNext())
			{
				List<GUITextElement> current3 = enumerator4.Current;
				current3.Clear();
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					goto end_IL_0182;
				}
				continue;
				end_IL_0182:
				break;
			}
		}
		_arrSmallList.Clear();
		using (List<List<GUITextElement>>.Enumerator enumerator5 = _arrLargeList.GetEnumerator())
		{
			while (enumerator5.MoveNext())
			{
				List<GUITextElement> current4 = enumerator5.Current;
				current4.Clear();
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					goto end_IL_01d4;
				}
				continue;
				end_IL_01d4:
				break;
			}
		}
		_arrLargeList.Clear();
		_SmallVec.c29e4b089788dccb4b3add6f9076b772d(1024, 0, 0, 0);
		_LargeVec.c29e4b089788dccb4b3add6f9076b772d(1024, 0, 0, 0);
	}
}
