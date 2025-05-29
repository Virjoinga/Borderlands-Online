using System.Collections.Generic;
using A;
using Core;
using UnityEngine;

public class CameraEffectMgr
{
	private GameObject mFpsCamera;

	private PostEffectsBase[] imageEffectArray;

	private DistortionImageEffect distoryEffect;

	private DepthOfFieldScatter mUiDepthOfField;

	private List<PostEffectsBase> mCurPostEffect;

	public void c9b75e0c1c51390d2a4e1da0f0555fe93(Camera c7232c5b54bf2c06955e12fba4f07459c, bool cc2a4a02a728c83b472006c5fc196fded)
	{
		if (!cc2a4a02a728c83b472006c5fc196fded)
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
			mCurPostEffect.Clear();
			imageEffectArray = c7232c5b54bf2c06955e12fba4f07459c.GetComponents<PostEffectsBase>();
			if (imageEffectArray != null)
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
				for (int i = 0; i < imageEffectArray.Length; i++)
				{
					PostEffectsBase postEffectsBase = imageEffectArray[i];
					if (!postEffectsBase.enabled)
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
					postEffectsBase.enabled = false;
					mCurPostEffect.Add(postEffectsBase);
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
		}
		else
		{
			for (int j = 0; j < mCurPostEffect.Count; j++)
			{
				PostEffectsBase postEffectsBase2 = mCurPostEffect[j];
				postEffectsBase2.enabled = true;
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
		distoryEffect = c7232c5b54bf2c06955e12fba4f07459c.GetComponent<DistortionImageEffect>();
		if (!(distoryEffect != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			distoryEffect.enabled = cc2a4a02a728c83b472006c5fc196fded;
			return;
		}
	}

	public void c6355182065dc8b6a75012f75feefaa76()
	{
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			ImageEffectBase[] components = mFpsCamera.GetComponents<ImageEffectBase>();
			if (components != null)
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
				for (int i = 0; i < components.Length; i++)
				{
					Object.DestroyImmediate(components[i]);
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
			PostEffectsBase[] components2 = mFpsCamera.GetComponents<PostEffectsBase>();
			if (components2 != null)
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
				for (int j = 0; j < components2.Length; j++)
				{
					Object.DestroyImmediate(components2[j]);
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
			SSAOEffect component = mFpsCamera.GetComponent<SSAOEffect>();
			if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				Object.DestroyImmediate(component);
			}
			c25075cfed962291f0d0b630ce9ee8669();
			return;
		}
	}

	private void ca7e69b5f93272de76355c8122320e78f()
	{
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnlineHostMinResMode)
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
					return;
				}
			}
		}
		Camera component = mFpsCamera.GetComponent<Camera>();
		component.farClipPlane = c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_farClip;
		int num = 21102592;
		component.cullingMask &= ~num;
		if (mFpsCamera.GetComponent<DistrotionLogic>() == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			mFpsCamera.AddComponent<DistrotionLogic>();
		}
		if (!(mFpsCamera.GetComponent<DistortionImageEffect>() == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			DistortionImageEffect distortionImageEffect = mFpsCamera.AddComponent<DistortionImageEffect>();
			distortionImageEffect.shader = Shader.Find("TKC/Distortion/Apply");
			return;
		}
	}

	public void c62d6e942d709562f158104952dad345a(GameObject cf81f226b3aad521e84068ebbdd3b3125)
	{
		mFpsCamera = cf81f226b3aad521e84068ebbdd3b3125;
	}

	public void c25075cfed962291f0d0b630ce9ee8669()
	{
		ca7e69b5f93272de76355c8122320e78f();
		mCurPostEffect = new List<PostEffectsBase>();
		string text = c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c4420eafaa55a37f84d3775eed102e985();
		string path = "CameraEffect/" + text;
		GameObject c7088de59e49f7108f520cf7e0bae167e = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
		GameObject c7088de59e49f7108f520cf7e0bae167e2 = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
		c7088de59e49f7108f520cf7e0bae167e2 = Resources.Load(path) as GameObject;
		if (c7088de59e49f7108f520cf7e0bae167e2 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Graphics, "Can't get the effectCamera base the level name : " + text + ". Use the default camera effect");
			c7088de59e49f7108f520cf7e0bae167e2 = Resources.Load("EffectCamera_out") as GameObject;
		}
		c7088de59e49f7108f520cf7e0bae167e = Object.Instantiate(c7088de59e49f7108f520cf7e0bae167e2) as GameObject;
		if ((bool)c7088de59e49f7108f520cf7e0bae167e)
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
				ComponentHelper.c0bd715794203aecb6153c35217fbf4f4(c7088de59e49f7108f520cf7e0bae167e, mFpsCamera);
				c06ca0e618478c23eba3419653a19760f<QualityManager>.c5ee19dc8d4cccf5ae2de225410458b86.c26a93f072a5ab78f3cb70fabef1ce607(mFpsCamera);
				DepthOfFieldScatter component = mFpsCamera.GetComponent<DepthOfFieldScatter>();
				if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					if (component.useGPUFocalDistance)
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
						component.enabled = false;
					}
					else
					{
						Object.DestroyImmediate(component);
					}
				}
				Object.DestroyImmediate(c7088de59e49f7108f520cf7e0bae167e);
			}
		}
		else
		{
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Graphics, "*****LevelEffectCamera missing!");
		}
		DepthOfFieldScatter component2 = (Resources.Load("Graphics/GraphicsData") as GameObject).GetComponent<DepthOfFieldScatter>();
		if (!component2)
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
			mUiDepthOfField = mFpsCamera.AddComponent<DepthOfFieldScatter>();
			ComponentHelper.c0bd715794203aecb6153c35217fbf4f4(component2, mUiDepthOfField);
			mUiDepthOfField.enabled = false;
			return;
		}
	}

	public void cbdb542073b311fc24f36e1573abfa7d6(bool c87b995380f7a20665c44dc0d85627df1)
	{
		if (mUiDepthOfField != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			mUiDepthOfField.enabled = !c87b995380f7a20665c44dc0d85627df1;
		}
		if (!(mUiDepthOfField != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (!c87b995380f7a20665c44dc0d85627df1)
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
				for (int i = 0; i < mCurPostEffect.Count; i++)
				{
					if (!(mUiDepthOfField == mCurPostEffect[i]))
					{
						continue;
					}
					while (true)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						mCurPostEffect.Remove(mCurPostEffect[i]);
						return;
					}
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

	public void cf91ae5249669b02f125e35baedef33f7(bool c201e69461401637f68794a86ca99b782)
	{
		if (!mFpsCamera)
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
			DepthOfFieldScatter component = mFpsCamera.GetComponent<DepthOfFieldScatter>();
			if (!component)
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
				if (!component.useGPUFocalDistance)
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
					component.enabled = c201e69461401637f68794a86ca99b782;
					return;
				}
			}
		}
	}

	public void cf68970c6c22b47cab1e243e1f94b8034(float c3fb93291523bffd171607f86ba16cab8)
	{
		if (!mFpsCamera)
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
			DepthOfFieldScatter component = mFpsCamera.GetComponent<DepthOfFieldScatter>();
			if (!component)
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
				if (!component.enabled)
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
					component.aperture = c3fb93291523bffd171607f86ba16cab8;
					return;
				}
			}
		}
	}

	public void c63c2b1e7db4971298084f26ce7561cbb(float c554df7716192c4ab31a2d7edc3a238f1)
	{
		if (!mFpsCamera)
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
			DepthOfFieldScatter component = mFpsCamera.GetComponent<DepthOfFieldScatter>();
			if (!component)
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
				if (!component.enabled)
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
					component.focalLength = c554df7716192c4ab31a2d7edc3a238f1;
					return;
				}
			}
		}
	}
}
