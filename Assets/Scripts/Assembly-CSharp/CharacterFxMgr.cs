using System;
using System.Collections.Generic;
using A;
using Core;
using UnityEngine;

public class CharacterFxMgr
{
	public enum FX_TYPE
	{
		FX_FIRE = 0,
		FX_ELECTRIC = 1,
		FX_POISON = 2,
		FX_REVIVE = 3,
		FX_HUNTER_MARK = 4,
		FX_NUM = 5
	}

	public class FxPara
	{
		private Color mEffectColor;

		private Color mBlendPara;

		public FxPara(Color c2c8cd522b82315613d31b9fe7681d12b, Color cf702e01273c83e985d77b9b86b0672d4)
		{
			mEffectColor = c2c8cd522b82315613d31b9fe7681d12b;
			mBlendPara = cf702e01273c83e985d77b9b86b0672d4;
		}

		public Color ca6131082fcef8cf5e97b5772101f806f()
		{
			return mEffectColor;
		}

		public Color c7f91a925f6a1a150cb056338b13bbdcc()
		{
			return mBlendPara;
		}
	}

	private class CharacterEntity
	{
		private Entity mCharacter;

		private Utils.Timer mTimer;

		private CharacterFxMgr mFxMgr;

		private FX_TYPE m_type;

		private float m_duration;

		private List<Material> m_matList = new List<Material>();

		private static string m_name_defaultShader = "Custom/BOL_Charactor_BRDF";

		private static string m_name_effectShader = "Custom/BOL_Character_BRDF_WithHurtEffect";

		public CharacterEntity(CharacterFxMgr c2c9193f3eb2833f7f4cf7cdef720e3fc, Entity c7f0cb975fc308799d9e5fbea5bbae4f8, float cc38eba0587ccfea8f79928554ac7e78f, FX_TYPE c4b8b40b1ebdb4d69424a5e73de76f930)
		{
			mFxMgr = c2c9193f3eb2833f7f4cf7cdef720e3fc;
			mCharacter = c7f0cb975fc308799d9e5fbea5bbae4f8;
			mTimer = new Utils.Timer();
			mTimer.Start(cc38eba0587ccfea8f79928554ac7e78f);
			m_type = c4b8b40b1ebdb4d69424a5e73de76f930;
			m_duration = cc38eba0587ccfea8f79928554ac7e78f;
			if (m_type == FX_TYPE.FX_REVIVE)
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
						cb93c92195d19e4c4e0e42f71e8ecc591(true);
						return;
					}
				}
			}
			cbf4d8c527acdfb8d1863d7345eb87311(m_name_defaultShader);
			cbbc6a799c11aa08bf37e7db528ab120d();
		}

		private void cb93c92195d19e4c4e0e42f71e8ecc591(bool c38daa1ecfc4be57f0bab6f15b4488ecc)
		{
			if (mCharacter == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (4)
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
			CharacterEffectData component = (Resources.Load("Graphics/GraphicsData") as GameObject).GetComponent<CharacterEffectData>();
			Renderer[] componentsInChildren = mCharacter.GetComponentsInChildren<Renderer>();
			foreach (Renderer renderer in componentsInChildren)
			{
				if (!renderer)
				{
					continue;
				}
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
				for (int j = 0; j < renderer.materials.Length; j++)
				{
					Material material = renderer.materials[j];
					if (c38daa1ecfc4be57f0bab6f15b4488ecc)
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
						material.EnableKeyword("RESPAWN_ON");
						material.SetTexture("_RespawnTexture", component.mThirdPersonRespawnTexture);
						material.SetFloat("_RespawnStrength", component.mThirdPersonRespawnStrength);
						material.SetFloat("_RespawnSpeedU", component.mThirdPersonRespawnSpeedU);
						material.SetFloat("_RespawnSpeedV", component.mThirdPersonRespawnSpeedV);
					}
					else
					{
						material.DisableKeyword("RESPAWN_ON");
						material.SetTexture("_RespawnTexture", c7e1395dd376890f1113e22916ff9ac07.c7088de59e49f7108f520cf7e0bae167e);
						material.SetFloat("_RespawnStrength", 0f);
						material.SetFloat("_RespawnSpeedU", 0f);
						material.SetFloat("_RespawnSpeedV", 0f);
					}
				}
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
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

		public bool cc6c44508a047da266029850e43e5e0c2(Entity c4c05bc5fd4a142aaeafb039b130ba355)
		{
			if (c4c05bc5fd4a142aaeafb039b130ba355 == mCharacter)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						return true;
					}
				}
			}
			return false;
		}

		public bool c37d00ccb1f78a69f8ed99b3518d5a2c1()
		{
			return mTimer.cf928603d375f06225f9eb5213fb17bd4();
		}

		private void cbf4d8c527acdfb8d1863d7345eb87311(string cf6493bc8973218015779b7c362833024)
		{
			m_matList.Clear();
			if (mCharacter == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (1)
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
			Renderer[] componentsInChildren = mCharacter.GetComponentsInChildren<Renderer>();
			foreach (Renderer renderer in componentsInChildren)
			{
				if (!renderer)
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
					break;
				}
				for (int j = 0; j < renderer.materials.Length; j++)
				{
					Material material = renderer.materials[j];
					if (!(material.shader.name == cf6493bc8973218015779b7c362833024))
					{
						continue;
					}
					while (true)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						break;
					}
					m_matList.Add(material);
				}
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
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

		private void cb3a5d5004e6d5ecae023290aba072ffa(string c0db8bad76b7fbbdf3341c6537173568b, bool c3a5b232fa296b25f58f340ade58c34c2)
		{
			if (mCharacter == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (6)
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
			using (List<Material>.Enumerator enumerator = m_matList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					Material current = enumerator.Current;
					current.shader = Shader.Find(c0db8bad76b7fbbdf3341c6537173568b);
					if (!c3a5b232fa296b25f58f340ade58c34c2)
					{
						continue;
					}
					while (true)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						break;
					}
					c3438f8cd2b9d35b7420e6d0ee6dd08a8(current);
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
		}

		private void cbbc6a799c11aa08bf37e7db528ab120d()
		{
			cb3a5d5004e6d5ecae023290aba072ffa(m_name_effectShader, true);
		}

		public void c760434d5bc6eb3308436d24734255519()
		{
			if (m_type == FX_TYPE.FX_REVIVE)
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
						cb93c92195d19e4c4e0e42f71e8ecc591(false);
						return;
					}
				}
			}
			cf9c74788342bdfa3dda247b3f6020815();
		}

		private void cf9c74788342bdfa3dda247b3f6020815()
		{
			cb3a5d5004e6d5ecae023290aba072ffa(m_name_defaultShader, false);
		}

		private void c3438f8cd2b9d35b7420e6d0ee6dd08a8(Material c2d92018f60a097ee6949da5af2f1ab2d)
		{
			c2d92018f60a097ee6949da5af2f1ab2d.SetColor("_Attack_Color", mFxMgr.c874abf1cebf73b8b253992f74522f43b()[(int)m_type].ca6131082fcef8cf5e97b5772101f806f());
			c2d92018f60a097ee6949da5af2f1ab2d.SetTexture("_EmissUvAnimTex", mFxMgr.c846ab5a68ba7303b6260844e7eb80946());
			Color color = mFxMgr.c874abf1cebf73b8b253992f74522f43b()[(int)m_type].c7f91a925f6a1a150cb056338b13bbdcc();
			if (m_type == FX_TYPE.FX_REVIVE)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				color.r = 0f;
			}
			c2d92018f60a097ee6949da5af2f1ab2d.SetColor("_Attack_Para", color);
		}

		public void c94c4a3e2b27068abb12c8cf0c122dfdf()
		{
			if (m_type != FX_TYPE.FX_REVIVE)
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
				Color color = mFxMgr.c874abf1cebf73b8b253992f74522f43b()[(int)m_type].c7f91a925f6a1a150cb056338b13bbdcc();
				float r = color.r;
				float r2 = Mathf.Abs(Mathf.Sin((float)Math.PI * mTimer.c8d61bc457bf1e08126a3d9d2111b25df() * m_duration)) * r;
				color.r = r2;
				using (List<Material>.Enumerator enumerator = m_matList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Material current = enumerator.Current;
						current.SetColor("_Attack_Para", color);
					}
					while (true)
					{
						switch (5)
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

	private FxPara[] mFxParaArray;

	private List<CharacterEntity> mCharacterList;

	private Texture mUvAnimTex;

	public CharacterFxMgr()
	{
		mFxParaArray = new FxPara[5];
		mCharacterList = new List<CharacterEntity>();
	}

	public void ccc9d3a38966dc10fedb531ea17d24611()
	{
		CharacterEffectData component = (Resources.Load("Graphics/GraphicsData") as GameObject).GetComponent<CharacterEffectData>();
		if (!(component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			Color cf702e01273c83e985d77b9b86b0672d = new Color(component.mFireBlendPara, component.mSpeedX, component.mSpeedY);
			mFxParaArray[0] = new FxPara(component.mFireColor, cf702e01273c83e985d77b9b86b0672d);
			cf702e01273c83e985d77b9b86b0672d = new Color(component.mElectricPara, component.mSpeedX, component.mSpeedY);
			mFxParaArray[1] = new FxPara(component.mElectricColor, cf702e01273c83e985d77b9b86b0672d);
			cf702e01273c83e985d77b9b86b0672d = new Color(component.mPoisonPara, component.mSpeedX, component.mSpeedY);
			mFxParaArray[2] = new FxPara(component.mPoisonColor, cf702e01273c83e985d77b9b86b0672d);
			cf702e01273c83e985d77b9b86b0672d = new Color(component.mRevivePara, component.mSpeedX, component.mSpeedY);
			mFxParaArray[3] = new FxPara(component.mReviveColor, cf702e01273c83e985d77b9b86b0672d);
			cf702e01273c83e985d77b9b86b0672d = new Color(component.mHunterMarkPara, component.mSpeedX, component.mSpeedY);
			mFxParaArray[4] = new FxPara(component.mHunterMarkColor, cf702e01273c83e985d77b9b86b0672d);
			mUvAnimTex = component.mUvAnimTex;
			return;
		}
	}

	public FxPara[] c874abf1cebf73b8b253992f74522f43b()
	{
		return mFxParaArray;
	}

	public Texture c846ab5a68ba7303b6260844e7eb80946()
	{
		return mUvAnimTex;
	}

	public void ca0b9153d8ee5859976e87c76026dac7d(Entity ceea7ffac27989468f5cbbc023d783ec4, float cc38eba0587ccfea8f79928554ac7e78f, AttackInfo.ElementalType c11f5349fc6023cd49477c1013e34a7d3)
	{
		FX_TYPE fX_TYPE = FX_TYPE.FX_FIRE;
		switch (c11f5349fc6023cd49477c1013e34a7d3)
		{
		case AttackInfo.ElementalType.Fire:
			fX_TYPE = FX_TYPE.FX_FIRE;
			break;
		case AttackInfo.ElementalType.Shock:
			fX_TYPE = FX_TYPE.FX_ELECTRIC;
			break;
		case AttackInfo.ElementalType.Corrosive:
			fX_TYPE = FX_TYPE.FX_POISON;
			break;
		default:
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Graphics, "Unsupport fx effect!");
			return;
		}
		cd9568bf035fae5f39fd87a96cba69fa2(ceea7ffac27989468f5cbbc023d783ec4, cc38eba0587ccfea8f79928554ac7e78f, fX_TYPE);
	}

	public void cd9568bf035fae5f39fd87a96cba69fa2(Entity ceea7ffac27989468f5cbbc023d783ec4, float cc38eba0587ccfea8f79928554ac7e78f, FX_TYPE c4b8b40b1ebdb4d69424a5e73de76f930)
	{
		CharacterEntity item = new CharacterEntity(this, ceea7ffac27989468f5cbbc023d783ec4, cc38eba0587ccfea8f79928554ac7e78f, c4b8b40b1ebdb4d69424a5e73de76f930);
		mCharacterList.Add(item);
	}

	public void cddbb691fc8f8aca349591e50c2f98b80(Entity c4c05bc5fd4a142aaeafb039b130ba355)
	{
		for (int i = 0; i < mCharacterList.Count; i++)
		{
			CharacterEntity characterEntity = mCharacterList[i];
			if (!characterEntity.cc6c44508a047da266029850e43e5e0c2(c4c05bc5fd4a142aaeafb039b130ba355))
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
				break;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			characterEntity.c760434d5bc6eb3308436d24734255519();
			mCharacterList.Remove(characterEntity);
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

	public void Update()
	{
		for (int i = 0; i < mCharacterList.Count; i++)
		{
			CharacterEntity characterEntity = mCharacterList[i];
			if (characterEntity.c37d00ccb1f78a69f8ed99b3518d5a2c1())
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				characterEntity.c760434d5bc6eb3308436d24734255519();
				mCharacterList.Remove(characterEntity);
			}
			else
			{
				characterEntity.c94c4a3e2b27068abb12c8cf0c122dfdf();
			}
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}
}
