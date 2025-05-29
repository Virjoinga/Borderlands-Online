using System.Collections.Generic;
using A;
using UnityEngine;
using XsdSettings;

public class NPCDialogView : BaseView
{
	protected bool _bTestvisible;

	protected XsdSettings.TownNpc _NPCSetting;

	protected int _iOnShowStrIndex = -1;

	protected List<string> _strDialogList = new List<string>();

	protected GameObject m_dialogCamera;

	public override bool c57b6c6861c1d709f4f7aa7b8a699b5c9()
	{
		return true;
	}

	public void c52bb22ffb228abf4382a86779891bb80(bool c74232243aff1dcbf2e8fc243633bb51a)
	{
		_bTestvisible = c74232243aff1dcbf2e8fc243633bb51a;
	}

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().cbfdeda957ab87de3d0acf25194e61c4c(this);
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c239889f6079aa61647e3c4b8f3627d00(c7bb86b60f299c950179b9bd1c30a2a68);
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c0bd653723f77fd78e6c7d4d25ed14dcd(c7bb86b60f299c950179b9bd1c30a2a68);
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().cfdafa122fc114376585cbb27b8811a86(this);
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
	}

	public override bool cc130a2d46a451dc54b61a8f0d60794ae()
	{
		if (c150264a18c2cb408479d3f072cac8cc1)
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
					NPC_UIFlowController.c71f6ce28731edfd43c976fbd57c57bea().cfdf90c86b56eee510f610ea962abe27b(NPC_UIFlowController.NPC_UIFlowState.FunctionList);
					return true;
				}
			}
		}
		return base.cc130a2d46a451dc54b61a8f0d60794ae();
	}

	protected void c7bb86b60f299c950179b9bd1c30a2a68()
	{
		if (!_bVisible)
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
					return;
				}
			}
		}
		if (!c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.ca561485909b8620867b83991201b70d3(0))
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
			_iOnShowStrIndex++;
			if (_iOnShowStrIndex < _strDialogList.Count)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						c2fa8a6ee40c4f7f52aa7c2003b19c513();
						return;
					}
				}
			}
			NPC_UIFlowController.c71f6ce28731edfd43c976fbd57c57bea().cfdf90c86b56eee510f610ea962abe27b(NPC_UIFlowController.NPC_UIFlowState.Quest);
			return;
		}
	}

	public bool c3dcc75cd10b9ee6a7830e31932f6df00()
	{
		return _NPCSetting != cdfd8a8ffcb3189a52a3fc228a94319da.c7088de59e49f7108f520cf7e0bae167e;
	}

	public virtual void cbf02f618cec2bb6ec0c7e716b8cbce65(string c74ac62ff669a886a2f2240d313d2e9a3 = null)
	{
		_strDialogList.Clear();
		_iOnShowStrIndex = 0;
		if (c74ac62ff669a886a2f2240d313d2e9a3 == null)
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
			if (_NPCSetting != null)
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
				_strDialogList.Add(_NPCSetting.m_greetingsId);
				goto IL_0060;
			}
		}
		_strDialogList.Add(c74ac62ff669a886a2f2240d313d2e9a3);
		goto IL_0060;
		IL_0060:
		c2fa8a6ee40c4f7f52aa7c2003b19c513();
	}

	public virtual void cbf02f618cec2bb6ec0c7e716b8cbce65(string[] cd5dc5763f862b67fe053750383f78df8)
	{
		_iOnShowStrIndex = 0;
		_strDialogList = new List<string>(cd5dc5763f862b67fe053750383f78df8);
		c2fa8a6ee40c4f7f52aa7c2003b19c513();
	}

	public void c5c5e4b4ccad80ebe798c7ebbfb613299(GameObject c6374444951cc8820e934e68c2ec37889)
	{
		if (!(c6374444951cc8820e934e68c2ec37889 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			m_dialogCamera = c6374444951cc8820e934e68c2ec37889;
			return;
		}
	}

	protected virtual void c2fa8a6ee40c4f7f52aa7c2003b19c513()
	{
	}
}
