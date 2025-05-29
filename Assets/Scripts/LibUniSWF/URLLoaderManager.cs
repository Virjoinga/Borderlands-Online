using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using pumpkin.events;
using pumpkin.net;

public class URLLoaderManager : MonoBehaviour
{
	private static URLLoaderManager _instance;

	private bool routineStarted = false;

	private List<URLLoader> m_Queue = new List<URLLoader>();

	public static URLLoaderManager getInstance()
	{
		if (_instance != null)
		{
			return _instance;
		}
		GameObject gameObject = GameObject.Find("URLLoaderManager");
		if (gameObject != null)
		{
			_instance = gameObject.GetComponent<URLLoaderManager>();
			return _instance;
		}
		gameObject = new GameObject();
		gameObject.name = "URLLoaderManager";
		return gameObject.AddComponent<URLLoaderManager>();
	}

	private void Start()
	{
	}

	private IEnumerator ProcessQueue()
	{
		while (m_Queue.Count > 0)
		{
			URLLoader loader = m_Queue[0];
			m_Queue.RemoveAt(0);
			if (!loader.cancelled)
			{
				yield return loader.www;
				if (loader.www.error != null)
				{
					loader.dispatchEvent(new IOErrorEvent(IOErrorEvent.IO_ERROR)
					{
						error = loader.www.error + ", url: " + loader.www.url
					});
				}
				else if (!loader.cancelled)
				{
					loader.data = loader.www.text;
					loader.dispatchEvent(new CEvent(CEvent.COMPLETE));
				}
			}
		}
	}

	public void addLoadRequest(URLLoader loader)
	{
		m_Queue.Add(loader);
		StartCoroutine(ProcessQueue());
	}
}
