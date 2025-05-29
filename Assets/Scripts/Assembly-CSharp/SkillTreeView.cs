using System.Collections.Generic;
using A;
using XsdSettings;

public class SkillTreeView : BaseView
{
	protected XsdSettings.SkillTree _skillTreeData;

	protected int _iCharacterID;

	protected int _iEarnedPt;

	protected int _iUnspentPt;

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().cbfdeda957ab87de3d0acf25194e61c4c(this);
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c914f3898d0cb85fdb88383c5a243cded(this);
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c3ee3ae9c8e9d7863fc24390827b6193f(this, "UISkillTree");
		SkillTreeDataManager.c71f6ce28731edfd43c976fbd57c57bea().ce299e6d366e2dbedce1e85e4f5aaedf8(ca866bdd6da64f9816094fec0e01d7ecc);
		SkillTreeDataManager.c71f6ce28731edfd43c976fbd57c57bea().c39e911336cb557f0eec128814bdf7728(c91b0bad551b5877ac848dcbffd1fcd76);
		_skillTreeData = SkillTreeDataManager.c71f6ce28731edfd43c976fbd57c57bea().c08678cb5a9f2ec077be4dd868efd1453;
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().cee8cde4410c30a1ff6fab848a28cf88f(this, string.Empty);
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().cfdafa122fc114376585cbb27b8811a86(this);
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c0f8db058f30b85298d876c68b2ca7053(this);
		SkillTreeDataManager.c71f6ce28731edfd43c976fbd57c57bea().c813c04cff18bcb0a23378cfc5a4c4e9a(ca866bdd6da64f9816094fec0e01d7ecc);
		SkillTreeDataManager.c71f6ce28731edfd43c976fbd57c57bea().c47e881bbdb23d9f2d20b66a55626b570(c91b0bad551b5877ac848dcbffd1fcd76);
	}

	protected virtual void cfe214abf428181629c26312b09c426cd(List<InvestedSkill> c2a84e1af1999f8830e06d6fd6cb8ebb9)
	{
	}

	protected virtual void c9f0fdb45a77c27d9088ce909195d9b3b(int c37c8cc761dd6f739a4c896e64e44fdd5, int c43c216df6aadde10be3f9bdf566009ca)
	{
	}

	protected void ca866bdd6da64f9816094fec0e01d7ecc(List<InvestedSkill> c2a84e1af1999f8830e06d6fd6cb8ebb9)
	{
		cfe214abf428181629c26312b09c426cd(c2a84e1af1999f8830e06d6fd6cb8ebb9);
	}

	protected void c91b0bad551b5877ac848dcbffd1fcd76(int c37c8cc761dd6f739a4c896e64e44fdd5, int c43c216df6aadde10be3f9bdf566009ca)
	{
		c9f0fdb45a77c27d9088ce909195d9b3b(c37c8cc761dd6f739a4c896e64e44fdd5, c43c216df6aadde10be3f9bdf566009ca);
	}

	public virtual void c14b12898fa8e71d52bd003cdc77e9d5d()
	{
		c150264a18c2cb408479d3f072cac8cc1 = !_bVisible;
	}

	protected virtual void cab3d64fce75ee3fef1f99660a92504f4()
	{
		SkillTreeDataManager.c71f6ce28731edfd43c976fbd57c57bea().c1c15f3fcf8a83518063cfbba8d5b51fc();
	}

	public virtual void cb2129d5ac409250d4c0820338b1540f1(int c1bbe7ac27bc57192b9ca7f2cd055cabd)
	{
		SkillTreeDataManager.c71f6ce28731edfd43c976fbd57c57bea().cb2129d5ac409250d4c0820338b1540f1(c1bbe7ac27bc57192b9ca7f2cd055cabd);
	}

	public override bool cc130a2d46a451dc54b61a8f0d60794ae()
	{
		if (c150264a18c2cb408479d3f072cac8cc1)
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
					c150264a18c2cb408479d3f072cac8cc1 = false;
					return true;
				}
			}
		}
		return base.cc130a2d46a451dc54b61a8f0d60794ae();
	}
}
