using UnityEngine;
using pumpkin.display;

namespace pumpkin.tweener
{
	internal class TweenerCallback
	{
		internal GameObject reciever;

		internal string methodName;

		internal TweenerObj.Callback callback;

		internal TweenerObj.CallbackWithArgument callbackWithArg;

		internal TweenerObj.DisplayObjectTargetCallback callbackWithTarget;

		internal object messageArg;

		public void applyDisplayObject(DisplayObject obj)
		{
			if ((bool)reciever)
			{
				if (methodName == null)
				{
					Debug.Log(string.Concat("Tweener recieved '", reciever, "' has no method name set"));
				}
				else if (messageArg == null)
				{
					reciever.SendMessage(methodName);
				}
				else
				{
					reciever.SendMessage(methodName, messageArg);
				}
			}
			if (callbackWithTarget != null)
			{
				callbackWithTarget(obj);
			}
			if (callbackWithArg != null)
			{
				callbackWithArg(messageArg);
			}
			if (callback != null)
			{
				callback();
			}
		}
	}
}
