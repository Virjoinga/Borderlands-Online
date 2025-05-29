using System.Collections.Generic;
using A;
using Core;
using UnityEngine;

public class MecanimEventEmitter : MonoBehaviour
{
	public Object animatorController;

	public Animator animator;

	public MecanimEventEmitTypes emitType = MecanimEventEmitTypes.Upwards;

	protected int m_animatorControllerId = -1;

	protected bool m_bEmitterLoaded;

	protected List<MecanimEvent> m_animEventList = new List<MecanimEvent>();

	private void Start()
	{
		string text = base.gameObject.name;
		if (base.transform.parent != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			text = base.transform.parent.name + "-->" + text;
		}
		if (animator == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Animation, "Do not find animator component." + text);
					base.enabled = false;
					return;
				}
			}
		}
		if (animatorController == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Animation, "Please assgin animator in editor. Add emitter at runtime is not currently supported." + text);
					base.enabled = false;
					return;
				}
			}
		}
		if (MecanimEventManager.c18ae3439905a0b018b68783f166607d2 != null)
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
			string key = Utils.cabefce0ea6f28c011adc224f6f0f0790(animator.runtimeAnimatorController.name);
			m_bEmitterLoaded = MecanimEventManager.c18ae3439905a0b018b68783f166607d2.ContainsKey(key);
			if (m_bEmitterLoaded)
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
				m_animatorControllerId = MecanimEventManager.c18ae3439905a0b018b68783f166607d2[key];
			}
			else
			{
				DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.Animation, "Couldn't load MecanimEventEmitter data for: " + Utils.c6623cde42db4307c0b144942a5a8c70d(base.gameObject) + "\n\t animator.runtimeAnimatorController.name: " + animator.runtimeAnimatorController.name);
			}
		}
		if (m_animEventList == null)
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
			m_animEventList.Clear();
			return;
		}
	}

	private void Update()
	{
		if (!m_bEmitterLoaded)
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
					return;
				}
			}
		}
		MecanimEventManager.c61d1999d0d09515f6fefe4c234a27452(ref m_animEventList, m_animatorControllerId, animator);
		for (int i = 0; i < m_animEventList.Count; i++)
		{
			MecanimEvent mecanimEvent = m_animEventList[i];
			MecanimEvent.c3094946243c26396f504b818c6388458(mecanimEvent);
			MecanimEventEmitTypes mecanimEventEmitTypes = emitType;
			if (mecanimEventEmitTypes != MecanimEventEmitTypes.Upwards)
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
				if (mecanimEventEmitTypes != MecanimEventEmitTypes.Broadcast)
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
					if (mecanimEvent.paramType != 0)
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
						SendMessage(mecanimEvent.functionName, mecanimEvent.parameter, SendMessageOptions.DontRequireReceiver);
					}
					else
					{
						SendMessage(mecanimEvent.functionName, SendMessageOptions.DontRequireReceiver);
					}
				}
				else if (mecanimEvent.paramType != 0)
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
					BroadcastMessage(mecanimEvent.functionName, mecanimEvent.parameter, SendMessageOptions.DontRequireReceiver);
				}
				else
				{
					BroadcastMessage(mecanimEvent.functionName, SendMessageOptions.DontRequireReceiver);
				}
			}
			else if (mecanimEvent.paramType != 0)
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
				SendMessageUpwards(mecanimEvent.functionName, mecanimEvent.parameter, SendMessageOptions.DontRequireReceiver);
			}
			else
			{
				SendMessageUpwards(mecanimEvent.functionName, SendMessageOptions.DontRequireReceiver);
			}
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			if (m_animEventList == null)
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
				m_animEventList.Clear();
				return;
			}
		}
	}
}
