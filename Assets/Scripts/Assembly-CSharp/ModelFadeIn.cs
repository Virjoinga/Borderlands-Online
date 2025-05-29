using System.Collections.Generic;
using A;
using UnityEngine;

public class ModelFadeIn : MonoBehaviour
{
	public Texture2D roilTex;

	public Texture2D eneryTex;

	public Color highLightColor;

	public Shader characterShaderAttached;

	public Shader wpnShaderAttached;

	public float totalHeight = 3f;

	public float totalTime = 2f;

	public bool DirFromUpToDown;

	public Camera sceneCamera;

	private bool _isPlaying;

	private List<Material> _MaterialList;

	private List<Shader> _OriShaderList;

	private float _curTime;

	private Vector4 _startPos = new Vector4(0f, 0f, 0f, 1f);

	public bool c27b8b8f2b26d9420fc1ac46dcae468c9
	{
		get
		{
			return _isPlaying;
		}
	}

	private void Awake()
	{
	}

	public void cd93285db16841148ed53a5bbeb35cf20()
	{
		_isPlaying = false;
		_startPos = base.transform.position;
		_MaterialList = new List<Material>();
		_OriShaderList = new List<Shader>();
		Renderer[] componentsInChildren = base.gameObject.GetComponentsInChildren<Renderer>();
		foreach (Renderer renderer in componentsInChildren)
		{
			if (!(renderer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			Material[] materials = renderer.materials;
			for (int j = 0; j < materials.Length; j++)
			{
				_MaterialList.Add(materials[j]);
				_OriShaderList.Add(materials[j].shader);
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

	private void Update()
	{
		if (!_isPlaying)
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
			_curTime += Time.deltaTime;
			if (_curTime < totalTime)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
					{
						using (List<Material>.Enumerator enumerator = _MaterialList.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								Material current = enumerator.Current;
								float num = 0f;
								if (DirFromUpToDown)
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
									num = 2.2f * (totalTime - _curTime) / totalTime;
								}
								else
								{
									num = 2.2f * _curTime / totalTime;
								}
								current.SetVector("_CenterPosTime", new Vector4(_startPos.x, _startPos.y, _startPos.z, num));
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
					}
					}
				}
			}
			cdada4c3678c9c23c38aaf0754a94a620();
			return;
		}
	}

	public virtual void c0a75d7afd2f7f1e47a5aadaab61303c7()
	{
		_curTime = 0f;
		using (List<Material>.Enumerator enumerator = _MaterialList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Material current = enumerator.Current;
				if (current.shader.name == "Custom/BOL_Charactor_BRDF")
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
					current.shader = characterShaderAttached;
				}
				else
				{
					current.shader = wpnShaderAttached;
				}
				current.SetTexture("_RoilingFlameModule", roilTex);
				current.SetTexture("_PyroEnergy", eneryTex);
				current.SetVector("_CenterPosTime", new Vector4(_startPos.x, _startPos.y, _startPos.z, _curTime));
				current.SetVector("_EmissiveHightColor", highLightColor);
				current.DisableKeyword("DirUpToDown");
				current.DisableKeyword("DirDownToUp");
				if (DirFromUpToDown)
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
					current.EnableKeyword("DirUpToDown");
				}
				else
				{
					current.EnableKeyword("DirDownToUp");
				}
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					goto end_IL_0131;
				}
				continue;
				end_IL_0131:
				break;
			}
		}
		_isPlaying = true;
	}

	public virtual void cdada4c3678c9c23c38aaf0754a94a620()
	{
		_isPlaying = false;
		for (int i = 0; i < _MaterialList.Count; i++)
		{
			_MaterialList[i].shader = _OriShaderList[i];
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
			_curTime = 0f;
			return;
		}
	}

	public virtual void c4207787d36579661719681a2d411dede()
	{
		_isPlaying = false;
	}
}
