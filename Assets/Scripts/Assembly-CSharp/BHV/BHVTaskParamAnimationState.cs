namespace BHV
{
	public class BHVTaskParamAnimationState : BHVTaskParam
	{
		public AnimationStateFSM cd4c6f5bc0ffba00956fa80fc2758673f;

		public BHVTaskParamAnimationState()
		{
			base.m_Type = BHVTaskType.PlayAnimation;
			cd4c6f5bc0ffba00956fa80fc2758673f = AnimationStateFSM.Invalid;
		}

		public override void c21abc56059d171e999147f26bbf75889(ref BHVTaskParamSync.Data c90756c75001df916758775f95eee6676, bool ca0a690ca94fac43f6d2dd7209319634b)
		{
			base.c21abc56059d171e999147f26bbf75889(ref c90756c75001df916758775f95eee6676, ca0a690ca94fac43f6d2dd7209319634b);
			if (base.m_Type != BHVTaskType.PlayAnimation)
			{
				return;
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
				if (ca0a690ca94fac43f6d2dd7209319634b)
				{
					while (true)
					{
						switch (7)
						{
						case 0:
							break;
						default:
							c90756c75001df916758775f95eee6676.cd4c6f5bc0ffba00956fa80fc2758673f = cd4c6f5bc0ffba00956fa80fc2758673f;
							return;
						}
					}
				}
				cd4c6f5bc0ffba00956fa80fc2758673f = c90756c75001df916758775f95eee6676.cd4c6f5bc0ffba00956fa80fc2758673f;
				return;
			}
		}
	}
}
