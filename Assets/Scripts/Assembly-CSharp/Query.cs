using System.Collections;

public class Query
{
	public Hashtable Parameters;

	public Hashtable Operations;

	public Query()
	{
		Parameters = new Hashtable();
		Operations = new Hashtable();
	}

	public void c7e4fb2fa43b589f3d18d37ef1950a9f2(string c848e354a81c17f27f4fefe05118064aa, object c967b0939baaec09f6bd06b6c5055f6fd, QueryComparisonType c0c3258864a98918a57fb8b7a2b7a75c8 = QueryComparisonType.Equal)
	{
		Parameters[c848e354a81c17f27f4fefe05118064aa] = c967b0939baaec09f6bd06b6c5055f6fd;
		Operations[c848e354a81c17f27f4fefe05118064aa] = (byte)c0c3258864a98918a57fb8b7a2b7a75c8;
	}
}
