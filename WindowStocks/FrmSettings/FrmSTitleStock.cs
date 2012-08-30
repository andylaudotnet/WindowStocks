using System;
using System.Windows.Forms;

namespace WindowStocks.FrmSettings
{
    internal sealed partial class FrmSTitleStock : FrmSettingsBase
    {
        #region Constructors (1)

        internal FrmSTitleStock()
        {
            InitializeComponent();
            Program.ConfigChanged += new EventHandler(Program_ConfigChanged);
            Program_ConfigChanged(null, null);
        }


        #endregion Constructors

        private void FrmSTitleStock_Load(object sender, EventArgs e)
        {
            RadioTitleAppend.Checked = !Program.Config.IsReplaceWindowTitle;
            RadioTitleReplace.Checked = Program.Config.IsReplaceWindowTitle;
            NumTitleCount.Value = Program.Config.WindowTitleCount;
            NumTitleTime.Value = Program.Config.WindowTitleShowTime;
            ComboTitleFormat.Text = Program.Config.WindowTitleFormat;
        }

        private void RadioTitleAppend_CheckedChanged(object sender, EventArgs e)
        {
            if (!RadioTitleAppend.Checked) return;
            FrmSContainer.VirtualConfig.IsReplaceWindowTitle = false;
            FrmSContainer.CompareConfig();
        }

        private void RadioTitleReplace_CheckedChanged(object sender, EventArgs e)
        {
            if (!RadioTitleReplace.Checked) return;
            FrmSContainer.VirtualConfig.IsReplaceWindowTitle = true;
            FrmSContainer.CompareConfig();

        }

        private void NumTitleCount_ValueChanged(object sender, EventArgs e)
        {
            FrmSContainer.VirtualConfig.WindowTitleCount = (int)NumTitleCount.Value;
            FrmSContainer.CompareConfig();
        }

        private void NumTitleTime_ValueChanged(object sender, EventArgs e)
        {
            FrmSContainer.VirtualConfig.WindowTitleShowTime = (int)NumTitleTime.Value;
            FrmSContainer.CompareConfig();
        }

        private void ComboTitleFormat_TextChanged(object sender, EventArgs e)
        {
            FrmSContainer.VirtualConfig.WindowTitleFormat = ComboTitleFormat.Text;
            FrmSContainer.CompareConfig();
        }



    }
}
