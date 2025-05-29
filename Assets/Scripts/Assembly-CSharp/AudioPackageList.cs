using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

[Serializable]
public class AudioPackageList
{
	public const string AUDIO_PACKAGE_ELEMENT_NAME = "AudioPackage";

	public const string AUDIO_PACKAGE_NAME_ATTR_NAME = "name";

	[XmlElement(ElementName = "AudioPackage")]
	public string[] m_packages;

	public AudioPackageList()
	{
	}

	public AudioPackageList(IEnumerable<string> c99e3d0b4ce51c8a7f689a835d475a34b)
	{
		m_packages = c99e3d0b4ce51c8a7f689a835d475a34b.ToArray();
	}
}
