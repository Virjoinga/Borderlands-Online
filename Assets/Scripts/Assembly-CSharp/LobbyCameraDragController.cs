using A;
using UnityEngine;

public class LobbyCameraDragController : MonoBehaviour
{
	private GameObject m_Camera;

	private GameObject m_BoundaryRect;

	private GameObject m_TimePassing;

	private Vector2 m_v2BoundryRangeX = new Vector2(0f, 0f);

	private Vector2 m_v2BoundryRangeZ = new Vector2(0f, 0f);

	private float m_fBoundryY;

	private Vector2 m_v2MouseStartPos = new Vector2(0f, 0f);

	private bool m_bDragable;

	public float m_fDragSpeed = 2f;

	private float m_fScale = 1000f;

	private void Start()
	{
		m_Camera = GameObject.Find("LobbyCamera");
		m_BoundaryRect = GameObject.Find("PRO_Looby_Camera_Plane");
		m_TimePassing = GameObject.Find("PRO_Looby_Timepassing");
		if (m_Camera != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			Animation component = m_Camera.GetComponent<Animation>();
			component.playAutomatically = true;
			component.Play();
		}
		if (m_TimePassing != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			Animation component2 = m_TimePassing.GetComponent<Animation>();
			component2.Stop();
			component2["ANI_Looby_Timepassing"].time = 0f;
			component2.Play();
		}
		float num = m_BoundaryRect.renderer.bounds.size.x / 2f;
		float num2 = m_BoundaryRect.renderer.bounds.size.z / 2f;
		m_v2BoundryRangeX.x = m_BoundaryRect.transform.position.x - num;
		m_v2BoundryRangeX.y = m_BoundaryRect.transform.position.x + num;
		m_v2BoundryRangeZ.x = m_BoundaryRect.transform.position.z - num2;
		m_v2BoundryRangeZ.y = m_BoundaryRect.transform.position.z + num2;
		m_fBoundryY = m_BoundaryRect.transform.position.y;
	}

	private void Update()
	{
		if (c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.ca561485909b8620867b83991201b70d3(0, true))
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
			if (!m_bDragable)
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
				m_bDragable = true;
				m_v2MouseStartPos = Input.mousePosition;
			}
		}
		if (c06ca0e618478c23eba3419653a19760f<InputManager>.c5ee19dc8d4cccf5ae2de225410458b86.c5adfffc6150c77758b5ca44b059aee74(0))
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
			m_bDragable = false;
		}
		if (!m_bDragable)
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
		Vector2 vector = Input.mousePosition;
		if (vector.x - m_v2MouseStartPos.x == 0f)
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
			if (vector.y - m_v2MouseStartPos.y == 0f)
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
		}
		Vector2 vector2 = (vector - m_v2MouseStartPos) / m_fScale;
		vector2 = m_fDragSpeed * vector2;
		m_v2MouseStartPos = vector;
		Vector3 localPosition = m_Camera.transform.localPosition;
		localPosition.x -= vector2.x;
		localPosition.z -= vector2.y;
		m_Camera.transform.localPosition = localPosition;
		Vector3 position = m_Camera.transform.position;
		if (position.x > m_v2BoundryRangeX.y)
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
			position.x = m_v2BoundryRangeX.y;
		}
		else if (position.x < m_v2BoundryRangeX.x)
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
			position.x = m_v2BoundryRangeX.x;
		}
		if (position.z > m_v2BoundryRangeZ.y)
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
			position.z = m_v2BoundryRangeZ.y;
		}
		else if (position.z < m_v2BoundryRangeZ.x)
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
			position.z = m_v2BoundryRangeZ.x;
		}
		position.y = m_fBoundryY;
		m_Camera.transform.position = position;
	}
}
