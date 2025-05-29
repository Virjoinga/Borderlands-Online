using System.Collections.Generic;
using UnityEngine;

public class ClusterAction_ResetAnimatorSpeed : ClusterAction
{
	public enum ResetType
	{
		SetNewSpeed = 0,
		RestoreOriginalSpeed = 1
	}

	public static Dictionary<string, float> m_storedSpeeds = new Dictionary<string, float>();

	public EntityNpc.EntitySubType m_npcType;

	public Scene.TargetType m_targetType;

	public GameObject m_targetObject;

	public float m_newAnimatorSpeed = 1f;

	public ResetType m_resetType = ResetType.RestoreOriginalSpeed;

	public override object Clone()
	{
		ClusterAction_ResetAnimatorSpeed clusterAction_ResetAnimatorSpeed = ScriptableObject.CreateInstance(GetType()) as ClusterAction_ResetAnimatorSpeed;
		clusterAction_ResetAnimatorSpeed.m_npcType = m_npcType;
		clusterAction_ResetAnimatorSpeed.m_targetType = m_targetType;
		clusterAction_ResetAnimatorSpeed.m_targetObject = m_targetObject;
		clusterAction_ResetAnimatorSpeed.m_newAnimatorSpeed = m_newAnimatorSpeed;
		clusterAction_ResetAnimatorSpeed.m_resetType = m_resetType;
		clusterAction_ResetAnimatorSpeed.m_executionOrder = m_executionOrder;
		return clusterAction_ResetAnimatorSpeed;
	}
}
