using System.Collections;
using A;
using Core;
using UnityEngine;

public class SnapEffectMgr
{
	public class SnapItem
	{
		public Texture2D mItemTex;

		public Matrix4x4 mToWorldMat;

		public SkinnedMeshRenderer mSnapMesh;

		public TexPostEffectMgr.POST_EFFECT_TYPE mPostEffectType;

		public SnapItem(Texture2D c853ebd35d95c349adfcf2dcca32ad762, Matrix4x4 c1ef0a19ca24f9f36498772084c44dbe1, SkinnedMeshRenderer c4ea6a3a4fc302daedb765ad1ffc63b34, TexPostEffectMgr.POST_EFFECT_TYPE cb240ccfefb41d0bc0a76e758f31d79ac)
		{
			mItemTex = c853ebd35d95c349adfcf2dcca32ad762;
			mToWorldMat = c1ef0a19ca24f9f36498772084c44dbe1;
			mSnapMesh = c4ea6a3a4fc302daedb765ad1ffc63b34;
			mPostEffectType = cb240ccfefb41d0bc0a76e758f31d79ac;
		}
	}

	private Camera mSnapCamera;

	public int mSnapLayer = 22;

	private RenderTexture mSnapRT;

	private int mSnapWidth = 1280;

	private int mSnapHeight = 720;

	private Mesh mSnapMesh;

	private GameObject mSnapPostEffect;

	private Matrix4x4 mToWorldMat;

	private Queue mSnapQueue;

	private bool mSnapStart;

	private Rect mSnapUv;

	public int mItemTexW;

	public int mItemTexH;

	public RenderTexture mResultRt;

	public void ccc9d3a38966dc10fedb531ea17d24611(GameObject c7fc31157c6e66fba53b537fe287659bd)
	{
		mSnapRT = new RenderTexture(mSnapWidth, mSnapHeight, 24);
		mSnapRT.name = "SnapEffectMgr_mSnapRT";
		mSnapRT.Create();
		mSnapMesh = new Mesh();
		mSnapCamera = c7fc31157c6e66fba53b537fe287659bd.AddComponent<Camera>();
		mSnapCamera.renderingPath = RenderingPath.UsePlayerSettings;
		mSnapCamera.cullingMask = 1 << mSnapLayer;
		mSnapCamera.targetTexture = mSnapRT;
		mSnapCamera.depth = 100f;
		mSnapCamera.clearFlags = CameraClearFlags.Color;
		mSnapCamera.backgroundColor = new Color(0f, 0f, 0f, 0f);
		mSnapCamera.nearClipPlane = 0.01f;
		c7fc31157c6e66fba53b537fe287659bd.AddComponent<SnapImageEffect>();
		c7fc31157c6e66fba53b537fe287659bd.AddComponent<GammaEffect>();
		mSnapQueue = new Queue();
		mSnapStart = false;
		mSnapUv = new Rect(0f, 0f, 1f, 1f);
		mSnapCamera.gameObject.SetActive(false);
	}

	public void Update()
	{
		c159ec81b48b5061891903ea29c54338c();
	}

	public void cf710a2904b380cfd99d91500d1838c90(GameObject ca540f128cc0496888bd14b95ab27aaee)
	{
		if (!(ca540f128cc0496888bd14b95ab27aaee != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			ComponentHelper.c0bd715794203aecb6153c35217fbf4f4(ca540f128cc0496888bd14b95ab27aaee, mSnapCamera.gameObject);
			return;
		}
	}

	public void c25b98c6351c6977ed7c754d7c8a0a836(SkinnedMeshRenderer c4ea6a3a4fc302daedb765ad1ffc63b34, ref Matrix4x4 c5b57750cb72c113cb7b45cd082600408, Texture2D c853ebd35d95c349adfcf2dcca32ad762, TexPostEffectMgr.POST_EFFECT_TYPE cb240ccfefb41d0bc0a76e758f31d79ac = TexPostEffectMgr.POST_EFFECT_TYPE.POST_EFFECT_UI)
	{
		if (c4ea6a3a4fc302daedb765ad1ffc63b34 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Graphics, "Null Snap Mesh!");
					return;
				}
			}
		}
		if (c853ebd35d95c349adfcf2dcca32ad762 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Graphics, "Null Snap Tex!");
					return;
				}
			}
		}
		Matrix4x4 localToWorldMatrix = mSnapCamera.gameObject.transform.localToWorldMatrix;
		SnapItem obj = new SnapItem(c853ebd35d95c349adfcf2dcca32ad762, localToWorldMatrix * c5b57750cb72c113cb7b45cd082600408, c4ea6a3a4fc302daedb765ad1ffc63b34, cb240ccfefb41d0bc0a76e758f31d79ac);
		mSnapQueue.Enqueue(obj);
	}

	public bool c3ed99fc46b89f7ebe24eb0d04e85db84()
	{
		return mSnapStart;
	}

	public void c159ec81b48b5061891903ea29c54338c()
	{
		if (mSnapQueue.Count <= 0)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (mSnapStart)
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
				SnapItem snapItem = mSnapQueue.Peek() as SnapItem;
				if (snapItem == null)
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
				if (snapItem.mItemTex == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				mItemTexW = snapItem.mItemTex.width;
				mItemTexH = snapItem.mItemTex.height;
				mResultRt = RenderTexture.GetTemporary(mItemTexW, mItemTexH);
				mSnapCamera.gameObject.SetActive(true);
				c159ec81b48b5061891903ea29c54338c(snapItem.mSnapMesh, snapItem.mToWorldMat);
				mSnapStart = true;
				return;
			}
		}
	}

	private void c785edbd1f1f2fe1ea68896cb0b7ec280(Texture2D c853ebd35d95c349adfcf2dcca32ad762, string cd1e3dee5c83b42041dac36bf26b36d23)
	{
	}

	public Rect c44190b16a8195463b1b40b90756b1945()
	{
		return mSnapUv;
	}

	private void c6060dc7f1293b0d54cbb4c88d0be16bd(SkinnedMeshRenderer c3dc2a2e845e0c25ac3938da0a7fb6d48, Matrix4x4 cc0f05d90843be7a3df5b2be5c952378f)
	{
		Bounds localBounds = c3dc2a2e845e0c25ac3938da0a7fb6d48.localBounds;
		Vector3[] array = cf3959069936a01183409b8e4d8027897.c0a0cdf4a196914163f7334d9b0781a04(8);
		array[0] = new Vector3(localBounds.min.x, localBounds.min.y, localBounds.min.z);
		array[1] = new Vector3(localBounds.max.x, localBounds.min.y, localBounds.min.z);
		array[2] = new Vector3(localBounds.max.x, localBounds.max.y, localBounds.min.z);
		array[3] = new Vector3(localBounds.min.x, localBounds.max.y, localBounds.min.z);
		array[4] = new Vector3(localBounds.min.x, localBounds.min.y, localBounds.max.z);
		array[5] = new Vector3(localBounds.max.x, localBounds.min.y, localBounds.max.z);
		array[6] = new Vector3(localBounds.max.x, localBounds.max.y, localBounds.max.z);
		array[7] = new Vector3(localBounds.min.x, localBounds.max.y, localBounds.max.z);
		Bounds c36964cf41281414170f34ee68bef6c = default(Bounds);
		cbfa7a001415df4290eaa7aad69f557b0.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
		Matrix4x4 matrix4x = mSnapCamera.projectionMatrix * mSnapCamera.worldToCameraMatrix * cc0f05d90843be7a3df5b2be5c952378f;
		for (int i = 0; i < 8; i++)
		{
			Vector3 vector = matrix4x.MultiplyVector(array[i]);
			vector.x *= 0.5f;
			vector.x += 0.5f;
			vector.y *= 0.5f;
			vector.y += 0.5f;
			if (i == 0)
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
				c36964cf41281414170f34ee68bef6c = new Bounds(vector, Vector3.zero);
			}
			c36964cf41281414170f34ee68bef6c.Encapsulate(vector);
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			Vector3 min = c36964cf41281414170f34ee68bef6c.min;
			Vector3 max = c36964cf41281414170f34ee68bef6c.max;
			mSnapUv = new Rect(min.x, min.y, max.x - min.x, max.y - min.y);
			if (mSnapUv.width + mSnapUv.x > 1f)
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
				mSnapUv.width = 1f - mSnapUv.x;
			}
			if (!(mSnapUv.height + mSnapUv.y > 1f))
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
				mSnapUv.height = 1f - mSnapUv.y;
				return;
			}
		}
	}

	public IEnumerator cf9da4ddea5630a732c3109cc83da3847(RenderTexture c263ec16e61906403155bad836ad25565)
	{
		if (mSnapQueue.Count > 0)
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
			if (mSnapStart)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
					{
						yield return new WaitForEndOfFrame();
						SnapItem curItem = mSnapQueue.Dequeue() as SnapItem;
						RenderTexture currentActiveRT = RenderTexture.active;
						RenderTexture.active = c263ec16e61906403155bad836ad25565;
						curItem.mItemTex.ReadPixels(new Rect(0f, 0f, c263ec16e61906403155bad836ad25565.width, c263ec16e61906403155bad836ad25565.height), 0, 0);
						curItem.mItemTex.Apply();
						RenderTexture.active = currentActiveRT;
						c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c0e679f4989d9772fd4db03bedfd64968().ca489b6557226f61729b498b54e0e3d63(curItem.mItemTex, curItem.mPostEffectType);
						RenderTexture.ReleaseTemporary(mResultRt);
						mSnapStart = false;
						mSnapCamera.gameObject.SetActive(false);
						yield break;
					}
					}
				}
			}
		}
		yield return c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e;
	}

	private void c159ec81b48b5061891903ea29c54338c(SkinnedMeshRenderer c4ea6a3a4fc302daedb765ad1ffc63b34, Matrix4x4 c5b57750cb72c113cb7b45cd082600408)
	{
		if (!(c4ea6a3a4fc302daedb765ad1ffc63b34 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			c4ea6a3a4fc302daedb765ad1ffc63b34.BakeMesh(mSnapMesh);
			c6060dc7f1293b0d54cbb4c88d0be16bd(c4ea6a3a4fc302daedb765ad1ffc63b34, c5b57750cb72c113cb7b45cd082600408);
			Graphics.DrawMesh(mSnapMesh, c5b57750cb72c113cb7b45cd082600408, c4ea6a3a4fc302daedb765ad1ffc63b34.material, mSnapLayer, mSnapCamera);
			return;
		}
	}
}
