using A;
using UnityEngine;

public class PreviewTest : MonoBehaviour
{
	public GameObject mThrCharDisplayPlane;

	public GameObject mWeaponDisplayPlane;

	public GameObject mWeaponMesh;

	public Rect mDisplayUV;

	private Texture2D mWeaponTexture;

	private Rect mChrRect;

	private bool mDisplayTestTex;

	private void Start()
	{
		mWeaponTexture = new Texture2D(1280, 720, TextureFormat.ARGB32, false);
		mWeaponTexture.name = "PreviewTest_mWeaponTexture";
		mChrRect = new Rect(0f, 0f, 250f, 370f);
		mDisplayTestTex = false;
	}

	private void OnGUI()
	{
		if (!mDisplayTestTex)
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
			Graphics.DrawTexture(mChrRect, c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.ce9030196d2dbfbe5a5051960f05df6d0().c9bf29a49cfe42cc19891e9333401d847(), c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.ce9030196d2dbfbe5a5051960f05df6d0().c0c17e73f50a88deade51a968597893c7(), 0, 0, 0, 0);
			return;
		}
	}

	private void FixedUpdate()
	{
		if (Input.GetKeyDown("d"))
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
			mDisplayTestTex = !mDisplayTestTex;
		}
		if (Input.GetKeyDown("u"))
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
			c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.ce9030196d2dbfbe5a5051960f05df6d0().cbef16445507599c30d2c9998fd70600a(mDisplayUV);
		}
		if (Input.GetKeyDown("v"))
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
			if (mWeaponMesh != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				Matrix4x4 c5b57750cb72c113cb7b45cd = Matrix4x4.identity;
				c5b57750cb72c113cb7b45cd.SetTRS(new Vector3(0f, 0f, 1f), Quaternion.Euler(new Vector3(0f, 90f, 0f)), Vector3.one * 2f);
				SkinnedMeshRenderer componentInChildren = mWeaponMesh.GetComponentInChildren<SkinnedMeshRenderer>();
				if (componentInChildren != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c848ee3ec1aba9ee52ed305a7c47e42ce().c25b98c6351c6977ed7c754d7c8a0a836(componentInChildren, ref c5b57750cb72c113cb7b45cd, mWeaponTexture);
				}
			}
		}
		if (mThrCharDisplayPlane != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			MeshRenderer component = mThrCharDisplayPlane.GetComponent<MeshRenderer>();
			if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				Material material = component.material;
				material.SetTexture("_MainTex", c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.ce9030196d2dbfbe5a5051960f05df6d0().c9bf29a49cfe42cc19891e9333401d847());
			}
		}
		if (!(mWeaponDisplayPlane != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			MeshRenderer component2 = mWeaponDisplayPlane.GetComponent<MeshRenderer>();
			if (!(component2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				Material material2 = component2.material;
				material2.SetTexture("_MainTex", mWeaponTexture);
				return;
			}
		}
	}
}
