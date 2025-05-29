using System.Collections.Generic;
using A;
using UnityEngine;

public class TownInstanceSelectionControl
{
	private static GameObject _cameraObj = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;

	protected static List<int> m_InstanceList = new List<int>();

	public static bool cc552cc23538c00c3a15b965d2749b596()
	{
		if (_cameraObj != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			switch (4)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			InstanceBehaviour.ca1b9dbcdbe8df928e93eeb9f3a881f3d();
			c31dc9d024dbe410812f73d913424f88f(false);
			_cameraObj.SetActive(false);
			c2f18a3b5ccc9813ca1b7e1fcfcffdc75(false);
			return;
		}
	}

	public static void c20b4ba07771cf8d865c0ff126f5cb784()
	{
		GameObject gameObject = GameObject.Find("Instance Selection");
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
						switch (2)
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
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
				InstanceBehaviour component2 = component.GetChild(i).gameObject.GetComponent<InstanceBehaviour>();
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
				switch (5)
				{
				case 0:
					continue;
				}
				bool activeSelf = _cameraObj.activeSelf;
				if (activeSelf)
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
					cc5441980ac3f22768080730945fcb58e();
				}
				_cameraObj.SetActive(!activeSelf);
				c2f18a3b5ccc9813ca1b7e1fcfcffdc75(!activeSelf);
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
			switch (1)
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

	public static List<int> c0010e81ac585c9de1e18e6b8c90850de()
	{
		m_InstanceList.Clear();
		GameObject gameObject = GameObject.Find("Instance Selection");
		if ((bool)gameObject)
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
			Transform component = gameObject.GetComponent<Transform>();
			for (int i = 0; i < component.childCount; i++)
			{
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
				int item = int.Parse(component.GetChild(i).gameObject.name.Substring(component.GetChild(i).gameObject.name.Length - 3, 3));
				m_InstanceList.Add(item);
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
		return m_InstanceList;
	}

	public static void c31dc9d024dbe410812f73d913424f88f(bool c8be1fcd630e5fe96821376d111325750)
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
			DepthOfFieldScatter component = _cameraObj.GetComponent<DepthOfFieldScatter>();
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
				if (component.enabled == c8be1fcd630e5fe96821376d111325750)
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
					component.enabled = c8be1fcd630e5fe96821376d111325750;
					return;
				}
			}
		}
	}
}
