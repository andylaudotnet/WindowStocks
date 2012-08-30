namespace WindowStocks
{
	partial class FrmBallon
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.TimerMain = new System.Windows.Forms.Timer(this.components);
			this.LabelTitle = new System.Windows.Forms.Label();
			this.LayoutMain = new System.Windows.Forms.TableLayoutPanel();
			this.PicIcon = new System.Windows.Forms.PictureBox();
			this.LabelBody = new System.Windows.Forms.Label();
			this.PanelMain = new System.Windows.Forms.Panel();
			this.LayoutMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PicIcon)).BeginInit();
			this.PanelMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// TimerMain
			// 
			this.TimerMain.Interval = 500;
			this.TimerMain.Tick += new System.EventHandler(this.TimerMain_Tick);
			// 
			// LabelTitle
			// 
			this.LabelTitle.AutoSize = true;
			this.LabelTitle.Location = new System.Drawing.Point(57, 0);
			this.LabelTitle.Name = "LabelTitle";
			this.LabelTitle.Size = new System.Drawing.Size(0, 14);
			this.LabelTitle.TabIndex = 3;
			this.LabelTitle.MouseLeave += new System.EventHandler(this.FrmMsg_MouseLeave);
			this.LabelTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmMsg_MouseMove);
			// 
			// LayoutMain
			// 
			this.LayoutMain.AutoSize = true;
			this.LayoutMain.ColumnCount = 2;
			this.LayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.LayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.LayoutMain.Controls.Add(this.PicIcon, 0, 0);
			this.LayoutMain.Controls.Add(this.LabelTitle, 1, 0);
			this.LayoutMain.Controls.Add(this.LabelBody, 1, 1);
			this.LayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LayoutMain.Location = new System.Drawing.Point(10, 10);
			this.LayoutMain.Name = "LayoutMain";
			this.LayoutMain.RowCount = 2;
			this.LayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.LayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.LayoutMain.Size = new System.Drawing.Size(84, 0);
			this.LayoutMain.TabIndex = 1;
			this.LayoutMain.MouseLeave += new System.EventHandler(this.FrmMsg_MouseLeave);
			this.LayoutMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmMsg_MouseMove);
			// 
			// PicIcon
			// 
			this.PicIcon.Location = new System.Drawing.Point(3, 3);
			this.PicIcon.Name = "PicIcon";
			this.PicIcon.Size = new System.Drawing.Size(48, 48);
			this.PicIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.PicIcon.TabIndex = 0;
			this.PicIcon.TabStop = false;
			this.PicIcon.MouseLeave += new System.EventHandler(this.FrmMsg_MouseLeave);
			this.PicIcon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmMsg_MouseMove);
			// 
			// LabelBody
			// 
			this.LabelBody.AutoSize = true;
			this.LabelBody.Location = new System.Drawing.Point(57, 54);
			this.LabelBody.Name = "LabelBody";
			this.LabelBody.Size = new System.Drawing.Size(0, 14);
			this.LabelBody.TabIndex = 4;
			this.LabelBody.MouseLeave += new System.EventHandler(this.FrmMsg_MouseLeave);
			this.LabelBody.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmMsg_MouseMove);
			// 
			// PanelMain
			// 
			this.PanelMain.AutoSize = true;
			this.PanelMain.BackColor = System.Drawing.Color.PapayaWhip;
			this.PanelMain.Controls.Add(this.LayoutMain);
			this.PanelMain.Cursor = System.Windows.Forms.Cursors.Hand;
			this.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PanelMain.Location = new System.Drawing.Point(0, 0);
			this.PanelMain.Margin = new System.Windows.Forms.Padding(0);
			this.PanelMain.Name = "PanelMain";
			this.PanelMain.Padding = new System.Windows.Forms.Padding(10);
			this.PanelMain.Size = new System.Drawing.Size(104, 16);
			this.PanelMain.TabIndex = 0;
			this.PanelMain.MouseLeave += new System.EventHandler(this.FrmMsg_MouseLeave);
			this.PanelMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmMsg_MouseMove);
			// 
			// FrmBallon
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(104, 16);
			this.ControlBox = false;
			this.Controls.Add(this.PanelMain);
			this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmBallon";
			this.Opacity = 0.99;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.TopMost = true;
			this.MouseLeave += new System.EventHandler(this.FrmMsg_MouseLeave);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmBallon_FormClosing);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmMsg_MouseMove);
			this.LayoutMain.ResumeLayout(false);
			this.LayoutMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PicIcon)).EndInit();
			this.PanelMain.ResumeLayout(false);
			this.PanelMain.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.Timer TimerMain;
		public System.Windows.Forms.PictureBox PicIcon;
		public System.Windows.Forms.Label LabelTitle;
		public System.Windows.Forms.TableLayoutPanel LayoutMain;
		public System.Windows.Forms.Label LabelBody;
		public System.Windows.Forms.Panel PanelMain;

	}
}