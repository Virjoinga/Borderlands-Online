using System;
using Core;
using UnityEngine;

[Serializable]
public class ClusterAction : ScriptableObject, ICloneable, IComparable
{
	[SerializeField]
	protected int m_executionOrder;

	public virtual object Clone()
	{
		ClusterAction clusterAction = ScriptableObject.CreateInstance(GetType()) as ClusterAction;
		clusterAction.m_executionOrder = m_executionOrder;
		return clusterAction;
	}

	public int CompareTo(object obj)
	{
		if (obj is ClusterAction)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					if (this == obj)
					{
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								return 0;
							}
						}
					}
					int executionOrder = (obj as ClusterAction).m_executionOrder;
					if (m_executionOrder <= executionOrder)
					{
						while (true)
						{
							switch (7)
							{
							case 0:
								break;
							default:
								return -1;
							}
						}
					}
					return 1;
				}
				}
			}
		}
		DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.System, "compare to Object is not a ClusterAction");
		return 0;
	}

	public virtual void c07b7ce37423e253b784029efb12b608f(Scene c706ea4155b03100282fe553e4d0be557)
	{
		throw new NotImplementedException();
	}
}
