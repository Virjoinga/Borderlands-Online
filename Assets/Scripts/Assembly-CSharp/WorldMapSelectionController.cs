using A;
using UnityEngine;

public class WorldMapSelectionController
{
	private static GameObject _cameraObj;

	public static bool c201e69461401637f68794a86ca99b782()
	{
		if (_cameraObj != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return _cameraObj.activeSelf;
				}
			}
		}
		return false;
	}

	public static void cc5441980ac3f22768080730945fcb58e()
	{
		if (!(_cameraObj != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (!_cameraObj.activeSelf)
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
				_cameraObj.SetActive(false);
				c2f18a3b5ccc9813ca1b7e1fcfcffdc75(false);
				return;
			}
		}
	}

	public static void c019e3fcbf5d897f84f9f86a706775b78()
	{
		GameObject gameObject = GameObject.Find("World Map");
		if (!gameObject)
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
			Transform component = gameObject.GetComponent<Transform>();
			for (int i = 0; i < component.childCount; i++)
			{
				if (component.GetChild(i).gameObject.name == "InstanceSelectionCamera_Floasm")
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
					_cameraObj = component.GetChild(i).gameObject;
					continue;
				}
				if (!component.GetChild(i).gameObject.name.Contains("Pro_Instance_"))
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
				WorldMapBehaviour component2 = component.GetChild(i).gameObject.GetComponent<WorldMapBehaviour>();
				if (!(component2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				component2.c436d39aab7fcf511f0d05bfa21382243();
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				bool activeSelf = _cameraObj.activeSelf;
				_cameraObj.SetActive(!activeSelf);
				c2f18a3b5ccc9813ca1b7e1fcfcffdc75(!activeSelf);
				if (activeSelf)
				{
					while (true)
					{
						switch (5)
						{
						case 0:
							break;
						default:
							c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1570506bf0b326e191d0406037cb4fef();
							c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.c0888ee52497af70d4cc14624cbd11269();
							return;
						}
					}
				}
				c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1bdd1e7aa891de56d871ae24289f5f8b();
				c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.cca84ca4deababdecf8f3d8cc7a45edb9();
				TownBehaviour.m_bCheckWorldMap = true;
				return;
			}
		}
	}

	public static void c2f18a3b5ccc9813ca1b7e1fcfcffdc75(bool c8be1fcd630e5fe96821376d111325750)
	{
		EntityPlayer entityPlayer = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().c66b232dbebded7c7e9a89c1e8bd84689() as EntityPlayer;
		if (!entityPlayer)
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
			entityPlayer.c2f18a3b5ccc9813ca1b7e1fcfcffdc75(c8be1fcd630e5fe96821376d111325750);
			return;
		}
	}
}
