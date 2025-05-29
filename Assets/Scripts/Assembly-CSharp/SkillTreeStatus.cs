using System;
using System.Collections;
using System.Collections.Generic;
using A;
using Core;
using Photon;
using UnityEngine;
using XsdSettings;

public class SkillTreeStatus : Photon.MonoBehaviour
{
	public class SkillStatus
	{
		public int m_grade;
	}

	public class EffectInSkillData
	{
		public int m_skillID;

		public Effect m_effectData;

		public EffectInSkillData(int cbd26e39b8b1d5b0abffedcac5d1ecc8f, Effect cb4894757e910c1c28ee57d196a07df28)
		{
			m_skillID = cbd26e39b8b1d5b0abffedcac5d1ecc8f;
			m_effectData = cb4894757e910c1c28ee57d196a07df28;
		}
	}

	public delegate void SkillUpgradeHandler(int grade);

	private EntityPlayer m_owner;

	public Dictionary<int, SkillStatus> m_data = new Dictionary<int, SkillStatus>();

	private List<int> m_theTypeList = new List<int>();

	private bool m_skilldata_initialized_client;

	private string m_cacheDataReceived_client = string.Empty;

	private static Dictionary<int, List<EffectInSkillData>> m_effectInSKillDict = c921aff039f7642da07a1bcaa368b7e9c.c7088de59e49f7108f520cf7e0bae167e;

	private static Dictionary<EffectType, AffectType> m_effectOperationList = new Dictionary<EffectType, AffectType>
	{
		{
			EffectType.RegenHealthOnHit,
			AffectType.PostAdd
		},
		{
			EffectType.ExplodeOnHit,
			AffectType.PostAdd
		},
		{
			EffectType.ResistElemental,
			AffectType.Scale
		},
		{
			EffectType.DecreaseElementalDuration,
			AffectType.Scale
		},
		{
			EffectType.IgniteWhenFirebird,
			AffectType.Scale
		},
		{
			EffectType.ChanceElementalExplode,
			AffectType.PostAdd
		},
		{
			EffectType.ExtendElementalDOT,
			AffectType.Scale
		},
		{
			EffectType.ChanceDazeWhenDOT,
			AffectType.PostAdd
		},
		{
			EffectType.AccelCooldownWhenHurt,
			AffectType.Scale
		},
		{
			EffectType.ChanceAddBulletWhenHurt,
			AffectType.PostAdd
		},
		{
			EffectType.RegenHealthFromEnemy,
			AffectType.PostAdd
		},
		{
			EffectType.ExtendRangeDuration,
			AffectType.Scale
		},
		{
			EffectType.AddMeleeDamage,
			AffectType.Scale
		},
		{
			EffectType.ChanceMeleeDaze,
			AffectType.PostAdd
		},
		{
			EffectType.ChanceLoadMoreBullet,
			AffectType.PostAdd
		},
		{
			EffectType.TurretWithSniper,
			AffectType.Scale
		},
		{
			EffectType.TransferDamageToTurret,
			AffectType.PostAdd
		},
		{
			EffectType.SlowdownNearTurret,
			AffectType.PostAdd
		},
		{
			EffectType.ResistExplode,
			AffectType.PostAdd
		},
		{
			EffectType.ThrowMine,
			AffectType.Scale
		},
		{
			EffectType.Invisible,
			AffectType.PostAdd
		},
		{
			EffectType.MoreDamageToLowHealth,
			AffectType.Scale
		},
		{
			EffectType.ExplodeOnCriticalHit,
			AffectType.Scale
		},
		{
			EffectType.DecreaseHunterCooldown,
			AffectType.PostAdd
		},
		{
			EffectType.ChanceDazeOnCriticalHit,
			AffectType.PostAdd
		},
		{
			EffectType.RevealEnemy,
			AffectType.PostAdd
		},
		{
			EffectType.AmmoCapacity,
			AffectType.Scale
		},
		{
			EffectType.WeaponAccuracy,
			AffectType.Scale
		},
		{
			EffectType.LootProbability,
			AffectType.Scale
		},
		{
			EffectType.GoldBonus,
			AffectType.Scale
		},
		{
			EffectType.XPBonus,
			AffectType.Scale
		},
		{
			EffectType.ShieldRechargeDelay,
			AffectType.Scale
		},
		{
			EffectType.BulletDamagePostAdd,
			AffectType.PostAdd
		},
		{
			EffectType.BulletDamageScale,
			AffectType.Scale
		},
		{
			EffectType.WeaponMaxHPScale,
			AffectType.Scale
		},
		{
			EffectType.WeaponMaxHPPostAdd,
			AffectType.PostAdd
		},
		{
			EffectType.WeaponMaxShieldPostAdd,
			AffectType.PostAdd
		},
		{
			EffectType.WeaponMaxShieldScale,
			AffectType.Scale
		}
	};

	private int m_newMaxHP_PVP_Init;

	private bool m_sync_maxHP_PVP;

	private int m_newMaxShield_PVP_Init;

	private bool m_sync_maxShield_PVP;

	private void Awake()
	{
		m_skilldata_initialized_client = false;
		m_cacheDataReceived_client = string.Empty;
	}

	public void ccc9d3a38966dc10fedb531ea17d24611()
	{
		m_owner = GetComponent<EntityPlayer>();
		m_data.Clear();
		m_theTypeList = m_owner.ccaf53be8b86b7016efd6970ff8c92ad3.cf7f0990d94f23818b80b300c2e741783();
		for (int i = 0; i < m_theTypeList.Count; i++)
		{
			m_data.Add(m_theTypeList[i], new SkillStatus());
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
			m_skilldata_initialized_client = true;
			if (m_cacheDataReceived_client != string.Empty)
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
				c7b1a77a0f18ad32c525937d1abe956cb(m_cacheDataReceived_client);
			}
			cb2dafa29fccde4ce21a991589009df45();
			c56694e3a9f5ac83d713458ba54bc1563();
			return;
		}
	}

	private static void cb2dafa29fccde4ce21a991589009df45()
	{
		if (m_effectInSKillDict != null)
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
					return;
				}
			}
		}
		m_effectInSKillDict = new Dictionary<int, List<EffectInSkillData>>();
		SkillSetup skillSetup = c1ee7921b0c3cce194fb7cae41b5a9d82<SkillTreeServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cf7c751c78f7532960e17cac5a131ac86();
		for (int i = 0; i < skillSetup.m_skills.Length; i++)
		{
			Skill skill = skillSetup.m_skills[i];
			for (int j = 0; j < skill.m_effectList.Length; j++)
			{
				Effect effect = skill.m_effectList[j];
				if (effect.m_type == EffectType.Invalid)
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
					continue;
				}
				EffectInSkillData item = new EffectInSkillData(skill.m_id, effect);
				if (m_effectInSKillDict.ContainsKey((int)effect.m_type))
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
					m_effectInSKillDict[(int)effect.m_type].Add(item);
				}
				else
				{
					List<EffectInSkillData> list = new List<EffectInSkillData>();
					list.Add(item);
					m_effectInSKillDict.Add((int)effect.m_type, list);
				}
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					goto end_IL_00f9;
				}
				continue;
				end_IL_00f9:
				break;
			}
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	private static void c56694e3a9f5ac83d713458ba54bc1563()
	{
		int num = 0;
		string text = string.Empty;
		IEnumerator enumerator = Enum.GetValues(Type.GetTypeFromHandle(c494d7a9577f7e64983f9c532ef82600b.cc1720d05c75832f704b87474932341c3())).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				EffectType effectType = (EffectType)(int)enumerator.Current;
				if (effectType == EffectType.Invalid)
				{
					continue;
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (effectType == EffectType.Max)
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
				}
				else
				{
					if (m_effectInSKillDict.ContainsKey((int)effectType))
					{
						continue;
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
					if (m_effectOperationList.ContainsKey(effectType))
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
					num++;
					text = string.Concat(text, effectType, " , ");
				}
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					goto end_IL_00b6;
				}
				continue;
				end_IL_00b6:
				break;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable == null)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						goto end_IL_00ce;
					}
					continue;
					end_IL_00ce:
					break;
				}
			}
			else
			{
				disposable.Dispose();
			}
		}
		if (num <= 0)
		{
			return;
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, string.Format("{0} effect operation missing: {1}", num, text));
			return;
		}
	}

	public bool caa378d123472dde8837de8804cbf0182(ESkillType c4f09c39924e70788c7b055c1d1490578)
	{
		return m_data[(int)c4f09c39924e70788c7b055c1d1490578].m_grade > 0;
	}

	public int ca019ed8e32c3f9618e8c8d060dcff0cd(ESkillType c4f09c39924e70788c7b055c1d1490578)
	{
		return m_data[(int)c4f09c39924e70788c7b055c1d1490578].m_grade;
	}

	public AffectType c6dc389961c519ce61badd4f5a6569fb3(EffectType c4f09c39924e70788c7b055c1d1490578)
	{
		if (m_effectInSKillDict.ContainsKey((int)c4f09c39924e70788c7b055c1d1490578))
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
			string operation = m_effectInSKillDict[(int)c4f09c39924e70788c7b055c1d1490578][0].m_effectData.m_operation;
			for (int i = 0; i < 3; i++)
			{
				AffectType affectType = (AffectType)i;
				if (!string.Equals(operation, Utils.c06e309e4c34dfe6936b31f538f71347e(affectType), StringComparison.OrdinalIgnoreCase))
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
					return affectType;
				}
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
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, string.Format("GetOperation() 111 {0}", c4f09c39924e70788c7b055c1d1490578));
		}
		else
		{
			if (m_effectOperationList.ContainsKey(c4f09c39924e70788c7b055c1d1490578))
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					return m_effectOperationList[c4f09c39924e70788c7b055c1d1490578];
				}
			}
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, string.Format("GetOperation() {0} not exist", c4f09c39924e70788c7b055c1d1490578));
		}
		return AffectType.Scale;
	}

	public float ce4b7562d91f6077f573c5f5fa3d3e6dc(EffectType c4f09c39924e70788c7b055c1d1490578)
	{
		AffectType affectType = c6dc389961c519ce61badd4f5a6569fb3(c4f09c39924e70788c7b055c1d1490578);
		float num = c60c4bc9a822c2cf24a43a6bfce027b54(affectType);
		List<EffectInSkillData> value;
		if (m_effectInSKillDict.TryGetValue((int)c4f09c39924e70788c7b055c1d1490578, out value))
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
			int num2 = 0;
			while (true)
			{
				if (num2 < value.Count)
				{
					SkillStatus value2;
					if (m_data.TryGetValue(value[num2].m_skillID, out value2))
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
						Effect effectData = value[num2].m_effectData;
						int grade = value2.m_grade;
						num = c64ea79c3f9aff92800febf6f66509157(grade, effectData.m_firstGrade, effectData.m_perGrade);
						if (affectType != AffectType.Scale)
						{
							break;
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
						num += 1f;
						break;
					}
					num2++;
					continue;
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
				break;
			}
		}
		return num;
	}

	public float c60c4bc9a822c2cf24a43a6bfce027b54(AffectType c4f09c39924e70788c7b055c1d1490578)
	{
		if (c4f09c39924e70788c7b055c1d1490578 == AffectType.Scale)
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
		if (c4f09c39924e70788c7b055c1d1490578 == AffectType.PostAdd)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return 0f;
				}
			}
		}
		return 0f;
	}

	private float c64ea79c3f9aff92800febf6f66509157(int c26883cf36e0d9e02787ee96dd7f71b24, float c8e26a8f36b042a2f165fc9dadacbc4e6, float c8a8e18d70bf9474d2f7e4fc404a36fb7)
	{
		float result;
		if (c26883cf36e0d9e02787ee96dd7f71b24 == 0)
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
			result = 0f;
		}
		else
		{
			result = c8e26a8f36b042a2f165fc9dadacbc4e6 + (float)(c26883cf36e0d9e02787ee96dd7f71b24 - 1) * c8a8e18d70bf9474d2f7e4fc404a36fb7;
		}
		return result;
	}

	public float c275ce281d2ced47562dce554e5197b73(ESkillType c4f09c39924e70788c7b055c1d1490578, int cafa0d5e23a9ceb3de45a25d5526eb91b = 0)
	{
		return c1ee7921b0c3cce194fb7cae41b5a9d82<SkillTreeServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cc68b2da7036261f61f86280fd6e61748((int)c4f09c39924e70788c7b055c1d1490578).m_effectList[cafa0d5e23a9ceb3de45a25d5526eb91b].m_duration;
	}

	private bool cabffe93afe0daa3dd55f8fada5911c92(ESkillType c4f09c39924e70788c7b055c1d1490578, EffectType c59cf1d59c433de899b88276188e84d1f)
	{
		Effect[] effectList = c1ee7921b0c3cce194fb7cae41b5a9d82<SkillTreeServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cc68b2da7036261f61f86280fd6e61748((int)c4f09c39924e70788c7b055c1d1490578).m_effectList;
		foreach (Effect effect in effectList)
		{
			if (effect.m_type != c59cf1d59c433de899b88276188e84d1f)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				return true;
			}
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			return false;
		}
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.c8b2526be2638bb30a29ab8314b369311)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return;
				}
			}
		}
		string text = (string)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
		if (m_skilldata_initialized_client)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					c7b1a77a0f18ad32c525937d1abe956cb(text);
					return;
				}
			}
		}
		m_cacheDataReceived_client = text;
	}

	private string cf7f80451022faa10133085ada77f2c40()
	{
		string text = string.Empty;
		for (int i = 0; i < m_theTypeList.Count; i++)
		{
			object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(5);
			array[0] = text;
			array[1] = m_theTypeList[i];
			array[2] = ":";
			array[3] = m_data[m_theTypeList[i]].m_grade;
			array[4] = ";";
			text = string.Concat(array);
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
			return text;
		}
	}

	private void c7b1a77a0f18ad32c525937d1abe956cb(string c7f4dd80296d0263f50706537a1182977)
	{
		char[] array = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = ';';
		string[] array2 = c7f4dd80296d0263f50706537a1182977.Split(array);
		for (int i = 0; i < array2.Length; i++)
		{
			if (array2[i].Length <= 0)
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
				break;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			string obj = array2[i];
			char[] array3 = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
			array3[0] = ':';
			string[] array4 = obj.Split(array3);
			int key = Convert.ToInt32(array4[0]);
			int grade = Convert.ToInt32(array4[1]);
			m_data[key].m_grade = grade;
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	[RPC]
	private void RPC_H2C_SetShieldMax(int _max, PhotonMessageInfo info)
	{
		if (m_owner == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return;
				}
			}
		}
		EntityShield entityShield = m_owner.c136b0f223897fdf01d18a9a5e3745433();
		if (entityShield != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (entityShield.m_shieldPoints != null)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						entityShield.m_shieldPoints.c82133ff2bb787510ed8585dd3d834b59(_max);
						if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c28b45877056e09d3c4d6fa790a1517aa())
						{
							while (true)
							{
								switch (1)
								{
								case 0:
									break;
								default:
									if (!m_sync_maxShield_PVP)
									{
										while (true)
										{
											switch (4)
											{
											case 0:
												break;
											default:
												m_sync_maxShield_PVP = true;
												entityShield.m_shieldPoints.ca0f7f52805a9c67a892c5b479a17c3aa(_max);
												return;
											}
										}
									}
									return;
								}
							}
						}
						return;
					}
				}
			}
		}
		m_newMaxShield_PVP_Init = _max;
	}

	[RPC]
	private void RPC_H2C_SetMaxHP(int _max, PhotonMessageInfo _info)
	{
		if (m_owner != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (m_owner.c5ca38fad98337fc5c7255384b2cd1a86() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						m_owner.c5ca38fad98337fc5c7255384b2cd1a86().c9af7b3e5f6626ceef1a0036138121839(_max);
						if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c28b45877056e09d3c4d6fa790a1517aa())
						{
							while (true)
							{
								switch (1)
								{
								case 0:
									break;
								default:
									if (!m_sync_maxHP_PVP)
									{
										while (true)
										{
											switch (7)
											{
											case 0:
												break;
											default:
												m_sync_maxHP_PVP = true;
												m_owner.c5ca38fad98337fc5c7255384b2cd1a86().cf0a63fdc9831dd55ae40ac6a5f5eb7e0(_max);
												return;
											}
										}
									}
									return;
								}
							}
						}
						return;
					}
				}
			}
		}
		m_newMaxHP_PVP_Init = _max;
	}

	private void Update()
	{
		if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c28b45877056e09d3c4d6fa790a1517aa())
		{
			return;
		}
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
			if (!m_sync_maxHP_PVP)
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
				if (m_newMaxHP_PVP_Init > 0)
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
					if (m_owner != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						if (m_owner.c5ca38fad98337fc5c7255384b2cd1a86() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							m_sync_maxHP_PVP = true;
							EquipmentInventoryEntity equipmentInventoryEntity = m_owner.c5ca38fad98337fc5c7255384b2cd1a86();
							equipmentInventoryEntity.c9af7b3e5f6626ceef1a0036138121839(m_newMaxHP_PVP_Init);
							equipmentInventoryEntity.cf0a63fdc9831dd55ae40ac6a5f5eb7e0(m_newMaxHP_PVP_Init);
						}
					}
				}
			}
			if (m_sync_maxShield_PVP)
			{
				return;
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				if (m_newMaxShield_PVP_Init <= 0)
				{
					return;
				}
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					if (!(m_owner != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
					{
						return;
					}
					while (true)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						if (!(m_owner.c136b0f223897fdf01d18a9a5e3745433() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
						{
							return;
						}
						while (true)
						{
							switch (3)
							{
							case 0:
								continue;
							}
							m_sync_maxShield_PVP = true;
							EntityShield entityShield = m_owner.c136b0f223897fdf01d18a9a5e3745433();
							entityShield.m_shieldPoints.c82133ff2bb787510ed8585dd3d834b59(m_newMaxShield_PVP_Init);
							entityShield.m_shieldPoints.ca0f7f52805a9c67a892c5b479a17c3aa(m_newMaxShield_PVP_Init);
							return;
						}
					}
				}
			}
		}
	}

	[RPC]
	private void RPC_H2C_SetShieldMax_InTown(float skillScale, float weaponScale, float weaponPostAdd, float curPowerRating, PhotonMessageInfo _info)
	{
		if (m_owner == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return;
				}
			}
		}
		EntityShield entityShield = m_owner.c136b0f223897fdf01d18a9a5e3745433();
		if (!(entityShield != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (entityShield.m_shieldPoints == null)
			{
				return;
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				float num = entityShield.m_shieldPoints.c3326a47fbaf3911cb03db331d9fcd9bf();
				float num2 = num * (weaponScale + skillScale - 1f) + weaponPostAdd * curPowerRating;
				entityShield.m_shieldPoints.c82133ff2bb787510ed8585dd3d834b59((int)num2);
				return;
			}
		}
	}
}
