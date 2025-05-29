using System;
using System.Collections.Generic;
using UnityEngine;
using pumpkin.display;
using pumpkin.displayInternal;
using pumpkin.geom;
using pumpkin.uniSWFInternal;

namespace pumpkin.swf
{
	public class GraphicsVectorGenerator
	{
		internal static bool m_lcheck = false;

		private Material currentMaterial;

		private Texture currentTexture;

		private List<Vector2> currentPoints = new List<Vector2>();

		private List<Vector2> currentUv = new List<Vector2>();

		private List<Color> currentColor = new List<Color>();

		private Color col;

		private Matrix currentMatrix;

		private pumpkin.display.Graphics g;

		public GraphicsVectorGenerator(pumpkin.display.Graphics g)
		{
			if (!m_lcheck)
			{
				if (!UniSWFLicense.isPro())
				{
					throw new Exception(UniSWFLicense.PRO_WARNING_STR);
				}
				m_lcheck = true;
			}
			this.g = g;
		}

		public void setMaterial(Material m)
		{
			currentMaterial = m;
			col = Color.white;
		}

		public void beginFill(Color col)
		{
			flush();
			currentTexture = null;
			currentMatrix = null;
			currentMaterial = new Material(TextureManager.baseColorShader);
			currentMaterial.color = Color.white;
			this.col = col;
		}

		public void beginMaterialFill(Material mat, Matrix matrix)
		{
			flush();
			currentTexture = null;
			currentMatrix = null;
			currentMaterial = mat;
			if (mat.HasProperty("_MainTex"))
			{
				currentTexture = mat.mainTexture;
			}
			col = Color.white;
			currentMatrix = matrix;
			if (currentMatrix != null)
			{
				currentMatrix = currentMatrix.clone().invert();
			}
			else
			{
				currentMatrix = new Matrix();
			}
		}

		public void setFillColor(Color col)
		{
			this.col = col;
		}

		public void moveTo(float x, float y)
		{
			flush();
			lineTo(x, y);
		}

		public void lineTo(float x, float y)
		{
			currentPoints.Add(new Vector2(x, y));
			if (currentMatrix != null && (bool)currentTexture)
			{
				Vector2 vector = currentMatrix.transformPoint(new Vector2(x, y));
				Vector2 item = new Vector2(vector.x / (float)currentTexture.width, 1f - vector.y / (float)currentTexture.height);
				currentUv.Add(item);
			}
			else
			{
				currentUv.Add(Vector2.zero);
			}
			currentColor.Add(col);
		}

		public void flush()
		{
			if (m_lcheck && currentPoints.Count > 0)
			{
				SimpleVectorShape simpleVectorShape = new SimpleVectorShape();
				simpleVectorShape.vertices = currentPoints.ToArray();
				simpleVectorShape.uv = currentUv.ToArray();
				simpleVectorShape.colors = currentColor.ToArray();
				GraphicsDrawOP graphicsDrawOP = new GraphicsDrawOP();
				graphicsDrawOP.simpleVectorShape = simpleVectorShape;
				graphicsDrawOP.material = currentMaterial;
				if (currentMatrix != null)
				{
					graphicsDrawOP.matrix = currentMatrix.clone();
				}
				g.drawOPs.Add(graphicsDrawOP);
				currentPoints.Clear();
			}
		}
	}
}
