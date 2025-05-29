using A;
using UnityEngine;

internal class BuildingKitTestScene : MonoBehaviour
{
	private void OnGUI()
	{
		GUI.enabled = true;
		GUILayout.BeginArea(new Rect(100f, 100f, 500f, 500f));
		GUILayoutOption[] array = c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = GUILayout.Width(500f);
		GUILayout.Box("Please enble #USING_BUILDINGKIT_TEST_SCENE", array);
		GUILayoutOption[] array2 = c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(1);
		array2[0] = GUILayout.Width(500f);
		GUILayout.Box("in BuildingKitTestScene.cs if you want to use", array2);
		GUILayoutOption[] array3 = c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(1);
		array3[0] = GUILayout.Width(500f);
		GUILayout.Box("BuildingKit Test Scene.", array3);
		GUILayout.EndArea();
	}
}
