using A;
using UnityEngine;

public class WorldMapBehaviour : MonoBehaviour
{
	private bool m_bMouseOver;

	private bool m_bLocked;

	private string m_LevelID;

	private MeshRenderer m_MeshRender;

	private Material _CommonMaterial;

	private Material _SelectMaterial;

	private Material _LockMaterial;

	private GameObject _playerObj;

	public void Start()
	{
		m_bMouseOver = false;
		m_LevelID = base.gameObject.name.Substring(base.gameObject.name.Length - 3, 3);
		GameObject gameObject = GameObject.Find("World Map");
		Transform component = gameObject.GetComponent<Transform>();
		for (int i = 0; i < component.childCount; i++)
		{
			if (component.GetChild(i).gameObject.name == "Material_Common_Cache")
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
				_CommonMaterial = component.GetChild(i).gameObject.GetComponent<MeshRenderer>().material;
			}
			if (component.GetChild(i).gameObject.name == "Material_Lock_Cache")
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
				_LockMaterial = component.GetChild(i).gameObject.GetComponent<MeshRenderer>().material;
			}
			if (!(component.GetChild(i).gameObject.name == "Material_Select_Cache"))
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
			_SelectMaterial = component.GetChild(i).gameObject.GetComponent<MeshRenderer>().material;
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			m_MeshRender = base.gameObject.GetComponent<MeshRenderer>();
			component = base.gameObject.GetComponent<Transform>();
			for (int j = 0; j < component.childCount; j++)
			{
				if (!(component.GetChild(j).gameObject.name == "PlayerLocated"))
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
				_playerObj = component.GetChild(j).gameObject;
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

	public void c436d39aab7fcf511f0d05bfa21382243()
	{
		m_bLocked = LevelLockingManager.c71f6ce28731edfd43c976fbd57c57bea().cfbf6ce5213eb84d4ac07084f783da2ed(int.Parse(m_LevelID));
		if (m_bLocked)
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
			m_MeshRender.material = _LockMaterial;
		}
		else
		{
			m_MeshRender.material = _CommonMaterial;
		}
		if (c7357a84e2931ca684965424193dbf015())
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					if (!_playerObj.activeSelf)
					{
						while (true)
						{
							switch (7)
							{
							case 0:
								break;
							default:
								_playerObj.SetActive(true);
								return;
							}
						}
					}
					return;
				}
			}
		}
		_playerObj.SetActive(false);
	}

	public void OnMouseOver()
	{
		if (m_bLocked)
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
		if (m_bMouseOver)
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
			m_bMouseOver = true;
			m_MeshRender.material = _SelectMaterial;
			return;
		}
	}

	public void OnMouseExit()
	{
		if (m_bLocked)
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
		if (!m_bMouseOver)
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
			m_bMouseOver = false;
			m_MeshRender.material = _CommonMaterial;
			return;
		}
	}

	public void OnMouseUp()
	{
		if (m_bLocked)
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
		if (c7357a84e2931ca684965424193dbf015())
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
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<WorldMapSelectView>().c150264a18c2cb408479d3f072cac8cc1 = false;
		c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.cfe7182ecd28c1d073193664c0a470e42("OnGoToInstance", int.Parse(m_LevelID));
	}

	private bool c7357a84e2931ca684965424193dbf015()
	{
		return c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_playlistId == int.Parse(m_LevelID);
	}
}
