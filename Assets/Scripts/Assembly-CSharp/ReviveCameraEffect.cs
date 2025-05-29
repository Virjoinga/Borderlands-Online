using A;
using UnityEngine;

public class ReviveCameraEffect : MonoBehaviour
{
	public AnimationCurve mSaturationCurve;

	private ReviveEffect mReviveEffect;

	private GameObject mRootObj;

	private float mRevieUpdateTime;

	private void TriggerEffectByName(string name)
	{
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnlineHostMinResMode)
		{
			while (true)
			{
				switch (3)
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
		if (name == "PlayerReviveStart")
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					c0b3e307ce9591c6c5d3023f19ade0d0f();
					return;
				}
			}
		}
		if (!(name == "PlayerReviveEnd"))
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
			cfe9d34786e7b14f90bd7fb60d8916d0e();
			return;
		}
	}

	private void c0b3e307ce9591c6c5d3023f19ade0d0f()
	{
		mRootObj = base.gameObject.transform.parent.gameObject;
		mReviveEffect = mRootObj.AddComponent<ReviveEffect>();
		mReviveEffect.shader = Shader.Find("Custom/ReviveEffect");
		mRevieUpdateTime = 0f;
	}

	private void cfe9d34786e7b14f90bd7fb60d8916d0e()
	{
		if (!mReviveEffect)
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
			Object.Destroy(mReviveEffect);
			mReviveEffect = c218bab79098439fdc4a11f7cc3878282.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	private void FixedUpdate()
	{
		if (!mReviveEffect)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			mRevieUpdateTime += Time.fixedDeltaTime;
			mReviveEffect.mLerpVal = mSaturationCurve.Evaluate(mRevieUpdateTime);
			return;
		}
	}
}
