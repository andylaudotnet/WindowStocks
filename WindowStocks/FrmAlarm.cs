// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FrmAlarm.cs" company="NSnaiL">
//   Copyright (C) 2009 NSnaiL
// </copyright>
// <summary>
//   Defines the FrmAlarm type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WindowStocks
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    internal sealed partial class FrmAlarm : FrmBase
    {
        #region Constructors (1)

        public FrmAlarm()
        {
            InitializeComponent();
            LayoutMain.SetRowSpan(PicIcon, 2);
            Program.ConfigChanged += Program_ConfigChanged;
            Program_ConfigChanged(null, null);
        }

        #endregion Constructors

        #region Delegates and Events (1)

        // Delegates (1) 

        private delegate void InvokeDelegate();

        #endregion Delegates and Events

        #region Methods (7)

        // Public Methods (1) 

        public DialogResult ShowAlarm(IWin32Window parent, string title, string text)
        {
            LabelTitle.Text = title;
            LabelBody.Text = text;
            Screen screen = Screen.FromHandle(Handle);
            Location = new Point(screen.WorkingArea.Width - Width - 10, screen.WorkingArea.Height - Height - 10);
            return ShowDialog(parent);
        }
        // Private Methods (6) 

        private void CloseWarning(object stockKey)
        {
            //已阅读, 关闭预警
            lock (Program.UserData.Stocks.SyncRoot)
            {
                (Program.UserData.Stocks[stockKey] as Stock)
                    .ShowWarning = false;
            }
        }

        private void FrmAlarm_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void FrmAlarm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseWarning(Tag);
        }

        private void FrmAlarm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void FrmAlarm_Load(object sender, EventArgs e)
        {

        }

        private new void Program_ConfigChanged(object sender, EventArgs e)
        {
            base.Program_ConfigChanged(sender, e);
            LabelTitle.Font = new Font(Program.Config.GenericFont, FontStyle.Bold);
        }

        #endregion Methods
    }
}
