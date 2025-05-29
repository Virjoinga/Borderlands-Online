using UnityEngine;

[ExecuteInEditMode]
public class VPaintEditorBehaviour : MonoBehaviour
{
	public void OnEnable()
	{
		base.gameObject.hideFlags = HideFlags.HideInHierarchy;
	}
}
