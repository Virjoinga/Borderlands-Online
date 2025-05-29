using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using A;
using Core;
using UnityEngine;
using XsdSettings;
using pumpkin.display;
using pumpkin.events;
using pumpkin.geom;
using pumpkin.text;

public class uniSkillTreeView : SkillTreeView
{
	public class SkillTreePanel : c196099a1254db61d3be10d70e14e7422
	{
		public delegate void DeleVoid();

		protected const int _iBranchNum = 3;

		protected const string _strClassNamePrefix = "CLASS_";

		protected MovieClip _rootMC;

		protected MovieClip _mcClass;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b _btnReset;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b _btnClose;

		protected TextField _textUnspentSkillPt;

		protected TextField[] _textTreeNameAry = c19e050a19e36cad0b82e93ce13289601.c0a0cdf4a196914163f7334d9b0781a04(3);

		protected Dictionary<int, TierBGProgress> _dicProgressBG = new Dictionary<int, TierBGProgress>();

		protected Dictionary<int, Dictionary<int, SkillIconSlot>> _dicPositionSkillSlot = new Dictionary<int, Dictionary<int, SkillIconSlot>>();

		protected Dictionary<int, SkillIconSlot> _dicSkillSlot = new Dictionary<int, SkillIconSlot>();

		protected DeleVoid _onClickReset;

		protected DeleVoid _onClickClose;

		protected string _strTreeNamePrefix = "textTreeName_";

		[CompilerGenerated]
		private static Dictionary<string, int> _003C_003Ef__switch_0024map2B;

		public SkillTreePanel()
		{
			_btnReset = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			_btnClose = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
		}

		public void cac7688b05e921e2be3f92479ba44b4a8()
		{
			_dicProgressBG.Clear();
			_dicPositionSkillSlot.Clear();
			_dicSkillSlot.Clear();
		}

		public void c076bcbb538ab7a02f13183c99cc8c79e(DeleVoid c7e4d7125545e289b9a8aca0341027655, DeleVoid c841247da5d5339137d102abe03c762c6)
		{
			_onClickReset = c7e4d7125545e289b9a8aca0341027655;
			_onClickClose = c841247da5d5339137d102abe03c762c6;
			XsdSettings.SkillTree c08678cb5a9f2ec077be4dd868efd = SkillTreeDataManager.c71f6ce28731edfd43c976fbd57c57bea().c08678cb5a9f2ec077be4dd868efd1453;
			string text = c08678cb5a9f2ec077be4dd868efd.m_avatarType.ToString();
			MovieClip childByName = _rootMC.getChildByName<MovieClip>("mcCareerBG");
			if (childByName != null)
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
				childByName.gotoAndStop(text);
			}
			if (_mcClass != null)
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
				UnityTextField unityTextField = (UnityTextField)_mcClass.getChildByName<TextField>("textClassName");
				if (unityTextField != null)
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
					unityTextField.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("CLASS_" + text));
				}
			}
			for (int i = 1; i <= 3; i++)
			{
				TierBGProgress value = null;
				_dicProgressBG.TryGetValue(i, out value);
				if (value == null)
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
				string c2517975451e334c7dfe394eb021ae = text + '_' + i;
				value.c9b0ea1029fa2792e65fc0a564791d576(c2517975451e334c7dfe394eb021ae);
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				if (_rootMC != null)
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
					if (c08678cb5a9f2ec077be4dd868efd == null)
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
					SkillTreeTier[] tierList = c08678cb5a9f2ec077be4dd868efd.m_tierList;
					foreach (SkillTreeTier skillTreeTier in tierList)
					{
						NodeGroup[] nodeGroupList = skillTreeTier.m_nodeGroupList;
						foreach (NodeGroup nodeGroup in nodeGroupList)
						{
							int num = nodeGroup.m_nodeList.Length;
							int num2 = num % 2;
							for (int l = 0; l < num; l++)
							{
								SkillNode skillNode = nodeGroup.m_nodeList[l];
								Skill skill = c1ee7921b0c3cce194fb7cae41b5a9d82<SkillTreeServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cc68b2da7036261f61f86280fd6e61748(Convert.ToInt32(skillNode.m_id));
								if (skill == null)
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
									continue;
								}
								int key = (nodeGroup.m_id - 1) * 3 + num2 + 2 * l + 1;
								if (skillTreeTier.m_id != 1)
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
									if (skillTreeTier.m_id != 2)
									{
										goto IL_0210;
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
								key = 1;
								goto IL_0210;
								IL_0210:
								SkillIconSlot skillIconSlot = _dicPositionSkillSlot[skillTreeTier.m_id][key];
								if (!_dicSkillSlot.ContainsKey(skill.m_id))
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
									_dicSkillSlot.Add(skill.m_id, skillIconSlot);
								}
								skillIconSlot.c73e2661815f684ef5dd4807355ef628c(skill, skillTreeTier.m_id, c08678cb5a9f2ec077be4dd868efd.m_avatarType);
								SkillNodeTips cf11827593d70bd2d2c0ef6e439b1c9d = new SkillNodeTips(skill, 0);
								skillIconSlot.cf11827593d70bd2d2c0ef6e439b1c9d9 = cf11827593d70bd2d2c0ef6e439b1c9d;
							}
							while (true)
							{
								switch (2)
								{
								case 0:
									break;
								default:
									goto end_IL_02a5;
								}
								continue;
								end_IL_02a5:
								break;
							}
						}
						while (true)
						{
							switch (7)
							{
							case 0:
								break;
							default:
								goto end_IL_02c0;
							}
							continue;
							end_IL_02c0:
							break;
						}
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
				c5b42a9b12146680344bf0e9f363746ad();
				return;
			}
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			_rootMC = base.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
			_textUnspentSkillPt = _rootMC.getChildByName<TextField>("textField_AvailablePt");
			for (int i = 0; i < 3; i++)
			{
				string name = _strTreeNamePrefix + (i + 1);
				_textTreeNameAry[i] = _rootMC.getChildByName<TextField>(name);
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

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool result = false;
			string[] c7088de59e49f7108f520cf7e0bae167e = c7e77aa637b9ae1290617ecc771e6c274.c7088de59e49f7108f520cf7e0bae167e;
			int num = 0;
			if (movieClip.name.Contains("mcSkillProgress"))
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
				result = true;
				string name = movieClip.name;
				char[] array = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
				array[0] = '_';
				c7088de59e49f7108f520cf7e0bae167e = name.Split(array);
				num = Convert.ToInt32(c7088de59e49f7108f520cf7e0bae167e[1]);
				TierBGProgress tierBGProgress = new TierBGProgress();
				tierBGProgress.c130648b59a0c8debea60aa153f844879(movieClip);
				tierBGProgress.c986c33043099c7ac4f6e988bc47e375c(num);
				_dicProgressBG.Add(num, tierBGProgress);
			}
			else if (movieClip.name.Contains("mcSkillPt"))
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
				result = true;
				string name2 = movieClip.name;
				char[] array2 = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
				array2[0] = '_';
				c7088de59e49f7108f520cf7e0bae167e = name2.Split(array2);
				num = Convert.ToInt32(c7088de59e49f7108f520cf7e0bae167e[1]);
				Dictionary<int, SkillIconSlot> value = c3b617685fccba0720d430954ae04044b.c7088de59e49f7108f520cf7e0bae167e;
				_dicPositionSkillSlot.TryGetValue(num, out value);
				if (value == null)
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
					value = new Dictionary<int, SkillIconSlot>();
					_dicPositionSkillSlot.Add(num, value);
				}
				int key = Convert.ToInt32(c7088de59e49f7108f520cf7e0bae167e[2]);
				SkillIconSlot skillIconSlot = new SkillIconSlot();
				skillIconSlot.c130648b59a0c8debea60aa153f844879(movieClip);
				if (num != 1)
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
					if (num != 2)
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
						movieClip.visible = false;
					}
				}
				value.Add(key, skillIconSlot);
			}
			else
			{
				string name3 = movieClip.name;
				if (name3 != null)
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
					if (_003C_003Ef__switch_0024map2B == null)
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
						Dictionary<string, int> dictionary = new Dictionary<string, int>(4);
						dictionary.Add("mcClass", 0);
						dictionary.Add("btnReset", 1);
						dictionary.Add("mcCareerBG", 2);
						dictionary.Add("mcBtnClose", 3);
						_003C_003Ef__switch_0024map2B = dictionary;
					}
					int value2;
					if (_003C_003Ef__switch_0024map2B.TryGetValue(name3, out value2))
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
						switch (value2)
						{
						case 0:
							result = true;
							_mcClass = movieClip;
							break;
						case 1:
							result = true;
							_btnReset.c130648b59a0c8debea60aa153f844879(movieClip);
							_btnReset.addEventListener(MouseEvent.CLICK, cf6563846a162845bc34a8cb660536911);
							break;
						case 2:
							result = true;
							break;
						case 3:
							_btnClose.c130648b59a0c8debea60aa153f844879(movieClip);
							_btnClose.addEventListener(MouseEvent.CLICK, c83f5d510d483adac7af2c6c9fdf95b71);
							result = true;
							break;
						}
					}
				}
			}
			return result;
		}

		public void c334c04c5cc461446c5aa8c59fec26682()
		{
			c5b42a9b12146680344bf0e9f363746ad();
			c2fc143854d098a92d7edb0cf889f62f6();
		}

		public void c9f178d5dee7a09e328f5e6d6e807da40()
		{
			if (_textUnspentSkillPt == null)
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
				_textUnspentSkillPt.text = SkillTreeDataManager.c71f6ce28731edfd43c976fbd57c57bea().c4d24a9cadafffc413bf9c8df83bdec2d.ToString();
				return;
			}
		}

		protected void c2fc143854d098a92d7edb0cf889f62f6()
		{
			using (Dictionary<int, TierBGProgress>.KeyCollection.Enumerator enumerator = _dicProgressBG.Keys.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					int current = enumerator.Current;
					int num = SkillTreeDataManager.c71f6ce28731edfd43c976fbd57c57bea().cd6ef934b24b5c66ce894c3d83366b5e8(current);
					float c32e0e6207ac89ce45f0302861859f7b = SkillTreeDataManager.c71f6ce28731edfd43c976fbd57c57bea().cc372931d6207ce6ae7b685ff7f8ca879(num, current);
					TierBGProgress tierBGProgress = _dicProgressBG[current];
					tierBGProgress.c99595b74276138cc095f9087059d16e3(num, c32e0e6207ac89ce45f0302861859f7b);
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
					return;
				}
			}
		}

		protected void c5b42a9b12146680344bf0e9f363746ad()
		{
			if (_dicSkillSlot.Count == 0)
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
						return;
					}
				}
			}
			XsdSettings.SkillTree c08678cb5a9f2ec077be4dd868efd = SkillTreeDataManager.c71f6ce28731edfd43c976fbd57c57bea().c08678cb5a9f2ec077be4dd868efd1453;
			SkillTreeTier[] tierList = c08678cb5a9f2ec077be4dd868efd.m_tierList;
			foreach (SkillTreeTier skillTreeTier in tierList)
			{
				int id = skillTreeTier.m_id;
				NodeGroup[] nodeGroupList = skillTreeTier.m_nodeGroupList;
				foreach (NodeGroup nodeGroup in nodeGroupList)
				{
					int id2 = nodeGroup.m_id;
					bool flag = SkillTreeDataManager.c71f6ce28731edfd43c976fbd57c57bea().c5ecba50bdb5dc4dcc6028fbc4131f8bd(id, id2);
					SkillNode[] nodeList = nodeGroup.m_nodeList;
					foreach (SkillNode skillNode in nodeList)
					{
						int num = Convert.ToInt32(skillNode.m_id);
						SkillIconSlot skillIconSlot = _dicSkillSlot[num];
						if (skillIconSlot == null)
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
							DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "Can not get skill slot of skill " + num);
							continue;
						}
						skillIconSlot.cee4dbe0df59423dd4db33ca55ae178f1(flag);
						if (!flag)
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
						int num2 = SkillTreeDataManager.c71f6ce28731edfd43c976fbd57c57bea().cea0fda735aa58693de81cd5dabada6f7(num);
						Skill c02f15d17d3be88f612695c422dc620bd = c1ee7921b0c3cce194fb7cae41b5a9d82<SkillTreeServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cc68b2da7036261f61f86280fd6e61748(num);
						SkillNodeTips cf11827593d70bd2d2c0ef6e439b1c9d = new SkillNodeTips(c02f15d17d3be88f612695c422dc620bd, num2);
						skillIconSlot.cf11827593d70bd2d2c0ef6e439b1c9d9 = cf11827593d70bd2d2c0ef6e439b1c9d;
						skillIconSlot.ca319d61fca7270c1e640c72e5012eb6c(num2);
					}
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							goto end_IL_0157;
						}
						continue;
						end_IL_0157:
						break;
					}
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						goto end_IL_0172;
					}
					continue;
					end_IL_0172:
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
				for (int l = 0; l < 3; l++)
				{
					TextField textField = _textTreeNameAry[l];
					if (textField == null)
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
					textField.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(c08678cb5a9f2ec077be4dd868efd.m_groupNameList[l]));
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

		protected void cf6563846a162845bc34a8cb660536911(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			if (_onClickReset == null)
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
				_onClickReset();
				return;
			}
		}

		protected void c83f5d510d483adac7af2c6c9fdf95b71(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			if (_onClickClose == null)
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
				_onClickClose();
				return;
			}
		}
	}

	public class SkillIconSlot : ceaa621c569baf012ce466a5c368364e3
	{
		public enum SkillSlotStatus
		{
			eNone = 0,
			eLock = 1,
			eUnlock = 2,
			eUpgrade = 3,
			eComplete = 4
		}

		protected MovieClip _rootMC;

		protected int _iTierID;

		protected int _iSlotIndex;

		protected int _iCurGrade = -1;

		protected int _iUnSpentSkillPt;

		protected bool _bUnlocked;

		protected SkillSlotStatus _slotStatus;

		protected AvatarType _avatarType = AvatarType.TOTAL;

		protected Skill _skill;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b _btnMouseCover;

		public void c73e2661815f684ef5dd4807355ef628c(Skill c02f15d17d3be88f612695c422dc620bd, int c026d78bf74853e7058639078ccf224f7, AvatarType c951097a6ef3eb670bc38dce2cd336b7a)
		{
			_skill = c02f15d17d3be88f612695c422dc620bd;
			_rootMC.visible = true;
			_iTierID = c026d78bf74853e7058639078ccf224f7;
			_avatarType = c951097a6ef3eb670bc38dce2cd336b7a;
			MovieClip childByName = _rootMC.getChildByName<MovieClip>("mcSkillTreeIcon");
			uniSkillTreeView uniSkillTreeView2 = (uniSkillTreeView)c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<SkillTreeView>();
			if (_iTierID != 1)
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
				if (_iTierID != 2)
				{
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
						if (uniSkillTreeView2 != null)
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
							if (_skill != null)
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
								MovieClip childByName2 = childByName.getChildByName<MovieClip>(_skill.m_icon);
								if (childByName2 != null)
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
									childByName.removeChild(childByName2);
								}
								uniSkillTreeView2.c6a21327f8a1406da47c07d9ef9662d87(childByName, _skill.m_icon);
							}
						}
					}
					goto IL_0135;
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
			MovieClip childByName3 = _rootMC.getChildByName<MovieClip>("mcClassIcon");
			if (childByName3 != null)
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
				if (_avatarType != AvatarType.TOTAL)
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
					childByName3.gotoAndStop(_avatarType.ToString());
				}
			}
			goto IL_0135;
			IL_0135:
			c46f083a1c6dc7b33c99f7a6787447fc3();
		}

		public void ca319d61fca7270c1e640c72e5012eb6c(int c5bb5b2c0730b1a22c2b32d6390a3c632)
		{
			_iCurGrade = c5bb5b2c0730b1a22c2b32d6390a3c632;
			c46f083a1c6dc7b33c99f7a6787447fc3();
		}

		public void cee4dbe0df59423dd4db33ca55ae178f1(bool ca6bdb36ef5c7408d2206bd7042017526)
		{
			_bUnlocked = ca6bdb36ef5c7408d2206bd7042017526;
			c46f083a1c6dc7b33c99f7a6787447fc3();
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			_rootMC = base.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
			_rootMC.removeAllEventListeners(MouseEvent.CLICK);
			_rootMC.addEventListener(MouseEvent.CLICK, cbfe1a41acbaa3e09dabd1e800be3ad56);
			if (_btnMouseCover == null)
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
				_btnMouseCover = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			}
			MovieClip childByName = _rootMC.getChildByName<MovieClip>("mcMouseCover");
			if (childByName == null)
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
				_btnMouseCover.c130648b59a0c8debea60aa153f844879(childByName);
				return;
			}
		}

		protected void cbfe1a41acbaa3e09dabd1e800be3ad56(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			if (_slotStatus != SkillSlotStatus.eUnlock)
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
				if (_slotStatus != SkillSlotStatus.eUpgrade)
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
					break;
				}
			}
			uniSkillTreeView uniSkillTreeView2 = (uniSkillTreeView)c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<SkillTreeView>();
			if (uniSkillTreeView2 == null)
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
				if (_skill == null)
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
					uniSkillTreeView2.cb2129d5ac409250d4c0820338b1540f1(_skill.m_id);
					return;
				}
			}
		}

		protected void c46f083a1c6dc7b33c99f7a6787447fc3()
		{
			int maxGrade;
			bool flag;
			if (_bUnlocked)
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
				if (_iCurGrade != -1)
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
					if (_skill == null)
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
					maxGrade = _skill.m_maxGrade;
					if (_iCurGrade == 0)
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
						_rootMC.gotoAndStop("unlock");
						_slotStatus = SkillSlotStatus.eUnlock;
					}
					else if (_iCurGrade < maxGrade)
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
						_rootMC.gotoAndStop("upgrade");
						_slotStatus = SkillSlotStatus.eUpgrade;
					}
					else if (_iCurGrade == maxGrade)
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
						_rootMC.gotoAndStop("complete");
						flag = false;
						if (_iTierID != 1)
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
							if (_iTierID != 2)
							{
								flag = _slotStatus == SkillSlotStatus.eUpgrade;
								goto IL_0116;
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
						flag = _slotStatus == SkillSlotStatus.eUnlock;
						goto IL_0116;
					}
					goto IL_0156;
				}
			}
			_rootMC.gotoAndStop("lock");
			_slotStatus = SkillSlotStatus.eLock;
			goto IL_01c9;
			IL_01c9:
			_btnMouseCover.cbf402c82d0fffee7c8f37c98e456b8f8 = _slotStatus != SkillSlotStatus.eLock;
			if (_skill == null)
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
				MovieClip childByName = _rootMC.getChildByName<MovieClip>("mcSkillTreeIcon");
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
					MovieClip childByName2 = childByName.getChildByName<MovieClip>(_skill.m_icon);
					if (childByName2 == null)
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
						childByName2.alpha = childByName.alpha;
						return;
					}
				}
			}
			IL_0156:
			if (_iCurGrade >= 0)
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
				TextField childByName3 = _rootMC.getChildByName<TextField>("textSkillPt");
				if (childByName3 != null)
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
					string text = _iCurGrade + "/" + maxGrade;
					childByName3.text = text;
				}
			}
			goto IL_01c9;
			IL_0116:
			if (flag)
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
				MovieClip childByName4 = _rootMC.getChildByName<MovieClip>("mcFlash");
				if (childByName4 != null)
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
					childByName4.gotoAndPlay(1);
				}
			}
			_slotStatus = SkillSlotStatus.eComplete;
			goto IL_0156;
		}
	}

	public class TierBGProgress : c196099a1254db61d3be10d70e14e7422
	{
		protected Dictionary<int, MovieClip> _dicArcher = new Dictionary<int, MovieClip>();

		protected MovieClip _maskMC;

		protected MovieClip _slaveMC;

		protected MovieClip _rootMC;

		protected int _iOrder;

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool result = false;
			if (movieClip.name.Contains("mcArcher"))
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
				string name = movieClip.name;
				char[] array = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
				array[0] = '_';
				string[] array2 = name.Split(array);
				int key = Convert.ToInt32(array2[1]);
				_dicArcher.Add(key, movieClip);
				result = true;
			}
			else if (movieClip.name == "mcMask")
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
				movieClip.visible = false;
				_maskMC = movieClip;
				result = true;
			}
			else if (movieClip.name == "mcSlave")
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
				_slaveMC = movieClip;
				result = true;
			}
			return result;
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			_rootMC = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			_rootMC.gotoAndStop(10);
		}

		public void c986c33043099c7ac4f6e988bc47e375c(int c251b838130da0d6727597523fbf47173)
		{
			_iOrder = c251b838130da0d6727597523fbf47173;
			if (_iOrder == 1)
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
						_slaveMC.gotoAndStop("green");
						return;
					}
				}
			}
			if (_iOrder == 2)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						_slaveMC.gotoAndStop("blue");
						return;
					}
				}
			}
			if (_iOrder != 3)
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
				_slaveMC.gotoAndStop("red");
				return;
			}
		}

		public void c99595b74276138cc095f9087059d16e3(int c4a060427f1f65b24d4037e1c198998cd, float c32e0e6207ac89ce45f0302861859f7b1)
		{
			if (c4a060427f1f65b24d4037e1c198998cd <= 2)
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
				_maskMC.y = 0f;
			}
			else
			{
				if (c32e0e6207ac89ce45f0302861859f7b1 < 0f)
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
					c32e0e6207ac89ce45f0302861859f7b1 = 0f;
				}
				if (c32e0e6207ac89ce45f0302861859f7b1 > 1f)
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
					c32e0e6207ac89ce45f0302861859f7b1 = 1f;
				}
				MovieClip movieClip = _dicArcher[c4a060427f1f65b24d4037e1c198998cd];
				MovieClip movieClip2 = _dicArcher[c4a060427f1f65b24d4037e1c198998cd + 1];
				float num = movieClip2.y - movieClip.y;
				float y = movieClip.y + num * c32e0e6207ac89ce45f0302861859f7b1;
				_maskMC.y = y;
			}
			Rectangle bounds = _maskMC.getBounds(_slaveMC);
			_slaveMC.clipRect = bounds.rect;
			_maskMC.visible = false;
		}

		public void c9b0ea1029fa2792e65fc0a564791d576(string c2517975451e334c7dfe394eb021ae146)
		{
			MovieClip childByName = _rootMC.getChildByName<MovieClip>("mcBranchBG");
			if (childByName == null)
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
				childByName.gotoAndStop(c2517975451e334c7dfe394eb021ae146);
				return;
			}
		}
	}

	public class SkillNodeTips : ca28a90236225d84ff4176d76e8446d33
	{
		protected Skill _skill;

		protected int _iCurGrade;

		protected static SkillInfoPanel _skillInfoPanel;

		public SkillNodeTips(Skill c02f15d17d3be88f612695c422dc620bd, int cdc8b4fbb6ffde2b0bdd62713b5b1b929)
		{
			_skill = c02f15d17d3be88f612695c422dc620bd;
			_iCurGrade = cdc8b4fbb6ffde2b0bdd62713b5b1b929;
		}

		public override DisplayObject c710592d0cc98297d2151ac3095b4f412()
		{
			if (_skill == null)
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
						return null;
					}
				}
			}
			c8958be2e7cc65a2356b1cd729028de49();
			return _skillInfoPanel.c89ef242f4744e0f1c4ffea4da8b79bc1;
		}

		public static void caed26b5e11a7c953e35e9d6dc5e0cd5e()
		{
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("Tips.swf", "Panel_Skill_Tips", c1141a8fde9aa0f410bc4a7fdd2e3ef7c);
		}

		protected static void c1141a8fde9aa0f410bc4a7fdd2e3ef7c(MovieClip c38166bc7092867b1eae7a76b075dbdbd)
		{
			_skillInfoPanel = new SkillInfoPanel();
			_skillInfoPanel.c130648b59a0c8debea60aa153f844879(c38166bc7092867b1eae7a76b075dbdbd);
		}

		protected void c8958be2e7cc65a2356b1cd729028de49()
		{
			if (_skillInfoPanel == null)
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
				int num;
				if (_skill.m_id != 51)
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
					if (_skill.m_id != 52)
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
						if (_skill.m_id != 101)
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
							if (_skill.m_id != 102)
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
								if (_skill.m_id != 151)
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
									if (_skill.m_id != 152)
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
										if (_skill.m_id != 1)
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
											num = ((_skill.m_id != 2) ? 1 : 0);
											goto IL_0101;
										}
									}
								}
							}
						}
					}
				}
				num = 0;
				goto IL_0101;
				IL_0101:
				bool c339e29dc3fdd9d4819ba8658eb12dd = (byte)num != 0;
				_skillInfoPanel.c339e29dc3fdd9d4819ba8658eb12dd02 = c339e29dc3fdd9d4819ba8658eb12dd;
				_skillInfoPanel.c6c770498718aaed70bc669c699ad7cfa(_skill);
				_skillInfoPanel.c2735c0549c35c53de1e43d9ee87ef2c7(_iCurGrade);
				return;
			}
		}
	}

	public class SkillInfoPanel : c196099a1254db61d3be10d70e14e7422
	{
		protected Skill _skill;

		protected MovieClip _rootMC;

		protected MovieClip mcTop;

		protected MovieClip mcBottom;

		protected int _iCurGrade;

		protected bool _bShowAttributeDes = true;

		protected static int MAX_ATTRIBUTE_COUNT = 3;

		protected TextField _textSkillName;

		protected TextField _textSkillDes;

		protected TextField _textNextGrade;

		protected TextField[] _curAttributeName = c19e050a19e36cad0b82e93ce13289601.c0a0cdf4a196914163f7334d9b0781a04(MAX_ATTRIBUTE_COUNT);

		protected TextField[] _curAttributeValue = c19e050a19e36cad0b82e93ce13289601.c0a0cdf4a196914163f7334d9b0781a04(MAX_ATTRIBUTE_COUNT);

		protected TextField[] _nextAttributeName = c19e050a19e36cad0b82e93ce13289601.c0a0cdf4a196914163f7334d9b0781a04(MAX_ATTRIBUTE_COUNT);

		protected TextField[] _nextAttributeValue = c19e050a19e36cad0b82e93ce13289601.c0a0cdf4a196914163f7334d9b0781a04(MAX_ATTRIBUTE_COUNT);

		public bool c339e29dc3fdd9d4819ba8658eb12dd02
		{
			set
			{
				_bShowAttributeDes = value;
			}
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			_rootMC = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			_rootMC.mouseEnabled = false;
			mcTop = _rootMC.getChildByName<MovieClip>("mcTop");
			mcBottom = _rootMC.getChildByName<MovieClip>("mcBottom");
			_textSkillName = mcTop.getChildByName<TextField>("textSkillName");
			_textSkillDes = mcTop.getChildByName<TextField>("textSkillDes");
			_textNextGrade = mcBottom.getChildByName<TextField>("textNextGrade");
			mcBottom.visible = false;
			for (int i = 0; i < MAX_ATTRIBUTE_COUNT; i++)
			{
				string name = "textCurParameter_" + i;
				_curAttributeName[i] = mcTop.getChildByName<TextField>(name);
				if (_curAttributeName[i] != null)
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
					_curAttributeName[i].visible = false;
				}
				name = "textCurValue_" + i;
				_curAttributeValue[i] = mcTop.getChildByName<TextField>(name);
				if (_curAttributeValue[i] != null)
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
					_curAttributeValue[i].visible = false;
					_curAttributeValue[i].textFormat.color = new Color(1f, 0.5f, 0f);
				}
				name = "textNextParameter_" + i;
				_nextAttributeName[i] = mcBottom.getChildByName<TextField>(name);
				if (_nextAttributeName[i] != null)
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
					_nextAttributeName[i].visible = false;
					_nextAttributeName[i].textFormat.color = new Color(1f, 0.5f, 0f);
				}
				name = "textNextValue_" + i;
				_nextAttributeValue[i] = mcBottom.getChildByName<TextField>(name);
				if (_nextAttributeValue[i] == null)
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
				_nextAttributeValue[i].visible = false;
				_nextAttributeValue[i].textFormat.color = new Color(1f, 0.5f, 0f);
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

		public void c6c770498718aaed70bc669c699ad7cfa(Skill c02f15d17d3be88f612695c422dc620bd)
		{
			_skill = c02f15d17d3be88f612695c422dc620bd;
			cee3f7e1f2fe80146187019ef16248436();
		}

		public void c2735c0549c35c53de1e43d9ee87ef2c7(int cdc8b4fbb6ffde2b0bdd62713b5b1b929)
		{
			_iCurGrade = cdc8b4fbb6ffde2b0bdd62713b5b1b929;
			cee3f7e1f2fe80146187019ef16248436();
		}

		protected void cee3f7e1f2fe80146187019ef16248436()
		{
			if (_skill == null)
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
			if (_textSkillName != null)
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
				_textSkillName.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(_skill.m_name));
			}
			if (_textSkillDes != null)
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
				_textSkillDes.multiline = true;
				_textSkillDes.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(_skill.m_description));
			}
			Effect[] effectList = _skill.m_effectList;
			bool visible = _iCurGrade != 0;
			bool flag = _iCurGrade < _skill.m_maxGrade;
			MovieClip movieClip = mcBottom;
			int visible2;
			if (flag)
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
				visible2 = (_bShowAttributeDes ? 1 : 0);
			}
			else
			{
				visible2 = 0;
			}
			movieClip.visible = (byte)visible2 != 0;
			int i = 0;
			if (_bShowAttributeDes)
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
				for (; i < effectList.Length; i++)
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
					if (i < MAX_ATTRIBUTE_COUNT)
					{
						Effect effect = effectList[i];
						if (_curAttributeName[i] == null)
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
						DisplayType displayType = SkillDisplayStore.c44a2b51cbcd8bf73167ba6a2f008a34b.m_skillDisplaySetup.cadef9a192fc5bdbc6abde1b1df3c3e98(effect.m_type);
						float num = effect.m_firstGrade + effect.m_perGrade * (float)(_iCurGrade - 1);
						float num2 = effect.m_firstGrade + effect.m_perGrade * (float)_iCurGrade;
						StringBuilder stringBuilder = new StringBuilder();
						StringBuilder stringBuilder2 = new StringBuilder();
						if (num >= 0f)
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
							stringBuilder.Append(" + ");
						}
						else
						{
							num = 0f - num;
							stringBuilder.Append(" - ");
						}
						if (num2 >= 0f)
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
							stringBuilder2.Append(" + ");
						}
						else
						{
							num2 = 0f - num2;
							stringBuilder2.Append(" - ");
						}
						if (displayType == DisplayType.Percentage)
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
							stringBuilder.Append(num * 100f).Append(" % ");
							stringBuilder2.Append(num2 * 100f).Append(" % ");
						}
						else
						{
							stringBuilder.Append(num);
							stringBuilder2.Append(num2);
						}
						_curAttributeValue[i].text = stringBuilder.ToString();
						_curAttributeValue[i].visible = visible;
						_curAttributeName[i].text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(effect.m_type.ToString()));
						_curAttributeName[i].visible = visible;
						_nextAttributeName[i].text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(effect.m_type.ToString()));
						_nextAttributeName[i].visible = flag;
						_nextAttributeValue[i].text = stringBuilder2.ToString();
						_nextAttributeValue[i].visible = flag;
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
			for (; i < MAX_ATTRIBUTE_COUNT; i++)
			{
				_curAttributeName[i].visible = false;
				_curAttributeValue[i].visible = false;
				_nextAttributeName[i].visible = false;
				_nextAttributeValue[i].visible = false;
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

	protected SkillTreePanel _skillTreeRoot;

	protected MovieClip _rootMC;

	protected c196099a1254db61d3be10d70e14e7422 _root;

	protected Dictionary<string, MovieClip> _dicSkillIcon = new Dictionary<string, MovieClip>();

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		_bActive = false;
		SkillNodeTips.caed26b5e11a7c953e35e9d6dc5e0cd5e();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("Skill_Tree.swf", "whole", c1141a8fde9aa0f410bc4a7fdd2e3ef7c);
		if (_skillTreeData == null)
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
			c35fe8b4a94d6035b8ce6ba18ca926d34();
			return;
		}
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		_dicSkillIcon.Clear();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_root);
		_skillTreeRoot = null;
		_root = c9c0c8f01d2944aa6e09f167c382ebe52.c7088de59e49f7108f520cf7e0bae167e;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("Skill_Tree.swf");
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("Skill_Tree_icon.swf");
	}

	public override void c14b12898fa8e71d52bd003cdc77e9d5d()
	{
		base.c14b12898fa8e71d52bd003cdc77e9d5d();
	}

	private void c1141a8fde9aa0f410bc4a7fdd2e3ef7c(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_rootMC = cbe9ca8ddb3cdc2312e6ff8411b2db2c8;
		_rootMC.visible = false;
		_rootMC.addFrameScript("KeyFrame_1", c2d4b6616c5d13a240f0d050133a6a00b);
		_rootMC.addFrameScript("KeyFrame_2", c2d4b6616c5d13a240f0d050133a6a00b);
		_rootMC.addFrameScript("KeyFrame_3", c2d4b6616c5d13a240f0d050133a6a00b);
		_rootMC.addFrameScript("KeyFrame_4", c2d4b6616c5d13a240f0d050133a6a00b);
		_rootMC.addFrameScript("normal", c2d4b6616c5d13a240f0d050133a6a00b);
		_rootMC.addFrameScript("fadeout", c2d4b6616c5d13a240f0d050133a6a00b);
		_rootMC.addFrameScript("fadeoutEnd", c90b8f3c7c55511377f8b8d0554b881be);
		_root = new c196099a1254db61d3be10d70e14e7422();
		_skillTreeRoot = new SkillTreePanel();
		_root.c130648b59a0c8debea60aa153f844879(_rootMC);
		_bActive = true;
	}

	protected void c35fe8b4a94d6035b8ce6ba18ca926d34()
	{
		SkillTreeTier[] tierList = _skillTreeData.m_tierList;
		foreach (SkillTreeTier skillTreeTier in tierList)
		{
			if (skillTreeTier.m_id == 1)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (skillTreeTier.m_id == 2)
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
			NodeGroup[] nodeGroupList = skillTreeTier.m_nodeGroupList;
			foreach (NodeGroup nodeGroup in nodeGroupList)
			{
				SkillNode[] nodeList = nodeGroup.m_nodeList;
				foreach (SkillNode skillNode in nodeList)
				{
					Skill skill = c1ee7921b0c3cce194fb7cae41b5a9d82<SkillTreeServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cc68b2da7036261f61f86280fd6e61748(Convert.ToInt32(skillNode.m_id));
					(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("Skill_Tree_icon.swf", skill.m_icon, c910207b182ba6deb649b233dac255af0);
				}
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						goto end_IL_00df;
					}
					continue;
					end_IL_00df:
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
				break;
			}
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

	private void c910207b182ba6deb649b233dac255af0(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		if (cbe9ca8ddb3cdc2312e6ff8411b2db2c8 == null)
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
		cbe9ca8ddb3cdc2312e6ff8411b2db2c8.name = cbe9ca8ddb3cdc2312e6ff8411b2db2c8.getSymbolName();
		if (_dicSkillIcon.ContainsKey(cbe9ca8ddb3cdc2312e6ff8411b2db2c8.name))
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
			_dicSkillIcon.Add(cbe9ca8ddb3cdc2312e6ff8411b2db2c8.getSymbolName(), cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
			return;
		}
	}

	public void c6a21327f8a1406da47c07d9ef9662d87(MovieClip c38166bc7092867b1eae7a76b075dbdbd, string cc1e419f52102dfd441b21e702e5c1c88)
	{
		if (c38166bc7092867b1eae7a76b075dbdbd == null)
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
			if (cc1e419f52102dfd441b21e702e5c1c88.Length == 0)
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
			c38166bc7092867b1eae7a76b075dbdbd.gotoAndStop("EndFrame");
			MovieClip childByName = c38166bc7092867b1eae7a76b075dbdbd.getChildByName<MovieClip>("mcIconImg");
			childByName.visible = false;
			MovieClip childByName2 = c38166bc7092867b1eae7a76b075dbdbd.getChildByName<MovieClip>(cc1e419f52102dfd441b21e702e5c1c88);
			if (childByName2 != null)
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
				MovieClip value = c656b7be10c614ae4a7eb17c462d2f675.c7088de59e49f7108f520cf7e0bae167e;
				_dicSkillIcon.TryGetValue(cc1e419f52102dfd441b21e702e5c1c88, out value);
				if (value == null)
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
				MovieClip movieClip = value.newInstance();
				movieClip.x = 0f;
				movieClip.y = 0f;
				movieClip.name = value.name;
				c38166bc7092867b1eae7a76b075dbdbd.addChildAt(movieClip, c38166bc7092867b1eae7a76b075dbdbd.getChildIndex(childByName));
				return;
			}
		}
	}

	private void c2d4b6616c5d13a240f0d050133a6a00b(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		MovieClip childByName = _rootMC.getChildByName<MovieClip>("mcRoot");
		if (childByName == null)
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
			MovieClip movieClip = _skillTreeRoot.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
			_skillTreeRoot.cac7688b05e921e2be3f92479ba44b4a8();
			if (movieClip == childByName)
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
				_skillTreeRoot.cd1e17b6ce3586ba6a22d6a71ff17d01c();
			}
			else
			{
				_skillTreeRoot.c130648b59a0c8debea60aa153f844879(childByName);
			}
			if (_skillTreeData == null)
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
				_skillTreeRoot.c076bcbb538ab7a02f13183c99cc8c79e(cab3d64fce75ee3fef1f99660a92504f4, cac876187a3cb76b907712a8437486059);
				cfe214abf428181629c26312b09c426cd(SkillTreeDataManager.c71f6ce28731edfd43c976fbd57c57bea().c1c854731c4ee6c7c125777fa11db8c5d);
				c9f0fdb45a77c27d9088ce909195d9b3b(SkillTreeDataManager.c71f6ce28731edfd43c976fbd57c57bea().cd2a5c391c1d46ff36a39370815c88946, SkillTreeDataManager.c71f6ce28731edfd43c976fbd57c57bea().c4d24a9cadafffc413bf9c8df83bdec2d);
				return;
			}
		}
	}

	private void c90b8f3c7c55511377f8b8d0554b881be(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		_rootMC.visible = false;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_root);
	}

	private void cac876187a3cb76b907712a8437486059()
	{
		c150264a18c2cb408479d3f072cac8cc1 = false;
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
		_rootMC.visible = _bVisible;
		if (_bVisible)
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
					(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cb4341b3564e3d55dc9f38df4b813c5da(_root);
					_rootMC.gotoAndPlay("fadein");
					cfe214abf428181629c26312b09c426cd(SkillTreeDataManager.c71f6ce28731edfd43c976fbd57c57bea().c1c854731c4ee6c7c125777fa11db8c5d);
					return;
				}
			}
		}
		_rootMC.gotoAndPlay("fadeout");
	}

	protected override void c9f0fdb45a77c27d9088ce909195d9b3b(int c37c8cc761dd6f739a4c896e64e44fdd5, int c43c216df6aadde10be3f9bdf566009ca)
	{
		base.c9f0fdb45a77c27d9088ce909195d9b3b(c37c8cc761dd6f739a4c896e64e44fdd5, c43c216df6aadde10be3f9bdf566009ca);
		if (_skillTreeRoot == null)
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
			_skillTreeRoot.c9f178d5dee7a09e328f5e6d6e807da40();
			return;
		}
	}

	protected override void cfe214abf428181629c26312b09c426cd(List<InvestedSkill> c2a84e1af1999f8830e06d6fd6cb8ebb9)
	{
		base.cfe214abf428181629c26312b09c426cd(c2a84e1af1999f8830e06d6fd6cb8ebb9);
		if (_skillTreeRoot == null)
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
			_skillTreeRoot.c334c04c5cc461446c5aa8c59fec26682();
			return;
		}
	}
}
