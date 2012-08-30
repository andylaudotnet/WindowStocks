using System;
using System.Windows.Forms;

namespace WindowStocks.FrmSettings
{
    internal partial class FrmSContainer : FrmBase
    {
        #region Fields (2)

        private Form ChildForm;
        internal readonly Config VirtualConfig = Program.Config.DeepClone();

        #endregion Fields

        #region Constructors (1)

        public FrmSContainer()
        {
            InitializeComponent();
            CompareConfig();
            Program.ConfigChanged += Program_ConfigChanged;
            Program_ConfigChanged(null, null);
        }

        #endregion Constructors

        #region Methods (8)

        // Private Methods (7) 

        private void ButtonApply_Click(object sender, EventArgs e)
        {
            Program.Config.AutoStartParam = VirtualConfig.AutoStartParam;
            Program.Config.IsAutoStart = VirtualConfig.IsAutoStart;
            Program.Config.GenericFont = VirtualConfig.GenericFont;
            Program.Config.GvMainBgColor = VirtualConfig.GvMainBgColor;
            Program.Config.GvMainForeColorDown = VirtualConfig.GvMainForeColorDown;
            Program.Config.GvMainForeColorStill = VirtualConfig.GvMainForeColorStill;
            Program.Config.GvMainForeColorUp = VirtualConfig.GvMainForeColorUp;
            Program.Config.IsShowGvMainGridLines = VirtualConfig.IsShowGvMainGridLines;
            Program.Config.IsReplaceWindowTitle = VirtualConfig.IsReplaceWindowTitle;
            Program.Config.WindowTitleFormat = VirtualConfig.WindowTitleFormat;
            Program.Config.WindowTitleCount = VirtualConfig.WindowTitleCount;
            Program.Config.WindowTitleShowTime = VirtualConfig.WindowTitleShowTime;
            Program.Config.RenderMode = VirtualConfig.RenderMode;
            Program.Config.HotKeyCode = VirtualConfig.HotKeyCode;
            Program.Config.HotKeyModifiers = VirtualConfig.HotKeyModifiers;
            Program.Config.IsShowChart = VirtualConfig.IsShowChart;
            Program.Config.ChartTransparency = VirtualConfig.ChartTransparency;
            Program.Config.UpdateCycle = VirtualConfig.UpdateCycle;
            Program.Config.KLineStyle = VirtualConfig.KLineStyle;
            Program.Config.GvMainGridLinesColor = VirtualConfig.GvMainGridLinesColor;
            Program.Config.GvMainHighLightColor = VirtualConfig.GvMainHighLightColor;
            Program.Config.GvMainInterlacedColor = VirtualConfig.GvMainInterlacedColor;
            Program.Config.IsShowGvMainHighLight = VirtualConfig.IsShowGvMainHighLight;
            Program.Config.IsShowGvMainInterlaced = VirtualConfig.IsShowGvMainInterlaced;

            Program.Config.Save(Program.PathConfig);
            CompareConfig();
            Program.ConfigChangedToggle(null, null);
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            ButtonApply_Click(null, null);
            Close();
        }

        private void FrmSContainer_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ChildForm != null)
                ChildForm.Close();
        }

        private void FrmSContainer_Load(object sender, EventArgs e)
        {
            TreeLeft.ExpandAll();
            TreeLeft.SelectedNode = TreeLeft.Nodes[0].Nodes[0];
        }

        private void TreeLeft_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (ChildForm != null)
            {
                ChildForm.Close();
                ChildForm = null;
            }
            switch (e.Node.Text)
            {
                case "界面样式":
                case "全局样式":
                    ChildForm = new FrmSGlobalStyle();
                    break;
                case "股票列表":
                    ChildForm = new FrmSDataGrid();
                    break;
                case "标题栏行情":
                    ChildForm = new FrmSTitleStock();
                    break;
                case "系统设置":
                    ChildForm = new FrmSSystem();
                    break;
            }
            if (ChildForm == null) return;
            ChildForm.MdiParent = this;
            ChildForm.Parent = PanelRight;
            ChildForm.Show();
        }
        // Internal Methods (1) 

        internal void CompareConfig()
        {
            ButtonApply.Enabled = false;
            if (!Compare.FontCompare(VirtualConfig.GenericFont, Program.Config.GenericFont)
                || VirtualConfig.GvMainBgColor != Program.Config.GvMainBgColor
                || VirtualConfig.GvMainForeColorDown != Program.Config.GvMainForeColorDown
                || VirtualConfig.GvMainForeColorStill != Program.Config.GvMainForeColorStill
                || VirtualConfig.GvMainForeColorUp != Program.Config.GvMainForeColorUp
                || VirtualConfig.IsShowGvMainGridLines != Program.Config.IsShowGvMainGridLines
                || VirtualConfig.IsReplaceWindowTitle != Program.Config.IsReplaceWindowTitle
                || VirtualConfig.WindowTitleFormat != Program.Config.WindowTitleFormat
                || VirtualConfig.WindowTitleCount != Program.Config.WindowTitleCount
                || VirtualConfig.WindowTitleShowTime != Program.Config.WindowTitleShowTime
                || VirtualConfig.RenderMode != Program.Config.RenderMode
                || VirtualConfig.HotKeyCode != Program.Config.HotKeyCode
                || VirtualConfig.HotKeyModifiers != Program.Config.HotKeyModifiers
                || VirtualConfig.IsShowChart != Program.Config.IsShowChart
                || VirtualConfig.ChartTransparency != Program.Config.ChartTransparency
                || VirtualConfig.AutoStartParam != Program.Config.AutoStartParam
                || VirtualConfig.IsAutoStart != Program.Config.IsAutoStart
                || VirtualConfig.UpdateCycle != Program.Config.UpdateCycle
                || VirtualConfig.KLineStyle != Program.Config.KLineStyle
                || VirtualConfig.GvMainGridLinesColor != Program.Config.GvMainGridLinesColor
                || VirtualConfig.GvMainHighLightColor != Program.Config.GvMainHighLightColor
                || VirtualConfig.GvMainInterlacedColor != Program.Config.GvMainInterlacedColor
                || VirtualConfig.IsShowGvMainHighLight != Program.Config.IsShowGvMainHighLight
                || VirtualConfig.IsShowGvMainInterlaced != Program.Config.IsShowGvMainInterlaced
                )
                ButtonApply.Enabled = true;
        }

        #endregion Methods
    }
}
