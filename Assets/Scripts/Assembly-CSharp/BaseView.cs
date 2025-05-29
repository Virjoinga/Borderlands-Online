using System;

public class BaseView
{
	protected bool _bActive;

	protected bool _bVisible;

	private ViewVisbleChangeFunc _funcVisibleChange;

	public virtual bool cd0069281ff5290a7e6c484b6aed3933d
	{
		get
		{
			return _bActive;
		}
	}

	public virtual bool c150264a18c2cb408479d3f072cac8cc1
	{
		get
		{
			return _bVisible;
		}
		set
		{
			if (!cd0069281ff5290a7e6c484b6aed3933d)
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
				if (_bVisible == value)
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
					cbf5f806ecf4d92b475f68040522616cf(value);
					return;
				}
			}
		}
	}

	public virtual bool c57b6c6861c1d709f4f7aa7b8a699b5c9()
	{
		return false;
	}

	public virtual void OnTestGUI()
	{
	}

	protected virtual void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		if (_bVisible == c8be1fcd630e5fe96821376d111325750)
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
			_bVisible = c8be1fcd630e5fe96821376d111325750;
			if (_funcVisibleChange == null)
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
				_funcVisibleChange(this, _bVisible, c9e82bede03ea180ba65a597350997ad2);
				return;
			}
		}
	}

	public void cd709174be42fda430a2bdb7ad8549098(bool c74232243aff1dcbf2e8fc243633bb51a)
	{
		cbf5f806ecf4d92b475f68040522616cf(c74232243aff1dcbf2e8fc243633bb51a, true);
	}

	public void cc4d8eea4e06ec8ec2e166a7004d3700e(ViewVisbleChangeFunc cb24ea666f3f25bc975f1e84effd63cad)
	{
		_funcVisibleChange = (ViewVisbleChangeFunc)Delegate.Combine(_funcVisibleChange, cb24ea666f3f25bc975f1e84effd63cad);
	}

	public void cee6e47a3f2472df3eece01f53b58beea(ViewVisbleChangeFunc cb24ea666f3f25bc975f1e84effd63cad)
	{
		_funcVisibleChange = (ViewVisbleChangeFunc)Delegate.Remove(_funcVisibleChange, cb24ea666f3f25bc975f1e84effd63cad);
	}

	public virtual void cd93285db16841148ed53a5bbeb35cf20()
	{
		_bActive = true;
	}

	public virtual void cac7688b05e921e2be3f92479ba44b4a8()
	{
		if (_bVisible)
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
			cd709174be42fda430a2bdb7ad8549098(false);
		}
		_bActive = false;
	}

	public virtual bool OnScreenResized()
	{
		return false;
	}

	public virtual bool cc130a2d46a451dc54b61a8f0d60794ae()
	{
		return false;
	}

	public virtual bool OnShortCutCMD(string command)
	{
		if (!cd0069281ff5290a7e6c484b6aed3933d)
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
					return false;
				}
			}
		}
		c150264a18c2cb408479d3f072cac8cc1 = !c150264a18c2cb408479d3f072cac8cc1;
		return true;
	}
}
