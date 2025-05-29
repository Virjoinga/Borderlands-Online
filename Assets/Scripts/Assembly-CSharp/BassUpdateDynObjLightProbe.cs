using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using A;
using Core;
using UnityEngine;

public class BassUpdateDynObjLightProbe : MonoBehaviour
{
	public GameObject m_fpsCamera;

	public UnityEngine.Object m_testLevelName;

	private static float s_fSqrtPI = (float)Math.Sqrt(Math.PI);

	private static float s_fC0 = 1f / (2f * s_fSqrtPI);

	private static float s_fC1 = (float)Math.Sqrt(3.0) / (3f * s_fSqrtPI);

	private static float s_fC2 = (float)Math.Sqrt(15.0) / (8f * s_fSqrtPI);

	private static float s_fC3 = (float)Math.Sqrt(5.0) / (16f * s_fSqrtPI);

	private static float s_fC4 = 0.5f * s_fC2;

	private void Start()
	{
		if (!(m_testLevelName != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_farLightProCoeff != null)
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
				if (c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_nearLightProCoeff != null)
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
					string text = "LightProbe/" + m_testLevelName.name;
					string text2 = text + "/farlightProbes";
					string text3 = text + "/nearlightProbes";
					TextAsset textAsset = ResourcesLoader.c38aeacc59bd560b59403945ae7996d79(text2, Type.GetTypeFromHandle(cda4706963b5b94cc26d866126dd86f9c.cc1720d05c75832f704b87474932341c3())) as TextAsset;
					TextAsset textAsset2 = ResourcesLoader.c38aeacc59bd560b59403945ae7996d79(text3, Type.GetTypeFromHandle(cda4706963b5b94cc26d866126dd86f9c.cc1720d05c75832f704b87474932341c3())) as TextAsset;
					if (textAsset != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						if (textAsset2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
						{
							while (true)
							{
								switch (3)
								{
								case 0:
									break;
								default:
								{
									BinaryFormatter binaryFormatter = new BinaryFormatter();
									Stream stream = c051941cafcc989335d3382955d18e617.c7088de59e49f7108f520cf7e0bae167e;
									try
									{
										stream = new MemoryStream(textAsset.bytes);
										c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_farLightProCoeff = binaryFormatter.Deserialize(stream) as float[];
									}
									catch (Exception ex)
									{
										DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Graphics, ex.ToString());
										DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Graphics, "LinSH : Read " + text2 + " file error!");
									}
									finally
									{
										stream.Close();
										stream = c051941cafcc989335d3382955d18e617.c7088de59e49f7108f520cf7e0bae167e;
									}
									try
									{
										stream = new MemoryStream(textAsset2.bytes);
										c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_nearLightProCoeff = binaryFormatter.Deserialize(stream) as float[];
									}
									catch (Exception ex2)
									{
										DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Graphics, ex2.ToString());
										DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Graphics, "LinSH: Read " + text3 + " file error!");
									}
									finally
									{
										stream.Close();
										stream = c051941cafcc989335d3382955d18e617.c7088de59e49f7108f520cf7e0bae167e;
									}
									if (c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_farLightProCoeff != null)
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
										if (c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_nearLightProCoeff != null)
										{
											while (true)
											{
												switch (2)
												{
												case 0:
													break;
												default:
													if (c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_nearLightProCoeff.Length != c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_farLightProCoeff.Length)
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
														if (c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_nearLightProCoeff.Length != LightmapSettings.lightProbes.coefficients.Length)
														{
															while (true)
															{
																switch (4)
																{
																case 0:
																	break;
																default:
																	DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Graphics, "LinSH: light probe number is not match near/far/lightmapSetting!");
																	c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_nearLightProCoeff = (c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_farLightProCoeff = null);
																	return;
																}
															}
														}
													}
													c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_customLightProbes = UnityEngine.Object.Instantiate(LightmapSettings.lightProbes) as LightProbes;
													return;
												}
											}
										}
									}
									DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Graphics, "LinSH: Can't create the light probe instance");
									return;
								}
								}
							}
						}
					}
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Graphics, "Light Probe missing");
					return;
				}
			}
		}
	}

	private void OnWillRenderObject()
	{
		cd1c2ac58b4e5cfb3af72b00523636f20();
	}

	private void cd1c2ac58b4e5cfb3af72b00523636f20()
	{
		if (m_fpsCamera == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				PlayerInfoSync playerInfoSync = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56();
				if (playerInfoSync != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					Entity entity = playerInfoSync.c66b232dbebded7c7e9a89c1e8bd84689();
					if (entity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						Camera componentInChildren = entity.GetComponentInChildren<Camera>();
						if (componentInChildren != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							m_fpsCamera = componentInChildren.gameObject;
						}
					}
				}
			}
		}
		Renderer renderer = base.renderer;
		Material material = renderer.material;
		if (!(c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_customLightProbes != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_farLightProCoeff == null)
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
				if (c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_nearLightProCoeff == null)
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
					if (!material.HasProperty("_Tkc_SHAr"))
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
						if (!(m_fpsCamera != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
							Vector3 position = base.transform.position;
							Vector3 position2 = m_fpsCamera.transform.position;
							float num = Vector3.Distance(position, position2);
							float num2 = 0f;
							float shadowDistance = QualitySettings.shadowDistance;
							float num3 = 3f;
							float[] array = c45a99a14f737cada4caa361b45034f4d.c0a0cdf4a196914163f7334d9b0781a04(27);
							float num4 = shadowDistance + num3;
							if (num > num4)
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
								c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_customLightProbes.coefficients = c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_farLightProCoeff;
								num2 = 0f;
								c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_customLightProbes.GetInterpolatedLightProbe(position, renderer, array);
							}
							else if (num < shadowDistance)
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
								c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_customLightProbes.coefficients = c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_nearLightProCoeff;
								num2 = 1f;
								c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_customLightProbes.GetInterpolatedLightProbe(position, renderer, array);
							}
							else
							{
								float[] array2 = c45a99a14f737cada4caa361b45034f4d.c0a0cdf4a196914163f7334d9b0781a04(27);
								c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_customLightProbes.coefficients = c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_nearLightProCoeff;
								c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_customLightProbes.GetInterpolatedLightProbe(position, renderer, array2);
								float[] array3 = c45a99a14f737cada4caa361b45034f4d.c0a0cdf4a196914163f7334d9b0781a04(27);
								c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_customLightProbes.coefficients = c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_farLightProCoeff;
								c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_customLightProbes.GetInterpolatedLightProbe(position, renderer, array3);
								float num5 = (num4 - num) / num3;
								for (int i = 0; i < 27; i++)
								{
									array[i] = array2[i] * num5 + array3[i] * (1f - num5);
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
								num2 = 1f - num5;
							}
							float[][] array4 = cd95db4156b58f4e69611463e4ef580a6.c0a0cdf4a196914163f7334d9b0781a04(3);
							float[] array5 = c45a99a14f737cada4caa361b45034f4d.c0a0cdf4a196914163f7334d9b0781a04(9);
							array5[0] = array[0];
							array5[1] = array[3];
							array5[2] = array[6];
							array5[3] = array[9];
							array5[4] = array[12];
							array5[5] = array[15];
							array5[6] = array[18];
							array5[7] = array[21];
							array5[8] = array[24];
							array4[0] = array5;
							float[] array6 = c45a99a14f737cada4caa361b45034f4d.c0a0cdf4a196914163f7334d9b0781a04(9);
							array6[0] = array[1];
							array6[1] = array[4];
							array6[2] = array[7];
							array6[3] = array[10];
							array6[4] = array[13];
							array6[5] = array[16];
							array6[6] = array[19];
							array6[7] = array[22];
							array6[8] = array[25];
							array4[1] = array6;
							float[] array7 = c45a99a14f737cada4caa361b45034f4d.c0a0cdf4a196914163f7334d9b0781a04(9);
							array7[0] = array[2];
							array7[1] = array[5];
							array7[2] = array[8];
							array7[3] = array[11];
							array7[4] = array[14];
							array7[5] = array[17];
							array7[6] = array[20];
							array7[7] = array[23];
							array7[8] = array[26];
							array4[2] = array7;
							float[][] array8 = array4;
							Vector4[] array9 = c6b9b486e00bdfd9ee7ce0bac7f34a00e.c0a0cdf4a196914163f7334d9b0781a04(3);
							array9[0] = Vector4.zero;
							array9[1] = Vector4.zero;
							array9[2] = Vector4.zero;
							Vector4[] array10 = array9;
							Vector4[] array11 = c6b9b486e00bdfd9ee7ce0bac7f34a00e.c0a0cdf4a196914163f7334d9b0781a04(3);
							array11[0] = Vector4.zero;
							array11[1] = Vector4.zero;
							array11[2] = Vector4.zero;
							Vector4[] array12 = array11;
							for (int j = 0; j < 3; j++)
							{
								array10[j].x = (0f - s_fC1) * array8[j][3];
								array10[j].y = (0f - s_fC1) * array8[j][1];
								array10[j].z = s_fC1 * array8[j][2];
								array10[j].w = s_fC0 * array8[j][0] - s_fC3 * array8[j][6];
							}
							while (true)
							{
								switch (7)
								{
								case 0:
									continue;
								}
								for (int j = 0; j < 3; j++)
								{
									array12[j].x = s_fC2 * array8[j][4];
									array12[j].y = (0f - s_fC2) * array8[j][5];
									array12[j].z = 3f * s_fC3 * array8[j][6];
									array12[j].w = (0f - s_fC2) * array8[j][7];
								}
								while (true)
								{
									switch (5)
									{
									case 0:
										continue;
									}
									Vector4 zero = Vector4.zero;
									zero.x = s_fC4 * array8[0][8];
									zero.y = s_fC4 * array8[1][8];
									zero.z = s_fC4 * array8[2][8];
									zero.w = num2;
									material.SetVector("_Tkc_SHAr", array10[0]);
									material.SetVector("_Tkc_SHAg", array10[1]);
									material.SetVector("_Tkc_SHAb", array10[2]);
									material.SetVector("_Tkc_SHBr", array12[0]);
									material.SetVector("_Tkc_SHBg", array12[1]);
									material.SetVector("_Tkc_SHBb", array12[2]);
									material.SetVector("_Tkc_SHC", zero);
									material.SetColor("_AmbintLight", RenderSettings.ambientLight);
									return;
								}
							}
						}
					}
				}
			}
		}
	}
}
