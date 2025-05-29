using System;
using System.Xml;
using UnityEngine;

[Serializable]
[ExecuteInEditMode]
public abstract class NamedUniqueAudioObject : UniqueAudioObject
{
	protected string m_name = "New Object";

	private static readonly string NAME_ATTR = "Name";

	private static readonly string GUID_ATTR = "GUID";

	public virtual string Name
	{
		get
		{
			return m_name;
		}
		set
		{
			m_name = value;
		}
	}

	protected NamedUniqueAudioObject(Guid c35f98ccbfa8c6bf09319c620b21b5dc5, string cd99af21e22e356018b8f72d4a7e4872a)
		: base(c35f98ccbfa8c6bf09319c620b21b5dc5)
	{
		m_name = cd99af21e22e356018b8f72d4a7e4872a;
	}

	protected NamedUniqueAudioObject(string cd99af21e22e356018b8f72d4a7e4872a)
	{
		m_name = cd99af21e22e356018b8f72d4a7e4872a;
	}

	protected NamedUniqueAudioObject()
	{
	}

	public virtual void cc09306479ed0f9f54a5e4e8dd8d72b99(XmlNode cab83bba925e6355b7d0df9fe7c31c6e1)
	{
		Name = cab83bba925e6355b7d0df9fe7c31c6e1.Attributes[NAME_ATTR].Value.ToString();
		c38b0293f2e32959475dd3d81f2e1822a(new Guid(cab83bba925e6355b7d0df9fe7c31c6e1.Attributes[GUID_ATTR].Value.ToString()));
	}

	public virtual void c9742307d0830ac7381f2acd66ed5a6e2(XmlElement cab83bba925e6355b7d0df9fe7c31c6e1)
	{
		cab83bba925e6355b7d0df9fe7c31c6e1.SetAttribute(NAME_ATTR, Name);
		cab83bba925e6355b7d0df9fe7c31c6e1.SetAttribute(GUID_ATTR, base.guid.ToString());
	}
}
