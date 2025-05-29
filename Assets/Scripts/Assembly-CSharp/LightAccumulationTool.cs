using UnityEngine;

public class LightAccumulationTool : MonoBehaviour
{
	private Camera m_camera;

	private Shader m_accumShader;

	private void Start()
	{
		m_camera = GetComponent<Camera>();
		m_accumShader = Shader.Find("Custom/LightAccumTool");
		m_camera.SetReplacementShader(m_accumShader, string.Empty);
	}

	private void Update()
	{
	}
}
