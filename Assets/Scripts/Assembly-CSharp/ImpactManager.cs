using System;
using System.Collections.Generic;
using A;
using Core;
using UnityEngine;
using XsdSettings;

public class ImpactManager : c06ca0e618478c23eba3419653a19760f<ImpactManager>
{
	public int m_poolSize = 150;

	public float m_maxImpactDistance = 200f;

	public float m_defaultImpactDelay = 0.025f;

	public float m_bulletSpeed = 500f;

	public float m_tolerantDistance = 0.05f;

	public ParticleSystem m_elementalFire;

	public ParticleSystem m_elementalShock;

	public ParticleSystem m_elementalCorrosive;

	public ParticleSystem m_elementalExplosive;

	public ImpactSetup[] m_impacts = c49917f8525c2b1884254edcbb3429182.c0a0cdf4a196914163f7334d9b0781a04(0);

	private EffectPool m_pool;

	private RingBuffer m_decals;

	private List<ImpactContext> m_impactBuffer = new List<ImpactContext>();

	protected override void Awake()
	{
		base.Awake();
		m_pool = new EffectPool(m_poolSize);
		m_decals = new RingBuffer(m_poolSize, false);
	}

	public void c189918e11f8f4ad15b18a905c9adc502(Vector3 c6fbf9bf303de8f447f09fde3a44278f2, Vector3 c9a096c7639549cf7066d5ed203ecbab1, AttackInfo.ElementalType c01adf83bf2e5024ab7c2cf2d958cfdd6)
	{
		RaycastHit hitInfo;
		if (!Physics.Raycast(c6fbf9bf303de8f447f09fde3a44278f2, c9a096c7639549cf7066d5ed203ecbab1, out hitInfo, m_maxImpactDistance, TargetingService.c766b2ad3bfeb136864b1696e7dda3d4c))
		{
			return;
		}
		ImpactContext c36964cf41281414170f34ee68bef6c = default(ImpactContext);
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
			if (!(hitInfo.collider != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				c56d2e8e1f765950dcfb43f1abcb0daff.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
				c36964cf41281414170f34ee68bef6c.m_impactType = ImpactContext.ImpactType.Terrain;
				c36964cf41281414170f34ee68bef6c.m_resolutionTime = Time.time + c3ebd305d7ae6450840c8161586ceaeab(hitInfo.distance);
				c36964cf41281414170f34ee68bef6c.m_affectedObject = hitInfo.collider.gameObject;
				c36964cf41281414170f34ee68bef6c.m_elementalType = c01adf83bf2e5024ab7c2cf2d958cfdd6;
				c36964cf41281414170f34ee68bef6c.m_position = hitInfo.point;
				c36964cf41281414170f34ee68bef6c.m_normal = hitInfo.normal;
				c36964cf41281414170f34ee68bef6c.m_forward = c9a096c7639549cf7066d5ed203ecbab1;
				m_impactBuffer.Add(c36964cf41281414170f34ee68bef6c);
				return;
			}
		}
	}

	public ImpactSetup ce6742c66aa7d7ff584dc42eb090262dd(string cdc6c1b5d576b10e3dddc8d9f2d8974dc)
	{
		for (int i = 0; i < m_impacts.Length; i++)
		{
			if (!(cdc6c1b5d576b10e3dddc8d9f2d8974dc == m_impacts[i].m_impactType))
			{
				continue;
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
				return m_impacts[i];
			}
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			return null;
		}
	}

	private ParticleSystem cef41ae2b7d234672080181e62300af87(AttackInfo.ElementalType c01adf83bf2e5024ab7c2cf2d958cfdd6)
	{
		switch (c01adf83bf2e5024ab7c2cf2d958cfdd6)
		{
		case AttackInfo.ElementalType.Fire:
			return m_elementalFire;
		case AttackInfo.ElementalType.Shock:
			return m_elementalShock;
		case AttackInfo.ElementalType.Corrosive:
			return m_elementalCorrosive;
		case AttackInfo.ElementalType.Explosive:
			return m_elementalExplosive;
		default:
			return null;
		}
	}

	public void ca91a558b2373d4e79863a70a93654218(GameObject ce7df41518c0940974d277780511764ec, AttackInfo.ElementalType cdc6c1b5d576b10e3dddc8d9f2d8974dc, Vector3 cef9712200bbe2c3873eec3ca2e18a595, Vector3 ce0b1068786abedfc61051e3371371ea6, Vector3 cdb904a3027943a47994b1cd1d4f659fc)
	{
		if (ce7df41518c0940974d277780511764ec == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return;
				}
			}
		}
		ImpactSetup impactSetup = ce6742c66aa7d7ff584dc42eb090262dd(ce7df41518c0940974d277780511764ec.tag);
		if (impactSetup == null)
		{
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
		ParticleSystem particleSystem = UnityEngine.Object.Instantiate(impactSetup.m_particuleSystem, cef9712200bbe2c3873eec3ca2e18a595, Quaternion.FromToRotation(Vector3.forward, -ce0b1068786abedfc61051e3371371ea6)) as ParticleSystem;
		particleSystem.Play();
		UnityEngine.Object.Destroy(particleSystem.gameObject, particleSystem.startLifetime + particleSystem.duration);
		ParticleSystem particleSystem2 = cef41ae2b7d234672080181e62300af87(cdc6c1b5d576b10e3dddc8d9f2d8974dc);
		if (particleSystem2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			ParticleSystem particleSystem3 = UnityEngine.Object.Instantiate(particleSystem2, cef9712200bbe2c3873eec3ca2e18a595, Quaternion.FromToRotation(Vector3.forward, -ce0b1068786abedfc61051e3371371ea6)) as ParticleSystem;
			particleSystem3.Play();
			UnityEngine.Object.Destroy(particleSystem3.gameObject, particleSystem3.startLifetime + particleSystem3.duration);
		}
		GameObject gameObject = new GameObject("Decal_" + impactSetup.m_impactType);
		if (m_decals.ca0dc0c335bcd7a0d16510da3a64d1c4f() >= m_poolSize)
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
			GameObject obj = m_decals.c7605b6a8df360621e4eb06fe0b47814b() as GameObject;
			UnityEngine.Object.Destroy(obj);
		}
		m_decals.cd6aca5b3793f791cfc489609e675c90b(gameObject);
		gameObject.transform.position = cef9712200bbe2c3873eec3ca2e18a595;
		gameObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, cdb904a3027943a47994b1cd1d4f659fc);
		gameObject.transform.localScale = impactSetup.m_decalSize;
		cc49e644e4794a97f26962520c4027935(impactSetup, gameObject, ce7df41518c0940974d277780511764ec);
	}

	public void cc49e644e4794a97f26962520c4027935(ImpactSetup cb723be2e992e7f7198bc3e66304005a7, GameObject c408cdede67f4d498c4c3508017efbbc1, GameObject ce7df41518c0940974d277780511764ec)
	{
		EffectPoolController effectPoolController = c408cdede67f4d498c4c3508017efbbc1.AddComponent<EffectPoolController>();
		effectPoolController.c57e4d4cd41f3be21d7e24a71aa08c6ba(m_pool);
		Decal.dCount++;
		Decal decal = c408cdede67f4d498c4c3508017efbbc1.AddComponent<Decal>();
		decal.affectedObject = ce7df41518c0940974d277780511764ec;
		decal.decalMode = DecalMode.MESH_FILTER;
		decal.pushDistance = m_tolerantDistance;
		Material material = cb723be2e992e7f7198bc3e66304005a7.m_material;
		if (cb723be2e992e7f7198bc3e66304005a7.m_texture != null)
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
			if (cb723be2e992e7f7198bc3e66304005a7.m_texture.Length > 0)
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
				int num = UnityEngine.Random.Range(0, cb723be2e992e7f7198bc3e66304005a7.m_texture.Length);
				material.mainTexture = cb723be2e992e7f7198bc3e66304005a7.m_texture[num];
			}
		}
		decal.decalMaterial = material;
		decal.ce281869c43f18fb7a3f5381b24b58075();
		decal.transform.parent = ce7df41518c0940974d277780511764ec.transform;
	}

	private void Update()
	{
		float time = Time.time;
		for (int num = m_impactBuffer.Count - 1; num >= 0; num--)
		{
			if (m_impactBuffer[num].m_resolutionTime < time)
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
				ImpactContext.ImpactType impactType = m_impactBuffer[num].m_impactType;
				if (impactType != 0)
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
					if (impactType != ImpactContext.ImpactType.Entity)
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
					}
					else
					{
						cf0f8f703fc0b77b2b69b5e469163a6ee(m_impactBuffer[num].m_victim, m_impactBuffer[num].m_damageInfo, false);
					}
				}
				else
				{
					ca91a558b2373d4e79863a70a93654218(m_impactBuffer[num].m_affectedObject, m_impactBuffer[num].m_elementalType, m_impactBuffer[num].m_position, m_impactBuffer[num].m_forward, m_impactBuffer[num].m_normal);
				}
				m_impactBuffer.RemoveAt(num);
			}
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	public void c272f383f145ac48ad098896e52a6d331(bool cda06e7be7f2d67ea759e0c02c7f27d60, Entity cf7ee7f254a35f9c53a393957e2758a0a, DamageInfo cd267a5dc6434bf247c67a6b37ed70c84)
	{
		if (cda06e7be7f2d67ea759e0c02c7f27d60)
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
					cf0f8f703fc0b77b2b69b5e469163a6ee(cf7ee7f254a35f9c53a393957e2758a0a, cd267a5dc6434bf247c67a6b37ed70c84, cda06e7be7f2d67ea759e0c02c7f27d60);
					return;
				}
			}
		}
		Entity entity = BadAssNetworkView.cd45cbc6284a89fa5c2b29c7ad9718528(cd267a5dc6434bf247c67a6b37ed70c84.m_from);
		if (!(entity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
		{
			return;
		}
		ImpactContext c36964cf41281414170f34ee68bef6c = default(ImpactContext);
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			float ca3d88a80f99d24e2b577c8a389135fb = Vector3.Distance(cf7ee7f254a35f9c53a393957e2758a0a.c4cf00ced2bc60ae908904eb73692869f(), entity.c4cf00ced2bc60ae908904eb73692869f());
			c56d2e8e1f765950dcfb43f1abcb0daff.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
			c36964cf41281414170f34ee68bef6c.m_impactType = ImpactContext.ImpactType.Entity;
			c36964cf41281414170f34ee68bef6c.m_resolutionTime = Time.time + c3ebd305d7ae6450840c8161586ceaeab(ca3d88a80f99d24e2b577c8a389135fb);
			c36964cf41281414170f34ee68bef6c.m_victim = cf7ee7f254a35f9c53a393957e2758a0a;
			c36964cf41281414170f34ee68bef6c.m_damageInfo = cd267a5dc6434bf247c67a6b37ed70c84;
			m_impactBuffer.Add(c36964cf41281414170f34ee68bef6c);
			return;
		}
	}

	private float c3ebd305d7ae6450840c8161586ceaeab(float ca3d88a80f99d24e2b577c8a389135fb8)
	{
		return m_defaultImpactDelay + 1f / (m_bulletSpeed / ca3d88a80f99d24e2b577c8a389135fb8);
	}

	public void cf0f8f703fc0b77b2b69b5e469163a6ee(Entity cf7ee7f254a35f9c53a393957e2758a0a, DamageInfo cd267a5dc6434bf247c67a6b37ed70c84, bool cdf5a8d522cf4c4b331f6a380cecd2451 = true)
	{
		if (cf7ee7f254a35f9c53a393957e2758a0a == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		int num = cd267a5dc6434bf247c67a6b37ed70c84.m_shieldDamagePoints + cd267a5dc6434bf247c67a6b37ed70c84.m_healthDamagePoints;
		Vector3 c1662deabeaea10c800de78a048b2d = cf7ee7f254a35f9c53a393957e2758a0a.c4cf00ced2bc60ae908904eb73692869f() + Vector3.up * cf7ee7f254a35f9c53a393957e2758a0a.m_entityHeight * 0.6f;
		WeakPoint weakPoint = cf7ee7f254a35f9c53a393957e2758a0a.c63f8f07320313ddc4213cb59ee025962().c92b2d96b80fc4e8dc19a3368e56dbacb(cd267a5dc6434bf247c67a6b37ed70c84.m_weakPointIndex);
		VFXManager c45374b5c8fce1bef9b5da65184df0d6e = cf7ee7f254a35f9c53a393957e2758a0a.ccdbbc6879c7efc53e81b9c2fbaceead9();
		Entity entity = BadAssNetworkView.cd45cbc6284a89fa5c2b29c7ad9718528(cd267a5dc6434bf247c67a6b37ed70c84.m_from);
		if (entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (!(entity != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			PlayerInfoSync playerInfoSync = entity.cd95354b53e674ec7dc9594e66e4d316f();
			if (cdf5a8d522cf4c4b331f6a380cecd2451)
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
				if (playerInfoSync != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					if (playerInfoSync.c16d1154aec91a0f8f4a52d77fc081194())
					{
						goto IL_011f;
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
			}
			if (!cdf5a8d522cf4c4b331f6a380cecd2451)
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
				goto IL_011f;
			}
			goto IL_0171;
			IL_0171:
			if (num <= 0)
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
				bool flag = cd267a5dc6434bf247c67a6b37ed70c84.m_attackSubType == AttackSubType.SkillTurretProjectile;
				if (playerInfoSync != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					if (playerInfoSync.c16d1154aec91a0f8f4a52d77fc081194())
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
						if (cdf5a8d522cf4c4b331f6a380cecd2451)
						{
							goto IL_01ea;
						}
					}
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
				if (!flag)
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
					break;
				}
				goto IL_01ea;
				IL_01ea:
				if (AttackInfo.cb40d9d92cf67eb5b4aecc077640e0f4e(cd267a5dc6434bf247c67a6b37ed70c84.m_attackSubType) == AttackInfo.AttackType.DamageOverTime)
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDWorldTipsView>().c84366760d1fa67e4323e190564d3e406(num, weakPoint.cf7d609e6e0384b70ae8d814e5f8712be(), c1662deabeaea10c800de78a048b2d, cd267a5dc6434bf247c67a6b37ed70c84.m_elementalType, false);
							return;
						}
					}
				}
				c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDWorldTipsView>().c84366760d1fa67e4323e190564d3e406(num, weakPoint.cf7d609e6e0384b70ae8d814e5f8712be(), c1662deabeaea10c800de78a048b2d, cd267a5dc6434bf247c67a6b37ed70c84.m_elementalType);
				return;
			}
			IL_011f:
			if (AttackInfo.cb40d9d92cf67eb5b4aecc077640e0f4e(cd267a5dc6434bf247c67a6b37ed70c84.m_attackSubType) == AttackInfo.AttackType.Projectile)
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
				ca6bd5fd4f2a938c5384d5af2508144d4(cf7ee7f254a35f9c53a393957e2758a0a, c45374b5c8fce1bef9b5da65184df0d6e, cd267a5dc6434bf247c67a6b37ed70c84, weakPoint, ref c1662deabeaea10c800de78a048b2d);
			}
			else if (AttackInfo.cb40d9d92cf67eb5b4aecc077640e0f4e(cd267a5dc6434bf247c67a6b37ed70c84.m_attackSubType) == AttackInfo.AttackType.DamageOverTime)
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
				c7f972b6da5995cecae8b0436e99fc254(cf7ee7f254a35f9c53a393957e2758a0a, c45374b5c8fce1bef9b5da65184df0d6e, cd267a5dc6434bf247c67a6b37ed70c84);
			}
			goto IL_0171;
		}
	}

	private bool ca6bd5fd4f2a938c5384d5af2508144d4(Entity cf7ee7f254a35f9c53a393957e2758a0a, VFXManager c45374b5c8fce1bef9b5da65184df0d6e, DamageInfo cd267a5dc6434bf247c67a6b37ed70c84, WeakPoint c21dfbdbfc865e775d0fd21534f7fb298, ref Vector3 c1662deabeaea10c800de78a048b2d062)
	{
		if (!(cf7ee7f254a35f9c53a393957e2758a0a == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (!(c45374b5c8fce1bef9b5da65184df0d6e == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				if (!(c21dfbdbfc865e775d0fd21534f7fb298 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
				{
					Quaternion c503ab5ca60e7190c695317675932aef = Quaternion.identity;
					Vector3 vector = (c1662deabeaea10c800de78a048b2d062 = c19c05b99efbde627d44661b5486c1fc8(cf7ee7f254a35f9c53a393957e2758a0a, cd267a5dc6434bf247c67a6b37ed70c84, ref c503ab5ca60e7190c695317675932aef));
					ENPCParticleType eNPCParticleType = ENPCParticleType.E_DamagedBulletNone;
					ENPCParticleType eNPCParticleType2 = eNPCParticleType;
					string value = "E_DamagedBullet" + cd267a5dc6434bf247c67a6b37ed70c84.m_elementalType;
					if (Enum.IsDefined(Type.GetTypeFromHandle(c7c024c895b783b2788de68fa41b4699a.cc1720d05c75832f704b87474932341c3()), value))
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
						eNPCParticleType2 = (ENPCParticleType)(int)Enum.Parse(Type.GetTypeFromHandle(c7c024c895b783b2788de68fa41b4699a.cc1720d05c75832f704b87474932341c3()), value);
					}
					if (c21dfbdbfc865e775d0fd21534f7fb298.m_partInfo == WeakPoint.PartInfo.Head)
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
						eNPCParticleType = ENPCParticleType.E_DamageHeadShot;
					}
					eNPCParticleType = cf7ee7f254a35f9c53a393957e2758a0a.cfa1f39f0f16c281e2062553416590dbb(eNPCParticleType, c21dfbdbfc865e775d0fd21534f7fb298);
					if (eNPCParticleType == ENPCParticleType.E_DamageShieldHit)
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
						EntityNpc entityNpc = cf7ee7f254a35f9c53a393957e2758a0a as EntityNpc;
						if (entityNpc != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							if (cd267a5dc6434bf247c67a6b37ed70c84.m_shieldDamagePoints - entityNpc.ce7804365a7377021025c46a16aa79db4() > 0)
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
								eNPCParticleType = ENPCParticleType.E_DamageShieldBroken;
							}
						}
					}
					if (eNPCParticleType == ENPCParticleType.E_DamageShieldBroken)
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
						c45374b5c8fce1bef9b5da65184df0d6e.c930218e437c0501ced1553e08dab14d9(eNPCParticleType, cf7ee7f254a35f9c53a393957e2758a0a.gameObject.transform);
					}
					else if (VFXManager.cc7cfd55d187c16b8a5b776189ba38781(eNPCParticleType))
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
						c45374b5c8fce1bef9b5da65184df0d6e.c0c5ca8f54702477a0524e764704df02c(eNPCParticleType, cf7ee7f254a35f9c53a393957e2758a0a, vector, c503ab5ca60e7190c695317675932aef);
						if (eNPCParticleType2 != eNPCParticleType)
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
							if (!VFXManager.cc7cfd55d187c16b8a5b776189ba38781(eNPCParticleType2))
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
								c45374b5c8fce1bef9b5da65184df0d6e.c930218e437c0501ced1553e08dab14d9(eNPCParticleType2, cf7ee7f254a35f9c53a393957e2758a0a, c21dfbdbfc865e775d0fd21534f7fb298.gameObject.transform, c21dfbdbfc865e775d0fd21534f7fb298.gameObject.transform.InverseTransformPoint(vector), Quaternion.LookRotation(c21dfbdbfc865e775d0fd21534f7fb298.gameObject.transform.InverseTransformDirection(c503ab5ca60e7190c695317675932aef.eulerAngles)));
							}
						}
					}
					else
					{
						c45374b5c8fce1bef9b5da65184df0d6e.c930218e437c0501ced1553e08dab14d9(eNPCParticleType, cf7ee7f254a35f9c53a393957e2758a0a, c21dfbdbfc865e775d0fd21534f7fb298.gameObject.transform, c21dfbdbfc865e775d0fd21534f7fb298.gameObject.transform.InverseTransformPoint(vector), Quaternion.LookRotation(c21dfbdbfc865e775d0fd21534f7fb298.gameObject.transform.InverseTransformDirection(c503ab5ca60e7190c695317675932aef.eulerAngles)));
					}
					if (cd267a5dc6434bf247c67a6b37ed70c84.m_isTriggeringDamageOverTime)
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
						c7f972b6da5995cecae8b0436e99fc254(cf7ee7f254a35f9c53a393957e2758a0a, c45374b5c8fce1bef9b5da65184df0d6e, cd267a5dc6434bf247c67a6b37ed70c84);
					}
					return true;
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
			}
		}
		return false;
	}

	private bool c7f972b6da5995cecae8b0436e99fc254(Entity cf7ee7f254a35f9c53a393957e2758a0a, VFXManager c45374b5c8fce1bef9b5da65184df0d6e, DamageInfo cd267a5dc6434bf247c67a6b37ed70c84)
	{
		if (!(cf7ee7f254a35f9c53a393957e2758a0a == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (!(c45374b5c8fce1bef9b5da65184df0d6e == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
			{
				if (!cd267a5dc6434bf247c67a6b37ed70c84.m_isTriggeringDamageOverTime)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							return false;
						}
					}
				}
				VoiceSystem componentInChildren = cf7ee7f254a35f9c53a393957e2758a0a.GetComponentInChildren<VoiceSystem>();
				ENPCParticleType c6e9c05551eaa310c6fcb665b20682b9c;
				switch (cd267a5dc6434bf247c67a6b37ed70c84.m_elementalType)
				{
				case AttackInfo.ElementalType.Fire:
					if (c45374b5c8fce1bef9b5da65184df0d6e.m_audioCtl != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						c45374b5c8fce1bef9b5da65184df0d6e.m_audioCtl.TriggerEventByName("Wep_Ele_Incendiary_DoT");
					}
					if (componentInChildren != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						VoiceConfig[] voiceConfigs = componentInChildren.m_voiceConfigs;
						int num = 0;
						while (true)
						{
							if (num < voiceConfigs.Length)
							{
								VoiceConfig voiceConfig = voiceConfigs[num];
								if (voiceConfig.m_voice.ToLower().Contains("_fire_dot_"))
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
									componentInChildren.TryToSpeak(voiceConfig.m_voice);
									break;
								}
								num++;
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
					}
					c6e9c05551eaa310c6fcb665b20682b9c = ENPCParticleType.E_DamageOverTimeFire;
					break;
				case AttackInfo.ElementalType.Shock:
					if (c45374b5c8fce1bef9b5da65184df0d6e.m_audioCtl != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						c45374b5c8fce1bef9b5da65184df0d6e.m_audioCtl.TriggerEventByName("Wep_Ele_Shock_DoT");
					}
					c6e9c05551eaa310c6fcb665b20682b9c = ENPCParticleType.E_DamageOverTimeShock;
					break;
				case AttackInfo.ElementalType.Corrosive:
					if (c45374b5c8fce1bef9b5da65184df0d6e.m_audioCtl != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						c45374b5c8fce1bef9b5da65184df0d6e.m_audioCtl.TriggerEventByName("Wep_Ele_Shock_DoT");
					}
					c6e9c05551eaa310c6fcb665b20682b9c = ENPCParticleType.E_DamageOverTimeCorrosive;
					break;
				default:
					c6e9c05551eaa310c6fcb665b20682b9c = ENPCParticleType.E_DamageOverTimeShock;
					break;
				}
				string value = "E_DamageOverTime" + cd267a5dc6434bf247c67a6b37ed70c84.m_elementalType;
				if (Enum.IsDefined(Type.GetTypeFromHandle(c7c024c895b783b2788de68fa41b4699a.cc1720d05c75832f704b87474932341c3()), value))
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
					ENPCParticleType eNPCParticleType = (ENPCParticleType)(int)Enum.Parse(Type.GetTypeFromHandle(c7c024c895b783b2788de68fa41b4699a.cc1720d05c75832f704b87474932341c3()), value);
					string text = string.Empty;
					VFXforNPC[] particleList = c45374b5c8fce1bef9b5da65184df0d6e.m_particleList;
					int num2 = 0;
					while (true)
					{
						if (num2 < particleList.Length)
						{
							VFXforNPC vFXforNPC = particleList[num2];
							if (vFXforNPC.m_type == eNPCParticleType)
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
								text = vFXforNPC.m_audioEvent;
								break;
							}
							num2++;
							continue;
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
						break;
					}
					if (text != string.Empty)
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
						if (c45374b5c8fce1bef9b5da65184df0d6e.m_audioCtl != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
							c45374b5c8fce1bef9b5da65184df0d6e.m_audioCtl.TriggerEventByName(text);
						}
					}
				}
				float num3 = DamageManager.c5ee19dc8d4cccf5ae2de225410458b86.c99eed77fc7972e1cedd74ab862117b4e(cd267a5dc6434bf247c67a6b37ed70c84.m_elementalType, cf7ee7f254a35f9c53a393957e2758a0a, BadAssNetworkView.cd45cbc6284a89fa5c2b29c7ad9718528(cd267a5dc6434bf247c67a6b37ed70c84.m_from));
				WeakPoint c38b98045365f4b50a4fbe3f1d89af = c581015e4f6ee9df70e01d3565f2f7aca.c7088de59e49f7108f520cf7e0bae167e;
				cf7ee7f254a35f9c53a393957e2758a0a.c659e11237d268aac8b68c419cf6b053a(out c38b98045365f4b50a4fbe3f1d89af);
				c45374b5c8fce1bef9b5da65184df0d6e.c930218e437c0501ced1553e08dab14d9(c6e9c05551eaa310c6fcb665b20682b9c, cf7ee7f254a35f9c53a393957e2758a0a, c38b98045365f4b50a4fbe3f1d89af.transform, Vector3.zero, Quaternion.identity, num3);
				c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c9e16403ef21c39f75e639d41fc5111b7().ca0b9153d8ee5859976e87c76026dac7d(cf7ee7f254a35f9c53a393957e2758a0a, num3, cd267a5dc6434bf247c67a6b37ed70c84.m_elementalType);
				return true;
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
		return false;
	}

	private Vector3 c19c05b99efbde627d44661b5486c1fc8(Entity cf7ee7f254a35f9c53a393957e2758a0a, DamageInfo cd267a5dc6434bf247c67a6b37ed70c84, ref Quaternion c503ab5ca60e7190c695317675932aef3)
	{
		WeakPoint weakPoint = cf7ee7f254a35f9c53a393957e2758a0a.c63f8f07320313ddc4213cb59ee025962().c92b2d96b80fc4e8dc19a3368e56dbacb(cd267a5dc6434bf247c67a6b37ed70c84.m_weakPointIndex);
		if (AttackInfo.cb40d9d92cf67eb5b4aecc077640e0f4e(cd267a5dc6434bf247c67a6b37ed70c84.m_attackSubType) != 0)
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
					return weakPoint.transform.position;
				}
			}
		}
		Entity entity = BadAssNetworkView.cd45cbc6284a89fa5c2b29c7ad9718528(cd267a5dc6434bf247c67a6b37ed70c84.m_from);
		if (entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					return weakPoint.transform.position;
				}
			}
		}
		Vector3 vector = entity.cad7880776eb7b2ddfb106102d4c51bbf();
		Vector3 direction = entity.c56fad5727ffebf48f3df62074cd1bbe6();
		EntityWeapon entityWeapon = entity.c3941dac8608f650ceb15dc36294a741c();
		if (entityWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			vector = entityWeapon.cad7880776eb7b2ddfb106102d4c51bbf();
			direction = entityWeapon.c56fad5727ffebf48f3df62074cd1bbe6();
		}
		Ray cdb5cb253ef1339831696a37475f7233f = new Ray(vector, direction);
		float c85645ac328a4c6e6c17d3da3be1e11f = float.MaxValue;
		RaycastHit c3ced719b4780c1919017d69e82521ab;
		if (cf7ee7f254a35f9c53a393957e2758a0a.c63f8f07320313ddc4213cb59ee025962().ce3a634dd33744eb63234d14e7a1e099f(cdb5cb253ef1339831696a37475f7233f, out c3ced719b4780c1919017d69e82521ab, ref c85645ac328a4c6e6c17d3da3be1e11f))
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					c503ab5ca60e7190c695317675932aef3 = Quaternion.LookRotation(c3ced719b4780c1919017d69e82521ab.normal);
					return c3ced719b4780c1919017d69e82521ab.point;
				}
			}
		}
		Collider collider = weakPoint.collider;
		float magnitude = (collider.ClosestPointOnBounds(vector) - vector).magnitude;
		Vector3 position = vector + direction.normalized * magnitude * 0.9f;
		Vector3 vector2 = collider.ClosestPointOnBounds(position);
		c503ab5ca60e7190c695317675932aef3 = Quaternion.LookRotation(vector - vector2);
		return vector2;
	}

	private void cc8b2ae9b3200bc97b23ed4cce119aeb9(Entity c5d720f6d007abb0c4a21d6a654e405bb, DamageInfo cd267a5dc6434bf247c67a6b37ed70c84)
	{
		EntityPlayer entityPlayer = c5d720f6d007abb0c4a21d6a654e405bb as EntityPlayer;
		BadAssFPSCamera badAssFPSCamera = entityPlayer.cc6a7269e9ea93e537de47dc752b09a86();
		if (badAssFPSCamera == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		AttackInfo.AttackType attackType = AttackInfo.cb40d9d92cf67eb5b4aecc077640e0f4e(cd267a5dc6434bf247c67a6b37ed70c84.m_attackSubType);
		switch (attackType)
		{
		case AttackInfo.AttackType.Projectile:
			if (cd267a5dc6434bf247c67a6b37ed70c84.m_attackSubType == AttackSubType.ProjectileAxe)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						badAssFPSCamera.c19a5441553998e0c8500003947ff7737(BadAssFPSCamera.ShakeType.medium);
						return;
					}
				}
			}
			badAssFPSCamera.c19a5441553998e0c8500003947ff7737(BadAssFPSCamera.ShakeType.low);
			break;
		case AttackInfo.AttackType.Melee:
		case AttackInfo.AttackType.Charge:
			badAssFPSCamera.c19a5441553998e0c8500003947ff7737(BadAssFPSCamera.ShakeType.medium);
			break;
		case AttackInfo.AttackType.Area:
			badAssFPSCamera.c19a5441553998e0c8500003947ff7737(BadAssFPSCamera.ShakeType.high);
			break;
		case AttackInfo.AttackType.DamageOverTime:
			break;
		default:
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Gamelogic, string.Concat("No Camera Shake Feedbacks for this Attack Type [", attackType, "]"));
			break;
		}
	}

	public void c32fc71b48a1dfa81f5deb24415522cea(Entity cf7ee7f254a35f9c53a393957e2758a0a, DamageInfo cd267a5dc6434bf247c67a6b37ed70c84, int c94fb97bff20285635980507f7f1a581a, int c01e492fde1ff4a1457e04c75a02245a5, bool cdf5a8d522cf4c4b331f6a380cecd2451)
	{
		PlayerInfoSync playerInfoSync = cf7ee7f254a35f9c53a393957e2758a0a.cd95354b53e674ec7dc9594e66e4d316f();
		if (playerInfoSync != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (playerInfoSync.c16d1154aec91a0f8f4a52d77fc081194())
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						cc8b2ae9b3200bc97b23ed4cce119aeb9(cf7ee7f254a35f9c53a393957e2758a0a, cd267a5dc6434bf247c67a6b37ed70c84);
						c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDFeedbackView>().ca9e5e4b6111ffdc3b0b4d8368c5c2046(cd267a5dc6434bf247c67a6b37ed70c84);
						c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<HUDFeedbackView>().cdb78d8f4c0a151823a6bd467ced0d6aa(c94fb97bff20285635980507f7f1a581a, c01e492fde1ff4a1457e04c75a02245a5, cd267a5dc6434bf247c67a6b37ed70c84);
						return;
					}
				}
			}
		}
		c272f383f145ac48ad098896e52a6d331(cdf5a8d522cf4c4b331f6a380cecd2451, cf7ee7f254a35f9c53a393957e2758a0a, cd267a5dc6434bf247c67a6b37ed70c84);
	}
}
