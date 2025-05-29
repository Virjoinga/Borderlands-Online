using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using A;
using Core;
using UnityEngine;
using XsdSettings;
using pumpkin.swf;

public class LevelLoadingManager : c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>
{
	public class MapsDescXml
	{
		private static MapsDescXml s_instance;

		private XmlDocument m_xmlDoc;

		private XmlNode m_levelLoadingNode;

		public static MapsDescXml c5ee19dc8d4cccf5ae2de225410458b86
		{
			get
			{
				if (s_instance == null)
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
					s_instance = new MapsDescXml();
				}
				return s_instance;
			}
		}

		private MapsDescXml()
		{
			string text = "Maps/MapsDesc";
			TextAsset textAsset = ResourcesLoader.c38aeacc59bd560b59403945ae7996d79(text) as TextAsset;
			if (textAsset != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						m_xmlDoc = new XmlDocument();
						if (m_xmlDoc != null)
						{
							while (true)
							{
								switch (1)
								{
								case 0:
									break;
								default:
									m_xmlDoc.LoadXml(textAsset.text);
									return;
								}
							}
						}
						return;
					}
				}
			}
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Framework, "Could not load Map Desc:" + text);
		}

		public XmlDocument ce47cc86d7b19cb0ceb4b63bcfe8d210a()
		{
			return m_xmlDoc;
		}

		public XmlNode ca8e6f751bfbb2db1fb95fe72f802a524()
		{
			return m_levelLoadingNode;
		}

		public void c840d299b55e9d897960d96d3ffa2996b(string ca52db4ecb147839553b6d7ab8d5814ee)
		{
			XmlNodeList elementsByTagName = m_xmlDoc.GetElementsByTagName("Map");
			m_levelLoadingNode = c3a9e4cbb7b375022c4393aa381eeb15e.c7088de59e49f7108f520cf7e0bae167e;
			for (int i = 0; i < elementsByTagName.Count; i++)
			{
				if (!(elementsByTagName[i].Attributes["name"].Value.ToLower() == ca52db4ecb147839553b6d7ab8d5814ee.ToLower()))
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
					if (!c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_offlineMode)
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
					if (!(elementsByTagName[i].SelectSingleNode("AssetBundles/AssetBundle[@type='Map']/@map").Value.ToLower() == ca52db4ecb147839553b6d7ab8d5814ee.ToLower()))
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
						break;
					}
				}
				m_levelLoadingNode = elementsByTagName[i];
				return;
			}
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

	private class LevelLoadingStepController
	{
		private List<LevelLoadingStep> m_steps;

		private int m_curStep;

		public void c040ee5dc6011ac6f76e73d8f329ca070()
		{
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "Cancel Loading");
			m_curStep = m_steps.Count;
			using (Dictionary<string, BaseAssetBundle>.Enumerator enumerator = c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.c2db49eb57b860f27c56d506da7c57f6d.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					InGameAssetBundle inGameAssetBundle = (InGameAssetBundle)enumerator.Current.Value;
					if (inGameAssetBundle == null)
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
						break;
					}
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					inGameAssetBundle.c040ee5dc6011ac6f76e73d8f329ca070();
				}
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						goto end_IL_0076;
					}
					continue;
					end_IL_0076:
					break;
				}
			}
			c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.c2db49eb57b860f27c56d506da7c57f6d.Clear();
		}

		public bool c739bc996d272aeac228d6b5198b164d2()
		{
			return m_steps != c49c7402481b06bd866af1e0f8db69728.c7088de59e49f7108f520cf7e0bae167e;
		}

		public float c0a687459ceef442f37c4d398cb12f99f()
		{
			float num = 0f;
			if (m_steps != null)
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
				for (int i = 0; i < m_steps.Count; i++)
				{
					num += m_steps[i].m_weight * m_steps[i].m_loadingProgress;
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
			return num;
		}

		public string c8b70afb12d12e93983260684a70f87c7()
		{
			if (m_steps != null)
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
				if (m_curStep >= 0)
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
					if (m_curStep < m_steps.Count)
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								return m_steps[m_curStep].ToString();
							}
						}
					}
				}
			}
			return "Not Loading";
		}

		public void Start()
		{
			m_steps = new List<LevelLoadingStep>();
			m_steps.Add(new LevelLoadingStep_Init(0f));
			m_steps.Add(new LevelLoadingStep_DownloadAssetBundle(0.6f));
			m_steps.Add(new LevelLoadingStep_LoadPlayerAudio(0f));
			m_steps.Add(new LevelLoadingStep_PreLoadPlayerBuildingKit(0f));
			m_steps.Add(new LevelLoadingStep_LoadMapSetting(0f));
			m_steps.Add(new LevelLoadingStep_LoadResourceDependencyBundle(0.1f));
			m_steps.Add(new LevelLoadingStep_PreLoadNpcResources(0.05f));
			m_steps.Add(new LevelLoadingStep_PreLoadWeapon(0.05f));
			m_steps.Add(new LevelLoadingStep_SyncLocalPlayer(0f));
			m_steps.Add(new LevelLoadingStep_UI(0f));
			m_steps.Add(new LevelLoadingStep_LoadLevelBundle(0.05f));
			m_steps.Add(new LevelLoadingStep_LoadLevel(0.1f));
			m_steps.Add(new LevelLoadingStep_LoadLevelDataBundle(0.05f));
			m_steps.Add(new LevelLoadingStep_GenerateWeaponsData(0f));
			m_steps.Add(new LevelLoadingStep_EndLoading(0f));
			m_curStep = 0;
			if (m_curStep >= m_steps.Count)
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
				m_steps[m_curStep].c7d932c2f1a060d3f30f1ff4d7b85e54a();
				return;
			}
		}

		public void Update()
		{
			if (m_steps == null)
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
				if (m_curStep < m_steps.Count)
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							if (m_steps[m_curStep].c9384e0a8d465c2efe1d9876980016fe5())
							{
								while (true)
								{
									switch (7)
									{
									case 0:
										break;
									default:
										m_steps[m_curStep].cb6ca2e5e68d36a18810ef9f711e1c717();
										m_steps[m_curStep].m_loadingProgress = 1f;
										m_curStep++;
										if (m_curStep < m_steps.Count)
										{
											while (true)
											{
												switch (6)
												{
												case 0:
													break;
												default:
													m_steps[m_curStep].c7d932c2f1a060d3f30f1ff4d7b85e54a();
													return;
												}
											}
										}
										return;
									}
								}
							}
							return;
						}
					}
				}
				m_steps = c49c7402481b06bd866af1e0f8db69728.c7088de59e49f7108f520cf7e0bae167e;
				return;
			}
		}
	}

	private abstract class LevelLoadingStep
	{
		public float m_weight;

		public float m_loadingProgress;

		public LevelLoadingStep(float cea8bc0ff9f39b928110f79da66ab6ab7)
		{
			m_weight = cea8bc0ff9f39b928110f79da66ab6ab7;
		}

		public abstract void c7d932c2f1a060d3f30f1ff4d7b85e54a();

		public abstract bool c9384e0a8d465c2efe1d9876980016fe5();

		public abstract void cb6ca2e5e68d36a18810ef9f711e1c717();

		protected List<string> c30b7927bc4bd2490364ede0e702c5807()
		{
			List<string> list = new List<string>(c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_assetBundleList.Count);
			for (int i = 0; i < c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_assetBundleList.Count; i++)
			{
				XmlAttribute xmlAttribute = c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_assetBundleList[i].Attributes["name"];
				XmlAttribute xmlAttribute2 = c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_assetBundleList[i].Attributes["type"];
				XmlAttribute xmlAttribute3 = c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_assetBundleList[i].Attributes["behaviour"];
				if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnlineHostMinResMode)
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
					if (xmlAttribute2.Value == "Map")
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
						list.Add("host_" + c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_assetBundleList[i].Attributes["name"].Value);
					}
					else
					{
						list.Add(c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_assetBundleList[i].Attributes["name"].Value);
					}
				}
				else
				{
					list.Add(c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_assetBundleList[i].Attributes["name"].Value);
				}
				if (xmlAttribute3 == null)
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
				if (!(xmlAttribute3.Value == "light_pillar"))
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
					break;
				}
				string item = xmlAttribute.Value.Replace(".assetbundle", "_cl.assetbundle");
				list.Add(item);
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				return list;
			}
		}
	}

	private class LevelLoadingStep_Init : LevelLoadingStep
	{
		private AsyncOperation m_async;

		public LevelLoadingStep_Init(float cea8bc0ff9f39b928110f79da66ab6ab7)
			: base(cea8bc0ff9f39b928110f79da66ab6ab7)
		{
		}

		public override void c7d932c2f1a060d3f30f1ff4d7b85e54a()
		{
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "LevelLoadingStep_Init.EnterStep [" + Time.time + "]");
			c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_startLoadingTime = Time.realtimeSinceStartup;
			MergedMeshManager.cbb095e7528094c5de72868b1811f5a4a();
			XmlNode previousLevel = c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_previousLevel;
			if (!c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnlineHostMinResMode)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (previousLevel != null)
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
					if (MapsDescXml.c5ee19dc8d4cccf5ae2de225410458b86.ca8e6f751bfbb2db1fb95fe72f802a524().SelectSingleNode("AssetBundles/AssetBundle[@type='Map']/@map").Value != previousLevel.SelectSingleNode("AssetBundles/AssetBundle[@type='Map']/@map").Value)
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
						List<string> list = new List<string>();
						XmlNodeList xmlNodeList = previousLevel.SelectNodes("NPCSetting/NPC/@value");
						for (int i = 0; i < xmlNodeList.Count; i++)
						{
							string value = xmlNodeList[i].Value;
							BuildingKitRender buildingKitRender = new BuildingKitRender("NPC", value);
							buildingKitRender.c090e54583724a369a50a88fc3eb5592a();
							list.AddRange(buildingKitRender.c0c98f9aa4067deab3caf8159826ae606());
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
				}
			}
			string text = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c9d8ee6a5af1e2ca6cb9e7b7a609a6d69();
			if (text != c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_previousInstance)
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
				VFXManager.ca1e80b7d8118ff175dca46b7f324d279();
				c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_previousInstance = text;
			}
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.c6738a99a1dd128185a2728e161db856b(true);
			m_async = Application.LoadLevelAsync("ResourcesLoading");
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().OnLevelLoadingStart();
			c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_assetBundleList = c28b90c18f91a8d49d865016b8fd4a7a2.c7088de59e49f7108f520cf7e0bae167e;
			c738d5a7846d67e3d23bc27c7ec8d34b7();
		}

		public override bool c9384e0a8d465c2efe1d9876980016fe5()
		{
			if (m_async.isDone)
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
						return true;
					}
				}
			}
			return false;
		}

		public override void cb6ca2e5e68d36a18810ef9f711e1c717()
		{
			if (c1ee7921b0c3cce194fb7cae41b5a9d82<ObjectiveManager>.c5ee19dc8d4cccf5ae2de225410458b86 == null)
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
			c1ee7921b0c3cce194fb7cae41b5a9d82<ObjectiveManager>.c5ee19dc8d4cccf5ae2de225410458b86.cac7688b05e921e2be3f92479ba44b4a8();
		}

		private void c738d5a7846d67e3d23bc27c7ec8d34b7()
		{
			string empty = string.Empty;
			if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnlineHostMinResMode)
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
				empty = "AssetBundles/AssetBundle[@type='Map' or @behaviour='light_pillar']";
			}
			else if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_offlineMode)
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
				empty = "AssetBundles/AssetBundle";
			}
			else
			{
				empty = "AssetBundles/AssetBundle";
			}
			c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_assetBundleList = MapsDescXml.c5ee19dc8d4cccf5ae2de225410458b86.ca8e6f751bfbb2db1fb95fe72f802a524().SelectNodes(empty);
		}
	}

	private class LevelLoadingStep_DownloadAssetBundle : LevelLoadingStep
	{
		private bool m_finish;

		private List<string> m_bundleList;

		public LevelLoadingStep_DownloadAssetBundle(float cea8bc0ff9f39b928110f79da66ab6ab7)
			: base(cea8bc0ff9f39b928110f79da66ab6ab7)
		{
		}

		public override void c7d932c2f1a060d3f30f1ff4d7b85e54a()
		{
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "LevelLoadingStep_DownloadAssetBundle.EnterStep [" + Time.time + "]");
			m_bundleList = c30b7927bc4bd2490364ede0e702c5807();
			c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.StartCoroutine(c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad618dcc0547ebee513a30332046d81f(m_bundleList, c6c5f4b57cf17cf49efa5aaab74a3405e, null, false, 1));
		}

		public override bool c9384e0a8d465c2efe1d9876980016fe5()
		{
			float num = 0f;
			float num2 = 0f;
			for (int i = 0; i < m_bundleList.Count; i++)
			{
				string ccc3a743cfeeaa8212871445f2d92eb9a = m_bundleList[i];
				float num3 = c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.c911b31a1a7387d3854cd33c617dd4b3f(ccc3a743cfeeaa8212871445f2d92eb9a);
				uint num4 = c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.c5c3c145d54edc727770887f87bea1217(ccc3a743cfeeaa8212871445f2d92eb9a);
				num += (float)num4;
				num2 += (float)num4 * num3;
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
				if (num == 0f)
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
					m_loadingProgress = 1f;
				}
				else
				{
					m_loadingProgress = num2 / num;
				}
				return m_finish;
			}
		}

		public override void cb6ca2e5e68d36a18810ef9f711e1c717()
		{
		}

		private void c6c5f4b57cf17cf49efa5aaab74a3405e(object cd22aa6735988e8e65acbd503f3870e3e = null)
		{
			m_finish = true;
		}
	}

	private class LevelLoadingStep_PreLoadPlayerBuildingKit : LevelLoadingStep
	{
		private bool m_finished;

		public LevelLoadingStep_PreLoadPlayerBuildingKit(float cea8bc0ff9f39b928110f79da66ab6ab7)
			: base(cea8bc0ff9f39b928110f79da66ab6ab7)
		{
		}

		public override void c7d932c2f1a060d3f30f1ff4d7b85e54a()
		{
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "LevelLoadingStep_PreLoadPlayerBuildingKit.EnterStep [" + Time.time + "]");
			List<string> list = new List<string>();
			BuildingKitRender buildingKitRender = new BuildingKitRender("CHR", "Siren");
			list.AddRange(buildingKitRender.ca8a5af6eb0b2329ae9c0880a0712d3b8());
			buildingKitRender = new BuildingKitRender("CHR", "Soldier");
			list.AddRange(buildingKitRender.ca8a5af6eb0b2329ae9c0880a0712d3b8());
			buildingKitRender = new BuildingKitRender("CHR", "Berserker");
			list.AddRange(buildingKitRender.ca8a5af6eb0b2329ae9c0880a0712d3b8());
			buildingKitRender = new BuildingKitRender("CHR", "Hunter");
			list.AddRange(buildingKitRender.ca8a5af6eb0b2329ae9c0880a0712d3b8());
			c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.StartCoroutine(c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad618dcc0547ebee513a30332046d81f(list, c1bc4a788e5709e3d6a09ab266b5e0695, list));
		}

		public override bool c9384e0a8d465c2efe1d9876980016fe5()
		{
			return m_finished;
		}

		public override void cb6ca2e5e68d36a18810ef9f711e1c717()
		{
		}

		private void c1bc4a788e5709e3d6a09ab266b5e0695(object cd22aa6735988e8e65acbd503f3870e3e)
		{
			List<string> c99e3d0b4ce51c8a7f689a835d475a34b = (List<string>)cd22aa6735988e8e65acbd503f3870e3e;
			BuildingKitRender buildingKitRender = new BuildingKitRender("CHR", "Siren");
			buildingKitRender.c5f562c5a8498db03688b38f3dcdf7faf();
			buildingKitRender = new BuildingKitRender("CHR", "Soldier");
			buildingKitRender.c5f562c5a8498db03688b38f3dcdf7faf();
			buildingKitRender = new BuildingKitRender("CHR", "Berserker");
			buildingKitRender.c5f562c5a8498db03688b38f3dcdf7faf();
			buildingKitRender = new BuildingKitRender("CHR", "Hunter");
			buildingKitRender.c5f562c5a8498db03688b38f3dcdf7faf();
			c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1c729e95f2ac60ec91fb0f073386b3cf(c99e3d0b4ce51c8a7f689a835d475a34b);
			m_finished = true;
		}
	}

	private class LevelLoadingStep_LoadPlayerAudio : LevelLoadingStep
	{
		private bool m_finish;

		public LevelLoadingStep_LoadPlayerAudio(float cea8bc0ff9f39b928110f79da66ab6ab7)
			: base(cea8bc0ff9f39b928110f79da66ab6ab7)
		{
		}

		public override void c7d932c2f1a060d3f30f1ff4d7b85e54a()
		{
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "LevelLoadingStep_LoadPlayerAudio.EnterStep [" + Time.time + "]");
			if (cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5def92cf2ece25f46fbe9356a28a245b)
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
				if (cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.c9f6a0386ce93c761939b8a4def1e3435.m_enableAssetbundle)
				{
					while (true)
					{
						switch (5)
						{
						case 0:
							break;
						default:
						{
							PlayerProperties playerProperties = c06ca0e618478c23eba3419653a19760f<PlayerManager>.c5ee19dc8d4cccf5ae2de225410458b86.ccc826da979542be7370386df94069f47();
							AvatarType c63132f2d3c0a9069ea15ea2b1105548a = playerProperties.m_avatarDna.c071244a19e2d9f70f4d2d6d38677162a();
							List<string> list;
							if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
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
								list = c1ee7921b0c3cce194fb7cae41b5a9d82<PlayerResourcesLoader>.c5ee19dc8d4cccf5ae2de225410458b86.c550863df1f9cadf29cfb256b0d29b0b7(c63132f2d3c0a9069ea15ea2b1105548a);
							}
							else
							{
								list = c1ee7921b0c3cce194fb7cae41b5a9d82<PlayerResourcesLoader>.c5ee19dc8d4cccf5ae2de225410458b86.ccdf641fee83157b3c6c8f22823c89292(c63132f2d3c0a9069ea15ea2b1105548a, ccd144ae7483ed93b767e14c99901f15c.c7088de59e49f7108f520cf7e0bae167e);
							}
							List<string> list2 = list;
							c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.StartCoroutine(c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad618dcc0547ebee513a30332046d81f(list2, c1bc4a788e5709e3d6a09ab266b5e0695, list2));
							return;
						}
						}
					}
				}
			}
			m_finish = true;
		}

		public override bool c9384e0a8d465c2efe1d9876980016fe5()
		{
			return m_finish;
		}

		public override void cb6ca2e5e68d36a18810ef9f711e1c717()
		{
		}

		private void c1bc4a788e5709e3d6a09ab266b5e0695(object cd22aa6735988e8e65acbd503f3870e3e)
		{
			List<string> list = (List<string>)cd22aa6735988e8e65acbd503f3870e3e;
			for (int i = 0; i < list.Count; i++)
			{
				string text = list[i];
				BaseAssetBundle baseAssetBundle = c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.cc287004e3f873904ffcdfe194323b23f(text);
				if (baseAssetBundle == null)
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
				UnityEngine.Object[] array = baseAssetBundle.c6a2c96c95dbb6d94ab759d22726b0440();
				if (array != null)
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
					cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.c9f6a0386ce93c761939b8a4def1e3435.c8a3e20cbb1a0f01c8d52d7bfc64bfd44(text, array);
				}
				else
				{
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Audio, "Can't Load Bundle Content For " + text);
				}
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				m_finish = true;
				return;
			}
		}
	}

	private class LevelLoadingStep_LoadMapSetting : LevelLoadingStep
	{
		public LevelLoadingStep_LoadMapSetting(float cea8bc0ff9f39b928110f79da66ab6ab7)
			: base(cea8bc0ff9f39b928110f79da66ab6ab7)
		{
		}

		public override void c7d932c2f1a060d3f30f1ff4d7b85e54a()
		{
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "LevelLoadingStep_LoadMapSetting.EnterStep [" + Time.time + "]");
			XmlNode xmlNode = MapsDescXml.c5ee19dc8d4cccf5ae2de225410458b86.ca8e6f751bfbb2db1fb95fe72f802a524().SelectSingleNode("MapSetting/CameraSetting/FarClip/@value");
			if (xmlNode != null)
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
				float.TryParse(xmlNode.Value, out c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_farClip);
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "MapSetting->CameraSetting->FarClip: " + c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_farClip);
			}
			XmlNode xmlNode2 = MapsDescXml.c5ee19dc8d4cccf5ae2de225410458b86.ca8e6f751bfbb2db1fb95fe72f802a524().SelectSingleNode("MapSetting/CameraSetting/CameraEffect/@value");
			if (xmlNode2 == null)
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
				c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_cameraEffect = xmlNode2.Value;
				return;
			}
		}

		public override bool c9384e0a8d465c2efe1d9876980016fe5()
		{
			return true;
		}

		public override void cb6ca2e5e68d36a18810ef9f711e1c717()
		{
		}
	}

	private class LevelLoadingStep_LoadResourceDependencyBundle : LevelLoadingStep
	{
		public LevelLoadingStep_LoadResourceDependencyBundle(float cea8bc0ff9f39b928110f79da66ab6ab7)
			: base(cea8bc0ff9f39b928110f79da66ab6ab7)
		{
		}

		public override void c7d932c2f1a060d3f30f1ff4d7b85e54a()
		{
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "LevelLoadingStep_LoadResourceDependencyBundle.EnterStep [" + Time.time + "]");
			for (int i = 0; i < c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_assetBundleList.Count; i++)
			{
				XmlAttribute xmlAttribute = c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_assetBundleList[i].Attributes["type"];
				if (xmlAttribute == null)
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
					break;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (!(xmlAttribute.Value == "ResourceDependency"))
				{
					continue;
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
				BaseAssetBundle c55644b999838f2d90a4ea87f98774f = c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.cc287004e3f873904ffcdfe194323b23f(c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_assetBundleList[i].Attributes["name"].Value);
				c5bf960f59155c91ae528d821e44784ac(c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_assetBundleList[i], c55644b999838f2d90a4ea87f98774f);
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

		public override bool c9384e0a8d465c2efe1d9876980016fe5()
		{
			return true;
		}

		public override void cb6ca2e5e68d36a18810ef9f711e1c717()
		{
		}

		private void c5bf960f59155c91ae528d821e44784ac(XmlNode cab83bba925e6355b7d0df9fe7c31c6e1, BaseAssetBundle c55644b999838f2d90a4ea87f98774f18)
		{
			switch (cab83bba925e6355b7d0df9fe7c31c6e1.Attributes["behaviour"].Value)
			{
			default:
				return;
			case "shared":
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
					string value2 = cab83bba925e6355b7d0df9fe7c31c6e1.Attributes["name"].Value;
					UnityEngine.Object[] array2 = c55644b999838f2d90a4ea87f98774f18.c6a2c96c95dbb6d94ab759d22726b0440();
					if (array2 != null)
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
						if (array2.Length != 0)
						{
							c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.cbfe45335bcb72146fc37f1b8c3950206(c55644b999838f2d90a4ea87f98774f18, "OutputBuildNumber for " + value2);
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Framework, "Fail to load " + value2);
					return;
				}
			case "audio":
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					string value = cab83bba925e6355b7d0df9fe7c31c6e1.Attributes["name"].Value;
					UnityEngine.Object[] array = c55644b999838f2d90a4ea87f98774f18.c6a2c96c95dbb6d94ab759d22726b0440();
					if (array == null)
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
					if (!cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5def92cf2ece25f46fbe9356a28a245b)
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
						cf207d0dcc90ebe31ba05b418f82d4cd4<AudioSystem>.c5ee19dc8d4cccf5ae2de225410458b86.c9f6a0386ce93c761939b8a4def1e3435.c8a3e20cbb1a0f01c8d52d7bfc64bfd44(value, array);
						return;
					}
				}
			case "vfxmanager":
				while (true)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnlineHostMinResMode)
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
						VFXManager.c5424b257448f7fd262986b927c1d46be(c55644b999838f2d90a4ea87f98774f18);
						return;
					}
				}
			case "light_pillar":
				break;
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				Pickable.LightPillarManager.ccf24681862bae286c19d5c9b16296be5.cb78d29c2fb21572285a48670ca83732a(c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e);
				return;
			}
		}
	}

	private class LevelLoadingStep_PreLoadNpcResources : LevelLoadingStep
	{
		private bool m_finish;

		public LevelLoadingStep_PreLoadNpcResources(float cea8bc0ff9f39b928110f79da66ab6ab7)
			: base(cea8bc0ff9f39b928110f79da66ab6ab7)
		{
		}

		public override void c7d932c2f1a060d3f30f1ff4d7b85e54a()
		{
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "LevelLoadingStep_PreLoadNpcResources.EnterStep [" + Time.time + "]");
			AIServiceSetting.c5ee19dc8d4cccf5ae2de225410458b86.c9ee8cfaa6e149322d3e55ae5ead97ebf();
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
						ceddde82639e912d34189cd4d21e4963b(false);
						m_finish = true;
						return;
					}
				}
			}
			List<string> list = cbf298251e7ef84590f448acf528c7d05();
			if (list.Count > 0)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.StartCoroutine(c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad618dcc0547ebee513a30332046d81f(list, cc84b45a16e448f7d0dbd2769b52afa6f, list));
						return;
					}
				}
			}
			m_finish = true;
		}

		public override bool c9384e0a8d465c2efe1d9876980016fe5()
		{
			return m_finish;
		}

		public override void cb6ca2e5e68d36a18810ef9f711e1c717()
		{
		}

		private void ceddde82639e912d34189cd4d21e4963b(bool c8b6e31e8301cd4d1eb7e3b6e854baf78)
		{
			XmlNodeList xmlNodeList = MapsDescXml.c5ee19dc8d4cccf5ae2de225410458b86.ca8e6f751bfbb2db1fb95fe72f802a524().SelectNodes("NPCSetting/NPC/@value");
			for (int i = 0; i < xmlNodeList.Count; i++)
			{
				string value = xmlNodeList[i].Value;
				BuildingKitRender buildingKitRender = new BuildingKitRender("NPC", value);
				buildingKitRender.c67915f2da62d83244da1e904f44dcc85(c8b6e31e8301cd4d1eb7e3b6e854baf78);
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
				return;
			}
		}

		private void cc84b45a16e448f7d0dbd2769b52afa6f(object cd22aa6735988e8e65acbd503f3870e3e = null)
		{
			ceddde82639e912d34189cd4d21e4963b(true);
			List<string> c99e3d0b4ce51c8a7f689a835d475a34b = (List<string>)cd22aa6735988e8e65acbd503f3870e3e;
			c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1c729e95f2ac60ec91fb0f073386b3cf(c99e3d0b4ce51c8a7f689a835d475a34b);
			m_finish = true;
		}

		private List<string> cbf298251e7ef84590f448acf528c7d05()
		{
			List<string> list = new List<string>();
			XmlNodeList xmlNodeList = MapsDescXml.c5ee19dc8d4cccf5ae2de225410458b86.ca8e6f751bfbb2db1fb95fe72f802a524().SelectNodes("NPCSetting/NPC/@value");
			for (int i = 0; i < xmlNodeList.Count; i++)
			{
				string value = xmlNodeList[i].Value;
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "Loading Npc for Level: " + value);
				BuildingKitRender buildingKitRender = new BuildingKitRender("NPC", value);
				list.AddRange(buildingKitRender.c0c98f9aa4067deab3caf8159826ae606());
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
				return list;
			}
		}
	}

	private class LevelLoadingStep_SyncLocalPlayer : LevelLoadingStep
	{
		public LevelLoadingStep_SyncLocalPlayer(float cea8bc0ff9f39b928110f79da66ab6ab7)
			: base(cea8bc0ff9f39b928110f79da66ab6ab7)
		{
		}

		public override void c7d932c2f1a060d3f30f1ff4d7b85e54a()
		{
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "LevelLoadingStep_SyncLocalPlayer.EnterStep [" + Time.time + "]");
		}

		public override bool c9384e0a8d465c2efe1d9876980016fe5()
		{
			if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Framework, "LevelLoadingStep_SyncLocalPlayer.UpdateStep: Session is null. [" + Time.time + "]");
						return false;
					}
				}
			}
			if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56() == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						return false;
					}
				}
			}
			return true;
		}

		public override void cb6ca2e5e68d36a18810ef9f711e1c717()
		{
		}
	}

	private class LevelLoadingStep_PreLoadWeapon : LevelLoadingStep
	{
		private bool m_finish;

		public LevelLoadingStep_PreLoadWeapon(float cea8bc0ff9f39b928110f79da66ab6ab7)
			: base(cea8bc0ff9f39b928110f79da66ab6ab7)
		{
		}

		public override void c7d932c2f1a060d3f30f1ff4d7b85e54a()
		{
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "LevelLoadingStep_PreLoadWeapon.EnterStep [" + Time.time + "]");
			if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnlineHostMinResMode)
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
						ceddde82639e912d34189cd4d21e4963b();
						m_finish = true;
						return;
					}
				}
			}
			List<string> list = ca3b8782d70f3279bb2b63caa6a874a34();
			if (list.Count > 0)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.StartCoroutine(c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad618dcc0547ebee513a30332046d81f(list, c5bf58895a4c656905e5b1a46dd2fc451, list));
						return;
					}
				}
			}
			m_finish = true;
		}

		public override bool c9384e0a8d465c2efe1d9876980016fe5()
		{
			return m_finish;
		}

		public override void cb6ca2e5e68d36a18810ef9f711e1c717()
		{
		}

		private void ceddde82639e912d34189cd4d21e4963b()
		{
			BuildingKitRender buildingKitRender = new BuildingKitRender("WPN", "SMG");
			buildingKitRender.c67915f2da62d83244da1e904f44dcc85(false);
			BuildingKitRender buildingKitRender2 = new BuildingKitRender("WPN", "SniperRifle");
			buildingKitRender2.c67915f2da62d83244da1e904f44dcc85(false);
			BuildingKitRender buildingKitRender3 = new BuildingKitRender("WPN", "ShotGun");
			buildingKitRender3.c67915f2da62d83244da1e904f44dcc85(false);
			BuildingKitRender buildingKitRender4 = new BuildingKitRender("WPN", "RepeaterPistol");
			buildingKitRender4.c67915f2da62d83244da1e904f44dcc85(false);
			BuildingKitRender buildingKitRender5 = new BuildingKitRender("WPN", "CombatRifle");
			buildingKitRender5.c67915f2da62d83244da1e904f44dcc85(false);
		}

		private void c5bf58895a4c656905e5b1a46dd2fc451(object cd22aa6735988e8e65acbd503f3870e3e = null)
		{
			ceddde82639e912d34189cd4d21e4963b();
			List<string> c99e3d0b4ce51c8a7f689a835d475a34b = (List<string>)cd22aa6735988e8e65acbd503f3870e3e;
			c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1c729e95f2ac60ec91fb0f073386b3cf(c99e3d0b4ce51c8a7f689a835d475a34b);
			m_finish = true;
		}

		private List<string> ca3b8782d70f3279bb2b63caa6a874a34()
		{
			List<string> list = new List<string>();
			BuildingKitRender buildingKitRender = new BuildingKitRender("WPN", "SMG");
			list.AddRange(buildingKitRender.c0c98f9aa4067deab3caf8159826ae606(false));
			BuildingKitRender buildingKitRender2 = new BuildingKitRender("WPN", "SniperRifle");
			list.AddRange(buildingKitRender2.c0c98f9aa4067deab3caf8159826ae606(false));
			BuildingKitRender buildingKitRender3 = new BuildingKitRender("WPN", "ShotGun");
			list.AddRange(buildingKitRender3.c0c98f9aa4067deab3caf8159826ae606(false));
			BuildingKitRender buildingKitRender4 = new BuildingKitRender("WPN", "RepeaterPistol");
			list.AddRange(buildingKitRender4.c0c98f9aa4067deab3caf8159826ae606(false));
			BuildingKitRender buildingKitRender5 = new BuildingKitRender("WPN", "CombatRifle");
			list.AddRange(buildingKitRender5.c0c98f9aa4067deab3caf8159826ae606(false));
			return list;
		}
	}

	private class LevelLoadingStep_UI : LevelLoadingStep
	{
		public LevelLoadingStep_UI(float cea8bc0ff9f39b928110f79da66ab6ab7)
			: base(cea8bc0ff9f39b928110f79da66ab6ab7)
		{
		}

		public override void c7d932c2f1a060d3f30f1ff4d7b85e54a()
		{
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "LevelLoadingStep_UI.EnterStep [" + Time.time + "]");
			if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c45c9d44751117fd2457b8e19283bfa51())
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
						c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<FrontEndStepManager>().c80de27b415dc1bfb2c73a64cfcafa59f(FrontEndStepManager.StepState.Town, c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e);
						return;
					}
				}
			}
			if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c28b45877056e09d3c4d6fa790a1517aa())
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<FrontEndStepManager>().c80de27b415dc1bfb2c73a64cfcafa59f(FrontEndStepManager.StepState.PVP, c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e);
						return;
					}
				}
			}
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<FrontEndStepManager>().c80de27b415dc1bfb2c73a64cfcafa59f(FrontEndStepManager.StepState.Gaming, c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e);
		}

		public override bool c9384e0a8d465c2efe1d9876980016fe5()
		{
			using (Dictionary<string, BaseAssetBundle>.Enumerator enumerator = c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.c2db49eb57b860f27c56d506da7c57f6d.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<string, BaseAssetBundle> current = enumerator.Current;
					if (!current.Key.StartsWith("uniswf_"))
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
					InGameAssetBundle inGameAssetBundle = (InGameAssetBundle)current.Value;
					if (inGameAssetBundle.m_www.isDone)
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
						return false;
					}
				}
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						goto end_IL_0083;
					}
					continue;
					end_IL_0083:
					break;
				}
			}
			return true;
		}

		public override void cb6ca2e5e68d36a18810ef9f711e1c717()
		{
		}
	}

	private class LevelLoadingStep_LoadLevelBundle : LevelLoadingStep
	{
		private AssetBundleRequest m_bundleLoading;

		public LevelLoadingStep_LoadLevelBundle(float cea8bc0ff9f39b928110f79da66ab6ab7)
			: base(cea8bc0ff9f39b928110f79da66ab6ab7)
		{
		}

		public override void c7d932c2f1a060d3f30f1ff4d7b85e54a()
		{
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "LevelLoadingStep_LoadLevelBundle.EnterStep [" + Time.time + "]");
			string value = MapsDescXml.c5ee19dc8d4cccf5ae2de225410458b86.ca8e6f751bfbb2db1fb95fe72f802a524().SelectSingleNode("AssetBundles/AssetBundle[@type='Map']/@map").Value;
			string ccc3a743cfeeaa8212871445f2d92eb9a = cfcb9706acc023c8e9d231a2388b34554();
			BaseAssetBundle baseAssetBundle = c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.cc287004e3f873904ffcdfe194323b23f(ccc3a743cfeeaa8212871445f2d92eb9a);
			m_bundleLoading = baseAssetBundle.ce2bd12bfa7577675b369574fae296f5d(value, Type.GetTypeFromHandle(c21ee453ba7700fb19a2fce2faed35b78.cc1720d05c75832f704b87474932341c3()));
		}

		public override bool c9384e0a8d465c2efe1d9876980016fe5()
		{
			if (m_bundleLoading != null)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				m_loadingProgress = m_bundleLoading.progress;
			}
			if (m_bundleLoading != null)
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
				if (!m_bundleLoading.isDone)
				{
					return false;
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
			return true;
		}

		public override void cb6ca2e5e68d36a18810ef9f711e1c717()
		{
		}

		private string cfcb9706acc023c8e9d231a2388b34554()
		{
			if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnlineHostMinResMode)
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
						return "host_" + MapsDescXml.c5ee19dc8d4cccf5ae2de225410458b86.ca8e6f751bfbb2db1fb95fe72f802a524().SelectSingleNode("AssetBundles/AssetBundle[@type='Map']/@name").Value;
					}
				}
			}
			return MapsDescXml.c5ee19dc8d4cccf5ae2de225410458b86.ca8e6f751bfbb2db1fb95fe72f802a524().SelectSingleNode("AssetBundles/AssetBundle[@type='Map']/@name").Value;
		}
	}

	private class LevelLoadingStep_LoadLevel : LevelLoadingStep
	{
		private AsyncOperation m_levelLoadingAsync;

		public LevelLoadingStep_LoadLevel(float cea8bc0ff9f39b928110f79da66ab6ab7)
			: base(cea8bc0ff9f39b928110f79da66ab6ab7)
		{
		}

		public override void c7d932c2f1a060d3f30f1ff4d7b85e54a()
		{
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "LevelLoadingStep_LoadLevel.EnterStep [" + Time.time + "]");
			string value = MapsDescXml.c5ee19dc8d4cccf5ae2de225410458b86.ca8e6f751bfbb2db1fb95fe72f802a524().SelectSingleNode("AssetBundles/AssetBundle[@type='Map']/@map").Value;
			if (!c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnlineHostMinResMode)
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
				c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.ca5bd80f5ff7a2e9ca939a6283399ec2d().c6355182065dc8b6a75012f75feefaa76();
			}
			m_levelLoadingAsync = Application.LoadLevelAsync(value);
		}

		public override bool c9384e0a8d465c2efe1d9876980016fe5()
		{
			if (m_levelLoadingAsync != null)
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
				m_loadingProgress = m_levelLoadingAsync.progress;
			}
			if (m_levelLoadingAsync != null)
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
				if (!m_levelLoadingAsync.isDone)
				{
					return false;
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
			return true;
		}

		public override void cb6ca2e5e68d36a18810ef9f711e1c717()
		{
			bool flag = false;
			int i = 1;
			for (GameObject gameObject = GameObject.Find("submap" + i); gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e; i++, gameObject = GameObject.Find("submap" + i))
			{
				flag = true;
				Transform transform = gameObject.transform.FindChild("LA");
				if (transform != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					if (transform.parent == gameObject.transform)
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
						DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "Static Batching LA");
						List<GameObject> list = new List<GameObject>();
						c5b20864dac4f794b9808635669eb27a2(list, transform.gameObject);
						if (list.Count <= 0)
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
						StaticBatchingUtility.Combine(list.ToArray(), transform.gameObject);
						continue;
					}
				}
				DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Framework, "No LA for static batching for [" + gameObject.name + "]");
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				if (flag)
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
					GameObject gameObject2 = GameObject.Find("LA");
					if (gameObject2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						if (gameObject2.transform.parent == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
						{
							while (true)
							{
								switch (3)
								{
								case 0:
									break;
								default:
								{
									DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "Static Batching LA");
									List<GameObject> list2 = new List<GameObject>();
									c5b20864dac4f794b9808635669eb27a2(list2, gameObject2);
									if (list2.Count > 0)
									{
										while (true)
										{
											switch (7)
											{
											case 0:
												break;
											default:
												StaticBatchingUtility.Combine(list2.ToArray(), gameObject2);
												return;
											}
										}
									}
									return;
								}
								}
							}
						}
					}
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Framework, "No LA for static batching");
					return;
				}
			}
		}

		private void c5b20864dac4f794b9808635669eb27a2(List<GameObject> ca545e52da5cf58789d4b7efffec79b4f, GameObject c0b8b4f11377b8a222dc728ff2c622559)
		{
			Renderer component = c0b8b4f11377b8a222dc728ff2c622559.GetComponent<Renderer>();
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (!(component.material != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					if (!(component.sharedMaterial != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
					{
						goto IL_00cc;
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
				MeshFilter component2 = c0b8b4f11377b8a222dc728ff2c622559.GetComponent<MeshFilter>();
				if (component2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					if (component2.sharedMesh != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						ca545e52da5cf58789d4b7efffec79b4f.Add(c0b8b4f11377b8a222dc728ff2c622559);
						c0b8b4f11377b8a222dc728ff2c622559.AddComponent<BatchingMeshContainer>().m_mesh = component2.sharedMesh;
					}
				}
			}
			goto IL_00cc;
			IL_00cc:
			for (int i = 0; i < c0b8b4f11377b8a222dc728ff2c622559.transform.childCount; i++)
			{
				c5b20864dac4f794b9808635669eb27a2(ca545e52da5cf58789d4b7efffec79b4f, c0b8b4f11377b8a222dc728ff2c622559.transform.GetChild(i).gameObject);
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

	private class LevelLoadingStep_LoadLevelDataBundle : LevelLoadingStep
	{
		private List<AssetBundleRequest> m_resourcesLoadingList = new List<AssetBundleRequest>();

		public LevelLoadingStep_LoadLevelDataBundle(float cea8bc0ff9f39b928110f79da66ab6ab7)
			: base(cea8bc0ff9f39b928110f79da66ab6ab7)
		{
		}

		public override void c7d932c2f1a060d3f30f1ff4d7b85e54a()
		{
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "LevelLoadingStep_LoadLevelDataBundle.EnterStep [" + Time.time + "]");
			if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnlineHostMinResMode)
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
			XmlNode xmlNode = MapsDescXml.c5ee19dc8d4cccf5ae2de225410458b86.ca8e6f751bfbb2db1fb95fe72f802a524().SelectSingleNode("AssetBundles/AssetBundle[@type='LevelData']/@name");
			XmlNode xmlNode2 = MapsDescXml.c5ee19dc8d4cccf5ae2de225410458b86.ca8e6f751bfbb2db1fb95fe72f802a524().SelectSingleNode("AssetBundles/AssetBundle[@type='LevelData']/Cubemap/@path");
			if (xmlNode == null)
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
				BaseAssetBundle baseAssetBundle = c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.cc287004e3f873904ffcdfe194323b23f(xmlNode.Value);
				if (xmlNode2 == null)
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
					if (!baseAssetBundle.c1a84901a0a9ec83a0000feb026941d27(xmlNode2.Value))
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
						m_resourcesLoadingList.Add(baseAssetBundle.ce2bd12bfa7577675b369574fae296f5d(xmlNode2.Value, Type.GetTypeFromHandle(ced3d18b01082ebe6ed37974d567698bd.cc1720d05c75832f704b87474932341c3())));
						return;
					}
				}
			}
		}

		public override bool c9384e0a8d465c2efe1d9876980016fe5()
		{
			if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnlineHostMinResMode)
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
						return true;
					}
				}
			}
			bool flag = true;
			int num = 0;
			while (true)
			{
				if (num < m_resourcesLoadingList.Count)
				{
					AssetBundleRequest assetBundleRequest = m_resourcesLoadingList[num];
					if (!assetBundleRequest.isDone)
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
						flag = false;
						break;
					}
					num++;
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
			if (flag)
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
				for (int i = 0; i < m_resourcesLoadingList.Count; i++)
				{
					AssetBundleRequest assetBundleRequest2 = m_resourcesLoadingList[i];
					if (!assetBundleRequest2.isDone)
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
					UnityEngine.Object asset = assetBundleRequest2.asset;
					if (asset.GetType() == Type.GetTypeFromHandle(ced3d18b01082ebe6ed37974d567698bd.cc1720d05c75832f704b87474932341c3()))
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
						c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_levelCubemap = asset as Cubemap;
					}
					else if (asset.GetType() == Type.GetTypeFromHandle(cda4706963b5b94cc26d866126dd86f9c.cc1720d05c75832f704b87474932341c3()))
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
						if (asset.name.Contains("farlightProbes"))
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
							c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_farLigthProb = asset as TextAsset;
						}
						else if (asset.name.Contains("nearlightProbes"))
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
							c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_nearLigthProb = asset as TextAsset;
						}
					}
					m_resourcesLoadingList.Remove(assetBundleRequest2);
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
				if (c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_nearLigthProb != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					if (c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_farLigthProb != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						cac6e7db617378ce664947781cfa08c9c();
					}
				}
				if (m_resourcesLoadingList.Count == 0)
				{
					while (true)
					{
						switch (4)
						{
						case 0:
							break;
						default:
							return true;
						}
					}
				}
			}
			return false;
		}

		public override void cb6ca2e5e68d36a18810ef9f711e1c717()
		{
		}

		private void cac6e7db617378ce664947781cfa08c9c()
		{
			TextAsset farLigthProb = c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_farLigthProb;
			TextAsset nearLigthProb = c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_nearLigthProb;
			if (farLigthProb != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (nearLigthProb != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					BinaryFormatter binaryFormatter = new BinaryFormatter();
					Stream stream = c051941cafcc989335d3382955d18e617.c7088de59e49f7108f520cf7e0bae167e;
					try
					{
						stream = new MemoryStream(farLigthProb.bytes);
						c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_farLightProCoeff = binaryFormatter.Deserialize(stream) as float[];
					}
					catch (Exception ex)
					{
						DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Framework, ex.ToString());
						DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Framework, "LinSH: Read FarData error!");
					}
					finally
					{
						stream.Close();
						stream = c051941cafcc989335d3382955d18e617.c7088de59e49f7108f520cf7e0bae167e;
					}
					try
					{
						stream = new MemoryStream(nearLigthProb.bytes);
						c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_nearLightProCoeff = binaryFormatter.Deserialize(stream) as float[];
					}
					catch (Exception ex2)
					{
						DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Framework, ex2.ToString());
						DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Framework, "LinSH: Read NearData error!");
					}
					finally
					{
						stream.Close();
						stream = c051941cafcc989335d3382955d18e617.c7088de59e49f7108f520cf7e0bae167e;
					}
					if (c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_nearLightProCoeff != null)
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
						if (c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_farLightProCoeff != null)
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
							if (LightmapSettings.lightProbes != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
								if (c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_nearLightProCoeff.Length != c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_farLightProCoeff.Length)
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
									if (c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_nearLightProCoeff.Length != LightmapSettings.lightProbes.coefficients.Length)
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
										DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Framework, "LinSH: light probe number is not match near/far/lightmapSetting!");
										c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_nearLightProCoeff = (c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_farLightProCoeff = null);
										goto IL_021d;
									}
								}
								c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_customLightProbes = UnityEngine.Object.Instantiate(LightmapSettings.lightProbes) as LightProbes;
								goto IL_021d;
							}
						}
					}
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "LinSH : Can't create the light probe instance!");
					goto IL_021d;
				}
			}
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Framework, "LinSH: Light Probe miss!");
			goto IL_021d;
			IL_021d:
			nearLigthProb = null;
		}
	}

	private class LevelLoadingStep_GenerateWeaponsData : LevelLoadingStep
	{
		public LevelLoadingStep_GenerateWeaponsData(float cea8bc0ff9f39b928110f79da66ab6ab7)
			: base(cea8bc0ff9f39b928110f79da66ab6ab7)
		{
		}

		public override void c7d932c2f1a060d3f30f1ff4d7b85e54a()
		{
		}

		public override bool c9384e0a8d465c2efe1d9876980016fe5()
		{
			return true;
		}

		public override void cb6ca2e5e68d36a18810ef9f711e1c717()
		{
		}
	}

	private class LevelLoadingStep_EndLoading : LevelLoadingStep
	{
		public LevelLoadingStep_EndLoading(float cea8bc0ff9f39b928110f79da66ab6ab7)
			: base(cea8bc0ff9f39b928110f79da66ab6ab7)
		{
		}

		public override void c7d932c2f1a060d3f30f1ff4d7b85e54a()
		{
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "LevelLoadingStep_EndLoading.EnterStep [" + Time.time + "]");
		}

		public override bool c9384e0a8d465c2efe1d9876980016fe5()
		{
			List<string> c99e3d0b4ce51c8a7f689a835d475a34b = c30b7927bc4bd2490364ede0e702c5807();
			c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1c729e95f2ac60ec91fb0f073386b3cf(c99e3d0b4ce51c8a7f689a835d475a34b);
			if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnlineHostMinResMode)
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
				ResourcesLoader.c9984361ac943dc8858e866d1e158927b();
				Resources.UnloadUnusedAssets();
			}
			else
			{
				c06ca0e618478c23eba3419653a19760f<QualityManager>.c5ee19dc8d4cccf5ae2de225410458b86.cbeb6a55e2651386be919902924c130f7();
			}
			if (c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_callback != null)
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
				c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_callback(c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_callbackParam);
			}
			List<string> list = new List<string>();
			using (Dictionary<string, BaseAssetBundle>.Enumerator enumerator = c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.c2db49eb57b860f27c56d506da7c57f6d.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<string, BaseAssetBundle> current = enumerator.Current;
					if (!current.Key.StartsWith("uniswf_"))
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
					list.Add(current.Key);
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						goto end_IL_00ed;
					}
					continue;
					end_IL_00ed:
					break;
				}
			}
			for (int i = 0; i < list.Count; i++)
			{
				c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.c023f6d02221ee56c20921f9cd2e22441(list[i]);
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				c06ca0e618478c23eba3419653a19760f<UniResourceManager>.c5ee19dc8d4cccf5ae2de225410458b86.ce6106566ea862da64238f154db641dac();
				List<KeyValuePair<string, Material>> list2 = new List<KeyValuePair<string, Material>>();
				using (Dictionary<string, Material>.Enumerator enumerator2 = TextureManager.instance.materials.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						KeyValuePair<string, Material> current2 = enumerator2.Current;
						if (!current2.Key.Contains(".swf_"))
						{
							continue;
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
						if (current2.Key.Contains("swf/"))
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
						string key = current2.Key;
						string[] array = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(1);
						array[0] = ".swf";
						string key2 = key.Split(array, StringSplitOptions.RemoveEmptyEntries)[0] + ".swf/" + current2.Key;
						list2.Add(new KeyValuePair<string, Material>(key2, current2.Value));
					}
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							goto end_IL_0214;
						}
						continue;
						end_IL_0214:
						break;
					}
				}
				for (int j = 0; j < list2.Count; j++)
				{
					if (!TextureManager.instance.materials.ContainsKey(list2[j].Key))
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
						TextureManager.instance.materials.Add(list2[j].Key, list2[j].Value);
					}
					else
					{
						TextureManager.instance.materials[list2[j].Key] = list2[j].Value;
					}
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					return true;
				}
			}
		}

		public override void cb6ca2e5e68d36a18810ef9f711e1c717()
		{
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().OnLevelLoadingFinish();
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<FrontEndStepManager>().OnCurStepLevelLoadingFinish();
			c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_previousLevel = MapsDescXml.c5ee19dc8d4cccf5ae2de225410458b86.ca8e6f751bfbb2db1fb95fe72f802a524();
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "System.GC.Collect");
			GC.Collect();
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "System.GC.Collect");
			GC.Collect();
		}
	}

	private LevelLoadingStepController m_stepController = new LevelLoadingStepController();

	private FuncBase m_callback;

	private object m_callbackParam;

	private XmlNodeList m_assetBundleList;

	public float m_farClip = 3500f;

	private string m_cameraEffect = string.Empty;

	private string m_previousInstance;

	private XmlNode m_previousLevel;

	private TextAsset m_nearLigthProb;

	private TextAsset m_farLigthProb;

	public float[] m_farLightProCoeff;

	public float[] m_nearLightProCoeff;

	public LightProbes m_customLightProbes;

	public Cubemap m_levelCubemap;

	public GameObject m_levelEffectCamera;

	public float m_startLoadingTime;

	public string c4420eafaa55a37f84d3775eed102e985()
	{
		return m_cameraEffect;
	}

	public float c0a687459ceef442f37c4d398cb12f99f()
	{
		return m_stepController.c0a687459ceef442f37c4d398cb12f99f();
	}

	public string c8b70afb12d12e93983260684a70f87c7()
	{
		return m_stepController.c8b70afb12d12e93983260684a70f87c7();
	}

	public bool c739bc996d272aeac228d6b5198b164d2()
	{
		return m_stepController.c739bc996d272aeac228d6b5198b164d2();
	}

	public void c040ee5dc6011ac6f76e73d8f329ca070()
	{
		m_stepController.c040ee5dc6011ac6f76e73d8f329ca070();
	}

	private void Start()
	{
		MapsDescXml mapsDescXml = MapsDescXml.c5ee19dc8d4cccf5ae2de225410458b86;
		if (mapsDescXml == null)
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
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "MapsDescXml constructed");
			return;
		}
	}

	private void Update()
	{
		m_stepController.Update();
	}

	private void cbfe45335bcb72146fc37f1b8c3950206(BaseAssetBundle c55644b999838f2d90a4ea87f98774f18, string c00bb86ffbeb6764fbe60d7b64859db7f)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, c00bb86ffbeb6764fbe60d7b64859db7f);
		UnityEngine.Object @object = c55644b999838f2d90a4ea87f98774f18.c38aeacc59bd560b59403945ae7996d79("BUILD_NUMBER", Type.GetTypeFromHandle(cda4706963b5b94cc26d866126dd86f9c.cc1720d05c75832f704b87474932341c3()));
		if (!(@object != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			TextAsset textAsset = @object as TextAsset;
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, textAsset.text);
			return;
		}
	}

	public bool c696204347900a421f9e900c068ebdcc7(string cd99af21e22e356018b8f72d4a7e4872a, FuncBase c2db84530ef366a6deb001d449d4aa151 = null, object ca194018e271c05a581adf5b72f2e37fb = null)
	{
		if (string.IsNullOrEmpty(cd99af21e22e356018b8f72d4a7e4872a))
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
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Framework, "LoadMap - Nothing to load");
					return false;
				}
			}
		}
		m_callback = c2db84530ef366a6deb001d449d4aa151;
		m_callbackParam = ca194018e271c05a581adf5b72f2e37fb;
		MapsDescXml.c5ee19dc8d4cccf5ae2de225410458b86.c840d299b55e9d897960d96d3ffa2996b(cd99af21e22e356018b8f72d4a7e4872a);
		m_stepController.Start();
		return true;
	}
}
