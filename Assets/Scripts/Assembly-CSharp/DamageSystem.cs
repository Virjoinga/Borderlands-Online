using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using A;
using Core;
using UnityEngine;
using XsdSettings;

internal class DamageSystem
{
	private DamageSettings m_damageSettings = new DamageSettings();

	private List<ElementalDamageSettings> m_elementalDamageSettings = new List<ElementalDamageSettings>();

	private EntityWeapon m_lastWeapon;

	private HitInfo m_lastHitInfo;

	public void ccc9d3a38966dc10fedb531ea17d24611()
	{
		TextAsset textAsset = ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("ElementalDamageTable") as TextAsset;
		MemoryStream memoryStream = new MemoryStream(textAsset.bytes);
		try
		{
			XmlSerializer xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(c2a0ae52a7fbca8b1ef399188e7222e59.cc1720d05c75832f704b87474932341c3()));
			m_elementalDamageSettings = xmlSerializer.Deserialize(memoryStream) as List<ElementalDamageSettings>;
		}
		finally
		{
			if (memoryStream != null)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					((IDisposable)memoryStream).Dispose();
					break;
				}
			}
		}
		Resources.UnloadAsset(textAsset);
		TextAsset textAsset2 = ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("BOL_DamageSettings") as TextAsset;
		MemoryStream memoryStream2 = new MemoryStream(textAsset2.bytes);
		try
		{
			XmlSerializer xmlSerializer2 = new XmlSerializer(Type.GetTypeFromHandle(c9576b5ddeae36fe4fcaf5ed6d73a4c0e.cc1720d05c75832f704b87474932341c3()));
			m_damageSettings = xmlSerializer2.Deserialize(memoryStream2) as DamageSettings;
		}
		finally
		{
			if (memoryStream2 != null)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					((IDisposable)memoryStream2).Dispose();
					break;
				}
			}
		}
		Resources.UnloadAsset(textAsset2);
	}

	private ElementalDamageSettings c8f9b06c4da03f5970af172a63daa28c1(AttackInfo.ElementalType cdde15e415d8c1cdd0d502ae01b80b58d)
	{
		for (int i = 0; i < m_elementalDamageSettings.Count; i++)
		{
			if (m_elementalDamageSettings[i].m_elemental != cdde15e415d8c1cdd0d502ae01b80b58d)
			{
				continue;
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				return m_elementalDamageSettings[i];
			}
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			return null;
		}
	}

	public float c99eed77fc7972e1cedd74ab862117b4e(AttackInfo.ElementalType cdde15e415d8c1cdd0d502ae01b80b58d, Entity c42167b7db020f2e5cd252c40ece23f3b, Entity c9fd4dd0ab9bc10aa34242de0def9d8f4)
	{
		float num = c8f9b06c4da03f5970af172a63daa28c1(cdde15e415d8c1cdd0d502ae01b80b58d).m_effectDuration;
		if (c42167b7db020f2e5cd252c40ece23f3b != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (c42167b7db020f2e5cd252c40ece23f3b is EntityPlayer)
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
				float num2 = (c42167b7db020f2e5cd252c40ece23f3b as EntityPlayer).c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.DecreaseElementalDuration);
				num *= num2;
			}
		}
		if (c9fd4dd0ab9bc10aa34242de0def9d8f4 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (c9fd4dd0ab9bc10aa34242de0def9d8f4 is EntityPlayer)
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
				float num3 = (c9fd4dd0ab9bc10aa34242de0def9d8f4 as EntityPlayer).c8461c34c06edbd90bf4b90de8c15863f.c6bbb90ce98ca4f07581063bdf0dadfb5(EffectType.ExtendElementalDOT);
				num *= num3;
			}
		}
		return num;
	}

	public int c1f787f99a147b5c013b65bed97203d9d()
	{
		return m_damageSettings.m_DOT_LIMIT_PLAYER;
	}

	public int cf81797f580e0ae4c2e2409eb821640dc()
	{
		return m_damageSettings.m_DOT_LIMIT_AI;
	}

	private float cc235baad7fc18433d74d7c2121b932bd(float c88d190ead93205eef032482d8085d15c)
	{
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c28b45877056e09d3c4d6fa790a1517aa())
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
					return Mathf.Clamp(c88d190ead93205eef032482d8085d15c, m_damageSettings.m_pvp_damageMin, m_damageSettings.m_pvp_damageMax);
				}
			}
		}
		return Mathf.Clamp(c88d190ead93205eef032482d8085d15c, m_damageSettings.m_pve_damageMin, m_damageSettings.m_pve_damageMax);
	}

	public bool c4946f219fce052aa41b878a8c07b1f78(HitInfo c3ced719b4780c1919017d69e82521ab3, bool c0ea90b943954dfb309da54924fca03b4, ref DamageInfo cd267a5dc6434bf247c67a6b37ed70c84)
	{
		Entity entity = BadAssNetworkView.cd45cbc6284a89fa5c2b29c7ad9718528(c3ced719b4780c1919017d69e82521ab3.m_to);
		Entity c0402779363a90fb1388693c197ee744a = BadAssNetworkView.cd45cbc6284a89fa5c2b29c7ad9718528(c3ced719b4780c1919017d69e82521ab3.m_owner);
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		if (entity.c147acea867a351adb3024b05cfd5b676())
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return false;
				}
			}
		}
		if (!entity.ce003fe849cc45b85ca4570109817c796())
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
			if (c73e1a950ed07eb24d29a732ced6f6dc9(entity) > 0)
			{
				float num4 = cc235baad7fc18433d74d7c2121b932bd(c3ced719b4780c1919017d69e82521ab3.m_damagePoint);
				WeakPoint weakPoint = entity.c63f8f07320313ddc4213cb59ee025962().c92b2d96b80fc4e8dc19a3368e56dbacb(c3ced719b4780c1919017d69e82521ab3.m_weakPointIndex);
				float num5 = 1f;
				if (AttackInfo.cb40d9d92cf67eb5b4aecc077640e0f4e(c3ced719b4780c1919017d69e82521ab3.m_attackSubType) == AttackInfo.AttackType.DamageOverTime)
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
					WeakPoint c38b98045365f4b50a4fbe3f1d89af = entity.c63f8f07320313ddc4213cb59ee025962().c92b2d96b80fc4e8dc19a3368e56dbacb(entity.c659e11237d268aac8b68c419cf6b053a());
					num5 = c0db419ec1b4d4d5d502b27a2ffb2cbcf(entity, c38b98045365f4b50a4fbe3f1d89af);
				}
				else
				{
					num5 = c0db419ec1b4d4d5d502b27a2ffb2cbcf(entity, weakPoint);
				}
				bool flag = num5 > 1f;
				if (num5 > float.Epsilon)
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
					float num6 = c2113651fed5404400ea850a410850f0b(c0402779363a90fb1388693c197ee744a, c3ced719b4780c1919017d69e82521ab3);
					float num7 = cd85ff2cc98f2f24ff4fc4e7674d194c8(c0402779363a90fb1388693c197ee744a, c3ced719b4780c1919017d69e82521ab3);
					float num8 = c9e78731a722173182d97fcb193f372d4(c0402779363a90fb1388693c197ee744a, c3ced719b4780c1919017d69e82521ab3);
					float num9 = cbc82bd86727dfe88813561a2b0a3ffa9(c0402779363a90fb1388693c197ee744a, c3ced719b4780c1919017d69e82521ab3);
					float num10 = cb3223f9a305a17e1eab189d88cb7010d(c0402779363a90fb1388693c197ee744a, c3ced719b4780c1919017d69e82521ab3);
					float num11 = c3e09247dd3e9371b0945bda51e18553f(c0402779363a90fb1388693c197ee744a, entity, c3ced719b4780c1919017d69e82521ab3, flag);
					float num12 = cb03a35912a8260632564d1b668f66748(entity, c3ced719b4780c1919017d69e82521ab3);
					float num13 = c67f9311ddac7ff1a6aeb7caf015a14f9(entity, c3ced719b4780c1919017d69e82521ab3);
					float num14 = c6fe8d13591d462327306a32e7824f43e(entity, c3ced719b4780c1919017d69e82521ab3);
					float num15 = ce78805f904c50c7f149c6307c9b9fd5b(entity, c3ced719b4780c1919017d69e82521ab3);
					float num16 = num4;
					num16 *= num6;
					num16 *= num7;
					num16 *= num8;
					num16 *= num9;
					num16 *= num10;
					num16 *= num11;
					float num17 = 1f;
					if (flag)
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
						EntityWeapon entityWeapon = BadAssNetworkView.cd45cbc6284a89fa5c2b29c7ad9718528(c3ced719b4780c1919017d69e82521ab3.m_from) as EntityWeapon;
						if (entityWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							num17 = FloatAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(entityWeapon.m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.CriticalHitScale) as FloatAttributeValue);
						}
					}
					num16 *= 1f + (num5 - 1f) * num17;
					num16 *= num12;
					num16 *= num13;
					num16 *= num14;
					num16 *= num15;
					if (num15 < 0f)
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
						num16 = 0f;
					}
					else
					{
						num16 = cc235baad7fc18433d74d7c2121b932bd(num16);
					}
					int num18 = c10d0e821e194dba6b2c3ee099358416c(entity);
					if (num18 > 0)
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
						float num19 = cb374bdc5604b25c4316473aeae04a403(entity, c3ced719b4780c1919017d69e82521ab3);
						float c88d190ead93205eef032482d8085d15c = num16 * num19;
						c88d190ead93205eef032482d8085d15c = cc235baad7fc18433d74d7c2121b932bd(c88d190ead93205eef032482d8085d15c);
						num = Mathf.FloorToInt(c88d190ead93205eef032482d8085d15c);
						if (num18 >= num)
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
							num16 = -1f;
						}
						else
						{
							num = num18;
							num16 -= (float)num;
						}
					}
					if (num16 > 0f)
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
						int num20 = c0d3aebca061a7a8e22bfb5cba4258a55(entity, weakPoint);
						if (num20 > 0)
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
							float num21 = c9051f9fdb9ba45dab8021957bbdfebee(weakPoint.m_matterType, c3ced719b4780c1919017d69e82521ab3);
							float c88d190ead93205eef032482d8085d15c2 = num16 * num21;
							c88d190ead93205eef032482d8085d15c2 = cc235baad7fc18433d74d7c2121b932bd(c88d190ead93205eef032482d8085d15c2);
							int num22 = Mathf.FloorToInt(c88d190ead93205eef032482d8085d15c2);
							if (num20 >= num22)
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
								num16 = -1f;
								num2 = num22;
							}
							else
							{
								num2 = num20;
								num16 -= (float)num2;
							}
						}
					}
					if (num16 > 0f)
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
						float num23 = c9051f9fdb9ba45dab8021957bbdfebee(weakPoint.m_matterType, c3ced719b4780c1919017d69e82521ab3);
						num16 *= num23;
						num16 = cc235baad7fc18433d74d7c2121b932bd(num16);
						num3 = Mathf.FloorToInt(num16);
					}
				}
				bool isTriggeringDamageOverTime = false;
				cd267a5dc6434bf247c67a6b37ed70c84.m_attackSubType = c3ced719b4780c1919017d69e82521ab3.m_attackSubType;
				cd267a5dc6434bf247c67a6b37ed70c84.m_elementalType = c3ced719b4780c1919017d69e82521ab3.m_elementalType;
				cd267a5dc6434bf247c67a6b37ed70c84.m_isTriggeringDamageOverTime = isTriggeringDamageOverTime;
				int from;
				if (c3ced719b4780c1919017d69e82521ab3.m_owner != 0)
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
					from = c3ced719b4780c1919017d69e82521ab3.m_owner;
				}
				else
				{
					from = c3ced719b4780c1919017d69e82521ab3.m_from;
				}
				cd267a5dc6434bf247c67a6b37ed70c84.m_from = from;
				cd267a5dc6434bf247c67a6b37ed70c84.m_shieldDamagePoints = num;
				cd267a5dc6434bf247c67a6b37ed70c84.m_healthDamagePoints = num3 + num2;
				cd267a5dc6434bf247c67a6b37ed70c84.m_weakPointIndex = c3ced719b4780c1919017d69e82521ab3.m_weakPointIndex;
				cd267a5dc6434bf247c67a6b37ed70c84.m_force = c3ced719b4780c1919017d69e82521ab3.m_rayDirection.magnitude;
				return true;
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
		return false;
	}

	private bool c47cb2969becdbe14624ace7928b1e732(HitInfo c3ced719b4780c1919017d69e82521ab3, Entity c0402779363a90fb1388693c197ee744a, EntityWeapon c39409683a32e09391d094314ffeae2b5)
	{
		if (!cd0e78bb2aacaab4676e1d0dcabacc347(c3ced719b4780c1919017d69e82521ab3, c39409683a32e09391d094314ffeae2b5))
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return false;
				}
			}
		}
		float c46b361ee1a87173ef6885513d3e7cca = c0402779363a90fb1388693c197ee744a.c150748569f6883ea4267194e6e3271e7(c39409683a32e09391d094314ffeae2b5, c3ced719b4780c1919017d69e82521ab3.m_to);
		c06ca0e618478c23eba3419653a19760f<StateDamageManager>.c5ee19dc8d4cccf5ae2de225410458b86.cafe676ccf3cf6b69db4f76056920fcb6(c3ced719b4780c1919017d69e82521ab3, c46b361ee1a87173ef6885513d3e7cca, c99eed77fc7972e1cedd74ab862117b4e(c3ced719b4780c1919017d69e82521ab3.m_elementalType, BadAssNetworkView.cd45cbc6284a89fa5c2b29c7ad9718528(c3ced719b4780c1919017d69e82521ab3.m_to), c0402779363a90fb1388693c197ee744a));
		return true;
	}

	public bool c47cb2969becdbe14624ace7928b1e732(HitInfo c3ced719b4780c1919017d69e82521ab3, float c997345152cfe8f0da7a8ebca2c0b00b6, ref DamageInfo cd267a5dc6434bf247c67a6b37ed70c84)
	{
		cd267a5dc6434bf247c67a6b37ed70c84.m_attackSubType = c3ced719b4780c1919017d69e82521ab3.m_attackSubType;
		cd267a5dc6434bf247c67a6b37ed70c84.m_elementalType = c3ced719b4780c1919017d69e82521ab3.m_elementalType;
		cd267a5dc6434bf247c67a6b37ed70c84.m_isTriggeringDamageOverTime = true;
		int from;
		if (c3ced719b4780c1919017d69e82521ab3.m_owner != 0)
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
			from = c3ced719b4780c1919017d69e82521ab3.m_owner;
		}
		else
		{
			from = c3ced719b4780c1919017d69e82521ab3.m_from;
		}
		cd267a5dc6434bf247c67a6b37ed70c84.m_from = from;
		cd267a5dc6434bf247c67a6b37ed70c84.m_shieldDamagePoints = 0;
		cd267a5dc6434bf247c67a6b37ed70c84.m_healthDamagePoints = 0;
		cd267a5dc6434bf247c67a6b37ed70c84.m_weakPointIndex = c3ced719b4780c1919017d69e82521ab3.m_weakPointIndex;
		cd267a5dc6434bf247c67a6b37ed70c84.m_force = c3ced719b4780c1919017d69e82521ab3.m_rayDirection.magnitude;
		c06ca0e618478c23eba3419653a19760f<StateDamageManager>.c5ee19dc8d4cccf5ae2de225410458b86.cafe676ccf3cf6b69db4f76056920fcb6(c3ced719b4780c1919017d69e82521ab3, c997345152cfe8f0da7a8ebca2c0b00b6, c99eed77fc7972e1cedd74ab862117b4e(c3ced719b4780c1919017d69e82521ab3.m_elementalType, BadAssNetworkView.cd45cbc6284a89fa5c2b29c7ad9718528(c3ced719b4780c1919017d69e82521ab3.m_to), BadAssNetworkView.cd45cbc6284a89fa5c2b29c7ad9718528(c3ced719b4780c1919017d69e82521ab3.m_owner)));
		return true;
	}

	private bool c88877f6f5607c0553a9e4d569cf256ed(HitInfo c3ced719b4780c1919017d69e82521ab3, EntityWeapon c39409683a32e09391d094314ffeae2b5)
	{
		int result;
		if (!(c39409683a32e09391d094314ffeae2b5 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (m_lastHitInfo != null)
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
				if (c3ced719b4780c1919017d69e82521ab3 != null)
				{
					if (c39409683a32e09391d094314ffeae2b5.c83e548e5608cd7f222098a6966b16545() == WeaponType.ShotGun)
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
						if (m_lastWeapon == c39409683a32e09391d094314ffeae2b5)
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
							result = ((Mathf.Abs((float)(m_lastHitInfo.m_timeStamp - c3ced719b4780c1919017d69e82521ab3.m_timeStamp)) < 0.001f) ? 1 : 0);
							goto IL_0096;
						}
					}
					result = 0;
					goto IL_0096;
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
		return false;
		IL_0096:
		return (byte)result != 0;
	}

	private bool cd0e78bb2aacaab4676e1d0dcabacc347(HitInfo c3ced719b4780c1919017d69e82521ab3, EntityWeapon c39409683a32e09391d094314ffeae2b5)
	{
		if (c3ced719b4780c1919017d69e82521ab3.m_elementalType == AttackInfo.ElementalType.None)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return false;
				}
			}
		}
		Entity entity = BadAssNetworkView.cd45cbc6284a89fa5c2b29c7ad9718528(c3ced719b4780c1919017d69e82521ab3.m_to);
		if (!(entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (entity.c34e2df09efc33ff67ad7080de3d7f694())
			{
				if (c88877f6f5607c0553a9e4d569cf256ed(c3ced719b4780c1919017d69e82521ab3, c39409683a32e09391d094314ffeae2b5))
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							return false;
						}
					}
				}
				m_lastWeapon = c39409683a32e09391d094314ffeae2b5;
				m_lastHitInfo = c3ced719b4780c1919017d69e82521ab3;
				float num;
				if (c39409683a32e09391d094314ffeae2b5 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					num = c39409683a32e09391d094314ffeae2b5.cdbaa846b08ebd130487157e88e4cfe71();
				}
				else
				{
					num = c8f9b06c4da03f5970af172a63daa28c1(c3ced719b4780c1919017d69e82521ab3.m_elementalType).m_baseProcRatio;
				}
				if (num <= 0f)
				{
					while (true)
					{
						switch (2)
						{
						case 0:
							break;
						default:
							return false;
						}
					}
				}
				if (num >= 1f)
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							return true;
						}
					}
				}
				float num2 = UnityEngine.Random.Range(0f, 1f);
				return num2 <= num;
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				break;
			}
		}
		return false;
	}

	private int c10d0e821e194dba6b2c3ee099358416c(Entity c5d720f6d007abb0c4a21d6a654e405bb)
	{
		if (c5d720f6d007abb0c4a21d6a654e405bb == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return 0;
				}
			}
		}
		EntityShield entityShield = c5d720f6d007abb0c4a21d6a654e405bb.c136b0f223897fdf01d18a9a5e3745433();
		if (entityShield == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					return 0;
				}
			}
		}
		return entityShield.m_shieldPoints.c4c4b463091d2b6acfdded4fa12b32f25();
	}

	private int c73e1a950ed07eb24d29a732ced6f6dc9(Entity c5d720f6d007abb0c4a21d6a654e405bb)
	{
		if (c5d720f6d007abb0c4a21d6a654e405bb == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return 0;
				}
			}
		}
		EquipmentInventoryEntity equipmentInventoryEntity = c5d720f6d007abb0c4a21d6a654e405bb.c5ca38fad98337fc5c7255384b2cd1a86();
		if (equipmentInventoryEntity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					return 0;
				}
			}
		}
		return equipmentInventoryEntity.ca2ff7a501878363cb1d5f0472e306620();
	}

	private int c0d3aebca061a7a8e22bfb5cba4258a55(Entity c5d720f6d007abb0c4a21d6a654e405bb, WeakPoint c38b98045365f4b50a4fbe3f1d89af089)
	{
		if (c38b98045365f4b50a4fbe3f1d89af089 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return 0;
				}
			}
		}
		if (c38b98045365f4b50a4fbe3f1d89af089.m_damagePropagationType != WeakPoint.DamagePropagationType.ApplyToSelf)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					return 0;
				}
			}
		}
		if (c5d720f6d007abb0c4a21d6a654e405bb == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					return 0;
				}
			}
		}
		EquipmentInventoryEntity equipmentInventoryEntity = c5d720f6d007abb0c4a21d6a654e405bb.c5ca38fad98337fc5c7255384b2cd1a86();
		if (equipmentInventoryEntity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					return 0;
				}
			}
		}
		return equipmentInventoryEntity.c0e018ed0ee4ac2592fafd36d256cd617(c38b98045365f4b50a4fbe3f1d89af089);
	}

	private float c2113651fed5404400ea850a410850f0b(Entity c0402779363a90fb1388693c197ee744a, HitInfo c3ced719b4780c1919017d69e82521ab3)
	{
		return 1f;
	}

	private float cd85ff2cc98f2f24ff4fc4e7674d194c8(Entity c0402779363a90fb1388693c197ee744a, HitInfo c3ced719b4780c1919017d69e82521ab3)
	{
		return 1f;
	}

	private float c9e78731a722173182d97fcb193f372d4(Entity c0402779363a90fb1388693c197ee744a, HitInfo c3ced719b4780c1919017d69e82521ab3)
	{
		if (c0402779363a90fb1388693c197ee744a == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return 1f;
				}
			}
		}
		return c0402779363a90fb1388693c197ee744a.c9e78731a722173182d97fcb193f372d4(AttackInfo.cb40d9d92cf67eb5b4aecc077640e0f4e(c3ced719b4780c1919017d69e82521ab3.m_attackSubType));
	}

	private float cbc82bd86727dfe88813561a2b0a3ffa9(Entity c0402779363a90fb1388693c197ee744a, HitInfo c3ced719b4780c1919017d69e82521ab3)
	{
		if (c0402779363a90fb1388693c197ee744a == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return 1f;
				}
			}
		}
		return c0402779363a90fb1388693c197ee744a.cbc82bd86727dfe88813561a2b0a3ffa9(AttackInfo.cb40d9d92cf67eb5b4aecc077640e0f4e(c3ced719b4780c1919017d69e82521ab3.m_attackSubType));
	}

	private float c3e09247dd3e9371b0945bda51e18553f(Entity c0402779363a90fb1388693c197ee744a, Entity cf7ee7f254a35f9c53a393957e2758a0a, HitInfo c3ced719b4780c1919017d69e82521ab3, bool c630d50d5dec38605bd844e4adb5c00ba)
	{
		if (c0402779363a90fb1388693c197ee744a == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return 1f;
				}
			}
		}
		return c0402779363a90fb1388693c197ee744a.c3e09247dd3e9371b0945bda51e18553f(AttackInfo.cb40d9d92cf67eb5b4aecc077640e0f4e(c3ced719b4780c1919017d69e82521ab3.m_attackSubType), c630d50d5dec38605bd844e4adb5c00ba, cf7ee7f254a35f9c53a393957e2758a0a);
	}

	private float cb3223f9a305a17e1eab189d88cb7010d(Entity c0402779363a90fb1388693c197ee744a, HitInfo c3ced719b4780c1919017d69e82521ab3)
	{
		if (c0402779363a90fb1388693c197ee744a == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return 1f;
				}
			}
		}
		return c0402779363a90fb1388693c197ee744a.cb3223f9a305a17e1eab189d88cb7010d();
	}

	private float c6fe8d13591d462327306a32e7824f43e(Entity cf7ee7f254a35f9c53a393957e2758a0a, HitInfo c3ced719b4780c1919017d69e82521ab3)
	{
		if (cf7ee7f254a35f9c53a393957e2758a0a == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return 1f;
				}
			}
		}
		return cf7ee7f254a35f9c53a393957e2758a0a.c6fe8d13591d462327306a32e7824f43e();
	}

	private float cb03a35912a8260632564d1b668f66748(Entity cf7ee7f254a35f9c53a393957e2758a0a, HitInfo c3ced719b4780c1919017d69e82521ab3)
	{
		return 1f;
	}

	private float c0db419ec1b4d4d5d502b27a2ffb2cbcf(Entity cf7ee7f254a35f9c53a393957e2758a0a, WeakPoint c38b98045365f4b50a4fbe3f1d89af089)
	{
		if (c38b98045365f4b50a4fbe3f1d89af089 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return 1f;
				}
			}
		}
		if (m_damageSettings == null)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					return 1f;
				}
			}
		}
		int num = (int)c38b98045365f4b50a4fbe3f1d89af089.cf7d609e6e0384b70ae8d814e5f8712be();
		if (m_damageSettings.m_weakpointStrengthModifiers == null)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return 1f;
				}
			}
		}
		if (num >= 0)
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
			if (m_damageSettings.m_weakpointStrengthModifiers.Length > num)
			{
				return m_damageSettings.m_weakpointStrengthModifiers[num];
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				break;
			}
		}
		return 1f;
	}

	private float c67f9311ddac7ff1a6aeb7caf015a14f9(Entity cf7ee7f254a35f9c53a393957e2758a0a, HitInfo c3ced719b4780c1919017d69e82521ab3)
	{
		return 1f;
	}

	private float ce78805f904c50c7f149c6307c9b9fd5b(Entity cf7ee7f254a35f9c53a393957e2758a0a, HitInfo c3ced719b4780c1919017d69e82521ab3)
	{
		return cf7ee7f254a35f9c53a393957e2758a0a.ce78805f904c50c7f149c6307c9b9fd5b(cf7ee7f254a35f9c53a393957e2758a0a, c3ced719b4780c1919017d69e82521ab3);
	}

	private float cb374bdc5604b25c4316473aeae04a403(Entity cf7ee7f254a35f9c53a393957e2758a0a, HitInfo c3ced719b4780c1919017d69e82521ab3)
	{
		ElementalDamageSettings elementalDamageSettings = c8f9b06c4da03f5970af172a63daa28c1(c3ced719b4780c1919017d69e82521ab3.m_elementalType);
		if (elementalDamageSettings == null)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return 1f;
				}
			}
		}
		return elementalDamageSettings.m_damageCoefShield;
	}

	private float c9051f9fdb9ba45dab8021957bbdfebee(WeakPoint.MatterType c4723212bd44ddd8b02fd699d91db8e73, HitInfo c3ced719b4780c1919017d69e82521ab3)
	{
		ElementalDamageSettings elementalDamageSettings = c8f9b06c4da03f5970af172a63daa28c1(c3ced719b4780c1919017d69e82521ab3.m_elementalType);
		if (elementalDamageSettings == null)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return 1f;
				}
			}
		}
		if (c4723212bd44ddd8b02fd699d91db8e73 != 0)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					if (c4723212bd44ddd8b02fd699d91db8e73 != WeakPoint.MatterType.Armor)
					{
						while (true)
						{
							switch (3)
							{
							case 0:
								break;
							default:
								DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, "Invalid Matter Type: " + c4723212bd44ddd8b02fd699d91db8e73);
								return 1f;
							}
						}
					}
					return elementalDamageSettings.m_damageCoefArmor;
				}
			}
		}
		return elementalDamageSettings.m_damageCoefFlesh;
	}
}
