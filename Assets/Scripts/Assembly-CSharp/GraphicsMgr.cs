using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using A;
using BHV;
using Core;
using UnityEngine;

public class GraphicsMgr : c06ca0e618478c23eba3419653a19760f<GraphicsMgr>
{
	private struct WindowsRECT
	{
		public int Left;

		public int Top;

		public int Right;

		public int Bottom;
	}

	private const string APP_NAME = "Borderlands Online";

	private const int GWL_STYLE = -16;

	private const long WS_MAXIMIZE = 16777216L;

	private GameObject mGraphicMgrObj;

	private BolRTMgr mBolRTMgr;

	private CharacterFxMgr mCharacterFxMgr;

	private CameraEffectMgr mCameraEffectMgr;

	private SnapEffectMgr mSnapEffectMgr;

	private FpEffectMgr mFpEffectMgr;

	private NpcTitleMgr mNpcTitleMgr;

	private UIPreviewMgr mUIPreviewMgr;

	private TexPostEffectMgr mTexPostEffectMgr;

	private FpCameraEffectMgr mFpCameraEffectMgr;

	public bool mIsHideFpMesh;

	private EntityPlayer mEntityPlay;

	private Camera mFpsCamera;

	private Vector3 mFpsCameraPos;

	private int mResIndex;

	private Resolution[] mWantSupportResInfoArray;

	private List<Resolution> mSupportResInfoArray;

	private float mOriSceneFov;

	private float mOriWpnFov;

	private Vector3 mOriCameraLSPos;

	private WeaponCameraControl mWpnCamControl;

	private Resolution mLastResolution;

	private bool mFullScreen;

	private int widthMargin;

	private int titleHeight;

	private int posXBeforeFullScreen;

	private int posYBeforeFullScreen;

	private long restoreWindowStyle;

	private Resolution restoreResolution;

	private Action<int, int> OnChangeResolution;

	[CompilerGenerated]
	private static Action<int, int> _003C_003Ef__am_0024cache1E;

	public bool c13d6075d6ee54181527ae5452bddb1f9
	{
		get
		{
			return mFullScreen;
		}
	}

	public event Action<int, int> c57cfd7669972522489095c9dc42b8dbd
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			OnChangeResolution = (Action<int, int>)Delegate.Combine(OnChangeResolution, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			OnChangeResolution = (Action<int, int>)Delegate.Remove(OnChangeResolution, value);
		}
	}

	public GraphicsMgr()
	{
		Resolution c36964cf41281414170f34ee68bef6c7 = default(Resolution);
		c6db7dc205a7d9988b99bd67708d3c321.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c7);
		mLastResolution = c36964cf41281414170f34ee68bef6c7;
		Resolution c36964cf41281414170f34ee68bef6c8 = default(Resolution);
		c6db7dc205a7d9988b99bd67708d3c321.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c8);
		restoreResolution = c36964cf41281414170f34ee68bef6c8;
		if (_003C_003Ef__am_0024cache1E == null)
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
			_003C_003Ef__am_0024cache1E = delegate
			{
			};
		}
		OnChangeResolution = _003C_003Ef__am_0024cache1E;
		base._002Ector();
		if (!(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnlineHostMinResMode)
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
				break;
			}
		}
		mBolRTMgr = new BolRTMgr();
		mCharacterFxMgr = new CharacterFxMgr();
		mCameraEffectMgr = new CameraEffectMgr();
		mSnapEffectMgr = new SnapEffectMgr();
		mFpEffectMgr = new FpEffectMgr();
		mNpcTitleMgr = new NpcTitleMgr();
		mUIPreviewMgr = new UIPreviewMgr();
		mTexPostEffectMgr = new TexPostEffectMgr();
		mFpCameraEffectMgr = new FpCameraEffectMgr();
		mIsHideFpMesh = false;
		mResIndex = 0;
		mWantSupportResInfoArray = c29591da2930c0b2592a310cfa2b7a356.c0a0cdf4a196914163f7334d9b0781a04(2);
		ref Resolution reference = ref mWantSupportResInfoArray[0];
		Resolution c36964cf41281414170f34ee68bef6c9 = default(Resolution);
		c6db7dc205a7d9988b99bd67708d3c321.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c9);
		reference = c36964cf41281414170f34ee68bef6c9;
		mWantSupportResInfoArray[0].width = 1280;
		mWantSupportResInfoArray[0].height = 720;
		ref Resolution reference2 = ref mWantSupportResInfoArray[1];
		Resolution c36964cf41281414170f34ee68bef6c10 = default(Resolution);
		c6db7dc205a7d9988b99bd67708d3c321.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c10);
		reference2 = c36964cf41281414170f34ee68bef6c10;
		mWantSupportResInfoArray[1].width = 1920;
		mWantSupportResInfoArray[1].height = 1080;
		mSupportResInfoArray = new List<Resolution>(Screen.resolutions);
		mLastResolution.width = -1;
		mLastResolution.height = -1;
	}

	public void c8f626bba32832ffb79455022b91d32ea()
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(Resources.Load("NoneSceneLighting/LightingInfo") as GameObject) as GameObject;
		if (gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					if (gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								break;
							default:
								gameObject.transform.parent = mGraphicMgrObj.transform;
								mGraphicMgrObj.transform.Translate(gameObject.transform.position, mGraphicMgrObj.transform);
								gameObject.transform.localPosition = Vector3.zero;
								return;
							}
						}
					}
					return;
				}
			}
		}
		DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Graphics, "Missing None Scene Lighting info!");
	}

	public void ccc9d3a38966dc10fedb531ea17d24611()
	{
		if (!(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnlineHostMinResMode)
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
				break;
			}
		}
		mGraphicMgrObj = new GameObject("GraphicMgr");
		mGraphicMgrObj.transform.parent = base.gameObject.transform;
		if (mCharacterFxMgr != null)
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
			mCharacterFxMgr.ccc9d3a38966dc10fedb531ea17d24611();
		}
		if (mBolRTMgr != null)
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
			mBolRTMgr.ccc9d3a38966dc10fedb531ea17d24611();
		}
		GameObject gameObject = new GameObject("SnapCamera");
		gameObject.transform.parent = mGraphicMgrObj.transform;
		mSnapEffectMgr.ccc9d3a38966dc10fedb531ea17d24611(gameObject);
		GameObject gameObject2 = new GameObject("TexPostEffect");
		gameObject2.transform.parent = mGraphicMgrObj.transform;
		mTexPostEffectMgr.ccc9d3a38966dc10fedb531ea17d24611(gameObject2);
		mFpEffectMgr.ccc9d3a38966dc10fedb531ea17d24611(mGraphicMgrObj);
		mFpCameraEffectMgr.ccc9d3a38966dc10fedb531ea17d24611(mGraphicMgrObj);
		mNpcTitleMgr.ccc9d3a38966dc10fedb531ea17d24611();
		GameObject gameObject3 = new GameObject("previewCamera");
		gameObject3.transform.parent = mGraphicMgrObj.transform;
		mUIPreviewMgr.ccc9d3a38966dc10fedb531ea17d24611(gameObject3);
		c8f626bba32832ffb79455022b91d32ea();
		ccbc542cefb11fe2fe60cb1638bb51c90();
	}

	public Matrix4x4 c2694e49b3dd72d5e48cd8c895dcd8516()
	{
		return mWpnCamControl.cd392a2edecfcb3ad1e1ec6bcd9e0afde();
	}

	public void cdc9296eaeada8fb29e6327e8ea46c263(bool ce9ca765ff99e19f289743f05ecf611fa)
	{
		if (Application.platform != RuntimePlatform.WindowsPlayer)
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
					return;
				}
			}
		}
		if (ce9ca765ff99e19f289743f05ecf611fa == mFullScreen)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		if (ce9ca765ff99e19f289743f05ecf611fa)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
				{
					int[] array = c7df10b501931979249f3931a402530da();
					posXBeforeFullScreen = array[0];
					posYBeforeFullScreen = array[1];
					restoreResolution.width = Screen.width;
					restoreResolution.height = Screen.height;
					cb3126faefa49b5f249219d552893aeb5(-widthMargin, -titleHeight, 0, 0);
					Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, false);
					mFullScreen = true;
					return;
				}
				}
			}
		}
		cb3126faefa49b5f249219d552893aeb5(posXBeforeFullScreen, posYBeforeFullScreen, 0, 0);
		Screen.SetResolution(restoreResolution.width, restoreResolution.height, false);
		mFullScreen = false;
	}

	public void cec8851c193f8c5acd30d850dc225c27c()
	{
		mResIndex++;
		if (mResIndex >= mSupportResInfoArray.Count)
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
			mResIndex = 0;
		}
		Resolution resolution = mSupportResInfoArray[mResIndex];
		Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen, 0);
		mFullScreen = false;
	}

	public List<Resolution> caab7a5deeed79bf492ba0eb309877b09()
	{
		return mSupportResInfoArray;
	}

	public Resolution c89e060370172be264cf70d913cf785f5()
	{
		Resolution c36964cf41281414170f34ee68bef6c = default(Resolution);
		c6db7dc205a7d9988b99bd67708d3c321.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
		c36964cf41281414170f34ee68bef6c.width = 0;
		c36964cf41281414170f34ee68bef6c.height = 0;
		using (List<Resolution>.Enumerator enumerator = mSupportResInfoArray.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Resolution current = enumerator.Current;
				if (current.width + current.height <= c36964cf41281414170f34ee68bef6c.width + c36964cf41281414170f34ee68bef6c.height)
				{
					continue;
				}
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
				c36964cf41281414170f34ee68bef6c.width = current.width;
				c36964cf41281414170f34ee68bef6c.height = current.height;
				c36964cf41281414170f34ee68bef6c.refreshRate = current.refreshRate;
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				return c36964cf41281414170f34ee68bef6c;
			}
		}
	}

	public bool c874545c544d3c5eb582d8011a5b38382(int c1dc62a9f1323a11caf8c414033dd8664, int cdfb3569b5c3a736a4b6dd8e7dc1efcab)
	{
		using (List<Resolution>.Enumerator enumerator = mSupportResInfoArray.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Resolution current = enumerator.Current;
				if (current.width != c1dc62a9f1323a11caf8c414033dd8664)
				{
					continue;
				}
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
				if (current.height != cdfb3569b5c3a736a4b6dd8e7dc1efcab)
				{
					continue;
				}
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					return true;
				}
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					goto end_IL_005e;
				}
				continue;
				end_IL_005e:
				break;
			}
		}
		return false;
	}

	public bool cfd94cabf4bc48ab0b63510121c0c5a11(int c1dc62a9f1323a11caf8c414033dd8664, int cdfb3569b5c3a736a4b6dd8e7dc1efcab)
	{
		if (!c874545c544d3c5eb582d8011a5b38382(c1dc62a9f1323a11caf8c414033dd8664, cdfb3569b5c3a736a4b6dd8e7dc1efcab))
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
					array[0] = "This system can't support this resolution: width = ";
					array[1] = c1dc62a9f1323a11caf8c414033dd8664;
					array[2] = ", height = ";
					array[3] = cdfb3569b5c3a736a4b6dd8e7dc1efcab;
					DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Graphics, string.Concat(array));
					return false;
				}
				}
			}
		}
		Screen.SetResolution(c1dc62a9f1323a11caf8c414033dd8664, cdfb3569b5c3a736a4b6dd8e7dc1efcab, Screen.fullScreen);
		return true;
	}

	public void ce5b1d2bd701cbd0a2796b43591b3561a()
	{
		if (!(mEntityPlay != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			mOriSceneFov = mEntityPlay.c9b6d1d87bef7b03dad787ff0031551ee().cd3d8b35d2647005675ba92178c253805<BHVFirstPersonSettings>().m_FOVDefault;
			WeaponCameraControl componentInChildren = mEntityPlay.GetComponentInChildren<WeaponCameraControl>();
			Camera camera = componentInChildren.camera;
			mOriWpnFov = camera.fieldOfView;
			mOriCameraLSPos = mFpsCamera.transform.localPosition;
			return;
		}
	}

	private void c5e32f3e442eed3279685c7505be5ca77()
	{
		mEntityPlay.c9b6d1d87bef7b03dad787ff0031551ee().cd3d8b35d2647005675ba92178c253805<BHVFirstPersonSettings>().m_FOVDefault = mOriSceneFov;
		WeaponCameraControl componentInChildren = mEntityPlay.GetComponentInChildren<WeaponCameraControl>();
		Camera camera = componentInChildren.camera;
		camera.fieldOfView = mOriWpnFov;
		mEntityPlay.m_equipedWeapon.c2cf125a3ac2861ae411123eacb7237b1(mOriWpnFov);
		GameObject gameObject = mEntityPlay.cdc80718389782f689e37bd44dbe7ee66().gameObject;
		SkinnedMeshRenderer component = gameObject.GetComponent<SkinnedMeshRenderer>();
		component.material.SetMatrix("_ProjMat", componentInChildren.cd392a2edecfcb3ad1e1ec6bcd9e0afde());
		mFpsCamera.transform.localPosition = mOriCameraLSPos;
	}

	public void cde69f813c75ed74f0d2b4d4a985d1115()
	{
		float num = 500f;
		float num2 = 100f;
		float num3 = 30f;
		float num4 = 150f;
		float height = 30f;
		if (mEntityPlay != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			float fOVDefault = GUI.HorizontalSlider(new Rect(num, num2 + num3, num4, height), mEntityPlay.c9b6d1d87bef7b03dad787ff0031551ee().cd3d8b35d2647005675ba92178c253805<BHVFirstPersonSettings>().m_FOVDefault, 3f, 175f);
			GUI.Label(new Rect(num, num2, num4, height), "Scene Fov : " + fOVDefault);
			mEntityPlay.c9b6d1d87bef7b03dad787ff0031551ee().cd3d8b35d2647005675ba92178c253805<BHVFirstPersonSettings>().m_FOVDefault = fOVDefault;
			WeaponCameraControl componentInChildren = mEntityPlay.GetComponentInChildren<WeaponCameraControl>();
			Camera camera = componentInChildren.camera;
			float fieldOfView = camera.fieldOfView;
			float num5 = GUI.HorizontalSlider(new Rect(num, num2 + num3 * 3f, num4, height), camera.fieldOfView, 3f, 175f);
			GUI.Label(new Rect(num, num2 + num3 * 2f, num4, height), "Weapon Fov : " + num5);
			if (!Mathf.Approximately(fieldOfView, num5))
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
				mEntityPlay.m_equipedWeapon.c2cf125a3ac2861ae411123eacb7237b1(num5);
				GameObject gameObject = mEntityPlay.cdc80718389782f689e37bd44dbe7ee66().gameObject;
				SkinnedMeshRenderer component = gameObject.GetComponent<SkinnedMeshRenderer>();
				component.material.SetMatrix("_ProjMat", componentInChildren.cd392a2edecfcb3ad1e1ec6bcd9e0afde());
			}
		}
		if (!(mEntityPlay != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			Transform transform = mFpsCamera.transform;
			float num6 = 0.2f;
			float num7 = 0.5f;
			float width = 50f;
			float num8 = 30f;
			int num9 = 5;
			int num10 = 300;
			GUI.Label(new Rect(num, num2 + num3 * (float)num9, num4 + 300f, height), "FpsCam Local : " + transform.localPosition.ToString("n3"));
			num9++;
			GUI.Label(new Rect(num, num2 + num3 * (float)num9, width, height), "z : ");
			float x = GUI.HorizontalSlider(new Rect(num + num8, num2 + num3 * (float)num9, num10, height), transform.localPosition.x, 0f - num7, num7);
			num9++;
			GUI.Label(new Rect(num, num2 + num3 * (float)num9, width, height), "x : ");
			float y = GUI.HorizontalSlider(new Rect(num + num8, num2 + num3 * (float)num9, num10, height), transform.localPosition.y, 0f - num6, num6);
			num9++;
			GUI.Label(new Rect(num, num2 + num3 * (float)num9, width, height), "y : ");
			float z = GUI.HorizontalSlider(new Rect(num + num8, num2 + num3 * (float)num9, num10, height), transform.localPosition.z, 0f - num6, num6);
			num9++;
			transform.localPosition = new Vector3(x, y, z);
			if (!GUI.Button(new Rect(num, num2 + num3 * (float)num9, width, height), "Reset"))
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
				c5e32f3e442eed3279685c7505be5ca77();
				return;
			}
		}
	}

	public void c04af773a558b79f50ffd46b6d46137d0(GameObject cc518a48439964aceecaf2169f9016671, float cbdb75e3df89ce8af9387f0854dd17bf4)
	{
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnlineHostMinResMode)
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
			if (!(cc518a48439964aceecaf2169f9016671 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				float num = 10f;
				int num2 = (int)(cc518a48439964aceecaf2169f9016671.transform.position - mFpsCameraPos).magnitude;
				SkinnedMeshRenderer component = cc518a48439964aceecaf2169f9016671.GetComponent<SkinnedMeshRenderer>();
				if (!(component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					Material[] materials = component.materials;
					foreach (Material material in materials)
					{
						if ((float)num2 > num)
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
							material.SetFloat("_BRDF_PARA", 0f);
						}
						else
						{
							material.SetFloat("_BRDF_PARA", cbdb75e3df89ce8af9387f0854dd17bf4);
						}
					}
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							return;
						}
					}
				}
			}
		}
	}

	public BolRTMgr ccffb6c52596bb8aa19fb001ee528ca6d()
	{
		return mBolRTMgr;
	}

	public CharacterFxMgr c9e16403ef21c39f75e639d41fc5111b7()
	{
		return mCharacterFxMgr;
	}

	public void Update()
	{
		if (mFpsCamera != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			mFpsCameraPos = mFpsCamera.transform.position;
		}
		mSnapEffectMgr.Update();
		if (mLastResolution.width == Screen.width)
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
			if (mLastResolution.height == Screen.height)
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
		if (mLastResolution.width != -1)
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
			if (mLastResolution.height != -1)
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
				OnChangeResolution(Screen.width, Screen.height);
			}
		}
		mLastResolution.width = Screen.width;
		mLastResolution.height = Screen.height;
	}

	public Camera c800a736f9c78c72b510a3f7e608b6fb4()
	{
		return mFpsCamera;
	}

	public void FixedUpdate()
	{
		if (mEntityPlay == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					mEntityPlay = (EntityPlayer)c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().c66b232dbebded7c7e9a89c1e8bd84689();
				}
			}
		}
		if (mFpsCamera == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (mEntityPlay != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (mEntityPlay.cc6a7269e9ea93e537de47dc752b09a86() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					mFpsCamera = mEntityPlay.cc6a7269e9ea93e537de47dc752b09a86().camera;
				}
			}
		}
		if (mEntityPlay != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (mWpnCamControl == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				mWpnCamControl = mEntityPlay.GetComponentInChildren<WeaponCameraControl>();
			}
		}
		if (mCharacterFxMgr == null)
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
			mCharacterFxMgr.Update();
			return;
		}
	}

	public CameraEffectMgr ca5bd80f5ff7a2e9ca939a6283399ec2d()
	{
		return mCameraEffectMgr;
	}

	public SnapEffectMgr c848ee3ec1aba9ee52ed305a7c47e42ce()
	{
		return mSnapEffectMgr;
	}

	public FpEffectMgr c20e43347435e746a8d6d3d2c3d99c2f6()
	{
		return mFpEffectMgr;
	}

	public NpcTitleMgr cd76850fff3f38531496e8d16b9a1db09()
	{
		return mNpcTitleMgr;
	}

	public UIPreviewMgr ce9030196d2dbfbe5a5051960f05df6d0()
	{
		return mUIPreviewMgr;
	}

	public TexPostEffectMgr c0e679f4989d9772fd4db03bedfd64968()
	{
		return mTexPostEffectMgr;
	}

	public FpCameraEffectMgr c988e4ac6fdd1506753a02a8d529aa7be()
	{
		return mFpCameraEffectMgr;
	}

	public void c66f6f5c1adb9e048546e406c25cf43db()
	{
		List<Entity> c0c2a548e7e20a141e7763c365a4d;
		c06ca0e618478c23eba3419653a19760f<EntityManager>.c5ee19dc8d4cccf5ae2de225410458b86.c87ecafd3dda798dbf216aaf5316d45f6(Entity.EntityType.Player, out c0c2a548e7e20a141e7763c365a4d);
		for (int i = 0; i < c0c2a548e7e20a141e7763c365a4d.Count; i++)
		{
			EntityPlayer entityPlayer = c0c2a548e7e20a141e7763c365a4d[i] as EntityPlayer;
			if (entityPlayer.caac907d451029d68503484a63934c93f())
			{
				continue;
			}
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
			entityPlayer.c6a81925b944ea7d0f6008bd83da0380d(true);
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	public void c6394b4e5eb2c68525f7e96959e519fb7()
	{
		List<Entity> c0c2a548e7e20a141e7763c365a4d;
		c06ca0e618478c23eba3419653a19760f<EntityManager>.c5ee19dc8d4cccf5ae2de225410458b86.c87ecafd3dda798dbf216aaf5316d45f6(Entity.EntityType.Player, out c0c2a548e7e20a141e7763c365a4d);
		for (int i = 0; i < c0c2a548e7e20a141e7763c365a4d.Count; i++)
		{
			EntityPlayer entityPlayer = c0c2a548e7e20a141e7763c365a4d[i] as EntityPlayer;
			if (entityPlayer.caac907d451029d68503484a63934c93f())
			{
				continue;
			}
			while (true)
			{
				switch (5)
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
			entityPlayer.c6a81925b944ea7d0f6008bd83da0380d(false);
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	[DllImport("user32.dll", EntryPoint = "GetForegroundWindow")]
	private static extern IntPtr c341edfd3cd3f0d8f6c0004012bbc3bf5();

	[DllImport("user32.dll", EntryPoint = "GetWindowRect")]
	private static extern bool cc46b6dcfc39f535727bb31726fbf95e3(IntPtr cd166f04fc352569cf5173308b7cf2444, out WindowsRECT c2cc1b8f71d8f03c1aeb5bbfd0d1c3221);

	[DllImport("user32.dll", EntryPoint = "SetWindowPos")]
	private static extern bool cc37d9eea8f52ad2af531da6d8a6f46a6(IntPtr cef3556ef492684a97af026c46392c38f, int c5baaa360b1f4afca7ed19a4af8f3a9fe, int c5ebdc65d5cb420faf7ba524809963aa9, int c6725a1e4c7f38417d2fb352556181fe5, int c0b1d09605989f46bacb30020eb1a1d24, int c8283ed60caf94af1c9576a81434c5019, int c8b35b97319c95e850bfe5de03e5e1cc6);

	[DllImport("user32.dll", EntryPoint = "FindWindow")]
	private static extern IntPtr caabb5a24f6165378db05a9a8c9960faa(string c4d5566b45034dba2ede6abfcc93260aa, string cf588e4f1c49f4f3783dc7516b1b5c05b);

	[DllImport("user32.dll", EntryPoint = "GetWindowLong")]
	private static extern long c3b206076a1259e6382c146131729ae69(IntPtr cd166f04fc352569cf5173308b7cf2444, int cadd0768db0496c880b7f7b5b441a533d);

	[DllImport("user32.dll", EntryPoint = "SetWindowLong")]
	private static extern long cbe5e40de7d2982663b74dd04355279c5(IntPtr cd166f04fc352569cf5173308b7cf2444, int cadd0768db0496c880b7f7b5b441a533d, long c6141460a4ded5396b69f28840d97492c);

	private int[] c7df10b501931979249f3931a402530da()
	{
		int[] array = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(4);
		WindowsRECT c2cc1b8f71d8f03c1aeb5bbfd0d1c = default(WindowsRECT);
		cc46b6dcfc39f535727bb31726fbf95e3(c341edfd3cd3f0d8f6c0004012bbc3bf5(), out c2cc1b8f71d8f03c1aeb5bbfd0d1c);
		array[0] = c2cc1b8f71d8f03c1aeb5bbfd0d1c.Left;
		array[1] = c2cc1b8f71d8f03c1aeb5bbfd0d1c.Top;
		array[2] = c2cc1b8f71d8f03c1aeb5bbfd0d1c.Right;
		array[3] = c2cc1b8f71d8f03c1aeb5bbfd0d1c.Bottom;
		return array;
	}

	private void ccbc542cefb11fe2fe60cb1638bb51c90()
	{
		if (Application.platform != RuntimePlatform.WindowsPlayer)
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
			int[] array = c7df10b501931979249f3931a402530da();
			int num = array[2] - array[0];
			int num2 = array[3] - array[1];
			widthMargin = (num - Screen.width) / 2;
			titleHeight = num2 - Screen.height - widthMargin;
			return;
		}
	}

	private bool cb3126faefa49b5f249219d552893aeb5(int c5ebdc65d5cb420faf7ba524809963aa9, int c9d16e16b57deb9bb1da907451ba1f25b, int ce6a10e6f44eb3512ad9deb102ad672ea, int c1dd39d5f302416bcff295ffadc160d97)
	{
		IntPtr intPtr = c341edfd3cd3f0d8f6c0004012bbc3bf5();
		IntPtr intPtr2 = caabb5a24f6165378db05a9a8c9960faa(null, "Borderlands Online");
		if (intPtr == intPtr2)
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
					StartCoroutine(c13b9c3b828ed8df52f7f24b68a7523f4(intPtr, c5ebdc65d5cb420faf7ba524809963aa9, c9d16e16b57deb9bb1da907451ba1f25b, ce6a10e6f44eb3512ad9deb102ad672ea, c1dd39d5f302416bcff295ffadc160d97, 0.05f));
					return true;
				}
			}
		}
		return false;
	}

	public IEnumerator c13b9c3b828ed8df52f7f24b68a7523f4(IntPtr cef54a48e668e01d38a41425f24740e24, int c5ebdc65d5cb420faf7ba524809963aa9, int c9d16e16b57deb9bb1da907451ba1f25b, int ce6a10e6f44eb3512ad9deb102ad672ea, int c1dd39d5f302416bcff295ffadc160d97, float cb17344c6ba6038b9297f344b2472c2f5)
	{
		yield return new WaitForSeconds(cb17344c6ba6038b9297f344b2472c2f5);
		int c8b35b97319c95e850bfe5de03e5e1cc;
		if (ce6a10e6f44eb3512ad9deb102ad672ea * c1dd39d5f302416bcff295ffadc160d97 != 0)
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
			c8b35b97319c95e850bfe5de03e5e1cc = 0;
		}
		else
		{
			c8b35b97319c95e850bfe5de03e5e1cc = 1;
		}
		cc37d9eea8f52ad2af531da6d8a6f46a6(cef54a48e668e01d38a41425f24740e24, 0, c5ebdc65d5cb420faf7ba524809963aa9, c9d16e16b57deb9bb1da907451ba1f25b, ce6a10e6f44eb3512ad9deb102ad672ea, c1dd39d5f302416bcff295ffadc160d97, c8b35b97319c95e850bfe5de03e5e1cc);
	}

	public void c4da1d12b82b3dc60ec775b00dd0c80e8()
	{
		IntPtr intPtr = c341edfd3cd3f0d8f6c0004012bbc3bf5();
		IntPtr intPtr2 = caabb5a24f6165378db05a9a8c9960faa(null, "Borderlands Online");
		if (!(intPtr == intPtr2))
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
			long num = c3b206076a1259e6382c146131729ae69(intPtr, -16);
			restoreWindowStyle = num;
			cbe5e40de7d2982663b74dd04355279c5(intPtr, -16, 16777216L);
			return;
		}
	}

	public void c7d19c8dab71520305aa3023fcdc19ca3()
	{
		IntPtr intPtr = c341edfd3cd3f0d8f6c0004012bbc3bf5();
		IntPtr intPtr2 = caabb5a24f6165378db05a9a8c9960faa(null, "Borderlands Online");
		if (!(intPtr == intPtr2))
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
			cbe5e40de7d2982663b74dd04355279c5(intPtr2, -16, restoreWindowStyle);
			return;
		}
	}

	[CompilerGenerated]
	private static void c5577297aa993933f58d7eb748b0502aa(int c36964cf41281414170f34ee68bef6c06, int c36964cf41281414170f34ee68bef6c06)
	{
	}
}
