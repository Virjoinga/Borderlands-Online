using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using Core;
using UnityEngine;

namespace A
{
	public class c585561a7e2d1fad0661d8f890537fed4 : c06ca0e618478c23eba3419653a19760f<c585561a7e2d1fad0661d8f890537fed4>
	{
		private const string ca100e204671469a39df3138bc720cc6f = "http://sghw-badass2.2kgames.t2.corp/debug/";

		private TcpClient cb21d3f1fb5dfe8a8517b8a2dd5ca6eda = new TcpClient();

		private NetworkStream c193092de6441b2af3e83e011d7a2a07c;

		private StringWriter ce24c92c5273d9ea3eabd80a5e04a531b;

		private StreamWriter cec3485027c8cf126810a56df452cd338;

		private int cc84798268dfb635d7f1204fa6fc8b7e7;

		public static string c5871675a9f1c5f7e18d2787277f85f73 = "bol_output.html";

		protected override void Awake()
		{
			base.Awake();
			Application.RegisterLogCallback(ca7e0932d6cb3c8f6e60e02bb4a1a637e);
			ce24c92c5273d9ea3eabd80a5e04a531b = new StringWriter();
			IAsyncResult asyncResult = cb21d3f1fb5dfe8a8517b8a2dd5ca6eda.BeginConnect("127.0.0.1", 666, null, c9d6b94476c9fd708af4084a517eb1f88.c7088de59e49f7108f520cf7e0bae167e);
			if (!asyncResult.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(0.1)))
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Profile, "Failed to connect to log server");
			}
			else
			{
				c193092de6441b2af3e83e011d7a2a07c = cb21d3f1fb5dfe8a8517b8a2dd5ca6eda.GetStream();
			}
			try
			{
			}
			catch (Exception)
			{
			}
			c5aabc300b185682d3098db84e7b1e0ae();
		}

		private void OnDestroy()
		{
			c7d7af1b29b18c698a0195ee503a08493();
			Application.RegisterLogCallback(null);
		}

		private void c7d7af1b29b18c698a0195ee503a08493()
		{
			if (c193092de6441b2af3e83e011d7a2a07c != null)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				UTF8Encoding uTF8Encoding = new UTF8Encoding();
				byte[] bytes = uTF8Encoding.GetBytes(ce24c92c5273d9ea3eabd80a5e04a531b.ToString());
				c193092de6441b2af3e83e011d7a2a07c.Write(bytes, 0, bytes.Length);
			}
			if (cec3485027c8cf126810a56df452cd338 != null)
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
				cec3485027c8cf126810a56df452cd338.Write(ce24c92c5273d9ea3eabd80a5e04a531b.ToString());
				cec3485027c8cf126810a56df452cd338.Flush();
			}
			ce24c92c5273d9ea3eabd80a5e04a531b.GetStringBuilder().Remove(0, ce24c92c5273d9ea3eabd80a5e04a531b.ToString().Length);
		}

		public void ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory ccc12d01a2caed4c0bee1fb76f94cbefa, LogType cb8a377f02b5e4f1fdb02baa91ff63d29, string c709b291ceac9f97f0c78f269054fa014)
		{
		}

		private void ca7e0932d6cb3c8f6e60e02bb4a1a637e(string c71a4f9192b925ef69eb2abdd6bc6fdb3, string c234559b393d74c9d27df1458e6a16b58, LogType c2b4f43f34e21572af6ab4414f04cee36)
		{
			if (c2b4f43f34e21572af6ab4414f04cee36 != LogType.Assert)
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
				if (c2b4f43f34e21572af6ab4414f04cee36 != LogType.Exception)
				{
					goto IL_002f;
				}
				while (true)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			DebugUtils.c9dcb1254e55b65d1a798e7fb9e087d29(LogCategory.System, c71a4f9192b925ef69eb2abdd6bc6fdb3, c234559b393d74c9d27df1458e6a16b58);
			goto IL_002f;
			IL_002f:
			if (c2b4f43f34e21572af6ab4414f04cee36 != LogType.Assert)
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
				if (c2b4f43f34e21572af6ab4414f04cee36 != 0)
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
					if (c2b4f43f34e21572af6ab4414f04cee36 == LogType.Exception)
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
					}
				}
			}
			c71a4f9192b925ef69eb2abdd6bc6fdb3 = c71a4f9192b925ef69eb2abdd6bc6fdb3.Replace("Exception: ", string.Empty);
			string text = "trace" + cc84798268dfb635d7f1204fa6fc8b7e7++;
			if (!c71a4f9192b925ef69eb2abdd6bc6fdb3.Contains("::"))
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
				object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(7);
				array[0] = "<p class=\"";
				array[1] = LogCategory.Default;
				array[2] = "\"><span class=\"";
				array[3] = c2b4f43f34e21572af6ab4414f04cee36;
				array[4] = "\"/><span class=\"time\">TIME##</span><a onclick=\"hide('TRACE##')\">STACK</a>";
				array[5] = c71a4f9192b925ef69eb2abdd6bc6fdb3;
				array[6] = "</p>";
				c71a4f9192b925ef69eb2abdd6bc6fdb3 = string.Concat(array);
			}
			else
			{
				c71a4f9192b925ef69eb2abdd6bc6fdb3 = c71a4f9192b925ef69eb2abdd6bc6fdb3.Replace("::", string.Concat("\"><span class=\"", c2b4f43f34e21572af6ab4414f04cee36, "\"/><span class=\"time\">TIME##</span><a onclick=\"hide('TRACE##')\">STACK</a>"));
				c71a4f9192b925ef69eb2abdd6bc6fdb3 = "<p class=\"" + c71a4f9192b925ef69eb2abdd6bc6fdb3 + "</p>";
			}
			string newValue = Time.realtimeSinceStartup.ToString();
			c71a4f9192b925ef69eb2abdd6bc6fdb3 = c71a4f9192b925ef69eb2abdd6bc6fdb3.Replace("TIME##", newValue);
			c71a4f9192b925ef69eb2abdd6bc6fdb3 = c71a4f9192b925ef69eb2abdd6bc6fdb3.Replace("TRACE##", text);
			ce24c92c5273d9ea3eabd80a5e04a531b.WriteLine(c71a4f9192b925ef69eb2abdd6bc6fdb3);
			string[] array2 = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(5);
			array2[0] = "<pre id=\"";
			array2[1] = text;
			array2[2] = "\">";
			array2[3] = c234559b393d74c9d27df1458e6a16b58;
			array2[4] = "</pre>";
			c71a4f9192b925ef69eb2abdd6bc6fdb3 = string.Concat(array2);
			ce24c92c5273d9ea3eabd80a5e04a531b.WriteLine(c71a4f9192b925ef69eb2abdd6bc6fdb3);
			c7d7af1b29b18c698a0195ee503a08493();
		}

		private void c5aabc300b185682d3098db84e7b1e0ae()
		{
			ce24c92c5273d9ea3eabd80a5e04a531b.WriteLine("<script language=\"javascript\" src=\"http://sghw-badass2.2kgames.t2.corp/debug/log.js\"></script>");
			ce24c92c5273d9ea3eabd80a5e04a531b.WriteLine("<link rel=\"stylesheet\" type=\"text/css\" href=\"http://sghw-badass2.2kgames.t2.corp/debug/log.css\" />");
			ce24c92c5273d9ea3eabd80a5e04a531b.WriteLine("<div class=\"Category\">\n");
			for (int i = 0; i < Enum.GetValues(Type.GetTypeFromHandle(c3e742cdc20ad60758b9ec7d89ca3ae10.cc1720d05c75832f704b87474932341c3())).Length; i++)
			{
				StringWriter stringWriter = ce24c92c5273d9ea3eabd80a5e04a531b;
				object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(7);
				array[0] = "<input type=\"button\" value=\"";
				array[1] = Enum.GetValues(Type.GetTypeFromHandle(c3e742cdc20ad60758b9ec7d89ca3ae10.cc1720d05c75832f704b87474932341c3())).GetValue(i);
				array[2] = "\" class=\"";
				array[3] = Enum.GetValues(Type.GetTypeFromHandle(c3e742cdc20ad60758b9ec7d89ca3ae10.cc1720d05c75832f704b87474932341c3())).GetValue(i);
				array[4] = " Button\" onclick=\"hide_class('";
				array[5] = Enum.GetValues(Type.GetTypeFromHandle(c3e742cdc20ad60758b9ec7d89ca3ae10.cc1720d05c75832f704b87474932341c3())).GetValue(i);
				array[6] = "')\"/>";
				stringWriter.WriteLine(string.Concat(array));
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
				ce24c92c5273d9ea3eabd80a5e04a531b.WriteLine("<br />");
				ce24c92c5273d9ea3eabd80a5e04a531b.WriteLine("</div>");
				ce24c92c5273d9ea3eabd80a5e04a531b.WriteLine("<div class=\"Priority\">\n");
				for (int j = 0; j < Enum.GetValues(Type.GetTypeFromHandle(c0c25e40d160f54f0e8e27772993320d4.cc1720d05c75832f704b87474932341c3())).Length; j++)
				{
					StringWriter stringWriter2 = ce24c92c5273d9ea3eabd80a5e04a531b;
					object[] array2 = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(5);
					array2[0] = "<input type=\"button\" value=\"";
					array2[1] = Enum.GetValues(Type.GetTypeFromHandle(c0c25e40d160f54f0e8e27772993320d4.cc1720d05c75832f704b87474932341c3())).GetValue(j);
					array2[2] = "\" class=\"Button\" onclick=\"hide_priority('";
					array2[3] = Enum.GetValues(Type.GetTypeFromHandle(c0c25e40d160f54f0e8e27772993320d4.cc1720d05c75832f704b87474932341c3())).GetValue(j);
					array2[4] = "')\"/>";
					stringWriter2.WriteLine(string.Concat(array2));
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					ce24c92c5273d9ea3eabd80a5e04a531b.WriteLine("<br />");
					ce24c92c5273d9ea3eabd80a5e04a531b.WriteLine("</div>");
					ce24c92c5273d9ea3eabd80a5e04a531b.WriteLine("<h1 class=\"date\">{0} - {1} - {2}</h1>", DateTime.Now.ToString(), Application.platform, Application.unityVersion);
					ce24c92c5273d9ea3eabd80a5e04a531b.WriteLine("<p>Click on buttons to toggle visibility. Click on STACK buttons to toggle visibility of stack traces.</p>");
					c7d7af1b29b18c698a0195ee503a08493();
					return;
				}
			}
		}
	}
}
