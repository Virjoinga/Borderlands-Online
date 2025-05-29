using System.Collections;
using UnityEngine;

public class ExpiringCurrency
{
	private float mRemainingTime0;

	private float mCurrentTime0;

	public int Count { get; set; }

	public float c556272486f855b6dc3e20f90745df2a7
	{
		get
		{
			return mRemainingTime0 - (Time.time - mCurrentTime0);
		}
	}

	public int Expires { get; set; }

	public ExpiringCurrency(Hashtable c591d56a94543e3559945c497f37126c4)
	{
		Count = (int)c591d56a94543e3559945c497f37126c4[0];
		mRemainingTime0 = (float)c591d56a94543e3559945c497f37126c4[1];
		mCurrentTime0 = Time.time;
	}
}
