using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowStocks
{
    internal partial class FrmPluginsManager : FrmBase
    {
        public FrmPluginsManager()
        {
            InitializeComponent();
            Program.ConfigChanged += Program_ConfigChanged;
            Program_ConfigChanged(null, null);
        }

        private new void Program_ConfigChanged(object sender, EventArgs e)
        {
            base.Program_ConfigChanged(sender, e);
            InitLvMain();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            new FrmPluginsEdit().ShowDialog(this);
        }

        private void InitLvMain()
        {
            LvMain.Items.Clear();
            ButtonDel.Enabled = ButtonEdit.Enabled = false;
            foreach (Config.PluginStruct plug in Program.Config.Plugins)
            {
                ListViewItem item = new ListViewItem();
                item.Text = plug.Name;
                item.ImageIndex = plug.IsUrl ? 1 : 0;
                item.Tag = plug.ShortKeyModifiers | plug.ShortKeyCode;
                item.SubItems.Add(plug.CommandLine);

                string subItems2 = string.Empty;
                if (Program.Config.HotKeyModifiers != Keys.None)
                {
                    if ((plug.ShortKeyModifiers & Keys.Control) == Keys.Control)
                        subItems2 += "Ctrl+";
                    if ((plug.ShortKeyModifiers & Keys.Alt) == Keys.Alt)
                        subItems2 += "Alt+";
                    if ((plug.ShortKeyModifiers & Keys.Shift) == Keys.Shift)
                        subItems2 += "Shift+";
                }
                if (plug.ShortKeyCode != Keys.None)
                    subItems2 += plug.ShortKeyCode;
                else
                    subItems2 = "无";
                item.SubItems.Add(subItems2);
                LvMain.Items.Add(item);
            }
        }

        private void FrmPluginsManager_Load(object sender, EventArgs e)
        {
            InitLvMain();
        }

        private void LvMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            ButtonDel.Enabled = ButtonEdit.Enabled = LvMain.SelectedItems.Count > 0;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (LvMain.SelectedItems.Count == 0) return;
            if (MessageBox.Show(this, "确定要移除选中的外部工具吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (ListViewItem item in LvMain.SelectedItems)
                {
                    for (int i = 0; i < Program.Config.Plugins.Count; i++)
                    {
                        if (Program.Config.Plugins[i].CommandLine == item.SubItems[1].Text
                            && (Program.Config.Plugins[i].IsUrl ? 1 : 0) == item.ImageIndex
                            && Program.Config.Plugins[i].Name == item.Text
                            && (Program.Config.Plugins[i].ShortKeyModifiers | Program.Config.Plugins[i].ShortKeyCode) == (Keys)item.Tag)
                        {
                            Program.Config.Plugins.Remove(Program.Config.Plugins[i]);
                            break;
                        }
                    }
                }
                InitLvMain();
                Program.ConfigChangedToggle(null, null);
            }
        }

        private void LvMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            foreach (ListViewItem item in LvMain.SelectedItems)
                Win32.ShellExecute(Handle, "open", item.SubItems[1].Text, "", "", Win32.SW_SHOW);
        }

        private void LvMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LvMain_MouseDoubleClick(null, null);
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (LvMain.SelectedItems.Count == 0) return;
            new FrmPluginsEdit(LvMain.SelectedIndices[0]).ShowDialog(this);
        }
    }
}
