using System.Xml.Serialization;

namespace XsdSettings
{
	public class UI_WeaponCraftConfig
	{
		public int Stage { get; set; }

		public int DisplayLevel { get; set; }

		[XmlArrayItem("WeaponID", IsNullable = false)]
		public int[] Weapons { get; set; }

		public UI_WeaponCraftConfig()
		{
			Stage = 0;
			DisplayLevel = 0;
		}
	}
}
