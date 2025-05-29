using A;

public class PhotonMessageInfo
{
	private int timeInt;

	public PhotonPlayer sender;

	public PhotonView photonView;

	public double c24d168bafd94cfd3e438faef12da2b5c
	{
		get
		{
			return (double)(uint)timeInt / 1000.0;
		}
	}

	public PhotonMessageInfo()
	{
		sender = PhotonNetwork.ceb41162a7cd2a1d5c4a03830e02b4198;
		timeInt = (int)(PhotonNetwork.cad9f703d862495149cd6bddd080f050b * 1000.0);
		photonView = c56ecf3283d235e852cde628d84d7b371.c7088de59e49f7108f520cf7e0bae167e;
	}

	public PhotonMessageInfo(PhotonPlayer ceb41162a7cd2a1d5c4a03830e02b4198, int c24d168bafd94cfd3e438faef12da2b5c, PhotonView ca4187010cdd35921f11dd5df8ccc23e3)
	{
		sender = ceb41162a7cd2a1d5c4a03830e02b4198;
		timeInt = c24d168bafd94cfd3e438faef12da2b5c;
		photonView = ca4187010cdd35921f11dd5df8ccc23e3;
	}

	public void c20b8dda8cbcdfbbc16c4d332102c641e()
	{
		timeInt = PhotonNetwork.networkingPeer.ServerTimeInMilliSeconds;
	}

	public override string ToString()
	{
		return string.Format("[PhotonMessageInfo: player='{1}' timestamp={0}]", c24d168bafd94cfd3e438faef12da2b5c, sender);
	}
}
