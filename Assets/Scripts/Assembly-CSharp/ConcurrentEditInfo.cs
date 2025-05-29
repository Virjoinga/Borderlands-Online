using System;
using UnityEngine;

public class ConcurrentEditInfo : MonoBehaviour
{
	public string m_ConcurrentEditInfo = string.Empty;

	public static string cee9b256c4c1b76c097407e15b387dc5e()
	{
		return string.Format("{0}_{1}", Environment.GetEnvironmentVariable("COMPUTERNAME"), DateTime.Now.ToString("s"));
	}

	public void c36c557e3f9cecc38e4de32db86128993()
	{
		m_ConcurrentEditInfo = cee9b256c4c1b76c097407e15b387dc5e();
	}
}
