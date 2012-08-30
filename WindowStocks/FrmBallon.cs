// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FrmBallon.cs" company="NSnaiL">
//   Copyright (C) 2009 NSnaiL
// </copyright>
// <summary>
//   Defines the FrmBallon type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WindowStocks
{
	using System;
	using System.Drawing;
	using System.Threading;
	using System.Windows.Forms;

	internal sealed partial class FrmBallon : FrmBase
	{
		#region Constructors (1) 

		internal FrmBallon()
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

		// Public Methods (2) 

		public void HideSmooth()
		{
			while (Opacity > 0 && Visible) {
				Opacity -= 0.1;
				Thread.Sleep(20);
			}
			Hide();

		}

		public void ShowBallon(IWin32Window parent, Image icon, Color backColor, string title, string msg)
		{
			PicIcon.Image = icon;
			PanelMain.BackColor = backColor;
			LabelTitle.Text = title;
			LabelBody.Text = msg;
			Screen screen = Screen.FromHandle(Handle);
			Location = new Point(screen.WorkingArea.Width - Width - 10, screen.WorkingArea.Height - Height - 10);
			Show(parent);
			Opacity = 0.99;
		}
		// Private Methods (5) 

		private void FrmBallon_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing) {
				e.Cancel = true;
				Hide();
			}
		}

		private void FrmMsg_MouseLeave(object sender, EventArgs e)
		{
			TimerMain.Enabled = true;
		}

		private void FrmMsg_MouseMove(object sender, MouseEventArgs e)
		{
			TimerMain.Enabled = false;
		}

		private new void Program_ConfigChanged(object sender, EventArgs e)
		{
            base.Program_ConfigChanged(sender, e);
			LabelTitle.Font = new Font(Program.Config.GenericFont, FontStyle.Bold);
		}

		private void TimerMain_Tick(object sender, EventArgs e)
		{
			TimerMain.Enabled = false;
			HideSmooth();
		}

		#endregion Methods 
	}
}
