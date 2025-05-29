using System.Collections.Generic;
using UnityEngine;

public class ItemTipsData
{
	public Color nameColor = Color.white;

	public string name = string.Empty;

	public ItemDNA item;

	public Color levelColor = Color.white;

	public int level = 1;

	public string brand = "none";

	public bool bEquiped;

	public int price = -1;

	public List<ItemElement> attributeList = new List<ItemElement>();

	public List<ItemElement> additionAttList = new List<ItemElement>();
}
