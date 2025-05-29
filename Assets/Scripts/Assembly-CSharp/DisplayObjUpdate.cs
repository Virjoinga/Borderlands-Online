using System;
using A;
using UnityEngine;

public class DisplayObjUpdate : MonoBehaviour
{
	private bool mNeedShaderModify;

	private float mBrdfPara;

	private Renderer m_render;

	private void Start()
	{
		mNeedShaderModify = false;
		Shader shader = Shader.Find("Custom/BOL_Charactor_BRDF");
		m_render = (Renderer)base.gameObject.GetComponent(Type.GetTypeFromHandle(c1e516986f72a006d858f0218621fc458.cc1720d05c75832f704b87474932341c3()));
		if ((bool)m_render)
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
			Material material = m_render.material;
			if (shader == material.shader)
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
				mNeedShaderModify = true;
				mBrdfPara = material.GetFloat("_BRDF_PARA");
			}
		}
		if (!c06ca0e618478c23eba3419653a19760f<VisibilityManager>.c5ee19dc8d4cccf5ae2de225410458b86)
		{
			return;
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				continue;
			}
			c06ca0e618478c23eba3419653a19760f<VisibilityManager>.c5ee19dc8d4cccf5ae2de225410458b86.c57e4d4cd41f3be21d7e24a71aa08c6ba(m_render);
			return;
		}
	}

	private void OnDestroy()
	{
		if (!c06ca0e618478c23eba3419653a19760f<VisibilityManager>.c5ee19dc8d4cccf5ae2de225410458b86)
		{
			return;
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
			c06ca0e618478c23eba3419653a19760f<VisibilityManager>.c5ee19dc8d4cccf5ae2de225410458b86.cf5212e6903ec0c0b27816142c32a2d13(m_render);
			return;
		}
	}

	private void OnWillRenderObject()
	{
		if (!mNeedShaderModify)
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
			if (!c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86)
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
				c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.c04af773a558b79f50ffd46b6d46137d0(base.gameObject, mBrdfPara);
				return;
			}
		}
	}
}
