using Core;
using UnityEngine;
using XsdSettings;

public class AttackInfo
{
	public enum AttackType
	{
		Projectile = 0,
		Area = 1,
		Melee = 2,
		DamageOverTime = 3,
		Charge = 4,
		Recover = 5,
		Skill = 6
	}

	public enum ElementalType
	{
		None = 0,
		Fire = 1,
		Shock = 2,
		Corrosive = 3,
		Explosive = 4,
		Max = 5
	}

	public AttackSubType m_subType;

	public int m_attacker;

	public int m_owner;

	public int m_target;

	public Vector3 m_origin;

	public Vector3 m_direction;

	public float m_range;

	public double m_timeStamp;

	public int m_damagePoint;

	public AttackInfo()
	{
	}

	public AttackInfo(AttackSubType ccefb70d1c6517764559a52080e56d522)
	{
		m_subType = ccefb70d1c6517764559a52080e56d522;
	}

	public AttackInfo(AttackInfo c095f59bf32567f9716f72d707585375b)
	{
		m_subType = c095f59bf32567f9716f72d707585375b.m_subType;
		m_attacker = c095f59bf32567f9716f72d707585375b.m_attacker;
		m_target = c095f59bf32567f9716f72d707585375b.m_target;
		m_origin = c095f59bf32567f9716f72d707585375b.m_origin;
		m_direction = c095f59bf32567f9716f72d707585375b.m_direction;
		m_timeStamp = c095f59bf32567f9716f72d707585375b.m_timeStamp;
		m_damagePoint = c095f59bf32567f9716f72d707585375b.m_damagePoint;
	}

	public static AttackType cb40d9d92cf67eb5b4aecc077640e0f4e(AttackSubType ccefb70d1c6517764559a52080e56d522)
	{
		if (ccefb70d1c6517764559a52080e56d522 > AttackSubType.ProjectileFirst)
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
			if (ccefb70d1c6517764559a52080e56d522 < AttackSubType.ProjectileLast)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						return AttackType.Projectile;
					}
				}
			}
		}
		if (ccefb70d1c6517764559a52080e56d522 > AttackSubType.AreaFirst)
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
			if (ccefb70d1c6517764559a52080e56d522 < AttackSubType.AreaLast)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						return AttackType.Area;
					}
				}
			}
		}
		if (ccefb70d1c6517764559a52080e56d522 > AttackSubType.MeleeFirst)
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
			if (ccefb70d1c6517764559a52080e56d522 < AttackSubType.MeleeLast)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						return AttackType.Melee;
					}
				}
			}
		}
		if (ccefb70d1c6517764559a52080e56d522 > AttackSubType.DamageOverTimeFirst)
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
			if (ccefb70d1c6517764559a52080e56d522 < AttackSubType.DamageOverTimeLast)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						return AttackType.DamageOverTime;
					}
				}
			}
		}
		if (ccefb70d1c6517764559a52080e56d522 > AttackSubType.ChargeFirst)
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
			if (ccefb70d1c6517764559a52080e56d522 < AttackSubType.ChargeLast)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						return AttackType.Charge;
					}
				}
			}
		}
		if (ccefb70d1c6517764559a52080e56d522 > AttackSubType.RecoverFirst)
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
			if (ccefb70d1c6517764559a52080e56d522 < AttackSubType.RecoverLast)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						return AttackType.Recover;
					}
				}
			}
		}
		if (ccefb70d1c6517764559a52080e56d522 > AttackSubType.SkillFirst)
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
			if (ccefb70d1c6517764559a52080e56d522 < AttackSubType.SkillLast)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						return AttackType.Skill;
					}
				}
			}
		}
		DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, string.Concat("Invalid Attack Sub Type [", ccefb70d1c6517764559a52080e56d522, "]"));
		return AttackType.Projectile;
	}

	public static ElementalType cd949fd4db8e262c24b57d93db37f93bf(AttackSubType ccefb70d1c6517764559a52080e56d522)
	{
		switch (ccefb70d1c6517764559a52080e56d522)
		{
		case AttackSubType.DamageOverTimeFirebird:
			return ElementalType.Fire;
		case AttackSubType.DamageOverTimeFire:
			return ElementalType.Fire;
		case AttackSubType.DamageOverTimeShock:
			return ElementalType.Shock;
		case AttackSubType.DamageOverTimeCorrosive:
			return ElementalType.Corrosive;
		default:
			return ElementalType.None;
		}
	}

	public AttackType c070529b1f39068ce13a5e9ed5c480b92()
	{
		return cb40d9d92cf67eb5b4aecc077640e0f4e(m_subType);
	}
}
