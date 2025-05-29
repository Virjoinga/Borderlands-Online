using System.Collections;
using System.Collections.Generic;
using A;
using UnityEngine;
using XsdSettings;

public class DNAPortrait : c06ca0e618478c23eba3419653a19760f<DNAPortrait>
{
	private Dictionary<int, DNAPortraitData> _mapPortraitDataCache;

	private UISnapData snapData;

	private DNAPortrait()
	{
		_mapPortraitDataCache = new Dictionary<int, DNAPortraitData>();
	}

	public void cac7688b05e921e2be3f92479ba44b4a8()
	{
		using (Dictionary<int, DNAPortraitData>.Enumerator enumerator = _mapPortraitDataCache.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				KeyValuePair<int, DNAPortraitData> current = enumerator.Current;
				Object.Destroy(current.Value.model);
				Object.Destroy(current.Value.tex);
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
				break;
			}
		}
		_mapPortraitDataCache.Clear();
		snapData = c7092818ec56a2cc1ec4d188b523c87e1.c7088de59e49f7108f520cf7e0bae167e;
	}

	public bool c4eb4b65926bb326691460e35136288d0(ItemDNA caedbc1db6c28d44eab6021e7d674eab3)
	{
		if (caedbc1db6c28d44eab6021e7d674eab3.m_type == ItemType.Material)
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
					return true;
				}
			}
		}
		int hashCode = caedbc1db6c28d44eab6021e7d674eab3.GetHashCode();
		DNAPortraitData value = cc275723896d1438875dfc3d2784fdcdf.c7088de59e49f7108f520cf7e0bae167e;
		if (_mapPortraitDataCache.TryGetValue(hashCode, out value))
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return value.model != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e;
				}
			}
		}
		return false;
	}

	public Texture2D c6965e945a09324a9af86f14518e0a697(ItemDNA caedbc1db6c28d44eab6021e7d674eab3, int c75b39f670644319e12d269760738e219 = 0, int ce5bb9a4a07c7d2e3338d904a4e1588bf = 0, TexPostEffectMgr.POST_EFFECT_TYPE cd3f028c57829f7f55d1c76f674c82eac = TexPostEffectMgr.POST_EFFECT_TYPE.POST_EFFECT_UI)
	{
		Texture2D cd6102468cd57214a9f3e10633998391b = c9e48915b2a8c6753d0b1a12e50ad1d27.c7088de59e49f7108f520cf7e0bae167e;
		if (caedbc1db6c28d44eab6021e7d674eab3.m_type == ItemType.Material)
		{
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
				c01b5ba430c0ae0fcec6c2d498c1c44ae(caedbc1db6c28d44eab6021e7d674eab3, out cd6102468cd57214a9f3e10633998391b);
				return cd6102468cd57214a9f3e10633998391b;
			}
		}
		int hashCode = caedbc1db6c28d44eab6021e7d674eab3.GetHashCode();
		DNAPortraitData value = cc275723896d1438875dfc3d2784fdcdf.c7088de59e49f7108f520cf7e0bae167e;
		_mapPortraitDataCache.TryGetValue(hashCode, out value);
		bool flag = false;
		if (value == null)
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
			if (c75b39f670644319e12d269760738e219 > 0)
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
				if (ce5bb9a4a07c7d2e3338d904a4e1588bf > 0)
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
					value = new DNAPortraitData(c75b39f670644319e12d269760738e219, ce5bb9a4a07c7d2e3338d904a4e1588bf);
					goto IL_008a;
				}
			}
			value = new DNAPortraitData();
			goto IL_008a;
		}
		if (value.boundPostEffect != cd3f028c57829f7f55d1c76f674c82eac)
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
			value.boundPostEffect = cd3f028c57829f7f55d1c76f674c82eac;
			flag = true;
		}
		goto IL_00c8;
		IL_00c8:
		cd6102468cd57214a9f3e10633998391b = value.tex;
		if (flag)
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
			if (caedbc1db6c28d44eab6021e7d674eab3.m_type == ItemType.Weapon)
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
				WeaponDNA c39409683a32e09391d094314ffeae2b = caedbc1db6c28d44eab6021e7d674eab3.ca79da172938fdc8c067fb64242b6174a();
				StartCoroutine(c7a094416ed4925696907210ec8b7b4e4(c39409683a32e09391d094314ffeae2b, cd6102468cd57214a9f3e10633998391b, _mapPortraitDataCache[hashCode]));
			}
			else if (caedbc1db6c28d44eab6021e7d674eab3.m_type == ItemType.Shield)
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
				c419772aa443803373b2498fcf893a736(caedbc1db6c28d44eab6021e7d674eab3, cd6102468cd57214a9f3e10633998391b, _mapPortraitDataCache[hashCode]);
			}
			else if (caedbc1db6c28d44eab6021e7d674eab3.m_type == ItemType.ClassMode)
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
				c1b4bd610eb36e298e1ec62675cda8bb6(caedbc1db6c28d44eab6021e7d674eab3, cd6102468cd57214a9f3e10633998391b, _mapPortraitDataCache[hashCode]);
			}
		}
		return cd6102468cd57214a9f3e10633998391b;
		IL_008a:
		value.dna = caedbc1db6c28d44eab6021e7d674eab3;
		value.boundPostEffect = cd3f028c57829f7f55d1c76f674c82eac;
		_mapPortraitDataCache.Add(hashCode, value);
		flag = true;
		goto IL_00c8;
	}

	private void c01b5ba430c0ae0fcec6c2d498c1c44ae(ItemDNA cf4af10ce9fa4ab84bd021b054d46a667, out Texture2D cd6102468cd57214a9f3e10633998391b)
	{
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InventoryView>().c3aa85fcf668307b56a215299bba49e31(cf4af10ce9fa4ab84bd021b054d46a667, out cd6102468cd57214a9f3e10633998391b);
	}

	private IEnumerator c7a094416ed4925696907210ec8b7b4e4(WeaponDNA c39409683a32e09391d094314ffeae2b5, Texture2D cd6102468cd57214a9f3e10633998391b, DNAPortraitData c6a03c72d453373f7c71baec6e8b91183)
	{
		GameObject model = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
		if (c6a03c72d453373f7c71baec6e8b91183.model == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			model = new GameObject(c39409683a32e09391d094314ffeae2b5.m_name);
			model.transform.parent = base.gameObject.transform;
			model.transform.localPosition = Vector3.zero;
			model.transform.localRotation = Quaternion.identity;
			yield return StartCoroutine(c06ca0e618478c23eba3419653a19760f<WeaponFactory>.c5ee19dc8d4cccf5ae2de225410458b86.cc864175eadf2cb0caddb6b43308a8afe(c39409683a32e09391d094314ffeae2b5, model));
		}
		model.layer = LayerMask.NameToLayer("UI");
		model.SetActive(true);
		Matrix4x4 toWorldMat = Matrix4x4.identity;
		toWorldMat.SetTRS(new Vector3(0f, 0f, 1f), Quaternion.Euler(new Vector3(0f, -90f, 0f)), Vector3.one * 0.5f);
		SkinnedMeshRenderer mesh = model.GetComponentInChildren<SkinnedMeshRenderer>();
		if (mesh != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c848ee3ec1aba9ee52ed305a7c47e42ce().c25b98c6351c6977ed7c754d7c8a0a836(mesh, ref toWorldMat, cd6102468cd57214a9f3e10633998391b, c6a03c72d453373f7c71baec6e8b91183.boundPostEffect);
		}
		model.SetActive(false);
		c6a03c72d453373f7c71baec6e8b91183.model = model;
	}

	private void c942edf13ec0a0399f1c6774236641c73()
	{
		snapData = (Resources.Load("Graphics/GraphicsData") as GameObject).GetComponent<UISnapData>();
	}

	private void c419772aa443803373b2498fcf893a736(ItemDNA c83130c8b3cb0bca5da0dd22b9693898d, Texture2D cd6102468cd57214a9f3e10633998391b, DNAPortraitData c6a03c72d453373f7c71baec6e8b91183)
	{
		if (snapData == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			c942edf13ec0a0399f1c6774236641c73();
		}
		GameObject gameObject = c6a03c72d453373f7c71baec6e8b91183.model;
		if (gameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			gameObject = new GameObject(c83130c8b3cb0bca5da0dd22b9693898d.c8e074b9d0135ff808166cc324407f74c().m_shieldManufacturer.ToString());
			gameObject.transform.parent = base.gameObject.transform;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localRotation = Quaternion.identity;
			c06ca0e618478c23eba3419653a19760f<WeaponFactory>.c5ee19dc8d4cccf5ae2de225410458b86.c7a2cb8c7425fd15999d90e446496ec69(c83130c8b3cb0bca5da0dd22b9693898d, gameObject);
		}
		gameObject.layer = LayerMask.NameToLayer("UI");
		gameObject.SetActive(true);
		float shield_Scale = snapData.m_Shield_Scale;
		Vector3 shield_Rot = snapData.m_Shield_Rot;
		Matrix4x4 c5b57750cb72c113cb7b45cd = Matrix4x4.identity;
		c5b57750cb72c113cb7b45cd.SetTRS(new Vector3(0f, 0f, 1f), Quaternion.Euler(shield_Rot), Vector3.one * shield_Scale);
		SkinnedMeshRenderer componentInChildren = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
		if (componentInChildren != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c848ee3ec1aba9ee52ed305a7c47e42ce().c25b98c6351c6977ed7c754d7c8a0a836(componentInChildren, ref c5b57750cb72c113cb7b45cd, cd6102468cd57214a9f3e10633998391b, c6a03c72d453373f7c71baec6e8b91183.boundPostEffect);
		}
		gameObject.SetActive(false);
		c6a03c72d453373f7c71baec6e8b91183.model = gameObject;
	}

	private void cd9fbf09b3e73dba958ec274fcdd9abd0(ItemDNA c498ff81f8ab3e0654c2a1ef994384fb9, out Matrix4x4 c5d1f277f4da60c06b72f285d5509deb7)
	{
		c5d1f277f4da60c06b72f285d5509deb7 = Matrix4x4.identity;
		float num = 1f;
		Vector3 euler = new Vector3(0f, 180f, 0f);
		switch (c498ff81f8ab3e0654c2a1ef994384fb9.m_classMode.m_cmType)
		{
		case ClassModeType.SoldierDemoMan:
		case ClassModeType.SoldierMachinist:
			num = snapData.m_ClassMode_SOLDIER_Scale;
			euler = snapData.m_ClassMode_SOLDIER_Rot;
			break;
		case ClassModeType.SirenEnchanter:
		case ClassModeType.SirenSorcerer:
			num = snapData.m_ClassMode_SIREN_Scale;
			euler = snapData.m_ClassMode_SIREN_Rot;
			break;
		case ClassModeType.BerserkerGuardian:
		case ClassModeType.BerserkerButcher:
			num = snapData.m_ClassMode_BERSERKER_Scale;
			euler = snapData.m_ClassMode_BERSERKER_Rot;
			break;
		case ClassModeType.HunterAgent:
		case ClassModeType.HunterMarksman:
			num = snapData.m_ClassMode_HUNTER_Scale;
			euler = snapData.m_ClassMode_HUNTER_Rot;
			break;
		}
		c5d1f277f4da60c06b72f285d5509deb7.SetTRS(new Vector3(0f, 0f, 1f), Quaternion.Euler(euler), Vector3.one * num);
	}

	private void c1b4bd610eb36e298e1ec62675cda8bb6(ItemDNA c498ff81f8ab3e0654c2a1ef994384fb9, Texture2D cd6102468cd57214a9f3e10633998391b, DNAPortraitData c6a03c72d453373f7c71baec6e8b91183)
	{
		if (snapData == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			c942edf13ec0a0399f1c6774236641c73();
		}
		GameObject gameObject = c6a03c72d453373f7c71baec6e8b91183.model;
		if (gameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			gameObject = new GameObject(c498ff81f8ab3e0654c2a1ef994384fb9.c253c28f3a59bc5e5a528dfbb463a8a45().m_cmType.ToString());
			gameObject.transform.parent = base.gameObject.transform;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localRotation = Quaternion.identity;
			c06ca0e618478c23eba3419653a19760f<WeaponFactory>.c5ee19dc8d4cccf5ae2de225410458b86.c509692699b2920501e9ab023be263d36(c498ff81f8ab3e0654c2a1ef994384fb9, gameObject);
		}
		gameObject.layer = LayerMask.NameToLayer("UI");
		gameObject.SetActive(true);
		Matrix4x4 c5d1f277f4da60c06b72f285d5509deb = Matrix4x4.identity;
		cd9fbf09b3e73dba958ec274fcdd9abd0(c498ff81f8ab3e0654c2a1ef994384fb9, out c5d1f277f4da60c06b72f285d5509deb);
		SkinnedMeshRenderer componentInChildren = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
		if (componentInChildren != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c848ee3ec1aba9ee52ed305a7c47e42ce().c25b98c6351c6977ed7c754d7c8a0a836(componentInChildren, ref c5d1f277f4da60c06b72f285d5509deb, cd6102468cd57214a9f3e10633998391b, c6a03c72d453373f7c71baec6e8b91183.boundPostEffect);
		}
		gameObject.SetActive(false);
		c6a03c72d453373f7c71baec6e8b91183.model = gameObject;
	}
}
