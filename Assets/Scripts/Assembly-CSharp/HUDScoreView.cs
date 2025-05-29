using System.Collections.Generic;
using A;

public class HUDScoreView : BaseView
{
	protected bool m_bScoreBoardVisible;

	protected List<StatisticsManager.StatSheet> m_scoreCardList = new List<StatisticsManager.StatSheet>();

	public override bool c57b6c6861c1d709f4f7aa7b8a699b5c9()
	{
		return true;
	}

	public override void OnTestGUI()
	{
	}

	public virtual void c2061c84033e144e4c9761c26f0ee9a5d(bool c8be1fcd630e5fe96821376d111325750)
	{
		m_bScoreBoardVisible = c8be1fcd630e5fe96821376d111325750;
	}

	public virtual void c4b79dd2406b9a346ab9d6050a383ffb4(StatisticsManager.StatSheet[] c912f5d0ee7cccfc3d9bfe9cd831d54a7)
	{
		m_scoreCardList.Clear();
		foreach (StatisticsManager.StatSheet statSheet in c912f5d0ee7cccfc3d9bfe9cd831d54a7)
		{
			if (statSheet.m_name == null)
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
			m_scoreCardList.Add(statSheet);
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			m_scoreCardList.Sort(ca33854696368819ae699ceaa1aab640f);
			return;
		}
	}

	protected int ca33854696368819ae699ceaa1aab640f(StatisticsManager.StatSheet c55548d7c3d612d81f44ffddf160db45c, StatisticsManager.StatSheet ce8331da224869a297200f69ab63fbbe9)
	{
		return -(c55548d7c3d612d81f44ffddf160db45c.m_score - ce8331da224869a297200f69ab63fbbe9.m_score);
	}

	public virtual void c9c6080e1b1663d026afd1cc2c9b9a906(StatisticsManager.StatSheet[] c09ca635c6106f923fefa1dc01370ac42)
	{
		c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.c1bdd1e7aa891de56d871ae24289f5f8b();
	}

	protected void c8764d38baaff094368eb4fed91f2e592()
	{
		c06ca0e618478c23eba3419653a19760f<GameFlowManager>.c5ee19dc8d4cccf5ae2de225410458b86.cec9cdae23444bbac5cad953e7fc1f8e9();
	}
}
