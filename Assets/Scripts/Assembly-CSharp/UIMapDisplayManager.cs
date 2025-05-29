using System;
using System.Collections.Generic;
using System.Text;
using A;
using UnityEngine;
using pumpkin.display;
using pumpkin.events;
using pumpkin.geom;
using pumpkin.text;

public class UIMapDisplayManager
{
	public enum MapCategoryTag
	{
		Common = 0,
		MiniMap = 1,
		LargeMap = 2,
		PVPMap = 3
	}

	public class UIMapRoot : c196099a1254db61d3be10d70e14e7422
	{
		protected c7beefc397f483dc0b72dcd3e6bdcf929 _mapPanel;

		protected MapObject _player;

		protected MovieClip _mcIconTemplate;

		protected MovieClip _mcIconContainer;

		protected MovieClip _mcDragArea;

		protected TextField _textMapName;

		protected List<MapIcon> _mapIconPool = new List<MapIcon>();

		protected Dictionary<int, MapIcon> _onShowMapIconDic = new Dictionary<int, MapIcon>();

		protected Texture _mapTex;

		protected float _fScale = 1f;

		protected float _fOffsetX;

		protected float _fOffsetY;

		protected float _fLastFrameMousePosX;

		protected float _fLastFrameMousePosY;

		protected bool _bDragable;

		protected bool _bNeedAdjust;

		protected bool _bNeedUpdateViewPort;

		protected bool _bVerticalDragAble;

		protected bool _bHorizontalDragAble;

		protected bool _bVisible = true;

		protected Vector2 _v2WorldSize = new Vector2(0f, 0f);

		protected Vector2 _v2PlayerPos = new Vector2(0f, 0f);

		protected Vector2 _v2MapRectMCSize = new Vector2(0f, 0f);

		protected Rect _onShowRectInTex = new Rect(0f, 0f, 1f, 1f);

		protected Rect _onShowRectInViewPort = new Rect(0f, 0f, 1f, 1f);

		protected MapCategoryTag _categoryTag;

		public bool c729bd42662457ecf184ce15af0942cbe
		{
			set
			{
				_bDragable = value;
			}
		}

		public bool cd61d9f244ef37bfca642c090f0dd57af
		{
			set
			{
				_bNeedAdjust = value;
			}
		}

		public Vector2 cf0471c63448d3685ac44fe425bcc3c6e
		{
			set
			{
				_v2WorldSize = value;
			}
		}

		public float c2b8fb615324c416fbab0b55f12a92dce
		{
			set
			{
				_fScale = value / _fScale;
			}
		}

		public MapCategoryTag c4ff0d4ba3eeaed831ca975de7848acce
		{
			get
			{
				return _categoryTag;
			}
			set
			{
				_categoryTag = value;
			}
		}

		public Texture c94b817daf954df0906d9a038fd06d320
		{
			set
			{
				_mapTex = value;
				if (!_bDragable)
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
					if (!(_mapTex != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
						if (!_bNeedAdjust)
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
							_onShowRectInViewPort.x = (_v2MapRectMCSize.x - (float)_mapTex.width) / 2f;
							_onShowRectInViewPort.y = (_v2MapRectMCSize.y - (float)_mapTex.height) / 2f;
							_onShowRectInViewPort.height = _mapTex.height;
							_onShowRectInViewPort.width = _mapTex.width;
							_bHorizontalDragAble = _mapTex.width > Screen.width;
							_bVerticalDragAble = _mapTex.height > Screen.height;
						}
						else
						{
							float num = _v2MapRectMCSize.x / _v2MapRectMCSize.y;
							float num2 = (float)_mapTex.width / (float)_mapTex.height;
							if (num > num2)
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
								_onShowRectInViewPort.height = _v2MapRectMCSize.y;
								_onShowRectInViewPort.width = _v2MapRectMCSize.y * num2;
								_onShowRectInViewPort.y = 0f;
								_onShowRectInViewPort.x = (_v2MapRectMCSize.x - _onShowRectInViewPort.width) / 2f;
								_fScale = _onShowRectInViewPort.height / (float)_mapTex.height;
							}
							else
							{
								_onShowRectInViewPort.width = _v2MapRectMCSize.x;
								_onShowRectInViewPort.height = _v2MapRectMCSize.x / num2;
								_onShowRectInViewPort.x = 0f;
								_onShowRectInViewPort.y = (_v2MapRectMCSize.y - _onShowRectInViewPort.height) / 2f;
								_fScale = _onShowRectInViewPort.width / (float)_mapTex.width;
							}
						}
						c0c935947a2ad338a7296e9d3c24b2ce0();
						return;
					}
				}
			}
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			MovieClip childByName = base.c89ef242f4744e0f1c4ffea4da8b79bc1.getChildByName<MovieClip>("mcMapRect");
			if (childByName != null)
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
				_mapPanel = new c7beefc397f483dc0b72dcd3e6bdcf929();
				_mapPanel.c130648b59a0c8debea60aa153f844879(childByName);
				_v2MapRectMCSize.x = childByName.width;
				_v2MapRectMCSize.y = childByName.height;
				_onShowRectInViewPort.width = childByName.width;
				_onShowRectInViewPort.height = childByName.height;
			}
			_mcIconTemplate = base.c89ef242f4744e0f1c4ffea4da8b79bc1.getChildByName<MovieClip>("mcIconCollection");
			MovieClip childByName2 = base.c89ef242f4744e0f1c4ffea4da8b79bc1.getChildByName<MovieClip>("mcPlayer");
			if (childByName2 != null)
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
				_player = new MapObject();
				_player.c130648b59a0c8debea60aa153f844879(childByName2);
			}
			_mcIconContainer = base.c89ef242f4744e0f1c4ffea4da8b79bc1.getChildByName<MovieClip>("mcIconContainer");
			_textMapName = base.c89ef242f4744e0f1c4ffea4da8b79bc1.getChildByName<TextField>("textInstanceName");
			_mcDragArea = base.c89ef242f4744e0f1c4ffea4da8b79bc1.getChildByName<MovieClip>("mcDragArea");
			if (_mcDragArea == null)
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
				_mcDragArea.addEventListener(MouseEvent.MOUSE_DOWN, c6c076d28a9046d110d5941592bf14ad0);
				_mcDragArea.addEventListener(MouseEvent.MOUSE_UP, c3baaed47ba1641317847c6810a78569a);
				return;
			}
		}

		protected void c6c076d28a9046d110d5941592bf14ad0(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			if (_mcDragArea == null)
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
				_mcDragArea.addEventListener(MouseEvent.MOUSE_MOVE, cce51b2bbe535cb55500728ada30f8f4e);
				_fLastFrameMousePosX = Input.mousePosition.x;
				_fLastFrameMousePosY = Input.mousePosition.y;
				return;
			}
		}

		protected void c3baaed47ba1641317847c6810a78569a(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			if (_mcDragArea == null)
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
				_mcDragArea.removeAllEventListeners(MouseEvent.MOUSE_MOVE);
				_fLastFrameMousePosX = 0f;
				_fLastFrameMousePosY = 0f;
				return;
			}
		}

		protected void cce51b2bbe535cb55500728ada30f8f4e(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			_bNeedUpdateViewPort = false;
			if (_bHorizontalDragAble)
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
				float num = Input.mousePosition.x - _fLastFrameMousePosX;
				float num2 = _onShowRectInViewPort.x + (_fOffsetX + num);
				float num3 = _onShowRectInViewPort.x + (_fOffsetX + num) + _onShowRectInViewPort.width;
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
					if (num3 > (float)Screen.width)
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
						_fOffsetX += num;
						_bNeedUpdateViewPort = true;
					}
				}
			}
			if (_bVerticalDragAble)
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
				float num4 = Input.mousePosition.y - _fLastFrameMousePosY;
				float num5 = _onShowRectInViewPort.y + (_fOffsetY + num4);
				float num6 = _onShowRectInViewPort.y + (_fOffsetY + num4) + _onShowRectInViewPort.height;
				if (num5 < 0f)
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
					if (num6 > (float)Screen.height)
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
						_fOffsetY += num4;
						_bNeedUpdateViewPort = true;
					}
				}
			}
			_fLastFrameMousePosX = Input.mousePosition.x;
			_fLastFrameMousePosY = Input.mousePosition.y;
		}

		public void c43cbb41bf755dfa61de619fc6e86ab31(bool c74232243aff1dcbf2e8fc243633bb51a)
		{
			if (_bDragable)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (!_bNeedAdjust)
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
					if (!_bVisible)
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
						if (c74232243aff1dcbf2e8fc243633bb51a)
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
							Vector2 vector = ce327ed2a74113168259d0491bd1aac35(_v2PlayerPos);
							float num = 0f;
							float num2 = 0f;
							float num3 = 50f;
							if (vector.x < 0f)
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
								num = vector.x - num3;
							}
							else if (vector.x > (float)Screen.width)
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
								num = vector.x - (float)Screen.width + num3;
							}
							if (vector.y < 0f)
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
								num2 = vector.y - num3;
							}
							else if (vector.y > (float)Screen.height)
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
								num2 = vector.y - (float)Screen.height + num3;
							}
							_fOffsetX += num;
							_fOffsetY += num2;
						}
					}
					if (_bVisible)
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
						if (!c74232243aff1dcbf2e8fc243633bb51a)
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
							_fOffsetX = 0f;
							_fOffsetY = 0f;
							if (_mcDragArea != null)
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
								_mcDragArea.removeAllEventListeners(MouseEvent.MOUSE_MOVE);
							}
						}
					}
				}
			}
			_bVisible = c74232243aff1dcbf2e8fc243633bb51a;
		}

		public virtual void c194b2ae40fd2c9494195cfea2bc80278(UIMapDataManager.UIMapObject c47b98c4493ce819dc05236a33086e9f9)
		{
			MapIcon mapIcon = c118c9c32a19e6f667dc6707f01b59017();
			if (mapIcon == null)
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
				mapIcon.c1b43efa39c10e5734987ae1ab98bc231(c47b98c4493ce819dc05236a33086e9f9);
				if (_onShowMapIconDic.ContainsKey(c47b98c4493ce819dc05236a33086e9f9.objInfo.GetInstanceID()))
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
					_onShowMapIconDic.Add(c47b98c4493ce819dc05236a33086e9f9.objInfo.GetInstanceID(), mapIcon);
					return;
				}
			}
		}

		public virtual void c66518e581390bcde034d900d43a609e3(int cb72e836b35783d6360d141c9ef1b7515)
		{
			MapIcon value = null;
			_onShowMapIconDic.TryGetValue(cb72e836b35783d6360d141c9ef1b7515, out value);
			if (value == null)
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
				value.c43cbb41bf755dfa61de619fc6e86ab31(false);
				_onShowMapIconDic.Remove(cb72e836b35783d6360d141c9ef1b7515);
				_mapIconPool.Add(value);
				return;
			}
		}

		protected virtual void c0c935947a2ad338a7296e9d3c24b2ce0()
		{
		}

		public void Update(Vector2 v2PlayerPos, float fPlayerDirAngle)
		{
			_v2PlayerPos = v2PlayerPos;
			if (!_bVisible)
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
				cbe154d50b8301b5ec241255197c4531a(v2PlayerPos);
				Dictionary<int, MapIcon>.Enumerator enumerator = _onShowMapIconDic.GetEnumerator();
				while (enumerator.MoveNext())
				{
					MapIcon value = enumerator.Current.Value;
					if (value.c65d246760c30e4bc7c4a634fbe26e722 == null)
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
					Vector2 vector = ce327ed2a74113168259d0491bd1aac35(value.c65d246760c30e4bc7c4a634fbe26e722.v2LocalPosInProportion);
					value.c034936ede6b65db0da600e58eb5611d2(vector.x, vector.y);
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					if (_player == null)
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
						Vector2 vector2 = ce327ed2a74113168259d0491bd1aac35(v2PlayerPos);
						_player.c034936ede6b65db0da600e58eb5611d2(vector2.x, vector2.y);
						_player.c95b58ea1846fc7087c97f6018072d7de(fPlayerDirAngle);
						return;
					}
				}
			}
		}

		protected Vector2 ce327ed2a74113168259d0491bd1aac35(Vector2 c9dce7f45f82d4f208ce62d6c5926a62b)
		{
			Vector2 result = new Vector2(0f, 0f);
			result.x = (c9dce7f45f82d4f208ce62d6c5926a62b.x - _onShowRectInTex.x) / _onShowRectInTex.width * _onShowRectInViewPort.width + _onShowRectInViewPort.x;
			result.y = (c9dce7f45f82d4f208ce62d6c5926a62b.y - _onShowRectInTex.y) / _onShowRectInTex.height * _onShowRectInViewPort.height + _onShowRectInViewPort.y;
			if (_bDragable)
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
				result.x += _fOffsetX;
				result.y -= _fOffsetY;
			}
			return result;
		}

		public MapIcon c118c9c32a19e6f667dc6707f01b59017()
		{
			MapIcon mapIcon = null;
			if (_mapIconPool.Count > 0)
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
				mapIcon = _mapIconPool[0];
				_mapIconPool.Remove(mapIcon);
			}
			else
			{
				if (_mcIconTemplate == null)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						return null;
					}
				}
				MovieClip movieClip = _mcIconTemplate.newInstance();
				movieClip.scaleX = _mcIconTemplate.width / movieClip.width;
				movieClip.scaleY = _mcIconTemplate.height / movieClip.height;
				if (_mcIconContainer != null)
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
					_mcIconContainer.addChild(movieClip);
				}
				mapIcon = new MapIcon();
				mapIcon.c080c47c42f83c638229e4ac8fd372d45 = _onShowRectInViewPort;
				mapIcon.c130648b59a0c8debea60aa153f844879(movieClip);
			}
			return mapIcon;
		}

		public virtual void c447622bfef0197a740b1446b9c4bf5df(int c1c4bb487a9ef4614cf80b719d11a7ddd)
		{
			MapIcon value = null;
			if (!_onShowMapIconDic.TryGetValue(c1c4bb487a9ef4614cf80b719d11a7ddd, out value))
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
				value.c1b43efa39c10e5734987ae1ab98bc231();
				return;
			}
		}

		public virtual void cdfb66cdb035e8738bbe2a1d6770b717b(string cf4034dc10446272afddc861aee70a462, int c9526cedaae8a6f13c52592df57f78e6e, int cad0bf4708b84096a7adbac3208b2d880)
		{
			if (cf4034dc10446272afddc861aee70a462 == null)
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
				if (cf4034dc10446272afddc861aee70a462.Length == 0)
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
				StringBuilder stringBuilder = new StringBuilder(LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(cf4034dc10446272afddc861aee70a462)));
				if (cad0bf4708b84096a7adbac3208b2d880 > 1)
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
					stringBuilder.Append(" - ").Append(c9526cedaae8a6f13c52592df57f78e6e);
				}
				if (_textMapName == null)
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
					_textMapName.text = stringBuilder.ToString();
					return;
				}
			}
		}

		protected void cbe154d50b8301b5ec241255197c4531a(Vector2 c5e97115b40ba90e62d32857c0c4c7c73)
		{
			if (_mapPanel == null)
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
				if (base.c89ef242f4744e0f1c4ffea4da8b79bc1 == null)
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
				Rect onShowRectInViewPort = _onShowRectInViewPort;
				if (!_bDragable)
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
					Vector2 vector = new Vector2(0f, 0f);
					vector.x = _onShowRectInViewPort.width * _fScale / _v2WorldSize.x;
					vector.y = _onShowRectInViewPort.height * _fScale / _v2WorldSize.y;
					float left = c5e97115b40ba90e62d32857c0c4c7c73.x - vector.x / 2f;
					float top = c5e97115b40ba90e62d32857c0c4c7c73.y - vector.y / 2f;
					_onShowRectInTex = new Rect(left, top, vector.x, vector.y);
				}
				else
				{
					onShowRectInViewPort.x = _onShowRectInViewPort.x + _fOffsetX;
					onShowRectInViewPort.y = _onShowRectInViewPort.y - _fOffsetY;
					if (_bNeedUpdateViewPort)
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
						using (Dictionary<int, MapIcon>.ValueCollection.Enumerator enumerator = _onShowMapIconDic.Values.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								MapIcon current = enumerator.Current;
								current.c080c47c42f83c638229e4ac8fd372d45 = onShowRectInViewPort;
							}
							while (true)
							{
								switch (3)
								{
								case 0:
									break;
								default:
									goto end_IL_0175;
								}
								continue;
								end_IL_0175:
								break;
							}
						}
					}
					_bNeedUpdateViewPort = false;
				}
				_mapPanel.c533af2b08173b7c2e3e5405efc254ee3(_mapTex, _onShowRectInTex, onShowRectInViewPort);
				return;
			}
		}
	}

	public class MapIcon : MapObject
	{
		protected const string _strFramePrefix = "mcTarget_";

		protected MovieClip _mcCurIcon;

		protected UIMapDataManager.UIMapObject _iconData;

		protected float _fCurIconWidth;

		protected float _fCurIconHeight;

		protected Rect _onShowRectInViewPort = new Rect(0f, 0f, 1f, 1f);

		public Rect c080c47c42f83c638229e4ac8fd372d45
		{
			set
			{
				_onShowRectInViewPort = value;
			}
		}

		public UIMapDataManager.UIMapObject c65d246760c30e4bc7c4a634fbe26e722
		{
			get
			{
				return _iconData;
			}
		}

		public void c1b43efa39c10e5734987ae1ab98bc231(UIMapDataManager.UIMapObject cc5010b0c3ba44a1d74547a88034f3804 = null)
		{
			if (_iconData != null)
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
				if (cc5010b0c3ba44a1d74547a88034f3804 == null)
				{
					goto IL_002f;
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
			_iconData = cc5010b0c3ba44a1d74547a88034f3804;
			goto IL_002f;
			IL_002f:
			if (_iconData == null)
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
			MovieClip movieClip = base.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
			if (_iconData == null)
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
				if (movieClip == null)
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
				movieClip.gotoAndStop(_iconData.objInfo.ObjType.ToString());
				string name = "mcTarget_" + _iconData.objInfo.ObjType;
				_mcCurIcon = movieClip.getChildByName<MovieClip>(name);
				if (_mcCurIcon == null)
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
					_fCurIconWidth = _mcCurIcon.width * movieClip.scaleX;
					_fCurIconHeight = _mcCurIcon.height * movieClip.scaleY;
					if (_iconData.objInfo.ObjType == UIMapDataManager.MiniMapObjectType.NPC)
					{
						while (true)
						{
							switch (6)
							{
							case 0:
								break;
							default:
								_mcCurIcon.gotoAndStop(_iconData.npcIconType.ToString());
								return;
							}
						}
					}
					if (_iconData.objInfo.ObjType == UIMapDataManager.MiniMapObjectType.EnemyPlayer)
					{
						while (true)
						{
							switch (5)
							{
							case 0:
								break;
							default:
								if (_iconData.bIsDead)
								{
									while (true)
									{
										switch (5)
										{
										case 0:
											break;
										default:
											_mcCurIcon.gotoAndStop("dead");
											_mcCurIcon.visible = true;
											return;
										}
									}
								}
								_mcCurIcon.gotoAndStop("alive");
								_mcCurIcon.visible = _iconData.bIsOnFire;
								return;
							}
						}
					}
					if (_iconData.objInfo.ObjType != UIMapDataManager.MiniMapObjectType.TeamMate)
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
						if (_iconData.bIsDead)
						{
							while (true)
							{
								switch (5)
								{
								case 0:
									break;
								default:
									_mcCurIcon.gotoAndStop("dead");
									return;
								}
							}
						}
						_mcCurIcon.gotoAndStop("alive");
						return;
					}
				}
			}
		}

		public override void c034936ede6b65db0da600e58eb5611d2(float cf22abc11d4de1bf9512d436d39658129, float c7dda3842e8e35e19a7c65986229c1802)
		{
			base.c034936ede6b65db0da600e58eb5611d2(cf22abc11d4de1bf9512d436d39658129, c7dda3842e8e35e19a7c65986229c1802);
			cc9c9a6dea5e7f66982332238f2ddabd8();
		}

		protected void cc9c9a6dea5e7f66982332238f2ddabd8()
		{
			MovieClip movieClip = base.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
			if (_mcCurIcon == null)
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
				if (movieClip == null)
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
				float x = movieClip.x;
				float y = movieClip.y;
				float num = x;
				float num2 = y;
				float num3 = _fCurIconWidth / 2f;
				float num4 = _fCurIconHeight / 2f;
				int num5;
				if (!(x + num3 > _onShowRectInViewPort.x + _onShowRectInViewPort.width))
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
					if (!(x - num3 < _onShowRectInViewPort.x))
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
						if (!(y + num4 > _onShowRectInViewPort.y + _onShowRectInViewPort.height))
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
							num5 = ((y - num4 < _onShowRectInViewPort.y) ? 1 : 0);
							goto IL_00f3;
						}
					}
				}
				num5 = 1;
				goto IL_00f3;
				IL_00f3:
				bool flag = num5 == 0;
				if (!flag)
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
					if (_iconData.objInfo.bAlwaysOnMap)
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
						float num6 = _onShowRectInViewPort.width / 2f;
						float num7 = _onShowRectInViewPort.height / 2f;
						float num8 = x - num6;
						float num9 = y - num7;
						float num10 = Math.Abs(num7 / num9) * num8;
						float num11 = Math.Abs(num6 / num8) * num9;
						float num12 = Mathf.Abs(num8 / num9);
						if (num12 >= num6 / num7)
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
							num2 = num7 + num11;
						}
						else
						{
							num = num6 + num10;
						}
					}
					if (num < num3)
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
						num = num3;
					}
					else if (num > _onShowRectInViewPort.width - num3)
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
						num = _onShowRectInViewPort.width - num3;
					}
					if (num2 < num4)
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
						num2 = num4;
					}
					else if (num2 > _onShowRectInViewPort.height - num4)
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
						num2 = _onShowRectInViewPort.height - num4;
					}
					Matrix matrix = movieClip.getMatrix();
					matrix.tx = num;
					matrix.ty = num2;
					movieClip.setMatrix(matrix);
				}
				int visible;
				if (!flag)
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
					visible = (_iconData.objInfo.bAlwaysOnMap ? 1 : 0);
				}
				else
				{
					visible = 1;
				}
				movieClip.visible = (byte)visible != 0;
				return;
			}
		}
	}

	public class MapObject : c196099a1254db61d3be10d70e14e7422
	{
		public virtual void c034936ede6b65db0da600e58eb5611d2(float cf22abc11d4de1bf9512d436d39658129, float c7dda3842e8e35e19a7c65986229c1802)
		{
			if (base.c89ef242f4744e0f1c4ffea4da8b79bc1 == null)
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
			base.c89ef242f4744e0f1c4ffea4da8b79bc1.x = cf22abc11d4de1bf9512d436d39658129;
			base.c89ef242f4744e0f1c4ffea4da8b79bc1.y = c7dda3842e8e35e19a7c65986229c1802;
		}

		public void c43cbb41bf755dfa61de619fc6e86ab31(bool c74232243aff1dcbf2e8fc243633bb51a)
		{
			if (base.c89ef242f4744e0f1c4ffea4da8b79bc1 == null)
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
				base.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = c74232243aff1dcbf2e8fc243633bb51a;
				return;
			}
		}

		public void c95b58ea1846fc7087c97f6018072d7de(float c600f94f25573194335c5c2fb591a674e)
		{
			if (base.c89ef242f4744e0f1c4ffea4da8b79bc1 == null)
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
			base.c89ef242f4744e0f1c4ffea4da8b79bc1.rotation = c600f94f25573194335c5c2fb591a674e;
		}
	}

	protected class MinimapNotificationListener : UIMapDataManager.MinimapNotificationListener
	{
		public void OnAddNewMapObject(UIMapDataManager.UIMapObject tarObj)
		{
			c71f6ce28731edfd43c976fbd57c57bea().OnAddNewMapObj(tarObj);
		}

		public void OnRemoveMapObject(UIMapDataManager.UIMapObject tarObj)
		{
			c71f6ce28731edfd43c976fbd57c57bea().OnRemoveNewMapObj(tarObj);
		}

		public void OnMapObjectUpdate(UIMapDataManager.UIMapObject tarObj)
		{
			c71f6ce28731edfd43c976fbd57c57bea().OnObjInfoUpdated(tarObj);
		}

		public void OnSwitchMapTexture(int iNewIdx)
		{
			c71f6ce28731edfd43c976fbd57c57bea().OnSwitchMapTexture(iNewIdx);
		}

		public void OnMapSetup()
		{
			c71f6ce28731edfd43c976fbd57c57bea().OnMapSetup();
		}
	}

	protected static UIMapDisplayManager _instance;

	protected bool _bInited;

	protected List<UIMapRoot> _mapList = new List<UIMapRoot>();

	protected MinimapNotificationListener _nofiListener = new MinimapNotificationListener();

	protected UIMapDisplayManager()
	{
	}

	public static UIMapDisplayManager c71f6ce28731edfd43c976fbd57c57bea()
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
			_instance = new UIMapDisplayManager();
		}
		return _instance;
	}

	public void ccc9d3a38966dc10fedb531ea17d24611()
	{
		UIMapDataManager.c71f6ce28731edfd43c976fbd57c57bea().cc7c09df5a4a467ee40cdda5047fd18d0(_nofiListener);
		if (UIMapDataManager.c71f6ce28731edfd43c976fbd57c57bea()._curStatus != UIMapDataManager.MinimapStatus.Normal)
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
			ccc437187d04634cbc9cf03de5d51dc15();
			return;
		}
	}

	public void cac7688b05e921e2be3f92479ba44b4a8()
	{
		UIMapDataManager.c71f6ce28731edfd43c976fbd57c57bea().cd178f4fb7e34eae260792cefd4140db9(_nofiListener);
		_mapList.Clear();
		_bInited = false;
	}

	public void OnAddNewMapObj(UIMapDataManager.UIMapObject tarObj)
	{
		using (List<UIMapRoot>.Enumerator enumerator = _mapList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				UIMapRoot current = enumerator.Current;
				current.c194b2ae40fd2c9494195cfea2bc80278(tarObj);
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

	public void OnRemoveNewMapObj(UIMapDataManager.UIMapObject tarObj)
	{
		using (List<UIMapRoot>.Enumerator enumerator = _mapList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				UIMapRoot current = enumerator.Current;
				current.c66518e581390bcde034d900d43a609e3(tarObj.objInfo.GetInstanceID());
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

	public void OnObjInfoUpdated(UIMapDataManager.UIMapObject tarObj)
	{
		using (List<UIMapRoot>.Enumerator enumerator = _mapList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				UIMapRoot current = enumerator.Current;
				current.c447622bfef0197a740b1446b9c4bf5df(tarObj.objInfo.GetInstanceID());
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
				return;
			}
		}
	}

	public void OnSwitchMapTexture(int iNewIdx)
	{
		UIMapDataManager.MapContext c30723ad1ed00b021a57cce509d64f2a = UIMapDataManager.c71f6ce28731edfd43c976fbd57c57bea().c30723ad1ed00b021a57cce509d64f2a6;
		using (List<UIMapRoot>.Enumerator enumerator = _mapList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				UIMapRoot current = enumerator.Current;
				if (c30723ad1ed00b021a57cce509d64f2a == null)
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
				if (!(c30723ad1ed00b021a57cce509d64f2a.curMiniMapConfig != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (c30723ad1ed00b021a57cce509d64f2a.curMiniMapConfig.MiniMapTexture == null)
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
				if (iNewIdx >= c30723ad1ed00b021a57cce509d64f2a.curMiniMapConfig.MiniMapTexture.Length)
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
				Texture2D texture = c30723ad1ed00b021a57cce509d64f2a.curMiniMapConfig.MiniMapTexture[iNewIdx].texture;
				if (!(texture != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				current.c94b817daf954df0906d9a038fd06d320 = texture;
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

	protected void ccc437187d04634cbc9cf03de5d51dc15()
	{
		UIMapDataManager.MapContext c30723ad1ed00b021a57cce509d64f2a = UIMapDataManager.c71f6ce28731edfd43c976fbd57c57bea().c30723ad1ed00b021a57cce509d64f2a6;
		if (c30723ad1ed00b021a57cce509d64f2a == null)
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
			if (!(c30723ad1ed00b021a57cce509d64f2a.curMiniMapConfig != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				using (List<UIMapRoot>.Enumerator enumerator = _mapList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						UIMapRoot current = enumerator.Current;
						current.c94b817daf954df0906d9a038fd06d320 = c30723ad1ed00b021a57cce509d64f2a.defaultTexture;
						current.cf0471c63448d3685ac44fe425bcc3c6e = c30723ad1ed00b021a57cce509d64f2a.v2DisplayAreaLocalSize;
						current.c2b8fb615324c416fbab0b55f12a92dce = c30723ad1ed00b021a57cce509d64f2a.curMiniMapConfig.Scale;
						current.cdfb66cdb035e8738bbe2a1d6770b717b(c30723ad1ed00b021a57cce509d64f2a.strInstanceName, c30723ad1ed00b021a57cce509d64f2a.iMapIndex, c30723ad1ed00b021a57cce509d64f2a.iMapSubPartCnt);
						Dictionary<int, UIMapDataManager.UIMapObject> dictionary = UIMapDataManager.c71f6ce28731edfd43c976fbd57c57bea().c793a8b137ecffd2d0bcd165376f788ba();
						if (dictionary == null)
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
						using (Dictionary<int, UIMapDataManager.UIMapObject>.ValueCollection.Enumerator enumerator2 = dictionary.Values.GetEnumerator())
						{
							while (enumerator2.MoveNext())
							{
								UIMapDataManager.UIMapObject current2 = enumerator2.Current;
								current.c194b2ae40fd2c9494195cfea2bc80278(current2);
							}
							while (true)
							{
								switch (6)
								{
								case 0:
									break;
								default:
									goto end_IL_00f4;
								}
								continue;
								end_IL_00f4:
								break;
							}
						}
					}
					while (true)
					{
						switch (2)
						{
						case 0:
							break;
						default:
							goto end_IL_011b;
						}
						continue;
						end_IL_011b:
						break;
					}
				}
				_bInited = true;
				return;
			}
		}
	}

	public void OnMapSetup()
	{
		ccc437187d04634cbc9cf03de5d51dc15();
	}

	public void Update()
	{
		UIMapDataManager.MapContext c30723ad1ed00b021a57cce509d64f2a = UIMapDataManager.c71f6ce28731edfd43c976fbd57c57bea().c30723ad1ed00b021a57cce509d64f2a6;
		if (!_bInited)
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
			if (c30723ad1ed00b021a57cce509d64f2a == null)
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
				for (int i = 0; i < _mapList.Count; i++)
				{
					_mapList[i].Update(c30723ad1ed00b021a57cce509d64f2a.v2PlayerPosInProportion, c30723ad1ed00b021a57cce509d64f2a.fPlayerDirAngle);
				}
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
		}
	}

	public void c79b68441494b2679b55be7197f656be8(UIMapRoot cee81b3b44fd8c98c3607b89675bea517)
	{
		UIMapDataManager.MapContext c30723ad1ed00b021a57cce509d64f2a = UIMapDataManager.c71f6ce28731edfd43c976fbd57c57bea().c30723ad1ed00b021a57cce509d64f2a6;
		if (c30723ad1ed00b021a57cce509d64f2a != null)
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
			if (c30723ad1ed00b021a57cce509d64f2a.curMiniMapConfig != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				cee81b3b44fd8c98c3607b89675bea517.c94b817daf954df0906d9a038fd06d320 = c30723ad1ed00b021a57cce509d64f2a.defaultTexture;
				cee81b3b44fd8c98c3607b89675bea517.cf0471c63448d3685ac44fe425bcc3c6e = c30723ad1ed00b021a57cce509d64f2a.v2DisplayAreaLocalSize;
				cee81b3b44fd8c98c3607b89675bea517.c2b8fb615324c416fbab0b55f12a92dce = c30723ad1ed00b021a57cce509d64f2a.curMiniMapConfig.Scale;
				cee81b3b44fd8c98c3607b89675bea517.cdfb66cdb035e8738bbe2a1d6770b717b(c30723ad1ed00b021a57cce509d64f2a.strInstanceName, c30723ad1ed00b021a57cce509d64f2a.iMapIndex, c30723ad1ed00b021a57cce509d64f2a.iMapSubPartCnt);
			}
		}
		if (_bInited)
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
			Dictionary<int, UIMapDataManager.UIMapObject> dictionary = UIMapDataManager.c71f6ce28731edfd43c976fbd57c57bea().c793a8b137ecffd2d0bcd165376f788ba();
			using (Dictionary<int, UIMapDataManager.UIMapObject>.ValueCollection.Enumerator enumerator = dictionary.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					UIMapDataManager.UIMapObject current = enumerator.Current;
					cee81b3b44fd8c98c3607b89675bea517.c194b2ae40fd2c9494195cfea2bc80278(current);
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						goto end_IL_00d3;
					}
					continue;
					end_IL_00d3:
					break;
				}
			}
		}
		_mapList.Add(cee81b3b44fd8c98c3607b89675bea517);
	}
}
