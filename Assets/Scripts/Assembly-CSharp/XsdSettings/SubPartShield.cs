namespace XsdSettings
{
	public class SubPartShield
	{
		private ShieldSubPart m_subpartTypeField;

		private ShieldAttributeType m_shieldAttributeField;

		private AffectType m_affectTypeField;

		public ShieldSubPart m_subpartType { get; set; }

		public int m_index { get; set; }

		public string m_partName { get; set; }

		public ShieldAttributeType m_shieldAttribute { get; set; }

		public AffectType m_affectType { get; set; }

		public float m_attributeValue { get; set; }

		public int m_namePriority { get; set; }

		public override int GetHashCode()
		{
			return cab05c97ab6dee558edc49d79f6a92ed1(m_subpartType, m_index);
		}

		public static int cab05c97ab6dee558edc49d79f6a92ed1(ShieldSubPart c4b66d9e492c5b1f14c95e7b40efbdf98, int c5612a459a84ffdb41c885401433cd62d)
		{
			int num = (int)((ShieldSubPart)255 & c4b66d9e492c5b1f14c95e7b40efbdf98);
			num <<= 16;
			return num | (0xFFFF & (short)c5612a459a84ffdb41c885401433cd62d);
		}

		public bool c8bcc550da88694617c77beaecf52f7ae(ShieldSubPart cdfac2ca8e4e1f50612512a48205b3634)
		{
			if (cdfac2ca8e4e1f50612512a48205b3634 != ShieldSubPart.Battery)
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
				if (cdfac2ca8e4e1f50612512a48205b3634 != 0)
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
					if (cdfac2ca8e4e1f50612512a48205b3634 != ShieldSubPart.Capacitor)
					{
						return false;
					}
					while (true)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						break;
					}
				}
			}
			return true;
		}

		public bool ca4c3620c6946b4ca465b7914dcd6a668(ShieldSubPart cdfac2ca8e4e1f50612512a48205b3634)
		{
			if (cdfac2ca8e4e1f50612512a48205b3634 != ShieldSubPart.Accessory)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (cdfac2ca8e4e1f50612512a48205b3634 != ShieldSubPart.Material)
				{
					return false;
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			return true;
		}
	}
}
