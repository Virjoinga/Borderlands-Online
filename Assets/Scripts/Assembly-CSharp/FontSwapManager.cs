using System.Collections.Generic;
using A;
using Core;
using UnityEngine;

internal class FontSwapManager : c06ca0e618478c23eba3419653a19760f<FontSwapManager>
{
	public class TextRenderElement
	{
		public UnityTextField _textField;

		public TextMesh _textMesh;

		public FontSwapTexture _textTexture;

		public FontRect _fontRect;

		public Material _material;

		public TextRenderElement(UnityTextField c3a93568e0f033263d093913b18d1f42c)
		{
			_textField = c3a93568e0f033263d093913b18d1f42c;
			Transform transform = c06ca0e618478c23eba3419653a19760f<FontSwapManager>.c5ee19dc8d4cccf5ae2de225410458b86.c0a36e74d5463c373e72be4e300d072d1(_textField.textFormat.font);
			GameObject gameObject = Object.Instantiate(transform.gameObject) as GameObject;
			gameObject.layer = LayerMask.NameToLayer("UI");
			_textMesh = gameObject.GetComponent<TextMesh>();
			_textMesh.fontStyle = FontStyle.Normal;
			_textMesh.fontSize = Mathf.RoundToInt(_textField.textFormat.size);
			if (_textField.textFormat.italic)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				_textMesh.fontStyle |= FontStyle.Italic;
			}
			if (_textField.textFormat.bold)
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
				_textMesh.fontStyle |= FontStyle.Bold;
			}
			if (_textField.textFormat.align == 0)
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
				_textMesh.alignment = TextAlignment.Left;
			}
			else
			{
				if (_textField.textFormat.align != 1)
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
					if (_textField.textFormat.align != 4)
					{
						if (_textField.textFormat.align == 2)
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
							_textMesh.alignment = TextAlignment.Right;
						}
						goto IL_01a8;
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
				_textMesh.alignment = TextAlignment.Center;
			}
			goto IL_01a8;
			IL_01a8:
			cf382d7cc348c9e607dbab0a1fc0974b3();
		}

		public void cf382d7cc348c9e607dbab0a1fc0974b3()
		{
			string empty = string.Empty;
			if (_textField.multiline)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				empty = c45e6cdd6edc52c1399e714ebb7578efb(_textField.text, _textMesh, _textField.c5966fc7f2f1243425ba932fa3223e264() / 10f);
			}
			else
			{
				empty = _textField.text.TrimEnd(cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(0));
			}
			_textMesh.color = _textField.c34fce3bccfffc6feb3579939c6d9a057;
			_textMesh.text = empty;
		}

		public void cb6ddb86ff592b855d40e4b6baac609bf()
		{
			if (_textMesh.gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				Object.Destroy(_textMesh.gameObject);
			}
			if (!(_material != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				Object.Destroy(_material);
				return;
			}
		}

		public Vector2 cd3571daf3839f19446d9bf1d2ae15d0a()
		{
			return new Vector2(_textMesh.renderer.bounds.size.x, _textMesh.renderer.bounds.size.y);
		}

		public static string c45e6cdd6edc52c1399e714ebb7578efb(string c551f6a80e4cd17bcb44185fdf4388e31, TextMesh c208cebb87440041f044bad134fd88588, float cde26ec86f6eefd5b918e335a7f53d4cb)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			for (int i = 0; i < c551f6a80e4cd17bcb44185fdf4388e31.Length; i++)
			{
				text2 = (c208cebb87440041f044bad134fd88588.text = text2 + c551f6a80e4cd17bcb44185fdf4388e31.Substring(i, 1));
				float x = c208cebb87440041f044bad134fd88588.renderer.bounds.size.x;
				if (x > cde26ec86f6eefd5b918e335a7f53d4cb)
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
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					text2 = c551f6a80e4cd17bcb44185fdf4388e31.Substring(i, 1);
					text = text + "\n" + c551f6a80e4cd17bcb44185fdf4388e31.Substring(i, 1);
				}
				else
				{
					text += c551f6a80e4cd17bcb44185fdf4388e31.Substring(i, 1);
				}
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				return text;
			}
		}
	}

	private const string DefaultFontName = "MSYH";

	public Shader mFontOutlineShader;

	protected List<FontSwapTexture> _arrTextureList;

	protected Dictionary<UnityTextField, TextRenderElement> _arrRenderList;

	protected Dictionary<string, string> _mapFontName2ObjectName;

	public string[] FLASH_FONT_NAMES = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(0);

	public string[] UNITY_FONT_NAMES = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(0);

	private float _fUpdateTimer;

	public FontSwapManager()
	{
		_arrTextureList = new List<FontSwapTexture>();
		_arrRenderList = new Dictionary<UnityTextField, TextRenderElement>();
		_mapFontName2ObjectName = new Dictionary<string, string>
		{
			{ "Î¢ÈíÑÅºÚ", "MSYH" },
			{ "MSYH", "MSYH" },
			{ "Compacta Bd BT", "COMPACTA Bold BT" }
		};
	}

	private void Update()
	{
		if (_fUpdateTimer < 100f)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					_fUpdateTimer += Time.deltaTime;
					return;
				}
			}
		}
		_fUpdateTimer = 0f;
		c0152ca5a8975604e439dc2408c0c7cd9();
	}

	public void c0152ca5a8975604e439dc2408c0c7cd9()
	{
		using (Dictionary<UnityTextField, TextRenderElement>.Enumerator enumerator = _arrRenderList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				enumerator.Current.Value._textMesh.renderer.enabled = true;
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
				break;
			}
		}
		for (int i = 0; i < _arrTextureList.Count; i++)
		{
			_arrTextureList[i]._textRendererCamera.enabled = true;
			_arrTextureList[i]._textRendererCamera.RenderWithShader(Shader.Find("Custom/UIFontColorBlend"), string.Empty);
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			using (Dictionary<UnityTextField, TextRenderElement>.Enumerator enumerator2 = _arrRenderList.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					enumerator2.Current.Value._textField.cab0bb682ae5fcb74dec34d839a21ea45();
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
	}

	public void c475e42fd982df7e1ed0631603fe72193(TextRenderElement cc0aeb66eb3857e6773bfe62e53d3410a)
	{
		c07d85b5dd43717ca8d6a0bf3b9934e34(cc0aeb66eb3857e6773bfe62e53d3410a._textTexture, cc0aeb66eb3857e6773bfe62e53d3410a);
	}

	private void c07d85b5dd43717ca8d6a0bf3b9934e34(FontSwapTexture c619f1ccb945254bec1f5f1073515b5be, TextRenderElement cc0aeb66eb3857e6773bfe62e53d3410a)
	{
		using (Dictionary<UnityTextField, TextRenderElement>.Enumerator enumerator = _arrRenderList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				KeyValuePair<UnityTextField, TextRenderElement> current = enumerator.Current;
				if (current.Value._textTexture != c619f1ccb945254bec1f5f1073515b5be)
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
				current.Value._textMesh.renderer.enabled = true;
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					goto end_IL_0064;
				}
				continue;
				end_IL_0064:
				break;
			}
		}
		c619f1ccb945254bec1f5f1073515b5be._textRendererCamera.enabled = true;
		c619f1ccb945254bec1f5f1073515b5be._textRendererCamera.RenderWithShader(Shader.Find("Custom/UIFontColorBlend"), string.Empty);
		cc0aeb66eb3857e6773bfe62e53d3410a._textField.cab0bb682ae5fcb74dec34d839a21ea45();
	}

	public Font c247d079cbd276539a42b66ea2e660690(string cba08a872985c032aa5aa53eb0d7db7e6)
	{
		Transform transform = c0a36e74d5463c373e72be4e300d072d1(cba08a872985c032aa5aa53eb0d7db7e6);
		TextMesh component = transform.gameObject.GetComponent<TextMesh>();
		if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return component.font;
				}
			}
		}
		return null;
	}

	public Transform c0a36e74d5463c373e72be4e300d072d1(string cba08a872985c032aa5aa53eb0d7db7e6)
	{
		Transform transform = ce1fb4d774e60a964105c162513d97b38.c7088de59e49f7108f520cf7e0bae167e;
		if (!string.IsNullOrEmpty(cba08a872985c032aa5aa53eb0d7db7e6))
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
			if (_mapFontName2ObjectName.ContainsKey(cba08a872985c032aa5aa53eb0d7db7e6))
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
				transform = base.transform.FindChild(_mapFontName2ObjectName[cba08a872985c032aa5aa53eb0d7db7e6]);
			}
		}
		if (transform == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			transform = base.transform.FindChild("MSYH");
		}
		return transform;
	}

	public void c7c180d3766c7861a208cfd3dc537208c(UnityTextField c3884c3ced21ce048872e27ce1e157e99)
	{
		if (_arrRenderList.ContainsKey(c3884c3ced21ce048872e27ce1e157e99))
		{
			while (true)
			{
				switch (6)
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
		TextRenderElement textRenderElement = new TextRenderElement(c3884c3ced21ce048872e27ce1e157e99);
		int count = _arrRenderList.Count;
		textRenderElement._textMesh.gameObject.name = "TextMesh" + count;
		textRenderElement._textMesh.transform.parent = base.gameObject.transform;
		c5270af500d0382e11aefd27ee267cb22(textRenderElement, 1f);
		_arrRenderList.Add(c3884c3ced21ce048872e27ce1e157e99, textRenderElement);
	}

	public void c5269337dd37446a5b02beed784c874e0(UnityTextField c78f76199df3b01b565c14f17fe0235ae, out Rect cadc118b5c81bb89bf38380c9747869ba, out Vector3 cb25294f966b28cdf44d1bc2462c479c1, out Material c50c9eb60fe79dee2c3dd1e3c26b1ca96)
	{
		if (_arrRenderList.ContainsKey(c78f76199df3b01b565c14f17fe0235ae))
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					TextRenderElement textRenderElement = _arrRenderList[c78f76199df3b01b565c14f17fe0235ae];
					TextMesh textMesh = textRenderElement._textMesh;
					Vector2 vector = textRenderElement.cd3571daf3839f19446d9bf1d2ae15d0a() * 10f;
					cadc118b5c81bb89bf38380c9747869ba = new Rect(textMesh.transform.localPosition.x * 10f / 1024f, (0f - textMesh.transform.localPosition.y) * 10f / 1024f, (vector.x + 1f) / 1024f, (vector.y + 1f) / 1024f);
					cb25294f966b28cdf44d1bc2462c479c1 = new Vector3(vector.x, vector.y, 0f);
					if (textRenderElement._material == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						textRenderElement._material = new Material(Shader.Find("Transparent/DiffuseDoubeSided"));
						textRenderElement._material.name = "FontSwapManager_GetRenderInfo";
					}
					textRenderElement._material.mainTexture = textRenderElement._textTexture._cameraTexture;
					c50c9eb60fe79dee2c3dd1e3c26b1ca96 = textRenderElement._material;
					return;
				}
				}
			}
		}
		cb3c9a6938f5f6d2ba586599d5e174fcf.c61f14727dc2b99c6844722ff39d0543a(ref cadc118b5c81bb89bf38380c9747869ba);
		ced819f907a00cbfa6286c200338b520d.c61f14727dc2b99c6844722ff39d0543a(ref cb25294f966b28cdf44d1bc2462c479c1);
		c50c9eb60fe79dee2c3dd1e3c26b1ca96 = null;
	}

	public void cba23612a1580080a6189ff33fe2e2d9c(UnityTextField c78f76199df3b01b565c14f17fe0235ae)
	{
		TextRenderElement value;
		if (!_arrRenderList.TryGetValue(c78f76199df3b01b565c14f17fe0235ae, out value))
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
			value.cf382d7cc348c9e607dbab0a1fc0974b3();
			cd6ecb124c84faeeea7a789d81f1bc4a9(value);
			c475e42fd982df7e1ed0631603fe72193(value);
			return;
		}
	}

	private void Start()
	{
	}

	protected override void Awake()
	{
		base.Awake();
		if (FLASH_FONT_NAMES.Length > 0)
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
			if (UNITY_FONT_NAMES.Length == FLASH_FONT_NAMES.Length)
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
				_mapFontName2ObjectName.Clear();
				for (int i = 0; i < FLASH_FONT_NAMES.Length; i++)
				{
					_mapFontName2ObjectName.Add(FLASH_FONT_NAMES[i], UNITY_FONT_NAMES[i]);
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
			}
		}
		ca2cbab0db110e7228ed078c6c201d68f();
	}

	protected void ca2cbab0db110e7228ed078c6c201d68f()
	{
		_arrTextureList.Add(new FontSwapTexture(0, base.gameObject));
	}

	protected void c536ee1939e25a21eb10827e3a09051ad()
	{
		for (int i = 0; i < _arrTextureList.Count; i++)
		{
			_arrTextureList[i].cac7688b05e921e2be3f92479ba44b4a8();
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

	protected void c0a125a410144fef9bf224ceec3af7146()
	{
		c536ee1939e25a21eb10827e3a09051ad();
		using (Dictionary<UnityTextField, TextRenderElement>.Enumerator enumerator = _arrRenderList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				c5270af500d0382e11aefd27ee267cb22(enumerator.Current.Value, 1f);
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
				return;
			}
		}
	}

	protected void cd6ecb124c84faeeea7a789d81f1bc4a9(TextRenderElement cc0aeb66eb3857e6773bfe62e53d3410a)
	{
		Vector2 vector = cc0aeb66eb3857e6773bfe62e53d3410a.cd3571daf3839f19446d9bf1d2ae15d0a();
		FontRect fontRect = cc0aeb66eb3857e6773bfe62e53d3410a._fontRect;
		Rect rect = fontRect.rect;
		if (!(rect.width < vector.x))
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
			if (!(rect.height < vector.y))
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
				break;
			}
		}
		c5270af500d0382e11aefd27ee267cb22(cc0aeb66eb3857e6773bfe62e53d3410a, 1.5f);
	}

	public void cb6ddb86ff592b855d40e4b6baac609bf()
	{
		using (Dictionary<UnityTextField, TextRenderElement>.Enumerator enumerator = _arrRenderList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				enumerator.Current.Value.cb6ddb86ff592b855d40e4b6baac609bf();
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
				break;
			}
		}
		_arrRenderList.Clear();
		for (int i = 0; i < _arrTextureList.Count; i++)
		{
			_arrTextureList[i].cb6ddb86ff592b855d40e4b6baac609bf();
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			_arrTextureList.Clear();
			return;
		}
	}

	protected void c5270af500d0382e11aefd27ee267cb22(TextRenderElement cc0aeb66eb3857e6773bfe62e53d3410a, float c52653cd226edee69dc40caf0157e2a97 = 1f)
	{
		if (cc0aeb66eb3857e6773bfe62e53d3410a._textTexture != null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (cc0aeb66eb3857e6773bfe62e53d3410a._fontRect != null)
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
				cc0aeb66eb3857e6773bfe62e53d3410a._textTexture.c858d49c3aa8b8f3ea460cdf0aaa021bc(cc0aeb66eb3857e6773bfe62e53d3410a._fontRect);
			}
		}
		cc0aeb66eb3857e6773bfe62e53d3410a._textTexture = c7941a9e1d38c56b59ad403b22caea346.c7088de59e49f7108f520cf7e0bae167e;
		cc0aeb66eb3857e6773bfe62e53d3410a._fontRect = cd3225b6fd68bda0aaf45c71a7e4e8b77.c7088de59e49f7108f520cf7e0bae167e;
		Vector2 vector = cc0aeb66eb3857e6773bfe62e53d3410a.cd3571daf3839f19446d9bf1d2ae15d0a() * c52653cd226edee69dc40caf0157e2a97;
		FontRect c358811514c3bcb6d6e34e63c5e = cd3225b6fd68bda0aaf45c71a7e4e8b77.c7088de59e49f7108f520cf7e0bae167e;
		vector.x = Mathf.Ceil(100f * vector.x) / 100f;
		vector.y = Mathf.Ceil(100f * vector.y) / 100f;
		if (!(vector.x > 1024f))
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
			if (!(vector.y > 1024f))
			{
				int num = 0;
				while (true)
				{
					if (num < _arrTextureList.Count)
					{
						if (_arrTextureList[num].c9f0d4a285162de5a06c48455afd64adf(vector.x, vector.y, out c358811514c3bcb6d6e34e63c5e))
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
							cc0aeb66eb3857e6773bfe62e53d3410a._textTexture = _arrTextureList[num];
							break;
						}
						num++;
						continue;
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
					break;
				}
				if (cc0aeb66eb3857e6773bfe62e53d3410a._textTexture == null)
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
					cc0aeb66eb3857e6773bfe62e53d3410a._textTexture = new FontSwapTexture(_arrTextureList.Count, base.gameObject);
					cc0aeb66eb3857e6773bfe62e53d3410a._textTexture.c9f0d4a285162de5a06c48455afd64adf(vector.x, vector.y, out c358811514c3bcb6d6e34e63c5e);
					_arrTextureList.Add(cc0aeb66eb3857e6773bfe62e53d3410a._textTexture);
				}
				cc0aeb66eb3857e6773bfe62e53d3410a._fontRect = c358811514c3bcb6d6e34e63c5e;
				Rect rect = c358811514c3bcb6d6e34e63c5e.rect;
				cc0aeb66eb3857e6773bfe62e53d3410a._textMesh.transform.parent = cc0aeb66eb3857e6773bfe62e53d3410a._textTexture._textureRoot.transform;
				cc0aeb66eb3857e6773bfe62e53d3410a._textMesh.transform.localPosition = new Vector3(rect.x, rect.y, 0f);
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
		DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.GUI, "FontSwapManager: Too big");
	}
}
