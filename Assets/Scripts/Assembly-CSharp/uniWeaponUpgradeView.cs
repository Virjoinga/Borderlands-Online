using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using UnityEngine;
using XsdSettings;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

public class uniWeaponUpgradeView : WeaponUpgradeView
{
	private class WeaponUpgradePanel : c196099a1254db61d3be10d70e14e7422
	{
		private MovieClip _detailMC;

		private MovieClip _intensityMC;

		private MovieClip _rechargeMC;

		private MovieClip _levelIndicatorMC;

		private MovieClip _progressBar;

		private MovieClip _progressMask;

		private bool _processing;

		private c82f7c0afbcfc8c5382a8c6daa9365b7b _addEnergy;

		private c82f7c0afbcfc8c5382a8c6daa9365b7b _purchaseMaterial;

		private c82f7c0afbcfc8c5382a8c6daa9365b7b _intensityWeapon;

		public MovieClip mcRootMovie;

		public uniInventoryView inventoryView;

		private int currentLevel;

		private int upgradeMaxExp;

		private static int MAX_LEVEL = 9;

		private static int MAX_WEAPON_ATTRIBUTE = 7;

		private static int MAX_WEAPON_EXTRA_INFO = 12;

		private float deltaTime;

		[CompilerGenerated]
		private static Dictionary<string, int> _003C_003Ef__switch_0024map33;

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			mcRootMovie = base.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
			mcRootMovie.addEventListener(CEvent.ENTER_FRAME, OnEnterFrame);
		}

		public bool c9aa23177ec07c5cf830d5b68922e3b42()
		{
			return _processing;
		}

		public void c07ec193ee4af3de137fb7911ca462c52(WeaponDNA c7ad992a76feafc31f8ad6e56516da24f, bool c0288bae5354ccafc155abd254e67b8a0)
		{
			currentLevel = c7ad992a76feafc31f8ad6e56516da24f.m_starLevel;
			if (c0288bae5354ccafc155abd254e67b8a0)
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
				c2da0a52b50f9e6b25ca05bdafac9bfd7(c7ad992a76feafc31f8ad6e56516da24f.m_starLevel);
			}
			c3fff9cb9ecc7cbb4e3b5193863237b34(c7ad992a76feafc31f8ad6e56516da24f);
			c974834b8b7d91a051a589980dc175be7(c7ad992a76feafc31f8ad6e56516da24f);
			c979b213607766f25a0f44f6962a97947(c7ad992a76feafc31f8ad6e56516da24f);
			if (c0288bae5354ccafc155abd254e67b8a0)
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
				cf1bd9abd5e0d71d9fcfee46fd1cacde2(c7ad992a76feafc31f8ad6e56516da24f);
			}
			c2cd45348277dde4961f00f09c538774e();
		}

		public void c23905fc84163092f84a7f00d69f51100()
		{
			c2da0a52b50f9e6b25ca05bdafac9bfd7(0);
			c3fff9cb9ecc7cbb4e3b5193863237b34(cc607e9943fa3c5044ada833720c23c9a.c7088de59e49f7108f520cf7e0bae167e);
			c343cc875403b962b6f5532a1beb4e4b2();
			cf845d24a01b4c25ac759344df28aa7fa();
			c304760718c6d2dccbef7637813351945();
		}

		private string caee2229b477c4d384cd6050bb27068dd(List<SingleWeaponAttribute> c6a2022d96d7ebb4ce1c1ca2a00e339e6, ItemElement cc0aeb66eb3857e6773bfe62e53d3410a)
		{
			string result = string.Empty;
			for (int i = 0; i < c6a2022d96d7ebb4ce1c1ca2a00e339e6.Count; i++)
			{
				if (cc0aeb66eb3857e6773bfe62e53d3410a.aType != c6a2022d96d7ebb4ce1c1ca2a00e339e6[i].m_attributeType)
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
				if (c6a2022d96d7ebb4ce1c1ca2a00e339e6[i].m_affectType == AffectType.Scale)
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
					result = Mathf.Abs(c6a2022d96d7ebb4ce1c1ca2a00e339e6[i].m_value) * 100f + "%";
				}
				else
				{
					if (c6a2022d96d7ebb4ce1c1ca2a00e339e6[i].m_affectType != AffectType.PostAdd)
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
					result = c6a2022d96d7ebb4ce1c1ca2a00e339e6[i].m_value.ToString();
				}
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				return result;
			}
		}

		public void c343cc875403b962b6f5532a1beb4e4b2()
		{
			MovieClip movieClip = _detailMC.getChildByName("mcBody") as MovieClip;
			TextField textField = movieClip.getChildByName("txTitle") as TextField;
			textField.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Weapon_Upgrade_Preview"));
			TextField textField2 = movieClip.getChildByName("txName") as TextField;
			textField2.text = string.Empty;
			TextField textField3 = movieClip.getChildByName("txLevelNumber") as TextField;
			textField3.text = string.Empty;
			TextField textField4 = movieClip.getChildByName("txLevelLabel") as TextField;
			textField4.visible = false;
			MovieClip movieClip2 = movieClip.getChildByName("mcType") as MovieClip;
			movieClip2.visible = false;
			MovieClip movieClip3 = movieClip.getChildByName("gunbrand") as MovieClip;
			movieClip3.visible = false;
			for (int i = 0; i < MAX_WEAPON_ATTRIBUTE; i++)
			{
				MovieClip movieClip4 = movieClip.getChildByName("mcDownElem" + i) as MovieClip;
				movieClip4.visible = false;
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
				for (int j = 0; j < MAX_WEAPON_EXTRA_INFO; j++)
				{
					UnityTextField unityTextField = movieClip.getChildByName("tfDesc" + j) as UnityTextField;
					unityTextField.visible = false;
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

		public void c974834b8b7d91a051a589980dc175be7(WeaponDNA c7ad992a76feafc31f8ad6e56516da24f)
		{
			ItemTipsData itemTipsData = ItemCardPanel.cfa5ab8a3a1b0bbe4ab6ea32a3cbe648e(c7ad992a76feafc31f8ad6e56516da24f, null, true);
			List<SingleWeaponAttribute> c6a2022d96d7ebb4ce1c1ca2a00e339e = StarLevelAttributeStore.cecd5638d8f5bf49105ca7c28afbbfba4.c0df9dda41628088f6ce9fe9d256faaaa(c7ad992a76feafc31f8ad6e56516da24f.c83e548e5608cd7f222098a6966b16545(), c7ad992a76feafc31f8ad6e56516da24f.m_starLevel);
			MovieClip movieClip = _detailMC.getChildByName("mcBody") as MovieClip;
			TextField textField = movieClip.getChildByName("txTitle") as TextField;
			if (c7ad992a76feafc31f8ad6e56516da24f.m_starLevel < MAX_LEVEL)
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
				textField.text = c7ad992a76feafc31f8ad6e56516da24f.m_starLevel + 1 + LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Weapon_Upgrade_Star_Preview"));
			}
			else
			{
				textField.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Weapon_Upgrade_Max"));
			}
			UnityTextField unityTextField = movieClip.getChildByName("txName") as UnityTextField;
			unityTextField.text = itemTipsData.name;
			unityTextField.c34fce3bccfffc6feb3579939c6d9a057 = itemTipsData.nameColor;
			TextField textField2 = movieClip.getChildByName("txLevelNumber") as TextField;
			textField2.text = itemTipsData.level.ToString();
			TextField textField3 = movieClip.getChildByName("txLevelLabel") as TextField;
			textField3.visible = true;
			MovieClip movieClip2 = movieClip.getChildByName("mcType") as MovieClip;
			movieClip2.gotoAndStop("Weapon_" + c7ad992a76feafc31f8ad6e56516da24f.c83e548e5608cd7f222098a6966b16545());
			movieClip2.visible = true;
			MovieClip movieClip3 = movieClip.getChildByName("gunbrand") as MovieClip;
			movieClip3.gotoAndStop(itemTipsData.brand);
			movieClip3.visible = true;
			for (int i = 0; i < MAX_WEAPON_ATTRIBUTE; i++)
			{
				MovieClip movieClip4 = movieClip.getChildByName("mcDownElem" + i) as MovieClip;
				if (i < itemTipsData.attributeList.Count)
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
					movieClip4.visible = true;
					UnityTextField unityTextField2 = movieClip4.getChildByName("title") as UnityTextField;
					unityTextField2.text = itemTipsData.attributeList[i].title;
					unityTextField2 = movieClip4.getChildByName("value") as UnityTextField;
					string empty = string.Empty;
					empty = caee2229b477c4d384cd6050bb27068dd(c6a2022d96d7ebb4ce1c1ca2a00e339e, itemTipsData.attributeList[i]);
					unityTextField2.text = itemTipsData.attributeList[i].value.ToString();
					unityTextField2 = movieClip4.getChildByName("delta") as UnityTextField;
					MovieClip movieClip5 = movieClip4.getChildByName("arrow") as MovieClip;
					if (empty != string.Empty)
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
						unityTextField2.visible = true;
						unityTextField2.text = empty;
						movieClip5.gotoAndStop("up");
					}
					else
					{
						unityTextField2.visible = false;
						movieClip5.gotoAndStop("none");
					}
					MovieClip movieClip6 = movieClip4.getChildByName("iconType") as MovieClip;
					movieClip6.gotoAndStop(itemTipsData.attributeList[i].iconType);
				}
				else
				{
					movieClip4.visible = false;
				}
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				for (int j = 0; j < MAX_WEAPON_EXTRA_INFO; j++)
				{
					UnityTextField unityTextField3 = movieClip.getChildByName("tfDesc" + j) as UnityTextField;
					if (j < itemTipsData.additionAttList.Count)
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
						unityTextField3.visible = true;
						unityTextField3.text = itemTipsData.additionAttList[j].value.ToString();
					}
					else
					{
						unityTextField3.visible = false;
					}
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

		public void cfecc2dfe50fcbc82953cecf507d28947(WeaponDNA c39409683a32e09391d094314ffeae2b5)
		{
			if (c39409683a32e09391d094314ffeae2b5.m_starExperience >= StarLevelAttributeStore.cecd5638d8f5bf49105ca7c28afbbfba4.c15e38327c5b5eed2c917ce1e8b78d24a(c39409683a32e09391d094314ffeae2b5.c83e548e5608cd7f222098a6966b16545(), c39409683a32e09391d094314ffeae2b5.m_starLevel, c39409683a32e09391d094314ffeae2b5.m_level, c39409683a32e09391d094314ffeae2b5.m_rarity))
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
				if (c39409683a32e09391d094314ffeae2b5.m_starExperience > 0)
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
					if (c39409683a32e09391d094314ffeae2b5.m_starLevel < MAX_LEVEL)
					{
						while (true)
						{
							switch (5)
							{
							case 0:
								break;
							default:
								_intensityMC.visible = true;
								_intensityMC.gotoAndStop("normal");
								_rechargeMC.visible = false;
								_rechargeMC.stop();
								return;
							}
						}
					}
				}
			}
			_intensityMC.visible = false;
			_rechargeMC.visible = true;
			_rechargeMC.gotoAndStop("normal");
			_intensityMC.stop();
		}

		private void c3fff9cb9ecc7cbb4e3b5193863237b34(WeaponDNA c39409683a32e09391d094314ffeae2b5)
		{
			TextField textField = _progressBar.getChildByName("txtExperience") as TextField;
			if (c39409683a32e09391d094314ffeae2b5 != null)
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
						float num = 0f;
						if (c39409683a32e09391d094314ffeae2b5.m_starLevel < MAX_LEVEL)
						{
							while (true)
							{
								switch (2)
								{
								case 0:
									break;
								default:
								{
									upgradeMaxExp = StarLevelAttributeStore.cecd5638d8f5bf49105ca7c28afbbfba4.c15e38327c5b5eed2c917ce1e8b78d24a(c39409683a32e09391d094314ffeae2b5.c83e548e5608cd7f222098a6966b16545(), c39409683a32e09391d094314ffeae2b5.m_starLevel, c39409683a32e09391d094314ffeae2b5.m_level, c39409683a32e09391d094314ffeae2b5.m_rarity);
									float num2 = upgradeMaxExp;
									float num3;
									if (num2 == 0f)
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
										num3 = 0f;
									}
									else
									{
										num3 = (float)c39409683a32e09391d094314ffeae2b5.m_starExperience / num2;
									}
									num = num3;
									c2b99c398ea6d62a70c59beccfdc632ca(num, true);
									textField.text = c39409683a32e09391d094314ffeae2b5.m_starExperience + "/" + upgradeMaxExp;
									_addEnergy.c150264a18c2cb408479d3f072cac8cc1 = true;
									return;
								}
								}
							}
						}
						num = 1f;
						upgradeMaxExp = StarLevelAttributeStore.cecd5638d8f5bf49105ca7c28afbbfba4.c15e38327c5b5eed2c917ce1e8b78d24a(c39409683a32e09391d094314ffeae2b5.c83e548e5608cd7f222098a6966b16545(), c39409683a32e09391d094314ffeae2b5.m_starLevel - 1, c39409683a32e09391d094314ffeae2b5.m_level, c39409683a32e09391d094314ffeae2b5.m_rarity);
						c2b99c398ea6d62a70c59beccfdc632ca(num, false);
						_addEnergy.c150264a18c2cb408479d3f072cac8cc1 = false;
						textField.text = upgradeMaxExp + "/" + upgradeMaxExp;
						return;
					}
					}
				}
			}
			c2b99c398ea6d62a70c59beccfdc632ca(0f, false);
			textField.text = "0/0";
			_intensityMC.visible = false;
			_rechargeMC.visible = true;
		}

		public void c2da0a52b50f9e6b25ca05bdafac9bfd7(int cd6bb591c33b2ee3ab93e98aa43a6da63)
		{
			MovieClip movieClip = _levelIndicatorMC.getChildByName("mcBody") as MovieClip;
			for (int i = 1; i <= MAX_LEVEL; i++)
			{
				MovieClip movieClip2 = movieClip.getChildByName("s" + i) as MovieClip;
				if (i <= currentLevel)
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
					movieClip2.gotoAndStop("upgraded");
				}
				else
				{
					movieClip2.gotoAndStop("unupgrade");
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

		public void c2b99c398ea6d62a70c59beccfdc632ca(float c7433d33ccdda437ab9849647095953ce, bool cf6ffdab6983744bc0c6f3d32c2cab820)
		{
			_progressBar.gotoAndStop((int)(Mathf.Min(c7433d33ccdda437ab9849647095953ce, 1f) * 50f));
			if (!(c7433d33ccdda437ab9849647095953ce >= 1f))
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
				if (cf6ffdab6983744bc0c6f3d32c2cab820)
				{
					while (true)
					{
						switch (7)
						{
						case 0:
							break;
						default:
							_progressBar.gotoAndPlay("full");
							(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c462fe1a64a37daab5e61f688d9a61e7f("UI_Wep_Upgrade_Charge_Complete");
							return;
						}
					}
				}
				_progressBar.gotoAndStop("full");
				return;
			}
		}

		public void cf1bd9abd5e0d71d9fcfee46fd1cacde2(WeaponDNA c39409683a32e09391d094314ffeae2b5)
		{
			MovieClip c459979a48624cdc8dd782ffdbab = (MovieClip)_intensityMC.getChildByName("mcBody").getChildByName("mcMaterial");
			ItemConsume itemConsume = StarLevelAttributeStore.cecd5638d8f5bf49105ca7c28afbbfba4.cd1b950d28832dc51f746809d8f189d68(c39409683a32e09391d094314ffeae2b5.c83e548e5608cd7f222098a6966b16545(), c39409683a32e09391d094314ffeae2b5.m_starLevel);
			if (itemConsume == null)
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
				c1b4dc2403354a34b7b4047286eb60c94(c459979a48624cdc8dd782ffdbab, itemConsume.m_materialType, itemConsume.m_materialNums, c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cdff08bd623e04fdde40092784eebdeec(itemConsume.m_materialType));
				_intensityWeapon.cf798cedf450c3ad2a08ce2d2fd00d464 = "$" + itemConsume.m_itemNums;
				return;
			}
		}

		private void c1b4dc2403354a34b7b4047286eb60c94(MovieClip c459979a48624cdc8dd782ffdbab36750, MaterialType cf4af10ce9fa4ab84bd021b054d46a667, int c82fcbab5e578dc3a31c1f662916bd87e, int cb427f3b34793a41fc0b9945d1a5b8bfe)
		{
			TextField textField = (TextField)c459979a48624cdc8dd782ffdbab36750.getChildByName("textNumber");
			if (cb427f3b34793a41fc0b9945d1a5b8bfe < c82fcbab5e578dc3a31c1f662916bd87e)
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
				object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
				array[0] = "<color=red>";
				array[1] = cb427f3b34793a41fc0b9945d1a5b8bfe;
				array[2] = "</color>/";
				array[3] = c82fcbab5e578dc3a31c1f662916bd87e;
				textField.text = string.Concat(array);
			}
			else
			{
				textField.text = cb427f3b34793a41fc0b9945d1a5b8bfe + "/" + c82fcbab5e578dc3a31c1f662916bd87e;
			}
			textField.visible = true;
			c459979a48624cdc8dd782ffdbab36750 = c459979a48624cdc8dd782ffdbab36750.getChildByName("icon") as MovieClip;
			while (c459979a48624cdc8dd782ffdbab36750.numChildren != 0)
			{
				c459979a48624cdc8dd782ffdbab36750.removeChildAt(0);
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				MovieClip movieClip = inventoryView.cf00e0520259191fd2faf4e52ef6f3ac0(cf4af10ce9fa4ab84bd021b054d46a667);
				movieClip.x = -48f;
				movieClip.y = 0f;
				c459979a48624cdc8dd782ffdbab36750.addChild(movieClip);
				return;
			}
		}

		private void cb6f7cf0785182bb61ca5cfd7fe1ef9ce(MovieClip c459979a48624cdc8dd782ffdbab36750)
		{
			TextField textField = (TextField)c459979a48624cdc8dd782ffdbab36750.getChildByName("textNumber");
			textField.text = 0 + "/" + 0;
			textField.visible = false;
			c459979a48624cdc8dd782ffdbab36750 = c459979a48624cdc8dd782ffdbab36750.getChildByName("icon") as MovieClip;
			while (c459979a48624cdc8dd782ffdbab36750.numChildren != 0)
			{
				c459979a48624cdc8dd782ffdbab36750.removeChildAt(0);
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

		public void cf845d24a01b4c25ac759344df28aa7fa()
		{
			MovieClip c459979a48624cdc8dd782ffdbab = (MovieClip)_rechargeMC.getChildByName("mcBody").getChildByName("mcRechargeMaterailA");
			MovieClip c459979a48624cdc8dd782ffdbab2 = (MovieClip)_rechargeMC.getChildByName("mcBody").getChildByName("mcRechargeMaterailB");
			cb6f7cf0785182bb61ca5cfd7fe1ef9ce(c459979a48624cdc8dd782ffdbab);
			cb6f7cf0785182bb61ca5cfd7fe1ef9ce(c459979a48624cdc8dd782ffdbab2);
		}

		public void c979b213607766f25a0f44f6962a97947(WeaponDNA c39409683a32e09391d094314ffeae2b5)
		{
			MovieClip c459979a48624cdc8dd782ffdbab = (MovieClip)_rechargeMC.getChildByName("mcBody").getChildByName("mcRechargeMaterailA");
			ConsumedMaterial[] array = StarLevelAttributeStore.cecd5638d8f5bf49105ca7c28afbbfba4.c427b782717fb7214fcc0f2cf5778100a(c39409683a32e09391d094314ffeae2b5.c83e548e5608cd7f222098a6966b16545());
			if (array.Length > 0)
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
				c1b4dc2403354a34b7b4047286eb60c94(c459979a48624cdc8dd782ffdbab, array[0].m_consumedMaterialType, array[0].m_consumedMaterialNums, c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cdff08bd623e04fdde40092784eebdeec(array[0].m_consumedMaterialType));
			}
			MovieClip movieClip = (MovieClip)_rechargeMC.getChildByName("mcBody").getChildByName("mcRechargeMaterailB");
			if (array.Length > 1)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						movieClip.visible = true;
						c1b4dc2403354a34b7b4047286eb60c94(movieClip, array[1].m_consumedMaterialType, array[1].m_consumedMaterialNums, c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cdff08bd623e04fdde40092784eebdeec(array[1].m_consumedMaterialType));
						return;
					}
				}
			}
			movieClip.visible = false;
		}

		private void c2eb914d0aca480a7ee19628955d75238(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			deltaTime += Time.deltaTime;
			if (!(deltaTime >= 1.5f))
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
				c2da0a52b50f9e6b25ca05bdafac9bfd7(currentLevel);
				if (currentLevel <= MAX_LEVEL)
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
					MovieClip movieClip = (MovieClip)_levelIndicatorMC.getChildByName("mcBody").getChildByName("s" + currentLevel);
					movieClip.gotoAndPlay("upgraded");
				}
				mcRootMovie.removeEventListener(CEvent.ENTER_FRAME, c2eb914d0aca480a7ee19628955d75238);
				return;
			}
		}

		public void ca7f40a3610b9512926911208d97b0caa()
		{
			deltaTime = 0f;
			mcRootMovie.addEventListener(CEvent.ENTER_FRAME, c2eb914d0aca480a7ee19628955d75238);
			_intensityMC.gotoAndPlay("fadeout");
		}

		public void c23ffb495db7c9da62404f1cc24a67351()
		{
			_detailMC.gotoAndPlay("fadein");
			_intensityMC.gotoAndPlay("fadein");
			_rechargeMC.gotoAndPlay("fadein");
			_levelIndicatorMC.gotoAndPlay("fadein");
			_processing = false;
		}

		public void cce6adadf40a70610ce3ae5dd40479620()
		{
			_detailMC.gotoAndPlay("fadeout");
			_intensityMC.gotoAndPlay("fadeout");
			_rechargeMC.gotoAndPlay("fadeout");
			_levelIndicatorMC.gotoAndPlay("fadeout");
		}

		private void OnFadeoutComplete(CEvent evt)
		{
			MovieClip movieClip = evt.currentTarget as MovieClip;
			movieClip.visible = false;
		}

		private void OnIntensityPanelFadeout(CEvent evt)
		{
			_rechargeMC.visible = true;
			_intensityMC.visible = false;
			_rechargeMC.gotoAndPlay("fadein");
		}

		private void OnRechargePanelFadeout(CEvent evt)
		{
			_rechargeMC.visible = false;
			if (_intensityMC.visible)
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
				_intensityMC.visible = true;
				_intensityMC.gotoAndPlay("fadein");
				return;
			}
		}

		public void ca61d5a82dff4dca6763fa249b5241e54()
		{
			_processing = false;
		}

		public void cb875222c821f3646dd22d722aafdbebc()
		{
			_processing = true;
		}

		public void c2cd45348277dde4961f00f09c538774e()
		{
			_intensityWeapon.cbf402c82d0fffee7c8f37c98e456b8f8 = true;
			_addEnergy.cbf402c82d0fffee7c8f37c98e456b8f8 = true;
		}

		public void c304760718c6d2dccbef7637813351945()
		{
			_intensityWeapon.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
			_addEnergy.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
		}

		private void OnProgressBarFadeoutComplete(CEvent evt)
		{
			_rechargeMC.gotoAndPlay("fadeout");
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c462fe1a64a37daab5e61f688d9a61e7f("UI_Panel_Movement");
		}

		private void OnEnterFrame(CEvent evt)
		{
			MaskManager.c71f6ce28731edfd43c976fbd57c57bea().Update(_progressMask);
		}

		private void c4a4e32c5e1f2cd9d559a176e93393e63()
		{
			MovieClip movieClip = _progressBar.getChildByName("mcProgressBar") as MovieClip;
			_progressMask = _progressBar.getChildByName("mcProgressMask") as MovieClip;
			_progressBar.stop();
			MaskManager maskManager = MaskManager.c71f6ce28731edfd43c976fbd57c57bea();
			MovieClip progressMask = _progressMask;
			MovieClip[] array = c2376ea3bd38aedb0e6abb20d59d298e8.c0a0cdf4a196914163f7334d9b0781a04(1);
			array[0] = movieClip;
			maskManager.c691ab6ea2ee6d471d8daa38c709e55f3(progressMask, array);
		}

		private void OnAddExperience(CEvent evt)
		{
			dispatchEvent(new CEvent("ADD_WEAPON_EXPERIENCE"));
		}

		private void OnIntensityWeapon(CEvent evt)
		{
			dispatchEvent(new CEvent("ADD_WEAPON_GRADE"));
		}

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool result = false;
			string name = movieClip.name;
			if (name != null)
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
				if (_003C_003Ef__switch_0024map33 == null)
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
					Dictionary<string, int> dictionary = new Dictionary<string, int>(7);
					dictionary.Add("mcStar", 0);
					dictionary.Add("mcDetail", 1);
					dictionary.Add("mcRecharge", 2);
					dictionary.Add("mcIntensity", 3);
					dictionary.Add("btnRight", 4);
					dictionary.Add("mcPurchase", 5);
					dictionary.Add("mcUpgrade", 6);
					_003C_003Ef__switch_0024map33 = dictionary;
				}
				int value;
				if (_003C_003Ef__switch_0024map33.TryGetValue(name, out value))
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
					switch (value)
					{
					case 0:
						_levelIndicatorMC = movieClip;
						result = true;
						break;
					case 1:
						_detailMC = movieClip;
						result = true;
						break;
					case 2:
						_rechargeMC = movieClip;
						_rechargeMC.addFrameScript("end", OnRechargePanelFadeout);
						_progressBar = (MovieClip)_rechargeMC.getChildByName("mcBody").getChildByName("mcRechargeBar");
						_progressBar.addFrameScript("fulled", OnProgressBarFadeoutComplete);
						c4a4e32c5e1f2cd9d559a176e93393e63();
						result = false;
						break;
					case 3:
						_intensityMC = movieClip;
						_intensityMC.addFrameScript("end", OnIntensityPanelFadeout);
						result = false;
						break;
					case 4:
						_addEnergy = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
						_addEnergy.c130648b59a0c8debea60aa153f844879(movieClip);
						_addEnergy.addEventListener(MouseEvent.CLICK, OnAddExperience);
						result = true;
						break;
					case 5:
						_purchaseMaterial = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
						_purchaseMaterial.c130648b59a0c8debea60aa153f844879(movieClip);
						result = true;
						break;
					case 6:
						_intensityWeapon = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
						_intensityWeapon.c130648b59a0c8debea60aa153f844879(movieClip);
						_intensityWeapon.addEventListener(MouseEvent.CLICK, OnIntensityWeapon);
						result = true;
						break;
					}
				}
			}
			return result;
		}
	}

	private uniInventoryView.InventoryPanel _inventoryPanel;

	private WeaponUpgradePanel _panel;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c968ae3f7ba22e4826b18039ba36f33ce(this, new Vector2(800f, 52f));
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("Weapon_upgrade.swf", "WeaponUpgradePanel", c1141a8fde9aa0f410bc4a7fdd2e3ef7c);
		_inventoryPanel = (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InventoryView>() as uniInventoryView).c796c173865ebd0e0606dad33b499db0b;
	}

	private void c1141a8fde9aa0f410bc4a7fdd2e3ef7c(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		_panel = new WeaponUpgradePanel();
		_panel.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		_panel.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = false;
		_panel.inventoryView = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InventoryView>() as uniInventoryView;
		_panel.addEventListener("ADD_WEAPON_EXPERIENCE", OnAddExperience);
		_panel.addEventListener("ADD_WEAPON_GRADE", OnAddWeaponGrade);
	}

	public override void c23ffb495db7c9da62404f1cc24a67351()
	{
		base.c23ffb495db7c9da62404f1cc24a67351();
		weaponIndex = -1;
		c660501325b92420b182c10632cb9aa92(null);
		_panel.c23ffb495db7c9da62404f1cc24a67351();
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		_inventoryPanel = null;
		_panel.inventoryView = c1fb1d14041a4c84aec6a998d1468bd58.c7088de59e49f7108f520cf7e0bae167e;
		MaskManager.c71f6ce28731edfd43c976fbd57c57bea().cac7688b05e921e2be3f92479ba44b4a8();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_panel);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("Weapon_upgrade.swf");
	}

	protected override void ca7f40a3610b9512926911208d97b0caa()
	{
		base.ca7f40a3610b9512926911208d97b0caa();
		_panel.ca7f40a3610b9512926911208d97b0caa();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c462fe1a64a37daab5e61f688d9a61e7f("UI_Wep_Upgrade_Glow_Success");
	}

	protected override void ccd3eab4bbc52e554166ae214401869fe()
	{
		base.ccd3eab4bbc52e554166ae214401869fe();
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c462fe1a64a37daab5e61f688d9a61e7f("UI_Wep_Upgrade_Glow_Fail");
	}

	public override void ca61d5a82dff4dca6763fa249b5241e54()
	{
		_panel.ca61d5a82dff4dca6763fa249b5241e54();
		_panel.c2cd45348277dde4961f00f09c538774e();
	}

	public override void cb875222c821f3646dd22d722aafdbebc()
	{
		_panel.cb875222c821f3646dd22d722aafdbebc();
		_panel.c304760718c6d2dccbef7637813351945();
	}

	public override void c660501325b92420b182c10632cb9aa92(ItemDNA c000a5a1f484781c00fa6008d1814e675, bool c1cfcfc2b2c10ed433757ae4513e115fe = true, bool c01de5f7fd10b55819a8738f39620dedf = true)
	{
		base.c660501325b92420b182c10632cb9aa92(c000a5a1f484781c00fa6008d1814e675, c1cfcfc2b2c10ed433757ae4513e115fe, c01de5f7fd10b55819a8738f39620dedf);
		if (c000a5a1f484781c00fa6008d1814e675 != null)
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
					(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c462fe1a64a37daab5e61f688d9a61e7f("UI_Wep_Upgrade_SelectWep");
					_panel.c07ec193ee4af3de137fb7911ca462c52(c000a5a1f484781c00fa6008d1814e675.ca79da172938fdc8c067fb64242b6174a(), c01de5f7fd10b55819a8738f39620dedf);
					return;
				}
			}
		}
		_panel.c23905fc84163092f84a7f00d69f51100();
	}

	private void c1fc97d9000793496ac114d06521f85a0(WeaponDNA c39409683a32e09391d094314ffeae2b5)
	{
		_panel.cfecc2dfe50fcbc82953cecf507d28947(c39409683a32e09391d094314ffeae2b5);
	}

	private void OnAddExperience(CEvent evt)
	{
		ca0d81305a63da237ff4996557b68322d();
	}

	private void OnAddWeaponGrade(CEvent evt)
	{
		c003d770a5d51d5333b7aa55f762704c4();
	}

	public override void OnExperienceUpdate(ItemDNA newWeapon)
	{
		base.OnExperienceUpdate(newWeapon);
		if (newWeapon == null)
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
			(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c462fe1a64a37daab5e61f688d9a61e7f("UI_Wep_Upgrade_Charging_Rnd");
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
					continue;
				}
				break;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<UniUIManager>().cb4341b3564e3d55dc9f38df4b813c5da(_panel);
		}
		else
		{
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.GetComponent<UniUIManager>().c27542a6dc8f97862ef53db1d4f3a6db8(_panel);
		}
		_panel.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = _bVisible;
		if (_inventoryPanel == null)
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
			_inventoryPanel = (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InventoryView>() as uniInventoryView).c796c173865ebd0e0606dad33b499db0b;
			_panel.inventoryView = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InventoryView>() as uniInventoryView;
		}
		if (_inventoryPanel == null)
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
			if (_bVisible)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						_inventoryPanel.addEventListener("Item" + MouseEvent.CLICK, c3f07aa998bf303194d0f7ebe96fc957c);
						_inventoryPanel.addEventListener("Item" + c649b5d45cf350f685c56c4bd02800198.cfb118d69d579b2fbde25fa8127b213f3, c41b74e095a2dce69351faa913502b0b5);
						_inventoryPanel.addEventListener("Item" + MouseEvent.MOUSE_ENTER, c958c3ac0a1c5a32823ec17487f74f1b5);
						_inventoryPanel.addEventListener("Item" + MouseEvent.MOUSE_LEAVE, cb7fe6f7819f02ed4cfb952c1e0a2b0ec);
						return;
					}
				}
			}
			_inventoryPanel.removeEventListener("Item" + MouseEvent.CLICK, c3f07aa998bf303194d0f7ebe96fc957c);
			_inventoryPanel.removeEventListener("Item" + c649b5d45cf350f685c56c4bd02800198.cfb118d69d579b2fbde25fa8127b213f3, c41b74e095a2dce69351faa913502b0b5);
			_inventoryPanel.removeEventListener("Item" + MouseEvent.MOUSE_ENTER, c958c3ac0a1c5a32823ec17487f74f1b5);
			_inventoryPanel.removeEventListener("Item" + MouseEvent.MOUSE_LEAVE, cb7fe6f7819f02ed4cfb952c1e0a2b0ec);
			return;
		}
	}

	protected void c3f07aa998bf303194d0f7ebe96fc957c(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		if (_panel.c9aa23177ec07c5cf830d5b68922e3b42())
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
		cdd9021d4f44808fce2ab49c52f0db6f7 cdd9021d4f44808fce2ab49c52f0db6f = c3d202dee321219a80026dc3081fb3c86 as cdd9021d4f44808fce2ab49c52f0db6f7;
		UIItemSlotData uIItemSlotData = (UIItemSlotData)cdd9021d4f44808fce2ab49c52f0db6f.c591d56a94543e3559945c497f37126c4;
		if (!uIItemSlotData.item.ca8e8ecb1231bf8cf32c06da446a48681(ItemType.Weapon))
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
			weaponIndex = uIItemSlotData.index;
			c1fc97d9000793496ac114d06521f85a0(uIItemSlotData.item.ca79da172938fdc8c067fb64242b6174a());
			c660501325b92420b182c10632cb9aa92(uIItemSlotData.item);
			return;
		}
	}

	protected void c41b74e095a2dce69351faa913502b0b5(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
	}

	protected void c958c3ac0a1c5a32823ec17487f74f1b5(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
	}

	protected void cb7fe6f7819f02ed4cfb952c1e0a2b0ec(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
	}
}
