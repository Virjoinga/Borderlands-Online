using System;
using System.Collections.Generic;
using A;
using UnityEngine;
using XsdSettings;

public class SupplyStation : MonoBehaviour
{
	public enum ESupplyType
	{
		Ammo = 0,
		Health = 1,
		AmmoHealth = 2
	}

	public class SupplyData
	{
		public Transform m_icon;

		public Update_Regen m_update_function;
	}

	[Serializable]
	public class AmmoRegenData
	{
		public AmmoType m_type;

		public int m_increace;
	}

	public delegate void Update_Regen();

	[SerializeField]
	private ESupplyType m_type;

	[SerializeField]
	private Transform m_ammo_icon;

	[SerializeField]
	private Transform m_health_icon;

	[SerializeField]
	private Transform m_ammoHealth_icon;

	[SerializeField]
	private Transform m_vfx_supplying_light;

	[SerializeField]
	private float m_HealthRegenPerSecond = 0.1f;

	[SerializeField]
	private float m_interval_ammoRegen = 1f;

	private List<EntityPlayer> m_playerInZoneList = new List<EntityPlayer>();

	private SupplyData m_data;

	private Dictionary<EntityPlayer, Utils.Timer> m_timer_ammoRegen_Dict = new Dictionary<EntityPlayer, Utils.Timer>();

	[SerializeField]
	private AmmoRegenData[] m_ammoRegenDataList;

	private void c894e588df4ea2bf05d56218b272a9ea4()
	{
	}

	private void c11e4ac5871c29026d919df2cbc1c8659()
	{
	}

	private void cc57e30ceb8de59f892134405dd66257a()
	{
	}

	private void OnPlayerEnter(EntityPlayer _player)
	{
		if (!m_playerInZoneList.Contains(_player))
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
			PlayerThirdPersonAnimationManagerFSM component = _player.GetComponent<PlayerThirdPersonAnimationManagerFSM>();
			if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (component.m_AudioCtl != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					component.m_AudioCtl.TriggerEventByName("Itm_Pickup_Ammo");
				}
			}
		}
		if (m_playerInZoneList.Count == 0)
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
			m_vfx_supplying_light.gameObject.SetActive(true);
		}
		m_playerInZoneList.Add(_player);
	}

	private void OnPlayerExit(EntityPlayer _player)
	{
		m_playerInZoneList.Remove(_player);
		if (m_playerInZoneList.Count != 0)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_vfx_supplying_light.gameObject.SetActive(false);
			return;
		}
	}

	private void ccc9d3a38966dc10fedb531ea17d24611()
	{
		m_playerInZoneList.Clear();
		Dictionary<ESupplyType, SupplyData> dictionary = new Dictionary<ESupplyType, SupplyData>();
		dictionary.Add(ESupplyType.Ammo, new SupplyData
		{
			m_icon = m_ammo_icon,
			m_update_function = c894e588df4ea2bf05d56218b272a9ea4
		});
		dictionary.Add(ESupplyType.Health, new SupplyData
		{
			m_icon = m_health_icon,
			m_update_function = c11e4ac5871c29026d919df2cbc1c8659
		});
		dictionary.Add(ESupplyType.AmmoHealth, new SupplyData
		{
			m_icon = m_ammoHealth_icon,
			m_update_function = cc57e30ceb8de59f892134405dd66257a
		});
		Dictionary<ESupplyType, SupplyData> dictionary2 = dictionary;
		m_data = dictionary2[m_type];
		m_data.m_icon.gameObject.SetActive(true);
	}

	private void cb5d8f38efa288c7cb54ac22a9486f5e2(EntityPlayer c41edc6c4614cf807cf2505a9be83affe)
	{
		if (m_timer_ammoRegen_Dict.ContainsKey(c41edc6c4614cf807cf2505a9be83affe))
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
			m_timer_ammoRegen_Dict.Add(c41edc6c4614cf807cf2505a9be83affe, new Utils.Timer());
			return;
		}
	}

	private void c1733beb9190021b0f68dfda6d60848f6(EntityPlayer c41edc6c4614cf807cf2505a9be83affe)
	{
		if (!m_timer_ammoRegen_Dict.ContainsKey(c41edc6c4614cf807cf2505a9be83affe))
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
			m_timer_ammoRegen_Dict.Remove(c41edc6c4614cf807cf2505a9be83affe);
			return;
		}
	}

	private void c509893ebd52811edc5a33cbe58d3e7fd()
	{
		if (m_vfx_supplying_light == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (m_interval_ammoRegen == 0f)
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
				if (m_HealthRegenPerSecond == 0f)
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
					if (m_ammoRegenDataList != null)
					{
						return;
					}
					while (true)
					{
						switch (2)
						{
						case 0:
							break;
						default:
							return;
						}
					}
				}
			}
		}
	}

	private void Start()
	{
		ccc9d3a38966dc10fedb531ea17d24611();
	}

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		EntityPlayer component = other.GetComponent<EntityPlayer>();
		if (!(component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			OnPlayerEnter(component);
			return;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		EntityPlayer component = other.GetComponent<EntityPlayer>();
		if (!(component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			OnPlayerExit(component);
			return;
		}
	}
}
