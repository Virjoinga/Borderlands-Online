using System;
using pumpkin.events;

namespace pumpkin.logging
{
	public class Logger : EventDispatcher
	{
		public const int LEVEL_ERROR = 5;

		public const int LEVEL_INFO = 10;

		public const int LEVEL_DEBUG = 20;

		public const int LEVEL_DEBUG2 = 30;

		public const int LEVEL_AMFCALL = 40;

		public static Logger _instance = null;

		public int logLevel = 30;

		public static Logger instance
		{
			get
			{
				return getInstance();
			}
		}

		public Logger()
		{
			_instance = this;
		}

		public static Logger getInstance()
		{
			if (_instance == null)
			{
				_instance = new Logger();
			}
			return _instance;
		}

		public void log(int level, string logStr)
		{
			if (level <= logLevel)
			{
				Console.WriteLine("[" + levelIdToStr(level) + "] " + logStr);
			}
			dispatchEvent(new LogEvent(level, logStr));
		}

		public static void info(string logStr)
		{
			instance.log(10, logStr);
		}

		public static void error(string logStr)
		{
			error(logStr, "");
		}

		public static void error(string logStr, string stackTrace)
		{
			instance.log(5, logStr);
		}

		public static void debug(string logStr)
		{
			instance.log(20, logStr);
		}

		public static void debug2(string logStr)
		{
			instance.log(30, logStr);
		}

		public static void debugAmfCall(string logStr)
		{
			instance.log(40, logStr);
		}

		public static string levelIdToStr(int level)
		{
			switch (level)
			{
			case 10:
				return "INFO";
			case 20:
				return "DEBUG";
			case 30:
				return "DEBUG2";
			case 5:
				return "LEVEL_ERROR";
			case 40:
				return "LEVEL_AMFCALL";
			default:
				return level + "";
			}
		}
	}
}
