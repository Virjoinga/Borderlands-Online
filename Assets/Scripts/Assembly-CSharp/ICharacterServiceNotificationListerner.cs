public interface ICharacterServiceNotificationListerner
{
	void OnGotMyCurrencies(CurrencyInfo currency);

	void OnExperienceUpdated(int experience);

	void OnGetPersonalSettings(string strSettings);

	void OnSetPersonalSettings(int iResult);
}
