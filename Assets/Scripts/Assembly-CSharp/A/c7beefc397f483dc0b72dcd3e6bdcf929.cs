using UnityEngine;
using pumpkin.display;
using pumpkin.swf;

namespace A
{
	public class c7beefc397f483dc0b72dcd3e6bdcf929 : ceaa621c569baf012ce466a5c368364e3
	{
		protected Texture c53573cc4dff493c29715cadfe2300f0d;

		protected Material c4ee12633e2794f3e5c49ec487353212e;

		protected Rect c4dffe185817624b1eb40fa8c986e9d43;

		protected Rect c3f0e8163fe520a62fd4001f483261a58;

		protected pumpkin.display.Sprite c7dafa2645512cd06f2e411281f3dc2ae;

		protected float c92a2ffaad124bdbbc1520ebc4f56f3d2 = 1f;

		public virtual Texture cbab63f4e93c5dc56beab020324420ef2
		{
			get
			{
				return c53573cc4dff493c29715cadfe2300f0d;
			}
		}

		public virtual pumpkin.display.Sprite c1a06cef513f56d0885753120a79246cd
		{
			get
			{
				return c7dafa2645512cd06f2e411281f3dc2ae;
			}
		}

		public virtual float c2f5e208842730f75c8d5498004244d2a
		{
			get
			{
				return c92a2ffaad124bdbbc1520ebc4f56f3d2;
			}
			set
			{
				c92a2ffaad124bdbbc1520ebc4f56f3d2 = value;
			}
		}

		public override bool c150264a18c2cb408479d3f072cac8cc1
		{
			set
			{
				if (!cafbbef33d1cd0d1a2f0610a49f2aafad)
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
					if (value)
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
						cf832a91b2d0fc2c9ebf56240d5d0f6c8();
					}
				}
				base.c150264a18c2cb408479d3f072cac8cc1 = value;
			}
		}

		public c7beefc397f483dc0b72dcd3e6bdcf929()
		{
			c7dafa2645512cd06f2e411281f3dc2ae = new pumpkin.display.Sprite();
			c4ee12633e2794f3e5c49ec487353212e = new Material(TextureManager.baseBitmapShader);
		}

		public virtual void c533af2b08173b7c2e3e5405efc254ee3(Texture cf83e762e4368c5dedaab3e73ad69452e)
		{
			c533af2b08173b7c2e3e5405efc254ee3(cf83e762e4368c5dedaab3e73ad69452e, new Rect(0f, 0f, 1f, 1f));
		}

		public virtual void c533af2b08173b7c2e3e5405efc254ee3(Texture cf83e762e4368c5dedaab3e73ad69452e, Rect cadc118b5c81bb89bf38380c9747869ba)
		{
			c285534d649fe484e0a3ea92aa5adf4dd();
			c533af2b08173b7c2e3e5405efc254ee3(cf83e762e4368c5dedaab3e73ad69452e, cadc118b5c81bb89bf38380c9747869ba, c3f0e8163fe520a62fd4001f483261a58);
		}

		public virtual void c533af2b08173b7c2e3e5405efc254ee3(Texture cf83e762e4368c5dedaab3e73ad69452e, Rect cadc118b5c81bb89bf38380c9747869ba, Rect cdac6dc579c4b72dbc8a3ca93ea9caaa9)
		{
			c53573cc4dff493c29715cadfe2300f0d = cf83e762e4368c5dedaab3e73ad69452e;
			c4dffe185817624b1eb40fa8c986e9d43 = cadc118b5c81bb89bf38380c9747869ba;
			c3f0e8163fe520a62fd4001f483261a58 = cdac6dc579c4b72dbc8a3ca93ea9caaa9;
			cf832a91b2d0fc2c9ebf56240d5d0f6c8();
		}

		public void cebb7bc7852c7c7427532f3bd680c245e(pumpkin.display.Sprite c82fcbab5e578dc3a31c1f662916bd87e)
		{
			if (c82fcbab5e578dc3a31c1f662916bd87e == null)
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
				c82fcbab5e578dc3a31c1f662916bd87e.graphics.clear();
				if (!(c53573cc4dff493c29715cadfe2300f0d != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
					c82fcbab5e578dc3a31c1f662916bd87e.graphics.drawRectUV(c4ee12633e2794f3e5c49ec487353212e, c4dffe185817624b1eb40fa8c986e9d43, c3f0e8163fe520a62fd4001f483261a58);
					return;
				}
			}
		}

		protected virtual void cf832a91b2d0fc2c9ebf56240d5d0f6c8()
		{
			c7dafa2645512cd06f2e411281f3dc2ae.graphics.clear();
			if (!(c53573cc4dff493c29715cadfe2300f0d != c9ac9b51d84401f2963498ec9c44725f0.c7088de59e49f7108f520cf7e0bae167e))
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
				c4ee12633e2794f3e5c49ec487353212e.mainTexture = c53573cc4dff493c29715cadfe2300f0d;
				c7dafa2645512cd06f2e411281f3dc2ae.graphics.drawRectUV(c4ee12633e2794f3e5c49ec487353212e, c4dffe185817624b1eb40fa8c986e9d43, c3f0e8163fe520a62fd4001f483261a58);
				return;
			}
		}

		protected override void c16dd84132166e8847948a375ec27d1d9()
		{
			base.c16dd84132166e8847948a375ec27d1d9();
			c285534d649fe484e0a3ea92aa5adf4dd();
			for (int i = 0; i < ca37fcdce7d4937b60735f4033eb55695.numChildren; i++)
			{
				ca37fcdce7d4937b60735f4033eb55695.getChildAt(i).visible = false;
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
				ca37fcdce7d4937b60735f4033eb55695.addChildAt(c7dafa2645512cd06f2e411281f3dc2ae, 1);
				return;
			}
		}

		protected virtual void c285534d649fe484e0a3ea92aa5adf4dd()
		{
			float num = (1f - c92a2ffaad124bdbbc1520ebc4f56f3d2) / 2f;
			c3f0e8163fe520a62fd4001f483261a58.x = Mathf.Round(c0ffd7f3b3dfe86849f698f744e296ad3.srcWidth * num);
			c3f0e8163fe520a62fd4001f483261a58.y = Mathf.Round(c0ffd7f3b3dfe86849f698f744e296ad3.srcHeight * num);
			c3f0e8163fe520a62fd4001f483261a58.width = Mathf.Round(c0ffd7f3b3dfe86849f698f744e296ad3.srcWidth * c92a2ffaad124bdbbc1520ebc4f56f3d2);
			c3f0e8163fe520a62fd4001f483261a58.height = Mathf.Round(c0ffd7f3b3dfe86849f698f744e296ad3.srcHeight * c92a2ffaad124bdbbc1520ebc4f56f3d2);
		}

		protected override void c146b4c165c8d635e38ccda9d949a8a36()
		{
			cf832a91b2d0fc2c9ebf56240d5d0f6c8();
		}
	}
}
