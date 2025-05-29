using UnityEngine;
using pumpkin.display;

namespace pumpkin.swf.vm.ops
{
	public class SetDisplayObjectPropOP : SimpleActionOP
	{
		public string objectName;

		public string propertyName;

		public object value;

		public override void run(SimpleActionVM vm)
		{
			Debug.Log("SetProp: " + objectName + ", " + propertyName + ", " + value);
			DisplayObject displayObject = null;
			displayObject = ((!string.IsNullOrEmpty(objectName)) ? vm.movieClip.getChildByName(objectName) : vm.movieClip);
			if (propertyName == "x")
			{
				displayObject.x = toFloat(value);
			}
			else if (propertyName == "y")
			{
				displayObject.y = toFloat(value);
			}
			else if (propertyName == "scaleX")
			{
				displayObject.scaleX = toFloat(value);
			}
			else if (propertyName == "scaleY")
			{
				displayObject.scaleY = toFloat(value);
			}
			else if (propertyName == "alpha")
			{
				displayObject.alpha = toFloat(value);
			}
			else if (propertyName == "visible")
			{
				displayObject.visible = toFloat(value) != 0f;
			}
			else if (propertyName == "name")
			{
				displayObject.name = value as string;
			}
			else if (propertyName == "colorTransform")
			{
				int num = (int)value;
				float b = (float)(num & 0xFF) / 255f;
				float g = (float)((num & 0xFF00) >> 8) / 255f;
				float r = (float)((num & 0xFF0000) >> 16) / 255f;
				displayObject.colorTransform = new Color(r, g, b);
			}
		}

		protected float toFloat(object value)
		{
			if (value is float)
			{
				return (float)value;
			}
			if (value is double)
			{
				return (float)(double)value;
			}
			if (value is int)
			{
				return (int)value;
			}
			return float.Parse(value.ToString());
		}
	}
}
