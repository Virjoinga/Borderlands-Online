using System.Collections.Generic;
using A;
using Core;
using UnityEngine;
using XsdSettings;

public class ClassCustomView : BaseView
{
	private struct FeatureDesc
	{
		public string name;

		public string animationName;
	}

	public const int STYLE_NUM = 6;

	public const int NUM = 3;

	public const int PART_NUM = 6;

	public DNACreateBehaviour _logicBehaviour;

	private List<List<FeatureDesc>> _FeatureList = new List<List<FeatureDesc>>();

	private List<int> _FeatureRecorder = new List<int>();

	private LocalizedString[] styleName;

	private string[] animationName;

	protected string _name;

	protected bool _bRotateEnable;

	protected bool _bCursorInCheckRect;

	private UIAvatarManager _avatarManager;

	private List<byte> fbxs;

	private List<byte> mats;

	public ClassCustomView()
	{
		LocalizedString[] array = cd8987b2728b75d5f121e97e4ff768d84.c0a0cdf4a196914163f7334d9b0781a04(6);
		array[0] = new LocalizedString("Hair");
		array[1] = new LocalizedString("Face");
		array[2] = new LocalizedString("Mask");
		array[3] = new LocalizedString("Coat");
		array[4] = new LocalizedString("Pants");
		array[5] = new LocalizedString("Boots");
		styleName = array;
		string[] array2 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(6);
		array2[0] = "stand_changehead";
		array2[1] = "stand_changehead";
		array2[2] = "stand_changebody";
		array2[3] = "stand_changebody";
		array2[4] = "stand_changebody";
		array2[5] = "stand_changebody";
		animationName = array2;
		_name = string.Empty;
		base._002Ector();
	}

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
	}

	public virtual void ce82e275cb065bd8e3c15b8d2b7396422()
	{
		FeatureDesc item = default(FeatureDesc);
		for (int i = 0; i < 6; i++)
		{
			List<FeatureDesc> list = new List<FeatureDesc>();
			for (int j = 1; j < 7; j++)
			{
				if (i < 7)
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
					item.name = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(styleName[i]) + j;
				}
				else
				{
					item.name = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(styleName[i]);
				}
				item.animationName = animationName[i];
				list.Add(item);
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					goto end_IL_0081;
				}
				continue;
				end_IL_0081:
				break;
			}
			_FeatureList.Add(list);
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			GameObject gameObject = GameObject.Find("Model_Group");
			if (gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				_avatarManager = gameObject.GetComponent<UIAvatarManager>();
				if (_avatarManager == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.GUI, "----------initAvatarModel---------");
				}
			}
			AvatarType c530262bed2fed8bf0fa08fae = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<FrontEndStepManager>().c530262bed2fed8bf0fa08fae31480158;
			if (c530262bed2fed8bf0fa08fae == AvatarType.TOTAL)
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
				DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.GUI, "*****Character class type wrong!");
			}
			else
			{
				fbxs = _avatarManager.c776f10275205e9a738d414973e864515(c530262bed2fed8bf0fa08fae).buildingKitRender.ccf784a7191cc76b4e0c079ff7b1e7ac7.mFBXs;
				mats = _avatarManager.c776f10275205e9a738d414973e864515(c530262bed2fed8bf0fa08fae).buildingKitRender.ccf784a7191cc76b4e0c079ff7b1e7ac7.mMats;
			}
			_FeatureRecorder.Add(fbxs[0]);
			_FeatureRecorder.Add(fbxs[1]);
			_FeatureRecorder.Add(mats[2]);
			_FeatureRecorder.Add(mats[3]);
			_FeatureRecorder.Add(mats[4]);
			if (c530262bed2fed8bf0fa08fae != AvatarType.BERSERKER)
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
				_FeatureRecorder.Add(mats[5]);
				_FeatureRecorder.Add(mats[6]);
				_FeatureRecorder.Add(mats[7]);
			}
			_FeatureRecorder.Add(0);
			return;
		}
	}

	public virtual void c7d1840b98a06410c4a22d4c051ecae9f(c2597280f86604f98f89309a4de95dd62 c72943404493c5c9abc349e4b65bfe91b)
	{
	}

	public virtual void cfcad2bb178b2ee0f48018fadc7c7352a()
	{
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		_FeatureList.Clear();
		_FeatureRecorder.Clear();
	}

	protected void c8e60fb4f81068550dfc04c72900be46e()
	{
		_logicBehaviour.c92d57f37bbd6f97e11c80978db66cb16(3);
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, " onPrevClick ");
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<FrontEndStepManager>().c80de27b415dc1bfb2c73a64cfcafa59f(FrontEndStepManager.StepState.ClassSelect, c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e);
	}

	protected void cfc5920a5bb9bf351536e2ca4aea54e54()
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, " onNextClick ");
		_logicBehaviour.c49fa125ba4362ced3a0bd1ce8f3c8188(_name);
		_logicBehaviour.c742aaec0df3b68985ab7230816610221();
	}

	protected void cfbd9ccf2762acc9ab5b9ff3e8975e3b9(int c5b71d9faedd613acf532774e558e4606, int c343f09726f61b6b56d24591379c667b9, bool cb843f97c9f7026e9f00dccd9de16cd3e = true)
	{
		_FeatureRecorder[c5b71d9faedd613acf532774e558e4606] = c343f09726f61b6b56d24591379c667b9;
		_logicBehaviour.c5f036d9797e7523ba491832594238078((byte)c5b71d9faedd613acf532774e558e4606, (byte)c343f09726f61b6b56d24591379c667b9, cb843f97c9f7026e9f00dccd9de16cd3e);
		_logicBehaviour.c9c8c2e259fa10b28eef998125e51490f(_FeatureList[c5b71d9faedd613acf532774e558e4606][c343f09726f61b6b56d24591379c667b9].animationName);
	}

	public int c6412dee21869cb067c5e01137bf5e450(int c4d7aa49aee8e99233ad8b8fd4359c08e)
	{
		return _FeatureRecorder[c4d7aa49aee8e99233ad8b8fd4359c08e];
	}

	public string c64cf9e4192445a3dfe6687ff0dec4168(int c4d7aa49aee8e99233ad8b8fd4359c08e)
	{
		return _FeatureList[c4d7aa49aee8e99233ad8b8fd4359c08e][_FeatureRecorder[c4d7aa49aee8e99233ad8b8fd4359c08e]].name;
	}

	public void c69b7264d5f6dc27474e86b241d437906(bool cc6409b7059219ca1ba3a0053a1165e60 = false)
	{
		if (cc6409b7059219ca1ba3a0053a1165e60)
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
			_bCursorInCheckRect = false;
			_bRotateEnable = false;
		}
		GameUIManager.CursorManager.CursorType c6de715717a660431b466566175fe3dcf = GameUIManager.CursorManager.CursorType.DefaultCursor;
		if (_bRotateEnable)
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
			c6de715717a660431b466566175fe3dcf = GameUIManager.CursorManager.CursorType.HandClosed;
		}
		else if (_bCursorInCheckRect)
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
			c6de715717a660431b466566175fe3dcf = GameUIManager.CursorManager.CursorType.HandSelected;
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().cff2b0374fa4093a26652f81f964f8e9f(c6de715717a660431b466566175fe3dcf);
	}
}
