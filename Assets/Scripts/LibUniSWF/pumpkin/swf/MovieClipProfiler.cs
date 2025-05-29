using System;

namespace pumpkin.swf
{
	[Flags]
	public enum MovieClipProfiler
	{
		SwfNone = 0,
		SwfLoad = 1,
		TextureLoad = 2,
		TextExportWarn = 3,
		ParseXmlActions = 4,
		SwfUnload = 5,
		SwfTextureUnload = 6,
		SwfAll = 0xFF
	}
}
