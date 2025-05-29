using System;
using System.Collections.Generic;
using UnityEngine;
using pumpkin.display;
using pumpkin.displayInternal;
using pumpkin.events;

[AddComponentMenu("uniSWF/MovieClipOverlayCameraBehaviour")]
public class MovieClipOverlayCameraBehaviour : PumpkinBehaviour
{
	private struct UserInputState
	{
		public bool lastWasDown;

		public DisplayObject lastMouseDown;

		public List<DisplayObject> lastMouseDownStack;

		public DisplayObject currentMouseOver;
	}

	public static string overlayCameraName = "Main Camera";

	public static bool defaultUseAccurateTiming = false;

	public bool enableKeyboard = true;

	public bool enableMouse = true;

	public bool enableTouch = true;

	public bool enableMouseOver = true;

	public bool multitouch = true;

	public int fps = 30;

	public Color colorTransform = Color.white;

	[NonSerialized]
	public MovieClip player;

	[NonSerialized]
	public Stage stage;

	[NonSerialized]
	public IGraphicsGenerator gfxGenerator;

	public Vector2 stageScale = new Vector2(1f, 1f);

	public bool syncStageScalePerFrame = true;

	public bool processInputOnUpdate = true;

	public string swf = null;

	public string symbolName = null;

	public string gotoAndStopLabel = null;

	public int gotoAndStopFrame = 0;

	public bool loop = true;

	[NonSerialized]
	public MovieClip movieClip;

	protected bool enableEventStack = true;

	protected bool debugInteraction = false;

	protected MeshFilter meshFilter;

	protected MeshRenderer meshRenderer;

	protected bool m_Is3D = false;

	protected double lastInterval;

	protected double updateInterval;

	protected DisplayObject currentMouseOver;

	protected bool lastWasDown = false;

	protected Vector2 lastMousePos;

	protected bool m_EnableMouse = true;

	protected bool lastTouchWasDown = false;

	protected DisplayObject lastUnderMouse;

	protected Vector3 drawOffset = default(Vector3);

	protected bool drawNow = true;

	protected Vector3 drawScale;

	protected float m_LastOrth = -1f;

	protected float m_LastScreenWidth = -1f;

	protected float m_LastScreenHeight = -1f;

	protected bool m_EnableAutoSize = true;

	protected bool m_IsTouchDevice = false;

	private static MovieClipOverlayCameraBehaviour _instance;

	private CEvent m_EnterFrameEvent;

	public bool useFastRenderer = false;

	public bool useSmoothTime = false;

	public bool useAccurateTiming = defaultUseAccurateTiming;

	public bool doubleBufferMesh = false;

	private double t;

	private double frameDrift = 0.0;

	private SimpleStageRenderResult m_LastRenderMesh;

	protected Rect m_lastCamRect = default(Rect);

	private bool _usingCustomDrawOffset = false;

	public DisplayObject lastObjectUnderMouse = null;

	protected Touch m_CurrentTouch;

	private Dictionary<int, UserInputState> m_InputState = new Dictionary<int, UserInputState>();

	public static MovieClipOverlayCameraBehaviour instance
	{
		get
		{
			if (!_instance)
			{
				_instance = GameObject.Find(overlayCameraName).GetComponent<MovieClipOverlayCameraBehaviour>();
			}
			return _instance;
		}
	}

	public int currentFrame
	{
		get
		{
			return player.getCurrentFrame();
		}
		set
		{
			player.setFrame(value);
		}
	}

	public void Awake()
	{
		m_EnterFrameEvent = new CEvent(CEvent.ENTER_FRAME, false, false);
		gfxGenerator = instanceGfxGenerator();
		stage = new Stage();
		stage.host = this;
		if (enableKeyboard)
		{
			stage.stageFlags |= StageFlags.PROCESS_KEYEVENTS;
		}
		if (!string.IsNullOrEmpty(swf) && !string.IsNullOrEmpty(swf))
		{
			movieClip = new MovieClip(swf, symbolName);
			stage.addChild(movieClip);
			if (gotoAndStopLabel != null && gotoAndStopLabel.Length > 0)
			{
				movieClip.gotoAndStop(gotoAndStopLabel);
			}
			if (gotoAndStopFrame > 0)
			{
				movieClip.gotoAndStop(gotoAndStopFrame);
			}
			movieClip.looping = loop;
			movieClip.colorTransform = colorTransform;
			movieClip.alpha = colorTransform.a;
		}
		updateInterval = 1f / (float)fps;
		lastInterval = 0.0;
		m_EnableMouse = true;
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			m_EnableMouse = false;
		}
		if (Application.isEditor)
		{
			UniSWFSharedAssetManagerBehaviour.checkPreloadExecutionOrder();
		}
		stage.scaleX = stageScale.x;
		stage.scaleY = stageScale.y;
		if (base.camera == null)
		{
			Debug.LogError("MovieClipOverlayCameraBehaviour must be attached to a camera");
			return;
		}
		if (!base.camera.orthographic)
		{
			Debug.LogError("MovieClipOverlayCameraBehaviour requires the camera projection to be set to orthographic, Use multiple cameras to mix 2D and 3D objects in a scene.");
		}
		m_IsTouchDevice = isTouchDevice();
	}

	public override void OnStart()
	{
		base.OnStart();
	}

	protected virtual IGraphicsGenerator instanceGfxGenerator()
	{
		IGraphicsGenerator graphicsGenerator = null;
		graphicsGenerator = ((!useFastRenderer) ? ((IGraphicsGenerator)new GraphicsDrawMeshGenerator()) : ((IGraphicsGenerator)new FastGraphicsDrawMeshGenerator()));
		calcDrawOffsets();
		return graphicsGenerator;
	}

	public override void OnUpdate()
	{
		base.OnUpdate();
		if (processInputOnUpdate)
		{
			if (enableKeyboard)
			{
				handleKeyboardInput();
			}
			if (enableMouse)
			{
				handleUserInput();
			}
		}
		if (!useAccurateTiming)
		{
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			if ((double)realtimeSinceStartup > lastInterval + updateInterval)
			{
				if (!processInputOnUpdate)
				{
					if (enableKeyboard)
					{
						handleKeyboardInput();
					}
					if (enableMouse)
					{
						handleUserInput();
					}
				}
				renderFrame();
			}
		}
		else
		{
			float num = ((!useSmoothTime) ? Time.deltaTime : Time.smoothDeltaTime);
			t += num;
			if (t >= updateInterval)
			{
				frameDrift = t - updateInterval;
				t = frameDrift;
				if (t > updateInterval)
				{
					t = updateInterval;
				}
				if (!processInputOnUpdate)
				{
					if (enableKeyboard)
					{
						handleKeyboardInput();
					}
					if (enableMouse)
					{
						handleUserInput();
					}
				}
				renderFrame();
			}
		}
		if (Application.isPlaying && !enableMouse)
		{
		}
	}

	public void OnPostRender()
	{
		if (stage != null)
		{
			if (m_EnableAutoSize && m_LastOrth != base.camera.orthographicSize)
			{
				m_LastOrth = base.camera.orthographicSize;
				calcDrawOffsets();
			}
			if (base.camera.rect != m_lastCamRect)
			{
				calcDrawOffsets();
				m_lastCamRect = base.camera.rect;
			}
			if ((m_EnableAutoSize && (float)Screen.width != m_LastScreenWidth) || (float)Screen.height != m_LastScreenHeight)
			{
				m_LastScreenWidth = Screen.width;
				m_LastScreenHeight = Screen.height;
				calcDrawOffsets();
				stage.screenWidth = Screen.width;
				stage.screenHeight = Screen.height;
				stage.dispatchEvent(new CEvent(CEvent.RESIZE));
			}
			if (syncStageScalePerFrame && (stage.scaleX != stageScale.x || stage.scaleY != stageScale.y))
			{
				stage.scaleX = stageScale.x;
				stage.scaleY = stageScale.y;
			}
			if (drawNow && gfxGenerator != null && !m_Is3D)
			{
				gfxGenerator.renderStage(stage);
				gfxGenerator.drawMeshNow(base.transform.localToWorldMatrix, drawOffset, drawScale);
			}
		}
	}

	protected virtual void calcDrawOffsets()
	{
		if (!_usingCustomDrawOffset)
		{
			Camera viewportCamera = getViewportCamera();
			float orthographicSize = viewportCamera.orthographicSize;
			float aspect = viewportCamera.aspect;
			drawOffset.x = (0f - viewportCamera.aspect) * orthographicSize;
			drawOffset.y = orthographicSize;
			drawOffset.z = 100f;
			int height = Screen.height;
			if ((bool)viewportCamera.targetTexture)
			{
				height = viewportCamera.targetTexture.height;
			}
			float num = viewportCamera.rect.height * (float)height / 2f;
			float num2 = 1f / num * orthographicSize;
			drawScale.x = num2;
			drawScale.y = 0f - num2;
			drawOffset.z += 1f;
			drawScale.z = drawScale.x;
		}
	}

	public virtual void updateCalcDrawOffsets()
	{
		calcDrawOffsets();
	}

	public void setProjectionValues(Vector3 drawOffset, Vector3 drawScale)
	{
		this.drawOffset = drawOffset;
		this.drawScale = drawScale;
		_usingCustomDrawOffset = true;
	}

	protected virtual Camera getViewportCamera()
	{
		return base.camera;
	}

	protected virtual void handleKeyboardInput()
	{
		if (stage == null || (stage.stageFlags & StageFlags.PROCESS_KEYEVENTS) == 0)
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

	public void renderFrame()
	{
		stage.updateFrame(m_EnterFrameEvent);
		lastInterval = Time.realtimeSinceStartup;
		if (m_Is3D && (bool)meshFilter && gfxGenerator != null && gfxGenerator.renderStage(stage))
		{
			meshFilter.mesh = gfxGenerator.applyToMeshRenderer(meshRenderer);
		}
	}

	private void initTouchIputState()
	{
		m_InputState[0] = default(UserInputState);
		m_InputState[1] = default(UserInputState);
	}

	protected Vector2 convertToCameraRectSpace(float posX, float posY)
	{
		Rect rect = getViewportCamera().rect;
		float num = Screen.width;
		float num2 = Screen.height;
		float num3 = rect.x * num;
		float num4 = num2 - rect.y * num2 - rect.height * num2;
		return new Vector2(posX - num3, num2 - posY - num4);
	}

	public virtual void handleUserInput()
	{
		m_CurrentTouch = default(Touch);
		if (stage == null)
		{
			return;
		}
		if (enableMouse && Input.touchCount == 0)
		{
			if (!m_InputState.ContainsKey(0))
			{
				m_InputState[0] = default(UserInputState);
			}
			handleMouseInputState(convertToCameraRectSpace(Input.mousePosition.x, Input.mousePosition.y), Input.GetButton("Fire1"), 0);
		}
		if (!enableTouch)
		{
			return;
		}
		if (multitouch)
		{
			for (int i = 0; i < Input.touches.Length; i++)
			{
				Touch currentTouch = Input.touches[i];
				int num = ((!enableMouse) ? currentTouch.fingerId : (currentTouch.fingerId + 3));
				m_CurrentTouch = currentTouch;
				Vector2 mousePos = convertToCameraRectSpace(currentTouch.position.x, currentTouch.position.y);
				if (!m_InputState.ContainsKey(num))
				{
					m_InputState[num] = default(UserInputState);
				}
				if (currentTouch.phase == TouchPhase.Began)
				{
					handleMouseInputState(mousePos, true, num);
				}
				else if (currentTouch.phase == TouchPhase.Moved)
				{
					handleMouseInputState(mousePos, true, num);
				}
				else if (currentTouch.phase == TouchPhase.Ended)
				{
					handleMouseInputState(mousePos, false, num);
					m_InputState.Remove(num);
				}
			}
		}
		else
		{
			int touchCount = Input.touchCount;
			int num2 = 3;
			if (!m_InputState.ContainsKey(num2))
			{
				m_InputState[num2] = default(UserInputState);
			}
			if (touchCount > 0)
			{
				Touch touch = (m_CurrentTouch = Input.GetTouch(0));
				Vector2 position = touch.position;
				position.y = (float)Screen.height - position.y;
				handleMouseInputState(position, true, num2);
				lastTouchWasDown = true;
			}
			else if (lastTouchWasDown)
			{
				handleMouseInputState(lastMousePos, false, num2);
				lastTouchWasDown = false;
			}
		}
	}

	protected static bool isTouchDevice()
	{
		return Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer;
	}

	public virtual void handleMouseInputState(Vector2 mousePos, bool leftDown, int id)
	{
		Vector2 point = mousePos;
		if (stage == null)
		{
			return;
		}
		UserInputState value = m_InputState[id];
		stage.stageMouseX = point.x;
		stage.stageMouseY = point.y;
		DisplayObject displayObject = null;
		DisplayObject objectUnderPoint = stage.getObjectUnderPoint(point);
		if (objectUnderPoint == null && stage.defaultStageHitTest)
		{
			objectUnderPoint = stage;
		}
		lastObjectUnderMouse = objectUnderPoint;
		if (objectUnderPoint != null)
		{
			if (debugInteraction)
			{
				Debug.Log(string.Concat("objUnderMouse=", objectUnderPoint, ", name: ", objectUnderPoint.name, ", currentMouseOver=", value.currentMouseOver));
			}
			bool flag = false;
			if (enableMouseOver)
			{
				if (value.currentMouseOver != objectUnderPoint && value.currentMouseOver != null)
				{
					value.currentMouseOver.fireEvent(createMouseEvent(value.currentMouseOver, MouseEvent.MOUSE_LEAVE, mousePos, id));
					flag = true;
				}
				else if (value.currentMouseOver == null)
				{
					flag = true;
				}
			}
			value.currentMouseOver = objectUnderPoint;
			if (enableMouseOver && flag)
			{
				if (m_IsTouchDevice)
				{
					if (leftDown)
					{
						value.currentMouseOver.fireEvent(createMouseEvent(value.currentMouseOver, MouseEvent.MOUSE_ENTER, mousePos, id));
					}
				}
				else
				{
					value.currentMouseOver.fireEvent(createMouseEvent(value.currentMouseOver, MouseEvent.MOUSE_ENTER, mousePos, id));
				}
			}
			if (!value.lastWasDown && leftDown)
			{
				value.currentMouseOver.fireEvent(createMouseEvent(value.currentMouseOver, MouseEvent.MOUSE_DOWN, mousePos, id));
				value.lastMouseDown = value.currentMouseOver;
				value.lastMouseDownStack = _getParentStack(value.currentMouseOver);
			}
			else if (!leftDown && value.lastWasDown)
			{
				value.currentMouseOver.fireEvent(createMouseEvent(value.currentMouseOver, MouseEvent.MOUSE_UP, mousePos, id));
				_handleMouseReleaseClick(value.lastMouseDown, value.currentMouseOver, mousePos, value.lastMouseDownStack, id);
				value.lastMouseDown = null;
				value.lastMouseDownStack = null;
				displayObject = value.currentMouseOver;
			}
		}
		else
		{
			if (enableMouseOver && value.currentMouseOver != null)
			{
				value.currentMouseOver.fireEvent(createMouseEvent(value.currentMouseOver, MouseEvent.MOUSE_LEAVE, mousePos, id));
			}
			value.currentMouseOver = null;
		}
		if (lastMousePos != mousePos && value.currentMouseOver != null)
		{
			value.currentMouseOver.fireEvent(createMouseEvent(value.currentMouseOver, MouseEvent.MOUSE_MOVE, mousePos, id));
		}
		if (!leftDown)
		{
			if (value.currentMouseOver != null && value.lastWasDown && displayObject != value.currentMouseOver)
			{
				value.currentMouseOver.fireEvent(createMouseEvent(value.currentMouseOver, MouseEvent.MOUSE_UP, mousePos, id));
			}
			if (value.lastWasDown)
			{
			}
			value.lastMouseDown = null;
			value.lastMouseDownStack = null;
		}
		value.lastWasDown = leftDown;
		lastMousePos = mousePos;
		m_InputState[id] = value;
		stage.mouseOver = value.currentMouseOver;
	}

	protected virtual void _handleMouseReleaseClick(DisplayObject lastMouseDown, DisplayObject currentMouseOver, Vector2 mousePos, List<DisplayObject> lastMouseDownStack, int id)
	{
		if (lastMouseDown == currentMouseOver)
		{
			currentMouseOver.fireEvent(createMouseEvent(currentMouseOver, MouseEvent.CLICK, mousePos, id));
		}
		else
		{
			if (!enableEventStack)
			{
				return;
			}
			List<DisplayObject> list = _getParentStack(currentMouseOver);
			if (list == null || lastMouseDownStack == null)
			{
				return;
			}
			for (int i = 0; i < list.Count; i++)
			{
				for (int j = 0; j < lastMouseDownStack.Count; j++)
				{
					if (list[i] == lastMouseDownStack[j])
					{
						lastMouseDownStack[j].fireEvent(createMouseEvent(list[i], MouseEvent.CLICK, mousePos, id));
						return;
					}
				}
			}
		}
	}

	internal string dumpStack(string name, List<DisplayObject> mouseDownStack)
	{
		string text = "Stack: " + name + "\n";
		for (int i = 0; i < mouseDownStack.Count; i++)
		{
			string text2 = text;
			text = string.Concat(text2, "    [", i, "] ", mouseDownStack[i], "\n");
		}
		return text;
	}

	protected List<DisplayObject> _getParentStack(DisplayObject obj)
	{
		List<DisplayObject> list = new List<DisplayObject>();
		int num = 1024;
		while (obj.parent != null && num-- > 0)
		{
			list.Add(obj);
			obj = obj.parent;
		}
		return list;
	}

	protected virtual MouseEvent createMouseEvent(DisplayObject targetSpace, string type, Vector3 mouseStagePos, int id)
	{
		MouseEvent mouseEvent = new MouseEvent(type, true, false);
		mouseEvent.stageX = mouseStagePos.x;
		mouseEvent.stageY = mouseStagePos.y;
		mouseEvent.touchId = id;
		mouseEvent.touch = m_CurrentTouch;
		return mouseEvent;
	}

	public void setFps(float fps)
	{
		this.fps = (int)fps;
		updateInterval = 1f / fps;
		lastInterval = 0.0;
		frameDrift = 0.0;
		t = 0.0;
	}
}
