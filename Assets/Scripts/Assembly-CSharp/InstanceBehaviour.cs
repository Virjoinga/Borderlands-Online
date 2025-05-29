using System.Collections.Generic;
using A;
using Core;
using UnityEngine;
using XsdSettings;

public class InstanceBehaviour : MonoBehaviour
{
	public static bool m_FocusedOnSelected = false;

	private bool m_bMouseOver;

	private bool m_bLocked;

	private string m_LevelID;

	private Animator m_Animator;

	private MeshRenderer m_MeshRender;

	private Material _CommonMaterial;

	private Material _SelectMaterial;

	private Material _LockMaterial;

	private Material _dailyQuestMaterial;

	private Material _questMaterial;

	private GameObject _questObj;

	public static bool m_bCanClick = true;

	private static List<int> m_InstanceList = new List<int>();

	public static int c1a605e22757a2d6d1113ddab3d23567a()
	{
		if (m_InstanceList.Count != 0)
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
					return m_InstanceList[0];
				}
			}
		}
		return 0;
	}

	public static bool cc28becfbf026be02ce2117a8b03bb537()
	{
		return m_InstanceList.Count != 0;
	}

	public static bool c89a7636a8125a41cf8849c69c2136973()
	{
		Playlist playlist = MatchmakingService.c5ee19dc8d4cccf5ae2de225410458b86.c2718b579e09549a1cd47620188a40a38(m_InstanceList[0]);
		if (playlist == null)
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
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "Trying to enter Playlist [" + m_InstanceList[0] + "]");
					return false;
				}
			}
		}
		return playlist.m_bossName != string.Empty;
	}

	public static string c57944e4bbc6cec134bb74186f64f35a5()
	{
		Playlist playlist = MatchmakingService.c5ee19dc8d4cccf5ae2de225410458b86.c2718b579e09549a1cd47620188a40a38(m_InstanceList[0]);
		if (playlist == null)
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
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Network, "Trying to enter Playlist [" + m_InstanceList[0] + "]");
					return string.Empty;
				}
			}
		}
		return playlist.m_bossName;
	}

	public void Start()
	{
		m_bMouseOver = false;
		m_LevelID = base.gameObject.name.Substring(base.gameObject.name.Length - 3, 3);
		m_Animator = base.gameObject.GetComponent<Animator>();
		m_Animator.speed = 0f;
		GameObject gameObject = GameObject.Find("Instance Selection");
		Transform component = gameObject.GetComponent<Transform>();
		for (int i = 0; i < component.childCount; i++)
		{
			if (component.GetChild(i).gameObject.name == "Material_Common_Cache")
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
				_CommonMaterial = component.GetChild(i).gameObject.GetComponent<MeshRenderer>().material;
			}
			if (component.GetChild(i).gameObject.name == "Material_Lock_Cache")
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
				_LockMaterial = component.GetChild(i).gameObject.GetComponent<MeshRenderer>().material;
			}
			if (component.GetChild(i).gameObject.name == "Material_Select_Cache")
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
				_SelectMaterial = component.GetChild(i).gameObject.GetComponent<MeshRenderer>().material;
			}
			if (component.GetChild(i).gameObject.name == "Material_QuestExist")
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
				_questMaterial = component.GetChild(i).gameObject.GetComponent<MeshRenderer>().material;
			}
			if (!(component.GetChild(i).gameObject.name == "Material_QuestBlue"))
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
			_dailyQuestMaterial = component.GetChild(i).gameObject.GetComponent<MeshRenderer>().material;
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			m_MeshRender = base.gameObject.GetComponent<MeshRenderer>();
			component = base.gameObject.GetComponent<Transform>();
			for (int j = 0; j < component.childCount; j++)
			{
				if (!(component.GetChild(j).gameObject.name == "Pro_Instance_QuestExist"))
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
					_questObj = component.GetChild(j).gameObject;
					return;
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
	}

	public void c436d39aab7fcf511f0d05bfa21382243()
	{
		m_bCanClick = true;
		m_Animator.speed = 1f;
		m_Animator.CrossFade("Base Layer.Empty", 0.01f);
		m_bLocked = LevelLockingManager.c71f6ce28731edfd43c976fbd57c57bea().cfbf6ce5213eb84d4ac07084f783da2ed(int.Parse(m_LevelID));
		if (m_bLocked)
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
			m_MeshRender.material = _LockMaterial;
		}
		else
		{
			m_MeshRender.material = _CommonMaterial;
		}
		if (!(_questObj != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			MeshRenderer component = _questObj.GetComponent<MeshRenderer>();
			NpcTitleMgr.NPC_ICON_TYPE nPC_ICON_TYPE = QuestUIDataManager.c71f6ce28731edfd43c976fbd57c57bea().ca481ed3c1b498d8142b62adaf2d68067(int.Parse(m_LevelID));
			if (nPC_ICON_TYPE == NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DONE)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						component.material = _questMaterial;
						_questObj.SetActive(true);
						return;
					}
				}
			}
			if (nPC_ICON_TYPE == NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DAILY_DONE)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						component.material = _dailyQuestMaterial;
						_questObj.SetActive(true);
						return;
					}
				}
			}
			_questObj.SetActive(false);
			return;
		}
	}

	public static void c08db3656c23a73a47b1a938945909eac()
	{
		m_InstanceList.Clear();
	}

	public void OnMouseOver()
	{
		if (m_InstanceList.Contains(int.Parse(m_LevelID)))
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
			m_FocusedOnSelected = true;
		}
		if (m_bLocked)
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
		if (!c7022fb8bd63bc57eb4438bbc03ad4176())
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
		if (m_bMouseOver)
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
			m_bMouseOver = true;
			m_MeshRender.material = _SelectMaterial;
			return;
		}
	}

	public void OnMouseExit()
	{
		if (m_InstanceList.Contains(int.Parse(m_LevelID)))
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
			m_FocusedOnSelected = false;
		}
		if (m_bLocked)
		{
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
		if (!c7022fb8bd63bc57eb4438bbc03ad4176())
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
		if (!m_bMouseOver)
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
			m_bMouseOver = false;
			m_MeshRender.material = _CommonMaterial;
			return;
		}
	}

	private bool c7022fb8bd63bc57eb4438bbc03ad4176()
	{
		if (m_InstanceList.Count == 0)
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
					return true;
				}
			}
		}
		if (m_InstanceList.Contains(int.Parse(m_LevelID)))
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return true;
				}
			}
		}
		return false;
	}

	public static void ca1b9dbcdbe8df928e93eeb9f3a881f3d()
	{
		GameObject gameObject = GameObject.Find("Instance Selection");
		Transform component = gameObject.GetComponent<Transform>();
		TownInstanceSelectionControl.c31dc9d024dbe410812f73d913424f88f(false);
		for (int i = 0; i < component.childCount; i++)
		{
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			int item = int.Parse(component.GetChild(i).gameObject.name.Substring(component.GetChild(i).gameObject.name.Length - 3, 3));
			if (!m_InstanceList.Contains(item))
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
			Animator component2 = component.GetChild(i).gameObject.GetComponent<Animator>();
			component2.speed = 1f;
			component2.CrossFade("Base Layer.Quit", 0.01f);
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			m_FocusedOnSelected = false;
			m_InstanceList.Clear();
			return;
		}
	}

	public void OnMouseUp()
	{
		if (m_bLocked)
		{
			while (true)
			{
				switch (5)
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
		if (!c7022fb8bd63bc57eb4438bbc03ad4176())
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
		if (!m_bCanClick)
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
			m_Animator.speed = 1f;
			TownInstanceSelectionControl.c31dc9d024dbe410812f73d913424f88f(true);
			m_Animator.CrossFade("Base Layer.Start", 0.01f);
			m_InstanceList.Clear();
			m_InstanceList.Add(int.Parse(m_LevelID));
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InstanceView>().cfe3722be9d3db53de899f357df1ae081();
			return;
		}
	}
}
