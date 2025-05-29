using System;
using System.Diagnostics;
using A;
using UnityEngine;

public class BHVBrain : MonoBehaviour, IDamageListener, IPrefabManagerXmlGenericSetup
{
	public bool m_isDamageable = true;

	public bool m_isShowDebugFSM;

	public bool m_isShowDebugBHVTaskManager;

	public bool m_isShowDebugAnimationManager;

	public Color m_debugTextColot = Color.red;

	protected bool m_isNpc;

	protected bool m_isPlayer;

	[HideInInspector]
	public Entity m_entity { get; private set; }

	public bool ceb70887701f0c688b6ddc239066fdda5(string ce6be564ae39a9af3aff0a170d981d7b6)
	{
		return true;
	}

	private void Start()
	{
		m_entity = GetComponent<Entity>();
		if ((bool)DamageManager.c5ee19dc8d4cccf5ae2de225410458b86)
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
			if (m_isDamageable)
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
				DamageManager.c5ee19dc8d4cccf5ae2de225410458b86.c5c5b57d23b5b73637a6ed6524fed2be5(this);
			}
			else
			{
				DamageManager.c5ee19dc8d4cccf5ae2de225410458b86.cd5e20c96aa545559531f1792ec0f8b61(m_entity);
			}
		}
		int isNpc;
		if (GetComponent<EntityNpc>() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			isNpc = 1;
		}
		else
		{
			isNpc = 0;
		}
		m_isNpc = (byte)isNpc != 0;
		int isPlayer;
		if (GetComponent<EntityPlayer>() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			isPlayer = 1;
		}
		else
		{
			isPlayer = 0;
		}
		m_isPlayer = (byte)isPlayer != 0;
	}

	private void OnDestroy()
	{
		if (!DamageManager.c5ee19dc8d4cccf5ae2de225410458b86)
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
			DamageManager.c5ee19dc8d4cccf5ae2de225410458b86.c67b40caae87a37a992e8004e2229b0eb(this);
			return;
		}
	}

	private void Update()
	{
	}

	public void OnDamaged(DamageContext context)
	{
	}

	public void OnEntityKill(KillContext context)
	{
	}

	[Conditional("DEBUG")]
	private void OnGUI()
	{
		if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
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
				return;
			}
		}
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		if (c06ca0e618478c23eba3419653a19760f<DebugCamera>.c5ee19dc8d4cccf5ae2de225410458b86 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (c06ca0e618478c23eba3419653a19760f<DebugCamera>.c5ee19dc8d4cccf5ae2de225410458b86.c201e69461401637f68794a86ca99b782())
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
				flag4 = true;
				flag = c06ca0e618478c23eba3419653a19760f<DebugCamera>.c5ee19dc8d4cccf5ae2de225410458b86.m_showNPCLog;
				flag2 = false;
				flag3 = c06ca0e618478c23eba3419653a19760f<DebugCamera>.c5ee19dc8d4cccf5ae2de225410458b86.m_showPlayerLog;
			}
		}
		if (!flag)
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
			if (!m_isShowDebugFSM)
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
				if (!m_isShowDebugBHVTaskManager)
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
					if (!m_isShowDebugAnimationManager)
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
						if (!flag2)
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
							if (!flag3)
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
								if (!AIServiceUtility.c5ee19dc8d4cccf5ae2de225410458b86.m_bShowNpcHP)
								{
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
						}
					}
				}
			}
		}
		string text = string.Empty;
		if (m_isPlayer)
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
			PlayerThirdPersonAnimationManagerFSM component = GetComponent<PlayerThirdPersonAnimationManagerFSM>();
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
				int num;
				if (flag2)
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
					num = (component.m_isPlayerLocal ? 1 : 0);
				}
				else
				{
					num = 0;
				}
				flag2 = (byte)num != 0;
				int num2;
				if (flag3)
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
					num2 = ((!component.m_isPlayerLocal) ? 1 : 0);
				}
				else
				{
					num2 = 0;
				}
				flag3 = (byte)num2 != 0;
				if (!flag2)
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
					if (!flag3)
					{
						goto IL_01dd;
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
				}
				BHVTaskManager component2 = GetComponent<BHVTaskManager>();
				if (component2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					text += component2.ToString();
				}
				text += component.ToString();
			}
			goto IL_01dd;
		}
		goto IL_0250;
		IL_0250:
		if (!m_isNpc)
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
			if (!flag3)
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
				break;
			}
		}
		Camera c7088de59e49f7108f520cf7e0bae167e = c4ffee394d9d7cb3cc1237fb7e347bc29.c7088de59e49f7108f520cf7e0bae167e;
		if (flag4)
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
			if (c06ca0e618478c23eba3419653a19760f<DebugCamera>.c5ee19dc8d4cccf5ae2de225410458b86 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				break;
			}
			if (c06ca0e618478c23eba3419653a19760f<DebugCamera>.c5ee19dc8d4cccf5ae2de225410458b86.m_camera == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
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
			c7088de59e49f7108f520cf7e0bae167e = c06ca0e618478c23eba3419653a19760f<DebugCamera>.c5ee19dc8d4cccf5ae2de225410458b86.m_camera;
		}
		else
		{
			if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				break;
			}
			if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56() == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			EntityPlayer entityPlayer = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56().c66b232dbebded7c7e9a89c1e8bd84689() as EntityPlayer;
			if (entityPlayer == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				break;
			}
			if (entityPlayer.cc6a7269e9ea93e537de47dc752b09a86() == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			c7088de59e49f7108f520cf7e0bae167e = entityPlayer.cc6a7269e9ea93e537de47dc752b09a86().camera;
		}
		if (!(c7088de59e49f7108f520cf7e0bae167e != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			Vector3 vector = c7088de59e49f7108f520cf7e0bae167e.WorldToScreenPoint(base.transform.position + Vector3.up * 1f + c7088de59e49f7108f520cf7e0bae167e.transform.right * 0.5f);
			if (!(vector.z > 0f))
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
				if (AIServiceUtility.c5ee19dc8d4cccf5ae2de225410458b86.m_bShowNpcHP)
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
					text = text + Convert.ToString(m_entity.ca2ff7a501878363cb1d5f0472e306620()) + "\n";
				}
				if (flag)
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
					if (m_isNpc)
					{
						goto IL_048b;
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
				}
				if (m_isShowDebugBHVTaskManager)
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
					goto IL_048b;
				}
				goto IL_04be;
				IL_04be:
				if (flag)
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
					if (m_isNpc)
					{
						goto IL_04ef;
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
				}
				if (m_isShowDebugAnimationManager)
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
					goto IL_04ef;
				}
				goto IL_0534;
				IL_0534:
				if (text.Length == 0)
				{
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
				Color contentColor = GUI.contentColor;
				GUI.contentColor = m_debugTextColot;
				GUI.Label(new Rect(vector.x, (float)Screen.height - vector.y, 800f, 600f), text);
				GUI.contentColor = contentColor;
				return;
				IL_04ef:
				if (m_isNpc)
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
					AnimationManagerFSM component3 = GetComponent<AnimationManagerFSM>();
					if ((bool)component3)
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
						text += component3.ToString();
					}
				}
				goto IL_0534;
				IL_048b:
				BHVTaskManager component4 = GetComponent<BHVTaskManager>();
				if ((bool)component4)
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
					text += component4.ToString();
				}
				goto IL_04be;
			}
		}
		IL_01dd:
		if (flag2)
		{
			while (true)
			{
				switch (4)
				{
				case 0:
					break;
				default:
					if (text.Length != 0)
					{
						while (true)
						{
							switch (2)
							{
							case 0:
								break;
							default:
							{
								Color contentColor2 = GUI.contentColor;
								GUI.contentColor = m_debugTextColot;
								GUI.Label(new Rect(180f, Screen.height - 500, 800f, 600f), "<LocalPlayer>\n" + text);
								GUI.contentColor = contentColor2;
								return;
							}
							}
						}
					}
					return;
				}
			}
		}
		goto IL_0250;
	}

	private void OnSpawnCompleted()
	{
	}
}
