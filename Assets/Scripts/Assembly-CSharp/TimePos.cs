using A;
using UnityEngine;

public class TimePos
{
	public Vector3 m_position;

	public Quaternion m_rotation;

	public int m_frameNum { get; private set; }

	public double m_networkTimeStamp { get; private set; }

	public double m_time { get; private set; }

	public TimePos(TimePos c4cd2d111e7f2b609406fdf987db52f2e)
	{
		m_networkTimeStamp = c4cd2d111e7f2b609406fdf987db52f2e.m_networkTimeStamp;
		m_time = c4cd2d111e7f2b609406fdf987db52f2e.m_time;
		m_position = c4cd2d111e7f2b609406fdf987db52f2e.m_position;
		m_rotation = c4cd2d111e7f2b609406fdf987db52f2e.m_rotation;
		m_frameNum = c4cd2d111e7f2b609406fdf987db52f2e.m_frameNum;
	}

	public TimePos(double cad9f703d862495149cd6bddd080f050b, Vector3 cef9712200bbe2c3873eec3ca2e18a595, double cbad8ba0203043c3416d7afaeb775e965, int c54c75a1eaccb56ae03a0d1c56438d1d2)
	{
		m_networkTimeStamp = cbad8ba0203043c3416d7afaeb775e965;
		m_time = cad9f703d862495149cd6bddd080f050b;
		m_position = cef9712200bbe2c3873eec3ca2e18a595;
		m_frameNum = c54c75a1eaccb56ae03a0d1c56438d1d2;
	}

	public TimePos(double cad9f703d862495149cd6bddd080f050b, Vector3 cef9712200bbe2c3873eec3ca2e18a595, Quaternion c4ea6de03c1203f2470a6677821ad93f0, double cbad8ba0203043c3416d7afaeb775e965, int c54c75a1eaccb56ae03a0d1c56438d1d2)
	{
		m_networkTimeStamp = cbad8ba0203043c3416d7afaeb775e965;
		m_time = cad9f703d862495149cd6bddd080f050b;
		m_position = cef9712200bbe2c3873eec3ca2e18a595;
		m_rotation = c4ea6de03c1203f2470a6677821ad93f0;
		m_frameNum = c54c75a1eaccb56ae03a0d1c56438d1d2;
	}

	public TimePos(double cad9f703d862495149cd6bddd080f050b, Vector3 cef9712200bbe2c3873eec3ca2e18a595, int c54c75a1eaccb56ae03a0d1c56438d1d2)
	{
		m_time = cad9f703d862495149cd6bddd080f050b;
		m_position = cef9712200bbe2c3873eec3ca2e18a595;
		m_frameNum = c54c75a1eaccb56ae03a0d1c56438d1d2;
	}

	public override bool Equals(object obj)
	{
		TimePos timePos = obj as TimePos;
		if (timePos != null)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					int result;
					if (timePos.m_time == m_time)
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
						result = ((timePos.m_frameNum == m_frameNum) ? 1 : 0);
					}
					else
					{
						result = 0;
					}
					return (byte)result != 0;
				}
				}
			}
		}
		return false;
	}

	public override int GetHashCode()
	{
		return m_time.GetHashCode() ^ m_position.GetHashCode();
	}

	public override string ToString()
	{
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(10);
		array[0] = " localTime:";
		array[1] = m_time;
		array[2] = "remoteTime:";
		array[3] = m_networkTimeStamp;
		array[4] = "m_position:";
		array[5] = m_position.x;
		array[6] = ",";
		array[7] = m_position.y;
		array[8] = ",";
		array[9] = m_position.z;
		return string.Concat(array);
	}
}
