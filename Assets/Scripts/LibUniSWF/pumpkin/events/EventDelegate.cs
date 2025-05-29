using System;
using System.Reflection;
using UnityEngine;

namespace pumpkin.events
{
	public class EventDelegate
	{
		public enum DISPATCH_TYPE
		{
			GAMEOBJECT = 0,
			DELEGATE = 1
		}

		public GameObject gameObject;

		public object targetObject;

		public string functionName;

		public DISPATCH_TYPE dispatchType;

		public EventDispatcher.EventCallback delegateCallback;

		public bool useCapture;

		public string eventName;

		public MulticastDelegate internalDelegate;

		public bool Invoke(CEvent e)
		{
			if (dispatchType == DISPATCH_TYPE.GAMEOBJECT)
			{
				if (!gameObject)
				{
					return false;
				}
				gameObject.SendMessage(functionName, e, SendMessageOptions.DontRequireReceiver);
				return true;
			}
			if (dispatchType == DISPATCH_TYPE.DELEGATE)
			{
				if (delegateCallback == null)
				{
					return false;
				}
				delegateCallback(e);
				return true;
			}
			return false;
		}

		public bool compareToDelegate(EventDispatcher.EventCallback delegateCallback, bool useCapture)
		{
			if (this.delegateCallback.GetHashCode() == delegateCallback.GetHashCode() && this.useCapture == useCapture)
			{
				return true;
			}
			if (delegateCallback != null && (object)internalDelegate != null && delegateCallback.Target != null)
			{
				object target = delegateCallback.Target;
				FieldInfo[] fields = target.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
				if (fields.Length > 0 && fields[0].Name[0] == '$')
				{
					MulticastDelegate multicastDelegate = fields[0].GetValue(target) as MulticastDelegate;
					return (Delegate)internalDelegate == (Delegate)multicastDelegate && this.useCapture == useCapture;
				}
			}
			return delegateCallback == this.delegateCallback && this.useCapture == useCapture;
		}

		public bool compareToGameObject(GameObject gameObject, string functionName, bool useCapture)
		{
			return this.gameObject == gameObject && this.functionName == functionName && this.useCapture == useCapture;
		}

		public void cacheCompilerGenerated()
		{
			MulticastDelegate multicastDelegate = delegateCallback;
			if ((object)multicastDelegate != null && multicastDelegate.Target != null)
			{
				FieldInfo[] fields = multicastDelegate.Target.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
				if (fields.Length > 0)
				{
					internalDelegate = fields[0].GetValue(multicastDelegate.Target) as MulticastDelegate;
				}
			}
		}
	}
}
