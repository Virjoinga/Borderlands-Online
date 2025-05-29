namespace pumpkin.net
{
	public class URLRequest
	{
		public bool routeInternal = false;

		public string data;

		public string method = URLRequestMethod.GET;

		public string contentType = "application/x-www-form-urlencoded";

		public string url;

		public URLRequest()
		{
		}

		public URLRequest(string url)
		{
			this.url = url;
		}
	}
}
