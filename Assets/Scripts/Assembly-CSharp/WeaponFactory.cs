using System;
using System.Collections;
using A;
using UnityEngine;
using XsdSettings;

public class WeaponFactory : c06ca0e618478c23eba3419653a19760f<WeaponFactory>
{
	private class CoroutineParam
	{
		public GameObject model;
	}

	public delegate void WeaponCreatedCallBack(ref GameObject model, WeaponDNA dna);

	private GameObject weaponElementalObject;

	protected override void Awake()
	{
		base.Awake();
	}

	private void Start()
	{
		weaponElementalObject = (GameObject)UnityEngine.Object.Instantiate(ResourcesLoader.c38aeacc59bd560b59403945ae7996d79("Particles/WeaponElementalManager"));
		weaponElementalObject.transform.parent = base.gameObject.transform;
	}

	public GameObject cc1971f70976931d09d855a4f000c417e()
	{
		return weaponElementalObject;
	}

	public void cc5bc70567710d6a69882bdd6416a1db9(WeaponDNA caedbc1db6c28d44eab6021e7d674eab3, WeaponCreatedCallBack c57d9051143d71d3b14e2cf4bc738012d)
	{
		if (c57d9051143d71d3b14e2cf4bc738012d == null)
		{
			while (true)
			{
				switch (1)
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
		StartCoroutine(c94ca9c14fae094191cbb97de513d7dd4(caedbc1db6c28d44eab6021e7d674eab3, c57d9051143d71d3b14e2cf4bc738012d));
	}

	private IEnumerator c94ca9c14fae094191cbb97de513d7dd4(WeaponDNA caedbc1db6c28d44eab6021e7d674eab3, WeaponCreatedCallBack c57d9051143d71d3b14e2cf4bc738012d)
	{
		CoroutineParam param = new CoroutineParam();
		yield return StartCoroutine(c45546d557e80a3e33e49ee02212faaf4(caedbc1db6c28d44eab6021e7d674eab3, param));
		c57d9051143d71d3b14e2cf4bc738012d(ref param.model, caedbc1db6c28d44eab6021e7d674eab3);
	}

	private IEnumerator c45546d557e80a3e33e49ee02212faaf4(WeaponDNA caedbc1db6c28d44eab6021e7d674eab3, CoroutineParam cd22aa6735988e8e65acbd503f3870e3e)
	{
		BuildingPart[] buidingParts = c015251fb9f02fd840fd03897a90706e4.c0a0cdf4a196914163f7334d9b0781a04(caedbc1db6c28d44eab6021e7d674eab3.m_subPartsCode.Length);
		for (int j = 0; j < caedbc1db6c28d44eab6021e7d674eab3.m_subPartsCode.Length; j++)
		{
			buidingParts[j] = new BuildingPart(SubPartStore.c2468dbf91d056d864da750fa5576bbef.cdbf696aded5fd1b462c05fbd81522f65(caedbc1db6c28d44eab6021e7d674eab3.m_subPartsCode[j]));
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
			BuildingKitRender buildingUnitRender = new BuildingKitRender(new BuildingUnit(buidingParts));
			BuildingKit kit = BuildingKitManager.cf35675a65469fa29b2d1a69927efca64(buildingUnitRender.ccf784a7191cc76b4e0c079ff7b1e7ac7.bkID);
			byte matIndex = buildingUnitRender.ccf784a7191cc76b4e0c079ff7b1e7ac7.mMats[buildingUnitRender.ccf784a7191cc76b4e0c079ff7b1e7ac7.mMats.Count - 1];
			for (int i = 0; i < kit.caa0fdc2398c34830d3d15f05bcff2020(); i++)
			{
				buildingUnitRender.ccf784a7191cc76b4e0c079ff7b1e7ac7.mMats[i] = matIndex;
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				if (!c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.OnlineHostMinResMode)
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
					yield return StartCoroutine(c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad618dcc0547ebee513a30332046d81f(buildingUnitRender.c0c98f9aa4067deab3caf8159826ae606(), OnAssetBundleLoaded, buildingUnitRender));
				}
				cd22aa6735988e8e65acbd503f3870e3e.model = buildingUnitRender.c3309affdc4b59cba5f457bbaec5f0762();
				yield break;
			}
		}
	}

	public IEnumerator cc864175eadf2cb0caddb6b43308a8afe(WeaponDNA caedbc1db6c28d44eab6021e7d674eab3, GameObject c0b8b4f11377b8a222dc728ff2c622559)
	{
		CoroutineParam param = new CoroutineParam();
		yield return StartCoroutine(c45546d557e80a3e33e49ee02212faaf4(caedbc1db6c28d44eab6021e7d674eab3, param));
		if (!(param.model != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
		{
			yield break;
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
			param.model.transform.parent = c0b8b4f11377b8a222dc728ff2c622559.transform;
			param.model.transform.localPosition = Vector3.zero;
			param.model.transform.localRotation = Quaternion.identity;
			yield break;
		}
	}

	public GameObject c7a2cb8c7425fd15999d90e446496ec69(ItemDNA c4ed717bfa8e3dbe7b0f04513d76a651e, GameObject c0b8b4f11377b8a222dc728ff2c622559)
	{
		CoroutineParam coroutineParam = new CoroutineParam();
		string c8aa0e7ee156ed339de23d3fe5557b = ItemGeneratorService.c474b312bbfb73d3e8ab0cf777f80e68c(c4ed717bfa8e3dbe7b0f04513d76a651e) + "_Model";
		coroutineParam.model = (GameObject)UnityEngine.Object.Instantiate(ResourcesLoader.c38aeacc59bd560b59403945ae7996d79(c8aa0e7ee156ed339de23d3fe5557b), Vector3.zero, Quaternion.identity);
		if (coroutineParam.model != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			coroutineParam.model.transform.parent = c0b8b4f11377b8a222dc728ff2c622559.transform;
			coroutineParam.model.transform.localPosition = Vector3.zero;
			coroutineParam.model.transform.localRotation = Quaternion.identity;
		}
		return coroutineParam.model;
	}

	public GameObject c509692699b2920501e9ab023be263d36(ItemDNA c4ed717bfa8e3dbe7b0f04513d76a651e, GameObject c0b8b4f11377b8a222dc728ff2c622559)
	{
		CoroutineParam coroutineParam = new CoroutineParam();
		string c8aa0e7ee156ed339de23d3fe5557b = ItemGeneratorService.c474b312bbfb73d3e8ab0cf777f80e68c(c4ed717bfa8e3dbe7b0f04513d76a651e);
		coroutineParam.model = (GameObject)UnityEngine.Object.Instantiate(ResourcesLoader.c38aeacc59bd560b59403945ae7996d79(c8aa0e7ee156ed339de23d3fe5557b), Vector3.zero, Quaternion.identity);
		if (coroutineParam.model != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			coroutineParam.model.transform.parent = c0b8b4f11377b8a222dc728ff2c622559.transform;
			coroutineParam.model.transform.localPosition = Vector3.zero;
			coroutineParam.model.transform.localRotation = Quaternion.identity;
			UnityEngine.Object.Destroy(coroutineParam.model.GetComponent<Pickable>());
			UnityEngine.Object.Destroy(coroutineParam.model.GetComponent<EntityClassMode>());
		}
		return coroutineParam.model;
	}

	private void OnAssetBundleLoaded(object param = null)
	{
	}

	public void c1b4573b967cc82fbdcd32cc6799f9a7b(EntityWeapon c39409683a32e09391d094314ffeae2b5)
	{
		if (c39409683a32e09391d094314ffeae2b5.c83e548e5608cd7f222098a6966b16545() != WeaponType.ShotGun)
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
			string text = "WPN_SHN_mag" + c39409683a32e09391d094314ffeae2b5.c7f910426b3f87db67b8af4c62170e282(WeaponSubPart.MAG) + "_1";
			IEnumerator enumerator = c39409683a32e09391d094314ffeae2b5.transform.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					Transform transform = (Transform)enumerator.Current;
					if (!(transform.name == text))
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
						UnityEngine.Object.DestroyImmediate(transform.gameObject);
						return;
					}
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable == null)
				{
					while (true)
					{
						switch (5)
						{
						case 0:
							break;
						default:
							goto end_IL_00ac;
						}
						continue;
						end_IL_00ac:
						break;
					}
				}
				else
				{
					disposable.Dispose();
				}
			}
		}
	}
}
