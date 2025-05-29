using System;

public class VPaintObjectNotDynamicException : Exception
{
	public override string Message
	{
		get
		{
			return "Method called requires VPaint Object to be dynamic. Set VPaintObject.isDynamic to true before calling this method.";
		}
	}
}
