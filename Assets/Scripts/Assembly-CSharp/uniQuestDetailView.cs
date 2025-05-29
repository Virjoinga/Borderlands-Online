using System;
using System.Text;
using A;
using UnityEngine;
using XsdSettings;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

public class uniQuestDetailView : QuestDetailView
{
	public class QuestDetail : c196099a1254db61d3be10d70e14e7422
	{
		protected const int SLOTCOUNT = 4;

		protected MovieClip _rootMC;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b _btnCancel;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b _btnAccept;

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b _btnSubmit;

		protected DeleOnClickAccept _onClickAccept;

		protected DeleOnClickCancel _onClickCancel;

		protected bool _bBtnVisible = true;

		protected c87da635fd7858aaa8f8053a95f123b32[] _rewardSlotAry = cd37cd7953f9ca8b68e2410db7162caa8.c0a0cdf4a196914163f7334d9b0781a04(4);

		protected WeaponGeneratorService _weaponGenerateService;

		protected ItemGeneratorService _itemGenerateService;

		public DeleOnClickAccept c13245fc997bb28d302a958edc7a71b98
		{
			set
			{
				_onClickAccept = value;
			}
		}

		public bool c0c96bf89d6652c6c16b48f708fe5c87a
		{
			set
			{
				_bBtnVisible = value;
			}
		}

		public DeleOnClickCancel ccc9c53ec64b790d308a821bbc73cc9d2
		{
			set
			{
				_onClickCancel = value;
			}
		}

		public QuestDetail()
		{
			_btnCancel = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			_btnAccept = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
			_btnSubmit = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
		}

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool result = false;
			if (movieClip.name.Contains("mcRewardSlot_"))
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
				c87da635fd7858aaa8f8053a95f123b32 c87da635fd7858aaa8f8053a95f123b = new c87da635fd7858aaa8f8053a95f123b32();
				c87da635fd7858aaa8f8053a95f123b.c130648b59a0c8debea60aa153f844879(movieClip);
				string name = movieClip.name;
				char[] array = cd9dc39991e9f0a2fbbd20ffc56eaa931.c0a0cdf4a196914163f7334d9b0781a04(1);
				array[0] = '_';
				string[] array2 = name.Split(array);
				if (array2.Length >= 2)
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
					int num = Convert.ToInt32(array2[1]) - 1;
					if (num < 4)
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
						_rewardSlotAry[num] = c87da635fd7858aaa8f8053a95f123b;
					}
				}
			}
			return result;
		}

		protected void c49a9d21f36de53188f91b0e3bf7aa651(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			if (_onClickCancel == null)
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
				_onClickCancel();
				return;
			}
		}

		protected void cd9c7ad114842fa34282adae1521a48b8(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			if (_onClickAccept == null)
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
				_onClickAccept();
				return;
			}
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			_rootMC = base.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
			_weaponGenerateService = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<WeaponGeneratorService>();
			_itemGenerateService = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<ItemGeneratorService>();
		}

		public void c43cbb41bf755dfa61de619fc6e86ab31(bool c74232243aff1dcbf2e8fc243633bb51a)
		{
			_rootMC.visible = c74232243aff1dcbf2e8fc243633bb51a;
		}

		public void c12c1611d592facfca7f3d95d2ce78e8a(QuestUIData c03a4aef4270a8b2a2426ba59fb48cf53)
		{
			if (c03a4aef4270a8b2a2426ba59fb48cf53 == null)
			{
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
			if (c03a4aef4270a8b2a2426ba59fb48cf53._quest != null)
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
				if (_bBtnVisible)
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
					QuestState mStatus = c03a4aef4270a8b2a2426ba59fb48cf53._questProgress.mStatus;
					_rootMC.gotoAndStop(mStatus.ToString());
					MovieClip c7088de59e49f7108f520cf7e0bae167e = c656b7be10c614ae4a7eb17c462d2f675.c7088de59e49f7108f520cf7e0bae167e;
					if (mStatus == QuestState.Available)
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
						c7088de59e49f7108f520cf7e0bae167e = _rootMC.getChildByName<MovieClip>("btnAccept");
						if (c7088de59e49f7108f520cf7e0bae167e != null)
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
							_btnAccept.removeAllEventListeners(MouseEvent.CLICK);
							_btnAccept.c130648b59a0c8debea60aa153f844879(c7088de59e49f7108f520cf7e0bae167e);
							_btnAccept.addEventListener(MouseEvent.CLICK, cd9c7ad114842fa34282adae1521a48b8);
						}
					}
					else if (mStatus == QuestState.Completed)
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
						c7088de59e49f7108f520cf7e0bae167e = _rootMC.getChildByName<MovieClip>("btnSubmit");
						if (c7088de59e49f7108f520cf7e0bae167e != null)
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
							_btnSubmit.removeAllEventListeners(MouseEvent.CLICK);
							_btnSubmit.c130648b59a0c8debea60aa153f844879(c7088de59e49f7108f520cf7e0bae167e);
							_btnSubmit.addEventListener(MouseEvent.CLICK, cd9c7ad114842fa34282adae1521a48b8);
						}
					}
					_btnCancel.removeAllEventListeners(MouseEvent.CLICK);
					_btnCancel.c130648b59a0c8debea60aa153f844879(_rootMC.getChildByName<MovieClip>("btnCancal"));
					_btnCancel.addEventListener(MouseEvent.CLICK, c49a9d21f36de53188f91b0e3bf7aa651);
					goto IL_01ed;
				}
			}
			MovieClip childByName = _rootMC.getChildByName<MovieClip>("btnAccept");
			MovieClip childByName2 = _rootMC.getChildByName<MovieClip>("btnCancal");
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
				childByName.visible = false;
			}
			if (childByName2 != null)
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
				childByName2.visible = false;
			}
			goto IL_01ed;
			IL_01ed:
			TextField childByName3 = _rootMC.getChildByName<TextField>("textQuestDescription");
			if (childByName3 != null)
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
				childByName3.visible = true;
				childByName3.multiline = true;
				childByName3.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(c03a4aef4270a8b2a2426ba59fb48cf53._quest.mDescription));
			}
			TextField childByName4 = _rootMC.getChildByName<TextField>("textInstance");
			if (childByName4 != null)
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
				StringBuilder stringBuilder = new StringBuilder();
				if (c03a4aef4270a8b2a2426ba59fb48cf53._quest.mIsBoundInstance)
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
					int[] mBoundInstanceList = c03a4aef4270a8b2a2426ba59fb48cf53._quest.mBoundInstanceList;
					foreach (int c35f98ccbfa8c6bf09319c620b21b5dc in mBoundInstanceList)
					{
						Playlist playlist = MatchmakingService.c5ee19dc8d4cccf5ae2de225410458b86.c2718b579e09549a1cd47620188a40a38(c35f98ccbfa8c6bf09319c620b21b5dc);
						if (playlist == null)
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
						stringBuilder.Append(LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(playlist.m_name))).Append(" ");
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
				else
				{
					stringBuilder.Append(LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Quest_AnyInstance")));
				}
				childByName4.text = stringBuilder.ToString();
			}
			TextField childByName5 = _rootMC.getChildByName<TextField>("textDifficulty");
			if (childByName5 != null)
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
				string text = "Difficulty_";
				int mRequiredDifficulty = c03a4aef4270a8b2a2426ba59fb48cf53._quest.mRequiredDifficulty;
				if (mRequiredDifficulty == -1)
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
					text += "NoL";
				}
				else
				{
					text += mRequiredDifficulty;
				}
				text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(text));
				childByName5.text = text;
			}
			int num = 0;
			int num2 = 0;
			int j = 0;
			for (int k = 0; k < c03a4aef4270a8b2a2426ba59fb48cf53._quest.mRewards.Length; k++)
			{
				QuestReward questReward = c03a4aef4270a8b2a2426ba59fb48cf53._quest.mRewards[k];
				if (questReward.mType == QuestRewardType.BondCurrency)
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
					num = questReward.mCount;
					continue;
				}
				if (questReward.mType == QuestRewardType.Experience)
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
					num2 = questReward.mCount;
					continue;
				}
				if (questReward.mType != 0)
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
					if (questReward.mType != QuestRewardType.Shield)
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
						if (questReward.mType != QuestRewardType.ClassMode)
						{
							if (questReward.mType != QuestRewardType.Material)
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
							MovieClip movieClip = (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InventoryView>() as uniInventoryView).cf00e0520259191fd2faf4e52ef6f3ac0(questReward.mMaterialType);
							if (movieClip == null)
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
							if (j >= _rewardSlotAry.Length)
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
							if (_rewardSlotAry[j] != null)
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
								MovieClip childByName6 = _rewardSlotAry[j].cf60cea27899464ecfab889519bbd47e7.getChildByName<MovieClip>("icon");
								if (childByName6 != null)
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
									_rewardSlotAry[j].cf60cea27899464ecfab889519bbd47e7.removeChild(childByName6);
								}
								_rewardSlotAry[j].c1d4a927ba62b28412f982cec1c20bc7a = false;
								MovieClip movieClip2 = movieClip.newInstance();
								movieClip2.name = "icon";
								_rewardSlotAry[j].cf11827593d70bd2d2c0ef6e439b1c9d9 = c403f7706ca94554a763547a002570309.c7088de59e49f7108f520cf7e0bae167e;
								_rewardSlotAry[j].cf60cea27899464ecfab889519bbd47e7.stopAll();
								_rewardSlotAry[j].cf60cea27899464ecfab889519bbd47e7.addChild(movieClip2);
								_rewardSlotAry[j].quantity = questReward.mCount;
								_rewardSlotAry[j].c76cc6288aad6ff8d562a2365e727c68c.c150264a18c2cb408479d3f072cac8cc1 = false;
								_rewardSlotAry[j].c76cc6288aad6ff8d562a2365e727c68c.c533af2b08173b7c2e3e5405efc254ee3(c7e1395dd376890f1113e22916ff9ac07.c7088de59e49f7108f520cf7e0bae167e);
								_rewardSlotAry[j].c591d56a94543e3559945c497f37126c4 = c03a4aef4270a8b2a2426ba59fb48cf53;
							}
							j++;
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
					}
				}
				Texture2D cf83e762e4368c5dedaab3e73ad69452e = c9e48915b2a8c6753d0b1a12e50ad1d27.c7088de59e49f7108f520cf7e0bae167e;
				ItemDNA itemDNA = c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e;
				QuestRewardType mType = questReward.mType;
				if (mType != QuestRewardType.Shield)
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
					if (mType != QuestRewardType.ClassMode)
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
						if (mType != 0)
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
						}
						else if (_weaponGenerateService != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							itemDNA = ItemDNA.c8284b9f225995cc6a6e1888c9c037b06(_weaponGenerateService.c4e0dae6a16a8a80ddb5214a896b9df58(questReward.mRewardID));
						}
					}
					else if (_itemGenerateService != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						itemDNA = _itemGenerateService.c8be4fb00b4db963ae0ea814af0f6f03d(questReward.mRewardID);
					}
				}
				else if (_itemGenerateService != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					ShieldDNA shieldDNA = _itemGenerateService.cd07bbd862d5849fcdfb1b2299a9185eb(questReward.mRewardID);
					if (shieldDNA != null)
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
						itemDNA = ItemDNA.c8f331a9c3beba42f2ccd0923c0c67e0a(shieldDNA);
					}
				}
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
					cf83e762e4368c5dedaab3e73ad69452e = c06ca0e618478c23eba3419653a19760f<DNAPortrait>.c5ee19dc8d4cccf5ae2de225410458b86.c6965e945a09324a9af86f14518e0a697(itemDNA);
				}
				if (j >= _rewardSlotAry.Length)
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
				if (_rewardSlotAry[j] != null)
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
					MovieClip childByName7 = _rewardSlotAry[j].cf60cea27899464ecfab889519bbd47e7.getChildByName<MovieClip>("icon");
					if (childByName7 != null)
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
						_rewardSlotAry[j].cf60cea27899464ecfab889519bbd47e7.removeChild(childByName7);
					}
					if (_rewardSlotAry[j].c76cc6288aad6ff8d562a2365e727c68c != null)
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
						_rewardSlotAry[j].c591d56a94543e3559945c497f37126c4 = c03a4aef4270a8b2a2426ba59fb48cf53;
						_rewardSlotAry[j].c76cc6288aad6ff8d562a2365e727c68c.c150264a18c2cb408479d3f072cac8cc1 = true;
						_rewardSlotAry[j].c76cc6288aad6ff8d562a2365e727c68c.c533af2b08173b7c2e3e5405efc254ee3(cf83e762e4368c5dedaab3e73ad69452e);
						_rewardSlotAry[j].cf11827593d70bd2d2c0ef6e439b1c9d9 = new ItemTips(itemDNA);
						_rewardSlotAry[j].quantity = 0;
					}
				}
				j++;
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
			for (; j < 4; j++)
			{
				if (_rewardSlotAry[j] == null)
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
				if (_rewardSlotAry[j].c76cc6288aad6ff8d562a2365e727c68c == null)
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
				_rewardSlotAry[j].cf11827593d70bd2d2c0ef6e439b1c9d9 = c403f7706ca94554a763547a002570309.c7088de59e49f7108f520cf7e0bae167e;
				_rewardSlotAry[j].quantity = 0;
				_rewardSlotAry[j].c591d56a94543e3559945c497f37126c4 = c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e;
				_rewardSlotAry[j].c76cc6288aad6ff8d562a2365e727c68c.c150264a18c2cb408479d3f072cac8cc1 = false;
				_rewardSlotAry[j].c76cc6288aad6ff8d562a2365e727c68c.c533af2b08173b7c2e3e5405efc254ee3(c7e1395dd376890f1113e22916ff9ac07.c7088de59e49f7108f520cf7e0bae167e);
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				_rootMC.getChildByName<TextField>("textMoneyCount").text = num.ToString();
				_rootMC.getChildByName<TextField>("textExpCount").text = num2.ToString();
				MovieClip childByName8 = _rootMC.getChildByName<MovieClip>("mcQuestIcon");
				if (childByName8 == null)
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
					childByName8.gotoAndStop(c03a4aef4270a8b2a2426ba59fb48cf53._quest.mCategory.ToString());
					MovieClip childByName9 = childByName8.getChildByName<MovieClip>("mcIconColor");
					if (childByName9 == null)
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
						string to = "Available";
						if (c03a4aef4270a8b2a2426ba59fb48cf53._questProgress != null)
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
							to = c03a4aef4270a8b2a2426ba59fb48cf53._questProgress.mStatus.ToString();
						}
						childByName9.gotoAndStop(to);
						return;
					}
				}
			}
		}
	}

	protected QuestDetail _questDetail;

	protected c196099a1254db61d3be10d70e14e7422 _container;

	protected MovieClip _containerMC;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		_bActive = false;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("Quest.swf", "Panel_DetailRoot", c9a5189aa2c54892454fc07db5cd96c02);
	}

	protected void c9a5189aa2c54892454fc07db5cd96c02(MovieClip c38166bc7092867b1eae7a76b075dbdbd)
	{
		_questDetail = new QuestDetail();
		_questDetail.c13245fc997bb28d302a958edc7a71b98 = c02ed51fd65a976a6ef07902fa09bef51;
		_questDetail.ccc9c53ec64b790d308a821bbc73cc9d2 = c160c4effdbc25f551e67296293735016;
		c38166bc7092867b1eae7a76b075dbdbd.visible = false;
		c38166bc7092867b1eae7a76b075dbdbd.addFrameScript("DetailAppear", c57bf6bfe368af1a9b79d34417f9b57ba);
		c38166bc7092867b1eae7a76b075dbdbd.addFrameScript("FadeOut", cf8d5496eaeffeee86e21791e82ef3c11);
		c38166bc7092867b1eae7a76b075dbdbd.addFrameScript("KeyFrame_1", cf8d5496eaeffeee86e21791e82ef3c11);
		c38166bc7092867b1eae7a76b075dbdbd.addFrameScript("KeyFrame_2", cf8d5496eaeffeee86e21791e82ef3c11);
		c38166bc7092867b1eae7a76b075dbdbd.addFrameScript("KeyFrame_3", c90b8f3c7c55511377f8b8d0554b881be);
		_container = new c196099a1254db61d3be10d70e14e7422();
		_container.c130648b59a0c8debea60aa153f844879(c38166bc7092867b1eae7a76b075dbdbd);
		_containerMC = c38166bc7092867b1eae7a76b075dbdbd;
		_bActive = true;
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_container);
		_questDetail = null;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("Quest.swf");
	}

	protected void cf8d5496eaeffeee86e21791e82ef3c11(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		c81b908a469694969d8bec25b256b0b96();
	}

	protected void c57bf6bfe368af1a9b79d34417f9b57ba(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		_containerMC.visible = true;
		c81b908a469694969d8bec25b256b0b96();
	}

	protected void c90b8f3c7c55511377f8b8d0554b881be(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		_containerMC.visible = false;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_container);
	}

	protected void c81b908a469694969d8bec25b256b0b96()
	{
		MovieClip childByName = _containerMC.getChildByName<MovieClip>("mcQuestDetail");
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
			_questDetail.c130648b59a0c8debea60aa153f844879(childByName);
			_questDetail.c12c1611d592facfca7f3d95d2ce78e8a(_questData);
			return;
		}
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
		if (c8be1fcd630e5fe96821376d111325750)
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
					(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cb4341b3564e3d55dc9f38df4b813c5da(_container);
					_containerMC.gotoAndPlay("DetailAppear");
					return;
				}
			}
		}
		_containerMC.gotoAndPlay("FadeOut");
	}

	protected override void c02ed51fd65a976a6ef07902fa09bef51()
	{
		base.c02ed51fd65a976a6ef07902fa09bef51();
		c150264a18c2cb408479d3f072cac8cc1 = false;
	}

	protected override void c160c4effdbc25f551e67296293735016()
	{
		base.c160c4effdbc25f551e67296293735016();
		c150264a18c2cb408479d3f072cac8cc1 = false;
	}
}
