using System.Collections;
using System.Collections.Generic;
using A;
using Photon;
using UnityEngine;
using XsdSettings;

public abstract class EquipmentInventoryEntity : Photon.MonoBehaviour
{
	public enum PropertyFlags
	{
		None = 0,
		InBattle = 1,
		Flag1 = 2,
		Flag2 = 4,
		Flag3 = 8,
		Flag4 = 16,
		Flag5 = 32,
		Flag6 = 64,
		Flag7 = 128,
		All = int.MaxValue
	}

	protected Entity m_entity;

	protected List<Utils.PouchNetwork> m_pouchList = new List<Utils.PouchNetwork>();

	public abstract int ccfad1bf47b003333c5ddd084f14d33e7();

	public abstract void c9af7b3e5f6626ceef1a0036138121839(int c19e024b5bcbd347892bec27154c527de);

	public virtual int cdee885326dc3732f50e8ea26f8cbfb73()
	{
		return 0;
	}

	public virtual void c34fa9ca078c2cc90fb0cae8284ed10d7(int c19e024b5bcbd347892bec27154c527de)
	{
	}

	public abstract int ca2ff7a501878363cb1d5f0472e306620();

	public abstract void cf0a63fdc9831dd55ae40ac6a5f5eb7e0(int c19e024b5bcbd347892bec27154c527de);

	public virtual int ce7804365a7377021025c46a16aa79db4()
	{
		return 0;
	}

	public virtual int ca937003ba4cbf4130cad1fcc9da2873e()
	{
		return 0;
	}

	public virtual void c405b3c9891c62259c5917e975ecd6145(int c83130c8b3cb0bca5da0dd22b9693898d)
	{
	}

	public virtual void c521b7affa3889eae158dbd009bbe95cb(int c83130c8b3cb0bca5da0dd22b9693898d)
	{
	}

	public virtual int c8a605fa1a9c2a71cfb141d9433f2f958(AmmoType c1e73ae4c18ab95639cb0c7604f21dc2b = AmmoType.SMG)
	{
		return 0;
	}

	public virtual int c899909cfce72c3526b0e233b21dcf395(WeaponType c39409683a32e09391d094314ffeae2b5)
	{
		return 0;
	}

	public virtual int c78d9aede4c30f70263e7312e02202ac1(WeaponType c2b4f43f34e21572af6ab4414f04cee36)
	{
		return 0;
	}

	public virtual int c19b70ea6e4db0802bb7cae385cc85109(AmmoType c1e73ae4c18ab95639cb0c7604f21dc2b = AmmoType.SMG)
	{
		return 0;
	}

	public virtual void c21ad47204b5c92fdbb3d4d6a2babb082(int cfd8fa226b0f9739fe464bf6cf939f561, AmmoType c1e73ae4c18ab95639cb0c7604f21dc2b = AmmoType.SMG)
	{
	}

	public virtual int c5c30fc221fd2805f9535a08995b34b98(WeaponType c21171aa66b09d27be1f523137627333d)
	{
		return 0;
	}

	public virtual void ce653df38cbca26f91f2e8654ccc7b048(int cfd8fa226b0f9739fe464bf6cf939f561, WeaponType c21171aa66b09d27be1f523137627333d)
	{
	}

	public virtual void c2d2d33b57e3f95d0673fb35826ea2dc8(int cfd8fa226b0f9739fe464bf6cf939f561, WeaponType c2b4f43f34e21572af6ab4414f04cee36)
	{
	}

	public virtual int c4864359b53f3eb339247aab4edeb1fe5()
	{
		return 0;
	}

	public virtual int cc0b9d3080e1a0c182204b250d657b977()
	{
		return 0;
	}

	public virtual void ce997541d3ac9e95ddee7d477001213a0(int cfd8fa226b0f9739fe464bf6cf939f561)
	{
	}

	public virtual int c43a75ebc3bb03dc214576d3b5b1a1301()
	{
		return 0;
	}

	public virtual void ccd54745b619f8623af9ba6da7437e69b(int cfd8fa226b0f9739fe464bf6cf939f561)
	{
	}

	public virtual byte c7513e66c4e0fc55e6fea9dd9cb8b9943()
	{
		return 0;
	}

	public virtual PropertyFlags c8636e472c72127553c97e9fcab49f723()
	{
		return PropertyFlags.None;
	}

	public virtual void c830fb918b7a26abced3d1b85d11d53a0(PropertyFlags c1241d2df0b8d540930a28f541f89b2c5)
	{
	}

	public virtual EntityShield cb4633378bdf6d47c409332e395d58c7a()
	{
		return null;
	}

	public virtual EntityWeapon cdda217ef6662acf86a5584ba19758192()
	{
		return null;
	}

	public virtual EntityWeapon c4e0dae6a16a8a80ddb5214a896b9df58(byte ccdfba09818795b7154978e955acab94a)
	{
		return null;
	}

	public virtual int c0e018ed0ee4ac2592fafd36d256cd617(WeakPoint c38b98045365f4b50a4fbe3f1d89af089)
	{
		return 0;
	}

	public virtual int ccfad1bf47b003333c5ddd084f14d33e7(WeakPoint c38b98045365f4b50a4fbe3f1d89af089)
	{
		return 0;
	}

	public virtual void c15ecef7ebaa3979b9ad1ce64ac8a6c25(WeakPoint c38b98045365f4b50a4fbe3f1d89af089, int c19e024b5bcbd347892bec27154c527de)
	{
	}

	public virtual void cd93285db16841148ed53a5bbeb35cf20(byte cd6bb591c33b2ee3ab93e98aa43a6da63, int cb75bb7e4635f59359605d47e3ee3541b)
	{
	}

	public virtual void cd93285db16841148ed53a5bbeb35cf20(byte cd6bb591c33b2ee3ab93e98aa43a6da63)
	{
	}

	public virtual void Start()
	{
		if (!DamageManager.c5ee19dc8d4cccf5ae2de225410458b86)
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
			DamageManager.c5ee19dc8d4cccf5ae2de225410458b86.cf3d2cb82d21abb0d2de84f85c25fdb49(GetComponent<Entity>());
			return;
		}
	}

	private void OnDestroy()
	{
		if (!DamageManager.c5ee19dc8d4cccf5ae2de225410458b86)
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
			DamageManager.c5ee19dc8d4cccf5ae2de225410458b86.cd5e20c96aa545559531f1792ec0f8b61(GetComponent<Entity>());
			return;
		}
	}

	public virtual void c06ade3733c4658b091be622d9d3b4034()
	{
		using (List<Utils.PouchNetwork>.Enumerator enumerator = m_pouchList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Utils.PouchNetwork current = enumerator.Current;
				current.c06ade3733c4658b091be622d9d3b4034();
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
				return;
			}
		}
	}

	public virtual void cdfac57bd798072bd71a801c00909ad5c()
	{
		using (List<Utils.PouchNetwork>.Enumerator enumerator = m_pouchList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Utils.PouchNetwork current = enumerator.Current;
				current.cdfac57bd798072bd71a801c00909ad5c();
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

	public virtual Hashtable c07eadde5914bc707bfda0013beb8972c()
	{
		Hashtable hashtable = new Hashtable();
		int num = 0;
		hashtable[num++] = ccfad1bf47b003333c5ddd084f14d33e7();
		hashtable[num++] = ca2ff7a501878363cb1d5f0472e306620();
		hashtable[num++] = ca937003ba4cbf4130cad1fcc9da2873e();
		hashtable[num++] = ce7804365a7377021025c46a16aa79db4();
		return hashtable;
	}

	public virtual void caece940d1c226511b3cca16fa8aa6a38(Hashtable c591d56a94543e3559945c497f37126c4)
	{
		int num = 0;
		int c19e024b5bcbd347892bec27154c527de = (int)c591d56a94543e3559945c497f37126c4[num++];
		int c19e024b5bcbd347892bec27154c527de2 = (int)c591d56a94543e3559945c497f37126c4[num++];
		int c83130c8b3cb0bca5da0dd22b9693898d = (int)c591d56a94543e3559945c497f37126c4[num++];
		int c83130c8b3cb0bca5da0dd22b9693898d2 = (int)c591d56a94543e3559945c497f37126c4[num++];
		c9af7b3e5f6626ceef1a0036138121839(c19e024b5bcbd347892bec27154c527de);
		cf0a63fdc9831dd55ae40ac6a5f5eb7e0(c19e024b5bcbd347892bec27154c527de2);
		c405b3c9891c62259c5917e975ecd6145(c83130c8b3cb0bca5da0dd22b9693898d);
		c521b7affa3889eae158dbd009bbe95cb(c83130c8b3cb0bca5da0dd22b9693898d2);
	}

	public void c87b9fec8b277580dc8b52d15d6d96b87()
	{
		Hashtable hashtable = c07eadde5914bc707bfda0013beb8972c();
		PhotonView obj = base.photonView;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = hashtable;
		obj.c19fd12ed98be2a9174d53644dc9757c8("RPC_SendLifeAndShield", PhotonTargets.Others, array);
	}

	[RPC]
	protected void RPC_SendLifeAndShield(Hashtable data)
	{
		c06ade3733c4658b091be622d9d3b4034();
		caece940d1c226511b3cca16fa8aa6a38(data);
	}
}
