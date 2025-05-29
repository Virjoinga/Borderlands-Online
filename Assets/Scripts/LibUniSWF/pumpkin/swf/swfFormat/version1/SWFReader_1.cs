using System.Collections;
using UnityEngine;
using pumpkin.geom;
using pumpkin.geom.structs;
using pumpkin.swf.vm;

namespace pumpkin.swf.swfFormat.version1
{
	public class SWFReader_1 : ISWFReaderImpl
	{
		private SwfAssetContext context;

		private int m_Version;

		public void readSWF(SwfBinaryReader b, SwfAssetContext assetContext)
		{
			context = assetContext;
			m_Version = assetContext.version;
			Section section = new Section(b);
			section.readString();
			section.end();
			int num = b.ReadInt32();
			for (int i = 0; i < num; i++)
			{
				AssetBaseInfo assetBaseInfo = null;
				int num2 = b.ReadInt32();
				string className = readString(b);
				int num3 = b.ReadInt32();
				if (num2 == AssetBaseInfo.TYPE_MOVIECLIP_ASSET)
				{
					assetBaseInfo = readMovieClipAssetInfo(b);
				}
				else if (num2 == AssetBaseInfo.TYPE_BITMAP_ASSET)
				{
					assetBaseInfo = readBitmapAssetInfo(b);
				}
				else
				{
					if (num2 != AssetBaseInfo.TYPE_BITMAPFONT_ASSET)
					{
						break;
					}
					assetBaseInfo = readBitmapFontInfo(b);
				}
				if (assetBaseInfo != null)
				{
					assetBaseInfo.type = num2;
					assetBaseInfo.className = className;
					assetBaseInfo.cid = num3;
					assetBaseInfo.assetContext = context;
					context.exports[num3] = assetBaseInfo;
				}
			}
			context.sharedAssets = readString(b);
		}

		public MovieClipAssetInfo readMovieClipAssetInfo(SwfBinaryReader b)
		{
			Section section = new Section(b);
			MovieClipAssetInfo movieClipAssetInfo = new MovieClipAssetInfo();
			uint num = 0u;
			if (m_Version >= MovieClipReader.FORMAT_VERSION_7)
			{
				num = b.ReadUInt32();
			}
			int num2 = b.ReadInt32();
			for (int i = 0; i < num2; i++)
			{
				string key = readString(b);
				int value = b.ReadInt32();
				movieClipAssetInfo.labels[key] = value;
			}
			int num3 = b.ReadInt32();
			for (int j = 0; j < num3; j++)
			{
				Section section2 = new Section(b);
				FrameInfo frameInfo = new FrameInfo();
				int num4 = b.ReadInt32();
				for (int k = 0; k < num4; k++)
				{
					Section section3 = new Section(b);
					DisplayObjectInfo displayObjectInfo = new DisplayObjectInfo();
					if (m_Version >= MovieClipReader.FORMAT_VERSION_7)
					{
						uint num5 = b.ReadUInt32();
						displayObjectInfo.type = b.ReadInt32();
						displayObjectInfo.cid = b.ReadInt32();
						displayObjectInfo.instanceId = b.ReadInt32();
						displayObjectInfo.tranform = readTransformInfo(b);
						displayObjectInfo.name = readString(b);
						displayObjectInfo.userDataJSON = readString(b);
						if (displayObjectInfo.type == DisplayObjectInfo.TYPE_DYNAMICTEXT_INSTANCE)
						{
							displayObjectInfo.textInfo = new TextDisplayInfo();
							Section section4 = new Section(b);
							displayObjectInfo.textInfo.align = b.ReadInt32();
							displayObjectInfo.textInfo.text = readString(b);
							if (m_Version >= MovieClipReader.FORMAT_VERSION_4)
							{
								displayObjectInfo.textInfo.htmlText = readString(b);
								displayObjectInfo.textInfo.type = b.ReadInt32();
								displayObjectInfo.textInfo.multiline = b.ReadInt32();
								displayObjectInfo.textInfo.selectable = b.ReadInt32();
								displayObjectInfo.textInfo.color = readColorRGB(b);
							}
							if (m_Version >= MovieClipReader.FORMAT_VERSION_5)
							{
								displayObjectInfo.textInfo.maxChars = b.ReadInt32();
								displayObjectInfo.textInfo.letterSpacing = b.ReadSingle();
							}
							section4.end();
						}
						displayObjectInfo.isSimpleButton = b.ReadInt32() != 0;
						displayObjectInfo.maskInstanceId = b.ReadInt32();
						displayObjectInfo.isMask = b.ReadInt32() != 0;
						displayObjectInfo.blendMode = b.ReadInt32();
						displayObjectInfo.colorTransform = readColorRGB(b);
					}
					else
					{
						displayObjectInfo.type = b.ReadInt32();
						displayObjectInfo.cid = b.ReadInt32();
						displayObjectInfo.instanceId = b.ReadInt32();
						displayObjectInfo.tranform = readTransformInfo(b);
						displayObjectInfo.name = readString(b);
						displayObjectInfo.userDataJSON = readString(b);
						if (displayObjectInfo.type == DisplayObjectInfo.TYPE_DYNAMICTEXT_INSTANCE)
						{
							displayObjectInfo.textInfo = new TextDisplayInfo();
							Section section5 = new Section(b);
							displayObjectInfo.textInfo.align = b.ReadInt32();
							displayObjectInfo.textInfo.text = readString(b);
							if (m_Version >= MovieClipReader.FORMAT_VERSION_4)
							{
								displayObjectInfo.textInfo.htmlText = readString(b);
								displayObjectInfo.textInfo.type = b.ReadInt32();
								displayObjectInfo.textInfo.multiline = b.ReadInt32();
								displayObjectInfo.textInfo.selectable = b.ReadInt32();
								displayObjectInfo.textInfo.color = readColorRGB(b);
							}
							if (m_Version >= MovieClipReader.FORMAT_VERSION_5)
							{
								displayObjectInfo.textInfo.maxChars = b.ReadInt32();
								displayObjectInfo.textInfo.letterSpacing = b.ReadSingle();
							}
							section5.end();
						}
						if (m_Version >= MovieClipReader.FORMAT_VERSION_4)
						{
							displayObjectInfo.isSimpleButton = b.ReadInt32() != 0;
							displayObjectInfo.maskInstanceId = b.ReadInt32();
							displayObjectInfo.isMask = b.ReadInt32() != 0;
							displayObjectInfo.blendMode = b.ReadInt32();
							displayObjectInfo.colorTransform = readColorRGB(b);
						}
					}
					frameInfo.displayList.Add(displayObjectInfo);
					section3.end();
				}
				frameInfo.frameUserActionsXML = section2.readString();
				if (string.IsNullOrEmpty(frameInfo.frameUserActionsXML))
				{
					frameInfo.frameUserActionsXML = null;
				}
				if (m_Version >= MovieClipReader.FORMAT_VERSION_6)
				{
					SimpleActionVM.getGlobalVM();
					frameInfo.actions = LegacySimpleActionVMBinaryReader.decodeBinary(SimpleActionVM.registry, b, section2);
				}
				movieClipAssetInfo.addFrame(frameInfo);
				section2.end();
			}
			if (m_Version >= MovieClipReader.FORMAT_VERSION_7)
			{
				movieClipAssetInfo.shared = (num & MovieClipAssetInfo.FIELDBIT_shared) != 0;
				if ((num & MovieClipAssetInfo.FIELDBIT_scale9Grid) != 0)
				{
					movieClipAssetInfo.scale9grid = new Rectangle(readRect(b));
				}
			}
			else
			{
				movieClipAssetInfo.shared = b.ReadInt32() != 0;
			}
			section.end();
			return movieClipAssetInfo;
		}

		public BitmapAssetInfo readBitmapAssetInfo(SwfBinaryReader b)
		{
			BitmapAssetInfo bitmapAssetInfo = new BitmapAssetInfo();
			Section section = new Section(b);
			bitmapAssetInfo.srcRect = readRect(b);
			bitmapAssetInfo.shapeRect = readRect(b);
			bitmapAssetInfo.textureUri = section.readString();
			bitmapAssetInfo.pixelSize = section.readFloat();
			bitmapAssetInfo.isTransparent = section.readInt() == 1;
			bitmapAssetInfo.fileFormat = (byte)section.readInt();
			bitmapAssetInfo.embedeData = section.readByteArray();
			if (bitmapAssetInfo.embedeData != null && bitmapAssetInfo.embedeData.Length > 0)
			{
				BitmapAssetInfo bitmapAssetInfo2 = bitmapAssetInfo;
				Texture2D texture2D = new Texture2D(0, 0);
				texture2D.LoadImage(bitmapAssetInfo.embedeData);
				bitmapAssetInfo2.bitmapData = context.textureManager.createBitmapDataFromTexture(context.swfPrefix + bitmapAssetInfo.textureUri, texture2D);
				Vector2 vector = TextureManager.MaterialPixelSpaceToUVSpace(bitmapAssetInfo2.bitmapData, new Vector2(bitmapAssetInfo2.srcRect.x, bitmapAssetInfo2.srcRect.y));
				Vector2 vector2 = TextureManager.MaterialPixelSpaceToUVSpace(bitmapAssetInfo2.bitmapData, new Vector2(bitmapAssetInfo2.srcRect.width, bitmapAssetInfo2.srcRect.height));
				bitmapAssetInfo2.uvRect = new Rect(vector.x, vector.y, vector2.x, vector2.y);
			}
			section.end();
			return bitmapAssetInfo;
		}

		public BitmapFontAssetInfo readBitmapFontInfo(SwfBinaryReader b)
		{
			Section section = new Section(b);
			BitmapFontAssetInfo bitmapFontAssetInfo = new BitmapFontAssetInfo();
			int num = b.ReadInt32();
			for (int i = 0; i < num; i++)
			{
				Section section2 = new Section(b);
				BitmapFontCharInfo bitmapFontCharInfo = new BitmapFontCharInfo();
				string text = readString(b);
				if (text.Length > 0)
				{
					bitmapFontCharInfo.c = text[0];
				}
				bitmapFontCharInfo.cid = b.ReadInt32();
				bitmapFontCharInfo.topLine = b.ReadSingle();
				bitmapFontCharInfo.charWidth = b.ReadSingle();
				if (m_Version >= MovieClipReader.FORMAT_VERSION_5)
				{
					bitmapFontCharInfo.charHeight = b.ReadSingle();
					bitmapFontCharInfo.charStartX = b.ReadSingle();
					bitmapFontCharInfo.charStartY = b.ReadSingle();
				}
				if (m_Version >= MovieClipReader.FORMAT_VERSION_6)
				{
					bitmapFontCharInfo.minX = b.ReadSingle();
				}
				bitmapFontAssetInfo.characters[bitmapFontCharInfo.c] = bitmapFontCharInfo;
				section2.end();
			}
			bitmapFontAssetInfo.kerning = b.ReadSingle();
			bitmapFontAssetInfo.size = b.ReadSingle();
			bitmapFontAssetInfo.letterSpacing = b.ReadSingle();
			bitmapFontAssetInfo.name = readString(b);
			bitmapFontAssetInfo.style = readString(b);
			bitmapFontAssetInfo.text = readString(b);
			bitmapFontAssetInfo.align = b.ReadInt32();
			bitmapFontAssetInfo.shared = b.ReadInt32() != 0;
			bitmapFontAssetInfo.pixelSize = b.ReadSingle();
			bitmapFontAssetInfo.spaceWidth = b.ReadSingle();
			if (m_Version >= MovieClipReader.FORMAT_VERSION_4)
			{
				bitmapFontAssetInfo.color = readColorRGB(b);
				bitmapFontAssetInfo.bold = b.ReadInt32();
				bitmapFontAssetInfo.italic = b.ReadInt32();
				bitmapFontAssetInfo.underline = b.ReadInt32();
				bitmapFontAssetInfo.hasFilters = b.ReadInt32();
			}
			if (m_Version >= MovieClipReader.FORMAT_VERSION_5)
			{
				bitmapFontAssetInfo.filterJson = readString(b);
				bitmapFontAssetInfo.filterHash = readString(b);
				bitmapFontAssetInfo.instanceName = readString(b);
				bitmapFontAssetInfo.parentSymbolName = readString(b);
			}
			section.end();
			return bitmapFontAssetInfo;
		}

		private Matrix readMatrix(SwfBinaryReader b)
		{
			Section section = new Section(b);
			Matrix matrix = new Matrix();
			matrix.a = section.readFloat();
			matrix.b = section.readFloat();
			matrix.c = section.readFloat();
			matrix.d = section.readFloat();
			matrix.tx = section.readFloat();
			matrix.ty = section.readFloat();
			section.end();
			return matrix;
		}

		private void readMatrixRef(SwfBinaryReader b, ref SMatrix mat)
		{
			Section section = new Section(b);
			mat.a = section.readFloat();
			mat.b = section.readFloat();
			mat.c = section.readFloat();
			mat.d = section.readFloat();
			mat.tx = section.readFloat();
			mat.ty = section.readFloat();
			section.end();
		}

		private TransformInfo readTransformInfo(SwfBinaryReader b)
		{
			Section section = new Section(b);
			TransformInfo transformInfo = new TransformInfo();
			readMatrixRef(b, ref transformInfo.matrix);
			transformInfo.width = section.readFloat();
			transformInfo.height = section.readFloat();
			transformInfo.alpha = section.readFloat();
			transformInfo.visible = section.readInt() != 0;
			section.end();
			return transformInfo;
		}

		private Rect readRect(SwfBinaryReader b)
		{
			Section section = new Section(b);
			Rect result = default(Rect);
			result.x = section.readFloat();
			result.y = section.readFloat();
			result.width = section.readFloat();
			result.height = section.readFloat();
			section.end();
			return result;
		}

		private string readString(SwfBinaryReader b)
		{
			Section section = new Section(b);
			int num = b.ReadInt32();
			if (num < 0 || num > 665535)
			{
				return null;
			}
			string result = new string(b.ReadChars(num));
			section.end();
			return result;
		}

		private Color readColorRGB(SwfBinaryReader b)
		{
			Section section = new Section(b);
			Color result = default(Color);
			result.r = section.readFloat() / 255f;
			result.g = section.readFloat() / 255f;
			result.b = section.readFloat() / 255f;
			result.a = 1f;
			section.end();
			return result;
		}

		public IEnumerator readSWFCO(SwfBinaryReader b, SwfAssetContext assetContext, float swfStreampreloadDelay, int chunksPerStep)
		{
			Section headerSection = new Section(b);
			headerSection.readString();
			headerSection.end();
			int numObject = b.ReadInt32();
			int chunkNum = 0;
			for (int i = 0; i < numObject; i++)
			{
				AssetBaseInfo assetInfo2 = null;
				int type = b.ReadInt32();
				string className = readString(b);
				int cid = b.ReadInt32();
				if (type == AssetBaseInfo.TYPE_MOVIECLIP_ASSET)
				{
					assetInfo2 = readMovieClipAssetInfo(b);
				}
				else if (type == AssetBaseInfo.TYPE_BITMAP_ASSET)
				{
					assetInfo2 = readBitmapAssetInfo(b);
				}
				else
				{
					if (type != AssetBaseInfo.TYPE_BITMAPFONT_ASSET)
					{
						break;
					}
					assetInfo2 = readBitmapFontInfo(b);
				}
				if (assetInfo2 != null)
				{
					assetInfo2.type = type;
					assetInfo2.className = className;
					assetInfo2.cid = cid;
					assetInfo2.assetContext = context;
					context.exports[cid] = assetInfo2;
				}
				chunkNum++;
				if (chunkNum >= chunksPerStep)
				{
					yield return new WaitForEndOfFrame();
				}
			}
			context.sharedAssets = readString(b);
		}
	}
}
