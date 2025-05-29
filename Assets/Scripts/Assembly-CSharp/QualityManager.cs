using System;
using System.Collections.Generic;
using System.IO;
using A;
using UnityEngine;

public class QualityManager : c06ca0e618478c23eba3419653a19760f<QualityManager>
{
	public enum SceneShadowSetting
	{
		SceneSetting = 0,
		NoShadows = 1,
		HardShadows = 2,
		SoftShadows = 3
	}

	public enum QualityLevel
	{
		QualityLevel_Low = 0,
		QualityLevel_Medium = 1,
		QualityLevel_High = 2,
		QualityLevel_Count = 3
	}

	private Camera mCamera;

	private List<LightShadows> lightShadows;

	private List<Light> mLights;

	private SceneShadowSetting mShadowSetting;

	private QualityLevel m_qualityLevel;

	public QualityManager()
	{
		lightShadows = new List<LightShadows>();
		mLights = new List<Light>();
		ce68d01749ff82dd08e4ee20912bef7ae();
	}

	public void cbeb6a55e2651386be919902924c130f7()
	{
		lightShadows.Clear();
		mLights.Clear();
		Light[] array = (Light[])UnityEngine.Object.FindObjectsOfType(Type.GetTypeFromHandle(c0c058c8584be4aeef61671b581e3f0c3.cc1720d05c75832f704b87474932341c3()));
		for (int i = 0; i < array.Length; i++)
		{
			lightShadows.Add(array[i].shadows);
			mLights.Add(array[i]);
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
			mShadowSetting = SceneShadowSetting.SceneSetting;
			return;
		}
	}

	private bool c7a010ed4236015f5ee1162a8f36cf290()
	{
		if (mCamera != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return true;
				}
			}
		}
		Camera[] allCameras = Camera.allCameras;
		foreach (Camera camera in allCameras)
		{
			if (!(camera.name == "FpsCamera(Clone)"))
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
				mCamera = camera;
				return true;
			}
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			return false;
		}
	}

	public RenderingPath c5afa0429920a230a9db976b039fb58a9()
	{
		if (c7a010ed4236015f5ee1162a8f36cf290())
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return mCamera.actualRenderingPath;
				}
			}
		}
		return RenderingPath.UsePlayerSettings;
	}

	public void ca664c9d76c077b514c04d3a5d56e7a44(RenderingPath cbaf2313d6fc31deb6b32c254941c6928)
	{
		if (!c7a010ed4236015f5ee1162a8f36cf290())
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
			mCamera.renderingPath = cbaf2313d6fc31deb6b32c254941c6928;
			return;
		}
	}

	public int cd00586576d3c68b48c527e9f287aecc2()
	{
		if (c7a010ed4236015f5ee1162a8f36cf290())
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return mCamera.GetComponents<MonoBehaviour>().Length;
				}
			}
		}
		return 0;
	}

	public string c49d098cb59d3fa080352749724ab98af(int c5612a459a84ffdb41c885401433cd62d)
	{
		if (c5612a459a84ffdb41c885401433cd62d > cd00586576d3c68b48c527e9f287aecc2() - 1)
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
					return string.Empty;
				}
			}
		}
		string text = mCamera.GetComponents<MonoBehaviour>()[c5612a459a84ffdb41c885401433cd62d].ToString();
		int num = text.LastIndexOf('(');
		int num2 = text.LastIndexOf(')');
		return text.Substring(num + 1, num2 - num - 1);
	}

	public bool cfca8b749d32c6441259f7cd54044d4ed(int c5612a459a84ffdb41c885401433cd62d)
	{
		if (c5612a459a84ffdb41c885401433cd62d > cd00586576d3c68b48c527e9f287aecc2() - 1)
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
					return false;
				}
			}
		}
		return mCamera.GetComponents<MonoBehaviour>()[c5612a459a84ffdb41c885401433cd62d].enabled;
	}

	public void c665dbda2874eba09e0440d02798b1e02(int c5612a459a84ffdb41c885401433cd62d)
	{
		if (c5612a459a84ffdb41c885401433cd62d > cd00586576d3c68b48c527e9f287aecc2() - 1)
		{
			while (true)
			{
				switch (6)
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
		MonoBehaviour monoBehaviour = mCamera.GetComponents<MonoBehaviour>()[c5612a459a84ffdb41c885401433cd62d];
		monoBehaviour.enabled = !monoBehaviour.enabled;
	}

	public void c4dfaa7e10c127c98f9189d0442618be5(bool c920ec89e005050fc25d0cfe7686e61bc)
	{
		for (int i = 0; i < cd00586576d3c68b48c527e9f287aecc2(); i++)
		{
			MonoBehaviour monoBehaviour = mCamera.GetComponents<MonoBehaviour>()[i];
			monoBehaviour.enabled = c920ec89e005050fc25d0cfe7686e61bc;
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
			return;
		}
	}

	public int c1ffc79b914762422f09c7d15cd5e14ca()
	{
		return QualitySettings.antiAliasing;
	}

	public void ce701b3dc51667c1b93cba04cf2a24070(int cabad90baef0a56b68c71c45a23daf7fb)
	{
		QualitySettings.antiAliasing = cabad90baef0a56b68c71c45a23daf7fb;
	}

	public int c1554ea0e6a8d79bab924aa312ea3e7a8()
	{
		return QualitySettings.pixelLightCount;
	}

	public void c7372a827b4de10900c7ad7d12c24d28d()
	{
		QualitySettings.pixelLightCount++;
	}

	public void c735cb54c294dde23dfc7650759b64c06()
	{
		if (QualitySettings.pixelLightCount <= 0)
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
			QualitySettings.pixelLightCount--;
			return;
		}
	}

	public AnisotropicFiltering c322df46f24db29dc1575b3ef055b2b67()
	{
		return QualitySettings.anisotropicFiltering;
	}

	public void c4a5f94abcf557ba9b7c7453c5f1bb362(AnisotropicFiltering c4eed957bd1c063760a12d25c0d16e711)
	{
		QualitySettings.anisotropicFiltering = c4eed957bd1c063760a12d25c0d16e711;
	}

	public int c4ffa97ed1ffc4f33c5c8f0cb947ec011()
	{
		return QualitySettings.masterTextureLimit;
	}

	public void c660135df7f57242660d9a6ce62f39803()
	{
		if (QualitySettings.masterTextureLimit <= 0)
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
			QualitySettings.masterTextureLimit--;
			return;
		}
	}

	public void cd20f277718dd99e0e518a759c69e7c74()
	{
		if (QualitySettings.masterTextureLimit >= 3)
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
			QualitySettings.masterTextureLimit++;
			return;
		}
	}

	public bool c536afbd0ef836174ab9904f844a1a8af()
	{
		return QualitySettings.softVegetation;
	}

	public void c9dbf39fde6573d4623ba59a64a127996(bool c7012333eca6b837775bc288cc43ca1c4)
	{
		QualitySettings.softVegetation = !QualitySettings.softVegetation;
	}

	public void cd313b58ae7cfac77f5961cb404a5d4f4()
	{
		for (int i = 0; i < mLights.Count; i++)
		{
			mLights[i].shadows = lightShadows[i];
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
			mShadowSetting = SceneShadowSetting.SceneSetting;
			return;
		}
	}

	public void cccbfc61b4118931c7d67e2f466450d4b(LightShadows c76220937753c77ce96a74f5b5b1c0df4)
	{
		Light[] array = (Light[])UnityEngine.Object.FindObjectsOfType(Type.GetTypeFromHandle(c0c058c8584be4aeef61671b581e3f0c3.cc1720d05c75832f704b87474932341c3()));
		for (int i = 0; i < array.Length; i++)
		{
			array[i].shadows = c76220937753c77ce96a74f5b5b1c0df4;
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
			if (c76220937753c77ce96a74f5b5b1c0df4 == LightShadows.None)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						mShadowSetting = SceneShadowSetting.NoShadows;
						return;
					}
				}
			}
			if (c76220937753c77ce96a74f5b5b1c0df4 == LightShadows.Hard)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						mShadowSetting = SceneShadowSetting.HardShadows;
						return;
					}
				}
			}
			if (c76220937753c77ce96a74f5b5b1c0df4 != LightShadows.Soft)
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
				mShadowSetting = SceneShadowSetting.SoftShadows;
				return;
			}
		}
	}

	public SceneShadowSetting cabed3a8aa120dae1871d9d1ff1c395cf()
	{
		return mShadowSetting;
	}

	public ShadowProjection c991b5ee64a656f7d83db4af7b75a22ff()
	{
		return QualitySettings.shadowProjection;
	}

	public void c010d53884a7147a6bf722347f4b02862(ShadowProjection ca998e0e032b8dcda193aede7c89b6c24)
	{
		QualitySettings.shadowProjection = ca998e0e032b8dcda193aede7c89b6c24;
	}

	public int cb5aed818e28cc014c07738de4a0637ad()
	{
		return QualitySettings.shadowCascades;
	}

	public void ce6c6f229f43944e0f22d402aedf09b10(int ca7c54739a9ef80b2d3a48cd5bbaa3ef0)
	{
		if (ca7c54739a9ef80b2d3a48cd5bbaa3ef0 != 1)
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
			if (ca7c54739a9ef80b2d3a48cd5bbaa3ef0 != 2)
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
				if (ca7c54739a9ef80b2d3a48cd5bbaa3ef0 != 4)
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
					break;
				}
			}
		}
		QualitySettings.shadowCascades = ca7c54739a9ef80b2d3a48cd5bbaa3ef0;
	}

	public float ce1f891c7e3bfbe0fa861582b076b9297()
	{
		return QualitySettings.shadowDistance;
	}

	public void cdee2048e3184a9293b9434cd51593ad1()
	{
		QualitySettings.shadowDistance += 5f;
	}

	public void ce47be2be5506182f5a36b2a8812472c4()
	{
		if (!(QualitySettings.shadowDistance - 5f >= 0f))
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
			QualitySettings.shadowDistance -= 5f;
			return;
		}
	}

	public BlendWeights cf746f3c28ea45973b21ffe2d29d27f7b()
	{
		return QualitySettings.blendWeights;
	}

	public void cfa6ad78284ae1e7c4eb27d6611a2df07(BlendWeights cde66a0757689e69d39f1025dc212a44e)
	{
		QualitySettings.blendWeights = cde66a0757689e69d39f1025dc212a44e;
	}

	public int c8bb53d11232ba85a469c853b006cbd85()
	{
		return QualitySettings.vSyncCount;
	}

	public void c5eb990c13af0ffe6de35f8552c709c94(int c818e3c5b1df0f3cfc0d973a56c746c84)
	{
		if (c818e3c5b1df0f3cfc0d973a56c746c84 != 0)
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
			if (c818e3c5b1df0f3cfc0d973a56c746c84 != 1)
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
				if (c818e3c5b1df0f3cfc0d973a56c746c84 != 2)
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
					break;
				}
			}
		}
		QualitySettings.vSyncCount = c818e3c5b1df0f3cfc0d973a56c746c84;
	}

	public float c85b3f427df6c85171facf3b5788bbb32()
	{
		return QualitySettings.lodBias;
	}

	public void cc6071acd91c6c6fd3b387921dbcdc050()
	{
		QualitySettings.lodBias += 0.1f;
	}

	public void c16735fc33d05cb1cfc0760deeca30e14()
	{
		if (!(QualitySettings.lodBias - 0.1f >= 0f))
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
			QualitySettings.lodBias -= 0.1f;
			return;
		}
	}

	public int c3b145584e7b213421dd975874cd9062b()
	{
		return QualitySettings.maximumLODLevel;
	}

	public void cfdf380c436d9908237a565be437439d2(int cd6bb591c33b2ee3ab93e98aa43a6da63)
	{
		if (cd6bb591c33b2ee3ab93e98aa43a6da63 != 0)
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
			if (cd6bb591c33b2ee3ab93e98aa43a6da63 != 1)
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
				if (cd6bb591c33b2ee3ab93e98aa43a6da63 != 2)
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
					break;
				}
			}
		}
		QualitySettings.maximumLODLevel = cd6bb591c33b2ee3ab93e98aa43a6da63;
	}

	private void ce68d01749ff82dd08e4ee20912bef7ae()
	{
		TextAsset textAsset = Resources.Load("Quality/BaseCompat", Type.GetTypeFromHandle(cda4706963b5b94cc26d866126dd86f9c.cc1720d05c75832f704b87474932341c3())) as TextAsset;
		if (textAsset != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			StringReader stringReader = new StringReader(textAsset.text);
			string text = "[AppCompatGPU-0x" + SystemInfo.graphicsDeviceVendorID.ToString("X4") + "]";
			List<string> list = new List<string>();
			for (string text2 = stringReader.ReadLine(); text2 != null; text2 = stringReader.ReadLine())
			{
				list.Add(text2);
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
			int num = -1;
			int num2 = 0;
			while (true)
			{
				if (num2 < list.Count)
				{
					if (text == list[num2])
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
						num = num2;
						break;
					}
					num2++;
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
				break;
			}
			bool flag = false;
			if (num != -1)
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
				list.RemoveRange(0, num);
				int num3 = -1;
				for (int i = 1; i < list.Count; i++)
				{
					if (!list[i].StartsWith("[AppCompatGPU"))
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
					num3 = i;
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
				if (num3 != -1)
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
					list.RemoveRange(num3, list.Count - num3);
				}
				string value = "0x" + SystemInfo.graphicsDeviceID.ToString("X4");
				for (int j = 0; j < list.Count; j++)
				{
					if (!list[j].StartsWith(value))
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
					int num4 = list[j].IndexOf('=');
					int num5 = list[j].IndexOf(',');
					string s = list[j].Substring(num4 + 1, num5 - num4 - 1);
					flag = true;
					int num6 = int.Parse(s);
					if (num6 < 2)
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
						QualitySettings.SetQualityLevel(0);
					}
					else if (num6 < 4)
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
						QualitySettings.SetQualityLevel(1);
					}
					else
					{
						QualitySettings.SetQualityLevel(2);
					}
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
			}
			if (!flag)
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
				c6464a6d9c10a539b8997149e2f292a68();
			}
		}
		m_qualityLevel = (QualityLevel)QualitySettings.GetQualityLevel();
	}

	private void c6464a6d9c10a539b8997149e2f292a68()
	{
		if (SystemInfo.graphicsShaderLevel >= 30)
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
			if (SystemInfo.graphicsMemorySize >= 256)
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
				if (SystemInfo.graphicsPixelFillrate >= 2000)
				{
					if (SystemInfo.graphicsDeviceVendorID == 32902)
					{
						while (true)
						{
							switch (5)
							{
							case 0:
								break;
							default:
								QualitySettings.SetQualityLevel(0);
								return;
							}
						}
					}
					if (SystemInfo.graphicsDeviceVendorID == 4098)
					{
						while (true)
						{
							switch (6)
							{
							case 0:
								break;
							default:
								if (SystemInfo.graphicsMemorySize > 512)
								{
									while (true)
									{
										switch (4)
										{
										case 0:
											break;
										default:
											QualitySettings.SetQualityLevel(2);
											return;
										}
									}
								}
								QualitySettings.SetQualityLevel(1);
								return;
							}
						}
					}
					if (SystemInfo.graphicsDeviceVendorID == 4318)
					{
						while (true)
						{
							switch (5)
							{
							case 0:
								break;
							default:
								if (SystemInfo.graphicsDeviceID > 4096)
								{
									while (true)
									{
										switch (6)
										{
										case 0:
											break;
										default:
											QualitySettings.SetQualityLevel(2);
											return;
										}
									}
								}
								if (SystemInfo.graphicsDeviceID < 1536)
								{
									while (true)
									{
										switch (5)
										{
										case 0:
											break;
										default:
											QualitySettings.SetQualityLevel(0);
											return;
										}
									}
								}
								QualitySettings.SetQualityLevel(1);
								return;
							}
						}
					}
					QualitySettings.SetQualityLevel(0);
					return;
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
			}
		}
		QualitySettings.SetQualityLevel(0);
	}

	private void c7d6a0dc8ad353c3990e852daf26a1c4e(GameObject c723a0a6c9898e2b852cd9f26e82b9ea4, bool c38daa1ecfc4be57f0bab6f15b4488ecc)
	{
		GlobalFog component = c723a0a6c9898e2b852cd9f26e82b9ea4.GetComponent<GlobalFog>();
		if (!(component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			component.enabled = c38daa1ecfc4be57f0bab6f15b4488ecc;
			return;
		}
	}

	private void c5b99e46dbbecdaf65468f9c4bf17525f(GameObject c723a0a6c9898e2b852cd9f26e82b9ea4, bool c38daa1ecfc4be57f0bab6f15b4488ecc)
	{
		SSAOEffect component = c723a0a6c9898e2b852cd9f26e82b9ea4.GetComponent<SSAOEffect>();
		if (!(component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			component.enabled = c38daa1ecfc4be57f0bab6f15b4488ecc;
			return;
		}
	}

	private void cff47c04c1cbfe13da188b8bc3a67cca6(GameObject c723a0a6c9898e2b852cd9f26e82b9ea4, bool c38daa1ecfc4be57f0bab6f15b4488ecc)
	{
		AntialiasingAsPostEffect component = c723a0a6c9898e2b852cd9f26e82b9ea4.GetComponent<AntialiasingAsPostEffect>();
		if (!(component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			component.enabled = c38daa1ecfc4be57f0bab6f15b4488ecc;
			return;
		}
	}

	public void c26a93f072a5ab78f3cb70fabef1ce607(GameObject c723a0a6c9898e2b852cd9f26e82b9ea4)
	{
		if (c723a0a6c9898e2b852cd9f26e82b9ea4 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (m_qualityLevel == QualityLevel.QualityLevel_High)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					c7d6a0dc8ad353c3990e852daf26a1c4e(c723a0a6c9898e2b852cd9f26e82b9ea4, true);
					c5b99e46dbbecdaf65468f9c4bf17525f(c723a0a6c9898e2b852cd9f26e82b9ea4, true);
					cff47c04c1cbfe13da188b8bc3a67cca6(c723a0a6c9898e2b852cd9f26e82b9ea4, true);
					return;
				}
			}
		}
		if (m_qualityLevel == QualityLevel.QualityLevel_Medium)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					c7d6a0dc8ad353c3990e852daf26a1c4e(c723a0a6c9898e2b852cd9f26e82b9ea4, true);
					c5b99e46dbbecdaf65468f9c4bf17525f(c723a0a6c9898e2b852cd9f26e82b9ea4, false);
					cff47c04c1cbfe13da188b8bc3a67cca6(c723a0a6c9898e2b852cd9f26e82b9ea4, false);
					return;
				}
			}
		}
		if (m_qualityLevel != 0)
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
			c7d6a0dc8ad353c3990e852daf26a1c4e(c723a0a6c9898e2b852cd9f26e82b9ea4, false);
			c5b99e46dbbecdaf65468f9c4bf17525f(c723a0a6c9898e2b852cd9f26e82b9ea4, false);
			cff47c04c1cbfe13da188b8bc3a67cca6(c723a0a6c9898e2b852cd9f26e82b9ea4, false);
			return;
		}
	}

	private void cefebc676a9f80388c88c7c89af0224e1(Camera cc5681de8b48bc9f26dbaad39bc1bdc88)
	{
		if (!(cc5681de8b48bc9f26dbaad39bc1bdc88 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			SSAOEffect component = cc5681de8b48bc9f26dbaad39bc1bdc88.GetComponent<SSAOEffect>();
			if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				component.enabled = !component.enabled;
			}
			BOL_Outline component2 = cc5681de8b48bc9f26dbaad39bc1bdc88.GetComponent<BOL_Outline>();
			if (component2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				component2.enabled = !component2.enabled;
			}
			DepthOfFieldScatter component3 = cc5681de8b48bc9f26dbaad39bc1bdc88.GetComponent<DepthOfFieldScatter>();
			if (component3 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				component3.enabled = !component3.enabled;
			}
			AntialiasingAsPostEffect component4 = cc5681de8b48bc9f26dbaad39bc1bdc88.GetComponent<AntialiasingAsPostEffect>();
			if (!(component4 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				component4.enabled = false;
				return;
			}
		}
	}

	public void cefebc676a9f80388c88c7c89af0224e1()
	{
		if (!(c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			PlayerInfoSync playerInfoSync = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56();
			if (!(playerInfoSync != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				Entity entity = playerInfoSync.c66b232dbebded7c7e9a89c1e8bd84689();
				if (!(entity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					Camera componentInChildren = entity.GetComponentInChildren<Camera>();
					cefebc676a9f80388c88c7c89af0224e1(componentInChildren);
					return;
				}
			}
		}
	}

	public bool cf9d53399cb00c37c50f9a1db72d52307()
	{
		if (c7a010ed4236015f5ee1162a8f36cf290())
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					AntialiasingAsPostEffect component = mCamera.GetComponent<AntialiasingAsPostEffect>();
					return component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e;
				}
				}
			}
		}
		return false;
	}

	public void c9067f22df4e4b51b240042cb51590fdc()
	{
		if (cf9d53399cb00c37c50f9a1db72d52307())
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
			if (!c7a010ed4236015f5ee1162a8f36cf290())
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
		}
		AntialiasingAsPostEffect antialiasingAsPostEffect = mCamera.gameObject.AddComponent<AntialiasingAsPostEffect>();
		antialiasingAsPostEffect.shaderFXAAII = Shader.Find("Hidden/FXAA II");
		antialiasingAsPostEffect.shaderFXAAIII = Shader.Find("Hidden/FXAA III (Console)");
		antialiasingAsPostEffect.shaderFXAAPreset2 = Shader.Find("Hidden/FXAA Preset 2");
		antialiasingAsPostEffect.shaderFXAAPreset3 = Shader.Find("Hidden/FXAA Preset 3");
		antialiasingAsPostEffect.nfaaShader = Shader.Find("Hidden/NFAA");
		antialiasingAsPostEffect.ssaaShader = Shader.Find("Hidden/SSAA");
		antialiasingAsPostEffect.dlaaShader = Shader.Find("Hidden/DLAA");
		if (!antialiasingAsPostEffect)
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
			antialiasingAsPostEffect.mode = AAMode.FXAA1PresetB;
			return;
		}
	}

	public AAMode c48cf306e27e4beffcd736a9b7c0147d6()
	{
		if (!cf9d53399cb00c37c50f9a1db72d52307())
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
					return AAMode.FXAA2;
				}
			}
		}
		AntialiasingAsPostEffect component = mCamera.GetComponent<AntialiasingAsPostEffect>();
		if ((bool)component)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					return component.mode;
				}
			}
		}
		return AAMode.FXAA2;
	}

	public void cf7a96d8ba3d4fbe06d6adf085f07eaa2(AAMode cde455e60ea7e347ce54dc40b476821a9)
	{
		if (!cf9d53399cb00c37c50f9a1db72d52307())
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
		AntialiasingAsPostEffect component = mCamera.GetComponent<AntialiasingAsPostEffect>();
		if (!component)
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
			component.mode = cde455e60ea7e347ce54dc40b476821a9;
			return;
		}
	}

	public QualityLevel c70c62640d14b3b0cafe640ed65a43d7c()
	{
		return m_qualityLevel;
	}

	public string c7bffcb7930ce8baaaa17db274905ba9b()
	{
		if (m_qualityLevel == QualityLevel.QualityLevel_Low)
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
					return "Low";
				}
			}
		}
		if (m_qualityLevel == QualityLevel.QualityLevel_Medium)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					return "Medium";
				}
			}
		}
		return "High";
	}

	public int c7d0007c10c2eebc5b81088e213ecd789()
	{
		return (int)m_qualityLevel;
	}

	public void c95509b3eae2b5a2f33e246dae08f3b95()
	{
		if (c7d0007c10c2eebc5b81088e213ecd789() + 1 >= 3)
		{
			while (true)
			{
				switch (5)
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
		m_qualityLevel++;
		QualitySettings.SetQualityLevel(c7d0007c10c2eebc5b81088e213ecd789());
	}

	public void cd17e57e7ada808c8bf53ef84572032ad()
	{
		if (c7d0007c10c2eebc5b81088e213ecd789() <= 0)
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
		m_qualityLevel--;
		QualitySettings.SetQualityLevel(c7d0007c10c2eebc5b81088e213ecd789());
	}
}
