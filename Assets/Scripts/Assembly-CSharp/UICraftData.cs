using XsdSettings;

public class UICraftData
{
	public enum CraftSlotState
	{
		None = 0,
		Locked = 1,
		UnLocked = 2,
		Available = 3,
		Crafted = 4
	}

	protected WeaponCraftConfig _weaponCraftConfig;

	protected ItemDNA _weaponItemDNA;

	protected CraftSlotState _state;

	public int CurMatAQuantity;

	public int CurMatBQuantity;

	public bool bCanCraft;

	public ItemDNA cbfc09aabd64369e9fa4a40b3e7868fa8
	{
		get
		{
			return _weaponItemDNA;
		}
		set
		{
			_weaponItemDNA = value;
		}
	}

	public WeaponCraftConfig c4ba13b059545376cb542c819fb24fbe5
	{
		get
		{
			return _weaponCraftConfig;
		}
		set
		{
			c4ba13b059545376cb542c819fb24fbe5 = value;
		}
	}

	public CraftSlotState c664bd9d17bd42ccbccae1eef1cde7890
	{
		get
		{
			return _state;
		}
		set
		{
			_state = value;
		}
	}

	public UICraftData(WeaponCraftConfig caa2bea5f0d6db8453b7173ec97ede70d, ItemDNA caccc06fd56c01b9b26d54feb9344306e)
	{
		_weaponCraftConfig = caa2bea5f0d6db8453b7173ec97ede70d;
		_weaponItemDNA = caccc06fd56c01b9b26d54feb9344306e;
	}
}
