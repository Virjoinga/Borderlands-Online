using Core;
using UnityEngine;

[ExecuteInEditMode]
public abstract class BaseEventTriggerCtl : MonoBehaviour
{
	public abstract EventTriggerData c6ce4fecb4b540d34b74bd1f7ebd58577();

	public virtual void TriggerEventByName(string eventName)
	{
	}

	public virtual void ReleaseEventByName(string eventName)
	{
	}

	protected virtual void TriggerAudioEventMecanim(string eventName)
	{
		TriggerEventByName(eventName);
	}

	public virtual void ReleaseAudioEventMecanim(string eventName)
	{
		ReleaseEventByName(eventName);
	}

	protected virtual void TriggerNPCLogicEventMecanim(string eventName)
	{
		DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Audio, "TriggerNPCLogicEventMecanim with param " + eventName);
	}

	protected virtual void ReleaseNPCLogicEventMecanim(string eventName)
	{
		DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Audio, "ReleaseNPCLogicEventMecanim with param " + eventName);
	}

	protected virtual void TriggerNPCVFXEventMechanim(string eventName)
	{
		DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Audio, "TriggerNPCVFXEventMechanim with param " + eventName);
	}

	protected virtual void ReleaseNPCVFXEventMechanim(string eventName)
	{
		DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Audio, "ReleaseNPCVFXEventMechanim with param " + eventName);
	}

	public virtual void TriggerEventOnChildren(string eventName)
	{
	}
}
