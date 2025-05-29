using System.Collections.Generic;
using System.Text;
using A;
using pumpkin.display;

public class uniLargeMapView : LargeMapView
{
	protected class LargeMapRoot : UIMapDisplayManager.UIMapRoot
	{
		protected static string ITEM_PREFIX = "mcMapLegend_";

		protected static int ITEM_COUNT = 10;

		protected MapLegend[] _legendAry = new MapLegend[ITEM_COUNT];

		protected HashSet<UIMapDataManager.MiniMapObjectType> _MapObjTypeToShow = new HashSet<UIMapDataManager.MiniMapObjectType>();

		protected HashSet<NpcTitleMgr.NPC_ICON_TYPE> _NpcIconToShow = new HashSet<NpcTitleMgr.NPC_ICON_TYPE>();

		protected UnityTextField _textMapTitle;

		protected UnityTextField _textMapDesc;

		protected string _strMapName;

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			_MapObjTypeToShow.Clear();
			_MapObjTypeToShow.Add(UIMapDataManager.MiniMapObjectType.NPC);
			_MapObjTypeToShow.Add(UIMapDataManager.MiniMapObjectType.TownExit);
			_MapObjTypeToShow.Add(UIMapDataManager.MiniMapObjectType.WorldMapDevice);
			_MapObjTypeToShow.Add(UIMapDataManager.MiniMapObjectType.Trigger);
			_MapObjTypeToShow.Add(UIMapDataManager.MiniMapObjectType.InstanceExitOpen);
			_NpcIconToShow.Add(NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DONE);
			_NpcIconToShow.Add(NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_PROGRESS);
			_NpcIconToShow.Add(NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_NEW);
			_NpcIconToShow.Add(NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DAILY_NEW);
			_NpcIconToShow.Add(NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DAILY_DONE);
			_NpcIconToShow.Add(NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_SPECIAL_NEW);
			_NpcIconToShow.Add(NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_CRAFT);
			_NpcIconToShow.Add(NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_SPECIAL_DONE);
			_NpcIconToShow.Add(NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DOC);
			_NpcIconToShow.Add(NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_GUILD);
			_NpcIconToShow.Add(NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_MAIL);
			_NpcIconToShow.Add(NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_MAIL_NEW);
			_NpcIconToShow.Add(NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_WAREHOUSE);
			_NpcIconToShow.Add(NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_SHOP);
			_NpcIconToShow.Add(NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_MAIL_NEW);
			_NpcIconToShow.Add(NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_UPGRADE);
			MovieClip childByName = base.c89ef242f4744e0f1c4ffea4da8b79bc1.getChildByName<MovieClip>("mcLegendContainer");
			if (childByName == null)
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
				for (int i = 0; i < ITEM_COUNT; i++)
				{
					_legendAry[i] = new MapLegend();
					string name = ITEM_PREFIX + i;
					MovieClip childByName2 = childByName.getChildByName<MovieClip>(name);
					if (childByName2 == null)
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
					_legendAry[i].c130648b59a0c8debea60aa153f844879(childByName2);
					childByName2.visible = false;
				}
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					_textMapDesc = childByName.getChildByName<UnityTextField>("textMapDesc");
					if (_textMapDesc != null)
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
						_textMapDesc.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Map_Control"));
					}
					_textMapTitle = childByName.getChildByName<UnityTextField>("textMapName");
					return;
				}
			}
		}

		public override void cdfb66cdb035e8738bbe2a1d6770b717b(string cf4034dc10446272afddc861aee70a462, int c9526cedaae8a6f13c52592df57f78e6e, int cad0bf4708b84096a7adbac3208b2d880)
		{
			StringBuilder stringBuilder = new StringBuilder(LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(cf4034dc10446272afddc861aee70a462)));
			if (cad0bf4708b84096a7adbac3208b2d880 > 1)
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
				stringBuilder.Append(" - ").Append(c9526cedaae8a6f13c52592df57f78e6e);
			}
			if (_textMapTitle == null)
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
				_textMapTitle.text = stringBuilder.ToString();
				return;
			}
		}

		public override void c194b2ae40fd2c9494195cfea2bc80278(UIMapDataManager.UIMapObject c47b98c4493ce819dc05236a33086e9f9)
		{
			base.c194b2ae40fd2c9494195cfea2bc80278(c47b98c4493ce819dc05236a33086e9f9);
			c1d0989ae1c4c771915d14bd1b6927284();
		}

		public override void c66518e581390bcde034d900d43a609e3(int cb72e836b35783d6360d141c9ef1b7515)
		{
			base.c66518e581390bcde034d900d43a609e3(cb72e836b35783d6360d141c9ef1b7515);
			c1d0989ae1c4c771915d14bd1b6927284();
		}

		public override void c447622bfef0197a740b1446b9c4bf5df(int c1c4bb487a9ef4614cf80b719d11a7ddd)
		{
			base.c447622bfef0197a740b1446b9c4bf5df(c1c4bb487a9ef4614cf80b719d11a7ddd);
			c1d0989ae1c4c771915d14bd1b6927284();
		}

		protected override void c0c935947a2ad338a7296e9d3c24b2ce0()
		{
			base.c0c935947a2ad338a7296e9d3c24b2ce0();
			if (_textMapDesc == null)
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
				UnityTextField textMapDesc = _textMapDesc;
				int visible;
				if (!_bHorizontalDragAble)
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
					visible = (_bVerticalDragAble ? 1 : 0);
				}
				else
				{
					visible = 1;
				}
				textMapDesc.visible = (byte)visible != 0;
				return;
			}
		}

		protected void c1d0989ae1c4c771915d14bd1b6927284()
		{
			HashSet<NpcTitleMgr.NPC_ICON_TYPE> hashSet = new HashSet<NpcTitleMgr.NPC_ICON_TYPE>();
			HashSet<UIMapDataManager.MiniMapObjectType> hashSet2 = new HashSet<UIMapDataManager.MiniMapObjectType>();
			List<UIMapDisplayManager.MapIcon> list = new List<UIMapDisplayManager.MapIcon>();
			using (Dictionary<int, UIMapDisplayManager.MapIcon>.ValueCollection.Enumerator enumerator = _onShowMapIconDic.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					UIMapDisplayManager.MapIcon current = enumerator.Current;
					if (!_MapObjTypeToShow.Contains(current.c65d246760c30e4bc7c4a634fbe26e722.objInfo.ObjType))
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
					if (current.c65d246760c30e4bc7c4a634fbe26e722.objInfo.ObjType == UIMapDataManager.MiniMapObjectType.NPC)
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
						if (!_NpcIconToShow.Contains(current.c65d246760c30e4bc7c4a634fbe26e722.npcIconType))
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
						if (hashSet.Contains(current.c65d246760c30e4bc7c4a634fbe26e722.npcIconType))
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
						list.Add(current);
						hashSet.Add(current.c65d246760c30e4bc7c4a634fbe26e722.npcIconType);
					}
					else if (hashSet2.Contains(current.c65d246760c30e4bc7c4a634fbe26e722.objInfo.ObjType))
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
					}
					else
					{
						list.Add(current);
						hashSet2.Add(current.c65d246760c30e4bc7c4a634fbe26e722.objInfo.ObjType);
					}
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						goto end_IL_014b;
					}
					continue;
					end_IL_014b:
					break;
				}
			}
			int i;
			for (i = 0; i < ITEM_COUNT; i++)
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
				if (i < list.Count)
				{
					if (_legendAry[i] == null)
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
					_legendAry[i].c89ef242f4744e0f1c4ffea4da8b79bc1.visible = true;
					_legendAry[i].c1b43efa39c10e5734987ae1ab98bc231(list[i].c65d246760c30e4bc7c4a634fbe26e722);
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
				break;
			}
			for (; i < ITEM_COUNT; i++)
			{
				if (_legendAry[i] == null)
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
				_legendAry[i].c89ef242f4744e0f1c4ffea4da8b79bc1.visible = false;
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

	protected class MapLegend : c196099a1254db61d3be10d70e14e7422
	{
		protected UIMapDisplayManager.MapIcon _mapIcon;

		protected UnityTextField _textDes;

		protected readonly string LEGEND_DES_PREFIX = "MapLegend_";

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			_mapIcon = new UIMapDisplayManager.MapIcon();
			MovieClip childByName = base.c89ef242f4744e0f1c4ffea4da8b79bc1.getChildByName<MovieClip>("mcIcon");
			if (childByName != null)
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
				_mapIcon.c130648b59a0c8debea60aa153f844879(childByName);
			}
			_textDes = base.c89ef242f4744e0f1c4ffea4da8b79bc1.getChildByName<UnityTextField>("textDes");
		}

		public void c1b43efa39c10e5734987ae1ab98bc231(UIMapDataManager.UIMapObject cc5010b0c3ba44a1d74547a88034f3804)
		{
			if (cc5010b0c3ba44a1d74547a88034f3804 == null)
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
				if (_mapIcon == null)
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
					_mapIcon.c1b43efa39c10e5734987ae1ab98bc231(cc5010b0c3ba44a1d74547a88034f3804);
					string lEGEND_DES_PREFIX = LEGEND_DES_PREFIX;
					if (cc5010b0c3ba44a1d74547a88034f3804.objInfo.ObjType == UIMapDataManager.MiniMapObjectType.NPC)
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
						string text = cc5010b0c3ba44a1d74547a88034f3804.npcIconType.ToString();
						string oldValue = "NPC_ICON_";
						string text2 = text.Replace(oldValue, string.Empty);
						lEGEND_DES_PREFIX += text2;
					}
					else
					{
						lEGEND_DES_PREFIX += cc5010b0c3ba44a1d74547a88034f3804.objInfo.ObjType;
					}
					if (_textDes == null)
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
						if (lEGEND_DES_PREFIX == null)
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
							_textDes.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(lEGEND_DES_PREFIX));
							return;
						}
					}
				}
			}
		}
	}

	protected c196099a1254db61d3be10d70e14e7422 _container;

	protected MovieClip _largeMapRootMC;

	protected LargeMapRoot _mapRoot;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		_bActive = false;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("MiniMap.swf", "Panel_LargeMapContainer", c1141a8fde9aa0f410bc4a7fdd2e3ef7c);
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_container);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("MiniMap.swf");
	}

	private void c1141a8fde9aa0f410bc4a7fdd2e3ef7c(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_container = new c196099a1254db61d3be10d70e14e7422();
		_container.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		MovieClip childByName = cbe9ca8ddb3cdc2312e6ff8411b2db2c8.getChildByName<MovieClip>("mcLargeMapRoot");
		if (childByName != null)
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
			_mapRoot = new LargeMapRoot();
			_mapRoot.c4ff0d4ba3eeaed831ca975de7848acce = UIMapDisplayManager.MapCategoryTag.LargeMap;
			_mapRoot.c729bd42662457ecf184ce15af0942cbe = true;
			_mapRoot.cd61d9f244ef37bfca642c090f0dd57af = false;
			_mapRoot.c130648b59a0c8debea60aa153f844879(childByName);
			UIMapDisplayManager.c71f6ce28731edfd43c976fbd57c57bea().c79b68441494b2679b55be7197f656be8(_mapRoot);
		}
		_bActive = true;
		cbf5f806ecf4d92b475f68040522616cf(false);
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
		if (c8be1fcd630e5fe96821376d111325750)
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
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<UniUIManager>().cb4341b3564e3d55dc9f38df4b813c5da(_container);
		}
		else
		{
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<UniUIManager>().c27542a6dc8f97862ef53db1d4f3a6db8(_container);
		}
		if (_container != null)
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
			if (_container.c89ef242f4744e0f1c4ffea4da8b79bc1 != null)
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
				_container.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = c8be1fcd630e5fe96821376d111325750;
			}
			if (_mapRoot != null)
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
				if (_mapRoot.c89ef242f4744e0f1c4ffea4da8b79bc1 != null)
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
					_mapRoot.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = c8be1fcd630e5fe96821376d111325750;
				}
			}
		}
		if (!c8be1fcd630e5fe96821376d111325750)
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
			c06ca0e618478c23eba3419653a19760f<GuidanceTipsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c93a582e07019617943999be8717d5134("guidance_map");
			return;
		}
	}
}
