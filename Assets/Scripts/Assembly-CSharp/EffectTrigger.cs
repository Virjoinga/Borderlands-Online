using A;
using UnityEngine;

[AddComponentMenu("Effects/TKC/Effect Trigger")]
public class EffectTrigger : MonoBehaviour
{
	public string m_name = "EffectTrigger";

	public EffectTriggerType m_triggerType;

	public KeyCode m_keyCode;

	public EffectLocationType m_location;

	public EffectTriggerItem[] m_effectItemList;

	public GameObject m_gameObject;

	public RaycastHit m_raycastHit;

	public float m_raycastDistance;

	public EffectRayCastDirectionType m_raycastDirection;

	public Vector3 m_specifiedRaycastDirection = new Vector3(0f, -1f, 0f);

	[HideInInspector]
	public Vector3 m_specifiedRaycastOrigin = new Vector3(0f, 0f, 0f);

	private void Start()
	{
		if ((m_triggerType & EffectTriggerType.Start) == 0)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			c02ddda22c40e6537539ea11ecdcc6dba();
			return;
		}
	}

	private void Update()
	{
		if ((m_triggerType & EffectTriggerType.Update) != 0)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					c02ddda22c40e6537539ea11ecdcc6dba();
					return;
				}
			}
		}
		if ((m_triggerType & EffectTriggerType.KeyDown) == 0)
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
			if (!Input.GetKeyDown(m_keyCode))
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
				c02ddda22c40e6537539ea11ecdcc6dba();
				return;
			}
		}
	}

	private void OnCollisionEnter()
	{
		if ((m_triggerType & EffectTriggerType.CollisionEnter) == 0)
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
			c02ddda22c40e6537539ea11ecdcc6dba();
			return;
		}
	}

	private void OnCollisionExit()
	{
		if ((m_triggerType & EffectTriggerType.CollisionExit) == 0)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			c02ddda22c40e6537539ea11ecdcc6dba();
			return;
		}
	}

	private void OnDestroy()
	{
		if ((m_triggerType & EffectTriggerType.Destroy) == 0)
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
			c02ddda22c40e6537539ea11ecdcc6dba();
			return;
		}
	}

	private void OnDisable()
	{
		if ((m_triggerType & EffectTriggerType.Disable) == 0)
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
			c02ddda22c40e6537539ea11ecdcc6dba();
			return;
		}
	}

	private void OnEnable()
	{
		if ((m_triggerType & EffectTriggerType.Enable) == 0)
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
			c02ddda22c40e6537539ea11ecdcc6dba();
			return;
		}
	}

	private void OnMouseDown()
	{
		if ((m_triggerType & EffectTriggerType.MouseDown) == 0)
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
			c02ddda22c40e6537539ea11ecdcc6dba();
			return;
		}
	}

	private void OnMouseUp()
	{
		if ((m_triggerType & EffectTriggerType.MouseUp) == 0)
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
			c02ddda22c40e6537539ea11ecdcc6dba();
			return;
		}
	}

	private void OnTriggerEnter()
	{
		if ((m_triggerType & EffectTriggerType.TriggerEnter) == 0)
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
			c02ddda22c40e6537539ea11ecdcc6dba();
			return;
		}
	}

	private void OnTriggerExit()
	{
		if ((m_triggerType & EffectTriggerType.TriggerExit) == 0)
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
			c02ddda22c40e6537539ea11ecdcc6dba();
			return;
		}
	}

	public void c02ddda22c40e6537539ea11ecdcc6dba()
	{
		if (NetworkManager.c449802e708e91a9150466060fbab2ad6())
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
			if (!c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_offlineMode)
			{
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
		}
		if (m_effectItemList == null)
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
			if (m_effectItemList.Length <= 0)
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
				if (!c4a992b1dbf4fa82b66a024bea81aa9d7())
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
					for (int i = 0; i < m_effectItemList.Length; i++)
					{
						m_effectItemList[i].c02ddda22c40e6537539ea11ecdcc6dba(this);
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
			}
		}
	}

	public void TriggerEffectByName(string name)
	{
		if (!(name == m_name))
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
			c02ddda22c40e6537539ea11ecdcc6dba();
			return;
		}
	}

	private bool c4a992b1dbf4fa82b66a024bea81aa9d7()
	{
		bool result = true;
		if (m_gameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_gameObject = base.gameObject;
		}
		if (m_location == EffectLocationType.GameObject)
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
			result = true;
		}
		else if (m_location == EffectLocationType.Raycast)
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
			Vector3 direction = new Vector3(0f, -1f, 0f);
			Vector3 vector = new Vector3(0f, 0f, 0f);
			Transform transform = m_gameObject.transform;
			vector = transform.position;
			if (m_raycastDirection == EffectRayCastDirectionType.Forward)
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
				direction = transform.forward;
			}
			else if (m_raycastDirection == EffectRayCastDirectionType.Backward)
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
				direction = -transform.forward;
			}
			else if (m_raycastDirection == EffectRayCastDirectionType.Up)
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
				direction = transform.up;
			}
			else if (m_raycastDirection == EffectRayCastDirectionType.Down)
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
				direction = -transform.up;
			}
			else if (m_raycastDirection == EffectRayCastDirectionType.Left)
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
				direction = -transform.right;
			}
			else if (m_raycastDirection == EffectRayCastDirectionType.Right)
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
				direction = transform.right;
			}
			else if (m_raycastDirection == EffectRayCastDirectionType.Specified)
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
				direction = m_specifiedRaycastDirection;
				vector = m_specifiedRaycastOrigin;
			}
			if (m_raycastDistance <= 0f)
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
				result = Physics.Raycast(vector, direction, out m_raycastHit);
			}
			else
			{
				result = Physics.Raycast(vector, direction, out m_raycastHit, m_raycastDistance);
			}
		}
		return result;
	}
}
