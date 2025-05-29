using UnityEngine;

namespace BHV
{
	public sealed class BHVTaskParamIceEarthquakeAttack : BHVTaskParam
	{
		public int c847416d37b991d227537108be7e018d6 = 10;

		public int c81e29508298978db454dc17ab9bfd675 = 30;

		public int cc76de556484cafe7e7ae83c50164cffe = 5;

		public float c3f10cc4cf174729b94d21593956dc725 = 1.5f;

		public float cdf47769ad622c4e744ee790d4bce92cf = 0.5f;

		public float cb04ae3d0740704306ed2b9109ba63ea1 = 1.5f;

		public GameObject c14854daae2833463b186fc5cc589a09c;

		private int c0f562bde5ff2d23731b86c07aaa322bc;

		public BHVTaskParamIceEarthquakeAttack()
		{
			base.m_Type = BHVTaskType.IceEarthquakeAttack;
		}

		public override void c495597d24b447ad725643e71f5a54375()
		{
			c14854daae2833463b186fc5cc589a09c = BHVTaskParam.ce24b6cf07e186720ddf2f0f5b8e36db5(c0f562bde5ff2d23731b86c07aaa322bc);
		}

		public override void c9e0f906b8d383cc92cdc6bfdc3266fc2()
		{
			c0f562bde5ff2d23731b86c07aaa322bc = BHVTaskParam.cc06b80e952247ccc25281196351a06ea(c14854daae2833463b186fc5cc589a09c);
		}

		public override void c21abc56059d171e999147f26bbf75889(ref BHVTaskParamSync.Data c90756c75001df916758775f95eee6676, bool ca0a690ca94fac43f6d2dd7209319634b)
		{
			base.c21abc56059d171e999147f26bbf75889(ref c90756c75001df916758775f95eee6676, ca0a690ca94fac43f6d2dd7209319634b);
			if (ca0a690ca94fac43f6d2dd7209319634b)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						c90756c75001df916758775f95eee6676.c4dc17c8c736f97081413efcc43072ab4 = c0f562bde5ff2d23731b86c07aaa322bc;
						c90756c75001df916758775f95eee6676.caa1b18212b31f179824db0c752e81263 = c847416d37b991d227537108be7e018d6;
						c90756c75001df916758775f95eee6676.c53325e7ea8d9b49f3e07c9ded47fa5f6 = cc76de556484cafe7e7ae83c50164cffe;
						c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4.x = cdf47769ad622c4e744ee790d4bce92cf;
						c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4.y = cb04ae3d0740704306ed2b9109ba63ea1;
						return;
					}
				}
			}
			c0f562bde5ff2d23731b86c07aaa322bc = c90756c75001df916758775f95eee6676.c4dc17c8c736f97081413efcc43072ab4;
			c847416d37b991d227537108be7e018d6 = c90756c75001df916758775f95eee6676.caa1b18212b31f179824db0c752e81263;
			cc76de556484cafe7e7ae83c50164cffe = c90756c75001df916758775f95eee6676.c53325e7ea8d9b49f3e07c9ded47fa5f6;
			cdf47769ad622c4e744ee790d4bce92cf = c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4.x;
			cb04ae3d0740704306ed2b9109ba63ea1 = c90756c75001df916758775f95eee6676.cc42106392aa3350c9aa3f1157cd1bce4.y;
		}
	}
}
