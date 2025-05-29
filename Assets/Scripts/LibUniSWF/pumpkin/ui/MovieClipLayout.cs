using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using pumpkin.display;
using pumpkin.utils;

namespace pumpkin.ui
{
	public class MovieClipLayout
	{
		public float defaultEdgeThreshold = 100f;

		public bool defaultDetectHorizontalScale = true;

		public float backgroundEdgeThreshold = 10f;

		public Dictionary<string, SafeHashtable> originalProps = new Dictionary<string, SafeHashtable>();

		public Vector2 baselineSize;

		public Vector2 screenSize;

		public DisplayObjectContainer stageRef;

		public float screenAspect;

		public float screenAspect2;

		public Vector2 localScreenSize;

		public ArrayList ignoreList = new ArrayList();

		public float defaultThreshold = 60f;

		public void init(DisplayObjectContainer stageRef, Vector2 baselineSize, Vector2 screenSize)
		{
			this.stageRef = stageRef;
			this.baselineSize = baselineSize;
			this.screenSize = screenSize;
			originalProps = new Dictionary<string, SafeHashtable>();
			ignoreList = new ArrayList();
			resizeScreen(this.screenSize);
		}

		public void resizeScreen(Vector2 screenSize)
		{
			this.screenSize = screenSize;
			screenAspect = screenSize.y / screenSize.x;
			screenAspect2 = screenSize.x / screenSize.y;
			localScreenSize = new Vector2(baselineSize.y * screenAspect2, baselineSize.y);
		}

		public void autoScaleStage()
		{
			if (stageRef != null)
			{
				float num = screenSize.x / baselineSize.x;
				DisplayObjectContainer displayObjectContainer = stageRef;
				float num2 = num;
				stageRef.scaleY = num2;
				displayObjectContainer.scaleX = num2;
				num = screenSize.y / baselineSize.y;
				DisplayObjectContainer displayObjectContainer2 = stageRef;
				num2 = num;
				stageRef.scaleY = num2;
				displayObjectContainer2.scaleX = num2;
			}
		}

		public void autoScaleBackground(DisplayObject mc)
		{
			SafeHashtable safeHashtable = getOriginalProps(mc);
			Rect rect = safeHashtable.getRect("bounds");
			rect = new Rect(rect.x, rect.y, rect.width, rect.height);
			if (rect.height > localScreenSize.y)
			{
				float num = rect.width / rect.height;
				rect.height = localScreenSize.y;
				rect.width = num * rect.height;
			}
			float num2 = localScreenSize.y / rect.height;
			float scaleX = (mc.scaleY = num2);
			mc.scaleX = scaleX;
			float num4 = rect.width * num2;
			float num5 = rect.height * num2;
			if (num4 < localScreenSize.x)
			{
				num2 = localScreenSize.x / rect.width;
				scaleX = (mc.scaleY = num2);
				mc.scaleX = scaleX;
				num4 = rect.width * num2;
				num5 = rect.height * num2;
			}
			mc.x = (localScreenSize.x - baselineSize.x * num2) / 2f;
			mc.y = localScreenSize.y / 2f - num5 / 2f - (rect.y - safeHashtable.getFloat("y")) * num2;
			if (rect.y < 0f)
			{
				mc.y += rect.y;
			}
		}

		public void position(DisplayObject mc, Hashtable optionsIn)
		{
			if (mc == null || mc.name == null)
			{
				return;
			}
			SafeHashtable safeHashtable = new SafeHashtable(optionsIn);
			SafeHashtable safeHashtable2 = getOriginalProps(mc);
			if (safeHashtable.exists("left"))
			{
				if (safeHashtable.isString("left") && safeHashtable.getString("left", "").IndexOf("%") != -1)
				{
					Vector2 vector = safeHashtable2.getVector2("centrePoint");
					float num = float.Parse(safeHashtable.getString("left").Replace("%", "")) / 100f;
					setPositionCenterPoint(mc, new Vector2(localScreenSize.x * num, vector.y));
				}
				else if ((safeHashtable.isBool("left") && safeHashtable.isTrue("left")) || safeHashtable.getInt("left") == 1)
				{
					mc.x = safeHashtable2.getFloat("x");
				}
			}
			if (safeHashtable.exists("right"))
			{
				if (safeHashtable.isString("right") && safeHashtable.getString("right", "").IndexOf("%") != -1)
				{
					Vector2 vector2 = safeHashtable2.getVector2("centrePoint");
					float num = 1f - float.Parse(safeHashtable.getString("right").Replace("%", "")) / 100f;
					setPositionCenterPoint(mc, new Vector2(localScreenSize.x * num, vector2.y));
				}
				else if ((safeHashtable.isBool("right") && safeHashtable.isTrue("right")) || safeHashtable.getInt("right") == 1)
				{
					mc.x = localScreenSize.x - (baselineSize.x - safeHashtable2.getFloat("x"));
				}
			}
			if (safeHashtable.exists("top"))
			{
				if (safeHashtable.isString("top") && safeHashtable.getString("top", "").IndexOf("%") != -1)
				{
					Vector2 vector3 = safeHashtable2.getVector2("centrePoint");
					float num = float.Parse(safeHashtable.getString("top").Replace("%", "")) / 100f;
					setPositionCenterPoint(mc, new Vector2(vector3.x, localScreenSize.y * num));
				}
				else if ((safeHashtable.isBool("top") && safeHashtable.isTrue("top")) || safeHashtable.getInt("top") == 1)
				{
					mc.y = safeHashtable2.getFloat("y");
				}
			}
			if (safeHashtable.exists("bottom"))
			{
				if (safeHashtable.isString("bottom") && safeHashtable.getString("bottom", "").IndexOf("%") != -1)
				{
					Vector2 vector4 = safeHashtable2.getVector2("centrePoint");
					float num = 1f - float.Parse(safeHashtable.getString("bottom").Replace("%", "")) / 100f;
					setPositionCenterPoint(mc, new Vector2(vector4.x, localScreenSize.y * num));
				}
				else if ((safeHashtable.isBool("bottom") && safeHashtable.isTrue("bottom")) || safeHashtable.getInt("bottom") == 1)
				{
					mc.y = localScreenSize.y - (baselineSize.y - safeHashtable2.getFloat("y"));
				}
			}
			if (safeHashtable.isBool("relative") && safeHashtable.isTrue("relative"))
			{
				Vector2 vector5 = safeHashtable2.getVector2("centrePoint");
				float num2 = vector5.x / baselineSize.x;
				float num3 = vector5.y / baselineSize.y;
				setPositionCenterPoint(mc, new Vector2(localScreenSize.x * num2, localScreenSize.y * num3));
			}
			if (safeHashtable.isBool("relativeX") && safeHashtable.isTrue("relativeX"))
			{
				Vector2 vector6 = safeHashtable2.getVector2("centrePoint");
				float num = vector6.x / baselineSize.x;
				setPositionCenterPoint(mc, new Vector2(localScreenSize.x * num, vector6.y));
			}
			if (safeHashtable.isBool("relativeY") && safeHashtable.isTrue("relativeY"))
			{
				Vector2 vector7 = safeHashtable2.getVector2("centrePoint");
				float num = vector7.y / baselineSize.y;
				setPositionCenterPoint(mc, new Vector2(vector7.x, localScreenSize.y * num));
			}
			if (safeHashtable.getObject("relativeTo") is DisplayObject)
			{
				DisplayObject displayObject = safeHashtable.getObject("relativeTo") as DisplayObject;
				SafeHashtable safeHashtable3 = getOriginalProps(displayObject);
				float num4 = safeHashtable2.getFloat("x") - safeHashtable3.getFloat("x");
				float num5 = safeHashtable2.getFloat("y") - safeHashtable3.getFloat("y");
				mc.x = displayObject.x + num4;
				mc.y = displayObject.y + num5;
			}
		}

		public void autoRelative(DisplayObjectContainer root, Hashtable optionsIn)
		{
			SafeHashtable safeHashtable = new SafeHashtable(optionsIn);
			bool flag = safeHashtable.isTrue("autoScaleStage", true);
			bool flag2 = safeHashtable.isTrue("detectBackground", true);
			bool flag3 = safeHashtable.isTrue("detectEdges", true);
			float @float = safeHashtable.getFloat("detectEdgeBorder", defaultEdgeThreshold);
			object obj;
			if (safeHashtable.getObject("ignoreList") is IList)
			{
				IList list = safeHashtable.getObject("ignoreList") as IList;
				obj = list;
			}
			else
			{
				obj = new ArrayList();
			}
			IList list2 = (IList)obj;
			bool flag4 = safeHashtable.isTrue("detectHorizontalScale", defaultDetectHorizontalScale);
			if (flag)
			{
				autoScaleStage();
			}
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < ignoreList.Count; i++)
			{
				arrayList.Add(ignoreList[i]);
			}
			for (int i = 0; i < list2.Count; i++)
			{
				arrayList.Add(list2[i]);
			}
			ArrayList arrayList2 = new ArrayList();
			for (int i = 0; i < root.numChildren; i++)
			{
				DisplayObject childAt = root.getChildAt(i);
				if (arrayList.IndexOf(childAt.name) != -1 || string.IsNullOrEmpty(childAt.name))
				{
					continue;
				}
				if (flag2 && isBackground(childAt))
				{
					autoScaleBackground(childAt);
					arrayList2.Add(childAt);
				}
				else if (flag4 && isLeftEdge(childAt, @float) && isRightEdge(childAt, @float))
				{
					autoScaleHorizontally(childAt);
					if (isBottomEdge(childAt, @float))
					{
						position(childAt, new Hashtable { { "bottom", true } });
					}
				}
				else if (flag3 && isLeftEdge(childAt, @float))
				{
					position(childAt, new Hashtable { { "left", true } });
				}
				else if (flag3 && isRightEdge(childAt, @float))
				{
					position(childAt, new Hashtable { { "right", true } });
				}
				else
				{
					position(childAt, new Hashtable { { "relative", true } });
				}
			}
		}

		public void autoScaleHorizontally(DisplayObject mc)
		{
			SafeHashtable safeHashtable = getOriginalProps(mc);
			Rect rect = safeHashtable.getRect("bounds");
			float num = localScreenSize.x / rect.width;
			float scaleX = (mc.scaleY = num);
			mc.scaleX = scaleX;
			float num3 = rect.width * num;
			float num4 = rect.height * num;
			if (num3 < localScreenSize.x)
			{
				num = localScreenSize.x / rect.width;
				scaleX = (mc.scaleY = num);
				mc.scaleX = scaleX;
				num3 = rect.width * num;
				num4 = rect.height * num;
			}
			mc.x = localScreenSize.x / 2f - num3 / 2f - (rect.x - safeHashtable.getFloat("y")) * num;
		}

		public void layoutIgnore(DisplayObject mc)
		{
			if (ignoreList.IndexOf(mc) == -1)
			{
				ignoreList.Add(mc);
			}
		}

		public SafeHashtable getOriginalProps(DisplayObject mc)
		{
			if (originalProps == null)
			{
				originalProps = new Dictionary<string, SafeHashtable>();
			}
			if (!originalProps.ContainsKey(mc.name))
			{
				SafeHashtable safeHashtable = new SafeHashtable();
				safeHashtable.setObject("x", mc.x);
				safeHashtable.setObject("y", mc.y);
				safeHashtable.setObject("bounds", mc.getBounds(mc.parent).rect);
				safeHashtable.setObject("localBounds", mc.getBounds(null).rect);
				safeHashtable.setObject("centrePoint", getPositionCenterPoint(mc));
				originalProps[mc.name] = safeHashtable;
			}
			return originalProps[mc.name];
		}

		public bool isBackground(DisplayObject mc)
		{
			SafeHashtable safeHashtable = getOriginalProps(mc);
			Rect rect = safeHashtable.getRect("bounds");
			if (rect.x <= backgroundEdgeThreshold && rect.x + rect.width >= baselineSize.x - backgroundEdgeThreshold && rect.y <= backgroundEdgeThreshold && rect.y + rect.height >= baselineSize.y - backgroundEdgeThreshold)
			{
				return true;
			}
			if (isLeftEdge(mc, defaultThreshold) && isRightEdge(mc, defaultThreshold))
			{
				return true;
			}
			return false;
		}

		public bool isLeftEdge(DisplayObject mc, float threshold)
		{
			SafeHashtable safeHashtable = getOriginalProps(mc);
			Rect rect = safeHashtable.getRect("bounds");
			Vector2 vector = safeHashtable.getVector2("centrePoint");
			if (rect.x <= 0f && rect.x + rect.width >= 0f)
			{
				return true;
			}
			if (Math.Abs(vector.x) < threshold)
			{
				return true;
			}
			return false;
		}

		public bool isRightEdge(DisplayObject mc, float threshold)
		{
			SafeHashtable safeHashtable = getOriginalProps(mc);
			Rect rect = safeHashtable.getRect("bounds");
			Vector2 vector = safeHashtable.getVector2("centrePoint");
			if (rect.x <= baselineSize.x && rect.x + rect.width >= baselineSize.x)
			{
				return true;
			}
			if (Math.Abs(baselineSize.x - rect.x) / 2f < threshold)
			{
				return true;
			}
			if (Math.Abs(baselineSize.x - rect.x) / 2f < threshold)
			{
				return true;
			}
			if (Math.Abs(baselineSize.x - vector.x) < threshold)
			{
				return true;
			}
			return false;
		}

		public bool isBottomEdge(DisplayObject mc, float threshold)
		{
			SafeHashtable safeHashtable = getOriginalProps(mc);
			Rect rect = safeHashtable.getRect("bounds");
			if (rect.y <= baselineSize.y && rect.y + rect.height >= baselineSize.y)
			{
				return true;
			}
			if (Mathf.Abs(baselineSize.y - rect.y) / 2f < threshold)
			{
				return true;
			}
			if (Mathf.Abs(baselineSize.y - rect.y) / 2f < threshold)
			{
				return true;
			}
			if (Mathf.Abs(baselineSize.y - safeHashtable.getVector2("centrePoint").y) < threshold)
			{
				return true;
			}
			return false;
		}

		public Vector2 getPositionCenterPoint(DisplayObject mc)
		{
			Rect rect = mc.getBounds(null).rect;
			rect.x += mc.x;
			rect.y += mc.y;
			return new Vector2(rect.x + rect.width / 2f, rect.y + rect.height / 2f);
		}

		public void setPositionCenterPoint(DisplayObject mc, Vector2 pos)
		{
			SafeHashtable safeHashtable = getOriginalProps(mc);
			Rect rect = safeHashtable.getRect("localBounds");
			Rect rect2 = new Rect(rect.x, rect.y, rect.width, rect.height);
			rect2.x += safeHashtable.getFloat("x");
			rect2.y += safeHashtable.getFloat("y");
			mc.x = pos.x - (rect2.x - safeHashtable.getFloat("x")) - rect2.width / 2f;
			mc.y = pos.y - (rect2.y - safeHashtable.getFloat("y")) - rect2.height / 2f;
		}

		public void resetLayout(DisplayObjectContainer root)
		{
			if (originalProps == null || originalProps.Count == 0)
			{
				return;
			}
			for (int i = 0; i < root.numChildren; i++)
			{
				DisplayObject childAt = root.getChildAt(i);
				if (originalProps.ContainsKey(childAt.name))
				{
					childAt.x = originalProps[childAt.name].getFloat("x");
					childAt.y = originalProps[childAt.name].getFloat("y");
				}
			}
		}
	}
}
