using System;
using UnityEngine;

public class MiniMapConfig : MonoBehaviour
{
	[Serializable]
	public class MinimapTexture
	{
		public Texture2D texture;
	}

	public Vector3 RectOriginPoint = new Vector3(0f, 0f, 0f);

	public Vector3 RectEndPoint = new Vector3(0f, 0f, 0f);

	public float Scale = 0.45f;

	public MinimapTexture[] MiniMapTexture;

	public Vector3 NormalInWorldView = new Vector3(0f, 0f, 1f);

	private void OnDestroy()
	{
		for (int i = 0; i < MiniMapTexture.Length; i++)
		{
			Resources.UnloadAsset(MiniMapTexture[i].texture);
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
			return;
		}
	}

	private void Start()
	{
	}

	private void Update()
	{
	}
}
