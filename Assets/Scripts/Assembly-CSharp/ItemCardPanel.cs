using System.Collections.Generic;
using System.Text;
using A;
using UnityEngine;
using XsdSettings;
using pumpkin.display;

public class ItemCardPanel : c196099a1254db61d3be10d70e14e7422
{
	protected ItemTipsPanel _cardPanel;

	protected ItemTipsPanel _comparePanel;

	protected ItemDNA _showItem;

	protected ItemDNA _compareItem;

	protected float rightPosX;

	protected float leftPosX;

	public void c2bc47b1e29f7a6270d8c07e700f9a474()
	{
		_comparePanel.c89ef242f4744e0f1c4ffea4da8b79bc1.x = 0f;
		_cardPanel.c89ef242f4744e0f1c4ffea4da8b79bc1.x = rightPosX;
		DisplayObjectContainer displayObjectContainer = _cardPanel.c89ef242f4744e0f1c4ffea4da8b79bc1;
		bool visible = true;
		_comparePanel.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = visible;
		displayObjectContainer.visible = visible;
	}

	public void cdb8cb55fc5bf99fb5dd2235d0d25463a(bool c231126bbfcc1f6c7accfc02fbd905b3b)
	{
		if (_compareItem != null)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					if (c231126bbfcc1f6c7accfc02fbd905b3b)
					{
						while (true)
						{
							switch (6)
							{
							case 0:
								break;
							default:
								_cardPanel.c89ef242f4744e0f1c4ffea4da8b79bc1.x = 0f;
								_comparePanel.c89ef242f4744e0f1c4ffea4da8b79bc1.x = rightPosX;
								return;
							}
						}
					}
					_comparePanel.c89ef242f4744e0f1c4ffea4da8b79bc1.x = 0f;
					_cardPanel.c89ef242f4744e0f1c4ffea4da8b79bc1.x = rightPosX;
					return;
				}
			}
		}
		_cardPanel.c89ef242f4744e0f1c4ffea4da8b79bc1.x = 0f;
		_comparePanel.c89ef242f4744e0f1c4ffea4da8b79bc1.x = rightPosX;
	}

	public virtual void cd351226c5175db6eab2a3dd9ec9ff57c(MovieClip c59a247e42dc696f4409f74cfa6b6515b)
	{
		_cardPanel = new ItemTipsPanel();
		_cardPanel.c130648b59a0c8debea60aa153f844879(c59a247e42dc696f4409f74cfa6b6515b);
		_comparePanel = new ItemTipsPanel();
		_comparePanel.c130648b59a0c8debea60aa153f844879(c59a247e42dc696f4409f74cfa6b6515b.newInstance());
		if (ca37fcdce7d4937b60735f4033eb55695 == null)
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
			ca37fcdce7d4937b60735f4033eb55695 = new MovieClip();
		}
		DisplayObjectContainer displayObjectContainer = ca37fcdce7d4937b60735f4033eb55695;
		float num = 0f;
		ca37fcdce7d4937b60735f4033eb55695.y = num;
		displayObjectContainer.x = num;
		ca37fcdce7d4937b60735f4033eb55695.addChild(_comparePanel.c89ef242f4744e0f1c4ffea4da8b79bc1);
		ca37fcdce7d4937b60735f4033eb55695.addChild(_cardPanel.c89ef242f4744e0f1c4ffea4da8b79bc1);
		(ca37fcdce7d4937b60735f4033eb55695 as MovieClip).mouseEnabled = false;
		(ca37fcdce7d4937b60735f4033eb55695 as MovieClip).mouseChildrenEnabled = false;
		rightPosX = _cardPanel.c89ef242f4744e0f1c4ffea4da8b79bc1.width - 14f;
		_comparePanel.c89ef242f4744e0f1c4ffea4da8b79bc1.x += rightPosX;
	}

	public virtual void c58de56793cb96a279858c7b68a326d17(ItemDNA ca57e1c076c01141c5ce58c7341db7833, ItemDNA cd7c0d36f2c73807ca9525013ef524075)
	{
		_showItem = ca57e1c076c01141c5ce58c7341db7833;
		_compareItem = cd7c0d36f2c73807ca9525013ef524075;
		if (_compareItem == _showItem)
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
			_compareItem = c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e;
		}
		if (_showItem != null)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					ca37fcdce7d4937b60735f4033eb55695.visible = true;
					c99ac8131fcc91e2930bd187de9d69a9e();
					return;
				}
			}
		}
		ca37fcdce7d4937b60735f4033eb55695.visible = false;
	}

	public void c99ac8131fcc91e2930bd187de9d69a9e()
	{
		ItemTipsData itemTipsData = cbc738f422522aa6184fa54cfc686885a.c7088de59e49f7108f520cf7e0bae167e;
		ItemTipsData itemTipsData2 = cbc738f422522aa6184fa54cfc686885a.c7088de59e49f7108f520cf7e0bae167e;
		switch (_showItem.m_type)
		{
		case ItemType.Weapon:
		{
			WeaponDNA weaponDNA;
			if (_compareItem == null)
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
				weaponDNA = cc607e9943fa3c5044ada833720c23c9a.c7088de59e49f7108f520cf7e0bae167e;
			}
			else
			{
				weaponDNA = _compareItem.ca79da172938fdc8c067fb64242b6174a();
			}
			WeaponDNA weaponDNA2 = weaponDNA;
			WeaponDNA c8e4449729799306211c95fcee7653c = _showItem.ca79da172938fdc8c067fb64242b6174a();
			itemTipsData = cfa5ab8a3a1b0bbe4ab6ea32a3cbe648e(c8e4449729799306211c95fcee7653c, weaponDNA2);
			itemTipsData.price = _showItem.m_price;
			itemTipsData.item = _showItem;
			if (weaponDNA2 == null)
			{
				break;
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
			itemTipsData2 = cfa5ab8a3a1b0bbe4ab6ea32a3cbe648e(weaponDNA2);
			itemTipsData2.item = _compareItem;
			itemTipsData2.bEquiped = true;
			itemTipsData2.price = _compareItem.m_price;
			break;
		}
		case ItemType.Shield:
		{
			ShieldDNA shieldDNA;
			if (_compareItem == null)
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
				shieldDNA = c26b1d577ac9c0da502ba2980efb9fbde.c7088de59e49f7108f520cf7e0bae167e;
			}
			else
			{
				shieldDNA = _compareItem.c8e074b9d0135ff808166cc324407f74c();
			}
			ShieldDNA shieldDNA2 = shieldDNA;
			ShieldDNA shieldDNA3 = _showItem.c8e074b9d0135ff808166cc324407f74c();
			itemTipsData = cf74c938f1a684c82bbed16edbccc998f(shieldDNA3, shieldDNA2);
			itemTipsData.price = _showItem.m_price;
			itemTipsData.item = _showItem;
			if (shieldDNA2 == null)
			{
				break;
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
			itemTipsData2 = cf74c938f1a684c82bbed16edbccc998f(shieldDNA2, shieldDNA3);
			itemTipsData2.item = _compareItem;
			itemTipsData2.bEquiped = true;
			itemTipsData2.price = _compareItem.m_price;
			break;
		}
		case ItemType.Material:
			itemTipsData = new ItemTipsData();
			itemTipsData.name = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(_showItem.m_materialType.ToString()));
			itemTipsData.price = _showItem.m_price;
			itemTipsData.item = _showItem;
			break;
		case ItemType.ClassMode:
		{
			ClassModeDNA classModeDNA;
			if (_compareItem == null)
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
				classModeDNA = c6fa4f42bf72c2dd1857080a6c791c70f.c7088de59e49f7108f520cf7e0bae167e;
			}
			else
			{
				classModeDNA = _compareItem.c253c28f3a59bc5e5a528dfbb463a8a45();
			}
			ClassModeDNA classModeDNA2 = classModeDNA;
			ClassModeDNA classModeDNA3 = _showItem.c253c28f3a59bc5e5a528dfbb463a8a45();
			itemTipsData = ce1c8db90ec27ba2c8ea88570c0f2de9c(classModeDNA3, classModeDNA2);
			itemTipsData.price = _showItem.m_price;
			itemTipsData.item = _showItem;
			if (classModeDNA2 == null)
			{
				break;
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				break;
			}
			itemTipsData2 = ce1c8db90ec27ba2c8ea88570c0f2de9c(classModeDNA2, classModeDNA3);
			itemTipsData2.item = _compareItem;
			itemTipsData2.bEquiped = true;
			itemTipsData2.price = _compareItem.m_price;
			break;
		}
		}
		_cardPanel.c4415aa0606651420b103929644cf44bd(itemTipsData);
		_comparePanel.c4415aa0606651420b103929644cf44bd(itemTipsData2);
	}

	private static bool c1ed99e29c1b8b55558093b5f7577054b(AttributeType cf39b3e28036216b9dd77b3a379af25ba, List<SkillAttributeConfig> c47afe2d09d476c9451eea962083255f3, ref float ccc6172909026ff508df1593a9a533a0f)
	{
		float num = ccc6172909026ff508df1593a9a533a0f;
		if (cf39b3e28036216b9dd77b3a379af25ba == AttributeType.WeaponDamage)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					bool result = false;
					using (List<SkillAttributeConfig>.Enumerator enumerator = c47afe2d09d476c9451eea962083255f3.GetEnumerator())
					{
						for (; enumerator.MoveNext(); ccc6172909026ff508df1593a9a533a0f = num)
						{
							SkillAttributeConfig current = enumerator.Current;
							if (current.m_attrType != EffectType.BulletDamageScale)
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
								if (current.m_attrType != EffectType.BulletDamagePostAdd)
								{
									continue;
								}
								while (true)
								{
									switch (3)
									{
									case 0:
										continue;
									}
									break;
								}
							}
							if (current.m_affectType == AffectType.Scale)
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
								num += ccc6172909026ff508df1593a9a533a0f * current.m_attrValue;
							}
							else
							{
								num += current.m_attrValue;
							}
							result = true;
						}
						while (true)
						{
							switch (1)
							{
							case 0:
								break;
							default:
								return result;
							}
						}
					}
				}
				}
			}
		}
		using (List<SkillAttributeConfig>.Enumerator enumerator2 = c47afe2d09d476c9451eea962083255f3.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				SkillAttributeConfig current2 = enumerator2.Current;
				if (!(current2.m_attrType.ToString() == cf39b3e28036216b9dd77b3a379af25ba.ToString()))
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
					if (current2.m_attrType == EffectType.WeaponReloadSpeed)
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
						if (cf39b3e28036216b9dd77b3a379af25ba == AttributeType.ReloadTime)
						{
							goto IL_0146;
						}
						while (true)
						{
							switch (3)
							{
							case 0:
								continue;
							}
							break;
						}
					}
					if (current2.m_attrType == EffectType.ClipSize)
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
						if (cf39b3e28036216b9dd77b3a379af25ba == AttributeType.ClipSize)
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
							goto IL_0146;
						}
					}
					if (current2.m_attrType != EffectType.WeaponAccuracy)
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
					if (cf39b3e28036216b9dd77b3a379af25ba != AttributeType.AccuracyMax)
					{
						continue;
					}
					while (true)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						ccc6172909026ff508df1593a9a533a0f = 100f - num * (1f - current2.m_attrValue);
						return true;
					}
				}
				goto IL_0146;
				IL_0146:
				if (current2.m_affectType == AffectType.Scale)
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
					num += ccc6172909026ff508df1593a9a533a0f * current2.m_attrValue;
				}
				else
				{
					num += current2.m_attrValue;
				}
				ccc6172909026ff508df1593a9a533a0f = num;
				return true;
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					goto end_IL_01c8;
				}
				continue;
				end_IL_01c8:
				break;
			}
		}
		return false;
	}

	public static ItemTipsData cfa5ab8a3a1b0bbe4ab6ea32a3cbe648e(WeaponDNA c8e4449729799306211c95fcee7653c27, WeaponDNA c8886dc4027ad833d95b5e5919720ec29 = null, bool cfbe84ffd3ef5b29ec1c1e0810adf6adc = false)
	{
		ItemTipsData itemTipsData = new ItemTipsData();
		StringBuilder stringBuilder;
		EntityPlayer entityPlayer;
		WeaponAttribute attribute;
		WeaponAttribute weaponAttribute2;
		List<SkillAttributeConfig> c47afe2d09d476c9451eea962083255f;
		List<SkillAttributeConfig> c47afe2d09d476c9451eea962083255f2;
		bool flag2;
		int value;
		float num5;
		float num3;
		ItemElement itemElement;
		if (c8e4449729799306211c95fcee7653c27 != null)
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
			stringBuilder = new StringBuilder();
			entityPlayer = c709fa52dfb309bbfe248c9f258832331.c7088de59e49f7108f520cf7e0bae167e;
			if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				entityPlayer = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().c66b232dbebded7c7e9a89c1e8bd84689() as EntityPlayer;
			}
			itemTipsData.nameColor = UniUIManager.UniSWFToolClass.c87015237d139b95339567fd82054be1b(c8e4449729799306211c95fcee7653c27.m_rarity);
			itemTipsData.name = c8e4449729799306211c95fcee7653c27.c5f6245b591c90000d8430fc1ca8cc4de();
			int level;
			if (entityPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				level = entityPlayer.c9f4dd15e13b73ad690e986546c3286bc(c8e4449729799306211c95fcee7653c27.m_level);
			}
			else
			{
				level = c8e4449729799306211c95fcee7653c27.m_level;
			}
			itemTipsData.level = level;
			bool flag = c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c7513e66c4e0fc55e6fea9dd9cb8b9943() > c8e4449729799306211c95fcee7653c27.m_level;
			Color levelColor;
			if (flag)
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
				levelColor = Color.green;
			}
			else
			{
				levelColor = UniUIManager.UniSWFToolClass.c7fad7b5218f6951e51fe893390ef3e3c(c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c7513e66c4e0fc55e6fea9dd9cb8b9943(), c8e4449729799306211c95fcee7653c27.m_level);
			}
			itemTipsData.levelColor = levelColor;
			attribute = c8e4449729799306211c95fcee7653c27.m_attribute;
			WeaponAttribute weaponAttribute;
			if (c8886dc4027ad833d95b5e5919720ec29 == null)
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
				weaponAttribute = c71722c4194895927e64f2a4f0991fcca.c7088de59e49f7108f520cf7e0bae167e;
			}
			else
			{
				weaponAttribute = c8886dc4027ad833d95b5e5919720ec29.m_attribute;
			}
			weaponAttribute2 = weaponAttribute;
			c47afe2d09d476c9451eea962083255f = ExtraAttributeStore.c2e69c2ee08703c97ae2f380010f975a8.c7495388aceb7889e8ef8e2d021bdb97f(c8e4449729799306211c95fcee7653c27);
			c47afe2d09d476c9451eea962083255f2 = c64a21d00899c5d901cd458598ffd8992.c7088de59e49f7108f520cf7e0bae167e;
			int num;
			if (c8886dc4027ad833d95b5e5919720ec29 != null)
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
				num = ((c8886dc4027ad833d95b5e5919720ec29.m_type != c8e4449729799306211c95fcee7653c27.m_type) ? 1 : 0);
			}
			else
			{
				num = 1;
			}
			flag2 = (byte)num != 0;
			if (!flag2)
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
				c47afe2d09d476c9451eea962083255f2 = ExtraAttributeStore.c2e69c2ee08703c97ae2f380010f975a8.c7495388aceb7889e8ef8e2d021bdb97f(c8886dc4027ad833d95b5e5919720ec29);
			}
			if (!cfbe84ffd3ef5b29ec1c1e0810adf6adc)
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
				if (c8e4449729799306211c95fcee7653c27.m_starLevel > 0)
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
					itemElement = new ItemElement();
					itemElement.value = c8e4449729799306211c95fcee7653c27.m_starLevel;
					itemElement.eType = ETipsItemType.STAR;
					itemElement.arrow = "none";
					itemTipsData.attributeList.Add(itemElement);
				}
				int num2 = StarLevelAttributeStore.cecd5638d8f5bf49105ca7c28afbbfba4.c15e38327c5b5eed2c917ce1e8b78d24a(c8e4449729799306211c95fcee7653c27.c83e548e5608cd7f222098a6966b16545(), c8e4449729799306211c95fcee7653c27.m_starLevel, c8e4449729799306211c95fcee7653c27.m_level, c8e4449729799306211c95fcee7653c27.m_rarity);
				if (num2 > 0)
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
					itemElement = new ItemElement();
					stringBuilder.Append(LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Weapon_Upgrade_Requirement"))).Append(" ").Append(c8e4449729799306211c95fcee7653c27.m_starExperience)
						.Append("/")
						.Append(num2);
					itemElement.value = stringBuilder.ToString();
					itemElement.eType = ETipsItemType.TEXT;
					itemElement.arrow = "none";
					itemTipsData.attributeList.Add(itemElement);
				}
			}
			num3 = 0f;
			float num4 = 0f;
			itemElement = new ItemElement();
			value = (attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.WeaponProjectilesPerShot) as IntAttributeValue).m_value;
			num3 = (attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.WeaponDamage) as FloatAttributeValue).m_value;
			itemElement.aType = AttributeType.WeaponDamage;
			if (c1ed99e29c1b8b55558093b5f7577054b(AttributeType.WeaponDamage, c47afe2d09d476c9451eea962083255f, ref num3))
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
				itemElement.color = Color.green;
			}
			if (flag)
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
				if (entityPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					num5 = entityPlayer.c7cb1ac7f406fd6311968208ac9386b8b((int)num3);
					goto IL_034c;
				}
			}
			num5 = num3;
			goto IL_034c;
		}
		goto IL_0b8f;
		IL_0b8f:
		return itemTipsData;
		IL_034c:
		float num6 = num5;
		if (num6 > num3)
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
			itemElement.color = Color.green;
		}
		num3 = num6;
		if (value > 1)
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
			stringBuilder.Remove(0, stringBuilder.Length);
			stringBuilder.Append(value).Append(" x ").Append((num3 / (float)value).ToString("f1"));
			itemElement.value = stringBuilder.ToString();
		}
		else
		{
			itemElement.value = ((int)num3).ToString();
		}
		itemElement.eType = ETipsItemType.ITVA;
		if (flag2)
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
			itemElement.arrow = "none";
		}
		else
		{
			float num4 = (weaponAttribute2.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.WeaponDamage) as FloatAttributeValue).m_value;
			c1ed99e29c1b8b55558093b5f7577054b(AttributeType.WeaponDamage, c47afe2d09d476c9451eea962083255f2, ref num4);
			itemElement.arrow = UniUIManager.UniSWFToolClass.c829860ccd1c2bd1526f02a4101640f7a(num3, num4, 1);
		}
		itemElement.iconType = AttributeType.WeaponDamage.ToString();
		itemElement.title = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("WC_AttDesc_0"));
		itemTipsData.attributeList.Add(itemElement);
		itemElement = new ItemElement();
		num3 = attribute.c2d32d874e045788b400f1b8bfd71f5f0();
		itemElement.aType = AttributeType.AccuracyMax;
		if (c1ed99e29c1b8b55558093b5f7577054b(AttributeType.AccuracyMax, c47afe2d09d476c9451eea962083255f, ref num3))
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
			itemElement.color = Color.green;
		}
		itemElement.value = num3.ToString("f1");
		if (flag2)
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
			itemElement.arrow = "none";
		}
		else
		{
			float num4 = weaponAttribute2.c2d32d874e045788b400f1b8bfd71f5f0();
			c1ed99e29c1b8b55558093b5f7577054b(AttributeType.AccuracyMax, c47afe2d09d476c9451eea962083255f2, ref num4);
			itemElement.arrow = UniUIManager.UniSWFToolClass.c829860ccd1c2bd1526f02a4101640f7a(num3, num4);
		}
		itemElement.iconType = "accuracy";
		itemElement.eType = ETipsItemType.ITVA;
		itemElement.title = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("WC_AttDesc_1"));
		itemTipsData.attributeList.Add(itemElement);
		itemElement = new ItemElement();
		num3 = (attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.FireRate) as FloatAttributeValue).m_value;
		itemElement.aType = AttributeType.FireRate;
		if (c1ed99e29c1b8b55558093b5f7577054b(AttributeType.FireRate, c47afe2d09d476c9451eea962083255f, ref num3))
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
			itemElement.color = Color.green;
		}
		itemElement.value = num3.ToString("f1");
		if (flag2)
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
			itemElement.arrow = "none";
		}
		else
		{
			float num4 = (weaponAttribute2.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.FireRate) as FloatAttributeValue).m_value;
			c1ed99e29c1b8b55558093b5f7577054b(AttributeType.FireRate, c47afe2d09d476c9451eea962083255f2, ref num4);
			itemElement.arrow = UniUIManager.UniSWFToolClass.c829860ccd1c2bd1526f02a4101640f7a(num3, num4);
		}
		itemElement.iconType = AttributeType.FireRate.ToString();
		itemElement.eType = ETipsItemType.ITVA;
		itemElement.title = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("WC_AttDesc_2"));
		itemTipsData.attributeList.Add(itemElement);
		itemElement = new ItemElement();
		num3 = (attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ReloadTime) as FloatAttributeValue).m_value;
		itemElement.aType = AttributeType.ReloadTime;
		if (c1ed99e29c1b8b55558093b5f7577054b(AttributeType.ReloadTime, c47afe2d09d476c9451eea962083255f, ref num3))
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
			itemElement.color = Color.green;
		}
		itemElement.value = num3.ToString("f1");
		if (flag2)
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
			itemElement.arrow = "none";
		}
		else
		{
			float num4 = (weaponAttribute2.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ReloadTime) as FloatAttributeValue).m_value;
			c1ed99e29c1b8b55558093b5f7577054b(AttributeType.ReloadTime, c47afe2d09d476c9451eea962083255f2, ref num4);
			itemElement.arrow = UniUIManager.UniSWFToolClass.c829860ccd1c2bd1526f02a4101640f7a(num4, num3);
		}
		itemElement.iconType = AttributeType.ReloadTime.ToString();
		itemElement.eType = ETipsItemType.ITVA;
		itemElement.title = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("WC_AttDesc_3"));
		itemTipsData.attributeList.Add(itemElement);
		itemElement = new ItemElement();
		num3 = (attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ClipSize) as IntAttributeValue).m_value;
		itemElement.aType = AttributeType.ClipSize;
		if (c1ed99e29c1b8b55558093b5f7577054b(AttributeType.ClipSize, c47afe2d09d476c9451eea962083255f, ref num3))
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
			itemElement.color = Color.green;
		}
		itemElement.value = ((int)num3).ToString();
		if (flag2)
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
			itemElement.arrow = "none";
		}
		else
		{
			float num4 = (weaponAttribute2.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ClipSize) as IntAttributeValue).m_value;
			c1ed99e29c1b8b55558093b5f7577054b(AttributeType.ClipSize, c47afe2d09d476c9451eea962083255f2, ref num4);
			itemElement.arrow = UniUIManager.UniSWFToolClass.c829860ccd1c2bd1526f02a4101640f7a(num3, num4);
		}
		itemElement.iconType = AttributeType.ClipSize.ToString();
		itemElement.eType = ETipsItemType.ITVA;
		itemElement.title = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("WC_AttDesc_4"));
		itemTipsData.attributeList.Add(itemElement);
		itemTipsData.brand = UniUIManager.UniSWFToolClass._BrandStringMap[(attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ManufactureType) as IntAttributeValue).m_value];
		AttackInfo.ElementalType value2 = (AttackInfo.ElementalType)(attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ElementalType) as IntAttributeValue).m_value;
		if (value2 != 0)
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
			itemElement = new ItemElement();
			itemElement.value = (attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.WeaponElementalDamage) as FloatAttributeValue).m_value.ToString("f1");
			num3 = (attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.WeaponElementalDamage) as FloatAttributeValue).m_value;
			float num7;
			if (entityPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				num7 = entityPlayer.c7cb1ac7f406fd6311968208ac9386b8b((int)num3);
			}
			else
			{
				num7 = num3;
			}
			num6 = num7;
			if (num6 > num3)
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
				itemElement.color = Color.green;
			}
			num3 = num6;
			itemElement.value = num3.ToString("f1");
			itemElement.aType = AttributeType.WeaponElementalDamage;
			if (flag2)
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
				itemElement.arrow = "none";
			}
			else
			{
				itemElement.arrow = UniUIManager.UniSWFToolClass.c829860ccd1c2bd1526f02a4101640f7a((attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.WeaponElementalDamage) as FloatAttributeValue).m_value, (weaponAttribute2.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.WeaponElementalDamage) as FloatAttributeValue).m_value);
			}
			itemElement.iconType = "element" + value2;
			itemElement.eType = ETipsItemType.ITVA;
			itemElement.title = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("WC_AttDesc_5"));
			itemTipsData.attributeList.Add(itemElement);
			itemElement = new ItemElement();
			itemElement.value = (attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ElementalProcCoef) as FloatAttributeValue).m_value.ToString("p0");
			itemElement.aType = AttributeType.ElementalProcCoef;
			if (flag2)
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
				itemElement.arrow = "none";
			}
			else
			{
				itemElement.arrow = UniUIManager.UniSWFToolClass.c829860ccd1c2bd1526f02a4101640f7a((attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ElementalProcCoef) as FloatAttributeValue).m_value, (weaponAttribute2.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ElementalProcCoef) as FloatAttributeValue).m_value);
			}
			itemElement.iconType = "element" + value2;
			itemElement.eType = ETipsItemType.ITVA;
			itemElement.title = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("WC_AttDesc_6"));
			itemTipsData.attributeList.Add(itemElement);
		}
		Dictionary<string, WeaponCardDisplayType> dictionary = c8e4449729799306211c95fcee7653c27.cefb40e06b60c8f7c43d5935ac57ba968();
		if (dictionary != null)
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
			using (Dictionary<string, WeaponCardDisplayType>.Enumerator enumerator = dictionary.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<string, WeaponCardDisplayType> current = enumerator.Current;
					itemElement = new ItemElement();
					itemElement.value = current.Key;
					itemElement.color = UniUIManager.UniSWFToolClass.c4e58bbb395c6e7f02f6d88d05f41b180(current.Value);
					itemElement.eType = ETipsItemType.TEXT;
					itemElement.arrow = "none";
					itemTipsData.additionAttList.Add(itemElement);
				}
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						goto end_IL_0b76;
					}
					continue;
					end_IL_0b76:
					break;
				}
			}
		}
		goto IL_0b8f;
	}

	public ItemTipsData cf74c938f1a684c82bbed16edbccc998f(ShieldDNA cc3903659f6abf884e4709091f9206475, ShieldDNA cc5911fb91e9ef8ae7e39b1c801f365be = null)
	{
		ItemTipsData itemTipsData = new ItemTipsData();
		if (cc3903659f6abf884e4709091f9206475 != null)
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
			EntityPlayer entityPlayer = c709fa52dfb309bbfe248c9f258832331.c7088de59e49f7108f520cf7e0bae167e;
			if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				entityPlayer = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().c66b232dbebded7c7e9a89c1e8bd84689() as EntityPlayer;
			}
			itemTipsData.name = cc3903659f6abf884e4709091f9206475.c5f6245b591c90000d8430fc1ca8cc4de();
			itemTipsData.level = cc3903659f6abf884e4709091f9206475.m_level;
			itemTipsData.nameColor = UniUIManager.UniSWFToolClass.c87015237d139b95339567fd82054be1b(cc3903659f6abf884e4709091f9206475.m_rarity);
			itemTipsData.levelColor = UniUIManager.UniSWFToolClass.c7fad7b5218f6951e51fe893390ef3e3c(c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c7513e66c4e0fc55e6fea9dd9cb8b9943(), cc3903659f6abf884e4709091f9206475.m_level);
			ShieldAttribute attribute = cc3903659f6abf884e4709091f9206475.m_attribute;
			float num = 0f;
			ItemElement itemElement = new ItemElement();
			num = cc3903659f6abf884e4709091f9206475.c965cfadc1c472321fd6724099dc3ac00(ShieldAttributeType.Capacity);
			float num2;
			if (entityPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				num2 = entityPlayer.c7cb1ac7f406fd6311968208ac9386b8b((int)num);
			}
			else
			{
				num2 = num;
			}
			float num3 = num2;
			if (num3 > num)
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
				itemElement.color = Color.green;
			}
			num = num3;
			itemElement.value = num.ToString("f1");
			ItemElement itemElement2 = itemElement;
			object arrow;
			if (cc5911fb91e9ef8ae7e39b1c801f365be == null)
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
				arrow = "none";
			}
			else
			{
				arrow = UniUIManager.UniSWFToolClass.c829860ccd1c2bd1526f02a4101640f7a(cc3903659f6abf884e4709091f9206475.c965cfadc1c472321fd6724099dc3ac00(ShieldAttributeType.Capacity), cc5911fb91e9ef8ae7e39b1c801f365be.c965cfadc1c472321fd6724099dc3ac00(ShieldAttributeType.Capacity));
			}
			itemElement2.arrow = (string)arrow;
			itemElement.iconType = "shield" + ShieldAttributeType.Capacity;
			itemElement.eType = ETipsItemType.ITVA;
			itemElement.title = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("SC_AttDesc_0"));
			itemTipsData.attributeList.Add(itemElement);
			itemElement = new ItemElement();
			itemElement.value = cc3903659f6abf884e4709091f9206475.c965cfadc1c472321fd6724099dc3ac00(ShieldAttributeType.RechargeRate).ToString("f1");
			ItemElement itemElement3 = itemElement;
			object arrow2;
			if (cc5911fb91e9ef8ae7e39b1c801f365be == null)
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
				arrow2 = "none";
			}
			else
			{
				arrow2 = UniUIManager.UniSWFToolClass.c829860ccd1c2bd1526f02a4101640f7a(cc3903659f6abf884e4709091f9206475.c965cfadc1c472321fd6724099dc3ac00(ShieldAttributeType.RechargeRate), cc5911fb91e9ef8ae7e39b1c801f365be.c965cfadc1c472321fd6724099dc3ac00(ShieldAttributeType.RechargeRate));
			}
			itemElement3.arrow = (string)arrow2;
			itemElement.iconType = "shield" + ShieldAttributeType.RechargeRate;
			itemElement.eType = ETipsItemType.ITVA;
			itemElement.title = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("SC_AttDesc_1"));
			itemTipsData.attributeList.Add(itemElement);
			itemElement = new ItemElement();
			itemElement.value = cc3903659f6abf884e4709091f9206475.c965cfadc1c472321fd6724099dc3ac00(ShieldAttributeType.RechargeDelay).ToString("f1");
			ItemElement itemElement4 = itemElement;
			object arrow3;
			if (cc5911fb91e9ef8ae7e39b1c801f365be == null)
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
				arrow3 = "none";
			}
			else
			{
				arrow3 = UniUIManager.UniSWFToolClass.c829860ccd1c2bd1526f02a4101640f7a(cc5911fb91e9ef8ae7e39b1c801f365be.c965cfadc1c472321fd6724099dc3ac00(ShieldAttributeType.RechargeDelay), cc3903659f6abf884e4709091f9206475.c965cfadc1c472321fd6724099dc3ac00(ShieldAttributeType.RechargeDelay));
			}
			itemElement4.arrow = (string)arrow3;
			itemElement.iconType = "shield" + ShieldAttributeType.RechargeDelay;
			itemElement.eType = ETipsItemType.ITVA;
			itemElement.title = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("SC_AttDesc_2"));
			itemTipsData.attributeList.Add(itemElement);
			itemTipsData.brand = UniUIManager.UniSWFToolClass._BrandStringMap[(int)attribute.c4e0f63f4b4d409c5e3992c71520e30a0(ShieldAttributeType.Manufacturer)];
		}
		return itemTipsData;
	}

	public ItemTipsData ce1c8db90ec27ba2c8ea88570c0f2de9c(ClassModeDNA c176822fdbbb024478da34c927718d68e, ClassModeDNA c1441561c68fe614567d5cde5fa8abcdd = null)
	{
		ItemTipsData itemTipsData = new ItemTipsData();
		if (c176822fdbbb024478da34c927718d68e != null)
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
			itemTipsData.name = c176822fdbbb024478da34c927718d68e.c5f6245b591c90000d8430fc1ca8cc4de();
			itemTipsData.nameColor = UniUIManager.UniSWFToolClass.c87015237d139b95339567fd82054be1b(c176822fdbbb024478da34c927718d68e.m_rarity);
			itemTipsData.level = c176822fdbbb024478da34c927718d68e.m_level;
			itemTipsData.levelColor = UniUIManager.UniSWFToolClass.c7fad7b5218f6951e51fe893390ef3e3c(c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c7513e66c4e0fc55e6fea9dd9cb8b9943(), c176822fdbbb024478da34c927718d68e.m_level);
			ItemElement itemElement = new ItemElement();
			if (c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c093d70e3287743ce2bc905d2c4b341f3().m_type != c176822fdbbb024478da34c927718d68e.c95c0ac986e3767a549cf71c2cf28b34f(c176822fdbbb024478da34c927718d68e.m_cmType))
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
				itemElement.color = Color.red;
			}
			itemElement.value = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("CC_Class_Requirement")) + LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("CLASS_" + c176822fdbbb024478da34c927718d68e.c95c0ac986e3767a549cf71c2cf28b34f(c176822fdbbb024478da34c927718d68e.m_cmType)));
			itemElement.eType = ETipsItemType.TEXT;
			itemTipsData.attributeList.Add(itemElement);
			List<SkillAttributeConfig> list = c176822fdbbb024478da34c927718d68e.cd0c0b3e28f87164a771cf50ebb30e5de();
			using (List<SkillAttributeConfig>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					SkillAttributeConfig current = enumerator.Current;
					itemElement = new ItemElement();
					string text = string.Empty;
					if (SkillDisplayStore.c44a2b51cbcd8bf73167ba6a2f008a34b.m_skillDisplaySetup.cadef9a192fc5bdbc6abde1b1df3c3e98(current.m_attrType) == DisplayType.Percentage)
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
						text = "P0";
					}
					else if (SkillDisplayStore.c44a2b51cbcd8bf73167ba6a2f008a34b.m_skillDisplaySetup.cadef9a192fc5bdbc6abde1b1df3c3e98(current.m_attrType) == DisplayType.RawValue)
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
						text = "f2";
					}
					float num = 0f;
					if (current.m_affectType == AffectType.Scale)
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
						num = current.m_attrValue - 1f;
					}
					else
					{
						num = current.m_attrValue;
					}
					string text2 = num.ToString(text);
					if (num > 0f)
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
						text2 = "+" + text2;
					}
					itemElement.value = text2;
					itemElement.eType = ETipsItemType.TV;
					itemElement.title = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(current.m_attrType.ToString()));
					itemTipsData.attributeList.Add(itemElement);
				}
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						goto end_IL_0249;
					}
					continue;
					end_IL_0249:
					break;
				}
			}
		}
		return itemTipsData;
	}
}
