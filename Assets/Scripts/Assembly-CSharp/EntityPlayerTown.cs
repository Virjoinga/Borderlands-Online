using System;
using System.Collections;
using System.Collections.Generic;
using A;
using Core;
using UnityEngine;

public class EntityPlayerTown : EntityPlayer, InteractionClient
{
	protected int m_currentAimedPlayerID;

	protected PlayerInfoSync m_currentAimedPlayerInfo;

	protected List<EntityPlayer> m_aimedPlayers = new List<EntityPlayer>();

	private HighlightWrapper m_highlight_wrapper = new HighlightWrapper();

	protected override void Awake()
	{
		base.Awake();
		if (!InteractionManager.c5ee19dc8d4cccf5ae2de225410458b86)
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
			InteractionManager.c5ee19dc8d4cccf5ae2de225410458b86.c57e4d4cd41f3be21d7e24a71aa08c6ba(this);
			return;
		}
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		if (!InteractionManager.c5ee19dc8d4cccf5ae2de225410458b86)
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
			InteractionManager.c5ee19dc8d4cccf5ae2de225410458b86.cf5212e6903ec0c0b27816142c32a2d13(this);
			return;
		}
	}

	public override void Start()
	{
		m_equipment = GetComponent<EquipmentInventoryEntityPlayerTown>();
		m_collisionManager = GetComponent<CollisionManager>();
		m_instanceInput = GetComponent<InstanceInput>();
		m_playerController = GetComponent<PlayerController>();
		m_playerBehavior = (PlayerBehavior)GetComponent(Type.GetTypeFromHandle(c0f5d17a33d8cd277a8ef3e79eecf4a03.cc1720d05c75832f704b87474932341c3()));
		m_vfxMgr = GetComponentInChildren<VFXManager>();
		PlayerInfoSync playerInfoSync = cd95354b53e674ec7dc9594e66e4d316f();
		if (playerInfoSync != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			playerInfoSync.c7cd2e714b90259c7cbaa0bd226fe8435(this);
			if (playerInfoSync.c2d17ea39faa888e633ce06615ddf5c6a > PlayerInfoSync.PlayerState.None)
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
				ce8aaeb9ca9b756e07c42f70ffc88ec2a();
			}
			else
			{
				m_handler_statechanged = base.ce8aaeb9ca9b756e07c42f70ffc88ec2a;
				playerInfoSync.c556b16ab244cfd0d587e50a0ea733af2 += m_handler_statechanged;
			}
		}
		base.name = base.name + "(" + playerInfoSync.m_name + ")";
		m_name = playerInfoSync.m_name;
		int num = c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1ee9148b69b784ee94cf0d54409c8ee0(cd95354b53e674ec7dc9594e66e4d316f().m_avatarDna.c071244a19e2d9f70f4d2d6d38677162a(), cd95354b53e674ec7dc9594e66e4d316f().m_exp);
		ItemDNA[] array = cd7e95b9c3ab3ea52b4fc74831d35ced6.c0a0cdf4a196914163f7334d9b0781a04(4);
		ItemDNA c83130c8b3cb0bca5da0dd22b9693898d = c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e;
		byte c688b7ccc0986bb3587eb91f0c9571c7d = 0;
		if (caac907d451029d68503484a63934c93f())
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
			for (int i = 0; i < 4; i++)
			{
				array[i] = c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c4e0dae6a16a8a80ddb5214a896b9df58((byte)i);
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				break;
			}
			c83130c8b3cb0bca5da0dd22b9693898d = c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cec5e771a298fe1e51f84e4ec6dcb5165();
			Inventory inventory = OnAccessSingleton<IInventoryService, InventoryService, InventoryServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c844f1a916a01fdb8a6a6e640d1811cf2(OnlineService.s_characterId, cb8d3896b4fab7d0390a49fc34789c675.c7088de59e49f7108f520cf7e0bae167e);
			if (inventory != null)
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
				c688b7ccc0986bb3587eb91f0c9571c7d = inventory.c91233b4b8268e8e24a4daa8c053e41ec();
			}
		}
		(m_equipment as EquipmentInventoryEntityPlayerTown).cd93285db16841148ed53a5bbeb35cf20((byte)num, array, c83130c8b3cb0bca5da0dd22b9693898d, c688b7ccc0986bb3587eb91f0c9571c7d);
		cdea459d34b5e2c81e7b54f656d605342();
		m_relatedPlayer = this;
		if (playerInfoSync != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (!playerInfoSync.c16d1154aec91a0f8f4a52d77fc081194())
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
				if (GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c87b271fc3048524b0894366245574631(playerInfoSync.m_characterId))
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
					MapObjectMark mapObjectMark = base.gameObject.AddComponent<MapObjectMark>();
					mapObjectMark.ObjType = UIMapDataManager.MiniMapObjectType.TeamMate;
					mapObjectMark.bAlwaysOnMap = true;
					mapObjectMark.cd26ab2539c05dcb4fe11c30d0792cfaf();
				}
			}
		}
		m_isInBattle = false;
		m_skillManager = GetComponent<PlayerSkillManage>();
		if (m_skillManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_skillManager.ccc9d3a38966dc10fedb531ea17d24611();
		}
		m_skillTreeStatus = GetComponent<SkillTreeStatus>();
		m_skillTreeStatus.ccc9d3a38966dc10fedb531ea17d24611();
		m_effectMgr = new PlayerEffectManager(this);
		StatisticsManager.StatSheet statSheet = c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c45046ccb66f97acb081de281306e5c25().cdcb2ff44fc70c31a5ec9c7f0156d8f27(m_playerInfo);
		if (statSheet != null)
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
			statSheet.Reset(m_name);
		}
		c63442ae8c521ed9ec39ab8fef9481e2b();
		m_ability.ce385d5e67ccaf21ebf4f026a4744475e(new SwitchWeapon());
		m_ability.ce385d5e67ccaf21ebf4f026a4744475e(new EquipWeapon());
		m_ability.ce385d5e67ccaf21ebf4f026a4744475e(new EquipShield());
		m_ability.ce385d5e67ccaf21ebf4f026a4744475e(new EquipClassMode());
		cbd67dd78c28bf48a51f4a5e980200357();
	}

	public override void c61f40925cf99c31aa9ac5df098110ada(byte c71953cab9dff52e14146804e2928df92)
	{
		c6cb662b5f4cf63b261aebc6f8f4f85a4(c71953cab9dff52e14146804e2928df92);
	}

	public override void c2bf177eafbfeb7beaa0bfd04facb2029(byte c71953cab9dff52e14146804e2928df92)
	{
		cc138972f2def727f3f514e72eb92827e(c71953cab9dff52e14146804e2928df92);
	}

	public override void c89361444df98c6f8354125e8bdb18882(byte c19a39247ea86ffe5f0de9d429ca0ca95)
	{
		caca8909bc1b1c48be9b9e5b497950bbc(c19a39247ea86ffe5f0de9d429ca0ca95);
	}

	public override void cccb56495987b6a4ebab7b225fb1af261(byte c71953cab9dff52e14146804e2928df92)
	{
		c8cc28bd59a2da591a27cc3e0a7981a44(c71953cab9dff52e14146804e2928df92);
	}

	public override void cc62b4b3e79f635a94d84949382bba1fc(byte c42a8a9b0dd4206315a44f945fbf7331f, byte c5242449e40eab9ce5011e2bacd82070c)
	{
		(c5ca38fad98337fc5c7255384b2cd1a86() as EquipmentInventoryEntityPlayer).cc62b4b3e79f635a94d84949382bba1fc(c42a8a9b0dd4206315a44f945fbf7331f, c5242449e40eab9ce5011e2bacd82070c);
	}

	public override void ccfdbed5cc5051e9ffb25bea212f7ddc6(byte c42a8a9b0dd4206315a44f945fbf7331f, byte c5242449e40eab9ce5011e2bacd82070c)
	{
		(c5ca38fad98337fc5c7255384b2cd1a86() as EquipmentInventoryEntityPlayer).ccfdbed5cc5051e9ffb25bea212f7ddc6(c42a8a9b0dd4206315a44f945fbf7331f, c5242449e40eab9ce5011e2bacd82070c);
	}

	public override void cabac189d699c8d8d56d0e1a68cd1440b(EntityWeapon c5855a8e103463e7269cfc5037b8f30a6, byte c793014f9fd028450a4a9908376309f26)
	{
		StartCoroutine(c2bc2a64e036bf2279503ff5f1337de76(c5855a8e103463e7269cfc5037b8f30a6, c793014f9fd028450a4a9908376309f26));
	}

	private IEnumerator c2bc2a64e036bf2279503ff5f1337de76(EntityWeapon c5855a8e103463e7269cfc5037b8f30a6, byte c793014f9fd028450a4a9908376309f26)
	{
		c5855a8e103463e7269cfc5037b8f30a6.cd93c0dd53b810158c02385f682094c2c();
		while (!c5855a8e103463e7269cfc5037b8f30a6.c39df47367fa21412aabfef05d9972f8c())
		{
			yield return 0;
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
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "EquipWeaponWhenReadyInTown: Model instantiated");
			c42841eb15edb296c94c38f237f57d3dd(c5855a8e103463e7269cfc5037b8f30a6);
			AnimationManager animMng = cb8119a2676bfbd4df00a9ed683eed91a();
			if (!animMng)
			{
				yield break;
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				animMng.OnPickUpWeapon(c5855a8e103463e7269cfc5037b8f30a6);
				yield break;
			}
		}
	}

	public bool c0c9ccf9f6d8cef1e33079d8eaf757b12(Ray cdb5cb253ef1339831696a37475f7233f, ref float c85645ac328a4c6e6c17d3da3be1e11f0)
	{
		if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56())
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
					return false;
				}
			}
		}
		CollisionManager collisionManager = c63f8f07320313ddc4213cb59ee025962();
		if (collisionManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			RaycastHit c3ced719b4780c1919017d69e82521ab;
			if (collisionManager.cd7c958f1e0eea8f346b44512bf8f1ea4(cdb5cb253ef1339831696a37475f7233f, out c3ced719b4780c1919017d69e82521ab, ref c85645ac328a4c6e6c17d3da3be1e11f0))
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						if ((bool)m_playerInfo)
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
							if (!m_playerInfo.c16d1154aec91a0f8f4a52d77fc081194())
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
								c06ca0e618478c23eba3419653a19760f<GuidanceTipsManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnCanInteractWithPlayer();
							}
						}
						return true;
					}
				}
			}
		}
		return false;
	}

	public bool cab69fd15e36704ccac7469787a1570a0(Entity c5d720f6d007abb0c4a21d6a654e405bb)
	{
		if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56())
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
		if ((bool)m_playerInfo)
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
			if (!m_playerInfo.c16d1154aec91a0f8f4a52d77fc081194())
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						return true;
					}
				}
			}
		}
		return false;
	}

	private MenuItemDef[] cf022149fbfec1b9a3b2e3074928913be()
	{
		m_currentAimedPlayerInfo = cd95354b53e674ec7dc9594e66e4d316f(m_currentAimedPlayerID);
		MenuItemDef[] array = cacffdc9bda8a41773c3ac61797275a6c.c0a0cdf4a196914163f7334d9b0781a04(4);
		if (m_currentAimedPlayerInfo != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			array[0].itemTitle = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Group_Invitation"));
			array[0].itemData = m_currentAimedPlayerInfo.m_characterId;
			if (!GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c9b5f43fba87a5416412d8faadde1992a())
			{
				goto IL_00d9;
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				break;
			}
			if (GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c8a142a1ecdf6817b0b02b74d6d1c8796())
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
				if (!GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c87b271fc3048524b0894366245574631(m_currentAimedPlayerInfo.m_characterId))
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
					goto IL_00d9;
				}
			}
			array[0].itemFunc = cb05b540dfaf7d184486e56f02dd45ae3.c7088de59e49f7108f520cf7e0bae167e;
			goto IL_010a;
		}
		goto IL_02b1;
		IL_01b3:
		array[2].itemTitle = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Chat_Send"));
		array[2].itemData = m_currentAimedPlayerInfo.m_name;
		array[2].itemFunc = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<ChatView>().c9c8e5a517b23a2b1acabe838f9baf845;
		array[3].itemTitle = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("GUILD_INVITATION"));
		array[3].itemData = m_currentAimedPlayerInfo.m_characterId;
		if (!GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c17ba091c28b756583dc29d3eec870622())
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
			if (!GuildManager.c71f6ce28731edfd43c976fbd57c57bea().cd6451c6b5252840b2be641871236928f())
			{
				array[3].itemFunc = cb05b540dfaf7d184486e56f02dd45ae3.c7088de59e49f7108f520cf7e0bae167e;
				goto IL_02b1;
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				break;
			}
		}
		array[3].itemFunc = GuildManager.c71f6ce28731edfd43c976fbd57c57bea().c3523f24b7f5c8c0e8868cf3e73f36d20;
		goto IL_02b1;
		IL_00d9:
		array[0].itemFunc = GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c89fcb77276a7956cd51b61c3a4437b0f;
		goto IL_010a;
		IL_02b1:
		return array;
		IL_010a:
		array[1].itemTitle = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Friend_Invitation"));
		array[1].itemData = m_currentAimedPlayerInfo.m_characterId;
		if (!FriendManager.c71f6ce28731edfd43c976fbd57c57bea().c52b0e4c302961935453bec436d84dc68(m_currentAimedPlayerInfo.m_characterId))
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
			if (FriendManager.c71f6ce28731edfd43c976fbd57c57bea().c20292dc0112b596d061ae25400743cc5())
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
				array[1].itemFunc = FriendManager.c71f6ce28731edfd43c976fbd57c57bea().cbbcfd0bf92e11cfa6ba6b913e85d9791;
				goto IL_01b3;
			}
		}
		array[1].itemFunc = cb05b540dfaf7d184486e56f02dd45ae3.c7088de59e49f7108f520cf7e0bae167e;
		goto IL_01b3;
	}

	private List<EntityPlayer> c38036095a3a6faa248fa40a50f9865a0()
	{
		InteractionClient[] array = c06ca0e618478c23eba3419653a19760f<TargetingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_mutilpleInteractions.ToArray();
		m_aimedPlayers.Clear();
		for (int i = 0; i < array.Length; i++)
		{
			EntityPlayer entityPlayer = array[i] as EntityPlayer;
			if (!(entityPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_aimedPlayers.Add(entityPlayer);
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			return m_aimedPlayers;
		}
	}

	private MenuItemDef[] cab7d9e84a27a2ae796947cb54f378541()
	{
		m_aimedPlayers = c38036095a3a6faa248fa40a50f9865a0();
		MenuItemDef[] array = cacffdc9bda8a41773c3ac61797275a6c.c0a0cdf4a196914163f7334d9b0781a04(m_aimedPlayers.Count);
		for (int i = 0; i < array.Length; i++)
		{
			PlayerInfoSync playerInfoSync = m_aimedPlayers[i].cd95354b53e674ec7dc9594e66e4d316f();
			if (i == 0)
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
				m_currentAimedPlayerID = playerInfoSync.m_characterId;
			}
			array[i].itemData = playerInfoSync.m_characterId;
			array[i].itemTitle = playerInfoSync.m_name;
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			return array;
		}
	}

	private PlayerInfoSync cd95354b53e674ec7dc9594e66e4d316f(int c35f98ccbfa8c6bf09319c620b21b5dc5)
	{
		for (int i = 0; i < m_aimedPlayers.Count; i++)
		{
			PlayerInfoSync playerInfoSync = m_aimedPlayers[i].cd95354b53e674ec7dc9594e66e4d316f();
			if (playerInfoSync.m_characterId != c35f98ccbfa8c6bf09319c620b21b5dc5)
			{
				continue;
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
				return playerInfoSync;
			}
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			return null;
		}
	}

	private void c170174ca9ff77e21e0cc1d243a4ef9f7(int c35f98ccbfa8c6bf09319c620b21b5dc5)
	{
		for (int i = 0; i < m_aimedPlayers.Count; i++)
		{
			PlayerInfoSync playerInfoSync = m_aimedPlayers[i].cd95354b53e674ec7dc9594e66e4d316f();
			EntityPlayerTown entityPlayerTown = m_aimedPlayers[i] as EntityPlayerTown;
			if (playerInfoSync.m_characterId == c35f98ccbfa8c6bf09319c620b21b5dc5)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (!(entityPlayerTown != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					break;
				}
				entityPlayerTown.ca3a4e42c026dd118d96d9b26744e311b(E_HighlightType.Golden);
			}
			else
			{
				if (!(entityPlayerTown != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
				{
					continue;
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				entityPlayerTown.ca3a4e42c026dd118d96d9b26744e311b(E_HighlightType.None);
			}
		}
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

	private void c266f0252c730bed4a989f9de07cefac3()
	{
		m_currentAimedPlayerInfo = cd95354b53e674ec7dc9594e66e4d316f(m_currentAimedPlayerID);
		if (!m_currentAimedPlayerInfo)
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
			GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c0d1b2121def725b11ad7317d4212131a(m_currentAimedPlayerInfo.m_characterId);
			FriendManager.c71f6ce28731edfd43c976fbd57c57bea().c0d1b2121def725b11ad7317d4212131a(m_currentAimedPlayerInfo.m_characterId);
			return;
		}
	}

	public void OnPlayerSelected(int id)
	{
		if (m_currentAimedPlayerID == id)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_currentAimedPlayerID = id;
			c266f0252c730bed4a989f9de07cefac3();
			c170174ca9ff77e21e0cc1d243a4ef9f7(m_currentAimedPlayerID);
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PlayerListView>().ca3ea8bd7a9dcad537d36095b45cfcf5c(cf022149fbfec1b9a3b2e3074928913be());
			return;
		}
	}

	private void OnPlayerListClosed(BaseView view, bool bVisible, bool bInner)
	{
		if (bVisible)
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
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PopupMenuView>().cee6e47a3f2472df3eece01f53b58beea(OnPlayerListClosed);
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PlayerListView>().cee6e47a3f2472df3eece01f53b58beea(OnPlayerListClosed);
			c170174ca9ff77e21e0cc1d243a4ef9f7(-1);
			m_currentAimedPlayerID = -1;
			m_aimedPlayers.Clear();
			return;
		}
	}

	public void c4f2632dc55b69776a2b25638b97dedb6(Entity c5d720f6d007abb0c4a21d6a654e405bb, bool c1ccd82293d4f02d70adb2db899caf66f = false)
	{
		if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56())
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
		MenuItemDef[] c6ffe00a26fa81a07fd2c8df9d336f = cab7d9e84a27a2ae796947cb54f378541();
		c266f0252c730bed4a989f9de07cefac3();
		c170174ca9ff77e21e0cc1d243a4ef9f7(m_currentAimedPlayerID);
		if (m_aimedPlayers.Count == 1)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PopupMenuView>().cc4d8eea4e06ec8ec2e166a7004d3700e(OnPlayerListClosed);
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PopupMenuView>().c687c56ed531550f24368180c4c3bc947(cf022149fbfec1b9a3b2e3074928913be(), new Vector2((float)Screen.width * 0.5f, (float)Screen.height * 0.5f));
					return;
				}
			}
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PlayerListView>().cc4d8eea4e06ec8ec2e166a7004d3700e(OnPlayerListClosed);
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<PlayerListView>().c687c56ed531550f24368180c4c3bc947(c6ffe00a26fa81a07fd2c8df9d336f, cf022149fbfec1b9a3b2e3074928913be(), OnPlayerSelected);
	}

	public bool cafe5e3051445e4e581a42f13d84472ee()
	{
		return false;
	}

	public E_USE_TYPE c2aae0ed9fb0e39619e71e33a2e3fc48b()
	{
		return E_USE_TYPE.E_TALK;
	}

	public override void Update()
	{
	}

	protected override IEnumerator c1dbda475e2f6005bc6e1968e8163d5b5()
	{
		for (byte i = 0; i < EntityPlayer.m_WeapnSlotNums; i++)
		{
			yield return StartCoroutine(c3950e6e8b4cd51dc750217b1aa707759(i));
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
			if ((bool)m_equipment.cdda217ef6662acf86a5584ba19758192())
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
				m_equipment.cdda217ef6662acf86a5584ba19758192().c1c5a947f5f8c009fe6fac45c9e29ad1d(this);
				m_equipedWeapon = m_equipment.cdda217ef6662acf86a5584ba19758192();
			}
			c6619cf9e11b07d0d83539685b47e823d();
			yield break;
		}
	}

	protected override IEnumerator c3950e6e8b4cd51dc750217b1aa707759(byte c19a39247ea86ffe5f0de9d429ca0ca95)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "add one weapon:" + c19a39247ea86ffe5f0de9d429ca0ca95);
		while (!(m_equipment as EquipmentInventoryEntityPlayerTown).c39df47367fa21412aabfef05d9972f8c())
		{
			yield return 0;
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
			EntityWeapon weapon2 = ceaa467e9f01cebcf620c4729a7dcef3f.c7088de59e49f7108f520cf7e0bae167e;
			weapon2 = m_equipment.c4e0dae6a16a8a80ddb5214a896b9df58(c19a39247ea86ffe5f0de9d429ca0ca95);
			if (!(weapon2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
			{
				yield break;
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				break;
			}
			while (!weapon2.m_isReady)
			{
				yield return 0;
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "EquipNewWeapon weapon:" + weapon2.c729ce3b5f48e0eac3a7ead97b1d02f8d());
				weapon2.c959567c3d0deab4dacbe2081900e09fd(this);
				yield break;
			}
		}
	}

	protected override IEnumerator cb44f868f4b7a8ce03439794e80a8db52()
	{
		EntityShield shield2 = cfdcd4b1e38674bf0a07bf7a1172dc29c.c7088de59e49f7108f520cf7e0bae167e;
		do
		{
			shield2 = m_equipment.cb4633378bdf6d47c409332e395d58c7a();
			yield return 0;
		}
		while (shield2 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e);
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
			while (!shield2.c39df47367fa21412aabfef05d9972f8c())
			{
				yield return 0;
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				shield2.c1c5a947f5f8c009fe6fac45c9e29ad1d(this);
				yield break;
			}
		}
	}

	public override void ce7f18d227f2281ec702017e97b1553a7(byte c793014f9fd028450a4a9908376309f26)
	{
		if (m_equipment.c20ad6bcf5b5ce2ad75ae35905409f5fa(c793014f9fd028450a4a9908376309f26) == null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_equipment.cb71c24b68b65fe176d7936520d63a102(c793014f9fd028450a4a9908376309f26);
			StartCoroutine(ce763bd1866687d6bcc8efb401b464efc(m_equipment.cdda217ef6662acf86a5584ba19758192()));
			return;
		}
	}

	private IEnumerator ce763bd1866687d6bcc8efb401b464efc(EntityWeapon c39409683a32e09391d094314ffeae2b5)
	{
		if (c39409683a32e09391d094314ffeae2b5 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					yield break;
				}
			}
		}
		while (!c39409683a32e09391d094314ffeae2b5.c39df47367fa21412aabfef05d9972f8c())
		{
			if (c3941dac8608f650ceb15dc36294a741c() != c39409683a32e09391d094314ffeae2b5)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						yield break;
					}
				}
			}
			yield return 0;
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			break;
		}
		while (c39409683a32e09391d094314ffeae2b5.m_owner == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			if (c3941dac8608f650ceb15dc36294a741c() != c39409683a32e09391d094314ffeae2b5)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						yield break;
					}
				}
			}
			yield return 0;
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				continue;
			}
			AnimationManager animMng = cb8119a2676bfbd4df00a9ed683eed91a();
			if (animMng == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						yield break;
					}
				}
			}
			animMng.OnSwitchWeapon(c39409683a32e09391d094314ffeae2b5);
			yield break;
		}
	}

	public void ca3a4e42c026dd118d96d9b26744e311b(E_HighlightType cf2353f300f592cfe033872788352a1be, bool cbf33c7320016d4f4097ef66731046d7b = false)
	{
		m_highlight_wrapper.ca3a4e42c026dd118d96d9b26744e311b(base.gameObject, cf2353f300f592cfe033872788352a1be, cbf33c7320016d4f4097ef66731046d7b);
	}

	public override void c7f7764f5af0ac27b16e2d01b492e5258()
	{
	}

	virtual Vector3 c92d603ba66d53bb9d12c51cf08e9b1d9()
	{
		return c4cf00ced2bc60ae908904eb73692869f();
	}

	Vector3 InteractionClient.c4cf00ced2bc60ae908904eb73692869f()
	{
		//ILSpy generated this explicit interface implementation from .override directive in c92d603ba66d53bb9d12c51cf08e9b1d9
		return this.c92d603ba66d53bb9d12c51cf08e9b1d9();
	}
}
