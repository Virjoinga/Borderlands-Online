using System;
using System.Collections;
using A;
using UnityEngine;

public class AvatarElement
{
	public string m_materialName;

	public string m_bundleName;

	public Material m_externalMaterial;

	private AssetBundleRequest m_gameObjectRequest;

	private AssetBundleRequest m_materialRequest;

	private AssetBundleRequest m_boneNameRequest;

	public AvatarElement(string ccc3a743cfeeaa8212871445f2d92eb9a = null, string cdfad4ba0a55425109c91f87781d91a4f = null, Material c9b18cd1a7afd4015684e3d8e96d3786c = null)
	{
		m_materialName = cdfad4ba0a55425109c91f87781d91a4f;
		m_bundleName = ccc3a743cfeeaa8212871445f2d92eb9a;
		m_externalMaterial = c9b18cd1a7afd4015684e3d8e96d3786c;
	}

	public IEnumerator c0b5d3d482d60c5a27fcad8cb250dff45()
	{
		m_gameObjectRequest = c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.cc287004e3f873904ffcdfe194323b23f(m_bundleName).ce2bd12bfa7577675b369574fae296f5d("rendererobject", Type.GetTypeFromHandle(cc30ad18d9004f6c9825d2221f535b10a.cc1720d05c75832f704b87474932341c3()));
		yield return m_gameObjectRequest;
		if (!m_externalMaterial)
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
			m_materialRequest = c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.cc287004e3f873904ffcdfe194323b23f(m_bundleName).ce2bd12bfa7577675b369574fae296f5d(m_materialName, Type.GetTypeFromHandle(cbb7eb9da7b34ed2d998f9a826f2af269.cc1720d05c75832f704b87474932341c3()));
			yield return m_materialRequest;
		}
		m_boneNameRequest = c06ca0e618478c23eba3419653a19760f<AssetBundleManager>.c5ee19dc8d4cccf5ae2de225410458b86.cc287004e3f873904ffcdfe194323b23f(m_bundleName).ce2bd12bfa7577675b369574fae296f5d("bonenames", Type.GetTypeFromHandle(c17ff91b1b18cad985dc783638b7c9d87.cc1720d05c75832f704b87474932341c3()));
		yield return m_boneNameRequest;
	}

	public SkinnedMeshRenderer c16f1782edb3f3dcef9e705f27c2b3cbc()
	{
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(m_gameObjectRequest.asset);
		if ((bool)m_externalMaterial)
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
			gameObject.renderer.material = m_externalMaterial;
		}
		else
		{
			gameObject.renderer.material = (Material)m_materialRequest.asset;
		}
		return (SkinnedMeshRenderer)gameObject.renderer;
	}

	public string[] c673227b85e92101ae640db66607e2f41()
	{
		StringHolder stringHolder = (StringHolder)m_boneNameRequest.asset;
		return stringHolder.m_content;
	}
}
