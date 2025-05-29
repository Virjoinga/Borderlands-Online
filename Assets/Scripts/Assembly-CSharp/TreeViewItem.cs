using System;
using System.Collections.Generic;
using A;
using Core;
using UnityEngine;

[Serializable]
public class TreeViewItem
{
	public class ClickEventArgs : EventArgs
	{
	}

	public class CheckedEventArgs : EventArgs
	{
	}

	public class UncheckedEventArgs : EventArgs
	{
	}

	public class SelectedEventArgs : EventArgs
	{
	}

	public class UnselectedEventArgs : EventArgs
	{
	}

	public enum SiblingOrder
	{
		FIRST_CHILD = 0,
		MIDDLE_CHILD = 1,
		LAST_CHILD = 2
	}

	public enum TextureIcons
	{
		BLANK = 0,
		GUIDE = 1,
		LAST_SIBLING_COLLAPSED = 2,
		LAST_SIBLING_EXPANDED = 3,
		LAST_SIBLING_NO_CHILD = 4,
		MIDDLE_SIBLING_COLLAPSED = 5,
		MIDDLE_SIBLING_EXPANDED = 6,
		MIDDLE_SIBLING_NO_CHILD = 7,
		NORMAL_CHECKED = 8,
		NORMAL_UNCHECKED = 9
	}

	public string Header = string.Empty;

	public bool IsExpanded = true;

	public bool IsCheckBox;

	public bool IsChecked;

	public bool IsHover;

	public bool IsSelected;

	public List<TreeViewItem> Items = new List<TreeViewItem>();

	public TreeViewControl ParentControl;

	public TreeViewItem Parent;

	public object DataContext;

	public EventHandler Click;

	public EventHandler Checked;

	public EventHandler Unchecked;

	public EventHandler Selected;

	public EventHandler Unselected;

	protected float m_hoverTime;

	public TreeViewItem(TreeViewControl cc5c58bc85412c47c47176038d58ffb38, TreeViewItem c0b8b4f11377b8a222dc728ff2c622559)
	{
		ParentControl = cc5c58bc85412c47c47176038d58ffb38;
		Parent = c0b8b4f11377b8a222dc728ff2c622559;
		if (!(null == cc5c58bc85412c47c47176038d58ffb38))
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
			return;
		}
	}

	public virtual TreeViewItem c2c88f58e2567403c799587ade8434690(string cde8f0acced36a8aa8dd4c33e6e29c417)
	{
		TreeViewItem treeViewItem = new TreeViewItem(ParentControl, this);
		treeViewItem.Header = cde8f0acced36a8aa8dd4c33e6e29c417;
		TreeViewItem treeViewItem2 = treeViewItem;
		Items.Add(treeViewItem2);
		return treeViewItem2;
	}

	public virtual TreeViewItem c2c88f58e2567403c799587ade8434690(string cde8f0acced36a8aa8dd4c33e6e29c417, bool ca7dd7a3bf2ffecc94bc85ca9e79db406)
	{
		TreeViewItem treeViewItem = new TreeViewItem(ParentControl, this);
		treeViewItem.Header = cde8f0acced36a8aa8dd4c33e6e29c417;
		treeViewItem.IsExpanded = ca7dd7a3bf2ffecc94bc85ca9e79db406;
		TreeViewItem treeViewItem2 = treeViewItem;
		Items.Add(treeViewItem2);
		return treeViewItem2;
	}

	public TreeViewItem c2c88f58e2567403c799587ade8434690(string cde8f0acced36a8aa8dd4c33e6e29c417, bool ca7dd7a3bf2ffecc94bc85ca9e79db406, bool cf475688674a08b7c35a3336c842416e5)
	{
		TreeViewItem treeViewItem = new TreeViewItem(ParentControl, this);
		treeViewItem.Header = cde8f0acced36a8aa8dd4c33e6e29c417;
		treeViewItem.IsExpanded = ca7dd7a3bf2ffecc94bc85ca9e79db406;
		treeViewItem.IsCheckBox = true;
		treeViewItem.IsChecked = cf475688674a08b7c35a3336c842416e5;
		TreeViewItem treeViewItem2 = treeViewItem;
		Items.Add(treeViewItem2);
		return treeViewItem2;
	}

	public bool c0bfd1b0b3f61c2a369fd4466c9c24293()
	{
		if (Items != null)
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
			if (Items.Count != 0)
			{
				return true;
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
		return false;
	}

	public string c6623cde42db4307c0b144942a5a8c70d()
	{
		string result;
		if (Parent != null)
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
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			result = Parent.c6623cde42db4307c0b144942a5a8c70d() + "/" + Header;
		}
		else
		{
			result = Header;
		}
		return result;
	}

	public bool ceab6cfb006fffb945bbb94b3ec951557(TreeViewItem c4eaf5bd7bf07e2883569cff3a347ffa3)
	{
		if (Parent == null)
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
					return false;
				}
			}
		}
		if (Parent.Equals(c4eaf5bd7bf07e2883569cff3a347ffa3))
		{
			while (true)
			{
				switch (1)
				{
				case 0:
					break;
				default:
					return true;
				}
			}
		}
		return Parent.ceab6cfb006fffb945bbb94b3ec951557(c4eaf5bd7bf07e2883569cff3a347ffa3);
	}

	protected float ce4c98ad80915c588916ba1570c4341ab(Rect c72a284dac60bcb9983cf785d5d82b623, Vector3 cf1946df563e9a331ccf4b1ee178d6841)
	{
		if (c72a284dac60bcb9983cf785d5d82b623.Contains(cf1946df563e9a331ccf4b1ee178d6841))
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
					return 0f;
				}
			}
		}
		float num = (c72a284dac60bcb9983cf785d5d82b623.yMin + c72a284dac60bcb9983cf785d5d82b623.yMax) * 0.5f;
		float y = cf1946df563e9a331ccf4b1ee178d6841.y;
		return Mathf.Abs(num - y) / 50f;
	}

	public virtual void c2c18cde2ff7b17fc844a0e3af9b27f12(int c8a60c0e987231379511ae0de477bb73e, SiblingOrder c610d9c3cc00e65bd62b371d191021846)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Default, "hey man, go to your inherit class");
		if (null == ParentControl)
		{
			while (true)
			{
				switch (3)
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
		GUILayout.BeginHorizontal(c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
		for (int i = 0; i < c8a60c0e987231379511ae0de477bb73e; i++)
		{
			ParentControl.c8118758f6a102f80d76e6f3a1652a12c(TextureIcons.GUIDE);
		}
		while (true)
		{
			switch (1)
			{
			case 0:
				continue;
			}
			if (!c0bfd1b0b3f61c2a369fd4466c9c24293())
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
				bool flag;
				switch (c610d9c3cc00e65bd62b371d191021846)
				{
				case SiblingOrder.FIRST_CHILD:
					flag = ParentControl.c8118758f6a102f80d76e6f3a1652a12c(TextureIcons.MIDDLE_SIBLING_NO_CHILD);
					break;
				case SiblingOrder.MIDDLE_CHILD:
					flag = ParentControl.c8118758f6a102f80d76e6f3a1652a12c(TextureIcons.MIDDLE_SIBLING_NO_CHILD);
					break;
				case SiblingOrder.LAST_CHILD:
					flag = ParentControl.c8118758f6a102f80d76e6f3a1652a12c(TextureIcons.LAST_SIBLING_NO_CHILD);
					break;
				default:
					flag = false;
					break;
				}
				if (flag)
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
					IsExpanded = !IsExpanded;
				}
			}
			else if (IsExpanded)
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
				bool flag2;
				switch (c610d9c3cc00e65bd62b371d191021846)
				{
				case SiblingOrder.FIRST_CHILD:
					flag2 = ParentControl.c8118758f6a102f80d76e6f3a1652a12c(TextureIcons.MIDDLE_SIBLING_EXPANDED);
					break;
				case SiblingOrder.MIDDLE_CHILD:
					flag2 = ParentControl.c8118758f6a102f80d76e6f3a1652a12c(TextureIcons.MIDDLE_SIBLING_EXPANDED);
					break;
				case SiblingOrder.LAST_CHILD:
					flag2 = ParentControl.c8118758f6a102f80d76e6f3a1652a12c(TextureIcons.LAST_SIBLING_EXPANDED);
					break;
				default:
					flag2 = false;
					break;
				}
				if (flag2)
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
					IsExpanded = !IsExpanded;
				}
			}
			else
			{
				bool flag3;
				switch (c610d9c3cc00e65bd62b371d191021846)
				{
				case SiblingOrder.FIRST_CHILD:
					flag3 = ParentControl.c8118758f6a102f80d76e6f3a1652a12c(TextureIcons.MIDDLE_SIBLING_COLLAPSED);
					break;
				case SiblingOrder.MIDDLE_CHILD:
					flag3 = ParentControl.c8118758f6a102f80d76e6f3a1652a12c(TextureIcons.MIDDLE_SIBLING_COLLAPSED);
					break;
				case SiblingOrder.LAST_CHILD:
					flag3 = ParentControl.c8118758f6a102f80d76e6f3a1652a12c(TextureIcons.LAST_SIBLING_COLLAPSED);
					break;
				default:
					flag3 = false;
					break;
				}
				if (flag3)
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
					IsExpanded = !IsExpanded;
				}
			}
			bool flag4;
			if (!string.IsNullOrEmpty(Header))
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
				if (ParentControl.SelectedItem == this)
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
					if (!ParentControl.m_forceDefaultSkin)
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
						GUI.skin = ParentControl.m_skinSelected;
						flag4 = true;
						goto IL_0238;
					}
				}
				flag4 = false;
				goto IL_0238;
			}
			goto IL_0602;
			IL_0602:
			GUILayout.EndHorizontal();
			if (ParentControl.IsHoverEnabled)
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
				if (Event.current != null)
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
					if (Event.current.type == EventType.Repaint)
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
						Vector2 mousePosition = Event.current.mousePosition;
						if (ParentControl.ceb3ebf3a0eb7cb68338b3c75579cc10d(mousePosition))
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
							Rect lastRect = GUILayoutUtility.GetLastRect();
							if (lastRect.Contains(mousePosition))
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
								IsHover = true;
								ParentControl.HoverItem = this;
							}
							else
							{
								IsHover = false;
							}
							if (ParentControl.IsHoverEnabled)
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
								if (ParentControl.IsHoverAnimationEnabled)
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
									m_hoverTime = ce4c98ad80915c588916ba1570c4341ab(lastRect, Event.current.mousePosition);
								}
							}
						}
					}
				}
			}
			if (c0bfd1b0b3f61c2a369fd4466c9c24293())
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
				if (IsExpanded)
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
					for (int j = 0; j < Items.Count; j++)
					{
						TreeViewItem treeViewItem = Items[j];
						treeViewItem.Parent = this;
						if (j + 1 == Items.Count)
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
							treeViewItem.c2c18cde2ff7b17fc844a0e3af9b27f12(c8a60c0e987231379511ae0de477bb73e + 1, SiblingOrder.LAST_CHILD);
						}
						else if (j == 0)
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
							treeViewItem.c2c18cde2ff7b17fc844a0e3af9b27f12(c8a60c0e987231379511ae0de477bb73e + 1, SiblingOrder.FIRST_CHILD);
						}
						else
						{
							treeViewItem.c2c18cde2ff7b17fc844a0e3af9b27f12(c8a60c0e987231379511ae0de477bb73e + 1, SiblingOrder.MIDDLE_CHILD);
						}
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
			}
			if (IsSelected)
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
				if (ParentControl.SelectedItem != this)
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
					if (Unselected != null)
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
						Unselected(this, new UnselectedEventArgs());
					}
				}
			}
			IsSelected = ParentControl.SelectedItem == this;
			return;
			IL_0238:
			if (IsCheckBox)
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
				if (IsChecked)
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
					if (ParentControl.c8118758f6a102f80d76e6f3a1652a12c(TextureIcons.NORMAL_CHECKED))
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
						IsChecked = false;
						if (ParentControl.SelectedItem != this)
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
							ParentControl.SelectedItem = this;
							IsSelected = true;
							if (Selected != null)
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
								Selected(this, new SelectedEventArgs());
							}
						}
						if (Unchecked != null)
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
							Unchecked(this, new UncheckedEventArgs());
						}
						goto IL_03a7;
					}
				}
				if (!IsChecked)
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
					if (ParentControl.c8118758f6a102f80d76e6f3a1652a12c(TextureIcons.NORMAL_UNCHECKED))
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
						IsChecked = true;
						if (ParentControl.SelectedItem != this)
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
							ParentControl.SelectedItem = this;
							IsSelected = true;
							if (Selected != null)
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
								Selected(this, new SelectedEventArgs());
							}
						}
						if (Checked != null)
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
							Checked(this, new CheckedEventArgs());
						}
					}
				}
				goto IL_03a7;
			}
			goto IL_03b6;
			IL_03b6:
			if (ParentControl.IsHoverEnabled)
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
				GUISkin skin = GUI.skin;
				if (flag4)
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
					GUI.skin = ParentControl.m_skinSelected;
				}
				else if (IsHover)
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
					GUI.skin = ParentControl.m_skinHover;
				}
				else
				{
					GUI.skin = ParentControl.m_skinUnselected;
				}
				if (ParentControl.IsHoverAnimationEnabled)
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
					GUI.skin.button.fontSize = (int)Mathf.Lerp(20f, 12f, m_hoverTime);
				}
				GUI.SetNextControlName("toggleButton");
				if (GUILayout.Button(Header, c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0)))
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
					GUI.FocusControl("toggleButton");
					if (ParentControl.SelectedItem != this)
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
						ParentControl.SelectedItem = this;
						IsSelected = true;
						if (Selected != null)
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
							Selected(this, new SelectedEventArgs());
						}
					}
					if (Click != null)
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
						Click(this, new ClickEventArgs());
					}
				}
				GUI.skin = skin;
			}
			else
			{
				GUI.SetNextControlName("toggleButton");
				if (GUILayout.Button(Header, c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0)))
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
					GUI.FocusControl("toggleButton");
					if (ParentControl.SelectedItem != this)
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
						ParentControl.SelectedItem = this;
						IsSelected = true;
						if (Selected != null)
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
							Selected(this, new SelectedEventArgs());
						}
					}
					if (Click != null)
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
						Click(this, new ClickEventArgs());
					}
				}
			}
			if (flag4)
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
				if (!ParentControl.m_forceDefaultSkin)
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
					GUI.skin = ParentControl.m_skinUnselected;
				}
			}
			goto IL_0602;
			IL_03a7:
			ParentControl.c8118758f6a102f80d76e6f3a1652a12c(TextureIcons.BLANK);
			goto IL_03b6;
		}
	}
}
