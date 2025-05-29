using System.Collections.Generic;
using A;

public class HUDVictoryCondition : BaseView
{
	public enum eTimeStatus
	{
		none = 0,
		normal = 1,
		last20sec = 2,
		over = 3
	}

	protected eTimeStatus m_currentStatus;

	protected bool m_bNewPhaseActived;

	public override bool c57b6c6861c1d709f4f7aa7b8a699b5c9()
	{
		return true;
	}

	public override void OnTestGUI()
	{
	}

	public virtual void cd2cca57d3ef8ebc1d8ebfb19bd5a12d8(bool cda27ffec6c31265acec668af9ab6bac7)
	{
	}

	public virtual void cf887ab58656d86bc97c0443b84700a30(int c3675120a7d006992458a7b012bc6ae14, StatisticsManager.StatSheet c25f5f36a54095a8f73d85c7f7b5af196 = null)
	{
		int num = c3675120a7d006992458a7b012bc6ae14 / 60;
		int num2 = c3675120a7d006992458a7b012bc6ae14 % 60;
		m_bNewPhaseActived = false;
		if (m_currentStatus == eTimeStatus.over)
		{
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
			if (num == 0)
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
				if (num2 == 0)
				{
					goto IL_0055;
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			m_bNewPhaseActived = true;
			m_currentStatus = eTimeStatus.none;
		}
		goto IL_0055;
		IL_0055:
		if (num2 > 20)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				break;
			}
			if (m_currentStatus != eTimeStatus.normal)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				if (m_currentStatus != eTimeStatus.over)
				{
					while (true)
					{
						switch (2)
						{
						case 0:
							break;
						default:
							m_currentStatus = eTimeStatus.normal;
							m_bNewPhaseActived = true;
							return;
						}
					}
				}
			}
		}
		if (num2 < 20)
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
			if (num == 0)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
				if (m_currentStatus != eTimeStatus.last20sec)
				{
					while (true)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						break;
					}
					if (m_currentStatus != eTimeStatus.over)
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								m_currentStatus = eTimeStatus.last20sec;
								m_bNewPhaseActived = true;
								return;
							}
						}
					}
				}
			}
		}
		if (num != 0)
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
			if (num2 != 0)
			{
				return;
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				if (m_currentStatus == eTimeStatus.over)
				{
					return;
				}
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					m_currentStatus = eTimeStatus.over;
					m_bNewPhaseActived = true;
					return;
				}
			}
		}
	}

	protected StatisticsManager.StatSheet c96d07c9c1d2f219d906efac7cd5e405f()
	{
		StatisticsManager.StatSheet result = null;
		int num = 0;
		int num2 = c06ca0e618478c23eba3419653a19760f<ScoringManager>.c5ee19dc8d4cccf5ae2de225410458b86.c415f9dee531e543fc447806c04e5e5f9();
		List<PlayerInfoSync> c9c8de68aa0982db2bbd496692c37e;
		c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c7822eacaa3505f8c170e4316704ac984(out c9c8de68aa0982db2bbd496692c37e);
		StatisticsManager.StatSheet statSheet = null;
		int num3 = 0;
		while (true)
		{
			if (num3 < c9c8de68aa0982db2bbd496692c37e.Count)
			{
				statSheet = c06ca0e618478c23eba3419653a19760f<StatisticsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c45046ccb66f97acb081de281306e5c25().cdcb2ff44fc70c31a5ec9c7f0156d8f27(c9c8de68aa0982db2bbd496692c37e[num3]);
				if (statSheet != null)
				{
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
					if (statSheet.m_score == num2)
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
						result = statSheet;
						num++;
						if (num >= 2)
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
							result = null;
							break;
						}
					}
				}
				num3++;
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
			break;
		}
		return result;
	}
}
