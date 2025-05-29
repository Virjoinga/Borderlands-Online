using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using Core;
using UnityEngine;
using pumpkin.display;
using pumpkin.events;

public class uniLoginView : LoginView
{
	private readonly LocalizedString _testString = new LocalizedString("Test String");

	private string _languageInput = string.Empty;

	private c196099a1254db61d3be10d70e14e7422 _panel;

	private c82f7c0afbcfc8c5382a8c6daa9365b7b mcLoginBtn;

	private c82f7c0afbcfc8c5382a8c6daa9365b7b mcSignBtn;

	private ccf8bd4afc86b3c33d69f65b1612538ce mcNameInput;

	private ccf8bd4afc86b3c33d69f65b1612538ce mcPasswordInput;

	[CompilerGenerated]
	private static Dictionary<string, int> _003C_003Ef__switch_0024map4;

	public override bool c57b6c6861c1d709f4f7aa7b8a699b5c9()
	{
		return false;
	}

	public override void OnTestGUI()
	{
		GUI.TextField(new Rect(500f, 600f, 280f, 25f), LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(_testString));
		_languageInput = GUI.TextField(new Rect(360f, 600f, 50f, 25f), _languageInput, 5);
		if (!GUI.Button(new Rect(200f, 600f, 150f, 25f), "Change Language:"))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			LocalizeSystem.c71f6ce28731edfd43c976fbd57c57bea().cfc8ae7589bb86588d34a387a4dbf2280(_languageInput);
			return;
		}
	}

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("Login.swf", "LoginView", c1141a8fde9aa0f410bc4a7fdd2e3ef7c);
	}

	private void c1141a8fde9aa0f410bc4a7fdd2e3ef7c(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_panel = new c196099a1254db61d3be10d70e14e7422();
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, "UI Base: Login view initializing!");
		_panel.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8, "game_enabled", OnWidgetInitialized);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cb4341b3564e3d55dc9f38df4b813c5da(_panel);
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c239889f6079aa61647e3c4b8f3627d00(c7bb86b60f299c950179b9bd1c30a2a68);
	}

	protected bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
	{
		bool result = false;
		string name = movieClip.name;
		if (name != null)
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
			if (_003C_003Ef__switch_0024map4 == null)
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
				Dictionary<string, int> dictionary = new Dictionary<string, int>(4);
				dictionary.Add("mcLoginBtn", 0);
				dictionary.Add("mcSignBtn", 1);
				dictionary.Add("mcNameInput", 2);
				dictionary.Add("mcPasswordInput", 3);
				_003C_003Ef__switch_0024map4 = dictionary;
			}
			int value;
			if (_003C_003Ef__switch_0024map4.TryGetValue(name, out value))
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
				switch (value)
				{
				case 0:
					mcLoginBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
					mcLoginBtn.c130648b59a0c8debea60aa153f844879(movieClip);
					mcLoginBtn.addEventListener(MouseEvent.CLICK, c533e34f1af2d0edbdd14b5a06d3aad16);
					result = true;
					break;
				case 1:
					mcSignBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
					mcSignBtn.c130648b59a0c8debea60aa153f844879(movieClip);
					mcSignBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
					result = true;
					break;
				case 2:
					mcNameInput = new ccf8bd4afc86b3c33d69f65b1612538ce();
					mcNameInput.c130648b59a0c8debea60aa153f844879(movieClip);
					mcNameInput.c09721d98c247dde8efe59bc3cebbad00 = _name;
					mcNameInput.ce8805cc02a868fbf01bc5a4fa7c97062 = true;
					result = true;
					break;
				case 3:
					mcPasswordInput = new ccf8bd4afc86b3c33d69f65b1612538ce();
					mcPasswordInput.c130648b59a0c8debea60aa153f844879(movieClip);
					mcPasswordInput.c99e714c3ac13a5f71f8be80bd4e975eb = true;
					mcPasswordInput.c09721d98c247dde8efe59bc3cebbad00 = _password;
					result = true;
					break;
				}
			}
		}
		return result;
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_panel);
		_panel = c9c0c8f01d2944aa6e09f167c382ebe52.c7088de59e49f7108f520cf7e0bae167e;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("Login.swf");
	}

	public override void cc6d8fb0627b56c504494f2637f0707f0(bool c38daa1ecfc4be57f0bab6f15b4488ecc)
	{
		base.cc6d8fb0627b56c504494f2637f0707f0(c38daa1ecfc4be57f0bab6f15b4488ecc);
		if (mcLoginBtn != null)
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
			mcLoginBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = c38daa1ecfc4be57f0bab6f15b4488ecc;
		}
		if (mcSignBtn != null)
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
			mcSignBtn.cbf402c82d0fffee7c8f37c98e456b8f8 = c38daa1ecfc4be57f0bab6f15b4488ecc;
		}
		if (mcNameInput != null)
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
			mcNameInput.cbf402c82d0fffee7c8f37c98e456b8f8 = c38daa1ecfc4be57f0bab6f15b4488ecc;
		}
		if (mcPasswordInput == null)
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
			mcPasswordInput.cbf402c82d0fffee7c8f37c98e456b8f8 = c38daa1ecfc4be57f0bab6f15b4488ecc;
			return;
		}
	}

	public override void cd8807a5234c8bc932a35c30ae53838ee(string c5fe690777bf5dec9374fa61ab6703175, string c2b1dbe8e2d138df405faa6136d3c44c1)
	{
		base.cd8807a5234c8bc932a35c30ae53838ee(c5fe690777bf5dec9374fa61ab6703175, c2b1dbe8e2d138df405faa6136d3c44c1);
		if (mcNameInput != null)
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
			mcNameInput.c09721d98c247dde8efe59bc3cebbad00 = _name;
		}
		if (mcPasswordInput == null)
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
			mcPasswordInput.c09721d98c247dde8efe59bc3cebbad00 = _password;
			return;
		}
	}

	protected void c43716429a809284e63df92d026489d4c(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, "\n Password:" + mcPasswordInput.c09721d98c247dde8efe59bc3cebbad00);
		c236434cb1dd35d7dd3d7445ddba8a5a5(mcNameInput.c09721d98c247dde8efe59bc3cebbad00, mcPasswordInput.c09721d98c247dde8efe59bc3cebbad00);
	}

	protected void c533e34f1af2d0edbdd14b5a06d3aad16(CEvent c145c47696cdb7404f93dd0c2b26cfd51)
	{
		if (!c5579ff2e2783eafd5ea42598a5482f87(mcNameInput.c09721d98c247dde8efe59bc3cebbad00, mcPasswordInput.c09721d98c247dde8efe59bc3cebbad00))
		{
			return;
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c0bd653723f77fd78e6c7d4d25ed14dcd(c7bb86b60f299c950179b9bd1c30a2a68);
			cf157585a3977fe246b88a258164747cc(mcNameInput.c09721d98c247dde8efe59bc3cebbad00, mcPasswordInput.c09721d98c247dde8efe59bc3cebbad00);
			return;
		}
	}

	protected void c7bb86b60f299c950179b9bd1c30a2a68()
	{
		if (Input.GetKeyDown(KeyCode.Tab))
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
			if (mcNameInput != null)
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
				if (mcNameInput.c49c2231d3c9f8a197e7c1f14492aa721())
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
					if (mcPasswordInput != null)
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
						mcNameInput.ce8805cc02a868fbf01bc5a4fa7c97062 = false;
						mcPasswordInput.ce8805cc02a868fbf01bc5a4fa7c97062 = true;
					}
				}
				else
				{
					mcPasswordInput.ce8805cc02a868fbf01bc5a4fa7c97062 = false;
					mcNameInput.ce8805cc02a868fbf01bc5a4fa7c97062 = true;
				}
			}
		}
		if (!Input.GetKey(KeyCode.KeypadEnter))
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
			if (!Input.GetKey(KeyCode.Return))
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
				break;
			}
		}
		if (mcNameInput == null)
		{
			return;
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			if (mcPasswordInput == null)
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
				if (!c5579ff2e2783eafd5ea42598a5482f87(mcNameInput.c09721d98c247dde8efe59bc3cebbad00, mcPasswordInput.c09721d98c247dde8efe59bc3cebbad00))
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
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c0bd653723f77fd78e6c7d4d25ed14dcd(c7bb86b60f299c950179b9bd1c30a2a68);
					cf157585a3977fe246b88a258164747cc(mcNameInput.c09721d98c247dde8efe59bc3cebbad00, mcPasswordInput.c09721d98c247dde8efe59bc3cebbad00);
					return;
				}
			}
		}
	}
}
