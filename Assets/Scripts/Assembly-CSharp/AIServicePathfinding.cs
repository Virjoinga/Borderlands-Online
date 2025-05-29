using A;
using UnityEngine;

public sealed class AIServicePathfinding
{
	[HideInInspector]
	public int m_activeMavMeshLayer = 1;

	private static readonly AIServicePathfinding s_instance = new AIServicePathfinding();

	public static AIServicePathfinding c5ee19dc8d4cccf5ae2de225410458b86
	{
		get
		{
			return s_instance;
		}
	}

	private AIServicePathfinding()
	{
	}

	public AIServicePathfindingResult c18ff488bb71fea0bf65994cf9e0da4fe(NavMeshAgent c6b99ad50eb6dc037190daff68450f5f6, Vector3 cd6a7967330188dc1a6131ff919985c04)
	{
		c6b99ad50eb6dc037190daff68450f5f6.SetDestination(cd6a7967330188dc1a6131ff919985c04);
		return AIServicePathfindingResult.SUCCESS;
	}

	public AIServicePathfindingResult cc6f51174acea6f36f36e7356734f18e1(NavMeshAgent c6b99ad50eb6dc037190daff68450f5f6)
	{
		c6b99ad50eb6dc037190daff68450f5f6.ResetPath();
		return AIServicePathfindingResult.SUCCESS;
	}

	public AIServicePathfindingResult c2158bbdaed20b1abffd808ceb9985286(NavMeshAgent c6b99ad50eb6dc037190daff68450f5f6, float cf6e1a5c5132a48f8bc47958d2be74c56)
	{
		c6b99ad50eb6dc037190daff68450f5f6.speed = cf6e1a5c5132a48f8bc47958d2be74c56;
		return AIServicePathfindingResult.SUCCESS;
	}

	public AIServicePathfindingResult c0798615c4d823cab99e322e9bd611bf8(NavMeshAgent c6b99ad50eb6dc037190daff68450f5f6, float c0bc825bfffbcd9f7a9aaf0a230c037bd)
	{
		c6b99ad50eb6dc037190daff68450f5f6.angularSpeed = c0bc825bfffbcd9f7a9aaf0a230c037bd;
		return AIServicePathfindingResult.SUCCESS;
	}

	public AIServicePathfindingResult cf6af91221ed5cef5473c974ad2375725(NavMeshAgent c6b99ad50eb6dc037190daff68450f5f6, float cf575e81a7ec0714bfaed22ce986402b3)
	{
		c6b99ad50eb6dc037190daff68450f5f6.acceleration = cf575e81a7ec0714bfaed22ce986402b3;
		return AIServicePathfindingResult.SUCCESS;
	}

	public AIServicePathfindingResult c52b03b300f3d18698e1369b7676e4ce4(NavMeshAgent c6b99ad50eb6dc037190daff68450f5f6, bool c76255d1e4fcad0f368a50050da6bf091)
	{
		c6b99ad50eb6dc037190daff68450f5f6.updateRotation = c76255d1e4fcad0f368a50050da6bf091;
		return AIServicePathfindingResult.SUCCESS;
	}

	public AIServicePathfindingResult cacece2ba60347d30fef63f1f992f4e12(NavMeshAgent c6b99ad50eb6dc037190daff68450f5f6, bool c4d7fcfc073b89715fb434677652b6de3)
	{
		c6b99ad50eb6dc037190daff68450f5f6.updatePosition = c4d7fcfc073b89715fb434677652b6de3;
		return AIServicePathfindingResult.SUCCESS;
	}

	public Vector3 ccc1bc2d5101c39c39fc80c79747a6c8b(float c2002bb238c228cf502166e05c0d89311, NavMeshAgent c6b99ad50eb6dc037190daff68450f5f6)
	{
		Vector3 result = c6b99ad50eb6dc037190daff68450f5f6.transform.position + cd9761354b8ba9519cb1ef92160cf8b59(c6b99ad50eb6dc037190daff68450f5f6) * c2002bb238c228cf502166e05c0d89311;
		result.y = c6b99ad50eb6dc037190daff68450f5f6.transform.position.y;
		return result;
	}

	public AIServicePathfindingResult c68228ae817c8a3a0983d4818eab1e40d(float c2002bb238c228cf502166e05c0d89311, NavMeshAgent c6b99ad50eb6dc037190daff68450f5f6)
	{
		c6b99ad50eb6dc037190daff68450f5f6.transform.position = ccc1bc2d5101c39c39fc80c79747a6c8b(c2002bb238c228cf502166e05c0d89311, c6b99ad50eb6dc037190daff68450f5f6);
		return AIServicePathfindingResult.SUCCESS;
	}

	public bool cdc4e149cd54739f999b6786b45f53db7(NavMeshAgent c6b99ad50eb6dc037190daff68450f5f6, Vector3 ca57283c03be55af031c0448e815af854, out Vector3 c3e32dcf701d8dae92a9d3c989f9eb387)
	{
		NavMeshHit hit;
		c6b99ad50eb6dc037190daff68450f5f6.Raycast(ca57283c03be55af031c0448e815af854, out hit);
		if (hit.hit)
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
					c3e32dcf701d8dae92a9d3c989f9eb387 = hit.position;
					c3e32dcf701d8dae92a9d3c989f9eb387 += hit.normal * 0.01f;
					c3e32dcf701d8dae92a9d3c989f9eb387.y = ca57283c03be55af031c0448e815af854.y;
					return true;
				}
			}
		}
		c3e32dcf701d8dae92a9d3c989f9eb387 = ca57283c03be55af031c0448e815af854;
		return false;
	}

	public AIServicePathfindingStatus ccf1f6c103ff2cda951ec9c16ce0394c3(NavMeshAgent c6b99ad50eb6dc037190daff68450f5f6)
	{
		return AIServicePathfindingStatus.FAILED;
	}

	public Vector3 cd9761354b8ba9519cb1ef92160cf8b59(NavMeshAgent ce1c16ad75d5300e1af3cdb9e253cfa7d)
	{
		Vector3 desiredVelocity = ce1c16ad75d5300e1af3cdb9e253cfa7d.desiredVelocity;
		desiredVelocity.y = 0f;
		return desiredVelocity;
	}

	public Vector3 c3a0755c94976451bf75a254edfe4aead(NavMeshAgent ce1c16ad75d5300e1af3cdb9e253cfa7d)
	{
		if (cd9761354b8ba9519cb1ef92160cf8b59(ce1c16ad75d5300e1af3cdb9e253cfa7d).magnitude <= float.Epsilon)
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
					return Vector3.zero;
				}
			}
		}
		return cd9761354b8ba9519cb1ef92160cf8b59(ce1c16ad75d5300e1af3cdb9e253cfa7d).normalized;
	}

	public bool ce8c21d608c9df9d3220d463d8da7ce5d(NavMeshAgent ce1c16ad75d5300e1af3cdb9e253cfa7d, Vector3 cf6af9bfe3579d09c233445ffb83a3162)
	{
		Vector3 vector = ce1c16ad75d5300e1af3cdb9e253cfa7d.destination - cf6af9bfe3579d09c233445ffb83a3162;
		vector.y = 0f;
		return vector.sqrMagnitude <= ce1c16ad75d5300e1af3cdb9e253cfa7d.stoppingDistance * ce1c16ad75d5300e1af3cdb9e253cfa7d.stoppingDistance;
	}

	public bool cad1e454abed62b0e36d73bc6cd26c0a5(NavMeshAgent ce1c16ad75d5300e1af3cdb9e253cfa7d, Vector3 c0b885a96d3f0d32f51ff3ec0d37d2900)
	{
		if (ce1c16ad75d5300e1af3cdb9e253cfa7d == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
					return true;
				}
			}
		}
		NavMeshHit hit;
		if (ce1c16ad75d5300e1af3cdb9e253cfa7d.Raycast(c0b885a96d3f0d32f51ff3ec0d37d2900, out hit))
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
		return false;
	}
}
