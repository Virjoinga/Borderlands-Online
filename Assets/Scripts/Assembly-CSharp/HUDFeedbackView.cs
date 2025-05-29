using A;
using UnityEngine;

public class HUDFeedbackView : BaseView
{
	public enum Direction
	{
		Front = 0,
		Back = 1,
		Left = 2,
		Right = 3
	}

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c858f0c33158b659215d28b3c0548a38a(this);
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ceb073876b67631e82266e224318dc9de(this);
	}

	public virtual void cdb78d8f4c0a151823a6bd467ced0d6aa(int c83130c8b3cb0bca5da0dd22b9693898d, int c0e0b6548ee9ac8354c15e369d7f01c5f, DamageInfo cd267a5dc6434bf247c67a6b37ed70c84)
	{
		BadAssNetworkView badAssNetworkView = BadAssNetworkView.c16cef725419dd5314991ac769ad60eb9(cd267a5dc6434bf247c67a6b37ed70c84.m_from);
		GameObject gameObject = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
		if (badAssNetworkView != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			gameObject = badAssNetworkView.gameObject;
		}
		if (gameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		PlayerInfoSync playerInfoSync = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56();
		if (playerInfoSync == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		Entity entity = playerInfoSync.c66b232dbebded7c7e9a89c1e8bd84689();
		if (entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		Vector3 forward = entity.transform.forward;
		Vector3 from = gameObject.transform.position - entity.transform.position;
		forward.y = (from.y = 0f);
		float num = Vector3.Angle(from, forward);
		Direction c1a9559709f1b5e7a60a6a0bfbcee;
		if ((double)num < 45.0)
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
			c1a9559709f1b5e7a60a6a0bfbcee = Direction.Front;
		}
		else if ((double)num > 135.0)
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
			c1a9559709f1b5e7a60a6a0bfbcee = Direction.Back;
		}
		else
		{
			Vector3 right = entity.transform.right;
			float num2 = Vector3.Angle(from, right);
			int num3;
			if (num2 < 90f)
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
				num3 = 3;
			}
			else
			{
				num3 = 2;
			}
			c1a9559709f1b5e7a60a6a0bfbcee = (Direction)num3;
		}
		if (from.sqrMagnitude < float.Epsilon)
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
			c1a9559709f1b5e7a60a6a0bfbcee = Direction.Back;
		}
		if (c83130c8b3cb0bca5da0dd22b9693898d > 0)
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
			c0e3f77bf0be2b3f0e55911072aee6430(c1a9559709f1b5e7a60a6a0bfbcee);
		}
		if (c0e0b6548ee9ac8354c15e369d7f01c5f <= 0)
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
			ccc3a4e4ffdac3e7fcb5f35e5012c37ae(c1a9559709f1b5e7a60a6a0bfbcee);
			return;
		}
	}

	public virtual void ca9e5e4b6111ffdc3b0b4d8368c5c2046(DamageInfo c7a58c08f49a0d62fda3d0fda4b15109a)
	{
	}

	protected virtual void c0e3f77bf0be2b3f0e55911072aee6430(Direction c1a9559709f1b5e7a60a6a0bfbcee7536)
	{
	}

	protected virtual void ccc3a4e4ffdac3e7fcb5f35e5012c37ae(Direction c1a9559709f1b5e7a60a6a0bfbcee7536)
	{
	}
}
