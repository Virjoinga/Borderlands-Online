using System.ComponentModel;
using System.Xml.Serialization;
using A;

namespace XsdSettings
{
	public class SubPartWpn
	{
		private BuildingPart m_BuildingPartField;

		private BOLAttribute[] m_AttributesField;

		public int m_Index { get; set; }

		public WeaponType m_weaponType { get; set; }

		public WeaponSubPart m_partType { get; set; }

		public BuildingPart m_BuildingPart { get; set; }

		[DefaultValue("")]
		public string m_partName { get; set; }

		[DefaultValue(0)]
		public int m_namePriority { get; set; }

		[DefaultValue("")]
		public string m_redline { get; set; }

		[DefaultValue(0)]
		public int m_redlinePriority { get; set; }

		[XmlArrayItem("m_attribute", IsNullable = false)]
		public BOLAttribute[] m_Attributes { get; set; }

		public SubPartWpn(WeaponType ceccaa67e17deb18ec7c67b2cb86757de, WeaponSubPart c740fb87e58adaf9671b066d0900f1176)
		{
			m_Index = 0;
			m_weaponType = ceccaa67e17deb18ec7c67b2cb86757de;
			m_partType = c740fb87e58adaf9671b066d0900f1176;
		}

		public SubPartWpn(SubPartWpn c740fb87e58adaf9671b066d0900f1176)
		{
			m_Index = c740fb87e58adaf9671b066d0900f1176.m_Index;
			m_weaponType = c740fb87e58adaf9671b066d0900f1176.m_weaponType;
			m_partType = c740fb87e58adaf9671b066d0900f1176.m_partType;
			m_Attributes = c507bbd74718b0292bc9a38cabdac42fe.c0a0cdf4a196914163f7334d9b0781a04(c740fb87e58adaf9671b066d0900f1176.m_Attributes.Length);
			for (int i = 0; i < c740fb87e58adaf9671b066d0900f1176.m_Attributes.Length; i++)
			{
				m_Attributes[i] = new BOLAttribute(c740fb87e58adaf9671b066d0900f1176.m_Attributes[i]);
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				return;
			}
		}

		public SubPartWpn()
		{
			m_Index = 0;
			m_weaponType = WeaponType.SMG;
			m_partType = WeaponSubPart.ACC;
			m_partName = string.Empty;
			m_namePriority = 0;
			m_redline = string.Empty;
			m_redlinePriority = 0;
		}

		public override int GetHashCode()
		{
			return cab05c97ab6dee558edc49d79f6a92ed1(m_weaponType, m_partType, m_Index);
		}

		public static WeaponType ccf6c15dffba5e0dd8c87e3162699a671(int c875cb4aedab4dbd285f491b3440727ec)
		{
			c875cb4aedab4dbd285f491b3440727ec >>= 24;
			c875cb4aedab4dbd285f491b3440727ec &= 0xFF;
			return (WeaponType)c875cb4aedab4dbd285f491b3440727ec;
		}

		public static int cab05c97ab6dee558edc49d79f6a92ed1(WeaponType c4377262dd7fb8935a8214f6610cfb066, WeaponSubPart cb0ca9dede0c248c3a590cdb1af344863, int c5612a459a84ffdb41c885401433cd62d)
		{
			int num = (int)((WeaponType)255 & c4377262dd7fb8935a8214f6610cfb066);
			num <<= 8;
			num |= (int)((WeaponSubPart)255 & cb0ca9dede0c248c3a590cdb1af344863);
			num <<= 16;
			return num | (0xFFFF & (short)c5612a459a84ffdb41c885401433cd62d);
		}

		public override bool Equals(object obj)
		{
			SubPartWpn subPartWpn = obj as SubPartWpn;
			if (subPartWpn != null)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (subPartWpn.GetHashCode() == GetHashCode())
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							return true;
						}
					}
				}
			}
			return false;
		}

		public bool c8bcc550da88694617c77beaecf52f7ae(WeaponSubPart cdfac2ca8e4e1f50612512a48205b3634)
		{
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (cdfac2ca8e4e1f50612512a48205b3634 != WeaponSubPart.MATERIAL)
				{
					return false;
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
			}
			return true;
		}

		public bool ca4c3620c6946b4ca465b7914dcd6a668(WeaponSubPart cdfac2ca8e4e1f50612512a48205b3634)
		{
			if (cdfac2ca8e4e1f50612512a48205b3634 != WeaponSubPart.GRIP)
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
				if (cdfac2ca8e4e1f50612512a48205b3634 != WeaponSubPart.BARREL)
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
					if (cdfac2ca8e4e1f50612512a48205b3634 != WeaponSubPart.BODY)
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
						if (cdfac2ca8e4e1f50612512a48205b3634 != WeaponSubPart.MAG)
						{
							return false;
						}
						while (true)
						{
							switch (4)
							{
							case 0:
								continue;
							}
							break;
						}
					}
				}
			}
			return true;
		}
	}
}
