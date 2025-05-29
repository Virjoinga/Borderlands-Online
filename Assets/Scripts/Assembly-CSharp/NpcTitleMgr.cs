using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using Core;
using UnityEngine;

public class NpcTitleMgr
{
	public enum NPC_ICON_TYPE
	{
		NPC_ICON_NONE = 0,
		NPC_ICON_DONE = 1,
		NPC_ICON_PROGRESS = 2,
		NPC_ICON_NEW = 3,
		NPC_ICON_DAILY_NEW = 4,
		NPC_ICON_DAILY_DONE = 5,
		NPC_ICON_SPECIAL_NEW = 6,
		NPC_ICON_SPECIAL_DONE = 7,
		NPC_ICON_CRAFT = 8,
		NPC_ICON_DOC = 9,
		NPC_ICON_GUILD = 10,
		NPC_ICON_MAIL = 11,
		NPC_ICON_MAIL_NEW = 12,
		NPC_ICON_WAREHOUSE = 13,
		NPC_ICON_SHOP = 14,
		NPC_ICON_UPGRADE = 15,
		NPC_ICON_DUMMY = 16,
		NPC_ICON_SKILL = 17,
		NPC_ICON_NUM = 18
	}

	private const string MESH_ICON_GAMEOBJECT_NAME = "Icon";

	private const string MESH_NUM_ABOVE_ICON_GAMEOBJECT_NAME = "NumAboveIcon";

	private Material mNpcNameMaterial;

	private Material mIconNewMaterial;

	private Material mIconProgressMaterial;

	private Material mIconDoneMaterial;

	private Material mIconSkillMaterial;

	private Material mIconDummyMaterial;

	private Material mIconDailyQuestNew;

	private Material mIconDailyQuestDone;

	private Material mIconSpecialQuestNew;

	private Material mIconSpecialQuestDone;

	private Material mIconCraft;

	private Material mIconDoc;

	private Material mIconGuild;

	private Material mIconMail;

	private Material mIconMailNew;

	private Material mIconShop;

	private Material mIconUpgrade;

	private BillboardSizeChanger mSizeChanger;

	private BillboardAnimator mBillboardAnimator;

	private List<Material> mNumListMaterials = new List<Material>();

	private Dictionary<NPC_ICON_TYPE, Material> mMatTypeDic = new Dictionary<NPC_ICON_TYPE, Material>();

	private GameObject mRefMsyhObj;

	private TextMesh mRefTextMesh;

	private Texture mRefMsyhTex;

	private Mesh mMeshIcon;

	private Mesh mMeshNumAboveIcon;

	private GameObject mCurNpcObj;

	private NPC_ICON_TYPE mPreHideIconType;

	public void ccc9d3a38966dc10fedb531ea17d24611()
	{
		GameObject gameObject = Resources.Load("Graphics/GraphicsData") as GameObject;
		NPCTitleEffectData component = gameObject.GetComponent<NPCTitleEffectData>();
		mMatTypeDic = new Dictionary<NPC_ICON_TYPE, Material>();
		mNpcNameMaterial = component.mNameMaterial;
		mIconDoneMaterial = component.mIconDoneMaterial;
		mIconProgressMaterial = component.mIconProgressMaterial;
		mIconNewMaterial = component.mIconNewMaterial;
		mIconDummyMaterial = component.mIconDummyMaterial;
		mIconSkillMaterial = component.mIconArrawMaterial;
		mIconDailyQuestNew = component.mDailyNewMaterial;
		mIconDailyQuestDone = component.mDailyDoneMaterial;
		mIconSpecialQuestNew = component.mSpecialNewMaterial;
		mIconSpecialQuestDone = component.mSpecialDoneMaterial;
		mIconCraft = component.mIconCraft;
		mIconDoc = component.mIconDoc;
		mIconGuild = component.mIconGuild;
		mIconMail = component.mIconMail;
		mIconMailNew = component.mIconMailNew;
		mIconShop = component.mIconShop;
		mIconUpgrade = component.mIconUpgrade;
		mMatTypeDic.Add(NPC_ICON_TYPE.NPC_ICON_DONE, mIconDoneMaterial);
		mMatTypeDic.Add(NPC_ICON_TYPE.NPC_ICON_PROGRESS, mIconProgressMaterial);
		mMatTypeDic.Add(NPC_ICON_TYPE.NPC_ICON_NEW, mIconNewMaterial);
		mMatTypeDic.Add(NPC_ICON_TYPE.NPC_ICON_DAILY_NEW, mIconDailyQuestNew);
		mMatTypeDic.Add(NPC_ICON_TYPE.NPC_ICON_DAILY_DONE, mIconDailyQuestDone);
		mMatTypeDic.Add(NPC_ICON_TYPE.NPC_ICON_SPECIAL_NEW, mIconSpecialQuestNew);
		mMatTypeDic.Add(NPC_ICON_TYPE.NPC_ICON_SPECIAL_DONE, mIconSpecialQuestDone);
		mMatTypeDic.Add(NPC_ICON_TYPE.NPC_ICON_CRAFT, mIconCraft);
		mMatTypeDic.Add(NPC_ICON_TYPE.NPC_ICON_DOC, mIconDoc);
		mMatTypeDic.Add(NPC_ICON_TYPE.NPC_ICON_GUILD, mIconGuild);
		mMatTypeDic.Add(NPC_ICON_TYPE.NPC_ICON_MAIL, mIconMail);
		mMatTypeDic.Add(NPC_ICON_TYPE.NPC_ICON_MAIL_NEW, mIconMailNew);
		mMatTypeDic.Add(NPC_ICON_TYPE.NPC_ICON_SHOP, mIconShop);
		mMatTypeDic.Add(NPC_ICON_TYPE.NPC_ICON_UPGRADE, mIconUpgrade);
		mMatTypeDic.Add(NPC_ICON_TYPE.NPC_ICON_DUMMY, mIconDummyMaterial);
		mMatTypeDic.Add(NPC_ICON_TYPE.NPC_ICON_SKILL, mIconSkillMaterial);
		mSizeChanger = gameObject.GetComponent<BillboardSizeChanger>();
		mBillboardAnimator = gameObject.GetComponent<BillboardAnimator>();
		Material[] mNumIconMaterial = component.mNumIconMaterial;
		foreach (Material item in mNumIconMaterial)
		{
			mNumListMaterials.Add(item);
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
			GameObject gameObject2 = Resources.Load("UI_uniSWF/Fonts/UnityFontManager") as GameObject;
			mRefMsyhObj = UnityEngine.Object.Instantiate(gameObject2.transform.FindChild("MSYH").gameObject) as GameObject;
			mRefTextMesh = mRefMsyhObj.GetComponent<TextMesh>();
			mRefTextMesh.color = Color.green;
			MeshRenderer component2 = mRefMsyhObj.GetComponent<MeshRenderer>();
			Texture texture = component2.material.GetTexture("_MainTex");
			mNpcNameMaterial.SetTexture("_MainTex", texture);
			mMeshIcon = cdf3662fae863bc238312331a5f374029(new Vector3(0f, 0f, 0f));
			mMeshNumAboveIcon = cdf3662fae863bc238312331a5f374029(new Vector3(0f, 2f, 0f));
			return;
		}
	}

	private Mesh cdf3662fae863bc238312331a5f374029(Vector3 c52921fe9488ee3d539be727c81094423)
	{
		Mesh mesh = new Mesh();
		float num = 1f;
		float z = 0.01f;
		Vector3[] array = cf3959069936a01183409b8e4d8027897.c0a0cdf4a196914163f7334d9b0781a04(4);
		array[0] = new Vector3(0f - num, 0f - num, z) + c52921fe9488ee3d539be727c81094423;
		array[1] = new Vector3(num, 0f - num, z) + c52921fe9488ee3d539be727c81094423;
		array[2] = new Vector3(num, num, z) + c52921fe9488ee3d539be727c81094423;
		array[3] = new Vector3(0f - num, num, z) + c52921fe9488ee3d539be727c81094423;
		mesh.vertices = array;
		Vector2[] array2 = c2bf31259f27c8d0f78a3b547e04e62ca.c0a0cdf4a196914163f7334d9b0781a04(4);
		array2[0] = new Vector2(1f, 0f);
		array2[1] = new Vector2(0f, 0f);
		array2[2] = new Vector2(0f, 1f);
		array2[3] = new Vector2(1f, 1f);
		mesh.uv = array2;
		int[] array3 = c43dea354950155c55761387ae241b88e.c0a0cdf4a196914163f7334d9b0781a04(6);
		RuntimeHelpers.InitializeArray(array3, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
		mesh.triangles = array3;
		return mesh;
	}

	public void c80df4aae3a83f1614f1eb6e199fc4d52(GameObject c869bd2919e0cc0ae295e2b29d288c00b, NPC_ICON_TYPE cc86191b3374befc421ca3c63c426e269)
	{
		TextMesh componentInChildren = c869bd2919e0cc0ae295e2b29d288c00b.GetComponentInChildren<TextMesh>();
		if (!componentInChildren)
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
			GameObject gameObject = componentInChildren.gameObject.transform.FindChild("Icon").gameObject;
			gameObject.SetActive(true);
			if (!(gameObject != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				MeshRenderer component = gameObject.GetComponent<MeshRenderer>();
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
					component.gameObject.SetActive(true);
					if (cc86191b3374befc421ca3c63c426e269 == NPC_ICON_TYPE.NPC_ICON_NONE)
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								gameObject.SetActive(false);
								return;
							}
						}
					}
					Material value = cbea7b81e65efa29a099764b7785c1976.c7088de59e49f7108f520cf7e0bae167e;
					if (mMatTypeDic.TryGetValue(cc86191b3374befc421ca3c63c426e269, out value))
					{
						while (true)
						{
							switch (6)
							{
							case 0:
								break;
							default:
								component.sharedMaterial = value;
								return;
							}
						}
					}
					component.gameObject.SetActive(false);
					return;
				}
			}
		}
	}

	public void c61079aece8524c509095139b0e9fa145(GameObject c869bd2919e0cc0ae295e2b29d288c00b)
	{
		TextMesh componentInChildren = c869bd2919e0cc0ae295e2b29d288c00b.GetComponentInChildren<TextMesh>();
		if (!(componentInChildren != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			mCurNpcObj = componentInChildren.gameObject;
			GameObject gameObject = componentInChildren.gameObject.transform.FindChild("Icon").gameObject;
			MeshRenderer component = gameObject.GetComponent<MeshRenderer>();
			if (!gameObject.activeSelf)
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
				mPreHideIconType = NPC_ICON_TYPE.NPC_ICON_NONE;
			}
			else
			{
				using (Dictionary<NPC_ICON_TYPE, Material>.Enumerator enumerator = mMatTypeDic.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						KeyValuePair<NPC_ICON_TYPE, Material> current = enumerator.Current;
						if (!(current.Value == component.sharedMaterial))
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
						mPreHideIconType = current.Key;
					}
					while (true)
					{
						switch (5)
						{
						case 0:
							break;
						default:
							goto end_IL_00de;
						}
						continue;
						end_IL_00de:
						break;
					}
				}
			}
			mCurNpcObj.SetActive(false);
			return;
		}
	}

	public void cf838f7acd5eb655ae8a916dd0f765a44()
	{
		if (mCurNpcObj == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		mCurNpcObj.SetActive(true);
		c80df4aae3a83f1614f1eb6e199fc4d52(mCurNpcObj, mPreHideIconType);
	}

	public void cfe1eaf488bc05fe7986123cdec13c2ae(GameObject c869bd2919e0cc0ae295e2b29d288c00b, string ca45083def253bd922119089a04537d00)
	{
		TextMesh componentInChildren = c869bd2919e0cc0ae295e2b29d288c00b.GetComponentInChildren<TextMesh>();
		if (!(componentInChildren != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			componentInChildren.text = ca45083def253bd922119089a04537d00;
			return;
		}
	}

	public void c998544bee641bc3a66b600fbd8bc9fe2(GameObject c869bd2919e0cc0ae295e2b29d288c00b)
	{
		BassBillboard componentInChildren = c869bd2919e0cc0ae295e2b29d288c00b.GetComponentInChildren<BassBillboard>();
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			UnityEngine.Object.Destroy(componentInChildren.gameObject);
			return;
		}
	}

	public void cf5f3d76ee14f5eecbe23e4814d041f23(GameObject c869bd2919e0cc0ae295e2b29d288c00b, int cf0692d1ad1343d71e46cb73da971ddaf)
	{
		if (c869bd2919e0cc0ae295e2b29d288c00b == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (mNumListMaterials == null)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		if (cf0692d1ad1343d71e46cb73da971ddaf < 0)
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
			if (cf0692d1ad1343d71e46cb73da971ddaf > mNumListMaterials.Count)
			{
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
			TextMesh componentInChildren = c869bd2919e0cc0ae295e2b29d288c00b.GetComponentInChildren<TextMesh>();
			if (componentInChildren == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (componentInChildren.gameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			Transform transform = componentInChildren.gameObject.transform.FindChild("NumAboveIcon");
			if (transform == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
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
			GameObject gameObject = transform.gameObject;
			if (gameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
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
			gameObject.SetActive(true);
			MeshRenderer component = gameObject.GetComponent<MeshRenderer>();
			if (component == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (cf0692d1ad1343d71e46cb73da971ddaf == 0)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						gameObject.SetActive(false);
						return;
					}
				}
			}
			GameObject gameObject2 = component.gameObject;
			if (gameObject2 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			gameObject2.SetActive(true);
			component.sharedMaterial = mNumListMaterials[cf0692d1ad1343d71e46cb73da971ddaf - 1];
			return;
		}
	}

	public void cb78df4930894dc7183d21d17dcc5b2f9(GameObject c869bd2919e0cc0ae295e2b29d288c00b, NPC_ICON_TYPE c435a7c0f75095fb5396ec5d67ff80ff1, bool cc2a4a02a728c83b472006c5fc196fded)
	{
		TextMesh componentInChildren = c869bd2919e0cc0ae295e2b29d288c00b.GetComponentInChildren<TextMesh>();
		if (componentInChildren == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		Transform transform = componentInChildren.gameObject.transform.FindChild("Icon");
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
		GameObject gameObject = transform.gameObject;
		MeshRenderer component = gameObject.GetComponent<MeshRenderer>();
		Material value = cbea7b81e65efa29a099764b7785c1976.c7088de59e49f7108f520cf7e0bae167e;
		mMatTypeDic.TryGetValue(c435a7c0f75095fb5396ec5d67ff80ff1, out value);
		if (component.sharedMaterial == value)
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
			if (cc2a4a02a728c83b472006c5fc196fded)
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
				gameObject.GetComponent<BillboardAnimator>().c0a75d7afd2f7f1e47a5aadaab61303c7();
			}
			else
			{
				gameObject.GetComponent<BillboardAnimator>().cdada4c3678c9c23c38aaf0754a94a620();
			}
		}
		if (!(component.sharedMaterial == mIconSkillMaterial))
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
			if (c435a7c0f75095fb5396ec5d67ff80ff1 != NPC_ICON_TYPE.NPC_ICON_SKILL)
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
				GameObject gameObject2 = componentInChildren.gameObject.transform.FindChild("NumAboveIcon").gameObject;
				if (cc2a4a02a728c83b472006c5fc196fded)
				{
					while (true)
					{
						switch (5)
						{
						case 0:
							break;
						default:
							gameObject2.GetComponent<BillboardAnimator>().c0a75d7afd2f7f1e47a5aadaab61303c7();
							return;
						}
					}
				}
				gameObject2.GetComponent<BillboardAnimator>().cdada4c3678c9c23c38aaf0754a94a620();
				return;
			}
		}
	}

	public GameObject c56e7023c9b616eca4ee05b6fe564f13d(GameObject c869bd2919e0cc0ae295e2b29d288c00b, Vector3 cce67dd2bf0eb57c1b98f8009c526da16, string c03c6e083485242ee4483a0522e68735d, NPC_ICON_TYPE c435a7c0f75095fb5396ec5d67ff80ff1)
	{
		GameObject gameObject = new GameObject(c03c6e083485242ee4483a0522e68735d + "_" + c435a7c0f75095fb5396ec5d67ff80ff1);
		MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
		meshRenderer.material = mNpcNameMaterial;
		TextMesh textMesh = gameObject.AddComponent<TextMesh>();
		textMesh.font = c06ca0e618478c23eba3419653a19760f<GUIFontSwapManager>.c5ee19dc8d4cccf5ae2de225410458b86.c247d079cbd276539a42b66ea2e660690("Microsoft YaHei");
		textMesh.fontSize = 24;
		textMesh.text = c03c6e083485242ee4483a0522e68735d;
		textMesh.anchor = TextAnchor.MiddleCenter;
		BassBillboard bassBillboard = gameObject.AddComponent<BassBillboard>();
		bassBillboard.m_isVertical = false;
		gameObject.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
		gameObject.transform.Rotate(new Vector3(0f, 180f, 0f));
		gameObject.transform.parent = c869bd2919e0cc0ae295e2b29d288c00b.transform;
		gameObject.transform.localPosition = cce67dd2bf0eb57c1b98f8009c526da16;
		GameObject gameObject2 = new GameObject("Icon");
		gameObject2.AddComponent<MeshRenderer>();
		gameObject2.AddComponent<MeshFilter>();
		gameObject2.GetComponent<MeshFilter>().mesh = mMeshIcon;
		gameObject2.AddComponent<BillboardSizeChanger>();
		gameObject2.GetComponent<BillboardSizeChanger>().mFarthestDistance = mSizeChanger.mFarthestDistance;
		gameObject2.AddComponent<BillboardAnimator>();
		gameObject2.GetComponent<BillboardAnimator>().SpeedDirection = mBillboardAnimator.SpeedDirection;
		gameObject2.GetComponent<BillboardAnimator>().Amplitude = mBillboardAnimator.Amplitude;
		gameObject2.GetComponent<BillboardAnimator>().Velocity = mBillboardAnimator.Velocity;
		gameObject2.GetComponent<BillboardAnimator>().TotalTime = mBillboardAnimator.TotalTime;
		if (c435a7c0f75095fb5396ec5d67ff80ff1 == NPC_ICON_TYPE.NPC_ICON_NONE)
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
			gameObject2.SetActive(false);
		}
		else
		{
			Material value = cbea7b81e65efa29a099764b7785c1976.c7088de59e49f7108f520cf7e0bae167e;
			if (mMatTypeDic.TryGetValue(c435a7c0f75095fb5396ec5d67ff80ff1, out value))
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
				gameObject2.GetComponent<MeshRenderer>().sharedMaterial = value;
			}
			else
			{
				DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Graphics, "Miss icon type! : " + c435a7c0f75095fb5396ec5d67ff80ff1);
			}
		}
		gameObject2.transform.parent = gameObject.transform;
		gameObject2.transform.localPosition = cce67dd2bf0eb57c1b98f8009c526da16 + new Vector3(0f, 6f, 0f);
		float num = 4f;
		gameObject2.transform.localScale = new Vector3(num, num, 1f);
		if (c435a7c0f75095fb5396ec5d67ff80ff1 == NPC_ICON_TYPE.NPC_ICON_SKILL)
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
			GameObject gameObject3 = new GameObject("NumAboveIcon");
			gameObject3.AddComponent<MeshRenderer>();
			gameObject3.AddComponent<MeshFilter>();
			gameObject3.GetComponent<MeshFilter>().mesh = mMeshNumAboveIcon;
			gameObject3.AddComponent<BillboardSizeChanger>();
			gameObject3.GetComponent<BillboardSizeChanger>().mFarthestDistance = mSizeChanger.mFarthestDistance;
			gameObject3.AddComponent<BillboardAnimator>();
			gameObject3.GetComponent<BillboardAnimator>().SpeedDirection = mBillboardAnimator.SpeedDirection;
			gameObject3.GetComponent<BillboardAnimator>().Amplitude = mBillboardAnimator.Amplitude;
			gameObject3.GetComponent<BillboardAnimator>().Velocity = mBillboardAnimator.Velocity;
			gameObject3.GetComponent<BillboardAnimator>().TotalTime = mBillboardAnimator.TotalTime;
			gameObject3.transform.parent = gameObject.transform;
			gameObject3.transform.localPosition = cce67dd2bf0eb57c1b98f8009c526da16 + new Vector3(0f, 6f, 0f);
			gameObject3.transform.localScale = new Vector3(num, num, 1f);
			if (mNumListMaterials.Count >= 1)
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
				gameObject3.GetComponent<MeshRenderer>().sharedMaterial = mNumListMaterials[0];
			}
		}
		return gameObject;
	}

	public void c1df48099cdcf8d823e68395243c06932(GameObject c072d62d4edaec97afba470332ae2bbe8)
	{
		BassBillboard componentInChildren = c072d62d4edaec97afba470332ae2bbe8.GetComponentInChildren<BassBillboard>();
		if (!(componentInChildren != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			componentInChildren.gameObject.SetActive(false);
			return;
		}
	}

	public void ca6ac12c7e3baf8b991ea8855be177e29(GameObject c072d62d4edaec97afba470332ae2bbe8)
	{
		BassBillboard[] componentsInChildren = c072d62d4edaec97afba470332ae2bbe8.GetComponentsInChildren<BassBillboard>(true);
		if (componentsInChildren.Length <= 0)
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
			BassBillboard bassBillboard = componentsInChildren[0];
			bassBillboard.gameObject.SetActive(true);
			return;
		}
	}
}
