using System.Collections.Generic;
using A;
using UnityEngine;

public class HighlightWrapper
{
	private E_HighlightType m_state_highlight;

	private Dictionary<E_HighlightType, Color> m_colorDic = new Dictionary<E_HighlightType, Color>
	{
		{
			E_HighlightType.None,
			Color.white
		},
		{
			E_HighlightType.Silver,
			new Color(40f / 51f, 40f / 51f, 40f / 51f)
		},
		{
			E_HighlightType.Golden,
			new Color(1f, 0.8156863f, 21f / 85f)
		}
	};

	private Material matHighlightTransparent;

	private bool bDrawingInTransparentQueue;

	private bool m_bOtherEntityExit;

	private Material matHighlight;

	private Material[] arrHighlightMatCache;

	private Material[] arrOriginalMatCache;

	private Mesh[] meshes;

	public E_HighlightType cc3d1f78e30a88b8755ee1613e0f61039
	{
		get
		{
			return m_state_highlight;
		}
		set
		{
			m_state_highlight = value;
		}
	}

	public void ca3a4e42c026dd118d96d9b26744e311b(GameObject c0f8c7247a91b9b4d42f0cacdb6ba1d07, E_HighlightType cf2353f300f592cfe033872788352a1be, bool cbf33c7320016d4f4097ef66731046d7b)
	{
		if (cc3d1f78e30a88b8755ee1613e0f61039 == cf2353f300f592cfe033872788352a1be)
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
			if (m_bOtherEntityExit == cbf33c7320016d4f4097ef66731046d7b)
			{
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
		if (matHighlightTransparent == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			GameObject gameObject = Resources.Load("Graphics/GraphicsData") as GameObject;
			CharacterOutlineEffectData component = gameObject.GetComponent<CharacterOutlineEffectData>();
			matHighlightTransparent = component.matHighlightTransparent;
			m_colorDic[E_HighlightType.None] = component.noneColor;
			m_colorDic[E_HighlightType.Silver] = component.silverColor;
			m_colorDic[E_HighlightType.Golden] = component.goldenColor;
		}
		if (matHighlightTransparent == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		m_bOtherEntityExit = cbf33c7320016d4f4097ef66731046d7b;
		bDrawingInTransparentQueue = cbf33c7320016d4f4097ef66731046d7b;
		cc3d1f78e30a88b8755ee1613e0f61039 = cf2353f300f592cfe033872788352a1be;
		Color color = m_colorDic[cc3d1f78e30a88b8755ee1613e0f61039];
		float value = 0f;
		if (cc3d1f78e30a88b8755ee1613e0f61039 != 0)
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
			if (!bDrawingInTransparentQueue)
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
				value = matHighlightTransparent.GetFloat("_OutlineWidth");
			}
		}
		SkinnedMeshRenderer[] componentsInChildren = c0f8c7247a91b9b4d42f0cacdb6ba1d07.GetComponentsInChildren<SkinnedMeshRenderer>();
		foreach (SkinnedMeshRenderer skinnedMeshRenderer in componentsInChildren)
		{
			if (!skinnedMeshRenderer)
			{
				continue;
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
			for (int j = 0; j < skinnedMeshRenderer.materials.Length; j++)
			{
				Material material = skinnedMeshRenderer.materials[j];
				if (!(material.shader.name == "Custom/BOL_Charactor_BRDF"))
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
					if (!(material.shader.name == "Custom/BOL_Wpn_MaskReflect"))
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
				}
				material.SetColor("_OutlineColor", color);
				material.SetFloat("_OutlineWidth", value);
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

	public void c3fa255c4c719e308e0d4504a40033428(GameObject c0f8c7247a91b9b4d42f0cacdb6ba1d07, E_HighlightType cf2353f300f592cfe033872788352a1be, bool cbf33c7320016d4f4097ef66731046d7b)
	{
		if (cc3d1f78e30a88b8755ee1613e0f61039 == cf2353f300f592cfe033872788352a1be)
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
			if (m_bOtherEntityExit == cbf33c7320016d4f4097ef66731046d7b)
			{
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
		}
		if (!(matHighlight == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (!(matHighlightTransparent == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
			{
				goto IL_00d7;
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
		GameObject gameObject = Resources.Load("Graphics/GraphicsData") as GameObject;
		CharacterOutlineEffectData component = gameObject.GetComponent<CharacterOutlineEffectData>();
		matHighlight = component.matHighlight;
		matHighlightTransparent = component.matHighlightTransparent;
		m_colorDic[E_HighlightType.None] = component.noneColor;
		m_colorDic[E_HighlightType.Silver] = component.silverColor;
		m_colorDic[E_HighlightType.Golden] = component.goldenColor;
		goto IL_00d7;
		IL_00d7:
		if (matHighlight == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (matHighlightTransparent == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_bOtherEntityExit = cbf33c7320016d4f4097ef66731046d7b;
			Material material;
			if (cbf33c7320016d4f4097ef66731046d7b)
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
				material = matHighlightTransparent;
			}
			else
			{
				material = matHighlight;
			}
			Material material2 = material;
			E_HighlightType e_HighlightType = cc3d1f78e30a88b8755ee1613e0f61039;
			cc3d1f78e30a88b8755ee1613e0f61039 = cf2353f300f592cfe033872788352a1be;
			Color color = m_colorDic[cc3d1f78e30a88b8755ee1613e0f61039];
			MeshRenderer[] componentsInChildren = c0f8c7247a91b9b4d42f0cacdb6ba1d07.GetComponentsInChildren<MeshRenderer>();
			foreach (MeshRenderer meshRenderer in componentsInChildren)
			{
				if (!meshRenderer)
				{
					continue;
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				int num;
				if (cc3d1f78e30a88b8755ee1613e0f61039 != 0)
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
					num = 0;
					if (e_HighlightType == E_HighlightType.None)
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
						num = meshRenderer.materials.Length + 1;
					}
					else
					{
						num = meshRenderer.materials.Length;
					}
					if (arrHighlightMatCache != null)
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
						if (arrHighlightMatCache.Length == num)
						{
							goto IL_020b;
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
					arrHighlightMatCache = cb49f36706caafb4b94436f6a37599753.c0a0cdf4a196914163f7334d9b0781a04(num);
					goto IL_020b;
				}
				if (arrOriginalMatCache != null)
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
					if (arrOriginalMatCache.Length == meshRenderer.materials.Length - 1)
					{
						goto IL_02b5;
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
				}
				arrOriginalMatCache = cb49f36706caafb4b94436f6a37599753.c0a0cdf4a196914163f7334d9b0781a04(meshRenderer.materials.Length - 1);
				goto IL_02b5;
				IL_020b:
				for (int j = 0; j < num - 1; j++)
				{
					arrHighlightMatCache[j] = meshRenderer.materials[j];
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
				arrHighlightMatCache[num - 1] = material2;
				material2.SetColor("_OutlineColor", color);
				meshRenderer.materials = arrHighlightMatCache;
				continue;
				IL_02b5:
				for (int k = 0; k < meshRenderer.materials.Length - 1; k++)
				{
					arrOriginalMatCache[k] = meshRenderer.materials[k];
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
				meshRenderer.materials = arrOriginalMatCache;
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

	public void OnRenderObject(GameObject _gameObj)
	{
		if (!bDrawingInTransparentQueue)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (cc3d1f78e30a88b8755ee1613e0f61039 == E_HighlightType.None)
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
				if (matHighlightTransparent == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
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
				SkinnedMeshRenderer[] componentsInChildren = _gameObj.GetComponentsInChildren<SkinnedMeshRenderer>();
				if (meshes != null)
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
					if (meshes.Length == componentsInChildren.Length)
					{
						goto IL_00ba;
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
				meshes = ca6a8ca843a4497dfa8dad06768105ff8.c0a0cdf4a196914163f7334d9b0781a04(componentsInChildren.Length);
				for (int i = 0; i < meshes.Length; i++)
				{
					meshes[i] = new Mesh();
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
				goto IL_00ba;
				IL_00ba:
				for (int j = 0; j < componentsInChildren.Length; j++)
				{
					Transform transform = componentsInChildren[j].gameObject.transform;
					Matrix4x4 localToWorldMatrix = transform.localToWorldMatrix;
					Matrix4x4 identity = Matrix4x4.identity;
					identity = Matrix4x4.Scale(new Vector3(1f / transform.lossyScale.x, 1f / transform.lossyScale.y, 1f / transform.lossyScale.z));
					localToWorldMatrix *= identity;
					componentsInChildren[j].BakeMesh(meshes[j]);
					matHighlightTransparent.SetColor("_OutlineColor", m_colorDic[cc3d1f78e30a88b8755ee1613e0f61039]);
					Graphics.DrawMesh(meshes[j], localToWorldMatrix, matHighlightTransparent, 0);
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
	}
}
