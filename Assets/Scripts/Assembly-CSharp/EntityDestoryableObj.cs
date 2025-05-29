using System.Collections.Generic;
using A;
using BHV;
using UnityEngine;

public class EntityDestoryableObj : EntityObject
{
	private DestoryableObjSetting m_destorySetting;

	private string m_uiName;

	private bool m_bPlayDestroyEffect;

	public bool m_bHideUI;

	public override void ce7325a1f0410a6d170ae58fce0f0ae7f(Dictionary<BHVTaskType, BHVTask> c3521c9096ab7c30ece57e61bdb8622f2)
	{
		if (c3521c9096ab7c30ece57e61bdb8622f2 == null)
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
					return;
				}
			}
		}
		c3521c9096ab7c30ece57e61bdb8622f2.Add(BHVTaskType.Default, new BHVTaskDefault());
	}

	public override void Start()
	{
		base.Start();
		m_destorySetting = GetComponentInChildren<DestoryableObjSetting>();
		m_collisionManager = GetComponentInChildren<CollisionManager>();
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_collisionManager.cd93285db16841148ed53a5bbeb35cf20(false);
		}
		if (!(m_destorySetting != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			m_uiName = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(m_destorySetting.m_name));
			return;
		}
	}

	public override string ca6bcee369aa6d4cdf126ebaeef6f6c73()
	{
		return m_uiName;
	}

	public override void Update()
	{
		if (m_collisionManager == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_collisionManager = GetComponentInChildren<CollisionManager>();
			if (m_collisionManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				m_collisionManager.cd93285db16841148ed53a5bbeb35cf20(false);
			}
		}
		if (m_destorySetting == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_destorySetting = GetComponentInChildren<DestoryableObjSetting>();
			if (m_destorySetting != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				m_uiName = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(m_destorySetting.m_name));
			}
		}
		base.Update();
		int num = ca2ff7a501878363cb1d5f0472e306620();
		if (num > 0)
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
			if (m_bPlayDestroyEffect)
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
				Renderer[] componentsInChildren = base.gameObject.GetComponentsInChildren<Renderer>();
				Renderer[] array = componentsInChildren;
				foreach (Renderer renderer in array)
				{
					renderer.enabled = false;
				}
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					Collider[] componentsInChildren2 = base.gameObject.GetComponentsInChildren<Collider>();
					Collider[] array2 = componentsInChildren2;
					foreach (Collider collider in array2)
					{
						collider.enabled = false;
					}
					while (true)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						VFXManager componentInChildren = GetComponentInChildren<VFXManager>();
						if (!(componentInChildren != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
							if (componentInChildren.m_particleList.Length <= 0)
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
								if (componentInChildren.m_particleList[0] == null)
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
									componentInChildren.c930218e437c0501ced1553e08dab14d9(componentInChildren.m_particleList[0].m_type, c4cf00ced2bc60ae908904eb73692869f());
									m_bPlayDestroyEffect = true;
									return;
								}
							}
						}
					}
				}
			}
		}
	}
}
