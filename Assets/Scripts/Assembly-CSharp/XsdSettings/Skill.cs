using System.Xml.Serialization;

namespace XsdSettings
{
	public class Skill
	{
		private Effect[] m_effectListField;

		public int m_id { get; set; }

		public string m_icon { get; set; }

		public string m_name { get; set; }

		public string m_description { get; set; }

		public int m_maxGrade { get; set; }

		[XmlArrayItem("m_effect", IsNullable = false)]
		public Effect[] m_effectList { get; set; }
	}
}
