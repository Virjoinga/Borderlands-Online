using UnityEngine;
using pumpkin.display;
using pumpkin.events;
using pumpkin.geom;
using pumpkin.text;

namespace pumpkin.ui
{
	public class ScreenUtils
	{
		public static void center(Stage stage, DisplayObject d)
		{
			Rectangle bounds = d.getBounds(d.parent);
			d.x = stage.stageWidth / 2f - bounds.width / 2f;
			d.y = stage.stageHeight / 2f - bounds.height / 2f;
			d.x -= bounds.x;
			d.y -= bounds.y;
		}

		public static void bottomLeft(Stage stage, DisplayObject d)
		{
			Rectangle bounds = d.getBounds(d.parent);
			d.x = stage.stageWidth - bounds.width;
			d.y = stage.stageHeight - bounds.height;
		}

		public static void bottomRight(Stage stage, DisplayObject d)
		{
			Rectangle bounds = d.getBounds(d.parent);
			d.x = stage.stageWidth - bounds.width;
			d.y = stage.stageHeight - bounds.height;
		}

		public static void bottom(Stage stage, DisplayObject d)
		{
			Rectangle bounds = d.getBounds(d.parent);
			d.y = stage.stageHeight - bounds.height;
		}

		public static void bottomCenter(Stage stage, DisplayObject d)
		{
			Rectangle bounds = d.getBounds(d.parent);
			d.x = stage.stageWidth / 2f - bounds.width / 2f;
			d.y = stage.stageHeight / 2f - bounds.height / 2f;
			d.x -= bounds.x;
			d.y = stage.stageHeight - bounds.height;
		}

		public static void alignRight(Stage stage, DisplayObject d)
		{
			Rectangle bounds = d.getBounds(d.parent);
			d.x = stage.stageWidth - bounds.width;
		}

		public static MovieClip createButton(MovieClip clip, string childName, EventDispatcher.EventCallback onClick)
		{
			MovieClip childByName = clip.getChildByName<MovieClip>(childName);
			if (childByName == null)
			{
				return null;
			}
			createButton(childByName, onClick);
			return childByName;
		}

		public static void createButton(MovieClip clip, EventDispatcher.EventCallback onClick)
		{
			clip.gotoAndStop(1);
			clip.buttonMode = true;
			clip.addEventListener(MouseEvent.CLICK, onClick);
			clip.addEventListener(MouseEvent.MOUSE_ENTER, onButtonEnter);
			clip.addEventListener(MouseEvent.MOUSE_LEAVE, onButtonLeave);
			if (isTouchDevice())
			{
				clip.addEventListener(MouseEvent.MOUSE_UP, onButtonLeave);
			}
		}

		public static void setupButtonWithLabel(MovieClip clip, string label)
		{
			clip.gotoAndStop(1);
			clip.buttonMode = true;
			clip.addEventListener(MouseEvent.MOUSE_ENTER, onButtonEnter);
			clip.addEventListener(MouseEvent.MOUSE_LEAVE, onButtonLeave);
			if (isTouchDevice())
			{
				clip.addEventListener(MouseEvent.MOUSE_UP, onButtonLeave);
			}
			TextField childByName = clip.getChildByName<TextField>("txt");
			if (childByName != null && label != null)
			{
				childByName.text = label;
			}
		}

		public static void createButtonWithLabel(MovieClip clip, string label, EventDispatcher.EventCallback onClick)
		{
			clip.gotoAndStop(1);
			clip.buttonMode = true;
			clip.addEventListener(MouseEvent.CLICK, onClick);
			clip.addEventListener(MouseEvent.MOUSE_ENTER, onButtonEnter);
			clip.addEventListener(MouseEvent.MOUSE_LEAVE, onButtonLeave);
			if (isTouchDevice())
			{
				clip.addEventListener(MouseEvent.MOUSE_UP, onButtonLeave);
			}
			TextField childByName = clip.getChildByName<TextField>("txt");
			if (childByName != null)
			{
				childByName.text = label;
			}
		}

		public static MovieClip createButtonWithLabel(MovieClip clip, string childName, string label, EventDispatcher.EventCallback onClick)
		{
			clip = clip.getChildByName<MovieClip>(childName);
			if (clip == null)
			{
				return clip;
			}
			clip.gotoAndStop(1);
			clip.buttonMode = true;
			clip.addEventListener(MouseEvent.CLICK, onClick);
			clip.addEventListener(MouseEvent.MOUSE_ENTER, onButtonEnter);
			clip.addEventListener(MouseEvent.MOUSE_LEAVE, onButtonLeave);
			if (isTouchDevice())
			{
				clip.addEventListener(MouseEvent.MOUSE_UP, onButtonLeave);
			}
			TextField childByName = clip.getChildByName<TextField>("txt");
			if (childByName != null)
			{
				childByName.text = label;
			}
			return clip;
		}

		public static void createButtonWithLabelAutoFit(MovieClip clip, string label, EventDispatcher.EventCallback onClick)
		{
			clip.gotoAndStop(1);
			clip.buttonMode = true;
			clip.addEventListener(MouseEvent.CLICK, onClick);
			clip.addEventListener(MouseEvent.MOUSE_ENTER, onButtonEnter);
			clip.addEventListener(MouseEvent.MOUSE_LEAVE, onButtonLeave);
			if (isTouchDevice())
			{
				clip.addEventListener(MouseEvent.MOUSE_UP, onButtonLeave);
			}
			TextField childByName = clip.getChildByName<TextField>("txt");
			if (childByName != null)
			{
				childByName.text = label;
				childByName.textFormat.fitSize = true;
				childByName.textFormat = childByName.textFormat;
			}
		}

		public static void createButtonWithLabelWithoutMouseOver(MovieClip clip, string label, EventDispatcher.EventCallback onClick)
		{
			clip.gotoAndStop(1);
			clip.buttonMode = true;
			clip.addEventListener(MouseEvent.CLICK, onClick);
			TextField childByName = clip.getChildByName<TextField>("txt");
			if (childByName != null)
			{
				childByName.text = label;
			}
		}

		protected static void onButtonEnter(CEvent e)
		{
			MovieClip movieClip = (MovieClip)e.currentTarget;
			if (movieClip != null)
			{
				movieClip.gotoAndStop(2);
			}
		}

		protected static void onButtonLeave(CEvent e)
		{
			MovieClip movieClip = (MovieClip)e.currentTarget;
			if (movieClip != null)
			{
				movieClip.gotoAndStop(1);
			}
		}

		private static bool isTouchDevice()
		{
			return Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer;
		}
	}
}
