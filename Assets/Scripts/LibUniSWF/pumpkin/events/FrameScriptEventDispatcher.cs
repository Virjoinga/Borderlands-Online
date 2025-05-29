using System;
using System.Collections.Generic;
using UnityEngine;

namespace pumpkin.events
{
	public class FrameScriptEventDispatcher
	{
		public static int MAX_RECURSE = 127;

		private Dictionary<int, List<EventDelegate>> listeners = null;

		private List<EventDelegate> m_CurrentDispatchList = null;

		private bool m_InEventDispatch = false;

		private bool m_EventChanges = false;

		private int m_DispatchDepth = 0;

		private static bool __crop_b = false;

		private static PlatformWarning m_PlatformWarning;

		public bool addEventListener(int type, EventDispatcher.EventCallback listenerFun)
		{
			return addEventListener(type, listenerFun, false);
		}

		public bool addEventListener(int type, EventDispatcher.EventCallback listenerFun, bool useCapture)
		{
			List<EventDelegate> list = _getDispatchList(type, true);
			if (list == null)
			{
				return false;
			}
			for (int i = 0; i < list.Count; i++)
			{
				EventDelegate eventDelegate = list[i];
				if (eventDelegate.compareToDelegate(listenerFun, useCapture))
				{
					return false;
				}
			}
			EventDelegate eventDelegate2 = new EventDelegate();
			eventDelegate2.dispatchType = EventDelegate.DISPATCH_TYPE.DELEGATE;
			eventDelegate2.delegateCallback = listenerFun;
			eventDelegate2.cacheCompilerGenerated();
			eventDelegate2.useCapture = useCapture;
			list.Add(eventDelegate2);
			_eventAdded(type);
			return true;
		}

		public bool dispatchEventId(int type, CEvent e)
		{
			if (!__crop_b && Application.isPlaying)
			{
				__crop_b = Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.LinuxPlayer || Application.platform == RuntimePlatform.OSXWebPlayer || Application.platform == RuntimePlatform.WindowsWebPlayer || Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.NaCl;
				if (!__crop_b)
				{
					string text = string.Concat("This version of uniSWF is not compatible with the current runtime platform '", Application.platform, "', contact support for additional platform options");
					if (!m_PlatformWarning)
					{
						GameObject gameObject = new GameObject();
						gameObject.hideFlags = HideFlags.HideAndDontSave;
						m_PlatformWarning = gameObject.AddComponent<PlatformWarning>();
						m_PlatformWarning.warningStr = text;
					}
					throw new Exception(text);
				}
			}
			if (e == null)
			{
				return false;
			}
			if (e.type == null)
			{
				return false;
			}
			if (m_DispatchDepth > 10)
			{
				Debug.LogWarning("Event dispatch depth limit reached on type '" + e.type + "', potential EventDispatcher loop detected");
				return false;
			}
			if (listeners == null)
			{
				return false;
			}
			List<EventDelegate> list = _getDispatchList(type, true);
			if (e.target == null)
			{
				e.target = this;
			}
			if (e.currentTarget == null)
			{
				e.currentTarget = this;
			}
			if (list != null)
			{
				m_InEventDispatch = true;
				m_DispatchDepth++;
				try
				{
					for (int i = 0; i < list.Count; i++)
					{
						EventDelegate eventDelegate = list[i];
						if (eventDelegate == null)
						{
						}
						if (!eventDelegate.Invoke(e))
						{
							list.RemoveAt(i);
							i--;
						}
						if (e.isImmediateCancelled())
						{
							return true;
						}
					}
				}
				finally
				{
					m_DispatchDepth--;
					if (m_EventChanges)
					{
						foreach (int key in listeners.Keys)
						{
							List<EventDelegate> list2 = listeners[key];
							for (int j = 0; j < list2.Count; j++)
							{
								if (list2[j] == null)
								{
									list2.RemoveAt(j);
									j--;
								}
							}
						}
						m_EventChanges = false;
					}
					m_InEventDispatch = false;
				}
				return true;
			}
			return false;
		}

		public int removeAllEventListeners(int type)
		{
			List<EventDelegate> list = _getDispatchList(type, false);
			if (list == null)
			{
				return 0;
			}
			listeners.Remove(type);
			return list.Count;
		}

		public bool removeEventListener(int type, EventDispatcher.EventCallback listenerFun)
		{
			return removeEventListener(type, listenerFun, false);
		}

		public bool removeEventListener(int type, EventDispatcher.EventCallback listenerFun, bool capture)
		{
			if (listeners == null)
			{
				return false;
			}
			List<EventDelegate> list = _getDispatchList(type, false);
			int num = 0;
			if (list != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i] == null)
					{
						continue;
					}
					EventDelegate eventDelegate = list[i];
					if (eventDelegate.compareToDelegate(listenerFun, capture))
					{
						if (!m_InEventDispatch)
						{
							list.RemoveAt(i);
							i--;
						}
						else
						{
							list[i] = null;
							m_EventChanges = true;
						}
						num++;
					}
				}
			}
			if (num != 0)
			{
				_eventRemoved(type);
			}
			return num != 0;
		}

		public bool willTrigger(int type)
		{
			if (listeners == null)
			{
				return false;
			}
			List<EventDelegate> list = _getDispatchList(type, false);
			if (list == null)
			{
				return false;
			}
			return list.Count > 0;
		}

		public bool hasEventListener(int type)
		{
			return willTrigger(type);
		}

		private List<EventDelegate> _getDispatchList(int type, bool autoCreate)
		{
			if (listeners == null)
			{
				listeners = new Dictionary<int, List<EventDelegate>>();
			}
			if (!listeners.ContainsKey(type))
			{
				if (autoCreate)
				{
					List<EventDelegate> list = new List<EventDelegate>();
					listeners[type] = list;
					return list;
				}
				return null;
			}
			return listeners[type];
		}

		protected virtual void _eventAdded(int type)
		{
		}

		protected virtual void _eventRemoved(int type)
		{
		}

		public Dictionary<int, List<EventDelegate>> getEventListeners()
		{
			return listeners;
		}
	}
}
