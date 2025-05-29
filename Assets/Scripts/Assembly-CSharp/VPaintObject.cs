using System;
using System.Collections;
using System.Collections.Generic;
using A;
using Core;
using UnityEngine;
using Valkyrie.VPaint;

[ExecuteInEditMode]
[AddComponentMenu("VPaint/VPaint Object")]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class VPaintObject : MonoBehaviour, IVPaintIdentifier
{
	public static List<VPaintObject> all = new List<VPaintObject>();

	[HideInInspector]
	public Mesh _mesh;

	[NonSerialized]
	public Mesh _meshNonSerialized;

	[HideInInspector]
	public Material originalMaterial;

	[HideInInspector]
	public Mesh originalMesh;

	[NonSerialized]
	public Color[] colorsBuilder;

	[NonSerialized]
	public float[] transparencyBuilder;

	[NonSerialized]
	public int index;

	[NonSerialized]
	public Color[] myColors;

	[NonSerialized]
	public Vector3[] myVertices;

	[HideInInspector]
	public MeshCollider editorCollider;

	private MeshRenderer _meshRenderer;

	private MeshFilter _meshFilter;

	[SerializeField]
	private bool _isDynamic;

	private Material instancedMaterial;

	private MeshRenderer c436170ac290329e42049d308ddbdead4
	{
		get
		{
			if (!_meshRenderer)
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
				_meshRenderer = GetComponent<MeshRenderer>();
			}
			return _meshRenderer;
		}
	}

	private MeshFilter c1b0ab22440fbcc60df2f472261cf4d03
	{
		get
		{
			if (!_meshFilter)
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
				_meshFilter = GetComponent<MeshFilter>();
			}
			return _meshFilter;
		}
	}

	public bool c38cb1eed166b6c6ce16a48473b997952
	{
		get
		{
			return _isDynamic;
		}
		set
		{
			if (value == _isDynamic)
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
				if (!value)
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
					if ((bool)editorCollider)
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
						UnityEngine.Object.Destroy(editorCollider.gameObject);
						goto IL_005c;
					}
				}
				c51ee6e0110d25afc689fc3e68c718021();
				goto IL_005c;
				IL_005c:
				value = _isDynamic;
				return;
			}
		}
	}

	public static List<VPaintObject> ce60f76e72eaed45ea61930c7c5e99cc0(Vector3 cef9712200bbe2c3873eec3ca2e18a595, float c910cd76e621cfb0fa326d295444e5d55)
	{
		float num = c910cd76e621cfb0fa326d295444e5d55 * c910cd76e621cfb0fa326d295444e5d55;
		List<VPaintObject> list = new List<VPaintObject>();
		using (List<VPaintObject>.Enumerator enumerator = all.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				VPaintObject current = enumerator.Current;
				if (!current)
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
				}
				else
				{
					if (!(current.renderer.bounds.SqrDistance(cef9712200bbe2c3873eec3ca2e18a595) < num))
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
					list.Add(current);
				}
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				return list;
			}
		}
	}

	private void c51ee6e0110d25afc689fc3e68c718021()
	{
		GameObject gameObject = new GameObject(base.name + " Collider");
		gameObject.hideFlags = HideFlags.HideInHierarchy;
		editorCollider = gameObject.AddComponent<MeshCollider>();
		editorCollider.sharedMesh = originalMesh;
	}

	public void OnApplicationQuit()
	{
		OnDestroy();
	}

	public void OnDestroy()
	{
		if ((bool)_mesh)
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
			if (_mesh != originalMesh)
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
				UnityEngine.Object.DestroyImmediate(_mesh);
			}
		}
		all.Remove(this);
		if (!editorCollider)
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
			UnityEngine.Object.DestroyImmediate(editorCollider.gameObject);
			return;
		}
	}

	public void OnEnable()
	{
		if (Application.isPlaying)
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
			if (!_mesh)
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
			UnityEngine.Object[] array = UnityEngine.Object.FindObjectsOfType(Type.GetTypeFromHandle(c0660c8466252dc3b170922a2e291f97b.cc1720d05c75832f704b87474932341c3()));
			UnityEngine.Object[] array2 = array;
			foreach (UnityEngine.Object @object in array2)
			{
				VPaintObject vPaintObject = @object as VPaintObject;
				if (vPaintObject == this)
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
					continue;
				}
				if (!(vPaintObject._mesh == _mesh))
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
					_mesh = c8daf33963c4c831f4bebda3f27067f17.c7088de59e49f7108f520cf7e0bae167e;
					c9ad2c401546a29463aa1117c3f13a666();
					return;
				}
			}
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
	}

	public void Awake()
	{
		if (!Application.isPlaying)
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
					return;
				}
			}
		}
		if (!_isDynamic)
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
			c51ee6e0110d25afc689fc3e68c718021();
			return;
		}
	}

	public Color[] cae38ccf90cf33a547b0b84a6fe0425f0()
	{
		return cdde5b1604999906d214f0b05ebcc515b().colors;
	}

	public Vector3[] c0ff330c92799fd91c77a0a460add7dc0()
	{
		return cdde5b1604999906d214f0b05ebcc515b().vertices;
	}

	public void cbec59bd01f76e4395aca1fade53c4ae3(Color[] c81ab568aadb36f0d1d090dcd90f07953)
	{
		Mesh mesh = cdde5b1604999906d214f0b05ebcc515b();
		if (c81ab568aadb36f0d1d090dcd90f07953.Length != myVertices.Length)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					for (int i = 0; i < c81ab568aadb36f0d1d090dcd90f07953.Length; i++)
					{
						c81ab568aadb36f0d1d090dcd90f07953[i] = Color.magenta;
					}
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Graphics, "Invalid vertex colors assigned to " + base.name + ". Check the Maintenance window for your VPaint Group for more info.");
							return;
						}
					}
				}
				}
			}
		}
		for (int j = 0; j < c81ab568aadb36f0d1d090dcd90f07953.Length; j++)
		{
			myColors[j] = c81ab568aadb36f0d1d090dcd90f07953[j];
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			mesh.colors = myColors;
			return;
		}
	}

	public bool IsEqualTo(IVPaintIdentifier obj)
	{
		return obj == this;
	}

	public Bounds c018339f13387f9419cb777b2e46f4087()
	{
		if ((bool)editorCollider)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return editorCollider.bounds;
				}
			}
		}
		return base.renderer.bounds;
	}

	public void c2399496032f40ebe7a98946db00a141d()
	{
		if (colorsBuilder == null)
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
		if (transparencyBuilder == null)
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
		Mesh mesh = cdde5b1604999906d214f0b05ebcc515b();
		mesh.colors = colorsBuilder;
		myColors = colorsBuilder;
		colorsBuilder = ced3d90993f8ad0244e6ffe666e5d70e3.c7088de59e49f7108f520cf7e0bae167e;
		transparencyBuilder = cc85691b95eca272682421b44175d2a17.c7088de59e49f7108f520cf7e0bae167e;
	}

	public Mesh cdde5b1604999906d214f0b05ebcc515b()
	{
		if (!this)
		{
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
				return null;
			}
		}
		if (!c1b0ab22440fbcc60df2f472261cf4d03)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				return null;
			}
		}
		if (!_mesh)
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
			if (!_meshNonSerialized)
			{
				if (!c1b0ab22440fbcc60df2f472261cf4d03.sharedMesh)
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
					if (!originalMesh)
					{
						while (true)
						{
							switch (3)
							{
							case 0:
								break;
							default:
								return null;
							}
						}
					}
				}
				if ((bool)originalMesh)
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
					c1b0ab22440fbcc60df2f472261cf4d03.sharedMesh = originalMesh;
				}
				originalMesh = c1b0ab22440fbcc60df2f472261cf4d03.sharedMesh;
				VertexDataCache component = GetComponent<VertexDataCache>();
				if ((bool)component)
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
					_mesh = component.cdde5b1604999906d214f0b05ebcc515b();
				}
				else
				{
					_mesh = UnityEngine.Object.Instantiate(c1b0ab22440fbcc60df2f472261cf4d03.sharedMesh) as Mesh;
				}
				c1b0ab22440fbcc60df2f472261cf4d03.sharedMesh = _mesh;
				myVertices = _mesh.vertices;
				Color[] colors = _mesh.colors;
				if (colors != null)
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
					if (colors.Length == myVertices.Length)
					{
						goto IL_01c9;
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
				}
				Color[] colors2 = (myColors = c9f85b5d461e935e3fe059d6462b10a03.c0a0cdf4a196914163f7334d9b0781a04(myVertices.Length));
				_mesh.colors = colors2;
				goto IL_01c9;
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
			_mesh = _meshNonSerialized;
		}
		goto IL_0207;
		IL_01c9:
		if (_mesh.uv2.Length == 0)
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
			_mesh.uv2 = _mesh.uv;
		}
		_mesh.RecalculateBounds();
		goto IL_0207;
		IL_0207:
		c1b0ab22440fbcc60df2f472261cf4d03.sharedMesh = _mesh;
		_meshNonSerialized = _mesh;
		if (myVertices == null)
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
			myVertices = _mesh.vertices;
		}
		if (myColors == null)
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
			myColors = _mesh.colors;
		}
		return _mesh;
	}

	public void c9ad2c401546a29463aa1117c3f13a666()
	{
		if ((bool)_mesh)
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
			if (_mesh != originalMesh)
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
				UnityEngine.Object.DestroyImmediate(_mesh);
			}
		}
		_mesh = c8daf33963c4c831f4bebda3f27067f17.c7088de59e49f7108f520cf7e0bae167e;
		_meshNonSerialized = c8daf33963c4c831f4bebda3f27067f17.c7088de59e49f7108f520cf7e0bae167e;
		MeshFilter component = GetComponent<MeshFilter>();
		if (!component)
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
		component.sharedMesh = originalMesh;
		ceee0e9dedd8ce0ef88a399e69b6d17a0();
	}

	public void c7899a4aee7acd811f3e5f88c012a79af(Color[] c81ab568aadb36f0d1d090dcd90f07953)
	{
		Mesh mesh = cdde5b1604999906d214f0b05ebcc515b();
		if (c81ab568aadb36f0d1d090dcd90f07953.Length != myVertices.Length)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Graphics, "Colors length of " + base.name + " is different than vertices length");
					return;
				}
			}
		}
		Vector4[] array = c6b9b486e00bdfd9ee7ce0bac7f34a00e.c0a0cdf4a196914163f7334d9b0781a04(c81ab568aadb36f0d1d090dcd90f07953.Length);
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = c81ab568aadb36f0d1d090dcd90f07953[i];
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			mesh.tangents = array;
			return;
		}
	}

	public void ce885aa0d1b7c97426a36cb383d2ef24c(Color c2022f114954310f1130ded90da1fb8b7)
	{
		Mesh mesh = cdde5b1604999906d214f0b05ebcc515b();
		Color[] array = myColors;
		if (array == null)
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
			array = mesh.colors;
		}
		if (array != null)
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
			if (array.Length != 0)
			{
				goto IL_005d;
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
		array = c9f85b5d461e935e3fe059d6462b10a03.c0a0cdf4a196914163f7334d9b0781a04(mesh.vertices.Length);
		goto IL_005d;
		IL_005d:
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = c2022f114954310f1130ded90da1fb8b7;
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			mesh.colors = array;
			return;
		}
	}

	public void c2ccae518c645e81239c1d7b3f7625194(Vector3 c51a8e07ec6dcf2bf31a58a12e24f0421, VPaintObjectPositionalModifier cdf9db16670994041db627d073b69a8b0)
	{
		Mesh mesh = cdde5b1604999906d214f0b05ebcc515b();
		Vector3[] array = myVertices;
		Color[] colors = myColors;
		if (colors == null)
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
			colors = mesh.colors;
		}
		int num = array.Length;
		for (int i = 0; i < num; i++)
		{
			Vector3 a = base.transform.TransformPoint(array[i]);
			float distance = Vector3.Distance(a, c51a8e07ec6dcf2bf31a58a12e24f0421);
			colors[i] = cdf9db16670994041db627d073b69a8b0(colors[i], distance);
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			mesh.colors = colors;
			myColors = colors;
			return;
		}
	}

	public IEnumerator c6c35012e6563cca31b65bf2ce00819e9(Vector3 c51a8e07ec6dcf2bf31a58a12e24f0421, VPaintObjectPositionalModifier cdf9db16670994041db627d073b69a8b0, float cad9f703d862495149cd6bddd080f050b)
	{
		Mesh j = cdde5b1604999906d214f0b05ebcc515b();
		Vector3[] vertices = myVertices;
		Color[] colors = myColors;
		if (colors == null)
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
			colors = j.colors;
		}
		int len = vertices.Length;
		Color[] target = c9f85b5d461e935e3fe059d6462b10a03.c0a0cdf4a196914163f7334d9b0781a04(len);
		for (int i = 0; i < len; i++)
		{
			Vector3 v = base.transform.TransformPoint(vertices[i]);
			float distance = Vector3.Distance(v, c51a8e07ec6dcf2bf31a58a12e24f0421);
			target[i] = cdf9db16670994041db627d073b69a8b0(colors[i], distance);
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				continue;
			}
			IEnumerator routine = VPaintUtility.LerpColors(this, colors, target, cad9f703d862495149cd6bddd080f050b);
			while (routine.MoveNext())
			{
				yield return c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e;
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					yield break;
				}
			}
		}
	}

	public void c381c142e4cb536a23602ded52e047e6e(Color c2022f114954310f1130ded90da1fb8b7, Vector3 c51a8e07ec6dcf2bf31a58a12e24f0421, float c910cd76e621cfb0fa326d295444e5d55, float c9cbd33e54532b6159b26e373b90f6e60, float c8dd7effeadbd39ab2a07ec4f5c587ab6)
	{
		c2ccae518c645e81239c1d7b3f7625194(c51a8e07ec6dcf2bf31a58a12e24f0421, delegate(Color ceacb19a4ed73f90d25df5977139fddb1, float cf0ecbb9b13151932b8293691a84d1c24)
		{
			if (c910cd76e621cfb0fa326d295444e5d55 < cf0ecbb9b13151932b8293691a84d1c24)
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
						return ceacb19a4ed73f90d25df5977139fddb1;
					}
				}
			}
			float t = Mathf.Pow(1f - cf0ecbb9b13151932b8293691a84d1c24 / c910cd76e621cfb0fa326d295444e5d55, c9cbd33e54532b6159b26e373b90f6e60) * c8dd7effeadbd39ab2a07ec4f5c587ab6;
			return Color.Lerp(ceacb19a4ed73f90d25df5977139fddb1, c2022f114954310f1130ded90da1fb8b7, t);
		});
	}

	public void c8c90d3f27332249424a6d6c559cb9230(float c1ab67f2623a1293ab32e224829336cd3, Vector3 c51a8e07ec6dcf2bf31a58a12e24f0421, float c910cd76e621cfb0fa326d295444e5d55, float c9cbd33e54532b6159b26e373b90f6e60, float c8dd7effeadbd39ab2a07ec4f5c587ab6)
	{
		c2ccae518c645e81239c1d7b3f7625194(c51a8e07ec6dcf2bf31a58a12e24f0421, delegate(Color ceacb19a4ed73f90d25df5977139fddb1, float cf0ecbb9b13151932b8293691a84d1c24)
		{
			if (c910cd76e621cfb0fa326d295444e5d55 < cf0ecbb9b13151932b8293691a84d1c24)
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
						return ceacb19a4ed73f90d25df5977139fddb1;
					}
				}
			}
			float t = Mathf.Pow(1f - cf0ecbb9b13151932b8293691a84d1c24 / c910cd76e621cfb0fa326d295444e5d55, c9cbd33e54532b6159b26e373b90f6e60) * c8dd7effeadbd39ab2a07ec4f5c587ab6;
			ceacb19a4ed73f90d25df5977139fddb1.a = Mathf.Lerp(ceacb19a4ed73f90d25df5977139fddb1.a, c1ab67f2623a1293ab32e224829336cd3, t);
			return ceacb19a4ed73f90d25df5977139fddb1;
		});
	}

	public void ca3359aa601be1e5eb1ea06b7030f1685(Material ce496f2302aa3f83a2edca09168844502)
	{
		if (!base.renderer)
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
		if (!originalMaterial)
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
			originalMaterial = base.renderer.sharedMaterial;
		}
		base.renderer.sharedMaterial = ce496f2302aa3f83a2edca09168844502;
		instancedMaterial = ce496f2302aa3f83a2edca09168844502;
	}

	public void ceee0e9dedd8ce0ef88a399e69b6d17a0()
	{
		if (!base.renderer)
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
					return;
				}
			}
		}
		if (base.renderer.sharedMaterial != instancedMaterial)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					originalMaterial = base.renderer.sharedMaterial;
					return;
				}
			}
		}
		if (!originalMaterial)
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
			base.renderer.sharedMaterial = originalMaterial;
			return;
		}
	}
}
