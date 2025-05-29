using System.Collections;

public class MailInfo
{
	public int MailID;

	public MailState Mailstate;

	public MailType Mailtype;

	public int SenderID;

	public string SenderName;

	public int ReceiverID;

	public string ReceiverName;

	public string Content;

	public int Expiration;

	public InventoryItem Item;

	public MailInfo(Hashtable c28cf3d24e3067ef54895f824fad7fcef)
	{
		MailID = (int)c28cf3d24e3067ef54895f824fad7fcef[0];
		Mailtype = (MailType)(byte)c28cf3d24e3067ef54895f824fad7fcef[1];
		Mailstate = (MailState)(byte)c28cf3d24e3067ef54895f824fad7fcef[2];
		SenderID = (int)c28cf3d24e3067ef54895f824fad7fcef[3];
		SenderName = (string)c28cf3d24e3067ef54895f824fad7fcef[4];
		ReceiverID = (int)c28cf3d24e3067ef54895f824fad7fcef[5];
		ReceiverName = (string)c28cf3d24e3067ef54895f824fad7fcef[6];
		Content = (string)c28cf3d24e3067ef54895f824fad7fcef[7];
		Expiration = (int)c28cf3d24e3067ef54895f824fad7fcef[8];
		Hashtable hashtable = (Hashtable)c28cf3d24e3067ef54895f824fad7fcef[9];
		if (hashtable == null)
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
			Item = new InventoryItem(hashtable);
			return;
		}
	}
}
