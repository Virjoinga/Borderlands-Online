using System.Collections.Generic;
using UnityEngine;
using pumpkin.display;
using pumpkin.swf;

[AddComponentMenu("uniSWF/SpriteSheetMovieClipBehaviour")]
public class SpriteSheetMovieClipBehaviour : MonoBehaviour
{
	public static Vector2 defaultDrawScale = new Vector2(0.01f, 0.01f);

	public static Dictionary<string, AnimSpriteSheet> spriteSheetCache = new Dictionary<string, AnimSpriteSheet>();

	public string swf = null;

	public string symbolName = null;

	public int gotoAndStopFrame = 0;

	public int fps = 30;

	public bool cache = true;

	public bool generateDefault = true;

	public bool playing = true;

	public bool loop = true;

	public AnimSpriteSheet spriteSheet;

	public Vector2 drawScale = Vector2.zero;

	public Vector2 offsetPosition = Vector2.zero;

	public bool flipY = false;

	public bool useSmoothTime = false;

	public static bool enableDepreciatedFrameTiming = false;

	protected double lastInterval;

	protected double updateInterval;

	protected MovieClip player;

	protected MeshFilter meshFilter;

	protected MeshRenderer meshRenderer;

	private double t;

	private double frameDrift = 0.0;

	public void Awake()
	{
		updateInterval = 1f / (float)fps;
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
		spriteSheet = new AnimSpriteSheet();
		if (swf == null || symbolName == null || swf.Length == 0 || symbolName.Length == 0 || !generateDefault)
		{
			return;
		}
		string key = swf + symbolName;
		AnimSpriteSheet animSpriteSheet = ((!spriteSheetCache.ContainsKey(key)) ? null : spriteSheetCache[key]);
		if (animSpriteSheet == null)
		{
			Stage stage = new Stage();
			stage.host = this;
			if (drawScale == Vector2.zero)
			{
				drawScale = getDefaultDrawScale();
			}
			stage.host = this;
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
			int start = 1;
			if (gotoAndStopFrame != 0)
			{
				start = gotoAndStopFrame;
			}
			player = new MovieClip(swfURI);
			stage.addChild(player);
			player.x = offsetPosition.x;
			player.y = offsetPosition.y;
			spriteSheet.addAnimFrameFromMovieClipRange(symbolName, stage, player, start, -1);
			spriteSheet.generateMesh();
			meshFilter.mesh = spriteSheet.mesh;
			meshRenderer.material = spriteSheet.lastMaterial;
			if (cache)
			{
				spriteSheetCache[key] = animSpriteSheet;
			}
		}
		else
		{
			spriteSheet.frames = animSpriteSheet.frames;
			spriteSheet.anims = animSpriteSheet.anims;
			spriteSheet.animNameMap = animSpriteSheet.animNameMap;
			spriteSheet.maxIndexMap = animSpriteSheet.maxIndexMap;
			spriteSheet.generateMesh();
			meshFilter.mesh = spriteSheet.mesh;
			meshRenderer.material = animSpriteSheet.lastMaterial;
		}
		if (playing)
		{
			spriteSheet.playAnim(symbolName);
		}
		spriteSheet.loop = loop;
	}

	public void Update()
	{
		if (enableDepreciatedFrameTiming)
		{
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			if ((double)realtimeSinceStartup > lastInterval + updateInterval)
			{
				spriteSheet.frameUpdate();
				lastInterval = realtimeSinceStartup;
			}
			return;
		}
		float num = ((!useSmoothTime) ? Time.deltaTime : Time.smoothDeltaTime);
		t += num;
		if (t >= updateInterval)
		{
			frameDrift = t - updateInterval;
			t = frameDrift;
			spriteSheet.frameUpdate();
		}
	}

	protected AnimSpriteSheet loadCacheSpriteSheet(string sharedCacheKey)
	{
		AnimSpriteSheet animSpriteSheet = ((!spriteSheetCache.ContainsKey(sharedCacheKey)) ? null : spriteSheetCache[sharedCacheKey]);
		if (animSpriteSheet != null)
		{
			spriteSheet.frames = animSpriteSheet.frames;
			spriteSheet.anims = animSpriteSheet.anims;
			spriteSheet.animNameMap = animSpriteSheet.animNameMap;
			spriteSheet.maxIndexMap = animSpriteSheet.maxIndexMap;
			spriteSheet.generateMesh();
			meshFilter.mesh = spriteSheet.mesh;
			meshRenderer.material = animSpriteSheet.lastMaterial;
			return spriteSheet;
		}
		return null;
	}

	protected void generateCacheSpriteSheet(string sharedCacheKey)
	{
		spriteSheet.generateMesh();
		meshFilter.mesh = spriteSheet.mesh;
		meshRenderer.material = spriteSheet.lastMaterial;
		spriteSheetCache[sharedCacheKey] = spriteSheet;
	}

	public virtual Vector2 getDefaultDrawScale()
	{
		return defaultDrawScale;
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
