using A;
using Core;
using UnityEngine;

public sealed class AIServiceCurve
{
	public enum ECurveType
	{
		EJumpCurve = 0,
		ESpiderWidommakeJumpCurve = 1,
		ESpitCurve = 2,
		EIcePickAttackFlyingCurve = 3,
		EThrowAxeCurve = 4,
		EKnoxxJetAttackCurve = 5,
		EKnoxxMissileFlyingCurve = 6,
		EApollyonJumpCurve = 7
	}

	public class Curve
	{
		protected AnimationCurve m_animationCurve = new AnimationCurve();

		protected Vector3 m_curveStartPosition;

		public Vector3 m_curveEndPosition;

		protected Keyframe m_startKey;

		protected Keyframe m_topKey;

		protected Keyframe m_topKey1;

		protected Keyframe m_endKey;

		protected float m_time;

		public static Vector3 cdfea466b721ee9c3a777ecae775839c5(Vector3 c68af8ed5e37e15b62b20e7502dbbd5a3, Vector3 c0b885a96d3f0d32f51ff3ec0d37d2900, float ceb8b3aecb62e595cd2d83736ab804281)
		{
			return c68af8ed5e37e15b62b20e7502dbbd5a3 + (c0b885a96d3f0d32f51ff3ec0d37d2900 - c68af8ed5e37e15b62b20e7502dbbd5a3) * ceb8b3aecb62e595cd2d83736ab804281;
		}

		public bool c8a3c82bab0e64a4d2e673575bedb5d79(Vector3 c68af8ed5e37e15b62b20e7502dbbd5a3, Vector3 c0b885a96d3f0d32f51ff3ec0d37d2900, float ceb8b3aecb62e595cd2d83736ab804281)
		{
			float distance = 3f;
			m_curveStartPosition = c68af8ed5e37e15b62b20e7502dbbd5a3;
			m_curveEndPosition = cdfea466b721ee9c3a777ecae775839c5(c68af8ed5e37e15b62b20e7502dbbd5a3, c0b885a96d3f0d32f51ff3ec0d37d2900, ceb8b3aecb62e595cd2d83736ab804281);
			Vector3 curveEndPosition = m_curveEndPosition;
			curveEndPosition.y = c0b885a96d3f0d32f51ff3ec0d37d2900.y;
			RaycastHit hitInfo;
			if (Physics.Raycast(curveEndPosition, -Vector3.up, out hitInfo, distance, 1 << LayerMask.NameToLayer("Walkable")))
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
						m_curveEndPosition.y = hitInfo.point.y;
						while (m_animationCurve.length > 0)
						{
							m_animationCurve.RemoveKey(0);
						}
						while (true)
						{
							switch (1)
							{
							case 0:
								break;
							default:
								m_startKey.time = 0f;
								m_startKey.value = c68af8ed5e37e15b62b20e7502dbbd5a3.y;
								m_startKey.inTangent = 0f;
								m_startKey.outTangent = 0f;
								m_startKey.tangentMode = 10;
								m_animationCurve.AddKey(m_startKey);
								m_topKey.time = 0.66f;
								m_topKey.value = c0b885a96d3f0d32f51ff3ec0d37d2900.y;
								m_topKey.inTangent = 0f;
								m_topKey.outTangent = 0f;
								m_topKey.tangentMode = 10;
								m_animationCurve.AddKey(m_topKey);
								m_endKey.time = 1f;
								m_endKey.value = m_curveEndPosition.y;
								m_endKey.inTangent = 0f;
								m_endKey.outTangent = 0f;
								m_endKey.tangentMode = 10;
								m_animationCurve.AddKey(m_endKey);
								m_animationCurve.SmoothTangents(0, 0f);
								m_animationCurve.SmoothTangents(1, 0f);
								m_animationCurve.SmoothTangents(2, 0f);
								m_time = 0f;
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		public bool c1660b88d9fa326a439baf51c839d7e12(Vector3 c68af8ed5e37e15b62b20e7502dbbd5a3, Vector3 c0b885a96d3f0d32f51ff3ec0d37d2900, float ceb8b3aecb62e595cd2d83736ab804281)
		{
			float distance = 3f;
			m_curveStartPosition = c68af8ed5e37e15b62b20e7502dbbd5a3;
			m_curveEndPosition = cdfea466b721ee9c3a777ecae775839c5(c68af8ed5e37e15b62b20e7502dbbd5a3, c0b885a96d3f0d32f51ff3ec0d37d2900, ceb8b3aecb62e595cd2d83736ab804281);
			Vector3 curveEndPosition = m_curveEndPosition;
			curveEndPosition.y = c0b885a96d3f0d32f51ff3ec0d37d2900.y;
			RaycastHit hitInfo;
			if (Physics.Raycast(curveEndPosition, -Vector3.up, out hitInfo, distance, 1 << LayerMask.NameToLayer("Walkable")))
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
				m_curveEndPosition.y = hitInfo.point.y;
			}
			while (m_animationCurve.length > 0)
			{
				m_animationCurve.RemoveKey(0);
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				m_startKey.time = 0f;
				m_startKey.value = c68af8ed5e37e15b62b20e7502dbbd5a3.y;
				m_startKey.inTangent = 0f;
				m_startKey.outTangent = 0f;
				m_startKey.tangentMode = 10;
				m_animationCurve.AddKey(m_startKey);
				m_topKey.time = 1f / ceb8b3aecb62e595cd2d83736ab804281;
				m_topKey.value = c0b885a96d3f0d32f51ff3ec0d37d2900.y;
				m_topKey.inTangent = 0f;
				m_topKey.outTangent = 0f;
				m_topKey.tangentMode = 10;
				m_animationCurve.AddKey(m_topKey);
				m_endKey.time = 1f;
				m_endKey.value = m_curveEndPosition.y;
				m_endKey.inTangent = 0f;
				m_endKey.outTangent = 0f;
				m_endKey.tangentMode = 10;
				m_animationCurve.AddKey(m_endKey);
				m_animationCurve.SmoothTangents(0, 0f);
				m_animationCurve.SmoothTangents(1, 0f);
				m_animationCurve.SmoothTangents(2, 0f);
				m_time = 0f;
				return true;
			}
		}

		public bool c28285bc14fd5bc5688495fc3cda008c4(Vector3 c68af8ed5e37e15b62b20e7502dbbd5a3, Vector3 c0b885a96d3f0d32f51ff3ec0d37d2900, float ceb8b3aecb62e595cd2d83736ab804281)
		{
			float distance = 10f;
			m_curveStartPosition = c68af8ed5e37e15b62b20e7502dbbd5a3;
			m_curveEndPosition = cdfea466b721ee9c3a777ecae775839c5(c68af8ed5e37e15b62b20e7502dbbd5a3, c0b885a96d3f0d32f51ff3ec0d37d2900, ceb8b3aecb62e595cd2d83736ab804281);
			Vector3 curveEndPosition = m_curveEndPosition;
			curveEndPosition.y = c0b885a96d3f0d32f51ff3ec0d37d2900.y;
			RaycastHit hitInfo;
			if (Physics.Raycast(curveEndPosition, -Vector3.up, out hitInfo, distance, 1 << LayerMask.NameToLayer("Walkable")))
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
						m_curveEndPosition.y = hitInfo.point.y;
						while (m_animationCurve.length > 0)
						{
							m_animationCurve.RemoveKey(0);
						}
						while (true)
						{
							switch (7)
							{
							case 0:
								break;
							default:
								m_startKey.time = 0f;
								m_startKey.value = c68af8ed5e37e15b62b20e7502dbbd5a3.y;
								m_startKey.inTangent = 0f;
								m_startKey.outTangent = 0f;
								m_startKey.tangentMode = 10;
								m_animationCurve.AddKey(m_startKey);
								m_topKey.time = 0.5f;
								m_topKey.value = c0b885a96d3f0d32f51ff3ec0d37d2900.y + 2f;
								m_topKey.inTangent = 0f;
								m_topKey.outTangent = 0f;
								m_topKey.tangentMode = 10;
								m_animationCurve.AddKey(m_topKey);
								m_endKey.time = 1f;
								m_endKey.value = m_curveEndPosition.y;
								m_endKey.inTangent = 0f;
								m_endKey.outTangent = 0f;
								m_endKey.tangentMode = 10;
								m_animationCurve.AddKey(m_endKey);
								m_animationCurve.SmoothTangents(0, 0f);
								m_animationCurve.SmoothTangents(1, 0f);
								m_animationCurve.SmoothTangents(2, 0f);
								m_time = 0f;
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		public bool cbaea5f2a30fc23ddb48bf662f1329e17(Vector3 c68af8ed5e37e15b62b20e7502dbbd5a3, Vector3 c0b885a96d3f0d32f51ff3ec0d37d2900, float ceb8b3aecb62e595cd2d83736ab804281)
		{
			float distance = 10f;
			m_curveStartPosition = c68af8ed5e37e15b62b20e7502dbbd5a3;
			m_curveEndPosition = cdfea466b721ee9c3a777ecae775839c5(c68af8ed5e37e15b62b20e7502dbbd5a3, c0b885a96d3f0d32f51ff3ec0d37d2900, ceb8b3aecb62e595cd2d83736ab804281);
			Vector3 curveEndPosition = m_curveEndPosition;
			curveEndPosition.y = c0b885a96d3f0d32f51ff3ec0d37d2900.y;
			RaycastHit hitInfo;
			if (Physics.Raycast(curveEndPosition + Vector3.up * 2f, -Vector3.up, out hitInfo, distance, 1 << LayerMask.NameToLayer("Walkable")))
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
				m_curveEndPosition.y = hitInfo.point.y + 1.1f;
			}
			while (m_animationCurve.length > 0)
			{
				m_animationCurve.RemoveKey(0);
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				m_startKey.time = 0f;
				m_startKey.value = c68af8ed5e37e15b62b20e7502dbbd5a3.y;
				m_startKey.inTangent = 0f;
				m_startKey.outTangent = 0f;
				m_startKey.tangentMode = 10;
				m_animationCurve.AddKey(m_startKey);
				m_topKey.time = 0.75f;
				m_topKey.value = c0b885a96d3f0d32f51ff3ec0d37d2900.y + 10f;
				m_topKey.inTangent = 0f;
				m_topKey.outTangent = 0f;
				m_topKey.tangentMode = 10;
				m_animationCurve.AddKey(m_topKey);
				m_endKey.time = 1f;
				m_endKey.value = m_curveEndPosition.y;
				m_endKey.inTangent = 0f;
				m_endKey.outTangent = 0f;
				m_endKey.tangentMode = 10;
				m_animationCurve.AddKey(m_endKey);
				m_animationCurve.SmoothTangents(0, 0f);
				m_animationCurve.SmoothTangents(1, 0f);
				m_animationCurve.SmoothTangents(2, 0f);
				m_time = 0f;
				return true;
			}
		}

		public bool c474bb98602cf4117dd9fef4be9ed7def(Vector3 c68af8ed5e37e15b62b20e7502dbbd5a3, Vector3 c0b885a96d3f0d32f51ff3ec0d37d2900, float ceb8b3aecb62e595cd2d83736ab804281)
		{
			m_curveStartPosition = c68af8ed5e37e15b62b20e7502dbbd5a3;
			m_curveEndPosition = cdfea466b721ee9c3a777ecae775839c5(c68af8ed5e37e15b62b20e7502dbbd5a3, c0b885a96d3f0d32f51ff3ec0d37d2900, ceb8b3aecb62e595cd2d83736ab804281);
			Vector3 curveEndPosition = m_curveEndPosition;
			curveEndPosition.y = c0b885a96d3f0d32f51ff3ec0d37d2900.y;
			RaycastHit hitInfo;
			if (Physics.Raycast(curveEndPosition + Vector3.up * 2f, -Vector3.up, out hitInfo, 6f, 1 << LayerMask.NameToLayer("Walkable")))
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
				m_curveEndPosition.y = hitInfo.point.y;
			}
			while (m_animationCurve.length > 0)
			{
				m_animationCurve.RemoveKey(0);
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				m_startKey.time = 0f;
				m_startKey.value = c68af8ed5e37e15b62b20e7502dbbd5a3.y;
				m_startKey.inTangent = 0f;
				m_startKey.outTangent = 0f;
				m_startKey.tangentMode = 10;
				m_animationCurve.AddKey(m_startKey);
				m_topKey.time = 0.66f;
				m_topKey.value = c0b885a96d3f0d32f51ff3ec0d37d2900.y;
				m_topKey.inTangent = 0f;
				m_topKey.outTangent = 0f;
				m_topKey.tangentMode = 10;
				m_animationCurve.AddKey(m_topKey);
				m_endKey.time = 1f;
				m_endKey.value = m_curveEndPosition.y;
				m_endKey.inTangent = 0f;
				m_endKey.outTangent = 0f;
				m_endKey.tangentMode = 10;
				m_animationCurve.AddKey(m_endKey);
				m_animationCurve.SmoothTangents(0, 0f);
				m_animationCurve.SmoothTangents(1, 0f);
				m_animationCurve.SmoothTangents(2, 0f);
				m_time = 0f;
				return true;
			}
		}

		public bool c80404dd57fa71b991a3eb595a27a6900(Vector3 c68af8ed5e37e15b62b20e7502dbbd5a3, Vector3 c0b885a96d3f0d32f51ff3ec0d37d2900, float ceb8b3aecb62e595cd2d83736ab804281)
		{
			m_curveStartPosition = c68af8ed5e37e15b62b20e7502dbbd5a3;
			m_curveEndPosition = cdfea466b721ee9c3a777ecae775839c5(c68af8ed5e37e15b62b20e7502dbbd5a3, c0b885a96d3f0d32f51ff3ec0d37d2900, ceb8b3aecb62e595cd2d83736ab804281);
			NavMeshHit hit;
			if (NavMesh.SamplePosition(m_curveEndPosition, out hit, 1f, int.MaxValue))
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
						m_curveEndPosition = hit.position;
						while (m_animationCurve.length > 0)
						{
							m_animationCurve.RemoveKey(0);
						}
						while (true)
						{
							switch (3)
							{
							case 0:
								break;
							default:
								m_startKey.time = 0f;
								m_startKey.value = c68af8ed5e37e15b62b20e7502dbbd5a3.y;
								m_startKey.inTangent = 0f;
								m_startKey.outTangent = 0f;
								m_startKey.tangentMode = 10;
								m_animationCurve.AddKey(m_startKey);
								m_topKey.time = 0.1f;
								m_topKey.value = c0b885a96d3f0d32f51ff3ec0d37d2900.y + 3f;
								m_topKey.inTangent = 0f;
								m_topKey.outTangent = 0f;
								m_topKey.tangentMode = 10;
								m_animationCurve.AddKey(m_topKey);
								m_topKey1.time = 0.9f;
								m_topKey1.value = c0b885a96d3f0d32f51ff3ec0d37d2900.y + 3f;
								m_topKey1.inTangent = 0f;
								m_topKey1.outTangent = 0f;
								m_topKey1.tangentMode = 10;
								m_animationCurve.AddKey(m_topKey1);
								m_endKey.time = 1f;
								m_endKey.value = m_curveEndPosition.y;
								m_endKey.inTangent = 0f;
								m_endKey.outTangent = 0f;
								m_endKey.tangentMode = 10;
								m_animationCurve.AddKey(m_endKey);
								m_animationCurve.SmoothTangents(0, 0f);
								m_animationCurve.SmoothTangents(1, 0f);
								m_animationCurve.SmoothTangents(2, 0f);
								m_animationCurve.SmoothTangents(3, 0f);
								m_time = 0f;
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		public bool c5675c5caa5bb8ca4a4f77df0a6b4f3a8(Vector3 c68af8ed5e37e15b62b20e7502dbbd5a3, Vector3 c0b885a96d3f0d32f51ff3ec0d37d2900, float ceb8b3aecb62e595cd2d83736ab804281)
		{
			float distance = 10f;
			m_curveStartPosition = c68af8ed5e37e15b62b20e7502dbbd5a3;
			m_curveEndPosition = cdfea466b721ee9c3a777ecae775839c5(c68af8ed5e37e15b62b20e7502dbbd5a3, c0b885a96d3f0d32f51ff3ec0d37d2900, ceb8b3aecb62e595cd2d83736ab804281);
			Vector3 curveEndPosition = m_curveEndPosition;
			curveEndPosition.y = c0b885a96d3f0d32f51ff3ec0d37d2900.y;
			RaycastHit hitInfo;
			if (Physics.Raycast(curveEndPosition + Vector3.up * 2f, -Vector3.up, out hitInfo, distance, 1 << LayerMask.NameToLayer("Walkable")))
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
				m_curveEndPosition.y = hitInfo.point.y;
			}
			while (m_animationCurve.length > 0)
			{
				m_animationCurve.RemoveKey(0);
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				m_startKey.time = 0f;
				m_startKey.value = c68af8ed5e37e15b62b20e7502dbbd5a3.y;
				m_startKey.inTangent = 0f;
				m_startKey.outTangent = 0f;
				m_startKey.tangentMode = 10;
				m_animationCurve.AddKey(m_startKey);
				m_topKey.time = 0.1f;
				m_topKey.value = c0b885a96d3f0d32f51ff3ec0d37d2900.y + 10f;
				m_topKey.inTangent = 0f;
				m_topKey.outTangent = 0f;
				m_topKey.tangentMode = 10;
				m_animationCurve.AddKey(m_topKey);
				m_endKey.time = 1f;
				m_endKey.value = m_curveEndPosition.y;
				m_endKey.inTangent = 0f;
				m_endKey.outTangent = 0f;
				m_endKey.tangentMode = 10;
				m_animationCurve.AddKey(m_endKey);
				m_animationCurve.SmoothTangents(0, 0f);
				m_animationCurve.SmoothTangents(1, 0f);
				m_animationCurve.SmoothTangents(2, 0f);
				m_time = 0f;
				return true;
			}
		}

		public bool c77bcb24eeae986d72b2961310a2fc749(Vector3 c68af8ed5e37e15b62b20e7502dbbd5a3, Vector3 c0b885a96d3f0d32f51ff3ec0d37d2900, float ceb8b3aecb62e595cd2d83736ab804281)
		{
			m_curveStartPosition = c68af8ed5e37e15b62b20e7502dbbd5a3;
			m_curveEndPosition = c0b885a96d3f0d32f51ff3ec0d37d2900;
			while (m_animationCurve.length > 0)
			{
				m_animationCurve.RemoveKey(0);
			}
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
				m_startKey.time = 0f;
				m_startKey.value = c68af8ed5e37e15b62b20e7502dbbd5a3.y;
				m_startKey.inTangent = 0f;
				m_startKey.outTangent = 0f;
				m_startKey.tangentMode = 10;
				m_animationCurve.AddKey(m_startKey);
				m_topKey.time = 0.5f;
				m_topKey.value = c0b885a96d3f0d32f51ff3ec0d37d2900.y + 3f;
				m_topKey.inTangent = 0f;
				m_topKey.outTangent = 0f;
				m_topKey.tangentMode = 10;
				m_animationCurve.AddKey(m_topKey);
				m_endKey.time = 1f;
				m_endKey.value = m_curveEndPosition.y;
				m_endKey.inTangent = 0f;
				m_endKey.outTangent = 0f;
				m_endKey.tangentMode = 10;
				m_animationCurve.AddKey(m_endKey);
				m_animationCurve.SmoothTangents(0, 0f);
				m_animationCurve.SmoothTangents(1, 0f);
				m_animationCurve.SmoothTangents(2, 0f);
				m_time = 0f;
				return true;
			}
		}

		public bool cec13c99f505a1259251e1a9d93313b6c(Vector3 c68af8ed5e37e15b62b20e7502dbbd5a3, Vector3 c0b885a96d3f0d32f51ff3ec0d37d2900, float ceb8b3aecb62e595cd2d83736ab804281)
		{
			m_curveStartPosition = c68af8ed5e37e15b62b20e7502dbbd5a3;
			m_curveEndPosition = c0b885a96d3f0d32f51ff3ec0d37d2900;
			while (m_animationCurve.length > 0)
			{
				m_animationCurve.RemoveKey(0);
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
				m_startKey.time = 0f;
				m_startKey.value = c68af8ed5e37e15b62b20e7502dbbd5a3.y;
				m_startKey.inTangent = 0f;
				m_startKey.outTangent = 0f;
				m_startKey.tangentMode = 10;
				m_animationCurve.AddKey(m_startKey);
				m_topKey.time = 0.5f;
				m_topKey.value = c0b885a96d3f0d32f51ff3ec0d37d2900.y + 1f;
				m_topKey.inTangent = 0f;
				m_topKey.outTangent = 0f;
				m_topKey.tangentMode = 10;
				m_animationCurve.AddKey(m_topKey);
				m_endKey.time = 1f;
				m_endKey.value = m_curveEndPosition.y;
				m_endKey.inTangent = 0f;
				m_endKey.outTangent = 0f;
				m_endKey.tangentMode = 10;
				m_animationCurve.AddKey(m_endKey);
				m_animationCurve.SmoothTangents(0, 0f);
				m_animationCurve.SmoothTangents(1, 0f);
				m_animationCurve.SmoothTangents(2, 0f);
				m_time = 0f;
				return true;
			}
		}

		public Vector3 c848b83091aec1d2f4e6a0b802aeab3f6(float cad9f703d862495149cd6bddd080f050b)
		{
			Vector3 result = Vector3.Lerp(m_curveStartPosition, m_curveEndPosition, cad9f703d862495149cd6bddd080f050b);
			result.y = m_animationCurve.Evaluate(cad9f703d862495149cd6bddd080f050b);
			return result;
		}

		public bool Update(float deltaTime, float speed, out Vector3 newPosition)
		{
			if (speed <= 0f)
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
						newPosition = m_curveStartPosition;
						return false;
					}
				}
			}
			m_time += deltaTime;
			Vector3 vector = m_curveEndPosition - m_curveStartPosition;
			vector.y = 0f;
			float magnitude = vector.magnitude;
			if (magnitude <= float.Epsilon)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						newPosition = m_curveStartPosition;
						return false;
					}
				}
			}
			float num = m_time * speed / magnitude;
			if (num <= 0f)
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						newPosition = m_curveStartPosition;
						return false;
					}
				}
			}
			if (num >= 1f)
			{
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						newPosition = m_curveEndPosition;
						return true;
					}
				}
			}
			newPosition = c848b83091aec1d2f4e6a0b802aeab3f6(num);
			return false;
		}

		public void cf5df02b4a23539710208f8c70041faaa()
		{
			int num = 64;
			for (int i = 0; i < num; i++)
			{
				Debug.c01037ade1f1152c7345e14ef90726aba(c848b83091aec1d2f4e6a0b802aeab3f6((float)i / (float)num), c848b83091aec1d2f4e6a0b802aeab3f6((float)(i + 1) / (float)num), Color.green);
			}
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
				return;
			}
		}
	}

	private static readonly AIServiceCurve s_instance = new AIServiceCurve();

	public static AIServiceCurve c5ee19dc8d4cccf5ae2de225410458b86
	{
		get
		{
			return s_instance;
		}
	}

	public bool ca25ef68488c936a066765fa72cc6878d(Entity c5d720f6d007abb0c4a21d6a654e405bb, Vector3 c68af8ed5e37e15b62b20e7502dbbd5a3, Vector3 c0b885a96d3f0d32f51ff3ec0d37d2900, float c716bd6af12c0c2d616fc8ad553e3aa4d, float c541f06fd0d96bf5e41bf135ddcfbba42, float c649666f364a85335d6fee0596eb04cf3, float ceb8b3aecb62e595cd2d83736ab804281 = 1.5f)
	{
		if (c5d720f6d007abb0c4a21d6a654e405bb == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		float sqrMagnitude = (c0b885a96d3f0d32f51ff3ec0d37d2900 - c68af8ed5e37e15b62b20e7502dbbd5a3).sqrMagnitude;
		if (sqrMagnitude > c541f06fd0d96bf5e41bf135ddcfbba42 * c541f06fd0d96bf5e41bf135ddcfbba42)
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
		if (sqrMagnitude < c716bd6af12c0c2d616fc8ad553e3aa4d * c716bd6af12c0c2d616fc8ad553e3aa4d)
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
		Vector3 c0b885a96d3f0d32f51ff3ec0d37d2901 = Curve.cdfea466b721ee9c3a777ecae775839c5(c68af8ed5e37e15b62b20e7502dbbd5a3, c0b885a96d3f0d32f51ff3ec0d37d2900, ceb8b3aecb62e595cd2d83736ab804281);
		if (Mathf.Abs(c0b885a96d3f0d32f51ff3ec0d37d2900.y - c68af8ed5e37e15b62b20e7502dbbd5a3.y) > c649666f364a85335d6fee0596eb04cf3)
		{
			while (true)
			{
				switch (5)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		if (Mathf.Abs(c0b885a96d3f0d32f51ff3ec0d37d2900.y - c0b885a96d3f0d32f51ff3ec0d37d2901.y) > c649666f364a85335d6fee0596eb04cf3)
		{
			while (true)
			{
				switch (2)
				{
				case 0:
					break;
				default:
					return false;
				}
			}
		}
		if (Mathf.Abs(c68af8ed5e37e15b62b20e7502dbbd5a3.y - c0b885a96d3f0d32f51ff3ec0d37d2901.y) > c649666f364a85335d6fee0596eb04cf3)
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
		if (AIServicePathfinding.c5ee19dc8d4cccf5ae2de225410458b86 == null)
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
		NavMeshAgent navMeshAgent = c5d720f6d007abb0c4a21d6a654e405bb.cb7fad43afb51f83d8698379136b46e95();
		if (navMeshAgent == c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e)
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
		if (AIServicePathfinding.c5ee19dc8d4cccf5ae2de225410458b86.cad1e454abed62b0e36d73bc6cd26c0a5(navMeshAgent, c0b885a96d3f0d32f51ff3ec0d37d2901))
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
		return true;
	}

	public Curve cd440a8b2fe2065c9cd33808285d3d764(ECurveType c8f16261f68d31e8c195cc96a57fa8fe5, Vector3 cd51dced8c9a4077c2675a5ce5f62fa9d, Vector3 c0b885a96d3f0d32f51ff3ec0d37d2900, float ceb8b3aecb62e595cd2d83736ab804281 = 1.5f)
	{
		Curve curve = new Curve();
		if (curve == null)
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.AI, "Could not allocate curve");
					return null;
				}
			}
		}
		if (c8f16261f68d31e8c195cc96a57fa8fe5 == ECurveType.EJumpCurve)
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
			if (curve.c8a3c82bab0e64a4d2e673575bedb5d79(cd51dced8c9a4077c2675a5ce5f62fa9d, c0b885a96d3f0d32f51ff3ec0d37d2900, ceb8b3aecb62e595cd2d83736ab804281))
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						return curve;
					}
				}
			}
		}
		if (c8f16261f68d31e8c195cc96a57fa8fe5 == ECurveType.ESpitCurve)
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
			if (curve.c1660b88d9fa326a439baf51c839d7e12(cd51dced8c9a4077c2675a5ce5f62fa9d, c0b885a96d3f0d32f51ff3ec0d37d2900, ceb8b3aecb62e595cd2d83736ab804281))
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						return curve;
					}
				}
			}
		}
		if (c8f16261f68d31e8c195cc96a57fa8fe5 == ECurveType.ESpiderWidommakeJumpCurve)
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
			if (curve.c28285bc14fd5bc5688495fc3cda008c4(cd51dced8c9a4077c2675a5ce5f62fa9d, c0b885a96d3f0d32f51ff3ec0d37d2900, ceb8b3aecb62e595cd2d83736ab804281))
			{
				while (true)
				{
					switch (3)
					{
					case 0:
						break;
					default:
						return curve;
					}
				}
			}
		}
		if (c8f16261f68d31e8c195cc96a57fa8fe5 == ECurveType.EIcePickAttackFlyingCurve)
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
			if (curve.cbaea5f2a30fc23ddb48bf662f1329e17(cd51dced8c9a4077c2675a5ce5f62fa9d, c0b885a96d3f0d32f51ff3ec0d37d2900, ceb8b3aecb62e595cd2d83736ab804281))
			{
				while (true)
				{
					switch (4)
					{
					case 0:
						break;
					default:
						return curve;
					}
				}
			}
		}
		if (c8f16261f68d31e8c195cc96a57fa8fe5 == ECurveType.EThrowAxeCurve)
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
			if (curve.c474bb98602cf4117dd9fef4be9ed7def(cd51dced8c9a4077c2675a5ce5f62fa9d, c0b885a96d3f0d32f51ff3ec0d37d2900, ceb8b3aecb62e595cd2d83736ab804281))
			{
				while (true)
				{
					switch (2)
					{
					case 0:
						break;
					default:
						return curve;
					}
				}
			}
		}
		if (c8f16261f68d31e8c195cc96a57fa8fe5 == ECurveType.EKnoxxJetAttackCurve)
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
			if (curve.c80404dd57fa71b991a3eb595a27a6900(cd51dced8c9a4077c2675a5ce5f62fa9d, c0b885a96d3f0d32f51ff3ec0d37d2900, ceb8b3aecb62e595cd2d83736ab804281))
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						return curve;
					}
				}
			}
		}
		if (c8f16261f68d31e8c195cc96a57fa8fe5 == ECurveType.EKnoxxMissileFlyingCurve)
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
			if (curve.c5675c5caa5bb8ca4a4f77df0a6b4f3a8(cd51dced8c9a4077c2675a5ce5f62fa9d, c0b885a96d3f0d32f51ff3ec0d37d2900, ceb8b3aecb62e595cd2d83736ab804281))
			{
				while (true)
				{
					switch (7)
					{
					case 0:
						break;
					default:
						return curve;
					}
				}
			}
		}
		return null;
	}
}
