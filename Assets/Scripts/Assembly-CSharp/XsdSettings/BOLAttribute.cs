namespace XsdSettings
{
	public class BOLAttribute
	{
		private AttributeValue m_attributeValueField;

		public AttributeType m_attributeType { get; set; }

		public AttributeValue m_attributeValue { get; set; }

		public BOLAttribute(AttributeType c3607af875c43c841d5ae8a29c4e6728c)
		{
			m_attributeType = c3607af875c43c841d5ae8a29c4e6728c;
			m_attributeValue = AttributeStore.attributeStore.ced9ccbb2ae629d205bc0aeebee27f84b(c3607af875c43c841d5ae8a29c4e6728c);
		}

		public BOLAttribute(BOLAttribute c6a2022d96d7ebb4ce1c1ca2a00e339e6)
		{
			m_attributeType = c6a2022d96d7ebb4ce1c1ca2a00e339e6.m_attributeType;
			m_attributeValue = (AttributeValue)c6a2022d96d7ebb4ce1c1ca2a00e339e6.m_attributeValue.Clone();
		}

		public BOLAttribute()
		{
			m_attributeType = AttributeType.None;
		}

		public virtual void c44f9e79fa85546625edd2986a4083fbf()
		{
			if (m_attributeValue == null)
			{
				return;
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (AttributeStore.attributeStore.ccf8b867ebe626fbd9a2992c0ef6fa576(m_attributeType) == m_attributeValue.m_type)
				{
					return;
				}
				while (true)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					m_attributeValue = AttributeStore.attributeStore.ced9ccbb2ae629d205bc0aeebee27f84b(m_attributeType, m_attributeValue);
					return;
				}
			}
		}
	}
}
