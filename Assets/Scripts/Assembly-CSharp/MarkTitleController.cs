using System.Collections.Generic;
using A;
using UnityEngine;

public class MarkTitleController
{
	public class TitleInfo
	{
		public MarkManager.BroadcastMarkedInfo m_markedInfo;

		public GameObject m_ui_obj;

		private int level_lasttick;

		public TitleInfo(MarkManager.BroadcastMarkedInfo c26c2a562b5aa8b33b9782e04ed37918b, GameObject c92be84c2929e14255cef0634f9677b3f)
		{
			m_markedInfo = c26c2a562b5aa8b33b9782e04ed37918b;
			m_ui_obj = c92be84c2929e14255cef0634f9677b3f;
		}

		public bool c1b4287a6c8f9d51b23a7cfbb28671c8d()
		{
			return m_ui_obj != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e;
		}

		public void c6bf746cbb8e0419c327e6db236041cd3()
		{
			if (m_markedInfo.m_mark_level > 0)
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
				if (level_lasttick == 0)
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
					c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c9e16403ef21c39f75e639d41fc5111b7().cd9568bf035fae5f39fd87a96cba69fa2(m_markedInfo.c66b232dbebded7c7e9a89c1e8bd84689(), 99999f, CharacterFxMgr.FX_TYPE.FX_HUNTER_MARK);
					goto IL_00a5;
				}
			}
			if (m_markedInfo.m_mark_level == 0)
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
				if (level_lasttick > 0)
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
					c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c9e16403ef21c39f75e639d41fc5111b7().cddbb691fc8f8aca349591e50c2f98b80(m_markedInfo.c66b232dbebded7c7e9a89c1e8bd84689());
				}
			}
			goto IL_00a5;
			IL_00a5:
			level_lasttick = m_markedInfo.m_mark_level;
		}
	}

	private Dictionary<int, TitleInfo> m_titleList = new Dictionary<int, TitleInfo>();

	private List<TitleInfo> m_toRemoveList = new List<TitleInfo>();

	private NpcTitleMgr m_uimgr;

	private List<Entity> m_temp_marked_list = new List<Entity>();

	private NpcTitleMgr c4f6c56c28729608780780f466400cd6f
	{
		get
		{
			if (m_uimgr == null)
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
				m_uimgr = c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.cd76850fff3f38531496e8d16b9a1db09();
			}
			return m_uimgr;
		}
	}

	public void OnGetTitleInfo(MarkManager.BroadcastMarkedInfo _newInfo)
	{
		if (_newInfo == null)
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
			if (_newInfo.c66b232dbebded7c7e9a89c1e8bd84689() == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (_newInfo.c66b232dbebded7c7e9a89c1e8bd84689().ce003fe849cc45b85ca4570109817c796())
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
					if (m_titleList == null)
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
						if (c4f6c56c28729608780780f466400cd6f == null)
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
						int entity_id = _newInfo.m_entity_id;
						if (!m_titleList.ContainsKey(entity_id))
						{
							while (true)
							{
								switch (2)
								{
								case 0:
									continue;
								}
								m_titleList[entity_id] = new TitleInfo(_newInfo, cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e);
								return;
							}
						}
						TitleInfo titleInfo = m_titleList[entity_id];
						if (!titleInfo.c1b4287a6c8f9d51b23a7cfbb28671c8d())
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
							if (_newInfo.m_mark_level > 0)
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
								if (!c95cd2eaf57f155c93fb4b927b52ca60e(_newInfo.c66b232dbebded7c7e9a89c1e8bd84689()))
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
									Vector3 up = Vector3.up;
									if (_newInfo.c66b232dbebded7c7e9a89c1e8bd84689() is EntityNpc)
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
										up.y = _newInfo.c66b232dbebded7c7e9a89c1e8bd84689().m_entityHeight;
									}
									titleInfo.m_ui_obj = c4f6c56c28729608780780f466400cd6f.c56e7023c9b616eca4ee05b6fe564f13d(_newInfo.c66b232dbebded7c7e9a89c1e8bd84689().gameObject, up, _newInfo.m_mark_level.ToString(), NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_SKILL);
								}
							}
						}
						int mark_level;
						int mark_level2;
						GameObject gameObject;
						if (titleInfo.c1b4287a6c8f9d51b23a7cfbb28671c8d())
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
							mark_level = titleInfo.m_markedInfo.m_mark_level;
							mark_level2 = _newInfo.m_mark_level;
							gameObject = _newInfo.c66b232dbebded7c7e9a89c1e8bd84689().gameObject;
							if (mark_level != mark_level2)
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
								if (mark_level == 0)
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
									if (mark_level2 > 0)
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
										c4f6c56c28729608780780f466400cd6f.ca6ac12c7e3baf8b991ea8855be177e29(gameObject);
										c4f6c56c28729608780780f466400cd6f.cf5f3d76ee14f5eecbe23e4814d041f23(gameObject, mark_level2);
										goto IL_0243;
									}
								}
								if (mark_level > 0)
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
									if (mark_level2 == 0)
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
										c4f6c56c28729608780780f466400cd6f.c1df48099cdcf8d823e68395243c06932(gameObject);
										goto IL_0243;
									}
								}
								c4f6c56c28729608780780f466400cd6f.cf5f3d76ee14f5eecbe23e4814d041f23(gameObject, mark_level2);
								goto IL_0243;
							}
							goto IL_02af;
						}
						goto IL_0322;
						IL_0322:
						titleInfo.m_markedInfo = _newInfo;
						return;
						IL_02af:
						MarkManager.MarkPhase phase = titleInfo.m_markedInfo.m_phase;
						MarkManager.MarkPhase phase2 = _newInfo.m_phase;
						if (phase == MarkManager.MarkPhase.Marking)
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
							if (phase2 != 0)
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
								c4f6c56c28729608780780f466400cd6f.cb78df4930894dc7183d21d17dcc5b2f9(gameObject, NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_SKILL, false);
								goto IL_0322;
							}
						}
						if (phase != 0)
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
							if (phase2 == MarkManager.MarkPhase.Marking)
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
								c4f6c56c28729608780780f466400cd6f.cb78df4930894dc7183d21d17dcc5b2f9(gameObject, NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_SKILL, true);
							}
						}
						goto IL_0322;
						IL_0243:
						if (mark_level2 > mark_level)
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
							Entity entity = _newInfo.c66b232dbebded7c7e9a89c1e8bd84689();
							WeakPoint c38b98045365f4b50a4fbe3f1d89af = c581015e4f6ee9df70e01d3565f2f7aca.c7088de59e49f7108f520cf7e0bae167e;
							entity.c659e11237d268aac8b68c419cf6b053a(out c38b98045365f4b50a4fbe3f1d89af);
							entity.ccdbbc6879c7efc53e81b9c2fbaceead9().c930218e437c0501ced1553e08dab14d9(ENPCParticleType.E_Marked_Slag, entity, c38b98045365f4b50a4fbe3f1d89af.transform, Vector3.zero, Quaternion.identity);
							MarkCollect.c5ee19dc8d4cccf5ae2de225410458b86.OnMarkLevelChanged(entity);
						}
						goto IL_02af;
					}
				}
			}
		}
	}

	public void OnLateUpdate()
	{
		Dictionary<int, TitleInfo>.Enumerator enumerator = m_titleList.GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (enumerator.Current.Value == null)
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
			}
			else
			{
				enumerator.Current.Value.c6bf746cbb8e0419c327e6db236041cd3();
			}
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			enumerator = m_titleList.GetEnumerator();
			m_toRemoveList.Clear();
			while (enumerator.MoveNext())
			{
				TitleInfo value = enumerator.Current.Value;
				if (value == null)
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
					continue;
				}
				if (value.m_markedInfo == null)
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
					continue;
				}
				Entity entity = value.m_markedInfo.c66b232dbebded7c7e9a89c1e8bd84689();
				if (entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					continue;
				}
				if (!entity.ce003fe849cc45b85ca4570109817c796())
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
				m_toRemoveList.Add(value);
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				for (int i = 0; i < m_toRemoveList.Count; i++)
				{
					TitleInfo titleInfo = m_toRemoveList[i];
					if (titleInfo == null)
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
						continue;
					}
					if (titleInfo.m_markedInfo == null)
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
						continue;
					}
					Entity entity2 = titleInfo.m_markedInfo.c66b232dbebded7c7e9a89c1e8bd84689();
					if (entity2 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					}
					else if (c4f6c56c28729608780780f466400cd6f == null)
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
					}
					else
					{
						c4f6c56c28729608780780f466400cd6f.c998544bee641bc3a66b600fbd8bc9fe2(entity2.gameObject);
						m_titleList.Remove(titleInfo.m_markedInfo.m_entity_id);
					}
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

	public bool cbab2dad8aaf1583a05752c4116f9b8c4(Entity c6e853f452cc819532893b63942b8ed3d)
	{
		bool result = false;
		int key = c6e853f452cc819532893b63942b8ed3d.cc7403315505256d19a7b92aa614a8f10();
		TitleInfo value;
		if (m_titleList.TryGetValue(key, out value))
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
			MarkManager.BroadcastMarkedInfo markedInfo = value.m_markedInfo;
			result = markedInfo.m_mark_level > 0;
		}
		return result;
	}

	public List<Entity> c435356281ba1e3f425fbeeb2da333da7()
	{
		m_temp_marked_list.Clear();
		Dictionary<int, TitleInfo>.Enumerator enumerator = m_titleList.GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (enumerator.Current.Value.m_markedInfo.m_mark_level <= 0)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_temp_marked_list.Add(enumerator.Current.Value.m_markedInfo.c66b232dbebded7c7e9a89c1e8bd84689());
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			return m_temp_marked_list;
		}
	}

	public bool c95cd2eaf57f155c93fb4b927b52ca60e(Entity ce4a0d48c7734206432c9cc9470156e6f)
	{
		EntityPlayer entityPlayer = ce4a0d48c7734206432c9cc9470156e6f as EntityPlayer;
		int result;
		if (entityPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			result = (entityPlayer.cd95354b53e674ec7dc9594e66e4d316f().c16d1154aec91a0f8f4a52d77fc081194() ? 1 : 0);
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}
}
