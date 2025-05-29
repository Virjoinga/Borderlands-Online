using System.Collections.Generic;
using A;

internal class CurrencyService : OnAccessSingleton<ICurrencyService, CurrencyService, CurrencyServiceOffline>, ICurrencyService
{
	private List<OnCurrenciesUpdated> mOnCurrenciesUpdated = new List<OnCurrenciesUpdated>();

	private OnGotCurrencies mOnGotCurrencies;

	public CurrencyService()
	{
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(187, OnCurrenciesReceived);
		PhotonNetwork.onlinePeer.c71111ea3c8afdb98963505d86a8495b6(156, OnCurrenciesReceived);
		PhotonNetwork.onlinePeer.c89f9569b4330d0286992724cb1480f55(218, OnCurrenciesUpdatedEvent);
	}

	public void ceaf946a4b1d023143d622c7be7019235(OnGotCurrencies c2db84530ef366a6deb001d449d4aa151)
	{
		mOnGotCurrencies = c2db84530ef366a6deb001d449d4aa151;
		PhotonNetwork.onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(156, c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0));
	}

	public void cd58c83dd05d7926d4dc9ac246fb08de3(OnGotCurrencies c2db84530ef366a6deb001d449d4aa151, int c5dfde30d8784694fb9999709d290e6c4)
	{
		if (c2db84530ef366a6deb001d449d4aa151 != null)
		{
			while (true)
			{
				switch (6)
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
			mOnGotCurrencies = c2db84530ef366a6deb001d449d4aa151;
		}
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(1);
		array[0] = c5dfde30d8784694fb9999709d290e6c4;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(187, array);
	}

	private void OnCurrenciesReceived(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (mOnGotCurrencies == null)
		{
			return;
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
			if (operationResponse == 0)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				mOnGotCurrencies((int)parameters[0], (int)parameters[1], (int)parameters[2], (int)parameters[3]);
			}
			else
			{
				mOnGotCurrencies(-1, -1, -1, -1);
			}
			mOnGotCurrencies = c47d88aa3070736746a371064934e2c05.c7088de59e49f7108f520cf7e0bae167e;
			return;
		}
	}

	private void OnCurrenciesUpdatedEvent(Dictionary<byte, object> parameters)
	{
		int bondCurrency = (int)parameters[0];
		int specialCurrency = (int)parameters[1];
		int circulateCurrency = (int)parameters[2];
		mOnCurrenciesUpdated.ForEach(delegate(OnCurrenciesUpdated c2db84530ef366a6deb001d449d4aa151)
		{
			c2db84530ef366a6deb001d449d4aa151(bondCurrency, circulateCurrency, specialCurrency);
		});
	}

	public void c9a1a020b9c227311aeba9b5e48ccec2b(OnCurrenciesUpdated c2db84530ef366a6deb001d449d4aa151)
	{
		mOnCurrenciesUpdated.Add(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c0b8be230e87a5cf71ef51ec29c2b0e3d(OnCurrenciesUpdated c2db84530ef366a6deb001d449d4aa151)
	{
		mOnCurrenciesUpdated.Remove(c2db84530ef366a6deb001d449d4aa151);
	}

	public void cfb8f7efeae7b64504aa102b388466247(int c5dfde30d8784694fb9999709d290e6c4, int cdddf3ee050c73253a0eed1738c2fc872, int c8e0912d89bc1f75509dd09fc37fdec7b, int c7b176945cd320ea3c7e7a8e06224c2d0)
	{
		OnlineServerPeer onlinePeer = PhotonNetwork.onlinePeer;
		object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
		array[0] = c5dfde30d8784694fb9999709d290e6c4;
		array[1] = cdddf3ee050c73253a0eed1738c2fc872;
		array[2] = c8e0912d89bc1f75509dd09fc37fdec7b;
		array[3] = c7b176945cd320ea3c7e7a8e06224c2d0;
		onlinePeer.c4c1ac70d53ab42afe86bbfda86212944(186, array);
	}
}
