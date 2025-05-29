using A;
using UnityEngine;

public class snapTest : MonoBehaviour
{
	private Material mPlaneMaterial;

	public Vector3 mRotation;

	public Vector3 mTranslate;

	public Vector3 mScale;

	public GameObject mCameraEffect;

	public GameObject mSnapObj;

	private Texture2D mSnapTex;

	private void Start()
	{
		MeshRenderer component = base.gameObject.GetComponent<MeshRenderer>();
		if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			mPlaneMaterial = component.material;
		}
		mRotation = new Vector3(-90f, 90f, 0f);
		c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c848ee3ec1aba9ee52ed305a7c47e42ce().cf710a2904b380cfd99d91500d1838c90(mCameraEffect);
		int width = 1280;
		int height = 720;
		mSnapTex = new Texture2D(width, height, TextureFormat.ARGB32, false);
		mSnapTex.name = "snapTest_mSnapTex";
	}

	private void FixedUpdate()
	{
		if (Input.GetKey("a"))
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
			Matrix4x4 c5b57750cb72c113cb7b45cd = Matrix4x4.identity;
			c5b57750cb72c113cb7b45cd.SetTRS(new Vector3(0f, 0f, 1f), Quaternion.Euler(new Vector3(0f, 90f, 0f)), Vector3.one * 2f);
			SkinnedMeshRenderer componentInChildren = mSnapObj.GetComponentInChildren<SkinnedMeshRenderer>();
			c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c848ee3ec1aba9ee52ed305a7c47e42ce().c25b98c6351c6977ed7c754d7c8a0a836(componentInChildren, ref c5b57750cb72c113cb7b45cd, mSnapTex);
		}
		mPlaneMaterial.SetTexture("_MainTex", mSnapTex);
	}
}
