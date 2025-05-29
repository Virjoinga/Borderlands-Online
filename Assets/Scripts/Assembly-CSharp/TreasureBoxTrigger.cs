using A;
using UnityEngine;

public class TreasureBoxTrigger : InteractiveTrigger
{
	private LootingTable m_looting;

	private Collider m_collider;

	private SkinnedMeshRenderer m_render;

	public EntityPlayer m_triggerPlayer;

	protected override void Start()
	{
		m_render = GetComponentInChildren<SkinnedMeshRenderer>();
		base.Start();
		m_looting = GetComponent<LootingTable>();
		m_collider = GetComponent<Collider>();
		m_useOnce = true;
	}

	public override void OnActivate()
	{
		base.OnActivate();
		if (!(m_render != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
		{
			return;
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_render.material.SetFloat("_Illumin", 0f);
			return;
		}
	}

	public override void c4f2632dc55b69776a2b25638b97dedb6(Entity c5d720f6d007abb0c4a21d6a654e405bb, bool c1ccd82293d4f02d70adb2db899caf66f = false)
	{
		m_triggerPlayer = c5d720f6d007abb0c4a21d6a654e405bb as EntityPlayer;
		base.c4f2632dc55b69776a2b25638b97dedb6(c5d720f6d007abb0c4a21d6a654e405bb, c1ccd82293d4f02d70adb2db899caf66f);
	}
}
