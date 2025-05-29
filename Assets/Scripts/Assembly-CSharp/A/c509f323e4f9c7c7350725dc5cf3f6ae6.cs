using UnityEngine;
using XsdSettings;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

namespace A
{
	public class c509f323e4f9c7c7350725dc5cf3f6ae6 : c9f62278a5e2341872ad7373d9bb65f26
	{
		protected MovieClip ce455d8f33195003c6d8a1b4c19f5e76b;

		protected MovieClip ceb4571ca7f02fb40a98cbbf8b1f58d4b;

		protected TextField c5d96dddf6df5aa49b15d2398df5f9437;

		protected TextField ca84ebe7f578948a6eec4a5e2a15ace07;

		protected TextField c5cb93dc2252bdcc84f647582c5085f75;

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			c0ffd7f3b3dfe86849f698f744e296ad3.mouseChildrenEnabled = true;
			MovieClip movieClip = base.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
			ce455d8f33195003c6d8a1b4c19f5e76b = movieClip.getChildByName<MovieClip>("online_status");
			ceb4571ca7f02fb40a98cbbf8b1f58d4b = ce455d8f33195003c6d8a1b4c19f5e76b.getChildByName<MovieClip>("mc_Icon");
			c5d96dddf6df5aa49b15d2398df5f9437 = ce455d8f33195003c6d8a1b4c19f5e76b.getChildByName<TextField>("tflv");
			ca84ebe7f578948a6eec4a5e2a15ace07 = ce455d8f33195003c6d8a1b4c19f5e76b.getChildByName<TextField>("tfname");
			c5cb93dc2252bdcc84f647582c5085f75 = ce455d8f33195003c6d8a1b4c19f5e76b.getChildByName<TextField>("tfposition");
			c0ffd7f3b3dfe86849f698f744e296ad3.addEventListener(MouseEvent.CLICK, c298e7f50cb7d3132a8729e55d70a008d);
		}

		protected void c298e7f50cb7d3132a8729e55d70a008d(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			FriendManager.c71f6ce28731edfd43c976fbd57c57bea().c1c7eba11d297c10307e34ca826071071(c93b9f9e7db3254d97a5118f2dcffe924);
		}

		public override void c263a18e823d534fe933bf797fd17c221(int c62a53388af21c9e5e206591a30eb9f80)
		{
			Presence presence = FriendManager.c71f6ce28731edfd43c976fbd57c57bea().ce9b5878739f3b5cba4562c672e5555e1(c62a53388af21c9e5e206591a30eb9f80);
			if (presence == null)
			{
				return;
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				c93b9f9e7db3254d97a5118f2dcffe924 = presence.mCharacterId;
				UnityTextField unityTextField = (UnityTextField)c5d96dddf6df5aa49b15d2398df5f9437;
				if (presence.mIsOnline)
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
					ca84ebe7f578948a6eec4a5e2a15ace07.textFormat.color = Color.white;
					unityTextField.c34fce3bccfffc6feb3579939c6d9a057 = Color.yellow;
					c5cb93dc2252bdcc84f647582c5085f75.textFormat.color = Color.white;
					c5cb93dc2252bdcc84f647582c5085f75.text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("Instance_" + presence.mCurrentTown));
				}
				else
				{
					ca84ebe7f578948a6eec4a5e2a15ace07.textFormat.color = Color.gray;
					unityTextField.c34fce3bccfffc6feb3579939c6d9a057 = Color.gray;
					c5cb93dc2252bdcc84f647582c5085f75.textFormat.color = Color.gray;
					c5cb93dc2252bdcc84f647582c5085f75.text = Utility.c3702d7d2ce9dcf64b29c2fab82d733d5(presence.mLastOnline);
				}
				ca84ebe7f578948a6eec4a5e2a15ace07.text = presence.mCharacterName;
				unityTextField.text = "Lv:" + presence.mCharacterLevel;
				AvatarType mAvatarType = presence.mAvatarType;
				ceb4571ca7f02fb40a98cbbf8b1f58d4b.gotoAndStop(mAvatarType.ToString());
				return;
			}
		}
	}
}
