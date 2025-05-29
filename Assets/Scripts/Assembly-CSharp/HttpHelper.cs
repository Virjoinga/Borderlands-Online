using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;

public class HttpHelper
{
	private class QueuedRequest
	{
		public string Method { get; set; }

		public string RemotePath { get; set; }

		public string Payload { get; set; }
	}

	private static HttpHelper mInstance;

	private Thread mThread;

	private Queue<QueuedRequest> mRequestQueue;

	private object mLockable;

	public static HttpHelper c5ee19dc8d4cccf5ae2de225410458b86
	{
		get
		{
			if (mInstance == null)
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
				if (1 == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				mInstance = new HttpHelper();
			}
			return mInstance;
		}
	}

	private HttpHelper()
	{
		mLockable = new object();
		mRequestQueue = new Queue<QueuedRequest>();
		mThread = new Thread(cda771c066a3234c3bcadc0e1e785d8e5);
		mThread.Start();
	}

	public void c792f1c0f8c1b48739428cedef1acbe53(string cb0c1ef29c7fcbdd20452581d386ee8c8, string cd58ed56479e69b5713707217e0f65564, JSONObject c591d56a94543e3559945c497f37126c4)
	{
		c792f1c0f8c1b48739428cedef1acbe53(cb0c1ef29c7fcbdd20452581d386ee8c8, cd58ed56479e69b5713707217e0f65564, c591d56a94543e3559945c497f37126c4.ToString());
	}

	private void c792f1c0f8c1b48739428cedef1acbe53(string cb0c1ef29c7fcbdd20452581d386ee8c8, string cd58ed56479e69b5713707217e0f65564, string c591d56a94543e3559945c497f37126c4)
	{
		string remotePath = "http://" + cb0c1ef29c7fcbdd20452581d386ee8c8 + cd58ed56479e69b5713707217e0f65564;
		lock (mLockable)
		{
			mRequestQueue.Enqueue(new QueuedRequest
			{
				Method = "POST",
				RemotePath = remotePath,
				Payload = c591d56a94543e3559945c497f37126c4
			});
		}
	}

	private void cda771c066a3234c3bcadc0e1e785d8e5()
	{
		while (true)
		{
			if (mRequestQueue.Count > 0)
			{
				try
				{
					QueuedRequest queuedRequest = null;
					lock (mLockable)
					{
						queuedRequest = mRequestQueue.Dequeue();
					}
					if (queuedRequest == null)
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
						if (1 == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						WebRequest webRequest = WebRequest.Create(new Uri(queuedRequest.RemotePath));
						webRequest.Timeout = 30000;
						webRequest.Method = queuedRequest.Method;
						if (!string.IsNullOrEmpty(queuedRequest.Payload))
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
							webRequest.ContentLength = queuedRequest.Payload.Length;
							Stream requestStream = webRequest.GetRequestStream();
							try
							{
								StreamWriter streamWriter = new StreamWriter(requestStream);
								try
								{
									streamWriter.Write(queuedRequest.Payload);
								}
								finally
								{
									if (streamWriter != null)
									{
										while (true)
										{
											switch (1)
											{
											case 0:
												continue;
											}
											((IDisposable)streamWriter).Dispose();
											break;
										}
									}
								}
							}
							finally
							{
								if (requestStream != null)
								{
									while (true)
									{
										switch (1)
										{
										case 0:
											continue;
										}
										((IDisposable)requestStream).Dispose();
										break;
									}
								}
							}
						}
						WebResponse response = webRequest.GetResponse();
						try
						{
						}
						finally
						{
							if (response != null)
							{
								while (true)
								{
									switch (3)
									{
									case 0:
										continue;
									}
									((IDisposable)response).Dispose();
									break;
								}
							}
						}
						break;
					}
				}
				catch (WebException)
				{
				}
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
			Thread.Sleep(100);
		}
	}
}
