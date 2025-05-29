using System.Collections;

namespace pumpkin.swf
{
	public interface ISWFReaderImpl
	{
		void readSWF(SwfBinaryReader b, SwfAssetContext assetContext);

		IEnumerator readSWFCO(SwfBinaryReader b, SwfAssetContext assetContext, float swfStreampreloadDelay, int chunksPerStep);
	}
}
