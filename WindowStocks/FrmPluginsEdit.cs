using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowStocks
{
    internal partial class FrmPluginsEdit : FrmBase
    {
        private int EditIndex = -1;

        public FrmPluginsEdit(int editIndex)
            : this()
        {
            EditIndex = editIndex;
        }

        public FrmPluginsEdit()
        {
            InitializeComponent();
            Program.ConfigChanged += new EventHandler(Program_ConfigChanged);
            Program.ConfigChangedToggle(null, null);
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            if (TextPlugName.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "请为外部工具指定一个名称.", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TextPlugName.Focus();
                return;
            }

            string commandLine = null;
            if (RadioTargetProgram.Checked)
            {
                commandLine = ComboTargetProgram.Text.Trim();
                if (commandLine.Length == 0)
                {
                    MessageBox.Show(this, "请选择目标文件路径.", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ComboTargetProgram.Focus();
                    return;
                }
                if (!File.Exists(commandLine))
                {
                    MessageBox.Show(this, "目标文件不存在.", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ComboTargetProgram.Focus();
                    ComboTargetProgram.SelectAll();
                    return;
                }
            }
            else if (RadioTargetUrl.Checked)
            {
                commandLine = ComboTargetUrl.Text.Trim();
                if (commandLine.Length == 0)
                {
                    MessageBox.Show(this, "请填写目标网址.", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ComboTargetUrl.Focus();
                    return;
                }
            }
            else return;

            if (TextShortKey.ShortKeyCode != Keys.None)
            {
                foreach (Config.PluginStruct plug in Program.Config.Plugins)
                {
                    if (plug.ShortKeyCode == TextShortKey.ShortKeyCode && plug.ShortKeyModifiers == TextShortKey.ShortKeyModifiers && !plug.Equals(Program.Config.Plugins[EditIndex]))
                    {
                        MessageBox.Show(this, string.Format("快捷键 \"{0}\" 已经被其它外部工具使用, 请重新指定.", TextShortKey.Text), "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TextShortKey.Focus();
                        return;
                    }


                }
            }

            Config.PluginStruct plug2 = new Config.PluginStruct(TextPlugName.Text.Trim(), TextShortKey.ShortKeyCode, TextShortKey.ShortKeyModifiers, RadioTargetUrl.Checked, commandLine);
            if (EditIndex < 0)
                Program.Config.Plugins.Add(plug2);
            else
                Program.Config.Plugins[EditIndex] = plug2;
            Program.ConfigChangedToggle(null, null);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void RadioTargetProgram_CheckedChanged(object sender, EventArgs e)
        {
            ComboTargetProgram.Enabled = ButtonBrowse.Enabled = RadioTargetProgram.Checked;
        }

        private void RadioTargetUrl_CheckedChanged(object sender, EventArgs e)
        {
            ComboTargetUrl.Enabled = RadioTargetUrl.Checked;
        }

        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog(this) == DialogResult.OK)
                ComboTargetProgram.Text = dialog.FileName;
        }

        private void FrmPluginsEdit_Load(object sender, EventArgs e)
        {
            if (EditIndex >= 0)
            {
                TextPlugName.Text = Program.Config.Plugins[EditIndex].Name;

                TextShortKey.ShortKeyCode = Program.Config.Plugins[EditIndex].ShortKeyCode;
                TextShortKey.ShortKeyModifiers = Program.Config.Plugins[EditIndex].ShortKeyModifiers;
                if (Program.Config.Plugins[EditIndex].ShortKeyModifiers != Keys.None)
                {
                    if ((TextShortKey.ShortKeyModifiers & Keys.Control) == Keys.Control)
                        TextShortKey.Text += "Ctrl+";
                    if ((TextShortKey.ShortKeyModifiers & Keys.Alt) == Keys.Alt)
                        TextShortKey.Text += "Alt+";
                    if ((TextShortKey.ShortKeyModifiers & Keys.Shift) == Keys.Shift)
                        TextShortKey.Text += "Shift+";
                }

                if (TextShortKey.ShortKeyCode != Keys.None)
                    TextShortKey.Text += TextShortKey.ShortKeyCode;
                else
                    TextShortKey.Text = "无";

                if (Program.Config.Plugins[EditIndex].IsUrl)
                {
                    ComboTargetUrl.Text = Program.Config.Plugins[EditIndex].CommandLine;
                    RadioTargetUrl.Checked = true;
                    RadioTargetProgram.Checked = false;
                }
                else
                {
                    ComboTargetProgram.Text = Program.Config.Plugins[EditIndex].CommandLine;
                    RadioTargetProgram.Checked = true;
                    RadioTargetUrl.Checked = false;
                }

                Text = "编辑外部工具...";
            }
            else
                Text = "添加外部工具...";

        }
    }
}
