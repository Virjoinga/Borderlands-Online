using UnityEngine;

public class DestoryableObjSetting : MonoBehaviour
{
	public string m_name = "DestoryableObj";

	public bool m_bHideUI;

	public bool m_receiveMeleeAttackDamage = true;

	public bool m_receiveAreaDamage = true;

	public bool m_receiveShootDamage = true;

	public int m_initHP = 100;
}
