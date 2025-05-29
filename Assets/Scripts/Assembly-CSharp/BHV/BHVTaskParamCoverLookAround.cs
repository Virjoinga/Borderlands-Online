namespace BHV
{
	public sealed class BHVTaskParamCoverLookAround : BHVTaskParamAnimationState
	{
		public CoverSlot.CoverHeight c717e5cc6398513ae1b501fafdc23be53;

		public float c8d6d0618a619c5377bfa2192b652bb59;

		public BHVTaskParamCoverLookAround()
		{
			base.m_Type = BHVTaskType.CoverLookAround;
			c717e5cc6398513ae1b501fafdc23be53 = CoverSlot.CoverHeight.INVALID;
			c8d6d0618a619c5377bfa2192b652bb59 = 0f;
		}

		public override void c21abc56059d171e999147f26bbf75889(ref BHVTaskParamSync.Data c90756c75001df916758775f95eee6676, bool ca0a690ca94fac43f6d2dd7209319634b)
		{
			base.c21abc56059d171e999147f26bbf75889(ref c90756c75001df916758775f95eee6676, ca0a690ca94fac43f6d2dd7209319634b);
			if (ca0a690ca94fac43f6d2dd7209319634b)
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
						c90756c75001df916758775f95eee6676.c717e5cc6398513ae1b501fafdc23be53 = c717e5cc6398513ae1b501fafdc23be53;
						c90756c75001df916758775f95eee6676.c8d6d0618a619c5377bfa2192b652bb59 = c8d6d0618a619c5377bfa2192b652bb59;
						return;
					}
				}
			}
			c717e5cc6398513ae1b501fafdc23be53 = c90756c75001df916758775f95eee6676.c717e5cc6398513ae1b501fafdc23be53;
			c8d6d0618a619c5377bfa2192b652bb59 = c90756c75001df916758775f95eee6676.c8d6d0618a619c5377bfa2192b652bb59;
		}
	}
}
