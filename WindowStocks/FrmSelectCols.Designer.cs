namespace WindowStocks
{
	partial class FrmSelectCols
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
            this.LayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.CheckCols = new System.Windows.Forms.CheckedListBox();
            this.PanelButtons = new System.Windows.Forms.Panel();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonApply = new System.Windows.Forms.Button();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.LayoutMain.SuspendLayout();
            this.PanelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // LayoutMain
            // 
            this.LayoutMain.ColumnCount = 1;
            this.LayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutMain.Controls.Add(this.CheckCols, 0, 0);
            this.LayoutMain.Controls.Add(this.PanelButtons, 0, 1);
            this.LayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutMain.Location = new System.Drawing.Point(0, 0);
            this.LayoutMain.Name = "LayoutMain";
            this.LayoutMain.RowCount = 2;
            this.LayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.LayoutMain.Size = new System.Drawing.Size(259, 374);
            this.LayoutMain.TabIndex = 0;
            // 
            // CheckCols
            // 
            this.CheckCols.CheckOnClick = true;
            this.CheckCols.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CheckCols.FormattingEnabled = true;
            this.CheckCols.Location = new System.Drawing.Point(3, 3);
            this.CheckCols.MultiColumn = true;
            this.CheckCols.Name = "CheckCols";
            this.CheckCols.Size = new System.Drawing.Size(253, 327);
            this.CheckCols.TabIndex = 1;
            this.CheckCols.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CheckCols_ItemCheck);
            // 
            // PanelButtons
            // 
            this.PanelButtons.Controls.Add(this.ButtonCancel);
            this.PanelButtons.Controls.Add(this.ButtonApply);
            this.PanelButtons.Controls.Add(this.ButtonOK);
            this.PanelButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.PanelButtons.Location = new System.Drawing.Point(3, 337);
            this.PanelButtons.Name = "PanelButtons";
            this.PanelButtons.Size = new System.Drawing.Size(253, 34);
            this.PanelButtons.TabIndex = 2;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(97, 3);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 25);
            this.ButtonCancel.TabIndex = 4;
            this.ButtonCancel.Text = "取消(&C)";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ButtonApply
            // 
            this.ButtonApply.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonApply.Enabled = false;
            this.ButtonApply.Location = new System.Drawing.Point(178, 3);
            this.ButtonApply.Name = "ButtonApply";
            this.ButtonApply.Size = new System.Drawing.Size(75, 25);
            this.ButtonApply.TabIndex = 5;
            this.ButtonApply.Text = "应用(&A)";
            this.ButtonApply.UseVisualStyleBackColor = true;
            this.ButtonApply.Click += new System.EventHandler(this.ButtonApply_Click);
            // 
            // ButtonOK
            // 
            this.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonOK.Location = new System.Drawing.Point(16, 3);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(75, 25);
            this.ButtonOK.TabIndex = 3;
            this.ButtonOK.Text = "确定(&O)";
            this.ButtonOK.UseVisualStyleBackColor = true;
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // FrmSelectCols
            // 
            this.AcceptButton = this.ButtonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(259, 374);
            this.Controls.Add(this.LayoutMain);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimizeBox = false;
            this.Name = "FrmSelectCols";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择显示的列...";
            this.LayoutMain.ResumeLayout(false);
            this.PanelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel LayoutMain;
		private System.Windows.Forms.CheckedListBox CheckCols;
		private System.Windows.Forms.Panel PanelButtons;
		private System.Windows.Forms.Button ButtonCancel;
		private System.Windows.Forms.Button ButtonApply;
		private System.Windows.Forms.Button ButtonOK;

	}
}