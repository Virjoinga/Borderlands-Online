using System;
using System.Collections.Generic;
using A;
using UnityEngine;

public class BuildingKitGenerator
{
	private List<CombineInstance> mCombineInstances;

	private List<Transform> mBones;

	private List<Material> mMaterials;

	private Transform[] mTransforms;

	private BuildingKit mKit;

	private BuildingUnit mUnit;

	private uint mSinglemeshHashcode;

	private static string s_displayObjName = "displayObj";

	public void c73b071ad863418024417716b8be899d1(BuildingUnit ce304a6a3f0cc4ab6dc3758509e317211)
	{
		mUnit = ce304a6a3f0cc4ab6dc3758509e317211;
		mKit = BuildingKitManager.cf35675a65469fa29b2d1a69927efca64(ce304a6a3f0cc4ab6dc3758509e317211.bkID);
		new BuildingKitBoneBodyLoader(mKit).c73b071ad863418024417716b8be899d1(true);
		for (int i = 0; i < mKit.caa0fdc2398c34830d3d15f05bcff2020(); i++)
		{
			for (int j = 0; j < mKit.c6ff6428f3ff765ca80c712124c47e83c(i); j++)
			{
				if (mKit.cc985d3ce3968b538b964e683c1676ef0(i, j) == BuildingKit.emptyPart)
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
					continue;
				}
				new BuildingKitFbxLoader(mKit, i, j).c73b071ad863418024417716b8be899d1(true);
				for (int k = 0; k < mKit.c627db55a4773c34acc049b18a3e399a6(i, j); k++)
				{
					new BuildingKitMaterialLoader(mKit, i, j, k).c73b071ad863418024417716b8be899d1(true);
					for (int l = 0; l < mKit.c19986b1d5c10a3b1e3d663ea11d99381(i, j, k); l++)
					{
						new BuildingKitTextureLoader(mKit, i, j, k, l).c73b071ad863418024417716b8be899d1(true);
					}
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							goto end_IL_00c9;
						}
						continue;
						end_IL_00c9:
						break;
					}
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
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					goto end_IL_010b;
				}
				continue;
				end_IL_010b:
				break;
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

	public void c9ac1c3f48a17eeb883683f7058855366(BuildingUnit ce304a6a3f0cc4ab6dc3758509e317211, bool c8b6e31e8301cd4d1eb7e3b6e854baf78)
	{
		mUnit = ce304a6a3f0cc4ab6dc3758509e317211;
		mKit = BuildingKitManager.cf35675a65469fa29b2d1a69927efca64(ce304a6a3f0cc4ab6dc3758509e317211.bkID);
		new BuildingKitBoneBodyLoader(mKit).c588e7dbcd383d8230b2d83d7b44af23b();
		for (int i = 0; i < mKit.caa0fdc2398c34830d3d15f05bcff2020(); i++)
		{
			for (int j = 0; j < mKit.c6ff6428f3ff765ca80c712124c47e83c(i); j++)
			{
				if (mKit.cc985d3ce3968b538b964e683c1676ef0(i, j) == BuildingKit.emptyPart)
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
					continue;
				}
				new BuildingKitFbxLoader(mKit, i, j).c588e7dbcd383d8230b2d83d7b44af23b();
				if (!c8b6e31e8301cd4d1eb7e3b6e854baf78)
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
				for (int k = 0; k < mKit.c627db55a4773c34acc049b18a3e399a6(i, j); k++)
				{
					new BuildingKitMaterialLoader(mKit, i, j, k).c588e7dbcd383d8230b2d83d7b44af23b();
					for (int l = 0; l < mKit.c19986b1d5c10a3b1e3d663ea11d99381(i, j, k); l++)
					{
						new BuildingKitTextureLoader(mKit, i, j, k, l).c588e7dbcd383d8230b2d83d7b44af23b();
					}
					while (true)
					{
						switch (5)
						{
						case 0:
							break;
						default:
							goto end_IL_00e1;
						}
						continue;
						end_IL_00e1:
						break;
					}
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
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					goto end_IL_0123;
				}
				continue;
				end_IL_0123:
				break;
			}
		}
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

	public void cba02ca1a8a050ac54c694317b191cc63(BuildingUnit ce304a6a3f0cc4ab6dc3758509e317211, bool c8b6e31e8301cd4d1eb7e3b6e854baf78)
	{
		mUnit = ce304a6a3f0cc4ab6dc3758509e317211;
		mKit = BuildingKitManager.cf35675a65469fa29b2d1a69927efca64(ce304a6a3f0cc4ab6dc3758509e317211.bkID);
		new BuildingKitBoneBodyLoader(mKit).c588e7dbcd383d8230b2d83d7b44af23b();
		if (BuildingKitManager.OnlineHostMinResMode)
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
			List<List<int>> list = new List<List<int>>();
			List<int> list2 = new List<int>();
			cb506454d41351dd5bcbedbd655432d70(list, list2);
			for (int i = 0; i < list.Count; i++)
			{
				for (int j = 0; j < list[i].Count; j++)
				{
					int num = list[i][j];
					new BuildingKitFbxLoader(mKit, num, mUnit.mFBXs[num]).c588e7dbcd383d8230b2d83d7b44af23b();
					if (!c8b6e31e8301cd4d1eb7e3b6e854baf78)
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
					new BuildingKitMaterialLoader(mKit, num, mUnit.mFBXs[num], mUnit.mMats[num]).c588e7dbcd383d8230b2d83d7b44af23b();
					for (int k = 0; k < mKit.c19986b1d5c10a3b1e3d663ea11d99381(num, mUnit.mFBXs[num], mUnit.mMats[num]); k++)
					{
						new BuildingKitTextureLoader(mKit, num, mUnit.mFBXs[num], mUnit.mMats[num], k).c588e7dbcd383d8230b2d83d7b44af23b();
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
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						goto end_IL_01a1;
					}
					continue;
					end_IL_01a1:
					break;
				}
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				for (int l = 0; l < list2.Count; l++)
				{
					new BuildingKitFbxLoader(mKit, list2[l], mUnit.mFBXs[list2[l]]).c588e7dbcd383d8230b2d83d7b44af23b();
					if (!c8b6e31e8301cd4d1eb7e3b6e854baf78)
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
					new BuildingKitMaterialLoader(mKit, list2[l], mUnit.mFBXs[list2[l]], mUnit.mMats[list2[l]]).c588e7dbcd383d8230b2d83d7b44af23b();
					for (int m = 0; m < mKit.c19986b1d5c10a3b1e3d663ea11d99381(list2[l], mUnit.mFBXs[list2[l]], mUnit.mMats[list2[l]]); m++)
					{
						new BuildingKitTextureLoader(mKit, list2[l], mUnit.mFBXs[list2[l]], mUnit.mMats[list2[l]], m).c588e7dbcd383d8230b2d83d7b44af23b();
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
		}
	}

	public GameObject c3ec92e17a377a835b74cf48e005fe134(BuildingUnit ce304a6a3f0cc4ab6dc3758509e317211)
	{
		mUnit = ce304a6a3f0cc4ab6dc3758509e317211;
		mKit = BuildingKitManager.cf35675a65469fa29b2d1a69927efca64(ce304a6a3f0cc4ab6dc3758509e317211.bkID);
		UnityEngine.Object @object = (UnityEngine.Object)new BuildingKitBoneBodyLoader(mKit).c588e7dbcd383d8230b2d83d7b44af23b();
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(@object, Vector3.zero, Quaternion.identity);
		gameObject.name = @object.name;
		return c0a6259fccb95aae60756b4a48cccb967(gameObject, ce304a6a3f0cc4ab6dc3758509e317211);
	}

	public static SkinnedMeshRenderer cc9bfa7a11dd9e2e916f75a4eb41a63ab(GameObject c869bd2919e0cc0ae295e2b29d288c00b)
	{
		Transform transform = c869bd2919e0cc0ae295e2b29d288c00b.transform.FindChild(s_displayObjName);
		if (transform != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return transform.gameObject.GetComponent<SkinnedMeshRenderer>();
				}
			}
		}
		return null;
	}

	public GameObject c0a6259fccb95aae60756b4a48cccb967(GameObject cdd4716fcbdea6a92cd5fc91c0b7e7a7c, BuildingUnit ce304a6a3f0cc4ab6dc3758509e317211)
	{
		mKit = BuildingKitManager.cf35675a65469fa29b2d1a69927efca64(ce304a6a3f0cc4ab6dc3758509e317211.bkID);
		mUnit = ce304a6a3f0cc4ab6dc3758509e317211;
		mCombineInstances = new List<CombineInstance>();
		mMaterials = new List<Material>();
		mBones = new List<Transform>();
		mTransforms = cdd4716fcbdea6a92cd5fc91c0b7e7a7c.GetComponentsInChildren<Transform>();
		List<List<int>> list = new List<List<int>>();
		List<int> list2 = new List<int>();
		cb506454d41351dd5bcbedbd655432d70(list, list2);
		if (list.Count > 0)
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
			c3a3e5c481990145e19edc7624ea59d97(list);
		}
		for (int i = 0; i < list2.Count; i++)
		{
			UnityEngine.Object @object = (UnityEngine.Object)new BuildingKitFbxLoader(mKit, list2[i], mUnit.mFBXs[list2[i]]).c588e7dbcd383d8230b2d83d7b44af23b();
			Material material = (Material)new BuildingKitMaterialLoader(mKit, list2[i], mUnit.mFBXs[list2[i]], mUnit.mMats[list2[i]]).c588e7dbcd383d8230b2d83d7b44af23b();
			for (int j = 0; j < mKit.c19986b1d5c10a3b1e3d663ea11d99381(list2[i], mUnit.mFBXs[list2[i]], mUnit.mMats[list2[i]]); j++)
			{
				string propertyName = mKit.cdd4910030dccaceb24cee2b201ce1ea8(list2[i], mUnit.mFBXs[list2[i]], mUnit.mMats[list2[i]], j);
				Texture texture = (Texture)new BuildingKitTextureLoader(mKit, list2[i], mUnit.mFBXs[list2[i]], mUnit.mMats[list2[i]], j).c588e7dbcd383d8230b2d83d7b44af23b();
				material.SetTexture(propertyName, texture);
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					goto end_IL_0233;
				}
				continue;
				end_IL_0233:
				break;
			}
			GameObject c18dd00f2b314f2ca5fddf0b9e6f2c = (GameObject)@object;
			c9de58a8a8b97090a2f88f9fc36e54cb3(c18dd00f2b314f2ca5fddf0b9e6f2c, mCombineInstances, mMaterials, mBones, material, false);
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			SkinnedMeshRenderer skinnedMeshRenderer = cc9bfa7a11dd9e2e916f75a4eb41a63ab(cdd4716fcbdea6a92cd5fc91c0b7e7a7c);
			if (skinnedMeshRenderer == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				GameObject gameObject = new GameObject(s_displayObjName);
				skinnedMeshRenderer = gameObject.AddComponent<SkinnedMeshRenderer>();
				gameObject.transform.parent = cdd4716fcbdea6a92cd5fc91c0b7e7a7c.transform;
				gameObject.AddComponent<DisplayObjUpdate>();
			}
			if (list2.Count == 0)
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
				if (list.Count == 1)
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
					skinnedMeshRenderer.sharedMesh = mCombineInstances[0].mesh;
					MergedMeshManager.cef68b3e88f6b33439885b9403199853b(skinnedMeshRenderer.gameObject, mSinglemeshHashcode, true);
					goto IL_044d;
				}
			}
			string text = mKit.cbb732e063b58a30b5dc6ec326627d01e() + mKit.c47e99b30b26b61d5866d7266a2e73bc8() + "FBX";
			for (int k = 0; k < ce304a6a3f0cc4ab6dc3758509e317211.mFBXs.Count; k++)
			{
				text += ce304a6a3f0cc4ab6dc3758509e317211.mFBXs[k] + ce304a6a3f0cc4ab6dc3758509e317211.mMats[k];
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
			object cebae66039aadeac8deb1211786332a = c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e;
			uint num = Utility.cf642a65627df2adf4e90330457651907(text);
			if (!BuildingKitLoader.c7eaa89766a0eddbc8b8e99acaf413fb6(num, out cebae66039aadeac8deb1211786332a))
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
				skinnedMeshRenderer.sharedMesh = new Mesh();
				skinnedMeshRenderer.sharedMesh.name = "Buildingkit_CombinedMesh" + num;
				skinnedMeshRenderer.sharedMesh.CombineMeshes(mCombineInstances.ToArray(), false, false);
			}
			else
			{
				skinnedMeshRenderer.sharedMesh = (Mesh)cebae66039aadeac8deb1211786332a;
			}
			MergedMeshManager.cef68b3e88f6b33439885b9403199853b(skinnedMeshRenderer.gameObject, num, true);
			goto IL_044d;
			IL_044d:
			skinnedMeshRenderer.bones = mBones.ToArray();
			skinnedMeshRenderer.materials = mMaterials.ToArray();
			skinnedMeshRenderer.useLightProbes = true;
			mCombineInstances = c6639be0af320939a2179c13ab16dd467.c7088de59e49f7108f520cf7e0bae167e;
			mMaterials = ce3eb729698dd08fe58b813a08449138b.c7088de59e49f7108f520cf7e0bae167e;
			mBones = c8b0b6eb91bae1d9c8adf0a06ec09f234.c7088de59e49f7108f520cf7e0bae167e;
			mTransforms = c506ad9050a2829852e547e2ff3fbec1f.c7088de59e49f7108f520cf7e0bae167e;
			mKit = cdb738ec8c8a01cc9bc318b9044b3bd1f.c7088de59e49f7108f520cf7e0bae167e;
			mUnit = c59ec4a225e09af7c7fae1b31a63ed330.c7088de59e49f7108f520cf7e0bae167e;
			return cdd4716fcbdea6a92cd5fc91c0b7e7a7c;
		}
	}

	private void cb506454d41351dd5bcbedbd655432d70(List<List<int>> c0111bff7f6bcc01785def9a58f3bfc1a, List<int> cbe073c6d908e94906b96f471e3bd75e8)
	{
		List<int> list = new List<int>();
		for (int i = 0; i < mKit.caa0fdc2398c34830d3d15f05bcff2020(); i++)
		{
			if (mKit.cc985d3ce3968b538b964e683c1676ef0(i, mUnit.mFBXs[i]) == BuildingKit.emptyPart)
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
			}
			else
			{
				if (list.Contains(i))
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
				bool flag = false;
				List<int> list2 = new List<int>();
				for (int j = i + 1; j < mKit.caa0fdc2398c34830d3d15f05bcff2020(); j++)
				{
					if (mKit.cc985d3ce3968b538b964e683c1676ef0(j, mUnit.mFBXs[j]) == BuildingKit.emptyPart)
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
						if (list.Contains(j))
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
						if (!c9e0efb8ce9dca1724a5e81eaa2363d4d(i, j))
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
						flag = true;
						list2.Add(j);
						list.Add(j);
					}
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
				if (flag)
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
					list2.Add(i);
					list.Add(i);
					c0111bff7f6bcc01785def9a58f3bfc1a.Add(list2);
				}
				else
				{
					cbe073c6d908e94906b96f471e3bd75e8.Add(i);
				}
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

	private bool c9e0efb8ce9dca1724a5e81eaa2363d4d(int c3a238049f2290b31bcc25f576c4b9eaa, int c5fd6a4045c396f6378b9e87b4f05da5f)
	{
		byte c21465c80ff0e7018b4dc31504d3756be = mUnit.mFBXs[c3a238049f2290b31bcc25f576c4b9eaa];
		byte c21465c80ff0e7018b4dc31504d3756be2 = mUnit.mFBXs[c5fd6a4045c396f6378b9e87b4f05da5f];
		byte c1ba84ba0939b132fbff850ff287f = mUnit.mMats[c3a238049f2290b31bcc25f576c4b9eaa];
		byte c1ba84ba0939b132fbff850ff287f2 = mUnit.mMats[c5fd6a4045c396f6378b9e87b4f05da5f];
		bool result = false;
		if (mKit.c87398697eafbdb76016c70cdc182e3ab(c3a238049f2290b31bcc25f576c4b9eaa, c21465c80ff0e7018b4dc31504d3756be, c1ba84ba0939b132fbff850ff287f) == mKit.c87398697eafbdb76016c70cdc182e3ab(c5fd6a4045c396f6378b9e87b4f05da5f, c21465c80ff0e7018b4dc31504d3756be2, c1ba84ba0939b132fbff850ff287f2))
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
					return true;
				}
			}
		}
		bool flag = mKit.c2a30bd8e2a872b7c49ecb5686a6719ce(c3a238049f2290b31bcc25f576c4b9eaa, c21465c80ff0e7018b4dc31504d3756be, c1ba84ba0939b132fbff850ff287f) == mKit.c2a30bd8e2a872b7c49ecb5686a6719ce(c5fd6a4045c396f6378b9e87b4f05da5f, c21465c80ff0e7018b4dc31504d3756be2, c1ba84ba0939b132fbff850ff287f2);
		bool flag2 = mKit.c19986b1d5c10a3b1e3d663ea11d99381(c3a238049f2290b31bcc25f576c4b9eaa, c21465c80ff0e7018b4dc31504d3756be, c1ba84ba0939b132fbff850ff287f) == mKit.c19986b1d5c10a3b1e3d663ea11d99381(c5fd6a4045c396f6378b9e87b4f05da5f, c21465c80ff0e7018b4dc31504d3756be2, c1ba84ba0939b132fbff850ff287f2);
		if (flag2)
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
			int num = 0;
			while (true)
			{
				if (num < mKit.c19986b1d5c10a3b1e3d663ea11d99381(c3a238049f2290b31bcc25f576c4b9eaa, c21465c80ff0e7018b4dc31504d3756be, c1ba84ba0939b132fbff850ff287f))
				{
					if (mKit.cde9f5a234249ce753831178fa2cc0648(c3a238049f2290b31bcc25f576c4b9eaa, c21465c80ff0e7018b4dc31504d3756be, c1ba84ba0939b132fbff850ff287f, num) != mKit.cde9f5a234249ce753831178fa2cc0648(c5fd6a4045c396f6378b9e87b4f05da5f, c21465c80ff0e7018b4dc31504d3756be2, c1ba84ba0939b132fbff850ff287f2, num))
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
						flag2 = false;
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
		if (flag)
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
			if (flag2)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
					{
						for (int i = 0; i < mKit.c19986b1d5c10a3b1e3d663ea11d99381(c3a238049f2290b31bcc25f576c4b9eaa, c21465c80ff0e7018b4dc31504d3756be, c1ba84ba0939b132fbff850ff287f); i++)
						{
							if (mKit.cdd4910030dccaceb24cee2b201ce1ea8(c3a238049f2290b31bcc25f576c4b9eaa, c21465c80ff0e7018b4dc31504d3756be, c1ba84ba0939b132fbff850ff287f, i) != mKit.cdd4910030dccaceb24cee2b201ce1ea8(c5fd6a4045c396f6378b9e87b4f05da5f, c21465c80ff0e7018b4dc31504d3756be2, c1ba84ba0939b132fbff850ff287f2, i))
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
						}
						while (true)
						{
							switch (3)
							{
							case 0:
								break;
							default:
							{
								List<ShaderProperty> list = mKit.c84559f6c218ebf5091e0a7143018af1f(c3a238049f2290b31bcc25f576c4b9eaa, c21465c80ff0e7018b4dc31504d3756be, c1ba84ba0939b132fbff850ff287f);
								List<ShaderProperty> list2 = mKit.c84559f6c218ebf5091e0a7143018af1f(c5fd6a4045c396f6378b9e87b4f05da5f, c21465c80ff0e7018b4dc31504d3756be2, c1ba84ba0939b132fbff850ff287f2);
								if (list != null)
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
									if (list2 != null)
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
										if (list.Count == list2.Count)
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
											for (int j = 0; j < list.Count; j++)
											{
												ShaderProperty shaderProperty = list[j];
												ShaderProperty shaderProperty2 = list2[j];
												if (shaderProperty.mType == shaderProperty2.mType)
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
													if (shaderProperty.mName == shaderProperty2.mName)
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
														if (shaderProperty.mValue != shaderProperty2.mValue)
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
										}
									}
								}
								return true;
							}
							}
						}
					}
					}
				}
			}
		}
		return result;
	}

	private void c9de58a8a8b97090a2f88f9fc36e54cb3(GameObject c18dd00f2b314f2ca5fddf0b9e6f2c714, List<CombineInstance> c39418561a4767fc16459195d4bba96a3, List<Material> c90e9d2d3391813a63a01f3e10bba6cb7, List<Transform> c47def65b102e0d279855c9f654f68bab, Material cd40bea8a369ef0c587b626afa8cbbacd, bool c7049feb4a952a265d9a00e0e1c15a3b6)
	{
		SkinnedMeshRenderer[] componentsInChildren = c18dd00f2b314f2ca5fddf0b9e6f2c714.GetComponentsInChildren<SkinnedMeshRenderer>(true);
		int num = 0;
		CombineInstance c36964cf41281414170f34ee68bef6c = default(CombineInstance);
		while (num < componentsInChildren.Length)
		{
			SkinnedMeshRenderer skinnedMeshRenderer = componentsInChildren[num];
			if (cd40bea8a369ef0c587b626afa8cbbacd != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (cd40bea8a369ef0c587b626afa8cbbacd.GetType() == Type.GetTypeFromHandle(cbb7eb9da7b34ed2d998f9a826f2af269.cc1720d05c75832f704b87474932341c3()))
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
					skinnedMeshRenderer.material = cd40bea8a369ef0c587b626afa8cbbacd;
					c90e9d2d3391813a63a01f3e10bba6cb7.AddRange(skinnedMeshRenderer.materials);
				}
			}
			for (int i = 0; i < skinnedMeshRenderer.sharedMesh.subMeshCount; i++)
			{
				cf938dbeda9b63740fd3acb3c87b2cdda.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
				if (c7049feb4a952a265d9a00e0e1c15a3b6)
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
					c36964cf41281414170f34ee68bef6c.mesh = (Mesh)UnityEngine.Object.Instantiate(skinnedMeshRenderer.sharedMesh);
				}
				else
				{
					c36964cf41281414170f34ee68bef6c.mesh = skinnedMeshRenderer.sharedMesh;
				}
				c36964cf41281414170f34ee68bef6c.subMeshIndex = i;
				c39418561a4767fc16459195d4bba96a3.Add(c36964cf41281414170f34ee68bef6c);
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				Transform[] bones = skinnedMeshRenderer.bones;
				foreach (Transform transform in bones)
				{
					Transform[] array = mTransforms;
					int num2 = 0;
					while (true)
					{
						if (num2 < array.Length)
						{
							Transform transform2 = array[num2];
							if (transform2.name != transform.name)
							{
								while (true)
								{
									switch (7)
									{
									case 0:
										break;
									default:
										goto end_IL_012b;
									}
									continue;
									end_IL_012b:
									break;
								}
								num2++;
								continue;
							}
							c47def65b102e0d279855c9f654f68bab.Add(transform2);
							break;
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
						break;
					}
				}
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						goto end_IL_0168;
					}
					continue;
					end_IL_0168:
					break;
				}
				num++;
				break;
			}
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

	private void c3a3e5c481990145e19edc7624ea59d97(List<List<int>> c0111bff7f6bcc01785def9a58f3bfc1a)
	{
		List<CombineInstance> list = new List<CombineInstance>();
		List<Material> list2 = new List<Material>();
		List<Transform> list3 = new List<Transform>();
		int num = 0;
		CombineInstance c36964cf41281414170f34ee68bef6c = default(CombineInstance);
		while (num < c0111bff7f6bcc01785def9a58f3bfc1a.Count)
		{
			list.Clear();
			list2.Clear();
			list3.Clear();
			int num2 = 0;
			while (num2 < c0111bff7f6bcc01785def9a58f3bfc1a[num].Count)
			{
				int num3 = c0111bff7f6bcc01785def9a58f3bfc1a[num][num2];
				UnityEngine.Object @object = (UnityEngine.Object)new BuildingKitFbxLoader(mKit, num3, mUnit.mFBXs[num3]).c588e7dbcd383d8230b2d83d7b44af23b();
				Material material = (Material)new BuildingKitMaterialLoader(mKit, num3, mUnit.mFBXs[num3], mUnit.mMats[num3]).c588e7dbcd383d8230b2d83d7b44af23b();
				for (int i = 0; i < mKit.c19986b1d5c10a3b1e3d663ea11d99381(num3, mUnit.mFBXs[num3], mUnit.mMats[num3]); i++)
				{
					string propertyName = mKit.cdd4910030dccaceb24cee2b201ce1ea8(num3, mUnit.mFBXs[num3], mUnit.mMats[num3], i);
					Texture texture = (Texture)new BuildingKitTextureLoader(mKit, num3, mUnit.mFBXs[num3], mUnit.mMats[num3], i).c588e7dbcd383d8230b2d83d7b44af23b();
					material.SetTexture(propertyName, texture);
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
					GameObject c18dd00f2b314f2ca5fddf0b9e6f2c = (GameObject)@object;
					c9de58a8a8b97090a2f88f9fc36e54cb3(c18dd00f2b314f2ca5fddf0b9e6f2c, list, list2, list3, material, false);
					num2++;
					break;
				}
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				Material item = list2[0];
				cf938dbeda9b63740fd3acb3c87b2cdda.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
				string text = mKit.cbb732e063b58a30b5dc6ec326627d01e() + mKit.c47e99b30b26b61d5866d7266a2e73bc8() + "SubFBX";
				for (int j = 0; j < c0111bff7f6bcc01785def9a58f3bfc1a[num].Count; j++)
				{
					text = text + c0111bff7f6bcc01785def9a58f3bfc1a[num][j] + mUnit.mFBXs[c0111bff7f6bcc01785def9a58f3bfc1a[num][j]];
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					uint cc584cc0d388b61d19d26e1dcdd9be = Utility.cf642a65627df2adf4e90330457651907(text);
					object cebae66039aadeac8deb1211786332a = c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e;
					if (!BuildingKitLoader.c7eaa89766a0eddbc8b8e99acaf413fb6(cc584cc0d388b61d19d26e1dcdd9be, out cebae66039aadeac8deb1211786332a))
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
						Mesh mesh = new Mesh();
						mesh.name = "Buildingkit_CombinedSubMesh_" + text;
						mesh.CombineMeshes(list.ToArray(), true, false);
						c36964cf41281414170f34ee68bef6c.mesh = mesh;
						mSinglemeshHashcode = cc584cc0d388b61d19d26e1dcdd9be;
					}
					else
					{
						c36964cf41281414170f34ee68bef6c.mesh = (Mesh)cebae66039aadeac8deb1211786332a;
						mSinglemeshHashcode = cc584cc0d388b61d19d26e1dcdd9be;
					}
					c36964cf41281414170f34ee68bef6c.subMeshIndex = 0;
					mCombineInstances.Add(c36964cf41281414170f34ee68bef6c);
					mBones.AddRange(list3);
					mMaterials.Add(item);
					num++;
					break;
				}
				break;
			}
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
}
