using A;
using Core;
using UnityEngine;

public class LODSystem
{
	public static void cdd06e4efd6e69863d8b70e6de8c9542e(GameObject c80822505abd04406a7a821211bd77371, int c15196f8c6375c76998a6c704ee1529ee)
	{
		if (c80822505abd04406a7a821211bd77371.GetComponents<MeshFilter>() == null)
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
		GameObject[] array = cc918c40632f876558345d2b35eb025ba.c0a0cdf4a196914163f7334d9b0781a04(c15196f8c6375c76998a6c704ee1529ee);
		LOD[] array2 = c97450eafe2fa544ab5cc946419b7c423.c0a0cdf4a196914163f7334d9b0781a04(c15196f8c6375c76998a6c704ee1529ee);
		Mesh sharedMesh = c80822505abd04406a7a821211bd77371.GetComponent<MeshFilter>().sharedMesh;
		if (c15196f8c6375c76998a6c704ee1529ee == 1)
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
		LODGroup lODGroup = c80822505abd04406a7a821211bd77371.AddComponent<LODGroup>();
		for (int i = 1; i < c15196f8c6375c76998a6c704ee1529ee; i++)
		{
			array[i] = (GameObject)Object.Instantiate(c80822505abd04406a7a821211bd77371, Vector3.zero, Quaternion.identity);
			Object.Destroy(array[i].GetComponent<LODTag>());
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			for (int j = 0; j < c15196f8c6375c76998a6c704ee1529ee; j++)
			{
				Renderer[] array3 = c1d4abf32375524a882b934c078483350.c0a0cdf4a196914163f7334d9b0781a04(1);
				if (j == 0)
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
					array3[0] = c80822505abd04406a7a821211bd77371.renderer;
				}
				else
				{
					array[j].transform.parent = c80822505abd04406a7a821211bd77371.transform;
					array[j].transform.localPosition = Vector3.zero;
					array[j].transform.localRotation = Quaternion.identity;
					array[j].name = "LOD" + j;
					Mesh mesh = new Mesh();
					cdf3662fae863bc238312331a5f374029(sharedMesh, mesh, -1);
					array[j].GetComponent<MeshFilter>().mesh = mesh;
					array3[0] = array[j].renderer;
				}
				array2[j] = new LOD(1f / (float)(j + 1), array3);
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				lODGroup.SetLODS(array2);
				lODGroup.RecalculateBounds();
				return;
			}
		}
	}

	public static void cc18ca4e96797d19995153e4e9646334f(GameObject c80822505abd04406a7a821211bd77371, int c15196f8c6375c76998a6c704ee1529ee)
	{
		if (c80822505abd04406a7a821211bd77371.GetComponents<MeshFilter>() == null)
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
					return;
				}
			}
		}
		GameObject[] array = cc918c40632f876558345d2b35eb025ba.c0a0cdf4a196914163f7334d9b0781a04(c15196f8c6375c76998a6c704ee1529ee);
		LOD[] array2 = c97450eafe2fa544ab5cc946419b7c423.c0a0cdf4a196914163f7334d9b0781a04(c15196f8c6375c76998a6c704ee1529ee);
		Mesh sharedMesh = c80822505abd04406a7a821211bd77371.GetComponent<MeshFilter>().sharedMesh;
		if (c80822505abd04406a7a821211bd77371.GetComponent<LODGroup>() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			Renderer[] componentsInChildren = c80822505abd04406a7a821211bd77371.GetComponentsInChildren<Renderer>();
			foreach (Renderer renderer in componentsInChildren)
			{
				if (!renderer.gameObject.name.Contains("LOD"))
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
				Object.DestroyImmediate(renderer.gameObject);
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
			Object.DestroyImmediate(c80822505abd04406a7a821211bd77371.GetComponent<LODGroup>());
		}
		if (c15196f8c6375c76998a6c704ee1529ee == 1)
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
		LODGroup lODGroup = c80822505abd04406a7a821211bd77371.AddComponent<LODGroup>();
		for (int j = 1; j < c15196f8c6375c76998a6c704ee1529ee; j++)
		{
			array[j] = (GameObject)Object.Instantiate(c80822505abd04406a7a821211bd77371, Vector3.zero, Quaternion.identity);
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			for (int k = 0; k < c15196f8c6375c76998a6c704ee1529ee; k++)
			{
				Renderer[] array3 = c1d4abf32375524a882b934c078483350.c0a0cdf4a196914163f7334d9b0781a04(1);
				if (k == 0)
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
					array3[0] = c80822505abd04406a7a821211bd77371.renderer;
				}
				else
				{
					array[k].transform.parent = c80822505abd04406a7a821211bd77371.transform;
					array[k].transform.localPosition = Vector3.zero;
					array[k].transform.localRotation = Quaternion.identity;
					array[k].name = "LOD" + k;
					Mesh mesh = new Mesh();
					cdf3662fae863bc238312331a5f374029(sharedMesh, mesh, -1);
					array[k].GetComponent<MeshFilter>().mesh = mesh;
					array3[0] = array[k].renderer;
				}
				array2[k] = new LOD(1f / (float)(k + 1), array3);
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				lODGroup.SetLODS(array2);
				lODGroup.RecalculateBounds();
				return;
			}
		}
	}

	private static void cdf3662fae863bc238312331a5f374029(Mesh cf11c5580084c440905144411a6a380a0, Mesh c56b619f725ce213e27e56f775bbcb3a8, int cccb2ea154f80c11ad17a946c71293524)
	{
		QEMInput qEMInput = new QEMInput();
		qEMInput.m_vertex = cf11c5580084c440905144411a6a380a0.vertices;
		qEMInput.m_triangle = cf11c5580084c440905144411a6a380a0.triangles;
		if (cf11c5580084c440905144411a6a380a0.uv != null)
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
			qEMInput.m_uv = cf11c5580084c440905144411a6a380a0.uv;
			qEMInput.m_uvWeight = 0.05f;
		}
		if (cf11c5580084c440905144411a6a380a0.uv2 != null)
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
			qEMInput.m_uv2 = cf11c5580084c440905144411a6a380a0.uv2;
			qEMInput.m_uv2Weight = 500f;
		}
		if (cf11c5580084c440905144411a6a380a0.normals != null)
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
			qEMInput.m_normal = cf11c5580084c440905144411a6a380a0.normals;
			qEMInput.m_normalWeight = 0.05f;
		}
		if (cf11c5580084c440905144411a6a380a0.uv == null)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Graphics, "srcMesh.uv == null");
					return;
				}
			}
		}
		if (cf11c5580084c440905144411a6a380a0.uv2 == null)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Graphics, "srcMesh.uv2 == null");
					return;
				}
			}
		}
		QEMCenter qEMCenter = new QEMCenter(qEMInput);
		if (cccb2ea154f80c11ad17a946c71293524 > 0)
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
			qEMCenter.c5d4e5f2506c6b95a571431abe9acb13e(cccb2ea154f80c11ad17a946c71293524);
		}
		else if (cccb2ea154f80c11ad17a946c71293524 < 0)
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
			qEMCenter.c5d4e5f2506c6b95a571431abe9acb13e();
		}
		qEMCenter.c624e1595d9343108a5af5816211ee871(c56b619f725ce213e27e56f775bbcb3a8);
	}
}
