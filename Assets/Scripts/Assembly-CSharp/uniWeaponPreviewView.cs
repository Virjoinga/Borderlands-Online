using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using UnityEngine;
using pumpkin.display;
using pumpkin.events;

public class uniWeaponPreviewView : WeaponPreviewView
{
	public class WeaponPreviewPanel : c196099a1254db61d3be10d70e14e7422
	{
		protected c82f7c0afbcfc8c5382a8c6daa9365b7b mcCancelBtn;

		protected MovieClip mcBG;

		protected c7beefc397f483dc0b72dcd3e6bdcf929 mcPortrait;

		[CompilerGenerated]
		private static Dictionary<string, int> _003C_003Ef__switch_0024map32;

		public virtual bool c150264a18c2cb408479d3f072cac8cc1
		{
			get
			{
				return base.c89ef242f4744e0f1c4ffea4da8b79bc1.visible;
			}
			set
			{
				base.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = value;
			}
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			base.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = false;
		}

		public virtual void c533af2b08173b7c2e3e5405efc254ee3(Texture c6d413f6463b3789f207ab004a5b98f40, Rect cadc118b5c81bb89bf38380c9747869ba)
		{
			if (mcPortrait == null)
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
				mcPortrait.c533af2b08173b7c2e3e5405efc254ee3(c6d413f6463b3789f207ab004a5b98f40, cadc118b5c81bb89bf38380c9747869ba);
				return;
			}
		}

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool result = false;
			string name = movieClip.name;
			if (name != null)
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
				if (_003C_003Ef__switch_0024map32 == null)
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
					Dictionary<string, int> dictionary = new Dictionary<string, int>(3);
					dictionary.Add("mcCancelBtn", 0);
					dictionary.Add("mcPortrait", 1);
					dictionary.Add("mcBG", 2);
					_003C_003Ef__switch_0024map32 = dictionary;
				}
				int value;
				if (_003C_003Ef__switch_0024map32.TryGetValue(name, out value))
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
					switch (value)
					{
					case 0:
						mcCancelBtn = new c82f7c0afbcfc8c5382a8c6daa9365b7b();
						mcCancelBtn.c130648b59a0c8debea60aa153f844879(movieClip);
						mcCancelBtn.addEventListener(MouseEvent.CLICK, c4688532094c84662fd34fb5a0fba01e7);
						result = true;
						break;
					case 1:
						mcPortrait = new c7beefc397f483dc0b72dcd3e6bdcf929();
						mcPortrait.c130648b59a0c8debea60aa153f844879(movieClip);
						result = true;
						break;
					case 2:
						mcBG = movieClip;
						result = true;
						break;
					}
				}
			}
			return result;
		}

		protected void c4688532094c84662fd34fb5a0fba01e7(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			dispatchEvent(new CEvent("Closing"));
		}

		public void c86b587fb92daf247d1b3abe04147cde4(bool c8be1fcd630e5fe96821376d111325750)
		{
			mcBG.visible = c8be1fcd630e5fe96821376d111325750;
			mcCancelBtn.c150264a18c2cb408479d3f072cac8cc1 = c8be1fcd630e5fe96821376d111325750;
		}

		public void c4874d27f4d9fce1b6be4d89660d0afc8(DisplayObject ceeadc1fedbc36762c176deab5162ee0e)
		{
			int childIndex = base.c89ef242f4744e0f1c4ffea4da8b79bc1.getChildIndex(mcPortrait.c89ef242f4744e0f1c4ffea4da8b79bc1);
			base.c89ef242f4744e0f1c4ffea4da8b79bc1.addChildAt(ceeadc1fedbc36762c176deab5162ee0e, childIndex);
		}
	}

	protected ItemCardPanel m_WeaponCard;

	protected WeaponPreviewPanel m_PreviewPanel;

	protected bool _bWeaponResLoaded;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		_bActive = false;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("Weapon_review.swf", "MainPanel", c664d93654a9f216d1350734720c326df);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("Tips.swf", "Panel_Tips_Card", cc139671fc499493f575387327ccbc7f3);
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		m_WeaponCard = c4c66dabfe7f2d9117be656807991c47b.c7088de59e49f7108f520cf7e0bae167e;
		m_PreviewPanel = null;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("Weapon_review.swf");
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("Tips.swf");
	}

	private void cc139671fc499493f575387327ccbc7f3(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		m_WeaponCard = new ItemCardPanel();
		m_WeaponCard.c130648b59a0c8debea60aa153f844879(new MovieClip());
		m_WeaponCard.cd351226c5175db6eab2a3dd9ec9ff57c(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		c03b68938a1a771df24ec59a531d0bfad();
	}

	private void c03b68938a1a771df24ec59a531d0bfad()
	{
		if (m_PreviewPanel == null)
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
			if (m_WeaponCard == null)
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
			(m_PreviewPanel.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip).stopAll();
			m_PreviewPanel.c4874d27f4d9fce1b6be4d89660d0afc8(m_WeaponCard.c89ef242f4744e0f1c4ffea4da8b79bc1);
			m_WeaponCard.c89ef242f4744e0f1c4ffea4da8b79bc1.x = 0f;
			return;
		}
	}

	private void c664d93654a9f216d1350734720c326df(MovieClip cbe9ca8ddb3cdc2312e6ff8411b2db2c8)
	{
		m_PreviewPanel = new WeaponPreviewPanel();
		m_PreviewPanel.c130648b59a0c8debea60aa153f844879(cbe9ca8ddb3cdc2312e6ff8411b2db2c8);
		m_PreviewPanel.addEventListener("Closing", ce4f702f44ab0a078206aa5fdd8952287);
		_bWeaponResLoaded = true;
		_bActive = true;
		c03b68938a1a771df24ec59a531d0bfad();
	}

	public override bool cc130a2d46a451dc54b61a8f0d60794ae()
	{
		if (m_PreviewPanel != null)
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
			if (m_PreviewPanel.c150264a18c2cb408479d3f072cac8cc1)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						c0027208817ce8ec1d561f1d34af428c3();
						return true;
					}
				}
			}
		}
		return base.cc130a2d46a451dc54b61a8f0d60794ae();
	}

	public override void c0027208817ce8ec1d561f1d34af428c3()
	{
		base.c0027208817ce8ec1d561f1d34af428c3();
		if (m_PreviewPanel != null)
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
			m_PreviewPanel.c150264a18c2cb408479d3f072cac8cc1 = false;
		}
		if (m_ShowingModel != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c0bd653723f77fd78e6c7d4d25ed14dcd(ce8af2c8f82327e7e5e38406619641a76);
			UnityEngine.Object.DestroyObject(m_ShowingModel);
			m_ShowingModel = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
		}
		if (m_WeaponCard != null)
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
			m_WeaponCard.c58de56793cb96a279858c7b68a326d17(null, c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e);
		}
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(m_PreviewPanel);
	}

	public void c55f17871c3376b87483caf11ac9597a8(ref GameObject cd1505a8bc35681ef0fed8cd958a8b539, WeaponDNA caedbc1db6c28d44eab6021e7d674eab3)
	{
		SkinnedMeshRenderer skinnedMeshRenderer = BuildingKitGenerator.cc9bfa7a11dd9e2e916f75a4eb41a63ab(cd1505a8bc35681ef0fed8cd958a8b539);
		skinnedMeshRenderer.material.SetTexture("_Cube", c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_levelCubemap);
		EntityWeapon.c1395e48881f07b054bc50fabaea80b76(cd1505a8bc35681ef0fed8cd958a8b539, EntityWeapon.c338e1019b68c1ba415414bd8d6cd4cae(caedbc1db6c28d44eab6021e7d674eab3.m_attribute));
		Vector3 extents = skinnedMeshRenderer.bounds.extents;
		Vector3 center = skinnedMeshRenderer.bounds.center;
		float[] array = c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.ce9030196d2dbfbe5a5051960f05df6d0().c1bcd51703b6984f7ac454c1dd6c69c8a();
		float[] array2 = c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.ce9030196d2dbfbe5a5051960f05df6d0().c13478151a197778390e347c292ebea1a();
		float num = 1f;
		if (cd1505a8bc35681ef0fed8cd958a8b539.name.ToLower().Contains("snr"))
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
			if (array.Length > 0)
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
				if (array2.Length > 0)
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
					num = array[0];
					mWpnRotSpeed = array2[0];
					goto IL_026a;
				}
			}
		}
		if (cd1505a8bc35681ef0fed8cd958a8b539.name.ToLower().Contains("smg"))
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
			if (array.Length > 1)
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
				if (array2.Length > 1)
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
					num = array[1];
					mWpnRotSpeed = array2[1];
					goto IL_026a;
				}
			}
		}
		if (cd1505a8bc35681ef0fed8cd958a8b539.name.ToLower().Contains("shn"))
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
			if (array.Length > 2)
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
				if (array2.Length > 2)
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
					num = array[2];
					mWpnRotSpeed = array2[2];
					goto IL_026a;
				}
			}
		}
		if (cd1505a8bc35681ef0fed8cd958a8b539.name.ToLower().Contains("rep"))
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
			if (array.Length > 3)
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
				if (array2.Length > 3)
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
					num = array[3];
					mWpnRotSpeed = array2[3];
					goto IL_026a;
				}
			}
		}
		if (cd1505a8bc35681ef0fed8cd958a8b539.name.ToLower().Contains("cor"))
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
			if (array.Length > 4)
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
				if (array2.Length > 4)
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
					num = array[4];
					mWpnRotSpeed = array2[4];
				}
			}
		}
		goto IL_026a;
		IL_026a:
		Vector3 c4d08ae331c26afaf32f24366155aeda = -center;
		MaterialHelper.cbf1c5cf9088f25c5aeaa81c33c6af2c1(cd1505a8bc35681ef0fed8cd958a8b539);
		c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.ce9030196d2dbfbe5a5051960f05df6d0().c6de8002d9a233bb083beb8d2a147d3b0(cd1505a8bc35681ef0fed8cd958a8b539, c4d08ae331c26afaf32f24366155aeda, new Vector3(0f, 0f, 0f), true);
		m_ShowingModel = cd1505a8bc35681ef0fed8cd958a8b539;
		m_ShowingModel.transform.RotateAround(Vector3.zero, Vector3.up, 90f);
		m_ShowingModel.transform.Translate(0f - (extents.z + num), 0f, 0f);
		Vector3 center2 = skinnedMeshRenderer.bounds.center;
		m_ShowingModel.transform.RotateAround(center2, Vector3.up, 180f);
		m_PreviewPanel.c533af2b08173b7c2e3e5405efc254ee3(c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.ce9030196d2dbfbe5a5051960f05df6d0().c9bf29a49cfe42cc19891e9333401d847(), new Rect(0f, 0f, 1f, 1f));
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c239889f6079aa61647e3c4b8f3627d00(ce8af2c8f82327e7e5e38406619641a76);
	}

	public override void c6187275e7336eafc3a9acc48a6644c55(WeaponDNA c39409683a32e09391d094314ffeae2b5, bool c69f0839d89f39802a18f6c3bcc72251a = true)
	{
		if (c39409683a32e09391d094314ffeae2b5 == null)
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
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c7d5a91af372c5abe00435cdf71f886ad(m_PreviewPanel);
		base.c6187275e7336eafc3a9acc48a6644c55(c39409683a32e09391d094314ffeae2b5, c69f0839d89f39802a18f6c3bcc72251a);
		if (m_PreviewPanel != null)
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
			m_PreviewPanel.c150264a18c2cb408479d3f072cac8cc1 = true;
			c06ca0e618478c23eba3419653a19760f<WeaponFactory>.c5ee19dc8d4cccf5ae2de225410458b86.cc5bc70567710d6a69882bdd6416a1db9(c39409683a32e09391d094314ffeae2b5, c55f17871c3376b87483caf11ac9597a8);
			m_PreviewPanel.c86b587fb92daf247d1b3abe04147cde4(c69f0839d89f39802a18f6c3bcc72251a);
		}
		if (m_WeaponCard == null)
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
			m_WeaponCard.c58de56793cb96a279858c7b68a326d17(ItemDNA.c8284b9f225995cc6a6e1888c9c037b06(c39409683a32e09391d094314ffeae2b5), c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e);
			return;
		}
	}

	protected void ce4f702f44ab0a078206aa5fdd8952287(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		c0027208817ce8ec1d561f1d34af428c3();
	}
}
