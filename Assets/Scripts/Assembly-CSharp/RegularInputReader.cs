using UnityEngine;

public class RegularInputReader : InputReader
{
	public override bool c7757051abb1c6405db9836fc93b27b1e(KeyCode c212885fdedb9b9fd5818b72e1ba772cf)
	{
		return Input.GetKey(c212885fdedb9b9fd5818b72e1ba772cf);
	}

	public override bool c7757051abb1c6405db9836fc93b27b1e(string cd99af21e22e356018b8f72d4a7e4872a)
	{
		return Input.GetKey(cd99af21e22e356018b8f72d4a7e4872a);
	}

	public override bool cbf1d27094f0bbdacb081739b10f4671c(KeyCode c212885fdedb9b9fd5818b72e1ba772cf)
	{
		return Input.GetKeyDown(c212885fdedb9b9fd5818b72e1ba772cf);
	}

	public override bool cbf1d27094f0bbdacb081739b10f4671c(string cd99af21e22e356018b8f72d4a7e4872a)
	{
		return Input.GetKeyDown(cd99af21e22e356018b8f72d4a7e4872a);
	}

	public override bool cd506b2de8384c3adbc5bfedd9c774b24(KeyCode c212885fdedb9b9fd5818b72e1ba772cf)
	{
		return Input.GetKeyUp(c212885fdedb9b9fd5818b72e1ba772cf);
	}

	public override float c8bb22a671c1c2a7c9a01ddc52a812d1d(string cdede8dea77bdda30136ed53c84c3b635)
	{
		return Input.GetAxis(cdede8dea77bdda30136ed53c84c3b635);
	}

	public override bool c0c86fb4d044c654b1e26019953887548(string ca101d1eb40817eb56dc49d01603ee9aa)
	{
		return Input.GetButton(ca101d1eb40817eb56dc49d01603ee9aa);
	}

	public override bool cd9a869e29c4cce44fbee025f63774fa9(string ca101d1eb40817eb56dc49d01603ee9aa)
	{
		return Input.GetButtonDown(ca101d1eb40817eb56dc49d01603ee9aa);
	}

	public override bool c335a1480fba59f7a546ea6803a9374b9(string ca101d1eb40817eb56dc49d01603ee9aa)
	{
		return Input.GetButtonUp(ca101d1eb40817eb56dc49d01603ee9aa);
	}

	public override bool cf444c2ed32312476a266d34e37bfd02f(int cc5b2a83f0ff489309eb5bc89970fb973, bool cb4545d0934b9eb94d684000578dcd1ac = false)
	{
		return Input.GetMouseButton(cc5b2a83f0ff489309eb5bc89970fb973);
	}

	public override bool ca561485909b8620867b83991201b70d3(int cc5b2a83f0ff489309eb5bc89970fb973, bool cb4545d0934b9eb94d684000578dcd1ac = false)
	{
		return Input.GetMouseButtonDown(cc5b2a83f0ff489309eb5bc89970fb973);
	}

	public override bool c5adfffc6150c77758b5ca44b059aee74(int cc5b2a83f0ff489309eb5bc89970fb973, bool cb4545d0934b9eb94d684000578dcd1ac = false)
	{
		return Input.GetMouseButtonUp(cc5b2a83f0ff489309eb5bc89970fb973);
	}
}
