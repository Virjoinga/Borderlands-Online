using UnityEngine;

public class MapObjectMark : MonoBehaviour
{
	public bool bAlwaysOnMap;

	[HideInInspector]
	public int iNPCID = -1;

	[HideInInspector]
	public int iCharacterID = -1;

	[SerializeField]
	public UIMapDataManager.MiniMapObjectType ObjType;

	private void OnEnable()
	{
		if (ObjType == UIMapDataManager.MiniMapObjectType.None)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			cd26ab2539c05dcb4fe11c30d0792cfaf();
			return;
		}
	}

	private void OnDisable()
	{
		UIMapDataManager.c71f6ce28731edfd43c976fbd57c57bea().cd327ead52a5b512b3dd6af488e444c9d(this);
	}

	public void cd26ab2539c05dcb4fe11c30d0792cfaf()
	{
		UIMapDataManager.c71f6ce28731edfd43c976fbd57c57bea().c0be9d40053ea381c1b1ba87562fdd043(this);
	}
}
