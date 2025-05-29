using System.Collections.Generic;
using pumpkin.display;
using pumpkin.events;

namespace A
{
	public class c196099a1254db61d3be10d70e14e7422 : c167c0089e0a52ec3a626bca450276515
	{
		protected List<UnityTextField> ce738256c9bb26d44ce14eb4834deb035 = new List<UnityTextField>();

		public string c878d4164b90c3984e81f987922e217f5
		{
			set
			{
				if (value == string.Empty)
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
				MovieClip movieClip = ca37fcdce7d4937b60735f4033eb55695 as MovieClip;
				if (movieClip == null)
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
				movieClip.addFrameScript(value, c19a5a54a66cd1049fccc9190f65c7b76);
			}
		}

		public MovieClip c130648b59a0c8debea60aa153f844879(MovieClip c998c56e5cab278873f1a5722e79733da, c590700d1bb82c2f57c638eb9603b93ee cc69ca0759f5440231c6169e8bdeca398)
		{
			cd08e53c53a73ed56efe5c161f7726541 = cc69ca0759f5440231c6169e8bdeca398;
			MovieClip result = c130648b59a0c8debea60aa153f844879(c998c56e5cab278873f1a5722e79733da);
			ce738256c9bb26d44ce14eb4834deb035.Clear();
			return result;
		}

		public MovieClip c130648b59a0c8debea60aa153f844879(MovieClip c998c56e5cab278873f1a5722e79733da, string c024b128f9f0bf70ab448bad7f12db8c0, c590700d1bb82c2f57c638eb9603b93ee cc69ca0759f5440231c6169e8bdeca398 = null)
		{
			cd08e53c53a73ed56efe5c161f7726541 = cc69ca0759f5440231c6169e8bdeca398;
			MovieClip result = c130648b59a0c8debea60aa153f844879(c998c56e5cab278873f1a5722e79733da);
			c878d4164b90c3984e81f987922e217f5 = c024b128f9f0bf70ab448bad7f12db8c0;
			return result;
		}

		protected virtual void c19a5a54a66cd1049fccc9190f65c7b76(CEvent cd729d94a5b443ac0f1b117450e5f4419)
		{
			cd1e17b6ce3586ba6a22d6a71ff17d01c();
		}

		protected override DisplayObject OnImportDisplayObject(MovieClip movieClip, DisplayObject child)
		{
			UnityTextField unityTextField = child as UnityTextField;
			if (unityTextField != null)
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
				ce738256c9bb26d44ce14eb4834deb035.Add(unityTextField);
			}
			return base.OnImportDisplayObject(movieClip, child);
		}

		public override void OnRemovedFromStage()
		{
			base.OnRemovedFromStage();
			using (List<UnityTextField>.Enumerator enumerator = ce738256c9bb26d44ce14eb4834deb035.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					UnityTextField current = enumerator.Current;
					if (!current.ca07ebfaabd41a5a4b21a0ae22c34e17b)
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
					if (1 == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					c7faa6f1d3168c8fb9e598b66c8c1c1fd.ccf24681862bae286c19d5c9b16296be5.c73f608275ed778f1b52438ced1f333ef();
				}
				while (true)
				{
					switch (5)
					{
					case 0:
						break;
					default:
						return;
					}
				}
			}
		}
	}
}
