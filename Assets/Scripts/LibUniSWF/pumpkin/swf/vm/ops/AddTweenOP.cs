using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using pumpkin.display;
using pumpkin.tweener;
using pumpkin.utils;

namespace pumpkin.swf.vm.ops
{
	public class AddTweenOP : SimpleActionOP
	{
		public string objectName;

		public object time;

		public object x;

		public object y;

		public object rotation;

		public object scaleX;

		public object scaleY;

		public string onComplete;

		public override void run(SimpleActionVM vm)
		{
			Debug.Log("AddTweenOP");
			DisplayObject displayObject = null;
			displayObject = ((!string.IsNullOrEmpty(objectName)) ? vm.movieClip.getChildByName(objectName) : vm.movieClip);
			if (displayObject == null)
			{
				Debug.LogWarning("AddTweenOP failed to find displayObject: " + objectName);
				return;
			}
			Hashtable hashtable = new Hashtable();
			if (time != null)
			{
				hashtable["time"] = time;
			}
			if (x != null)
			{
				hashtable["x"] = x;
			}
			if (y != null)
			{
				hashtable["y"] = y;
			}
			if (rotation != null)
			{
				hashtable["rotation"] = rotation;
			}
			if (scaleX != null)
			{
				hashtable["scaleX"] = scaleX;
			}
			if (scaleY != null)
			{
				hashtable["scaleY"] = scaleY;
			}
			SimpleActionVM vmRef = vm;
			MovieClip targetRef = vm.movieClip;
			List<SimpleActionOP> opsRef = vm.ops;
			SafeHashtable globalsRef = vm.globals;
			TweenerObj tweenerObj = Tweener.addTween(displayObject, hashtable);
			if (onComplete != null)
			{
				tweenerObj.OnComplete(delegate
				{
					vmRef.runFrame(targetRef, opsRef, onComplete, globalsRef);
				});
			}
			Debug.Log("x " + x);
			Debug.Log("y " + y);
			Debug.Log("Time " + time);
		}
	}
}
