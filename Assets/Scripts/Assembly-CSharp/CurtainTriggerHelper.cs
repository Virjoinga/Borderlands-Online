using A;
using UnityEngine;

public class CurtainTriggerHelper : MonoBehaviour
{
	public CurtainMecanimManager m_curtainManager;

	private void Start()
	{
		if (!(base.gameObject.collider != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			base.gameObject.collider.isTrigger = true;
			Rigidbody rigidbody = base.gameObject.AddComponent<Rigidbody>();
			rigidbody.useGravity = false;
			rigidbody.isKinematic = true;
			return;
		}
	}

	private void OnTriggerEnter(Collider intruder)
	{
		string text = intruder.gameObject.ToString();
		if (!text.ToLower().Contains("boundingbox"))
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
			if (!(m_curtainManager != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				m_curtainManager.OnTriggerEnter(intruder);
				return;
			}
		}
	}
}
