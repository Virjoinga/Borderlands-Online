using UnityEngine;

namespace pumpkin.events
{
	public class PlatformWarning : MonoBehaviour
	{
		public string warningStr = "";

		private void OnGUI()
		{
			GUILayout.Label(warningStr);
		}
	}
}
