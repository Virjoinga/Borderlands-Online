using pumpkin.swf.swfFormat.version1;
using pumpkin.swf.swfFormat.version8;

namespace pumpkin.swf
{
	public class MovieClipReader
	{
		internal static int FORMAT_VERSION_1 = 1;

		internal static int FORMAT_VERSION_2 = 2;

		internal static int FORMAT_VERSION_3 = 3;

		internal static int FORMAT_VERSION_4 = 4;

		internal static int FORMAT_VERSION_5 = 5;

		internal static int FORMAT_VERSION_6 = 6;

		internal static int FORMAT_VERSION_7 = 7;

		internal static int FORMAT_VERSION_8 = 8;

		internal static int FORMAT_VERSION = FORMAT_VERSION_8;

		public static int TYPE_HEADER = 755;

		public static int TYPE_INT = 1;

		public static int TYPE_FLOAT = 2;

		public static int TYPE_STRING_UTF8 = 3;

		public static int TYPE_RECT = 4;

		public static int TYPE_BYTEARRAY = 5;

		public static int TYPE_COLOR = 6;

		public static int TYPE_TRANSFORM = 100;

		public static int TYPE_MATRIX = 101;

		public static int TYPE_BITMAPASSETINFO = 102;

		public static int TYPE_BITMAPFONTASSETINFO = 103;

		public static int TYPE_BITMAPFONTCHARINFO = 104;

		public static int TYPE_DISPLAYOBJECTINFO = 105;

		public static int TYPE_DISPLAYOBJECTTEXTINFO = 106;

		public static int TYPE_MOVIECLIPASSETINFO = 107;

		public static int TYPE_FRAMEINFO = 108;

		public static int TYPE_ACTIONOP = 109;

		public static int TYPE_ARRAY = 110;

		public static int TYPE_DICTIONARY = 111;

		protected int m_Version = -1;

		private SwfAssetContext context;

		public SwfAssetContext readSwfAssetContext(SwfBinaryReader b, string swfPrefix)
		{
			context = new SwfAssetContext();
			context.swfPrefix = swfPrefix;
			if (TextureManager.instance == null)
			{
				new TextureManager();
			}
			context.textureManager = TextureManager.instance;
			string text = readHeaderString(b);
			if (text != "PBMC")
			{
				throw new SwfSerializerException("Header missmatch got " + text + "");
			}
			int num = b.ReadInt32();
			if (num > FORMAT_VERSION)
			{
				throw new SwfSerializerException("Version missmatch got " + num + " expected <= '" + FORMAT_VERSION + "', try upgrading the library or use an older version of the swf exporter");
			}
			m_Version = num;
			context.version = m_Version;
			getReaderImpl(context.version).readSWF(b, context);
			return context;
		}

		public void readSwfAssetContextPrepareCO(SwfBinaryReader b, string swfPrefix, SwfAssetContext context)
		{
			this.context = context;
			context.swfPrefix = swfPrefix;
			if (TextureManager.instance == null)
			{
				new TextureManager();
			}
			context.textureManager = TextureManager.instance;
			readHeaderString(b);
			int num = b.ReadInt32();
			if (num > FORMAT_VERSION)
			{
				throw new SwfSerializerException("Version missmatch got " + num + " expected <= '" + FORMAT_VERSION + "', try upgrading the library or use an older version of the swf exporter");
			}
			m_Version = num;
			context.version = m_Version;
		}

		public ISWFReaderImpl getReaderImpl(int version)
		{
			if (version <= FORMAT_VERSION_7)
			{
				return new SWFReader_1();
			}
			if (version == FORMAT_VERSION_8)
			{
				return new SWFReader_8();
			}
			throw new SwfSerializerException("Unsupported uniswf file format version '" + version + "'");
		}

		private string readHeaderString(SwfBinaryReader b)
		{
			pumpkin.swf.swfFormat.version1.Section section = new pumpkin.swf.swfFormat.version1.Section(b);
			int num = b.ReadInt32();
			if (num < 0 || num > 665535)
			{
				return null;
			}
			string result = new string(b.ReadChars(num));
			section.end();
			return result;
		}
	}
}
