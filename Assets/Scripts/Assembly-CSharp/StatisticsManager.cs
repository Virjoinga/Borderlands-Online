using System;
using System.Collections;
using System.Collections.Generic;
using A;
using Core;
using UnityEngine;
using XsdSettings;

public class StatisticsManager : c06ca0e618478c23eba3419653a19760f<StatisticsManager>
{
	public enum PingQuality
	{
		Low = 0,
		Medium = 1,
		High = 2
	}

	public class SessionStats
	{
		public string m_instanceName;

		public string m_mapName;

		public int m_playlistId;

		public ELevelDifficulty m_difficulty;

		public List<StatSheet> m_statsSheets = new List<StatSheet>();

		public int m_sessionLevelRange;

		public int m_timeLimit;

		public int m_endScore;

		public int m_endKillCount;

		public float m_duration;

		public int m_killCount { get; private set; }

		public void c21abc56059d171e999147f26bbf75889(PhotonStream c4f572e677246eb1a0cf92afc8682dc7b)
		{
			if (c4f572e677246eb1a0cf92afc8682dc7b.c8b2526be2638bb30a29ab8314b369311)
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
						c4f572e677246eb1a0cf92afc8682dc7b.caf7283cc5cd9725a88a9cdfa630d92f8((short)m_sessionLevelRange);
						c4f572e677246eb1a0cf92afc8682dc7b.caf7283cc5cd9725a88a9cdfa630d92f8((short)m_timeLimit);
						c4f572e677246eb1a0cf92afc8682dc7b.caf7283cc5cd9725a88a9cdfa630d92f8((short)m_endScore);
						c4f572e677246eb1a0cf92afc8682dc7b.caf7283cc5cd9725a88a9cdfa630d92f8((short)m_endKillCount);
						return;
					}
				}
			}
			m_sessionLevelRange = (short)c4f572e677246eb1a0cf92afc8682dc7b.cbc3e6f46d26c8fb00a98f05fc700248a();
			m_timeLimit = (short)c4f572e677246eb1a0cf92afc8682dc7b.cbc3e6f46d26c8fb00a98f05fc700248a();
			m_endScore = (short)c4f572e677246eb1a0cf92afc8682dc7b.cbc3e6f46d26c8fb00a98f05fc700248a();
			m_endKillCount = (short)c4f572e677246eb1a0cf92afc8682dc7b.cbc3e6f46d26c8fb00a98f05fc700248a();
		}

		public int cd5e6d79e1eab50259fd3eabb6af0bfd5()
		{
			return Mathf.Max(0, m_timeLimit - (int)c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c94ce42c8036c46b4b3e8327e21fffce0());
		}

		public void cf65f5870e4d34f78dbfa13a2392d8c0b()
		{
			m_killCount++;
		}

		public void cbaf7bab402e981ddfbcfb405d5f2f923(int c58bda81e8182122e809f8c789f59a6e4)
		{
			m_killCount = c58bda81e8182122e809f8c789f59a6e4;
		}

		public StatSheet cdb7db6721dec105d58123fc2c43fa883(PlayerInfoSync ceb41162a7cd2a1d5c4a03830e02b4198)
		{
			return c9c93863d9aadf94bb04b985014fb4cef(ceb41162a7cd2a1d5c4a03830e02b4198.m_characterId, ceb41162a7cd2a1d5c4a03830e02b4198.m_teamID, ceb41162a7cd2a1d5c4a03830e02b4198.m_name, c06ca0e618478c23eba3419653a19760f<LevelingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1ee9148b69b784ee94cf0d54409c8ee0(ceb41162a7cd2a1d5c4a03830e02b4198.m_avatarDna.c071244a19e2d9f70f4d2d6d38677162a(), ceb41162a7cd2a1d5c4a03830e02b4198.m_exp), false);
		}

		public void ce6bf36e217fcc303dbbaf5c8717c4b2a(PlayerInfoSync ceb41162a7cd2a1d5c4a03830e02b4198)
		{
			c9290e7c76b23e1075d6376626b897c65(ceb41162a7cd2a1d5c4a03830e02b4198.m_characterId, false);
		}

		public StatSheet cdcb2ff44fc70c31a5ec9c7f0156d8f27(PlayerInfoSync ceb41162a7cd2a1d5c4a03830e02b4198)
		{
			return cedee94723596d6f128e4fb046fec8bf2(ceb41162a7cd2a1d5c4a03830e02b4198.m_characterId, false);
		}

		public StatSheet c4df8d7d860c0beb0ca3ba64510fb0ba9(int c804e1fb3ce017e25e147307416292d7a)
		{
			return cedee94723596d6f128e4fb046fec8bf2(c804e1fb3ce017e25e147307416292d7a, true);
		}

		public StatSheet c848291d78ee9357cec9ec917ab8b8969(int c804e1fb3ce017e25e147307416292d7a)
		{
			return c9c93863d9aadf94bb04b985014fb4cef(c804e1fb3ce017e25e147307416292d7a, c804e1fb3ce017e25e147307416292d7a, c804e1fb3ce017e25e147307416292d7a.ToString(), 0, true);
		}

		public void c4b5792a6b0945540f8540ab028c98dcd(int c804e1fb3ce017e25e147307416292d7a)
		{
			c9290e7c76b23e1075d6376626b897c65(c804e1fb3ce017e25e147307416292d7a, true);
		}

		public StatSheet cedee94723596d6f128e4fb046fec8bf2(int c35f98ccbfa8c6bf09319c620b21b5dc5, bool c8f7104128fac87985a6a33c1f7312579)
		{
			for (int i = 0; i < m_statsSheets.Count; i++)
			{
				if (m_statsSheets[i].m_id != c35f98ccbfa8c6bf09319c620b21b5dc5)
				{
					continue;
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (m_statsSheets[i].m_isTeam != c8f7104128fac87985a6a33c1f7312579)
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
					return m_statsSheets[i];
				}
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				return null;
			}
		}

		public void c9290e7c76b23e1075d6376626b897c65(int c35f98ccbfa8c6bf09319c620b21b5dc5, bool c8f7104128fac87985a6a33c1f7312579)
		{
			for (int i = 0; i < m_statsSheets.Count; i++)
			{
				if (m_statsSheets[i].m_id != c35f98ccbfa8c6bf09319c620b21b5dc5)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (m_statsSheets[i].m_isTeam != c8f7104128fac87985a6a33c1f7312579)
				{
					continue;
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
				m_statsSheets.RemoveAt(i);
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

		public StatSheet c9c93863d9aadf94bb04b985014fb4cef(int c35f98ccbfa8c6bf09319c620b21b5dc5, int c804e1fb3ce017e25e147307416292d7a, string cd99af21e22e356018b8f72d4a7e4872a, int cd6bb591c33b2ee3ab93e98aa43a6da63, bool c8f7104128fac87985a6a33c1f7312579)
		{
			for (int i = 0; i < m_statsSheets.Count; i++)
			{
				if (m_statsSheets[i].m_id != c35f98ccbfa8c6bf09319c620b21b5dc5)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (m_statsSheets[i].m_isTeam != c8f7104128fac87985a6a33c1f7312579)
				{
					continue;
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					m_statsSheets[i].m_teamId = c804e1fb3ce017e25e147307416292d7a;
					m_statsSheets[i].m_level = cd6bb591c33b2ee3ab93e98aa43a6da63;
					return m_statsSheets[i];
				}
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				StatSheet statSheet = new StatSheet();
				statSheet.m_id = c35f98ccbfa8c6bf09319c620b21b5dc5;
				statSheet.m_teamId = c804e1fb3ce017e25e147307416292d7a;
				statSheet.m_name = cd99af21e22e356018b8f72d4a7e4872a;
				statSheet.m_level = cd6bb591c33b2ee3ab93e98aa43a6da63;
				statSheet.m_isTeam = c8f7104128fac87985a6a33c1f7312579;
				m_statsSheets.Add(statSheet);
				return statSheet;
			}
		}

		public object[] c08b2cef64c03654ac868055160ce1666()
		{
			return cac5e0eb9ccb8554c370ec833b3c6668f(this);
		}

		public int c415f9dee531e543fc447806c04e5e5f9()
		{
			int num = 0;
			for (int i = 0; i < m_statsSheets.Count; i++)
			{
				if (m_statsSheets[i].m_isTeam)
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
				num = Mathf.Max(num, m_statsSheets[i].m_score);
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				return num;
			}
		}

		public StatSheet c167429e9be097e1e036172092ef72105()
		{
			StatSheet statSheet = m_statsSheets[0];
			for (int i = 0; i < m_statsSheets.Count; i++)
			{
				if (m_statsSheets[i].m_isTeam)
				{
					continue;
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (m_statsSheets[i].m_score <= statSheet.m_score)
				{
					continue;
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
				statSheet = m_statsSheets[i];
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				return statSheet;
			}
		}

		public string c302d304131ef0b9a32ba8c5999bfce46()
		{
			StatSheet statSheet = m_statsSheets[0];
			for (int i = 0; i < m_statsSheets.Count; i++)
			{
				if (m_statsSheets[i].m_isTeam)
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
				if (m_statsSheets[i].m_skillCount <= statSheet.m_skillCount)
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
				statSheet = m_statsSheets[i];
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				return statSheet.m_name;
			}
		}

		public string c067fbf32a1f0a57fdc984a68bb773ef2()
		{
			StatSheet statSheet = m_statsSheets[0];
			for (int i = 0; i < m_statsSheets.Count; i++)
			{
				if (m_statsSheets[i].m_isTeam)
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
				if (m_statsSheets[i].m_grenadeKillCount <= statSheet.m_grenadeKillCount)
				{
					continue;
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
				statSheet = m_statsSheets[i];
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				return statSheet.m_name;
			}
		}

		public string c5612b528a562e624510f7286723cdbdf()
		{
			StatSheet statSheet = m_statsSheets[0];
			for (int i = 0; i < m_statsSheets.Count; i++)
			{
				if (m_statsSheets[i].m_isTeam)
				{
					continue;
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (m_statsSheets[i].m_headshotKillCount <= statSheet.m_headshotKillCount)
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
				statSheet = m_statsSheets[i];
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				return statSheet.m_name;
			}
		}

		public StatSheet c9e69f6afb2b50d93703124af45d4282c()
		{
			StatSheet result = m_statsSheets[0];
			int num = 0;
			while (true)
			{
				if (num < m_statsSheets.Count)
				{
					if (m_statsSheets[num].m_name == c1ee7921b0c3cce194fb7cae41b5a9d82<CharacterServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c4c40c6af474a3f102f58135c8f5f8409())
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
						result = m_statsSheets[num];
						break;
					}
					num++;
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
				break;
			}
			return result;
		}

		public int c64f58cc60811857c739035f7a63f475c()
		{
			return c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c64f58cc60811857c739035f7a63f475c();
		}

		public StatSheet ce3f8ddf52d20ed600b5d98ce3553eedd(int c5612a459a84ffdb41c885401433cd62d)
		{
			if (m_statsSheets == null)
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
						return null;
					}
				}
			}
			if (m_statsSheets.Count < 1)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						return null;
					}
				}
			}
			if (c5612a459a84ffdb41c885401433cd62d <= m_statsSheets.Count)
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
				if (c5612a459a84ffdb41c885401433cd62d >= 1)
				{
					LinkedList<StatSheet> linkedList = new LinkedList<StatSheet>();
					linkedList.AddFirst(m_statsSheets[0]);
					int num = 1;
					while (num < m_statsSheets.Count)
					{
						LinkedListNode<StatSheet> linkedListNode = linkedList.First;
						while (linkedListNode.Value.m_score > m_statsSheets[num].m_score)
						{
							if (linkedListNode == linkedList.Last)
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
								linkedList.AddAfter(linkedListNode, m_statsSheets[num]);
							}
							else
							{
								linkedListNode = linkedListNode.Next;
							}
						}
						while (true)
						{
							switch (6)
							{
							case 0:
								continue;
							}
							if (linkedListNode.Value.m_score < m_statsSheets[num].m_score)
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
								linkedList.AddBefore(linkedListNode, m_statsSheets[num]);
							}
							num++;
							break;
						}
					}
					while (true)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						LinkedListNode<StatSheet> linkedListNode2 = linkedList.First;
						for (int i = 1; i < c5612a459a84ffdb41c885401433cd62d; i++)
						{
							if (linkedListNode2 == null)
							{
								while (true)
								{
									switch (4)
									{
									case 0:
										break;
									default:
										return null;
									}
								}
							}
							linkedListNode2 = linkedListNode2.Next;
						}
						while (true)
						{
							switch (4)
							{
							case 0:
								continue;
							}
							if (linkedListNode2 == null)
							{
								while (true)
								{
									switch (5)
									{
									case 0:
										break;
									default:
										return null;
									}
								}
							}
							return linkedListNode2.Value;
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
					break;
				}
			}
			return null;
		}

		public int cfcc8770a968e4c3000aad65be068ae99()
		{
			int num = 0;
			for (int i = 0; i < m_statsSheets.Count; i++)
			{
				num = Mathf.Max(num, m_statsSheets[i].m_killCount);
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
				return num;
			}
		}

		public int c4d2b897929d3a76e632db9a02da4f5ff(int c2bc932848ba0f6a13e959e0af05fcf3c)
		{
			List<PlayerInfoSync> c9c8de68aa0982db2bbd496692c37e;
			c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c7822eacaa3505f8c170e4316704ac984(out c9c8de68aa0982db2bbd496692c37e);
			PlayerInfoSync[] array = c9c8de68aa0982db2bbd496692c37e.ToArray();
			Array.Sort(array, c7eb206db14d8da3c4f26d5579f983539);
			if (c2bc932848ba0f6a13e959e0af05fcf3c > 0)
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
				if (c2bc932848ba0f6a13e959e0af05fcf3c <= array.Length)
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
					StatSheet statSheet = cdcb2ff44fc70c31a5ec9c7f0156d8f27(array[c2bc932848ba0f6a13e959e0af05fcf3c - 1]);
					if (statSheet != null)
					{
						while (true)
						{
							switch (6)
							{
							case 0:
								break;
							default:
								return statSheet.m_score;
							}
						}
					}
				}
			}
			return 0;
		}

		public int c2016963052207f2f80b6eef4a79c4c1a(PlayerInfoSync ceb41162a7cd2a1d5c4a03830e02b4198)
		{
			List<PlayerInfoSync> c9c8de68aa0982db2bbd496692c37e;
			c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c7822eacaa3505f8c170e4316704ac984(out c9c8de68aa0982db2bbd496692c37e);
			PlayerInfoSync[] array = c9c8de68aa0982db2bbd496692c37e.ToArray();
			Array.Sort(array, c7eb206db14d8da3c4f26d5579f983539);
			for (int i = 0; i < array.Length; i++)
			{
				if (!(array[i] == ceb41162a7cd2a1d5c4a03830e02b4198))
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
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return i + 1;
				}
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				return 0;
			}
		}

		public int c7eb206db14d8da3c4f26d5579f983539(PlayerInfoSync c55548d7c3d612d81f44ffddf160db45c, PlayerInfoSync ce8331da224869a297200f69ab63fbbe9)
		{
			StatSheet c2993f6f258fe4579223a84a5bae0ed = cdcb2ff44fc70c31a5ec9c7f0156d8f27(c55548d7c3d612d81f44ffddf160db45c);
			StatSheet c568f0fb646e0f9df3ef10d50dec7cdaa = cdcb2ff44fc70c31a5ec9c7f0156d8f27(ce8331da224869a297200f69ab63fbbe9);
			return c7eb206db14d8da3c4f26d5579f983539(c2993f6f258fe4579223a84a5bae0ed, c568f0fb646e0f9df3ef10d50dec7cdaa);
		}

		public int c7eb206db14d8da3c4f26d5579f983539(StatSheet c2993f6f258fe4579223a84a5bae0ed06, StatSheet c568f0fb646e0f9df3ef10d50dec7cdaa)
		{
			if (c2993f6f258fe4579223a84a5bae0ed06 != null)
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
				if (c568f0fb646e0f9df3ef10d50dec7cdaa != null)
				{
					if (c2993f6f258fe4579223a84a5bae0ed06.m_killCount != c568f0fb646e0f9df3ef10d50dec7cdaa.m_killCount)
					{
						while (true)
						{
							switch (3)
							{
							case 0:
								break;
							default:
								return c568f0fb646e0f9df3ef10d50dec7cdaa.m_killCount - c2993f6f258fe4579223a84a5bae0ed06.m_killCount;
							}
						}
					}
					if (c2993f6f258fe4579223a84a5bae0ed06.m_deathcount != c568f0fb646e0f9df3ef10d50dec7cdaa.m_deathcount)
					{
						while (true)
						{
							switch (6)
							{
							case 0:
								break;
							default:
								return c2993f6f258fe4579223a84a5bae0ed06.m_deathcount - c568f0fb646e0f9df3ef10d50dec7cdaa.m_deathcount;
							}
						}
					}
					if (c2993f6f258fe4579223a84a5bae0ed06.m_score != c568f0fb646e0f9df3ef10d50dec7cdaa.m_score)
					{
						while (true)
						{
							switch (2)
							{
							case 0:
								break;
							default:
								return c568f0fb646e0f9df3ef10d50dec7cdaa.m_score - c2993f6f258fe4579223a84a5bae0ed06.m_score;
							}
						}
					}
					return -c2993f6f258fe4579223a84a5bae0ed06.m_lastKillTime.CompareTo(c568f0fb646e0f9df3ef10d50dec7cdaa.m_lastKillTime);
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
			return 0;
		}
	}

	public class StatSheet
	{
		public enum KillType
		{
			Normal = 0,
			Critical = 1,
			HeadShot = 2
		}

		public bool m_isTeam;

		public int m_id;

		public int m_teamId;

		public string m_name;

		public int m_level;

		public int m_lastKillerForRevenge;

		public int m_lastDamager;

		public int m_score;

		public int m_killCount;

		public int m_criticalKillCount;

		public int m_deathcount;

		public int m_totalDamage;

		public int m_criticalDamage;

		public int m_badassKill;

		public int m_bossKill;

		public int m_hitNumber;

		public int m_criticalHitNumber;

		public int m_sameVictimCount;

		public int m_meleeKillCount;

		public int m_grenadeKillCount;

		public int m_headshotKillCount;

		public int m_skillCount;

		public int m_nemesisCount;

		public Dictionary<AvatarType, Hashtable> m_skillKills;

		public Dictionary<WeaponType, Hashtable> m_weaponKills;

		public Dictionary<string, int> m_rivalTable;

		public int m_extraExp;

		public int m_extraMoney;

		public int m_honorValue;

		public int m_guildExp;

		public int m_killStreak;

		public int m_criticalKillStreak;

		public int m_deathStreak;

		public PingQuality m_ping;

		public float m_lastDamageTime;

		public float m_livingInterval;

		public float m_flyingInterval;

		public float m_standStillInterval;

		public Vector3 m_lastPos;

		public float m_lastKillTime;

		public float[] m_last4KillTimes;

		public int m_lastKillTimeIndex;

		public float m_SmgUsage;

		public float m_SniperUsage;

		public float m_ShotgunUsage;

		public float m_PistolUsage;

		public float m_CombatRifleUsage;

		private float m_lastSwitchTime;

		public InstanceGrade ca329c5118ba5116b53cec9efd5542cff
		{
			get
			{
				if (m_score >= 95)
				{
					while (true)
					{
						switch (2)
						{
						case 0:
							break;
						default:
							if (1 == 0)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							return InstanceGrade.S;
						}
					}
				}
				if (m_score >= 85)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							return InstanceGrade.A;
						}
					}
				}
				if (m_score >= 76)
				{
					while (true)
					{
						switch (2)
						{
						case 0:
							break;
						default:
							return InstanceGrade.B;
						}
					}
				}
				return InstanceGrade.C;
			}
		}

		public StatSheet()
		{
			Reset(string.Empty);
		}

		public void Reset(string name)
		{
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Stats, "StatSheet Reset [" + name + "]");
			m_name = name;
			m_lastKillerForRevenge = 0;
			m_lastDamager = 0;
			m_score = 0;
			m_killCount = 0;
			m_criticalKillCount = 0;
			m_meleeKillCount = 0;
			m_nemesisCount = 0;
			m_grenadeKillCount = 0;
			m_headshotKillCount = 0;
			m_skillCount = 0;
			m_skillKills = new Dictionary<AvatarType, Hashtable>();
			for (int i = 0; i < Enum.GetValues(Type.GetTypeFromHandle(c6b6839a04f0eb5690830cb0f6c6e137f.cc1720d05c75832f704b87474932341c3())).Length; i++)
			{
				m_skillKills.Add((AvatarType)i, new Hashtable());
				m_skillKills[(AvatarType)i].Add(0, 0);
				m_skillKills[(AvatarType)i].Add(1, 0);
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
				m_weaponKills = new Dictionary<WeaponType, Hashtable>();
				for (int j = 0; j < Enum.GetValues(Type.GetTypeFromHandle(cb69030d5cbca58447fc871be9aade1a0.cc1720d05c75832f704b87474932341c3())).Length; j++)
				{
					m_weaponKills.Add((WeaponType)j, new Hashtable());
					m_weaponKills[(WeaponType)j].Add(0, 0);
					m_weaponKills[(WeaponType)j].Add(1, 0);
					m_weaponKills[(WeaponType)j].Add(2, 0);
				}
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					m_rivalTable = new Dictionary<string, int>();
					m_deathcount = 0;
					m_totalDamage = 0;
					m_criticalDamage = 0;
					m_badassKill = 0;
					m_bossKill = 0;
					m_hitNumber = 0;
					m_criticalHitNumber = 0;
					m_sameVictimCount = 0;
					m_extraExp = 0;
					m_extraMoney = 0;
					m_honorValue = 0;
					m_guildExp = 0;
					m_killStreak = 0;
					m_criticalKillStreak = 0;
					m_deathStreak = 0;
					m_livingInterval = 0f;
					m_flyingInterval = 0f;
					m_standStillInterval = 0f;
					m_lastPos = Vector3.zero;
					m_lastKillTime = 0f;
					m_last4KillTimes = c45a99a14f737cada4caa361b45034f4d.c0a0cdf4a196914163f7334d9b0781a04(4);
					m_lastKillTimeIndex = -1;
					m_SmgUsage = 0f;
					m_SniperUsage = 0f;
					m_ShotgunUsage = 0f;
					m_PistolUsage = 0f;
					m_CombatRifleUsage = 0f;
					m_lastSwitchTime = Time.time;
					return;
				}
			}
		}

		public string ce216d34e7c8d4f31c9856f7585291f40()
		{
			string result = string.Empty;
			int num = 0;
			Dictionary<string, int>.Enumerator enumerator = m_rivalTable.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Value < num)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				result = enumerator.Current.Key;
				num = enumerator.Current.Value;
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				return result;
			}
		}

		public void c9924fc82f3b52e12b6256075475bdd9c(float cfcfdc1af24f820ab1b44039878f3c2cc)
		{
			if (cfcfdc1af24f820ab1b44039878f3c2cc <= 100f)
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
						m_ping = PingQuality.High;
						return;
					}
				}
			}
			if (cfcfdc1af24f820ab1b44039878f3c2cc <= 300f)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						m_ping = PingQuality.Medium;
						return;
					}
				}
			}
			m_ping = PingQuality.Low;
		}

		public void cca84ca4deababdecf8f3d8cc7a45edb9(bool cbebeaa4b36a302a484790d731f551986)
		{
			if (cbebeaa4b36a302a484790d731f551986)
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
						EntityWeapon entityWeapon;
						if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().c66b232dbebded7c7e9a89c1e8bd84689() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							entityWeapon = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().c66b232dbebded7c7e9a89c1e8bd84689().c3941dac8608f650ceb15dc36294a741c();
						}
						else
						{
							entityWeapon = ceaa467e9f01cebcf620c4729a7dcef3f.c7088de59e49f7108f520cf7e0bae167e;
						}
						EntityWeapon entityWeapon2 = entityWeapon;
						if ((bool)entityWeapon2)
						{
							while (true)
							{
								switch (1)
								{
								case 0:
									break;
								default:
									c1a6327c9e7b6688a621c96ccac024ec4(entityWeapon2.c83e548e5608cd7f222098a6966b16545());
									return;
								}
							}
						}
						return;
					}
					}
				}
			}
			m_lastSwitchTime = Time.time;
		}

		public void c1a6327c9e7b6688a621c96ccac024ec4(WeaponType c1c5db00626325496487cb3c00f9209cd)
		{
			float time = Time.time;
			switch (c1c5db00626325496487cb3c00f9209cd)
			{
			case WeaponType.SMG:
				m_SmgUsage += time - m_lastSwitchTime;
				break;
			case WeaponType.SniperRifle:
				m_SniperUsage += time - m_lastSwitchTime;
				break;
			case WeaponType.ShotGun:
				m_ShotgunUsage += time - m_lastSwitchTime;
				break;
			case WeaponType.RepeaterPistol:
				m_PistolUsage += time - m_lastSwitchTime;
				break;
			case WeaponType.CombatRifle:
				m_CombatRifleUsage += time - m_lastSwitchTime;
				break;
			}
			m_lastSwitchTime = time;
		}

		public void c839ccf8ec798aa926765aabf6701d67c(KillContext c2970555c0fc69d9442a248a8e3fc971c)
		{
			if (c2970555c0fc69d9442a248a8e3fc971c.m_killer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				m_lastKillerForRevenge = c2970555c0fc69d9442a248a8e3fc971c.m_killer.cc7403315505256d19a7b92aa614a8f10();
			}
			m_deathcount++;
			m_deathStreak++;
			m_killStreak = 0;
			m_criticalKillStreak = 0;
			m_livingInterval = 0f;
			int value = 0;
			if (!m_rivalTable.TryGetValue(c2970555c0fc69d9442a248a8e3fc971c.m_killer.m_name, out value))
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
				m_rivalTable.Add(c2970555c0fc69d9442a248a8e3fc971c.m_killer.m_name, 0);
			}
			Dictionary<string, int> rivalTable;
			Dictionary<string, int> dictionary = (rivalTable = m_rivalTable);
			string name;
			string key = (name = c2970555c0fc69d9442a248a8e3fc971c.m_killer.m_name);
			int num = rivalTable[name];
			dictionary[key] = num + 1;
		}

		public void cdb2127413cce26bb79a7ae953459f365(int cf13fd632f93aa296c99679582ff35a65)
		{
			m_extraExp += cf13fd632f93aa296c99679582ff35a65;
		}

		public void c50279d3fc48f71879c00951e4c85eac6(DamageContext c2970555c0fc69d9442a248a8e3fc971c)
		{
			bool flag = c2970555c0fc69d9442a248a8e3fc971c.m_strengthType == WeakPoint.StrengthType.VeryWeak;
			if (AttackInfo.cb40d9d92cf67eb5b4aecc077640e0f4e(c2970555c0fc69d9442a248a8e3fc971c.m_subType) == AttackInfo.AttackType.Projectile)
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
				m_hitNumber++;
				if (flag)
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
					m_criticalHitNumber++;
				}
			}
			m_totalDamage += c2970555c0fc69d9442a248a8e3fc971c.m_damageInfo.m_healthDamagePoints;
			if (!flag)
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
				m_criticalDamage += c2970555c0fc69d9442a248a8e3fc971c.m_damageInfo.m_healthDamagePoints;
				return;
			}
		}

		public void ccc077a08d65555c9e21142b9eaddeb30(DamageContext c2970555c0fc69d9442a248a8e3fc971c)
		{
			if (c2970555c0fc69d9442a248a8e3fc971c.m_killer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						m_lastDamager = c2970555c0fc69d9442a248a8e3fc971c.m_killer.cc7403315505256d19a7b92aa614a8f10();
						m_lastDamageTime = Time.time;
						return;
					}
				}
			}
			m_lastDamager = 0;
		}

		public float c4bf4414fb603fdda6c5240ff6e49d374(int c7c4e87a009ef9b8190abef69193117e8)
		{
			if (m_last4KillTimes == null)
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
						return 0f;
					}
				}
			}
			if (c7c4e87a009ef9b8190abef69193117e8 > m_last4KillTimes.Length - 1)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						return 0f;
					}
				}
			}
			if (m_lastKillTimeIndex >= 0)
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
				if (m_lastKillTimeIndex < m_last4KillTimes.Length)
				{
					int num = (m_lastKillTimeIndex - c7c4e87a009ef9b8190abef69193117e8 + m_last4KillTimes.Length) % m_last4KillTimes.Length;
					if (num >= 0)
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
						if (num < m_last4KillTimes.Length)
						{
							return m_last4KillTimes[m_lastKillTimeIndex] - m_last4KillTimes[num];
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
					}
					return 0f;
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
			return 0f;
		}

		public void c94a3dded3cebe251338ae0047e5e7c0f()
		{
			m_lastKillTimeIndex = -1;
		}

		public void c47cc5329fc69109ff70ca356b2f22bb6(WeaponType c27b7430edc94b8f5b543605119ec4a72, KillType c1f2da5d5df942706db1acaf5e7816206)
		{
			object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(5);
			array[0] = "StatSheet.AddWeaponKill[";
			array[1] = c27b7430edc94b8f5b543605119ec4a72;
			array[2] = "][";
			array[3] = c1f2da5d5df942706db1acaf5e7816206;
			array[4] = "]";
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Gamelogic, string.Concat(array));
			int num = (int)m_weaponKills[c27b7430edc94b8f5b543605119ec4a72][(int)c1f2da5d5df942706db1acaf5e7816206];
			m_weaponKills[c27b7430edc94b8f5b543605119ec4a72][(int)c1f2da5d5df942706db1acaf5e7816206] = num + 1;
		}

		public void c1babe499d121710272f7c72c1e923d1c(AvatarType c02f15d17d3be88f612695c422dc620bd)
		{
			int num = (int)m_skillKills[c02f15d17d3be88f612695c422dc620bd][1];
			m_skillKills[c02f15d17d3be88f612695c422dc620bd][1] = num + 1;
			m_skillCount++;
		}

		public void c611e11cf601ce0cd8cfc3a60ab2576fb(AvatarType c02f15d17d3be88f612695c422dc620bd)
		{
			int num = (int)m_skillKills[c02f15d17d3be88f612695c422dc620bd][0];
			m_skillKills[c02f15d17d3be88f612695c422dc620bd][0] = num + 1;
		}

		public void cf0fba2b784eca34c5d9a786db55811af(KillContext c2970555c0fc69d9442a248a8e3fc971c)
		{
			if (c2970555c0fc69d9442a248a8e3fc971c.m_killer == c2970555c0fc69d9442a248a8e3fc971c.m_victim)
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
			m_lastKillTime = Time.time;
			m_lastKillTimeIndex = (m_lastKillTimeIndex + 1) % m_last4KillTimes.Length;
			m_last4KillTimes[m_lastKillTimeIndex] = Time.time;
			int num;
			if (c2970555c0fc69d9442a248a8e3fc971c.m_strengthType == WeakPoint.StrengthType.VeryWeak)
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
				num = 1;
			}
			else
			{
				num = 0;
			}
			int num2 = num;
			m_killCount++;
			m_criticalKillCount += num2;
			m_deathStreak = 0;
			m_killStreak++;
			m_criticalKillStreak += num2;
			EntityNpc entityNpc = c2970555c0fc69d9442a248a8e3fc971c.m_victim as EntityNpc;
			if (!(entityNpc != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (entityNpc.c90ea3a207cd50bba4ba7c81b9ff2bcb5())
				{
					while (true)
					{
						switch (4)
						{
						case 0:
							break;
						default:
							m_bossKill++;
							return;
						}
					}
				}
				if (!entityNpc.cb3c049644818b9981f10871585889e97())
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
					m_badassKill++;
					return;
				}
			}
		}
	}

	private bool m_isRecording;

	private SessionStats m_currentSession = new SessionStats();

	private SessionStats m_lastScoreBoard = new SessionStats();

	public SessionStats c45046ccb66f97acb081de281306e5c25()
	{
		return m_currentSession;
	}

	public void c78d87698736a1e200b5e7caf5ae1d950()
	{
		m_isRecording = true;
		c45046ccb66f97acb081de281306e5c25().cbaf7bab402e981ddfbcfb405d5f2f923(0);
		c45046ccb66f97acb081de281306e5c25().m_instanceName = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c9d8ee6a5af1e2ca6cb9e7b7a609a6d69();
		c45046ccb66f97acb081de281306e5c25().m_difficulty = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.cfee2582eaf7bd61748c6f890c1e9365d();
		c45046ccb66f97acb081de281306e5c25().m_sessionLevelRange = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.cff61fc67eb6ac43c4cb6125ccbc8857c();
		c45046ccb66f97acb081de281306e5c25().m_playlistId = MatchmakingService.c5ee19dc8d4cccf5ae2de225410458b86.c8e693f5f3ec2e82bd093c9a5d56bdf43().m_id;
		c45046ccb66f97acb081de281306e5c25().m_mapName = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.ce5a94914572053ccdd4c35353ff8d650();
	}

	public void cd1ac1729b2ffe9d1bc0efb8d4f05abf8()
	{
		if (!m_isRecording)
		{
			while (true)
			{
				switch (7)
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
		PlayerInfoSync playerInfoSync = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56();
		if ((bool)playerInfoSync)
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
			EntityWeapon entityWeapon;
			if (playerInfoSync.c66b232dbebded7c7e9a89c1e8bd84689() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				entityWeapon = playerInfoSync.c66b232dbebded7c7e9a89c1e8bd84689().c3941dac8608f650ceb15dc36294a741c();
			}
			else
			{
				entityWeapon = ceaa467e9f01cebcf620c4729a7dcef3f.c7088de59e49f7108f520cf7e0bae167e;
			}
			EntityWeapon entityWeapon2 = entityWeapon;
			if ((bool)entityWeapon2)
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
				StatSheet statSheet = c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c45046ccb66f97acb081de281306e5c25().cdcb2ff44fc70c31a5ec9c7f0156d8f27(playerInfoSync);
				statSheet.c1a6327c9e7b6688a621c96ccac024ec4(entityWeapon2.c83e548e5608cd7f222098a6966b16545());
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Stats, "Weapon Usage for [" + playerInfoSync.m_name + "]");
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Stats, "SMG - " + statSheet.m_SmgUsage);
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Stats, "SniperRifle - " + statSheet.m_SniperUsage);
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Stats, "ShotGun - " + statSheet.m_ShotgunUsage);
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Stats, "Pistol - " + statSheet.m_PistolUsage);
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Stats, "CombatRifle - " + statSheet.m_CombatRifleUsage);
			}
		}
		m_isRecording = false;
	}

	public void c06778e43cc664bde56af0583cc97cdc0(object[] c02d7c52d563d7c8df2254f24486c36da)
	{
		m_currentSession = c975d0b97cc4c466717ecba0a98a0b491(c02d7c52d563d7c8df2254f24486c36da);
	}

	public void c712cfd0ed5ca21466f48bb3a7eada465(object[] c02d7c52d563d7c8df2254f24486c36da)
	{
		if (!m_isRecording)
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
		PlayerInfoSync playerInfoSync = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56();
		if ((bool)playerInfoSync)
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
			EntityWeapon entityWeapon;
			if (playerInfoSync.c66b232dbebded7c7e9a89c1e8bd84689() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				entityWeapon = playerInfoSync.c66b232dbebded7c7e9a89c1e8bd84689().c3941dac8608f650ceb15dc36294a741c();
			}
			else
			{
				entityWeapon = ceaa467e9f01cebcf620c4729a7dcef3f.c7088de59e49f7108f520cf7e0bae167e;
			}
			EntityWeapon entityWeapon2 = entityWeapon;
			if ((bool)entityWeapon2)
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
				StatSheet statSheet = c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c45046ccb66f97acb081de281306e5c25().cdcb2ff44fc70c31a5ec9c7f0156d8f27(playerInfoSync);
				statSheet.c1a6327c9e7b6688a621c96ccac024ec4(entityWeapon2.c83e548e5608cd7f222098a6966b16545());
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Stats, "Weapon Usage for [" + playerInfoSync.m_name + "]");
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Stats, "SMG - " + statSheet.m_SmgUsage);
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Stats, "SniperRifle - " + statSheet.m_SniperUsage);
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Stats, "ShotGun - " + statSheet.m_ShotgunUsage);
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Stats, "Pistol - " + statSheet.m_PistolUsage);
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Stats, "CombatRifle - " + statSheet.m_CombatRifleUsage);
			}
		}
		m_lastScoreBoard = c975d0b97cc4c466717ecba0a98a0b491(c02d7c52d563d7c8df2254f24486c36da);
		m_lastScoreBoard.c9e69f6afb2b50d93703124af45d4282c().m_rivalTable = m_currentSession.c9e69f6afb2b50d93703124af45d4282c().m_rivalTable;
		m_isRecording = false;
	}

	public SessionStats c876ebada48854e6e8e29d50bc5352240()
	{
		return m_lastScoreBoard;
	}

	public StatSheet[] c977d0006b79865307bd0d0edd98b35fc()
	{
		return m_currentSession.m_statsSheets.ToArray();
	}

	public static object[] cac5e0eb9ccb8554c370ec833b3c6668f(SessionStats c79481ca22d0ff4b145e4fe24cc5d6f6b)
	{
		List<object> list = new List<object>();
		list.Add(c79481ca22d0ff4b145e4fe24cc5d6f6b.m_instanceName);
		list.Add((byte)c79481ca22d0ff4b145e4fe24cc5d6f6b.m_difficulty);
		list.Add(c79481ca22d0ff4b145e4fe24cc5d6f6b.m_duration);
		list.Add(c79481ca22d0ff4b145e4fe24cc5d6f6b.m_timeLimit);
		list.Add(c79481ca22d0ff4b145e4fe24cc5d6f6b.m_endScore);
		list.Add((short)c79481ca22d0ff4b145e4fe24cc5d6f6b.m_killCount);
		list.Add((byte)c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets.Count);
		int num = 0;
		while (num < c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets.Count)
		{
			list.Add(c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[num].m_id);
			list.Add(c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[num].m_teamId);
			list.Add(c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[num].m_isTeam);
			list.Add(c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[num].m_name);
			list.Add(c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[num].m_level);
			list.Add((short)c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[num].m_lastKillerForRevenge);
			list.Add((short)c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[num].m_lastDamager);
			list.Add((short)c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[num].m_score);
			list.Add((byte)c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[num].m_killCount);
			list.Add((byte)c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[num].m_criticalKillCount);
			list.Add((byte)c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[num].m_deathcount);
			list.Add(c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[num].m_totalDamage);
			list.Add(c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[num].m_criticalDamage);
			list.Add((byte)c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[num].m_badassKill);
			list.Add((byte)c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[num].m_bossKill);
			list.Add((short)c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[num].m_hitNumber);
			list.Add((short)c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[num].m_criticalHitNumber);
			list.Add((short)c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[num].m_sameVictimCount);
			list.Add((short)c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[num].m_meleeKillCount);
			list.Add((short)c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[num].m_nemesisCount);
			list.Add((short)c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[num].m_grenadeKillCount);
			list.Add((short)c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[num].m_headshotKillCount);
			list.Add((short)c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[num].m_skillCount);
			list.Add(c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[num].m_extraExp);
			list.Add(c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[num].m_extraMoney);
			list.Add(c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[num].m_honorValue);
			list.Add(c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[num].m_guildExp);
			list.Add((byte)c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[num].m_killStreak);
			list.Add((byte)c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[num].m_criticalKillStreak);
			list.Add((byte)c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[num].m_deathStreak);
			list.Add((byte)c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[num].m_ping);
			list.Add(c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[num].m_lastDamageTime);
			list.Add(c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[num].m_livingInterval);
			list.Add(c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[num].m_flyingInterval);
			list.Add(c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[num].m_lastKillTime);
			list.Add((byte)c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[num].m_last4KillTimes.Length);
			for (int i = 0; i < c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[num].m_last4KillTimes.Length; i++)
			{
				list.Add(c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[num].m_last4KillTimes[i]);
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
				list.Add((byte)c79481ca22d0ff4b145e4fe24cc5d6f6b.m_statsSheets[num].m_lastKillTimeIndex);
				num++;
				break;
			}
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			return list.ToArray();
		}
	}

	private static SessionStats c975d0b97cc4c466717ecba0a98a0b491(object[] c591d56a94543e3559945c497f37126c4)
	{
		int num = 0;
		SessionStats sessionStats = new SessionStats();
		sessionStats.m_instanceName = (string)c591d56a94543e3559945c497f37126c4[num++];
		sessionStats.m_difficulty = (ELevelDifficulty)(byte)c591d56a94543e3559945c497f37126c4[num++];
		sessionStats.m_duration = (float)c591d56a94543e3559945c497f37126c4[num++];
		sessionStats.m_timeLimit = (int)c591d56a94543e3559945c497f37126c4[num++];
		sessionStats.m_endScore = (int)c591d56a94543e3559945c497f37126c4[num++];
		sessionStats.cbaf7bab402e981ddfbcfb405d5f2f923((short)c591d56a94543e3559945c497f37126c4[num++]);
		byte b = (byte)c591d56a94543e3559945c497f37126c4[num++];
		sessionStats.m_statsSheets = new List<StatSheet>();
		int num2 = 0;
		while (num2 < b)
		{
			StatSheet statSheet = new StatSheet();
			statSheet = new StatSheet();
			statSheet.m_id = (int)c591d56a94543e3559945c497f37126c4[num++];
			statSheet.m_teamId = (int)c591d56a94543e3559945c497f37126c4[num++];
			statSheet.m_isTeam = (bool)c591d56a94543e3559945c497f37126c4[num++];
			statSheet.m_name = (string)c591d56a94543e3559945c497f37126c4[num++];
			statSheet.m_level = (int)c591d56a94543e3559945c497f37126c4[num++];
			statSheet.m_lastKillerForRevenge = (short)c591d56a94543e3559945c497f37126c4[num++];
			statSheet.m_lastDamager = (short)c591d56a94543e3559945c497f37126c4[num++];
			statSheet.m_score = (short)c591d56a94543e3559945c497f37126c4[num++];
			statSheet.m_killCount = (byte)c591d56a94543e3559945c497f37126c4[num++];
			statSheet.m_criticalKillCount = (byte)c591d56a94543e3559945c497f37126c4[num++];
			statSheet.m_deathcount = (byte)c591d56a94543e3559945c497f37126c4[num++];
			statSheet.m_totalDamage = (int)c591d56a94543e3559945c497f37126c4[num++];
			statSheet.m_criticalDamage = (int)c591d56a94543e3559945c497f37126c4[num++];
			statSheet.m_badassKill = (byte)c591d56a94543e3559945c497f37126c4[num++];
			statSheet.m_bossKill = (byte)c591d56a94543e3559945c497f37126c4[num++];
			statSheet.m_hitNumber = (short)c591d56a94543e3559945c497f37126c4[num++];
			statSheet.m_criticalHitNumber = (short)c591d56a94543e3559945c497f37126c4[num++];
			statSheet.m_sameVictimCount = (short)c591d56a94543e3559945c497f37126c4[num++];
			statSheet.m_meleeKillCount = (short)c591d56a94543e3559945c497f37126c4[num++];
			statSheet.m_nemesisCount = (short)c591d56a94543e3559945c497f37126c4[num++];
			statSheet.m_grenadeKillCount = (short)c591d56a94543e3559945c497f37126c4[num++];
			statSheet.m_headshotKillCount = (short)c591d56a94543e3559945c497f37126c4[num++];
			statSheet.m_skillCount = (short)c591d56a94543e3559945c497f37126c4[num++];
			statSheet.m_extraExp = (int)c591d56a94543e3559945c497f37126c4[num++];
			statSheet.m_extraMoney = (int)c591d56a94543e3559945c497f37126c4[num++];
			statSheet.m_honorValue = (int)c591d56a94543e3559945c497f37126c4[num++];
			statSheet.m_guildExp = (int)c591d56a94543e3559945c497f37126c4[num++];
			statSheet.m_killStreak = (byte)c591d56a94543e3559945c497f37126c4[num++];
			statSheet.m_criticalKillStreak = (byte)c591d56a94543e3559945c497f37126c4[num++];
			statSheet.m_deathStreak = (byte)c591d56a94543e3559945c497f37126c4[num++];
			statSheet.m_ping = (PingQuality)(byte)c591d56a94543e3559945c497f37126c4[num++];
			statSheet.m_lastDamageTime = (float)c591d56a94543e3559945c497f37126c4[num++];
			statSheet.m_livingInterval = (float)c591d56a94543e3559945c497f37126c4[num++];
			statSheet.m_flyingInterval = (float)c591d56a94543e3559945c497f37126c4[num++];
			statSheet.m_lastKillTime = (float)c591d56a94543e3559945c497f37126c4[num++];
			int num3 = (byte)c591d56a94543e3559945c497f37126c4[num++];
			statSheet.m_last4KillTimes = c45a99a14f737cada4caa361b45034f4d.c0a0cdf4a196914163f7334d9b0781a04(num3);
			for (int i = 0; i < num3; i++)
			{
				statSheet.m_last4KillTimes[i] = (float)c591d56a94543e3559945c497f37126c4[num++];
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
				statSheet.m_lastKillTimeIndex = (byte)c591d56a94543e3559945c497f37126c4[num++];
				sessionStats.m_statsSheets.Add(statSheet);
				num2++;
				break;
			}
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			return sessionStats;
		}
	}
}
