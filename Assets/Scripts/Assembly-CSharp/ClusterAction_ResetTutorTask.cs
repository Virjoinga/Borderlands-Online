using A;
using BHV;
using UnityEngine;

public class ClusterAction_ResetTutorTask : ClusterAction
{
	public enum TutorTaskType
	{
		Move = 1,
		Talk = 2,
		Wait = 3,
		DoAction = 4
	}

	public enum TutorAction
	{
		None = 0,
		Nervous = 1,
		OperatingPanel = 2
	}

	public enum TutorMoveStyle
	{
		Normal = 0,
		Scared = 1
	}

	public enum FacingOption
	{
		Player = 0,
		TargetObject = 1
	}

	public TutorTaskType m_taskType = TutorTaskType.Wait;

	public string m_message;

	public float m_repeatMessageWaitTime;

	public float m_idleWaitTime;

	public bool m_finished;

	public BHVMovementSpeed m_moveSpeed;

	public GameObject m_moveToDestination;

	public GameObject m_facingObject;

	public TutorAction m_tutorAction;

	public TutorMoveStyle m_moveStyle;

	public FacingOption m_facingOption = FacingOption.TargetObject;

	[SerializeField]
	private int m_moveSpeedIndex;

	private string[] m_moveSpeedNames;

	public ClusterAction_ResetTutorTask()
	{
		string[] array = cc0e539374e3bec368c866a10ea95a837.c0a0cdf4a196914163f7334d9b0781a04(3);
		array[0] = "WALK";
		array[1] = "RUN";
		array[2] = "SPRINT";
		m_moveSpeedNames = array;
		base._002Ector();
	}

	public override object Clone()
	{
		ClusterAction_ResetTutorTask clusterAction_ResetTutorTask = ScriptableObject.CreateInstance(GetType()) as ClusterAction_ResetTutorTask;
		clusterAction_ResetTutorTask.m_taskType = m_taskType;
		clusterAction_ResetTutorTask.m_message = m_message;
		clusterAction_ResetTutorTask.m_repeatMessageWaitTime = m_repeatMessageWaitTime;
		clusterAction_ResetTutorTask.m_idleWaitTime = m_idleWaitTime;
		clusterAction_ResetTutorTask.m_finished = m_finished;
		clusterAction_ResetTutorTask.m_moveSpeed = m_moveSpeed;
		clusterAction_ResetTutorTask.m_moveToDestination = m_moveToDestination;
		clusterAction_ResetTutorTask.m_facingObject = m_facingObject;
		clusterAction_ResetTutorTask.m_tutorAction = m_tutorAction;
		clusterAction_ResetTutorTask.m_moveStyle = m_moveStyle;
		clusterAction_ResetTutorTask.m_facingOption = m_facingOption;
		clusterAction_ResetTutorTask.m_moveSpeedIndex = m_moveSpeedIndex;
		clusterAction_ResetTutorTask.m_executionOrder = m_executionOrder;
		return clusterAction_ResetTutorTask;
	}
}
