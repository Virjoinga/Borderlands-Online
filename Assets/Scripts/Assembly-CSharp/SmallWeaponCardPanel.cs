using A;
using Core;
using XsdSettings;
using pumpkin.display;
using pumpkin.events;

public class SmallWeaponCardPanel : c196099a1254db61d3be10d70e14e7422
{
	protected MovieClip mcSelf;

	protected MovieClip mcRootRoot;

	protected MovieClip mcRoot;

	protected UnityTextField mcDamage;

	protected UnityTextField mcAccuracy;

	protected UnityTextField mcFireRate;

	protected UnityTextField mcReloadSpeed;

	protected UnityTextField mcClipSize;

	protected MovieClip mcDamageArrow;

	protected MovieClip mcAccuracyArrow;

	protected MovieClip mcFireRateArrow;

	protected MovieClip mcReloadSpeedArrow;

	protected MovieClip mcClipSizeArrow;

	protected UnityTextField txElementDmg;

	protected MovieClip mcElementDmg;

	protected MovieClip mcElementDmgArrow;

	protected UnityTextField txElementCoef;

	protected MovieClip mcElementCoef;

	protected MovieClip mcElementCoefArrow;

	protected MovieClip mcBrand;

	protected UnityTextField mcName;

	protected Sprite mcRarity1;

	protected Sprite mcRarity2;

	protected bool _bEntityDisplaying;

	protected WeaponDNA _showEntity;

	protected WeaponDNA _compareEntity;

	protected bool _bShowArrow;

	protected ItemTipsData _tipsData;

	protected override void c969016383f47c249932cc75475f00ae1()
	{
		base.c969016383f47c249932cc75475f00ae1();
		mcSelf = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
		if (mcSelf == null)
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
					DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: SmallWeaponCardPanel MovieClip missing!!");
					return;
				}
			}
		}
		mcSelf.visible = false;
		mcSelf.stop();
		mcRootRoot = mcSelf.getChildByName<MovieClip>("mcRoot");
	}

	protected virtual void c1c3ee76beeceed832634f5603084d7a2()
	{
		mcRoot = mcRootRoot.getChildByName<MovieClip>("mcRoot");
	}

	private void cb858f4c907c42c1ea4be312cf85f7f91(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		c1c3ee76beeceed832634f5603084d7a2();
		if (mcRoot == null)
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
			c9faa54a7033ae745575aa65c49f30969();
			if (mcName != null)
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
				mcName.text = _tipsData.name;
				mcName.c34fce3bccfffc6feb3579939c6d9a057 = _tipsData.nameColor;
			}
			mcBrand.gotoAndStop(_tipsData.brand);
			if (mcRarity1 != null)
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
				mcRarity1.colorTransform = UniUIManager.UniSWFToolClass.c87015237d139b95339567fd82054be1b(_showEntity.m_rarity);
			}
			if (mcRarity2 != null)
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
				mcRarity2.visible = _showEntity.m_rarity != WeaponRarity.Common;
				mcRarity2.colorTransform = UniUIManager.UniSWFToolClass.c87015237d139b95339567fd82054be1b(_showEntity.m_rarity);
			}
			int num = 0;
			int count = _tipsData.attributeList.Count;
			if (num < count)
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
				mcDamage.c34fce3bccfffc6feb3579939c6d9a057 = _tipsData.attributeList[num].color;
				mcDamage.text = (string)_tipsData.attributeList[num].value;
				mcDamageArrow.gotoAndStop(_tipsData.attributeList[num].arrow);
				num++;
			}
			if (num < count)
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
				mcAccuracy.c34fce3bccfffc6feb3579939c6d9a057 = _tipsData.attributeList[num].color;
				mcAccuracy.text = (string)_tipsData.attributeList[num].value;
				mcAccuracyArrow.gotoAndStop(_tipsData.attributeList[num].arrow);
				num++;
			}
			if (num < count)
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
				mcFireRate.c34fce3bccfffc6feb3579939c6d9a057 = _tipsData.attributeList[num].color;
				mcFireRate.text = (string)_tipsData.attributeList[num].value;
				mcFireRateArrow.gotoAndStop(_tipsData.attributeList[num].arrow);
				num++;
			}
			if (num < count)
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
				mcReloadSpeed.c34fce3bccfffc6feb3579939c6d9a057 = _tipsData.attributeList[num].color;
				mcReloadSpeed.text = (string)_tipsData.attributeList[num].value;
				mcReloadSpeedArrow.gotoAndStop(_tipsData.attributeList[num].arrow);
				num++;
			}
			if (num < count)
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
				mcClipSize.c34fce3bccfffc6feb3579939c6d9a057 = _tipsData.attributeList[num].color;
				mcClipSize.text = (string)_tipsData.attributeList[num].value;
				mcClipSizeArrow.gotoAndStop(_tipsData.attributeList[num].arrow);
				num++;
			}
			WeaponAttribute attribute = _showEntity.m_attribute;
			AttackInfo.ElementalType value = (AttackInfo.ElementalType)(attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ElementalType) as IntAttributeValue).m_value;
			bool visible;
			if (value != 0)
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
				if (num < count)
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
					if (num + 1 < count)
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
						string empty = string.Empty;
						MovieClip movieClip = mcElementDmg;
						visible = true;
						mcElementCoef.visible = visible;
						movieClip.visible = visible;
						mcElementDmg.gotoAndStop(UniUIManager.UniSWFToolClass._ElementFrameMap[value] + "0");
						mcElementCoef.gotoAndStop(UniUIManager.UniSWFToolClass._ElementFrameMap[value] + "0");
						txElementDmg.c34fce3bccfffc6feb3579939c6d9a057 = _tipsData.attributeList[num].color;
						txElementDmg.text = (string)_tipsData.attributeList[num].value;
						empty = _tipsData.attributeList[num++].arrow;
						mcElementDmgArrow.visible = empty != "none";
						mcElementDmgArrow.gotoAndStop(empty);
						txElementCoef.c34fce3bccfffc6feb3579939c6d9a057 = _tipsData.attributeList[num].color;
						txElementCoef.text = (string)_tipsData.attributeList[num].value;
						empty = _tipsData.attributeList[num++].arrow;
						mcElementCoefArrow.visible = empty != "none";
						mcElementCoefArrow.gotoAndStop(empty);
					}
				}
			}
			else
			{
				MovieClip movieClip2 = mcElementDmgArrow;
				visible = false;
				mcElementCoef.visible = visible;
				visible = visible;
				mcElementDmg.visible = visible;
				visible = visible;
				mcElementCoefArrow.visible = visible;
				movieClip2.visible = visible;
				UnityTextField unityTextField = txElementDmg;
				string empty2 = string.Empty;
				txElementCoef.text = empty2;
				unityTextField.text = empty2;
			}
			MovieClip movieClip3 = mcDamageArrow;
			visible = _bShowArrow;
			mcClipSizeArrow.visible = visible;
			visible = visible;
			mcReloadSpeedArrow.visible = visible;
			visible = visible;
			mcFireRateArrow.visible = visible;
			visible = visible;
			mcAccuracyArrow.visible = visible;
			movieClip3.visible = visible;
			return;
		}
	}

	protected virtual void c9faa54a7033ae745575aa65c49f30969()
	{
		mcName = mcRoot.getChildByName<UnityTextField>("mcName");
		mcDamage = mcRoot.getChildByName<UnityTextField>("mcDamage");
		mcAccuracy = mcRoot.getChildByName<UnityTextField>("mcAccuracy");
		mcFireRate = mcRoot.getChildByName<UnityTextField>("mcFireRate");
		mcReloadSpeed = mcRoot.getChildByName<UnityTextField>("mcReloadSpeed");
		mcClipSize = mcRoot.getChildByName<UnityTextField>("mcClipSize");
		mcDamageArrow = mcRoot.getChildByName<MovieClip>("mcDamageArrow");
		mcAccuracyArrow = mcRoot.getChildByName<MovieClip>("mcAccuracyArrow");
		mcFireRateArrow = mcRoot.getChildByName<MovieClip>("mcFireRateArrow");
		mcReloadSpeedArrow = mcRoot.getChildByName<MovieClip>("mcReloadSpeedArrow");
		mcClipSizeArrow = mcRoot.getChildByName<MovieClip>("mcClipSizeArrow");
		mcBrand = mcRoot.getChildByName<MovieClip>("gunbrand");
		txElementDmg = mcRoot.getChildByName<UnityTextField>("txElementDmg");
		mcElementDmg = mcRoot.getChildByName<MovieClip>("mcElementDmg");
		mcElementDmgArrow = mcRoot.getChildByName<MovieClip>("mcElementDmgArrow");
		txElementCoef = mcRoot.getChildByName<UnityTextField>("txElementCoef");
		mcElementCoef = mcRoot.getChildByName<MovieClip>("mcElementCoef");
		mcElementCoefArrow = mcRoot.getChildByName<MovieClip>("mcElementCoefArrow");
		MovieClip childByName = mcRoot.getChildByName<MovieClip>("weapontype");
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
			mcRarity1 = childByName.getChildAt(0) as Sprite;
		}
		childByName = mcRoot.getChildByName<MovieClip>("weapontype_d");
		if (childByName == null)
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
			mcRarity2 = childByName.getChildAt(0) as Sprite;
			return;
		}
	}

	private void cfed16e7f2a0c5a927833018d8a3c50e6(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		mcSelf.visible = false;
		mcRootRoot.removeAllEventListeners(CEvent.ENTER_FRAME);
		_showEntity = cc607e9943fa3c5044ada833720c23c9a.c7088de59e49f7108f520cf7e0bae167e;
		_compareEntity = cc607e9943fa3c5044ada833720c23c9a.c7088de59e49f7108f520cf7e0bae167e;
		_bEntityDisplaying = _compareEntity != cc607e9943fa3c5044ada833720c23c9a.c7088de59e49f7108f520cf7e0bae167e;
		_bShowArrow = false;
	}

	private void c729f0f3da43fe351d2a333618a48a6db(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		if (!_bShowArrow)
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
			mcRootRoot.stop();
			return;
		}
	}

	public virtual void c58de56793cb96a279858c7b68a326d17(WeaponDNA c32fb601f955251e397f3d29075f51208, WeaponDNA c04d182ebd13b8bf7e53d75bb60be41b1 = null)
	{
		if (c32fb601f955251e397f3d29075f51208 == null)
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
			if (c04d182ebd13b8bf7e53d75bb60be41b1 == null)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						if (!_bEntityDisplaying)
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
							if (_compareEntity == null)
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
								break;
							}
						}
						c1b6dfffa2aeed0a61dd7747f6dd7eed7();
						return;
					}
				}
			}
		}
		if (c04d182ebd13b8bf7e53d75bb60be41b1 == null)
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
			if (_bShowArrow)
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
		}
		if (_showEntity == c32fb601f955251e397f3d29075f51208)
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
			if (_compareEntity == c04d182ebd13b8bf7e53d75bb60be41b1)
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
		}
		_showEntity = c32fb601f955251e397f3d29075f51208;
		_compareEntity = c04d182ebd13b8bf7e53d75bb60be41b1;
		_bEntityDisplaying = _compareEntity != cc607e9943fa3c5044ada833720c23c9a.c7088de59e49f7108f520cf7e0bae167e;
		mcSelf.visible = true;
		_bShowArrow = c04d182ebd13b8bf7e53d75bb60be41b1 != cc607e9943fa3c5044ada833720c23c9a.c7088de59e49f7108f520cf7e0bae167e;
		if (c04d182ebd13b8bf7e53d75bb60be41b1 != null)
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
			if (c32fb601f955251e397f3d29075f51208 == null)
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
				_showEntity = c04d182ebd13b8bf7e53d75bb60be41b1;
				_compareEntity = c32fb601f955251e397f3d29075f51208;
				_bEntityDisplaying = _compareEntity != cc607e9943fa3c5044ada833720c23c9a.c7088de59e49f7108f520cf7e0bae167e;
				_bShowArrow = false;
			}
		}
		_tipsData = ItemCardPanel.cfa5ab8a3a1b0bbe4ab6ea32a3cbe648e(_showEntity, _compareEntity, true);
		mcRootRoot.addEventListener(CEvent.ENTER_FRAME, cb858f4c907c42c1ea4be312cf85f7f91);
		mcRootRoot.addFrameScript("off", cfed16e7f2a0c5a927833018d8a3c50e6);
		if (_bShowArrow)
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
			mcRootRoot.addFrameScript("AnimationEnd", c729f0f3da43fe351d2a333618a48a6db);
		}
		mcRootRoot.gotoAndPlay("in");
	}

	public void c1b6dfffa2aeed0a61dd7747f6dd7eed7()
	{
		_showEntity = cc607e9943fa3c5044ada833720c23c9a.c7088de59e49f7108f520cf7e0bae167e;
		_compareEntity = cc607e9943fa3c5044ada833720c23c9a.c7088de59e49f7108f520cf7e0bae167e;
		_bEntityDisplaying = _compareEntity != cc607e9943fa3c5044ada833720c23c9a.c7088de59e49f7108f520cf7e0bae167e;
		_bShowArrow = false;
		mcRootRoot.removeAllEventListeners(CEvent.ENTER_FRAME);
		mcRootRoot.addFrameScript("off", cfed16e7f2a0c5a927833018d8a3c50e6);
		mcRootRoot.gotoAndPlay("out");
	}
}
