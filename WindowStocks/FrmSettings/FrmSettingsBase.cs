using System;
using System.Windows.Forms;

namespace WindowStocks.FrmSettings
{
	internal class FrmSettingsBase : FrmBase
	{
		#region Fields (1) 

		protected FrmSContainer FrmSContainer;

		#endregion Fields 

		#region Methods (1) 

		// Protected Methods (1) 

		protected override void OnLoad(EventArgs e)
		{
			FrmSContainer = ParentForm as FrmSContainer;
			base.OnLoad(e);
		}

		#endregion Methods 
    }


}
