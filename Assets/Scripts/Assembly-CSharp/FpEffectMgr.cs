using System;
using A;
using BHV;
using Core;
using UnityEngine;

public class FpEffectMgr
{
	private static float s_fSqrtPI = (float)Math.Sqrt(Math.PI);

	private static float s_fC0 = 1f / (2f * s_fSqrtPI);

	private static float s_fC1 = (float)Math.Sqrt(3.0) / (3f * s_fSqrtPI);

	private static float s_fC2 = (float)Math.Sqrt(15.0) / (8f * s_fSqrtPI);

	private static float s_fC3 = (float)Math.Sqrt(5.0) / (16f * s_fSqrtPI);

	private static float s_fC4 = 0.5f * s_fC2;

	private GameObject mGraphicMgrObj;

	private EntityPlayer mEntityPlay;

	private Mesh mFpWpnMesh;

	private Mesh mFpHandMesh;

	private Material mFpWpnMaterial;

	private Material mFpHandMaterial;

	private Camera mFpsCamera;

	private GameObject mHandModel;

	private bool mEnableRageEffect;

	private bool mEnableDash;

	private Material mRefractionMat;

	private Mesh mPlane;

	private Matrix4x4 mLocalMatrix;

	private Matrix4x4 mToWorldMat;

	private float mOriFov;

	private CustomMotionBlur mCustomMotionBlur;

	private Shader mShaderMotionBlur;

	private Texture mBlurMaskTex;

	private float mblurAmount;

	private bool mHasEffect;

	private Utils.Timer mTimer;

	private CharacterFxMgr.FX_TYPE mType;

	private MaterialPropertyBlock lightProbBlock;

	private Texture mRespawnTexture;

	private float mRespawnStrength = 1f;

	private float mRespawnSpeedU;

	private float mRespawnSpeedV;

	public void cad4b9805ada962a49e6eb4b43bce403b(bool cc2a4a02a728c83b472006c5fc196fded)
	{
		mEnableRageEffect = cc2a4a02a728c83b472006c5fc196fded;
	}

	public void c881ca682404299c847daa474407e6ac0(bool cc2a4a02a728c83b472006c5fc196fded)
	{
		mEnableDash = cc2a4a02a728c83b472006c5fc196fded;
	}

	private void c82fc4ddf3be9bc7bf077d24d29fa87c4()
	{
		mEnableRageEffect = false;
		RageEffectData component = (Resources.Load("Graphics/GraphicsData") as GameObject).GetComponent<RageEffectData>();
		mRefractionMat = component.mRefractionMaterial;
		GameObject gameObject = UnityEngine.Object.Instantiate(Resources.Load("Graphics/CHR_RagePlane") as GameObject) as GameObject;
		mPlane = UnityEngine.Object.Instantiate(gameObject.GetComponent<MeshFilter>().mesh) as Mesh;
		Vector3 pos = new Vector3(0f, 0f, 11f);
		Quaternion q = Quaternion.Euler(270f, 0f, 0f);
		Vector3 s = new Vector3(1.8f, 0.9f, 1f);
		mLocalMatrix = Matrix4x4.TRS(pos, q, s);
		mShaderMotionBlur = component.mCustomMotionBlurShader;
		mBlurMaskTex = component.mBlurMaskTex;
		mblurAmount = component.mAccPara;
	}

	public void ccc9d3a38966dc10fedb531ea17d24611(GameObject c93ebf9c9e9b3c7c4b0e9738fd12a7d8f)
	{
		mGraphicMgrObj = c93ebf9c9e9b3c7c4b0e9738fd12a7d8f;
		mFpWpnMesh = new Mesh();
		mFpHandMesh = new Mesh();
		mFpWpnMaterial = new Material(Shader.Find("Custom/BOL_Wpn_MaskReflectFov"));
		mFpHandMaterial = new Material(Shader.Find("Custom/diffuseFOV"));
		mGraphicMgrObj.AddComponent<FpDrawEffectLogic>();
		c82fc4ddf3be9bc7bf077d24d29fa87c4();
	}

	public void cd9568bf035fae5f39fd87a96cba69fa2(float cc38eba0587ccfea8f79928554ac7e78f, CharacterFxMgr.FX_TYPE c4b8b40b1ebdb4d69424a5e73de76f930)
	{
		mTimer = new Utils.Timer();
		mTimer.Start(cc38eba0587ccfea8f79928554ac7e78f);
		mType = c4b8b40b1ebdb4d69424a5e73de76f930;
		mHasEffect = true;
		if (mType == CharacterFxMgr.FX_TYPE.FX_REVIVE)
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
					if (mRespawnTexture == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
					{
						while (true)
						{
							switch (5)
							{
							case 0:
								break;
							default:
							{
								CharacterEffectData component = (Resources.Load("Graphics/GraphicsData") as GameObject).GetComponent<CharacterEffectData>();
								mRespawnTexture = component.mFirstPersonRespawnTexture;
								mRespawnStrength = component.mFirstPersonRespawnStrength;
								mRespawnSpeedU = component.mFirstPersonRespawnSpeedU;
								mRespawnSpeedV = component.mFirstPersonRespawnSpeedV;
								return;
							}
							}
						}
					}
					return;
				}
			}
		}
		c3438f8cd2b9d35b7420e6d0ee6dd08a8(mFpHandMaterial);
		c3438f8cd2b9d35b7420e6d0ee6dd08a8(mFpWpnMaterial);
	}

	private void c3438f8cd2b9d35b7420e6d0ee6dd08a8(Material c4b37d539f2c2303a31bf314f3f555bef)
	{
		CharacterFxMgr characterFxMgr = c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c9e16403ef21c39f75e639d41fc5111b7();
		Color color = characterFxMgr.c874abf1cebf73b8b253992f74522f43b()[(int)mType].ca6131082fcef8cf5e97b5772101f806f();
		c4b37d539f2c2303a31bf314f3f555bef.SetColor("_Effect_Color", color);
		c4b37d539f2c2303a31bf314f3f555bef.SetFloat("_Effect_Para", characterFxMgr.c874abf1cebf73b8b253992f74522f43b()[(int)mType].c7f91a925f6a1a150cb056338b13bbdcc().r);
	}

	private void cb8ec6fda84b9898f8dd6a1138f3f3012(Material c9055860f74af9225a85b37acded87bc4, Vector3 c8dcaedc408f69d1c0d517b5236596524)
	{
		Vector4[] array = c6b9b486e00bdfd9ee7ce0bac7f34a00e.c0a0cdf4a196914163f7334d9b0781a04(3);
		array[0] = Vector4.zero;
		array[1] = Vector4.zero;
		array[2] = Vector4.zero;
		Vector4[] cd879311cfd546183ad0d37421b5cb7ed = array;
		Vector4[] array2 = c6b9b486e00bdfd9ee7ce0bac7f34a00e.c0a0cdf4a196914163f7334d9b0781a04(3);
		array2[0] = Vector4.zero;
		array2[1] = Vector4.zero;
		array2[2] = Vector4.zero;
		Vector4[] c84a85213374affe55185103eff3790d = array2;
		Vector4 cec2ef0cebd12d37e23e2e97d93e4d3a = Vector4.zero;
		c1e4bc00aa59320fec98dbb66973ff06a(c8dcaedc408f69d1c0d517b5236596524, ref cd879311cfd546183ad0d37421b5cb7ed, ref c84a85213374affe55185103eff3790d, ref cec2ef0cebd12d37e23e2e97d93e4d3a);
		c9055860f74af9225a85b37acded87bc4.SetVector("unity_SHAr", cd879311cfd546183ad0d37421b5cb7ed[0]);
		c9055860f74af9225a85b37acded87bc4.SetVector("unity_SHAg", cd879311cfd546183ad0d37421b5cb7ed[1]);
		c9055860f74af9225a85b37acded87bc4.SetVector("unity_SHAb", cd879311cfd546183ad0d37421b5cb7ed[2]);
		c9055860f74af9225a85b37acded87bc4.SetVector("unity_SHBr", c84a85213374affe55185103eff3790d[0]);
		c9055860f74af9225a85b37acded87bc4.SetVector("unity_SHBg", c84a85213374affe55185103eff3790d[1]);
		c9055860f74af9225a85b37acded87bc4.SetVector("unity_SHBb", c84a85213374affe55185103eff3790d[2]);
		c9055860f74af9225a85b37acded87bc4.SetVector("unity_SHC", cec2ef0cebd12d37e23e2e97d93e4d3a);
		c9055860f74af9225a85b37acded87bc4.SetColor("_AmbintLight", RenderSettings.ambientLight);
	}

	private void c1e4bc00aa59320fec98dbb66973ff06a(Vector3 c8dcaedc408f69d1c0d517b5236596524, ref Vector4[] cd879311cfd546183ad0d37421b5cb7ed, ref Vector4[] c84a85213374affe55185103eff3790d6, ref Vector4 cec2ef0cebd12d37e23e2e97d93e4d3a4)
	{
		float[] array = c45a99a14f737cada4caa361b45034f4d.c0a0cdf4a196914163f7334d9b0781a04(27);
		LightmapSettings.lightProbes.GetInterpolatedLightProbe(c8dcaedc408f69d1c0d517b5236596524, null, array);
		float[][] array2 = cd95db4156b58f4e69611463e4ef580a6.c0a0cdf4a196914163f7334d9b0781a04(3);
		float[] array3 = c45a99a14f737cada4caa361b45034f4d.c0a0cdf4a196914163f7334d9b0781a04(9);
		array3[0] = array[0];
		array3[1] = array[3];
		array3[2] = array[6];
		array3[3] = array[9];
		array3[4] = array[12];
		array3[5] = array[15];
		array3[6] = array[18];
		array3[7] = array[21];
		array3[8] = array[24];
		array2[0] = array3;
		float[] array4 = c45a99a14f737cada4caa361b45034f4d.c0a0cdf4a196914163f7334d9b0781a04(9);
		array4[0] = array[1];
		array4[1] = array[4];
		array4[2] = array[7];
		array4[3] = array[10];
		array4[4] = array[13];
		array4[5] = array[16];
		array4[6] = array[19];
		array4[7] = array[22];
		array4[8] = array[25];
		array2[1] = array4;
		float[] array5 = c45a99a14f737cada4caa361b45034f4d.c0a0cdf4a196914163f7334d9b0781a04(9);
		array5[0] = array[2];
		array5[1] = array[5];
		array5[2] = array[8];
		array5[3] = array[11];
		array5[4] = array[14];
		array5[5] = array[17];
		array5[6] = array[20];
		array5[7] = array[23];
		array5[8] = array[26];
		array2[2] = array5;
		float[][] array6 = array2;
		for (int i = 0; i < 3; i++)
		{
			cd879311cfd546183ad0d37421b5cb7ed[i].x = (0f - s_fC1) * array6[i][3];
			cd879311cfd546183ad0d37421b5cb7ed[i].y = (0f - s_fC1) * array6[i][1];
			cd879311cfd546183ad0d37421b5cb7ed[i].z = s_fC1 * array6[i][2];
			cd879311cfd546183ad0d37421b5cb7ed[i].w = s_fC0 * array6[i][0] - s_fC3 * array6[i][6];
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
			for (int i = 0; i < 3; i++)
			{
				c84a85213374affe55185103eff3790d6[i].x = s_fC2 * array6[i][4];
				c84a85213374affe55185103eff3790d6[i].y = (0f - s_fC2) * array6[i][5];
				c84a85213374affe55185103eff3790d6[i].z = 3f * s_fC3 * array6[i][6];
				c84a85213374affe55185103eff3790d6[i].w = (0f - s_fC2) * array6[i][7];
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				cec2ef0cebd12d37e23e2e97d93e4d3a4.x = s_fC4 * array6[0][8];
				cec2ef0cebd12d37e23e2e97d93e4d3a4.y = s_fC4 * array6[1][8];
				cec2ef0cebd12d37e23e2e97d93e4d3a4.z = s_fC4 * array6[2][8];
				cec2ef0cebd12d37e23e2e97d93e4d3a4.w = 0f;
				return;
			}
		}
	}

	private MaterialPropertyBlock caf82540856101b5ab4cb48bb48bcd88f(Vector3 c8dcaedc408f69d1c0d517b5236596524)
	{
		Vector4[] array = c6b9b486e00bdfd9ee7ce0bac7f34a00e.c0a0cdf4a196914163f7334d9b0781a04(3);
		array[0] = Vector4.zero;
		array[1] = Vector4.zero;
		array[2] = Vector4.zero;
		Vector4[] cd879311cfd546183ad0d37421b5cb7ed = array;
		Vector4[] array2 = c6b9b486e00bdfd9ee7ce0bac7f34a00e.c0a0cdf4a196914163f7334d9b0781a04(3);
		array2[0] = Vector4.zero;
		array2[1] = Vector4.zero;
		array2[2] = Vector4.zero;
		Vector4[] c84a85213374affe55185103eff3790d = array2;
		Vector4 cec2ef0cebd12d37e23e2e97d93e4d3a = Vector4.zero;
		c1e4bc00aa59320fec98dbb66973ff06a(c8dcaedc408f69d1c0d517b5236596524, ref cd879311cfd546183ad0d37421b5cb7ed, ref c84a85213374affe55185103eff3790d, ref cec2ef0cebd12d37e23e2e97d93e4d3a);
		MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
		materialPropertyBlock.AddVector("unity_SHAr", cd879311cfd546183ad0d37421b5cb7ed[0]);
		materialPropertyBlock.AddVector("unity_SHAg", cd879311cfd546183ad0d37421b5cb7ed[1]);
		materialPropertyBlock.AddVector("unity_SHAb", cd879311cfd546183ad0d37421b5cb7ed[2]);
		materialPropertyBlock.AddVector("unity_SHBr", c84a85213374affe55185103eff3790d[0]);
		materialPropertyBlock.AddVector("unity_SHBg", c84a85213374affe55185103eff3790d[1]);
		materialPropertyBlock.AddVector("unity_SHBb", c84a85213374affe55185103eff3790d[2]);
		materialPropertyBlock.AddVector("unity_SHC", cec2ef0cebd12d37e23e2e97d93e4d3a);
		materialPropertyBlock.AddVector("_AmbintLight", RenderSettings.ambientLight);
		return materialPropertyBlock;
	}

	private void c39873085c632fb1cca8b7a250ddc2fee()
	{
		if (!(mFpsCamera != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (mEnableRageEffect)
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
				float num = (float)Math.PI / 180f * mFpsCamera.fieldOfView;
				float num2 = (float)Math.PI / 180f * mOriFov;
				float num3 = Mathf.Tan(num * 0.5f) / Mathf.Tan(num2 * 0.5f);
				Matrix4x4 matrix4x = Matrix4x4.Scale(new Vector3(num3, num3, 1f));
				Matrix4x4 localToWorldMatrix = mFpsCamera.gameObject.transform.localToWorldMatrix;
				mToWorldMat = localToWorldMatrix * matrix4x * mLocalMatrix;
				Graphics.DrawMesh(mPlane, mToWorldMat, mRefractionMat, 0, c4ffee394d9d7cb3cc1237fb7e347bc29.c7088de59e49f7108f520cf7e0bae167e);
			}
			if (mEnableDash)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						if (mCustomMotionBlur == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
						{
							while (true)
							{
								switch (1)
								{
								case 0:
									break;
								default:
									mCustomMotionBlur = mFpsCamera.gameObject.AddComponent<CustomMotionBlur>();
									mCustomMotionBlur.shader = mShaderMotionBlur;
									mCustomMotionBlur.mBlurMaskTex = mBlurMaskTex;
									mCustomMotionBlur.blurAmount = mblurAmount;
									return;
								}
							}
						}
						return;
					}
				}
			}
			if (!(mCustomMotionBlur != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				UnityEngine.Object.Destroy(mCustomMotionBlur);
				return;
			}
		}
	}

	private void c150500446ba6ed4f8c3fca46bd1e00be()
	{
		EntityWeapon equipedWeapon = mEntityPlay.m_equipedWeapon;
		if (mEntityPlay != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (mEntityPlay.cc6a7269e9ea93e537de47dc752b09a86() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				mFpsCamera = mEntityPlay.cc6a7269e9ea93e537de47dc752b09a86().camera;
				mOriFov = mEntityPlay.c9b6d1d87bef7b03dad787ff0031551ee().cd3d8b35d2647005675ba92178c253805<BHVFirstPersonSettings>().m_FOVDefault;
			}
		}
		if (!(equipedWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			SkinnedMeshRenderer mWpnRenderer = equipedWeapon.mWpnRenderer;
			if (!(mWpnRenderer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (mWpnRenderer.materials.Length > 1)
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Graphics, "material number must be one for weapon!");
				}
				c59c00e2c5172fa1beda4c62a3bb226b0();
				Matrix4x4 localToWorldMatrix = mWpnRenderer.gameObject.transform.localToWorldMatrix;
				mWpnRenderer.BakeMesh(mFpWpnMesh);
				if (LightmapSettings.lightProbes == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							Graphics.DrawMesh(mFpWpnMesh, localToWorldMatrix, mFpWpnMaterial, 0);
							return;
						}
					}
				}
				lightProbBlock = caf82540856101b5ab4cb48bb48bcd88f(mWpnRenderer.gameObject.transform.position);
				if (!(mFpsCamera != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					for (int i = 0; i < mFpWpnMesh.subMeshCount; i++)
					{
						Graphics.DrawMesh(mFpWpnMesh, localToWorldMatrix, mFpWpnMaterial, 0, null, i, lightProbBlock, false, true);
					}
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
			}
		}
	}

	private void c59c00e2c5172fa1beda4c62a3bb226b0()
	{
		mFpWpnMaterial.CopyPropertiesFromMaterial(mEntityPlay.m_equipedWeapon.m_thrWpnMat);
		mFpWpnMaterial.SetMatrix("_ProjMat", c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c2694e49b3dd72d5e48cd8c895dcd8516());
		mFpWpnMaterial.SetTexture("_Cube", c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_levelCubemap);
		if (mHasEffect)
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
			if (mTimer != null)
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
				if (mTimer.cf928603d375f06225f9eb5213fb17bd4())
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
					mHasEffect = false;
					mTimer = null;
					if (mType == CharacterFxMgr.FX_TYPE.FX_REVIVE)
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
						mFpWpnMaterial.DisableKeyword("RESPAWN_ON");
						mFpWpnMaterial.SetTexture("_RespawnTexture", c7e1395dd376890f1113e22916ff9ac07.c7088de59e49f7108f520cf7e0bae167e);
						mFpWpnMaterial.SetFloat("_RespawnStrength", 0f);
						mFpWpnMaterial.SetFloat("_RespawnSpeedU", 0f);
						mFpWpnMaterial.SetFloat("_RespawnSpeedV", 0f);
					}
					else
					{
						mFpWpnMaterial.SetFloat("_Effect_Para", 0f);
						mFpWpnMaterial.SetColor("_Effect_Color", new Color(1f, 1f, 1f));
					}
				}
			}
		}
		if (!mHasEffect)
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
			if (mType != CharacterFxMgr.FX_TYPE.FX_REVIVE)
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
				mFpWpnMaterial.EnableKeyword("RESPAWN_ON");
				mFpWpnMaterial.SetTexture("_RespawnTexture", mRespawnTexture);
				mFpWpnMaterial.SetFloat("_RespawnStrength", mRespawnStrength);
				mFpWpnMaterial.SetFloat("_RespawnSpeedU", mRespawnSpeedU);
				mFpWpnMaterial.SetFloat("_RespawnSpeedV", mRespawnSpeedV);
				return;
			}
		}
	}

	private void c643e80f4e898d93a25ec92269a108849()
	{
		Transform c7088de59e49f7108f520cf7e0bae167e = ce1fb4d774e60a964105c162513d97b38.c7088de59e49f7108f520cf7e0bae167e;
		if (mEntityPlay != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (mHandModel == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (mEntityPlay.ccd8e6ea278245d0f158036267242e60f() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					c7088de59e49f7108f520cf7e0bae167e = mEntityPlay.cdc80718389782f689e37bd44dbe7ee66();
					if (c7088de59e49f7108f520cf7e0bae167e == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
					{
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
					mHandModel = c7088de59e49f7108f520cf7e0bae167e.gameObject;
				}
			}
		}
		if (mHandModel == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
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
		if (mEntityPlay.m_equipedWeapon == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
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
		SkinnedMeshRenderer component = mHandModel.GetComponent<SkinnedMeshRenderer>();
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
			c964a9ba3694f9e7346451753c2ba5ab1();
			Matrix4x4 localToWorldMatrix = component.gameObject.transform.localToWorldMatrix;
			component.BakeMesh(mFpHandMesh);
			for (int i = 0; i < mFpHandMesh.subMeshCount; i++)
			{
				Graphics.DrawMesh(mFpHandMesh, localToWorldMatrix, mFpHandMaterial, 0, null, i, lightProbBlock, false, true);
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
	}

	private void c964a9ba3694f9e7346451753c2ba5ab1()
	{
		mFpHandMaterial.CopyPropertiesFromMaterial(mEntityPlay.m_fpHandMaterial);
		mFpHandMaterial.SetMatrix("_ProjMat", c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c2694e49b3dd72d5e48cd8c895dcd8516());
		mFpHandMaterial.SetColor("_Effect_Color", new Color(1f, 1f, 1f));
		if (mHasEffect)
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
			if (mTimer != null)
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
				if (mTimer.cf928603d375f06225f9eb5213fb17bd4())
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
					mHasEffect = false;
					mTimer = null;
					if (mType == CharacterFxMgr.FX_TYPE.FX_REVIVE)
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
						mFpHandMaterial.DisableKeyword("RESPAWN_ON");
						mFpHandMaterial.SetTexture("_RespawnTexture", c7e1395dd376890f1113e22916ff9ac07.c7088de59e49f7108f520cf7e0bae167e);
						mFpHandMaterial.SetFloat("_RespawnStrength", 0f);
						mFpHandMaterial.SetFloat("_RespawnSpeedU", 0f);
						mFpHandMaterial.SetFloat("_RespawnSpeedV", 0f);
					}
					else
					{
						mFpHandMaterial.SetFloat("_Effect_Para", 0f);
						mFpHandMaterial.SetColor("_Effect_Color", new Color(1f, 1f, 1f));
					}
				}
			}
		}
		if (!mHasEffect)
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
			if (mType != CharacterFxMgr.FX_TYPE.FX_REVIVE)
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
				mFpHandMaterial.EnableKeyword("RESPAWN_ON");
				mFpHandMaterial.SetTexture("_RespawnTexture", mRespawnTexture);
				mFpHandMaterial.SetFloat("_RespawnStrength", mRespawnStrength);
				mFpHandMaterial.SetFloat("_RespawnSpeedU", mRespawnSpeedU);
				mFpHandMaterial.SetFloat("_RespawnSpeedV", mRespawnSpeedV);
				return;
			}
		}
	}

	private void c893bac7065a3ec5937da2bc1ccbce67f(SkinnedMeshRenderer c7a4e30656c54011ea87170d8d45af6f2, Mesh c4ea6a3a4fc302daedb765ad1ffc63b34, string c32c6b9381981bef6638b465fc42260f3, Material c1ef0a19ca24f9f36498772084c44dbe1)
	{
		WeaponCameraControl componentInChildren = mEntityPlay.GetComponentInChildren<WeaponCameraControl>();
		mFpWpnMaterial.CopyPropertiesFromMaterial(c1ef0a19ca24f9f36498772084c44dbe1);
		mFpWpnMaterial.SetMatrix("_ProjMat", componentInChildren.cd392a2edecfcb3ad1e1ec6bcd9e0afde());
		Vector3 position = c7a4e30656c54011ea87170d8d45af6f2.gameObject.transform.position;
		Quaternion rotation = c7a4e30656c54011ea87170d8d45af6f2.gameObject.transform.rotation;
		c7a4e30656c54011ea87170d8d45af6f2.BakeMesh(c4ea6a3a4fc302daedb765ad1ffc63b34);
		Graphics.DrawMesh(mFpHandMesh, position, rotation, mFpWpnMaterial, 0);
	}

	public void c9ea61d4a68809e85510e78788ddb216f()
	{
		if (c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.mIsHideFpMesh)
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
			if (mEntityPlay == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						mEntityPlay = (EntityPlayer)c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().c66b232dbebded7c7e9a89c1e8bd84689();
					}
				}
			}
			if (mEntityPlay == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			c150500446ba6ed4f8c3fca46bd1e00be();
			c643e80f4e898d93a25ec92269a108849();
			c39873085c632fb1cca8b7a250ddc2fee();
			return;
		}
	}
}
