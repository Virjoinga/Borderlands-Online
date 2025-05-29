using System;
using System.Collections;
using System.Collections.Generic;
using A;

public class Warehouse
{
	private Dictionary<int, InventoryItem> mItems = new Dictionary<int, InventoryItem>();

	private int mAccountId;

	private int mMaxSlots = 60;

	public Warehouse()
	{
	}

	public Warehouse(Hashtable c28cf3d24e3067ef54895f824fad7fcef)
	{
		mAccountId = (int)c28cf3d24e3067ef54895f824fad7fcef[0];
		mMaxSlots = (int)c28cf3d24e3067ef54895f824fad7fcef[1];
		Hashtable hashtable = (Hashtable)c28cf3d24e3067ef54895f824fad7fcef[2];
		IDictionaryEnumerator enumerator = hashtable.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)enumerator.Current;
				int key = (int)dictionaryEntry.Key;
				Hashtable hashtable2 = (Hashtable)dictionaryEntry.Value;
				if (hashtable2 == null)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						break;
					}
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
				}
				else
				{
					mItems[key] = new InventoryItem(hashtable2);
				}
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable == null)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						goto end_IL_00e5;
					}
					continue;
					end_IL_00e5:
					break;
				}
			}
			else
			{
				disposable.Dispose();
			}
		}
	}

	public Hashtable c2785337dcd6da152ea623eabc85b6d49()
	{
		Hashtable hashtable = new Hashtable();
		using (Dictionary<int, InventoryItem>.Enumerator enumerator = mItems.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				KeyValuePair<int, InventoryItem> current = enumerator.Current;
				if (current.Value == null)
				{
					continue;
				}
				while (true)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				Hashtable value = current.Value.mItem.c2785337dcd6da152ea623eabc85b6d49();
				hashtable[current.Key] = value;
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					goto end_IL_0074;
				}
				continue;
				end_IL_0074:
				break;
			}
		}
		Hashtable hashtable2 = new Hashtable();
		hashtable2.Add(0, mAccountId);
		hashtable2.Add(1, mMaxSlots);
		hashtable2.Add(2, hashtable);
		return hashtable2;
	}

	public ItemDNA[] cabea7fa8a6965fb908a577c67283aba5()
	{
		ItemDNA[] array = cd7e95b9c3ab3ea52b4fc74831d35ced6.c0a0cdf4a196914163f7334d9b0781a04(mMaxSlots);
		using (Dictionary<int, InventoryItem>.Enumerator enumerator = mItems.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				KeyValuePair<int, InventoryItem> current = enumerator.Current;
				if (current.Key >= array.Length)
				{
					continue;
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				array[current.Key] = current.Value.mItem;
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				return array;
			}
		}
	}
}
