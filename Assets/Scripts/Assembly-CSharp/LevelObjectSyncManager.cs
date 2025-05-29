using System.Collections;
using System.Collections.Generic;
using A;
using Core;
using Photon;

public class LevelObjectSyncManager : MonoBehaviour
{
	private static LevelObjectSyncManager s_instance;

	private List<LevelObjectSync> m_levelObjects = new List<LevelObjectSync>();

	private BitArray m_bitArray = new BitArray(0);

	private byte[] m_byteArray = ce2f159fe707a376b497f666c368f15ed.c0a0cdf4a196914163f7334d9b0781a04(0);

	public static LevelObjectSyncManager c5ee19dc8d4cccf5ae2de225410458b86
	{
		get
		{
			return s_instance;
		}
	}

	private void Awake()
	{
		base.gameObject.transform.parent = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.transform;
		if (s_instance != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, "SessionInfo is already initialized");
		}
		s_instance = this;
	}

	public int c57e4d4cd41f3be21d7e24a71aa08c6ba(LevelObjectSync c3b93e300e785d02cbc903ad78d740f0f)
	{
		m_levelObjects.Add(c3b93e300e785d02cbc903ad78d740f0f);
		return m_levelObjects.Count - 1;
	}

	public bool c8d59b839636d6ca6992727c0544bd4c8(int c35f98ccbfa8c6bf09319c620b21b5dc5, ref LevelObjectSync.LevelObjectSyncState cd3b7e36044e9fd0402c7544cc0f576f5)
	{
		if (c35f98ccbfa8c6bf09319c620b21b5dc5 < m_bitArray.Length)
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
					int num;
					if (m_bitArray[c35f98ccbfa8c6bf09319c620b21b5dc5])
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
						num = 1;
					}
					else
					{
						num = 0;
					}
					cd3b7e36044e9fd0402c7544cc0f576f5 = (LevelObjectSync.LevelObjectSyncState)num;
					return true;
				}
				}
			}
		}
		return false;
	}

	public void cac7688b05e921e2be3f92479ba44b4a8()
	{
		m_levelObjects.Clear();
		m_bitArray = new BitArray(0);
	}

	public int c78f93b7f10e9d431910be305535ce7f4()
	{
		if (m_levelObjects == null)
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
					return 0;
				}
			}
		}
		return m_levelObjects.Count;
	}

	public LevelObjectSync c5126cda7cf5cdf4e8083679781e5b0ce(int c35f98ccbfa8c6bf09319c620b21b5dc5)
	{
		if (c35f98ccbfa8c6bf09319c620b21b5dc5 >= 0)
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
			if (c35f98ccbfa8c6bf09319c620b21b5dc5 < m_levelObjects.Count)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						return m_levelObjects[c35f98ccbfa8c6bf09319c620b21b5dc5];
					}
				}
			}
		}
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
		array[0] = "LevelObjectSyncManager.GetLevelObjectFromID: id[";
		array[1] = c35f98ccbfa8c6bf09319c620b21b5dc5;
		array[2] = "] is invalid. Max Id is ";
		array[3] = m_levelObjects.Count;
		DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, string.Concat(array));
		return null;
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.c8b2526be2638bb30a29ab8314b369311)
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
					if (m_bitArray.Length != m_levelObjects.Count)
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
						m_bitArray = new BitArray(m_levelObjects.Count);
					}
					for (int i = 0; i < m_levelObjects.Count; i++)
					{
						m_bitArray[i] = m_levelObjects[i].c285c6dfb3039cfe6087d40143faf7488() == LevelObjectSync.LevelObjectSyncState.Activated;
					}
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
						{
							int num = m_bitArray.Length / 8;
							int num2;
							if (m_bitArray.Length % 8 > 0)
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
								num2 = 1;
							}
							else
							{
								num2 = 0;
							}
							int num3 = num + num2;
							if (m_bitArray.Length > 0)
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
								if (m_byteArray.Length != num3)
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
									m_byteArray = ce2f159fe707a376b497f666c368f15ed.c0a0cdf4a196914163f7334d9b0781a04(num3);
								}
							}
							if (m_byteArray.Length > 0)
							{
								while (true)
								{
									switch (5)
									{
									case 0:
										break;
									default:
									{
										m_bitArray.CopyTo(m_byteArray, 0);
										for (int j = 0; j < m_byteArray.Length; j++)
										{
											stream.caf7283cc5cd9725a88a9cdfa630d92f8(m_byteArray[j]);
										}
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
		}
		if (stream.c9a57a1c6eac92cceec2de50aa04e4757 <= 0)
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
			m_byteArray = ce2f159fe707a376b497f666c368f15ed.c0a0cdf4a196914163f7334d9b0781a04(stream.c9a57a1c6eac92cceec2de50aa04e4757);
			for (int k = 0; k < m_byteArray.Length; k++)
			{
				m_byteArray[k] = (byte)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				m_bitArray = new BitArray(m_byteArray);
				if (m_levelObjects.Count > m_bitArray.Length)
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
					for (int l = 0; l < m_levelObjects.Count; l++)
					{
						LevelObjectSync levelObjectSync = m_levelObjects[l];
						int c17fcd0ed1024ad7689991a96ed60deb;
						if (m_bitArray[l])
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
							c17fcd0ed1024ad7689991a96ed60deb = 1;
						}
						else
						{
							c17fcd0ed1024ad7689991a96ed60deb = 0;
						}
						levelObjectSync.ccdbe4e8fac6da17241ea3a84ac4a449c((LevelObjectSync.LevelObjectSyncState)c17fcd0ed1024ad7689991a96ed60deb);
					}
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							return;
						}
					}
				}
			}
		}
	}
}
