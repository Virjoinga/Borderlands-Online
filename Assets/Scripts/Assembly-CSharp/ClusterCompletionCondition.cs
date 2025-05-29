using System;
using A;

[Serializable]
public class ClusterCompletionCondition : OldClusterCondition
{
	public Scene m_cluster;

	public override bool c943bc6a18586b3e0e6f0214717aca479()
	{
		if (!m_isValid)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (m_cluster != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (m_cluster.c3f963ede023fab99c4b2097e3537c34c() == Scene.SceneState.Completed)
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
					m_isValid = true;
				}
			}
		}
		return m_isValid;
	}
}
