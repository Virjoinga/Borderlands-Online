using System;
using UnityEngine;

namespace Core
{
	[Serializable]
	public class UIMessage
	{
		public enum c7487b4eea694c61027850111354bc24f
		{
			ce46bb1d037377c00fcc2fab1aa927d01 = 0,
			c181a87d44cdf850bdb7592b2a6ba24f8 = 1,
			c791e90673001750f3122e49fe9932b44 = 2,
			c032250debe9e9c0062c0148fd52393a3 = 3,
			ca716e985917247ae9314664de09f33a7 = 4,
			ce6db0d9bee52cc2eb4c88d724216d56c = 5,
			c480b6726cd3b2fc67b24d943fd669f73 = 6
		}

		public c7487b4eea694c61027850111354bc24f m_type;

		public string m_text = "Default Text";

		public float m_duration = 5f;

		public bool m_displayCountDown;

		[HideInInspector]
		public float m_decayDate;
	}
}
