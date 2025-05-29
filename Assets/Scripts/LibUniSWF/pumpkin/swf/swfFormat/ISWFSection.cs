namespace pumpkin.swf.swfFormat
{
	public interface ISWFSection
	{
		int type { get; }

		int size { get; }

		float readFloat();

		int readInt();

		string readString();

		string readStringNoSection();

		byte[] readByteArray();

		int getDataRead();

		void end();
	}
}
