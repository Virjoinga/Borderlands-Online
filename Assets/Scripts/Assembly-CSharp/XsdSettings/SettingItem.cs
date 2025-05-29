using System.ComponentModel;
using System.Xml.Serialization;

namespace XsdSettings
{
	public class SettingItem
	{
		private IntPair mRangeField;

		private IntPair[] mResolutionsField;

		private QualityLevel[] mQualitysField;

		public SettingDisplayType mDisplayType { get; set; }

		public string mTitle { get; set; }

		public string mDescription { get; set; }

		public SettingFunctionType mFunctionType { get; set; }

		public SettingStoreLocation mStoreLocation { get; set; }

		public IntPair mRange { get; set; }

		[XmlArrayItem("mResolutions", IsNullable = false)]
		public IntPair[] mResolutions { get; set; }

		[XmlArrayItem("mQuality", IsNullable = false)]
		public QualityLevel[] mQualitys { get; set; }

		[XmlArrayItem("StrValue", IsNullable = false)]
		public string[] mControlSchemeList { get; set; }

		[DefaultValue(typeof(float), "-1")]
		public float mDefaultFloat { get; set; }

		[DefaultValue(-1)]
		public int mDefaultInt { get; set; }

		public bool mDefaultBool { get; set; }

		[XmlIgnore]
		public bool mDefaultBoolSpecified { get; set; }

		public SettingItem()
		{
			mDisplayType = SettingDisplayType.Range;
			mTitle = string.Empty;
			mDescription = string.Empty;
			mFunctionType = SettingFunctionType.ScreenResolution;
			mStoreLocation = SettingStoreLocation.Server;
			mDefaultFloat = -1f;
			mDefaultInt = -1;
		}
	}
}
