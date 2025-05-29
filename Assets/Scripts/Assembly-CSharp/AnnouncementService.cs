using System;
using System.Collections;
using System.Collections.Generic;

internal class AnnouncementService : OnAccessSingleton<IAnnouncementService, AnnouncementService, AnnouncementServiceOffline>, IAnnouncementService
{
	private List<OnAnnouncements> mOnAnnouncements;

	public AnnouncementService()
	{
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(160, OnAnnouncementsEvent);
		mOnAnnouncements = new List<OnAnnouncements>();
	}

	public void OnAnnouncementsEvent(Dictionary<byte, object> parameters)
	{
		List<Announcement> list = new List<Announcement>();
		Hashtable hashtable = (Hashtable)parameters[0];
		IDictionaryEnumerator enumerator = hashtable.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				list.Add(new Announcement((Hashtable)((DictionaryEntry)enumerator.Current).Value));
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
				break;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable == null)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						goto end_IL_0079;
					}
					continue;
					end_IL_0079:
					break;
				}
			}
			else
			{
				disposable.Dispose();
			}
		}
		Announcement[] annnouncementsData = list.ToArray();
		mOnAnnouncements.ForEach(delegate(OnAnnouncements c5ebdc65d5cb420faf7ba524809963aa9)
		{
			c5ebdc65d5cb420faf7ba524809963aa9(annnouncementsData);
		});
	}

	public void ce49f946c9c8003f00306f94e17ff7825(OnAnnouncements c2db84530ef366a6deb001d449d4aa151)
	{
		mOnAnnouncements.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c5a21732345cea8239ce61ace459b93b1(OnAnnouncements c2db84530ef366a6deb001d449d4aa151)
	{
		mOnAnnouncements.Remove(c2db84530ef366a6deb001d449d4aa151);
	}
}
