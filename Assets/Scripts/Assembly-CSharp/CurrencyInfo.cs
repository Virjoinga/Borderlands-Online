using System;
using System.Collections;
using System.Collections.Generic;
using XsdSettings;

public class CurrencyInfo
{
	private Dictionary<LuckyBoxRank, int> mKeys = new Dictionary<LuckyBoxRank, int>();

	private Dictionary<LuckyBoxRank, ExpiringCurrency> mExpiringKeys = new Dictionary<LuckyBoxRank, ExpiringCurrency>();

	public int CharacterId { get; set; }

	public int BondCurrency { get; set; }

	public int CirculateCurrency { get; set; }

	public int SpecialCurrency { get; set; }

	public Dictionary<LuckyBoxRank, int> cbab1b45c1da05265f0459d3ebbe08b7c
	{
		get
		{
			return mKeys;
		}
	}

	public Dictionary<LuckyBoxRank, ExpiringCurrency> c6d1a6bc2728f2d802903c307c555a497
	{
		get
		{
			return mExpiringKeys;
		}
	}

	public CurrencyInfo(Hashtable c591d56a94543e3559945c497f37126c4)
	{
		cc95f1fbaa3f9e0533900d0e3a5e0bfa2(c591d56a94543e3559945c497f37126c4);
		OnAccessSingleton<ICurrencyService, CurrencyService, CurrencyServiceOffline>.c5ee19dc8d4cccf5ae2de225410458b86.c9a1a020b9c227311aeba9b5e48ccec2b(OnCurrenciesUpdated);
	}

	public void cc95f1fbaa3f9e0533900d0e3a5e0bfa2(Hashtable c591d56a94543e3559945c497f37126c4)
	{
		CharacterId = (int)c591d56a94543e3559945c497f37126c4[0];
		BondCurrency = (int)c591d56a94543e3559945c497f37126c4[1];
		CirculateCurrency = (int)c591d56a94543e3559945c497f37126c4[2];
		SpecialCurrency = (int)c591d56a94543e3559945c497f37126c4[3];
		Hashtable hashtable = (Hashtable)c591d56a94543e3559945c497f37126c4[4];
		IDictionaryEnumerator enumerator = hashtable.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)enumerator.Current;
				mKeys[(LuckyBoxRank)(int)dictionaryEntry.Key] = (int)dictionaryEntry.Value;
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				break;
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
						goto end_IL_00e3;
					}
					continue;
					end_IL_00e3:
					break;
				}
			}
			else
			{
				disposable.Dispose();
			}
		}
		Hashtable hashtable2 = (Hashtable)c591d56a94543e3559945c497f37126c4[5];
		IDictionaryEnumerator enumerator2 = hashtable2.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				DictionaryEntry dictionaryEntry2 = (DictionaryEntry)enumerator2.Current;
				Hashtable c591d56a94543e3559945c497f37126c5 = (Hashtable)dictionaryEntry2.Value;
				mExpiringKeys[(LuckyBoxRank)(int)dictionaryEntry2.Key] = new ExpiringCurrency(c591d56a94543e3559945c497f37126c5);
			}
			while (true)
			{
				switch (6)
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
			IDisposable disposable2 = enumerator2 as IDisposable;
			if (disposable2 == null)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						goto end_IL_017a;
					}
					continue;
					end_IL_017a:
					break;
				}
			}
			else
			{
				disposable2.Dispose();
			}
		}
	}

	private void OnCurrenciesUpdated(int bondCurrency, int circulateCurrency, int specialCurrency)
	{
		BondCurrency = bondCurrency;
		CirculateCurrency = circulateCurrency;
		SpecialCurrency = specialCurrency;
	}
}
