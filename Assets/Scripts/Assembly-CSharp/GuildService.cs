using System;
using System.Collections;
using System.Collections.Generic;
using A;

public class GuildService : OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>, IGuildService
{
	private ChangeGuildBannerCallback mOnChangedGuildBanner;

	private GetMyGuildInfoCallback mOnGotMyGuildInfo;

	private GetMyGuildIdCallback mOnGotMyGuildId;

	private GetGuildInfoCallback mOnGotGuildInfo;

	private CreateGuildCallback mOnCreatedGuild;

	private DismissGuildCallback mOnDismissedGuild;

	private ChangeGuildMasterCallback mOnChangedGuildMaster;

	private QuitGuildCallback mOnQuitGuild;

	private ExpellFromGuildCallback mOnExpelledFromGuild;

	private SearchGuildCallback mOnSearchedGuild;

	private ApplyToGuildCallback mOnAppliedToGuild;

	private GetMyGuildApplicationsCallback mOnGotMyGuildApplications;

	private CancelMyGuildApplicationCallback mOnCanceledMyGuildApplication;

	private GetGuildApplicationsCallback mOnGotGuildApplications;

	private ProcessGuildApplicationsCallback mOnProcessedGuildApplications;

	private InviteToGuildCallback mOnInvitedToGuild;

	private GetMyGuildInvitationsCallback mOnGotMyGuildInvitations;

	private ProcessGuildInvitationsCallback mOnProcessedGuildInvitations;

	private GetMyGuildNewsCallback mOnGotMyGuildNews;

	private AssignGuildManagerCallback mOnAssignedGuildManager;

	private DischargeGuildManagerCallback mOnDischargedGuildManager;

	private GetMyGuildSkillListCallback mOnGotMyGuildSkillList;

	private ActivateGuildSkillCallback mOnActivatedGuildSkill;

	private GetGuildManagerListCallback mOnGetGuildManagerListCallback;

	private List<ReceiveGuildInvitationCallback> mOnReceivedGuildInvitation = new List<ReceiveGuildInvitationCallback>();

	private List<ReceiveGuildJoinedCallback> mOnReceivedGuildJoined = new List<ReceiveGuildJoinedCallback>();

	private List<ReceiveGuildExpelledCallback> mOnReceivedGuildExpelled = new List<ReceiveGuildExpelledCallback>();

	private List<ReceiveFreeGuildSkillSlotGivenCallback> mOnReceivedFreeGuildSkillSlotGiven = new List<ReceiveFreeGuildSkillSlotGivenCallback>();

	private List<ReceiveGuildSkillSelectedCallback> mOnReceivedGuildSkillSelected = new List<ReceiveGuildSkillSelectedCallback>();

	private List<ReceiveGuildManagerAssignedCallback> mOnReceivedGuildManagerAssigned = new List<ReceiveGuildManagerAssignedCallback>();

	private List<ReceiveGuildManagerDischargedCallback> mOnReceivedGuildManagerDischarged = new List<ReceiveGuildManagerDischargedCallback>();

	private List<ReceiveGuildMasterChangedCallback> mOnReceivedGuildMasterChanged = new List<ReceiveGuildMasterChangedCallback>();

	public GuildService()
	{
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(100, OnChangeGuildBannerCallback);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(101, OnMyGuildInfoCallback);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(102, OnMyGuildIdCallback);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(103, OnGuildInfoCallback);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(104, OnCreateGuildCallback);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(105, OnDismissGuildCallback);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(107, OnChangeGuildMasterCallback);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(112, OnQuitGuildCallback);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(113, OnExpellFromGuildCallback);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(108, OnSearchGuildCallback);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(109, OnApplyToGuildCallback);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(110, OnGetGuildApplicationsCallback);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(77, OnGetMyGuildApplicationsCallback);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(76, OnCancelMyGuildApplicationCallback);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(111, OnProcessGuildApplicationsCallback);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(114, OnInviteToGuildCallback);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(115, OnGetMyGuildInvitationsCallback);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(116, OnProcessGuildInvitationsCallback);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(78, OnGetMyGuildNewsCallback);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(73, OnAssignGuildManagerCallback);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(72, OnDischargeGuildManagerCallback);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(64, OnActivateGuildSkillCallback);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(65, OnGetMyGuildSkillListCallback);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(63, OnGetGuildManagerListCallback);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(231, OnGuildInvitationEvent);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(232, OnGuildJoinedEvent);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(233, OnGuildExpelledEvent);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(234, OnFreeGuildSkillSlotGivenEvent);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(235, OnGuildSkillSelectedEvent);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(236, OnGuildManagerAssignedEvent);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(237, OnGuildManagerDischargedEvent);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(238, OnGuildMasterChangedEvent);
	}

	public void c75ac0309824b917125cffbd55c6fbd78(ChangeGuildBannerCallback c2db84530ef366a6deb001d449d4aa151, int cedbc5e8a9b3885fca16b21bd3e96e028, string c619200d57e5378c853c59fa9cc72647c)
	{
		mOnChangedGuildBanner = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(2);
		array[0] = cedbc5e8a9b3885fca16b21bd3e96e028;
		array[1] = c619200d57e5378c853c59fa9cc72647c;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(100, array);
	}

	private void OnChangeGuildBannerCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnChangedGuildBanner == null)
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
			if (operationResponse == 0)
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
				mOnChangedGuildBanner(true);
			}
			else
			{
				mOnChangedGuildBanner(false);
			}
			mOnChangedGuildBanner = c00793bcbef34f79706ed30b2b628df6f.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void c1c30180f8cf8e8933128caa5e48f49ae(GetMyGuildInfoCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mOnGotMyGuildInfo = c2db84530ef366a6deb001d449d4aa151;
		PhotonNetwork.onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(101, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
	}

	private void OnMyGuildInfoCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnGotMyGuildInfo == null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (operationResponse == 0)
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
				if (parameters.Count == 2)
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
					if (parameters[0] != null)
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
						if (parameters[1] != null)
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
							int guildId = (int)parameters[0];
							Guild guildInfo = new Guild((Hashtable)parameters[1]);
							mOnGotMyGuildInfo(guildId, guildInfo);
							goto IL_00b0;
						}
					}
				}
			}
			mOnGotMyGuildInfo(-1, ce7a54a45dbe39fa8df21d851b9bd8980.c7088de59e49f7108f520cf7e0bae167e);
			goto IL_00b0;
			IL_00b0:
			mOnGotMyGuildInfo = c5bc2bbd12fa175b4c534793106944a4e.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void cccd5c9bff9923476075b077c7fc87bb5(GetMyGuildIdCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mOnGotMyGuildId = c2db84530ef366a6deb001d449d4aa151;
		PhotonNetwork.onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(102, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
	}

	private void OnMyGuildIdCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnGotMyGuildId == null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (operationResponse == 0)
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
				if (parameters.Count > 0)
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
					if (parameters[0] != null)
					{
						while (true)
						{
							switch (6)
							{
							case 0:
								continue;
							}
							break;
						}
						int guildId = (int)parameters[0];
						mOnGotMyGuildId(guildId);
						goto IL_007e;
					}
				}
			}
			mOnGotMyGuildId(-1);
			goto IL_007e;
			IL_007e:
			mOnGotMyGuildId = c1c7ffda4fa9f78fa07e1bcfda2a4d7d3.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void c07fd9706f45f847d4addcf1957b61849(GetGuildInfoCallback c2db84530ef366a6deb001d449d4aa151, int c394a4be3262a9f37f9a497773fe52a5a)
	{
		mOnGotGuildInfo = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c394a4be3262a9f37f9a497773fe52a5a;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(103, array);
	}

	private void OnGuildInfoCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnGotGuildInfo == null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (operationResponse == 0)
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
				if (parameters.Count > 0)
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
					if (parameters[0] != null)
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
						Guild guildInfo = new Guild((Hashtable)parameters[0]);
						mOnGotGuildInfo(guildInfo);
						goto IL_0087;
					}
				}
			}
			mOnGotGuildInfo(ce7a54a45dbe39fa8df21d851b9bd8980.c7088de59e49f7108f520cf7e0bae167e);
			goto IL_0087;
			IL_0087:
			mOnGotGuildInfo = c7d833d77e19508d0d4eaf3095914b2da.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void cc4de3bcc457c8dac1f7fc8883cf00603(CreateGuildCallback c2db84530ef366a6deb001d449d4aa151, string cd99af21e22e356018b8f72d4a7e4872a, string c619200d57e5378c853c59fa9cc72647c = null, GuildPreference c6895cb3f6c7f5284072399c244b895cd = GuildPreference.None)
	{
		mOnCreatedGuild = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(3);
		array[0] = cd99af21e22e356018b8f72d4a7e4872a;
		array[1] = c619200d57e5378c853c59fa9cc72647c;
		array[2] = c6895cb3f6c7f5284072399c244b895cd;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(104, array);
	}

	private void OnCreateGuildCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnCreatedGuild == null)
		{
			return;
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			GuildCreationResult result;
			CreateGuildCallback createGuildCallback;
			Guild guildInfo;
			if (operationResponse == 0)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					break;
				}
				if (parameters.Count > 0)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						break;
					}
					if (parameters[0] != null)
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
						result = (GuildCreationResult)(int)parameters[0];
						createGuildCallback = mOnCreatedGuild;
						if (parameters.Count > 1)
						{
							while (true)
							{
								switch (6)
								{
								case 0:
									continue;
								}
								break;
							}
							if (parameters[1] != null)
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
								guildInfo = new Guild((Hashtable)parameters[1]);
								goto IL_00b5;
							}
						}
						guildInfo = ce7a54a45dbe39fa8df21d851b9bd8980.c7088de59e49f7108f520cf7e0bae167e;
						goto IL_00b5;
					}
				}
			}
			mOnCreatedGuild(GuildCreationResult.FAILURE_ETC, ce7a54a45dbe39fa8df21d851b9bd8980.c7088de59e49f7108f520cf7e0bae167e);
			goto IL_00ce;
			IL_00ce:
			mOnCreatedGuild = c4e853f4f487eaf727c0fab361daf5e75.c7088de59e49f7108f520cf7e0bae167e;
			return;
			IL_00b5:
			createGuildCallback(result, guildInfo);
			goto IL_00ce;
		}
	}

	public void c375b2f5564171f0063c8aa9c5f2f9c91(DismissGuildCallback c2db84530ef366a6deb001d449d4aa151, int c394a4be3262a9f37f9a497773fe52a5a)
	{
		mOnDismissedGuild = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c394a4be3262a9f37f9a497773fe52a5a;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(105, array);
	}

	private void OnDismissGuildCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnDismissedGuild == null)
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
			if (operationResponse == 0)
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
				mOnDismissedGuild(true);
			}
			else
			{
				mOnDismissedGuild(false);
			}
			mOnDismissedGuild = c79eb3d9ce8850e739c7a8c1ee876fa91.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void c779b55c400efe6490d8243ee1bd96e4d(ChangeGuildMasterCallback c2db84530ef366a6deb001d449d4aa151, int c80802ec65c3305544e11926984c3779d)
	{
		mOnChangedGuildMaster = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c80802ec65c3305544e11926984c3779d;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(107, array);
	}

	private void OnChangeGuildMasterCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnChangedGuildMaster == null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (operationResponse == 0)
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
				if (parameters.Count > 0)
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
					if (parameters[0] != null)
					{
						while (true)
						{
							switch (6)
							{
							case 0:
								continue;
							}
							break;
						}
						int changedCharacterId = Convert.ToInt32(parameters[0]);
						mOnChangedGuildMaster(true, changedCharacterId);
						goto IL_0082;
					}
				}
			}
			mOnChangedGuildMaster(false, 0);
			goto IL_0082;
			IL_0082:
			mOnChangedGuildMaster = cc4141c47bca9e107ca3a5ef4968a43a3.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void cd7f2c3b464455db93ee7e906dea031be(QuitGuildCallback c2db84530ef366a6deb001d449d4aa151, int c394a4be3262a9f37f9a497773fe52a5a)
	{
		mOnQuitGuild = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c394a4be3262a9f37f9a497773fe52a5a;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(112, array);
	}

	private void OnQuitGuildCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnQuitGuild == null)
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
			if (operationResponse == 0)
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
				mOnQuitGuild(true);
			}
			else
			{
				mOnQuitGuild(false);
			}
			mOnQuitGuild = cbcc5f48ccc5a1e5601c2101070f41ffc.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void c00df27457e44f5f399286b3f83145d4a(ExpellFromGuildCallback c2db84530ef366a6deb001d449d4aa151, int c394a4be3262a9f37f9a497773fe52a5a, int c1da1cb125daeddb92bac779f82c000c6)
	{
		mOnExpelledFromGuild = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(2);
		array[0] = c394a4be3262a9f37f9a497773fe52a5a;
		array[1] = c1da1cb125daeddb92bac779f82c000c6;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(113, array);
	}

	private void OnExpellFromGuildCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnExpelledFromGuild == null)
		{
			return;
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (operationResponse == 0)
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
				if (parameters.Count > 0)
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
					if (parameters[0] != null)
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
						int expelledCharacterId = Convert.ToInt32(parameters[0]);
						mOnExpelledFromGuild(true, expelledCharacterId);
						goto IL_0082;
					}
				}
			}
			mOnExpelledFromGuild(false, 0);
			goto IL_0082;
			IL_0082:
			mOnExpelledFromGuild = c702aee75ad535079787cb17be5eb9e1e.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void cd6f90e917c845ddd5202db36d56473e6(SearchGuildCallback c2db84530ef366a6deb001d449d4aa151, GuildPreference c6895cb3f6c7f5284072399c244b895cd, int ce607b3b1cd4098b46cd8bb4f666ecc96 = 50)
	{
		mOnSearchedGuild = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(2);
		array[0] = c6895cb3f6c7f5284072399c244b895cd;
		array[1] = ce607b3b1cd4098b46cd8bb4f666ecc96;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(108, array);
	}

	private void OnSearchGuildCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnSearchedGuild == null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			List<Guild> list = new List<Guild>();
			list.Clear();
			if (operationResponse == 0)
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
				if (parameters.Count > 0)
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
					if (parameters[0] != null)
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
						using (Dictionary<byte, object>.ValueCollection.Enumerator enumerator = parameters.Values.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								object current = enumerator.Current;
								Hashtable cd22aa6735988e8e65acbd503f3870e3e = (Hashtable)current;
								list.Add(new Guild(cd22aa6735988e8e65acbd503f3870e3e));
							}
							while (true)
							{
								switch (5)
								{
								case 0:
									break;
								default:
									goto end_IL_009e;
								}
								continue;
								end_IL_009e:
								break;
							}
						}
					}
				}
			}
			mOnSearchedGuild(list);
			mOnSearchedGuild = c9c88c9d760ff081fcda38da6513cc4f1.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void c80dccacb4ad2025da2fe6f19283df8f6(ApplyToGuildCallback c2db84530ef366a6deb001d449d4aa151, int c394a4be3262a9f37f9a497773fe52a5a)
	{
		mOnAppliedToGuild = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c394a4be3262a9f37f9a497773fe52a5a;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(109, array);
	}

	private void OnApplyToGuildCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnAppliedToGuild == null)
		{
			return;
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (operationResponse == 0)
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
				if (parameters.Count > 0)
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
					if (parameters[0] != null)
					{
						while (true)
						{
							switch (6)
							{
							case 0:
								continue;
							}
							break;
						}
						int guildId = Convert.ToInt32(parameters[0]);
						mOnAppliedToGuild(true, guildId);
						goto IL_0082;
					}
				}
			}
			mOnAppliedToGuild(false, 0);
			goto IL_0082;
			IL_0082:
			mOnAppliedToGuild = c479df2d5a47e7d426e2c1bb6ad0ea2c7.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void ca17ae57694723b206af5bc3f02aa4d80(CancelMyGuildApplicationCallback c2db84530ef366a6deb001d449d4aa151, int c394a4be3262a9f37f9a497773fe52a5a)
	{
		mOnCanceledMyGuildApplication = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c394a4be3262a9f37f9a497773fe52a5a;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(76, array);
	}

	private void OnCancelMyGuildApplicationCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnCanceledMyGuildApplication == null)
		{
			return;
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (operationResponse == 0)
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
				mOnCanceledMyGuildApplication(true);
			}
			else
			{
				mOnCanceledMyGuildApplication(false);
			}
			mOnCanceledMyGuildApplication = c1627e3b2d0eac634999cdb38a6552b06.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void c508b282423394afe3d81a9f7faa2967b(GetMyGuildApplicationsCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mOnGotMyGuildApplications = c2db84530ef366a6deb001d449d4aa151;
		PhotonNetwork.onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(77, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
	}

	private void OnGetMyGuildApplicationsCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnGotMyGuildApplications == null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			List<Guild> list = new List<Guild>();
			list.Clear();
			if (operationResponse == 0)
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
				if (parameters.Count > 0)
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
					if (parameters[0] != null)
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
						using (Dictionary<byte, object>.ValueCollection.Enumerator enumerator = parameters.Values.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								object current = enumerator.Current;
								Hashtable cd22aa6735988e8e65acbd503f3870e3e = (Hashtable)current;
								list.Add(new Guild(cd22aa6735988e8e65acbd503f3870e3e));
							}
							while (true)
							{
								switch (4)
								{
								case 0:
									break;
								default:
									goto end_IL_009e;
								}
								continue;
								end_IL_009e:
								break;
							}
						}
					}
				}
			}
			mOnGotMyGuildApplications(list);
			mOnGotMyGuildApplications = c6305cd88c371c58961054fa1914686f2.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void ceeacb24fb9f8879f890a919879452431(GetGuildApplicationsCallback c2db84530ef366a6deb001d449d4aa151, int c394a4be3262a9f37f9a497773fe52a5a)
	{
		mOnGotGuildApplications = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c394a4be3262a9f37f9a497773fe52a5a;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(110, array);
	}

	private void OnGetGuildApplicationsCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnGotGuildApplications == null)
		{
			return;
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (operationResponse == 0)
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
				if (parameters.Count > 0)
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
					List<Presence> list = new List<Presence>();
					using (Dictionary<byte, object>.ValueCollection.Enumerator enumerator = parameters.Values.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							object current = enumerator.Current;
							Hashtable c90ecb087828ed9ceb9c00eafb6d52f4c = (Hashtable)current;
							list.Add(new Presence(c90ecb087828ed9ceb9c00eafb6d52f4c));
						}
						while (true)
						{
							switch (1)
							{
							case 0:
								break;
							default:
								goto end_IL_0083;
							}
							continue;
							end_IL_0083:
							break;
						}
					}
					mOnGotGuildApplications(list);
					goto IL_00b9;
				}
			}
			mOnGotGuildApplications(c019cbcce6665e314c5a9ded22b7bf99f.c7088de59e49f7108f520cf7e0bae167e);
			goto IL_00b9;
			IL_00b9:
			mOnGotGuildApplications = c82e4a78a92c6abeb6be9837068ae8a75.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void c5754d5650a3df3b3f78db32c9e4a0591(ProcessGuildApplicationsCallback c2db84530ef366a6deb001d449d4aa151, int c394a4be3262a9f37f9a497773fe52a5a, List<ApplicantApproval> c405c82881d5a9b84784d976821e033f0)
	{
		mOnProcessedGuildApplications = c2db84530ef366a6deb001d449d4aa151;
		Dictionary<int, Hashtable> dictionary = new Dictionary<int, Hashtable>();
		int num = 0;
		using (List<ApplicantApproval>.Enumerator enumerator = c405c82881d5a9b84784d976821e033f0.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ApplicantApproval current = enumerator.Current;
				dictionary[num++] = new Hashtable
				{
					{ 0, current.ApplicantCharacterId },
					{ 1, current.IsAllowedToJoin }
				};
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
				break;
			}
		}
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(2);
		array[0] = c394a4be3262a9f37f9a497773fe52a5a;
		array[1] = dictionary;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(111, array);
	}

	private void OnProcessGuildApplicationsCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnProcessedGuildApplications == null)
		{
			return;
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (operationResponse == 0)
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
				if (parameters.Count > 0)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						break;
					}
					if (parameters[0] != null)
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
						int newMemberCount = Convert.ToInt32(parameters[0]);
						int failedApplicationCount = Convert.ToInt32(parameters[1]);
						mOnProcessedGuildApplications(newMemberCount, failedApplicationCount);
						goto IL_0093;
					}
				}
			}
			mOnProcessedGuildApplications(0, 0);
			goto IL_0093;
			IL_0093:
			mOnProcessedGuildApplications = c89342bb6bb870af87ff6aa03700aaf6d.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void c3523f24b7f5c8c0e8868cf3e73f36d20(InviteToGuildCallback c2db84530ef366a6deb001d449d4aa151, int c394a4be3262a9f37f9a497773fe52a5a, int c064930a80eb0fa8ab1437fac13875990)
	{
		mOnInvitedToGuild = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(2);
		array[0] = c394a4be3262a9f37f9a497773fe52a5a;
		array[1] = c064930a80eb0fa8ab1437fac13875990;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(114, array);
	}

	private void OnInviteToGuildCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnInvitedToGuild == null)
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
			if (operationResponse == 0)
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
				if (parameters.Count > 0)
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
					if (parameters[0] != null)
					{
						while (true)
						{
							switch (6)
							{
							case 0:
								continue;
							}
							break;
						}
						GuildInvitationResult result = (GuildInvitationResult)(int)parameters[0];
						mOnInvitedToGuild(result);
						goto IL_007e;
					}
				}
			}
			mOnInvitedToGuild(GuildInvitationResult.FAILURE_ETC);
			goto IL_007e;
			IL_007e:
			mOnInvitedToGuild = c2ff7362b2c09cebf6b7e4d319fa94d44.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void c2ce74fba6812de9efe750184fdfc0811(GetMyGuildInvitationsCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mOnGotMyGuildInvitations = c2db84530ef366a6deb001d449d4aa151;
		PhotonNetwork.onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(115, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
	}

	private void OnGetMyGuildInvitationsCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnGotMyGuildInvitations == null)
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
			if (operationResponse == 0)
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
				if (parameters.Count > 0)
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
					List<Invitation> list = new List<Invitation>();
					using (Dictionary<byte, object>.ValueCollection.Enumerator enumerator = parameters.Values.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							object current = enumerator.Current;
							Hashtable cd22aa6735988e8e65acbd503f3870e3e = (Hashtable)current;
							list.Add(new Invitation(cd22aa6735988e8e65acbd503f3870e3e));
						}
						while (true)
						{
							switch (6)
							{
							case 0:
								break;
							default:
								goto end_IL_0083;
							}
							continue;
							end_IL_0083:
							break;
						}
					}
					mOnGotMyGuildInvitations(list);
					goto IL_00b9;
				}
			}
			mOnGotMyGuildInvitations(c0b4e42bbff2ab975ee61015dd47a554a.c7088de59e49f7108f520cf7e0bae167e);
			goto IL_00b9;
			IL_00b9:
			mOnGotMyGuildInvitations = cd59ea8fd9dad1ecfd3c183839a74bcbc.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void cefc501f26eaeadd3f3849859260459bd(ProcessGuildInvitationsCallback c2db84530ef366a6deb001d449d4aa151, List<InvitationReply> c8391ebcfaa5fce0bc92b739fc8dcb216)
	{
		mOnProcessedGuildInvitations = c2db84530ef366a6deb001d449d4aa151;
		Dictionary<int, Hashtable> dictionary = new Dictionary<int, Hashtable>();
		int num = 0;
		using (List<InvitationReply>.Enumerator enumerator = c8391ebcfaa5fce0bc92b739fc8dcb216.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				InvitationReply current = enumerator.Current;
				dictionary[num++] = new Hashtable
				{
					{ 0, current.GuildId },
					{ 1, current.Reply },
					{ 2, current.GuildInviterCharacterId }
				};
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
				break;
			}
		}
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = dictionary;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(116, array);
	}

	private void OnProcessGuildInvitationsCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnProcessedGuildInvitations == null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (operationResponse == 0)
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
				if (parameters.Count > 0)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						break;
					}
					if (parameters[0] != null)
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
						mOnProcessedGuildInvitations(new Guild((Hashtable)parameters[0]));
						goto IL_0085;
					}
				}
			}
			mOnProcessedGuildInvitations(ce7a54a45dbe39fa8df21d851b9bd8980.c7088de59e49f7108f520cf7e0bae167e);
			goto IL_0085;
			IL_0085:
			mOnProcessedGuildInvitations = c0be0d2ea9a3ca4cab190d5f54150a8cf.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void cc94fcaeab5d835c80bf5ec715de08e9a(GetMyGuildNewsCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mOnGotMyGuildNews = c2db84530ef366a6deb001d449d4aa151;
		PhotonNetwork.onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(78, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
	}

	private void OnGetMyGuildNewsCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnGotMyGuildNews == null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (operationResponse == 0)
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
				if (parameters.Count > 0)
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
					List<GuildNews> list = new List<GuildNews>();
					using (Dictionary<byte, object>.ValueCollection.Enumerator enumerator = parameters.Values.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							object current = enumerator.Current;
							Hashtable cd22aa6735988e8e65acbd503f3870e3e = (Hashtable)current;
							list.Add(new GuildNews(cd22aa6735988e8e65acbd503f3870e3e));
						}
						while (true)
						{
							switch (3)
							{
							case 0:
								break;
							default:
								goto end_IL_0083;
							}
							continue;
							end_IL_0083:
							break;
						}
					}
					mOnGotMyGuildNews(list);
					goto IL_00b9;
				}
			}
			mOnGotMyGuildNews(c4800027e103e4d9d72528b6e7390764f.c7088de59e49f7108f520cf7e0bae167e);
			goto IL_00b9;
			IL_00b9:
			mOnGotMyGuildNews = c5100bea4772d726120fedb689b940a8a.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void cbe14e0cf727992257c34640ca9933a47(DischargeGuildManagerCallback c2db84530ef366a6deb001d449d4aa151, int c394a4be3262a9f37f9a497773fe52a5a, int c1da1cb125daeddb92bac779f82c000c6)
	{
		mOnDischargedGuildManager = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(2);
		array[0] = c394a4be3262a9f37f9a497773fe52a5a;
		array[1] = c1da1cb125daeddb92bac779f82c000c6;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(72, array);
	}

	private void OnDischargeGuildManagerCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnDischargedGuildManager == null)
		{
			return;
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (operationResponse == 0)
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
				if (parameters.Count > 0)
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
					if (parameters[0] != null)
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
						int dischargedCharacterId = Convert.ToInt32(parameters[0]);
						mOnDischargedGuildManager(true, dischargedCharacterId);
						goto IL_0082;
					}
				}
			}
			mOnDischargedGuildManager(false, 0);
			goto IL_0082;
			IL_0082:
			mOnDischargedGuildManager = cf8a4723a69a27ea1578a6ae0bd4c6e1a.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void cb883fc7044d8839b5e1c445e7c5959ab(AssignGuildManagerCallback c2db84530ef366a6deb001d449d4aa151, int c394a4be3262a9f37f9a497773fe52a5a, int c1da1cb125daeddb92bac779f82c000c6)
	{
		mOnAssignedGuildManager = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(2);
		array[0] = c394a4be3262a9f37f9a497773fe52a5a;
		array[1] = c1da1cb125daeddb92bac779f82c000c6;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(73, array);
	}

	private void OnAssignGuildManagerCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnAssignedGuildManager == null)
		{
			return;
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
			if (operationResponse == 0)
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
				if (parameters.Count > 0)
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
					if (parameters[0] != null)
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
						int assignedCharacterId = Convert.ToInt32(parameters[0]);
						mOnAssignedGuildManager(true, assignedCharacterId);
						goto IL_0082;
					}
				}
			}
			mOnAssignedGuildManager(false, 0);
			goto IL_0082;
			IL_0082:
			mOnAssignedGuildManager = c173ff491c0bff43bc116bdbf45d38f4f.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void c7960fcef25da79e0adcf535b540f54eb(GetGuildManagerListCallback c2db84530ef366a6deb001d449d4aa151, int c394a4be3262a9f37f9a497773fe52a5a)
	{
		mOnGetGuildManagerListCallback = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c394a4be3262a9f37f9a497773fe52a5a;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(63, array);
	}

	private void OnGetGuildManagerListCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnGetGuildManagerListCallback == null)
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
			if (operationResponse == 0)
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
				if (parameters.Count > 0)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						break;
					}
					List<int> list = new List<int>();
					IEnumerator enumerator = ((Hashtable)parameters[0]).Values.GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							object current = enumerator.Current;
							list.Add(Convert.ToInt32(current));
						}
						while (true)
						{
							switch (7)
							{
							case 0:
								break;
							default:
								goto end_IL_008c;
							}
							continue;
							end_IL_008c:
							break;
						}
					}
					finally
					{
						IDisposable disposable = enumerator as IDisposable;
						if (disposable == null)
						{
							while (true)
							{
								switch (3)
								{
								case 0:
									break;
								default:
									goto end_IL_00a2;
								}
								continue;
								end_IL_00a2:
								break;
							}
						}
						else
						{
							disposable.Dispose();
						}
					}
					mOnGetGuildManagerListCallback(list);
				}
			}
			mOnGetGuildManagerListCallback = c2caa990c06fc2dc9c802d67476ab13de.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void cd39d9f93990f17659465652406bdc997(GetMyGuildSkillListCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mOnGotMyGuildSkillList = c2db84530ef366a6deb001d449d4aa151;
		PhotonNetwork.onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(65, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
	}

	private void OnGetMyGuildSkillListCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnGotMyGuildSkillList == null)
		{
			return;
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (operationResponse == 0)
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
				if (parameters.Count > 0)
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
					List<GuildSkill> list = new List<GuildSkill>();
					using (Dictionary<byte, object>.ValueCollection.Enumerator enumerator = parameters.Values.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							object current = enumerator.Current;
							list.Add(new GuildSkill((Hashtable)current));
						}
						while (true)
						{
							switch (5)
							{
							case 0:
								break;
							default:
								goto end_IL_0081;
							}
							continue;
							end_IL_0081:
							break;
						}
					}
					mOnGotMyGuildSkillList(list);
				}
			}
			mOnGotMyGuildSkillList = c83ea1a75253b1054c79afd6c2b8b896e.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	public void c853aeff2d4c1e254c7e2970939494fb5(ActivateGuildSkillCallback c2db84530ef366a6deb001d449d4aa151, int cdc3aad41bf2754930ba17d687011c2ea)
	{
		mOnActivatedGuildSkill = c2db84530ef366a6deb001d449d4aa151;
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = cdc3aad41bf2754930ba17d687011c2ea;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(64, array);
	}

	private void OnActivateGuildSkillCallback(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnActivatedGuildSkill == null)
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
			if (operationResponse == 0)
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
				if (parameters.Count > 0)
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
					mOnActivatedGuildSkill(true, Convert.ToInt32(parameters[0]));
					goto IL_0068;
				}
			}
			mOnActivatedGuildSkill(false, 0);
			goto IL_0068;
			IL_0068:
			mOnActivatedGuildSkill = ce12dbc5056bd66b326dd082852213fc0.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	private void OnGuildInvitationEvent(Dictionary<byte, object> parameters)
	{
		if (parameters.Count < 3)
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
					return;
				}
			}
		}
		int guildId = Convert.ToInt32(parameters[0]);
		string masterName = Convert.ToString(parameters[1]);
		string guildName = Convert.ToString(parameters[2]);
		mOnReceivedGuildInvitation.ForEach(delegate(ReceiveGuildInvitationCallback c2db84530ef366a6deb001d449d4aa151)
		{
			c2db84530ef366a6deb001d449d4aa151(guildId, masterName, guildName);
		});
	}

	public void cc3c08f313aaa41b1b7729959344c15f2(ReceiveGuildInvitationCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mOnReceivedGuildInvitation.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c3b7b4999ead1b9fedaeb96ff16393e91(ReceiveGuildInvitationCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mOnReceivedGuildInvitation.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	private void OnGuildJoinedEvent(Dictionary<byte, object> parameters)
	{
		if (parameters.Count < 2)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return;
				}
			}
		}
		int guildId = Convert.ToInt32(parameters[0]);
		string guildName = Convert.ToString(parameters[1]);
		mOnReceivedGuildJoined.ForEach(delegate(ReceiveGuildJoinedCallback c2db84530ef366a6deb001d449d4aa151)
		{
			c2db84530ef366a6deb001d449d4aa151(guildId, guildName);
		});
	}

	public void cfd73ff44483ffd7fee5c26c41f29532d(ReceiveGuildJoinedCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mOnReceivedGuildJoined.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c6efc5d7c51ca6c85e4097d00dc9b2953(ReceiveGuildJoinedCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mOnReceivedGuildJoined.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	private void OnGuildExpelledEvent(Dictionary<byte, object> parameters)
	{
		if (parameters.Count < 2)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return;
				}
			}
		}
		int guildId = Convert.ToInt32(parameters[0]);
		string guildName = Convert.ToString(parameters[1]);
		mOnReceivedGuildExpelled.ForEach(delegate(ReceiveGuildExpelledCallback c2db84530ef366a6deb001d449d4aa151)
		{
			c2db84530ef366a6deb001d449d4aa151(guildId, guildName);
		});
	}

	public void c34a79128eb3035ac83d317ad2b784f61(ReceiveGuildExpelledCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mOnReceivedGuildExpelled.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c3d2ff3581b6161df3e9f53a754ae13c9(ReceiveGuildExpelledCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mOnReceivedGuildExpelled.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	private void OnFreeGuildSkillSlotGivenEvent(Dictionary<byte, object> parameters)
	{
		if (parameters.Count < 2)
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
					return;
				}
			}
		}
		int guildId = Convert.ToInt32(parameters[0]);
		int remainFreeSkillCount = Convert.ToInt32(parameters[1]);
		mOnReceivedFreeGuildSkillSlotGiven.ForEach(delegate(ReceiveFreeGuildSkillSlotGivenCallback c2db84530ef366a6deb001d449d4aa151)
		{
			c2db84530ef366a6deb001d449d4aa151(guildId, remainFreeSkillCount);
		});
	}

	public void cd6339b8ad5c928563231ceee927e308b(ReceiveFreeGuildSkillSlotGivenCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mOnReceivedFreeGuildSkillSlotGiven.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c741b14882be8b6016b45ac00b7c57911(ReceiveFreeGuildSkillSlotGivenCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mOnReceivedFreeGuildSkillSlotGiven.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	private void OnGuildSkillSelectedEvent(Dictionary<byte, object> parameters)
	{
		if (parameters.Count < 3)
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
					return;
				}
			}
		}
		int guildId = Convert.ToInt32(parameters[0]);
		int skillId = Convert.ToInt32(parameters[1]);
		int remainFreeSkillCount = Convert.ToInt32(parameters[2]);
		mOnReceivedGuildSkillSelected.ForEach(delegate(ReceiveGuildSkillSelectedCallback c2db84530ef366a6deb001d449d4aa151)
		{
			c2db84530ef366a6deb001d449d4aa151(guildId, skillId, remainFreeSkillCount);
		});
	}

	public void cb035cc1f181480e8a013f496cc66c1a4(ReceiveGuildSkillSelectedCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mOnReceivedGuildSkillSelected.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c8c93a199fbddd1ca4e571b743bddfed2(ReceiveGuildSkillSelectedCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mOnReceivedGuildSkillSelected.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	private void OnGuildManagerAssignedEvent(Dictionary<byte, object> parameters)
	{
		if (parameters.Count < 1)
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
					return;
				}
			}
		}
		int guildId = Convert.ToInt32(parameters[0]);
		mOnReceivedGuildManagerAssigned.ForEach(delegate(ReceiveGuildManagerAssignedCallback c2db84530ef366a6deb001d449d4aa151)
		{
			c2db84530ef366a6deb001d449d4aa151(guildId);
		});
	}

	public void c1cf31f72f6f7c6db4792bfafe9aad745(ReceiveGuildManagerAssignedCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mOnReceivedGuildManagerAssigned.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c4716fd5b3fdf6c6da11857a34151534a(ReceiveGuildManagerAssignedCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mOnReceivedGuildManagerAssigned.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	private void OnGuildManagerDischargedEvent(Dictionary<byte, object> parameters)
	{
		if (parameters.Count < 1)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return;
				}
			}
		}
		int guildId = Convert.ToInt32(parameters[0]);
		mOnReceivedGuildManagerDischarged.ForEach(delegate(ReceiveGuildManagerDischargedCallback c2db84530ef366a6deb001d449d4aa151)
		{
			c2db84530ef366a6deb001d449d4aa151(guildId);
		});
	}

	public void c819e997ca0996c6ed274584c0a6fb707(ReceiveGuildManagerDischargedCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mOnReceivedGuildManagerDischarged.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c11508bec6f0a727200b0be58366b0b6c(ReceiveGuildManagerDischargedCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mOnReceivedGuildManagerDischarged.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	private void OnGuildMasterChangedEvent(Dictionary<byte, object> parameters)
	{
		if (parameters.Count < 1)
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
					return;
				}
			}
		}
		int guildId = Convert.ToInt32(parameters[0]);
		mOnReceivedGuildMasterChanged.ForEach(delegate(ReceiveGuildMasterChangedCallback c2db84530ef366a6deb001d449d4aa151)
		{
			c2db84530ef366a6deb001d449d4aa151(guildId);
		});
	}

	public void c8096b4484f32d0bc59cb29f03032e070(ReceiveGuildMasterChangedCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mOnReceivedGuildMasterChanged.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c768294a1d24bf13e19d17e91f1b751be(ReceiveGuildMasterChangedCallback c2db84530ef366a6deb001d449d4aa151)
	{
		mOnReceivedGuildMasterChanged.Remove(c2db84530ef366a6deb001d449d4aa151);
	}
}
