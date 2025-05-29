using System;
using System.Runtime.CompilerServices;
using A;
using Core;
using UnityEngine;

public class PlayerInfoSync : MonoBehaviour, IPhotonView, IPhotonSerializeView
{
	public enum PlayerState
	{
		None = 0,
		PlayerReady = 1,
		MapReady = 2,
		PlayerAndMapReady = 3,
		Spawning = 4,
		Spawned = 5
	}

	public delegate void OnPlayerStateChanged_Handler();

	private PlayerState m_inner_playerstate;

	public int m_id;

	public string m_name;

	public int m_accountId;

	public int m_characterId;

	public int m_exp;

	public AvatarDNA m_avatarDna;

	public int m_teamID;

	public int m_groupId;

	public bool m_isInvulnerable;

	public bool m_canLevelUp = true;

	public AntiAddiction.Level m_antiAddictionLevel;

	private Entity m_entity;

	private int m_previousExp;

	public bool m_isReadyToSync_Host;

	private OnPlayerStateChanged_Handler OnPlayerStateChanged;

	public PhotonView photonView { get; set; }

	public PlayerState c2d17ea39faa888e633ce06615ddf5c6a
	{
		get
		{
			return m_inner_playerstate;
		}
		set
		{
			if (m_inner_playerstate == value)
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
				m_inner_playerstate = value;
				if (OnPlayerStateChanged == null)
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
					OnPlayerStateChanged();
					return;
				}
			}
		}
	}

	public int m_bondCurrency { get; private set; }

	public PhotonPlayer m_photonPlayer { get; private set; }

	public event OnPlayerStateChanged_Handler c556b16ab244cfd0d587e50a0ea733af2
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			OnPlayerStateChanged = (OnPlayerStateChanged_Handler)Delegate.Combine(OnPlayerStateChanged, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			OnPlayerStateChanged = (OnPlayerStateChanged_Handler)Delegate.Remove(OnPlayerStateChanged, value);
		}
	}

	public void Awake()
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "PlayerInfoSync.Awake() - " + Time.realtimeSinceStartup);
		m_isReadyToSync_Host = false;
		Session c5ee19dc8d4cccf5ae2de225410458b = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86;
		if (!(c5ee19dc8d4cccf5ae2de225410458b != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			c5ee19dc8d4cccf5ae2de225410458b.c57e4d4cd41f3be21d7e24a71aa08c6ba(this);
			base.gameObject.transform.parent = c5ee19dc8d4cccf5ae2de225410458b.m_playerDirectory.transform;
			return;
		}
	}

	public bool c16d1154aec91a0f8f4a52d77fc081194()
	{
		return m_id == NetworkManager.cf6124bd5254101846a57acc03f545846();
	}

	public PhotonPlayer ccbf0424f81fe9104b29857c1137a5d96()
	{
		return m_photonPlayer;
	}

	public void ccc9d3a38966dc10fedb531ea17d24611(object[] c591d56a94543e3559945c497f37126c4, PhotonPlayer c1ffbed4a781051881c8fac731543b807)
	{
		m_photonPlayer = c1ffbed4a781051881c8fac731543b807;
		int num = 0;
		m_id = (int)c591d56a94543e3559945c497f37126c4[num++];
		m_name = (string)c591d56a94543e3559945c497f37126c4[num++];
		m_accountId = (int)c591d56a94543e3559945c497f37126c4[num++];
		m_characterId = (int)c591d56a94543e3559945c497f37126c4[num++];
		m_exp = (int)c591d56a94543e3559945c497f37126c4[num++];
		c2d17ea39faa888e633ce06615ddf5c6a = PlayerState.None;
		c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c45046ccb66f97acb081de281306e5c25().cdb7db6721dec105d58123fc2c43fa883(this);
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_offlineMode)
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
			SessionInfo c5ee19dc8d4cccf5ae2de225410458b = SessionInfo.c5ee19dc8d4cccf5ae2de225410458b86;
			if (c5ee19dc8d4cccf5ae2de225410458b != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				m_avatarDna = c06ca0e618478c23eba3419653a19760f<PlayerManager>.c5ee19dc8d4cccf5ae2de225410458b86.ccc826da979542be7370386df94069f47().m_avatarDna;
				c5ee19dc8d4cccf5ae2de225410458b.cd3e3b856c4fdfeb7ba47c5b0f4236dbd(0);
			}
		}
		if (!photonView.c6971afb2ced2e6c56d327fce1c3bca83)
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
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, "mine");
			return;
		}
	}

	public void OnDestroy()
	{
		if ((bool)c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c45046ccb66f97acb081de281306e5c25().ce6bf36e217fcc303dbbaf5c8717c4b2a(this);
		}
		if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86)
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
			c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.cf5212e6903ec0c0b27816142c32a2d13(this);
			return;
		}
	}

	public void cc8d039af92e0721caddc46b8ffe7a233(int cdddf3ee050c73253a0eed1738c2fc872)
	{
		if (cdddf3ee050c73253a0eed1738c2fc872 == m_bondCurrency)
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
		m_bondCurrency = cdddf3ee050c73253a0eed1738c2fc872;
		if (!c16d1154aec91a0f8f4a52d77fc081194())
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
			c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.ceaf946a4b1d023143d622c7be7019235();
			return;
		}
	}

	public Entity c66b232dbebded7c7e9a89c1e8bd84689()
	{
		return m_entity;
	}

	public void c7cd2e714b90259c7cbaa0bd226fe8435(Entity c5d720f6d007abb0c4a21d6a654e405bb)
	{
		m_entity = c5d720f6d007abb0c4a21d6a654e405bb;
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.c8b2526be2638bb30a29ab8314b369311)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					if (!m_isReadyToSync_Host)
					{
						while (true)
						{
							switch (7)
							{
							case 0:
								break;
							default:
								return;
							}
						}
					}
					stream.caf7283cc5cd9725a88a9cdfa630d92f8(m_id);
					stream.caf7283cc5cd9725a88a9cdfa630d92f8(m_name);
					stream.caf7283cc5cd9725a88a9cdfa630d92f8(m_accountId);
					stream.caf7283cc5cd9725a88a9cdfa630d92f8(m_characterId);
					int cd6bb591c33b2ee3ab93e98aa43a6da = c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1ee9148b69b784ee94cf0d54409c8ee0(m_avatarDna.c071244a19e2d9f70f4d2d6d38677162a(), m_exp);
					stream.caf7283cc5cd9725a88a9cdfa630d92f8(c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c22535483c584afec3f67e9f95446a8f4(m_avatarDna.c071244a19e2d9f70f4d2d6d38677162a(), cd6bb591c33b2ee3ab93e98aa43a6da));
					stream.caf7283cc5cd9725a88a9cdfa630d92f8((byte)m_teamID);
					stream.caf7283cc5cd9725a88a9cdfa630d92f8((byte)m_groupId);
					stream.caf7283cc5cd9725a88a9cdfa630d92f8((byte)c2d17ea39faa888e633ce06615ddf5c6a);
					stream.caf7283cc5cd9725a88a9cdfa630d92f8((byte)m_antiAddictionLevel);
					stream.caf7283cc5cd9725a88a9cdfa630d92f8(m_avatarDna.Clone());
					return;
				}
				}
			}
		}
		m_id = (int)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
		m_name = (string)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
		m_accountId = (int)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
		m_characterId = (int)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
		int num = (int)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
		m_teamID = (byte)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
		m_groupId = (byte)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
		c2d17ea39faa888e633ce06615ddf5c6a = (PlayerState)(byte)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
		m_antiAddictionLevel = (AntiAddiction.Level)(byte)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
		m_avatarDna = (AvatarDNA)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
		if (!c16d1154aec91a0f8f4a52d77fc081194())
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
			m_exp = num;
		}
		c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c45046ccb66f97acb081de281306e5c25().cdb7db6721dec105d58123fc2c43fa883(this);
		StatisticsManager.StatSheet statSheet = c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c45046ccb66f97acb081de281306e5c25().cdcb2ff44fc70c31a5ec9c7f0156d8f27(this);
		if (statSheet == null)
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
			statSheet.cdb2127413cce26bb79a7ae953459f365(Mathf.Max(0, num - m_exp));
			return;
		}
	}

	[RPC]
	private void RPC_OnReceiveMoney(int bondCurrency)
	{
		cc8d039af92e0721caddc46b8ffe7a233(bondCurrency);
	}

	[RPC]
	private void RPC_OnReceiveExp(int exp)
	{
		int num = c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1ee9148b69b784ee94cf0d54409c8ee0(m_avatarDna.c071244a19e2d9f70f4d2d6d38677162a(), m_exp);
		int num2 = c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1ee9148b69b784ee94cf0d54409c8ee0(m_avatarDna.c071244a19e2d9f70f4d2d6d38677162a(), exp);
		m_exp = exp;
		StatisticsManager.StatSheet statSheet = c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c45046ccb66f97acb081de281306e5c25().cdcb2ff44fc70c31a5ec9c7f0156d8f27(this);
		if (statSheet != null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			statSheet.cdb2127413cce26bb79a7ae953459f365(Mathf.Max(0, exp - m_exp));
		}
		if (num2 <= num)
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
			c06ca0e618478c23eba3419653a19760f<ce9388431a2de8f3d6a4d9565d5f8f8a0>.c5ee19dc8d4cccf5ae2de225410458b86.cc3a03c998d897c7a7aa6b2d0b7da8767("OnLevelUp", this);
			return;
		}
	}
}
