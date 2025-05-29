using Core;
using UnityEngine;

public class LoginView : BaseView
{
	private string _testName = string.Empty;

	private string _testPassword = string.Empty;

	public LoginBehaviour _logicBehaviour;

	protected string _name = string.Empty;

	protected string _password = string.Empty;

	public override bool c57b6c6861c1d709f4f7aa7b8a699b5c9()
	{
		return false;
	}

	public override void OnTestGUI()
	{
		GUI.TextField(new Rect(100f, 100f, 80f, 25f), "Name:");
		GUI.TextField(new Rect(100f, 130f, 80f, 25f), "Password:");
		_testName = GUI.TextField(new Rect(185f, 100f, 145f, 25f), _testName, 20);
		_testPassword = GUI.PasswordField(new Rect(185f, 130f, 145f, 25f), _testPassword, "*"[0], 20);
		if (!GUI.Button(new Rect(140f, 170f, 100f, 25f), "Login"))
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
			cf157585a3977fe246b88a258164747cc(_testName, _testPassword);
			return;
		}
	}

	public virtual void cc6d8fb0627b56c504494f2637f0707f0(bool c38daa1ecfc4be57f0bab6f15b4488ecc)
	{
		if (!c38daa1ecfc4be57f0bab6f15b4488ecc)
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
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, "UI Base: Ooooooooops... system is busy!");
					return;
				}
			}
		}
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, "UI Base: OK you can do anything!");
	}

	public virtual void cd8807a5234c8bc932a35c30ae53838ee(string c5fe690777bf5dec9374fa61ab6703175, string c2b1dbe8e2d138df405faa6136d3c44c1)
	{
		_name = c5fe690777bf5dec9374fa61ab6703175;
		_password = c2b1dbe8e2d138df405faa6136d3c44c1;
	}

	protected void c236434cb1dd35d7dd3d7445ddba8a5a5(string c5fe690777bf5dec9374fa61ab6703175, string c2b1dbe8e2d138df405faa6136d3c44c1)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, "\n Password:" + c2b1dbe8e2d138df405faa6136d3c44c1);
	}

	protected void cf157585a3977fe246b88a258164747cc(string c5fe690777bf5dec9374fa61ab6703175, string c2b1dbe8e2d138df405faa6136d3c44c1)
	{
		_name = c5fe690777bf5dec9374fa61ab6703175;
		_password = c2b1dbe8e2d138df405faa6136d3c44c1;
		if (string.IsNullOrEmpty(_name))
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
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, "------No Name is here!!!!!------");
					return;
				}
			}
		}
		if (string.IsNullOrEmpty(_password))
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, "------No Password is here!!!!!------");
					return;
				}
			}
		}
		_logicBehaviour.cf54ad66cd295957df13a55870ed51497(_name, _password);
	}

	protected bool c5579ff2e2783eafd5ea42598a5482f87(string c5fe690777bf5dec9374fa61ab6703175, string c2b1dbe8e2d138df405faa6136d3c44c1)
	{
		if (string.IsNullOrEmpty(c5fe690777bf5dec9374fa61ab6703175))
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
					return false;
				}
			}
		}
		if (string.IsNullOrEmpty(c2b1dbe8e2d138df405faa6136d3c44c1))
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		return true;
	}
}
