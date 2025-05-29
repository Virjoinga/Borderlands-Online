using System.Collections.Generic;
using UnityEngine;
using pumpkin.displayInternal;
using pumpkin.swf;

namespace pumpkin.display
{
	public class AnimSpriteSheet
	{
		public static int STATE_STOPPED = 0;

		public static int STATE_PLAYING = 1;

		public Mesh mesh = new Mesh();

		public MeshRenderer meshRenderer;

		public int maxMaxVerts = 0;

		public int[] maxIndexMap;

		public List<AnimFrame> frames = new List<AnimFrame>();

		public List<AnimInfo> anims = new List<AnimInfo>();

		public Dictionary<string, int> animNameMap = new Dictionary<string, int>();

		public Material lastMaterial;

		public bool loop = true;

		public Vector3 offset = Vector3.zero;

		protected int m_PlayState = STATE_PLAYING;

		protected AnimInfo m_ActiveAnim;

		protected int m_FrameId = 0;

		private Vector3[] meshVertices;

		private Vector2[] meshUVs;

		private Color[] meshColors;

		private Vector3 _v3_staticZero = Vector3.zero;

		private Vector3 _v2_staticZero = Vector2.zero;

		private Color _col_staticZero = Color.clear;

		public int currentFrame
		{
			get
			{
				return m_FrameId + 1;
			}
			set
			{
				m_FrameId = value - 1;
			}
		}

		public int currentFrameId
		{
			get
			{
				return m_FrameId;
			}
			set
			{
				m_FrameId = value;
				renderFrame();
			}
		}

		public AnimInfo activeAnim
		{
			get
			{
				return m_ActiveAnim;
			}
		}

		public int addAnimFrameFromMovieClipRange(string animName, Stage root, MovieClipPlayer frameControl, int start, int end)
		{
			if (animNameMap.ContainsKey(animName))
			{
				return -1;
			}
			if (start > frameControl.totalFrames)
			{
				start = frameControl.totalFrames - 1;
			}
			if (end < start || end > frameControl.totalFrames)
			{
				end = frameControl.totalFrames;
			}
			int num = end - start + 1;
			int num2 = addAnim(animName);
			AnimInfo animInfo = anims[num2];
			int[] array = new int[num];
			int num3 = 0;
			for (int i = start; i <= end; i++)
			{
				frameControl.setFrame(i);
				int num4 = addFrameFromDisplayObject(root);
				array[num3++] = num4;
			}
			animInfo.frameIDs = array;
			return num2;
		}

		public int addFrameFromDisplayObject(Stage stage)
		{
			GraphicsMeshGenerator graphicsMeshGenerator = new GraphicsMeshGenerator();
			graphicsMeshGenerator.renderStage(stage);
			AnimFrame animFrame = new AnimFrame();
			if (graphicsMeshGenerator.submeshIndices == null || graphicsMeshGenerator.submeshIndices.Count < 1)
			{
				animFrame.vertices = new Vector3[0];
				animFrame.UVs = new Vector2[0];
				frames.Add(animFrame);
				return frames.Count - 1;
			}
			lastMaterial = graphicsMeshGenerator.currentMaterial;
			animFrame.vertices = graphicsMeshGenerator.vertices;
			animFrame.UVs = graphicsMeshGenerator.UVs;
			animFrame.material = graphicsMeshGenerator.currentMaterial;
			animFrame.colors = graphicsMeshGenerator.colors;
			frames.Add(animFrame);
			if (animFrame.vertices.Length > maxMaxVerts)
			{
				maxMaxVerts = animFrame.vertices.Length;
				maxIndexMap = graphicsMeshGenerator.submeshIndices[0];
			}
			return frames.Count - 1;
		}

		public int addAnim(string name)
		{
			AnimInfo animInfo = new AnimInfo();
			animInfo.name = name;
			animInfo.animId = anims.Count;
			anims.Add(animInfo);
			int num = anims.Count - 1;
			animNameMap[name] = num;
			return num;
		}

		public int playAnim(int animId)
		{
			m_PlayState = STATE_PLAYING;
			m_ActiveAnim = anims[animId];
			if (m_ActiveAnim.frameIDs == null || m_ActiveAnim.frameIDs.Length == 0)
			{
				return -1;
			}
			m_FrameId = 0;
			setFrameId(m_ActiveAnim.frameIDs[0]);
			return animId;
		}

		public int playAnimOnce(string name)
		{
			if (!animNameMap.ContainsKey(name))
			{
				return -1;
			}
			int num = animNameMap[name];
			if (m_ActiveAnim != null && m_ActiveAnim.animId == num)
			{
				return m_ActiveAnim.animId;
			}
			return playAnim(num);
		}

		public int playAnim(string name)
		{
			if (!animNameMap.ContainsKey(name))
			{
				return -1;
			}
			int animId = animNameMap[name];
			return playAnim(animId);
		}

		public void stop()
		{
			m_PlayState = STATE_STOPPED;
		}

		public void play()
		{
			m_PlayState = STATE_PLAYING;
		}

		public void setFrame(int frameNum)
		{
			if (m_ActiveAnim != null && frameNum >= 0 && frameNum < m_ActiveAnim.frameIDs.Length)
			{
				setFrameId(m_ActiveAnim.frameIDs[frameNum]);
			}
		}

		protected void setFrameId(int frameId)
		{
			AnimFrame animFrame = frames[frameId];
			if (meshVertices == null)
			{
				meshVertices = mesh.vertices;
				meshUVs = mesh.uv;
				meshColors = mesh.colors;
			}
			int num = meshVertices.Length;
			for (int i = 0; i < num; i++)
			{
				if (i < num)
				{
					meshVertices[i] = animFrame.vertices[i] + offset;
					meshUVs[i] = animFrame.UVs[i];
					meshColors[i] = animFrame.colors[i];
				}
				else
				{
					meshVertices[i] = _v3_staticZero;
					meshUVs[i] = _v2_staticZero;
					meshColors[i] = _col_staticZero;
				}
			}
			mesh.vertices = meshVertices;
			mesh.uv = meshUVs;
			mesh.colors = meshColors;
			if ((bool)meshRenderer)
			{
				meshRenderer.material = animFrame.material;
			}
		}

		public void applyFrameMeshColor(Color col)
		{
			if (!(mesh == null) && mesh.colors != null)
			{
				Color[] colors = mesh.colors;
				for (int i = 0; i < colors.Length; i++)
				{
					colors[i] = col;
				}
				mesh.colors = colors;
			}
		}

		public Mesh generateMesh()
		{
			meshVertices = null;
			meshUVs = null;
			meshColors = null;
			AnimFrame animFrame;
			for (int i = 0; i < frames.Count; i++)
			{
				animFrame = frames[i];
				if (animFrame.vertices.Length < maxMaxVerts)
				{
					Vector3[] vertices = animFrame.vertices;
					animFrame.vertices = new Vector3[maxMaxVerts];
					vertices.CopyTo(animFrame.vertices, 0);
					Vector2[] uVs = animFrame.UVs;
					animFrame.UVs = new Vector2[maxMaxVerts];
					uVs.CopyTo(animFrame.UVs, 0);
					Color[] colors = animFrame.colors;
					animFrame.colors = new Color[maxMaxVerts];
					colors.CopyTo(animFrame.colors, 0);
				}
			}
			if (frames.Count <= 0)
			{
				return null;
			}
			animFrame = frames[0];
			mesh.Clear();
			mesh.vertices = animFrame.vertices;
			mesh.uv = animFrame.UVs;
			mesh.colors = animFrame.colors;
			mesh.triangles = maxIndexMap;
			setFrameId(0);
			return mesh;
		}

		public void frameUpdate()
		{
			if (m_ActiveAnim == null || m_PlayState != STATE_PLAYING)
			{
				return;
			}
			if (m_FrameId < 0)
			{
				m_FrameId = 0;
			}
			if (m_FrameId >= m_ActiveAnim.frameIDs.Length)
			{
				if (loop)
				{
					m_FrameId = 0;
				}
				else
				{
					m_PlayState = STATE_STOPPED;
					m_FrameId = m_ActiveAnim.frameIDs.Length - 1;
				}
			}
			setFrameId(m_ActiveAnim.frameIDs[m_FrameId]);
			m_FrameId++;
		}

		public bool renderFrame()
		{
			if (m_ActiveAnim == null)
			{
				return false;
			}
			if (m_FrameId < 0 || m_FrameId >= m_ActiveAnim.frameIDs.Length)
			{
				return false;
			}
			setFrameId(m_ActiveAnim.frameIDs[m_FrameId]);
			return true;
		}
	}
}
