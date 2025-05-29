using UnityEngine;

public class AudioRTPCSystem : MonoBehaviour
{
	public RTPCField[] m_RTPCs;

	private void Awake()
	{
	}

	public void OnAddUpdate(int idx)
	{
		RTPCField rTPCField = m_RTPCs[idx];
		for (int num = rTPCField.typeCfgs.Length - 1; num >= 0; num--)
		{
			if (rTPCField.value >= rTPCField.typeCfgs[num].addStart)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						if (!rTPCField.currentType.Equals(rTPCField.typeCfgs[num].type))
						{
							while (true)
							{
								switch (6)
								{
								case 0:
									break;
								default:
									rTPCField.currentType = rTPCField.typeCfgs[num].type;
									return;
								}
							}
						}
						return;
					}
				}
			}
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	public void OnSubUpdate(int idx)
	{
		RTPCField rTPCField = m_RTPCs[idx];
		for (int i = 0; i < rTPCField.typeCfgs.Length; i++)
		{
			if (rTPCField.value > rTPCField.typeCfgs[i].subStart)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (rTPCField.currentType.Equals(rTPCField.typeCfgs[i].type))
				{
					return;
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					rTPCField.currentType = rTPCField.typeCfgs[i].type;
					return;
				}
			}
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}
}
