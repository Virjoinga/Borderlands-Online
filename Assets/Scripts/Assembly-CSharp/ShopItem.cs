using System.Collections;

public class ShopItem
{
	public ItemDNA Item { get; set; }

	public int Price { get; set; }

	public int Quantity { get; set; }

	public ShopItem()
	{
	}

	public ShopItem(Hashtable c28cf3d24e3067ef54895f824fad7fcef)
	{
		Item = ItemDNA.cc95f1fbaa3f9e0533900d0e3a5e0bfa2(c28cf3d24e3067ef54895f824fad7fcef);
		Price = (int)c28cf3d24e3067ef54895f824fad7fcef[c28cf3d24e3067ef54895f824fad7fcef.Count - 2];
		Quantity = (int)c28cf3d24e3067ef54895f824fad7fcef[c28cf3d24e3067ef54895f824fad7fcef.Count - 1];
	}
}
