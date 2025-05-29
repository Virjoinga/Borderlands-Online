using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;
using A;
using BHV;
using BHV_Anim;
using Core;
using UnityEngine;

public class AnimationManagerFSM : AnimationManager, IPrefabManagerXmlGenericSetup
{
	public delegate void OnAnimEventHandler();

	public Dictionary<string, OnAnimEventHandler> m_animEventHandlerList = new Dictionary<string, OnAnimEventHandler>();

	[HideInInspector]
	public GameObject m_animationHost;

	private Animator m_animator;

	[HideInInspector]
	public BaseEventTriggerCtl m_AudioCtl;

	[HideInInspector]
	public c0f3c1d262ce52808e3809fe84e7b77f8 m_animationStateMachine = new c0f3c1d262ce52808e3809fe84e7b77f8();

	[HideInInspector]
	public c0f3c1d262ce52808e3809fe84e7b77f8 m_upperBodyStateMachine;

	[HideInInspector]
	public AnimationStateFSM m_fullBodyNextState = AnimationStateFSM.Invalid;

	[HideInInspector]
	public AnimationStateFSM m_upperBodyNextState = AnimationStateFSM.Invalid;

	[HideInInspector]
	public c0f3c1d262ce52808e3809fe84e7b77f8 m_additiveStateMachine = new c0f3c1d262ce52808e3809fe84e7b77f8();

	private BHVStressLevel m_stressLevel = BHVStressLevel.INVALID;

	public MovementSync m_movementSync;

	public bool m_disableMovementAnimation;

	protected float m_modelScale = 1f;

	protected int m_maxFrameNumberPerAnimation = 1000;

	public Entity m_entity;

	private Transform m_displayTransform;

	private float m_lookAroundDuration;

	private bool m_isFacingDifferentFromMovement;

	private float m_angleBetweenFacingAndMovement;

	private bool m_canUseRootMotion;

	protected bool m_canUseRootMotionPrevious;

	public BHVAnimationManagerSetup m_setup;

	[HideInInspector]
	public DamageType m_damageType;

	[HideInInspector]
	public int m_iDeathAnimIndex;

	public AnimationEventController m_animationEventController;

	public Transform m_weaponHolder;

	public bool m_hasWeapon;

	public bool m_isHumanoid;

	[HideInInspector]
	public List<Transform> m_rigidbodyTransforms;

	protected List<Vector3> m_rigidbodyVelocity;

	public bool m_canUseFacingLogic;

	[HideInInspector]
	public bool m_bPlayNormalDeathAnim;

	public bool m_validateNextMovePosition = true;

	public VFXManager m_VFXManager;

	public int m_deathLayer = 3;

	protected Skeleton m_skeleton;

	public Animator ccaaf181e61e5f9e050ba82237ed111a2
	{
		get
		{
			return m_animator;
		}
		set
		{
			m_animator = value;
		}
	}

	public BHVStressLevel cc2c8af567962955d6c13e1bff99b395d
	{
		get
		{
			return m_stressLevel;
		}
		set
		{
			m_stressLevel = value;
		}
	}

	public Transform c915fd0f71703e34ea30c40c33035a630
	{
		get
		{
			return m_displayTransform;
		}
		private set
		{
			m_displayTransform = value;
		}
	}

	public float c86ef0d58721d467a4926e4d03627be8d
	{
		get
		{
			return m_lookAroundDuration;
		}
		set
		{
			m_lookAroundDuration = value;
		}
	}

	public bool c84d33ddfa4e085e39ae42f40e2ba6952
	{
		get
		{
			return m_isFacingDifferentFromMovement;
		}
		set
		{
			m_isFacingDifferentFromMovement = value;
		}
	}

	public float c5a566dbd0e781356afaeb0774ab2f0b1
	{
		get
		{
			return m_angleBetweenFacingAndMovement;
		}
		set
		{
			m_angleBetweenFacingAndMovement = value;
		}
	}

	public bool c4004fed08fd0ad52f8c3b650da10e9cb
	{
		get
		{
			return m_canUseRootMotion;
		}
		set
		{
			m_canUseRootMotion = value;
		}
	}

	public virtual bool ceb70887701f0c688b6ddc239066fdda5(string ce6be564ae39a9af3aff0a170d981d7b6)
	{
		if (string.IsNullOrEmpty(ce6be564ae39a9af3aff0a170d981d7b6))
		{
			while (true)
			{
				switch (4)
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
		try
		{
			StringReader stringReader = new StringReader(ce6be564ae39a9af3aff0a170d981d7b6);
			try
			{
				XmlSerializer xmlSerializer = new XmlSerializer(Type.GetTypeFromHandle(c36e3e023af707323655c1243da28d687.cc1720d05c75832f704b87474932341c3()));
				m_setup = xmlSerializer.Deserialize(stringReader) as BHVAnimationManagerSetup;
			}
			finally
			{
				if (stringReader != null)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						((IDisposable)stringReader).Dispose();
						break;
					}
				}
			}
		}
		catch (Exception ex)
		{
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, "Invalid Animation Manager Settings:" + ex.Message);
			return false;
		}
		for (int i = 0; i < m_setup.m_animationStateList.Length; i++)
		{
			string text = m_setup.m_animationStateList[i];
			if (c0863e4c849711eed38a60fb8e7267a47(text, m_animationStateMachine))
			{
				continue;
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Animation, "Could not add State:" + text);
				return false;
			}
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			if (m_setup.m_animationUpperBodyStateList != null)
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
				m_upperBodyStateMachine = new c0f3c1d262ce52808e3809fe84e7b77f8();
				for (int j = 0; j < m_setup.m_animationUpperBodyStateList.Length; j++)
				{
					string text2 = m_setup.m_animationUpperBodyStateList[j];
					if (c0863e4c849711eed38a60fb8e7267a47(text2, m_upperBodyStateMachine))
					{
						continue;
					}
					while (true)
					{
						switch (2)
						{
						case 0:
							continue;
						}
						DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Animation, "Could not add Upper Body State:" + text2);
						return false;
					}
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			return true;
		}
	}

	public AnimationStatus c388d41f72ca44e2a282caa5bc1558d3c(AnimationStateFSM c55e87a729aee70f0b2a783c7007f2dc3)
	{
		ce972fd150f340044b329bd2758a9cacc value = cde2bf372eeaf659ec9aa9ec29a6d1191.c7088de59e49f7108f520cf7e0bae167e;
		if (m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.TryGetValue(Utils.ccafcaf40248e9bbb1784d38d8b267eae(c55e87a729aee70f0b2a783c7007f2dc3), out value))
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return (value as AnimationManagerState).m_status;
				}
			}
		}
		if (m_upperBodyStateMachine != null)
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
			if (m_upperBodyStateMachine.cf72e8322082a011ac716a52a275711ac.TryGetValue(Utils.ccafcaf40248e9bbb1784d38d8b267eae(c55e87a729aee70f0b2a783c7007f2dc3), out value))
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						return (value as AnimationManagerState).m_status;
					}
				}
			}
		}
		return AnimationStatus.INVALID;
	}

	public virtual void c49a0d4c35c57d927e2af7b37aaf3d99b(AudioEventName cd99af21e22e356018b8f72d4a7e4872a)
	{
	}

	public virtual void cce25835105f4aac362f76d814881a1e8()
	{
	}

	public virtual void ca3581834a9207956f6744b50728ca55d()
	{
		if (m_rigidbodyTransforms == null)
		{
			while (true)
			{
				switch (3)
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
			m_rigidbodyTransforms = new List<Transform>();
		}
		else
		{
			m_rigidbodyTransforms.Clear();
		}
		Transform[] componentsInChildren = base.gameObject.transform.GetComponentsInChildren<Transform>();
		int num = componentsInChildren.Length;
		for (int i = 0; i < num; i++)
		{
			Transform transform = componentsInChildren[i];
			if (componentsInChildren[i] == base.transform)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
				continue;
			}
			if (transform.gameObject.name == "displayObj")
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
				m_displayTransform = transform;
			}
			if (transform.rigidbody != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (m_rigidbodyTransforms == null)
				{
					continue;
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				m_rigidbodyTransforms.Add(transform);
			}
			else
			{
				if (string.IsNullOrEmpty(m_setup.m_settings.m_weaponHolderName))
				{
					continue;
				}
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!(transform.gameObject.name == m_setup.m_settings.m_weaponHolderName))
				{
					continue;
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				m_weaponHolder = transform;
				m_hasWeapon = true;
			}
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			if (m_rigidbodyVelocity == null)
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
				m_rigidbodyVelocity = new List<Vector3>();
			}
			else
			{
				m_rigidbodyVelocity.Clear();
			}
			for (int j = 0; j < m_rigidbodyTransforms.Count; j++)
			{
				m_rigidbodyVelocity.Add(Vector3.zero);
			}
			while (true)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				c33f9c3a5a9687f3762dcd02c6dd2d0e2(m_rigidbodyTransforms, m_rigidbodyVelocity, RagdollOperationType.Disable);
				return;
			}
		}
	}

	public virtual void cfad7b897be050bfdbda2828a48ed8767(GameObject c71d5b01920f18d25ff230dd1573651cd)
	{
		m_animationHost = c71d5b01920f18d25ff230dd1573651cd;
		m_animator = m_animationHost.GetComponent<Animator>();
		if (m_animator != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			for (int i = 0; i < m_animator.layerCount; i++)
			{
				m_animator.SetLayerWeight(i, 1f);
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
		}
		m_modelScale = m_animationHost.transform.localScale.x;
		m_VFXManager = m_animationHost.GetComponent<VFXManager>();
		ca3581834a9207956f6744b50728ca55d();
	}

	public void c33f9c3a5a9687f3762dcd02c6dd2d0e2(List<Transform> cb0a58ee396f6a7fb3cc244b10ef1cda1, List<Vector3> c36acdb8cfd68544c9fada737eb882e10, RagdollOperationType ca93fd88c521924517395e258b92b5099)
	{
		if (cb0a58ee396f6a7fb3cc244b10ef1cda1 == null)
		{
			return;
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (c36acdb8cfd68544c9fada737eb882e10 == null)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			int count = cb0a58ee396f6a7fb3cc244b10ef1cda1.Count;
			if (count <= 0)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
			for (int i = 0; i < count; i++)
			{
				if (ca93fd88c521924517395e258b92b5099 == RagdollOperationType.Disable)
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
					if ((bool)cb0a58ee396f6a7fb3cc244b10ef1cda1[i].rigidbody)
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
						cb0a58ee396f6a7fb3cc244b10ef1cda1[i].rigidbody.isKinematic = true;
						cb0a58ee396f6a7fb3cc244b10ef1cda1[i].rigidbody.useGravity = false;
					}
					if (!cb0a58ee396f6a7fb3cc244b10ef1cda1[i].collider)
					{
						continue;
					}
					while (true)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						break;
					}
					cb0a58ee396f6a7fb3cc244b10ef1cda1[i].collider.enabled = false;
					continue;
				}
				if (ca93fd88c521924517395e258b92b5099 == RagdollOperationType.Enable)
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
					if ((bool)cb0a58ee396f6a7fb3cc244b10ef1cda1[i].rigidbody)
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
						cb0a58ee396f6a7fb3cc244b10ef1cda1[i].rigidbody.isKinematic = false;
						cb0a58ee396f6a7fb3cc244b10ef1cda1[i].rigidbody.useGravity = true;
					}
					if (!cb0a58ee396f6a7fb3cc244b10ef1cda1[i].collider)
					{
						continue;
					}
					while (true)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						break;
					}
					cb0a58ee396f6a7fb3cc244b10ef1cda1[i].collider.enabled = true;
					continue;
				}
				if (ca93fd88c521924517395e258b92b5099 == RagdollOperationType.Save_Position)
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
					c36acdb8cfd68544c9fada737eb882e10[i] = cb0a58ee396f6a7fb3cc244b10ef1cda1[i].position;
					continue;
				}
				if (ca93fd88c521924517395e258b92b5099 == RagdollOperationType.Compute_Velocity)
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
					cb0a58ee396f6a7fb3cc244b10ef1cda1[i].rigidbody.velocity = (cb0a58ee396f6a7fb3cc244b10ef1cda1[i].position - c36acdb8cfd68544c9fada737eb882e10[i]) / Time.deltaTime;
					continue;
				}
				if (ca93fd88c521924517395e258b92b5099 == RagdollOperationType.SetRagdollLayer)
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						break;
					}
					cb0a58ee396f6a7fb3cc244b10ef1cda1[i].gameObject.layer = LayerMask.NameToLayer("Ragdoll");
					continue;
				}
				if (ca93fd88c521924517395e258b92b5099 != RagdollOperationType.SetDefaultLayer)
				{
					continue;
				}
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
				cb0a58ee396f6a7fb3cc244b10ef1cda1[i].gameObject.layer = LayerMask.NameToLayer("Default");
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					return;
				}
			}
		}
	}

	public void c33f9c3a5a9687f3762dcd02c6dd2d0e2(RagdollOperationType ca93fd88c521924517395e258b92b5099)
	{
		c33f9c3a5a9687f3762dcd02c6dd2d0e2(m_rigidbodyTransforms, m_rigidbodyVelocity, ca93fd88c521924517395e258b92b5099);
	}

	public void c9620207019eec58f6f3d1178159e1111(bool c0554c6a9d15e88bbf1c3f5bf6be967aa)
	{
		m_entity.c63f8f07320313ddc4213cb59ee025962().c2fd255ea5510abf5ead6b84fa91ea6d5(false);
	}

	public void c4a1d8f8e343e7a26a8fe838554a74d19()
	{
		if (!(m_animator != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
		{
			return;
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			MecanimEventEmitter component = m_animator.GetComponent<MecanimEventEmitter>();
			if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
				UnityEngine.Object.DestroyImmediate(component);
			}
			UnityEngine.Object.DestroyImmediate(m_animator);
			return;
		}
	}

	public void c2351b5168c48a14c25a733a532f9a41e(bool c38daa1ecfc4be57f0bab6f15b4488ecc)
	{
		if (!(m_animator != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
		{
			return;
		}
		while (true)
		{
			switch (5)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			MecanimEventEmitter component = m_animator.GetComponent<MecanimEventEmitter>();
			if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				component.enabled = c38daa1ecfc4be57f0bab6f15b4488ecc;
			}
			m_animator.enabled = c38daa1ecfc4be57f0bab6f15b4488ecc;
			return;
		}
	}

	public virtual void cdb22a9a349507be00401b4d9fc80d1bb()
	{
		if (!m_VFXManager)
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
			m_VFXManager.cb6ddb86ff592b855d40e4b6baac609bf();
			return;
		}
	}

	public virtual void Start()
	{
		m_entity = GetComponent<Entity>();
		m_skeleton = GetComponentInChildren<Skeleton>();
		m_AudioCtl = GetComponentInChildren<BaseEventTriggerCtl>();
		m_validateNextMovePosition = true;
		ca3581834a9207956f6744b50728ca55d();
		c82680016189694aae7ffda7f93e20c78(m_setup.m_settings.m_animationSpeedFactor * m_entity.c51d604728b9ec2e83a3f2783582757e9());
		m_animator.logWarnings = false;
		for (int i = 0; i < ccaaf181e61e5f9e050ba82237ed111a2.layerCount; i++)
		{
			ccaaf181e61e5f9e050ba82237ed111a2.SetLayerWeight(i, 1f);
		}
		while (true)
		{
			switch (2)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_bPlayNormalDeathAnim = false;
			m_iDeathAnimIndex = 0;
			m_deathLayer = 3;
			m_movementSync = GetComponent<MovementSync>();
			if (m_additiveStateMachine == null)
			{
				return;
			}
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				c0863e4c849711eed38a60fb8e7267a47("LightHurt", m_additiveStateMachine);
				return;
			}
		}
	}

	public void c38e22188b18e8482a7c7b657c0db7eaf()
	{
		if (!(ccaaf181e61e5f9e050ba82237ed111a2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			ccaaf181e61e5f9e050ba82237ed111a2.speed = m_setup.m_settings.m_animationSpeedFactor * m_entity.c51d604728b9ec2e83a3f2783582757e9();
			return;
		}
	}

	public void c82680016189694aae7ffda7f93e20c78(float c2f96e9e246e73dcbfb34dd3466a52e36)
	{
		if (!(ccaaf181e61e5f9e050ba82237ed111a2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
		{
			return;
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			ccaaf181e61e5f9e050ba82237ed111a2.speed = c2f96e9e246e73dcbfb34dd3466a52e36;
			Mathf.Clamp(m_animator.speed, 0.1f, 10f);
			return;
		}
	}

	public virtual void Update()
	{
		m_animationStateMachine.Update();
		if (m_upperBodyStateMachine != null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_upperBodyStateMachine.Update();
		}
		if (m_additiveStateMachine != null)
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
			m_additiveStateMachine.Update();
		}
		if (!m_disableMovementAnimation)
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
			if (!(ccaaf181e61e5f9e050ba82237ed111a2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
			{
				return;
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				ccaaf181e61e5f9e050ba82237ed111a2.SetFloat("fMoveSpeed", 0f);
				ccaaf181e61e5f9e050ba82237ed111a2.SetBool("bMove", false);
				m_disableMovementAnimation = false;
				return;
			}
		}
	}

	public virtual void cd6f933bd268aaf1967c46349307f50eb(bool cb3e620f7e2e0ab93c5a062a93fd9a505)
	{
		if (!(m_animator != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			m_animator.applyRootMotion = cb3e620f7e2e0ab93c5a062a93fd9a505;
			return;
		}
	}

	protected virtual void FixedUpdate()
	{
	}

	public AnimationStatus c0682f58328f23f63387e2fc5249a2cba(string c368d1bcb4b5c877fda3256908849d6e6, float cc2677e8457ae923cc36d1ec213497a2a)
	{
		return c0682f58328f23f63387e2fc5249a2cba(m_animator, 0, c368d1bcb4b5c877fda3256908849d6e6, cc2677e8457ae923cc36d1ec213497a2a);
	}

	public AnimationStatus c0682f58328f23f63387e2fc5249a2cba(Animator cef259c7b790a51a5c0df46c8afec8439, int c5e08b87896fbbb40d17a3a54c8c33b79, string c368d1bcb4b5c877fda3256908849d6e6, float cc2677e8457ae923cc36d1ec213497a2a)
	{
		if (cef259c7b790a51a5c0df46c8afec8439 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return AnimationStatus.INVALID;
				}
			}
		}
		if (c5e08b87896fbbb40d17a3a54c8c33b79 >= 0)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				break;
			}
			if (c5e08b87896fbbb40d17a3a54c8c33b79 < cef259c7b790a51a5c0df46c8afec8439.layerCount)
			{
				if (string.IsNullOrEmpty(c368d1bcb4b5c877fda3256908849d6e6))
				{
					while (true)
					{
						switch (4)
						{
						case 0:
							break;
						default:
							return AnimationStatus.INVALID;
						}
					}
				}
				AnimatorStateInfo currentAnimatorStateInfo = cef259c7b790a51a5c0df46c8afec8439.GetCurrentAnimatorStateInfo(c5e08b87896fbbb40d17a3a54c8c33b79);
				if (currentAnimatorStateInfo.IsTag(c368d1bcb4b5c877fda3256908849d6e6))
				{
					while (true)
					{
						switch (5)
						{
						case 0:
							break;
						default:
						{
							float normalizedTime = currentAnimatorStateInfo.normalizedTime;
							if (normalizedTime >= cc2677e8457ae923cc36d1ec213497a2a)
							{
								while (true)
								{
									switch (4)
									{
									case 0:
										break;
									default:
										return AnimationStatus.SUCCESS;
									}
								}
							}
							return AnimationStatus.RUNNING;
						}
						}
					}
				}
				return AnimationStatus.INVALID;
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
		}
		return AnimationStatus.INVALID;
	}

	public void c64dc51f788493a1a9e7999e9e2317ddf(string cf9e4ee4aad0dfef345efeacc8e9c1232)
	{
		m_animationStateMachine.c64dc51f788493a1a9e7999e9e2317ddf(cf9e4ee4aad0dfef345efeacc8e9c1232);
	}

	public void c3d651aa95fd9820e9e2c328cc63e13e9(string c340cda5237492158a3158af7966d79b1, c0f3c1d262ce52808e3809fe84e7b77f8 cca1b4b7631bb90d88a39c0dc76744753)
	{
		cca1b4b7631bb90d88a39c0dc76744753.c3d651aa95fd9820e9e2c328cc63e13e9(c340cda5237492158a3158af7966d79b1);
	}

	public virtual void c04434b88d73eff2d8d910a75dbc1c5f2(AnimationStateFSM cf9e4ee4aad0dfef345efeacc8e9c1232)
	{
		string text = Utils.ccafcaf40248e9bbb1784d38d8b267eae(cf9e4ee4aad0dfef345efeacc8e9c1232);
		if (m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.ContainsKey(text))
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					m_fullBodyNextState = cf9e4ee4aad0dfef345efeacc8e9c1232;
					c3d651aa95fd9820e9e2c328cc63e13e9(text, m_animationStateMachine);
					return;
				}
			}
		}
		if (m_upperBodyStateMachine != null)
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
			if (m_upperBodyStateMachine.cf72e8322082a011ac716a52a275711ac.ContainsKey(text))
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						m_upperBodyNextState = cf9e4ee4aad0dfef345efeacc8e9c1232;
						c3d651aa95fd9820e9e2c328cc63e13e9(text, m_upperBodyStateMachine);
						return;
					}
				}
			}
		}
		if (m_additiveStateMachine == null)
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
			if (!m_additiveStateMachine.cf72e8322082a011ac716a52a275711ac.ContainsKey(text))
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
				c3d651aa95fd9820e9e2c328cc63e13e9(text, m_additiveStateMachine);
				return;
			}
		}
	}

	public bool ccbc3718dd3d0e1356fa98d45c46d48ea(string ce7431eb8cf0921edde84fddbb6379357)
	{
		return m_animationStateMachine.ccbc3718dd3d0e1356fa98d45c46d48ea(ce7431eb8cf0921edde84fddbb6379357);
	}

	public bool ccbc3718dd3d0e1356fa98d45c46d48ea(AnimationStateFSM cf9e4ee4aad0dfef345efeacc8e9c1232)
	{
		return ccbc3718dd3d0e1356fa98d45c46d48ea(c059bb29245b8e57e3b793798ddfdb249(Utils.ccafcaf40248e9bbb1784d38d8b267eae(cf9e4ee4aad0dfef345efeacc8e9c1232)));
	}

	public bool ccbc3718dd3d0e1356fa98d45c46d48ea(ce972fd150f340044b329bd2758a9cacc c12da452506697be78f3c915040b65dd8)
	{
		bool flag = m_animationStateMachine.ccbc3718dd3d0e1356fa98d45c46d48ea(c12da452506697be78f3c915040b65dd8);
		if (m_upperBodyStateMachine != null)
		{
			while (true)
			{
				int result;
				switch (6)
				{
				case 0:
					break;
				default:
					{
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						if (!flag)
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
							if (!m_upperBodyStateMachine.ccbc3718dd3d0e1356fa98d45c46d48ea(c12da452506697be78f3c915040b65dd8))
							{
								while (true)
								{
									switch (2)
									{
									case 0:
										continue;
									}
									break;
								}
								result = (m_additiveStateMachine.ccbc3718dd3d0e1356fa98d45c46d48ea(c12da452506697be78f3c915040b65dd8) ? 1 : 0);
								goto IL_0062;
							}
						}
						result = 1;
						goto IL_0062;
					}
					IL_0062:
					return (byte)result != 0;
				}
			}
		}
		return flag;
	}

	public bool c0863e4c849711eed38a60fb8e7267a47(string cf9e4ee4aad0dfef345efeacc8e9c1232, c0f3c1d262ce52808e3809fe84e7b77f8 cca1b4b7631bb90d88a39c0dc76744753)
	{
		AnimationManagerState c7088de59e49f7108f520cf7e0bae167e = c698b86bbc81d1867419347836c25ccea.c7088de59e49f7108f520cf7e0bae167e;
		try
		{
			string key = "Animation" + cf9e4ee4aad0dfef345efeacc8e9c1232 + "State";
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			Type type = executingAssembly.GetType(key);
			c7088de59e49f7108f520cf7e0bae167e = (AnimationManagerState)Activator.CreateInstance(type);
			c7088de59e49f7108f520cf7e0bae167e.ccc9d3a38966dc10fedb531ea17d24611(this);
			if (c7088de59e49f7108f520cf7e0bae167e == null)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return false;
				}
			}
			if (!cca1b4b7631bb90d88a39c0dc76744753.cf72e8322082a011ac716a52a275711ac.ContainsKey(key))
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						cca1b4b7631bb90d88a39c0dc76744753.cf72e8322082a011ac716a52a275711ac.Add(cf9e4ee4aad0dfef345efeacc8e9c1232, c7088de59e49f7108f520cf7e0bae167e);
						c7088de59e49f7108f520cf7e0bae167e.ce4bf9718485f72643b662cd66d5c4e8e(cca1b4b7631bb90d88a39c0dc76744753, cf9e4ee4aad0dfef345efeacc8e9c1232);
						return true;
					}
				}
			}
		}
		catch (Exception ex)
		{
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.AI, ex.ToString());
		}
		return false;
	}

	public AnimationManagerState c059bb29245b8e57e3b793798ddfdb249(string cf9e4ee4aad0dfef345efeacc8e9c1232)
	{
		if (m_animationStateMachine != null)
		{
			while (true)
			{
				switch (3)
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
			if (m_animationStateMachine.cf72e8322082a011ac716a52a275711ac.ContainsKey(cf9e4ee4aad0dfef345efeacc8e9c1232))
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						return m_animationStateMachine.cf72e8322082a011ac716a52a275711ac[cf9e4ee4aad0dfef345efeacc8e9c1232] as AnimationManagerState;
					}
				}
			}
		}
		if (m_upperBodyStateMachine != null)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				break;
			}
			if (m_upperBodyStateMachine.cf72e8322082a011ac716a52a275711ac.ContainsKey(cf9e4ee4aad0dfef345efeacc8e9c1232))
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						return m_upperBodyStateMachine.cf72e8322082a011ac716a52a275711ac[cf9e4ee4aad0dfef345efeacc8e9c1232] as AnimationManagerState;
					}
				}
			}
		}
		if (m_additiveStateMachine != null)
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
			if (m_additiveStateMachine.cf72e8322082a011ac716a52a275711ac.ContainsKey(cf9e4ee4aad0dfef345efeacc8e9c1232))
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						return m_additiveStateMachine.cf72e8322082a011ac716a52a275711ac[cf9e4ee4aad0dfef345efeacc8e9c1232] as AnimationManagerState;
					}
				}
			}
		}
		return null;
	}

	public virtual int c43e01190c713db1f8a78d1529ae2d2ed(string cb6ecce17c4a10cf4ade445feb45a0355)
	{
		return 0;
	}

	public override string ToString()
	{
		if (m_animator == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return null;
				}
			}
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("AnimManager rootMotion " + m_canUseRootMotionPrevious);
		if (m_animationStateMachine != null)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				break;
			}
			if (m_animationStateMachine.m_curState != null)
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
				AnimationManagerState animationManagerState = m_animationStateMachine.m_curState as AnimationManagerState;
				if (animationManagerState != null)
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
					stringBuilder.AppendLine(" " + c3b324704566b0779bfa19c201c85bef9(animationManagerState) + ": " + animationManagerState.m_status);
				}
			}
		}
		if (m_upperBodyStateMachine != null)
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
			if (m_upperBodyStateMachine.m_curState != null)
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
				AnimationManagerState animationManagerState2 = m_upperBodyStateMachine.m_curState as AnimationManagerState;
				if (animationManagerState2 != null)
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						break;
					}
					stringBuilder.AppendLine(" " + c3b324704566b0779bfa19c201c85bef9(animationManagerState2) + ": " + animationManagerState2.m_status);
				}
			}
		}
		if (m_additiveStateMachine != null)
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
			if (m_additiveStateMachine.m_curState != null)
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
				AnimationManagerState animationManagerState3 = m_additiveStateMachine.m_curState as AnimationManagerState;
				if (animationManagerState3 != null)
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
					stringBuilder.AppendLine(" " + c3b324704566b0779bfa19c201c85bef9(animationManagerState3) + ": " + animationManagerState3.m_status);
				}
			}
		}
		stringBuilder.AppendLine("Clips");
		for (int i = 0; i < m_animator.layerCount; i++)
		{
			AnimationInfo[] currentAnimationClipState = m_animator.GetCurrentAnimationClipState(i);
			for (int j = 0; j < currentAnimationClipState.Length; j++)
			{
				AnimationInfo animationInfo = currentAnimationClipState[j];
				if (!(animationInfo.clip != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
				{
					continue;
				}
				while (true)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
				if (string.IsNullOrEmpty(animationInfo.clip.name))
				{
					continue;
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!(animationInfo.weight > 0f))
				{
					continue;
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				object[] array = c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(4);
				array[0] = " ";
				array[1] = animationInfo.clip.name;
				array[2] = ": ";
				array[3] = animationInfo.weight;
				stringBuilder.AppendLine(string.Concat(array));
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					goto end_IL_02db;
				}
				continue;
				end_IL_02db:
				break;
			}
		}
		while (true)
		{
			switch (3)
			{
			case 0:
				continue;
			}
			return stringBuilder.ToString();
		}
	}

	private string c3b324704566b0779bfa19c201c85bef9(AnimationManagerState ca894d0713dbf31f80cf26b2d0b1b24ab)
	{
		if (ca894d0713dbf31f80cf26b2d0b1b24ab == null)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return null;
				}
			}
		}
		string text = ca894d0713dbf31f80cf26b2d0b1b24ab.GetType().Name;
		if (string.IsNullOrEmpty(text))
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					return null;
				}
			}
		}
		return text.Replace("Animation", string.Empty).Replace("State", string.Empty);
	}

	public void cb082f0bd0e14bac93e6ee86bb882c71d(ENPCParticleType c2b4f43f34e21572af6ab4414f04cee36, Transform c2651896b265273fbec506b1fb5f97c6e)
	{
		if (m_VFXManager == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return;
				}
			}
		}
		m_VFXManager.c930218e437c0501ced1553e08dab14d9(c2b4f43f34e21572af6ab4414f04cee36, c2651896b265273fbec506b1fb5f97c6e);
	}

	public virtual GameObject caa7c42ac554726b9f073f5a59404e5b5()
	{
		return null;
	}

	public virtual GameObject c8f822dae060543cd85b9b5aa16f48436(int cf304be0caeadea8eea88f52d32c75728)
	{
		return null;
	}

	public virtual void cd295c889c81e8823ba501a609b868079(bool c909dc6005555f2098b85680918806864)
	{
	}

	public virtual bool c39997c2d57776ba3c104737021557daf()
	{
		return false;
	}

	public virtual void OnDeath()
	{
	}

	public void TriggerAnimationEventMecanim(string eventName)
	{
		if (!m_animEventHandlerList.ContainsKey(eventName))
		{
			return;
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_animEventHandlerList[eventName]();
			return;
		}
	}
}
