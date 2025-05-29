using UnityEngine;

namespace BHV
{
	public sealed class BHVTaskParamBurrowAttack : BHVTaskParamAnimationState
	{
		public float ce5e766c95e8eb052ec042fe9c910a1fc;

		public Vector3 c43b879ebd43866fa135bbbda643a6b75;

		public BHVTaskParamBurrowAttack()
		{
			base.m_Type = BHVTaskType.BurrowAttack;
			ce5e766c95e8eb052ec042fe9c910a1fc = 2f;
		}

		public override void c21abc56059d171e999147f26bbf75889(ref BHVTaskParamSync.Data c90756c75001df916758775f95eee6676, bool ca0a690ca94fac43f6d2dd7209319634b)
		{
			base.c21abc56059d171e999147f26bbf75889(ref c90756c75001df916758775f95eee6676, ca0a690ca94fac43f6d2dd7209319634b);
			if (ca0a690ca94fac43f6d2dd7209319634b)
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
						c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4.x = ce5e766c95e8eb052ec042fe9c910a1fc;
						c90756c75001df916758775f95eee6676.c86de8be02f13b9351daaa3dee22fedd1 = c43b879ebd43866fa135bbbda643a6b75;
						return;
					}
				}
			}
			ce5e766c95e8eb052ec042fe9c910a1fc = c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4.x;
			c43b879ebd43866fa135bbbda643a6b75 = c90756c75001df916758775f95eee6676.c86de8be02f13b9351daaa3dee22fedd1;
		}
	}
}
