using System;
using System.Collections;
using System.Text;
using A;
using Core;
using UnityEngine;
using XsdSettings;

public class LoadingImgController : MonoBehaviour
{
	[Serializable]
	public class LoadingResource
	{
		public string strTitleImgName = string.Empty;

		public string strBGImgFolderName = string.Empty;

		public int iPlayListID;
	}

	public const string Path_LOADING_IN_ASSETS = "Assets/ArtResources/UI/Textures/";

	public int _RowCount;

	public int _ColumnCount;

	public int _TotalTipsCount = 46;

	protected int _iCurPercent;

	public string LoadingTipsKeyPrefix = "Loading_Tips_";

	public string LoadingBundlePrefix = "loading_";

	public string TGA_Prefix = "GUI_Loading_";

	public int LoadingTipsFontSize = 16;

	public string BGImgPath;

	public string TitleImgPath;

	protected string _strLoadingTips;

	protected Transform _progressBar;

	protected Transform _progressBarTrack;

	protected float _progressWidth;

	protected float _progressMargin;

	protected float _progressOriginalScale;

	protected TextMesh _textMS;

	protected Material m_instanceNameMaterial;

	protected Material m_backgroungMaterial;

	public LoadingResource[] _LoadingResouce;

	private GameObject[] _brushArray;

	private GameObject _instanceNamePlane;

	private GameObject _instanceBGPlane;

	protected int _totalBrushCount;

	protected int _iResouceIndex;

	protected int _iInstanceID;

	protected string _bundleName;

	private void OnDestroy()
	{
		Texture texture = m_instanceNameMaterial.GetTexture("_MainTex");
		if (texture != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			Resources.UnloadAsset(texture);
		}
		Texture texture2 = m_backgroungMaterial.GetTexture("_MainTex");
		if (!(texture2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			Resources.UnloadAsset(texture2);
			return;
		}
	}

	private void Start()
	{
		_progressBar = base.transform.FindChild("InstanceLoadingBar");
		_progressBarTrack = base.transform.FindChild("InstanceLoadingBarBG");
		_progressWidth = _progressBarTrack.GetComponent<MeshRenderer>().bounds.extents.x * 2f;
		_progressMargin = _progressWidth * 0.5f - _progressBar.GetComponent<MeshRenderer>().bounds.extents.x;
		_progressOriginalScale = _progressBar.localScale.x;
		_progressBar.localScale = new Vector3(0f, _progressBar.localScale.y, _progressBar.localScale.z);
		_textMS = base.gameObject.GetComponentInChildren<TextMesh>();
		_textMS.text = "0 %";
		_totalBrushCount = 10;
		_brushArray = cc918c40632f876558345d2b35eb025ba.c0a0cdf4a196914163f7334d9b0781a04(_totalBrushCount);
		Shader shader = Shader.Find("Transparent/Cutout/Soft Edge Unlit");
		_instanceNamePlane = GameObject.Find("LoadingPageScreenshotPoly_Title");
		m_instanceNameMaterial = new Material(shader);
		_instanceNamePlane.renderer.material = m_instanceNameMaterial;
		_instanceBGPlane = GameObject.Find("PlaneContainer/Plane_1");
		for (int i = 1; i <= _totalBrushCount; i++)
		{
			string text;
			if (i < 10)
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
				text = "0" + i;
			}
			else
			{
				text = i.ToString();
			}
			string text2 = text;
			string text3 = "Brush" + text2;
			GameObject gameObject = GameObject.Find(text3);
			if (gameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.GUI, "Object not found : " + text3);
			}
			_brushArray[i - 1] = gameObject;
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			if (_iResouceIndex >= 0)
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
				if (_iResouceIndex < _LoadingResouce.Length)
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
					string strTitleImgName = _LoadingResouce[_iResouceIndex].strTitleImgName;
					if (strTitleImgName == null)
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
						DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.GUI, "Instance Name not set : Instance " + _iResouceIndex);
					}
					TitleImgPath += strTitleImgName;
					Texture texture = (Texture)Resources.Load(TitleImgPath);
					m_instanceNameMaterial.SetTexture("_MainTex", texture);
					m_instanceNameMaterial.SetFloat("_TextureAlpha", 1f);
				}
			}
			bool flag = false;
			Playlist playlist = MatchmakingService.c5ee19dc8d4cccf5ae2de225410458b86.c2718b579e09549a1cd47620188a40a38(_iInstanceID);
			if (playlist != null)
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
				GamemodeType c7c285f21497bec76d425ba4a0a524b = MatchmakingService.c6921a12df59fc1206bd8bea12427f9af(playlist.m_gameMode);
				flag = MatchmakingService.c28b45877056e09d3c4d6fa790a1517aa(c7c285f21497bec76d425ba4a0a524b);
			}
			StringBuilder stringBuilder = new StringBuilder(LoadingTipsKeyPrefix);
			if (!flag)
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
				int num = UnityEngine.Random.Range(1, _TotalTipsCount + 1);
				if (num < 10)
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
					stringBuilder.Append("00").Append(num);
				}
				else if (num < 100)
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
					stringBuilder.Append("0").Append(num);
				}
				else
				{
					stringBuilder.Append(num);
				}
			}
			else
			{
				stringBuilder.Append("047");
			}
			_strLoadingTips = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString(stringBuilder.ToString()));
			base.transform.FindChild("Tips").GetComponent<TextMesh>().text = _strLoadingTips;
			StartCoroutine(c08335995275bf27f028227ac515a6bc3());
			return;
		}
	}

	public IEnumerator c08335995275bf27f028227ac515a6bc3()
	{
		string strBGImgFolderName = _LoadingResouce[_iResouceIndex].strBGImgFolderName;
		if (strBGImgFolderName == null)
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.GUI, "Empty instance name : instance " + _iResouceIndex);
					yield break;
				}
			}
		}
		_bundleName = LoadingBundlePrefix + strBGImgFolderName.ToLower() + ".assetbundle";
		yield return StartCoroutine(c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.c38aeacc59bd560b59403945ae7996d79(_bundleName, null, null, true));
		while (!c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.c65c2e0643566a30963cf509aec1dbee7(_bundleName))
		{
			yield return c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e;
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			Texture planeTexture = c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.ca587b9b39577370b2b93809ea02165bc(_bundleName) as Texture;
			m_backgroungMaterial = _instanceBGPlane.renderer.material;
			m_backgroungMaterial.mainTexture = planeTexture;
			_instanceBGPlane.renderer.material = m_backgroungMaterial;
			yield break;
		}
	}

	public void ca7765b30cae35487f51439575e903113(int cb021b8a5d8db4c91103982f1581f8fea)
	{
		for (int i = 0; i < _LoadingResouce.Length; i++)
		{
			if (_LoadingResouce[i].iPlayListID != cb021b8a5d8db4c91103982f1581f8fea)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				_iResouceIndex = i;
				return;
			}
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			_iInstanceID = cb021b8a5d8db4c91103982f1581f8fea;
			return;
		}
	}

	public void c8088eb10c995e36c82e819b6f8c6a424(float c0764f2d5a4333ea4b1f3360f2f949051)
	{
		if (c0764f2d5a4333ea4b1f3360f2f949051 < 0f)
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.GUI, "Progress percent over range");
					return;
				}
			}
		}
		float num = c0764f2d5a4333ea4b1f3360f2f949051 * 100f / 90f;
		int num2 = Mathf.FloorToInt((float)_totalBrushCount * num);
		if (num2 > 10)
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
			num2 = 10;
		}
		for (int i = 0; i < num2; i++)
		{
			_brushArray[i].SetActive(false);
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			if (num2 != _totalBrushCount)
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
				c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.c023f6d02221ee56c20921f9cd2e22441(_bundleName);
				return;
			}
		}
	}

	private void Update()
	{
		float num = c06ca0e618478c23eba3419653a19760f<LevelLoadingManager>.c5ee19dc8d4cccf5ae2de225410458b86.c0a687459ceef442f37c4d398cb12f99f();
		int num2 = (int)(num * 100f);
		if (num2 == 0)
		{
			return;
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			_iCurPercent = num2;
			c8088eb10c995e36c82e819b6f8c6a424(num);
			cb4e12194d6fcddccde0c710ac7da1156(num);
			return;
		}
	}

	private void cb4e12194d6fcddccde0c710ac7da1156(float c0764f2d5a4333ea4b1f3360f2f949051)
	{
		if (_progressBar != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			_progressBar.localScale = new Vector3(_progressOriginalScale * c0764f2d5a4333ea4b1f3360f2f949051, _progressBar.localScale.y, _progressBar.localScale.z);
			float x = _progressBar.GetComponent<MeshRenderer>().bounds.extents.x;
			_progressBar.localPosition = new Vector3(_progressMargin + _progressBarTrack.localPosition.x - _progressWidth * 0.5f + x, _progressBar.localPosition.y, _progressBar.localPosition.z);
		}
		if (!(_textMS != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
		{
			return;
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			_textMS.text = _iCurPercent + " %";
			return;
		}
	}
}
