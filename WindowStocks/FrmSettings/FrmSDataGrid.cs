using System;
using System.Windows.Forms;

namespace WindowStocks.FrmSettings
{
	internal partial class FrmSDataGrid : FrmSettingsBase
	{
		#region Constructors (1) 

		internal FrmSDataGrid()
		{
			InitializeComponent();
			Program.ConfigChanged += new EventHandler(Program_ConfigChanged);
			Program_ConfigChanged(null, null);
		}

		#endregion Constructors 

		#region Methods (14) 

		// Private Methods (14) 

		private void CheckHighLight_CheckedChanged(object sender, EventArgs e)
		{
			FrmSContainer.VirtualConfig.IsShowGvMainHighLight = LabelHighLight.Enabled = LabelHighLightVal.Enabled = CheckHighLight.Checked;
			FrmSContainer.CompareConfig();
		}

		private void CheckInterlaced_CheckedChanged(object sender, EventArgs e)
		{
			FrmSContainer.VirtualConfig.IsShowGvMainInterlaced = LabelInterlaced.Enabled = LabelInterlacedVal.Enabled = CheckInterlaced.Checked;
			FrmSContainer.CompareConfig();

		}

		private void CheckShowLines_CheckedChanged(object sender, EventArgs e)
		{
			FrmSContainer.VirtualConfig.IsShowGvMainGridLines = LabelLinesColor.Enabled = LabelLinesColorVal.Enabled = CheckShowLines.Checked;
			FrmSContainer.CompareConfig();
		}

		private void CheckShowPreview_CheckedChanged(object sender, EventArgs e)
		{
			FrmSContainer.VirtualConfig.IsShowChart = LabelPreTransp.Enabled = NumPreTransp.Enabled = CheckShowPreview.Checked;
			FrmSContainer.CompareConfig();
		}

		private void FrmSDataGrid_Load(object sender, EventArgs e)
		{
			LabelLinesColor.Enabled = LabelLinesColorVal.Enabled = CheckShowLines.Checked = Program.Config.IsShowGvMainGridLines;
			LabelBgColorVal.BackColor = Program.Config.GvMainGridLinesColor;
			LabelHighLight.Enabled = LabelHighLightVal.Enabled = CheckHighLight.Checked = Program.Config.IsShowGvMainHighLight;
			LabelHighLightVal.BackColor = Program.Config.GvMainHighLightColor;
			LabelInterlaced.Enabled = LabelInterlacedVal.Enabled = CheckInterlaced.Checked = Program.Config.IsShowGvMainInterlaced;
			LabelBgColorVal.BackColor = Program.Config.GvMainBgColor;
			LabelUpColorVal.BackColor = Program.Config.GvMainForeColorUp;
			LabelStillColorVal.BackColor = Program.Config.GvMainForeColorStill;
			LabelDownColorVal.BackColor = Program.Config.GvMainForeColorDown;
			CheckShowPreview.Checked = Program.Config.IsShowChart;
			NumPreTransp.Value = Program.Config.ChartTransparency;
		}

		private void LabelBgColorVal_Click(object sender, EventArgs e)
		{
			ColorDialog dialog = new ColorDialog();
			dialog.Color = FrmSContainer.VirtualConfig.GvMainBgColor;
			if (dialog.ShowDialog(this) == DialogResult.OK) {
				LabelBgColorVal.BackColor = FrmSContainer.VirtualConfig.GvMainBgColor = dialog.Color;
				FrmSContainer.CompareConfig();
			}
		}

		private void LabelDownColorVal_Click(object sender, EventArgs e)
		{
			ColorDialog dialog = new ColorDialog();
			dialog.Color = FrmSContainer.VirtualConfig.GvMainForeColorDown;
			if (dialog.ShowDialog(this) == DialogResult.OK) {
				LabelDownColorVal.BackColor = FrmSContainer.VirtualConfig.GvMainForeColorDown = dialog.Color;
				FrmSContainer.CompareConfig();
			}
		}

		private void LabelHighLightVal_Click(object sender, EventArgs e)
		{
			ColorDialog dialog = new ColorDialog();
			dialog.Color = FrmSContainer.VirtualConfig.GvMainHighLightColor;
			if (dialog.ShowDialog(this) == DialogResult.OK) {
				LabelHighLightVal.BackColor = FrmSContainer.VirtualConfig.GvMainHighLightColor = dialog.Color;
				FrmSContainer.CompareConfig();
			}
		}

		private void LabelInterlacedVal_Click(object sender, EventArgs e)
		{
			ColorDialog dialog = new ColorDialog();
			dialog.Color = FrmSContainer.VirtualConfig.GvMainInterlacedColor;
			if (dialog.ShowDialog(this) == DialogResult.OK) {
				LabelInterlacedVal.BackColor = FrmSContainer.VirtualConfig.GvMainInterlacedColor = dialog.Color;
				FrmSContainer.CompareConfig();
			}
		}

		private void LabelLinesColorVal_Click(object sender, EventArgs e)
		{
			ColorDialog dialog = new ColorDialog();
			dialog.Color = FrmSContainer.VirtualConfig.GvMainGridLinesColor;
			if (dialog.ShowDialog(this) == DialogResult.OK) {
				LabelLinesColorVal.BackColor = FrmSContainer.VirtualConfig.GvMainGridLinesColor = dialog.Color;
				FrmSContainer.CompareConfig();
			}
		}

		private void LabelStillColorVal_Click(object sender, EventArgs e)
		{
			ColorDialog dialog = new ColorDialog();
			dialog.Color = FrmSContainer.VirtualConfig.GvMainForeColorStill;
			if (dialog.ShowDialog(this) == DialogResult.OK) {
				LabelStillColorVal.BackColor = FrmSContainer.VirtualConfig.GvMainForeColorStill = dialog.Color;
				FrmSContainer.CompareConfig();
			}
		}

		private void LabelUpColorVal_Click(object sender, EventArgs e)
		{
			ColorDialog dialog = new ColorDialog();
			dialog.Color = FrmSContainer.VirtualConfig.GvMainForeColorUp;
			if (dialog.ShowDialog(this) == DialogResult.OK) {
				LabelUpColorVal.BackColor = FrmSContainer.VirtualConfig.GvMainForeColorUp = dialog.Color;
				FrmSContainer.CompareConfig();
			}
		}

		private void NumPreTransp_ValueChanged(object sender, EventArgs e)
		{
			FrmSContainer.VirtualConfig.ChartTransparency = (int)NumPreTransp.Value;
			FrmSContainer.CompareConfig();
		}

		#endregion Methods 
	}
}
