using System.Collections;
using UnityEngine;

namespace pumpkin.utils
{
	public class SafeHashtable
	{
		protected Hashtable m_Hash;

		public SafeHashtable()
		{
			m_Hash = new Hashtable();
		}

		public SafeHashtable(Hashtable hash)
		{
			if (hash != null)
			{
				m_Hash = hash;
			}
			else
			{
				m_Hash = new Hashtable();
			}
		}

		public object getObject(string name)
		{
			return getObject(name, null);
		}

		public object getObject(string name, object defaultValue)
		{
			if (!m_Hash.ContainsKey(name))
			{
				return defaultValue;
			}
			return m_Hash[name];
		}

		public Rect getRect(string name)
		{
			return getRect(name, default(Rect));
		}

		public Rect getRect(string name, Rect defaultValue)
		{
			if (!m_Hash.ContainsKey(name))
			{
				return defaultValue;
			}
			if (!(m_Hash[name] is Rect))
			{
				return defaultValue;
			}
			return (Rect)m_Hash[name];
		}

		public float getFloat(string name)
		{
			return getFloat(name, 0f);
		}

		public float getFloat(string name, float defaultValue)
		{
			if (!m_Hash.ContainsKey(name))
			{
				return defaultValue;
			}
			if (!(m_Hash[name] is float))
			{
				return defaultValue;
			}
			return (float)m_Hash[name];
		}

		public int getInt(string name)
		{
			return getInt(name, 0);
		}

		public int getInt(string name, int defaultValue)
		{
			if (!m_Hash.ContainsKey(name))
			{
				return defaultValue;
			}
			if (!(m_Hash[name] is int))
			{
				return defaultValue;
			}
			return (int)m_Hash[name];
		}

		public string getString(string name)
		{
			return getString(name, null);
		}

		public string getString(string name, string defaultValue)
		{
			if (!m_Hash.ContainsKey(name))
			{
				return defaultValue;
			}
			if (!(m_Hash[name] is string))
			{
				return defaultValue;
			}
			return (string)m_Hash[name];
		}

		public Vector2 getVector2(string name)
		{
			return getVector2(name, default(Vector2));
		}

		public Vector2 getVector2(string name, Vector2 defaultValue)
		{
			if (!m_Hash.ContainsKey(name))
			{
				return defaultValue;
			}
			if (!(m_Hash[name] is Vector2))
			{
				return defaultValue;
			}
			return (Vector2)m_Hash[name];
		}

		public void setObject(string name, object objectValue)
		{
			m_Hash[name] = objectValue;
		}

		public void setBool(string name, bool objectValue)
		{
			m_Hash[name] = objectValue;
		}

		public void setInt(string name, int objectValue)
		{
			m_Hash[name] = objectValue;
		}

		public void setFloat(string name, float objectValue)
		{
			m_Hash[name] = objectValue;
		}

		public void setString(string name, string objectValue)
		{
			m_Hash[name] = objectValue;
		}

		public void setVector2(string name, Vector2 objectValue)
		{
			m_Hash[name] = objectValue;
		}

		public void setVector3(string name, Vector3 objectValue)
		{
			m_Hash[name] = objectValue;
		}

		public bool isRect(string name)
		{
			if (!m_Hash.ContainsKey(name))
			{
				return false;
			}
			return m_Hash[name] is Rect;
		}

		public bool isFloat(string name)
		{
			if (!m_Hash.ContainsKey(name))
			{
				return false;
			}
			return m_Hash[name] is float;
		}

		public bool isInt(string name)
		{
			if (!m_Hash.ContainsKey(name))
			{
				return false;
			}
			return m_Hash[name] is int;
		}

		public bool isString(string name)
		{
			if (!m_Hash.ContainsKey(name))
			{
				return false;
			}
			return m_Hash[name] is string;
		}

		public bool isBool(string name)
		{
			if (!m_Hash.ContainsKey(name))
			{
				return false;
			}
			return m_Hash[name] is bool;
		}

		public bool isTrue(string name)
		{
			return isTrue(name, false);
		}

		public bool isTrue(string name, bool defaultValue)
		{
			if (!m_Hash.ContainsKey(name))
			{
				return defaultValue;
			}
			if (!(m_Hash[name] is bool))
			{
				return defaultValue;
			}
			return (bool)m_Hash[name];
		}

		public bool exists(string name)
		{
			if (name == null)
			{
				return false;
			}
			return m_Hash.ContainsKey(name);
		}

		public string dumpToString()
		{
			string text = "";
			foreach (string key in m_Hash.Keys)
			{
				string text3 = text;
				text = string.Concat(text3, "Key: ", key, " : ", m_Hash[key], "\n");
			}
			return text;
		}

		public Hashtable getInternalHashtable()
		{
			return m_Hash;
		}
	}
}
