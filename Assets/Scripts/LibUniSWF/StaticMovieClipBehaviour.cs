using System;
using UnityEngine;
using pumpkin.display;
using pumpkin.displayInternal;
using pumpkin.events;
using pumpkin.swf;

[ExecuteInEditMode]
[AddComponentMenu("uniSWF/StaticMovieClipBehaviour")]
public class StaticMovieClipBehaviour : MonoBehaviour
{
	public static Vector2 defaultDrawScale = new Vector2(0.01f, 0.01f);

	public string swf = null;

	public string symbolName = null;

	public string gotoAndStopLabel = null;

	public int gotoAndStopFrame = 0;

	protected bool enableCache = false;

	public bool billboard = false;

	public Camera billboardCamera = null;

	public bool loop = true;

	public bool flipY = false;

	public Vector2 drawScale = Vector2.zero;

	public bool editorPreview = true;

	public MovieClipBlendMode blendMode = MovieClipBlendMode.Normal;

	public int fps = 30;

	public Color colorTransform = Color.white;

	[NonSerialized]
	public MovieClip movieClip;

	[NonSerialized]
	public Stage stage;

	[NonSerialized]
	public IGraphicsGenerator gfxGenerator;

	protected MeshFilter meshFilter;

	protected MeshRenderer meshRenderer;

	protected bool m_Is3D = true;

	protected double lastInterval;

	protected double updateInterval;

	protected DisplayObject currentMouseOver;

	protected bool lastWasDown = false;

	protected Vector2 lastMousePos;

	protected bool m_EnableMouse = true;

	protected bool lastTouchWasDown = false;

	protected DisplayObject lastUnderMouse;

	private string lastMovieClip = null;

	private string lastSymbolName = null;

	private CEvent m_EnterFrameEvent;

	public int currentFrame
	{
		get
		{
			return movieClip.getCurrentFrame();
		}
		set
		{
			movieClip.setFrame(value);
		}
	}

	public float zDrawDisplayObjectSpace
	{
		get
		{
			return ((GraphicsMeshGenerator)gfxGenerator).zSpace;
		}
		set
		{
			((GraphicsMeshGenerator)gfxGenerator).zSpace = value;
		}
	}

	public float zDrawDisplayObjectContainerSpace
	{
		get
		{
			return ((GraphicsMeshGenerator)gfxGenerator).zContainerSpace;
		}
		set
		{
			((GraphicsMeshGenerator)gfxGenerator).zContainerSpace = value;
		}
	}

	public virtual void Awake()
	{
		if (!Application.isPlaying && !editorPreview)
		{
			return;
		}
		enableCache = false;
		m_EnterFrameEvent = new CEvent(CEvent.ENTER_FRAME, false, false);
		if (m_Is3D)
		{
			meshFilter = (MeshFilter)base.gameObject.GetComponent(typeof(MeshFilter));
			if (!meshFilter)
			{
				base.gameObject.AddComponent("MeshFilter");
			}
			meshRenderer = (MeshRenderer)base.gameObject.GetComponent(typeof(MeshRenderer));
			if (!meshRenderer)
			{
				base.gameObject.AddComponent("MeshRenderer");
			}
			meshFilter = (MeshFilter)base.gameObject.GetComponent(typeof(MeshFilter));
			meshRenderer = (MeshRenderer)base.gameObject.GetComponent(typeof(MeshRenderer));
		}
		gfxGenerator = instanceGfxGenerator();
		if (drawScale == Vector2.zero)
		{
			drawScale = getDefaultDrawScale();
		}
		stage = new Stage();
		stage.scaleX = drawScale.x;
		if (flipY)
		{
			stage.scaleY = drawScale.y;
		}
		else
		{
			stage.scaleY = 0f - drawScale.y;
		}
		SwfURI swfURI = new SwfURI();
		swfURI.swf = swf;
		swfURI.linkage = symbolName;
		movieClip = new MovieClip(swfURI);
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
		updateInterval = 1f / (float)fps;
		lastInterval = 0.0;
		movieClip.blendMode = (int)blendMode;
		m_EnableMouse = true;
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			m_EnableMouse = false;
		}
		lastMovieClip = swf;
		lastSymbolName = symbolName;
		if (Application.isEditor)
		{
			UniSWFSharedAssetManagerBehaviour.checkPreloadExecutionOrder();
		}
		renderFrame();
	}

	protected IGraphicsGenerator instanceGfxGenerator()
	{
		GraphicsMeshGenerator graphicsMeshGenerator = new GraphicsMeshGenerator();
		graphicsMeshGenerator.enableCache = enableCache;
		return graphicsMeshGenerator;
	}

	public virtual void update()
	{
		if (Application.isEditor && ((lastMovieClip != null && swf != null && lastMovieClip.CompareTo(swf) != 0) || (lastSymbolName != null && symbolName != null && lastSymbolName.CompareTo(symbolName) != 0)))
		{
			Awake();
		}
		if (movieClip != null)
		{
			bool flag = false;
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			if ((double)realtimeSinceStartup > lastInterval + updateInterval)
			{
				renderFrame();
				flag = true;
			}
			if (!Application.isPlaying)
			{
				return;
			}
			if (flag)
			{
				handleUserInput();
			}
		}
		if (billboard)
		{
			Transform transform = ((!(billboardCamera != null)) ? findMainCamera().transform : billboardCamera.transform);
			base.transform.eulerAngles = transform.eulerAngles;
		}
	}

	protected Camera findMainCamera()
	{
		if (Camera.main != null)
		{
			return Camera.main;
		}
		if (Camera.mainCamera != null)
		{
			return Camera.mainCamera;
		}
		Camera camera = (Camera)UnityEngine.Object.FindObjectOfType(typeof(Camera));
		if (camera == null)
		{
			throw new Exception("Failed to find a Camera in the scene");
		}
		return camera;
	}

	protected virtual void handleUserInput()
	{
	}

	public void calcOthoScale(Camera camera)
	{
		float orthographicSize = camera.orthographicSize;
		float num = Screen.height / 2;
		float num2 = 1f / num * orthographicSize;
		base.transform.localScale = new Vector3(num2, num2, num2);
	}

	public virtual Vector2 getDefaultDrawScale()
	{
		return defaultDrawScale;
	}

	public void setUri(string uri)
	{
		stage.removeChild(movieClip);
		SwfURI swfURI = new SwfURI(uri);
		swf = swfURI.swf;
		symbolName = swfURI.linkage;
		gotoAndStopLabel = (string)swfURI.label;
		movieClip = new MovieClip(swfURI);
		stage.addChild(movieClip);
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
}
