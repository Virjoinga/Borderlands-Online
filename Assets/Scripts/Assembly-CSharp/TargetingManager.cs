using System.Collections.Generic;
using A;
using UnityEngine;

public class TargetingManager : c06ca0e618478c23eba3419653a19760f<TargetingManager>
{
	public Ray m_lastAimingRay;

	public Entity m_aimedEntity;

	public InteractionClient m_currentInteraction;

	public InteractionClient m_availableInteraction;

	public InteractionClient m_seeableInteraction;

	public List<InteractionClient> m_mutilpleInteractions = new List<InteractionClient>();

	public Collider m_aimedCollider;

	public float m_distanceToAimed;

	public bool m_autoAiming;

	private Camera m_camera;

	private Vector3 m_screenPosition = Vector3.zero;

	private EntityPlayer m_localPlayerEntity;

	private float m_distance_townNpc;

	public float c60f02ce1a9440fb2d053ec657e58a753
	{
		get
		{
			return m_distance_townNpc;
		}
	}

	private void Update()
	{
		if (m_localPlayerEntity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (1)
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
			PlayerInfoSync playerInfoSync = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56();
			if (playerInfoSync != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
				m_localPlayerEntity = playerInfoSync.c66b232dbebded7c7e9a89c1e8bd84689() as EntityPlayer;
			}
		}
		if (m_camera == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				break;
			}
			m_camera = base.camera;
		}
		if (m_camera != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_screenPosition.Set(m_camera.pixelWidth / 2f, m_camera.pixelHeight / 2f, 0f);
		}
		if (m_localPlayerEntity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (m_camera != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				m_lastAimingRay = m_camera.ScreenPointToRay(m_screenPosition);
				if (m_localPlayerEntity.ce003fe849cc45b85ca4570109817c796())
				{
					while (true)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						m_availableInteraction = cab0600352ac332d43b502ebfa9cc06be.c7088de59e49f7108f520cf7e0bae167e;
						m_aimedEntity = c72d1b2b1b60b723ae8df41127652adb5.c7088de59e49f7108f520cf7e0bae167e;
						return;
					}
				}
				m_distanceToAimed = float.MaxValue;
				m_aimedEntity = TargetingService.cdb2b353157196638ba0e612861776113(m_lastAimingRay, m_localPlayerEntity, out m_aimedCollider, ref m_distanceToAimed, ColliderType.WeakPoint, true);
			}
		}
		cdee3d7a42cda6567728da40070be7d22();
		ca0dd0e1cac91de21d107f1ad2d10e434();
	}

	public void c1303fb339fb3afd9e5931160fcca18cc()
	{
	}

	public void c23b559d4547aa3ece9286f3fadfd44b9()
	{
	}

	private void ca0dd0e1cac91de21d107f1ad2d10e434()
	{
		if (m_autoAiming)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					List<Entity> list = DamageManager.c5ee19dc8d4cccf5ae2de225410458b86.cb8a72c40c1b6db1b4a333f6af978a477();
					Entity entity = c72d1b2b1b60b723ae8df41127652adb5.c7088de59e49f7108f520cf7e0bae167e;
					float num = float.PositiveInfinity;
					for (int i = 0; i < list.Count; i++)
					{
						EquipmentInventoryEntity equipmentInventoryEntity = list[i].c5ca38fad98337fc5c7255384b2cd1a86();
						if (!list[i].caac907d451029d68503484a63934c93f())
						{
							while (true)
							{
								switch (3)
								{
								case 0:
									continue;
								}
								break;
							}
							if (equipmentInventoryEntity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
							{
								while (true)
								{
									switch (5)
									{
									case 0:
										continue;
									}
									break;
								}
								if (equipmentInventoryEntity.ca2ff7a501878363cb1d5f0472e306620() > 0)
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
									float num2 = Vector3.Distance(list[i].c4cf00ced2bc60ae908904eb73692869f(), base.transform.position);
									if (num2 < num)
									{
										while (true)
										{
											switch (3)
											{
											case 0:
												continue;
											}
											break;
										}
										entity = list[i];
										num = num2;
									}
								}
							}
						}
					}
					while (true)
					{
						switch (2)
						{
						case 0:
							break;
						default:
							if (entity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
							{
								while (true)
								{
									switch (7)
									{
									case 0:
										break;
									default:
										if (m_localPlayerEntity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
										{
											while (true)
											{
												switch (5)
												{
												case 0:
													break;
												default:
													if (entity.ccd8e6ea278245d0f158036267242e60f() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
													{
														while (true)
														{
															switch (1)
															{
															case 0:
																continue;
															}
															break;
														}
														if (entity.ccd8e6ea278245d0f158036267242e60f().cb2362c81dda995fcf817a341a4eb3ffb() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
														{
															while (true)
															{
																switch (7)
																{
																case 0:
																	break;
																default:
																	m_localPlayerEntity.c0cf22ec412ee180adea404711b6e7305(entity.ccd8e6ea278245d0f158036267242e60f().cb2362c81dda995fcf817a341a4eb3ffb().transform);
																	return;
																}
															}
														}
													}
													m_localPlayerEntity.c0cf22ec412ee180adea404711b6e7305(entity.transform);
													return;
												}
											}
										}
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
		}
		if (!(m_localPlayerEntity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
		{
			return;
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				continue;
			}
			m_localPlayerEntity.c22cf8c28043e3d3f1b2bac01481e1ffd();
			return;
		}
	}

	private void cdee3d7a42cda6567728da40070be7d22()
	{
		InteractionManager.c5ee19dc8d4cccf5ae2de225410458b86.c54f7becd6f38edcaefd7d35cc9d49e83(m_localPlayerEntity, ref m_availableInteraction, ref m_seeableInteraction, ref m_distance_townNpc);
		if (m_availableInteraction == null)
		{
			return;
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			InteractionManager.c5ee19dc8d4cccf5ae2de225410458b86.c36467fe517a0f42347fb7d43c24ab6b1(m_availableInteraction, ref m_mutilpleInteractions);
			return;
		}
	}

	public bool c69e93962e1ca78e26e0c6dfcd5b44426()
	{
		return m_availableInteraction != cab0600352ac332d43b502ebfa9cc06be.c7088de59e49f7108f520cf7e0bae167e;
	}

	public bool ce3ca8a8aee98e7d85807f76484148792()
	{
		return m_seeableInteraction != cab0600352ac332d43b502ebfa9cc06be.c7088de59e49f7108f520cf7e0bae167e;
	}

	private bool c131b61c31a64bddaf683d44fa2499fb9(InteractionClient c4b957aa30a80c07317b36daa79d12be1)
	{
		int result;
		if (m_availableInteraction != null)
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
			result = ((m_availableInteraction == c4b957aa30a80c07317b36daa79d12be1) ? 1 : 0);
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	private bool ca76d3437763c326a88e3695229761714(InteractionClient c4b957aa30a80c07317b36daa79d12be1)
	{
		if (m_localPlayerEntity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return false;
				}
			}
		}
		Ray cdb5cb253ef1339831696a37475f7233f = new Ray(m_localPlayerEntity.cad7880776eb7b2ddfb106102d4c51bbf(), m_localPlayerEntity.c56fad5727ffebf48f3df62074cd1bbe6());
		float c85645ac328a4c6e6c17d3da3be1e11f = 50f;
		return c4b957aa30a80c07317b36daa79d12be1.c0c9ccf9f6d8cef1e33079d8eaf757b12(cdb5cb253ef1339831696a37475f7233f, ref c85645ac328a4c6e6c17d3da3be1e11f);
	}

	public E_HighlightType cf35cc45fb48a1252b0b5390ab7fd0162(InteractionClient c92be84c2929e14255cef0634f9677b3f, ref bool ca6b449875175a0577177e0ee8f61fd0a)
	{
		E_HighlightType result = E_HighlightType.None;
		if (c131b61c31a64bddaf683d44fa2499fb9(c92be84c2929e14255cef0634f9677b3f))
		{
			while (true)
			{
				switch (7)
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
			result = E_HighlightType.Golden;
			ca6b449875175a0577177e0ee8f61fd0a = cc5074d4add809ae7c1be1a85f14de578();
		}
		else if (ca76d3437763c326a88e3695229761714(c92be84c2929e14255cef0634f9677b3f))
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				break;
			}
			result = E_HighlightType.Silver;
		}
		return result;
	}

	private bool cc5074d4add809ae7c1be1a85f14de578()
	{
		using (List<InteractionClient>.Enumerator enumerator = InteractionManager.c5ee19dc8d4cccf5ae2de225410458b86.c20942eebb8297c02d80277ca67073728().GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				InteractionClient current = enumerator.Current;
				EntityPlayerTown entityPlayerTown = current as EntityPlayerTown;
				if (!(entityPlayerTown != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
				{
					continue;
				}
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
				if (!(entityPlayerTown != m_localPlayerEntity))
				{
					continue;
				}
				while (true)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					break;
				}
				float num = Vector3.Distance(m_localPlayerEntity.transform.position, entityPlayerTown.transform.position);
				float interactionDistance = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_globalSettings.m_interactionDistance;
				if (num >= interactionDistance * 1.5f)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						break;
					}
					continue;
				}
				Ray cdb5cb253ef1339831696a37475f7233f = new Ray(m_localPlayerEntity.cad7880776eb7b2ddfb106102d4c51bbf(), m_localPlayerEntity.c56fad5727ffebf48f3df62074cd1bbe6());
				float c85645ac328a4c6e6c17d3da3be1e11f = interactionDistance;
				if (!current.c0c9ccf9f6d8cef1e33079d8eaf757b12(cdb5cb253ef1339831696a37475f7233f, ref c85645ac328a4c6e6c17d3da3be1e11f))
				{
					continue;
				}
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!(c85645ac328a4c6e6c17d3da3be1e11f <= c60f02ce1a9440fb2d053ec657e58a753))
				{
					continue;
				}
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					return true;
				}
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					goto end_IL_012d;
				}
				continue;
				end_IL_012d:
				break;
			}
		}
		return false;
	}
}
