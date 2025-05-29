using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using A;
using UnityEngine;
using XsdSettings;

public class PassiveSkillsManager : MonoBehaviour
{
	private List<PassiveSkillSettings> m_passiveSkills = new List<PassiveSkillSettings>();

	private static PassiveSkillsManager s_instance;

	public static PassiveSkillsManager c5ee19dc8d4cccf5ae2de225410458b86
	{
		get
		{
			if (s_instance == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				s_instance = new PassiveSkillsManager();
			}
			return s_instance;
		}
	}

	private PassiveSkillsManager()
	{
	}

	private void Awake()
	{
		s_instance = this;
	}

	public void Start()
	{
		TextAsset textAsset = ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Entities/PassiveSkillsTable") as TextAsset;
		MemoryStream memoryStream = new MemoryStream(textAsset.bytes);
		try
		{
			XmlSerializer xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(cdc1ddd1165e461b1dd090a43139c49f5.cc1720d05c75832f704b87474932341c3()));
			m_passiveSkills = xmlSerializer.Deserialize(memoryStream) as List<PassiveSkillSettings>;
		}
		finally
		{
			if (memoryStream != null)
			{
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
					((IDisposable)memoryStream).Dispose();
					break;
				}
			}
		}
		Resources.UnloadAsset(textAsset);
	}

	public List<PassiveSkillSettings> c41c2e60c2b47d656c5026ecbe0c7c4f0(List<PassiveSkill> ccdb04986e8b25209ab7b226e7dc544e8)
	{
		List<PassiveSkillSettings> list = new List<PassiveSkillSettings>();
		ELevelDifficulty difficulty = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_difficulty;
		int num = 0;
		int num2 = 0;
		using (List<PassiveSkill>.Enumerator enumerator = ccdb04986e8b25209ab7b226e7dc544e8.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				PassiveSkill current = enumerator.Current;
				num2 += current.m_probability;
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
				break;
			}
		}
		int num3 = UnityEngine.Random.Range(0, num2);
		int num4 = 0;
		using (List<PassiveSkill>.Enumerator enumerator2 = ccdb04986e8b25209ab7b226e7dc544e8.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				PassiveSkill current2 = enumerator2.Current;
				using (List<PassiveSkillSettings>.Enumerator enumerator3 = m_passiveSkills.GetEnumerator())
				{
					while (enumerator3.MoveNext())
					{
						PassiveSkillSettings current3 = enumerator3.Current;
						if (num > (int)difficulty)
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
						if (current2.m_skillID != current3.m_skillID)
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
						if (current2.m_passiveSkillType != current3.m_skillType)
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
						if (num3 >= num4 + current2.m_probability)
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
						if (num3 < num4)
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
						list.Add(current3);
						num++;
					}
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							goto end_IL_0130;
						}
						continue;
						end_IL_0130:
						break;
					}
				}
				num4 += current2.m_probability;
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				return list;
			}
		}
	}
}
