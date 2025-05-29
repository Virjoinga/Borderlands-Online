using System;
using System.IO;
using A;
using ExitGames.Client.Photon;
using UnityEngine;

internal static class CustomTypes
{
	internal static void c57e4d4cd41f3be21d7e24a71aa08c6ba()
	{
		PhotonPeer.RegisterType(Type.GetTypeFromHandle(cb20d5b1cac70c36aa2ed87aa83f700b2.cc1720d05c75832f704b87474932341c3()), 87, c7198907aa8097e42d5309b8f0620eab7, cedbe6915fbdcd9cb7894ff430679dff9);
		PhotonPeer.RegisterType(Type.GetTypeFromHandle(c552101a5d79ee96b2db16006f74a170d.cc1720d05c75832f704b87474932341c3()), 86, cf77a4b04fc53e3bcb4470a9619794ab3, c3b1f29a5d782a1cd6716eb8201c9a431);
		PhotonPeer.RegisterType(Type.GetTypeFromHandle(c8ba5595b1636dc4d051bedb2a594aba2.cc1720d05c75832f704b87474932341c3()), 84, c229e333613233d912271248f046d878b, c752d335ca22e1350cf149a03656deb41);
		PhotonPeer.RegisterType(Type.GetTypeFromHandle(c9214d8ea34775364ab2dad30f0086c0f.cc1720d05c75832f704b87474932341c3()), 81, ce629c566882df99db0864b13c166bd05, c989e554aaa62cc4e99d49beaccc72de3);
		PhotonPeer.RegisterType(Type.GetTypeFromHandle(ca6c9a067d647bca38ad26420c7729e7a.cc1720d05c75832f704b87474932341c3()), 80, c709f92c4109768dfaa22dfb8a020565a, c33f3f0e4d4354e3b6195d0515b87ae6e);
	}

	private static byte[] c229e333613233d912271248f046d878b(object cb990e5ec7464fd4f8496073a94f069c1)
	{
		Transform transform = (Transform)cb990e5ec7464fd4f8496073a94f069c1;
		Vector3[] array = cf3959069936a01183409b8e4d8027897.c0a0cdf4a196914163f7334d9b0781a04(2);
		array[0] = transform.position;
		array[1] = transform.eulerAngles;
		return Protocol.Serialize(array);
	}

	private static object c752d335ca22e1350cf149a03656deb41(byte[] c947cdb5f4e2fa4e71242bc11adbdd0b0)
	{
		return Protocol.Deserialize(c947cdb5f4e2fa4e71242bc11adbdd0b0);
	}

	private static byte[] cf77a4b04fc53e3bcb4470a9619794ab3(object cb990e5ec7464fd4f8496073a94f069c1)
	{
		Vector3 vector = (Vector3)cb990e5ec7464fd4f8496073a94f069c1;
		int targetOffset = 0;
		byte[] array = ce2f159fe707a376b497f666c368f15ed.c0a0cdf4a196914163f7334d9b0781a04(12);
		Protocol.Serialize(vector.x, array, ref targetOffset);
		Protocol.Serialize(vector.y, array, ref targetOffset);
		Protocol.Serialize(vector.z, array, ref targetOffset);
		return array;
	}

	private static object c3b1f29a5d782a1cd6716eb8201c9a431(byte[] caaeca6e35667f32ce3da8be21b2cc4b8)
	{
		Vector3 c36964cf41281414170f34ee68bef6c = default(Vector3);
		ced819f907a00cbfa6286c200338b520d.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
		int offset = 0;
		Protocol.Deserialize(out c36964cf41281414170f34ee68bef6c.x, caaeca6e35667f32ce3da8be21b2cc4b8, ref offset);
		Protocol.Deserialize(out c36964cf41281414170f34ee68bef6c.y, caaeca6e35667f32ce3da8be21b2cc4b8, ref offset);
		Protocol.Deserialize(out c36964cf41281414170f34ee68bef6c.z, caaeca6e35667f32ce3da8be21b2cc4b8, ref offset);
		return c36964cf41281414170f34ee68bef6c;
	}

	private static byte[] c7198907aa8097e42d5309b8f0620eab7(object cb990e5ec7464fd4f8496073a94f069c1)
	{
		Vector2 vector = (Vector2)cb990e5ec7464fd4f8496073a94f069c1;
		MemoryStream memoryStream = new MemoryStream(8);
		memoryStream.Write(BitConverter.GetBytes(vector.x), 0, 4);
		memoryStream.Write(BitConverter.GetBytes(vector.y), 0, 4);
		return memoryStream.ToArray();
	}

	private static object cedbe6915fbdcd9cb7894ff430679dff9(byte[] caaeca6e35667f32ce3da8be21b2cc4b8)
	{
		Vector2 c36964cf41281414170f34ee68bef6c = default(Vector2);
		c9ef4b269732f6eff7b215dc57e5e252c.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
		c36964cf41281414170f34ee68bef6c.x = BitConverter.ToSingle(caaeca6e35667f32ce3da8be21b2cc4b8, 0);
		c36964cf41281414170f34ee68bef6c.y = BitConverter.ToSingle(caaeca6e35667f32ce3da8be21b2cc4b8, 4);
		return c36964cf41281414170f34ee68bef6c;
	}

	private static byte[] ce629c566882df99db0864b13c166bd05(object cebae66039aadeac8deb1211786332a72)
	{
		Quaternion quaternion = (Quaternion)cebae66039aadeac8deb1211786332a72;
		MemoryStream memoryStream = new MemoryStream(16);
		memoryStream.Write(BitConverter.GetBytes(quaternion.w), 0, 4);
		memoryStream.Write(BitConverter.GetBytes(quaternion.x), 0, 4);
		memoryStream.Write(BitConverter.GetBytes(quaternion.y), 0, 4);
		memoryStream.Write(BitConverter.GetBytes(quaternion.z), 0, 4);
		return memoryStream.ToArray();
	}

	private static object c989e554aaa62cc4e99d49beaccc72de3(byte[] caaeca6e35667f32ce3da8be21b2cc4b8)
	{
		Quaternion c36964cf41281414170f34ee68bef6c = default(Quaternion);
		c3fcb02b39b06d9650ad27b553e57f6dc.c61f14727dc2b99c6844722ff39d0543a(ref c36964cf41281414170f34ee68bef6c);
		c36964cf41281414170f34ee68bef6c.w = BitConverter.ToSingle(caaeca6e35667f32ce3da8be21b2cc4b8, 0);
		c36964cf41281414170f34ee68bef6c.x = BitConverter.ToSingle(caaeca6e35667f32ce3da8be21b2cc4b8, 4);
		c36964cf41281414170f34ee68bef6c.y = BitConverter.ToSingle(caaeca6e35667f32ce3da8be21b2cc4b8, 8);
		c36964cf41281414170f34ee68bef6c.z = BitConverter.ToSingle(caaeca6e35667f32ce3da8be21b2cc4b8, 12);
		return c36964cf41281414170f34ee68bef6c;
	}

	private static byte[] c709f92c4109768dfaa22dfb8a020565a(object cb990e5ec7464fd4f8496073a94f069c1)
	{
		int c29a834d12d3895f5680e69a30e6cd9a = ((PhotonPlayer)cb990e5ec7464fd4f8496073a94f069c1).c29a834d12d3895f5680e69a30e6cd9a3;
		return BitConverter.GetBytes(c29a834d12d3895f5680e69a30e6cd9a);
	}

	private static object c33f3f0e4d4354e3b6195d0515b87ae6e(byte[] caaeca6e35667f32ce3da8be21b2cc4b8)
	{
		int key = BitConverter.ToInt32(caaeca6e35667f32ce3da8be21b2cc4b8, 0);
		if (PhotonNetwork.networkingPeer.mActors.ContainsKey(key))
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
					return PhotonNetwork.networkingPeer.mActors[key];
				}
			}
		}
		return null;
	}
}
