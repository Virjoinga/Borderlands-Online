using System.Collections;
using UnityEngine;

[AddComponentMenu("uniSWF/PumpkinBehaviour")]
public class PumpkinBehaviour : MonoBehaviour
{
	public object userData;

	protected bool isLocal = true;

	private string m_CurrencState;

	private string m_NextState;

	private float m_StateStartTime = 0f;

	private float m_UpdateTime = 0f;

	private float m_UpdateSleep = 0f;

	protected bool debugStates = false;

	private void Start()
	{
		OnStart();
	}

	public virtual void OnStart()
	{
	}

	public virtual void Update()
	{
		if (m_UpdateSleep == 0f || !(Time.time - m_UpdateTime < m_UpdateSleep))
		{
			m_UpdateTime = Time.time;
			m_UpdateSleep = 0f;
			if (m_CurrencState != null && m_CurrencState.Length > 0)
			{
				SendMessage(m_CurrencState + "Update", SendMessageOptions.DontRequireReceiver);
			}
			OnUpdate();
		}
	}

	public virtual void OnUpdate()
	{
	}

	public void OnDestroy()
	{
		StopCoroutine("_setStateWithDelay");
		OnDestroyBehiavour();
	}

	public virtual void OnDestroyBehiavour()
	{
	}

	public void SetState(string name)
	{
		SetState(name, 0f);
	}

	public void SetState(string name, float delay)
	{
		if (!(m_NextState == name))
		{
			m_NextState = name;
			StopCoroutine("_setStateWithDelay");
			object[] value = new object[2] { name, delay };
			StartCoroutine("_setStateWithDelay", value);
		}
	}

	public void UpdateSleep(float t)
	{
		m_UpdateSleep = t;
	}

	private void _setState(string name)
	{
		if (m_CurrencState != null)
		{
			SendMessage(m_CurrencState + "End", SendMessageOptions.DontRequireReceiver);
		}
		m_CurrencState = name;
		m_NextState = null;
		m_StateStartTime = Time.time;
		if (m_CurrencState != null)
		{
			SendMessage(name + "Start", SendMessageOptions.DontRequireReceiver);
		}
	}

	protected IEnumerator _setStateWithDelay(object[] props)
	{
		yield return new WaitForSeconds((float)props[1]);
		_setState((string)props[0]);
	}

	protected object Wait(float time)
	{
		return new WaitForSeconds(time);
	}

	public string GetStateName()
	{
		return m_CurrencState;
	}

	public bool IsStateActive(string name)
	{
		if (m_CurrencState == null)
		{
			return false;
		}
		return m_CurrencState.CompareTo(name) == 0;
	}

	public float GetStateTime()
	{
		return Time.time - m_StateStartTime;
	}

	public float GetStateTimeMs()
	{
		return Time.time - m_StateStartTime;
	}

	public void RemoveComponent(string c)
	{
		Object.Destroy(GetComponent(c));
	}

	public Component AddComponent(string c)
	{
		return base.gameObject.AddComponent(c);
	}
}
