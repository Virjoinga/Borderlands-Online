using System;
using System.Collections.Generic;
using pumpkin.swf;

namespace pumpkin.system.defaults
{
	public class MovieClipPlayerDefaults
	{
		public class MovieClipPlayerWrapper : MovieClipPlayer
		{
			public MovieClipPlayerWrapper()
				: base(null, null)
			{
			}

			public static void clear_g_MovieClipClassMap()
			{
				MovieClipPlayer.g_MovieClipClassMap = null;
			}
		}

		public const string swfRoot = "";

		public const string swfProfile = null;

		public const MovieClipProfiler profilerSettings = MovieClipProfiler.SwfNone;

		public const bool enableAdvancedTextfield = false;

		public const bool enableDepreciatedPreFrameCallback = false;

		public const bool enableScale9 = false;

		public const bool enableDepreciatedInnerMovieClipFrameSetup = false;

		public const bool enableUVSubPixelBug = false;

		public const Dictionary<string, Type> g_MovieClipClassMap = null;

		public const bool _dev_enable_frameReferencing = false;

		public static ISwfResourceLoader rootResourceLoader
		{
			get
			{
				return new BuiltinResourceLoader();
			}
		}

		public static Dictionary<string, SwfAssetContext> contextCache
		{
			get
			{
				return new Dictionary<string, SwfAssetContext>();
			}
		}

		public static void restoreDefaults(bool clearCache = true)
		{
			MovieClipPlayer.swfRoot = "";
			MovieClipPlayer.swfProfile = null;
			MovieClipPlayer.profilerSettings = MovieClipProfiler.SwfNone;
			MovieClipPlayer.enableAdvancedTextfield = false;
			MovieClipPlayer.enableDepreciatedPreFrameCallback = false;
			MovieClipPlayer.enableScale9 = false;
			MovieClipPlayer.enableDepreciatedInnerMovieClipFrameSetup = false;
			MovieClipPlayer.enableUVSubPixelBug = false;
			MovieClipPlayer.rootResourceLoader = rootResourceLoader;
			MovieClipPlayer._dev_enable_frameReferencing = false;
			if (clearCache)
			{
				MovieClipPlayer.clearContextCache();
				MovieClipPlayer.contextCache = contextCache;
				MovieClipPlayerWrapper.clear_g_MovieClipClassMap();
			}
		}
	}
}
