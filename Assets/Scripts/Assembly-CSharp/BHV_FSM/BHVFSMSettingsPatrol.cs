using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	public class BHVFSMSettingsPatrol : BHVPropertySettings
	{
		[CompilerGenerated]
		private float c4305efc07cf296bee0c1ed6469af0041;

		[CompilerGenerated]
		private float cb02226640b6839f49a5cd4828017544e;

		[CompilerGenerated]
		private float c84f95facadbf925a76786018a7553e0f;

		[CompilerGenerated]
		private float cd260fe4258933e50bd8b99c996185e9a;

		[CompilerGenerated]
		private float c5ad2ee059bf05983873c8287ab98345f;

		[DefaultValue(typeof(float), "0")]
		public float m_patrolRadius
		{
			[CompilerGenerated]
			get
			{
				return c4305efc07cf296bee0c1ed6469af0041;
			}
			[CompilerGenerated]
			set
			{
				c4305efc07cf296bee0c1ed6469af0041 = value;
			}
		}

		[DefaultValue(typeof(float), "0")]
		public float m_patrolTime
		{
			[CompilerGenerated]
			get
			{
				return cb02226640b6839f49a5cd4828017544e;
			}
			[CompilerGenerated]
			set
			{
				cb02226640b6839f49a5cd4828017544e = value;
			}
		}

		[DefaultValue(typeof(float), "0")]
		public float m_chanceToIdleWhenReachPatrolPoint
		{
			[CompilerGenerated]
			get
			{
				return c84f95facadbf925a76786018a7553e0f;
			}
			[CompilerGenerated]
			set
			{
				c84f95facadbf925a76786018a7553e0f = value;
			}
		}

		[DefaultValue(typeof(float), "0")]
		public float m_stayIdleTimeMin
		{
			[CompilerGenerated]
			get
			{
				return cd260fe4258933e50bd8b99c996185e9a;
			}
			[CompilerGenerated]
			set
			{
				cd260fe4258933e50bd8b99c996185e9a = value;
			}
		}

		[DefaultValue(typeof(float), "0")]
		public float m_stayIdleTimeMax
		{
			[CompilerGenerated]
			get
			{
				return c5ad2ee059bf05983873c8287ab98345f;
			}
			[CompilerGenerated]
			set
			{
				c5ad2ee059bf05983873c8287ab98345f = value;
			}
		}

		public BHVFSMSettingsPatrol()
		{
			m_patrolRadius = 0f;
			m_patrolTime = 0f;
			m_chanceToIdleWhenReachPatrolPoint = 0f;
			m_stayIdleTimeMin = 0f;
			m_stayIdleTimeMax = 0f;
		}
	}
}
