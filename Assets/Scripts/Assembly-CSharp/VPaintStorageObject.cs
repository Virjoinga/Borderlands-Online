using UnityEngine;
using Valkyrie.VPaint;

public class VPaintStorageObject : ScriptableObject, IVPaintIdentifier
{
	public virtual void OnEnable()
	{
		base.hideFlags = HideFlags.HideInHierarchy;
	}

	public virtual bool IsEqualTo(IVPaintIdentifier obj)
	{
		return false;
	}
}
