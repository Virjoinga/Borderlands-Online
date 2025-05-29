using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace BHV_FSM
{
	[XmlInclude(typeof(BHVFSMSettingsIceEarthquakeAttack))]
	[XmlInclude(typeof(BHVFSMSettingsIceMeteorRandomAttack))]
	[XmlInclude(typeof(BHVFSMSettingsEarthPikeAttack))]
	[XmlInclude(typeof(BHVFSMSettingsLaserSweep))]
	[XmlInclude(typeof(BHVFSMSettingsMeleeAttack))]
	[XmlInclude(typeof(BHVFSMSettingsPlayerTeleport))]
	[XmlInclude(typeof(BHVFSMSettingsEyeLaserPlus))]
	[XmlInclude(typeof(BHVFSMSettingsDeathStruggle))]
	[XmlInclude(typeof(BHVFSMSettingsMinionSummon))]
	[XmlInclude(typeof(BHVFSMSettingsIceMeteorRowAttack))]
	[XmlInclude(typeof(BHVFSMSettingsChargeAttack))]
	[XmlInclude(typeof(BHVFSMSettingsJumpAttack))]
	[XmlInclude(typeof(BHVFSMSettingsThrowDaggerAttack))]
	[XmlInclude(typeof(BHVFSMSettingsBurrowAttack))]
	[XmlInclude(typeof(BHVFSMSettingsRadiusAttack))]
	[XmlInclude(typeof(BHVFSMSettingsRoundMeleeAttack))]
	[XmlInclude(typeof(BHVFSMSettingsEyeLaser))]
	[XmlInclude(typeof(BHVFSMSettingsRailGunAttack))]
	[XmlInclude(typeof(BHVFSMSettingsWebTrap))]
	[XmlInclude(typeof(BHVFSMSettingsEnergyMissile))]
	[XmlInclude(typeof(BHVFSMSettingsEnergyBlast))]
	[XmlInclude(typeof(BHVFSMSettingsSpitAttack))]
	[XmlInclude(typeof(BHVFSMSettingsJetAttack))]
	[XmlInclude(typeof(BHVFSMSettingsMortarAttack))]
	[XmlInclude(typeof(BHVFSMSettingsTentacleSpawn))]
	[XmlInclude(typeof(BHVFSMSettingsSuicide))]
	[XmlInclude(typeof(BHVFSMSettingsTentacleSweep))]
	public class BHVPropertySettingsAttackBase : BHVPropertySettings
	{
		public float c9131aa42991afc430ab613143539b516;

		public bool c5b327203cb3b313869d9cf35c4f00dda = true;

		[CompilerGenerated]
		private ENpcAttackMode cc7271d5eee926d7356efbc78cb478155;

		[CompilerGenerated]
		private float c8717f7122ab372a5c7368c916cac327a;

		[CompilerGenerated]
		private float c88fa1a09c57f4d042715662365716654;

		public ENpcAttackMode m_attackMode
		{
			[CompilerGenerated]
			get
			{
				return cc7271d5eee926d7356efbc78cb478155;
			}
			[CompilerGenerated]
			set
			{
				cc7271d5eee926d7356efbc78cb478155 = value;
			}
		}

		[DefaultValue(typeof(float), "1")]
		public float m_attackChanceWeight
		{
			[CompilerGenerated]
			get
			{
				return c8717f7122ab372a5c7368c916cac327a;
			}
			[CompilerGenerated]
			set
			{
				c8717f7122ab372a5c7368c916cac327a = value;
			}
		}

		[DefaultValue(typeof(float), "0")]
		public float m_coolDownTime
		{
			[CompilerGenerated]
			get
			{
				return c88fa1a09c57f4d042715662365716654;
			}
			[CompilerGenerated]
			set
			{
				c88fa1a09c57f4d042715662365716654 = value;
			}
		}

		public BHVPropertySettingsAttackBase()
		{
			m_attackMode = ENpcAttackMode.NAM_None;
			m_attackChanceWeight = 1f;
			m_coolDownTime = 0f;
		}
	}
}
