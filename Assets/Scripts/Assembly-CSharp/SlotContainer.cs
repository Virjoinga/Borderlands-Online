using UnityEngine;

public class SlotContainer : MonoBehaviour
{
}
public class SlotContainer<T> : SlotContainer where T : Slot, new()
{
	public T[] m_slots = new T[0];
}
