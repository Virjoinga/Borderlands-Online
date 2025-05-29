using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/DeathEffect")]
public class ReviveEffect : ImageEffectBase
{
	public float mLerpVal;

	protected override void Start()
	{
		if (!SystemInfo.supportsRenderTextures)
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
					base.enabled = false;
					return;
				}
			}
		}
		base.Start();
	}

	protected override void OnDisable()
	{
		base.OnDisable();
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.cf4af10ce9fa4ab84bd021b054d46a667.SetFloat("_LerpVal", mLerpVal);
		Graphics.Blit(source, destination, base.cf4af10ce9fa4ab84bd021b054d46a667, 0);
	}
}
