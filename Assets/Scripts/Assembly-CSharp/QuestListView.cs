using System.Collections.Generic;
using A;

public class QuestListView : BaseView
{
	protected int _iOnShowQuestID = -1;

	protected List<int> _onShowQuestIDList = new List<int>();

	protected Dictionary<int, QuestProgress> _questProgress = new Dictionary<int, QuestProgress>();

	public override bool c57b6c6861c1d709f4f7aa7b8a699b5c9()
	{
		return true;
	}

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().cbfdeda957ab87de3d0acf25194e61c4c(this);
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c914f3898d0cb85fdb88383c5a243cded(this);
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c3ee3ae9c8e9d7863fc24390827b6193f(this, "UIQuest");
		QuestUIDataManager.c71f6ce28731edfd43c976fbd57c57bea().cd35ec9bc0560c63369b10ad39d5c179b(c33ac4c0f51cd32dd024d0a97c2350cdf);
		_onShowQuestIDList = new List<int>();
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		base.cac7688b05e921e2be3f92479ba44b4a8();
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().cee8cde4410c30a1ff6fab848a28cf88f(this, string.Empty);
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().cfdafa122fc114376585cbb27b8811a86(this);
		c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c0f8db058f30b85298d876c68b2ca7053(this);
	}

	public override bool cc130a2d46a451dc54b61a8f0d60794ae()
	{
		if (c150264a18c2cb408479d3f072cac8cc1)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					c150264a18c2cb408479d3f072cac8cc1 = false;
					return true;
				}
			}
		}
		return base.cc130a2d46a451dc54b61a8f0d60794ae();
	}

	public virtual void c70b2c6b0dfcbcde99ba4dbf6a6b911f7(int c8d9247e6ec97defd6456db7da9372514)
	{
		_iOnShowQuestID = c8d9247e6ec97defd6456db7da9372514;
	}

	public virtual void cf00a3d5f06264dc7364f393405057c72(Dictionary<int, QuestProgress> c83eacefb66a7a7e1c47477d728c2025f)
	{
		_onShowQuestIDList.Clear();
		using (Dictionary<int, QuestProgress>.Enumerator enumerator = c83eacefb66a7a7e1c47477d728c2025f.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				KeyValuePair<int, QuestProgress> current = enumerator.Current;
				if (current.Value == null)
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
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
				}
				else
				{
					if (current.Value.mStatus == QuestState.Unavailable)
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
					if (current.Value.mStatus == QuestState.Available)
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
					}
					else
					{
						_onShowQuestIDList.Add(current.Value.mQuestId);
					}
				}
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
	}

	protected void c33ac4c0f51cd32dd024d0a97c2350cdf(Dictionary<int, QuestProgress> c83eacefb66a7a7e1c47477d728c2025f)
	{
		_questProgress = c83eacefb66a7a7e1c47477d728c2025f;
		if (!_bVisible)
		{
			return;
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			cf00a3d5f06264dc7364f393405057c72(c83eacefb66a7a7e1c47477d728c2025f);
			return;
		}
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
		if (!c8be1fcd630e5fe96821376d111325750)
		{
			return;
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			cf00a3d5f06264dc7364f393405057c72(_questProgress);
			return;
		}
	}

	protected virtual void c83f5d510d483adac7af2c6c9fdf95b71()
	{
		c150264a18c2cb408479d3f072cac8cc1 = false;
	}
}
