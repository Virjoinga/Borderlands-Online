using A;
using UnityEngine;

public class MinimapSwitch : MonoBehaviour
{
	public int MapTexIdxFrom0;

	private void OnTriggerEnter(Collider collider)
	{
		EntityPlayer component = collider.GetComponent<EntityPlayer>();
		if (!(component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (!(component.cd95354b53e674ec7dc9594e66e4d316f() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (!component.cd95354b53e674ec7dc9594e66e4d316f().c16d1154aec91a0f8f4a52d77fc081194())
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
					UIMapDataManager.c71f6ce28731edfd43c976fbd57c57bea().c19f5df9af6cc9db5bc7552a87f70f49b(MapTexIdxFrom0);
					return;
				}
			}
		}
	}
}
