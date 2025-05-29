public abstract class IContentManager
{
	public abstract void OnLanguageChange(string language);

	public abstract void OnContentAdded(ILocalizedContent content);
}
