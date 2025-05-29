using A;
using UnityEngine;

public class TransferEffect : MonoBehaviour
{
	private enum TRANSFER_PHASE
	{
		NORMAL_TO_WHITE = 0,
		WHITE_TO_BLACK = 1,
		HOLD_BLACK = 2,
		BLACK_TO_WHITE = 3,
		WHITE_TO_NORMAL = 4,
		PHASE_NUM = 5
	}

	private GameObject mTransferBackground;

	private int mOriCameraCullMasking;

	private CameraClearFlags mOriClearFlag;

	private TransferImageEffect mTransEffect;

	private bool mStartTransfer;

	private float mCurPhaseTime;

	private float mNormalToWhiteTime;

	private float mNormalToWhiteTimeStep;

	private float mWhiteToBlackTime;

	private float mWhiteToBlackTimeStep;

	private float mHoldBlackTime;

	private float mBlackToWhiteTime;

	private float mBlackToWhiteTimeStep;

	private float mWhiteToNormalTimeStep;

	private GameObject mFpsCamObj;

	private Camera mFpsCam;

	private bool mPhase1NeddInit;

	private ParticleSystem mParticleComp;

	private TRANSFER_PHASE mCurPhase;

	private void Awake()
	{
		mStartTransfer = false;
	}

	private void TriggerEffectByName(string name)
	{
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnlineHostMinResMode)
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
					return;
				}
			}
		}
		if (name == "TransferPlayerStart")
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					cdf13f494b8b530924380ac3c600a3c3c();
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c758cf934d27a077d85165dce3424bb11(false);
					return;
				}
			}
		}
		if (!(name == "TransferPlayerEnd"))
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
			c670b6669a6778179ed9f99b6823713c8();
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c758cf934d27a077d85165dce3424bb11(true);
			return;
		}
	}

	private void cdf13f494b8b530924380ac3c600a3c3c()
	{
		Camera camera = c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c800a736f9c78c72b510a3f7e608b6fb4();
		GameObject gameObject = (mFpsCamObj = camera.gameObject);
		mFpsCam = camera;
		TransferEffectData component = (Resources.Load("Graphics/GraphicsData") as GameObject).GetComponent<TransferEffectData>();
		mTransferBackground = Object.Instantiate(component.mTransferBackground) as GameObject;
		mTransferBackground.SetActive(true);
		mTransferBackground.transform.parent = mFpsCamObj.transform;
		mTransferBackground.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
		mTransferBackground.transform.localPosition = new Vector3(0f, 0f, 10f);
		mNormalToWhiteTime = component.mNormalToWhiteTime;
		mNormalToWhiteTimeStep = 1f / mNormalToWhiteTime;
		mWhiteToBlackTime = component.mWhiteToBlackTime;
		mWhiteToBlackTimeStep = 1f / mWhiteToBlackTime;
		mHoldBlackTime = component.mHoldBlackTime;
		mBlackToWhiteTime = mNormalToWhiteTime;
		mBlackToWhiteTimeStep = mNormalToWhiteTimeStep;
		mWhiteToNormalTimeStep = mWhiteToBlackTimeStep;
		mCurPhaseTime = 0f;
		mStartTransfer = true;
		mOriCameraCullMasking = camera.cullingMask;
		mOriClearFlag = camera.clearFlags;
		mTransEffect = gameObject.AddComponent<TransferImageEffect>();
		mTransEffect.shader = Shader.Find("Custom/FX/TransferEffect");
		mPhase1NeddInit = true;
		mCurPhase = TRANSFER_PHASE.NORMAL_TO_WHITE;
	}

	private void c1374e0d062655bbbc709e833f764ac48()
	{
		float c92b31540d294cca3aef40fe79f317dad = mNormalToWhiteTimeStep * mCurPhaseTime;
		mTransEffect.c14a85ecac424c1e74385e117288c6101(c92b31540d294cca3aef40fe79f317dad);
		if (!(mCurPhaseTime > mNormalToWhiteTime))
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
			mCurPhase = TRANSFER_PHASE.WHITE_TO_BLACK;
			mCurPhaseTime = 0f;
			return;
		}
	}

	private void c4db9c38258cf2d0ed2b8cb6335b080f8()
	{
		if (mPhase1NeddInit)
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
			mFpsCam.cullingMask = 8192;
			mFpsCam.clearFlags = CameraClearFlags.Color;
			float num = 0.003921569f;
			mFpsCam.backgroundColor = new Color(34f * num, 55f * num, 81f * num, 1f);
			c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.ca5bd80f5ff7a2e9ca939a6283399ec2d().c9b75e0c1c51390d2a4e1da0f0555fe93(mFpsCam, false);
			mParticleComp = mTransferBackground.GetComponent<ParticleSystem>();
			if (mParticleComp != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				mParticleComp.Play();
			}
			mPhase1NeddInit = false;
		}
		float num2 = mWhiteToBlackTimeStep * mCurPhaseTime;
		mTransEffect.c14a85ecac424c1e74385e117288c6101(1f - num2);
		if (!(mCurPhaseTime > mWhiteToBlackTime))
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
			mCurPhase = TRANSFER_PHASE.HOLD_BLACK;
			mCurPhaseTime = 0f;
			return;
		}
	}

	private void cf863af0f37ff4f081858272451edf7d5()
	{
		if (!(mCurPhaseTime > mHoldBlackTime))
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
			mCurPhase = TRANSFER_PHASE.BLACK_TO_WHITE;
			mCurPhaseTime = 0f;
			return;
		}
	}

	private void c2325102376c3b5d2e6522ace59cc2048()
	{
		float c92b31540d294cca3aef40fe79f317dad = mBlackToWhiteTimeStep * mCurPhaseTime;
		mTransEffect.c14a85ecac424c1e74385e117288c6101(c92b31540d294cca3aef40fe79f317dad);
		if (!(mCurPhaseTime > mBlackToWhiteTime))
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
			mCurPhase = TRANSFER_PHASE.WHITE_TO_NORMAL;
			mCurPhaseTime = 0f;
			return;
		}
	}

	private void cdf4a00f76bf359f779c9a4f9bb01299a()
	{
		float num = mWhiteToNormalTimeStep * mCurPhaseTime;
		if (!(num < 1f))
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
			mTransEffect.c14a85ecac424c1e74385e117288c6101(1f - num);
			return;
		}
	}

	private void FixedUpdate()
	{
		if (!mStartTransfer)
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
			mCurPhaseTime += Time.deltaTime;
			switch (mCurPhase)
			{
			case TRANSFER_PHASE.NORMAL_TO_WHITE:
				c1374e0d062655bbbc709e833f764ac48();
				break;
			case TRANSFER_PHASE.WHITE_TO_BLACK:
				c4db9c38258cf2d0ed2b8cb6335b080f8();
				break;
			case TRANSFER_PHASE.HOLD_BLACK:
				cf863af0f37ff4f081858272451edf7d5();
				break;
			case TRANSFER_PHASE.BLACK_TO_WHITE:
				c2325102376c3b5d2e6522ace59cc2048();
				break;
			case TRANSFER_PHASE.WHITE_TO_NORMAL:
				cdf4a00f76bf359f779c9a4f9bb01299a();
				break;
			}
			return;
		}
	}

	private void c670b6669a6778179ed9f99b6823713c8()
	{
		c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.ca5bd80f5ff7a2e9ca939a6283399ec2d().c9b75e0c1c51390d2a4e1da0f0555fe93(mFpsCam, true);
		mFpsCam.cullingMask = mOriCameraCullMasking;
		mFpsCam.clearFlags = mOriClearFlag;
		Object.Destroy(mTransferBackground);
		Object.Destroy(mTransEffect);
	}
}
