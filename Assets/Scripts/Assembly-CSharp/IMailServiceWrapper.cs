public interface IMailServiceWrapper : IServiceWrapper
{
	void c8c71e978b55bc1d65cffa8cba32ed71f(OnSendMail c2db84530ef366a6deb001d449d4aa151, string c76759d33b9cb2580a3b145e1ba084675, string ca04b8fe5d43144ba3361431c00741486);

	void c890613d5d5185ad6eda570654aedce91(OnGotMailInfo c2db84530ef366a6deb001d449d4aa151);

	void c576f44b3071b0b941ce913d80b32bc52(OnReadMail c2db84530ef366a6deb001d449d4aa151, int ca5b7408e6e09760b0d233c71c059aec3);

	void ce7617ddfcf071c0b6b413615f347f61b(OnGetMailItem c2db84530ef366a6deb001d449d4aa151, int ca5b7408e6e09760b0d233c71c059aec3);

	void c094cd005fed2c85b5b372c1cd5d05775(OnDeleteMail c2db84530ef366a6deb001d449d4aa151, int ca5b7408e6e09760b0d233c71c059aec3);
}
