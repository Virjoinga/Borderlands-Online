using System.Collections.Generic;
using A;
using UnityEngine;

public class DeathCameraEffect : MonoBehaviour
{
	private enum DEATH_STAT
	{
		STAT_NOT_START = 0,
		STAT_GRAY = 1,
		STAT_BLUR_BLACK = 2,
		STAT_PLAY_PARTICLE = 3
	}

	private const int DEATH_LAYER = 8192;

	private CameraClearFlags m_originCameraClearFlags = CameraClearFlags.Skybox;

	private int m_originCameraCullingMask;

	private bool m_death;

	private Camera m_camera;

	private Camera mParticleCam;

	private DEATH_STAT mCurStat;

	private DeathEffect mDeathEffect;

	private GameObject mRootObj;

	public float mGrayTime = 3f;

	private float mGrayModifyPerSecond;

	public float mBlurBlackTime = 3f;

	public float mModifySceneFovPerSec = 100f;

	public AnimationCurve mChangeToBlackCurve;

	public float mPlayParticlTime = 3f;

	public float mBlurAmout = 0.8f;

	private bool needPlayParticle = true;

	public bool mExtraBlur;

	private float mOriginFov;

	private float mTotalUpdateTime;

	private float mCurStatUpdateTime;

	public float lumScenePara = 1f;

	public float lumFpsPara = 1f;

	public static float s_StopTime = 7f;

	private EntityPlayer mEntityPlay;

	private float mfpOriFov;

	public float mMaxSceneFov = 120f;

	private float mMinFpFpv = 3f;

	public AnimationCurve mFpFovSpeedCurve;

	public bool mAnimPaused;

	private List<Entity> mNpcEntities;

	private void Start()
	{
		cc9b64a0a19385eafdaaa3ac6384a8836();
	}

	private void cc9b64a0a19385eafdaaa3ac6384a8836()
	{
		s_StopTime = mGrayTime + mBlurBlackTime;
		mGrayModifyPerSecond = 1f / mGrayTime;
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
		if (name == "PlayDeath")
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					cbd45278d9fe508a62dbd5474adbbe48f();
					return;
				}
			}
		}
		if (!(name == "PlayRevive"))
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
			c2b191a6b6204643a782d14408e5f0ce4();
			return;
		}
	}

	private void cbd45278d9fe508a62dbd5474adbbe48f()
	{
		if (m_death)
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
		mEntityPlay = (EntityPlayer)c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().c66b232dbebded7c7e9a89c1e8bd84689();
		m_camera = mEntityPlay.cc6a7269e9ea93e537de47dc752b09a86().camera;
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c2a7c8d4c8942c3b965a1a3737dabaf3a(false);
		cc9b64a0a19385eafdaaa3ac6384a8836();
		m_death = true;
		m_originCameraCullingMask = m_camera.cullingMask;
		m_originCameraClearFlags = m_camera.clearFlags;
		mRootObj = base.gameObject.transform.parent.gameObject;
		mDeathEffect = mRootObj.AddComponent<DeathEffect>();
		mDeathEffect.shader = Shader.Find("Custom/DeathEffect");
		mDeathEffect.lumScenePara = lumScenePara;
		mDeathEffect.lumFpsPara = lumFpsPara;
		mTotalUpdateTime = 0f;
		c248e3b853dc06c5199795843f5f4712b();
		mOriginFov = m_camera.fieldOfView;
		c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.ca5bd80f5ff7a2e9ca939a6283399ec2d().c9b75e0c1c51390d2a4e1da0f0555fe93(m_camera, false);
		BadAssFPSCamera component = m_camera.GetComponent<BadAssFPSCamera>();
		if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			component.enabled = false;
		}
		needPlayParticle = true;
		mParticleCam = base.gameObject.AddComponent<Camera>();
		c0573d502c257d8fa66c4c80d40310328();
		if (mAnimPaused)
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
			mEntityPlay.cc6aeb18b193c810dc60d4bc287856afd(true);
		}
		WeaponCameraControl componentInChildren = mEntityPlay.GetComponentInChildren<WeaponCameraControl>();
		mfpOriFov = componentInChildren.c26e0cf146dbd64d5e4f1d6aff5db6cb0().fieldOfView;
		c06ca0e618478c23eba3419653a19760f<EntityManager>.c5ee19dc8d4cccf5ae2de225410458b86.c87ecafd3dda798dbf216aaf5316d45f6(Entity.EntityType.Npc, out mNpcEntities);
	}

	private void c0573d502c257d8fa66c4c80d40310328()
	{
		Utils.c2a8451521957c62f3c9e4fe1e3e5797d(ref m_camera, ref mParticleCam);
		mParticleCam.cullingMask = 8192;
		mParticleCam.depth = 0.05f;
		mParticleCam.clearFlags = CameraClearFlags.Depth;
		mParticleCam.hdr = true;
		mParticleCam.renderingPath = RenderingPath.Forward;
	}

	public void c2b191a6b6204643a782d14408e5f0ce4()
	{
		if (!m_death)
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
		m_death = false;
		Object.Destroy(mParticleCam);
		mParticleCam = c4ffee394d9d7cb3cc1237fb7e347bc29.c7088de59e49f7108f520cf7e0bae167e;
		WeaponCameraControl componentInChildren = mEntityPlay.GetComponentInChildren<WeaponCameraControl>();
		componentInChildren.c26e0cf146dbd64d5e4f1d6aff5db6cb0().fieldOfView = mfpOriFov;
		componentInChildren.cadd19e77c13c8635640e3b9931b64a0e();
		c2be08896f8f70a1ce40974c7d0ff6f7c(componentInChildren.cd392a2edecfcb3ad1e1ec6bcd9e0afde());
		if (mAnimPaused)
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
			mEntityPlay.cc6aeb18b193c810dc60d4bc287856afd(false);
		}
		mEntityPlay = c709fa52dfb309bbfe248c9f258832331.c7088de59e49f7108f520cf7e0bae167e;
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c2a7c8d4c8942c3b965a1a3737dabaf3a(true);
		m_camera.cullingMask = m_originCameraCullingMask;
		m_camera.clearFlags = m_originCameraClearFlags;
		c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.ca5bd80f5ff7a2e9ca939a6283399ec2d().c9b75e0c1c51390d2a4e1da0f0555fe93(m_camera, true);
		if (mDeathEffect != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			Object.Destroy(mDeathEffect);
			mDeathEffect = c51cec1ee67667efec4b9a07d0f2a2914.c7088de59e49f7108f520cf7e0bae167e;
		}
		if (mNpcEntities != null)
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
			for (int i = 0; i < mNpcEntities.Count; i++)
			{
				EntityNpc entityNpc = mNpcEntities[i] as EntityNpc;
				if (!(entityNpc != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				AnimationManagerFSM animationManagerFSM = entityNpc.cb8119a2676bfbd4df00a9ed683eed91a() as AnimationManagerFSM;
				if (!(animationManagerFSM != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
				{
					continue;
				}
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
				animationManagerFSM.c38e22188b18e8482a7c7b657c0db7eaf();
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
			mNpcEntities = c46d0cfd01df867606732cf27afbc16ab.c7088de59e49f7108f520cf7e0bae167e;
		}
		BadAssFPSCamera component = m_camera.GetComponent<BadAssFPSCamera>();
		if (!(component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			component.enabled = true;
			return;
		}
	}

	private void FixedUpdate()
	{
		if (!(mDeathEffect != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			mTotalUpdateTime += Time.deltaTime;
			mCurStatUpdateTime += Time.deltaTime;
			DEATH_STAT dEATH_STAT = mCurStat;
			if (dEATH_STAT != DEATH_STAT.STAT_GRAY)
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
				if (dEATH_STAT != DEATH_STAT.STAT_BLUR_BLACK)
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
				}
				else
				{
					c05850b0789e310842d0920b7c6e1f056();
				}
			}
			else
			{
				ccc2c3fd4f0c5af9f6e3e9a145419a4c1();
			}
			if (!needPlayParticle)
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
				if (!(mTotalUpdateTime > mPlayParticlTime))
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
					cd87bac4ec51f7543103fb86d16f35cae();
					return;
				}
			}
		}
	}

	private void c2be08896f8f70a1ce40974c7d0ff6f7c(Matrix4x4 cc0e70b98e82c36e75858fbe588929e5c)
	{
		if (mEntityPlay == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		EntityWeapon entityWeapon = mEntityPlay.c3941dac8608f650ceb15dc36294a741c();
		if (entityWeapon == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		SkinnedMeshRenderer[] componentsInChildren = entityWeapon.GetComponentsInChildren<SkinnedMeshRenderer>();
		SkinnedMeshRenderer[] array = componentsInChildren;
		int num = 0;
		while (num < array.Length)
		{
			SkinnedMeshRenderer skinnedMeshRenderer = array[num];
			skinnedMeshRenderer.castShadows = false;
			Material[] materials = skinnedMeshRenderer.materials;
			foreach (Material material in materials)
			{
				material.SetMatrix("_ProjMat", cc0e70b98e82c36e75858fbe588929e5c);
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				if (skinnedMeshRenderer.material != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					skinnedMeshRenderer.material.SetMatrix("_ProjMat", cc0e70b98e82c36e75858fbe588929e5c);
				}
				num++;
				break;
			}
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			Transform transform = mEntityPlay.cdc80718389782f689e37bd44dbe7ee66();
			if (transform == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			Renderer component = transform.gameObject.GetComponent<SkinnedMeshRenderer>();
			if (!(component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (!(component.material != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					component.material.SetMatrix("_ProjMat", cc0e70b98e82c36e75858fbe588929e5c);
					return;
				}
			}
		}
	}

	private void ccc2c3fd4f0c5af9f6e3e9a145419a4c1()
	{
		if (mCurStatUpdateTime < mGrayTime)
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
					mDeathEffect.saturation -= mGrayModifyPerSecond * Time.fixedDeltaTime;
					return;
				}
			}
		}
		c376af7173dc43f9752ffb6324d8f4967();
	}

	private void c05850b0789e310842d0920b7c6e1f056()
	{
		if (mParticleCam != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			c0573d502c257d8fa66c4c80d40310328();
		}
		if (mCurStatUpdateTime < mBlurBlackTime)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
				{
					float num = mModifySceneFovPerSec * Time.fixedDeltaTime;
					if (m_camera.fieldOfView < mMaxSceneFov)
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
						m_camera.fieldOfView += num;
					}
					WeaponCameraControl componentInChildren = mEntityPlay.GetComponentInChildren<WeaponCameraControl>();
					componentInChildren.c26e0cf146dbd64d5e4f1d6aff5db6cb0().fieldOfView -= num * mFpFovSpeedCurve.Evaluate(mCurStatUpdateTime);
					if (componentInChildren.c26e0cf146dbd64d5e4f1d6aff5db6cb0().fieldOfView > mMinFpFpv)
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
						componentInChildren.cadd19e77c13c8635640e3b9931b64a0e();
						c2be08896f8f70a1ce40974c7d0ff6f7c(componentInChildren.cd392a2edecfcb3ad1e1ec6bcd9e0afde());
					}
					mDeathEffect.lumOffset = mChangeToBlackCurve.Evaluate(mCurStatUpdateTime);
					return;
				}
				}
			}
		}
		m_camera.fieldOfView = mOriginFov;
	}

	private void c248e3b853dc06c5199795843f5f4712b()
	{
		cd9e3d044531cc08120cd294b51bba496(DEATH_STAT.STAT_GRAY);
		mDeathEffect.statIndex = 0;
		mDeathEffect.saturation = 1f;
	}

	private void c376af7173dc43f9752ffb6324d8f4967()
	{
		cd9e3d044531cc08120cd294b51bba496(DEATH_STAT.STAT_BLUR_BLACK);
		mDeathEffect.statIndex = 1;
		mDeathEffect.blurAmount = mBlurAmout;
		mDeathEffect.extraBlur = mExtraBlur;
		mDeathEffect.lumOffset = 1f;
	}

	private void cd87bac4ec51f7543103fb86d16f35cae()
	{
		mDeathEffect.BroadcastMessage("TriggerEffectByName", "DeathParticle", SendMessageOptions.DontRequireReceiver);
		needPlayParticle = false;
	}

	private void cd9e3d044531cc08120cd294b51bba496(DEATH_STAT c4e41b35a620fe7e6c4bf371c4482f62a)
	{
		mCurStat = c4e41b35a620fe7e6c4bf371c4482f62a;
		mCurStatUpdateTime = 0f;
	}
}
