using A;
using UnityEngine;
using XsdSettings;

public class HUDAimTargetView : BaseView
{
	private bool _bEUseTipShowing;

	protected E_USE_TYPE _curType;

	protected float _fCrossHairAccurate;

	protected float _fScopeCrossHairAccurate;

	protected E_SCOPE_TYPE _eAimMode = E_SCOPE_TYPE.E_NORMAL;

	protected bool _bAimed;

	protected Entity _aimedEntity;

	protected bool _isInSameTeam;

	protected WeaponType _weaponType = WeaponType.TOTAL;

	protected AttackInfo.ElementalType _elementalType = AttackInfo.ElementalType.Max;

	protected bool _bEntityDisplaying;

	protected EntityObject _interactingItem;

	protected ItemDNA _compareItem;

	protected EntityWeapon.ScopeMaskType _maskType;

	protected GameObject _iconObject;

	protected Vector3 _screenPosition = Vector3.zero;

	protected bool m_previousIconeMode = true;

	protected Transform _pillorTF;

	protected int _iLastExp = -1;

	public override void OnTestGUI()
	{
		if (_bEUseTipShowing)
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
			GUI.TextField(new Rect(640f, 400f, 100f, 25f), "[E] to Use");
		}
		GUI.TextField(new Rect(500f, 200f, 180f, 25f), "Accurate is:" + _fCrossHairAccurate);
		GUI.TextField(new Rect(500f, 230f, 180f, 25f), "Aim Mode:" + _eAimMode);
		if (_aimedEntity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			EquipmentInventoryEntity equipmentInventoryEntity = _aimedEntity.c5ca38fad98337fc5c7255384b2cd1a86();
			Rect position = new Rect(500f, 100f, 180f, 25f);
			object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
			array[0] = "HP:";
			array[1] = equipmentInventoryEntity.ca2ff7a501878363cb1d5f0472e306620();
			array[2] = "/";
			array[3] = equipmentInventoryEntity.ccfad1bf47b003333c5ddd084f14d33e7();
			GUI.TextField(position, string.Concat(array));
		}
		if (!(_interactingItem != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (!_interactingItem.c3fa5657ea791d3c8779428f0361d91e3())
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
				if (!_interactingItem.m_pickable.cab69fd15e36704ccac7469787a1570a0(c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().c66b232dbebded7c7e9a89c1e8bd84689()))
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
					WeaponAttribute attribute = (_interactingItem as EntityWeapon).m_attribute;
					string empty = string.Empty;
					empty += "LEVEL REQUIREMENT: 1";
					empty = empty + "Name:" + _interactingItem.m_name;
					empty = empty + "\nDamage:" + (attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.WeaponDamage) as FloatAttributeValue).m_value;
					empty = empty + "\nAccuracy:" + attribute.c2d32d874e045788b400f1b8bfd71f5f0();
					empty = empty + "\nFire Rate:" + (attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.FireRate) as FloatAttributeValue).m_value;
					empty = empty + "\nReload Speed:" + (attribute.c4e0f63f4b4d409c5e3992c71520e30a0(AttributeType.ReloadTime) as FloatAttributeValue).m_value;
					empty = empty + "\nMagazine Size:" + (_interactingItem as EntityWeapon).c68ed8789a1e844cef343f5216d74d25f();
					string text = empty;
					object[] array2 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
					array2[0] = text;
					array2[1] = "\nFactory: XX\tQuanlity:\tType:";
					array2[2] = _interactingItem.m_subType;
					array2[3] = "\n";
					empty = string.Concat(array2);
					empty += "Cost:30000\n";
					GUI.TextField(new Rect(500f, 100f, 180f, 200f), empty);
					return;
				}
			}
		}
	}

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		Camera c91fcf132a3585bad3597263bc = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c91fcf132a3585bad3597263bc8937405;
		if (c91fcf132a3585bad3597263bc != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			_screenPosition.Set(c91fcf132a3585bad3597263bc.pixelWidth / 2f, c91fcf132a3585bad3597263bc.pixelHeight / 2f, 0f);
		}
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c858f0c33158b659215d28b3c0548a38a(this);
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().ceb073876b67631e82266e224318dc9de(this);
		_weaponType = WeaponType.TOTAL;
		_screenPosition = Vector3.zero;
	}

	public virtual void c5c6d9b37e66c45c8c7187665713ece00(E_SCOPE_TYPE cf7c8dfabbc57dfde03eb82fbfba3b0f6 = E_SCOPE_TYPE.E_NORMAL)
	{
		_eAimMode = cf7c8dfabbc57dfde03eb82fbfba3b0f6;
	}

	public virtual void c33d552efca40d63443e0a504daea3912(float c52921fe9488ee3d539be727c81094423, float c08627fb03567104b28523ad64354582e = float.MaxValue)
	{
		_fCrossHairAccurate = c52921fe9488ee3d539be727c81094423;
		_fScopeCrossHairAccurate = c08627fb03567104b28523ad64354582e;
	}

	public virtual void c565fc8fc4a259a71ab4632066f71f0ea(E_USE_TYPE c2b4f43f34e21572af6ab4414f04cee36)
	{
		_curType = c2b4f43f34e21572af6ab4414f04cee36;
	}

	public virtual void cda9735eb2b55d94b17b1b29402d92fb0(WeaponType c27b7430edc94b8f5b543605119ec4a72)
	{
		_weaponType = c27b7430edc94b8f5b543605119ec4a72;
	}

	public virtual void ce5470d1dea6bb0b4672c182f148335a5(AttackInfo.ElementalType c40f84f48cad1ac39385c547c5bfdbfab)
	{
		_elementalType = c40f84f48cad1ac39385c547c5bfdbfab;
	}

	public virtual void c6623ef8b23a16416be968b58cad3128e(EntityWeapon.ScopeMaskType c6dee70a5413108b347b704b46ad579d1)
	{
		_maskType = c6dee70a5413108b347b704b46ad579d1;
	}

	public virtual void cd20042520dda2fb118d7aa058174cd2f(Entity c1b673d88dc2361383429c174b464e388, bool cd2cb6285cd9f694f5fec76ed066610af = false)
	{
		_isInSameTeam = cd2cb6285cd9f694f5fec76ed066610af;
		_aimedEntity = c1b673d88dc2361383429c174b464e388;
		_bAimed = _aimedEntity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e;
	}

	public virtual void c3c9511180c24847893800d15719d6ce7(EntityObject c964c502d159dbf5de81022d9a17777c6, bool cfb58918ecebf4f97714bdbfa75f6d2e9, bool ce1a685f96ee8e0bae312f3fce2a5fccc, ItemDNA c51036833e047abd9bdf1859fef67cecb = null)
	{
		if (c964c502d159dbf5de81022d9a17777c6 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
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
					if (!(_interactingItem != c964c502d159dbf5de81022d9a17777c6))
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
				_interactingItem = cd106b90ad49dbab480b1d65a61bd2d9e.c7088de59e49f7108f520cf7e0bae167e;
				_bEntityDisplaying = false;
				_pillorTF = ce1fb4d774e60a964105c162513d97b38.c7088de59e49f7108f520cf7e0bae167e;
				_compareItem = c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e;
				c19f79f487937dbc8d71c8b454a0457aa();
				return;
			}
		}
		Vector3 cef9712200bbe2c3873eec3ca2e18a = c85ccd1347541cced93922d773e654ed4(c964c502d159dbf5de81022d9a17777c6);
		Vector3 vector = c514bb030c5ba00a0b0269eb2f9a2f39d(c964c502d159dbf5de81022d9a17777c6);
		if (!(c964c502d159dbf5de81022d9a17777c6 != _interactingItem))
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
			if (m_previousIconeMode == cfb58918ecebf4f97714bdbfa75f6d2e9)
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
				if (_compareItem == c51036833e047abd9bdf1859fef67cecb)
				{
					goto IL_01c6;
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
		}
		c19f79f487937dbc8d71c8b454a0457aa();
		_pillorTF = c964c502d159dbf5de81022d9a17777c6.gameObject.transform.FindChild("LightPillor");
		cef9712200bbe2c3873eec3ca2e18a = c85ccd1347541cced93922d773e654ed4(c964c502d159dbf5de81022d9a17777c6);
		vector = c514bb030c5ba00a0b0269eb2f9a2f39d(c964c502d159dbf5de81022d9a17777c6);
		int num;
		if (_interactingItem == c964c502d159dbf5de81022d9a17777c6)
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
			num = ((_compareItem == c51036833e047abd9bdf1859fef67cecb) ? 1 : 0);
		}
		else
		{
			num = 0;
		}
		bool flag = (byte)num != 0;
		_interactingItem = c964c502d159dbf5de81022d9a17777c6;
		_bEntityDisplaying = true;
		_compareItem = c51036833e047abd9bdf1859fef67cecb;
		if (!cfb58918ecebf4f97714bdbfa75f6d2e9)
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
			switch (c964c502d159dbf5de81022d9a17777c6.c4622c7a1660020e5029da03e27491b37().m_type)
			{
			default:
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
				c9c30bd737ebcd34f4739e25847bb02b6(cef9712200bbe2c3873eec3ca2e18a, ce1a685f96ee8e0bae312f3fce2a5fccc);
				break;
			case ItemType.Weapon:
			case ItemType.Shield:
			case ItemType.ClassMode:
				if (flag)
				{
					break;
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
				c29226db8d29cd80b3b478968bad1c6ad();
				break;
			}
		}
		else
		{
			c9c30bd737ebcd34f4739e25847bb02b6(cef9712200bbe2c3873eec3ca2e18a, ce1a685f96ee8e0bae312f3fce2a5fccc);
		}
		m_previousIconeMode = cfb58918ecebf4f97714bdbfa75f6d2e9;
		goto IL_01c6;
		IL_01c6:
		Camera c91fcf132a3585bad3597263bc = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c91fcf132a3585bad3597263bc8937405;
		if (!(c91fcf132a3585bad3597263bc != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			Vector3 position = vector;
			position.y += 0.4f;
			float num2 = Vector3.Distance(vector, c91fcf132a3585bad3597263bc.transform.position);
			Ray ray = new Ray(c91fcf132a3585bad3597263bc.transform.position, c91fcf132a3585bad3597263bc.transform.forward);
			if (_pillorTF != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				RaycastHit hitInfo;
				if (_pillorTF.collider.Raycast(ray, out hitInfo, 10f))
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
					position.y = Mathf.Min(cef9712200bbe2c3873eec3ca2e18a.y - 0.2f, Mathf.Max(hitInfo.point.y, position.y));
					num2 = hitInfo.distance;
				}
			}
			num2 = 1.5f / num2;
			Vector2 cef9712200bbe2c3873eec3ca2e18a2 = c91fcf132a3585bad3597263bc.WorldToScreenPoint(position);
			cef9712200bbe2c3873eec3ca2e18a2.y = (float)Screen.height - cef9712200bbe2c3873eec3ca2e18a2.y + 40f;
			cdf9d64b8309c15ad1f048bdea5fb5520(cef9712200bbe2c3873eec3ca2e18a2, num2);
			return;
		}
	}

	public Vector3 c85ccd1347541cced93922d773e654ed4(EntityObject c964c502d159dbf5de81022d9a17777c6)
	{
		if (_pillorTF != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return _pillorTF.position + _pillorTF.lossyScale.y * Vector3.up;
				}
			}
		}
		return c964c502d159dbf5de81022d9a17777c6.gameObject.transform.position + c964c502d159dbf5de81022d9a17777c6.gameObject.transform.lossyScale.y * Vector3.up;
	}

	public Vector3 c514bb030c5ba00a0b0269eb2f9a2f39d(EntityObject c964c502d159dbf5de81022d9a17777c6)
	{
		if (_pillorTF != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return _pillorTF.position;
				}
			}
		}
		return c964c502d159dbf5de81022d9a17777c6.gameObject.transform.position;
	}

	public override bool OnScreenResized()
	{
		Camera c91fcf132a3585bad3597263bc = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c91fcf132a3585bad3597263bc8937405;
		if (c91fcf132a3585bad3597263bc != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			_screenPosition.Set(c91fcf132a3585bad3597263bc.pixelWidth / 2f, c91fcf132a3585bad3597263bc.pixelHeight / 2f, 0f);
		}
		return true;
	}

	public virtual void cae9272f30f937b8331c75c81fa5faaa6(int ca971b078d9d4342f9513f33480424967)
	{
		if (_iLastExp != -1)
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
			if (_iLastExp != ca971b078d9d4342f9513f33480424967)
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
				c94b5204c5fd60d429ba70c491ef9c7eb(ca971b078d9d4342f9513f33480424967 - _iLastExp);
			}
		}
		_iLastExp = ca971b078d9d4342f9513f33480424967;
	}

	public virtual void cd2e48af5036f9af603d95eb723ef7beb(EntityNpc c5d720f6d007abb0c4a21d6a654e405bb)
	{
	}

	public virtual void c49129feb5dd2a9881cc3a462a98d59b7()
	{
	}

	public virtual void cfa5c65236b46d49f65e56ec12a03c489()
	{
	}

	public virtual void cf5386f91e44d079b4719a30812cbf941(int cd6bb591c33b2ee3ab93e98aa43a6da63, string cd99af21e22e356018b8f72d4a7e4872a)
	{
	}

	public virtual void cf8c79459ba37498d40bc2aad6dc9c03a(int ca9418d63b770eac102bfc9f4297a1066, int ca4ca4714d7c458ac40f3dadb7f670c6e, int c0bb32bee3cf6dd96e41e00dc5a4ae21a, int ce9468aa2dd2bd99d09db5f068744c509)
	{
	}

	protected virtual void cdf9d64b8309c15ad1f048bdea5fb5520(Vector2 cef9712200bbe2c3873eec3ca2e18a595, float c52653cd226edee69dc40caf0157e2a97)
	{
	}

	protected virtual void c19f79f487937dbc8d71c8b454a0457aa()
	{
	}

	protected virtual void c29226db8d29cd80b3b478968bad1c6ad()
	{
	}

	protected virtual void c9c30bd737ebcd34f4739e25847bb02b6(Vector3 cef9712200bbe2c3873eec3ca2e18a595, bool c0ed1ae01e6d9fafe2906352a3dde6927)
	{
	}

	protected virtual void c94b5204c5fd60d429ba70c491ef9c7eb(int c4a37d36a3ef1e82fa8b2e1badb7fbfb5)
	{
	}
}
