using System;
using A;
using UnityEngine;

public class WeaponPreviewView : BaseView
{
	public delegate void OnHideWeaponPreview();

	protected OnHideWeaponPreview _onHideWeaponPreview;

	protected GameObject m_ShowingModel;

	protected float mWpnRotSpeed;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		c0027208817ce8ec1d561f1d34af428c3();
	}

	public virtual void c0027208817ce8ec1d561f1d34af428c3()
	{
		c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.ce9030196d2dbfbe5a5051960f05df6d0().c9ff0f0f2e42ce6e75d98e84a884b4452(false);
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<CharInfoView>().c5942a289bb847abf2556f0b87b099420(true);
		c150264a18c2cb408479d3f072cac8cc1 = false;
		if (_onHideWeaponPreview == null)
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
			_onHideWeaponPreview();
			return;
		}
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c4717862155dcb63da4094ee983c75b38 = !c8be1fcd630e5fe96821376d111325750;
	}

	public virtual void c6187275e7336eafc3a9acc48a6644c55(WeaponDNA c39409683a32e09391d094314ffeae2b5, bool c69f0839d89f39802a18f6c3bcc72251a = true)
	{
		c150264a18c2cb408479d3f072cac8cc1 = true;
		c1ee7921b0c3cce194fb7cae41b5a9d82<QuestServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.cbd003204f631ee0c3edf8bfdbedafd12();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<CharInfoView>().c5942a289bb847abf2556f0b87b099420(false);
		c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.ce9030196d2dbfbe5a5051960f05df6d0().c9ff0f0f2e42ce6e75d98e84a884b4452(true);
	}

	public void c8a5f81fef417fc7b869decf09e301d68(OnHideWeaponPreview c2be4c75e5f74d59035d5eef61f2f8466)
	{
		_onHideWeaponPreview = (OnHideWeaponPreview)Delegate.Combine(_onHideWeaponPreview, c2be4c75e5f74d59035d5eef61f2f8466);
	}

	public void c32ff7c8655496ee6330280eb097e7940(OnHideWeaponPreview c2be4c75e5f74d59035d5eef61f2f8466)
	{
		_onHideWeaponPreview = (OnHideWeaponPreview)Delegate.Remove(_onHideWeaponPreview, c2be4c75e5f74d59035d5eef61f2f8466);
	}

	protected virtual void ce8af2c8f82327e7e5e38406619641a76()
	{
		if (!(m_ShowingModel != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			SkinnedMeshRenderer skinnedMeshRenderer = BuildingKitGenerator.cc9bfa7a11dd9e2e916f75a4eb41a63ab(m_ShowingModel);
			Vector3 center = skinnedMeshRenderer.bounds.center;
			if (c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.c0c86fb4d044c654b1e26019953887548("Fire1"))
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
				float num = mWpnRotSpeed;
				float num2 = (0f - Input.GetAxis("Mouse X")) * num;
				float num3 = (0f - Input.GetAxis("Mouse Y")) * num;
				float num4 = Math.Abs(num2);
				float num5 = Math.Abs(num3);
				if (!(num4 > 0.01f))
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
					if (!(num5 > 0.01f))
					{
						goto IL_016e;
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
				if (num4 > num5)
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
						num *= -1f;
					}
					m_ShowingModel.transform.RotateAround(center, Vector3.up, num * Time.deltaTime);
				}
				else
				{
					if (num3 < 0f)
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
						num *= -1f;
					}
					m_ShowingModel.transform.RotateAround(center, m_ShowingModel.transform.forward, num * Time.deltaTime);
				}
			}
			goto IL_016e;
			IL_016e:
			float num6 = c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.c8bb22a671c1c2a7c9a01ddc52a812d1d("SwitchWeapon");
			float num7 = 0.2f;
			if (num6 < 0f)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						m_ShowingModel.transform.position += Vector3.forward * num7;
						return;
					}
				}
			}
			if (!(num6 > 0f))
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
				m_ShowingModel.transform.position -= Vector3.forward * num7;
				return;
			}
		}
	}
}
