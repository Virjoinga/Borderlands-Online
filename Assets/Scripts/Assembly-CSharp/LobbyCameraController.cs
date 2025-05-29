using A;
using UnityEngine;

public class LobbyCameraController : MonoBehaviour
{
	private delegate void AnimationUpdateFunc();

	private int _curIndex = 1;

	private int _targetIndex = 1;

	private string ANIM_NAME = "Floasm_Lobby_camera01";

	public string ANIMATION_NAME = string.Empty;

	public GameObject[] _arrTextObject;

	public string TEXT_ANIM = "_anim";

	public string TEXT_ANIM_IDLE = "_idle";

	private AnimationUpdateFunc _updateFunc;

	private bool _bPlaying;

	private void Awake()
	{
		if (ANIMATION_NAME != string.Empty)
		{
			while (true)
			{
				switch (1)
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
			ANIM_NAME = ANIMATION_NAME;
		}
		if (TEXT_ANIM == string.Empty)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				break;
			}
			TEXT_ANIM = "_anim";
		}
		if (TEXT_ANIM_IDLE == string.Empty)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				break;
			}
			TEXT_ANIM_IDLE = "_idle";
		}
		if (base.camera == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
		base.camera.animation.wrapMode = WrapMode.ClampForever;
		base.camera.animation[ANIM_NAME].speed = 0f;
		base.camera.animation.Play(ANIM_NAME);
		for (int i = 0; i < _arrTextObject.Length; i++)
		{
			if (!(_arrTextObject[i] != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
			{
				continue;
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				break;
			}
			string text = _arrTextObject[i].name + TEXT_ANIM;
			_arrTextObject[i].animation[text].speed = 0f;
			_arrTextObject[i].animation.Play(text);
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			cf7041ea37043e7d8c048f6e396d45d6f(_targetIndex - 1);
			return;
		}
	}

	public void c5e79c12b4057f9becf0b648b40f4a7ee(int caaa3357772493402d14383b3a06e89ee)
	{
		if (caaa3357772493402d14383b3a06e89ee == _targetIndex)
		{
			while (true)
			{
				switch (1)
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
			if (!_bPlaying)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
		}
		cf7041ea37043e7d8c048f6e396d45d6f(_targetIndex - 1, -1f);
		_targetIndex = caaa3357772493402d14383b3a06e89ee;
		c099b8f51cb2596aa23afe47eede06a2b();
	}

	private void c099b8f51cb2596aa23afe47eede06a2b()
	{
		float speed;
		if (_targetIndex == _curIndex)
		{
			while (true)
			{
				switch (1)
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
			speed = 0f - base.camera.animation[ANIM_NAME].speed;
		}
		else if (_targetIndex > _curIndex)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				break;
			}
			speed = 1f + (float)(_targetIndex - _curIndex - 1) * 0.3f;
		}
		else
		{
			speed = -1f - (float)(_curIndex - _targetIndex - 1) * 0.3f;
		}
		base.camera.animation[ANIM_NAME].speed = speed;
		_bPlaying = true;
	}

	private void c61a711afedcb889e44fe9cdf43bffbc7(int c26e682ea4eb57ca2033b70f7994f2b4e)
	{
		_curIndex = c26e682ea4eb57ca2033b70f7994f2b4e;
		if (_curIndex != _targetIndex)
		{
			return;
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			base.camera.animation[ANIM_NAME].speed = 0f;
			_bPlaying = false;
			cf7041ea37043e7d8c048f6e396d45d6f(_targetIndex - 1);
			return;
		}
	}

	private void cf7041ea37043e7d8c048f6e396d45d6f(int c26e682ea4eb57ca2033b70f7994f2b4e, float c9e855f06f63b375a3f17fe638fce9dd3 = 1f)
	{
		if (!(_arrTextObject[c26e682ea4eb57ca2033b70f7994f2b4e] != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
		{
			return;
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			string text = _arrTextObject[c26e682ea4eb57ca2033b70f7994f2b4e].name + TEXT_ANIM;
			_arrTextObject[c26e682ea4eb57ca2033b70f7994f2b4e].animation[text].normalizedTime = 0f - Mathf.Min(0f, c9e855f06f63b375a3f17fe638fce9dd3);
			_arrTextObject[c26e682ea4eb57ca2033b70f7994f2b4e].animation[text].speed = c9e855f06f63b375a3f17fe638fce9dd3;
			_arrTextObject[c26e682ea4eb57ca2033b70f7994f2b4e].animation.wrapMode = WrapMode.ClampForever;
			_arrTextObject[c26e682ea4eb57ca2033b70f7994f2b4e].animation.Play(text);
			if (c9e855f06f63b375a3f17fe638fce9dd3 > 0f)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						_updateFunc = c5f10a328033b5421c8b60064782d9885;
						return;
					}
				}
			}
			_updateFunc = null;
			return;
		}
	}

	private void Update()
	{
		if (_updateFunc == null)
		{
			return;
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			_updateFunc();
			return;
		}
	}

	private void c5f10a328033b5421c8b60064782d9885()
	{
		int num = _targetIndex - 1;
		if (!(_arrTextObject[num] != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
		{
			return;
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (!(_arrTextObject[num].animation[_arrTextObject[num].name + TEXT_ANIM].normalizedTime > 1f))
			{
				return;
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				string text = _arrTextObject[num].name + TEXT_ANIM_IDLE;
				_arrTextObject[num].animation[text].speed = 1f;
				_arrTextObject[num].animation.wrapMode = WrapMode.Loop;
				_arrTextObject[num].animation.Play(text);
				return;
			}
		}
	}
}
