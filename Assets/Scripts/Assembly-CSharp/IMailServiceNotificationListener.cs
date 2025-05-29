using System.Collections.Generic;

public interface IMailServiceNotificationListener
{
	void OnGetNewMail(MailInfo newmail);

	void OnGetMailList(List<MailInfo> mailList);

	void OnSendMail(bool bIsSuccessful);

	void OnReadMail(int mailID);

	void OnDeleteMail(int mailID);

	void OnGetmailItem(short result, int mailID);
}
