using System.Collections.Generic;
using A;
using Core;
using UnityEngine;

public class ObjectiveManager : c1ee7921b0c3cce194fb7cae41b5a9d82<ObjectiveManager>
{
	private Dictionary<string, string> m_objectives = new Dictionary<string, string>();

	public void cc12be9962964908b417f759be8b7e9b9(string c35f98ccbfa8c6bf09319c620b21b5dc5, string ca1d18e73ea3ae81d7ff4c500c61bbd6a, string c05d56fe2592041e688d5606802d9613d)
	{
		string value = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<QuestTrackView>().c33096811c690978da9d02f180ff1e6d4(LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(ca1d18e73ea3ae81d7ff4c500c61bbd6a)), LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(c05d56fe2592041e688d5606802d9613d)));
		m_objectives.Add(c35f98ccbfa8c6bf09319c620b21b5dc5, value);
	}

	public void cbdcabb7d04b1a020f5dc77a9541ce50b(string c35f98ccbfa8c6bf09319c620b21b5dc5, bool c81eb588682707c869f6440c10e28093c)
	{
		string value;
		if (m_objectives.TryGetValue(c35f98ccbfa8c6bf09319c620b21b5dc5, out value))
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
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<QuestTrackView>().c34032e04fc02a186a3d3770f9d5425bd(value);
					m_objectives.Remove(c35f98ccbfa8c6bf09319c620b21b5dc5);
					return;
				}
			}
		}
		string[] array = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(5);
		array[0] = "You are trying to remove Objective [";
		array[1] = c35f98ccbfa8c6bf09319c620b21b5dc5;
		array[2] = "] which has never been given on map[";
		array[3] = Application.loadedLevelName;
		array[4] = "]";
		DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Gamelogic, string.Concat(array));
	}

	public void cac7688b05e921e2be3f92479ba44b4a8()
	{
		QuestTrackView questTrackView = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<QuestTrackView>();
		if (questTrackView == null)
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
		Dictionary<string, string>.Enumerator enumerator = m_objectives.GetEnumerator();
		while (enumerator.MoveNext())
		{
			questTrackView.c34032e04fc02a186a3d3770f9d5425bd(enumerator.Current.Value);
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			m_objectives.Clear();
			return;
		}
	}
}
