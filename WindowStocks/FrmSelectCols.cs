using System;
using System.Windows.Forms;

namespace WindowStocks
{
    internal sealed partial class FrmSelectCols : FrmBase
    {
        #region Fields (1)

        private DataGridView GvMain;

        #endregion Fields

        #region Constructors (1)

        internal FrmSelectCols(DataGridView dataGrid)
        {
            InitializeComponent();

            GvMain = dataGrid;
            CheckCols.Items.Add("全选/反选");
            int displayCount = 0;
            foreach (DataGridViewColumn col in GvMain.Columns)
            {
                CheckCols.Items.Add(col.HeaderText.Length > 0 ? col.HeaderText : col.HeaderCell.Tag as string, col.Visible);
                if (col.Visible) displayCount++;
            }
            if (displayCount == dataGrid.Columns.Count)
                CheckCols.SetItemChecked(0, true);

            ButtonApply.Enabled = false;
            Program.ConfigChanged += Program_ConfigChanged;
            Program_ConfigChanged(null, null);
        }

        #endregion Constructors

        #region Delegates and Events (1)

        // Events (1) 

        internal event EventHandler GvMain_DisplayColumnCountChanged;

        #endregion Delegates and Events

        #region Methods (5)

        // Private Methods (5) 

        private void ButtonApply_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GvMain.Columns.Count; i++)
                Program.Config.GvMainColVisibles[i] = GvMain.Columns[i].Visible = CheckCols.GetItemChecked(i + 1);
            ButtonApply.Enabled = false;
            if (GvMain_DisplayColumnCountChanged != null)
                GvMain_DisplayColumnCountChanged(GvMain.DisplayedColumnCount(false) == 0 ? false : true, null);
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            if (ButtonApply.Enabled)
                ButtonApply_Click(null, null);
            Close();
        }

        private void CheckCols_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index == 0)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    for (int i = 1; i < CheckCols.Items.Count; i++)
                        CheckCols.SetItemChecked(i, true);
                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    for (int i = 1; i < CheckCols.Items.Count; i++)
                        CheckCols.SetItemChecked(i, false);
                }
            }
            ButtonApply.Enabled = true;

        }

        #endregion Methods
    }
}
