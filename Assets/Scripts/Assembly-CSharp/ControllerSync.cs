using System.IO;
using A;
using Core;
using UnityEngine;

public class ControllerSync : MonoBehaviour, IPhotonSerializeView
{
	public PhotonView photonView { get; set; }

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.c8b2526be2638bb30a29ab8314b369311)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
				{
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
								break;
							default:
							{
								EntityPlayer entityPlayer = (EntityPlayer)playerInfoSync.c66b232dbebded7c7e9a89c1e8bd84689();
								if (entityPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
								{
									while (true)
									{
										switch (1)
										{
										case 0:
											break;
										default:
										{
											if (entityPlayer.cd95354b53e674ec7dc9594e66e4d316f().c2d17ea39faa888e633ce06615ddf5c6a != PlayerInfoSync.PlayerState.Spawned)
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
											InputFrame[] c37e1cf2b46ecb86ace924133d77dee;
											entityPlayer.GetComponent<InstanceInput>().c0b8c911a7411887fd2c5cdb0d89fc41d(out c37e1cf2b46ecb86ace924133d77dee);
											stream.caf7283cc5cd9725a88a9cdfa630d92f8(c023e655b3374ae122b1be89dacf987d2(c37e1cf2b46ecb86ace924133d77dee));
											return;
										}
										}
									}
								}
								return;
							}
							}
						}
					}
					return;
				}
				}
			}
		}
		if (!(c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			PhotonPlayer sender = info.sender;
			if (sender != null)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
					{
						PlayerInfoSync playerInfoSync2 = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.cb062638207d3746ee631744a4709b38f(sender.c29a834d12d3895f5680e69a30e6cd9a3);
						if ((bool)playerInfoSync2)
						{
							while (true)
							{
								switch (7)
								{
								case 0:
									break;
								default:
								{
									Entity entity = playerInfoSync2.c66b232dbebded7c7e9a89c1e8bd84689();
									if ((bool)entity)
									{
										while (true)
										{
											switch (1)
											{
											case 0:
												break;
											default:
											{
												InstanceInput component = entity.GetComponent<InstanceInput>();
												if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
												{
													while (true)
													{
														switch (2)
														{
														case 0:
															break;
														default:
														{
															byte[] c98dd5bedd676b4f9bcb3f75a8663a26e = (byte[])stream.cbc3e6f46d26c8fb00a98f05fc700248a();
															InputFrame[] c37e1cf2b46ecb86ace924133d77dee2;
															c6dba84585a5341d35fc0d3ae5c99000c(c98dd5bedd676b4f9bcb3f75a8663a26e, out c37e1cf2b46ecb86ace924133d77dee2);
															StatisticsManager.SessionStats sessionStats = c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c45046ccb66f97acb081de281306e5c25();
															if (sessionStats != null)
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
																StatisticsManager.StatSheet statSheet = sessionStats.cdcb2ff44fc70c31a5ec9c7f0156d8f27(playerInfoSync2);
																if (statSheet != null)
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
																	statSheet.c9924fc82f3b52e12b6256075475bdd9c(NetworkManager.c802128e3d024dd79aaf8dc5f4b18f6a0(sender.c29a834d12d3895f5680e69a30e6cd9a3));
																}
															}
															if (c37e1cf2b46ecb86ace924133d77dee2.Length > 0)
															{
																while (true)
																{
																	switch (5)
																	{
																	case 0:
																		break;
																	default:
																		component.c3bff30866b755ede02c1825cdf526fea(c37e1cf2b46ecb86ace924133d77dee2);
																		return;
																	}
																}
															}
															return;
														}
														}
													}
												}
												return;
											}
											}
										}
									}
									return;
								}
								}
							}
						}
						return;
					}
					}
				}
			}
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Network, "info.sender is null");
			return;
		}
	}

	private byte[] c023e655b3374ae122b1be89dacf987d2(InputFrame[] c633ba514513654371e7840224d9972f9)
	{
		MemoryStream memoryStream = new MemoryStream();
		for (int i = 0; i < c633ba514513654371e7840224d9972f9.Length; i++)
		{
			memoryStream.Write(InputFrame.c00ae05b9ced94c9fc5f4be4892e6192b(c633ba514513654371e7840224d9972f9[i]), 0, InputFrame.c5c3c145d54edc727770887f87bea1217());
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			return memoryStream.ToArray();
		}
	}

	private void c6dba84585a5341d35fc0d3ae5c99000c(byte[] c98dd5bedd676b4f9bcb3f75a8663a26e, out InputFrame[] c37e1cf2b46ecb86ace924133d77dee40)
	{
		MemoryStream memoryStream = new MemoryStream();
		int num = c98dd5bedd676b4f9bcb3f75a8663a26e.Length / InputFrame.c5c3c145d54edc727770887f87bea1217();
		memoryStream.Write(c98dd5bedd676b4f9bcb3f75a8663a26e, 0, c98dd5bedd676b4f9bcb3f75a8663a26e.Length);
		memoryStream.Seek(0L, SeekOrigin.Begin);
		c37e1cf2b46ecb86ace924133d77dee40 = c65f63442bbfa453f3e9f60c2e845dbe7.c0a0cdf4a196914163f7334d9b0781a04(num);
		for (int i = 0; i < num; i++)
		{
			byte[] array = ce2f159fe707a376b497f666c368f15ed.c0a0cdf4a196914163f7334d9b0781a04(InputFrame.c5c3c145d54edc727770887f87bea1217());
			memoryStream.Read(array, 0, InputFrame.c5c3c145d54edc727770887f87bea1217());
			c37e1cf2b46ecb86ace924133d77dee40[i] = InputFrame.c00ae05b9ced94c9fc5f4be4892e6192b(array);
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			return;
		}
	}
}
