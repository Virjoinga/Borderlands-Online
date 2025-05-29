using A;
using UnityEngine;
using XsdSettings;

public class UIPreviewMgr
{
	private Camera mUIPreviewCamera;

	private RenderTexture mUIPrivewRT;

	private GameObject mUIPriveCamObj;

	private int mPreviewRTWidth = 1280;

	private int mPreviewRTHeight = 720;

	private int mUIPreviewLayer = 24;

	private Rect mSrcUVRect;

	private Vector3 mSirenLocalPos;

	private Vector3 mSoldierLocalPos;

	private Vector3 mBerserkerLocalPos;

	private Vector3 mHUNTERLocalPos;

	private float[] mWpnLocalPos;

	private float[] mWpnRotSpeed;

	private float[] mAccessoryLocalPos;

	private float mShieldLocalPos;

	private GameObject m_previousDisplayObj;

	private int m_previousDisplayLayer = -1;

	public UIPreviewMgr()
	{
		mSrcUVRect = new Rect(0f, 0f, 1f, 1f);
	}

	public float[] c1bcd51703b6984f7ac454c1dd6c69c8a()
	{
		return mWpnLocalPos;
	}

	public float[] c13478151a197778390e347c292ebea1a()
	{
		return mWpnRotSpeed;
	}

	public float[] ca69a4e418f2dcb851f92d6d81d68a79d()
	{
		return mAccessoryLocalPos;
	}

	public float cb92845bb58bbb9fa6fc668dd11187120()
	{
		return mShieldLocalPos;
	}

	private Rect c7846b4255f1a1f2c0eddae2977e0cf2e(Renderer c68776ef7c204ace09d1a660239c02d77)
	{
		return new Rect(0.3f, 0f, 0.4f, 1f);
	}

	private void cfd3d35b8d8250846f059e233d140c8a9(GameObject c4eb9b2832b29b36df6ed03544b34037e)
	{
		if (c4eb9b2832b29b36df6ed03544b34037e != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					SkinnedMeshRenderer skinnedMeshRenderer = BuildingKitGenerator.cc9bfa7a11dd9e2e916f75a4eb41a63ab(c4eb9b2832b29b36df6ed03544b34037e);
					if (skinnedMeshRenderer == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						skinnedMeshRenderer = c4eb9b2832b29b36df6ed03544b34037e.GetComponentInChildren<SkinnedMeshRenderer>();
					}
					mSrcUVRect = c7846b4255f1a1f2c0eddae2977e0cf2e(skinnedMeshRenderer);
					return;
				}
				}
			}
		}
		mSrcUVRect = new Rect(0f, 0f, 1f, 1f);
	}

	public int c4861eb9b2510db1821a27c4857816dbd()
	{
		return mUIPreviewLayer;
	}

	public void ccc9d3a38966dc10fedb531ea17d24611(GameObject c8fac0408ed21176569b4d16b7159f969)
	{
		mUIPrivewRT = new RenderTexture(mPreviewRTWidth, mPreviewRTHeight, 24);
		mUIPrivewRT.name = "UIPreviewMgr_mUIPrivewRT";
		mUIPrivewRT.Create();
		mUIPreviewCamera = c8fac0408ed21176569b4d16b7159f969.AddComponent<Camera>();
		mUIPreviewCamera.renderingPath = RenderingPath.UsePlayerSettings;
		mUIPreviewCamera.cullingMask = 1 << mUIPreviewLayer;
		mUIPreviewCamera.targetTexture = mUIPrivewRT;
		mUIPreviewCamera.depth = 101f;
		mUIPreviewCamera.clearFlags = CameraClearFlags.Color;
		mUIPreviewCamera.backgroundColor = new Color(0f, 0f, 0f, 0f);
		mUIPreviewCamera.nearClipPlane = 0.01f;
		mUIPreviewCamera.hdr = true;
		GameObject c7088de59e49f7108f520cf7e0bae167e = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
		c7088de59e49f7108f520cf7e0bae167e = Resources.Load("CameraEffect/EffectCamera_UI_Preview") as GameObject;
		if (c7088de59e49f7108f520cf7e0bae167e != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			ComponentHelper.c0bd715794203aecb6153c35217fbf4f4(c7088de59e49f7108f520cf7e0bae167e, mUIPreviewCamera.gameObject);
		}
		mUIPriveCamObj = c8fac0408ed21176569b4d16b7159f969;
		UIPrivewData component = (Resources.Load("Graphics/GraphicsData") as GameObject).GetComponent<UIPrivewData>();
		mSirenLocalPos = component.m_SIREN_LocalPos;
		mSoldierLocalPos = component.m_SOLDIER_LocalPos;
		mBerserkerLocalPos = component.m_BERSERKER_LocalPos;
		mHUNTERLocalPos = component.m_HUNTER_LocalPos;
		mWpnLocalPos = component.m_Wpn_LocalPos;
		mWpnRotSpeed = component.m_Wpn_RotSpeed;
		mAccessoryLocalPos = component.m_Accessory_LocalPos;
		mShieldLocalPos = component.m_Shield_LocalPos;
		mUIPreviewCamera.fieldOfView = component.m_Fov;
		EdgeDetectEffectNormals component2 = mUIPreviewCamera.GetComponent<EdgeDetectEffectNormals>();
		if (component2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			component2.EnableAlphaCorrection(true);
		}
		c9ff0f0f2e42ce6e75d98e84a884b4452(false);
	}

	public void ceace8511c4a1ce75f593e7b8e330e7bb(int c7859ff6cbbe81607c624c05fadcb50ca, int c52c05a3e3218ee55c3e2678b7b2d3250)
	{
		if (mPreviewRTWidth == c7859ff6cbbe81607c624c05fadcb50ca)
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
			if (mPreviewRTHeight == c52c05a3e3218ee55c3e2678b7b2d3250)
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
				break;
			}
		}
		mPreviewRTWidth = c7859ff6cbbe81607c624c05fadcb50ca;
		mPreviewRTHeight = c52c05a3e3218ee55c3e2678b7b2d3250;
		mUIPrivewRT.Release();
		mUIPrivewRT = new RenderTexture(c7859ff6cbbe81607c624c05fadcb50ca, c52c05a3e3218ee55c3e2678b7b2d3250, 24);
		mUIPrivewRT.Create();
	}

	public void c9ff0f0f2e42ce6e75d98e84a884b4452(bool c33e7a3a45edac8bfef92cc3bf244dbf0)
	{
		if (mUIPriveCamObj == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		mUIPriveCamObj.SetActive(c33e7a3a45edac8bfef92cc3bf244dbf0);
	}

	public Texture c9bf29a49cfe42cc19891e9333401d847()
	{
		return mUIPrivewRT;
	}

	public Rect c0c17e73f50a88deade51a968597893c7()
	{
		return mSrcUVRect;
	}

	public void cbef16445507599c30d2c9998fd70600a(Rect ce294e042a2ee99cca935cf0a4b0c61c0)
	{
		mSrcUVRect = ce294e042a2ee99cca935cf0a4b0c61c0;
	}

	public void c6de8002d9a233bb083beb8d2a147d3b0(GameObject cccf59a34532363f337fca617a716fe54, Vector3 c4d08ae331c26afaf32f24366155aeda3, Vector3 c4ea6de03c1203f2470a6677821ad93f0, bool cdc4ce4aa9fe63ead0cefd3047101647a)
	{
		if (!(cccf59a34532363f337fca617a716fe54 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (!(mUIPriveCamObj != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				GameObject gameObject = cccf59a34532363f337fca617a716fe54.transform.Find("displayObj").gameObject;
				if (gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					if (m_previousDisplayObj != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						m_previousDisplayObj.layer = m_previousDisplayLayer;
					}
					m_previousDisplayObj = gameObject;
					m_previousDisplayLayer = gameObject.layer;
					gameObject.layer = c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.ce9030196d2dbfbe5a5051960f05df6d0().c4861eb9b2510db1821a27c4857816dbd();
					SkinnedMeshRenderer component = gameObject.GetComponent<SkinnedMeshRenderer>();
					if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						component.useLightProbes = false;
						component.castShadows = false;
						component.receiveShadows = false;
					}
				}
				cccf59a34532363f337fca617a716fe54.transform.parent = mUIPriveCamObj.transform;
				Vector3 localPosition = Vector3.zero;
				if (cdc4ce4aa9fe63ead0cefd3047101647a)
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
					localPosition = c4d08ae331c26afaf32f24366155aeda3;
				}
				else
				{
					PlayerInfoSync playerInfoSync = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56();
					AvatarType type = playerInfoSync.m_avatarDna.m_type;
					if (type == AvatarType.SIREN)
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
						localPosition = mSirenLocalPos;
					}
					else if (type == AvatarType.SOLDIER)
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
						localPosition = mSoldierLocalPos;
					}
					else if (type == AvatarType.BERSERKER)
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
						localPosition = mBerserkerLocalPos;
					}
					else if (type == AvatarType.HUNTER)
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
						localPosition = mHUNTERLocalPos;
					}
				}
				cccf59a34532363f337fca617a716fe54.transform.localPosition = localPosition;
				cccf59a34532363f337fca617a716fe54.transform.localRotation = Quaternion.Euler(c4ea6de03c1203f2470a6677821ad93f0);
				cfd3d35b8d8250846f059e233d140c8a9(cccf59a34532363f337fca617a716fe54);
				return;
			}
		}
	}
}
