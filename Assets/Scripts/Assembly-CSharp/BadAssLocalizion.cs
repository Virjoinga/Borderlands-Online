using A;
using UnityEngine;

public class BadAssLocalizion : MonoBehaviour
{
	public enum BADASS_SUPPORTED_LANGUAGE
	{
		LANG_INT = 0,
		LANG_CHI = 1
	}

	private LocalizedStringManager _locStringMgr;

	private void Start()
	{
		_locStringMgr = new LocalizedStringManager();
		LocalizeSystem.c71f6ce28731edfd43c976fbd57c57bea().c4abf4b2a135ff23fb33a4355cec2a85c<LocalizedString>(_locStringMgr);
		LocalizeSystem.c71f6ce28731edfd43c976fbd57c57bea().cfc8ae7589bb86588d34a387a4dbf2280(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.m_language);
	}

	public void cfc8ae7589bb86588d34a387a4dbf2280(string cd3d074e2f700204b5e406a7161f3f5f9)
	{
		LocalizeSystem.c71f6ce28731edfd43c976fbd57c57bea().cfc8ae7589bb86588d34a387a4dbf2280(cd3d074e2f700204b5e406a7161f3f5f9);
	}
}
