using System.Collections.Generic;
using A;

public class GuildServiceWrapperOnline : IGuildServiceWrapper, IServiceWrapper
{
	private bool m_isInitializing;

	private bool m_initialized;

	public void cd93285db16841148ed53a5bbeb35cf20()
	{
		if (m_isInitializing)
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
			if (m_initialized)
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
				m_isInitializing = true;
				OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cb035cc1f181480e8a013f496cc66c1a4(c1ee7921b0c3cce194fb7cae41b5a9d82<GuildServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cff4609ca67b17944f17a9f352b2613ec);
				OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cccd5c9bff9923476075b077c7fc87bb5(OnGotMyGuildId);
				OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cc3c08f313aaa41b1b7729959344c15f2(c1ee7921b0c3cce194fb7cae41b5a9d82<GuildServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.ca9cec762dd74c03c8749dc77a25ed449);
				OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cfd73ff44483ffd7fee5c26c41f29532d(c1ee7921b0c3cce194fb7cae41b5a9d82<GuildServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c54c1b3dd8940cd00f0d5c138c597fa13);
				OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c34a79128eb3035ac83d317ad2b784f61(c1ee7921b0c3cce194fb7cae41b5a9d82<GuildServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cf15a5eaed2657a5198cd6491f528fe47);
				OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cd6339b8ad5c928563231ceee927e308b(c1ee7921b0c3cce194fb7cae41b5a9d82<GuildServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c7c5b2658948a4f50ee3430a15470d39d);
				OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c1cf31f72f6f7c6db4792bfafe9aad745(c1ee7921b0c3cce194fb7cae41b5a9d82<GuildServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.ccf96b5751da0a1aeaa6d3f9e5c08df10);
				OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c819e997ca0996c6ed274584c0a6fb707(c1ee7921b0c3cce194fb7cae41b5a9d82<GuildServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c791a20c14adba3a9a530990f95fe91ab);
				OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c8096b4484f32d0bc59cb29f03032e070(c1ee7921b0c3cce194fb7cae41b5a9d82<GuildServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c80fc9b49ebcdd0325e202d5bb8a93e45);
				GuildManager.c71f6ce28731edfd43c976fbd57c57bea();
				return;
			}
		}
	}

	private void OnGotMyGuildId(int guildId)
	{
		m_initialized = true;
	}

	public bool c39df47367fa21412aabfef05d9972f8c()
	{
		return m_initialized;
	}

	public void c75ac0309824b917125cffbd55c6fbd78(ChangeGuildBannerCallback c2db84530ef366a6deb001d449d4aa151, int c394a4be3262a9f37f9a497773fe52a5a, string c619200d57e5378c853c59fa9cc72647c)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c75ac0309824b917125cffbd55c6fbd78(c2db84530ef366a6deb001d449d4aa151, c394a4be3262a9f37f9a497773fe52a5a, c619200d57e5378c853c59fa9cc72647c);
	}

	public void c1c30180f8cf8e8933128caa5e48f49ae(GetMyGuildInfoCallback c2db84530ef366a6deb001d449d4aa151)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c1c30180f8cf8e8933128caa5e48f49ae(c2db84530ef366a6deb001d449d4aa151);
	}

	public void cccd5c9bff9923476075b077c7fc87bb5(GetMyGuildIdCallback c2db84530ef366a6deb001d449d4aa151)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cccd5c9bff9923476075b077c7fc87bb5(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c07fd9706f45f847d4addcf1957b61849(GetGuildInfoCallback c2db84530ef366a6deb001d449d4aa151, int c394a4be3262a9f37f9a497773fe52a5a)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c07fd9706f45f847d4addcf1957b61849(c2db84530ef366a6deb001d449d4aa151, c394a4be3262a9f37f9a497773fe52a5a);
	}

	public void cc4de3bcc457c8dac1f7fc8883cf00603(CreateGuildCallback c2db84530ef366a6deb001d449d4aa151, string cd99af21e22e356018b8f72d4a7e4872a, string c619200d57e5378c853c59fa9cc72647c = null, GuildPreference c6895cb3f6c7f5284072399c244b895cd = GuildPreference.None)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cc4de3bcc457c8dac1f7fc8883cf00603(c2db84530ef366a6deb001d449d4aa151, cd99af21e22e356018b8f72d4a7e4872a, c619200d57e5378c853c59fa9cc72647c, c6895cb3f6c7f5284072399c244b895cd);
	}

	public void c375b2f5564171f0063c8aa9c5f2f9c91(DismissGuildCallback c2db84530ef366a6deb001d449d4aa151, int c394a4be3262a9f37f9a497773fe52a5a)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c375b2f5564171f0063c8aa9c5f2f9c91(c2db84530ef366a6deb001d449d4aa151, c394a4be3262a9f37f9a497773fe52a5a);
	}

	public void c779b55c400efe6490d8243ee1bd96e4d(ChangeGuildMasterCallback c2db84530ef366a6deb001d449d4aa151, int c80802ec65c3305544e11926984c3779d)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c779b55c400efe6490d8243ee1bd96e4d(c2db84530ef366a6deb001d449d4aa151, c80802ec65c3305544e11926984c3779d);
	}

	public void cd7f2c3b464455db93ee7e906dea031be(QuitGuildCallback c2db84530ef366a6deb001d449d4aa151, int c394a4be3262a9f37f9a497773fe52a5a)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cd7f2c3b464455db93ee7e906dea031be(c2db84530ef366a6deb001d449d4aa151, c394a4be3262a9f37f9a497773fe52a5a);
	}

	public void c00df27457e44f5f399286b3f83145d4a(ExpellFromGuildCallback c2db84530ef366a6deb001d449d4aa151, int c394a4be3262a9f37f9a497773fe52a5a, int c1da1cb125daeddb92bac779f82c000c6)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c00df27457e44f5f399286b3f83145d4a(c2db84530ef366a6deb001d449d4aa151, c394a4be3262a9f37f9a497773fe52a5a, c1da1cb125daeddb92bac779f82c000c6);
	}

	public void cd6f90e917c845ddd5202db36d56473e6(SearchGuildCallback c2db84530ef366a6deb001d449d4aa151, GuildPreference c6895cb3f6c7f5284072399c244b895cd, int ce607b3b1cd4098b46cd8bb4f666ecc96 = 50)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cd6f90e917c845ddd5202db36d56473e6(c2db84530ef366a6deb001d449d4aa151, c6895cb3f6c7f5284072399c244b895cd, ce607b3b1cd4098b46cd8bb4f666ecc96);
	}

	public void c80dccacb4ad2025da2fe6f19283df8f6(ApplyToGuildCallback c2db84530ef366a6deb001d449d4aa151, int c394a4be3262a9f37f9a497773fe52a5a)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c80dccacb4ad2025da2fe6f19283df8f6(c2db84530ef366a6deb001d449d4aa151, c394a4be3262a9f37f9a497773fe52a5a);
	}

	public void c508b282423394afe3d81a9f7faa2967b(GetMyGuildApplicationsCallback c2db84530ef366a6deb001d449d4aa151)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c508b282423394afe3d81a9f7faa2967b(c2db84530ef366a6deb001d449d4aa151);
	}

	public void ca17ae57694723b206af5bc3f02aa4d80(CancelMyGuildApplicationCallback c2db84530ef366a6deb001d449d4aa151, int c394a4be3262a9f37f9a497773fe52a5a)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.ca17ae57694723b206af5bc3f02aa4d80(c2db84530ef366a6deb001d449d4aa151, c394a4be3262a9f37f9a497773fe52a5a);
	}

	public void ceeacb24fb9f8879f890a919879452431(GetGuildApplicationsCallback cfa4fdb5692b14f08f3351c01b6dd34ba, int c394a4be3262a9f37f9a497773fe52a5a)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.ceeacb24fb9f8879f890a919879452431(cfa4fdb5692b14f08f3351c01b6dd34ba, c394a4be3262a9f37f9a497773fe52a5a);
	}

	public void c5754d5650a3df3b3f78db32c9e4a0591(ProcessGuildApplicationsCallback c2db84530ef366a6deb001d449d4aa151, int c394a4be3262a9f37f9a497773fe52a5a, List<ApplicantApproval> c405c82881d5a9b84784d976821e033f0)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c5754d5650a3df3b3f78db32c9e4a0591(c2db84530ef366a6deb001d449d4aa151, c394a4be3262a9f37f9a497773fe52a5a, c405c82881d5a9b84784d976821e033f0);
	}

	public void c3523f24b7f5c8c0e8868cf3e73f36d20(InviteToGuildCallback c2db84530ef366a6deb001d449d4aa151, int c394a4be3262a9f37f9a497773fe52a5a, int c064930a80eb0fa8ab1437fac13875990)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c3523f24b7f5c8c0e8868cf3e73f36d20(c2db84530ef366a6deb001d449d4aa151, c394a4be3262a9f37f9a497773fe52a5a, c064930a80eb0fa8ab1437fac13875990);
	}

	public void c2ce74fba6812de9efe750184fdfc0811(GetMyGuildInvitationsCallback c2db84530ef366a6deb001d449d4aa151)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c2ce74fba6812de9efe750184fdfc0811(c2db84530ef366a6deb001d449d4aa151);
	}

	public void cefc501f26eaeadd3f3849859260459bd(ProcessGuildInvitationsCallback c2db84530ef366a6deb001d449d4aa151, List<InvitationReply> c8391ebcfaa5fce0bc92b739fc8dcb216)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cefc501f26eaeadd3f3849859260459bd(c2db84530ef366a6deb001d449d4aa151, c8391ebcfaa5fce0bc92b739fc8dcb216);
	}

	public void cc94fcaeab5d835c80bf5ec715de08e9a(GetMyGuildNewsCallback c2db84530ef366a6deb001d449d4aa151)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cc94fcaeab5d835c80bf5ec715de08e9a(c2db84530ef366a6deb001d449d4aa151);
	}

	public void cb883fc7044d8839b5e1c445e7c5959ab(AssignGuildManagerCallback c2db84530ef366a6deb001d449d4aa151, int c394a4be3262a9f37f9a497773fe52a5a, int c1da1cb125daeddb92bac779f82c000c6)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cb883fc7044d8839b5e1c445e7c5959ab(c2db84530ef366a6deb001d449d4aa151, c394a4be3262a9f37f9a497773fe52a5a, c1da1cb125daeddb92bac779f82c000c6);
	}

	public void cbe14e0cf727992257c34640ca9933a47(DischargeGuildManagerCallback c2db84530ef366a6deb001d449d4aa151, int c394a4be3262a9f37f9a497773fe52a5a, int c1da1cb125daeddb92bac779f82c000c6)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cbe14e0cf727992257c34640ca9933a47(c2db84530ef366a6deb001d449d4aa151, c394a4be3262a9f37f9a497773fe52a5a, c1da1cb125daeddb92bac779f82c000c6);
	}

	public void c853aeff2d4c1e254c7e2970939494fb5(ActivateGuildSkillCallback c2db84530ef366a6deb001d449d4aa151, int cdc3aad41bf2754930ba17d687011c2ea)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c853aeff2d4c1e254c7e2970939494fb5(c2db84530ef366a6deb001d449d4aa151, cdc3aad41bf2754930ba17d687011c2ea);
	}

	public void cd39d9f93990f17659465652406bdc997(GetMyGuildSkillListCallback c2db84530ef366a6deb001d449d4aa151)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.cd39d9f93990f17659465652406bdc997(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c7960fcef25da79e0adcf535b540f54eb(GetGuildManagerListCallback c2db84530ef366a6deb001d449d4aa151, int c394a4be3262a9f37f9a497773fe52a5a)
	{
		OnAccessSingleton<IGuildService, GuildService, GuildServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c7960fcef25da79e0adcf535b540f54eb(c2db84530ef366a6deb001d449d4aa151, c394a4be3262a9f37f9a497773fe52a5a);
	}
}
