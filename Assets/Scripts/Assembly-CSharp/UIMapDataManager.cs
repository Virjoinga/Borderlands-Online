using System;
using System.Collections.Generic;
using System.Linq;
using A;
using UnityEngine;
using XsdSettings;

public class UIMapDataManager : IGroupServiceNotificationListerner, IMailServiceNotificationListener, IDamageListener
{
	public class UIMapObject
	{
		public MapObjectMark objInfo;

		public Vector2 v2LocalPosInProportion = new Vector2(0f, 0f);

		public NpcTitleMgr.NPC_ICON_TYPE npcIconType;

		public float fOnFireTime;

		public bool bIsOnFire;

		public bool bIsDead;

		public int iUnreadMailCnt;
	}

	public interface MinimapNotificationListener
	{
		void OnAddNewMapObject(UIMapObject tarObj);

		void OnRemoveMapObject(UIMapObject tarObj);

		void OnMapObjectUpdate(UIMapObject tarObj);

		void OnSwitchMapTexture(int iNewIdx);

		void OnMapSetup();
	}

	public enum MiniMapObjectType
	{
		None = 0,
		NPC = 1,
		TeamMate = 2,
		Enemy = 3,
		EnemyPlayer = 4,
		Boss = 5,
		Badass = 6,
		TownExit = 7,
		WorldMapDevice = 8,
		Trigger = 9,
		InstanceExitOpen = 10,
		InstanceExitClose = 11
	}

	public enum MinimapStatus
	{
		Loading = 0,
		Normal = 1,
		LoadConfigFailure = 2,
		LocalCoordinateSetupFailed = 3
	}

	public class MapContext
	{
		public MiniMapConfig curMiniMapConfig;

		public Vector2 v2DisplayAreaLocalSize;

		public Vector2 v2PlayerPosInProportion;

		public string strInstanceName;

		public int iMapIndex;

		public int iMapSubPartCnt;

		public float fPlayerDirAngle;

		public bool bIsPVP;

		public Texture2D defaultTexture;
	}

	protected static UIMapDataManager _instance;

	protected MapContext _curMapContext = new MapContext();

	protected Vector3 _v3DisplayAreaWorldSize = new Vector3(0f, 0f, 0f);

	protected Vector3 _v3RelativeOriginPt = new Vector3(0f, 0f, 0f);

	protected Rect _rectDisplayArea = new Rect(0f, 0f, 1f, 1f);

	protected PlayerInfoSync _localPlayer;

	protected Dictionary<int, UIMapObject> _dicOnStageObjects = new Dictionary<int, UIMapObject>();

	protected Dictionary<int, MapObjectMark> _mapObjCache = new Dictionary<int, MapObjectMark>();

	protected List<int> _teamMateIdList = new List<int>();

	protected List<UIMapObject> _onFiredEnemyList = new List<UIMapObject>();

	protected List<MinimapNotificationListener> _listeners = new List<MinimapNotificationListener>();

	protected float _fOffsetAngle;

	public MinimapStatus _curStatus;

	protected bool _bConfigLoaded;

	protected bool _bLocalCoordinateSetuped;

	public MapContext c30723ad1ed00b021a57cce509d64f2a6
	{
		get
		{
			return _curMapContext;
		}
	}

	protected UIMapDataManager()
	{
	}

	public static UIMapDataManager c71f6ce28731edfd43c976fbd57c57bea()
	{
		if (_instance == null)
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
			_instance = new UIMapDataManager();
		}
		return _instance;
	}

	public void ccc9d3a38966dc10fedb531ea17d24611()
	{
		GameObject gameObject = GameObject.Find("PRE_MiniMap");
		if (gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					_curMapContext = new MapContext();
					_curMapContext.curMiniMapConfig = gameObject.GetComponent<MiniMapConfig>();
					if (_curMapContext.curMiniMapConfig != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
					{
						while (true)
						{
							switch (7)
							{
							case 0:
								break;
							default:
							{
								Vector2 to = new Vector3(0f, 0f);
								to.x = _curMapContext.curMiniMapConfig.NormalInWorldView.x;
								to.y = _curMapContext.curMiniMapConfig.NormalInWorldView.z;
								Vector2 from = new Vector2(0f, 1f);
								float num = to.x * from.y - to.y * from.x;
								_fOffsetAngle = Vector2.Angle(from, to);
								if (num < 0f)
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
									_fOffsetAngle = 360f - _fOffsetAngle;
								}
								_curMapContext.curMiniMapConfig.RectEndPoint = Quaternion.Euler(0f, _fOffsetAngle, 0f) * _curMapContext.curMiniMapConfig.RectEndPoint;
								_curMapContext.curMiniMapConfig.RectOriginPoint = Quaternion.Euler(0f, _fOffsetAngle, 0f) * _curMapContext.curMiniMapConfig.RectOriginPoint;
								_v3DisplayAreaWorldSize.x = Math.Abs(_curMapContext.curMiniMapConfig.RectEndPoint.x - _curMapContext.curMiniMapConfig.RectOriginPoint.x);
								_v3DisplayAreaWorldSize.z = Math.Abs(_curMapContext.curMiniMapConfig.RectEndPoint.z - _curMapContext.curMiniMapConfig.RectOriginPoint.z);
								_curMapContext.v2DisplayAreaLocalSize.x = _v3DisplayAreaWorldSize.x;
								_curMapContext.v2DisplayAreaLocalSize.y = _v3DisplayAreaWorldSize.z;
								if (_curMapContext.curMiniMapConfig.MiniMapTexture != null)
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
									if (_curMapContext.curMiniMapConfig.MiniMapTexture.Length > 0)
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
										_curMapContext.defaultTexture = _curMapContext.curMiniMapConfig.MiniMapTexture[0].texture;
									}
								}
								c1ee7921b0c3cce194fb7cae41b5a9d82<GroupServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c28e7fb4a7d03eef0acca90b1bd76a2c9(this);
								GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c39867fdd7ae4787e9572c6b3b3f71e11(c851e95fc9c3ea103f94f6cc044c9cb56);
								for (int i = 0; i < GroupManager.c71f6ce28731edfd43c976fbd57c57bea().m_GroupInfoMap.Count; i++)
								{
									cd8cfe3489eaecb0c57e98bc004f4a785(GroupManager.c71f6ce28731edfd43c976fbd57c57bea().m_GroupInfoMap.ElementAt(i).Value.mCharacterId);
								}
								while (true)
								{
									switch (5)
									{
									case 0:
										break;
									default:
									{
										if (DamageManager.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
											DamageManager.c5ee19dc8d4cccf5ae2de225410458b86.c5c5b57d23b5b73637a6ed6524fed2be5(this);
										}
										QuestUIDataManager.c71f6ce28731edfd43c976fbd57c57bea().cd35ec9bc0560c63369b10ad39d5c179b(cb6d7fbe7459855c2a680f39974d15413);
										QuestUIDataManager.c71f6ce28731edfd43c976fbd57c57bea().c7805303703b83f4ce9498430b0a1527b();
										c1ee7921b0c3cce194fb7cae41b5a9d82<MailServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c523e4a3a3feaf78d0e1c44cb5f113f7c(this);
										c79016cf7efb60d4496015dea2d973d30();
										_curMapContext.strInstanceName = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c9d8ee6a5af1e2ca6cb9e7b7a609a6d69();
										_curMapContext.iMapIndex = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.cdbdfc7767749324b8b1cdac1ae6b9f5b();
										_curMapContext.bIsPVP = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c28b45877056e09d3c4d6fa790a1517aa();
										Playlist playlist = MatchmakingService.c5ee19dc8d4cccf5ae2de225410458b86.c2718b579e09549a1cd47620188a40a38(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_playlistId);
										if (playlist != null)
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
											_curMapContext.iMapSubPartCnt = playlist.m_sceneToPlay.Length;
										}
										_bConfigLoaded = true;
										if (_bLocalCoordinateSetuped)
										{
											while (true)
											{
												switch (6)
												{
												case 0:
													break;
												default:
													_curStatus = MinimapStatus.Normal;
													c9e7b43a5c88bb3052f96a75777c69885();
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
					}
					return;
				}
			}
		}
		_curStatus = MinimapStatus.LoadConfigFailure;
	}

	public void cac7688b05e921e2be3f92479ba44b4a8()
	{
		_bConfigLoaded = false;
		_bLocalCoordinateSetuped = false;
		_curStatus = MinimapStatus.Loading;
		_teamMateIdList.Clear();
		_curMapContext = null;
		_dicOnStageObjects.Clear();
		_onFiredEnemyList.Clear();
		_listeners.Clear();
		_mapObjCache.Clear();
		c1ee7921b0c3cce194fb7cae41b5a9d82<GroupServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c704834a4a19f1f8555b44d9c021845ab(this);
		GroupManager.c71f6ce28731edfd43c976fbd57c57bea().c30bfa60542449d4304af71ccef259137(c851e95fc9c3ea103f94f6cc044c9cb56);
		c1ee7921b0c3cce194fb7cae41b5a9d82<MailServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c92508dc6911d2386ea0db5b2e4a3f935(this);
		if (!(DamageManager.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			DamageManager.c5ee19dc8d4cccf5ae2de225410458b86.c67b40caae87a37a992e8004e2229b0eb(this);
			return;
		}
	}

	protected void ca244a42d98f0300c59a4cb1bb7b4277f()
	{
		if (!(_localPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (!(_localPlayer.c66b232dbebded7c7e9a89c1e8bd84689() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				GameObject gameObject = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
				float num = -1f;
				Entity entity = _localPlayer.c66b232dbebded7c7e9a89c1e8bd84689();
				WorldCenter[] array = UnityEngine.Object.FindObjectsOfType<WorldCenter>();
				foreach (WorldCenter worldCenter in array)
				{
					float magnitude = (worldCenter.transform.position - entity.c06a97336d66561bdcc24dede6e251a09().position).magnitude;
					if (!(num > magnitude))
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
						if (!(num < 0f))
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
					}
					num = magnitude;
					gameObject = worldCenter.gameObject;
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					if (gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						_v3RelativeOriginPt = gameObject.transform.position;
					}
					_bLocalCoordinateSetuped = true;
					if (!_bConfigLoaded)
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
						if (_curStatus != 0)
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
							_curStatus = MinimapStatus.Normal;
							c9e7b43a5c88bb3052f96a75777c69885();
							return;
						}
					}
				}
			}
		}
	}

	protected Vector2 c2610be0178961a3f4d3f9e825d4410ca(Vector3 c5f8971f122d566c60ee0344fcdab2bc4)
	{
		Vector2 result = new Vector2(0f, 0f);
		Vector3 vector = c5f8971f122d566c60ee0344fcdab2bc4 - _v3RelativeOriginPt;
		Vector3 vector2 = Quaternion.Euler(0f, _fOffsetAngle, 0f) * vector;
		if (_curMapContext != null)
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
			if (_curMapContext.curMiniMapConfig != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				result.x = Math.Abs(vector2.x - _curMapContext.curMiniMapConfig.RectOriginPoint.x) / _v3DisplayAreaWorldSize.x;
				result.y = Math.Abs(vector2.z - _curMapContext.curMiniMapConfig.RectOriginPoint.z) / _v3DisplayAreaWorldSize.z;
			}
		}
		return result;
	}

	protected void c9e7b43a5c88bb3052f96a75777c69885()
	{
		using (List<MinimapNotificationListener>.Enumerator enumerator = _listeners.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				MinimapNotificationListener current = enumerator.Current;
				current.OnMapSetup();
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
				break;
			}
		}
		ca46e78b20f8cc7452e88ced857937f39();
	}

	public void c19f5df9af6cc9db5bc7552a87f70f49b(int c6fda324f523de0ba05699947dd5ab64c)
	{
		if (!(_curMapContext.curMiniMapConfig != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (_curMapContext.curMiniMapConfig.MiniMapTexture == null)
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
				if (_curMapContext.curMiniMapConfig.MiniMapTexture.Length <= c6fda324f523de0ba05699947dd5ab64c)
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
					c10211712bca3b08bece94a6257b441d2(c6fda324f523de0ba05699947dd5ab64c);
					return;
				}
			}
		}
	}

	protected void cb6d7fbe7459855c2a680f39974d15413(Dictionary<int, QuestProgress> cd563a3564d781de51750031f869a03aa)
	{
		using (Dictionary<int, UIMapObject>.ValueCollection.Enumerator enumerator = _dicOnStageObjects.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				UIMapObject current = enumerator.Current;
				if (current.objInfo.ObjType != MiniMapObjectType.NPC)
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
				NpcTitleMgr.NPC_ICON_TYPE nPC_ICON_TYPE = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_NONE;
				if (c06ca0e618478c23eba3419653a19760f<TownNpcManager>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					nPC_ICON_TYPE = c06ca0e618478c23eba3419653a19760f<TownNpcManager>.c5ee19dc8d4cccf5ae2de225410458b86.c4853bb633cd73a41e5f8cedf7e0668ae(current.objInfo.iNPCID);
				}
				if (nPC_ICON_TYPE == current.npcIconType)
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
				current.npcIconType = nPC_ICON_TYPE;
				c8a6927ee7da6dc6146d1faf51a079c2c(current);
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
	}

	public void Update()
	{
		_localPlayer = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56();
		if (_curStatus == MinimapStatus.Loading)
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
			if (!_bLocalCoordinateSetuped)
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
				ca244a42d98f0300c59a4cb1bb7b4277f();
			}
		}
		if (_curStatus != MinimapStatus.Normal)
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
			if (_curMapContext == null)
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
				if (_curMapContext.curMiniMapConfig == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (_localPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					if (_localPlayer.c66b232dbebded7c7e9a89c1e8bd84689() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						cb8e0a5924a426fa72ae41e8004f6d66c();
						cd010441b1a1eea7eb3c8b889e349fbdd();
						c9d2d9dfad8f2b9aa8f2832f52211200d();
					}
				}
				if (!_curMapContext.bIsPVP)
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
					int num = 0;
					while (num < _onFiredEnemyList.Count)
					{
						_onFiredEnemyList[num].fOnFireTime += Time.deltaTime;
						if (_onFiredEnemyList[num].fOnFireTime > 5f)
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
							_onFiredEnemyList[num].bIsOnFire = false;
							c8a6927ee7da6dc6146d1faf51a079c2c(_onFiredEnemyList[num]);
							_onFiredEnemyList.RemoveAt(num);
						}
						else
						{
							num++;
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
			}
		}
	}

	protected void cb8e0a5924a426fa72ae41e8004f6d66c()
	{
		Vector3 c5f8971f122d566c60ee0344fcdab2bc = _localPlayer.c66b232dbebded7c7e9a89c1e8bd84689().c4cf00ced2bc60ae908904eb73692869f();
		if (!_curMapContext.curMiniMapConfig)
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
			_curMapContext.v2PlayerPosInProportion = c2610be0178961a3f4d3f9e825d4410ca(c5f8971f122d566c60ee0344fcdab2bc);
			return;
		}
	}

	protected virtual void cd010441b1a1eea7eb3c8b889e349fbdd()
	{
		Vector3 vector = _localPlayer.c66b232dbebded7c7e9a89c1e8bd84689().c56fad5727ffebf48f3df62074cd1bbe6();
		Vector2 to = new Vector2(vector.x, vector.z);
		Vector2 from = new Vector2(0f, 1f);
		float num = Vector2.Angle(from, to);
		float num2 = to.x * from.y - to.y * from.x;
		if (num2 < 0f)
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
			num = 360f - num;
		}
		num -= _fOffsetAngle;
		_curMapContext.fPlayerDirAngle = num;
	}

	protected virtual void c9d2d9dfad8f2b9aa8f2832f52211200d()
	{
		Dictionary<int, UIMapObject>.Enumerator enumerator = _dicOnStageObjects.GetEnumerator();
		while (enumerator.MoveNext())
		{
			UIMapObject value = enumerator.Current.Value;
			if (value == null)
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
			}
			else if (value.objInfo == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			else if (value.objInfo.gameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				value.v2LocalPosInProportion = c2610be0178961a3f4d3f9e825d4410ca(value.objInfo.gameObject.transform.position);
			}
		}
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

	public void OnDamaged(DamageContext damageContext)
	{
		if (_curMapContext == null)
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
		if (!_curMapContext.bIsPVP)
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
			if (!(damageContext.m_victim != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (!(_localPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					if (!(damageContext.m_killer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
						PlayerInfoSync playerInfoSync = damageContext.m_killer.cd95354b53e674ec7dc9594e66e4d316f();
						PlayerInfoSync playerInfoSync2 = damageContext.m_victim.cd95354b53e674ec7dc9594e66e4d316f();
						if (!(playerInfoSync != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
							if (!(playerInfoSync2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
								if (playerInfoSync.m_teamID != _localPlayer.m_teamID)
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
									Dictionary<int, UIMapObject>.Enumerator enumerator = _dicOnStageObjects.GetEnumerator();
									while (enumerator.MoveNext())
									{
										UIMapObject value = enumerator.Current.Value;
										if (value == null)
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
										if (value.objInfo == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
										if (value.objInfo.ObjType != MiniMapObjectType.EnemyPlayer)
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
										if (value.objInfo.iCharacterID != playerInfoSync2.m_characterId)
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
										value.fOnFireTime = 0f;
										value.bIsOnFire = true;
										c8a6927ee7da6dc6146d1faf51a079c2c(value);
										if (_onFiredEnemyList == null)
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
											continue;
										}
										if (_onFiredEnemyList.Contains(value))
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
										_onFiredEnemyList.Add(value);
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
							}
						}
					}
				}
			}
		}
	}

	public virtual void OnEntityKill(KillContext killContext)
	{
		if (killContext.m_victim == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (killContext.m_victim.c6420f67f9249b1d533531d9f351a36e0() == Entity.EntityType.Npc)
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
			MapObjectMark component = killContext.m_victim.GetComponent<MapObjectMark>();
			if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				UnityEngine.Object.Destroy(component);
			}
		}
		if (!_curMapContext.bIsPVP)
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
			if (!(killContext.m_victim != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (!(_localPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					if (!(killContext.m_killer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
						if (!(killContext.m_killer.cd95354b53e674ec7dc9594e66e4d316f() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
							if (!(killContext.m_victim.cd95354b53e674ec7dc9594e66e4d316f() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
								if (killContext.m_killer.cd95354b53e674ec7dc9594e66e4d316f().m_teamID != _localPlayer.m_teamID)
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
									if (killContext.m_victim.cd95354b53e674ec7dc9594e66e4d316f().m_teamID != _localPlayer.m_teamID)
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
										if (killContext.m_killer.cd95354b53e674ec7dc9594e66e4d316f().m_characterId != _localPlayer.m_characterId)
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
											break;
										}
									}
								}
								using (Dictionary<int, UIMapObject>.ValueCollection.Enumerator enumerator = _dicOnStageObjects.Values.GetEnumerator())
								{
									while (enumerator.MoveNext())
									{
										UIMapObject current = enumerator.Current;
										if (current.objInfo.ObjType != MiniMapObjectType.EnemyPlayer)
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
											if (current.objInfo.ObjType != MiniMapObjectType.TeamMate)
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
										}
										if (current.objInfo.iCharacterID != killContext.m_victim.cd95354b53e674ec7dc9594e66e4d316f().m_characterId)
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
										current.fOnFireTime = 0f;
										current.bIsOnFire = false;
										current.bIsDead = true;
										c8a6927ee7da6dc6146d1faf51a079c2c(current);
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
							}
						}
					}
				}
			}
		}
	}

	public void OnPlayerRevive(EntityPlayer revivedPlayer)
	{
		if (!(revivedPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			using (Dictionary<int, UIMapObject>.ValueCollection.Enumerator enumerator = _dicOnStageObjects.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					UIMapObject current = enumerator.Current;
					if (current.objInfo.ObjType != MiniMapObjectType.EnemyPlayer)
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
						if (current.objInfo.ObjType != MiniMapObjectType.TeamMate)
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
					}
					if (current.objInfo.iCharacterID != revivedPlayer.cd95354b53e674ec7dc9594e66e4d316f().m_characterId)
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
					current.bIsDead = false;
					c8a6927ee7da6dc6146d1faf51a079c2c(current);
				}
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
		}
	}

	protected void c851e95fc9c3ea103f94f6cc044c9cb56(int cc0bd81365a67b7881767838c0d2634ba, List<Presence> c72e4ada3dec90a66a68989a85ec6c74b)
	{
		ce9ffd3fea209ca0a129223d1bf90a2de();
		for (int i = 0; i < c72e4ada3dec90a66a68989a85ec6c74b.Count; i++)
		{
			cd8cfe3489eaecb0c57e98bc004f4a785(c72e4ada3dec90a66a68989a85ec6c74b[i].mCharacterId);
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
			return;
		}
	}

	public void OnGroupMatchmakingStarted()
	{
	}

	public void OnReceivedGroupInvitation(int senderCharacterId, int groupId, int messageId)
	{
	}

	public void OnKickedFromGroup()
	{
		using (List<int>.Enumerator enumerator = _teamMateIdList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				int current = enumerator.Current;
				c71ab5073460b9eb1d41f8bf18a5d690a(current);
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
		_teamMateIdList.Clear();
	}

	public void OnNewGroupLeader(int characterId)
	{
	}

	public void OnNewGroupMember(Presence characterinfo)
	{
		if (!(_localPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (characterinfo == null)
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
				if (characterinfo.mCharacterId == _localPlayer.m_characterId)
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
					cd8cfe3489eaecb0c57e98bc004f4a785(characterinfo.mCharacterId);
					return;
				}
			}
		}
	}

	public void OnGroupInviteRejected(int characterId)
	{
	}

	public void OnGroupMemberLeft(int characterId)
	{
		c71ab5073460b9eb1d41f8bf18a5d690a(characterId);
	}

	public void OnGroupDisbanded()
	{
		using (List<int>.Enumerator enumerator = _teamMateIdList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				int current = enumerator.Current;
				c71ab5073460b9eb1d41f8bf18a5d690a(current);
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
				break;
			}
		}
		_teamMateIdList.Clear();
	}

	protected void c1c2fe0690cc1b78ac46d88b9c27642b9(UIMapObject c16aba375ba545d585c3f1dc60c72a9dd)
	{
		using (List<MinimapNotificationListener>.Enumerator enumerator = _listeners.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				MinimapNotificationListener current = enumerator.Current;
				current.OnAddNewMapObject(c16aba375ba545d585c3f1dc60c72a9dd);
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
				return;
			}
		}
	}

	protected void c8ff7b3e6c803603fafe3933347e4873f(UIMapObject c16aba375ba545d585c3f1dc60c72a9dd)
	{
		using (List<MinimapNotificationListener>.Enumerator enumerator = _listeners.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				MinimapNotificationListener current = enumerator.Current;
				current.OnRemoveMapObject(c16aba375ba545d585c3f1dc60c72a9dd);
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
				return;
			}
		}
	}

	protected void c8a6927ee7da6dc6146d1faf51a079c2c(UIMapObject c16aba375ba545d585c3f1dc60c72a9dd)
	{
		using (List<MinimapNotificationListener>.Enumerator enumerator = _listeners.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				MinimapNotificationListener current = enumerator.Current;
				current.OnMapObjectUpdate(c16aba375ba545d585c3f1dc60c72a9dd);
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
				return;
			}
		}
	}

	protected void c10211712bca3b08bece94a6257b441d2(int c10d88007dbdb1ace882e672f52e555bf)
	{
		using (List<MinimapNotificationListener>.Enumerator enumerator = _listeners.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				MinimapNotificationListener current = enumerator.Current;
				current.OnSwitchMapTexture(c10d88007dbdb1ace882e672f52e555bf);
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
				return;
			}
		}
	}

	public void cc7c09df5a4a467ee40cdda5047fd18d0(MinimapNotificationListener c472a3b7c9dbd0d177f87c4386db7570d)
	{
		_listeners.Add(c472a3b7c9dbd0d177f87c4386db7570d);
	}

	public void cd178f4fb7e34eae260792cefd4140db9(MinimapNotificationListener c472a3b7c9dbd0d177f87c4386db7570d)
	{
		_listeners.Remove(c472a3b7c9dbd0d177f87c4386db7570d);
	}

	public Dictionary<int, UIMapObject> c793a8b137ecffd2d0bcd165376f788ba()
	{
		return _dicOnStageObjects;
	}

	public void OnGetNewMail(MailInfo newmail)
	{
		c79016cf7efb60d4496015dea2d973d30();
	}

	public void OnGetMailList(List<MailInfo> mailList)
	{
		c79016cf7efb60d4496015dea2d973d30();
	}

	public void OnSendMail(bool bIsSuccessful)
	{
		c79016cf7efb60d4496015dea2d973d30();
	}

	public void OnReadMail(int mailID)
	{
		c79016cf7efb60d4496015dea2d973d30();
	}

	public void OnDeleteMail(int mailID)
	{
		c79016cf7efb60d4496015dea2d973d30();
	}

	public void OnGetmailItem(short result, int mailID)
	{
		c79016cf7efb60d4496015dea2d973d30();
	}

	protected void c79016cf7efb60d4496015dea2d973d30()
	{
		using (Dictionary<int, UIMapObject>.ValueCollection.Enumerator enumerator = _dicOnStageObjects.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				UIMapObject current = enumerator.Current;
				if (current.objInfo.ObjType != MiniMapObjectType.NPC)
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
				if (!c06ca0e618478c23eba3419653a19760f<TownNpcManager>.c5ee19dc8d4cccf5ae2de225410458b86)
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
				NpcTitleMgr.NPC_ICON_TYPE nPC_ICON_TYPE = c06ca0e618478c23eba3419653a19760f<TownNpcManager>.c5ee19dc8d4cccf5ae2de225410458b86.c4853bb633cd73a41e5f8cedf7e0668ae(current.objInfo.iNPCID);
				if (nPC_ICON_TYPE != NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_MAIL)
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
					if (nPC_ICON_TYPE != NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_MAIL_NEW)
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
				}
				current.iUnreadMailCnt = c1ee7921b0c3cce194fb7cae41b5a9d82<MailServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c7115852a11d7d7b2222deb4caf2937ed();
				current.npcIconType = nPC_ICON_TYPE;
				c8a6927ee7da6dc6146d1faf51a079c2c(current);
			}
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
	}

	public void c0be9d40053ea381c1b1ba87562fdd043(MapObjectMark c16aba375ba545d585c3f1dc60c72a9dd)
	{
		if (_curStatus == MinimapStatus.Loading)
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
					_mapObjCache.Add(c16aba375ba545d585c3f1dc60c72a9dd.GetInstanceID(), c16aba375ba545d585c3f1dc60c72a9dd);
					return;
				}
			}
		}
		if (_curStatus != MinimapStatus.Normal)
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
			if (!c738babc79889bd2bd1dc93446b0b4865(c16aba375ba545d585c3f1dc60c72a9dd))
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
				if (c16aba375ba545d585c3f1dc60c72a9dd.ObjType == MiniMapObjectType.None)
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
					UIMapObject uIMapObject = new UIMapObject();
					uIMapObject.objInfo = c16aba375ba545d585c3f1dc60c72a9dd;
					uIMapObject.v2LocalPosInProportion = c2610be0178961a3f4d3f9e825d4410ca(c16aba375ba545d585c3f1dc60c72a9dd.gameObject.transform.position);
					_dicOnStageObjects.Add(c16aba375ba545d585c3f1dc60c72a9dd.GetInstanceID(), uIMapObject);
					if (c16aba375ba545d585c3f1dc60c72a9dd.ObjType == MiniMapObjectType.NPC)
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
						if (c06ca0e618478c23eba3419653a19760f<TownNpcManager>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							uIMapObject.npcIconType = c06ca0e618478c23eba3419653a19760f<TownNpcManager>.c5ee19dc8d4cccf5ae2de225410458b86.c4853bb633cd73a41e5f8cedf7e0668ae(c16aba375ba545d585c3f1dc60c72a9dd.iNPCID);
						}
					}
					c1c2fe0690cc1b78ac46d88b9c27642b9(uIMapObject);
					return;
				}
			}
		}
	}

	protected bool c738babc79889bd2bd1dc93446b0b4865(MapObjectMark c16aba375ba545d585c3f1dc60c72a9dd)
	{
		Vector2 point = c2610be0178961a3f4d3f9e825d4410ca(c16aba375ba545d585c3f1dc60c72a9dd.gameObject.transform.position);
		return _rectDisplayArea.Contains(point);
	}

	protected void ca46e78b20f8cc7452e88ced857937f39()
	{
		List<MapObjectMark> list = new List<MapObjectMark>();
		using (Dictionary<int, MapObjectMark>.ValueCollection.Enumerator enumerator = _mapObjCache.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				MapObjectMark current = enumerator.Current;
				list.Add(current);
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
				break;
			}
		}
		_mapObjCache.Clear();
		using (List<MapObjectMark>.Enumerator enumerator2 = list.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				MapObjectMark current2 = enumerator2.Current;
				c0be9d40053ea381c1b1ba87562fdd043(current2);
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					goto end_IL_008d;
				}
				continue;
				end_IL_008d:
				break;
			}
		}
		list.Clear();
	}

	public void cd327ead52a5b512b3dd6af488e444c9d(MapObjectMark c16aba375ba545d585c3f1dc60c72a9dd)
	{
		if (_curStatus == MinimapStatus.Normal)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					UIMapObject value = null;
					_dicOnStageObjects.TryGetValue(c16aba375ba545d585c3f1dc60c72a9dd.GetInstanceID(), out value);
					if (value != null)
					{
						while (true)
						{
							switch (3)
							{
							case 0:
								break;
							default:
								_dicOnStageObjects.Remove(c16aba375ba545d585c3f1dc60c72a9dd.GetInstanceID());
								if (_bConfigLoaded)
								{
									while (true)
									{
										switch (3)
										{
										case 0:
											break;
										default:
											c8ff7b3e6c803603fafe3933347e4873f(value);
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
		if (_curStatus != 0)
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
			if (!_mapObjCache.ContainsKey(c16aba375ba545d585c3f1dc60c72a9dd.GetInstanceID()))
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
				_mapObjCache.Remove(c16aba375ba545d585c3f1dc60c72a9dd.GetInstanceID());
				return;
			}
		}
	}

	protected void cd8cfe3489eaecb0c57e98bc004f4a785(int cf3ee56112c62330da43ddb0ed509ddf4)
	{
		if (!_bConfigLoaded)
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
			if (_localPlayer == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (cf3ee56112c62330da43ddb0ed509ddf4 == -1)
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
				if (cf3ee56112c62330da43ddb0ed509ddf4 == _localPlayer.m_characterId)
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
					if (_teamMateIdList.Contains(cf3ee56112c62330da43ddb0ed509ddf4))
					{
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
					PlayerInfoSync playerInfoSync = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c28296aaabdb7ddfba47ef5559c1df883(cf3ee56112c62330da43ddb0ed509ddf4);
					if (playerInfoSync == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						if (playerInfoSync.c66b232dbebded7c7e9a89c1e8bd84689() == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						GameObject gameObject = playerInfoSync.c66b232dbebded7c7e9a89c1e8bd84689().gameObject;
						if (!(gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
							MapObjectMark component = gameObject.GetComponent<MapObjectMark>();
							if (component == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
							{
								while (true)
								{
									switch (2)
									{
									case 0:
										break;
									default:
									{
										MapObjectMark mapObjectMark = playerInfoSync.c66b232dbebded7c7e9a89c1e8bd84689().gameObject.AddComponent<MapObjectMark>();
										mapObjectMark.ObjType = MiniMapObjectType.TeamMate;
										mapObjectMark.bAlwaysOnMap = true;
										mapObjectMark.cd26ab2539c05dcb4fe11c30d0792cfaf();
										_teamMateIdList.Add(cf3ee56112c62330da43ddb0ed509ddf4);
										return;
									}
									}
								}
							}
							if (component.ObjType == MiniMapObjectType.EnemyPlayer)
							{
								while (true)
								{
									switch (4)
									{
									case 0:
										break;
									default:
									{
										component.ObjType = MiniMapObjectType.TeamMate;
										UIMapObject value = null;
										if (_dicOnStageObjects.TryGetValue(component.GetInstanceID(), out value))
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
											c8a6927ee7da6dc6146d1faf51a079c2c(value);
										}
										_teamMateIdList.Add(cf3ee56112c62330da43ddb0ed509ddf4);
										return;
									}
									}
								}
							}
							if (component.ObjType != MiniMapObjectType.TeamMate)
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
								component.cd26ab2539c05dcb4fe11c30d0792cfaf();
								_teamMateIdList.Add(cf3ee56112c62330da43ddb0ed509ddf4);
								return;
							}
						}
					}
				}
			}
		}
	}

	protected void c71ab5073460b9eb1d41f8bf18a5d690a(int cf3ee56112c62330da43ddb0ed509ddf4)
	{
		if (!_bConfigLoaded)
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
		if (!_teamMateIdList.Contains(cf3ee56112c62330da43ddb0ed509ddf4))
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
			PlayerInfoSync playerInfoSync = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c28296aaabdb7ddfba47ef5559c1df883(cf3ee56112c62330da43ddb0ed509ddf4);
			if (!(playerInfoSync != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (!(playerInfoSync.c66b232dbebded7c7e9a89c1e8bd84689() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					MapObjectMark component = playerInfoSync.c66b232dbebded7c7e9a89c1e8bd84689().gameObject.GetComponent<MapObjectMark>();
					if (!(component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
						UnityEngine.Object.Destroy(component);
						return;
					}
				}
			}
		}
	}

	protected void ce9ffd3fea209ca0a129223d1bf90a2de()
	{
		if (!_bConfigLoaded)
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
		using (List<int>.Enumerator enumerator = _teamMateIdList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				int current = enumerator.Current;
				c71ab5073460b9eb1d41f8bf18a5d690a(current);
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					goto end_IL_0048;
				}
				continue;
				end_IL_0048:
				break;
			}
		}
		_teamMateIdList.Clear();
	}
}
