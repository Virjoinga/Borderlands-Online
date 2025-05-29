using System;
using UnityEngine;
using pumpkin.events;
using pumpkin.swf;
using pumpkin.swf.vm.ops;
using pumpkin.ui;

namespace pumpkin.display
{
	public class MovieClip : MovieClipPlayer
	{
		public SwfURI swfUri;

		public MovieClip()
			: base(null, null)
		{
			swfUri = new SwfURI(null);
		}

		public MovieClip(ISwfResourceLoader resourceLoader, string linkage)
			: base(null, null)
		{
			initUri(resourceLoader, new SwfURI(linkage));
		}

		public MovieClip(string linkage)
			: base(null, null)
		{
			initUri(new SwfURI(linkage));
		}

		public MovieClip(string swf, string symbolName)
			: base(null, null)
		{
			SwfURI uri = new SwfURI(swf + ":" + symbolName);
			initUri(uri);
		}

		public MovieClip(SwfURI uri)
			: base(null, null)
		{
			initUri(uri);
		}

		internal MovieClip(SwfAssetContext assetContext, string symbolName)
			: base(assetContext, symbolName)
		{
		}

		protected void initUri(ISwfResourceLoader resourceLoader, SwfURI uri)
		{
			if (uri != null && uri.swf != null && uri.swf.Length != 0)
			{
				swfUri = uri;
				m_AssetContext = resourceLoader.loadSWF(swfUri.swf);
				if (swfUri.linkage != null)
				{
					setSymbolName(swfUri.linkage);
				}
				if (swfUri.label != null)
				{
					gotoAndStop(swfUri.label);
				}
			}
		}

		protected void initUri(SwfURI uri)
		{
			if (uri != null && uri.swf != null && uri.swf.Length != 0)
			{
				swfUri = uri;
				m_AssetContext = MovieClipPlayer._preloadSWF(swfUri.swf);
				if (swfUri.linkage != null)
				{
					setSymbolName(swfUri.linkage);
				}
				if (swfUri.label != null)
				{
					gotoAndStop(swfUri.label);
				}
			}
		}

		public void gotoAndStop(object to)
		{
			setPlayState(0);
			if (to is string)
			{
				setFrameLabel((string)to);
			}
			else if (to is int)
			{
				setFrame((int)to);
			}
		}

		public void gotoAndPlay(object to)
		{
			setPlayState(1);
			if (to is string)
			{
				setFrameLabel((string)to);
			}
			else if (to is int)
			{
				setFrame((int)to);
			}
		}

		public void stop()
		{
			setPlayState(0);
		}

		public void stopAll()
		{
			stop();
			for (int i = 0; i < base.numChildren; i++)
			{
				DisplayObject childAt = getChildAt(i);
				if (childAt is MovieClip)
				{
					(childAt as MovieClip).stopAll();
				}
			}
		}

		public void play()
		{
			setPlayState(1);
		}

		public void playBackwards()
		{
			setPlayState(2);
		}

		public override void updateFrame(CEvent e)
		{
			base.updateFrame(e);
		}

		public MovieClip newInstance()
		{
			if (MovieClipPlayer.g_MovieClipClassMap != null)
			{
				MovieClipAssetInfo movieInfoByName = base.assetContext.getMovieInfoByName(m_SymbolName);
				if (!string.IsNullOrEmpty(movieInfoByName.className) && MovieClipPlayer.g_MovieClipClassMap.ContainsKey(movieInfoByName.className))
				{
					MovieClip movieClip = (MovieClip)Activator.CreateInstance(MovieClipPlayer.g_MovieClipClassMap[movieInfoByName.className]);
					movieClip.setSymbolByCid(base.assetContext, movieInfoByName.cid);
					if (movieClip != null)
					{
						return movieClip;
					}
					Debug.LogWarning(string.Concat("Failed to instantate MovieClip class mapping of type '", MovieClipPlayer.g_MovieClipClassMap[movieInfoByName.className], "'"));
				}
			}
			return new MovieClip(base.assetContext, m_SymbolName);
		}

		public MovieClipLayout getMovieClipLayout()
		{
			return GuiInitOP.getLayout(this);
		}
	}
}
