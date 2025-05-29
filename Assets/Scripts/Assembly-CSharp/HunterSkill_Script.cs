using System.Collections;
using UnityEngine;

public class HunterSkill_Script : MonoBehaviour
{
	public float m_lifeTimeMin = 1f;

	public float m_lifeTimeMax = 3f;

	public void cb87648b83ed063b8b24a3769197f46d0()
	{
		base.gameObject.SetActive(true);
		float cb9498b6b2d2733d403e9b3a2372790b = Random.Range(m_lifeTimeMin, m_lifeTimeMax);
		StartCoroutine(ca026af08fc71896ff9f81ee83f8359fc(cb9498b6b2d2733d403e9b3a2372790b));
	}

	private IEnumerator ca026af08fc71896ff9f81ee83f8359fc(float cb9498b6b2d2733d403e9b3a2372790b0)
	{
		yield return new WaitForSeconds(cb9498b6b2d2733d403e9b3a2372790b0);
		base.gameObject.SetActive(false);
	}
}
