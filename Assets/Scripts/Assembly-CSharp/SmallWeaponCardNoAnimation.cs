public class SmallWeaponCardNoAnimation : SmallWeaponCardPanel
{
	protected override void c969016383f47c249932cc75475f00ae1()
	{
		base.c969016383f47c249932cc75475f00ae1();
		mcRootRoot = mcSelf;
		mcRootRoot.stopAll();
		mcSelf.visible = true;
	}

	public override void c58de56793cb96a279858c7b68a326d17(WeaponDNA c32fb601f955251e397f3d29075f51208, WeaponDNA c04d182ebd13b8bf7e53d75bb60be41b1 = null)
	{
		base.c58de56793cb96a279858c7b68a326d17(c32fb601f955251e397f3d29075f51208, c04d182ebd13b8bf7e53d75bb60be41b1);
	}

	protected override void c1c3ee76beeceed832634f5603084d7a2()
	{
		mcRoot = mcSelf;
	}
}
