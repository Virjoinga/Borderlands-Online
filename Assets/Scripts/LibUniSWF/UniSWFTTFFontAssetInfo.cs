using UnityEngine;

public class UniSWFTTFFontAssetInfo : ScriptableObject
{
	public Font unityFont;

	public int ascender = 2048;

	public int unitsPerEM = 2048;

	public FTKerningInfo[] kerning;
}
