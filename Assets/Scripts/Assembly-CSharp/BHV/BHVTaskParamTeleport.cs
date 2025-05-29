using UnityEngine;

namespace BHV
{
	public sealed class BHVTaskParamTeleport : BHVTaskParam
	{
		public Vector3 c0bce9a1c21060e38a32aef1b647809fb;

		public Vector3 cc98ce48a9d5760a53aee7ca82e028df0;

		public float ca4dcddde017e1f3c4febaf10ce176ff7;

		public float ce603272242c63e7a2434f5103a7345bc;

		public float c594bb07e142a1dd16741953c76325d6b;

		public BHVTaskParamTeleport()
		{
			base.m_Type = BHVTaskType.Teleport;
		}

		public override void c21abc56059d171e999147f26bbf75889(ref BHVTaskParamSync.Data c90756c75001df916758775f95eee6676, bool ca0a690ca94fac43f6d2dd7209319634b)
		{
			base.c21abc56059d171e999147f26bbf75889(ref c90756c75001df916758775f95eee6676, ca0a690ca94fac43f6d2dd7209319634b);
			if (ca0a690ca94fac43f6d2dd7209319634b)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4 = c0bce9a1c21060e38a32aef1b647809fb;
						c90756c75001df916758775f95eee6676.c86de8be02f13b9351daaa3dee22fedd1 = cc98ce48a9d5760a53aee7ca82e028df0;
						c90756c75001df916758775f95eee6676.c1d766887e94dca7977e3a4b88558c892.x = ca4dcddde017e1f3c4febaf10ce176ff7;
						c90756c75001df916758775f95eee6676.c1d766887e94dca7977e3a4b88558c892.y = ce603272242c63e7a2434f5103a7345bc;
						c90756c75001df916758775f95eee6676.c1d766887e94dca7977e3a4b88558c892.z = c594bb07e142a1dd16741953c76325d6b;
						return;
					}
				}
			}
			c0bce9a1c21060e38a32aef1b647809fb = c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4;
			cc98ce48a9d5760a53aee7ca82e028df0 = c90756c75001df916758775f95eee6676.c86de8be02f13b9351daaa3dee22fedd1;
			ca4dcddde017e1f3c4febaf10ce176ff7 = c90756c75001df916758775f95eee6676.c1d766887e94dca7977e3a4b88558c892.x;
			ce603272242c63e7a2434f5103a7345bc = c90756c75001df916758775f95eee6676.c1d766887e94dca7977e3a4b88558c892.y;
			c594bb07e142a1dd16741953c76325d6b = c90756c75001df916758775f95eee6676.c1d766887e94dca7977e3a4b88558c892.z;
		}
	}
}
