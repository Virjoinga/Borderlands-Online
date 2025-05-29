using System;
using System.Collections;
using System.Collections.Generic;

public class Shop
{
	private Dictionary<int, ShopItem> mInventory = new Dictionary<int, ShopItem>();

	public int Id { get; set; }

	public Dictionary<int, ShopItem> cf29c277dedbf8f02ae332e42e112a348
	{
		get
		{
			return mInventory;
		}
	}

	public int LastGenerated { get; set; }

	public int RefreshTime { get; set; }

	public double SellRatio { get; set; }

	public Shop(Hashtable c28cf3d24e3067ef54895f824fad7fcef)
	{
		Id = (int)c28cf3d24e3067ef54895f824fad7fcef[0];
		Hashtable hashtable = (Hashtable)c28cf3d24e3067ef54895f824fad7fcef[1];
		LastGenerated = (int)c28cf3d24e3067ef54895f824fad7fcef[2];
		RefreshTime = (int)c28cf3d24e3067ef54895f824fad7fcef[3];
		SellRatio = (double)c28cf3d24e3067ef54895f824fad7fcef[4];
		IDictionaryEnumerator enumerator = hashtable.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)enumerator.Current;
				mInventory[(int)dictionaryEntry.Key] = new ShopItem((Hashtable)dictionaryEntry.Value);
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				return;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable == null)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						goto end_IL_00f7;
					}
					continue;
					end_IL_00f7:
					break;
				}
			}
			else
			{
				disposable.Dispose();
			}
		}
	}
}
