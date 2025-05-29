using UnityEngine;

public class SessionGrid : Grid
{
	public SessionGrid(byte c35f98ccbfa8c6bf09319c620b21b5dc5)
		: base(c35f98ccbfa8c6bf09319c620b21b5dc5, Vector3.zero, Vector3.zero, false)
	{
	}

	public override bool c7b0b058a2e7a511d7cd616b4c33a62ca(Entity c5d720f6d007abb0c4a21d6a654e405bb)
	{
		return true;
	}

	public override bool cf94ef1195a047a80546a2686375e537a(Grid ccc05a501bdfe710a82b7969e7a7550dd)
	{
		return false;
	}
}
