// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FrmAbout.cs" company="NSnaiL">
//   Copyright (C) 2009 NSnaiL
// </copyright>
// <summary>
//   Defines the FrmAbout type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WindowStocks
{
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Text;

    internal partial class FrmAbout : FrmBase
    {
        #region Constructors (1)

        public FrmAbout()
        {
            InitializeComponent();
            Program.ConfigChanged += Program_ConfigChanged;
            Program_ConfigChanged(null, null);
            LabelAbout.Text = string.Format("窗口行情 {0} {1}", Program.ProductVersion, Program.ProductVersionAdditional);
        }

        #endregion Constructors

        #region Methods (2)

        // Private Methods (2) 

        private void LinkHomePage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Win32.ShellExecute(Handle, "open", LinkHomePage.Text, "", "", Win32.SW_SHOW);
        }

        private new void Program_ConfigChanged(object sender, System.EventArgs e)
        {
            base.Program_ConfigChanged(sender, e);
            LabelAbout.Font = new Font(Program.Config.GenericFont, FontStyle.Bold);
        }

        #endregion Methods

        private void FrmAbout_Load(object sender, System.EventArgs e)
        {
            LabelCopy.Text = "贝塔软件 \u00a9 2009-2010";
        }
    }
}
