using System;
using A;
using Core;
using UnityEngine;

public class Example : MonoBehaviour
{
	public TreeViewControl m_myTreeView;

	public void Start()
	{
		m_myTreeView = base.gameObject.GetComponent<TreeViewControl>();
		if (null == m_myTreeView)
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
					DebugUtils.ccb67deef6e071a99e91295f0b4aacc89(LogCategory.Default, "Use the tree view menu to add the control");
					return;
				}
			}
		}
		c115c26188e1047317aa94556a6311bea(m_myTreeView);
	}

	public static void c74553312940a4dd552cadb13e15c286c(object c979ec2891bdf45f616bb8a2b2b7051d5, EventArgs c236d74eac74e69ae8a3d77f7cd775c36)
	{
		DebugUtils.ce6db0d9bee52cc2eb4c88d724216d56c(LogCategory.Default, string.Format("{0} detected: {1}", c236d74eac74e69ae8a3d77f7cd775c36.GetType().Name, (c979ec2891bdf45f616bb8a2b2b7051d5 as TreeViewItem).Header));
	}

	private static void cbf6662b69b6471c0668533b986d6def1(out EventHandler c16761206209501eeb56534c1f0d5895d)
	{
		c16761206209501eeb56534c1f0d5895d = c74553312940a4dd552cadb13e15c286c;
	}

	private static void c2ba064ec3d4b0f4695c41733e431fbb3(TreeViewItem ca57e1c076c01141c5ce58c7341db7833)
	{
		cbf6662b69b6471c0668533b986d6def1(out ca57e1c076c01141c5ce58c7341db7833.Click);
		cbf6662b69b6471c0668533b986d6def1(out ca57e1c076c01141c5ce58c7341db7833.Checked);
		cbf6662b69b6471c0668533b986d6def1(out ca57e1c076c01141c5ce58c7341db7833.Unchecked);
		cbf6662b69b6471c0668533b986d6def1(out ca57e1c076c01141c5ce58c7341db7833.Selected);
		cbf6662b69b6471c0668533b986d6def1(out ca57e1c076c01141c5ce58c7341db7833.Unselected);
	}

	public static void c115c26188e1047317aa94556a6311bea(TreeViewControl ca57e1c076c01141c5ce58c7341db7833)
	{
		ca57e1c076c01141c5ce58c7341db7833.Width = 600;
		ca57e1c076c01141c5ce58c7341db7833.Height = 500;
		ca57e1c076c01141c5ce58c7341db7833.cdf97cd075f0c2047a15ceb348bb72c54 = "Example.cs populated this treeview control";
		c2ba064ec3d4b0f4695c41733e431fbb3(ca57e1c076c01141c5ce58c7341db7833.c6026719265ab76e906dafcd44294f76c);
		TreeViewItem treeViewItem = ca57e1c076c01141c5ce58c7341db7833.c6026719265ab76e906dafcd44294f76c.c2c88f58e2567403c799587ade8434690("You can also add a tree view control");
		c2ba064ec3d4b0f4695c41733e431fbb3(treeViewItem);
		c2ba064ec3d4b0f4695c41733e431fbb3(treeViewItem.c2c88f58e2567403c799587ade8434690("to any existing game object by"));
		c2ba064ec3d4b0f4695c41733e431fbb3(treeViewItem.c2c88f58e2567403c799587ade8434690("selecting the game object and"));
		c2ba064ec3d4b0f4695c41733e431fbb3(treeViewItem.c2c88f58e2567403c799587ade8434690("using the menu item"));
		TreeViewItem treeViewItem2 = treeViewItem.c2c88f58e2567403c799587ade8434690("TreeView->Add Tree View to selected.", false);
		c2ba064ec3d4b0f4695c41733e431fbb3(treeViewItem2);
		c2ba064ec3d4b0f4695c41733e431fbb3(treeViewItem2.c2c88f58e2567403c799587ade8434690("You can also drag and drop the"));
		c2ba064ec3d4b0f4695c41733e431fbb3(treeViewItem2.c2c88f58e2567403c799587ade8434690("TreeViewControl script onto a"));
		c2ba064ec3d4b0f4695c41733e431fbb3(treeViewItem2.c2c88f58e2567403c799587ade8434690("game object."));
		c2ba064ec3d4b0f4695c41733e431fbb3(treeViewItem2.c2c88f58e2567403c799587ade8434690("New checked and", false, true));
		c2ba064ec3d4b0f4695c41733e431fbb3(treeViewItem2.c2c88f58e2567403c799587ade8434690("unchecked checkboxes", false, false));
	}

	public void OnGUI()
	{
		if (!(null != m_myTreeView))
		{
			return;
		}
		while (true)
		{
			switch (6)
			{
			case 0:
				continue;
			}
			if (1 == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			if (m_myTreeView.SelectedItem == null)
			{
				return;
			}
			while (true)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				if (string.IsNullOrEmpty(m_myTreeView.SelectedItem.Header))
				{
					return;
				}
				while (true)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					GUILayout.Label(string.Format("Example selected: {0}", m_myTreeView.SelectedItem.Header), c1733ce3cdf8c4064e3ce35cb335ea639.c0a0cdf4a196914163f7334d9b0781a04(0));
					return;
				}
			}
		}
	}
}
