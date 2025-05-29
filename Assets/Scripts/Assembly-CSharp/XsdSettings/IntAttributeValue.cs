using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace XsdSettings
{
	public class IntAttributeValue : AttributeValue
	{
		public int m_value { get; set; }

		public IntAttributeValue()
		{
			base.m_type = AttributeValueType.IntAttributeValue;
			m_value = 0;
		}

		public override void c9c04395301e0ad43dd772719c88b33d9(List<AttributeValue> c139fd184a4f510ff0a4311566ad755e9)
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			using (List<AttributeValue>.Enumerator enumerator = c139fd184a4f510ff0a4311566ad755e9.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					AttributeValue current = enumerator.Current;
					IntAttributeValue intAttributeValue = (IntAttributeValue)current;
					if (intAttributeValue.m_affectType == AffectType.Scale)
					{
						while (true)
						{
							switch (2)
							{
							case 0:
								continue;
							}
							break;
						}
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						if (intAttributeValue.m_value > 0)
						{
							while (true)
							{
								switch (4)
								{
								case 0:
									continue;
								}
								break;
							}
							num2 += (float)intAttributeValue.m_value;
						}
						else
						{
							num += (float)intAttributeValue.m_value;
						}
					}
					if (intAttributeValue.m_affectType == AffectType.PostAdd)
					{
						while (true)
						{
							switch (3)
							{
							case 0:
								continue;
							}
							break;
						}
						num4 += (float)intAttributeValue.m_value;
					}
					if (intAttributeValue.m_affectType != 0)
					{
						continue;
					}
					while (true)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						break;
					}
					num3 += (float)intAttributeValue.m_value;
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						goto end_IL_00df;
					}
					continue;
					end_IL_00df:
					break;
				}
			}
			m_value = (int)(((float)m_value + num3) * ((1f + num2) / (1f - num)) + num4);
		}

		public override void c651a84d619af0768400f8763b8926673(AttributeValue cefda2fdc3ce4e04f38bab77fc7998241)
		{
			if (cefda2fdc3ce4e04f38bab77fc7998241 is FloatAttributeValue)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				FloatAttributeValue floatAttributeValue = (FloatAttributeValue)cefda2fdc3ce4e04f38bab77fc7998241;
				m_value = (int)floatAttributeValue.m_value;
				base.m_affectType = floatAttributeValue.m_affectType;
			}
			if (!(cefda2fdc3ce4e04f38bab77fc7998241 is IntAttributeValue))
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
				IntAttributeValue intAttributeValue = (IntAttributeValue)cefda2fdc3ce4e04f38bab77fc7998241;
				m_value = intAttributeValue.m_value;
				base.m_affectType = intAttributeValue.m_affectType;
				return;
			}
		}

		public override string ToString()
		{
			return base.m_type.ToString() + "_" + m_value;
		}

		public override void cd1109b7ea29846a9735888dcb26a97fe(float cefda2fdc3ce4e04f38bab77fc7998241)
		{
			m_value = (int)cefda2fdc3ce4e04f38bab77fc7998241;
		}

		public override float c4e0f63f4b4d409c5e3992c71520e30a0()
		{
			return m_value;
		}

		[SpecialName]
		public static int c00ae05b9ced94c9fc5f4be4892e6192b(IntAttributeValue cf0ecbb9b13151932b8293691a84d1c24)
		{
			return cf0ecbb9b13151932b8293691a84d1c24.m_value;
		}
	}
}
