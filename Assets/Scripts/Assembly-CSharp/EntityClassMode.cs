using A;
using UnityEngine;
using XsdSettings;

public class EntityClassMode : EntityObject
{
	public ClassModeDNA m_dna;

	public ClassModeAttribute m_attribute { get; private set; }

	protected override void Awake()
	{
		base.Awake();
	}

	public override void Start()
	{
		base.Start();
		if (m_dna != null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			ItemDNA itemDNA = c9fc033d895059e2080450369e258d5f0()[0] as ItemDNA;
			if (itemDNA == null)
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
				m_dna = itemDNA.c253c28f3a59bc5e5a528dfbb463a8a45();
				m_attribute = m_dna.m_attribute;
				SkinnedMeshRenderer componentInChildren = base.gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
				if (m_dna.m_material < 0)
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
					if (!(componentInChildren != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
						if (m_dna.m_material >= componentInChildren.materials.Length)
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
							componentInChildren.material = componentInChildren.materials[m_dna.m_material];
							return;
						}
					}
				}
			}
		}
	}

	public void c68cd0a841e044876d964965d7ec944bd(ClassModeDNA caedbc1db6c28d44eab6021e7d674eab3)
	{
		m_dna = caedbc1db6c28d44eab6021e7d674eab3;
		m_attribute = m_dna.m_attribute;
	}

	public ClassModeDNA c729ce3b5f48e0eac3a7ead97b1d02f8d()
	{
		return m_dna;
	}

	public override void c1c5a947f5f8c009fe6fac45c9e29ad1d(Entity c706ea4155b03100282fe553e4d0be557)
	{
		c71e2faacad39f5de99408bee4edd5367(c706ea4155b03100282fe553e4d0be557);
	}

	public float c4e0f63f4b4d409c5e3992c71520e30a0(EffectType c2b4f43f34e21572af6ab4414f04cee36, AffectType c7d663c1e25c9ad53f0f4a926e3924759)
	{
		return m_attribute.c4e0f63f4b4d409c5e3992c71520e30a0(c2b4f43f34e21572af6ab4414f04cee36, c7d663c1e25c9ad53f0f4a926e3924759);
	}

	public void c959567c3d0deab4dacbe2081900e09fd(Entity c5d3fadbfa255cf4cd6eca73b917e9751)
	{
		if (c5d3fadbfa255cf4cd6eca73b917e9751 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (7)
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
		Skeleton skeleton = c5d3fadbfa255cf4cd6eca73b917e9751.ccd8e6ea278245d0f158036267242e60f();
		if (skeleton == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		if (m_dna == null)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		Transform transform = skeleton.c99ffe9fbf560125954f0bf35b449d5c8(m_dna.m_cmType);
		if (transform == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		base.transform.parent = transform;
		base.transform.localPosition = Vector3.zero;
		base.transform.localRotation = Quaternion.identity;
		Collider component = GetComponent<Collider>();
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
			component.enabled = false;
		}
		Rigidbody component2 = GetComponent<Rigidbody>();
		if (component2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			Object.Destroy(component2);
		}
		base.gameObject.SetActive(true);
		c648824e172f398cca38d5ea4468fbaaa();
	}
}
