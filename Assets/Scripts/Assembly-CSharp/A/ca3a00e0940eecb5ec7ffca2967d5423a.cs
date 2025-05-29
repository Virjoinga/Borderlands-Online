using System.Collections.Generic;
using Core;
using UnityEngine;
using XsdSettings;

namespace A
{
	public class ca3a00e0940eecb5ec7ffca2967d5423a : c06ca0e618478c23eba3419653a19760f<ca3a00e0940eecb5ec7ffca2967d5423a>
	{
		private Queue<UIMessage>[] cbce70165a9a3dd4d1adffe6eb7f5c48d = ca433fbc55c643809d32afe0d3f7b9216.c0a0cdf4a196914163f7334d9b0781a04(6);

		private UIMessage[] cfba3a7715f135db05fd99e564584b64b = c03b90d078d66b9a1b355cef13e522b22.c0a0cdf4a196914163f7334d9b0781a04(6);

		protected Dictionary<DisplayTarget, List<c59dffb97d0323f1c7e2cf13f91eec1ce>> c0ebe50c02b6e4c447f1d634ef5e2a2ee = new Dictionary<DisplayTarget, List<c59dffb97d0323f1c7e2cf13f91eec1ce>>();

		protected List<c59dffb97d0323f1c7e2cf13f91eec1ce> c6672c1890a3bb1234ded6b99812b0699 = new List<c59dffb97d0323f1c7e2cf13f91eec1ce>();

		private void Start()
		{
			for (int i = 0; i < cbce70165a9a3dd4d1adffe6eb7f5c48d.Length; i++)
			{
				cbce70165a9a3dd4d1adffe6eb7f5c48d[i] = new Queue<UIMessage>();
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
				return;
			}
		}

		public UIMessage c8c999e73064d771340dff4b02b6cf511(UIMessage.c7487b4eea694c61027850111354bc24f c2b4f43f34e21572af6ab4414f04cee36)
		{
			return cfba3a7715f135db05fd99e564584b64b[(int)c2b4f43f34e21572af6ab4414f04cee36];
		}

		public UIMessage[] c44473a378e6c56357d01e05d2061cad5()
		{
			return cfba3a7715f135db05fd99e564584b64b;
		}

		public void cba86f338d46d74a8d7beba9c6f0a3fa5(UIMessage c709b291ceac9f97f0c78f269054fa014)
		{
			cbce70165a9a3dd4d1adffe6eb7f5c48d[(int)c709b291ceac9f97f0c78f269054fa014.m_type].Enqueue(c709b291ceac9f97f0c78f269054fa014);
			EchoMessage echoMessage = new EchoMessage();
			echoMessage.m_localizedText = c709b291ceac9f97f0c78f269054fa014.m_text;
			if (c709b291ceac9f97f0c78f269054fa014.m_displayCountDown)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				EchoMessage echoMessage2 = new EchoMessage();
				DisplayTarget[] array = c8545d3485400c0f93543c8523f974c04.c0a0cdf4a196914163f7334d9b0781a04(1);
				array[0] = DisplayTarget.Countdown;
				echoMessage2.m_displayTargets = array;
				echoMessage2.m_localizedText = c709b291ceac9f97f0c78f269054fa014.m_duration.ToString();
				cba86f338d46d74a8d7beba9c6f0a3fa5(echoMessage2);
			}
			if (!(c709b291ceac9f97f0c78f269054fa014.m_text != string.Empty))
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
				DisplayTarget[] array2 = c8545d3485400c0f93543c8523f974c04.c0a0cdf4a196914163f7334d9b0781a04(1);
				array2[0] = DisplayTarget.LevelNotification;
				echoMessage.m_displayTargets = array2;
				cba86f338d46d74a8d7beba9c6f0a3fa5(echoMessage);
				return;
			}
		}

		public void cba86f338d46d74a8d7beba9c6f0a3fa5(string c09721d98c247dde8efe59bc3cebbad00, DisplayTarget c1a6223923f7293281f8140e9bf991c07)
		{
			EchoMessage echoMessage = new EchoMessage();
			echoMessage.m_localizedText = c09721d98c247dde8efe59bc3cebbad00;
			if (string.IsNullOrEmpty(c09721d98c247dde8efe59bc3cebbad00))
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
				DisplayTarget[] array = c8545d3485400c0f93543c8523f974c04.c0a0cdf4a196914163f7334d9b0781a04(1);
				array[0] = c1a6223923f7293281f8140e9bf991c07;
				echoMessage.m_displayTargets = array;
				cba86f338d46d74a8d7beba9c6f0a3fa5(echoMessage);
				return;
			}
		}

		public void cac7688b05e921e2be3f92479ba44b4a8()
		{
			for (int i = 0; i < cbce70165a9a3dd4d1adffe6eb7f5c48d.Length; i++)
			{
				cfba3a7715f135db05fd99e564584b64b[i] = null;
				cbce70165a9a3dd4d1adffe6eb7f5c48d[i].Clear();
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
				return;
			}
		}

		public void Update()
		{
			float time = Time.time;
			for (int i = 0; i < cfba3a7715f135db05fd99e564584b64b.Length; i++)
			{
				if (cfba3a7715f135db05fd99e564584b64b[i] == null)
				{
					continue;
				}
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
				if (cfba3a7715f135db05fd99e564584b64b[i].m_decayDate < time)
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
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<EchoMessageView>().c01be698909df4df10156c743f1f4a971(cfba3a7715f135db05fd99e564584b64b[i]);
					cfba3a7715f135db05fd99e564584b64b[i] = null;
				}
				else
				{
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<EchoMessageView>().c7e64ae2fafe55da103eb4e50d43a40ed(cfba3a7715f135db05fd99e564584b64b[i]);
				}
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				for (int j = 0; j < cfba3a7715f135db05fd99e564584b64b.Length; j++)
				{
					if (cfba3a7715f135db05fd99e564584b64b[j] != null)
					{
						continue;
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
					if (cbce70165a9a3dd4d1adffe6eb7f5c48d[j].Count <= 0)
					{
						continue;
					}
					while (true)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						break;
					}
					cfba3a7715f135db05fd99e564584b64b[j] = cbce70165a9a3dd4d1adffe6eb7f5c48d[j].Dequeue();
					cfba3a7715f135db05fd99e564584b64b[j].m_decayDate = time + cfba3a7715f135db05fd99e564584b64b[j].m_duration;
					c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<EchoMessageView>().c912f6520c68c7615ec30f3a26728abc6(cfba3a7715f135db05fd99e564584b64b[j]);
				}
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					cec6db10e0c9297d484266615b875108f();
					return;
				}
			}
		}

		public void c668f19c1f6a9b228c2058ac3956d5a3e(DisplayTarget c2b4f43f34e21572af6ab4414f04cee36, c59dffb97d0323f1c7e2cf13f91eec1ce c16761206209501eeb56534c1f0d5895d)
		{
			if (!c0ebe50c02b6e4c447f1d634ef5e2a2ee.ContainsKey(c2b4f43f34e21572af6ab4414f04cee36))
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
				c0ebe50c02b6e4c447f1d634ef5e2a2ee.Add(c2b4f43f34e21572af6ab4414f04cee36, new List<c59dffb97d0323f1c7e2cf13f91eec1ce>());
			}
			if (!c0ebe50c02b6e4c447f1d634ef5e2a2ee[c2b4f43f34e21572af6ab4414f04cee36].Contains(c16761206209501eeb56534c1f0d5895d))
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
				c0ebe50c02b6e4c447f1d634ef5e2a2ee[c2b4f43f34e21572af6ab4414f04cee36].Add(c16761206209501eeb56534c1f0d5895d);
			}
			if (c6672c1890a3bb1234ded6b99812b0699.Contains(c16761206209501eeb56534c1f0d5895d))
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
				c6672c1890a3bb1234ded6b99812b0699.Add(c16761206209501eeb56534c1f0d5895d);
				return;
			}
		}

		public void c1537c07d38c344aa046ee9930f300b5a(c59dffb97d0323f1c7e2cf13f91eec1ce c16761206209501eeb56534c1f0d5895d)
		{
			using (Dictionary<DisplayTarget, List<c59dffb97d0323f1c7e2cf13f91eec1ce>>.Enumerator enumerator = c0ebe50c02b6e4c447f1d634ef5e2a2ee.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<DisplayTarget, List<c59dffb97d0323f1c7e2cf13f91eec1ce>> current = enumerator.Current;
					if (!current.Value.Contains(c16761206209501eeb56534c1f0d5895d))
					{
						continue;
					}
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
					current.Value.Remove(c16761206209501eeb56534c1f0d5895d);
				}
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						goto end_IL_005d;
					}
					continue;
					end_IL_005d:
					break;
				}
			}
			if (!c6672c1890a3bb1234ded6b99812b0699.Contains(c16761206209501eeb56534c1f0d5895d))
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
				c6672c1890a3bb1234ded6b99812b0699.Remove(c16761206209501eeb56534c1f0d5895d);
				return;
			}
		}

		public void cba86f338d46d74a8d7beba9c6f0a3fa5(EchoMessage c709b291ceac9f97f0c78f269054fa014)
		{
			DisplayTarget[] displayTargets = c709b291ceac9f97f0c78f269054fa014.m_displayTargets;
			foreach (DisplayTarget key in displayTargets)
			{
				if (!c0ebe50c02b6e4c447f1d634ef5e2a2ee.ContainsKey(key))
				{
					continue;
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				using (List<c59dffb97d0323f1c7e2cf13f91eec1ce>.Enumerator enumerator = c0ebe50c02b6e4c447f1d634ef5e2a2ee[key].GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						c59dffb97d0323f1c7e2cf13f91eec1ce current = enumerator.Current;
						current.cba86f338d46d74a8d7beba9c6f0a3fa5(c709b291ceac9f97f0c78f269054fa014);
					}
					while (true)
					{
						switch (2)
						{
						case 0:
							break;
						default:
							goto end_IL_006c;
						}
						continue;
						end_IL_006c:
						break;
					}
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

		public void cba86f338d46d74a8d7beba9c6f0a3fa5(string ca9b41628fdb7a51448ed07e56256573e)
		{
			EchoMessage echoMessage = c06ca0e618478c23eba3419653a19760f<EchoMessageManager>.c5ee19dc8d4cccf5ae2de225410458b86.c8c999e73064d771340dff4b02b6cf511(ca9b41628fdb7a51448ed07e56256573e);
			if (echoMessage != null)
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
						cba86f338d46d74a8d7beba9c6f0a3fa5(echoMessage);
						return;
					}
				}
			}
			DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "Can not find echo message of " + ca9b41628fdb7a51448ed07e56256573e);
		}

		protected void cec6db10e0c9297d484266615b875108f()
		{
			for (int i = 0; i < c6672c1890a3bb1234ded6b99812b0699.Count; i++)
			{
				c6672c1890a3bb1234ded6b99812b0699[i].Update();
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				return;
			}
		}
	}
}
