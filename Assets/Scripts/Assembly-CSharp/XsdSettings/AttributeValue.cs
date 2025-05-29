using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace XsdSettings
{
	[XmlInclude(typeof(IntAttributeValue))]
	[XmlInclude(typeof(FloatAttributeValue))]
	public class AttributeValue : ICloneable
	{
		public AttributeValueType m_type { get; set; }

		public AffectType m_affectType { get; set; }

		public AttributeValue()
		{
			m_type = AttributeValueType.AttributeValue;
			m_affectType = AffectType.Scale;
		}

		public object Clone()
		{
			return (AttributeValue)MemberwiseClone();
		}

		public virtual void c3aab97bb9df3bfa336aa8aa4fde7e801(float c5ebdc65d5cb420faf7ba524809963aa9, float c07549ee2efd384827eea57c5cd016d41, float c52921fe9488ee3d539be727c81094423)
		{
			throw new NotImplementedException();
		}

		public virtual void c9c04395301e0ad43dd772719c88b33d9(List<AttributeValue> c139fd184a4f510ff0a4311566ad755e9)
		{
			throw new NotImplementedException();
		}

		public virtual void c651a84d619af0768400f8763b8926673(AttributeValue cefda2fdc3ce4e04f38bab77fc7998241)
		{
			throw new NotImplementedException();
		}

		public override string ToString()
		{
			return m_type.ToString();
		}

		public virtual void cd1109b7ea29846a9735888dcb26a97fe(float cefda2fdc3ce4e04f38bab77fc7998241)
		{
			throw new NotImplementedException();
		}

		public virtual float c4e0f63f4b4d409c5e3992c71520e30a0()
		{
			throw new NotImplementedException();
		}
	}
}
