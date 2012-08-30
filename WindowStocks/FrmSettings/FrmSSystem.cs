using System;
using System.Windows.Forms;

namespace WindowStocks.FrmSettings
{
    internal sealed partial class FrmSSystem : FrmSettingsBase
    {
        internal FrmSSystem()
        {
            InitializeComponent();
            Program.ConfigChanged += new EventHandler(Program_ConfigChanged);
            Program_ConfigChanged(null, null);
        }

        private void FrmSSystem_Load(object sender, EventArgs e)
        {
            if (Program.Config.HotKeyModifiers != Keys.None)
            {
                if ((Program.Config.HotKeyModifiers & Keys.Control) == Keys.Control)
                    TextHotKey.Text += "Ctrl+";
                if ((Program.Config.HotKeyModifiers & Keys.Alt) == Keys.Alt)
                    TextHotKey.Text += "Alt+";
                if ((Program.Config.HotKeyModifiers & Keys.Shift) == Keys.Shift)
                    TextHotKey.Text += "Shift+";
            }

            if (Program.Config.HotKeyCode != Keys.None)
                TextHotKey.Text += Program.Config.HotKeyCode;
            else
                TextHotKey.Text = "无";

            NumUpdateCycle.Value = Program.Config.UpdateCycle;
            CheckAutoStartMin.Checked = Program.Config.AutoStartParam == "minimized";
            CheckAutoStartMin.Enabled = CheckAutoStart.Checked = Program.Config.IsAutoStart;
        }

        private void TextHotKey_KeyUp(object sender, KeyEventArgs e)
        {
            FrmSContainer.VirtualConfig.HotKeyModifiers = TextHotKey.ShortKeyModifiers;
            FrmSContainer.VirtualConfig.HotKeyCode = TextHotKey.ShortKeyCode;
            FrmSContainer.CompareConfig();
        }

        private void TextHotKey_Leave(object sender, EventArgs e)
        {
            TextHotKey_KeyUp(null, null);
        }

        private void CheckAutoStart_CheckedChanged(object sender, EventArgs e)
        {
            FrmSContainer.VirtualConfig.IsAutoStart = CheckAutoStartMin.Enabled = CheckAutoStart.Checked;
            FrmSContainer.CompareConfig();
        }

        private void CheckAutoStartMin_CheckedChanged(object sender, EventArgs e)
        {
            FrmSContainer.VirtualConfig.AutoStartParam = CheckAutoStartMin.Checked ? "minimized" : string.Empty;
            FrmSContainer.CompareConfig();
        }

        private void NumUpdateCycle_ValueChanged(object sender, EventArgs e)
        {
            FrmSContainer.VirtualConfig.UpdateCycle = (int)NumUpdateCycle.Value;
            FrmSContainer.CompareConfig();
        }




    }
}
