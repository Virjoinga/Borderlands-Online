using System;
using System.Xml.Serialization;

[Serializable]
public class PlayerResources
{
	[Serializable]
	public class BundleSet
	{
		[XmlAttribute(AttributeName = "Type")]
		public string m_type;

		[XmlElement(ElementName = "Bundle")]
		public string[] m_bundles;
	}

	[XmlElement(ElementName = "Common")]
	public BundleSet m_commonBundleSet;

	[XmlElement(ElementName = "ClassSpecific")]
	public BundleSet[] m_classSpecificBundleSets = new BundleSet[4];

	[XmlElement(ElementName = "LocalPlayer")]
	public BundleSet[] m_localPlayerBundleSets = new BundleSet[4];

	[XmlElement(ElementName = "CommonTown")]
	public BundleSet m_commonTownBundleSet;

	[XmlElement(ElementName = "PlayerTown")]
	public BundleSet[] m_playerTownBundleSets = new BundleSet[4];
}
