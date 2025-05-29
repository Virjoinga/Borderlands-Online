using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using Core;
using UnityEngine;
using pumpkin.display;
using pumpkin.events;

public class ItemTipsPanel : c196099a1254db61d3be10d70e14e7422
{
	protected const string ITEM_MOVIE_NAME = "Movie_attribute";

	protected const int TOP_MIN_HEIGHT = 50;

	protected MovieClip mcSelf;

	protected MovieClip mcTop;

	protected MovieClip mcBottom;

	protected MovieClip mcPrice;

	protected UnityTextField txMoney;

	protected UnityTextField txName;

	protected UnityTextField txLevelLabel;

	protected UnityTextField txLevelNumber;

	protected UnityTextField txEquiped;

	protected MovieClip mcType;

	protected MovieClip mcBrand;

	protected MovieClip mcLevelBg;

	protected MovieClip mcTypeBg;

	protected BadAssMovieClip mcColorCover;

	protected BadAssMovieClip mcBackGround;

	protected BadAssMovieClip mcBottomBg;

	protected MovieClip mcUpElem;

	protected List<MovieClip> _arrUpItemCache = new List<MovieClip>();

	protected MovieClip mcDownElem;

	protected List<MovieClip> _arrDownItemCache = new List<MovieClip>();

	protected ItemTipsData _tipsData;

	protected bool _bEntityDisplaying;

	protected bool _bShowArrow;

	protected float _fUpElemHeight;

	protected float _fDownElemHeight;

	[CompilerGenerated]
	private static Dictionary<string, int> _003C_003Ef__switch_0024map9;

	protected override void c969016383f47c249932cc75475f00ae1()
	{
		base.c969016383f47c249932cc75475f00ae1();
		mcSelf = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
		if (mcSelf == null)
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
					DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "UIWarning: ItemTipsPanel MovieClip missing!!");
					return;
				}
			}
		}
		mcSelf.mouseEnabled = false;
		mcSelf.stopAll();
		c9faa54a7033ae745575aa65c49f30969();
	}

	protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
	{
		bool result = false;
		string name = movieClip.name;
		if (name != null)
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
			if (_003C_003Ef__switch_0024map9 == null)
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
				Dictionary<string, int> dictionary = new Dictionary<string, int>(10);
				dictionary.Add("mcTop", 0);
				dictionary.Add("mcBottom", 1);
				dictionary.Add("mcPrice", 2);
				dictionary.Add("mcUpElem0", 3);
				dictionary.Add("mcDownElem0", 4);
				dictionary.Add("mcBackGround", 5);
				dictionary.Add("mcBottomBg", 6);
				dictionary.Add("mcLevelBg", 7);
				dictionary.Add("mcTypeBg", 8);
				dictionary.Add("mcColorCover", 9);
				_003C_003Ef__switch_0024map9 = dictionary;
			}
			int value;
			if (_003C_003Ef__switch_0024map9.TryGetValue(name, out value))
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
					mcTop = movieClip;
					result = false;
					break;
				case 1:
					mcBottom = movieClip;
					result = false;
					break;
				case 2:
					mcPrice = movieClip;
					mcPrice.visible = false;
					txMoney = mcPrice.getChildByName<UnityTextField>("txMoney");
					txMoney.c34fce3bccfffc6feb3579939c6d9a057 = Color.white;
					result = false;
					break;
				case 3:
					mcUpElem = movieClip;
					_fUpElemHeight = mcUpElem.height;
					_arrUpItemCache.Add(mcUpElem);
					result = true;
					break;
				case 4:
					mcDownElem = movieClip;
					_fDownElemHeight = mcDownElem.height;
					_arrDownItemCache.Add(mcDownElem);
					result = true;
					break;
				case 5:
					mcBackGround = movieClip as BadAssMovieClip;
					result = true;
					break;
				case 6:
					mcBottomBg = movieClip as BadAssMovieClip;
					result = true;
					break;
				case 7:
					mcLevelBg = movieClip;
					result = true;
					break;
				case 8:
					mcTypeBg = movieClip;
					result = true;
					break;
				case 9:
					mcColorCover = movieClip as BadAssMovieClip;
					result = true;
					break;
				}
			}
		}
		return result;
	}

	public void c4415aa0606651420b103929644cf44bd(ItemTipsData c90bf733de9278b700baad5f94807708f)
	{
		_tipsData = c90bf733de9278b700baad5f94807708f;
		if (_tipsData != null)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					base.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = true;
					txName.c34fce3bccfffc6feb3579939c6d9a057 = _tipsData.nameColor;
					txName.text = _tipsData.name;
					txLevelLabel.c34fce3bccfffc6feb3579939c6d9a057 = _tipsData.levelColor;
					txLevelNumber.c34fce3bccfffc6feb3579939c6d9a057 = _tipsData.levelColor;
					txLevelNumber.text = _tipsData.level.ToString();
					txEquiped.visible = _tipsData.bEquiped;
					if (_tipsData.item != null)
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
						mcType.visible = true;
						mcType.gotoAndStop(UniUIManager.UniSWFToolClass.cdb5e1aceb6b2fd7da6a4e3b93ab68865(_tipsData.item));
					}
					else
					{
						mcType.visible = false;
					}
					mcBrand.gotoAndStop(_tipsData.brand);
					UnityTextField unityTextField = txLevelLabel;
					bool visible = _tipsData.level > 0;
					mcLevelBg.visible = visible;
					unityTextField.visible = visible;
					MovieClip movieClip = mcLevelBg;
					object to;
					if (_tipsData.bEquiped)
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
						to = "equiped";
					}
					else
					{
						to = "normal";
					}
					movieClip.gotoAndStop(to);
					if (_tipsData.nameColor == Color.white)
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
						BadAssMovieClip badAssMovieClip = mcColorCover;
						visible = false;
						mcTypeBg.visible = visible;
						badAssMovieClip.visible = visible;
					}
					else
					{
						BadAssMovieClip badAssMovieClip2 = mcColorCover;
						visible = true;
						mcTypeBg.visible = visible;
						badAssMovieClip2.visible = visible;
						mcTypeBg.colorTransform = _tipsData.nameColor;
						mcColorCover.colorTransform = _tipsData.nameColor;
					}
					cc6d1e30f7b5d104722afe8ade2ed9a07();
					return;
				}
				}
			}
		}
		base.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = false;
	}

	public void cc6d1e30f7b5d104722afe8ade2ed9a07()
	{
		int num = Mathf.CeilToInt(_fUpElemHeight);
		int count = _tipsData.attributeList.Count;
		if (count > _arrUpItemCache.Count)
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
			for (int i = _arrUpItemCache.Count; i < count; i++)
			{
				MovieClip movieClip = mcUpElem.newInstance();
				movieClip.name = "mcUpElem" + i;
				mcTop.addChild(movieClip);
				movieClip.x = mcUpElem.x;
				movieClip.y = mcUpElem.y + (float)((num - 6) * i);
				_arrUpItemCache.Add(movieClip);
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
		for (int j = 0; j < _arrUpItemCache.Count; j++)
		{
			if (j < count)
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
				_arrUpItemCache[j].visible = true;
				c2767fc1bb176e9cc679756466248f712(_tipsData.attributeList[j], _arrUpItemCache[j]);
			}
			else
			{
				_arrUpItemCache[j].visible = false;
			}
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			int count2 = _tipsData.additionAttList.Count;
			if (count2 > _arrDownItemCache.Count)
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
				num = Mathf.CeilToInt(_fDownElemHeight);
				for (int k = _arrDownItemCache.Count; k < count2; k++)
				{
					MovieClip movieClip2 = mcDownElem.newInstance();
					movieClip2.name = "mcDownElem" + k;
					mcBottom.addChild(movieClip2);
					movieClip2.x = mcDownElem.x;
					movieClip2.y = mcDownElem.y + (float)((num - 6) * k);
					_arrDownItemCache.Add(movieClip2);
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
			for (int l = 0; l < _arrDownItemCache.Count; l++)
			{
				if (l < count2)
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
					_arrDownItemCache[l].visible = true;
					c2767fc1bb176e9cc679756466248f712(_tipsData.additionAttList[l], _arrDownItemCache[l]);
				}
				else
				{
					_arrDownItemCache[l].visible = false;
				}
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				mcBottom.visible = count2 > 0;
				float num2 = 55 + (num - 6) * count;
				BadAssMovieClip badAssMovieClip = mcBackGround;
				int cafa7da0299ba59f683e3c6bda7d0b9be;
				if (count2 > 0)
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
					cafa7da0299ba59f683e3c6bda7d0b9be = 6;
				}
				else
				{
					cafa7da0299ba59f683e3c6bda7d0b9be = 9;
				}
				badAssMovieClip.cafa7da0299ba59f683e3c6bda7d0b9be = cafa7da0299ba59f683e3c6bda7d0b9be;
				mcBackGround.cf7772a1df19641cd211b92f3f6b89005 = num2 + 50f;
				mcBottom.y = mcTop.y + num2 + 3f;
				float num3 = mcBottom.y + 16f;
				if (mcBottom.visible)
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
					float num4 = (num - 6) * count2;
					mcBottomBg.cf7772a1df19641cd211b92f3f6b89005 = 50f + num4;
					mcColorCover.cf7772a1df19641cd211b92f3f6b89005 = 32f + num4;
					num3 += num4;
				}
				if (mcPrice == null)
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
					mcPrice.visible = _tipsData.price > 0;
					mcPrice.y = num3;
					if (!mcPrice.visible)
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
						if (txMoney == null)
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
							txMoney.text = "<color='#1CAAFC'><b>$</b></color><color='#FFCC00'> " + Mathf.FloorToInt(c1ee7921b0c3cce194fb7cae41b5a9d82<ShopServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c4a75d81249f55113c773cfaeb64936ea.m_soldRatio * (float)_tipsData.price) + "</color>";
							return;
						}
					}
				}
			}
		}
	}

	protected void c2767fc1bb176e9cc679756466248f712(ItemElement cb4be6dae1755138c26d22542471266a1, MovieClip c255299938668dff22d03038e3157081b)
	{
		c255299938668dff22d03038e3157081b.userData = cb4be6dae1755138c26d22542471266a1;
		c255299938668dff22d03038e3157081b.gotoAndStop(cb4be6dae1755138c26d22542471266a1.eType.ToString());
		c255299938668dff22d03038e3157081b.addEventListener(CEvent.ENTER_FRAME, c46e596090190b1b2977a2f3cfb5d4008);
	}

	protected void c46e596090190b1b2977a2f3cfb5d4008(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		MovieClip movieClip = (MovieClip)c3d202dee321219a80026dc3081fb3c86.currentTarget;
		ItemElement itemElement = (ItemElement)movieClip.userData;
		switch (itemElement.eType)
		{
		case ETipsItemType.ITVA:
			movieClip.getChildByName<MovieClip>("iconType").gotoAndStop(itemElement.iconType);
			movieClip.getChildByName<UnityTextField>("title").text = itemElement.title;
			movieClip.getChildByName<UnityTextField>("value").c34fce3bccfffc6feb3579939c6d9a057 = itemElement.color;
			movieClip.getChildByName<UnityTextField>("value").text = (string)itemElement.value;
			movieClip.getChildByName<MovieClip>("arrow").gotoAndStop(itemElement.arrow);
			break;
		case ETipsItemType.TEXT:
			movieClip.getChildByName<UnityTextField>("text").c34fce3bccfffc6feb3579939c6d9a057 = itemElement.color;
			movieClip.getChildByName<UnityTextField>("text").text = (string)itemElement.value;
			break;
		case ETipsItemType.TV:
			movieClip.getChildByName<UnityTextField>("title").text = itemElement.title;
			movieClip.getChildByName<UnityTextField>("value").c34fce3bccfffc6feb3579939c6d9a057 = itemElement.color;
			movieClip.getChildByName<UnityTextField>("value").text = (string)itemElement.value;
			break;
		case ETipsItemType.TVA:
			movieClip.getChildByName<UnityTextField>("title").text = itemElement.title;
			movieClip.getChildByName<UnityTextField>("value").c34fce3bccfffc6feb3579939c6d9a057 = itemElement.color;
			movieClip.getChildByName<UnityTextField>("value").text = (string)itemElement.value;
			movieClip.getChildByName<MovieClip>("arrow").gotoAndStop(itemElement.arrow);
			break;
		case ETipsItemType.STAR:
		{
			int num = (int)itemElement.value;
			for (int i = 0; i < 9; i++)
			{
				movieClip.getChildByName("star" + i).visible = i < num;
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
	}

	protected virtual void c9faa54a7033ae745575aa65c49f30969()
	{
		txName = mcTop.getChildByName<UnityTextField>("txName");
		txLevelLabel = mcTop.getChildByName<UnityTextField>("txLevelLabel");
		txLevelLabel.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Level"));
		txLevelNumber = mcTop.getChildByName<UnityTextField>("txLevelNumber");
		txEquiped = mcTop.getChildByName<UnityTextField>("txEquiped");
		mcType = mcTop.getChildByName<MovieClip>("mcType");
		mcBrand = mcTop.getChildByName<MovieClip>("mcBrand");
	}
}
