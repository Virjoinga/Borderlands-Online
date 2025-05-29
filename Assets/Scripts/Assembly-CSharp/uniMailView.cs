using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using UnityEngine;
using XsdSettings;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

public class uniMailView : MailView
{
	protected class MailBox : c196099a1254db61d3be10d70e14e7422
	{
		protected const string TAB_GROUP_NAME = "MAILLIST_FUNCTION_TAB";

		protected const string MAIL_ITEM_NAME_PREFIX = "mcMailItem_";

		protected const int MAIL_SLOT_COUNT = 16;

		protected c6425d3761c85e65e3530cc19d085d446 _tabMailList = new c6425d3761c85e65e3530cc19d085d446();

		protected c6425d3761c85e65e3530cc19d085d446 _tabCreateNewMail = new c6425d3761c85e65e3530cc19d085d446();

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b _btnClose = new c82f7c0afbcfc8c5382a8c6daa9365b7b();

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b _btnSend = new c82f7c0afbcfc8c5382a8c6daa9365b7b();

		protected cf7ac05203029a27299d6893b2dbaee2e _scBar = new cf7ac05203029a27299d6893b2dbaee2e();

		protected ccf8bd4afc86b3c33d69f65b1612538ce _textInputReceiver = new ccf8bd4afc86b3c33d69f65b1612538ce();

		protected ccf8bd4afc86b3c33d69f65b1612538ce _textInputNewMailContent = new ccf8bd4afc86b3c33d69f65b1612538ce();

		protected TextField _textCurMailCount;

		protected TextField _textMaxMailCount;

		protected MovieClip _mcCreateMaillRoot;

		protected MovieClip _mcMailListRoot;

		protected MailListItem[] _mailItemList = new MailListItem[16];

		protected List<MailInfo> _mailInfoList = new List<MailInfo>();

		protected MailAnimaState _curState;

		[CompilerGenerated]
		private static Dictionary<string, int> _003C_003Ef__switch_0024map21;

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool result = false;
			string name = movieClip.name;
			if (name != null)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (_003C_003Ef__switch_0024map21 == null)
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
					Dictionary<string, int> dictionary = new Dictionary<string, int>(9);
					dictionary.Add("btnMailList", 0);
					dictionary.Add("btnCreateNewMail", 1);
					dictionary.Add("mcBtnClose", 2);
					dictionary.Add("mcScrollingBar", 3);
					dictionary.Add("mcCreateNewMail", 4);
					dictionary.Add("mcReveiverName", 5);
					dictionary.Add("mcNewMailContent", 6);
					dictionary.Add("btnSend", 7);
					dictionary.Add("mcMailList", 8);
					_003C_003Ef__switch_0024map21 = dictionary;
				}
				int value;
				if (_003C_003Ef__switch_0024map21.TryGetValue(name, out value))
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
					switch (value)
					{
					case 0:
						_tabMailList.c130648b59a0c8debea60aa153f844879(movieClip);
						_tabMailList.cec024da8c099380cfe1334bfe4c8f30f = "MAILLIST_FUNCTION_TAB";
						_tabMailList.c6279c42b47398c5e401c1cff54ce61c2.addEventListener(CEvent.CHANGED, c2c914e5b7279c2bfd2ca6b1e8132869e);
						_tabMailList.c9c364a8fd1f013589fea518a3924e711 = true;
						_tabMailList.ce84b930a12a1d06512c79320b3f0d3f4 = false;
						result = true;
						break;
					case 1:
						_tabCreateNewMail.c130648b59a0c8debea60aa153f844879(movieClip);
						_tabCreateNewMail.cec024da8c099380cfe1334bfe4c8f30f = "MAILLIST_FUNCTION_TAB";
						_tabCreateNewMail.ce84b930a12a1d06512c79320b3f0d3f4 = false;
						_tabCreateNewMail.removeAllEventListeners(MouseEvent.CLICK);
						_tabCreateNewMail.addEventListener(MouseEvent.CLICK, c1a3e823b190999acf2435504e4577d39);
						result = true;
						break;
					case 2:
						_btnClose.c130648b59a0c8debea60aa153f844879(movieClip);
						_btnClose.removeAllEventListeners(MouseEvent.CLICK);
						_btnClose.addEventListener(MouseEvent.CLICK, c100051626b6a93d232edddddd4994c93);
						result = true;
						break;
					case 3:
						_scBar.c130648b59a0c8debea60aa153f844879(movieClip);
						_scBar.removeAllEventListeners("Scrolling");
						_scBar.addEventListener("Scrolling", c0bf98f01a649e054ba162a6ccab161d4);
						_scBar.c9c58dff860effc1212c1afb5d14e147c = (_scBar.cfcb3294d851a0336d3f3a8f2a943f2fb = 0);
						result = true;
						break;
					case 4:
						_mcCreateMaillRoot = movieClip;
						_mcCreateMaillRoot.visible = true;
						result = false;
						break;
					case 5:
						_textInputReceiver.c130648b59a0c8debea60aa153f844879(movieClip);
						_textInputReceiver.removeAllEventListeners(CEvent.CHANGED);
						_textInputReceiver.addEventListener(CEvent.CHANGED, cdc88cb39a6d4b5dd548147756af51857);
						result = true;
						break;
					case 6:
						_textInputNewMailContent.c130648b59a0c8debea60aa153f844879(movieClip);
						_textInputNewMailContent.removeAllEventListeners(CEvent.CHANGED);
						_textInputNewMailContent.addEventListener(CEvent.CHANGED, cdc88cb39a6d4b5dd548147756af51857);
						result = true;
						break;
					case 7:
						_btnSend.c130648b59a0c8debea60aa153f844879(movieClip);
						_btnSend.removeAllEventListeners(MouseEvent.CLICK);
						_btnSend.addEventListener(MouseEvent.CLICK, cc6cd1f31336426bd80b307202236b2b5);
						_btnSend.cbf402c82d0fffee7c8f37c98e456b8f8 = false;
						result = true;
						break;
					case 8:
					{
						_mcMailListRoot = movieClip;
						_mcMailListRoot.visible = false;
						for (int i = 0; i < 16; i++)
						{
							string name2 = "mcMailItem_" + i;
							MovieClip childByName = movieClip.getChildByName<MovieClip>(name2);
							if (childByName == null)
							{
								continue;
							}
							while (true)
							{
								switch (2)
								{
								case 0:
									continue;
								}
								break;
							}
							if (_mailItemList[i] == null)
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
								_mailItemList[i] = new MailListItem();
							}
							_mailItemList[i].c130648b59a0c8debea60aa153f844879(childByName);
							_mailItemList[i].removeAllEventListeners(MouseEvent.CLICK);
							_mailItemList[i].addEventListener(MouseEvent.CLICK, c7bcf7ecec4dc808acd6f248212ece1aa);
							_mailItemList[i].removeAllEventListeners(c649b5d45cf350f685c56c4bd02800198.c4c735ed0f7d81b376e20a84473c72a44);
							_mailItemList[i].addEventListener(c649b5d45cf350f685c56c4bd02800198.c4c735ed0f7d81b376e20a84473c72a44, c368ead34f78b806de6f4e0473b71b0d1);
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
						result = true;
						break;
					}
					}
				}
			}
			return result;
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			MovieClip movieClip = base.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
			if (movieClip == null)
			{
				return;
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
				movieClip.addFrameScript("Ready", c26a8258d03848b712b107711942df09a);
				c39062807a45556a41c3a92303c3ea6b5();
				return;
			}
		}

		protected void c26a8258d03848b712b107711942df09a(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			c39062807a45556a41c3a92303c3ea6b5();
		}

		protected void c39062807a45556a41c3a92303c3ea6b5()
		{
			_textCurMailCount = base.c89ef242f4744e0f1c4ffea4da8b79bc1.getChildByName<TextField>("textCurMailCnt");
			_textMaxMailCount = base.c89ef242f4744e0f1c4ffea4da8b79bc1.getChildByName<TextField>("textMaxMailCnt");
			int num;
			if (_curState != MailAnimaState.CreateNewMail)
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
				num = ((_curState != MailAnimaState.Reply) ? 1 : 0);
			}
			else
			{
				num = 0;
			}
			bool flag = (byte)num != 0;
			if (_mcCreateMaillRoot != null)
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
				_mcCreateMaillRoot.visible = !flag;
			}
			if (_mcMailListRoot == null)
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
				_mcMailListRoot.visible = flag;
				return;
			}
		}

		protected void c100051626b6a93d232edddddd4994c93(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			cc630451b632f9d42bd5d35004445c43e();
			dispatchEvent(new CEvent("EVT_CLICK_MAILLIST_CLOSE"));
		}

		protected void c7bcf7ecec4dc808acd6f248212ece1aa(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			MailListItem mailListItem = c3d202dee321219a80026dc3081fb3c86.target as MailListItem;
			if (mailListItem == null)
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
				dispatchEvent(new cdd9021d4f44808fce2ab49c52f0db6f7("EVT_LEFT_CLICK_MAILLIST_ITEM", mailListItem.c591d56a94543e3559945c497f37126c4));
				return;
			}
		}

		protected void c368ead34f78b806de6f4e0473b71b0d1(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			MailListItem mailListItem = c3d202dee321219a80026dc3081fb3c86.target as MailListItem;
			if (mailListItem == null)
			{
				return;
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
				dispatchEvent(new cdd9021d4f44808fce2ab49c52f0db6f7("EVT_RIGHT_CLICK_MAILLIST_ITEM", mailListItem.c591d56a94543e3559945c497f37126c4));
				return;
			}
		}

		protected void cdc88cb39a6d4b5dd548147756af51857(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			bool cbf402c82d0fffee7c8f37c98e456b8f = false;
			if (_textInputNewMailContent.c09721d98c247dde8efe59bc3cebbad00 != null)
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
				if (_textInputReceiver.c09721d98c247dde8efe59bc3cebbad00 != null)
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
					int num;
					if (_textInputNewMailContent.c09721d98c247dde8efe59bc3cebbad00.Length != 0)
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
						num = ((_textInputReceiver.c09721d98c247dde8efe59bc3cebbad00.Length != 0) ? 1 : 0);
					}
					else
					{
						num = 0;
					}
					cbf402c82d0fffee7c8f37c98e456b8f = (byte)num != 0;
				}
			}
			_btnSend.cbf402c82d0fffee7c8f37c98e456b8f8 = cbf402c82d0fffee7c8f37c98e456b8f;
		}

		protected void c1a3e823b190999acf2435504e4577d39(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			if (_textInputNewMailContent == null)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				_textInputNewMailContent.c09721d98c247dde8efe59bc3cebbad00 = string.Empty;
				_textInputReceiver.c09721d98c247dde8efe59bc3cebbad00 = c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e;
				return;
			}
		}

		protected void c2c914e5b7279c2bfd2ca6b1e8132869e(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			if (_mcCreateMaillRoot != null)
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
				_mcCreateMaillRoot.visible = _tabCreateNewMail.c9c364a8fd1f013589fea518a3924e711;
				if (_tabCreateNewMail.c9c364a8fd1f013589fea518a3924e711)
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
					if (_textInputNewMailContent != null)
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
						_textInputNewMailContent.c09721d98c247dde8efe59bc3cebbad00 = string.Empty;
						_textInputReceiver.c09721d98c247dde8efe59bc3cebbad00 = c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e;
					}
					dispatchEvent(new CEvent("EVT_CLICK_CREATE_NEW_MAIL"));
				}
			}
			if (_mcMailListRoot == null)
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
				_mcMailListRoot.visible = _tabMailList.c9c364a8fd1f013589fea518a3924e711;
				if (!_tabMailList.c9c364a8fd1f013589fea518a3924e711)
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
					dispatchEvent(new CEvent("EVT_CLICK_MAILLIST"));
					_scBar.cef9712200bbe2c3873eec3ca2e18a595 = 0;
					return;
				}
			}
		}

		protected void cc6cd1f31336426bd80b307202236b2b5(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			NewMailInfoContainer newMailInfoContainer = new NewMailInfoContainer();
			newMailInfoContainer.StrReceiverNickName = _textInputReceiver.c09721d98c247dde8efe59bc3cebbad00;
			newMailInfoContainer.StrMailContent = _textInputNewMailContent.c09721d98c247dde8efe59bc3cebbad00;
			_textInputReceiver.c09721d98c247dde8efe59bc3cebbad00 = string.Empty;
			_textInputNewMailContent.c09721d98c247dde8efe59bc3cebbad00 = string.Empty;
			cc630451b632f9d42bd5d35004445c43e();
			dispatchEvent(new cdd9021d4f44808fce2ab49c52f0db6f7("EVT_CLICK_SEND", newMailInfoContainer));
		}

		protected void c0bf98f01a649e054ba162a6ccab161d4(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			cdc61aa3211342711834b78e291404544(_scBar.cef9712200bbe2c3873eec3ca2e18a595);
		}

		public void cac7688b05e921e2be3f92479ba44b4a8()
		{
			_tabMailList.c9c364a8fd1f013589fea518a3924e711 = true;
		}

		protected void cc630451b632f9d42bd5d35004445c43e()
		{
			if (_textInputReceiver != null)
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
				_textInputReceiver.ce8805cc02a868fbf01bc5a4fa7c97062 = false;
			}
			if (_textInputNewMailContent == null)
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
				_textInputNewMailContent.ce8805cc02a868fbf01bc5a4fa7c97062 = false;
				return;
			}
		}

		public void c79c3f5edfd1dcb16b8552473da4fb938(MailAnimaState c8d775b30e865fb299ec61d7380e38f65)
		{
			if (c8d775b30e865fb299ec61d7380e38f65 == MailAnimaState.KickOff)
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
				_scBar.cef9712200bbe2c3873eec3ca2e18a595 = 0;
			}
			bool visible = false;
			if (c8d775b30e865fb299ec61d7380e38f65 != MailAnimaState.CreateNewMail)
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
				if (c8d775b30e865fb299ec61d7380e38f65 != MailAnimaState.Reply)
				{
					visible = true;
					if (!_tabMailList.c9c364a8fd1f013589fea518a3924e711)
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
						_tabMailList.c9c364a8fd1f013589fea518a3924e711 = true;
					}
					goto IL_008f;
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
			}
			if (!_tabCreateNewMail.c9c364a8fd1f013589fea518a3924e711)
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
				_tabCreateNewMail.c9c364a8fd1f013589fea518a3924e711 = true;
			}
			goto IL_008f;
			IL_008f:
			TextField childByName = base.c89ef242f4744e0f1c4ffea4da8b79bc1.getChildByName<TextField>("textMailTips");
			if (childByName == null)
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
				childByName.visible = visible;
				return;
			}
		}

		public void c6a305f63e983b65571baec62c02e68cf(List<MailInfo> cfd7b1f69400c74512a3ab00a28afa680)
		{
			_mailInfoList = cfd7b1f69400c74512a3ab00a28afa680;
			if (!(_scBar.c89ef242f4744e0f1c4ffea4da8b79bc1 is MovieClip))
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
			if (_textCurMailCount != null)
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
				if (_textMaxMailCount != null)
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
					_textMaxMailCount.text = Convert.ToString(MailServiceWrapper.MAILBOX_MAXVOLUME);
					if (cfd7b1f69400c74512a3ab00a28afa680.Count == MailServiceWrapper.MAILBOX_MAXVOLUME)
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
						_textCurMailCount.textFormat.color = new Color(255f, 0f, 0f);
					}
					else
					{
						_textCurMailCount.textFormat.color = new Color(255f, 204f, 0f);
					}
					_textCurMailCount.text = cfd7b1f69400c74512a3ab00a28afa680.Count.ToString();
				}
			}
			if (cfd7b1f69400c74512a3ab00a28afa680.Count > 16)
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
				_scBar.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = true;
				_scBar.c5a7d812d0a8e674b21eb0ed8824a2f59(16, 0, cfd7b1f69400c74512a3ab00a28afa680.Count, 1);
			}
			else
			{
				_scBar.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = false;
				_scBar.cef9712200bbe2c3873eec3ca2e18a595 = 0;
			}
			cdc61aa3211342711834b78e291404544(_scBar.cef9712200bbe2c3873eec3ca2e18a595);
			string text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("MAIL_EXPIRE_WARNING"));
			if (cfd7b1f69400c74512a3ab00a28afa680.Count == MailServiceWrapper.MAILBOX_MAXVOLUME)
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
				text = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("MAIL_FULL_WARNING"));
			}
			TextField childByName = base.c89ef242f4744e0f1c4ffea4da8b79bc1.getChildByName<TextField>("textMailTips");
			if (childByName == null)
			{
				return;
			}
			while (true)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				childByName.text = text;
				return;
			}
		}

		protected void cdc61aa3211342711834b78e291404544(int c5128793ce5a806c0b7ba35948f75f131)
		{
			if (c5128793ce5a806c0b7ba35948f75f131 < 0)
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
				if (c5128793ce5a806c0b7ba35948f75f131 > _mailInfoList.Count)
				{
					while (true)
					{
						switch (6)
						{
						case 0:
							break;
						default:
							return;
						}
					}
				}
				int i = 0;
				int num = c5128793ce5a806c0b7ba35948f75f131;
				while (i < 16)
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
					if (num < _mailInfoList.Count)
					{
						_mailItemList[i].c43cbb41bf755dfa61de619fc6e86ab31(true);
						_mailItemList[i].cfa637a48630ade74bf7a9f6e6b9d9903(_mailInfoList[num]);
						i++;
						num++;
						continue;
					}
					while (true)
					{
						switch (5)
						{
						case 0:
							continue;
						}
						break;
					}
					break;
				}
				for (; i < 16; i++)
				{
					if (_mailItemList[i] == null)
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
					_mailItemList[i].c43cbb41bf755dfa61de619fc6e86ab31(false);
				}
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
		}

		public void c3e4b023f9e36d68f5768aa2046447f03(string cd67082ec5a3c66f02562c5316d164d45)
		{
			_textInputReceiver.c09721d98c247dde8efe59bc3cebbad00 = cd67082ec5a3c66f02562c5316d164d45;
		}
	}

	protected class MailListItem : c82f7c0afbcfc8c5382a8c6daa9365b7b
	{
		protected MovieClip _mcMailStatus;

		protected MovieClip _mcRoot;

		protected MailInfo _mailInfo;

		[CompilerGenerated]
		private static Dictionary<string, int> _003C_003Ef__switch_0024map22;

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool result = false;
			string name = movieClip.name;
			if (name != null)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				if (_003C_003Ef__switch_0024map22 == null)
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
					Dictionary<string, int> dictionary = new Dictionary<string, int>(1);
					dictionary.Add("mcStatusIcon", 0);
					_003C_003Ef__switch_0024map22 = dictionary;
				}
				int value;
				if (_003C_003Ef__switch_0024map22.TryGetValue(name, out value))
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
					if (value != 0)
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
					}
					else
					{
						_mcMailStatus = movieClip;
					}
				}
			}
			return result;
		}

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			_mcRoot = base.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
			if (_mcRoot == null)
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
				_mcRoot.addFrameScript("up", c2d4b6616c5d13a240f0d050133a6a00b);
				_mcRoot.addFrameScript("over", c2d4b6616c5d13a240f0d050133a6a00b);
				_mcRoot.addFrameScript("disable", c2d4b6616c5d13a240f0d050133a6a00b);
				return;
			}
		}

		public void c43cbb41bf755dfa61de619fc6e86ab31(bool c74232243aff1dcbf2e8fc243633bb51a)
		{
			base.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = c74232243aff1dcbf2e8fc243633bb51a;
		}

		public void cfa637a48630ade74bf7a9f6e6b9d9903(MailInfo c581d1dfdd43628e29bfec127d5c010fa)
		{
			_mailInfo = c581d1dfdd43628e29bfec127d5c010fa;
			base.c591d56a94543e3559945c497f37126c4 = c581d1dfdd43628e29bfec127d5c010fa;
			c9c040a2d0edf8852c382f5612a6dfe82();
		}

		protected void c9c040a2d0edf8852c382f5612a6dfe82()
		{
			if (_mailInfo == null)
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
				if (_mcRoot == null)
				{
					while (true)
					{
						switch (7)
						{
						case 0:
							break;
						default:
							return;
						}
					}
				}
				TextField childByName = _mcRoot.getChildByName<TextField>("textSenderName");
				TextField childByName2 = _mcRoot.getChildByName<TextField>("textMailDate");
				if (childByName != null)
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
					string empty = string.Empty;
					if (_mailInfo.Mailtype == MailType.System)
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
						empty = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("MAIL_SYSTEM"));
					}
					else
					{
						empty = _mailInfo.SenderName + LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("MAIL_PLAYER"));
					}
					childByName.text = empty;
				}
				if (childByName2 != null)
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
					childByName2.text = MailView.EPOCH.AddSeconds(_mailInfo.Expiration).ToLocalTime().Subtract(MailServiceWrapper.MAIL_LIFETIME)
						.ToString("d");
				}
				if (_mcMailStatus == null)
				{
					return;
				}
				while (true)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					string to = c9a59173e62a56d32d37c19ac5ffc563a.c7088de59e49f7108f520cf7e0bae167e;
					switch (_mailInfo.Mailstate)
					{
					case MailState.Unread:
						to = "Unread";
						if (_mailInfo.Item == null)
						{
							break;
						}
						while (true)
						{
							switch (3)
							{
							case 0:
								continue;
							}
							break;
						}
						to = "Items";
						break;
					case MailState.Read:
						to = "Read";
						if (_mailInfo.Item == null)
						{
							break;
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
						to = "GetItems";
						break;
					case MailState.GetItems:
						to = "Read";
						break;
					}
					_mcMailStatus.gotoAndStop(to);
					return;
				}
			}
		}

		protected void c2d4b6616c5d13a240f0d050133a6a00b(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			c9c040a2d0edf8852c382f5612a6dfe82();
		}
	}

	protected class MailContentBoard : c196099a1254db61d3be10d70e14e7422
	{
		protected TextField _textSenderName;

		protected TextField _textMailContent;

		protected TextField _textRewardTitle;

		protected c87da635fd7858aaa8f8053a95f123b32 _rewardSlot = new c87da635fd7858aaa8f8053a95f123b32();

		protected ccf8bd4afc86b3c33d69f65b1612538ce _textInputReceiverName = new ccf8bd4afc86b3c33d69f65b1612538ce();

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b _btnReply = new c82f7c0afbcfc8c5382a8c6daa9365b7b();

		protected c82f7c0afbcfc8c5382a8c6daa9365b7b _btnGetReward = new c82f7c0afbcfc8c5382a8c6daa9365b7b();

		protected MailInfo _mailInfo;

		protected override void c969016383f47c249932cc75475f00ae1()
		{
			base.c969016383f47c249932cc75475f00ae1();
			MovieClip movieClip = base.c89ef242f4744e0f1c4ffea4da8b79bc1 as MovieClip;
			if (movieClip == null)
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
			MovieClip childByName = movieClip.getChildByName<MovieClip>("mcReceive");
			if (childByName != null)
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
				_textSenderName = childByName.getChildByName<TextField>("textSenderName");
				_textMailContent = childByName.getChildByName<TextField>("textMailContent");
				_textRewardTitle = childByName.getChildByName<TextField>("textRewardTitle");
				if (_textRewardTitle != null)
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
					_textRewardTitle.visible = false;
				}
				childByName.addFrameScript("NormalMail", c2d4b6616c5d13a240f0d050133a6a00b);
				MovieClip childByName2 = childByName.getChildByName<MovieClip>("btnReply");
				if (childByName2 != null)
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
					_btnReply.c130648b59a0c8debea60aa153f844879(childByName2);
					_btnReply.removeAllEventListeners(MouseEvent.CLICK);
					_btnReply.addEventListener(MouseEvent.CLICK, cf54583639dfefee65deaa3957da7ef62);
				}
				MovieClip childByName3 = childByName.getChildByName<MovieClip>("btnGetReward");
				if (childByName3 != null)
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
					_btnGetReward.c130648b59a0c8debea60aa153f844879(childByName3);
					_btnGetReward.removeAllEventListeners(MouseEvent.CLICK);
					_btnGetReward.addEventListener(MouseEvent.CLICK, c154debed7c70e2795f2dc41478ae02f5);
				}
				MovieClip childByName4 = childByName.getChildByName<MovieClip>("mcRewardItem");
				if (childByName4 != null)
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
					_rewardSlot.c130648b59a0c8debea60aa153f844879(childByName4);
				}
			}
			cb468fa4c423bca714403647cc3f95552(_mailInfo);
		}

		protected void c2d4b6616c5d13a240f0d050133a6a00b(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			cb468fa4c423bca714403647cc3f95552(_mailInfo);
		}

		public void cb468fa4c423bca714403647cc3f95552(MailInfo c581d1dfdd43628e29bfec127d5c010fa)
		{
			if (c581d1dfdd43628e29bfec127d5c010fa == null)
			{
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
			string empty = string.Empty;
			string empty2 = string.Empty;
			if (c581d1dfdd43628e29bfec127d5c010fa.Mailtype == MailType.System)
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
				empty = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("MAIL_SYSTEM"));
				JSONObject jSONObject = JSONObject.Create(c581d1dfdd43628e29bfec127d5c010fa.Content);
				empty2 = string.Empty;
				if (jSONObject != null)
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
					JSONObject field = jSONObject.GetField("type");
					if (field != null)
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
						switch ((SystemMailType)(int)field.n)
						{
						case SystemMailType.Normal:
							empty2 = jSONObject.GetField("p1").str;
							break;
						case SystemMailType.KimBox:
							empty2 = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("MAIL_REWARD_CONTENT"));
							break;
						case SystemMailType.QuestReward:
							empty2 = LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("MAIL_QuestReward_CONTENT"));
							break;
						}
					}
				}
			}
			else
			{
				empty = c581d1dfdd43628e29bfec127d5c010fa.SenderName + LocalizedString.c00ae05b9ced94c9fc5f4be4892e6192b(new LocalizedString("MAIL_PLAYER"));
				empty2 = c581d1dfdd43628e29bfec127d5c010fa.Content;
			}
			if (_textSenderName != null)
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
				_textSenderName.text = empty;
			}
			if (_textMailContent != null)
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
				_textMailContent.text = empty2;
			}
			bool visible = c581d1dfdd43628e29bfec127d5c010fa.Mailtype != MailType.System;
			int num;
			if (c581d1dfdd43628e29bfec127d5c010fa.Mailtype == MailType.System)
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
				if (c581d1dfdd43628e29bfec127d5c010fa.Item != null)
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
					num = ((c581d1dfdd43628e29bfec127d5c010fa.Item.mItem != c0ed4f52263d3a82a03d748ded997d43b.c7088de59e49f7108f520cf7e0bae167e) ? 1 : 0);
					goto IL_019a;
				}
			}
			num = 0;
			goto IL_019a;
			IL_019a:
			bool visible2 = (byte)num != 0;
			_btnReply.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = visible;
			_btnGetReward.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = visible2;
			if (_textRewardTitle != null)
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
				_textRewardTitle.visible = visible2;
			}
			if (c581d1dfdd43628e29bfec127d5c010fa.Item != null)
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
				if (c581d1dfdd43628e29bfec127d5c010fa.Item.mItem != null)
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
					if (_rewardSlot.c76cc6288aad6ff8d562a2365e727c68c != null)
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
						switch (c581d1dfdd43628e29bfec127d5c010fa.Item.mItem.m_type)
						{
						case ItemType.Weapon:
						case ItemType.Shield:
						case ItemType.ClassMode:
						{
							Texture2D cf83e762e4368c5dedaab3e73ad69452e = c06ca0e618478c23eba3419653a19760f<DNAPortrait>.c5ee19dc8d4cccf5ae2de225410458b86.c6965e945a09324a9af86f14518e0a697(c581d1dfdd43628e29bfec127d5c010fa.Item.mItem);
							_rewardSlot.c76cc6288aad6ff8d562a2365e727c68c.c533af2b08173b7c2e3e5405efc254ee3(cf83e762e4368c5dedaab3e73ad69452e);
							_rewardSlot.c1d4a927ba62b28412f982cec1c20bc7a = true;
							_rewardSlot.c76cc6288aad6ff8d562a2365e727c68c.c150264a18c2cb408479d3f072cac8cc1 = true;
							_rewardSlot.cf11827593d70bd2d2c0ef6e439b1c9d9 = new ItemTips(c581d1dfdd43628e29bfec127d5c010fa.Item.mItem);
							break;
						}
						case ItemType.Material:
						{
							MovieClip movieClip = (c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3().c5a9245d284a4186b1df5f04b4559bab8<InventoryView>() as uniInventoryView).cf00e0520259191fd2faf4e52ef6f3ac0(c581d1dfdd43628e29bfec127d5c010fa.Item.mItem.m_materialType);
							MovieClip childByName = _rewardSlot.cf60cea27899464ecfab889519bbd47e7.getChildByName<MovieClip>("icon");
							_rewardSlot.c1d4a927ba62b28412f982cec1c20bc7a = false;
							if (childByName != null)
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
								_rewardSlot.cf60cea27899464ecfab889519bbd47e7.removeChild(childByName);
							}
							MovieClip movieClip2 = movieClip.newInstance();
							movieClip2.name = "icon";
							_rewardSlot.cf60cea27899464ecfab889519bbd47e7.addChild(movieClip2);
							_rewardSlot.c76cc6288aad6ff8d562a2365e727c68c.c533af2b08173b7c2e3e5405efc254ee3(c7e1395dd376890f1113e22916ff9ac07.c7088de59e49f7108f520cf7e0bae167e);
							_rewardSlot.c76cc6288aad6ff8d562a2365e727c68c.c150264a18c2cb408479d3f072cac8cc1 = false;
							_rewardSlot.cf11827593d70bd2d2c0ef6e439b1c9d9 = c403f7706ca94554a763547a002570309.c7088de59e49f7108f520cf7e0bae167e;
							break;
						}
						}
						_rewardSlot.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = true;
						goto IL_03da;
					}
				}
			}
			_rewardSlot.c89ef242f4744e0f1c4ffea4da8b79bc1.visible = false;
			goto IL_03da;
			IL_03da:
			_mailInfo = c581d1dfdd43628e29bfec127d5c010fa;
		}

		protected void cf54583639dfefee65deaa3957da7ef62(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			dispatchEvent(new cdd9021d4f44808fce2ab49c52f0db6f7("EVT_CLICK_REPLY", _mailInfo));
		}

		protected void c154debed7c70e2795f2dc41478ae02f5(CEvent c3d202dee321219a80026dc3081fb3c86)
		{
			dispatchEvent(new cdd9021d4f44808fce2ab49c52f0db6f7("EVT_CLICK_GETREWARD", _mailInfo));
		}
	}

	protected const string EVT_CLICK_MAILLIST_CLOSE = "EVT_CLICK_MAILLIST_CLOSE";

	protected const string EVT_LEFT_CLICK_MAILLIST_ITEM = "EVT_LEFT_CLICK_MAILLIST_ITEM";

	protected const string EVT_RIGHT_CLICK_MAILLIST_ITEM = "EVT_RIGHT_CLICK_MAILLIST_ITEM";

	protected const string EVT_CLICK_CREATE_NEW_MAIL = "EVT_CLICK_CREATE_NEW_MAIL";

	protected const string EVT_CLICK_MAILLIST = "EVT_CLICK_MAILLIST";

	protected const string EVT_CLICK_REPLY = "EVT_CLICK_REPLY";

	protected const string EVT_CLICK_GETREWARD = "EVT_CLICK_GETREWARD";

	protected const string EVT_CLICK_SEND = "EVT_CLICK_SEND";

	protected MailAnimaState _curState;

	protected MovieClip _mcRootAnimation;

	protected c196099a1254db61d3be10d70e14e7422 _container = new c196099a1254db61d3be10d70e14e7422();

	protected MailBox _mailBox = new MailBox();

	protected MailContentBoard _mailContentBoard = new MailContentBoard();

	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		base.cd93285db16841148ed53a5bbeb35cf20();
		_bActive = false;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c9a36e6e68967bc69944e0eaf2aa68d73("InboxMail.swf", "Whole", cf11b9e5fdcf31241331b2095623cc4c6);
	}

	protected void cf11b9e5fdcf31241331b2095623cc4c6(MovieClip c38166bc7092867b1eae7a76b075dbdbd)
	{
		_container = new c196099a1254db61d3be10d70e14e7422();
		_mailBox = new MailBox();
		_mailContentBoard = new MailContentBoard();
		_container.c130648b59a0c8debea60aa153f844879(c38166bc7092867b1eae7a76b075dbdbd);
		_mcRootAnimation = c38166bc7092867b1eae7a76b075dbdbd;
		_mcRootAnimation.visible = false;
		_mcRootAnimation.addFrameScript("InboxOpen", c2d4b6616c5d13a240f0d050133a6a00b);
		_mcRootAnimation.addFrameScript("InboxFadeOut", c2d4b6616c5d13a240f0d050133a6a00b);
		_mcRootAnimation.addFrameScript("DetailAppear", c2d4b6616c5d13a240f0d050133a6a00b);
		_mcRootAnimation.addFrameScript("normal", c2d4b6616c5d13a240f0d050133a6a00b);
		_mcRootAnimation.addFrameScript("PannelFadeOut", c2d4b6616c5d13a240f0d050133a6a00b);
		_mcRootAnimation.addFrameScript("ContentShrink", c2d4b6616c5d13a240f0d050133a6a00b);
		_mcRootAnimation.addFrameScript("InboxFadeOutEnd", c729f0f3da43fe351d2a333618a48a6db);
		_mcRootAnimation.addFrameScript("fadeoutend", c729f0f3da43fe351d2a333618a48a6db);
		_bActive = true;
	}

	public override void cac7688b05e921e2be3f92479ba44b4a8()
	{
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_container);
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cf7bb4834a40d20c49e6c144062b5916b("InboxMail.swf");
		_container = c9c0c8f01d2944aa6e09f167c382ebe52.c7088de59e49f7108f520cf7e0bae167e;
		_mailBox = null;
		_mailContentBoard = null;
	}

	protected override void cbf5f806ecf4d92b475f68040522616cf(bool c8be1fcd630e5fe96821376d111325750, bool c9e82bede03ea180ba65a597350997ad2 = false)
	{
		base.cbf5f806ecf4d92b475f68040522616cf(c8be1fcd630e5fe96821376d111325750, c9e82bede03ea180ba65a597350997ad2);
		if (_mcRootAnimation == null)
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
			if (c8be1fcd630e5fe96821376d111325750)
			{
				while (true)
				{
					switch (6)
					{
					case 0:
						break;
					default:
						(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).cb4341b3564e3d55dc9f38df4b813c5da(_container);
						_mcRootAnimation.visible = true;
						c97d099cec851d2f0e43a5c7679b91d70();
						cb220312ba4169f4e8539d19ff2cc826e(MailAnimaState.KickOff);
						c9c040a2d0edf8852c382f5612a6dfe82();
						c06ca0e618478c23eba3419653a19760f<GuidanceTipsManager>.c5ee19dc8d4cccf5ae2de225410458b86.c93a582e07019617943999be8717d5134("guidance_mail");
						return;
					}
				}
			}
			cb220312ba4169f4e8539d19ff2cc826e(MailAnimaState.Quit);
			return;
		}
	}

	protected override void c9c040a2d0edf8852c382f5612a6dfe82()
	{
		base.c9c040a2d0edf8852c382f5612a6dfe82();
		if (_mailBox == null)
		{
			return;
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
			_mailBox.c6a305f63e983b65571baec62c02e68cf(_mailInfoList);
			return;
		}
	}

	protected override void c2bf5de9410e290af8bda22039a6ab9b2(object c591d56a94543e3559945c497f37126c4)
	{
		base.c2bf5de9410e290af8bda22039a6ab9b2(c591d56a94543e3559945c497f37126c4);
		MailInfo mailInfo = c591d56a94543e3559945c497f37126c4 as MailInfo;
		if (mailInfo == null)
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
			c3f2eb1fe3e05b644222ef6a3f96fd9b2(mailInfo);
			return;
		}
	}

	protected override void c3f2eb1fe3e05b644222ef6a3f96fd9b2(MailInfo c581d1dfdd43628e29bfec127d5c010fa)
	{
		base.c3f2eb1fe3e05b644222ef6a3f96fd9b2(c581d1dfdd43628e29bfec127d5c010fa);
		if (c581d1dfdd43628e29bfec127d5c010fa == null)
		{
			while (true)
			{
				switch (4)
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
		c0af0340887d57a212d15eed714538f79(c581d1dfdd43628e29bfec127d5c010fa);
		cb220312ba4169f4e8539d19ff2cc826e(MailAnimaState.MailContent);
		_mailContentBoard.cb468fa4c423bca714403647cc3f95552(c581d1dfdd43628e29bfec127d5c010fa);
	}

	protected override void cfbc6cd6bdb17c11ccf2b97a9f4f290a1(int c12459f7fd9a58b1a6784df61f00ccdd9)
	{
		base.cfbc6cd6bdb17c11ccf2b97a9f4f290a1(c12459f7fd9a58b1a6784df61f00ccdd9);
		cb220312ba4169f4e8539d19ff2cc826e(MailAnimaState.MailList);
	}

	protected override void cb220312ba4169f4e8539d19ff2cc826e(MailAnimaState c7d77be03dd09783b7cf45209bd57d03e)
	{
		if (_curState == c7d77be03dd09783b7cf45209bd57d03e)
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
					return;
				}
			}
		}
		switch (c7d77be03dd09783b7cf45209bd57d03e)
		{
		case MailAnimaState.KickOff:
			_mcRootAnimation.gotoAndPlay("InboxOpen");
			break;
		case MailAnimaState.MailContent:
			_mcRootAnimation.gotoAndPlay("DetailAppear");
			break;
		case MailAnimaState.MailList:
			if (_curState != MailAnimaState.MailContent)
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
				if (_curState != MailAnimaState.Reply)
				{
					break;
				}
				while (true)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			_mcRootAnimation.gotoAndPlay("ContentShrink");
			break;
		case MailAnimaState.CreateNewMail:
			if (_curState != MailAnimaState.MailContent)
			{
				break;
			}
			while (true)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				break;
			}
			_mcRootAnimation.gotoAndPlay("ContentShrink");
			break;
		case MailAnimaState.Quit:
			if (_curState != MailAnimaState.MailList)
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
				if (_curState != MailAnimaState.KickOff)
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
					if (_curState != MailAnimaState.CreateNewMail)
					{
						_mcRootAnimation.gotoAndPlay("PannelFadeOut");
						break;
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
				}
			}
			_mcRootAnimation.gotoAndPlay("InboxFadeOut");
			break;
		}
		_curState = c7d77be03dd09783b7cf45209bd57d03e;
		_mailBox.c79c3f5edfd1dcb16b8552473da4fb938(c7d77be03dd09783b7cf45209bd57d03e);
	}

	protected void c2d4b6616c5d13a240f0d050133a6a00b(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		c97d099cec851d2f0e43a5c7679b91d70();
		c9c040a2d0edf8852c382f5612a6dfe82();
	}

	protected void c97d099cec851d2f0e43a5c7679b91d70()
	{
		MovieClip childByName = _mcRootAnimation.getChildByName<MovieClip>("mcInbox");
		if (childByName != null)
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
			MovieClip childByName2 = childByName.getChildByName<MovieClip>("mcMailBoxRoot");
			if (childByName2 != null)
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
				_mailBox.c130648b59a0c8debea60aa153f844879(childByName2);
				_mailBox.removeAllEventListeners("EVT_CLICK_CREATE_NEW_MAIL");
				_mailBox.removeAllEventListeners("EVT_CLICK_MAILLIST_CLOSE");
				_mailBox.removeAllEventListeners("EVT_LEFT_CLICK_MAILLIST_ITEM");
				_mailBox.removeAllEventListeners("EVT_RIGHT_CLICK_MAILLIST_ITEM");
				_mailBox.removeAllEventListeners("EVT_CLICK_SEND");
				_mailBox.removeAllEventListeners("EVT_CLICK_MAILLIST");
				_mailBox.addEventListener("EVT_CLICK_CREATE_NEW_MAIL", c005c9acc50941e967e5b77e44203ea3b);
				_mailBox.addEventListener("EVT_CLICK_MAILLIST_CLOSE", c522e2c09bb7d763f18225b301803db8b);
				_mailBox.addEventListener("EVT_LEFT_CLICK_MAILLIST_ITEM", c7bcf7ecec4dc808acd6f248212ece1aa);
				_mailBox.addEventListener("EVT_RIGHT_CLICK_MAILLIST_ITEM", c368ead34f78b806de6f4e0473b71b0d1);
				_mailBox.addEventListener("EVT_CLICK_SEND", cc6cd1f31336426bd80b307202236b2b5);
				_mailBox.addEventListener("EVT_CLICK_MAILLIST", cb60b05839dec3ffb86cda4d5dd2df280);
			}
		}
		MovieClip childByName3 = _mcRootAnimation.getChildByName<MovieClip>("mcMailContent");
		if (childByName3 == null)
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
			_mailContentBoard.c130648b59a0c8debea60aa153f844879(childByName3);
			_mailContentBoard.removeAllEventListeners("EVT_CLICK_REPLY");
			_mailContentBoard.addEventListener("EVT_CLICK_REPLY", cf54583639dfefee65deaa3957da7ef62);
			_mailContentBoard.removeAllEventListeners("EVT_CLICK_GETREWARD");
			_mailContentBoard.addEventListener("EVT_CLICK_GETREWARD", c154debed7c70e2795f2dc41478ae02f5);
			return;
		}
	}

	protected void c729f0f3da43fe351d2a333618a48a6db(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		_mcRootAnimation.visible = false;
		(c06ca0e618478c23eba3419653a19760f<AppManager>.c5ee19dc8d4cccf5ae2de225410458b86.cad4d42df23ad826d4b65d44d510c01a3() as UniUIManager).c27542a6dc8f97862ef53db1d4f3a6db8(_container);
	}

	protected void c522e2c09bb7d763f18225b301803db8b(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		cbf5f806ecf4d92b475f68040522616cf(false);
	}

	protected void c005c9acc50941e967e5b77e44203ea3b(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		if (_curState == MailAnimaState.Reply)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			cb220312ba4169f4e8539d19ff2cc826e(MailAnimaState.CreateNewMail);
			return;
		}
	}

	protected void cb60b05839dec3ffb86cda4d5dd2df280(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		cb220312ba4169f4e8539d19ff2cc826e(MailAnimaState.MailList);
	}

	protected void c7bcf7ecec4dc808acd6f248212ece1aa(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		cdd9021d4f44808fce2ab49c52f0db6f7 cdd9021d4f44808fce2ab49c52f0db6f = c3d202dee321219a80026dc3081fb3c86 as cdd9021d4f44808fce2ab49c52f0db6f7;
		if (cdd9021d4f44808fce2ab49c52f0db6f == null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			MailInfo mailInfo = cdd9021d4f44808fce2ab49c52f0db6f.c591d56a94543e3559945c497f37126c4 as MailInfo;
			if (mailInfo == null)
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
				c3f2eb1fe3e05b644222ef6a3f96fd9b2(mailInfo);
				return;
			}
		}
	}

	protected void c368ead34f78b806de6f4e0473b71b0d1(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		cdd9021d4f44808fce2ab49c52f0db6f7 cdd9021d4f44808fce2ab49c52f0db6f = c3d202dee321219a80026dc3081fb3c86 as cdd9021d4f44808fce2ab49c52f0db6f7;
		if (cdd9021d4f44808fce2ab49c52f0db6f == null)
		{
			return;
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			MailInfo mailInfo = cdd9021d4f44808fce2ab49c52f0db6f.c591d56a94543e3559945c497f37126c4 as MailInfo;
			if (mailInfo == null)
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
				cfa3d216ee6c8a280caacb43ec2d88010(mailInfo);
				return;
			}
		}
	}

	protected void cc6cd1f31336426bd80b307202236b2b5(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		cdd9021d4f44808fce2ab49c52f0db6f7 cdd9021d4f44808fce2ab49c52f0db6f = c3d202dee321219a80026dc3081fb3c86 as cdd9021d4f44808fce2ab49c52f0db6f7;
		if (cdd9021d4f44808fce2ab49c52f0db6f == null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			NewMailInfoContainer newMailInfoContainer = cdd9021d4f44808fce2ab49c52f0db6f.c591d56a94543e3559945c497f37126c4 as NewMailInfoContainer;
			if (newMailInfoContainer == null)
			{
				return;
			}
			while (true)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				c330521174d958b9cdc7af9387000e5a0(newMailInfoContainer);
				return;
			}
		}
	}

	protected void cf54583639dfefee65deaa3957da7ef62(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		cb220312ba4169f4e8539d19ff2cc826e(MailAnimaState.Reply);
		cdd9021d4f44808fce2ab49c52f0db6f7 cdd9021d4f44808fce2ab49c52f0db6f = c3d202dee321219a80026dc3081fb3c86 as cdd9021d4f44808fce2ab49c52f0db6f7;
		if (cdd9021d4f44808fce2ab49c52f0db6f == null)
		{
			return;
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			MailInfo mailInfo = cdd9021d4f44808fce2ab49c52f0db6f.c591d56a94543e3559945c497f37126c4 as MailInfo;
			if (mailInfo == null)
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
				_mailBox.c3e4b023f9e36d68f5768aa2046447f03(mailInfo.SenderName);
				return;
			}
		}
	}

	protected void c154debed7c70e2795f2dc41478ae02f5(CEvent c3d202dee321219a80026dc3081fb3c86)
	{
		cdd9021d4f44808fce2ab49c52f0db6f7 cdd9021d4f44808fce2ab49c52f0db6f = c3d202dee321219a80026dc3081fb3c86 as cdd9021d4f44808fce2ab49c52f0db6f7;
		if (cdd9021d4f44808fce2ab49c52f0db6f == null)
		{
			return;
		}
		while (true)
		{
			switch (7)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			MailInfo mailInfo = cdd9021d4f44808fce2ab49c52f0db6f.c591d56a94543e3559945c497f37126c4 as MailInfo;
			if (mailInfo == null)
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
				cf2c155218c6f8005bc83c51eaa64aafb(mailInfo);
				return;
			}
		}
	}
}
