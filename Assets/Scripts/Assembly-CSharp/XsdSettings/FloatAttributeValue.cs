using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace XsdSettings
{
	public class FloatAttributeValue : AttributeValue
	{
		public float m_value { get; set; }

		public FloatAttributeValue()
		{
			base.m_type = AttributeValueType.FloatAttributeValue;
			m_value = 0f;
		}

		public override void c3aab97bb9df3bfa336aa8aa4fde7e801(float c5ebdc65d5cb420faf7ba524809963aa9, float c07549ee2efd384827eea57c5cd016d41, float c52921fe9488ee3d539be727c81094423)
		{
			m_value *= Mathf.Pow(c5ebdc65d5cb420faf7ba524809963aa9, c07549ee2efd384827eea57c5cd016d41) + c52921fe9488ee3d539be727c81094423;
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
					FloatAttributeValue floatAttributeValue = (FloatAttributeValue)current;
					if (floatAttributeValue.m_affectType == AffectType.Scale)
					{
						while (true)
						{
							switch (5)
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
						if (floatAttributeValue.m_value > 0f)
						{
							while (true)
							{
								switch (1)
								{
								case 0:
									continue;
								}
								break;
							}
							num2 += floatAttributeValue.m_value;
						}
						else
						{
							num += floatAttributeValue.m_value;
						}
					}
					if (floatAttributeValue.m_affectType == AffectType.PostAdd)
					{
						while (true)
						{
							switch (6)
							{
							case 0:
								continue;
							}
							break;
						}
						num4 += floatAttributeValue.m_value;
					}
					if (floatAttributeValue.m_affectType != 0)
					{
						continue;
					}
					while (true)
					{
						switch (2)
						{
						case 0:
							continue;
						}
						break;
					}
					num3 += floatAttributeValue.m_value;
				}
				while (true)
				{
					switch (7)
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
			m_value = (m_value + num3) * ((1f + num2) / (1f - num)) + num4;
		}

		public override void c651a84d619af0768400f8763b8926673(AttributeValue cefda2fdc3ce4e04f38bab77fc7998241)
		{
			if (cefda2fdc3ce4e04f38bab77fc7998241 is FloatAttributeValue)
			{
				while (true)
				{
					switch (6)
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
				m_value = floatAttributeValue.m_value;
				base.m_affectType = floatAttributeValue.m_affectType;
			}
			if (!(cefda2fdc3ce4e04f38bab77fc7998241 is IntAttributeValue))
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
			m_value = cefda2fdc3ce4e04f38bab77fc7998241;
		}

		public override float c4e0f63f4b4d409c5e3992c71520e30a0()
		{
			return m_value;
		}

		[SpecialName]
		public static float c00ae05b9ced94c9fc5f4be4892e6192b(FloatAttributeValue cf0ecbb9b13151932b8293691a84d1c24)
		{
			return cf0ecbb9b13151932b8293691a84d1c24.m_value;
		}
	}
}
