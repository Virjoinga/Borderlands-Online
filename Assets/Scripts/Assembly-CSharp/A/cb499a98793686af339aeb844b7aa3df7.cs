using pumpkin.display;
using pumpkin.events;

namespace A
{
	public class cb499a98793686af339aeb844b7aa3df7 : EventDispatcher
	{
		private static cb499a98793686af339aeb844b7aa3df7 cd55c99b38807cf15a2969975dd02178c;

		private static c7acaeff3c2b1ee99be0391731e4a9263 c5cd760a46484b8916ec0641229f36cf3;

		private bool c7b1a30d7d5ee1ed1c9d80cab38ac8e58;

		private DisplayObject cfa6c876c0f1997872471adc04ca92eb6;

		private ceaa621c569baf012ce466a5c368364e3 cc407f5407576294f436203556c33a9eb;

		public static cb499a98793686af339aeb844b7aa3df7 ccf24681862bae286c19d5c9b16296be5
		{
			get
			{
				if (cd55c99b38807cf15a2969975dd02178c == null)
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
					cd55c99b38807cf15a2969975dd02178c = new cb499a98793686af339aeb844b7aa3df7();
				}
				return cd55c99b38807cf15a2969975dd02178c;
			}
		}

		public bool c9eb06fa6cb8c5eea40ba124dbe5c8449
		{
			get
			{
				return c7b1a30d7d5ee1ed1c9d80cab38ac8e58;
			}
		}

		public DisplayObject cabcc1f4ac3c1213bcbbe24560ff08eb7
		{
			get
			{
				return cfa6c876c0f1997872471adc04ca92eb6;
			}
		}

		private cb499a98793686af339aeb844b7aa3df7()
		{
		}

		private void OnTipsChange(CEvent evt)
		{
			if (!c7b1a30d7d5ee1ed1c9d80cab38ac8e58)
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
				cecdbba337eca9563c514de5a01cd4bf6();
				return;
			}
		}

		public void c5734fb1245ed054d8619adf30ecab3c8(ceaa621c569baf012ce466a5c368364e3 cff69a954228b2d4c4b2ed5630a18ed38, cc04bd9c3eaf23b7d09819a18845f4453 c90bf733de9278b700baad5f94807708f)
		{
			if (c90bf733de9278b700baad5f94807708f == null)
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
						return;
					}
				}
			}
			cecdbba337eca9563c514de5a01cd4bf6();
			cc407f5407576294f436203556c33a9eb = cff69a954228b2d4c4b2ed5630a18ed38;
			DisplayObject displayObject = c5cd760a46484b8916ec0641229f36cf3.c360acb00df3109608934d8598192c939(cc407f5407576294f436203556c33a9eb, c90bf733de9278b700baad5f94807708f);
			if (displayObject == null)
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
			cfa6c876c0f1997872471adc04ca92eb6 = displayObject;
			c7b1a30d7d5ee1ed1c9d80cab38ac8e58 = true;
			cc407f5407576294f436203556c33a9eb.addEventListener("tipsChange", OnTipsChange);
		}

		public bool cd93285db16841148ed53a5bbeb35cf20(c7acaeff3c2b1ee99be0391731e4a9263 c5637318b04f333783d533b8d35151eb1)
		{
			if (c5637318b04f333783d533b8d35151eb1 == null)
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
			c5cd760a46484b8916ec0641229f36cf3 = c5637318b04f333783d533b8d35151eb1;
			c5cd760a46484b8916ec0641229f36cf3.ccc9d3a38966dc10fedb531ea17d24611();
			cecdbba337eca9563c514de5a01cd4bf6();
			return true;
		}

		public void cecdbba337eca9563c514de5a01cd4bf6()
		{
			c5cd760a46484b8916ec0641229f36cf3.c4bf7ff1d43cc4cbaaca76bb4a15b8e3e(cfa6c876c0f1997872471adc04ca92eb6);
			if (cc407f5407576294f436203556c33a9eb != null)
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
				cc407f5407576294f436203556c33a9eb.removeEventListener("tipsChange", OnTipsChange);
			}
			cfa6c876c0f1997872471adc04ca92eb6 = cc7b206340b600c7decc4e7b5711da220.c7088de59e49f7108f520cf7e0bae167e;
			cc407f5407576294f436203556c33a9eb = c738fb9eb93be0fefdb78974f473e6947.c7088de59e49f7108f520cf7e0bae167e;
			c7b1a30d7d5ee1ed1c9d80cab38ac8e58 = false;
		}
	}
}
