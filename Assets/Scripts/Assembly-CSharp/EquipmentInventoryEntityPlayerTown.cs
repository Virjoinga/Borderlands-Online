using A;
using Core;
using UnityEngine;
using XsdSettings;

public class EquipmentInventoryEntityPlayerTown : EquipmentInventoryEntityPlayer
{
	private bool isReady;

	private bool m_isMine;

	private InventoryServiceWrapper.InventoryUpdateType m_updateType;

	private byte m_activeWeaponRecved;

	public bool c39df47367fa21412aabfef05d9972f8c()
	{
		return isReady;
	}

	public void cd93285db16841148ed53a5bbeb35cf20(byte cd6bb591c33b2ee3ab93e98aa43a6da63, ItemDNA[] c56ebb9472aa0ed4d025830736291732c, ItemDNA c83130c8b3cb0bca5da0dd22b9693898d, byte c688b7ccc0986bb3587eb91f0c9571c7d)
	{
		m_entity = GetComponent<EntityPlayer>();
		AvatarType c951097a6ef3eb670bc38dce2cd336b7a = m_entity.cd95354b53e674ec7dc9594e66e4d316f().m_avatarDna.c071244a19e2d9f70f4d2d6d38677162a();
		m_pouchList[0].ccc9d3a38966dc10fedb531ea17d24611(c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c4459dc4cce1d07c3d1484ae8659420f3(c951097a6ef3eb670bc38dce2cd336b7a, cd6bb591c33b2ee3ab93e98aa43a6da63));
		for (byte b = 0; b < EquipmentInventoryEntityPlayer.s_weaponSlotCount; b++)
		{
			if (!m_weaponSlots[b].cc6aaf385211ddff355edfb4576dcd1d1())
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
				if (c56ebb9472aa0ed4d025830736291732c[b] != null)
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
					EntityWeapon c5d720f6d007abb0c4a21d6a654e405bb = c06ca0e618478c23eba3419653a19760f<InstantiateManager>.c5ee19dc8d4cccf5ae2de225410458b86.ced7f8f71bffe8b45eee62a9a84d360fd(c56ebb9472aa0ed4d025830736291732c[b].ca79da172938fdc8c067fb64242b6174a(), Vector3.zero, Quaternion.identity, false);
					m_weaponSlots[b].c7cd2e714b90259c7cbaa0bd226fe8435(c5d720f6d007abb0c4a21d6a654e405bb, c56ebb9472aa0ed4d025830736291732c[b]);
				}
			}
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				continue;
			}
			if (c83130c8b3cb0bca5da0dd22b9693898d != null)
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
				c78742691326e1e69f66c386d907da903(c83130c8b3cb0bca5da0dd22b9693898d);
				c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c3f364b40c92f5f9e53e65ac9b0913add(InventoryServiceWrapper.InventoryUpdateType.ChangeEquipedShield);
			}
			if (c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c86b944a82d70502ff9ec6c7d1fa5f420() != null)
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
				c474a2d0a31529b847725f85f5ab221a7(c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c86b944a82d70502ff9ec6c7d1fa5f420());
				c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c3f364b40c92f5f9e53e65ac9b0913add(InventoryServiceWrapper.InventoryUpdateType.ChangeEquipedClassMod);
			}
			cb71c24b68b65fe176d7936520d63a102(c688b7ccc0986bb3587eb91f0c9571c7d);
			if (m_entity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (m_entity.caac907d451029d68503484a63934c93f())
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
					m_isMine = true;
					c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c3f364b40c92f5f9e53e65ac9b0913add(InventoryServiceWrapper.InventoryUpdateType.FullUpdate);
				}
			}
			c0086d06d399d3534d81eb73a2590310c();
			return;
		}
	}

	private void OnDestroy()
	{
		if (!m_isMine)
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
			Inventory inventory = OnAccessSingleton<IInventoryService, InventoryService, InventoryServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c844f1a916a01fdb8a6a6e640d1811cf2(OnlineService.s_characterId, cb8d3896b4fab7d0390a49fc34789c675.c7088de59e49f7108f520cf7e0bae167e);
			if (inventory == null)
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
				inventory.cb71c24b68b65fe176d7936520d63a102(c91233b4b8268e8e24a4daa8c053e41ec());
				return;
			}
		}
	}

	public void c0086d06d399d3534d81eb73a2590310c()
	{
		if (!(m_entity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (!m_entity.caac907d451029d68503484a63934c93f())
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
				cb457b11bed8ea2da2625c20e4073efd3(c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c4e0dae6a16a8a80ddb5214a896b9df58(0), c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c4e0dae6a16a8a80ddb5214a896b9df58(1), c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c4e0dae6a16a8a80ddb5214a896b9df58(2), c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c4e0dae6a16a8a80ddb5214a896b9df58(3), c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c91233b4b8268e8e24a4daa8c053e41ec());
				return;
			}
		}
	}

	private void cb457b11bed8ea2da2625c20e4073efd3(ItemDNA c916b707dc486a2ec43ede95c5e00a2ca, ItemDNA ce8ed8d7732f2777e05bb1b3d9ec4cdb1, ItemDNA c8f9895d6a77577b91c8439b84a3eecac, ItemDNA cb8e7b9c66c68db79c4a931fb0727ee7d, byte c667745f4749ad3aa02bdb93a84eb6e4c)
	{
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(5);
		array[0] = c916b707dc486a2ec43ede95c5e00a2ca;
		array[1] = ce8ed8d7732f2777e05bb1b3d9ec4cdb1;
		array[2] = c8f9895d6a77577b91c8439b84a3eecac;
		array[3] = cb8e7b9c66c68db79c4a931fb0727ee7d;
		array[4] = c667745f4749ad3aa02bdb93a84eb6e4c;
		base.photonView.c19fd12ed98be2a9174d53644dc9757c8("RPC_RequestSetWeaponSlots", PhotonTargets.MasterClient, array);
	}

	[RPC]
	public void RPC_RequestSetWeaponSlots(ItemDNA s0, ItemDNA s1, ItemDNA s2, ItemDNA s3, byte activeSlot)
	{
	}

	private void OnLevelUp(PlayerInfoSync player)
	{
		Entity entity = player.c66b232dbebded7c7e9a89c1e8bd84689();
		if (entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (m_entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		if (!player.c16d1154aec91a0f8f4a52d77fc081194())
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
			if (entity.cc7403315505256d19a7b92aa614a8f10() != m_entity.cc7403315505256d19a7b92aa614a8f10())
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
				AvatarType c951097a6ef3eb670bc38dce2cd336b7a = player.m_avatarDna.c071244a19e2d9f70f4d2d6d38677162a();
				int cd6bb591c33b2ee3ab93e98aa43a6da = c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1ee9148b69b784ee94cf0d54409c8ee0(c951097a6ef3eb670bc38dce2cd336b7a, player.m_exp);
				int ce565b32ce48270d8a80781c7ab11cae = c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c4459dc4cce1d07c3d1484ae8659420f3(c951097a6ef3eb670bc38dce2cd336b7a, cd6bb591c33b2ee3ab93e98aa43a6da);
				m_pouchList[0].ccc9d3a38966dc10fedb531ea17d24611(ce565b32ce48270d8a80781c7ab11cae);
				return;
			}
		}
	}

	public override void c78742691326e1e69f66c386d907da903(ItemDNA c4ed717bfa8e3dbe7b0f04513d76a651e)
	{
		EntityShield entityShield = c06ca0e618478c23eba3419653a19760f<InstantiateManager>.c5ee19dc8d4cccf5ae2de225410458b86.cfe93941b14e28baa59c497f98102ccd5(Vector3.zero, Quaternion.identity, false);
		entityShield.c68cd0a841e044876d964965d7ec944bd(c4ed717bfa8e3dbe7b0f04513d76a651e.c8e074b9d0135ff808166cc324407f74c(), m_entity);
		entityShield.c1c5a947f5f8c009fe6fac45c9e29ad1d(m_entity);
		m_shieldSlot.c7cd2e714b90259c7cbaa0bd226fe8435(entityShield, c4ed717bfa8e3dbe7b0f04513d76a651e);
	}

	public override void c474a2d0a31529b847725f85f5ab221a7(ItemDNA c4ed717bfa8e3dbe7b0f04513d76a651e)
	{
		EntityClassMode entityClassMode = c06ca0e618478c23eba3419653a19760f<InstantiateManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad906dd3da954596cb70c5723a6afa82(c4ed717bfa8e3dbe7b0f04513d76a651e, Vector3.zero, Quaternion.identity, false);
		entityClassMode.c1c5a947f5f8c009fe6fac45c9e29ad1d(m_entity);
		entityClassMode.gameObject.SetActive(false);
		m_classModeSlot.c7cd2e714b90259c7cbaa0bd226fe8435(entityClassMode, c4ed717bfa8e3dbe7b0f04513d76a651e);
	}

	public void c5939103e64f288dfce17db2fb4594432(EntityShield c83130c8b3cb0bca5da0dd22b9693898d)
	{
		m_shieldSlot.c7cd2e714b90259c7cbaa0bd226fe8435(c83130c8b3cb0bca5da0dd22b9693898d, c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e);
	}

	public void ca9ccd8d9ca797ff77e45b9be166a21d2(ItemDNA ca57e1c076c01141c5ce58c7341db7833)
	{
	}

	public new void cccb56495987b6a4ebab7b225fb1af261(byte c793014f9fd028450a4a9908376309f26)
	{
	}

	public new void cc62b4b3e79f635a94d84949382bba1fc(byte c42a8a9b0dd4206315a44f945fbf7331f, byte c5242449e40eab9ce5011e2bacd82070c)
	{
	}

	public override void cabac189d699c8d8d56d0e1a68cd1440b(byte c71953cab9dff52e14146804e2928df92, byte c19a39247ea86ffe5f0de9d429ca0ca95)
	{
		if (m_entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (!m_entity.caac907d451029d68503484a63934c93f())
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
		PlayerInfoSync playerInfoSync = m_entity.cd95354b53e674ec7dc9594e66e4d316f();
		if (playerInfoSync == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (!playerInfoSync.c16d1154aec91a0f8f4a52d77fc081194())
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			object obj;
			if (m_weaponSlots[c19a39247ea86ffe5f0de9d429ca0ca95] != null)
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
				obj = m_weaponSlots[c19a39247ea86ffe5f0de9d429ca0ca95].c66b232dbebded7c7e9a89c1e8bd84689() as EntityWeapon;
			}
			else
			{
				obj = ceaa467e9f01cebcf620c4729a7dcef3f.c7088de59e49f7108f520cf7e0bae167e;
			}
			EntityWeapon entityWeapon = (EntityWeapon)obj;
			ItemDNA itemDNA = c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c4e0dae6a16a8a80ddb5214a896b9df58(c19a39247ea86ffe5f0de9d429ca0ca95);
			if (itemDNA == null)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			m_weaponSlots[c19a39247ea86ffe5f0de9d429ca0ca95].c7cd2e714b90259c7cbaa0bd226fe8435(0, itemDNA);
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "EquipWeapon - SpawnWeapon [ " + itemDNA.ca79da172938fdc8c067fb64242b6174a().m_name + "]");
			EntityWeapon entityWeapon2 = c06ca0e618478c23eba3419653a19760f<InstantiateManager>.c5ee19dc8d4cccf5ae2de225410458b86.ced7f8f71bffe8b45eee62a9a84d360fd(itemDNA.ca79da172938fdc8c067fb64242b6174a(), Vector3.zero, Quaternion.identity, false);
			(m_entity as EntityPlayer).cabac189d699c8d8d56d0e1a68cd1440b(entityWeapon2, c19a39247ea86ffe5f0de9d429ca0ca95);
			m_weaponSlots[c19a39247ea86ffe5f0de9d429ca0ca95].c7cd2e714b90259c7cbaa0bd226fe8435(entityWeapon2, itemDNA);
			if (itemDNA != null)
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
				if (itemDNA.ca79da172938fdc8c067fb64242b6174a() != null)
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
					if (itemDNA.ca79da172938fdc8c067fb64242b6174a().m_attribute != null)
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
						c21ad47204b5c92fdbb3d4d6a2babb082(c19b70ea6e4db0802bb7cae385cc85109(itemDNA.m_ammoType) - (m_entity as EntityPlayer).c1facd4b8473c97b11386825128ea5617(IntAttributeValue.c00ae05b9ced94c9fc5f4be4892e6192b(itemDNA.ca79da172938fdc8c067fb64242b6174a().m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ClipSize) as IntAttributeValue)), itemDNA.m_ammoType);
					}
				}
			}
			if (entityWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				c06ca0e618478c23eba3419653a19760f<EntityManager>.c5ee19dc8d4cccf5ae2de225410458b86.c986e2c92f577697169e986d88211a625(entityWeapon);
				object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
				array[0] = "EquipWeapon - DestroyEntity [";
				array[1] = entityWeapon.c729ce3b5f48e0eac3a7ead97b1d02f8d().m_name;
				array[2] = "] Item Slot ";
				array[3] = c71953cab9dff52e14146804e2928df92;
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, string.Concat(array));
			}
			c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c3f364b40c92f5f9e53e65ac9b0913add(InventoryServiceWrapper.InventoryUpdateType.ItemUpdate);
			cb71c24b68b65fe176d7936520d63a102(c19a39247ea86ffe5f0de9d429ca0ca95);
			return;
		}
	}

	public override void c61f40925cf99c31aa9ac5df098110ada(byte c793014f9fd028450a4a9908376309f26)
	{
		if (m_entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		PlayerInfoSync playerInfoSync = m_entity.cd95354b53e674ec7dc9594e66e4d316f();
		if (playerInfoSync == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (!playerInfoSync.c16d1154aec91a0f8f4a52d77fc081194())
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			ItemDNA itemDNA = c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cec5e771a298fe1e51f84e4ec6dcb5165();
			if (itemDNA == null)
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
				if (!itemDNA.ca8e8ecb1231bf8cf32c06da446a48681(ItemType.Shield))
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
					EntityShield entityShield = m_shieldSlot.c66b232dbebded7c7e9a89c1e8bd84689() as EntityShield;
					c78742691326e1e69f66c386d907da903(itemDNA);
					if (entityShield != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						c06ca0e618478c23eba3419653a19760f<EntityManager>.c5ee19dc8d4cccf5ae2de225410458b86.c986e2c92f577697169e986d88211a625(entityShield);
					}
					c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c3f364b40c92f5f9e53e65ac9b0913add(InventoryServiceWrapper.InventoryUpdateType.ChangeEquipedShield);
					return;
				}
			}
		}
	}

	public override void c2bf177eafbfeb7beaa0bfd04facb2029(byte c793014f9fd028450a4a9908376309f26)
	{
		if (m_entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		PlayerInfoSync playerInfoSync = m_entity.cd95354b53e674ec7dc9594e66e4d316f();
		if (playerInfoSync == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (!playerInfoSync.c16d1154aec91a0f8f4a52d77fc081194())
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			ItemDNA itemDNA = c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c86b944a82d70502ff9ec6c7d1fa5f420();
			if (itemDNA == null)
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
				if (!itemDNA.ca8e8ecb1231bf8cf32c06da446a48681(ItemType.ClassMode))
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
					EntityClassMode entityClassMode = m_classModeSlot.c66b232dbebded7c7e9a89c1e8bd84689() as EntityClassMode;
					c474a2d0a31529b847725f85f5ab221a7(itemDNA);
					if (entityClassMode != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						c06ca0e618478c23eba3419653a19760f<EntityManager>.c5ee19dc8d4cccf5ae2de225410458b86.c986e2c92f577697169e986d88211a625(entityClassMode);
					}
					c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c3f364b40c92f5f9e53e65ac9b0913add(InventoryServiceWrapper.InventoryUpdateType.ChangeEquipedClassMod);
					return;
				}
			}
		}
	}

	public override void c89361444df98c6f8354125e8bdb18882(byte c19a39247ea86ffe5f0de9d429ca0ca95)
	{
		if (m_entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		PlayerInfoSync playerInfoSync = m_entity.cd95354b53e674ec7dc9594e66e4d316f();
		if (playerInfoSync == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (!playerInfoSync.c16d1154aec91a0f8f4a52d77fc081194())
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			m_isItemsDirty = true;
			EntityWeapon entityWeapon = m_weaponSlots[c19a39247ea86ffe5f0de9d429ca0ca95].c66b232dbebded7c7e9a89c1e8bd84689() as EntityWeapon;
			if ((bool)entityWeapon)
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
				ce653df38cbca26f91f2e8654ccc7b048(c5c30fc221fd2805f9535a08995b34b98(entityWeapon.c83e548e5608cd7f222098a6966b16545()) + entityWeapon.m_ammoCount, entityWeapon.c83e548e5608cd7f222098a6966b16545());
				c06ca0e618478c23eba3419653a19760f<EntityManager>.c5ee19dc8d4cccf5ae2de225410458b86.c986e2c92f577697169e986d88211a625(entityWeapon);
			}
			m_weaponSlots[c19a39247ea86ffe5f0de9d429ca0ca95].cac7688b05e921e2be3f92479ba44b4a8();
			c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c3f364b40c92f5f9e53e65ac9b0913add(InventoryServiceWrapper.InventoryUpdateType.ItemUpdate);
			return;
		}
	}

	public override void ccfdbed5cc5051e9ffb25bea212f7ddc6(byte c42a8a9b0dd4206315a44f945fbf7331f, byte c5242449e40eab9ce5011e2bacd82070c)
	{
		if (m_entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		PlayerInfoSync playerInfoSync = m_entity.cd95354b53e674ec7dc9594e66e4d316f();
		if (playerInfoSync == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (!playerInfoSync.c16d1154aec91a0f8f4a52d77fc081194())
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
			m_isItemsDirty = true;
			InventorySlot inventorySlot = m_weaponSlots[c42a8a9b0dd4206315a44f945fbf7331f];
			m_weaponSlots[c42a8a9b0dd4206315a44f945fbf7331f] = m_weaponSlots[c5242449e40eab9ce5011e2bacd82070c];
			m_weaponSlots[c5242449e40eab9ce5011e2bacd82070c] = inventorySlot;
			if (m_activeWeaponSlot == c42a8a9b0dd4206315a44f945fbf7331f)
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
				cb71c24b68b65fe176d7936520d63a102(c5242449e40eab9ce5011e2bacd82070c);
			}
			else if (m_activeWeaponSlot == c5242449e40eab9ce5011e2bacd82070c)
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
				cb71c24b68b65fe176d7936520d63a102(c42a8a9b0dd4206315a44f945fbf7331f);
			}
			c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c3f364b40c92f5f9e53e65ac9b0913add(InventoryServiceWrapper.InventoryUpdateType.ItemUpdate);
			return;
		}
	}

	protected override void Update()
	{
		if (m_entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (!isReady)
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
			int num = 0;
			while (true)
			{
				if (num < EquipmentInventoryEntityPlayer.s_weaponSlotCount)
				{
					if ((bool)c4e0dae6a16a8a80ddb5214a896b9df58((byte)num))
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
						if (c4e0dae6a16a8a80ddb5214a896b9df58((byte)num).c39df47367fa21412aabfef05d9972f8c())
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
							isReady = true;
							break;
						}
					}
					num++;
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
				break;
			}
		}
		if (!m_entity.caac907d451029d68503484a63934c93f())
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
			if (m_activeWeaponSlot != m_activeWeaponRecved)
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
				(m_entity as EntityPlayer).ce7f18d227f2281ec702017e97b1553a7(m_activeWeaponRecved);
			}
		}
		if (!m_entity.cc9092b59c901ab832a40b51c2cfa71b7())
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
			if (m_updateType != 0)
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
				c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c3f364b40c92f5f9e53e65ac9b0913add(m_updateType);
				m_updateType = InventoryServiceWrapper.InventoryUpdateType.None;
			}
		}
		if (!(cb4633378bdf6d47c409332e395d58c7a() == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (!m_entity.caac907d451029d68503484a63934c93f())
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
				ItemDNA itemDNA = c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cec5e771a298fe1e51f84e4ec6dcb5165();
				if (itemDNA == null)
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
					c78742691326e1e69f66c386d907da903(itemDNA);
					c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c3f364b40c92f5f9e53e65ac9b0913add(InventoryServiceWrapper.InventoryUpdateType.ChangeEquipedShield);
					return;
				}
			}
		}
	}

	public override void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		c06ade3733c4658b091be622d9d3b4034();
		if (stream.c8b2526be2638bb30a29ab8314b369311)
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
			stream.caf7283cc5cd9725a88a9cdfa630d92f8((byte)m_flags);
			for (int i = 0; i < EquipmentInventoryEntityPlayer.s_weaponSlotCount; i++)
			{
				ItemDNA c7088de59e49f7108f520cf7e0bae167e = c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e;
				c7088de59e49f7108f520cf7e0bae167e = m_weaponSlots[i].c729ce3b5f48e0eac3a7ead97b1d02f8d();
				stream.caf7283cc5cd9725a88a9cdfa630d92f8(c7088de59e49f7108f520cf7e0bae167e);
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
			stream.caf7283cc5cd9725a88a9cdfa630d92f8(c91233b4b8268e8e24a4daa8c053e41ec());
		}
		if (!stream.cb8e0d05aa2c04e14f3633a4d8d11cfd7)
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
			if (m_entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			if (m_entity.caac907d451029d68503484a63934c93f())
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
			m_flags = (PropertyFlags)(byte)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
			for (int num = 0; num < EquipmentInventoryEntityPlayer.s_weaponSlotCount; num++)
			{
				ItemDNA itemDNA = (ItemDNA)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
				bool flag = false;
				if (itemDNA != null)
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
					if (m_weaponSlots[num] != null)
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
						flag = itemDNA.Equals(m_weaponSlots[num].c729ce3b5f48e0eac3a7ead97b1d02f8d());
						goto IL_015e;
					}
				}
				int num2;
				if (itemDNA == null)
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
					num2 = ((m_weaponSlots[num].c729ce3b5f48e0eac3a7ead97b1d02f8d() == c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e) ? 1 : 0);
				}
				else
				{
					num2 = 0;
				}
				flag = (byte)num2 != 0;
				goto IL_015e;
				IL_015e:
				if (!flag)
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
					if (m_weaponSlots[num].c729ce3b5f48e0eac3a7ead97b1d02f8d() != null)
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
						object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
						array[0] = "3d person of [";
						array[1] = m_entity.cd95354b53e674ec7dc9594e66e4d316f().m_name;
						array[2] = "] locally Destroy previous weapon:";
						array[3] = m_weaponSlots[num].c729ce3b5f48e0eac3a7ead97b1d02f8d().ca79da172938fdc8c067fb64242b6174a();
						DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, string.Concat(array));
						c06ca0e618478c23eba3419653a19760f<EntityManager>.c5ee19dc8d4cccf5ae2de225410458b86.c986e2c92f577697169e986d88211a625(m_weaponSlots[num].c66b232dbebded7c7e9a89c1e8bd84689());
					}
					if (itemDNA != null)
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
						object[] array2 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
						array2[0] = "3d person of [";
						array2[1] = m_entity.cd95354b53e674ec7dc9594e66e4d316f().m_name;
						array2[2] = "] locally SpawnWeapon:";
						array2[3] = itemDNA.ca79da172938fdc8c067fb64242b6174a();
						DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, string.Concat(array2));
						EntityWeapon entityWeapon = c06ca0e618478c23eba3419653a19760f<InstantiateManager>.c5ee19dc8d4cccf5ae2de225410458b86.ced7f8f71bffe8b45eee62a9a84d360fd(itemDNA.ca79da172938fdc8c067fb64242b6174a(), Vector3.zero, Quaternion.identity, false);
						m_weaponSlots[num].c7cd2e714b90259c7cbaa0bd226fe8435(entityWeapon, itemDNA);
						(m_entity as EntityPlayer).cabac189d699c8d8d56d0e1a68cd1440b(entityWeapon, (byte)num);
					}
				}
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				m_activeWeaponRecved = (byte)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "Client Recving inventory in town. activeWeaponSlot:" + m_activeWeaponRecved);
				return;
			}
		}
	}

	public override EntityShield cfe93941b14e28baa59c497f98102ccd5()
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "EquipmentTown: SpawnShield ");
		EntityShield c7088de59e49f7108f520cf7e0bae167e = cfdcd4b1e38674bf0a07bf7a1172dc29c.c7088de59e49f7108f520cf7e0bae167e;
		c7088de59e49f7108f520cf7e0bae167e = c06ca0e618478c23eba3419653a19760f<InstantiateManager>.c5ee19dc8d4cccf5ae2de225410458b86.cfe93941b14e28baa59c497f98102ccd5(Vector3.zero, Quaternion.identity, false);
		c5939103e64f288dfce17db2fb4594432(c7088de59e49f7108f520cf7e0bae167e);
		return c7088de59e49f7108f520cf7e0bae167e;
	}

	public override void cb71c24b68b65fe176d7936520d63a102(byte c19a39247ea86ffe5f0de9d429ca0ca95)
	{
		if (m_entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (c19a39247ea86ffe5f0de9d429ca0ca95 != m_activeWeaponSlot)
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
			m_activeWeaponSlot = c19a39247ea86ffe5f0de9d429ca0ca95;
		}
		c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c3f364b40c92f5f9e53e65ac9b0913add(InventoryServiceWrapper.InventoryUpdateType.ChangeActiveWeapon);
	}

	public override byte c91233b4b8268e8e24a4daa8c053e41ec()
	{
		return m_activeWeaponSlot;
	}
}
