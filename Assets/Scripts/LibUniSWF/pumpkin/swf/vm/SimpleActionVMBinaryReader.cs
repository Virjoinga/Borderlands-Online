using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using pumpkin.swf.swfFormat;

namespace pumpkin.swf.vm
{
	public class SimpleActionVMBinaryReader
	{
		internal static List<SimpleActionOP> decodeBinary(Dictionary<string, Type> registry, SwfBinaryReader b)
		{
			int num = b.ReadInt16();
			if (num <= 0)
			{
				return null;
			}
			List<SimpleActionOP> list = new List<SimpleActionOP>();
			Section2 section = new Section2();
			for (int i = 0; i < num; i++)
			{
				section.initFromReader(b);
				if (section.type != MovieClipReader.TYPE_ACTIONOP)
				{
					section.end();
					continue;
				}
				string text = section.readString();
				if (registry.ContainsKey(text))
				{
					SimpleActionOP simpleActionOP = (SimpleActionOP)Activator.CreateInstance(registry[text]);
					mapPropsToOP(simpleActionOP, b);
					list.Add(simpleActionOP);
					section.end();
				}
				else
				{
					Debug.LogError("Failed to find a VM OP named '" + text + "'");
				}
			}
			return list;
		}

		internal static void mapPropsToOP(SimpleActionOP op, SwfBinaryReader b)
		{
			Hashtable hashtable = decodeParamsHashtable(b, null);
			foreach (string key in hashtable.Keys)
			{
				FieldInfo field = op.GetType().GetField(key);
				if (field == null)
				{
					continue;
				}
				object obj = hashtable[key];
				if (obj != null)
				{
					try
					{
						field.SetValue(op, obj);
					}
					catch (Exception ex)
					{
						Debug.LogError("Failed to apply vm prop '" + key + "', reason: " + ex);
					}
				}
			}
		}

		internal static Hashtable decodeParamsHashtable(SwfBinaryReader b, Section2 dictSection)
		{
			Hashtable hashtable = new Hashtable();
			if (dictSection == null)
			{
				dictSection = new Section2(b);
			}
			if (dictSection.type != MovieClipReader.TYPE_DICTIONARY)
			{
				dictSection.end();
				return hashtable;
			}
			int num = dictSection.readInt();
			if (num <= 0)
			{
				return hashtable;
			}
			for (int i = 0; i < num; i++)
			{
				string key = dictSection.readString();
				hashtable[key] = decodeParam(b);
			}
			dictSection.end();
			return hashtable;
		}

		internal static ArrayList decodeParamsArray(SwfBinaryReader b, Section2 arraySection)
		{
			ArrayList arrayList = new ArrayList();
			if (arraySection == null)
			{
				arraySection = new Section2(b);
			}
			if (arraySection.type != MovieClipReader.TYPE_ARRAY)
			{
				arraySection.end();
				return arrayList;
			}
			int num = arraySection.readInt();
			if (num <= 0)
			{
				return arrayList;
			}
			for (int i = 0; i < num; i++)
			{
				arrayList.Add(decodeParam(b));
			}
			return arrayList;
		}

		internal static object decodeParam(SwfBinaryReader b)
		{
			Section2 section = new Section2(b);
			object obj = null;
			if (section.type == MovieClipReader.TYPE_INT)
			{
				obj = section.readInt();
			}
			else if (section.type == MovieClipReader.TYPE_FLOAT)
			{
				obj = section.readFloat();
			}
			else if (section.type == MovieClipReader.TYPE_STRING_UTF8)
			{
				obj = section.readString();
			}
			else if (section.type == MovieClipReader.TYPE_ARRAY)
			{
				obj = decodeParamsArray(b, section);
			}
			else
			{
				if (section.type != MovieClipReader.TYPE_DICTIONARY)
				{
					return null;
				}
				obj = decodeParamsHashtable(b, section);
			}
			section.end();
			return obj;
		}
	}
}
