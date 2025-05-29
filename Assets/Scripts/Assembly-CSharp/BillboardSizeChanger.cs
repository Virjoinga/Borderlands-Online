using A;
using UnityEngine;

public class BillboardSizeChanger : MonoBehaviour
{
	public float mFarthestDistance = 10f;

	private Vector3 mOriginalScale = new Vector3(1f, 1f, 1f);

	private void Start()
	{
		mOriginalScale = base.gameObject.transform.localScale;
	}

	private void Update()
	{
		if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56())
		{
			return;
		}
		while (true)
		{
			switch (3)
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
					switch (3)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			BadAssFPSCamera badAssFPSCamera = (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().c66b232dbebded7c7e9a89c1e8bd84689() as EntityPlayer).cc6a7269e9ea93e537de47dc752b09a86();
			if (!badAssFPSCamera)
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
				if (!badAssFPSCamera.camera)
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
				float num = Vector3.Distance(base.gameObject.transform.position, badAssFPSCamera.camera.gameObject.transform.position);
				if (num > mFarthestDistance)
				{
					while (true)
					{
						switch (2)
						{
						case 0:
							break;
						default:
						{
							float num2 = num / mFarthestDistance - 1f;
							base.gameObject.transform.localScale = new Vector3(num2, num2, 0f) + mOriginalScale;
							return;
						}
						}
					}
				}
				base.gameObject.transform.localScale = mOriginalScale;
				return;
			}
		}
	}
}
