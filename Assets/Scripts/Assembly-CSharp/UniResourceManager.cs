using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using A;
using Core;
using UnityEngine;
using pumpkin.display;
using pumpkin.swf;

public class UniResourceManager : c06ca0e618478c23eba3419653a19760f<UniResourceManager>
{
	private static UniResourceManager mResourceManager;

	private BadAssSWFResourceLoader mLoader;

	public BadAssSWFResourceLoader c4f968fce1aac9ab6a4eedf95fca4e6c9
	{
		get
		{
			return mLoader;
		}
	}

	private UniResourceManager()
	{
		mLoader = new BadAssSWFResourceLoader();
		new UniTextureManager();
	}

	public static UniResourceManager c562b279001b7d601417aecb2d2bdf748()
	{
		if (mResourceManager == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			mResourceManager = new UniResourceManager();
		}
		return mResourceManager;
	}

	public bool c72c7b4e5b823691629fab59201f0926f(string c753f9e9d7f9594352d1811715eb8d1dc)
	{
		StringBuilder stringBuilder = new StringBuilder(c753f9e9d7f9594352d1811715eb8d1dc);
		if (c753f9e9d7f9594352d1811715eb8d1dc.EndsWith(".assetbundle"))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			stringBuilder.Replace(".assetbundle", ".swf");
		}
		stringBuilder.Replace("uniswf_", string.Empty);
		for (int i = 0; i < mLoader.bundles.Count; i++)
		{
			if (!(mLoader.bundles[i] != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
			{
				continue;
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
			if (string.Compare(mLoader.bundles[i].mainAsset.name, stringBuilder.ToString(), true) != 0)
			{
				continue;
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				return true;
			}
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			return false;
		}
	}

	public void c1f36dd5e4264f714825df99e8cfacb93(string c753f9e9d7f9594352d1811715eb8d1dc)
	{
		if (!c573028942aaec87e6260cd05458a7e86(c753f9e9d7f9594352d1811715eb8d1dc))
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return;
				}
			}
		}
		if (!c753f9e9d7f9594352d1811715eb8d1dc.EndsWith(".assetbundle"))
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
			c753f9e9d7f9594352d1811715eb8d1dc += ".assetbundle";
		}
		InGameAssetBundle inGameAssetBundle = (InGameAssetBundle)c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.cc287004e3f873904ffcdfe194323b23f(c753f9e9d7f9594352d1811715eb8d1dc);
		if (inGameAssetBundle == null)
		{
			return;
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			mLoader.addAssetBundle(inGameAssetBundle.m_www.assetBundle);
			return;
		}
	}

	public void c7646b1aba345328d016fc76bdce9d560(AssetBundle c55644b999838f2d90a4ea87f98774f18)
	{
		if (!c573028942aaec87e6260cd05458a7e86(c55644b999838f2d90a4ea87f98774f18.name))
		{
			return;
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			mLoader.addAssetBundle(c55644b999838f2d90a4ea87f98774f18);
			return;
		}
	}

	public void ced4764550eac3f0cbafb4077c70dc371(string[] c54dbf21f7f9809407810d2ac4b193f9e)
	{
		for (int i = 0; i < c54dbf21f7f9809407810d2ac4b193f9e.Length; i++)
		{
			c1f36dd5e4264f714825df99e8cfacb93(c54dbf21f7f9809407810d2ac4b193f9e[i]);
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			return;
		}
	}

	public void ced4764550eac3f0cbafb4077c70dc371(AssetBundle[] c6e9249262fda0f2d4037fd8de12f0ccd)
	{
		for (int i = 0; i < c6e9249262fda0f2d4037fd8de12f0ccd.Length; i++)
		{
			c7646b1aba345328d016fc76bdce9d560(c6e9249262fda0f2d4037fd8de12f0ccd[i]);
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			return;
		}
	}

	public void c70b22c09cdc3ef99f97282d52b3acf62()
	{
		int count = c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.c2db49eb57b860f27c56d506da7c57f6d.Count;
		for (int i = 0; i < count; i++)
		{
			c1f36dd5e4264f714825df99e8cfacb93(c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.c2db49eb57b860f27c56d506da7c57f6d.ElementAt(i).Key);
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			return;
		}
	}

	private bool c573028942aaec87e6260cd05458a7e86(string c33110cb255eb6793a8dafcf47d69f543)
	{
		if (!c33110cb255eb6793a8dafcf47d69f543.StartsWith("uniswf_"))
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return false;
				}
			}
		}
		return !c72c7b4e5b823691629fab59201f0926f(c33110cb255eb6793a8dafcf47d69f543);
	}

	public void c8070b73e525959b9db0f2afe7e0894dc(AssetBundle c55644b999838f2d90a4ea87f98774f18)
	{
		mLoader.removeOnlyAssetBundle(c55644b999838f2d90a4ea87f98774f18);
	}

	public void c48e1453cceb6aadac64f47c441c1f427(string c5fe690777bf5dec9374fa61ab6703175)
	{
		if (!c72c7b4e5b823691629fab59201f0926f(c5fe690777bf5dec9374fa61ab6703175))
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return;
				}
			}
		}
		for (int i = 0; i < mLoader.bundles.Count; i++)
		{
			if (!(mLoader.bundles[i].mainAsset.name == c5fe690777bf5dec9374fa61ab6703175))
			{
				continue;
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				c8070b73e525959b9db0f2afe7e0894dc(mLoader.bundles[i]);
				return;
			}
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	public void cea5c2d566a3e46af584ab102342cab5a(string[] c54dbf21f7f9809407810d2ac4b193f9e)
	{
		for (int i = 0; i < c54dbf21f7f9809407810d2ac4b193f9e.Length; i++)
		{
			if (string.IsNullOrEmpty(c54dbf21f7f9809407810d2ac4b193f9e[i]))
			{
				continue;
			}
			while (true)
			{
				switch (2)
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
			c48e1453cceb6aadac64f47c441c1f427(c54dbf21f7f9809407810d2ac4b193f9e[i]);
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	public void ce6106566ea862da64238f154db641dac()
	{
		string[] array = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(mLoader.bundles.Count);
		for (int i = 0; i < mLoader.bundles.Count; i++)
		{
			if (mLoader.bundles[i] != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (mLoader.bundles[i].mainAsset != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					array[i] = mLoader.bundles[i].mainAsset.name;
					continue;
				}
			}
			array[i] = string.Empty;
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.GUI, "In RemoveAllAssetbundle, mLoader.bundles[index] is null");
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				continue;
			}
			cea5c2d566a3e46af584ab102342cab5a(array);
			return;
		}
	}

	public MovieClip c62489bc2bccb34a700c765f20e507ead(string c5fe690777bf5dec9374fa61ab6703175)
	{
		MovieClip result = c656b7be10c614ae4a7eb17c462d2f675.c7088de59e49f7108f520cf7e0bae167e;
		string c753f9e9d7f9594352d1811715eb8d1dc = c5fe690777bf5dec9374fa61ab6703175.Substring(0, c5fe690777bf5dec9374fa61ab6703175.IndexOf(".")) + ".swf";
		if (c72c7b4e5b823691629fab59201f0926f(c753f9e9d7f9594352d1811715eb8d1dc))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			result = new BadAssMovieClip(mLoader, c5fe690777bf5dec9374fa61ab6703175);
		}
		return result;
	}

	public IEnumerator ce4bd36f73dbe7cc7c7e521056b6cbcc6(string c5fe690777bf5dec9374fa61ab6703175)
	{
		string strAssetbundleName = "uniswf_" + c5fe690777bf5dec9374fa61ab6703175.Substring(0, c5fe690777bf5dec9374fa61ab6703175.IndexOf(".")) + ".assetbundle";
		if (!c72c7b4e5b823691629fab59201f0926f(strAssetbundleName))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			yield return StartCoroutine(c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.c38aeacc59bd560b59403945ae7996d79(strAssetbundleName));
			while (!c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.c65c2e0643566a30963cf509aec1dbee7(strAssetbundleName))
			{
				yield return c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e;
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				break;
			}
			c1f36dd5e4264f714825df99e8cfacb93(strAssetbundleName);
		}
		yield return c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e;
	}

	public void cf7bb4834a40d20c49e6c144062b5916b(string c5fe690777bf5dec9374fa61ab6703175)
	{
		if (!mLoader.unloadSWF(c5fe690777bf5dec9374fa61ab6703175))
		{
			return;
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			Dictionary<string, Material>.Enumerator enumerator = TextureManager.instance.materials.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (!enumerator.Current.Key.StartsWith(c5fe690777bf5dec9374fa61ab6703175))
				{
					continue;
				}
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
				Object.Destroy(enumerator.Current.Value);
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				Dictionary<string, Texture>.Enumerator enumerator2 = TextureManager.instance.textures.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					if (!enumerator2.Current.Key.StartsWith(c5fe690777bf5dec9374fa61ab6703175))
					{
						continue;
					}
					while (true)
					{
						switch (5)
						{
						case 0:
							continue;
						}
						break;
					}
					Resources.UnloadAsset(enumerator2.Current.Value);
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
		}
	}
}
