using System;
using A;

[Serializable]
public class PatrolSettings
{
	public enum PatrolPolicy
	{
		None = 0,
		Sequencial = 1,
		Random = 2
	}

	public PatrolPolicy m_patrolPolicy;

	public PatrolPoint[] m_patrolPath = c4e6dd5d96fbc93890cd256676fa3e4f5.c0a0cdf4a196914163f7334d9b0781a04(0);
}
