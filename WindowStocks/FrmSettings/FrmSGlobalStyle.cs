using System;
using System.Windows.Forms;

namespace WindowStocks.FrmSettings
{
	internal sealed partial class FrmSGlobalStyle : FrmSettingsBase
	{
		#region Constructors (1) 

		internal FrmSGlobalStyle()
		{
			InitializeComponent();
			Program.ConfigChanged += new EventHandler(Program_ConfigChanged);
			Program_ConfigChanged(null, null);
		}

		#endregion Constructors 

		#region Methods (5) 

		// Private Methods (5) 

		private void ComboKLineStyle_SelectedIndexChanged(object sender, EventArgs e)
		{
			FrmSContainer.VirtualConfig.KLineStyle = ComboKLineStyle.Text;
			FrmSContainer.CompareConfig();
		}

		private void ComboRenderMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			FrmSContainer.VirtualConfig.RenderMode = (ToolStripRenderMode)(ComboRenderMode.SelectedIndex + 1);
			FrmSContainer.CompareConfig();
		}

		private void FrmSGlobalStyle_Load(object sender, EventArgs e)
		{
			ComboRenderMode.SelectedIndex = (int)Program.Config.RenderMode - 1;
			ComboKLineStyle.Text = Program.Config.KLineStyle;
			LabelGeneralFontVal.Font = Program.Config.GenericFont;
		}

		private void LabelGeneralFontVal_Click(object sender, EventArgs e)
		{
			FontDialog dialog = new FontDialog();
			dialog.Font = FrmSContainer.VirtualConfig.GenericFont;
			if (dialog.ShowDialog(this) == DialogResult.OK) {
				LabelGeneralFontVal.Font = FrmSContainer.VirtualConfig.GenericFont = dialog.Font;
				FrmSContainer.CompareConfig();
			}
		}

		#endregion Methods 
	}
}
