using System.Xml.Serialization;

namespace XsdSettings
{
	public class UI_WeaponCraftConfigContainer
	{
		private UI_WeaponCraftConfig[] uI_WeaponCraftConfigListField;

		[XmlArrayItem(IsNullable = false)]
		public UI_WeaponCraftConfig[] UI_WeaponCraftConfigList { get; set; }
	}
}
