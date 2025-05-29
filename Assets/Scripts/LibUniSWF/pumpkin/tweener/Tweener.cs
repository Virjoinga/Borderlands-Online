using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using pumpkin.display;

namespace pumpkin.tweener
{
	public class Tweener
	{
		public enum TransitionType
		{
			linear = 0,
			easeInQuad = 1,
			easeOutQuad = 2,
			easeInOutQuad = 3,
			easeInCubic = 4,
			easeOutCubic = 5,
			easeInOutCubic = 6,
			easeInQuart = 7,
			easeOutQuart = 8,
			easeInOutQuart = 9,
			easeInQuint = 10,
			easeOutQuint = 11,
			easeInOutQuint = 12,
			easeInSine = 13,
			easeOutSine = 14,
			easeInOutSine = 15,
			easeInCirc = 16,
			easeOutCirc = 17,
			easeInOutCirc = 18,
			easeInExpo = 19,
			easeOutExpo = 20,
			easeInOutExpo = 21,
			easeInElastic = 22,
			easeOutElastic = 23,
			easeInOutElastic = 24,
			easeInBack = 25,
			easeOutBack = 26,
			easeInOutBack = 27,
			easeInBounce = 28,
			easeOutBounce = 29,
			easeInOutBounce = 30
		}

		internal static void cleanupTweens(List<TweenerObj> tweens)
		{
			bool flag = true;
			while (flag)
			{
				flag = false;
				for (int i = 0; i < tweens.Count; i++)
				{
					TweenerObj tweenerObj = tweens[i];
					if (tweenerObj.proporties.Count < 1)
					{
						tweens.Remove(tweenerObj);
						flag = true;
						break;
					}
					if (tweenerObj.percentage >= 1f && tweenerObj.isCompleted)
					{
						tweens.Remove(tweenerObj);
						flag = true;
						break;
					}
				}
			}
		}

		public static TweenerObj addTween(object context, Hashtable args)
		{
			if (context is DisplayObject)
			{
				DisplayObject displayObject = context as DisplayObject;
				if (displayObject.tweens == null)
				{
					displayObject.tweens = new List<TweenerObj>();
				}
				else
				{
					for (int i = 0; i < displayObject.tweens.Count; i++)
					{
						TweenerObj tweenerObj = displayObject.tweens[i];
						foreach (DictionaryEntry arg in args)
						{
							if (tweenerObj.proporties.Contains(arg.Key))
							{
								tweenerObj.proporties.Remove(arg.Key);
							}
						}
					}
					cleanupTweens(displayObject.tweens);
				}
				TweenerObj tweenerObj2 = new TweenerObj();
				if (!args.Contains("transition"))
				{
					tweenerObj2.transitionType = TransitionType.linear;
				}
				else if (args["transition"] is TransitionType)
				{
					tweenerObj2.transitionType = (TransitionType)args["transition"];
				}
				else
				{
					string value = args["transition"].ToString();
					tweenerObj2.transitionType = (TransitionType)Enum.Parse(typeof(TransitionType), value, true);
				}
				tweenerObj2.targetDisplayObj = displayObject;
				foreach (DictionaryEntry arg2 in args)
				{
					TweenerPropertyInfo tweenerPropertyInfo = new TweenerPropertyInfo();
					bool flag = true;
					string text = arg2.Key.ToString();
					if ((string)arg2.Key == "time")
					{
						tweenerObj2.time = toFloat(args[arg2.Key], text);
					}
					else
					{
						if ((string)arg2.Key == "transition")
						{
							continue;
						}
						if ((string)arg2.Key == "delay")
						{
							tweenerObj2.delay = toFloat(args[arg2.Key], text);
							continue;
						}
						if ((string)arg2.Key == "gotoAndStop")
						{
							if (args[arg2.Key] is string)
							{
								tweenerPropertyInfo.valueCompletef = (displayObject as MovieClip).getFrameLabel((string)args[arg2.Key]);
								flag = false;
							}
						}
						else if ((string)arg2.Key == "colorTransform")
						{
							if (args[arg2.Key] is Color)
							{
								Color color = (Color)args[arg2.Key];
								tweenerPropertyInfo.valueCompletev4.x = color.r;
								tweenerPropertyInfo.valueCompletev4.y = color.g;
								tweenerPropertyInfo.valueCompletev4.z = color.b;
								tweenerPropertyInfo.valueCompletev4.w = color.a;
								flag = false;
							}
						}
						else
						{
							if (text == "onStartGameObject" && args[arg2.Key] is GameObject)
							{
								if (tweenerObj2.onStart == null)
								{
									tweenerObj2.onStart = new TweenerCallback();
								}
								tweenerObj2.onStart.reciever = args[arg2.Key] as GameObject;
								continue;
							}
							if (text == "onStartGameObjectParams")
							{
								if (tweenerObj2.onStart == null)
								{
									tweenerObj2.onStart = new TweenerCallback();
								}
								tweenerObj2.onStart.messageArg = args[arg2.Key];
								continue;
							}
							if (text == "onStartGameMethod" && args[arg2.Key] is string)
							{
								if (tweenerObj2.onStart == null)
								{
									tweenerObj2.onStart = new TweenerCallback();
								}
								tweenerObj2.onStart.methodName = args[arg2.Key] as string;
								continue;
							}
							if (text == "onCompleteGameObject" && args[arg2.Key] is GameObject)
							{
								if (tweenerObj2.onComplete == null)
								{
									tweenerObj2.onComplete = new TweenerCallback();
								}
								tweenerObj2.onComplete.reciever = args[arg2.Key] as GameObject;
								continue;
							}
							if (text == "onCompleteGameObjectParams")
							{
								if (tweenerObj2.onComplete == null)
								{
									tweenerObj2.onComplete = new TweenerCallback();
								}
								tweenerObj2.onComplete.messageArg = args[arg2.Key];
								continue;
							}
							if (text == "onCompleteGameMethod" && args[arg2.Key] is string)
							{
								if (tweenerObj2.onComplete == null)
								{
									tweenerObj2.onComplete = new TweenerCallback();
								}
								tweenerObj2.onComplete.methodName = args[arg2.Key] as string;
								continue;
							}
							if (text == "onUpdateGameObject" && args[arg2.Key] is GameObject)
							{
								if (tweenerObj2.onUpdate == null)
								{
									tweenerObj2.onUpdate = new TweenerCallback();
								}
								tweenerObj2.onUpdate.reciever = args[arg2.Key] as GameObject;
								continue;
							}
							if (text == "onUpdateGameObjectParams")
							{
								if (tweenerObj2.onUpdate == null)
								{
									tweenerObj2.onUpdate = new TweenerCallback();
								}
								tweenerObj2.onUpdate.messageArg = args[arg2.Key];
								continue;
							}
							if (text == "onUpdateGameMethod" && args[arg2.Key] is string)
							{
								if (tweenerObj2.onUpdate == null)
								{
									tweenerObj2.onUpdate = new TweenerCallback();
								}
								tweenerObj2.onUpdate.methodName = args[arg2.Key] as string;
								continue;
							}
							if (text == "loop")
							{
								tweenerObj2.loop = toFloat(args[arg2.Key], text);
								continue;
							}
						}
						if (flag)
						{
							tweenerPropertyInfo.valueCompletef = toFloat(args[arg2.Key], text);
						}
						tweenerObj2.proporties[arg2.Key] = tweenerPropertyInfo;
					}
				}
				displayObject.tweens.Add(tweenerObj2);
				return tweenerObj2;
			}
			return null;
		}

		public static void removeTweens(object context)
		{
			if (context is DisplayObject)
			{
				DisplayObject displayObject = context as DisplayObject;
				displayObject.tweens = null;
			}
		}

		public static Hashtable Hash(params object[] args)
		{
			Hashtable hashtable = new Hashtable(args.Length / 2);
			if (args.Length % 2 != 0)
			{
				Debug.LogError("Hash requires an even number of args eg. Hash( 'valueA', 1,  'valueB',  2 ); ");
				return null;
			}
			for (int i = 0; i < args.Length - 1; i += 2)
			{
				hashtable.Add(args[i], args[i + 1]);
			}
			return hashtable;
		}

		private static float toFloat(object num, string propName)
		{
			if (num is float)
			{
				return (float)num;
			}
			if (num is int)
			{
				return (int)num;
			}
			try
			{
				return float.Parse(num.ToString());
			}
			catch (FormatException)
			{
				Debug.LogWarning("Failed to parse '" + propName + "'");
				return 0f;
			}
		}
	}
}
