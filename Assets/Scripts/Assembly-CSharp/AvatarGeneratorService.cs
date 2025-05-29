using System.Collections;
using A;
using Core;
using UnityEngine;
using XsdSettings;

public class AvatarGeneratorService : MonoBehaviour
{
	public IEnumerator c55b4878c03d9f87b4d34de1f79de2705(GameObject cfe0a1153f61dcdf419049830449301da, WeaponDNA c8845f28fdcd69fafc8894476a17e43db, byte c3003c6194f9f06563fb78310318e3417 = 0, bool c5a707433b54dfe00cc1ecec199a753a6 = false)
	{
		BuildingKitRender kitRender;
		switch (c8845f28fdcd69fafc8894476a17e43db.c83e548e5608cd7f222098a6966b16545())
		{
		case WeaponType.SMG:
			kitRender = new BuildingKitRender("WPN", "SMG");
			break;
		case WeaponType.ShotGun:
			kitRender = new BuildingKitRender("WPN", "ShotGun");
			break;
		case WeaponType.SniperRifle:
			kitRender = new BuildingKitRender("WPN", "SniperRifle");
			break;
		case WeaponType.CombatRifle:
			kitRender = new BuildingKitRender("WPN", "CombatRifle");
			break;
		case WeaponType.RepeaterPistol:
			kitRender = new BuildingKitRender("WPN", "RepeaterPistol");
			break;
		default:
			kitRender = new BuildingKitRender("WPN", "SMG");
			break;
		}
		kitRender.ccf784a7191cc76b4e0c079ff7b1e7ac7 = c8845f28fdcd69fafc8894476a17e43db.c0a44d3f083e360cf0185a2dac74d7e5e();
		for (int j = 0; j < kitRender.c0ea5dc09f2bcde02ec9c097cf6e3a2b4(); j++)
		{
			kitRender.c73b3e333e93633e0d4e21fb2e41d7d14(j, c3003c6194f9f06563fb78310318e3417);
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
			yield return StartCoroutine(c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad618dcc0547ebee513a30332046d81f(kitRender.c0c98f9aa4067deab3caf8159826ae606()));
			GameObject myWeapon = kitRender.c3309affdc4b59cba5f457bbaec5f0762();
			Rigidbody body = myWeapon.GetComponent<Rigidbody>();
			if (body != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				Object.Destroy(body);
			}
			Collider coll = GetComponent<Collider>();
			if (coll != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				coll.enabled = false;
			}
			Transform weaponNode = ce1fb4d774e60a964105c162513d97b38.c7088de59e49f7108f520cf7e0bae167e;
			Transform[] allBones = cfe0a1153f61dcdf419049830449301da.gameObject.transform.GetComponentsInChildren<Transform>();
			int i = 0;
			while (true)
			{
				if (i < allBones.Length)
				{
					if (c0a0a3811fe6f217cafe0a87c418d3fd6(allBones[i].gameObject.name.ToLower(), c8845f28fdcd69fafc8894476a17e43db.m_type, c5a707433b54dfe00cc1ecec199a753a6))
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
						weaponNode = allBones[i];
						break;
					}
					i++;
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
			if (weaponNode != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						myWeapon.transform.parent = weaponNode;
						myWeapon.transform.localPosition = Vector3.zero;
						myWeapon.transform.localRotation = Quaternion.identity;
						myWeapon.transform.localScale = Vector3.one;
						myWeapon.transform.Rotate(new Vector3(90f, 0f, 0f));
						yield break;
					}
				}
			}
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Framework, "Weapon Node Not Find!");
			yield break;
		}
	}

	private bool c0a0a3811fe6f217cafe0a87c418d3fd6(string cf6815e425026ca075e85851e7fd4a872, WeaponType c4f09c39924e70788c7b055c1d1490578, bool c8c4be06a0abac08f705808c69d97633d)
	{
		string text = string.Empty;
		switch (c4f09c39924e70788c7b055c1d1490578)
		{
		case WeaponType.SMG:
			text = "smg";
			break;
		case WeaponType.SniperRifle:
			text = "sniper";
			if (!c8c4be06a0abac08f705808c69d97633d)
			{
				break;
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			text += "_ui";
			break;
		case WeaponType.ShotGun:
			text = "shotgun";
			break;
		case WeaponType.RepeaterPistol:
			text = "rep";
			break;
		case WeaponType.CombatRifle:
			text = "rifle";
			break;
		}
		if (!(cf6815e425026ca075e85851e7fd4a872 == "bip01 r hand_" + text))
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
			if (!(cf6815e425026ca075e85851e7fd4a872 == "export_ r_hand_" + text))
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
				if (!(cf6815e425026ca075e85851e7fd4a872 == "export_r_hand_" + text))
				{
					return false;
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
		}
		return true;
	}
}
