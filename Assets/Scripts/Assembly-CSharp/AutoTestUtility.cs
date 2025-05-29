using System;
using System.Collections;
using System.Xml;
using A;
using Core;
using UnityEngine;
using XsdSettings;

public static class AutoTestUtility
{
	public static void c5c8ba70599a44e07627ee47ddd699857(Vector3 cef9712200bbe2c3873eec3ca2e18a595)
	{
		WeaponGeneratorService component = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<WeaponGeneratorService>();
		ItemDNA caedbc1db6c28d44eab6021e7d674eab = ItemDNA.c8284b9f225995cc6a6e1888c9c037b06(component.m_weapons[0]);
		cef9712200bbe2c3873eec3ca2e18a595.y += 1f;
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<InstantiateManager>().cbf43efce245fabdfb9d3009487ba8085(caedbc1db6c28d44eab6021e7d674eab, cef9712200bbe2c3873eec3ca2e18a595, Quaternion.identity, Vector3.up);
	}

	public static int c642bbf8d1fedcf6b86a1198b396dedbf(string cfc65a08403dc9fbf34393ce7bcf3e6f5 = null)
	{
		string cd99af21e22e356018b8f72d4a7e4872a = "lvl_autotest_1";
		if (cfc65a08403dc9fbf34393ce7bcf3e6f5 == "playerShootingTestPvP")
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
			cd99af21e22e356018b8f72d4a7e4872a = "lvl_autotest_PvP";
		}
		int result = -1;
		MatchmakingService component = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<MatchmakingService>();
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
			Playlist playlist = component.c9bdc2c0504907130c26fceebf8d21879(cd99af21e22e356018b8f72d4a7e4872a);
			result = playlist.m_id;
		}
		return result;
	}

	public static string c6921a12df59fc1206bd8bea12427f9af()
	{
		return Environment.GetEnvironmentVariable("gamemode");
	}

	public static void c1830583ece68f3e786cc89e71f4c1599()
	{
		string text = Environment.GetEnvironmentVariable("mapname");
		if (string.IsNullOrEmpty(text))
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
			string autoTestCase = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_autoTestCase;
			char[] array = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
			array[0] = '|';
			string[] array2 = autoTestCase.Split(array);
			if (array2.Length > 1)
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
				text = array2[1];
			}
		}
		if (string.IsNullOrEmpty(text))
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
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Autotest, "No EnvVar For MapName");
		}
		else
		{
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Autotest, "From EnvVar, Map Name Is: " + text);
			string text2 = "lvl_autotest_1";
			string value = "lvl_deleted";
			XmlDocument xmlDocument = LevelLoadingManager.MapsDescXml.c5ee19dc8d4cccf5ae2de225410458b86.ce47cc86d7b19cb0ceb4b63bcfe8d210a();
			XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("Map");
			for (int i = 0; i < elementsByTagName.Count; i++)
			{
				XmlNode xmlNode = elementsByTagName.Item(i);
				if (!(xmlNode.Attributes["name"].Value.ToLower() == text2.ToLower()))
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
				xmlNode.Attributes["name"].Value = value;
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
			for (int j = 0; j < elementsByTagName.Count; j++)
			{
				XmlNode xmlNode2 = elementsByTagName.Item(j);
				if (!(xmlNode2.Attributes["name"].Value.ToLower() == text.ToLower()))
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
				xmlNode2.Attributes["name"].Value = text2;
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
		Playlist playlist = MatchmakingService.c5ee19dc8d4cccf5ae2de225410458b86.c2e7bb39e76e20727d1aba6604464614e(text);
		if (playlist != null)
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
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_playlistId = playlist.m_id;
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Autotest, "Now new id: " + playlist.m_id);
		}
		string environmentVariable = Environment.GetEnvironmentVariable("maxplayer");
		int result = 0;
		if (int.TryParse(environmentVariable, out result))
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
			MatchmakingService.c5ee19dc8d4cccf5ae2de225410458b86.c2718b579e09549a1cd47620188a40a38(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_playlistId).m_maxPlayerCount = result;
		}
		string environmentVariable2 = Environment.GetEnvironmentVariable("npcname");
		if (string.IsNullOrEmpty(environmentVariable2))
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Autotest, "No Npc List");
					return;
				}
			}
		}
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Autotest, "From EnvVar, Npc Name Is: " + environmentVariable2);
		XmlDocument xmlDocument2 = LevelLoadingManager.MapsDescXml.c5ee19dc8d4cccf5ae2de225410458b86.ce47cc86d7b19cb0ceb4b63bcfe8d210a();
		XmlNode xmlNode3 = xmlDocument2.SelectSingleNode("/Instance/Maps/Map[@name='lvl_autotest_1']/NPCSetting");
		xmlNode3.RemoveAll();
		char[] array3 = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
		array3[0] = '|';
		string[] array4 = environmentVariable2.Split(array3);
		for (int k = 0; k < array4.Length; k++)
		{
			string value2 = array4[k].Trim();
			XmlElement xmlElement = xmlDocument2.CreateElement("NPC");
			XmlAttribute xmlAttribute = xmlDocument2.CreateAttribute("value");
			xmlAttribute.Value = value2;
			xmlElement.Attributes.Append(xmlAttribute);
			xmlNode3.AppendChild(xmlElement);
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

	public static Entity cafaeaeb1ae753a22530e1fbebe113e8c<c272566d4edbf24bb8c4df6114a524ac9>() where c272566d4edbf24bb8c4df6114a524ac9 : Entity
	{
		GameObject gameObject = GameObject.Find("/AppManager/Entities");
		GameObject c7088de59e49f7108f520cf7e0bae167e = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
		for (int i = 0; i < gameObject.transform.childCount; i++)
		{
			c7088de59e49f7108f520cf7e0bae167e = gameObject.transform.GetChild(i).gameObject;
			if (!(c7088de59e49f7108f520cf7e0bae167e != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			Entity component = c7088de59e49f7108f520cf7e0bae167e.GetComponent<c272566d4edbf24bb8c4df6114a524ac9>();
			if (!(component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				return component;
			}
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				continue;
			}
			return null;
		}
	}

	public static IEnumerator c88bf190f463b6c67167742aa8dae7509(AvatarType c2bfb3fe48ffea6949a5d0843b8d4e441)
	{
		MatchmakingService.LeaveRoomAsyncTask leaveRoom = new MatchmakingService.LeaveRoomAsyncTask();
		leaveRoom.c7cc9411392f033dee9802f9b9ca15b21();
		c06ca0e618478c23eba3419653a19760f<cc3d8f9888524f253f9d1a8618103803b>.c5ee19dc8d4cccf5ae2de225410458b86.c7a2810eafd8052b783f9446b7d4c9494(leaveRoom, cb72721790eb9d0ca9e6f1ccfb010aa33.c7088de59e49f7108f520cf7e0bae167e);
		while (!leaveRoom.c762acfd9de32c566fab82e7bbfb0e93f())
		{
			yield return 0;
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
			while (!Application.CanStreamedLevelBeLoaded("ResourcesLoading"))
			{
				Application.GetStreamProgressForLevel("ResourcesLoading");
				yield return c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e;
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				string autotestName2 = c585561a7e2d1fad0661d8f890537fed4.c5871675a9f1c5f7e18d2787277f85f73 + Environment.GetEnvironmentVariable("COMPUTERNAME") + DateTime.Now.Ticks;
				uint nameHash = Utility.cf642a65627df2adf4e90330457651907(autotestName2);
				autotestName2 = "at_" + nameHash;
				GameFlowManager gameFlow = c06ca0e618478c23eba3419653a19760f<AutoTestManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<GameFlowManager>();
				c06ca0e618478c23eba3419653a19760f<AutoTestManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<MenuManager>();
				NetworkManager.AuthenticateAsyncTask authenticate = new NetworkManager.AuthenticateAsyncTask();
				authenticate.c7cc9411392f033dee9802f9b9ca15b21(autotestName2);
				c06ca0e618478c23eba3419653a19760f<cc3d8f9888524f253f9d1a8618103803b>.c5ee19dc8d4cccf5ae2de225410458b86.c7a2810eafd8052b783f9446b7d4c9494(authenticate, cb72721790eb9d0ca9e6f1ccfb010aa33.c7088de59e49f7108f520cf7e0bae167e);
				while (!authenticate.c762acfd9de32c566fab82e7bbfb0e93f())
				{
					yield return 0;
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					if (authenticate.ccbba85a67aa095895787b6d432c194b3() == c2597280f86604f98f89309a4de95dd62.Success)
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
						OnlineService.c123f97c79fbb5492a276d756505ecfe3(autotestName2);
					}
					CharacterService.GetCharacterListAsyncTask getCharacterList = new CharacterService.GetCharacterListAsyncTask();
					getCharacterList.c7cc9411392f033dee9802f9b9ca15b21();
					c06ca0e618478c23eba3419653a19760f<cc3d8f9888524f253f9d1a8618103803b>.c5ee19dc8d4cccf5ae2de225410458b86.c7a2810eafd8052b783f9446b7d4c9494(getCharacterList, cb72721790eb9d0ca9e6f1ccfb010aa33.c7088de59e49f7108f520cf7e0bae167e);
					while (!getCharacterList.c762acfd9de32c566fab82e7bbfb0e93f())
					{
						yield return 0;
					}
					while (true)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						if (getCharacterList.ccbba85a67aa095895787b6d432c194b3() != c2597280f86604f98f89309a4de95dd62.Success)
						{
							while (true)
							{
								switch (4)
								{
								case 0:
									break;
								default:
									DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Autotest, "Can't Get Character List");
									yield break;
								}
							}
						}
						Character character2 = c997d65b1778a9a000b321a974141fe05.c7088de59e49f7108f520cf7e0bae167e;
						if (getCharacterList.m_characters.Count > 0)
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
							CharacterService.SelectCharacterAsyncTask selectCharacter = new CharacterService.SelectCharacterAsyncTask();
							selectCharacter.c7cc9411392f033dee9802f9b9ca15b21(getCharacterList.m_characters[0].Id);
							c06ca0e618478c23eba3419653a19760f<cc3d8f9888524f253f9d1a8618103803b>.c5ee19dc8d4cccf5ae2de225410458b86.c7a2810eafd8052b783f9446b7d4c9494(selectCharacter, cb72721790eb9d0ca9e6f1ccfb010aa33.c7088de59e49f7108f520cf7e0bae167e);
							while (!selectCharacter.c762acfd9de32c566fab82e7bbfb0e93f())
							{
								yield return 0;
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
							if (selectCharacter.ccbba85a67aa095895787b6d432c194b3() != c2597280f86604f98f89309a4de95dd62.Success)
							{
								while (true)
								{
									switch (4)
									{
									case 0:
										continue;
									}
									DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Autotest, "Can't Select Character");
									yield break;
								}
							}
							character2 = selectCharacter.m_character;
						}
						else
						{
							AvatarDNA dna = new AvatarDNA();
							dna.c300c4ff719a5623d8161bef607d268f1(c2bfb3fe48ffea6949a5d0843b8d4e441);
							CharacterService.CreateCharacterAsyncTask createCharacter = new CharacterService.CreateCharacterAsyncTask();
							createCharacter.c7cc9411392f033dee9802f9b9ca15b21(autotestName2, dna);
							c06ca0e618478c23eba3419653a19760f<cc3d8f9888524f253f9d1a8618103803b>.c5ee19dc8d4cccf5ae2de225410458b86.c7a2810eafd8052b783f9446b7d4c9494(createCharacter, cb72721790eb9d0ca9e6f1ccfb010aa33.c7088de59e49f7108f520cf7e0bae167e);
							while (!createCharacter.c762acfd9de32c566fab82e7bbfb0e93f())
							{
								yield return 0;
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
							if (createCharacter.ccbba85a67aa095895787b6d432c194b3() != c2597280f86604f98f89309a4de95dd62.Success)
							{
								while (true)
								{
									switch (5)
									{
									case 0:
										continue;
									}
									object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(5);
									array[0] = "Can't Create Character[";
									array[1] = autotestName2;
									array[2] = "][";
									array[3] = dna;
									array[4] = "]";
									DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Autotest, string.Concat(array));
									yield break;
								}
							}
							character2 = createCharacter.m_character;
						}
						PlayerProperties localPlayer = new PlayerProperties
						{
							m_id = character2.Id,
							m_name = character2.Name,
							m_exp = character2.Experience,
							m_level = character2.Level
						};
						AvatarDNA newdna = new AvatarDNA();
						newdna.c300c4ff719a5623d8161bef607d268f1(character2.AvatarType, character2.AvatarParts, character2.AvatarMaterials, character2.AvatarId);
						localPlayer.m_avatarDna = newdna;
						c06ca0e618478c23eba3419653a19760f<PlayerManager>.c5ee19dc8d4cccf5ae2de225410458b86.cd48a53289a0d0d4ec50069243545b823(localPlayer, true);
						gameFlow.cfe7182ecd28c1d073193664c0a470e42("OnGoToInstance", c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_playlistId);
						yield break;
					}
				}
			}
		}
	}

	private static void OnLoginProcess(bool isExistingUser)
	{
	}

	private static void OnCreateProcess(int errorCode)
	{
	}

	private static void OnFinishProcess(int errorCode)
	{
	}
}
