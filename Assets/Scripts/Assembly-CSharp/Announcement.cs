using System.Collections;

public class Announcement
{
	public string Content { get; set; }

	public AnnouncementType Type { get; set; }

	public Announcement()
	{
	}

	public Announcement(Hashtable c591d56a94543e3559945c497f37126c4)
	{
		cc95f1fbaa3f9e0533900d0e3a5e0bfa2(c591d56a94543e3559945c497f37126c4);
	}

	public void cc95f1fbaa3f9e0533900d0e3a5e0bfa2(Hashtable c591d56a94543e3559945c497f37126c4)
	{
		Content = (string)c591d56a94543e3559945c497f37126c4[0];
		Type = (AnnouncementType)(int)c591d56a94543e3559945c497f37126c4[1];
	}
}
