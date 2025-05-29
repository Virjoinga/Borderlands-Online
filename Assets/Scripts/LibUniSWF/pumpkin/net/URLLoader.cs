using System.Text;
using UnityEngine;
using pumpkin.events;

namespace pumpkin.net
{
	public class URLLoader : EventDispatcher
	{
		public delegate void RequestHandler(URLLoader loader, URLRequest request);

		public static RequestHandler requestHandler = loadImpl;

		public bool loading = false;

		public string data;

		public WWW www;

		public bool cancelled = false;

		public URLRequest request;

		public void load(URLRequest request)
		{
			requestHandler(this, request);
		}

		public void close()
		{
			cancelled = true;
		}

		protected static void loadImpl(URLLoader loader, URLRequest request)
		{
			if (request != null && !loader.loading)
			{
				loader.request = request;
				if (request.method == "POST")
				{
					byte[] bytes = Encoding.ASCII.GetBytes(request.data);
					loader.www = new WWW(request.url, bytes);
				}
				else
				{
					loader.www = new WWW(request.url);
				}
				URLLoaderManager.getInstance().addLoadRequest(loader);
			}
		}
	}
}
