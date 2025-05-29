using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using A;
using BHV;
using Core;
using UnityEngine;

public class BHVTaskManager : MonoBehaviour, IPrefabManagerXmlGenericSetup, IPhotonSerializeView
{
	private List<NetworkTaskStruct> m_networkBHVTaskList = new List<NetworkTaskStruct>();

	public BHVTaskManagerSetup m_setup;

	public BHVTaskManagerLayer[] m_layers;

	private int m_UIDCounter = -1;

	public BHVTaskActionParameters m_actionParameters = new BHVTaskActionParameters();

	public Dictionary<BHVTaskType, BHVTask> m_tasksLUT = new Dictionary<BHVTaskType, BHVTask>();

	public Dictionary<Type, BHVTaskSettings> m_settingsLUT;

	public int m_layerMask;

	public uint m_npcSubTypeHashCode;

	private MovementSync m_movement;

	private BHVTaskParamSync m_synchedParams = new BHVTaskParamSync();

	private BHVNavAgentSettings m_navAgentSettings;

	private BHVFireStyleSettings m_fireStyleSettings;

	private float m_passiveSkillSpeedModifier = 1f;

	public Entity m_entity { get; private set; }

	public AnimationManagerFSM m_animationManagerFSM { get; private set; }

	public NavMeshAgent m_navAgent { get; private set; }

	public virtual c272566d4edbf24bb8c4df6114a524ac9 cd3d8b35d2647005675ba92178c253805<c272566d4edbf24bb8c4df6114a524ac9>() where c272566d4edbf24bb8c4df6114a524ac9 : BHVTaskSettings
	{
		BHVTaskSettings value = cdc057a60b51fd80ad9a616e7bae09d22.c7088de59e49f7108f520cf7e0bae167e;
		m_settingsLUT.TryGetValue(typeof(c272566d4edbf24bb8c4df6114a524ac9), out value);
		return (c272566d4edbf24bb8c4df6114a524ac9)value;
	}

	public void cf9771eedb50d648414be8bcc9dac9bdc(BHVTaskLayer cbd55f21508704fe28527094b2adc77da)
	{
		m_layerMask |= 1 << (int)cbd55f21508704fe28527094b2adc77da;
	}

	public bool c41b1480f6c3fc4a99f2855c216e98ac6(BHVTaskLayer cbd55f21508704fe28527094b2adc77da)
	{
		return (m_layerMask & (1 << (int)cbd55f21508704fe28527094b2adc77da)) != 0;
	}

	public bool c297256866c0e59bcea3eaca6845d7a9a(EntityNpc.EntitySubType c22a75c71fa78ee19ac7d9915d41a0c01)
	{
		return true;
	}

	public void c6bb3d8c3bbcf29724a8c3bebc37fb458(EntityNpc.EntitySubType c22a75c71fa78ee19ac7d9915d41a0c01)
	{
		m_npcSubTypeHashCode = Utility.cf642a65627df2adf4e90330457651907(c22a75c71fa78ee19ac7d9915d41a0c01.ToString());
		if (!AIServiceSetting.c5ee19dc8d4cccf5ae2de225410458b86.m_settingList.TryGetValue(m_npcSubTypeHashCode, out m_settingsLUT))
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.AI, "Not find setting for " + c22a75c71fa78ee19ac7d9915d41a0c01);
		}
		AIServiceSetting.c5ee19dc8d4cccf5ae2de225410458b86.cf2f713d2eb507941299440866f1f376e(c22a75c71fa78ee19ac7d9915d41a0c01, m_tasksLUT);
		c242f2b67bf790f7ac406dd73571fe646();
		if (m_entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_entity = GetComponent<Entity>();
		}
		if (m_animationManagerFSM == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (m_entity.c6420f67f9249b1d533531d9f351a36e0() == Entity.EntityType.Npc)
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
				m_animationManagerFSM = GetComponent<AnimationManagerFSM>();
			}
			else if (m_entity.c6420f67f9249b1d533531d9f351a36e0() == Entity.EntityType.Player)
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
				m_animationManagerFSM = GetComponent<PlayerThirdPersonAnimationManagerFSM>();
			}
		}
		m_movement = m_entity.GetComponent<MovementSync>();
	}

	public bool ceb70887701f0c688b6ddc239066fdda5(string ce6be564ae39a9af3aff0a170d981d7b6)
	{
		if (string.IsNullOrEmpty(ce6be564ae39a9af3aff0a170d981d7b6))
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
					return false;
				}
			}
		}
		Entity component = GetComponent<Entity>();
		if (component is EntityNpc)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					return true;
				}
			}
		}
		StringReader textReader = new StringReader(ce6be564ae39a9af3aff0a170d981d7b6);
		m_setup = AIServiceSetting.c5ee19dc8d4cccf5ae2de225410458b86.m_taskSerializer.Deserialize(textReader) as BHVTaskManagerSetup;
		if (m_setup == null)
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Gamelogic, "Invalid Task Manager Settings:");
					return false;
				}
			}
		}
		m_setup.c088702f4b6cd07e179f719732c55051f();
		component.ce7325a1f0410a6d170ae58fce0f0ae7f(m_tasksLUT);
		m_settingsLUT = m_setup.cdc9012cd21aba43c660d610ebd1b159e;
		c242f2b67bf790f7ac406dd73571fe646();
		return true;
	}

	private void OnSpawnCompleted()
	{
		if (!base.enabled)
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
					return;
				}
			}
		}
		if (m_entity == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_entity = GetComponent<Entity>();
		}
		if (m_animationManagerFSM == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (m_entity.c6420f67f9249b1d533531d9f351a36e0() == Entity.EntityType.Npc)
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
				m_animationManagerFSM = GetComponent<AnimationManagerFSM>();
			}
			else if (m_entity.c6420f67f9249b1d533531d9f351a36e0() == Entity.EntityType.Player)
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
				m_animationManagerFSM = GetComponent<PlayerThirdPersonAnimationManagerFSM>();
			}
		}
		m_movement = m_entity.GetComponent<MovementSync>();
		m_navAgent = c89a66e17b6418582a7562f2b47a584aa.c7088de59e49f7108f520cf7e0bae167e;
	}

	public void c242f2b67bf790f7ac406dd73571fe646()
	{
		cf9771eedb50d648414be8bcc9dac9bdc(BHVTaskLayer.FULLBODY);
		cf9771eedb50d648414be8bcc9dac9bdc(BHVTaskLayer.TOPBODY);
		cf9771eedb50d648414be8bcc9dac9bdc(BHVTaskLayer.ADDITIVE);
		cf9771eedb50d648414be8bcc9dac9bdc(BHVTaskLayer.EFFECT);
		m_layers = ca524d59af1a3ad2725c60068e564a6a5.c0a0cdf4a196914163f7334d9b0781a04(4);
		for (int i = 0; i < m_layers.Length; i++)
		{
			if (c41b1480f6c3fc4a99f2855c216e98ac6((BHVTaskLayer)i))
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				m_layers[i] = new BHVTaskManagerLayer();
			}
			else
			{
				m_layers[i] = null;
			}
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	public int c954046389d340a6261e638dd2a1a7e32()
	{
		m_UIDCounter++;
		if (m_UIDCounter >= 126)
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
			m_UIDCounter = 0;
		}
		return m_UIDCounter;
	}

	public BHVTaskManagerResult Awake()
	{
		return BHVTaskManagerResult.SUCCESS;
	}

	public BHVTaskManagerResult Start()
	{
		BHVTaskManagerResult result = BHVTaskManagerResult.SUCCESS;
		m_navAgentSettings = cd3d8b35d2647005675ba92178c253805<BHVNavAgentSettings>();
		m_fireStyleSettings = cd3d8b35d2647005675ba92178c253805<BHVFireStyleSettings>();
		m_passiveSkillSpeedModifier = m_entity.c51d604728b9ec2e83a3f2783582757e9();
		return result;
	}

	public void Update()
	{
		if (!c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8266bc69cb6d3069bbd1b800662e5dbd())
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
					return;
				}
			}
		}
		if (m_movement != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			int count = m_networkBHVTaskList.Count;
			for (int num = count - 1; num >= 0; num--)
			{
				NetworkTaskStruct item = m_networkBHVTaskList[num];
				if ((double)Time.time - item.m_time > (double)m_movement.c1d076d8aaabeb171d01b8502d3217ec0)
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
					cd6aca5b3793f791cfc489609e675c90b(item.m_taskParam);
					m_networkBHVTaskList.Remove(item);
				}
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
		for (int i = 0; i < m_layers.Length; i++)
		{
			if (m_layers[i] == null)
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
			if (m_layers[i].m_currentTaskParamQueue != null)
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
				cd6cbcb4ebf27b1cb7541c506b3cc9a6a(m_layers[i].m_currentTaskParamQueue, true);
				m_layers[i].m_currentTaskParamQueue = c85f33439c924baf0c818a8ff3c1dfbc3.c7088de59e49f7108f520cf7e0bae167e;
			}
			if (m_layers[i].m_currentTask == null)
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
			m_layers[i].m_currentTask.Update(Time.deltaTime);
		}
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

	public BHVTaskManagerResult c365a77c63c91e13de4ca19c9a953aa5e()
	{
		for (int i = 0; i < m_layers.Length; i++)
		{
			if (m_layers[i] == null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (m_layers[i].m_currentTask == null)
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
			m_layers[i].m_currentTask.c496c317832865f592876a12acfff494f(true);
		}
		while (true)
		{
			switch (4)
			{
			case 0:
				continue;
			}
			return BHVTaskManagerResult.SUCCESS;
		}
	}

	public BHVTaskManagerResult cd6cbcb4ebf27b1cb7541c506b3cc9a6a(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
	{
		return cd6cbcb4ebf27b1cb7541c506b3cc9a6a(cdbade0534e8f60b8dbad77a5270d9acf, false);
	}

	private bool cda912fef78064a5bf0158b00fb1c59da(BHVTaskLayer cbd55f21508704fe28527094b2adc77da)
	{
		int result;
		if (m_layers != null)
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
			if (m_layers.Length > (int)cbd55f21508704fe28527094b2adc77da)
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
				result = ((m_layers[(int)cbd55f21508704fe28527094b2adc77da] != null) ? 1 : 0);
				goto IL_0041;
			}
		}
		result = 0;
		goto IL_0041;
		IL_0041:
		return (byte)result != 0;
	}

	public BHVTaskManagerResult cd6cbcb4ebf27b1cb7541c506b3cc9a6a(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf, bool c3da460af52d059876e658b4a52f857ee)
	{
		if (m_layers[(int)cdbade0534e8f60b8dbad77a5270d9acf.m_Layer].m_currentTask != null)
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
			if (BHVTask.cf874cd0b4372e0b1b284963141a5021c(cdbade0534e8f60b8dbad77a5270d9acf, m_layers[(int)cdbade0534e8f60b8dbad77a5270d9acf.m_Layer].m_currentTask))
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
				if (!c3da460af52d059876e658b4a52f857ee)
				{
					while (true)
					{
						switch (1)
						{
						case 0:
							break;
						default:
							return BHVTaskManagerResult.ERROR_TASK_ALREADY_RUNNING;
						}
					}
				}
			}
			m_layers[(int)cdbade0534e8f60b8dbad77a5270d9acf.m_Layer].m_currentTask.c496c317832865f592876a12acfff494f(false);
			m_layers[(int)cdbade0534e8f60b8dbad77a5270d9acf.m_Layer].m_currentTask = c2b111e746cb9c5af9c540853a9d9aa08.c7088de59e49f7108f520cf7e0bae167e;
		}
		if (cdbade0534e8f60b8dbad77a5270d9acf.c2c95b61a790880f15fa36108f89c3d5d)
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
			if (cda912fef78064a5bf0158b00fb1c59da(BHVTaskLayer.TOPBODY))
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
				if (m_layers[1].m_currentTask != null)
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
					m_layers[1].m_currentTask.c496c317832865f592876a12acfff494f(true);
					m_layers[1].m_currentTask = c2b111e746cb9c5af9c540853a9d9aa08.c7088de59e49f7108f520cf7e0bae167e;
				}
			}
		}
		m_layers[(int)cdbade0534e8f60b8dbad77a5270d9acf.m_Layer].m_currentTask = c21fdf84f556b5a8ad7ab27de58c6281d(cdbade0534e8f60b8dbad77a5270d9acf);
		if (m_layers[(int)cdbade0534e8f60b8dbad77a5270d9acf.m_Layer].m_currentTask == null)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					return BHVTaskManagerResult.ERROR_FAILED_TO_CREATE_TASK;
				}
			}
		}
		m_layers[(int)cdbade0534e8f60b8dbad77a5270d9acf.m_Layer].m_currentTask.Start();
		return BHVTaskManagerResult.SUCCESS;
	}

	public BHVTaskStatus c9a685b10bf52cc057c736c086bb850ca()
	{
		return c9a685b10bf52cc057c736c086bb850ca(BHVTaskLayer.FULLBODY);
	}

	public BHVTaskStatus c9a685b10bf52cc057c736c086bb850ca(BHVTaskLayer c6b7277151446bdab3b549e9217e86ad1)
	{
		if (m_layers[(int)c6b7277151446bdab3b549e9217e86ad1].m_currentTask != null)
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
					return m_layers[(int)c6b7277151446bdab3b549e9217e86ad1].m_currentTask.m_Status;
				}
			}
		}
		return BHVTaskStatus.INVALID;
	}

	public BHVTask c2d51f6bc5c05cfbf476c30230c67b09e()
	{
		return c2d51f6bc5c05cfbf476c30230c67b09e(BHVTaskLayer.FULLBODY);
	}

	public BHVTask c2d51f6bc5c05cfbf476c30230c67b09e(BHVTaskLayer c6b7277151446bdab3b549e9217e86ad1)
	{
		if (m_layers[(int)c6b7277151446bdab3b549e9217e86ad1].m_currentTask != null)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					return m_layers[(int)c6b7277151446bdab3b549e9217e86ad1].m_currentTask;
				}
			}
		}
		return null;
	}

	public virtual BHVTask c21fdf84f556b5a8ad7ab27de58c6281d(BHVTaskParam cdbade0534e8f60b8dbad77a5270d9acf)
	{
		BHVTask value = c2b111e746cb9c5af9c540853a9d9aa08.c7088de59e49f7108f520cf7e0bae167e;
		if (!m_tasksLUT.TryGetValue(cdbade0534e8f60b8dbad77a5270d9acf.m_Type, out value))
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.AI, cdbade0534e8f60b8dbad77a5270d9acf.m_Type.ToString() + " is not part of the possible tasks for " + m_entity.m_name);
					return null;
				}
			}
		}
		value.ccc9d3a38966dc10fedb531ea17d24611(this);
		if (!value.cd6c2cd7bb7b266ba7083ce848641dd61(cdbade0534e8f60b8dbad77a5270d9acf))
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.AI, cdbade0534e8f60b8dbad77a5270d9acf.m_Type.ToString() + " cannot set tasks parmeters for " + m_entity.m_name);
					return null;
				}
			}
		}
		return value;
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.c8b2526be2638bb30a29ab8314b369311)
		{
			while (true)
			{
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
					int num = 0;
					for (int i = 0; i < m_layers.Length; i++)
					{
						if (m_layers[i] == null)
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
						}
						else if (m_layers[i].m_currentTask == null)
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
						}
						else
						{
							num++;
						}
					}
					while (true)
					{
						switch (7)
						{
						case 0:
							break;
						default:
						{
							stream.caf7283cc5cd9725a88a9cdfa630d92f8(num);
							for (int j = 0; j < m_layers.Length; j++)
							{
								if (m_layers[j] == null)
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
								}
								else if (m_layers[j].m_currentTask == null)
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
								}
								else
								{
									m_layers[j].m_currentTask.cdf3fed1b3e2fb4370b5db53be9c44580().c21abc56059d171e999147f26bbf75889(ref m_synchedParams.cbfdd09e23f07797bcbd0a2c7c5a5c717, true);
									m_synchedParams.c21abc56059d171e999147f26bbf75889(stream);
								}
							}
							while (true)
							{
								switch (1)
								{
								case 0:
									break;
								default:
									return;
								}
							}
						}
						}
					}
				}
				}
			}
		}
		int num2 = (int)stream.cbc3e6f46d26c8fb00a98f05fc700248a();
		NetworkTaskStruct item = default(NetworkTaskStruct);
		for (int k = 0; k < num2; k++)
		{
			m_synchedParams.c21abc56059d171e999147f26bbf75889(stream);
			if (!m_synchedParams.c943bc6a18586b3e0e6f0214717aca479())
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
			BHVTask bHVTask = m_tasksLUT[m_synchedParams.cbfdd09e23f07797bcbd0a2c7c5a5c717.c9fcab9b0afd057008dc16bd60a2c543a];
			BHVTaskParam bHVTaskParam = bHVTask.cdf3fed1b3e2fb4370b5db53be9c44580();
			if (bHVTaskParam == null)
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
				bHVTaskParam = m_synchedParams.cefa2d3e106cf4ac2c9aa4706d7b89260();
				bHVTask.cd6c2cd7bb7b266ba7083ce848641dd61(bHVTaskParam);
			}
			else
			{
				if (bHVTaskParam.m_UID == m_synchedParams.cbfdd09e23f07797bcbd0a2c7c5a5c717.c98eaa1ce1a69490d1c0adebfc5365925)
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
					continue;
				}
				bHVTaskParam.c21abc56059d171e999147f26bbf75889(ref m_synchedParams.cbfdd09e23f07797bcbd0a2c7c5a5c717, false);
				bHVTaskParam.c495597d24b447ad725643e71f5a54375();
			}
			if (m_movement != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (m_movement.c1d076d8aaabeb171d01b8502d3217ec0 > 0.15f)
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
					item.m_taskParam = bHVTaskParam;
					item.m_time = Time.time;
					m_networkBHVTaskList.Add(item);
					continue;
				}
			}
			cd6aca5b3793f791cfc489609e675c90b(bHVTaskParam);
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				break;
			default:
				return;
			}
		}
	}

	private void cd6aca5b3793f791cfc489609e675c90b(BHVTaskParam c708174942947dea75149b1545756329d)
	{
		if (c708174942947dea75149b1545756329d == null)
		{
			return;
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
			m_layers[(int)c708174942947dea75149b1545756329d.m_Layer].m_currentTaskParamQueue = c708174942947dea75149b1545756329d;
			return;
		}
	}

	public bool c04ca5acd4c692e7b2a810ed8ac4deeca()
	{
		if (m_layers[0].m_currentTask != null)
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
			if (m_layers[0].m_currentTask.m_Type == BHVTaskType.Idle)
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						return true;
					}
				}
			}
		}
		return false;
	}

	public bool c3fceb6126c0a4863b41f07601abc0456()
	{
		int result;
		if (c2d51f6bc5c05cfbf476c30230c67b09e(BHVTaskLayer.FULLBODY).m_Type != BHVTaskType.MoveTo)
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
			if (c2d51f6bc5c05cfbf476c30230c67b09e(BHVTaskLayer.FULLBODY).m_Type != BHVTaskType.ChargeAttack)
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
				if (c2d51f6bc5c05cfbf476c30230c67b09e(BHVTaskLayer.FULLBODY).m_Type != BHVTaskType.JumpAttack)
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
					if (c2d51f6bc5c05cfbf476c30230c67b09e(BHVTaskLayer.FULLBODY).m_Type != BHVTaskType.Roll)
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
						result = ((c2d51f6bc5c05cfbf476c30230c67b09e(BHVTaskLayer.FULLBODY).m_Type == BHVTaskType.SlideMoveTo) ? 1 : 0);
						goto IL_0099;
					}
				}
			}
		}
		result = 1;
		goto IL_0099;
		IL_0099:
		return (byte)result != 0;
	}

	public override string ToString()
	{
		if (m_layers == null)
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
					return string.Empty;
				}
			}
		}
		StringBuilder stringBuilder = new StringBuilder("BHVTaskManager:\n");
		if (cda912fef78064a5bf0158b00fb1c59da(BHVTaskLayer.FULLBODY))
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
			if (m_layers[0].m_currentTask != null)
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
				stringBuilder.Append(m_layers[0].m_currentTask.ToString());
			}
			else
			{
				stringBuilder.Append(string.Format("    FullBody: -\n", c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0)));
			}
		}
		if (cda912fef78064a5bf0158b00fb1c59da(BHVTaskLayer.TOPBODY))
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
			if (m_layers[1].m_currentTask != null)
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
				stringBuilder.Append(m_layers[1].m_currentTask.ToString());
			}
			else
			{
				stringBuilder.Append(string.Format("    TopBody: -\n", c1c7245c803f9241d7fc0ed612dcdf524.c0a0cdf4a196914163f7334d9b0781a04(0)));
			}
		}
		return stringBuilder.ToString();
	}

	public float cdec9589c1698402d0a21ebc506ba03e9(BHVFireStyle cc07e04d5c87e30abb8b1ebd9f4f70424)
	{
		if (m_fireStyleSettings != null)
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
			switch (cc07e04d5c87e30abb8b1ebd9f4f70424)
			{
			case BHVFireStyle.BURST_SINGLE:
				return 0f;
			case BHVFireStyle.BURST_CHAINED:
				return UnityEngine.Random.Range(m_fireStyleSettings.m_burstChained_IdleTimeMin, m_fireStyleSettings.m_burstChained_IdleTimeMax);
			case BHVFireStyle.BURST_AUTO:
				return 0f;
			}
		}
		return 0f;
	}

	public float c62614a5ace3c704a56712e723a657907(BHVFireStyle cc07e04d5c87e30abb8b1ebd9f4f70424)
	{
		if (m_fireStyleSettings != null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			switch (cc07e04d5c87e30abb8b1ebd9f4f70424)
			{
			case BHVFireStyle.BURST_SINGLE:
				return UnityEngine.Random.Range(m_fireStyleSettings.m_burstSingle_FireTimeMin, m_fireStyleSettings.m_burstSingle_FireTimeMax);
			case BHVFireStyle.BURST_CHAINED:
				return UnityEngine.Random.Range(m_fireStyleSettings.m_burstChained_FireTimeMin, m_fireStyleSettings.m_burstChained_FireTimeMax);
			case BHVFireStyle.BURST_AUTO:
				return float.MaxValue;
			}
		}
		return 0f;
	}

	public float cde528db37f7946caf38a2c719cf0471e(BHVMovementSpeed c0191f0280773feacef99b482a6610638, BHVStressLevel c5da91eab262b016adb5d3b31cd0f8c08)
	{
		if (m_navAgentSettings == null)
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
			m_navAgentSettings = cd3d8b35d2647005675ba92178c253805<BHVNavAgentSettings>();
		}
		if (m_navAgentSettings == null)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					return 0f;
				}
			}
		}
		switch (c0191f0280773feacef99b482a6610638)
		{
		case BHVMovementSpeed.WALK:
		{
			float result;
			if (c5da91eab262b016adb5d3b31cd0f8c08 == BHVStressLevel.RELAX)
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
				result = m_navAgentSettings.m_walkSpeed * m_passiveSkillSpeedModifier;
			}
			else
			{
				result = m_navAgentSettings.m_walkCombatSpeed * m_passiveSkillSpeedModifier;
			}
			return result;
		}
		case BHVMovementSpeed.RUN:
			return m_navAgentSettings.m_runSpeed * m_passiveSkillSpeedModifier;
		case BHVMovementSpeed.CHARGE:
			return m_navAgentSettings.m_chargeSpeed * m_passiveSkillSpeedModifier;
		case BHVMovementSpeed.SPRINT:
			return m_navAgentSettings.m_sprintSpeed * m_passiveSkillSpeedModifier;
		case BHVMovementSpeed.JUMP:
			return m_navAgentSettings.m_jumpSpeed * m_passiveSkillSpeedModifier;
		default:
			DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.AI, "Movement Speed is invalid!");
			return 0f;
		}
	}
}
