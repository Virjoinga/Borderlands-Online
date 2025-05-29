using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using pumpkin.geom;
using pumpkin.geom.structs;
using pumpkin.swf.vm;

namespace pumpkin.swf.swfFormat.version8
{
	public class SWFReader_8 : ISWFReaderImpl
	{
		public static bool readOnlyEmbededTexture = true;

		private SwfAssetContext context;

		private static Section headerSection = new Section();

		private static Section movieClipSection = new Section();

		private static Section bitmapAssetInfoSection = new Section();

		public void readSWF(SwfBinaryReader b, SwfAssetContext assetContext)
		{
			context = assetContext;
			headerSection.initFromReader(b);
			headerSection.readString();
			headerSection.end();
			int num = b.ReadInt32();
			if (num < 0 || num > 655354)
			{
				throw new SwfSerializerException("Invalid string table size: " + num);
			}
			assetContext.stringTable = new string[num];
			for (int i = 0; i < num; i++)
			{
				assetContext.stringTable[i] = readString(b);
			}
			int num2 = b.ReadInt32();
			for (int j = 0; j < num2; j++)
			{
				AssetBaseInfo assetBaseInfo = null;
				int num3 = b.ReadInt32();
				string className = readStringNonBoxed(b);
				int num4 = b.ReadInt32();
				if (num3 == AssetBaseInfo.TYPE_MOVIECLIP_ASSET)
				{
					assetBaseInfo = readMovieClipAssetInfo(b);
				}
				else if (num3 == AssetBaseInfo.TYPE_BITMAP_ASSET)
				{
					assetBaseInfo = readBitmapAssetInfo(b);
				}
				else if (num3 == AssetBaseInfo.TYPE_BITMAPFONT_ASSET)
				{
					assetBaseInfo = readBitmapFontInfo(b);
				}
				else
				{
					if (num3 != AssetBaseInfo.TYPE_SIMPLESHAPE_ASSET)
					{
						break;
					}
					assetBaseInfo = readSimpleShapeInfo(b);
				}
				if (assetBaseInfo != null)
				{
					assetBaseInfo.type = num3;
					assetBaseInfo.className = className;
					assetBaseInfo.cid = num4;
					assetBaseInfo.assetContext = context;
					context.exports[num4] = assetBaseInfo;
				}
			}
			context.sharedAssets = readString(b);
		}

		public MovieClipAssetInfo readMovieClipAssetInfo(SwfBinaryReader b)
		{
			movieClipSection.initFromReader(b);
			if (movieClipSection.type != MovieClipReader.TYPE_MOVIECLIPASSETINFO)
			{
				throw new SwfSerializerException("Expected MovieClipAssetInfo, got: " + movieClipSection.type);
			}
			MovieClipAssetInfo movieClipAssetInfo = new MovieClipAssetInfo();
			uint num = 0u;
			num = b.ReadUInt32();
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
				FrameInfo frameInfo = new FrameInfo();
				int num4 = b.ReadInt32();
				for (int k = 0; k < num4; k++)
				{
					DisplayObjectInfo displayObjectInfo = new DisplayObjectInfo();
					ushort num5 = b.ReadUInt16();
					if ((num5 & DisplayObjectInfo.FIELDBIT_noChange) != 0)
					{
						int num6 = b.ReadInt32();
						if (movieClipAssetInfo.frames.Count == 0)
						{
							throw new SwfSerializerException("Keyframe reference error, zero frame count");
						}
						FrameInfo frameInfo2 = movieClipAssetInfo.frames[movieClipAssetInfo.frames.Count - 1];
						if (num6 < 0 || num6 >= frameInfo2.displayList.Count)
						{
							throw new SwfSerializerException("Keyframe reference error, prevDispIndex '" + num6 + "' is out of range of '" + frameInfo2.displayList.Count);
						}
						displayObjectInfo = frameInfo2.displayList[num6];
						if (displayObjectInfo == null)
						{
							displayObjectInfo = new DisplayObjectInfo();
							Debug.LogError("failed to find referenced DisplayObjectInfo index=" + num6);
						}
					}
					else
					{
						displayObjectInfo.isSimpleButton = (num5 & DisplayObjectInfo.FIELDBIT_isSimpleButton) != 0;
						displayObjectInfo.isMask = (num5 & DisplayObjectInfo.FIELDBIT_isMask) != 0;
						displayObjectInfo.type = b.ReadByte();
						displayObjectInfo.cid = b.ReadInt32();
						displayObjectInfo.instanceId = b.ReadInt32();
						displayObjectInfo.tranform = readTransformInfoNonBoxed(b);
						displayObjectInfo.name = readSmallStringNonBoxed(b);
						displayObjectInfo.userDataJSON = readStringNonBoxed(b);
						if (displayObjectInfo.type == DisplayObjectInfo.TYPE_DYNAMICTEXT_INSTANCE)
						{
							displayObjectInfo.textInfo = new TextDisplayInfo();
							Section section = new Section(b);
							displayObjectInfo.textInfo.align = b.ReadInt32();
							displayObjectInfo.textInfo.text = readString(b);
							displayObjectInfo.textInfo.htmlText = readString(b);
							displayObjectInfo.textInfo.type = b.ReadInt32();
							displayObjectInfo.textInfo.multiline = b.ReadInt32();
							displayObjectInfo.textInfo.selectable = b.ReadInt32();
							displayObjectInfo.textInfo.color = readColorRGB(b);
							displayObjectInfo.textInfo.maxChars = b.ReadInt32();
							displayObjectInfo.textInfo.letterSpacing = b.ReadSingle();
							section.end();
						}
						if ((num5 & DisplayObjectInfo.FIELDBIT_maskInstanceId) != 0)
						{
							displayObjectInfo.maskInstanceId = b.ReadInt32();
						}
						displayObjectInfo.blendMode = b.ReadByte();
						displayObjectInfo.colorTransform = readColorRGBNonBoxed(b);
					}
					frameInfo.displayList.Add(displayObjectInfo);
				}
				frameInfo.frameUserActionsXML = readStringNonBoxed(b);
				if (string.IsNullOrEmpty(frameInfo.frameUserActionsXML))
				{
					frameInfo.frameUserActionsXML = null;
				}
				SimpleActionVM.getGlobalVM();
				frameInfo.actions = SimpleActionVMBinaryReader.decodeBinary(SimpleActionVM.registry, b);
				movieClipAssetInfo.addFrame(frameInfo);
			}
			movieClipAssetInfo.shared = (num & MovieClipAssetInfo.FIELDBIT_shared) != 0;
			if ((num & MovieClipAssetInfo.FIELDBIT_scale9Grid) != 0)
			{
				movieClipAssetInfo.scale9grid = new Rectangle(readRectNonBoxed(b));
			}
			movieClipSection.end();
			return movieClipAssetInfo;
		}

		public string readStringTable(SwfBinaryReader b)
		{
			uint num = b.ReadUInt32();
			if (num < 0 || num > 999999)
			{
				throw new SwfSerializerException("Invalid string id: " + num);
			}
			return context.stringTable[num];
		}

		public BitmapAssetInfo readBitmapAssetInfo(SwfBinaryReader b)
		{
			BitmapAssetInfo bitmapAssetInfo = new BitmapAssetInfo();
			bitmapAssetInfoSection.initFromReader(b);
			uint num = b.ReadUInt32();
			bitmapAssetInfo.isTransparent = (num & BitmapAssetInfo.FIELDBIT_isTransparent) != 0;
			bitmapAssetInfo.textureReadWrite = (num & BitmapAssetInfo.FIELDBIT_textureReadWrite) != 0;
			bitmapAssetInfo.srcRect = readRectNonBoxed(b);
			bitmapAssetInfo.shapeRect = readRectNonBoxed(b);
			bitmapAssetInfo.textureUri = readStringTable(b);
			bitmapAssetInfo.pixelSize = b.ReadSingle();
			bitmapAssetInfo.fileFormat = b.ReadByte();
			bitmapAssetInfo.embedeData = readByteArrayNonBoxed(b);
			if (bitmapAssetInfo.embedeData != null && bitmapAssetInfo.embedeData.Length > 0)
			{
				BitmapAssetInfo bitmapAssetInfo2 = bitmapAssetInfo;
				Texture2D texture2D = new Texture2D(0, 0);
				texture2D.LoadImage(bitmapAssetInfo.embedeData);
				if (readOnlyEmbededTexture)
				{
					texture2D.Apply(false, true);
				}
				bitmapAssetInfo.embedeData = null;
				bitmapAssetInfo2.bitmapData = context.textureManager.createBitmapDataFromTexture(context.swfPrefix + bitmapAssetInfo.textureUri, texture2D);
				Vector2 vector = TextureManager.MaterialPixelSpaceToUVSpace(bitmapAssetInfo2.bitmapData, new Vector2(bitmapAssetInfo2.srcRect.x, bitmapAssetInfo2.srcRect.y));
				Vector2 vector2 = TextureManager.MaterialPixelSpaceToUVSpace(bitmapAssetInfo2.bitmapData, new Vector2(bitmapAssetInfo2.srcRect.width, bitmapAssetInfo2.srcRect.height));
				bitmapAssetInfo2.uvRect = new Rect(vector.x, vector.y, vector2.x, vector2.y);
			}
			bitmapAssetInfoSection.end();
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
				bitmapFontCharInfo.charHeight = b.ReadSingle();
				bitmapFontCharInfo.charStartX = b.ReadSingle();
				bitmapFontCharInfo.charStartY = b.ReadSingle();
				bitmapFontCharInfo.minX = b.ReadSingle();
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
			bitmapFontAssetInfo.color = readColorRGB(b);
			bitmapFontAssetInfo.bold = b.ReadInt32();
			bitmapFontAssetInfo.italic = b.ReadInt32();
			bitmapFontAssetInfo.underline = b.ReadInt32();
			bitmapFontAssetInfo.hasFilters = b.ReadInt32();
			bitmapFontAssetInfo.filterJson = readString(b);
			bitmapFontAssetInfo.filterHash = readString(b);
			bitmapFontAssetInfo.instanceName = readString(b);
			bitmapFontAssetInfo.parentSymbolName = readString(b);
			section.end();
			return bitmapFontAssetInfo;
		}

		private Matrix readMatrixNonBoxed(SwfBinaryReader b)
		{
			Matrix matrix = new Matrix();
			matrix.a = b.ReadSingle();
			matrix.b = b.ReadSingle();
			matrix.c = b.ReadSingle();
			matrix.d = b.ReadSingle();
			matrix.tx = b.ReadSingle();
			matrix.ty = b.ReadSingle();
			return matrix;
		}

		private void readMatrixNonBoxedRef(SwfBinaryReader b, ref SMatrix mat)
		{
			mat.a = b.ReadSingle();
			mat.b = b.ReadSingle();
			mat.c = b.ReadSingle();
			mat.d = b.ReadSingle();
			mat.tx = b.ReadSingle();
			mat.ty = b.ReadSingle();
		}

		private TransformInfo readTransformInfoNonBoxed(SwfBinaryReader b)
		{
			TransformInfo transformInfo = new TransformInfo();
			readMatrixNonBoxedRef(b, ref transformInfo.matrix);
			transformInfo.width = b.ReadSingle();
			transformInfo.height = b.ReadSingle();
			transformInfo.alpha = b.ReadSingle();
			transformInfo.visible = b.ReadByte() != 0;
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

		private Rect readRectNonBoxed(SwfBinaryReader b)
		{
			Rect result = default(Rect);
			result.x = b.ReadSingle();
			result.y = b.ReadSingle();
			result.width = b.ReadSingle();
			result.height = b.ReadSingle();
			return result;
		}

		private string readString(SwfBinaryReader b)
		{
			int num = b.ReadInt32();
			if (num < 0 || num > 665535)
			{
				return null;
			}
			return new string(b.ReadChars(num));
		}

		private string readStringNonBoxed(SwfBinaryReader b)
		{
			int num = b.ReadInt32();
			if (num < 0 || num > 665535)
			{
				return null;
			}
			return new string(b.ReadChars(num));
		}

		public static string readSmallStringNonBoxed(SwfBinaryReader b)
		{
			int num = b.ReadInt16();
			if (num < 0 || num > 665535)
			{
				return null;
			}
			return new string(b.ReadChars(num));
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

		private Color readColorRGBNonBoxed(SwfBinaryReader b)
		{
			Color result = default(Color);
			result.r = (float)(int)b.ReadByte() / 255f;
			result.g = (float)(int)b.ReadByte() / 255f;
			result.b = (float)(int)b.ReadByte() / 255f;
			result.a = 1f;
			return result;
		}

		public byte[] readByteArrayNonBoxed(SwfBinaryReader b)
		{
			int num = b.ReadInt32();
			if (num < 0 || num > 665535)
			{
				return null;
			}
			return b.ReadBytes(num);
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

		public SimpleShapeAssetInfo readSimpleShapeInfo(SwfBinaryReader b)
		{
			Section section = new Section(b);
			SimpleShapeAssetInfo simpleShapeAssetInfo = new SimpleShapeAssetInfo();
			simpleShapeAssetInfo.drawOPs = new List<SimpleShapeGraphicsOP>();
			int num = b.ReadInt32();
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				SimpleShapeGraphicsOP simpleShapeGraphicsOP = readSimpleShapeDrawOP(b);
				if (simpleShapeGraphicsOP != null)
				{
					simpleShapeAssetInfo.drawOPs.Add(simpleShapeGraphicsOP);
				}
			}
			section.end();
			return simpleShapeAssetInfo;
		}

		public SimpleShapeGraphicsOP readSimpleShapeDrawOP(SwfBinaryReader b)
		{
			Section section = new Section(b);
			SimpleShapeGraphicsOP simpleShapeGraphicsOP = new SimpleShapeGraphicsOP();
			simpleShapeGraphicsOP.opType = b.ReadByte();
			uint num = b.ReadUInt32();
			if ((num & SimpleShapeGraphicsOP.FIELDBIT_pos) != 0)
			{
				simpleShapeGraphicsOP.pos.x = b.ReadSingle();
				simpleShapeGraphicsOP.pos.y = b.ReadSingle();
			}
			if ((num & SimpleShapeGraphicsOP.FIELDBIT_bitmapCid) != 0)
			{
				simpleShapeGraphicsOP.bitmapCid = b.ReadInt32();
			}
			if ((num & SimpleShapeGraphicsOP.FIELDBIT_color) != 0)
			{
				simpleShapeGraphicsOP.color = b.ReadInt32();
			}
			if ((num & SimpleShapeGraphicsOP.FIELDBIT_matrix) != 0)
			{
				simpleShapeGraphicsOP.matrix = readMatrixNonBoxed(b);
			}
			section.end();
			return simpleShapeGraphicsOP;
		}
	}
}
