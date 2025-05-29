using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using UnityEngine;
using XsdSettings;

public class Utils : MonoBehaviour
{
	public class Timer
	{
		private bool m_isRunning;

		private float m_startTime;

		private float m_duration;

		private float m_pauseTime;

		public override string ToString()
		{
			return cd5e6d79e1eab50259fd3eabb6af0bfd5().ToString();
		}

		public float cd5e6d79e1eab50259fd3eabb6af0bfd5()
		{
			if (m_isRunning)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
					{
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						float time = Time.time;
						float a = m_duration - (time - m_startTime);
						return Mathf.Max(a, 0f);
					}
					}
				}
			}
			return 0f;
		}

		public float c8d61bc457bf1e08126a3d9d2111b25df()
		{
			if (m_isRunning)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						return Mathf.Clamp((Time.time - m_startTime) / m_duration, 0f, 1f);
					}
				}
			}
			return 0f;
		}

		public void Start(float duration)
		{
			m_duration = duration;
			m_startTime = Time.time;
			m_isRunning = true;
		}

		public void cdada4c3678c9c23c38aaf0754a94a620()
		{
			if (!m_isRunning)
			{
				return;
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				m_pauseTime = Time.time;
				m_isRunning = false;
				return;
			}
		}

		public void ccd732382db3f35031907fee9ca4c7dfc()
		{
			if (m_isRunning)
			{
				return;
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				float duration = m_duration - (m_pauseTime - m_startTime);
				Start(duration);
				return;
			}
		}

		public bool cb261500372fa488b369e9159a002977a()
		{
			return m_isRunning;
		}

		public bool cf928603d375f06225f9eb5213fb17bd4()
		{
			if (m_isRunning)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
					{
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						float time = Time.time;
						bool flag = time - m_startTime > m_duration;
						if (flag)
						{
							while (true)
							{
								switch (4)
								{
								case 0:
									continue;
								}
								break;
							}
							cdada4c3678c9c23c38aaf0754a94a620();
						}
						return flag;
					}
					}
				}
			}
			return false;
		}

		public void cbc7bb46a052fc3a5521eb00eb22b1beb(float c4137c9b4d8c16b4f81b6060933e9e663)
		{
			if (!m_isRunning)
			{
				return;
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				float num = Mathf.Clamp(c8d61bc457bf1e08126a3d9d2111b25df() + c4137c9b4d8c16b4f81b6060933e9e663, 0f, 1f);
				m_startTime = Time.time - num * m_duration;
				return;
			}
		}

		public void c5a00d1ab96cc4cdd950eefdf7ac6be0c(float cc896a4245d10c6b0a8b1d05726c40fc8)
		{
			if (!m_isRunning)
			{
				return;
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				m_duration += cc896a4245d10c6b0a8b1d05726c40fc8;
				return;
			}
		}
	}

	public struct Pouch
	{
		private int m_maxValue;

		private int m_currentValue;

		private int m_baseMaxValue;

		public void ccc9d3a38966dc10fedb531ea17d24611(int ce565b32ce48270d8a80781c7ab11cae6)
		{
			m_maxValue = ce565b32ce48270d8a80781c7ab11cae6;
			m_currentValue = m_maxValue;
			m_baseMaxValue = ce565b32ce48270d8a80781c7ab11cae6;
		}

		public void ccc9d3a38966dc10fedb531ea17d24611(int c0c1c4c5b37e56ec5d9d86749707e1bef, int ce565b32ce48270d8a80781c7ab11cae6)
		{
			m_maxValue = ce565b32ce48270d8a80781c7ab11cae6;
			m_currentValue = c0c1c4c5b37e56ec5d9d86749707e1bef;
			m_baseMaxValue = ce565b32ce48270d8a80781c7ab11cae6;
		}

		public void c0f566cbc91a795394e7799bfdbd784f8()
		{
			if (m_currentValue == m_maxValue)
			{
				return;
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				m_currentValue = m_maxValue;
				return;
			}
		}

		public void c9172684ab57085e2a77c2a3af69cb426(int cefda2fdc3ce4e04f38bab77fc7998241)
		{
			m_currentValue = Mathf.Min(m_maxValue, m_currentValue + cefda2fdc3ce4e04f38bab77fc7998241);
		}

		public int c17a506784adea8f822bee98ad9dba710()
		{
			return m_maxValue;
		}

		public int c4c4b463091d2b6acfdded4fa12b32f25()
		{
			return m_currentValue;
		}

		public int c3326a47fbaf3911cb03db331d9fcd9bf()
		{
			return m_baseMaxValue;
		}

		public void c82133ff2bb787510ed8585dd3d834b59(int cefda2fdc3ce4e04f38bab77fc7998241)
		{
			if (m_maxValue == cefda2fdc3ce4e04f38bab77fc7998241)
			{
				return;
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				m_maxValue = cefda2fdc3ce4e04f38bab77fc7998241;
				return;
			}
		}

		public void ca0f7f52805a9c67a892c5b479a17c3aa(int cefda2fdc3ce4e04f38bab77fc7998241)
		{
			cefda2fdc3ce4e04f38bab77fc7998241 = Mathf.Min(cefda2fdc3ce4e04f38bab77fc7998241, m_maxValue);
			cefda2fdc3ce4e04f38bab77fc7998241 = Mathf.Max(cefda2fdc3ce4e04f38bab77fc7998241, 0);
			if (m_currentValue == cefda2fdc3ce4e04f38bab77fc7998241)
			{
				return;
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				m_currentValue = cefda2fdc3ce4e04f38bab77fc7998241;
				return;
			}
		}

		public void cc934e25bb0ce6d2db75ef537501c8237(int cefda2fdc3ce4e04f38bab77fc7998241)
		{
			m_baseMaxValue = cefda2fdc3ce4e04f38bab77fc7998241;
		}
	}

	public class PouchNetwork
	{
		private bool authority = true;

		private Pouch m_authorityPouch;

		private Pouch m_localPouch;

		public void ccc9d3a38966dc10fedb531ea17d24611(int ce565b32ce48270d8a80781c7ab11cae6)
		{
			m_authorityPouch.ccc9d3a38966dc10fedb531ea17d24611(ce565b32ce48270d8a80781c7ab11cae6);
			m_localPouch.ccc9d3a38966dc10fedb531ea17d24611(ce565b32ce48270d8a80781c7ab11cae6);
		}

		public void ccc9d3a38966dc10fedb531ea17d24611(int c0c1c4c5b37e56ec5d9d86749707e1bef, int ce565b32ce48270d8a80781c7ab11cae6)
		{
			m_authorityPouch.ccc9d3a38966dc10fedb531ea17d24611(c0c1c4c5b37e56ec5d9d86749707e1bef, ce565b32ce48270d8a80781c7ab11cae6);
			m_localPouch.ccc9d3a38966dc10fedb531ea17d24611(c0c1c4c5b37e56ec5d9d86749707e1bef, ce565b32ce48270d8a80781c7ab11cae6);
		}

		public void c0f566cbc91a795394e7799bfdbd784f8()
		{
			if (authority)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						m_authorityPouch.c0f566cbc91a795394e7799bfdbd784f8();
						return;
					}
				}
			}
			m_localPouch.c0f566cbc91a795394e7799bfdbd784f8();
		}

		public void c9172684ab57085e2a77c2a3af69cb426(int cefda2fdc3ce4e04f38bab77fc7998241)
		{
			if (authority)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						m_authorityPouch.c9172684ab57085e2a77c2a3af69cb426(cefda2fdc3ce4e04f38bab77fc7998241);
						return;
					}
				}
			}
			m_localPouch.c9172684ab57085e2a77c2a3af69cb426(cefda2fdc3ce4e04f38bab77fc7998241);
		}

		public int c17a506784adea8f822bee98ad9dba710()
		{
			if (authority)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						return m_authorityPouch.c17a506784adea8f822bee98ad9dba710();
					}
				}
			}
			return m_localPouch.c17a506784adea8f822bee98ad9dba710();
		}

		public int c4c4b463091d2b6acfdded4fa12b32f25()
		{
			if (authority)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						return m_authorityPouch.c4c4b463091d2b6acfdded4fa12b32f25();
					}
				}
			}
			return m_localPouch.c4c4b463091d2b6acfdded4fa12b32f25();
		}

		public int c3326a47fbaf3911cb03db331d9fcd9bf()
		{
			if (authority)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						return m_authorityPouch.c3326a47fbaf3911cb03db331d9fcd9bf();
					}
				}
			}
			return m_localPouch.c3326a47fbaf3911cb03db331d9fcd9bf();
		}

		public void c82133ff2bb787510ed8585dd3d834b59(int cefda2fdc3ce4e04f38bab77fc7998241)
		{
			if (authority)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						m_authorityPouch.c82133ff2bb787510ed8585dd3d834b59(cefda2fdc3ce4e04f38bab77fc7998241);
						return;
					}
				}
			}
			m_localPouch.c82133ff2bb787510ed8585dd3d834b59(cefda2fdc3ce4e04f38bab77fc7998241);
		}

		public void ca0f7f52805a9c67a892c5b479a17c3aa(int cefda2fdc3ce4e04f38bab77fc7998241)
		{
			if (authority)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						m_authorityPouch.ca0f7f52805a9c67a892c5b479a17c3aa(cefda2fdc3ce4e04f38bab77fc7998241);
						return;
					}
				}
			}
			m_localPouch.ca0f7f52805a9c67a892c5b479a17c3aa(cefda2fdc3ce4e04f38bab77fc7998241);
		}

		public void cc934e25bb0ce6d2db75ef537501c8237(int cefda2fdc3ce4e04f38bab77fc7998241)
		{
			if (authority)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						m_authorityPouch.cc934e25bb0ce6d2db75ef537501c8237(cefda2fdc3ce4e04f38bab77fc7998241);
						return;
					}
				}
			}
			m_localPouch.cc934e25bb0ce6d2db75ef537501c8237(cefda2fdc3ce4e04f38bab77fc7998241);
		}

		public void c06ade3733c4658b091be622d9d3b4034()
		{
			authority = true;
		}

		public void cdfac57bd798072bd71a801c00909ad5c()
		{
			authority = false;
			m_localPouch = m_authorityPouch;
		}
	}

	public struct CacheFloatToInt
	{
		private float m_sum;

		public int c9172684ab57085e2a77c2a3af69cb426(float c60c59086c805e1f2f51383ae30aa35bd)
		{
			m_sum += c60c59086c805e1f2f51383ae30aa35bd;
			int num = Mathf.FloorToInt(m_sum);
			if (num > 0)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				m_sum -= num;
			}
			return num;
		}
	}

	public class CacheSeconds
	{
		private float m_sum;

		private float m_duration;

		private float m_startTime;

		public CacheSeconds(float c704812431a0b104a6ced6cea948cd0e8)
		{
			m_duration = c704812431a0b104a6ced6cea948cd0e8;
		}

		public int c9172684ab57085e2a77c2a3af69cb426(float c60c59086c805e1f2f51383ae30aa35bd)
		{
			int num = 0;
			m_sum += c60c59086c805e1f2f51383ae30aa35bd;
			if (Time.time - m_startTime >= m_duration)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				m_startTime = Time.time;
				num = Mathf.FloorToInt(m_sum);
				if (num > 0)
				{
					while (true)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						break;
					}
					m_sum -= num;
				}
			}
			return num;
		}
	}

	public class StaticRandom
	{
		private static float[] randomList;

		static StaticRandom()
		{
			float[] array = c45a99a14f737cada4caa361b45034f4d.c0a0cdf4a196914163f7334d9b0781a04(1000);
			RuntimeHelpers.InitializeArray(array, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
			randomList = array;
		}

		public static float c588e7dbcd383d8230b2d83d7b44af23b(int cafa0d5e23a9ceb3de45a25d5526eb91b)
		{
			return randomList[cafa0d5e23a9ceb3de45a25d5526eb91b % randomList.Length];
		}
	}

	private const string CLONE_MARKER = "(Clone)";

	public static Entity c15742cbc29c57b6f2724112b6bc5a5b2(GameObject ca3706854b3073a0804de98d5202b25f4)
	{
		if (ca3706854b3073a0804de98d5202b25f4 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				break;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			Transform parent = ca3706854b3073a0804de98d5202b25f4.transform;
			while ((bool)parent)
			{
				Entity component = parent.GetComponent<Entity>();
				if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							return component;
						}
					}
				}
				parent = parent.parent;
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				break;
			}
		}
		return null;
	}

	public static void c3bf54d312726877e5f77b6d475aef510(Entity c5d720f6d007abb0c4a21d6a654e405bb)
	{
		Vector3 position = c5d720f6d007abb0c4a21d6a654e405bb.transform.position;
		float entityHeight = c5d720f6d007abb0c4a21d6a654e405bb.m_entityHeight;
		RaycastHit hitInfo;
		if (!Physics.Raycast(position, -Vector3.up, out hitInfo, entityHeight * 4f))
		{
			return;
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			position.y = hitInfo.point.y + entityHeight * 0.5f;
			c5d720f6d007abb0c4a21d6a654e405bb.transform.position = position;
			return;
		}
	}

	public static bool cf2dc852cbf0274577dab9b8d1236b7a7(object ca3d8e9d8aa8654004cb491578986b996, object c1444c3ec10ef341ecd4f6247b3922171)
	{
		if (ca3d8e9d8aa8654004cb491578986b996 != null)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				break;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (c1444c3ec10ef341ecd4f6247b3922171 != null)
			{
				if (!ca3d8e9d8aa8654004cb491578986b996.Equals(c1444c3ec10ef341ecd4f6247b3922171))
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							if (ca3d8e9d8aa8654004cb491578986b996 is Vector3)
							{
								while (true)
								{
									switch (1)
									{
									case 0:
										continue;
									}
									break;
								}
								Vector3 c82fcbab5e578dc3a31c1f662916bd87e = (Vector3)ca3d8e9d8aa8654004cb491578986b996;
								Vector3 cb3d2bffae21da96491575e42414232f = (Vector3)c1444c3ec10ef341ecd4f6247b3922171;
								if (c82fcbab5e578dc3a31c1f662916bd87e.ce5aad699df330ff708587e4fabea8cbb(cb3d2bffae21da96491575e42414232f, PhotonNetwork.precisionForVectorSynchronization))
								{
									while (true)
									{
										switch (7)
										{
										case 0:
											break;
										default:
											return true;
										}
									}
								}
							}
							else if (ca3d8e9d8aa8654004cb491578986b996 is Vector2)
							{
								while (true)
								{
									switch (2)
									{
									case 0:
										continue;
									}
									break;
								}
								Vector2 c82fcbab5e578dc3a31c1f662916bd87e2 = (Vector2)ca3d8e9d8aa8654004cb491578986b996;
								Vector2 cb3d2bffae21da96491575e42414232f2 = (Vector2)c1444c3ec10ef341ecd4f6247b3922171;
								if (c82fcbab5e578dc3a31c1f662916bd87e2.ce5aad699df330ff708587e4fabea8cbb(cb3d2bffae21da96491575e42414232f2, PhotonNetwork.precisionForVectorSynchronization))
								{
									while (true)
									{
										switch (3)
										{
										case 0:
											break;
										default:
											return true;
										}
									}
								}
							}
							else if (ca3d8e9d8aa8654004cb491578986b996 is Quaternion)
							{
								while (true)
								{
									switch (5)
									{
									case 0:
										continue;
									}
									break;
								}
								Quaternion c82fcbab5e578dc3a31c1f662916bd87e3 = (Quaternion)ca3d8e9d8aa8654004cb491578986b996;
								Quaternion cb3d2bffae21da96491575e42414232f3 = (Quaternion)c1444c3ec10ef341ecd4f6247b3922171;
								if (c82fcbab5e578dc3a31c1f662916bd87e3.ce5aad699df330ff708587e4fabea8cbb(cb3d2bffae21da96491575e42414232f3, PhotonNetwork.precisionForQuaternionSynchronization))
								{
									while (true)
									{
										switch (3)
										{
										case 0:
											break;
										default:
											return true;
										}
									}
								}
							}
							else if (ca3d8e9d8aa8654004cb491578986b996 is float)
							{
								while (true)
								{
									switch (7)
									{
									case 0:
										continue;
									}
									break;
								}
								float c82fcbab5e578dc3a31c1f662916bd87e4 = (float)ca3d8e9d8aa8654004cb491578986b996;
								float cb3d2bffae21da96491575e42414232f4 = (float)c1444c3ec10ef341ecd4f6247b3922171;
								if (c82fcbab5e578dc3a31c1f662916bd87e4.ce5aad699df330ff708587e4fabea8cbb(cb3d2bffae21da96491575e42414232f4, PhotonNetwork.precisionForFloatSynchronization))
								{
									while (true)
									{
										switch (3)
										{
										case 0:
											break;
										default:
											return true;
										}
									}
								}
							}
							return false;
						}
					}
				}
				return true;
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				break;
			}
		}
		int result;
		if (ca3d8e9d8aa8654004cb491578986b996 == null)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				break;
			}
			result = ((c1444c3ec10ef341ecd4f6247b3922171 == c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e) ? 1 : 0);
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public static void ce6378e8b5a8ae9a4202182e1876677fe(Transform c3cb1f1345dbfd94c51709a9b2e9a9704, int c329db3bbe38dc031eb08c342538daa1a, bool cba9190ceb405f4119e92b51af7ea04d1 = false)
	{
		Stack<Transform> stack = new Stack<Transform>();
		stack.Push(c3cb1f1345dbfd94c51709a9b2e9a9704);
		while (stack.Count != 0)
		{
			Transform transform = stack.Pop();
			transform.gameObject.layer = c329db3bbe38dc031eb08c342538daa1a;
			for (int i = 0; i < transform.childCount; i++)
			{
				GameObject gameObject = transform.GetChild(i).gameObject;
				if (cba9190ceb405f4119e92b51af7ea04d1)
				{
					while (true)
					{
						switch (4)
						{
						case 0:
							continue;
						}
						break;
					}
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					if (gameObject.name.ToLower() == "displayobj")
					{
						while (true)
						{
							switch (1)
							{
							case 0:
								continue;
							}
							break;
						}
						continue;
					}
				}
				stack.Push(gameObject.transform);
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				break;
			}
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	public static void cb134d1f6198119cfd86f7cf4a4e3eedb(Transform c3cb1f1345dbfd94c51709a9b2e9a9704, string c0aa2b94b916f2fc817545ff787bdea7a, string c2fb3fb84abbdc1204d041c292e24fac0)
	{
		int num = LayerMask.NameToLayer(c0aa2b94b916f2fc817545ff787bdea7a);
		int layer = LayerMask.NameToLayer(c2fb3fb84abbdc1204d041c292e24fac0);
		Stack<Transform> stack = new Stack<Transform>();
		stack.Push(c3cb1f1345dbfd94c51709a9b2e9a9704);
		while (stack.Count != 0)
		{
			Transform transform = stack.Pop();
			if (transform.gameObject.layer == num)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					break;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				transform.gameObject.layer = layer;
			}
			for (int i = 0; i < transform.childCount; i++)
			{
				GameObject gameObject = transform.GetChild(i).gameObject;
				stack.Push(gameObject.transform);
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				break;
			}
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	public static int c61d61bbff7c3f4170e4d5b91619538d4(object ca87683771f895c903c0b6c97a8f34137)
	{
		int num = 0;
		if (ca87683771f895c903c0b6c97a8f34137 is Hashtable)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return num + c48ad35a6532e0c5642de63db021aab5a((Hashtable)ca87683771f895c903c0b6c97a8f34137);
				}
			}
		}
		if (ca87683771f895c903c0b6c97a8f34137 is IEnumerable)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					return num + c6db4f032b7b082fbff1ffeb6ed1ddf1b((IEnumerable)ca87683771f895c903c0b6c97a8f34137);
				}
			}
		}
		if (ca87683771f895c903c0b6c97a8f34137 is DictionaryEntry)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					return num + c3817b6b397e23d7c01ad13af5401f02b((DictionaryEntry)ca87683771f895c903c0b6c97a8f34137);
				}
			}
		}
		return num + BolCustomType.c3201deb4f4d63f1b77df235945b0cdd2(ca87683771f895c903c0b6c97a8f34137);
	}

	public static int c48ad35a6532e0c5642de63db021aab5a(Hashtable c28cf3d24e3067ef54895f824fad7fcef)
	{
		int num = 3;
		IEnumerator enumerator = c28cf3d24e3067ef54895f824fad7fcef.Values.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				num += c61d61bbff7c3f4170e4d5b91619538d4(current);
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				break;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable == null)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						goto end_IL_0053;
					}
					continue;
					end_IL_0053:
					break;
				}
			}
			else
			{
				disposable.Dispose();
			}
		}
		IEnumerator enumerator2 = c28cf3d24e3067ef54895f824fad7fcef.Keys.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				object current2 = enumerator2.Current;
				num += c61d61bbff7c3f4170e4d5b91619538d4(current2);
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				return num;
			}
		}
		finally
		{
			IDisposable disposable2 = enumerator2 as IDisposable;
			if (disposable2 == null)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						goto end_IL_00b2;
					}
					continue;
					end_IL_00b2:
					break;
				}
			}
			else
			{
				disposable2.Dispose();
			}
		}
	}

	public static int c6db4f032b7b082fbff1ffeb6ed1ddf1b(IEnumerable caae13fda89fbfb710ef14a2e5696772c)
	{
		int num = 4;
		IEnumerator enumerator = caae13fda89fbfb710ef14a2e5696772c.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				num += c61d61bbff7c3f4170e4d5b91619538d4(current);
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				break;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable == null)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						goto end_IL_004a;
					}
					continue;
					end_IL_004a:
					break;
				}
			}
			else
			{
				disposable.Dispose();
			}
		}
		return num;
	}

	public static int c3817b6b397e23d7c01ad13af5401f02b(DictionaryEntry c2bd409f3180456e111fd1ee81fbf1e26)
	{
		int num = 0;
		num += c61d61bbff7c3f4170e4d5b91619538d4(c2bd409f3180456e111fd1ee81fbf1e26.Key);
		return num + c61d61bbff7c3f4170e4d5b91619538d4(c2bd409f3180456e111fd1ee81fbf1e26.Value);
	}

	public static float cf2401d2b4bbb3c183866f9133a022812(float cae5fea398599f41bfafc9b6bb6f4559b, float c6cb66aa8544c442eb14b92180640f843, float c892246130fbeaf4178cac23e3076494d)
	{
		float num = cae5fea398599f41bfafc9b6bb6f4559b;
		if (Mathf.Abs(cae5fea398599f41bfafc9b6bb6f4559b - c6cb66aa8544c442eb14b92180640f843) < 0.001f)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return c6cb66aa8544c442eb14b92180640f843;
				}
			}
		}
		return Mathf.Lerp(cae5fea398599f41bfafc9b6bb6f4559b, c6cb66aa8544c442eb14b92180640f843, c892246130fbeaf4178cac23e3076494d);
	}

	public static Vector3 cf2401d2b4bbb3c183866f9133a022812(Vector3 cae5fea398599f41bfafc9b6bb6f4559b, Vector3 c6cb66aa8544c442eb14b92180640f843, float c892246130fbeaf4178cac23e3076494d)
	{
		Vector3 vector = cae5fea398599f41bfafc9b6bb6f4559b;
		if (Vector3.Distance(cae5fea398599f41bfafc9b6bb6f4559b, c6cb66aa8544c442eb14b92180640f843) < 0.001f)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return c6cb66aa8544c442eb14b92180640f843;
				}
			}
		}
		return Vector3.Lerp(cae5fea398599f41bfafc9b6bb6f4559b, c6cb66aa8544c442eb14b92180640f843, c892246130fbeaf4178cac23e3076494d);
	}

	public static void c2a8451521957c62f3c9e4fe1e3e5797d(ref Camera ccdb5ad90d78d57bee444842b91e17f47, ref Camera ce9c13b7b6cae85fd221d6ac886894eee)
	{
		ce9c13b7b6cae85fd221d6ac886894eee.fieldOfView = ccdb5ad90d78d57bee444842b91e17f47.fieldOfView;
		ce9c13b7b6cae85fd221d6ac886894eee.nearClipPlane = ccdb5ad90d78d57bee444842b91e17f47.nearClipPlane;
		ce9c13b7b6cae85fd221d6ac886894eee.farClipPlane = ccdb5ad90d78d57bee444842b91e17f47.farClipPlane;
		ce9c13b7b6cae85fd221d6ac886894eee.renderingPath = ccdb5ad90d78d57bee444842b91e17f47.renderingPath;
		ce9c13b7b6cae85fd221d6ac886894eee.hdr = ccdb5ad90d78d57bee444842b91e17f47.hdr;
		ce9c13b7b6cae85fd221d6ac886894eee.orthographicSize = ccdb5ad90d78d57bee444842b91e17f47.orthographicSize;
		ce9c13b7b6cae85fd221d6ac886894eee.orthographic = ccdb5ad90d78d57bee444842b91e17f47.orthographic;
		ce9c13b7b6cae85fd221d6ac886894eee.transparencySortMode = ccdb5ad90d78d57bee444842b91e17f47.transparencySortMode;
		ce9c13b7b6cae85fd221d6ac886894eee.depth = ccdb5ad90d78d57bee444842b91e17f47.depth;
		ce9c13b7b6cae85fd221d6ac886894eee.aspect = ccdb5ad90d78d57bee444842b91e17f47.aspect;
		ce9c13b7b6cae85fd221d6ac886894eee.cullingMask = ccdb5ad90d78d57bee444842b91e17f47.cullingMask;
		ce9c13b7b6cae85fd221d6ac886894eee.eventMask = ccdb5ad90d78d57bee444842b91e17f47.eventMask;
		ce9c13b7b6cae85fd221d6ac886894eee.backgroundColor = ccdb5ad90d78d57bee444842b91e17f47.backgroundColor;
		ce9c13b7b6cae85fd221d6ac886894eee.rect = ccdb5ad90d78d57bee444842b91e17f47.rect;
		ce9c13b7b6cae85fd221d6ac886894eee.pixelRect = ccdb5ad90d78d57bee444842b91e17f47.pixelRect;
		ce9c13b7b6cae85fd221d6ac886894eee.targetTexture = ccdb5ad90d78d57bee444842b91e17f47.targetTexture;
		ce9c13b7b6cae85fd221d6ac886894eee.worldToCameraMatrix = ccdb5ad90d78d57bee444842b91e17f47.worldToCameraMatrix;
		ce9c13b7b6cae85fd221d6ac886894eee.projectionMatrix = ccdb5ad90d78d57bee444842b91e17f47.projectionMatrix;
		ce9c13b7b6cae85fd221d6ac886894eee.clearFlags = ccdb5ad90d78d57bee444842b91e17f47.clearFlags;
		ce9c13b7b6cae85fd221d6ac886894eee.useOcclusionCulling = ccdb5ad90d78d57bee444842b91e17f47.useOcclusionCulling;
		ce9c13b7b6cae85fd221d6ac886894eee.layerCullDistances = ccdb5ad90d78d57bee444842b91e17f47.layerCullDistances;
		ce9c13b7b6cae85fd221d6ac886894eee.layerCullSpherical = ccdb5ad90d78d57bee444842b91e17f47.layerCullSpherical;
		ce9c13b7b6cae85fd221d6ac886894eee.depthTextureMode = ccdb5ad90d78d57bee444842b91e17f47.depthTextureMode;
		ce9c13b7b6cae85fd221d6ac886894eee.transform.position = ccdb5ad90d78d57bee444842b91e17f47.transform.position;
		ce9c13b7b6cae85fd221d6ac886894eee.transform.rotation = ccdb5ad90d78d57bee444842b91e17f47.transform.rotation;
	}

	public static float cae03c409152de312b7950c98c6058048(Ray cdb5cb253ef1339831696a37475f7233f, Vector3 c330987c4414f384d6c951ab9f68460d8)
	{
		Vector3 lhs = c330987c4414f384d6c951ab9f68460d8 - cdb5cb253ef1339831696a37475f7233f.origin;
		float num = Vector3.Dot(lhs, cdb5cb253ef1339831696a37475f7233f.direction.normalized);
		Vector3 origin = cdb5cb253ef1339831696a37475f7233f.origin;
		if (num > 0f)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				break;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			origin += cdb5cb253ef1339831696a37475f7233f.direction.normalized * num;
		}
		return Vector3.Distance(origin, c330987c4414f384d6c951ab9f68460d8);
	}

	public static string c6623cde42db4307c0b144942a5a8c70d(GameObject c68eeb75ae8e0180ebe74a7f42c8bcf3f)
	{
		string text = "null";
		if (null != c68eeb75ae8e0180ebe74a7f42c8bcf3f)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				break;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			text = c68eeb75ae8e0180ebe74a7f42c8bcf3f.name;
			while (null != c68eeb75ae8e0180ebe74a7f42c8bcf3f.transform.parent)
			{
				c68eeb75ae8e0180ebe74a7f42c8bcf3f = c68eeb75ae8e0180ebe74a7f42c8bcf3f.transform.parent.gameObject;
				text = c68eeb75ae8e0180ebe74a7f42c8bcf3f.name + "/" + text;
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				break;
			}
		}
		return text;
	}

	private static string cf5d6e9d75a1894cecd928212c4d8de2b(string c7c80fef79e3c330ae5014832d44fcd28)
	{
		string result = c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e;
		if (c7c80fef79e3c330ae5014832d44fcd28 != null)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				break;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (c7c80fef79e3c330ae5014832d44fcd28.EndsWith("(Clone)"))
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				result = c7c80fef79e3c330ae5014832d44fcd28.Substring(0, c7c80fef79e3c330ae5014832d44fcd28.Length - "(Clone)".Length);
			}
		}
		return result;
	}

	public static string cabefce0ea6f28c011adc224f6f0f0790(string c7c80fef79e3c330ae5014832d44fcd28)
	{
		string text = cf5d6e9d75a1894cecd928212c4d8de2b(c7c80fef79e3c330ae5014832d44fcd28);
		string text2 = text;
		if (text2 == null)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				break;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			text2 = c7c80fef79e3c330ae5014832d44fcd28;
		}
		return text2;
	}

	public static bool c9fca2106e59e7d995b6411e0e1a969dc(UnityEngine.Object cebae66039aadeac8deb1211786332a72)
	{
		string text = cabefce0ea6f28c011adc224f6f0f0790(cebae66039aadeac8deb1211786332a72.name);
		bool flag = null != text;
		if (flag)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				break;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			cebae66039aadeac8deb1211786332a72.name = text;
		}
		return flag;
	}

	public static void cee1496692d8e43aa68171d8c01774b76(GameObject ca3706854b3073a0804de98d5202b25f4, GameObject c0b8b4f11377b8a222dc728ff2c622559)
	{
		Transform transform = ca3706854b3073a0804de98d5202b25f4.transform;
		transform.parent = c0b8b4f11377b8a222dc728ff2c622559.transform;
		transform.localPosition = Vector3.zero;
		transform.localScale = Vector3.one;
		transform.localRotation = Quaternion.identity;
	}

	public static string cb4f3395638164fa74878314903d8280e(AmmoType c1e73ae4c18ab95639cb0c7604f21dc2b)
	{
		switch (c1e73ae4c18ab95639cb0c7604f21dc2b)
		{
		case AmmoType.AssaultRifle:
			return "AssaultRifle";
		case AmmoType.Grenade:
			return "Grenade";
		case AmmoType.Pistol:
			return "Pistol";
		case AmmoType.ShotGun:
			return "ShotGun";
		case AmmoType.SMG:
			return "SMG";
		case AmmoType.SniperRifle:
			return "SniperRifle";
		default:
			return string.Empty;
		}
	}

	public static string c06e309e4c34dfe6936b31f538f71347e(AffectType cfcdb77f40d98e426d6470fa78eff20db)
	{
		switch (cfcdb77f40d98e426d6470fa78eff20db)
		{
		case AffectType.PostAdd:
			return "PostAdd";
		case AffectType.PrevAdd:
			return "PrevAdd";
		case AffectType.Scale:
			return "Scale";
		default:
			return string.Empty;
		}
	}

	public static string ccafcaf40248e9bbb1784d38d8b267eae(AnimationStateFSM c17fcd0ed1024ad7689991a96ed60deb1)
	{
		switch (c17fcd0ed1024ad7689991a96ed60deb1)
		{
		case AnimationStateFSM.Invalid:
			return "Invalid";
		case AnimationStateFSM.Idle:
			return "Idle";
		case AnimationStateFSM.Move:
			return "Move";
		case AnimationStateFSM.MoveWithFacing:
			return "MoveWithFacing";
		case AnimationStateFSM.HoverPatrol:
			return "HoverPatrol";
		case AnimationStateFSM.FlyMeleeAttack:
			return "FlyMeleeAttack";
		case AnimationStateFSM.FlyGather:
			return "FlyGather";
		case AnimationStateFSM.Die:
			return "Die";
		case AnimationStateFSM.Dead:
			return "Dead";
		case AnimationStateFSM.MeleeAttack:
			return "MeleeAttack";
		case AnimationStateFSM.JumpAttack:
			return "JumpAttack";
		case AnimationStateFSM.JumpAttackCrash:
			return "JumpAttackCrash";
		case AnimationStateFSM.Warcry:
			return "Warcry";
		case AnimationStateFSM.Charge:
			return "Charge";
		case AnimationStateFSM.ChargeHit:
			return "ChargeHit";
		case AnimationStateFSM.Spawn:
			return "Spawn";
		case AnimationStateFSM.AdvanceSpawn:
			return "AdvanceSpawn";
		case AnimationStateFSM.Stun:
			return "Stun";
		case AnimationStateFSM.JumpOnSpot:
			return "JumpOnSpot";
		case AnimationStateFSM.Fire:
			return "Fire";
		case AnimationStateFSM.FireFullBody:
			return "FireFullBody";
		case AnimationStateFSM.DeployAidStation:
			return "DeployAidStation";
		case AnimationStateFSM.Reload:
			return "Reload";
		case AnimationStateFSM.CoverFire:
			return "CoverFire";
		case AnimationStateFSM.CoverIdleBeforeFire:
			return "CoverIdleBeforeFire";
		case AnimationStateFSM.CoverIdle:
			return "CoverIdle";
		case AnimationStateFSM.CoverLookAround:
			return "CoverLookAround";
		case AnimationStateFSM.CoverPeakIn:
			return "CoverPeakIn";
		case AnimationStateFSM.CoverPeakOut:
			return "CoverPeakOut";
		case AnimationStateFSM.CoverReload:
			return "CoverReload";
		case AnimationStateFSM.Hurt:
			return "Hurt";
		case AnimationStateFSM.LightHurt:
			return "LightHurt";
		case AnimationStateFSM.SuicideBomb:
			return "SuicideBomb";
		case AnimationStateFSM.RadiusAttack:
			return "RadiusAttack";
		case AnimationStateFSM.Burrow:
			return "Burrow";
		case AnimationStateFSM.Alert:
			return "Alert";
		case AnimationStateFSM.Roll:
			return "Roll";
		case AnimationStateFSM.SideStep:
			return "SideStep";
		case AnimationStateFSM.Spit:
			return "Spit";
		case AnimationStateFSM.Spacing:
			return "Spacing";
		case AnimationStateFSM.Critical:
			return "Critical";
		case AnimationStateFSM.SlideMove:
			return "SlideMove";
		case AnimationStateFSM.ThrowWeapon:
			return "ThrowWeapon";
		case AnimationStateFSM.ShowWeapon:
			return "ShowWeapon";
		case AnimationStateFSM.IceEarthquakeAttack:
			return "IceEarthquakeAttack";
		case AnimationStateFSM.IceMeteorAttack:
			return "IceMeteorAttack";
		case AnimationStateFSM.SummonExtraNPC:
			return "SummonExtraNPC";
		case AnimationStateFSM.Warning:
			return "Warning";
		case AnimationStateFSM.CombatSpawn:
			return "CombatSpawn";
		case AnimationStateFSM.RailgunAttack:
			return "RailgunAttack";
		case AnimationStateFSM.MortarAttack:
			return "MortarAttack";
		case AnimationStateFSM.TurnTo:
			return "TurnTo";
		case AnimationStateFSM.TurnOnSpot:
			return "TurnOnSpot";
		case AnimationStateFSM.LaserSweep:
			return "LaserSweep";
		case AnimationStateFSM.Empty:
			return "Empty";
		case AnimationStateFSM.PlayerIdle:
			return "PlayerIdle";
		case AnimationStateFSM.PlayerMove:
			return "PlayerMove";
		case AnimationStateFSM.PlayerCrouchIdle:
			return "PlayerCrouchIdle";
		case AnimationStateFSM.PlayerCrouchMove:
			return "PlayerCrouchMove";
		case AnimationStateFSM.PlayerFire:
			return "PlayerFire";
		case AnimationStateFSM.PlayerReload:
			return "PlayerReload";
		case AnimationStateFSM.PlayerSwitchWeapon:
			return "PlayerSwitchWeapon";
		case AnimationStateFSM.PlayerAim:
			return "PlayerAim";
		case AnimationStateFSM.PlayerJump:
			return "PlayerJump";
		case AnimationStateFSM.PlayerPickupWeapon:
			return "PlayerPickupWeapon";
		case AnimationStateFSM.PlayerMelee:
			return "PlayerMelee";
		case AnimationStateFSM.PlayerMeleeSkill:
			return "PlayerMeleeSkill";
		case AnimationStateFSM.PlayerThrowGrenade:
			return "PlayerThrowGrenade";
		case AnimationStateFSM.PlayerFireBird:
			return "PlayerFireBird";
		case AnimationStateFSM.PlayerCallback:
			return "PlayerCallback";
		case AnimationStateFSM.PlayerDie:
			return "PlayerDie";
		case AnimationStateFSM.PlayerBerserkCharge:
			return "PlayerBerserkCharge";
		case AnimationStateFSM.PlayerBerserkDash:
			return "PlayerBerserkDash";
		case AnimationStateFSM.PlayerBerserkPunch:
			return "PlayerBerserkPunch";
		case AnimationStateFSM.PlayerThrowTurret:
			return "PlayerThrowTurret";
		case AnimationStateFSM.PlayerRetrieveTurret:
			return "PlayerRetrieveTurret";
		case AnimationStateFSM.LavaStrike:
			return "LavaStrike";
		case AnimationStateFSM.PlayerReleaseDroid:
			return "PlayerReleaseDroid";
		case AnimationStateFSM.PlayerRetrieveDroid:
			return "PlayerRetrieveDroid";
		case AnimationStateFSM.WebTrap:
			return "WebTrap";
		case AnimationStateFSM.TutorialLesson:
			return "TutorialLesson";
		case AnimationStateFSM.TutorialAction:
			return "TutorialAction";
		case AnimationStateFSM.CircleMove:
			return "CircleMove";
		default:
			return string.Empty;
		}
	}
}
