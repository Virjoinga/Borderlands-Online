using System.Xml.Serialization;

namespace XsdSettings
{
	public class Category
	{
		private SettingItem[] mConfigItemsField;

		public SettingCategory mCategoryType { get; set; }

		[XmlArrayItem("mItem", IsNullable = false)]
		public SettingItem[] mConfigItems { get; set; }

		public Category()
		{
			mCategoryType = SettingCategory.Gameplay;
		}
	}
}
