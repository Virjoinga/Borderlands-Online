using UnityEngine;

namespace BHV
{
	public class BHVTaskLavaStrike : BHVTask
	{
		private BHVTaskParamLavaStrike c2227ddc7fcbe3fa329465d2fa8ffb479;

		private AnimationLavaStrikeState ce113c4eb20cf560d20f4894ad27be17a;

		private AIServiceCurve.Curve c3cbf455ba458fa064c80d16602c566d0 = new AIServiceCurve.Curve();

		private bool c6fea320beeb1e2b1394c38263a70008b;

		public BHVTaskLavaStrike()
		{
			base.m_Type = BHVTaskType.LavaStrike;
			base.m_Layer = BHVTaskLayer.FULLBODY;
		}

		public override bool cd6c2cd7bb7b266ba7083ce848641dd61(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
		{
			c2227ddc7fcbe3fa329465d2fa8ffb479 = cdbade0534e8f60b8dbad77a5270d9acf as BHVTaskParamLavaStrike;
			return base.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf);
		}

		public override BHVTaskParam cdf3fed1b3e2fb4370b5db53be9c44580()
		{
			return c2227ddc7fcbe3fa329465d2fa8ffb479;
		}

		public override void Start()
		{
			base.Start();
			ce113c4eb20cf560d20f4894ad27be17a = cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c059bb29245b8e57e3b793798ddfdb249("LavaStrike") as AnimationLavaStrikeState;
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM.LavaStrike);
			c6fea320beeb1e2b1394c38263a70008b = false;
			if (!c3cbf455ba458fa064c80d16602c566d0.cec13c99f505a1259251e1a9d93313b6c(cfc241af7ab51814fc074e767be1a0bb8.m_entity.transform.position, c2227ddc7fcbe3fa329465d2fa8ffb479.cb27477f78390e696816571af70122c22, 1f))
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				base.m_Status = BHVTaskStatus.FAILED;
			}
			cfc241af7ab51814fc074e767be1a0bb8.m_animationManagerFSM.m_validateNextMovePosition = false;
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			if (base.m_Status == BHVTaskStatus.FAILED)
			{
				return;
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (base.m_Status == BHVTaskStatus.SUCCESS)
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							return;
						}
					}
				}
				if (!c6fea320beeb1e2b1394c38263a70008b)
				{
					while (true)
					{
						switch (4)
						{
						case 0:
							continue;
						}
						break;
					}
					if (ce113c4eb20cf560d20f4894ad27be17a.m_bJumpLoop)
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
							{
								Vector3 newPosition;
								c6fea320beeb1e2b1394c38263a70008b = c3cbf455ba458fa064c80d16602c566d0.Update(deltaTime, 12f, out newPosition);
								cfc241af7ab51814fc074e767be1a0bb8.transform.position = newPosition;
								if (c6fea320beeb1e2b1394c38263a70008b)
								{
									while (true)
									{
										switch (6)
										{
										case 0:
											break;
										default:
											ce113c4eb20cf560d20f4894ad27be17a.OnLanded();
											return;
										}
									}
								}
								return;
							}
							}
						}
					}
				}
				if (!ce113c4eb20cf560d20f4894ad27be17a.m_bLavaStrikeEnd)
				{
					return;
				}
				while (true)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					base.m_Status = BHVTaskStatus.SUCCESS;
					return;
				}
			}
		}

		public override void c496c317832865f592876a12acfff494f(bool ce5e813b93a5483775927292e3ba4b8ef)
		{
			cfc241af7ab51814fc074e767be1a0bb8.m_entity.c3bf54d312726877e5f77b6d475aef510();
			base.c496c317832865f592876a12acfff494f(ce5e813b93a5483775927292e3ba4b8ef);
		}
	}
}
