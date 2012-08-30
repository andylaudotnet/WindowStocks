// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FrmKLine.cs" company="NSnaiL">
//   
// </copyright>
// <summary>
//   Defines the FrmKLine type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WindowStocks
{
	using System.Drawing;
	using System.Windows.Forms;
using System;

	internal sealed partial class FrmKLine : FrmBase
	{
		#region Fields (1) 

		private int FlashState4Count = 0;

		#endregion Fields 

		#region Constructors (1) 

		internal FrmKLine(Stock stock)
		{
			InitializeComponent();
			FlashMain.BGColor = Program.Config.KLineStyle == "黑色" ? "000000" : "FFFFFF";
			LabelLoading.BackColor = Program.Config.KLineStyle == "黑色" ? Color.Black : Color.White;
			Text = string.Format("{0}({1})", stock.Name, stock.Code);
            Program.ConfigChanged += Program_ConfigChanged;
            Program_ConfigChanged(null, null);
            FlashMain.Movie = string.Format("http://flashhq.gw.com.cn/tab.swf?font=0&flashdzh_theme={2}&stk_list=分时线,{0},{1},1,2; 日线,{0},{1},2,0;周线,{0},{1},2,1;月线,{0},{1},2,2;1分钟,{0},{1},2,3;5分钟,{0},{1},2,4;15分钟,{0},{1},2,5;30分钟,{0},{1},2,6;60分钟,{0},{1},2,7", stock.Area == "sh" ? "1" : "2", stock.Code, Program.Config.KLineStyle == "黑色" ? "Black" : "White");
			FlashMain.Play();
		}

		#endregion Constructors 

		#region Methods (5) 

		// Private Methods (5) 

		private void FlashMain_FlashCall(object sender, AxShockwaveFlashObjects._IShockwaveFlashEvents_FlashCallEvent e)
		{
			MessageBox.Show(e.ToString());
		}

		private void FlashMain_FSCommand(object sender, AxShockwaveFlashObjects._IShockwaveFlashEvents_FSCommandEvent e)
		{
			MessageBox.Show(e.ToString());
		}

		private void FlashMain_OnProgress(object sender, AxShockwaveFlashObjects._IShockwaveFlashEvents_OnProgressEvent e)
		{
			MessageBox.Show(e.ToString());
		}

		private void FlashMain_OnReadyStateChange(object sender, AxShockwaveFlashObjects._IShockwaveFlashEvents_OnReadyStateChangeEvent e)
		{
			if (e.newState == 4 && ++FlashState4Count == 10) {
				LabelLoading.Visible = false;
				FlashState4Count = 0;
			}
		}

		private void FrmKLine_Load(object sender, System.EventArgs e)
		{

		}

		#endregion Methods 
	}
}
