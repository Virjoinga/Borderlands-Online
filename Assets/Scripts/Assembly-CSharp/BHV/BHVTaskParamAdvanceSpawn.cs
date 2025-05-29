namespace BHV
{
	public sealed class BHVTaskParamAdvanceSpawn : BHVTaskParamAnimationState
	{
		public enum EAdvanceSpawnType
		{
			c281dcfcc0cb4d7f1df2e3947bd9882ce = 0,
			cd4c6462452152f433a2598d8fae14ea1 = 1
		}

		public EAdvanceSpawnType c5ba0fce5895e015467c6c68bb950b1e4;

		public BHVTaskParamAdvanceSpawn()
		{
			base.m_Type = BHVTaskType.AdvanceSpawn;
			c5ba0fce5895e015467c6c68bb950b1e4 = EAdvanceSpawnType.c281dcfcc0cb4d7f1df2e3947bd9882ce;
		}

		public override void c21abc56059d171e999147f26bbf75889(ref BHVTaskParamSync.Data c90756c75001df916758775f95eee6676, bool ca0a690ca94fac43f6d2dd7209319634b)
		{
			base.c21abc56059d171e999147f26bbf75889(ref c90756c75001df916758775f95eee6676, ca0a690ca94fac43f6d2dd7209319634b);
			if (ca0a690ca94fac43f6d2dd7209319634b)
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
						c90756c75001df916758775f95eee6676.c4dc17c8c736f97081413efcc43072ab4 = (int)c5ba0fce5895e015467c6c68bb950b1e4;
						return;
					}
				}
			}
			c5ba0fce5895e015467c6c68bb950b1e4 = (EAdvanceSpawnType)c90756c75001df916758775f95eee6676.c4dc17c8c736f97081413efcc43072ab4;
		}
	}
}
