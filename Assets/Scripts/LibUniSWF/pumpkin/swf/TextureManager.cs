using System;
using System.Collections.Generic;
using UnityEngine;

namespace pumpkin.swf
{
	public class TextureManager : ITextureManager
	{
		public static bool allowEditorUnload = false;

		public static string baseBitmapShaderName = "Shaders/uniSWF-Double-Alpha-Diffuse";

		public static string baseBitmapAdditiveMaterial = "Shaders/uniSWF-Double-Add-Alpha-Diffuse";

		public static string baseColorShaderName = "Shaders/uniSWF-Double-Colour-Diffuse";

		public static string baseBitmapMaskMaterial = "Shaders/uniSWF-Double-Masked-Colour-Diffuse";

		public static Shader baseBitmapShader;

		public static Shader baseColorShader;

		public static Shader baseBitmapAddShader;

		public static Shader baseBitmapMaskShader;

		public static TextureManager instance;

		public static bool isOpenGL = false;

		public static bool isD3D10 = false;

		public static bool isD3D = false;

		internal static int lastTextId = 0;

		public Dictionary<string, Material> materials = new Dictionary<string, Material>();

		public Dictionary<string, Texture> textures = new Dictionary<string, Texture>();

		public TextureManager()
		{
			instance = this;
			baseBitmapShader = (Shader)Resources.Load(baseBitmapShaderName, typeof(Shader));
			if (baseBitmapShader == null)
			{
				Debug.LogError("Failed to load uniSWF shader '" + baseBitmapShaderName + "' ");
			}
			baseColorShader = (Shader)Resources.Load(baseColorShaderName, typeof(Shader));
			if (baseColorShader == null)
			{
				Debug.LogError("Failed to load uniSWF shader '" + baseColorShaderName + "' ");
			}
			baseBitmapAddShader = (Shader)Resources.Load(baseBitmapAdditiveMaterial, typeof(Shader));
			if (baseBitmapAddShader == null)
			{
				Debug.LogError("Failed to load uniSWF shader '" + baseBitmapAdditiveMaterial + "' ");
			}
			baseBitmapMaskShader = (Shader)Resources.Load(baseBitmapMaskMaterial, typeof(Shader));
			if (baseBitmapMaskShader == null)
			{
				Debug.LogError("Failed to load uniSWF shader '" + baseBitmapMaskMaterial + "' ");
			}
			isOpenGL = SystemInfo.graphicsDeviceVersion.Contains("OpenGL");
			isD3D10 = SystemInfo.graphicsDeviceVersion.Contains("Direct3D 10");
			isD3D = SystemInfo.graphicsDeviceVersion.Contains("Direct3D");
		}

		public int getTotalTextures()
		{
			return materials.Count;
		}

		public void clearTextureCache()
		{
			Texture[] array = (Texture[])Resources.FindObjectsOfTypeAll(typeof(Texture));
			foreach (string key in textures.Keys)
			{
				if (Array.IndexOf(array, textures[key]) != -1 && (!Application.isEditor || (Application.isEditor && allowEditorUnload)))
				{
					Resources.UnloadAsset(textures[key]);
				}
			}
			materials = new Dictionary<string, Material>();
			textures = new Dictionary<string, Texture>();
			Resources.UnloadUnusedAssets();
		}

		public void clearTextureMatchingPrefix(string swfPrefix)
		{
			Texture[] array = (Texture[])Resources.FindObjectsOfTypeAll(typeof(Texture));
			List<string> list = new List<string>();
			foreach (string key in textures.Keys)
			{
				if (Array.IndexOf(array, textures[key]) != -1 && key.StartsWith(swfPrefix))
				{
					if ((MovieClipPlayer.profilerSettings & MovieClipProfiler.SwfTextureUnload) == MovieClipProfiler.SwfTextureUnload)
					{
						Debug.Log("SwfProfile->SwfTextureUnload: " + key);
					}
					list.Add(key);
					if (!Application.isEditor || (Application.isEditor && allowEditorUnload))
					{
						Resources.UnloadAsset(textures[key]);
					}
				}
			}
			for (int i = 0; i < list.Count; i++)
			{
				if (materials.ContainsKey(list[i]))
				{
					materials.Remove(list[i]);
				}
				if (textures.ContainsKey(list[i]))
				{
					textures.Remove(list[i]);
				}
			}
		}

		public Material getBitmapData(string uri)
		{
			if (!materials.ContainsKey(uri) || (materials.ContainsKey(uri) && materials[uri] == null))
			{
				if ((MovieClipPlayer.profilerSettings & MovieClipProfiler.TextureLoad) == MovieClipProfiler.TextureLoad)
				{
					Debug.Log("SwfProfile->TextureLoad: " + uri);
				}
				Texture texture = (Texture)Resources.Load(uri);
				if (texture == null)
				{
					Debug.Log("Failed to load texture: " + uri);
					return null;
				}
				Material material = new Material(baseBitmapShader);
				material.color = new Color(1f, 1f, 1f, 1f);
				material.name = uri;
				texture.name = uri;
				material.mainTexture = texture;
				materials[uri] = material;
				textures[uri] = texture;
			}
			return materials[uri];
		}

		public Material createCovertyToAdditive(Material existingMaterial)
		{
			string text = null;
			foreach (KeyValuePair<string, Material> material4 in materials)
			{
				if (material4.Value == existingMaterial)
				{
					text = material4.Key;
					break;
				}
			}
			if (!string.IsNullOrEmpty(text))
			{
				string key = text + "_A";
				if (!materials.ContainsKey(key))
				{
					Texture mainTexture = existingMaterial.mainTexture;
					Material material = new Material(baseBitmapAddShader);
					material.mainTexture = mainTexture;
					materials[key] = material;
					return material;
				}
				Material material2 = materials[key];
				if ((bool)material2)
				{
					return material2;
				}
			}
			Material material3 = new Material(baseBitmapAddShader);
			material3.mainTexture = existingMaterial.mainTexture;
			return material3;
		}

		public Material getBitmapDataFromSceneTexture(string uri, Texture tex)
		{
			if (!materials.ContainsKey(uri) || (materials.ContainsKey(uri) && materials[uri] == null))
			{
				if ((MovieClipPlayer.profilerSettings & MovieClipProfiler.TextureLoad) == MovieClipProfiler.TextureLoad)
				{
					Debug.Log("SwfProfile->TextureLoad: " + uri);
				}
				Material material = new Material(baseBitmapShader);
				material.color = new Color(1f, 1f, 1f, 1f);
				material.name = uri;
				tex.name = uri;
				material.mainTexture = tex;
				materials[uri] = material;
			}
			return materials[uri];
		}

		public Material getBitmapData(AssetBundle assetBundle, string uri)
		{
			if (!materials.ContainsKey(uri) || (materials.ContainsKey(uri) && materials[uri] == null))
			{
				if ((MovieClipPlayer.profilerSettings & MovieClipProfiler.TextureLoad) == MovieClipProfiler.TextureLoad)
				{
					Debug.Log("SwfProfile->TextureLoad: " + uri);
				}
				Texture texture = (Texture)assetBundle.Load(uri);
				if (texture == null)
				{
					Debug.Log("Failed to load texture: " + uri + " from bundle: " + assetBundle);
					return null;
				}
				Material material = new Material(baseBitmapShader);
				material.color = new Color(1f, 1f, 1f, 1f);
				material.name = uri;
				texture.name = uri;
				material.mainTexture = texture;
				materials[uri] = material;
				textures[uri] = texture;
			}
			return materials[uri];
		}

		public Material createBitmapDataFromTexture(string uri, Texture tex)
		{
			Material material = new Material(baseBitmapShader);
			material.color = new Color(1f, 1f, 1f, 1f);
			material.name = uri;
			tex.name = uri;
			material.mainTexture = tex;
			materials[uri] = material;
			textures[uri] = tex;
			return material;
		}

		public static Vector2 MaterialPixelSpaceToUVSpace(Material mat, Vector2 xy)
		{
			Texture mainTexture = mat.mainTexture;
			if (mainTexture == null)
			{
				Debug.LogWarning("PixelSpaceToUVSpace FAILED, mainTexture is NULL");
				return xy;
			}
			return new Vector2(xy.x / (float)mainTexture.width, xy.y / (float)mainTexture.height);
		}

		public static Vector2 MaterialUVSpaceToPixelSpace(Material mat, Vector2 xy)
		{
			Texture mainTexture = mat.mainTexture;
			if (mainTexture == null)
			{
				Debug.LogWarning("PixelSpaceToUVSpace FAILED, mainTexture is NULL");
				return xy;
			}
			return new Vector2(xy.x * (float)mainTexture.width, xy.y * (float)mainTexture.height);
		}

		public static int upToPower2(int inX)
		{
			int num;
			for (num = 1; num < inX; num <<= 1)
			{
			}
			return num;
		}

		public static int downToPower2(int inX)
		{
			int num;
			for (num = upToPower2(inX); num > inX; num >>= 1)
			{
			}
			return num;
		}
	}
}
