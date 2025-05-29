using System;
using A;

[Serializable]
public class ShaderProperty
{
	public ShaderPropertyType mType;

	public string mName;

	public string mDesc;

	public string mValue;

	public ShaderProperty()
	{
		mType = ShaderPropertyType.Float;
		mName = (mDesc = string.Empty);
		mValue = c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e;
	}

	public ShaderProperty(ShaderPropertyType inType, string inName, string inDesc, string inValue)
	{
		mType = inType;
		mName = inName;
		mDesc = inDesc;
		mValue = inValue;
	}
}
