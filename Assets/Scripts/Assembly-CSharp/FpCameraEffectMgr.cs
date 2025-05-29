using System.Collections.Generic;
using A;
using UnityEngine;

public class FpCameraEffectMgr
{
	private GameObject graphicMgrObj;

	private List<VFXforNPC> lstParticleEffects = new List<VFXforNPC>();

	public void ccc9d3a38966dc10fedb531ea17d24611(GameObject c93ebf9c9e9b3c7c4b0e9738fd12a7d8f)
	{
		graphicMgrObj = c93ebf9c9e9b3c7c4b0e9738fd12a7d8f;
		graphicMgrObj.AddComponent<FpCameraEffectBehaviour>();
	}

	public void Update()
	{
		if (!VFXManager.c4accf76c0f19b142d9a734118edfa5ce())
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
		for (int num = lstParticleEffects.Count - 1; num >= 0; num--)
		{
			if (!lstParticleEffects[num].m_timer.cf928603d375f06225f9eb5213fb17bd4())
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
				if (!(lstParticleEffects[num].m_particle != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
				{
					continue;
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!lstParticleEffects[num].m_particle.isStopped)
				{
					continue;
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
			if (lstParticleEffects[num].m_particle != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				lstParticleEffects[num].m_particle.Stop();
			}
			lstParticleEffects[num].m_particleGameObject.SetActive(false);
			lstParticleEffects.RemoveAt(num);
		}
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

	public void cb6ddb86ff592b855d40e4b6baac609bf()
	{
		for (int i = 0; i < lstParticleEffects.Count; i++)
		{
			if (lstParticleEffects[i].m_particle != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				lstParticleEffects[i].m_particle.Stop();
			}
			lstParticleEffects[i].m_particleGameObject.SetActive(false);
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				continue;
			}
			lstParticleEffects.Clear();
			return;
		}
	}

	public bool cf431f37720a42b1f9cfcdc32ff9dcd71(EntityPlayer ceb41162a7cd2a1d5c4a03830e02b4198, ENPCParticleType c2b4f43f34e21572af6ab4414f04cee36)
	{
		if (!VFXManager.c4accf76c0f19b142d9a734118edfa5ce())
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
					return false;
				}
			}
		}
		VFXforNPC vFXforNPC = ceb41162a7cd2a1d5c4a03830e02b4198.cb1bc1ed3579c8c5bda5a8a3dbd112ea9.ce8ff2ad1330d7ace4db19e7af93c265f(c2b4f43f34e21572af6ab4414f04cee36);
		if (vFXforNPC == null)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		if (vFXforNPC.m_particleGameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		vFXforNPC.m_particleGameObject.SetActive(false);
		if (vFXforNPC.m_particle != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			vFXforNPC.m_particle.Stop();
		}
		lstParticleEffects.Remove(vFXforNPC);
		return true;
	}

	public bool c02b20c991314989826a70c235439571f(EntityPlayer ceb41162a7cd2a1d5c4a03830e02b4198, ENPCParticleType c2b4f43f34e21572af6ab4414f04cee36, float cdc9f6ace07173b95607c1a4b98439397 = 0f)
	{
		return c02b20c991314989826a70c235439571f(ceb41162a7cd2a1d5c4a03830e02b4198, c2b4f43f34e21572af6ab4414f04cee36, Vector3.zero, Quaternion.identity, cdc9f6ace07173b95607c1a4b98439397);
	}

	public bool c02b20c991314989826a70c235439571f(EntityPlayer ceb41162a7cd2a1d5c4a03830e02b4198, ENPCParticleType c2b4f43f34e21572af6ab4414f04cee36, Vector3 c52921fe9488ee3d539be727c81094423, Quaternion c4ea6de03c1203f2470a6677821ad93f0, float cdc9f6ace07173b95607c1a4b98439397 = 0f)
	{
		if (!VFXManager.c4accf76c0f19b142d9a734118edfa5ce())
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
					return false;
				}
			}
		}
		VFXforNPC vFXforNPC = ceb41162a7cd2a1d5c4a03830e02b4198.cb1bc1ed3579c8c5bda5a8a3dbd112ea9.ce8ff2ad1330d7ace4db19e7af93c265f(c2b4f43f34e21572af6ab4414f04cee36);
		if (vFXforNPC == null)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		if (vFXforNPC.m_particleGameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		vFXforNPC.m_particleGameObject.SetActive(true);
		if (vFXforNPC.m_particleGameObject.transform == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		vFXforNPC.m_particleGameObject.transform.parent = ceb41162a7cd2a1d5c4a03830e02b4198.cc6a7269e9ea93e537de47dc752b09a86().transform;
		vFXforNPC.m_particleGameObject.transform.localPosition = c52921fe9488ee3d539be727c81094423;
		vFXforNPC.m_particleGameObject.transform.localRotation = c4ea6de03c1203f2470a6677821ad93f0;
		if (vFXforNPC.m_particle != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			vFXforNPC.m_particle.Play();
		}
		if (vFXforNPC.m_audioEvent != string.Empty)
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
			ceb41162a7cd2a1d5c4a03830e02b4198.cb1bc1ed3579c8c5bda5a8a3dbd112ea9.m_audioCtl.TriggerEventByName(vFXforNPC.m_audioEvent);
		}
		if (cdc9f6ace07173b95607c1a4b98439397 > 0f)
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
			vFXforNPC.m_timer.Start(cdc9f6ace07173b95607c1a4b98439397);
		}
		lstParticleEffects.Add(vFXforNPC);
		return true;
	}
}
