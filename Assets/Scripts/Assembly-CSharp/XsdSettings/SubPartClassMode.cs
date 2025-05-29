namespace XsdSettings
{
	public class SubPartClassMode
	{
		private ClassModeType m_classModeTypeField;

		private ClassModeSubPart m_subpartTypeField;

		private AffectType m_affectTypeField;

		private EffectType m_classModeAttributeField;

		public ClassModeType m_classModeType { get; set; }

		public ClassModeSubPart m_subpartType { get; set; }

		public int m_index { get; set; }

		public float m_attributeValue { get; set; }

		public AffectType m_affectType { get; set; }

		public EffectType m_classModeAttribute { get; set; }

		public string m_partName { get; set; }

		public int m_namePriority { get; set; }

		public override int GetHashCode()
		{
			return cab05c97ab6dee558edc49d79f6a92ed1(m_classModeType, m_subpartType, m_index);
		}

		public static int cab05c97ab6dee558edc49d79f6a92ed1(ClassModeType cb60928ef9d0be0bfc6010c7fcf5f6ab7, ClassModeSubPart c4b66d9e492c5b1f14c95e7b40efbdf98, int c5612a459a84ffdb41c885401433cd62d)
		{
			int num = (int)((ClassModeType)255 & cb60928ef9d0be0bfc6010c7fcf5f6ab7);
			num <<= 8;
			num |= (int)((ClassModeSubPart)255 & c4b66d9e492c5b1f14c95e7b40efbdf98);
			num <<= 16;
			return num | (0xFFFF & (short)c5612a459a84ffdb41c885401433cd62d);
		}
	}
}
