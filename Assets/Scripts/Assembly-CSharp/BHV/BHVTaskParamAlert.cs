using UnityEngine;

namespace BHV
{
	public sealed class BHVTaskParamAlert : BHVTaskParamAnimationState
	{
		public bool cc7d81a8db99fcd83e60b136f2338a19c;

		public Vector3 cdb7c7eb0eb3e0dcb44595eba0b1a5378;

		public BHVTaskParamAlert()
		{
			base.m_Type = BHVTaskType.Alert;
			cc7d81a8db99fcd83e60b136f2338a19c = false;
		}

		public override void c21abc56059d171e999147f26bbf75889(ref BHVTaskParamSync.Data c90756c75001df916758775f95eee6676, bool ca0a690ca94fac43f6d2dd7209319634b)
		{
			base.c21abc56059d171e999147f26bbf75889(ref c90756c75001df916758775f95eee6676, ca0a690ca94fac43f6d2dd7209319634b);
			if (ca0a690ca94fac43f6d2dd7209319634b)
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
						c90756c75001df916758775f95eee6676.c690ae2dd8233a5203502a2edad03714b = cc7d81a8db99fcd83e60b136f2338a19c;
						c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4 = cdb7c7eb0eb3e0dcb44595eba0b1a5378;
						return;
					}
				}
			}
			cc7d81a8db99fcd83e60b136f2338a19c = c90756c75001df916758775f95eee6676.c690ae2dd8233a5203502a2edad03714b;
			cdb7c7eb0eb3e0dcb44595eba0b1a5378 = c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4;
		}
	}
}
