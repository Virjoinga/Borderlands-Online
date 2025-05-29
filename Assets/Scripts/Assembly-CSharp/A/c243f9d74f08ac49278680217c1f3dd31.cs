using UnityEngine;

namespace A
{
	internal class c243f9d74f08ac49278680217c1f3dd31 : c415a520747e01b34a2dadc2d08ed2231, InstantiateManager.InstanciationClient
	{
		public c243f9d74f08ac49278680217c1f3dd31(GameObject cebae66039aadeac8deb1211786332a72)
			: base(cebae66039aadeac8deb1211786332a72)
		{
		}

		public bool c1a84901a0a9ec83a0000feb026941d27(Vector3 cf312a174496712827bd0ffaff85b09ea)
		{
			Terrain component = base.Obj.GetComponent<Terrain>();
			Vector3 position = component.GetPosition();
			Vector3 size = component.terrainData.size;
			bool result = false;
			if (cf312a174496712827bd0ffaff85b09ea.x >= position.x)
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
				if (cf312a174496712827bd0ffaff85b09ea.x <= position.x + size.x)
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
					if (cf312a174496712827bd0ffaff85b09ea.z >= position.z)
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
						if (cf312a174496712827bd0ffaff85b09ea.z <= position.z + size.z)
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
							if (cf312a174496712827bd0ffaff85b09ea.y >= position.y - 3f)
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
								result = true;
							}
						}
					}
				}
			}
			return result;
		}

		public Vector3 ce5b35972ecc0b8aa0cf3aafd5d587be8()
		{
			return base.Obj.GetComponent<Terrain>().GetPosition();
		}

		public virtual void OnInstanciate(GameObject instance, InstantiateManager.SpawnRequest request)
		{
		}
	}
}
