using A;
using pumpkin.display;
using pumpkin.events;

public class MaskPad
{
	public static readonly string MASKPAD_PREFIX = "MaskPad";

	protected string _strMaskMCName;

	protected MovieClip _relateMC;

	public void c9736b290a6efcb7524d4bedda677c9dc(MovieClip c998c56e5cab278873f1a5722e79733da, string c27db047aa304dfb00a82236ee9963324)
	{
		char[] array = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = '_';
		string[] array2 = c27db047aa304dfb00a82236ee9963324.Split(array);
		if (array2 == null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (array2.Length < 2)
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
			_strMaskMCName = "Mask_" + array2[1];
			_relateMC = c998c56e5cab278873f1a5722e79733da;
			_relateMC.visible = false;
			_relateMC.removeAllEventListeners(CEvent.ENTER_FRAME);
			_relateMC.addEventListener(CEvent.ENTER_FRAME, c40c94ee9334ace162d30e8b8b460f74b);
			return;
		}
	}

	protected void c40c94ee9334ace162d30e8b8b460f74b(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		MovieClip movieClip = _relateMC.parent as MovieClip;
		if (movieClip == null)
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
					return;
				}
			}
		}
		MovieClip childByName = movieClip.getChildByName<MovieClip>(_strMaskMCName);
		if (childByName == null)
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
		int childIndex = movieClip.getChildIndex(childByName);
		int childIndex2 = movieClip.getChildIndex(_relateMC);
		if (childIndex >= childIndex2)
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
		for (int i = childIndex + 1; i < childIndex2; i++)
		{
			DisplayObject childAt = movieClip.getChildAt(i);
			childAt.clipRect = childByName.getBounds(childAt).rect;
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			childByName.visible = false;
			return;
		}
	}
}
