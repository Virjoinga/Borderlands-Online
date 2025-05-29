using UnityEngine;

public class UIModelController : MonoBehaviour
{
	protected byte _rotateAxis;

	protected Vector3 _vecLastFrameMousePos;

	protected Vector3 _vecRotateSpeed = Vector3.zero;

	protected float _rotateSpeed = 2f;

	protected Quaternion _oriRotation;

	private void Awake()
	{
		_oriRotation = base.gameObject.transform.localRotation;
	}

	private void Update()
	{
		c3c734742a5b9de3262649ff375d2f06f();
	}

	private void Start()
	{
	}

	public void c0611c0503cb7e55eec97e2f0b356bbcd(Vector3 ce233b1fb8a4750ca379dc277602814da)
	{
		_vecRotateSpeed = ce233b1fb8a4750ca379dc277602814da;
	}

	public void c68d90d817b360f3767f83d5ba152ef76()
	{
		base.gameObject.transform.localRotation = _oriRotation;
	}

	protected void c3c734742a5b9de3262649ff375d2f06f()
	{
		Vector3 vector = Input.mousePosition - _vecLastFrameMousePos;
		_vecLastFrameMousePos = Input.mousePosition;
		Quaternion localRotation = base.gameObject.transform.localRotation;
		if (cf3267fd3a12d22d279a5fca3fa81ee88(_vecRotateSpeed.x))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			localRotation *= Quaternion.AngleAxis(_vecRotateSpeed.x * vector.x, Vector3.up);
		}
		if (cf3267fd3a12d22d279a5fca3fa81ee88(_vecRotateSpeed.y))
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
			localRotation *= Quaternion.AngleAxis(_vecRotateSpeed.y * vector.y, Vector3.left);
		}
		base.gameObject.transform.localRotation = localRotation;
	}

	public bool cf3267fd3a12d22d279a5fca3fa81ee88(float cefda2fdc3ce4e04f38bab77fc7998241)
	{
		if (object.Equals(cefda2fdc3ce4e04f38bab77fc7998241, 0f))
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return false;
				}
			}
		}
		if (float.IsNaN(cefda2fdc3ce4e04f38bab77fc7998241))
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		if (float.IsInfinity(cefda2fdc3ce4e04f38bab77fc7998241))
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		return true;
	}
}
