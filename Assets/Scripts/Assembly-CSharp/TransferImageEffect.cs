using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/TransferEffect")]
public class TransferImageEffect : ImageEffectBase
{
	public int statIndex;

	public void c14a85ecac424c1e74385e117288c6101(float c92b31540d294cca3aef40fe79f317dad)
	{
		if (!base.cf4af10ce9fa4ab84bd021b054d46a667)
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
			base.cf4af10ce9fa4ab84bd021b054d46a667.SetFloat("_BlendPara", c92b31540d294cca3aef40fe79f317dad);
			return;
		}
	}

	protected override void Start()
	{
		if (!SystemInfo.supportsRenderTextures)
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
		Graphics.Blit(source, destination, base.cf4af10ce9fa4ab84bd021b054d46a667, 0);
	}
}
