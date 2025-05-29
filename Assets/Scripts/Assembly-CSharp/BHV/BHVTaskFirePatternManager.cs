using UnityEngine;

namespace BHV
{
	public sealed class BHVTaskFirePatternManager
	{
		private float c23144d4b849283cd12fc6407ffc6f9ec;

		private float cc39412ddcc3a92df6fd6b08736573f2a;

		private float c3d3ba11ba7e7a38edec52d1a6b093100;

		public void Start(float fireDuration, float idleDuration, AIInventory inventory)
		{
			c23144d4b849283cd12fc6407ffc6f9ec = 0f;
			cc39412ddcc3a92df6fd6b08736573f2a = fireDuration;
			c3d3ba11ba7e7a38edec52d1a6b093100 = idleDuration;
		}

		public void Update(float deltaTime, AIInventory inventory, Vector3 shootFrom, Vector3 shootAt)
		{
			c23144d4b849283cd12fc6407ffc6f9ec += deltaTime;
			if (c23144d4b849283cd12fc6407ffc6f9ec <= cc39412ddcc3a92df6fd6b08736573f2a)
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
						c1ce589e4f7a15f1a76558a9625f44b2b(inventory, shootFrom, shootAt);
						return;
					}
				}
			}
			if (!(c23144d4b849283cd12fc6407ffc6f9ec >= cc39412ddcc3a92df6fd6b08736573f2a + c3d3ba11ba7e7a38edec52d1a6b093100))
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
				c23144d4b849283cd12fc6407ffc6f9ec -= cc39412ddcc3a92df6fd6b08736573f2a + c3d3ba11ba7e7a38edec52d1a6b093100;
				return;
			}
		}

		public void c1ce589e4f7a15f1a76558a9625f44b2b(AIInventory cfcf820426a6e568b08865de5afa27d4e, Vector3 cfe5f17d3f3999f7b2948954cc08fe3e7, Vector3 c2eb08f28635c6ef3036bc27e6a90a51b)
		{
		}
	}
}
