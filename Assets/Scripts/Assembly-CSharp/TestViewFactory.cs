using System;
using A;

public class TestViewFactory
{
	public enum ViewType
	{
		TestTeammateportrait = 0,
		TestWrapUp = 1,
		Testmatchmaking = 2,
		All = 3
	}

	private static TestViewFactory factory;

	private c8e81fbb352f6a532c1fd4a46305e91f9 m_curView;

	private TestViewFactory()
	{
	}

	public static TestViewFactory c71f6ce28731edfd43c976fbd57c57bea()
	{
		if (factory == null)
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
			factory = new TestViewFactory();
		}
		return factory;
	}

	public void cb0c41b302c345ae2ccda55729144ed4a(UniUIManager c532b9e27685f696d32331c089aec2fc2, ViewType c2b4f43f34e21572af6ab4414f04cee36)
	{
		if (m_curView != null)
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
			m_curView.cac7688b05e921e2be3f92479ba44b4a8();
			m_curView = c44768d96f809d3d509c41b3707aa37ab.c7088de59e49f7108f520cf7e0bae167e;
		}
		switch (c2b4f43f34e21572af6ab4414f04cee36)
		{
		case ViewType.TestTeammateportrait:
			m_curView = new c9f78f655c4c54b13154033525ab8adab(c532b9e27685f696d32331c089aec2fc2);
			break;
		case ViewType.TestWrapUp:
			m_curView = new c91aff805303ae5b9d8575bad699e1a6e(c532b9e27685f696d32331c089aec2fc2);
			break;
		case ViewType.Testmatchmaking:
			m_curView = new cc96858ead89ba1c23c655fe6ce1977da(c532b9e27685f696d32331c089aec2fc2);
			break;
		}
	}

	public ViewType c74cd1dab5f986fe723ada58db458e59d(string c5fe690777bf5dec9374fa61ab6703175)
	{
		c5fe690777bf5dec9374fa61ab6703175 = c5fe690777bf5dec9374fa61ab6703175.Replace(".swf", string.Empty);
		c5fe690777bf5dec9374fa61ab6703175 = "Test" + c5fe690777bf5dec9374fa61ab6703175.Replace("_", string.Empty).Replace(" ", string.Empty);
		ViewType result = ViewType.All;
		string[] names = Enum.GetNames(typeof(ViewType));
		for (int i = 0; i < names.Length; i++)
		{
			if (!(names[i] == c5fe690777bf5dec9374fa61ab6703175))
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				return (ViewType)i;
			}
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			return result;
		}
	}
}
