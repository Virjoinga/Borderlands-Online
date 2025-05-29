using System;
using System.Collections.Generic;
using A;
using UnityEngine;

[ExecuteInEditMode]
public class CustomTerrainScriptColorMapUltra : MonoBehaviour
{
	public float SplattingDistance = 600f;

	public Texture2D CustomColorMap;

	public Texture2D TerrainNormalMap;

	public Texture2D SplatMap1;

	public Texture2D SplatMap2;

	public Color SpecularColor = Color.gray;

	public Texture2D customSplatMap1;

	public Texture2D customSplatMap2;

	public Texture2D blankTexture;

	public Color ColTex1 = Color.gray;

	public Color ColTex2 = Color.gray;

	public Color ColTex3 = Color.gray;

	public Color ColTex4 = Color.gray;

	public Color ColTex5 = Color.gray;

	public Color ColTex6 = Color.gray;

	public float Elev1 = 1f;

	public float Elev2 = 1f;

	public float Elev3 = 1f;

	public float Elev4 = 1f;

	public float Elev5 = 1f;

	public float Elev6 = 1f;

	public float MultiUv = 0.5f;

	public bool BlendMultiUv = true;

	public float DesMultiUvFac = 0.5f;

	public float SpecPower = 1f;

	public float Spec1 = 5f / 64f;

	public float Spec2 = 5f / 64f;

	public float Spec3 = 5f / 64f;

	public float Spec4 = 5f / 64f;

	public float Spec5 = 5f / 64f;

	public float Spec6 = 5f / 64f;

	public bool TerrainFresnel;

	public float FresnelIntensity = 1f;

	public float FresnelPower = 1f;

	public float FresnelBias = -0.5f;

	public Color ReflectionColor = Color.white;

	public bool AdvancedNormalBlending;

	public Texture2D SourceNormal1;

	public Texture2D SourceNormal2;

	public Texture2D SourceNormal3;

	public Texture2D SourceNormal4;

	public Texture2D SourceNormal5;

	public Texture2D SourceNormal6;

	public Texture2D CombinedNormal12;

	public Texture2D CombinedNormal34;

	public Texture2D CombinedNormal56;

	public float Decal1_ColorCorrectionStrenght = 0.5f;

	public float Decal2_ColorCorrectionStrenght = 0.5f;

	public float Decal1_Sharpness = 16f;

	public float Decal2_Sharpness = 16f;

	[HideInInspector]
	public bool showNewInspector = true;

	public List<Material> blendedMaterials = new List<Material>();

	[HideInInspector]
	public bool detailsIntro;

	[HideInInspector]
	public bool detailsBase = true;

	[HideInInspector]
	public bool detailsMultiuv;

	[HideInInspector]
	public bool detailsImportSplat = true;

	[HideInInspector]
	public bool detailsComNormals = true;

	[HideInInspector]
	public bool detailsCreateComNormals = true;

	[HideInInspector]
	public bool detailsColCor = true;

	[HideInInspector]
	public bool detailsSpecVal = true;

	[HideInInspector]
	public bool detailsMeshMat = true;

	private void Awake()
	{
		Terrain terrain = (Terrain)GetComponent(Type.GetTypeFromHandle(c9bfea17e5d4060b1822eba65fe846a73.cc1720d05c75832f704b87474932341c3()));
		terrain.basemapDistance = 100000f;
		cd40386c30fc2c3a4ef41bf42d49ab4f9();
	}

	private void Start()
	{
		Terrain terrain = (Terrain)GetComponent(Type.GetTypeFromHandle(c9bfea17e5d4060b1822eba65fe846a73.cc1720d05c75832f704b87474932341c3()));
		terrain.basemapDistance = 100000f;
		cd40386c30fc2c3a4ef41bf42d49ab4f9();
	}

	public void cd40386c30fc2c3a4ef41bf42d49ab4f9()
	{
		Terrain terrain = (Terrain)GetComponent(Type.GetTypeFromHandle(c9bfea17e5d4060b1822eba65fe846a73.cc1720d05c75832f704b87474932341c3()));
		float x = terrain.terrainData.size.x;
		if ((bool)CustomColorMap)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			Shader.SetGlobalTexture("_CustomColorMap", CustomColorMap);
		}
		if ((bool)TerrainNormalMap)
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
			Shader.SetGlobalTexture("_TerrainNormalMap", TerrainNormalMap);
		}
		if ((bool)SplatMap1)
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
			Shader.SetGlobalTexture("_Control", SplatMap1);
		}
		if ((bool)SplatMap2)
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
			Shader.SetGlobalTexture("_Control2nd", SplatMap2);
			if (blankTexture != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				UnityEngine.Object.DestroyImmediate(blankTexture, true);
			}
		}
		else
		{
			if (!blankTexture)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
				c1893d590383ca891ac19a808687efe31();
			}
			Shader.SetGlobalTexture("_Control2nd", blankTexture);
		}
		Shader.SetGlobalColor("_SpecularColor", SpecularColor);
		if ((bool)CombinedNormal12)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				break;
			}
			Shader.SetGlobalTexture("_CombinedNormal12", CombinedNormal12);
		}
		if ((bool)CombinedNormal34)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				break;
			}
			Shader.SetGlobalTexture("_CombinedNormal34", CombinedNormal34);
		}
		if ((bool)CombinedNormal56)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				break;
			}
			Shader.SetGlobalTexture("_CombinedNormal56", CombinedNormal56);
		}
		Shader.SetGlobalVector("_terrainCombinedFloats", new Vector4(MultiUv, DesMultiUvFac, SplattingDistance, SpecPower));
		if (BlendMultiUv)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				break;
			}
			Shader.EnableKeyword("USE_BLENDMULTIUV");
			Shader.DisableKeyword("USE_ADDDMULTIUV");
		}
		else
		{
			Shader.DisableKeyword("USE_BLENDMULTIUV");
			Shader.EnableKeyword("USE_ADDDMULTIUV");
		}
		if (TerrainFresnel)
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
			Shader.EnableKeyword("USE_FRESNEL");
			Shader.DisableKeyword("NO_FRESNEL");
		}
		else
		{
			Shader.EnableKeyword("NO_FRESNEL");
			Shader.DisableKeyword("USE_FRESNEL");
		}
		if (AdvancedNormalBlending)
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
			Shader.DisableKeyword("USE_STANDARDNORMALBLENDING");
			Shader.EnableKeyword("USE_ADVANCEDNORMALBLENDING");
		}
		else
		{
			Shader.EnableKeyword("USE_STANDARDNORMALBLENDING");
			Shader.DisableKeyword("USE_ADVANCEDNORMALBLENDING");
		}
		Shader.SetGlobalVector("_Elev", new Vector4(Elev1, Elev2, Elev3, Elev4));
		Shader.SetGlobalVector("_Elev1", new Vector4(Elev5, Elev6, 1f, 1f));
		Shader.SetGlobalFloat("_Spec1", Spec1);
		Shader.SetGlobalFloat("_Spec2", Spec2);
		Shader.SetGlobalFloat("_Spec3", Spec3);
		Shader.SetGlobalFloat("_Spec4", Spec4);
		Shader.SetGlobalFloat("_Spec5", Spec5);
		Shader.SetGlobalFloat("_Spec6", Spec6);
		Shader.SetGlobalVector("_Fresnel", new Vector4(FresnelIntensity, FresnelPower, FresnelBias, 0f));
		Shader.SetGlobalFloat("_Spec2", Spec2);
		Shader.SetGlobalFloat("_Spec3", Spec3);
		Shader.SetGlobalColor("_ReflectionColor", ReflectionColor);
		Shader.SetGlobalColor("_ColTex1", ColTex1);
		Shader.SetGlobalColor("_ColTex2", ColTex2);
		Shader.SetGlobalColor("_ColTex3", ColTex3);
		Shader.SetGlobalColor("_ColTex4", ColTex4);
		Shader.SetGlobalColor("_ColTex5", ColTex5);
		Shader.SetGlobalColor("_ColTex6", ColTex6);
		Shader.SetGlobalVector("_DecalCombinedFloats", new Vector4(Decal1_ColorCorrectionStrenght, Decal2_ColorCorrectionStrenght, Decal1_Sharpness, Decal2_Sharpness));
		for (int i = 0; i < terrain.terrainData.splatPrototypes.Length; i++)
		{
			Shader.SetGlobalTexture("_Splat" + i, terrain.terrainData.splatPrototypes[i].texture);
			Shader.SetGlobalFloat("_Splat" + i + "Tiling", x / terrain.terrainData.splatPrototypes[i].tileSize.x);
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	public void c1893d590383ca891ac19a808687efe31()
	{
		blankTexture = new Texture2D(64, 64, TextureFormat.ARGB32, true);
		blankTexture.name = "createBlankTexture_blankTexture";
		Color[] array = c9f85b5d461e935e3fe059d6462b10a03.c0a0cdf4a196914163f7334d9b0781a04(4096);
		Color color = new Color(0f, 0f, 0f, 0f);
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = color;
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			blankTexture.SetPixels(array, 0);
			blankTexture.Apply(false, true);
			return;
		}
	}
}
