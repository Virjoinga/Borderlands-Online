using UnityEngine;

namespace BHV
{
	public sealed class BHVTaskParamHoverPatrol : BHVTaskParam
	{
		public Vector3 c9de49121b6b7cf920b8634d8371514e9;

		public BHVTaskParamHoverPatrol()
		{
			base.m_Type = BHVTaskType.HoverPatrol;
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
						c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4 = c9de49121b6b7cf920b8634d8371514e9;
						return;
					}
				}
			}
			c9de49121b6b7cf920b8634d8371514e9 = c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4;
		}
	}
}
