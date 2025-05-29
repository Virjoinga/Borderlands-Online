using System;
using UnityEngine;
using XsdSettings;

public class WeaponElementalManager : MonoBehaviour
{
	[Serializable]
	public class ElementalConfig
	{
		public WeaponType weapontype;

		public AttackInfo.ElementalType elementaltype;

		public string muzzleRescource;

		public string lightRescource;
	}

	public ElementalConfig[] elementalConfigs = new ElementalConfig[25];

	private void Start()
	{
	}

	private void Update()
	{
	}
}
