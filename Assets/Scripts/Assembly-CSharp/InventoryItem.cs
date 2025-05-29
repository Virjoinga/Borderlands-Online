using System.Collections;

public class InventoryItem
{
	public ItemDNA mItem;

	public int c9a57a1c6eac92cceec2de50aa04e4757
	{
		get
		{
			return mItem.m_value;
		}
		set
		{
			mItem.m_value = value;
		}
	}

	public InventoryItem()
	{
	}

	public InventoryItem(Hashtable c6be323d0a4967d9eb8ca81448ea134ba)
	{
		mItem = ItemDNA.cc95f1fbaa3f9e0533900d0e3a5e0bfa2(c6be323d0a4967d9eb8ca81448ea134ba);
	}
}
