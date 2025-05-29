internal class ChatServiceWarpper : ServiceWrapper<IChatServiceWrapper, ChatServiceWarpper>
{
	public override void cd93285db16841148ed53a5bbeb35cf20()
	{
		m_wrapperOnline = new ChatServiceWrapperOnline();
		base.cd93285db16841148ed53a5bbeb35cf20();
	}

	public void cb8dcf26100ed296de16c03054668e4a3(OnChat c2db84530ef366a6deb001d449d4aa151, byte c60cae76d65f1a4f1b2b01da404f738b0, int c1cc10478b0fb75a49477a8f3df0d162c, string c76759d33b9cb2580a3b145e1ba084675, string ca04b8fe5d43144ba3361431c00741486, byte[] c869de72ad8783f7d8dd3eff78f110bae)
	{
		m_wrapperOnline.cb8dcf26100ed296de16c03054668e4a3(c2db84530ef366a6deb001d449d4aa151, c60cae76d65f1a4f1b2b01da404f738b0, c1cc10478b0fb75a49477a8f3df0d162c, c76759d33b9cb2580a3b145e1ba084675, ca04b8fe5d43144ba3361431c00741486, c869de72ad8783f7d8dd3eff78f110bae);
	}

	public void c99ae00bed7f8b90460dead1f6df257e8(OnNewChat c2db84530ef366a6deb001d449d4aa151)
	{
		m_wrapperOnline.c99ae00bed7f8b90460dead1f6df257e8(c2db84530ef366a6deb001d449d4aa151);
	}

	public void cc8d3253f8397c4475d7f6d887b02c64e(OnNewChat c2db84530ef366a6deb001d449d4aa151)
	{
		m_wrapperOnline.cc8d3253f8397c4475d7f6d887b02c64e(c2db84530ef366a6deb001d449d4aa151);
	}

	public void c26284ca2d02d3aa0631d68ff992ed262(OnChatOK c2db84530ef366a6deb001d449d4aa151)
	{
		m_wrapperOnline.c26284ca2d02d3aa0631d68ff992ed262(c2db84530ef366a6deb001d449d4aa151);
	}

	public void cf536a49fbacf1808b502e8e454bda345(OnChatOK c2db84530ef366a6deb001d449d4aa151)
	{
		m_wrapperOnline.cf536a49fbacf1808b502e8e454bda345(c2db84530ef366a6deb001d449d4aa151);
	}
}
