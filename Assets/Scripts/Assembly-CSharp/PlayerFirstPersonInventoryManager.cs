using System;
using System.Collections;
using System.Text;
using A;
using UnityEngine;
using XsdSettings;

public class PlayerFirstPersonInventoryManager : MonoBehaviour
{
	private Animator m_inventoryAnimator;

	private EntityPlayer m_entityPlayer;

	private GameObject m_equipedWeapon;

	private GameObject m_backWeapon;

	private GameObject m_thighWeapon;

	private Skeleton m_inventoryPlayerSkeleton;

	private bool m_weaponResetPending;

	private GameObject m_equipedClassmode;

	private bool m_classmodeResetPending;

	private PlayerAnimationIkController m_playerIkController;

	public Skeleton c08335188fc1aef17bd106701ce1f7091
	{
		get
		{
			m_inventoryPlayerSkeleton = base.gameObject.GetComponent<Skeleton>();
			if (m_inventoryPlayerSkeleton == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				m_inventoryPlayerSkeleton = base.gameObject.AddComponent<Skeleton>();
			}
			return m_inventoryPlayerSkeleton;
		}
		set
		{
			m_inventoryPlayerSkeleton = value;
		}
	}

	private string c1f9e55b24f86312d9a6b5debe9c1d9f4(GameObject ccf6e2319511cbeac810481f6652649b7)
	{
		if (ccf6e2319511cbeac810481f6652649b7 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return null;
				}
			}
		}
		StringBuilder stringBuilder = new StringBuilder();
		if (ccf6e2319511cbeac810481f6652649b7.transform.parent != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			stringBuilder.AppendLine(ccf6e2319511cbeac810481f6652649b7.transform.parent.name);
			stringBuilder.AppendLine(ccf6e2319511cbeac810481f6652649b7.transform.parent.localPosition.ToString());
			stringBuilder.AppendLine(ccf6e2319511cbeac810481f6652649b7.transform.parent.localRotation.ToString());
		}
		stringBuilder.AppendLine(ccf6e2319511cbeac810481f6652649b7.transform.name);
		stringBuilder.AppendLine(ccf6e2319511cbeac810481f6652649b7.transform.localPosition.ToString());
		stringBuilder.AppendLine(ccf6e2319511cbeac810481f6652649b7.transform.localRotation.ToString());
		IEnumerator enumerator = ccf6e2319511cbeac810481f6652649b7.transform.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Transform transform = (Transform)enumerator.Current;
				stringBuilder.AppendLine(transform.name);
				stringBuilder.AppendLine(transform.localPosition.ToString());
				stringBuilder.AppendLine(transform.localRotation.ToString());
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					goto end_IL_0194;
				}
				continue;
				end_IL_0194:
				break;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable == null)
			{
				while (true)
				{
					switch (1)
					{
					case 0:
						break;
					default:
						goto end_IL_01ac;
					}
					continue;
					end_IL_01ac:
					break;
				}
			}
			else
			{
				disposable.Dispose();
			}
		}
		return stringBuilder.ToString();
	}

	public EntityPlayer c4a92afe664b68f75e668116af19e84e9()
	{
		if (m_entityPlayer == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					return null;
				}
			}
			PlayerInfoSync playerInfoSync = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56();
			if (playerInfoSync == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					return null;
				}
			}
			if (playerInfoSync.c66b232dbebded7c7e9a89c1e8bd84689() != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				m_entityPlayer = playerInfoSync.c66b232dbebded7c7e9a89c1e8bd84689() as EntityPlayer;
			}
		}
		return m_entityPlayer;
	}

	public bool c30de3c8b15ccbcc59964fdcdf3304e70()
	{
		if (m_equipedClassmode != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			UnityEngine.Object.DestroyImmediate(m_equipedClassmode);
		}
		EntityPlayer entityPlayer = c4a92afe664b68f75e668116af19e84e9();
		if (entityPlayer == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		if (c08335188fc1aef17bd106701ce1f7091 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		EntityClassMode entityClassMode = entityPlayer.c77717f6875cf8dbd332d3f112b2aa888();
		if (entityClassMode == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		ClassModeDNA classModeDNA = entityClassMode.c729ce3b5f48e0eac3a7ead97b1d02f8d();
		if (classModeDNA == null)
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
		m_equipedClassmode = c7f8a2c39587cb0e2e701abcbc27bdc8a(entityClassMode);
		if (m_equipedClassmode != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			Transform transform = c08335188fc1aef17bd106701ce1f7091.c99ffe9fbf560125954f0bf35b449d5c8(classModeDNA.m_cmType);
			if (transform == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					return false;
				}
			}
			m_equipedClassmode.transform.parent = transform;
			m_equipedClassmode.transform.localPosition = Vector3.zero;
			m_equipedClassmode.transform.localRotation = Quaternion.identity;
			m_equipedClassmode.transform.localScale = Vector3.one;
			m_equipedClassmode.SetActive(true);
			Component component = m_equipedClassmode.GetComponent<Animator>();
			if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				UnityEngine.Object.Destroy(component);
			}
			m_equipedClassmode.layer = c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.ce9030196d2dbfbe5a5051960f05df6d0().c4861eb9b2510db1821a27c4857816dbd();
			SkinnedMeshRenderer componentInChildren = m_equipedClassmode.GetComponentInChildren<SkinnedMeshRenderer>();
			if (componentInChildren != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				componentInChildren.gameObject.layer = c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.ce9030196d2dbfbe5a5051960f05df6d0().c4861eb9b2510db1821a27c4857816dbd();
			}
		}
		return true;
	}

	public bool c8d78e99a9118971f98ea10225050b22b()
	{
		if (m_equipedWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			UnityEngine.Object.DestroyImmediate(m_equipedWeapon);
		}
		if (m_backWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			UnityEngine.Object.DestroyImmediate(m_backWeapon);
		}
		if (m_thighWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			UnityEngine.Object.DestroyImmediate(m_thighWeapon);
		}
		EntityPlayer entityPlayer = c4a92afe664b68f75e668116af19e84e9();
		if (entityPlayer == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (c08335188fc1aef17bd106701ce1f7091 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		EntityWeapon entityWeapon = entityPlayer.c1cd8bfe2bd594219e3cd115ca7594a51();
		if (entityWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (7)
				{
				case 0:
					break;
				default:
					m_equipedWeapon = c3a2a49e64a3dd5ee9abd379427a973c6(entityWeapon);
					if (m_equipedWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
					{
						while (true)
						{
							switch (6)
							{
							case 0:
								break;
							default:
							{
								cd00000353c1c77f40801c060d7a6be40(m_equipedWeapon, c08335188fc1aef17bd106701ce1f7091.cf40f1411a71635238075b839a6650d91(entityWeapon.c83e548e5608cd7f222098a6966b16545()));
								WeaponType weaponType = entityWeapon.c83e548e5608cd7f222098a6966b16545();
								if (m_inventoryAnimator != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
									m_inventoryAnimator.SetInteger("iWeaponType", (int)weaponType);
								}
								if (m_playerIkController != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
									m_playerIkController.m_currentWeaponType = weaponType;
								}
								entityWeapon = entityPlayer.cbbb614d0d9109acaa212a9df5e71e116();
								if (entityWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
									m_backWeapon = c3a2a49e64a3dd5ee9abd379427a973c6(entityWeapon);
									if (m_backWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
										cd00000353c1c77f40801c060d7a6be40(m_backWeapon, c08335188fc1aef17bd106701ce1f7091.cf50410620462e4c261abcb41d0a98221(entityWeapon.c83e548e5608cd7f222098a6966b16545()));
									}
								}
								entityWeapon = entityPlayer.c184e9c28cddb14ec4108e680534cc445();
								if (entityWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
									m_thighWeapon = c3a2a49e64a3dd5ee9abd379427a973c6(entityWeapon);
									if (m_thighWeapon != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
										cd00000353c1c77f40801c060d7a6be40(m_thighWeapon, c08335188fc1aef17bd106701ce1f7091.cf50410620462e4c261abcb41d0a98221(entityWeapon.c83e548e5608cd7f222098a6966b16545()));
									}
								}
								return true;
							}
							}
						}
					}
					return false;
				}
			}
		}
		return false;
	}

	private GameObject c7f8a2c39587cb0e2e701abcbc27bdc8a(EntityClassMode cfe47eb612a9ed07d548cc1c70d298fda)
	{
		if (cfe47eb612a9ed07d548cc1c70d298fda == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return null;
				}
			}
		}
		GameObject gameObject = cfe47eb612a9ed07d548cc1c70d298fda.gameObject;
		if (gameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (6)
				{
				case 0:
					break;
				default:
					return null;
				}
			}
		}
		GameObject gameObject2 = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
		bool activeInHierarchy = gameObject.activeInHierarchy;
		gameObject.SetActive(true);
		Animator componentInChildren = gameObject.GetComponentInChildren<Animator>();
		if (componentInChildren != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			gameObject2 = UnityEngine.Object.Instantiate(componentInChildren.gameObject) as GameObject;
			if (gameObject2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		}
		gameObject.SetActive(activeInHierarchy);
		return gameObject2;
	}

	private GameObject c3a2a49e64a3dd5ee9abd379427a973c6(EntityWeapon c21171aa66b09d27be1f523137627333d)
	{
		if (c21171aa66b09d27be1f523137627333d == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return null;
				}
			}
		}
		GameObject gameObject = c21171aa66b09d27be1f523137627333d.gameObject;
		if (gameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
					return null;
				}
			}
		}
		GameObject gameObject2 = cf088431fef58ee0d8274f8c300aa822c.c7088de59e49f7108f520cf7e0bae167e;
		bool activeInHierarchy = gameObject.activeInHierarchy;
		gameObject.SetActive(true);
		Animator componentInChildren = gameObject.GetComponentInChildren<Animator>();
		if (componentInChildren != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			gameObject2 = UnityEngine.Object.Instantiate(componentInChildren.gameObject) as GameObject;
			if (gameObject2 != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				IEnumerator enumerator = gameObject2.transform.GetEnumerator();
				try
				{
					while (true)
					{
						if (enumerator.MoveNext())
						{
							Transform transform = (Transform)enumerator.Current;
							if (!(transform.name.ToLower() == "b_body"))
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
								transform.localRotation = Quaternion.Euler(270f, 0f, 0f);
								break;
							}
							break;
						}
						while (true)
						{
							switch (4)
							{
							case 0:
								break;
							default:
								goto end_IL_0129;
							}
							continue;
							end_IL_0129:
							break;
						}
						break;
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable == null)
					{
						while (true)
						{
							switch (5)
							{
							case 0:
								break;
							default:
								goto end_IL_0142;
							}
							continue;
							end_IL_0142:
							break;
						}
					}
					else
					{
						disposable.Dispose();
					}
				}
			}
		}
		gameObject.SetActive(activeInHierarchy);
		return gameObject2;
	}

	private void cd00000353c1c77f40801c060d7a6be40(GameObject ccf6e2319511cbeac810481f6652649b7, Transform c0b8b4f11377b8a222dc728ff2c622559)
	{
		if (ccf6e2319511cbeac810481f6652649b7 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
		{
			while (true)
			{
				switch (2)
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
		if (c0b8b4f11377b8a222dc728ff2c622559 == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			c0b8b4f11377b8a222dc728ff2c622559 = c4a92afe664b68f75e668116af19e84e9().transform;
		}
		ccf6e2319511cbeac810481f6652649b7.transform.parent = c0b8b4f11377b8a222dc728ff2c622559;
		ccf6e2319511cbeac810481f6652649b7.transform.localPosition = Vector3.zero;
		ccf6e2319511cbeac810481f6652649b7.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
		ccf6e2319511cbeac810481f6652649b7.transform.localScale = Vector3.one;
		ccf6e2319511cbeac810481f6652649b7.SetActive(true);
		Component component = ccf6e2319511cbeac810481f6652649b7.GetComponent<MecanimEventEmitter>();
		if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			UnityEngine.Object.Destroy(component);
		}
		component = ccf6e2319511cbeac810481f6652649b7.GetComponent<BaseEventTriggerCtl>();
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
			UnityEngine.Object.Destroy(component);
		}
		component = ccf6e2319511cbeac810481f6652649b7.GetComponent<Animator>();
		if (component != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			UnityEngine.Object.Destroy(component);
		}
		ccf6e2319511cbeac810481f6652649b7.layer = c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.ce9030196d2dbfbe5a5051960f05df6d0().c4861eb9b2510db1821a27c4857816dbd();
		SkinnedMeshRenderer componentInChildren = ccf6e2319511cbeac810481f6652649b7.GetComponentInChildren<SkinnedMeshRenderer>();
		if (!(componentInChildren != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			componentInChildren.material.shader = Shader.Find("Custom/BOL_Wpn_MaskReflect");
			componentInChildren.gameObject.layer = c06ca0e618478c23eba3419653a19760f<GraphicsMgr>.c5ee19dc8d4cccf5ae2de225410458b86.ce9030196d2dbfbe5a5051960f05df6d0().c4861eb9b2510db1821a27c4857816dbd();
			return;
		}
	}

	private void Start()
	{
		if (c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86 != null)
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
			c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c7d08ed02a7697465eaaf348e5256df6d(OnInventoryUpdate);
		}
		base.transform.parent = c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.transform;
	}

	public void OnInventoryUpdate(InventoryServiceWrapper.InventoryUpdateType updateType)
	{
		if (m_inventoryAnimator == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (m_inventoryAnimator.gameObject == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
				if (!m_inventoryAnimator.gameObject.activeInHierarchy)
				{
					while (true)
					{
						switch (3)
						{
						case 0:
							break;
						default:
							return;
						}
					}
				}
				if (updateType != InventoryServiceWrapper.InventoryUpdateType.ItemUpdate)
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
					if (updateType != InventoryServiceWrapper.InventoryUpdateType.ChangeActiveWeapon)
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
						if (updateType != InventoryServiceWrapper.InventoryUpdateType.FullUpdate)
						{
							if (updateType != InventoryServiceWrapper.InventoryUpdateType.ChangeEquipedClassMod)
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
								m_classmodeResetPending = true;
								return;
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
				}
				m_weaponResetPending = true;
				return;
			}
		}
	}

	public void OnShowInventoryView()
	{
		m_weaponResetPending = true;
		m_classmodeResetPending = true;
	}

	private void Update()
	{
		if (m_inventoryAnimator == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			m_inventoryAnimator = base.gameObject.GetComponent<Animator>();
		}
		if (m_playerIkController == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
			m_playerIkController = base.gameObject.GetComponent<PlayerAnimationIkController>();
		}
		if (m_weaponResetPending)
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
			m_weaponResetPending = !c8d78e99a9118971f98ea10225050b22b();
		}
		if (!m_classmodeResetPending)
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
			m_classmodeResetPending = !c30de3c8b15ccbcc59964fdcdf3304e70();
			return;
		}
	}

	private void OnDestroy()
	{
		if (c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86 == null)
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
			c1ee7921b0c3cce194fb7cae41b5a9d82<InventoryServiceWrapper>.c5ee19dc8d4cccf5ae2de225410458b86.c0e99b4914f8c6b80f6233d720bf3d53f(OnInventoryUpdate);
			return;
		}
	}

	private void OnEnable()
	{
		PlayerInfoSync playerInfoSync = c06ca0e618478c23eba3419653a19760f<Session>.c5ee19dc8d4cccf5ae2de225410458b86.c8458d28cbbf3db75361c95db115cef56();
		if (!(playerInfoSync != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
			if (playerInfoSync.m_avatarDna == null)
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
				AvatarType avatarType = playerInfoSync.m_avatarDna.c071244a19e2d9f70f4d2d6d38677162a();
				if (!(m_inventoryAnimator != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					m_inventoryAnimator.SetFloat("fDefaultPose", (float)avatarType);
					return;
				}
			}
		}
	}
}
