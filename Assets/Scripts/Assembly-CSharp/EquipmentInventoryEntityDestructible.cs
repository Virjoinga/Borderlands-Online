public class EquipmentInventoryEntityDestructible : EquipmentInventoryEntity
{
	private enum PouchType
	{
		LIFE = 0
	}

	public override int ca2ff7a501878363cb1d5f0472e306620()
	{
		return m_pouchList[0].c4c4b463091d2b6acfdded4fa12b32f25();
	}

	public override int ccfad1bf47b003333c5ddd084f14d33e7()
	{
		return m_pouchList[0].c17a506784adea8f822bee98ad9dba710();
	}

	public override void c9af7b3e5f6626ceef1a0036138121839(int c19e024b5bcbd347892bec27154c527de)
	{
		m_pouchList[0].c82133ff2bb787510ed8585dd3d834b59(c19e024b5bcbd347892bec27154c527de);
	}

	public override void cf0a63fdc9831dd55ae40ac6a5f5eb7e0(int c19e024b5bcbd347892bec27154c527de)
	{
		m_pouchList[0].ca0f7f52805a9c67a892c5b479a17c3aa(c19e024b5bcbd347892bec27154c527de);
	}

	public override void cd93285db16841148ed53a5bbeb35cf20(byte cd6bb591c33b2ee3ab93e98aa43a6da63, int cb75bb7e4635f59359605d47e3ee3541b)
	{
		m_pouchList[0].ccc9d3a38966dc10fedb531ea17d24611(cb75bb7e4635f59359605d47e3ee3541b);
	}

	private void Awake()
	{
		m_pouchList.Clear();
		m_pouchList.Add(new Utils.PouchNetwork());
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
	}
}
