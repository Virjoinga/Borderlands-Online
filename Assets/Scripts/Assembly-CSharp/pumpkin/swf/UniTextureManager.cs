using A;
using Core;
using UnityEngine;

namespace pumpkin.swf
{
	public class UniTextureManager : ITextureManager
	{
		public static UniTextureManager instance;

		public UniTextureManager()
		{
			if (TextureManager.instance == null)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				new TextureManager();
			}
			instance = this;
		}

		public virtual Material getBitmapData(string uri)
		{
			if (!TextureManager.instance.materials.ContainsKey(uri))
			{
				goto IL_0075;
			}
			while (true)
			{
				switch (3)
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
			if (TextureManager.instance.materials.ContainsKey(uri))
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
				if (TextureManager.instance.materials[uri] == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						break;
					}
					goto IL_0075;
				}
			}
			goto IL_0167;
			IL_0075:
			if ((MovieClipPlayer.profilerSettings & MovieClipProfiler.TextureLoad) == MovieClipProfiler.TextureLoad)
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
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, "SwfProfile->TextureLoad: " + uri);
			}
			Texture texture = (Texture)Resources.Load("UI_uniSWF/SwfAssets/" + uri);
			if (texture == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				texture = Resources.Load<Texture>(uri);
			}
			if (texture == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, "Shit! Failed to load texture: " + uri);
					return null;
				}
			}
			Material material = new Material(TextureManager.baseBitmapShader);
			material.color = new Color(1f, 1f, 1f, 1f);
			material.name = uri;
			texture.name = uri;
			material.mainTexture = texture;
			TextureManager.instance.materials[uri] = material;
			TextureManager.instance.textures[uri] = texture;
			goto IL_0167;
			IL_0167:
			return TextureManager.instance.materials[uri];
		}

		public virtual void clearTextureCache()
		{
			TextureManager.instance.clearTextureCache();
		}

		public virtual void clearTextureMatchingPrefix(string swfPrefix)
		{
			TextureManager.instance.clearTextureMatchingPrefix(swfPrefix);
		}

		public virtual Material createBitmapDataFromTexture(string uri, Texture tex)
		{
			return TextureManager.instance.createBitmapDataFromTexture(uri, tex);
		}

		public virtual Material getBitmapData(AssetBundle assetBundle, string uri)
		{
			if (!TextureManager.instance.materials.ContainsKey(uri))
			{
				goto IL_0075;
			}
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
			if (TextureManager.instance.materials.ContainsKey(uri))
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
				if (TextureManager.instance.materials[uri] == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					goto IL_0075;
				}
			}
			goto IL_0154;
			IL_0075:
			if ((MovieClipPlayer.profilerSettings & MovieClipProfiler.TextureLoad) == MovieClipProfiler.TextureLoad)
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
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, "SwfProfile->TextureLoad: " + uri);
			}
			Texture texture = (Texture)assetBundle.Load(uri);
			if (texture == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
					array[0] = "Failed to load texture: ";
					array[1] = uri;
					array[2] = " from bundle: ";
					array[3] = assetBundle;
					DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.GUI, string.Concat(array));
					return null;
				}
			}
			Material material = new Material(TextureManager.baseBitmapShader);
			material.color = new Color(1f, 1f, 1f, 1f);
			material.name = uri;
			texture.name = uri;
			material.mainTexture = texture;
			TextureManager.instance.materials[uri] = material;
			TextureManager.instance.textures[uri] = texture;
			goto IL_0154;
			IL_0154:
			return TextureManager.instance.materials[uri];
		}

		public virtual Material getBitmapDataFromSceneTexture(string uri, Texture tex)
		{
			return TextureManager.instance.getBitmapDataFromSceneTexture(uri, tex);
		}

		public virtual int getTotalTextures()
		{
			return TextureManager.instance.getTotalTextures();
		}
	}
}
