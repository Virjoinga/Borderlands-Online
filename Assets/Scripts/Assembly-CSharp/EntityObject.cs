using System;
using A;
using UnityEngine;

public class EntityObject : Entity
{
	public enum EntitySubType
	{
		None = 0,
		Weapon = 1,
		AmmoPack = 2,
		HealthPack = 3,
		MoneyPack = 4,
		Grenade = 5,
		Shield = 6,
		ExposiveDestructible_Barrel = 7,
		NPC_Grenade = 8,
		NPC_Armor = 9,
		Material = 10,
		DestoryableObj = 11,
		ClassMode = 12
	}

	public EntitySubType m_subType;

	protected Rigidbody m_rigidBody;

	protected CollisionManager m_collisionManager;

	protected EquipmentInventoryEntity m_equipment;

	public Entity m_owner { get; private set; }

	public Pickable m_pickable { get; private set; }

	public override void Start()
	{
		base.Start();
		m_pickable = GetComponent<Pickable>();
		m_rigidBody = GetComponent<Rigidbody>();
		m_equipment = GetComponent<EquipmentInventoryEntity>();
		m_collisionManager = GetComponent<CollisionManager>();
		if (!(m_collisionManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			m_collisionManager.cd93285db16841148ed53a5bbeb35cf20(false);
			return;
		}
	}

	public Rigidbody c379ca47225b608936782d004e6e6fff3()
	{
		if (c5eaa1d6ded3939c278019b4ed3305826())
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			c7625f669cf7d310f5ae9a4aa2646e757(true);
			if (m_rigidBody == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				m_rigidBody = base.gameObject.AddComponent<Rigidbody>();
			}
			if ((bool)m_rigidBody)
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
				m_rigidBody.useGravity = true;
				m_rigidBody.drag = 1f;
				m_rigidBody.mass = 1f;
				m_rigidBody.sleepVelocity = 10f;
				m_rigidBody.sleepAngularVelocity = 10f;
				if (m_subType != EntitySubType.HealthPack)
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
					if (m_subType != EntitySubType.MoneyPack)
					{
						goto IL_0100;
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
				m_rigidBody.interpolation = RigidbodyInterpolation.Interpolate;
				m_rigidBody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
			}
		}
		goto IL_0100;
		IL_0100:
		return m_rigidBody;
	}

	public override CollisionManager c63f8f07320313ddc4213cb59ee025962()
	{
		return m_collisionManager;
	}

	public bool c5eaa1d6ded3939c278019b4ed3305826()
	{
		int result;
		if (!(base.collider != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (m_collisionManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				result = (m_collisionManager.c5eaa1d6ded3939c278019b4ed3305826() ? 1 : 0);
			}
			else
			{
				result = 0;
			}
		}
		else
		{
			result = 1;
		}
		return (byte)result != 0;
	}

	public void c7625f669cf7d310f5ae9a4aa2646e757(bool cbf402c82d0fffee7c8f37c98e456b8f8)
	{
		if (base.collider != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					base.collider.enabled = cbf402c82d0fffee7c8f37c98e456b8f8;
					return;
				}
			}
		}
		if (!(m_collisionManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (!m_collisionManager.c5eaa1d6ded3939c278019b4ed3305826())
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
				m_collisionManager.c7625f669cf7d310f5ae9a4aa2646e757(cbf402c82d0fffee7c8f37c98e456b8f8);
				return;
			}
		}
	}

	public override EquipmentInventoryEntity c5ca38fad98337fc5c7255384b2cd1a86()
	{
		return m_equipment;
	}

	public override EntityType c6420f67f9249b1d533531d9f351a36e0()
	{
		return EntityType.Object;
	}

	public virtual bool c39df47367fa21412aabfef05d9972f8c()
	{
		return true;
	}

	public virtual void c1c5a947f5f8c009fe6fac45c9e29ad1d(Entity c706ea4155b03100282fe553e4d0be557)
	{
	}

	public virtual void c67c35955d666a0c6fe54cd6e348b1675()
	{
	}

	public ItemDNA c4622c7a1660020e5029da03e27491b37()
	{
		if ((bool)m_pickable)
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
					return m_pickable.c286cbdde6d61958bfcaff0cd6a8b2963();
				}
			}
		}
		return null;
	}

	public virtual void c648824e172f398cca38d5ea4468fbaaa()
	{
		if (!m_pickable)
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
			m_pickable.OnPick();
			return;
		}
	}

	public virtual void cd9058248734c831f0b6bdfd9e340e588(Vector3 cef9712200bbe2c3873eec3ca2e18a595, Quaternion c4ea6de03c1203f2470a6677821ad93f0, Vector3 ccb960b1045f89ea696f13319e5d8d099)
	{
		Rigidbody rigidbody = c379ca47225b608936782d004e6e6fff3();
		base.transform.position = cef9712200bbe2c3873eec3ca2e18a595;
		base.transform.rotation = c4ea6de03c1203f2470a6677821ad93f0;
		if (rigidbody != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			rigidbody.AddForce(ccb960b1045f89ea696f13319e5d8d099, ForceMode.VelocityChange);
			rigidbody.AddTorque(UnityEngine.Random.insideUnitSphere, ForceMode.Impulse);
		}
		if (!m_pickable)
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
			m_pickable.OnDrop();
			return;
		}
	}

	public virtual bool c3fa5657ea791d3c8779428f0361d91e3()
	{
		int result;
		if (m_pickable != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			result = (m_pickable.c3fa5657ea791d3c8779428f0361d91e3() ? 1 : 0);
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public bool c6d73cdad66ee997135db55333d3e5062()
	{
		int result;
		if (c3fa5657ea791d3c8779428f0361d91e3())
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
			result = (m_pickable.m_autoPickup ? 1 : 0);
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public void c71e2faacad39f5de99408bee4edd5367(Entity c201251370bf8deb7ba71da4ae484a494)
	{
		m_owner = c201251370bf8deb7ba71da4ae484a494;
		if (!(m_pickable != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			m_pickable.OnOwnerChanged();
			return;
		}
	}

	public static string[] c95e69186ffac00a7b6e6ea9e892c59b7()
	{
		return Enum.GetNames(typeof(EntitySubType));
	}

	public override int ceb10167333758220ffb9bc66317ad763()
	{
		return 254;
	}
}
