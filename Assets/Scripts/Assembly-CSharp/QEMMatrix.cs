using A;
using Core;
using UnityEngine;

public class QEMMatrix
{
	public static QEMMatrix s_tempQEMMatrix0;

	public static QEMMatrix s_tempQEMMatrix1;

	public static QEMMatrix s_tempQEMMatrix2;

	public static int s_n = 3;

	private QEMMatrixNxN m_A;

	private QEMVectorN m_b;

	private float m_c;

	public QEMMatrix()
	{
		m_A = new QEMMatrixNxN();
		m_b = new QEMVectorN();
	}

	public static void ccc9d3a38966dc10fedb531ea17d24611(int cb413b63b20e71ae5c504b03471480e2a)
	{
		if (cb413b63b20e71ae5c504b03471480e2a < 3)
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
			DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Graphics, "size < 3");
			cb413b63b20e71ae5c504b03471480e2a = 3;
		}
		QEMVectorN.s_n = cb413b63b20e71ae5c504b03471480e2a;
		s_n = cb413b63b20e71ae5c504b03471480e2a;
		QEMVectorN.s_tempVector = new QEMVectorN();
		s_tempQEMMatrix0 = new QEMMatrix();
		s_tempQEMMatrix1 = new QEMMatrix();
		s_tempQEMMatrix2 = new QEMMatrix();
	}

	public static void c9172684ab57085e2a77c2a3af69cb426(QEMMatrix cb6f02e44368ea9c6d908935668ddf449, QEMMatrix cdec7efe40b9cb86019555d0e14182695, ref QEMMatrix c7346be4b77404fdecfd50fc08d49c7e3)
	{
		QEMMatrixNxN.c9172684ab57085e2a77c2a3af69cb426(cb6f02e44368ea9c6d908935668ddf449.m_A, cdec7efe40b9cb86019555d0e14182695.m_A, ref c7346be4b77404fdecfd50fc08d49c7e3.m_A);
		QEMVectorN.c9172684ab57085e2a77c2a3af69cb426(cb6f02e44368ea9c6d908935668ddf449.m_b, cdec7efe40b9cb86019555d0e14182695.m_b, ref c7346be4b77404fdecfd50fc08d49c7e3.m_b);
		c7346be4b77404fdecfd50fc08d49c7e3.m_c = cb6f02e44368ea9c6d908935668ddf449.m_c + cdec7efe40b9cb86019555d0e14182695.m_c;
	}

	public void c9172684ab57085e2a77c2a3af69cb426(QEMMatrix cdec7efe40b9cb86019555d0e14182695)
	{
		m_A.c9172684ab57085e2a77c2a3af69cb426(cdec7efe40b9cb86019555d0e14182695.m_A);
		m_b.c9172684ab57085e2a77c2a3af69cb426(cdec7efe40b9cb86019555d0e14182695.m_b);
		m_c += cdec7efe40b9cb86019555d0e14182695.m_c;
	}

	public void ccb0d23031f36ef9d9e72c797d8c717e4(float cc6aae3613e8118db3849f77569032076)
	{
		m_A.ccb0d23031f36ef9d9e72c797d8c717e4(cc6aae3613e8118db3849f77569032076);
		m_b.ccb0d23031f36ef9d9e72c797d8c717e4(cc6aae3613e8118db3849f77569032076);
		m_c *= cc6aae3613e8118db3849f77569032076;
	}

	public float cadb490a5154195ab279210bc338e9d5a(QEMVectorN cf312a174496712827bd0ffaff85b09ea)
	{
		m_A.ccb0d23031f36ef9d9e72c797d8c717e4(cf312a174496712827bd0ffaff85b09ea, ref QEMVectorN.s_tempVector);
		float num = QEMVectorN.c73d241e02d022b2c3a9788b4039df0ef(QEMVectorN.s_tempVector, cf312a174496712827bd0ffaff85b09ea);
		num += 2f * QEMVectorN.c73d241e02d022b2c3a9788b4039df0ef(cf312a174496712827bd0ffaff85b09ea, m_b);
		return num + m_c;
	}

	public void c92eb2231f43bdb532bac8326ea4b2f1b()
	{
		m_A.c92eb2231f43bdb532bac8326ea4b2f1b();
		m_b.c92eb2231f43bdb532bac8326ea4b2f1b();
		m_c = 0f;
	}

	public void c8c08e5af03dde832c7190b0eccb38a93(Vector3 c754f8dcd7f14fe4f8f8b93a36691e7fe, float cf0ecbb9b13151932b8293691a84d1c24)
	{
		float x = c754f8dcd7f14fe4f8f8b93a36691e7fe.x;
		float y = c754f8dcd7f14fe4f8f8b93a36691e7fe.y;
		float z = c754f8dcd7f14fe4f8f8b93a36691e7fe.z;
		m_A.m_AC.set_cbbf1d0dd5bd18c03ef13e60bff03ebc0(0, x * x);
		m_A.m_AC.set_cbbf1d0dd5bd18c03ef13e60bff03ebc0(1, x * y);
		m_A.m_AC.set_cbbf1d0dd5bd18c03ef13e60bff03ebc0(2, y * y);
		m_A.m_AC.set_cbbf1d0dd5bd18c03ef13e60bff03ebc0(3, x * z);
		m_A.m_AC.set_cbbf1d0dd5bd18c03ef13e60bff03ebc0(4, y * z);
		m_A.m_AC.set_cbbf1d0dd5bd18c03ef13e60bff03ebc0(5, z * z);
		m_A.m_diagonal = 1f;
		Vector3 vector = cf0ecbb9b13151932b8293691a84d1c24 * c754f8dcd7f14fe4f8f8b93a36691e7fe;
		m_b.set_cbbf1d0dd5bd18c03ef13e60bff03ebc0(0, vector.x);
		m_b.set_cbbf1d0dd5bd18c03ef13e60bff03ebc0(1, vector.y);
		m_b.set_cbbf1d0dd5bd18c03ef13e60bff03ebc0(2, vector.z);
		m_c = cf0ecbb9b13151932b8293691a84d1c24 * cf0ecbb9b13151932b8293691a84d1c24;
	}

	private bool c9262bd8c5b2b56aa5daa96d5210ef0a8(Matrix4x4 ce496f2302aa3f83a2edca09168844502, float c46133d1809d6d3227e98e175cb2e7142)
	{
		float num = ce496f2302aa3f83a2edca09168844502.m00 * ce496f2302aa3f83a2edca09168844502.m11 * ce496f2302aa3f83a2edca09168844502.m22 * ce496f2302aa3f83a2edca09168844502.m33 + ce496f2302aa3f83a2edca09168844502.m01 * ce496f2302aa3f83a2edca09168844502.m12 * ce496f2302aa3f83a2edca09168844502.m23 * ce496f2302aa3f83a2edca09168844502.m30 + ce496f2302aa3f83a2edca09168844502.m02 * ce496f2302aa3f83a2edca09168844502.m13 * ce496f2302aa3f83a2edca09168844502.m20 * ce496f2302aa3f83a2edca09168844502.m31 + ce496f2302aa3f83a2edca09168844502.m03 * ce496f2302aa3f83a2edca09168844502.m10 * ce496f2302aa3f83a2edca09168844502.m21 * ce496f2302aa3f83a2edca09168844502.m32;
		num -= ce496f2302aa3f83a2edca09168844502.m03 * ce496f2302aa3f83a2edca09168844502.m12 * ce496f2302aa3f83a2edca09168844502.m21 * ce496f2302aa3f83a2edca09168844502.m30 + ce496f2302aa3f83a2edca09168844502.m13 * ce496f2302aa3f83a2edca09168844502.m22 * ce496f2302aa3f83a2edca09168844502.m31 * ce496f2302aa3f83a2edca09168844502.m00 + ce496f2302aa3f83a2edca09168844502.m23 * ce496f2302aa3f83a2edca09168844502.m32 * ce496f2302aa3f83a2edca09168844502.m01 * ce496f2302aa3f83a2edca09168844502.m10 + ce496f2302aa3f83a2edca09168844502.m33 * ce496f2302aa3f83a2edca09168844502.m02 * ce496f2302aa3f83a2edca09168844502.m11 * ce496f2302aa3f83a2edca09168844502.m20;
		num *= num;
		if (num > c46133d1809d6d3227e98e175cb2e7142)
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
		return false;
	}

	public bool c8c08e5af03dde832c7190b0eccb38a93(Vector3 c92796054b53538d6ad3ca14be8d69eb0, Vector3 c2aa9a45106c929d3e048f32dbf78d07c, Vector3 c6f4796f6a2ef00cf3477b31168a173e0, Vector3 c754f8dcd7f14fe4f8f8b93a36691e7fe, float ce8ed8d7732f2777e05bb1b3d9ec4cdb1, float c8f9895d6a77577b91c8439b84a3eecac, float cb8e7b9c66c68db79c4a931fb0727ee7d, int cb8e962c8bc667a610ba2ab548fa78ab6)
	{
		Matrix4x4 c36964cf41281414170f34ee68bef6c = default(Matrix4x4);
		c1c97c128a26876efad0545c5aa70dfd1.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
		c36964cf41281414170f34ee68bef6c.SetRow(0, new Vector4(c92796054b53538d6ad3ca14be8d69eb0.x, c92796054b53538d6ad3ca14be8d69eb0.y, c92796054b53538d6ad3ca14be8d69eb0.z, 1f));
		c36964cf41281414170f34ee68bef6c.SetRow(1, new Vector4(c2aa9a45106c929d3e048f32dbf78d07c.x, c2aa9a45106c929d3e048f32dbf78d07c.y, c2aa9a45106c929d3e048f32dbf78d07c.z, 1f));
		c36964cf41281414170f34ee68bef6c.SetRow(2, new Vector4(c6f4796f6a2ef00cf3477b31168a173e0.x, c6f4796f6a2ef00cf3477b31168a173e0.y, c6f4796f6a2ef00cf3477b31168a173e0.z, 1f));
		c36964cf41281414170f34ee68bef6c.SetRow(3, new Vector4(c754f8dcd7f14fe4f8f8b93a36691e7fe.x, c754f8dcd7f14fe4f8f8b93a36691e7fe.y, c754f8dcd7f14fe4f8f8b93a36691e7fe.z, 0f));
		Vector4 vector = c36964cf41281414170f34ee68bef6c.inverse * new Vector4(ce8ed8d7732f2777e05bb1b3d9ec4cdb1, c8f9895d6a77577b91c8439b84a3eecac, cb8e7b9c66c68db79c4a931fb0727ee7d, 0f);
		float x = vector.x;
		float y = vector.y;
		float z = vector.z;
		float w = vector.w;
		ref QEMMatrix3x3 aC = ref m_A.m_AC;
		int c5612a459a84ffdb41c885401433cd62d;
		int c5612a459a84ffdb41c885401433cd62d2 = (c5612a459a84ffdb41c885401433cd62d = 0);
		float num = aC.get_cbbf1d0dd5bd18c03ef13e60bff03ebc0(c5612a459a84ffdb41c885401433cd62d);
		aC.set_cbbf1d0dd5bd18c03ef13e60bff03ebc0(c5612a459a84ffdb41c885401433cd62d2, num + x * x);
		ref QEMMatrix3x3 aC2 = ref m_A.m_AC;
		int c5612a459a84ffdb41c885401433cd62d3 = (c5612a459a84ffdb41c885401433cd62d = 1);
		num = aC2.get_cbbf1d0dd5bd18c03ef13e60bff03ebc0(c5612a459a84ffdb41c885401433cd62d);
		aC2.set_cbbf1d0dd5bd18c03ef13e60bff03ebc0(c5612a459a84ffdb41c885401433cd62d3, num + x * y);
		ref QEMMatrix3x3 aC3 = ref m_A.m_AC;
		int c5612a459a84ffdb41c885401433cd62d4 = (c5612a459a84ffdb41c885401433cd62d = 2);
		num = aC3.get_cbbf1d0dd5bd18c03ef13e60bff03ebc0(c5612a459a84ffdb41c885401433cd62d);
		aC3.set_cbbf1d0dd5bd18c03ef13e60bff03ebc0(c5612a459a84ffdb41c885401433cd62d4, num + y * y);
		ref QEMMatrix3x3 aC4 = ref m_A.m_AC;
		int c5612a459a84ffdb41c885401433cd62d5 = (c5612a459a84ffdb41c885401433cd62d = 3);
		num = aC4.get_cbbf1d0dd5bd18c03ef13e60bff03ebc0(c5612a459a84ffdb41c885401433cd62d);
		aC4.set_cbbf1d0dd5bd18c03ef13e60bff03ebc0(c5612a459a84ffdb41c885401433cd62d5, num + x * z);
		ref QEMMatrix3x3 aC5 = ref m_A.m_AC;
		int c5612a459a84ffdb41c885401433cd62d6 = (c5612a459a84ffdb41c885401433cd62d = 4);
		num = aC5.get_cbbf1d0dd5bd18c03ef13e60bff03ebc0(c5612a459a84ffdb41c885401433cd62d);
		aC5.set_cbbf1d0dd5bd18c03ef13e60bff03ebc0(c5612a459a84ffdb41c885401433cd62d6, num + y * z);
		ref QEMMatrix3x3 aC6 = ref m_A.m_AC;
		int c5612a459a84ffdb41c885401433cd62d7 = (c5612a459a84ffdb41c885401433cd62d = 5);
		num = aC6.get_cbbf1d0dd5bd18c03ef13e60bff03ebc0(c5612a459a84ffdb41c885401433cd62d);
		aC6.set_cbbf1d0dd5bd18c03ef13e60bff03ebc0(c5612a459a84ffdb41c885401433cd62d7, num + z * z);
		m_A.m_AB.c09d84353c41f841631b72e2ed955fefc(cb8e962c8bc667a610ba2ab548fa78ab6, new Vector3(0f - x, 0f - y, 0f - z));
		QEMVectorN b;
		QEMVectorN qEMVectorN = (b = m_b);
		int c5612a459a84ffdb41c885401433cd62d8 = (c5612a459a84ffdb41c885401433cd62d = 0);
		num = b.get_cbbf1d0dd5bd18c03ef13e60bff03ebc0(c5612a459a84ffdb41c885401433cd62d);
		qEMVectorN.set_cbbf1d0dd5bd18c03ef13e60bff03ebc0(c5612a459a84ffdb41c885401433cd62d8, num + w * x);
		QEMVectorN b2;
		QEMVectorN qEMVectorN2 = (b2 = m_b);
		int c5612a459a84ffdb41c885401433cd62d9 = (c5612a459a84ffdb41c885401433cd62d = 1);
		num = b2.get_cbbf1d0dd5bd18c03ef13e60bff03ebc0(c5612a459a84ffdb41c885401433cd62d);
		qEMVectorN2.set_cbbf1d0dd5bd18c03ef13e60bff03ebc0(c5612a459a84ffdb41c885401433cd62d9, num + w * y);
		QEMVectorN b3;
		QEMVectorN qEMVectorN3 = (b3 = m_b);
		int c5612a459a84ffdb41c885401433cd62d10 = (c5612a459a84ffdb41c885401433cd62d = 2);
		num = b3.get_cbbf1d0dd5bd18c03ef13e60bff03ebc0(c5612a459a84ffdb41c885401433cd62d);
		qEMVectorN3.set_cbbf1d0dd5bd18c03ef13e60bff03ebc0(c5612a459a84ffdb41c885401433cd62d10, num + w * z);
		m_b.set_cbbf1d0dd5bd18c03ef13e60bff03ebc0(cb8e962c8bc667a610ba2ab548fa78ab6 + 3, 0f - w);
		m_c += w * w;
		return true;
	}

	public bool c8c08e5af03dde832c7190b0eccb38a93(float c7c80fef79e3c330ae5014832d44fcd28, int cb8e962c8bc667a610ba2ab548fa78ab6)
	{
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		m_A.m_AB.c09d84353c41f841631b72e2ed955fefc(cb8e962c8bc667a610ba2ab548fa78ab6, new Vector3(0f - num, 0f - num2, 0f - num3));
		m_b.set_cbbf1d0dd5bd18c03ef13e60bff03ebc0(cb8e962c8bc667a610ba2ab548fa78ab6 + 3, 0f - c7c80fef79e3c330ae5014832d44fcd28);
		m_c += c7c80fef79e3c330ae5014832d44fcd28 * c7c80fef79e3c330ae5014832d44fcd28;
		return true;
	}

	public bool c37752a4bccdb3f5868cae3dedd2038d0(ref QEMVectorN ce46da373f90404d63f954b1e23bb3600)
	{
		Vector3 c36964cf41281414170f34ee68bef6c = default(Vector3);
		ced819f907a00cbfa6286c200338b520d.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
		QEMMatrix3x3 qEMMatrix3x = QEMMatrix3x3.c9172684ab57085e2a77c2a3af69cb426(m_A.m_AC, m_A.m_AB.c2010e78adaf6cb4cd6b8c76338725122().ccb0d23031f36ef9d9e72c797d8c717e4(-1f / m_A.m_diagonal));
		float f = qEMMatrix3x.c0dcfe41f57932a16dbc85c83daf47296();
		if (Mathf.Abs(f) > 1E-05f)
		{
			while (true)
			{
				switch (3)
				{
				case 0:
					break;
				default:
				{
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					m_b.ccb0d23031f36ef9d9e72c797d8c717e4(-1f);
					Vector3 cf312a174496712827bd0ffaff85b09ea = m_A.m_AB.ccb0d23031f36ef9d9e72c797d8c717e4(m_b.m_b2) * (-1f / m_A.m_diagonal) + m_b.m_b1;
					c36964cf41281414170f34ee68bef6c = qEMMatrix3x.c4463fa705520e7ae2098551bae26ad78().ccb0d23031f36ef9d9e72c797d8c717e4(cf312a174496712827bd0ffaff85b09ea);
					m_A.m_AB.ccb0d23031f36ef9d9e72c797d8c717e4(c36964cf41281414170f34ee68bef6c, ref QEMVectorN.s_tempVector.m_b2);
					QEMVectorN.s_tempVector.m_b2.ccb0d23031f36ef9d9e72c797d8c717e4(-1f);
					QEMVectorAttribute.c9172684ab57085e2a77c2a3af69cb426(m_b.m_b2, QEMVectorN.s_tempVector.m_b2, ref ce46da373f90404d63f954b1e23bb3600.m_b2);
					ce46da373f90404d63f954b1e23bb3600.m_b2.ccb0d23031f36ef9d9e72c797d8c717e4(1f / m_A.m_diagonal);
					ce46da373f90404d63f954b1e23bb3600.m_b1 = c36964cf41281414170f34ee68bef6c;
					m_b.ccb0d23031f36ef9d9e72c797d8c717e4(-1f);
					return true;
				}
				}
			}
		}
		return false;
	}
}
