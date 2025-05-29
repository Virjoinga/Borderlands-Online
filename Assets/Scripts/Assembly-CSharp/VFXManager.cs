using System;
using System.Collections;
using System.Collections.Generic;
using A;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
	private static Dictionary<string, UnityEngine.Object> s_VFXTable = new Dictionary<string, UnityEngine.Object>();

	private static Dictionary<string, UnityEngine.Object> s_VFXAssets = new Dictionary<string, UnityEngine.Object>();

	public VFXforNPC[] m_particleList;

	public BaseEventTriggerCtl m_audioCtl;

	public static void c5424b257448f7fd262986b927c1d46be(BaseAssetBundle c55644b999838f2d90a4ea87f98774f18)
	{
		if (c55644b999838f2d90a4ea87f98774f18 == null)
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
		if (!c4accf76c0f19b142d9a734118edfa5ce())
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
			UnityEngine.Object[] array = c55644b999838f2d90a4ea87f98774f18.c6a2c96c95dbb6d94ab759d22726b0440();
			if (array == null)
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
			foreach (UnityEngine.Object @object in array)
			{
				if (@object is GameObject)
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
					if (!s_VFXTable.ContainsKey(@object.name))
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
						s_VFXTable.Add(@object.name, @object);
					}
					else
					{
						UnityEngine.Object.DestroyImmediate(@object, true);
					}
					continue;
				}
				if (!(@object != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
				{
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
				if (s_VFXAssets.ContainsKey(@object.name))
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
					break;
				}
				s_VFXAssets.Add(@object.name, @object);
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
	}

	public static void ca1e80b7d8118ff175dca46b7f324d279()
	{
		Dictionary<string, UnityEngine.Object>.Enumerator enumerator = s_VFXTable.GetEnumerator();
		while (enumerator.MoveNext())
		{
			UnityEngine.Object.DestroyImmediate(enumerator.Current.Value, true);
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
			s_VFXTable.Clear();
			Dictionary<string, UnityEngine.Object>.Enumerator enumerator2 = s_VFXAssets.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				if (enumerator2.Current.Value is Component)
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
					UnityEngine.Object.DestroyImmediate(enumerator2.Current.Value, true);
				}
				else
				{
					Resources.UnloadAsset(enumerator2.Current.Value);
				}
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				s_VFXAssets.Clear();
				return;
			}
		}
	}

	private void Start()
	{
		if (!c4accf76c0f19b142d9a734118edfa5ce())
		{
			while (true)
			{
				switch (4)
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
		for (int i = 0; i < m_particleList.Length; i++)
		{
			VFXforNPC vFXforNPC = m_particleList[i];
			if (vFXforNPC == null)
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
				break;
			}
			UnityEngine.Object value = c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e;
			if (!s_VFXTable.TryGetValue(vFXforNPC.m_particleGameObjectName, out value))
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
			vFXforNPC.m_particleGameObject = (GameObject)UnityEngine.Object.Instantiate(value);
			Quaternion localRotation = vFXforNPC.m_particleGameObject.transform.localRotation;
			vFXforNPC.m_particleGameObject.transform.parent = vFXforNPC.m_particleTransform;
			vFXforNPC.m_particleGameObject.transform.localPosition = Vector3.zero;
			vFXforNPC.m_particleGameObject.transform.localRotation = localRotation;
			vFXforNPC.m_particle = vFXforNPC.m_particleGameObject.particleSystem;
			vFXforNPC.m_particleGameObject.SetActive(false);
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				continue;
			}
			m_audioCtl = GetComponent<BaseEventTriggerCtl>();
			return;
		}
	}

	public void ca207f1e0d04d63120f9d87ad07507680(ENPCParticleType c6e9c05551eaa310c6fcb665b20682b9c, Transform c9faf24a1c81e179966bd889529a07723)
	{
		if (!c4accf76c0f19b142d9a734118edfa5ce())
		{
			while (true)
			{
				switch (6)
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
		for (int i = 0; i < m_particleList.Length; i++)
		{
			VFXforNPC vFXforNPC = m_particleList[i];
			if (c6e9c05551eaa310c6fcb665b20682b9c != vFXforNPC.m_type)
			{
				continue;
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				break;
			}
			Transform transform = c3bc7a726865b74db30fdc51cc35704df(vFXforNPC, c9faf24a1c81e179966bd889529a07723);
			if (!(transform != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
			{
				continue;
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
			if (!(vFXforNPC.m_particleGameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
			{
				continue;
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
			vFXforNPC.m_particleGameObject.transform.parent = transform;
			vFXforNPC.m_particleGameObject.transform.localPosition = Vector3.zero;
			vFXforNPC.m_particleGameObject.transform.localRotation = Quaternion.identity;
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

	public void c9d956169d3ec6aad567c376ca656c922(ENPCParticleType c6e9c05551eaa310c6fcb665b20682b9c)
	{
		if (!c4accf76c0f19b142d9a734118edfa5ce())
		{
			while (true)
			{
				switch (6)
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
		for (int i = 0; i < m_particleList.Length; i++)
		{
			VFXforNPC vFXforNPC = m_particleList[i];
			if (c6e9c05551eaa310c6fcb665b20682b9c != vFXforNPC.m_type)
			{
				continue;
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				break;
			}
			UnityEngine.Object.Destroy(vFXforNPC.m_particleGameObject);
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	public bool c6f2661406df861477b09a9ac6e05d089(ENPCParticleType c6e9c05551eaa310c6fcb665b20682b9c, Transform c9faf24a1c81e179966bd889529a07723, bool c200113bdb7cb2397f593e9b6b4d396f9, float cdc9f6ace07173b95607c1a4b98439397 = 0f, bool c2c8319c3a1c19709286e3d309413629b = true)
	{
		if (!c4accf76c0f19b142d9a734118edfa5ce())
		{
			while (true)
			{
				switch (4)
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
		if (m_particleList == null)
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
		for (int i = 0; i < m_particleList.Length; i++)
		{
			VFXforNPC vFXforNPC = m_particleList[i];
			if (vFXforNPC == null)
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
				continue;
			}
			if (c6e9c05551eaa310c6fcb665b20682b9c != vFXforNPC.m_type)
			{
				continue;
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
			if (vFXforNPC.m_particle == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				continue;
			}
			if (!c2c8319c3a1c19709286e3d309413629b)
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
				if (vFXforNPC.m_particle.isPlaying)
				{
					goto IL_01f9;
				}
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			if (vFXforNPC.m_particleGameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				continue;
			}
			Transform transform = c3bc7a726865b74db30fdc51cc35704df(vFXforNPC, c9faf24a1c81e179966bd889529a07723);
			if (c200113bdb7cb2397f593e9b6b4d396f9)
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
				vFXforNPC.m_particleGameObject.transform.parent = transform;
				vFXforNPC.m_particleGameObject.transform.localPosition = Vector3.zero;
				vFXforNPC.m_particleGameObject.transform.localRotation = Quaternion.identity;
			}
			else
			{
				vFXforNPC.m_particleGameObject.transform.parent = ce1fb4d774e60a964105c162513d97b38.c7088de59e49f7108f520cf7e0bae167e;
				vFXforNPC.m_particleGameObject.transform.position = transform.position;
				vFXforNPC.m_particleGameObject.transform.rotation = transform.rotation;
			}
			vFXforNPC.m_particleGameObject.SetActive(true);
			vFXforNPC.m_particle.Play();
			if (!string.IsNullOrEmpty(vFXforNPC.m_audioEvent))
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
				m_audioCtl.TriggerEventByName(vFXforNPC.m_audioEvent);
			}
			if (cdc9f6ace07173b95607c1a4b98439397 > 0f)
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
				if (vFXforNPC.m_timer == null)
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
					continue;
				}
				vFXforNPC.m_timer.Start(cdc9f6ace07173b95607c1a4b98439397);
			}
			goto IL_01f9;
			IL_01f9:
			return true;
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			return false;
		}
	}

	public bool cabda1e77309d61d99a04e4b57b962f2f(ENPCParticleType c6e9c05551eaa310c6fcb665b20682b9c, float cdc9f6ace07173b95607c1a4b98439397 = 0f, bool c2c8319c3a1c19709286e3d309413629b = true)
	{
		if (!c4accf76c0f19b142d9a734118edfa5ce())
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
					return false;
				}
			}
		}
		bool result = false;
		for (int i = 0; i < m_particleList.Length; i++)
		{
			if (c6e9c05551eaa310c6fcb665b20682b9c != m_particleList[i].m_type)
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
			if (m_particleList[i].m_particle == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					return false;
				}
			}
			if (!c2c8319c3a1c19709286e3d309413629b)
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
				if (m_particleList[i].m_particle.isPlaying)
				{
					goto IL_0122;
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
			m_particleList[i].m_particleGameObject.SetActive(true);
			m_particleList[i].m_particle.Play();
			if (m_particleList[i].m_audioEvent != string.Empty)
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
				m_audioCtl.TriggerEventByName(m_particleList[i].m_audioEvent);
			}
			if (cdc9f6ace07173b95607c1a4b98439397 > 0f)
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
				m_particleList[i].m_timer.Start(cdc9f6ace07173b95607c1a4b98439397);
			}
			goto IL_0122;
			IL_0122:
			result = true;
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			return result;
		}
	}

	public bool c930218e437c0501ced1553e08dab14d9(ENPCParticleType c6e9c05551eaa310c6fcb665b20682b9c, Entity cefa1ef202663b7c307052b892c11dbec, Transform c0b8b4f11377b8a222dc728ff2c622559, Vector3 c912f9ac7e315af00d7f70e9f885160e4, Quaternion c6a7088e341a59a8f41cb994cc49e2586, float cdc9f6ace07173b95607c1a4b98439397 = 0f, bool c2c8319c3a1c19709286e3d309413629b = true)
	{
		if (!c4accf76c0f19b142d9a734118edfa5ce())
		{
			while (true)
			{
				switch (6)
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
		for (int i = 0; i < m_particleList.Length; i++)
		{
			if (m_particleList[i] == null)
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
			if (c6e9c05551eaa310c6fcb665b20682b9c != m_particleList[i].m_type)
			{
				continue;
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				if (m_particleList[i].m_particleGameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (4)
						{
						case 0:
							continue;
						}
						return false;
					}
				}
				if (m_particleList[i].m_particleGameObject.transform == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (5)
						{
						case 0:
							continue;
						}
						return false;
					}
				}
				if (m_particleList[i].m_particle == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (2)
						{
						case 0:
							continue;
						}
						return false;
					}
				}
				if (!c2c8319c3a1c19709286e3d309413629b)
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
					if (m_particleList[i].m_particle.isPlaying)
					{
						goto IL_01de;
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
				}
				m_particleList[i].m_particleGameObject.transform.parent = c0b8b4f11377b8a222dc728ff2c622559;
				m_particleList[i].m_particleGameObject.transform.localPosition = c912f9ac7e315af00d7f70e9f885160e4;
				m_particleList[i].m_particleGameObject.transform.localRotation = c6a7088e341a59a8f41cb994cc49e2586;
				m_particleList[i].m_particleGameObject.SetActive(true);
				m_particleList[i].m_particle.Play();
				if (m_particleList[i].m_audioEvent != string.Empty)
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
					m_audioCtl.TriggerEventByName(m_particleList[i].m_audioEvent);
				}
				if (cdc9f6ace07173b95607c1a4b98439397 > 0f)
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
					m_particleList[i].m_timer.Start(cdc9f6ace07173b95607c1a4b98439397);
				}
				goto IL_01de;
				IL_01de:
				return true;
			}
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			return false;
		}
	}

	public bool c930218e437c0501ced1553e08dab14d9(ENPCParticleType c6e9c05551eaa310c6fcb665b20682b9c, Vector3 cef9712200bbe2c3873eec3ca2e18a595, Quaternion c4ea6de03c1203f2470a6677821ad93f0, float cdc9f6ace07173b95607c1a4b98439397 = 0f, bool c2c8319c3a1c19709286e3d309413629b = true)
	{
		if (!c4accf76c0f19b142d9a734118edfa5ce())
		{
			while (true)
			{
				switch (6)
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
		for (int i = 0; i < m_particleList.Length; i++)
		{
			if (c6e9c05551eaa310c6fcb665b20682b9c != m_particleList[i].m_type)
			{
				continue;
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				if (!c2c8319c3a1c19709286e3d309413629b)
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
					if (m_particleList[i].m_particle.isPlaying)
					{
						goto IL_0130;
					}
					while (true)
					{
						switch (2)
						{
						case 0:
							continue;
						}
						break;
					}
				}
				m_particleList[i].m_particleGameObject.transform.position = cef9712200bbe2c3873eec3ca2e18a595;
				m_particleList[i].m_particleGameObject.transform.rotation = c4ea6de03c1203f2470a6677821ad93f0;
				m_particleList[i].m_particleGameObject.SetActive(true);
				m_particleList[i].m_particle.Play();
				if (m_particleList[i].m_audioEvent != string.Empty)
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
					m_audioCtl.TriggerEventByName(m_particleList[i].m_audioEvent);
				}
				if (cdc9f6ace07173b95607c1a4b98439397 > 0f)
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
					m_particleList[i].m_timer.Start(cdc9f6ace07173b95607c1a4b98439397);
				}
				goto IL_0130;
				IL_0130:
				return true;
			}
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			return false;
		}
	}

	public bool c930218e437c0501ced1553e08dab14d9(ENPCParticleType c6e9c05551eaa310c6fcb665b20682b9c, Transform c2651896b265273fbec506b1fb5f97c6e, bool c2c8319c3a1c19709286e3d309413629b = true)
	{
		if (!c4accf76c0f19b142d9a734118edfa5ce())
		{
			while (true)
			{
				switch (5)
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
		if (c2651896b265273fbec506b1fb5f97c6e == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		for (int i = 0; i < m_particleList.Length; i++)
		{
			if (c6e9c05551eaa310c6fcb665b20682b9c != m_particleList[i].m_type)
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
				if (m_particleList[i].m_particle == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						return false;
					}
				}
				if (m_particleList[i].m_particleGameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (2)
						{
						case 0:
							continue;
						}
						return false;
					}
				}
				if (!c2c8319c3a1c19709286e3d309413629b)
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
					if (m_particleList[i].m_particle.isPlaying)
					{
						goto IL_01b6;
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
				m_particleList[i].m_particleGameObject.transform.parent = ce1fb4d774e60a964105c162513d97b38.c7088de59e49f7108f520cf7e0bae167e;
				m_particleList[i].m_particleGameObject.transform.position = c2651896b265273fbec506b1fb5f97c6e.position;
				m_particleList[i].m_particleGameObject.transform.rotation = c2651896b265273fbec506b1fb5f97c6e.rotation;
				m_particleList[i].m_particleGameObject.SetActive(true);
				m_particleList[i].m_particle.Play();
				if (m_audioCtl != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					if (!string.IsNullOrEmpty(m_particleList[i].m_audioEvent))
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
						m_audioCtl.TriggerEventByName(m_particleList[i].m_audioEvent);
					}
				}
				goto IL_01b6;
				IL_01b6:
				return true;
			}
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			return false;
		}
	}

	public bool c0c5ca8f54702477a0524e764704df02c(ENPCParticleType c6e9c05551eaa310c6fcb665b20682b9c, Entity cefa1ef202663b7c307052b892c11dbec, Vector3 c330987c4414f384d6c951ab9f68460d8, Quaternion c2a8e8b393b40d6cde9e5177c7a9adb48, bool c2c8319c3a1c19709286e3d309413629b = true)
	{
		if (!c4accf76c0f19b142d9a734118edfa5ce())
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
		for (int i = 0; i < m_particleList.Length; i++)
		{
			if (m_particleList[i] == null)
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
			if (c6e9c05551eaa310c6fcb665b20682b9c != m_particleList[i].m_type)
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
				if (m_particleList[i].m_particleGameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (4)
						{
						case 0:
							continue;
						}
						return false;
					}
				}
				if (m_particleList[i].m_particleGameObject.transform == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						return false;
					}
				}
				if (m_particleList[i].m_particle == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						return false;
					}
				}
				if (!c2c8319c3a1c19709286e3d309413629b)
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
					if (m_particleList[i].m_particle.isPlaying)
					{
						goto IL_01ba;
					}
					while (true)
					{
						switch (2)
						{
						case 0:
							continue;
						}
						break;
					}
				}
				m_particleList[i].m_particleGameObject.transform.parent = ce1fb4d774e60a964105c162513d97b38.c7088de59e49f7108f520cf7e0bae167e;
				m_particleList[i].m_particleGameObject.transform.position = c330987c4414f384d6c951ab9f68460d8;
				m_particleList[i].m_particleGameObject.transform.rotation = c2a8e8b393b40d6cde9e5177c7a9adb48;
				m_particleList[i].m_particleGameObject.SetActive(true);
				m_particleList[i].m_particle.Play();
				if (m_particleList[i].m_audioEvent != string.Empty)
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
					m_audioCtl.TriggerEventByName(m_particleList[i].m_audioEvent);
				}
				goto IL_01ba;
				IL_01ba:
				return true;
			}
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			return false;
		}
	}

	public bool c930218e437c0501ced1553e08dab14d9(ENPCParticleType c6e9c05551eaa310c6fcb665b20682b9c, Vector3 c330987c4414f384d6c951ab9f68460d8, Quaternion c2a8e8b393b40d6cde9e5177c7a9adb48, bool c2c8319c3a1c19709286e3d309413629b = true)
	{
		if (!c4accf76c0f19b142d9a734118edfa5ce())
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
					return false;
				}
			}
		}
		for (int i = 0; i < m_particleList.Length; i++)
		{
			if (c6e9c05551eaa310c6fcb665b20682b9c != m_particleList[i].m_type)
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
				if (!c2c8319c3a1c19709286e3d309413629b)
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
					if (m_particleList[i].m_particle.isPlaying)
					{
						goto IL_0109;
					}
					while (true)
					{
						switch (2)
						{
						case 0:
							continue;
						}
						break;
					}
				}
				m_particleList[i].m_particleGameObject.transform.position = c330987c4414f384d6c951ab9f68460d8;
				m_particleList[i].m_particleGameObject.transform.rotation = c2a8e8b393b40d6cde9e5177c7a9adb48;
				m_particleList[i].m_particleGameObject.SetActive(true);
				m_particleList[i].m_particle.Play();
				if (m_particleList[i].m_audioEvent != string.Empty)
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
					m_audioCtl.TriggerEventByName(m_particleList[i].m_audioEvent);
				}
				goto IL_0109;
				IL_0109:
				return true;
			}
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			return false;
		}
	}

	public bool c930218e437c0501ced1553e08dab14d9(ENPCParticleType c6e9c05551eaa310c6fcb665b20682b9c, Vector3 c330987c4414f384d6c951ab9f68460d8, bool c2c8319c3a1c19709286e3d309413629b = true)
	{
		if (!c4accf76c0f19b142d9a734118edfa5ce())
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
		for (int i = 0; i < m_particleList.Length; i++)
		{
			if (c6e9c05551eaa310c6fcb665b20682b9c != m_particleList[i].m_type)
			{
				continue;
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				if (!c2c8319c3a1c19709286e3d309413629b)
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
					if (m_particleList[i].m_particle.isPlaying)
					{
						goto IL_00ee;
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
				m_particleList[i].m_particleGameObject.transform.position = c330987c4414f384d6c951ab9f68460d8;
				m_particleList[i].m_particleGameObject.SetActive(true);
				m_particleList[i].m_particle.Play();
				if (m_particleList[i].m_audioEvent != string.Empty)
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
					m_audioCtl.TriggerEventByName(m_particleList[i].m_audioEvent);
				}
				goto IL_00ee;
				IL_00ee:
				return true;
			}
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			return false;
		}
	}

	public GameObject ce3d5e90605924606973312e2618e2dac(ENPCParticleType c6e9c05551eaa310c6fcb665b20682b9c, int c5612a459a84ffdb41c885401433cd62d = 0)
	{
		if (!c4accf76c0f19b142d9a734118edfa5ce())
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return null;
				}
			}
		}
		for (int i = 0; i < m_particleList.Length; i++)
		{
			if (c6e9c05551eaa310c6fcb665b20682b9c != m_particleList[i].m_type)
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
			if (c5612a459a84ffdb41c885401433cd62d-- != 0)
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
				return m_particleList[i].m_particleGameObject;
			}
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			return null;
		}
	}

	public VFXforNPC ce8ff2ad1330d7ace4db19e7af93c265f(ENPCParticleType c6e9c05551eaa310c6fcb665b20682b9c, int c5612a459a84ffdb41c885401433cd62d = 0)
	{
		if (!c4accf76c0f19b142d9a734118edfa5ce())
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
					return null;
				}
			}
		}
		for (int i = 0; i < m_particleList.Length; i++)
		{
			if (c6e9c05551eaa310c6fcb665b20682b9c != m_particleList[i].m_type)
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
				break;
			}
			if (c5612a459a84ffdb41c885401433cd62d-- != 0)
			{
				continue;
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				return m_particleList[i];
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

	public bool c61965fdbaf3e5bcda81d0af5a65e1ac8(ENPCParticleType c6e9c05551eaa310c6fcb665b20682b9c)
	{
		if (!c4accf76c0f19b142d9a734118edfa5ce())
		{
			while (true)
			{
				switch (5)
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
		for (int i = 0; i < m_particleList.Length; i++)
		{
			if (c6e9c05551eaa310c6fcb665b20682b9c != m_particleList[i].m_type)
			{
				continue;
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				if (m_particleList[i].m_particle != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					m_particleList[i].m_particle.Stop();
				}
				if (m_particleList[i].m_particleGameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					m_particleList[i].m_particleGameObject.SetActive(false);
				}
				return true;
			}
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			return false;
		}
	}

	public void cea92255d82a6e0d2a5f50a107d781c56(ENPCParticleType c6e9c05551eaa310c6fcb665b20682b9c)
	{
		if (!c4accf76c0f19b142d9a734118edfa5ce())
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
		for (int i = 0; i < m_particleList.Length; i++)
		{
			if (c6e9c05551eaa310c6fcb665b20682b9c != m_particleList[i].m_type)
			{
				continue;
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				if (m_particleList[i].m_particle != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					m_particleList[i].m_particle.transform.parent = base.gameObject.transform;
					m_particleList[i].m_particle.Stop();
					m_particleList[i].m_particle.Clear();
				}
				if (!(m_particleList[i].m_particleGameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					m_particleList[i].m_particleGameObject.SetActive(false);
					return;
				}
			}
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	private void Update()
	{
		if (!c4accf76c0f19b142d9a734118edfa5ce())
		{
			while (true)
			{
				switch (6)
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
		for (int i = 0; i < m_particleList.Length; i++)
		{
			if (!m_particleList[i].m_timer.cf928603d375f06225f9eb5213fb17bd4())
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
			m_particleList[i].m_particle.Stop();
			m_particleList[i].m_particleGameObject.SetActive(false);
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

	public void cb6ddb86ff592b855d40e4b6baac609bf()
	{
		if (!c4accf76c0f19b142d9a734118edfa5ce())
		{
			while (true)
			{
				switch (4)
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
		for (int i = 0; i < m_particleList.Length; i++)
		{
			if (m_particleList[i].m_particle == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			}
			else
			{
				m_particleList[i].m_particle.transform.parent = base.gameObject.transform;
				m_particleList[i].m_particle.Stop();
				m_particleList[i].m_particle.Clear();
				m_particleList[i].m_particleGameObject.SetActive(false);
			}
		}
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

	public static bool c4accf76c0f19b142d9a734118edfa5ce()
	{
		if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_offlineMode)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						return true;
					}
				}
			}
		}
		if (NetworkManager.c449802e708e91a9150466060fbab2ad6())
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
		return true;
	}

	private Transform c3bc7a726865b74db30fdc51cc35704df(VFXforNPC c37a5c084d9f8818d14ca2969de380ac4, Transform ce1be602cc4b9ec3bf76ad0d87d7460e7)
	{
		if (c37a5c084d9f8818d14ca2969de380ac4.m_boneParent == string.Empty)
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
					return null;
				}
			}
		}
		if (c37a5c084d9f8818d14ca2969de380ac4.m_boneTr == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			c37a5c084d9f8818d14ca2969de380ac4.m_boneTr = cd7e713117e8662fdc8bf0797b3134656(ce1be602cc4b9ec3bf76ad0d87d7460e7, c37a5c084d9f8818d14ca2969de380ac4.m_boneParent);
		}
		return c37a5c084d9f8818d14ca2969de380ac4.m_boneTr;
	}

	private Transform cd7e713117e8662fdc8bf0797b3134656(Transform c072d62d4edaec97afba470332ae2bbe8, string cf6815e425026ca075e85851e7fd4a872)
	{
		if (c072d62d4edaec97afba470332ae2bbe8.name.Equals(cf6815e425026ca075e85851e7fd4a872))
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
					return c072d62d4edaec97afba470332ae2bbe8;
				}
			}
		}
		IEnumerator enumerator = c072d62d4edaec97afba470332ae2bbe8.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Transform c072d62d4edaec97afba470332ae2bbe9 = (Transform)enumerator.Current;
				Transform transform = cd7e713117e8662fdc8bf0797b3134656(c072d62d4edaec97afba470332ae2bbe9, cf6815e425026ca075e85851e7fd4a872);
				if (!(transform != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
				{
					continue;
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					return transform;
				}
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					goto end_IL_0072;
				}
				continue;
				end_IL_0072:
				break;
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
						goto end_IL_008a;
					}
					continue;
					end_IL_008a:
					break;
				}
			}
			else
			{
				disposable.Dispose();
			}
		}
		return null;
	}

	public virtual void OnReceiveEvent(string eventData)
	{
	}

	public static bool cc7cfd55d187c16b8a5b776189ba38781(ENPCParticleType c6e9c05551eaa310c6fcb665b20682b9c)
	{
		if (c6e9c05551eaa310c6fcb665b20682b9c != ENPCParticleType.E_DamagedBulletNone)
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
			if (c6e9c05551eaa310c6fcb665b20682b9c != ENPCParticleType.E_DamageHeadShot)
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
				if (c6e9c05551eaa310c6fcb665b20682b9c != ENPCParticleType.E_DamageOnArmor)
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
					if (c6e9c05551eaa310c6fcb665b20682b9c != ENPCParticleType.E_DamageShieldHit)
					{
						return false;
					}
					while (true)
					{
						switch (2)
						{
						case 0:
							continue;
						}
						break;
					}
				}
			}
		}
		return true;
	}
}
