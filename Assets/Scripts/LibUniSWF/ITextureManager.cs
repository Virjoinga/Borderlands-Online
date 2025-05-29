using UnityEngine;

public interface ITextureManager
{
	int getTotalTextures();

	void clearTextureCache();

	void clearTextureMatchingPrefix(string swfPrefix);

	Material getBitmapData(string uri);

	Material getBitmapDataFromSceneTexture(string uri, Texture tex);

	Material getBitmapData(AssetBundle assetBundle, string uri);

	Material createBitmapDataFromTexture(string uri, Texture tex);
}
