using System.Collections.Generic;
using A;
using UnityEngine;

public class FontSwapTexture
{
	public const int TextureSize = 1024;

	private const float HORIZONTAL_SPACE = 0.05f;

	private const float VERTICAL_SPACE = 0.05f;

	private const float ACCURACY = 100f;

	public Camera _textRendererCamera;

	public RenderTexture _cameraTexture;

	private GameObject _cameraObject;

	private FontOutline _fontOutline;

	public GameObject _textureRoot;

	protected List<FontRect> _arrRectList = new List<FontRect>();

	public float c77d645a97353c7c9f413f353687bb03a
	{
		get
		{
			return _textRendererCamera.orthographicSize * 2f;
		}
	}

	public FontSwapTexture(int c5612a459a84ffdb41c885401433cd62d, GameObject c3cb1f1345dbfd94c51709a9b2e9a9704)
	{
		_cameraTexture = new RenderTexture(1024, 1024, 0);
		_cameraTexture.name = "FontSwapTexture_cameraTexture";
		float num = 51.2f;
		_textureRoot = new GameObject("_Root_" + c5612a459a84ffdb41c885401433cd62d);
		_textureRoot.transform.parent = c3cb1f1345dbfd94c51709a9b2e9a9704.transform;
		_textureRoot.transform.localPosition = new Vector3(0f, -c5612a459a84ffdb41c885401433cd62d * 1024, 0f);
		_cameraObject = new GameObject("TextCamera");
		_textRendererCamera = _cameraObject.AddComponent<Camera>();
		_textRendererCamera.clearFlags = CameraClearFlags.Color;
		_textRendererCamera.backgroundColor = new Color(0.4f, 0.4f, 0.4f, 0f);
		_textRendererCamera.cullingMask = 1 << LayerMask.NameToLayer("UI");
		_textRendererCamera.targetTexture = _cameraTexture;
		_textRendererCamera.orthographicSize = num;
		_textRendererCamera.pixelRect = new Rect(0f, 0f, 1024f, 1024f);
		_textRendererCamera.orthographic = true;
		_fontOutline = _cameraObject.AddComponent<FontOutline>();
		_fontOutline.edgeDetectShader = c06ca0e618478c23eba3419653a19760f<FontSwapManager>.c5ee19dc8d4cccf5ae2de225410458b86.mFontOutlineShader;
		_cameraObject.transform.parent = _textureRoot.transform;
		_cameraObject.transform.localPosition = new Vector3(num, 0f - num, -1f);
	}

	public void cb6ddb86ff592b855d40e4b6baac609bf()
	{
		Object.Destroy(_fontOutline);
		_cameraTexture.DiscardContents();
		Object.Destroy(_cameraTexture);
		Object.Destroy(_textRendererCamera);
		Object.Destroy(_textureRoot);
		Object.Destroy(_cameraObject);
		_arrRectList.Clear();
	}

	public bool c9f0d4a285162de5a06c48455afd64adf(float c1dc62a9f1323a11caf8c414033dd8664, float cdfb3569b5c3a736a4b6dd8e7dc1efcab, out FontRect c358811514c3bcb6d6e34e63c5e043372)
	{
		bool flag = false;
		if (_arrRectList.Count == 0)
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
			c358811514c3bcb6d6e34e63c5e043372 = new FontRect(new Rect(0.001f, -0.001f, c1dc62a9f1323a11caf8c414033dd8664, cdfb3569b5c3a736a4b6dd8e7dc1efcab));
			flag = true;
		}
		else
		{
			Rect c36964cf41281414170f34ee68bef6c = default(Rect);
			cb3c9a6938f5f6d2ba586599d5e174fcf.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
			c358811514c3bcb6d6e34e63c5e043372 = new FontRect(c36964cf41281414170f34ee68bef6c);
			int num = 0;
			while (true)
			{
				if (num < _arrRectList.Count)
				{
					FontRect fontRect = _arrRectList[num];
					Rect rect = fontRect.rect;
					if (!fontRect.rightAlloc)
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
						float left = Mathf.Ceil(100f * (rect.x + rect.width)) / 100f + 0.05f;
						float y = rect.y;
						Rect rect2 = new Rect(left, y, c1dc62a9f1323a11caf8c414033dd8664, cdfb3569b5c3a736a4b6dd8e7dc1efcab);
						if (!c2c8c0d830b048ebb2a2209f1d4c6ed00(rect2))
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
							fontRect.rightAlloc = true;
							c358811514c3bcb6d6e34e63c5e043372.leftRect = fontRect;
							c358811514c3bcb6d6e34e63c5e043372.rect = rect2;
							flag = true;
							break;
						}
					}
					if (!fontRect.downAlloc)
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
						float x = rect.x;
						float top = Mathf.Floor(100f * (rect.y - rect.height)) / 100f - 0.05f;
						Rect rect3 = new Rect(x, top, c1dc62a9f1323a11caf8c414033dd8664, cdfb3569b5c3a736a4b6dd8e7dc1efcab);
						if (!c2c8c0d830b048ebb2a2209f1d4c6ed00(rect3))
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
							fontRect.downAlloc = true;
							c358811514c3bcb6d6e34e63c5e043372.upRect = fontRect;
							c358811514c3bcb6d6e34e63c5e043372.rect = rect3;
							flag = true;
							break;
						}
					}
					num++;
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
				break;
			}
		}
		if (flag)
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
			_arrRectList.Add(c358811514c3bcb6d6e34e63c5e043372);
		}
		return flag;
	}

	public void c858d49c3aa8b8f3ea460cdf0aaa021bc(FontRect c91197decc5185346bdcd6700ac40fa26)
	{
		if (c91197decc5185346bdcd6700ac40fa26.leftRect != null)
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
			c91197decc5185346bdcd6700ac40fa26.leftRect.rightAlloc = false;
		}
		if (c91197decc5185346bdcd6700ac40fa26.upRect != null)
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
			c91197decc5185346bdcd6700ac40fa26.upRect.downAlloc = false;
		}
		_arrRectList.Remove(c91197decc5185346bdcd6700ac40fa26);
	}

	public void cac7688b05e921e2be3f92479ba44b4a8()
	{
		_arrRectList.Clear();
	}

	private bool c2c8c0d830b048ebb2a2209f1d4c6ed00(Rect c4a36f3f47f3590ea90ed47426e47c0d5)
	{
		if (c4a36f3f47f3590ea90ed47426e47c0d5.x + c4a36f3f47f3590ea90ed47426e47c0d5.width + 0.05f > c77d645a97353c7c9f413f353687bb03a)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return true;
				}
			}
		}
		if (c4a36f3f47f3590ea90ed47426e47c0d5.y - c4a36f3f47f3590ea90ed47426e47c0d5.height - 0.05f < 0f - c77d645a97353c7c9f413f353687bb03a)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					return true;
				}
			}
		}
		for (int i = 0; i < _arrRectList.Count; i++)
		{
			if (!cc45c82f9ffc5a13d7473d2b9ebe007da(c4a36f3f47f3590ea90ed47426e47c0d5, _arrRectList[i].rect))
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
				return true;
			}
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			return false;
		}
	}

	private bool cc45c82f9ffc5a13d7473d2b9ebe007da(Rect c4f065f637e7f5b4afc3da5533c5ac9c3, Rect ccd81f40e6d1393f976f5c3a3c373ceec)
	{
		float x = c4f065f637e7f5b4afc3da5533c5ac9c3.x;
		float num = c4f065f637e7f5b4afc3da5533c5ac9c3.x + c4f065f637e7f5b4afc3da5533c5ac9c3.width + 0.05f;
		float y = c4f065f637e7f5b4afc3da5533c5ac9c3.y;
		float num2 = c4f065f637e7f5b4afc3da5533c5ac9c3.y - c4f065f637e7f5b4afc3da5533c5ac9c3.height - 0.05f;
		float x2 = ccd81f40e6d1393f976f5c3a3c373ceec.x;
		float num3 = ccd81f40e6d1393f976f5c3a3c373ceec.x + ccd81f40e6d1393f976f5c3a3c373ceec.width + 0.05f;
		float y2 = ccd81f40e6d1393f976f5c3a3c373ceec.y;
		float num4 = ccd81f40e6d1393f976f5c3a3c373ceec.y - ccd81f40e6d1393f976f5c3a3c373ceec.height - 0.05f;
		if (num2 >= y2)
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
					return false;
				}
			}
		}
		if (y <= num4)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		if (num <= x2)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		if (x >= num3)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		return true;
	}
}
