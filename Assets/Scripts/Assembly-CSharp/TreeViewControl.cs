using System.Collections.Generic;
using A;
using Core;
using UnityEngine;

public class TreeViewControl : MonoBehaviour
{
	public enum DisplayTypes
	{
		NONE = 0,
		USE_SCROLL_VIEW = 1,
		USE_SCROLL_AREA = 2
	}

	public int X;

	public int Y;

	public int Width = 400;

	public int Height = 400;

	public bool IsExpanded = true;

	public bool IsHoverEnabled = true;

	public bool IsHoverAnimationEnabled;

	public bool DisplayOnGame;

	public bool DisplayOnScene = true;

	public bool DisplayInInspector;

	public TreeViewItem m_roomItem;

	public GUISkin m_skinHover;

	public GUISkin m_skinUnselected;

	public GUISkin m_skinSelected;

	public Texture2D m_textureBlank;

	public Texture2D m_textureGuide;

	public Texture2D m_textureLastSiblingCollapsed;

	public Texture2D m_textureLastSiblingExpanded;

	public Texture2D m_textureLastSiblingNoChild;

	public Texture2D m_textureMiddleSiblingCollapsed;

	public Texture2D m_textureMiddleSiblingExpanded;

	public Texture2D m_textureMiddleSiblingNoChild;

	public Texture2D m_textureNormalChecked;

	public Texture2D m_textureNormalUnchecked;

	public Texture2D m_textureSelectedBackground;

	public bool m_forceButtonText;

	public bool m_forceDefaultSkin;

	public TreeViewItem HoverItem;

	public TreeViewItem SelectedItem;

	private Vector2 m_scrollView = Vector2.zero;

	public TreeViewItem c6026719265ab76e906dafcd44294f76c
	{
		get
		{
			if (m_roomItem == null)
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
				m_roomItem = new TreeViewItem(this, ce1ba96a626699b6764f4c071143b0d7b.c7088de59e49f7108f520cf7e0bae167e)
				{
					Header = "Root item"
				};
			}
			return m_roomItem;
		}
	}

	public string cdf97cd075f0c2047a15ceb348bb72c54
	{
		get
		{
			return c6026719265ab76e906dafcd44294f76c.Header;
		}
		set
		{
			c6026719265ab76e906dafcd44294f76c.Header = value;
		}
	}

	public object c05ec8775d6819fdbfa114704b7e97042
	{
		get
		{
			return c6026719265ab76e906dafcd44294f76c.DataContext;
		}
		set
		{
			c6026719265ab76e906dafcd44294f76c.DataContext = value;
		}
	}

	public List<TreeViewItem> c1c22eabcddf2eb7b2a6a37ab94961db2
	{
		get
		{
			return c6026719265ab76e906dafcd44294f76c.Items;
		}
		set
		{
			c6026719265ab76e906dafcd44294f76c.Items = value;
		}
	}

	private GUIStyle cec884cea09a429bdead78f8710ba610d(Texture2D c619f1ccb945254bec1f5f1073515b5be)
	{
		GUIStyle gUIStyle = new GUIStyle();
		gUIStyle.normal.background = c619f1ccb945254bec1f5f1073515b5be;
		return gUIStyle;
	}

	private bool c470e6d328d66066109ebf6978e0b0ab3(Texture2D c619f1ccb945254bec1f5f1073515b5be)
	{
		GUIStyle style = cec884cea09a429bdead78f8710ba610d(c619f1ccb945254bec1f5f1073515b5be);
		string empty = string.Empty;
		GUILayoutOption[] array = c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(2);
		array[0] = GUILayout.Width(c619f1ccb945254bec1f5f1073515b5be.width);
		array[1] = GUILayout.MaxHeight(c619f1ccb945254bec1f5f1073515b5be.height);
		return GUILayout.Button(empty, style, array);
	}

	public bool c8118758f6a102f80d76e6f3a1652a12c(TreeViewItem.TextureIcons ca57e1c076c01141c5ce58c7341db7833)
	{
		switch (ca57e1c076c01141c5ce58c7341db7833)
		{
		case TreeViewItem.TextureIcons.BLANK:
		{
			if (!(null == m_textureGuide))
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
				if (!m_forceButtonText)
				{
					string empty2 = string.Empty;
					GUIStyle style2 = cec884cea09a429bdead78f8710ba610d(m_textureBlank);
					GUILayoutOption[] array5 = c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(2);
					array5[0] = GUILayout.MaxWidth(4f);
					array5[1] = GUILayout.MaxHeight(m_textureGuide.height);
					GUILayout.Label(empty2, style2, array5);
					goto IL_00d4;
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
			}
			string empty3 = string.Empty;
			GUILayoutOption[] array6 = c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(1);
			array6[0] = GUILayout.MaxWidth(4f);
			GUILayout.Label(empty3, array6);
			goto IL_00d4;
		}
		case TreeViewItem.TextureIcons.GUIDE:
		{
			if (!(null == m_textureGuide))
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
				if (!m_forceButtonText)
				{
					string empty = string.Empty;
					GUIStyle style = cec884cea09a429bdead78f8710ba610d(m_textureGuide);
					GUILayoutOption[] array2 = c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(2);
					array2[0] = GUILayout.MaxWidth(m_textureGuide.width);
					array2[1] = GUILayout.MaxHeight(m_textureGuide.height);
					GUILayout.Label(empty, style, array2);
					goto IL_0175;
				}
				while (true)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			GUILayoutOption[] array3 = c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(1);
			array3[0] = GUILayout.MaxWidth(16f);
			GUILayout.Label("|", array3);
			goto IL_0175;
		}
		case TreeViewItem.TextureIcons.LAST_SIBLING_COLLAPSED:
		{
			if (!(null == m_textureLastSiblingCollapsed))
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
				if (!m_forceButtonText)
				{
					return c470e6d328d66066109ebf6978e0b0ab3(m_textureLastSiblingCollapsed);
				}
				while (true)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			GUILayoutOption[] array7 = c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(1);
			array7[0] = GUILayout.MaxWidth(16f);
			return GUILayout.Button("<", array7);
		}
		case TreeViewItem.TextureIcons.LAST_SIBLING_EXPANDED:
		{
			if (!(null == m_textureLastSiblingExpanded))
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
				if (!m_forceButtonText)
				{
					return c470e6d328d66066109ebf6978e0b0ab3(m_textureLastSiblingExpanded);
				}
				while (true)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			GUILayoutOption[] array11 = c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(1);
			array11[0] = GUILayout.MaxWidth(16f);
			return GUILayout.Button(">", array11);
		}
		case TreeViewItem.TextureIcons.LAST_SIBLING_NO_CHILD:
		{
			if (!(null == m_textureLastSiblingNoChild))
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
				if (!m_forceButtonText)
				{
					return c470e6d328d66066109ebf6978e0b0ab3(m_textureLastSiblingNoChild);
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
			GUILayoutOption[] array12 = c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(1);
			array12[0] = GUILayout.MaxWidth(16f);
			return GUILayout.Button("-", array12);
		}
		case TreeViewItem.TextureIcons.MIDDLE_SIBLING_COLLAPSED:
		{
			if (!(null == m_textureMiddleSiblingCollapsed))
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
				if (!m_forceButtonText)
				{
					return c470e6d328d66066109ebf6978e0b0ab3(m_textureMiddleSiblingCollapsed);
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
			GUILayoutOption[] array4 = c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(1);
			array4[0] = GUILayout.MaxWidth(16f);
			return GUILayout.Button("<", array4);
		}
		case TreeViewItem.TextureIcons.MIDDLE_SIBLING_EXPANDED:
		{
			if (!(null == m_textureMiddleSiblingExpanded))
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
				if (!m_forceButtonText)
				{
					return c470e6d328d66066109ebf6978e0b0ab3(m_textureMiddleSiblingExpanded);
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
			}
			GUILayoutOption[] array10 = c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(1);
			array10[0] = GUILayout.MaxWidth(16f);
			return GUILayout.Button(">", array10);
		}
		case TreeViewItem.TextureIcons.MIDDLE_SIBLING_NO_CHILD:
		{
			if (!(null == m_textureMiddleSiblingNoChild))
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
				if (!m_forceButtonText)
				{
					return c470e6d328d66066109ebf6978e0b0ab3(m_textureMiddleSiblingNoChild);
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
			}
			GUILayoutOption[] array8 = c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(1);
			array8[0] = GUILayout.MaxWidth(16f);
			return GUILayout.Button("-", array8);
		}
		case TreeViewItem.TextureIcons.NORMAL_CHECKED:
		{
			if (!(null == m_textureNormalChecked))
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
				if (!m_forceButtonText)
				{
					return c470e6d328d66066109ebf6978e0b0ab3(m_textureNormalChecked);
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
			GUILayoutOption[] array9 = c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(1);
			array9[0] = GUILayout.MaxWidth(16f);
			return GUILayout.Button("x", array9);
		}
		case TreeViewItem.TextureIcons.NORMAL_UNCHECKED:
		{
			if (!(null == m_textureNormalUnchecked))
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
				if (!m_forceButtonText)
				{
					return c470e6d328d66066109ebf6978e0b0ab3(m_textureNormalUnchecked);
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
			GUILayoutOption[] array = c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(1);
			array[0] = GUILayout.MaxWidth(16f);
			return GUILayout.Button("o", array);
		}
		default:
			{
				return false;
			}
			IL_0175:
			return false;
			IL_00d4:
			return false;
		}
	}

	public void c7c347befd8df4401905b295a60b28e1f(DisplayTypes c378aa23d6915d64bf73a757aac886bbe)
	{
		if (!m_forceDefaultSkin)
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
			GUI.skin = m_skinUnselected;
		}
		DisplayTypes displayTypes = c378aa23d6915d64bf73a757aac886bbe;
		if (displayTypes != DisplayTypes.USE_SCROLL_VIEW)
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
			if (displayTypes != DisplayTypes.USE_SCROLL_AREA)
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
			}
			else
			{
				GUILayout.BeginArea(new Rect(X, Y, Width, Height));
				Vector2 scrollView = m_scrollView;
				GUILayoutOption[] array = c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(2);
				array[0] = GUILayout.MaxWidth(Width);
				array[1] = GUILayout.MaxHeight(Height);
				m_scrollView = GUILayout.BeginScrollView(scrollView, array);
			}
		}
		else
		{
			Vector2 scrollView2 = m_scrollView;
			GUILayoutOption[] array2 = c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(2);
			array2[0] = GUILayout.MaxWidth(Width);
			array2[1] = GUILayout.MaxHeight(Height);
			m_scrollView = GUILayout.BeginScrollView(scrollView2, array2);
		}
		c6026719265ab76e906dafcd44294f76c.c2c18cde2ff7b17fc844a0e3af9b27f12(0, TreeViewItem.SiblingOrder.FIRST_CHILD);
		displayTypes = c378aa23d6915d64bf73a757aac886bbe;
		if (displayTypes != DisplayTypes.USE_SCROLL_VIEW)
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
			if (displayTypes != DisplayTypes.USE_SCROLL_AREA)
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
			}
			else
			{
				GUILayout.EndScrollView();
				GUILayout.EndArea();
			}
		}
		else
		{
			GUILayout.EndScrollView();
		}
		GUI.skin = cbe822854180a01b0513beaf1107fd4f7.c7088de59e49f7108f520cf7e0bae167e;
	}

	public bool ceb3ebf3a0eb7cb68338b3c75579cc10d(Vector2 cf1946df563e9a331ccf4b1ee178d6841)
	{
		return new Rect(m_scrollView.x, m_scrollView.y, Width, Height).Contains(cf1946df563e9a331ccf4b1ee178d6841);
	}

	private void Start()
	{
		SelectedItem = ce1ba96a626699b6764f4c071143b0d7b.c7088de59e49f7108f520cf7e0bae167e;
	}

	private void OnGUI()
	{
		if (!DisplayOnGame)
		{
			while (true)
			{
				switch (5)
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
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Default, "treeview ongui!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
	}
}
