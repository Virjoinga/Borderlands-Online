using System;
using System.Collections.Generic;
using Core;
using pumpkin.display;
using pumpkin.events;

namespace A
{
	public class c167c0089e0a52ec3a626bca450276515 : EventDispatcher
	{
		protected DisplayObjectContainer ca37fcdce7d4937b60735f4033eb55695 = new DisplayObjectContainer();

		protected c590700d1bb82c2f57c638eb9603b93ee cd08e53c53a73ed56efe5c161f7726541;

		public DisplayObjectContainer c89ef242f4744e0f1c4ffea4da8b79bc1
		{
			get
			{
				return ca37fcdce7d4937b60735f4033eb55695;
			}
		}

		public c167c0089e0a52ec3a626bca450276515()
		{
			ca37fcdce7d4937b60735f4033eb55695.name = "WidgetContainer";
		}

		public MovieClip c130648b59a0c8debea60aa153f844879(MovieClip c998c56e5cab278873f1a5722e79733da)
		{
			if (ca37fcdce7d4937b60735f4033eb55695 == c998c56e5cab278873f1a5722e79733da)
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
						return c998c56e5cab278873f1a5722e79733da;
					}
				}
			}
			ca37fcdce7d4937b60735f4033eb55695 = c998c56e5cab278873f1a5722e79733da;
			cad7aa09d67394b5d75756536f558198b(c998c56e5cab278873f1a5722e79733da);
			c969016383f47c249932cc75475f00ae1();
			return ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
		}

		public bool cd1e17b6ce3586ba6a22d6a71ff17d01c()
		{
			MovieClip movieClip = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
			if (movieClip == null)
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
						return false;
					}
				}
			}
			cad7aa09d67394b5d75756536f558198b(movieClip);
			c969016383f47c249932cc75475f00ae1();
			return true;
		}

		public virtual void OnAddingToStage()
		{
		}

		public virtual void OnRemovedFromStage()
		{
		}

		protected virtual void c969016383f47c249932cc75475f00ae1()
		{
		}

		private void cad7aa09d67394b5d75756536f558198b(MovieClip c998c56e5cab278873f1a5722e79733da)
		{
			if (c998c56e5cab278873f1a5722e79733da == null)
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
						return;
					}
				}
			}
			List<DisplayObject> list = new List<DisplayObject>();
			for (int i = 0; i < c998c56e5cab278873f1a5722e79733da.numChildren; i++)
			{
				list.Add(c998c56e5cab278873f1a5722e79733da.getChildAt(i));
			}
			while (true)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				for (int j = 0; j < list.Count; j++)
				{
					DisplayObject displayObject = cc7b206340b600c7decc4e7b5711da220.c7088de59e49f7108f520cf7e0bae167e;
					DisplayObject displayObject2 = list[j];
					MovieClip movieClip = displayObject2 as MovieClip;
					if (movieClip != null)
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
						Type type = ca00f4bcde573bcbfcc12adbf29f015cb.c5ee19dc8d4cccf5ae2de225410458b86.c6ee1857d3d386f7c9ef3dd58c68b00dd(movieClip.getSymbolName());
						if (type != null)
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
							c590700d1bb82c2f57c638eb9603b93ee c590700d1bb82c2f57c638eb9603b93ee2 = OnWidgetInitialized;
							if (cd08e53c53a73ed56efe5c161f7726541 != null)
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
								c590700d1bb82c2f57c638eb9603b93ee2 = cd08e53c53a73ed56efe5c161f7726541;
							}
							if (c590700d1bb82c2f57c638eb9603b93ee2(ref movieClip, type))
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
								continue;
							}
						}
						cad7aa09d67394b5d75756536f558198b(movieClip);
						displayObject = movieClip;
					}
					if (displayObject == null)
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
						displayObject = OnImportDisplayObject(c998c56e5cab278873f1a5722e79733da, displayObject2);
					}
					if (displayObject == null)
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
						DebugUtils.ce93ff017745857c486c984051026749f(LogCategory.GUI, "!--GUIError: Movieclip Error!! Missed a movie named:" + displayObject2.name);
						c998c56e5cab278873f1a5722e79733da.removeChild(displayObject2);
					}
					if (displayObject == null)
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
						break;
					}
					if (displayObject == displayObject2)
					{
						continue;
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
					c998c56e5cab278873f1a5722e79733da.removeChild(displayObject2);
					c998c56e5cab278873f1a5722e79733da.addChild(displayObject);
				}
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
		}

		protected virtual bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			return false;
		}

		protected virtual DisplayObject OnImportDisplayObject(MovieClip movieClip, DisplayObject child)
		{
			return child;
		}
	}
}
