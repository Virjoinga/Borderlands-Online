using UnityEngine;
using pumpkin.display;
using pumpkin.events;

[AddComponentMenu("uniSWF/InteractiveMovieClipBehaviour")]
public class InteractiveMovieClipBehaviour : MovieClipBehaviour
{
	public bool enableMouse = true;

	public bool enableMouseOver = true;

	public bool enableTouch = true;

	public bool multitouch = true;

	public bool enableKeyboard = true;

	public Camera mouseInputCamera = null;

	protected bool m_DebugInteraction = false;

	protected Vector3 m_ColliderLastHitPoint = default(Vector3);

	protected bool m_ColliderHit = false;

	protected bool debugInteraction = false;

	protected bool enableEventStack = true;

	private BoxCollider m_Collider;

	private Vector2 _convertToCameraRectSpaceRes;

	private DisplayObject lastMouseDown = null;

	public override void Awake()
	{
		base.Awake();
		if (enableKeyboard)
		{
			stage.stageFlags |= StageFlags.PROCESS_KEYEVENTS;
		}
	}

	public override void Update()
	{
		base.Update();
		if (Application.isPlaying && enableKeyboard)
		{
			handleKeyboardInput();
		}
	}

	protected Vector3 screenCoordToMovieCoord(Vector3 coord)
	{
		Camera camera = ((!(mouseInputCamera != null)) ? findMainCamera() : mouseInputCamera);
		Ray ray = camera.ScreenPointToRay(coord);
		if (m_DebugInteraction)
		{
		}
		if (m_Collider == null)
		{
			m_Collider = GetComponent<BoxCollider>();
			if (m_Collider == null)
			{
				m_Collider = (BoxCollider)base.gameObject.AddComponent("BoxCollider");
			}
		}
		RaycastHit hitInfo;
		if (m_Collider.Raycast(ray, out hitInfo, 99999f))
		{
			m_ColliderHit = true;
			if (m_DebugInteraction)
			{
				drawMarker(hitInfo.point, Color.red);
			}
			Vector3 point = hitInfo.point;
			m_ColliderLastHitPoint = hitInfo.point;
			point.x -= base.transform.position.x;
			point.y -= base.transform.position.y;
			point.z -= base.transform.position.z;
			point = base.transform.worldToLocalMatrix.MultiplyVector(point);
			point.z = 0f;
			if (m_DebugInteraction)
			{
				drawMarker(point, Color.green);
			}
			return point;
		}
		m_ColliderHit = false;
		return new Vector3(0f, 0f);
	}

	private void drawMarker(Vector3 pos, Color col)
	{
	}

	protected void OnMouseDown()
	{
		Vector3 localMousePos = getLocalMousePos(Input.mousePosition);
		MouseEvent mouseEvent = new MouseEvent(MouseEvent.MOUSE_DOWN);
		mouseEvent.stageX = localMousePos.x;
		mouseEvent.stageY = localMousePos.y;
		stage.handleMouseEvent(mouseEvent);
	}

	protected void OnMouseUp()
	{
		Vector3 localMousePos = getLocalMousePos(Input.mousePosition);
		MouseEvent mouseEvent = new MouseEvent(MouseEvent.MOUSE_UP);
		mouseEvent.stageX = localMousePos.x;
		mouseEvent.stageY = localMousePos.y;
		stage.handleMouseEvent(mouseEvent);
	}

	protected Vector3 getLocalMousePos(Vector3 mousePos)
	{
		return screenCoordToMovieCoord(mousePos);
	}

	protected Vector2 getMousePos()
	{
		return getLocalMousePos(Input.mousePosition);
	}

	protected void handleKeyboardInput()
	{
		if ((stage.stageFlags & StageFlags.PROCESS_KEYEVENTS) == 0)
		{
			return;
		}
		string inputString = Input.inputString;
		foreach (char c in inputString)
		{
			KeyboardEvent keyboardEvent = new KeyboardEvent(KeyboardEvent.KEY_DOWN, true, false);
			keyboardEvent.charString = c.ToString();
			if (stage.focus != null)
			{
				stage.focus.fireEvent(keyboardEvent);
			}
			else
			{
				stage.fireEvent(keyboardEvent);
			}
		}
	}

	public void setInteractionDebugEnabled(bool setting)
	{
		m_DebugInteraction = setting;
	}

	protected Vector2 convertToCameraRectSpace(float posX, float posY)
	{
		_convertToCameraRectSpaceRes.x = posX;
		_convertToCameraRectSpaceRes.y = posY;
		return getLocalMousePos(_convertToCameraRectSpaceRes);
	}

	protected override void handleUserInput()
	{
		if (!enableMouse)
		{
			return;
		}
		if (m_EnableMouse && Input.touchCount == 0)
		{
			handleMouseInputState(getMousePos(), Input.GetButton("Fire1"));
		}
		if (multitouch)
		{
			int touchCount = Input.touchCount;
			if (touchCount > 0)
			{
				Vector2 position = Input.GetTouch(0).position;
				position = getLocalMousePos(position);
				handleMouseInputState(position, true);
				lastTouchWasDown = true;
			}
			else if (lastTouchWasDown)
			{
				handleMouseInputState(lastMousePos, false);
				lastTouchWasDown = false;
			}
		}
		stage.mouseOver = currentMouseOver;
	}

	protected void handleMouseInputState(Vector2 mousePos, bool leftDown)
	{
		Vector2 point = mousePos;
		stage.stageMouseX = point.x;
		stage.stageMouseY = point.y;
		DisplayObject displayObject = null;
		DisplayObject objectUnderPoint = stage.getObjectUnderPoint(point);
		if (objectUnderPoint != null)
		{
			if (m_DebugInteraction)
			{
				Debug.Log(string.Concat("objUnderMouse=", objectUnderPoint, ", name: ", objectUnderPoint.name, ", currentMouseOver=", currentMouseOver));
			}
			bool flag = false;
			if (enableMouseOver)
			{
				if (currentMouseOver != objectUnderPoint && currentMouseOver != null)
				{
					currentMouseOver.fireEvent(createMouseEvent(currentMouseOver, MouseEvent.MOUSE_LEAVE, mousePos));
					flag = true;
				}
				else if (currentMouseOver == null)
				{
					flag = true;
				}
			}
			currentMouseOver = objectUnderPoint;
			if (enableMouseOver && flag)
			{
				currentMouseOver.fireEvent(createMouseEvent(currentMouseOver, MouseEvent.MOUSE_ENTER, mousePos));
			}
			if (!lastWasDown && leftDown)
			{
				currentMouseOver.fireEvent(createMouseEvent(currentMouseOver, MouseEvent.MOUSE_DOWN, mousePos));
				lastMouseDown = currentMouseOver;
			}
			else if (!leftDown && lastWasDown)
			{
				currentMouseOver.fireEvent(createMouseEvent(currentMouseOver, MouseEvent.MOUSE_UP, mousePos));
				if (lastMouseDown == currentMouseOver)
				{
					currentMouseOver.fireEvent(createMouseEvent(currentMouseOver, MouseEvent.CLICK, mousePos));
				}
				lastMouseDown = null;
				displayObject = currentMouseOver;
			}
		}
		else
		{
			if (enableMouseOver && currentMouseOver != null)
			{
				currentMouseOver.fireEvent(createMouseEvent(currentMouseOver, MouseEvent.MOUSE_LEAVE, mousePos));
			}
			currentMouseOver = null;
		}
		if (lastMousePos != mousePos && currentMouseOver != null)
		{
			currentMouseOver.fireEvent(createMouseEvent(currentMouseOver, MouseEvent.MOUSE_MOVE, mousePos));
		}
		if (!leftDown)
		{
			if (currentMouseOver != null && lastWasDown && displayObject != currentMouseOver)
			{
				currentMouseOver.fireEvent(createMouseEvent(currentMouseOver, MouseEvent.MOUSE_UP, mousePos));
			}
			if (lastWasDown)
			{
			}
			lastMouseDown = null;
		}
		lastWasDown = leftDown;
		lastMousePos = mousePos;
		lastUnderMouse = objectUnderPoint;
	}

	protected MouseEvent createMouseEvent(DisplayObject targetSpace, string type, Vector3 mouseStagePos)
	{
		MouseEvent mouseEvent = new MouseEvent(type, true, false);
		mouseEvent.stageX = mouseStagePos.x;
		mouseEvent.stageY = mouseStagePos.y;
		mouseEvent.worldPos = m_ColliderLastHitPoint;
		return mouseEvent;
	}

	protected MouseEvent createMouseEvent(DisplayObject targetSpace, string type, Touch touch)
	{
		return new MouseEvent(type, true, false);
	}
}
