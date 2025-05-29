using UnityEngine;

namespace BHV
{
	public sealed class BHVTaskParamPlayerTeleport : BHVTaskParam
	{
		public GameObject cb9f7c51b162366e74587b2610dae6e64;

		public float ce744e5319e80ee316e783f0fce8ad670 = 5f;

		public float ca87f7a171027e8176ea195a9a92f70f4 = 4f;

		public float cb0600547448517b2371af69450201ec5 = 0.5f;

		private int c5611894dccdb85f1301ba212f2ce913a;

		public BHVTaskParamPlayerTeleport()
		{
			base.m_Type = BHVTaskType.PlayerTeleport;
			c5611894dccdb85f1301ba212f2ce913a = -1;
		}

		public override void c495597d24b447ad725643e71f5a54375()
		{
			cb9f7c51b162366e74587b2610dae6e64 = BHVTaskParam.ce24b6cf07e186720ddf2f0f5b8e36db5(c5611894dccdb85f1301ba212f2ce913a);
		}

		public override void c9e0f906b8d383cc92cdc6bfdc3266fc2()
		{
			c5611894dccdb85f1301ba212f2ce913a = BHVTaskParam.cc06b80e952247ccc25281196351a06ea(cb9f7c51b162366e74587b2610dae6e64);
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
						c90756c75001df916758775f95eee6676.c4dc17c8c736f97081413efcc43072ab4 = c5611894dccdb85f1301ba212f2ce913a;
						c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4.x = ce744e5319e80ee316e783f0fce8ad670;
						c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4.y = ca87f7a171027e8176ea195a9a92f70f4;
						c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4.z = cb0600547448517b2371af69450201ec5;
						return;
					}
				}
			}
			c5611894dccdb85f1301ba212f2ce913a = c90756c75001df916758775f95eee6676.c4dc17c8c736f97081413efcc43072ab4;
			ce744e5319e80ee316e783f0fce8ad670 = c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4.x;
			ca87f7a171027e8176ea195a9a92f70f4 = c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4.y;
			cb0600547448517b2371af69450201ec5 = c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4.z;
		}
	}
}
