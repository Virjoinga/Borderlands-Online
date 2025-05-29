using System.Collections.Generic;
using A;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
	public enum MenuPage
	{
		None = 0,
		HostInstance = 1,
		CheatMenu = 2,
		SkillTree = 3
	}

	private Dictionary<MenuPage, string> m_pages;

	private void Awake()
	{
		m_pages = new Dictionary<MenuPage, string>
		{
			{
				MenuPage.HostInstance,
				"HostMenu"
			},
			{
				MenuPage.SkillTree,
				"SkillTreeMenu"
			}
		};
	}

	public void ca2697a254bbeb745c522c64f883c925a(MenuPage cb9de848f0954cfda229568ddfad44033)
	{
		c8c3a9943d5bdc6b630044f5e1f7e79af();
		if (cb9de848f0954cfda229568ddfad44033 == MenuPage.None)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			base.gameObject.AddComponent(m_pages[cb9de848f0954cfda229568ddfad44033]);
			return;
		}
	}

	private void c8c3a9943d5bdc6b630044f5e1f7e79af()
	{
		HostMenu component = GetComponent<HostMenu>();
		if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			Object.Destroy(GetComponent<HostMenu>());
		}
		SkillTreeMenu component2 = GetComponent<SkillTreeMenu>();
		if (!(component2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			component2.ce7ae451e46fa21f3e8f2e60314307ec6();
			Object.Destroy(GetComponent<SkillTreeMenu>());
			return;
		}
	}
}
