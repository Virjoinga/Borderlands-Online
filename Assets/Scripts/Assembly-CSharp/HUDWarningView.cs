using A;

public class HUDWarningView : BaseView
{
	protected Delegate_EventProc _ConfirmProc;

	protected Delegate_EventProc _CancelProc;

	protected string m_strWarningText = string.Empty;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().cbfdeda957ab87de3d0acf25194e61c4c(this);
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().cfdafa122fc114376585cbb27b8811a86(this);
	}

	public virtual void c5200a497e5e56ce55ab88bb16853c3d8(string c7033d7f579ec542d7cca3c8e32d316d4, string c88366ab379be430cd8802fc113358ffa)
	{
	}

	public virtual void cea4468dc2438c0952d375da1a5a17607(string cad8d6e0a594ee2e7b3f487fb75cd3d59 = "", Delegate_EventProc c3ecf27f8d510a71f06e60a77ad171ed9 = null, Delegate_EventProc c87b9485b73761da34a9344ae11698587 = null)
	{
		c150264a18c2cb408479d3f072cac8cc1 = true;
		m_strWarningText = cad8d6e0a594ee2e7b3f487fb75cd3d59;
		_ConfirmProc = c3ecf27f8d510a71f06e60a77ad171ed9;
		_CancelProc = c87b9485b73761da34a9344ae11698587;
	}

	public virtual void cfd58c94350618be817cfdb449a158aad(bool c56e59f369525e00cfdef7ef793e66596 = true)
	{
		if (c56e59f369525e00cfdef7ef793e66596)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (_CancelProc != null)
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
				_CancelProc();
			}
		}
		else if (_ConfirmProc != null)
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
			_ConfirmProc();
		}
		c150264a18c2cb408479d3f072cac8cc1 = false;
		_ConfirmProc = c68ab6f5d12f16a1d54aa92651de73463.c7088de59e49f7108f520cf7e0bae167e;
		_CancelProc = c68ab6f5d12f16a1d54aa92651de73463.c7088de59e49f7108f520cf7e0bae167e;
		m_strWarningText = string.Empty;
	}

	public virtual void c5734fb1245ed054d8619adf30ecab3c8(string c9bbc30d75f7bf3ca249130e81ff0fd6d = "")
	{
	}

	public virtual void ce14ab3b98c66fd882f4ebb627236ed4f()
	{
	}
}
