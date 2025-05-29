using A;
using UnityEngine;

public class ParticleSizeKeeper : MonoBehaviour
{
	public float KeepDistance = 10f;

	private float mOriginalSize = 1f;

	private Vector3 mOriginalScale = Vector3.one;

	private void Start()
	{
		if (base.gameObject.particleSystem != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			mOriginalSize = base.gameObject.particleSystem.startSize;
		}
		if (!(base.gameObject.GetComponent<MeshRenderer>() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			mOriginalScale = base.gameObject.transform.localScale;
			return;
		}
	}

	private void Update()
	{
		if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56())
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
			if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().c66b232dbebded7c7e9a89c1e8bd84689())
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
			EntityPlayer entityPlayer = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().c66b232dbebded7c7e9a89c1e8bd84689() as EntityPlayer;
			if (!(entityPlayer != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				BadAssFPSCamera badAssFPSCamera = entityPlayer.cc6a7269e9ea93e537de47dc752b09a86();
				if (!badAssFPSCamera)
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
					if (!badAssFPSCamera.camera)
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
					float num = Vector3.Distance(base.gameObject.transform.position, badAssFPSCamera.camera.gameObject.transform.position);
					if (base.gameObject.particleSystem != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
						if (badAssFPSCamera.c83296771aacb04d01c8b957f0a990ece() != null)
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
							float num2 = badAssFPSCamera.camera.fieldOfView / badAssFPSCamera.c83296771aacb04d01c8b957f0a990ece().m_FOVDefault;
							base.gameObject.particleSystem.startSize = mOriginalSize * num2 * (num / KeepDistance);
						}
					}
					if (!(base.gameObject.GetComponent<MeshRenderer>() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
						base.gameObject.transform.localScale = mOriginalScale * (num / KeepDistance);
						return;
					}
				}
			}
		}
	}
}
