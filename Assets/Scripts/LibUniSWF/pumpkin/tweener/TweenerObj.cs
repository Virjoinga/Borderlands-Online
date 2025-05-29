using System;
using System.Collections;
using UnityEngine;
using pumpkin.display;

namespace pumpkin.tweener
{
	public class TweenerObj
	{
		public delegate void Callback();

		public delegate void CallbackWithArgument(object arg);

		public delegate void DisplayObjectTargetCallback(DisplayObject target);

		internal delegate float TransitionFunction(float start, float end, float value);

		internal delegate void TweenDelegate();

		internal float time = 1f;

		private TransitionFunction transition;

		private TweenDelegate apply;

		internal TweenerCallback onComplete;

		internal TweenerCallback onUpdate;

		internal TweenerCallback onStart;

		internal Hashtable proporties = new Hashtable();

		internal DisplayObject targetDisplayObj;

		internal float percentage = 0f;

		private bool isRunning = false;

		internal bool isCompleted = false;

		private float runningTime = 0f;

		internal Tweener.TransitionType transitionType;

		internal float delay = 0f;

		internal float delayTime = 0f;

		internal float loop = 0f;

		private float lastRealTime;

		private bool useRealTime = true;

		public TweenerObj()
		{
			apply = applyDisplayObjectTargets;
			lastRealTime = Time.realtimeSinceStartup;
		}

		protected void tweenStart()
		{
			switch (transitionType)
			{
			case Tweener.TransitionType.linear:
				transition = linear;
				break;
			case Tweener.TransitionType.easeInQuad:
				transition = easeInQuad;
				break;
			case Tweener.TransitionType.easeOutQuad:
				transition = easeOutQuad;
				break;
			case Tweener.TransitionType.easeInOutQuad:
				transition = easeInOutQuad;
				break;
			case Tweener.TransitionType.easeInCubic:
				transition = easeInCubic;
				break;
			case Tweener.TransitionType.easeOutCubic:
				transition = easeOutCubic;
				break;
			case Tweener.TransitionType.easeInOutCubic:
				transition = easeInOutCubic;
				break;
			case Tweener.TransitionType.easeInQuart:
				transition = easeInQuart;
				break;
			case Tweener.TransitionType.easeOutQuart:
				transition = easeOutQuart;
				break;
			case Tweener.TransitionType.easeInOutQuart:
				transition = easeInOutQuart;
				break;
			case Tweener.TransitionType.easeInQuint:
				transition = easeInQuint;
				break;
			case Tweener.TransitionType.easeOutQuint:
				transition = easeOutQuint;
				break;
			case Tweener.TransitionType.easeInOutQuint:
				transition = easeInOutQuint;
				break;
			case Tweener.TransitionType.easeInSine:
				transition = easeInSine;
				break;
			case Tweener.TransitionType.easeOutSine:
				transition = easeOutSine;
				break;
			case Tweener.TransitionType.easeInOutSine:
				transition = easeInOutSine;
				break;
			case Tweener.TransitionType.easeInCirc:
				transition = easeInCirc;
				break;
			case Tweener.TransitionType.easeOutCirc:
				transition = easeOutCirc;
				break;
			case Tweener.TransitionType.easeInOutCirc:
				transition = easeInOutCirc;
				break;
			case Tweener.TransitionType.easeInExpo:
				transition = easeInExpo;
				break;
			case Tweener.TransitionType.easeOutExpo:
				transition = easeOutExpo;
				break;
			case Tweener.TransitionType.easeInOutExpo:
				transition = easeInOutExpo;
				break;
			case Tweener.TransitionType.easeInElastic:
				transition = easeInElastic;
				break;
			case Tweener.TransitionType.easeOutElastic:
				transition = easeOutElastic;
				break;
			case Tweener.TransitionType.easeInOutElastic:
				transition = easeInOutElastic;
				break;
			case Tweener.TransitionType.easeInBack:
				transition = easeInBack;
				break;
			case Tweener.TransitionType.easeOutBack:
				transition = easeOutBack;
				break;
			case Tweener.TransitionType.easeInOutBack:
				transition = easeInOutBack;
				break;
			case Tweener.TransitionType.easeInBounce:
				transition = easeInBounce;
				break;
			case Tweener.TransitionType.easeOutBounce:
				transition = easeOutBounce;
				break;
			case Tweener.TransitionType.easeInOutBounce:
				transition = easeInOutBounce;
				break;
			default:
				Debug.LogError(string.Concat("unkown transtion '", transitionType, "' using default"));
				transition = linear;
				break;
			}
			apply();
			isRunning = true;
			lastRealTime = Time.realtimeSinceStartup;
		}

		public void tweenUpdate()
		{
			if (delay > 0f)
			{
				delayTime += Time.realtimeSinceStartup - lastRealTime;
				if (delayTime >= delay)
				{
					delay = 0f;
				}
				lastRealTime = Time.realtimeSinceStartup;
				return;
			}
			if (!isRunning)
			{
				tweenStart();
				if (onStart != null)
				{
					onStart.applyDisplayObject(targetDisplayObj);
				}
			}
			if (percentage >= 1f)
			{
				percentage = 1f;
				apply();
				if (loop > 0f || loop < 0f)
				{
					if (loop > 0f)
					{
						loop -= 1f;
					}
					runningTime = 0f;
					percentage = 0f;
				}
				else
				{
					_onTweenComplete();
				}
			}
			else
			{
				apply();
				if (onUpdate != null)
				{
					onUpdate.applyDisplayObject(targetDisplayObj);
				}
				if (useRealTime)
				{
					runningTime += Time.realtimeSinceStartup - lastRealTime;
				}
				else
				{
					runningTime += Time.deltaTime;
				}
				percentage = runningTime / time;
			}
			lastRealTime = Time.realtimeSinceStartup;
		}

		private void _onTweenComplete()
		{
			if (!isCompleted)
			{
				isCompleted = true;
				isRunning = false;
				if (percentage > 0.5f)
				{
					percentage = 1f;
				}
				else
				{
					percentage = 0f;
				}
				apply();
				if (onComplete != null)
				{
					onComplete.applyDisplayObject(targetDisplayObj);
				}
			}
		}

		private void applyDisplayObjectTargets()
		{
			if (targetDisplayObj == null)
			{
				Debug.LogError("TweenerObj::applyDisplayObjectTargets() targetDisplayObj==null");
				return;
			}
			if (transition == null)
			{
				Debug.LogError("TweenerObj::applyDisplayObjectTargets() transition==null");
				return;
			}
			foreach (DictionaryEntry proporty in proporties)
			{
				TweenerPropertyInfo tweenerPropertyInfo = (TweenerPropertyInfo)proporties[(string)proporty.Key];
				if (tweenerPropertyInfo == null)
				{
					Debug.LogError(string.Concat("properties[", proporty.Key, "]==null"));
				}
				else if ((string)proporty.Key == "x")
				{
					if (!isRunning)
					{
						tweenerPropertyInfo.valueStartf = targetDisplayObj.x;
					}
					else
					{
						targetDisplayObj.x = transition(tweenerPropertyInfo.valueStartf, tweenerPropertyInfo.valueCompletef, percentage);
					}
				}
				else if ((string)proporty.Key == "y")
				{
					if (!isRunning)
					{
						tweenerPropertyInfo.valueStartf = targetDisplayObj.y;
					}
					else
					{
						targetDisplayObj.y = transition(tweenerPropertyInfo.valueStartf, tweenerPropertyInfo.valueCompletef, percentage);
					}
				}
				else if ((string)proporty.Key == "scaleX")
				{
					if (!isRunning)
					{
						tweenerPropertyInfo.valueStartf = targetDisplayObj.scaleX;
					}
					else
					{
						targetDisplayObj.scaleX = transition(tweenerPropertyInfo.valueStartf, tweenerPropertyInfo.valueCompletef, percentage);
					}
				}
				else if ((string)proporty.Key == "scaleY")
				{
					if (!isRunning)
					{
						tweenerPropertyInfo.valueStartf = targetDisplayObj.scaleY;
					}
					else
					{
						targetDisplayObj.scaleY = transition(tweenerPropertyInfo.valueStartf, tweenerPropertyInfo.valueCompletef, percentage);
					}
				}
				else if ((string)proporty.Key == "rotation")
				{
					if (!isRunning)
					{
						tweenerPropertyInfo.valueStartf = targetDisplayObj.rotation;
					}
					else
					{
						targetDisplayObj.rotation = transition(tweenerPropertyInfo.valueStartf, tweenerPropertyInfo.valueCompletef, percentage);
					}
				}
				else if ((string)proporty.Key == "alpha")
				{
					if (!isRunning)
					{
						tweenerPropertyInfo.valueStartf = targetDisplayObj.alpha;
					}
					else
					{
						targetDisplayObj.alpha = transition(tweenerPropertyInfo.valueStartf, tweenerPropertyInfo.valueCompletef, percentage);
					}
				}
				else if ((string)proporty.Key == "gotoAndStop")
				{
					if (!isRunning)
					{
						tweenerPropertyInfo.valueStartf = (targetDisplayObj as MovieClip).currentFrame;
					}
					else
					{
						(targetDisplayObj as MovieClip).currentFrame = (int)transition(tweenerPropertyInfo.valueStartf, tweenerPropertyInfo.valueCompletef, percentage);
					}
				}
				else if ((string)proporty.Key == "colorTransform")
				{
					if (!isRunning)
					{
						tweenerPropertyInfo.valueStartv4.x = (targetDisplayObj as MovieClip).colorTransform.r;
						tweenerPropertyInfo.valueStartv4.y = (targetDisplayObj as MovieClip).colorTransform.g;
						tweenerPropertyInfo.valueStartv4.z = (targetDisplayObj as MovieClip).colorTransform.b;
						tweenerPropertyInfo.valueStartv4.w = (targetDisplayObj as MovieClip).colorTransform.a;
					}
					else
					{
						Color colorTransform = new Color(transition(tweenerPropertyInfo.valueStartv4.x, tweenerPropertyInfo.valueCompletev4.x, percentage), transition(tweenerPropertyInfo.valueStartv4.y, tweenerPropertyInfo.valueCompletev4.y, percentage), transition(tweenerPropertyInfo.valueStartv4.z, tweenerPropertyInfo.valueCompletev4.z, percentage), transition(tweenerPropertyInfo.valueStartv4.w, tweenerPropertyInfo.valueCompletev4.w, percentage));
						(targetDisplayObj as MovieClip).colorTransform = colorTransform;
					}
				}
			}
		}

		public TweenerObj OnStart(Callback callback)
		{
			onStart = new TweenerCallback();
			onStart.callback = callback;
			return this;
		}

		public TweenerObj OnStart(CallbackWithArgument callback, object messageArg)
		{
			onStart = new TweenerCallback();
			onStart.callbackWithArg = callback;
			onStart.messageArg = messageArg;
			return this;
		}

		public TweenerObj OnStartWithTarget(DisplayObjectTargetCallback callback)
		{
			onStart = new TweenerCallback();
			onStart.callbackWithTarget = callback;
			return this;
		}

		public TweenerObj OnUpdate(Callback callback)
		{
			onUpdate = new TweenerCallback();
			onUpdate.callback = callback;
			return this;
		}

		public TweenerObj OnUpdate(CallbackWithArgument callback, object messageArg)
		{
			onUpdate = new TweenerCallback();
			onUpdate.callbackWithArg = callback;
			onUpdate.messageArg = messageArg;
			return this;
		}

		public TweenerObj OnUpdateWithTarget(DisplayObjectTargetCallback callback)
		{
			onUpdate = new TweenerCallback();
			onUpdate.callbackWithTarget = callback;
			return this;
		}

		public TweenerObj OnComplete(Callback callback)
		{
			onComplete = new TweenerCallback();
			onComplete.callback = callback;
			return this;
		}

		public TweenerObj OnComplete(CallbackWithArgument callback, object messageArg)
		{
			onComplete = new TweenerCallback();
			onComplete.callbackWithArg = callback;
			onComplete.messageArg = messageArg;
			return this;
		}

		public TweenerObj OnCompleteWithTarget(DisplayObjectTargetCallback callback)
		{
			onComplete = new TweenerCallback();
			onComplete.callbackWithTarget = callback;
			return this;
		}

		public TweenerObj OnStartGameObject(GameObject reciever, string methodName)
		{
			return OnStartGameObject(reciever, methodName, null);
		}

		public TweenerObj OnStartGameObject(GameObject reciever, string methodName, object messageArg)
		{
			onStart = new TweenerCallback();
			onStart.reciever = reciever;
			onStart.methodName = methodName;
			onStart.messageArg = messageArg;
			return this;
		}

		public TweenerObj OnUpdateGameObject(GameObject reciever, string methodName)
		{
			return OnUpdateGameObject(reciever, methodName, null);
		}

		public TweenerObj OnUpdateGameObject(GameObject reciever, string methodName, object messageArg)
		{
			onUpdate = new TweenerCallback();
			onUpdate.reciever = reciever;
			onUpdate.methodName = methodName;
			onUpdate.messageArg = messageArg;
			return this;
		}

		public TweenerObj OnCompleteGameObject(GameObject reciever, string methodName)
		{
			return OnCompleteGameObject(reciever, methodName, null);
		}

		public TweenerObj OnCompleteGameObject(GameObject reciever, string methodName, object messageArg)
		{
			onComplete = new TweenerCallback();
			onComplete.reciever = reciever;
			onComplete.methodName = methodName;
			onComplete.messageArg = messageArg;
			return this;
		}

		private float linear(float start, float end, float val)
		{
			return Mathf.Lerp(start, end, val);
		}

		private float easeInQuad(float start, float end, float val)
		{
			end -= start;
			return end * val * val + start;
		}

		private float easeOutQuad(float start, float end, float val)
		{
			end -= start;
			return (0f - end) * val * (val - 2f) + start;
		}

		private float easeInOutQuad(float start, float end, float val)
		{
			val /= 0.5f;
			end -= start;
			if (val < 1f)
			{
				return end / 2f * val * val + start;
			}
			val -= 1f;
			return (0f - end) / 2f * (val * (val - 2f) - 1f) + start;
		}

		private float easeInCubic(float start, float end, float val)
		{
			end -= start;
			return end * val * val * val + start;
		}

		private float easeOutCubic(float start, float end, float val)
		{
			val -= 1f;
			end -= start;
			return end * (val * val * val + 1f) + start;
		}

		private float easeInOutCubic(float start, float end, float val)
		{
			val /= 0.5f;
			end -= start;
			if (val < 1f)
			{
				return end / 2f * val * val * val + start;
			}
			val -= 2f;
			return end / 2f * (val * val * val + 2f) + start;
		}

		private float easeInQuart(float start, float end, float val)
		{
			end -= start;
			return end * val * val * val * val + start;
		}

		private float easeOutQuart(float start, float end, float val)
		{
			val -= 1f;
			end -= start;
			return (0f - end) * (val * val * val * val - 1f) + start;
		}

		private float easeInOutQuart(float start, float end, float val)
		{
			val /= 0.5f;
			end -= start;
			if (val < 1f)
			{
				return end / 2f * val * val * val * val + start;
			}
			val -= 2f;
			return (0f - end) / 2f * (val * val * val * val - 2f) + start;
		}

		private float easeInQuint(float start, float end, float val)
		{
			end -= start;
			return end * val * val * val * val * val + start;
		}

		private float easeOutQuint(float start, float end, float val)
		{
			val -= 1f;
			end -= start;
			return end * (val * val * val * val * val + 1f) + start;
		}

		private float easeInOutQuint(float start, float end, float val)
		{
			val /= 0.5f;
			end -= start;
			if (val < 1f)
			{
				return end / 2f * val * val * val * val * val + start;
			}
			val -= 2f;
			return end / 2f * (val * val * val * val * val + 2f) + start;
		}

		private float easeInSine(float start, float end, float val)
		{
			end -= start;
			return (0f - end) * Mathf.Cos(val / 1f * ((float)Math.PI / 2f)) + end + start;
		}

		private float easeOutSine(float start, float end, float val)
		{
			end -= start;
			return end * Mathf.Sin(val / 1f * ((float)Math.PI / 2f)) + start;
		}

		private float easeInOutSine(float start, float end, float val)
		{
			end -= start;
			return (0f - end) / 2f * (Mathf.Cos((float)Math.PI * val / 1f) - 1f) + start;
		}

		private float easeInCirc(float start, float end, float val)
		{
			end -= start;
			return (0f - end) * (Mathf.Sqrt(1f - val * val) - 1f) + start;
		}

		private float easeOutCirc(float start, float end, float val)
		{
			val -= 1f;
			end -= start;
			return end * Mathf.Sqrt(1f - val * val) + start;
		}

		private float easeInOutCirc(float start, float end, float val)
		{
			val /= 0.5f;
			end -= start;
			if (val < 1f)
			{
				return (0f - end) / 2f * (Mathf.Sqrt(1f - val * val) - 1f) + start;
			}
			val -= 2f;
			return end / 2f * (Mathf.Sqrt(1f - val * val) + 1f) + start;
		}

		private float easeInExpo(float start, float end, float val)
		{
			end -= start;
			return end * Mathf.Pow(2f, 10f * (val / 1f - 1f)) + start;
		}

		private float easeOutExpo(float start, float end, float val)
		{
			end -= start;
			return end * (0f - Mathf.Pow(2f, -10f * val / 1f) + 1f) + start;
		}

		private float easeInOutExpo(float start, float end, float val)
		{
			val /= 0.5f;
			end -= start;
			if (val < 1f)
			{
				return end / 2f * Mathf.Pow(2f, 10f * (val - 1f)) + start;
			}
			val -= 1f;
			return end / 2f * (0f - Mathf.Pow(2f, -10f * val) + 2f) + start;
		}

		private float easeInElastic(float start, float end, float val)
		{
			end -= start;
			float num = 1f;
			float num2 = num * 0.3f;
			float num3 = 0f;
			float num4 = 0f;
			if (val == 0f)
			{
				return start;
			}
			if ((val /= num) == 1f)
			{
				return start + end;
			}
			if (num4 == 0f || num4 < Mathf.Abs(end))
			{
				num4 = end;
				num3 = num2 / 4f;
			}
			else
			{
				num3 = num2 / ((float)Math.PI * 2f) * Mathf.Asin(end / num4);
			}
			return 0f - num4 * Mathf.Pow(2f, 10f * (val -= 1f)) * Mathf.Sin((val * num - num3) * ((float)Math.PI * 2f) / num2) + start;
		}

		private float easeOutElastic(float start, float end, float val)
		{
			end -= start;
			float num = 1f;
			float num2 = num * 0.3f;
			float num3 = 0f;
			float num4 = 0f;
			if (val == 0f)
			{
				return start;
			}
			if ((val /= num) == 1f)
			{
				return start + end;
			}
			if (num4 == 0f || num4 < Mathf.Abs(end))
			{
				num4 = end;
				num3 = num2 / 4f;
			}
			else
			{
				num3 = num2 / ((float)Math.PI * 2f) * Mathf.Asin(end / num4);
			}
			return num4 * Mathf.Pow(2f, -10f * val) * Mathf.Sin((val * num - num3) * ((float)Math.PI * 2f) / num2) + end + start;
		}

		private float easeInOutElastic(float start, float end, float val)
		{
			end -= start;
			float num = 1f;
			float num2 = num * 0.3f;
			float num3 = 0f;
			float num4 = 0f;
			if (val == 0f)
			{
				return start;
			}
			if ((val /= num / 2f) == 2f)
			{
				return start + end;
			}
			if (num4 == 0f || num4 < Mathf.Abs(end))
			{
				num4 = end;
				num3 = num2 / 4f;
			}
			else
			{
				num3 = num2 / ((float)Math.PI * 2f) * Mathf.Asin(end / num4);
			}
			if (val < 1f)
			{
				return -0.5f * (num4 * Mathf.Pow(2f, 10f * (val -= 1f)) * Mathf.Sin((val * num - num3) * ((float)Math.PI * 2f) / num2)) + start;
			}
			return num4 * Mathf.Pow(2f, -10f * (val -= 1f)) * Mathf.Sin((val * num - num3) * ((float)Math.PI * 2f) / num2) * 0.5f + end + start;
		}

		private float easeInBack(float start, float end, float val)
		{
			end -= start;
			val /= 1f;
			float num = 1.70158f;
			return end * val * val * ((num + 1f) * val - num) + start;
		}

		private float easeOutBack(float start, float end, float val)
		{
			float num = 1.70158f;
			end -= start;
			val = val / 1f - 1f;
			return end * (val * val * ((num + 1f) * val + num) + 1f) + start;
		}

		private float easeInOutBack(float start, float end, float val)
		{
			float num = 1.70158f;
			end -= start;
			val /= 0.5f;
			if (val < 1f)
			{
				num *= 1.525f;
				return end / 2f * (val * val * ((num + 1f) * val - num)) + start;
			}
			val -= 2f;
			num *= 1.525f;
			return end / 2f * (val * val * ((num + 1f) * val + num) + 2f) + start;
		}

		private float easeInBounce(float start, float end, float val)
		{
			end -= start;
			float num = 1f;
			return end - easeOutBounce(0f, end, num - val) + start;
		}

		private float easeOutBounce(float start, float end, float val)
		{
			val /= 1f;
			end -= start;
			if (val < 0.36363637f)
			{
				return end * (7.5625f * val * val) + start;
			}
			if (val < 0.72727275f)
			{
				val -= 0.54545456f;
				return end * (7.5625f * val * val + 0.75f) + start;
			}
			if ((double)val < 0.9090909090909091)
			{
				val -= 0.8181818f;
				return end * (7.5625f * val * val + 0.9375f) + start;
			}
			val -= 21f / 22f;
			return end * (7.5625f * val * val + 63f / 64f) + start;
		}

		private float easeInOutBounce(float start, float end, float val)
		{
			end -= start;
			float num = 1f;
			if (val < num / 2f)
			{
				return easeInBounce(0f, end, val * 2f) * 0.5f + start;
			}
			return easeOutBounce(0f, end, val * 2f - num) * 0.5f + end * 0.5f + start;
		}
	}
}
