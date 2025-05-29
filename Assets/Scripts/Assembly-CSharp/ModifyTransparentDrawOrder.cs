using A;
using UnityEngine;

[ExecuteInEditMode]
public class ModifyTransparentDrawOrder : MonoBehaviour
{
	public int LayerNum;

	private void Start()
	{
		int num = 3000;
		Renderer component = base.gameObject.GetComponent<Renderer>();
		if (!(component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			for (int i = 0; i < component.materials.Length; i++)
			{
				Material material = component.materials[i];
				material.renderQueue = num + LayerNum;
			}
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
	}
}
