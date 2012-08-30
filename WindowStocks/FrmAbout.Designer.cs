namespace WindowStocks
{
	partial class FrmAbout
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
            this.PicIcon = new System.Windows.Forms.PictureBox();
            this.LabelAbout = new System.Windows.Forms.Label();
            this.LinkHomePage = new System.Windows.Forms.LinkLabel();
            this.ButtonOk = new System.Windows.Forms.Button();
            this.LabelCopy = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PicIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // PicIcon
            // 
            this.PicIcon.Image = global::WindowStocks.Properties.Resources.main_48x48;
            this.PicIcon.Location = new System.Drawing.Point(12, 15);
            this.PicIcon.Name = "PicIcon";
            this.PicIcon.Size = new System.Drawing.Size(48, 48);
            this.PicIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicIcon.TabIndex = 0;
            this.PicIcon.TabStop = false;
            // 
            // LabelAbout
            // 
            this.LabelAbout.AutoSize = true;
            this.LabelAbout.Location = new System.Drawing.Point(78, 15);
            this.LabelAbout.Name = "LabelAbout";
            this.LabelAbout.Size = new System.Drawing.Size(0, 14);
            this.LabelAbout.TabIndex = 0;
            // 
            // LinkHomePage
            // 
            this.LinkHomePage.AutoSize = true;
            this.LinkHomePage.Location = new System.Drawing.Point(78, 63);
            this.LinkHomePage.Name = "LinkHomePage";
            this.LinkHomePage.Size = new System.Drawing.Size(132, 14);
            this.LinkHomePage.TabIndex = 2;
            this.LinkHomePage.TabStop = true;
            this.LinkHomePage.Text = "http://www.beta-1.cn";
            this.LinkHomePage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkHomePage_LinkClicked);
            // 
            // ButtonOk
            // 
            this.ButtonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonOk.Location = new System.Drawing.Point(299, 15);
            this.ButtonOk.Name = "ButtonOk";
            this.ButtonOk.Size = new System.Drawing.Size(75, 25);
            this.ButtonOk.TabIndex = 3;
            this.ButtonOk.Text = "确定(&O)";
            this.ButtonOk.UseVisualStyleBackColor = true;
            // 
            // LabelCopy
            // 
            this.LabelCopy.AutoSize = true;
            this.LabelCopy.Location = new System.Drawing.Point(78, 40);
            this.LabelCopy.Name = "LabelCopy";
            this.LabelCopy.Size = new System.Drawing.Size(0, 14);
            this.LabelCopy.TabIndex = 1;
            // 
            // FrmAbout
            // 
            this.AcceptButton = this.ButtonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonOk;
            this.ClientSize = new System.Drawing.Size(388, 107);
            this.Controls.Add(this.LabelCopy);
            this.Controls.Add(this.ButtonOk);
            this.Controls.Add(this.LinkHomePage);
            this.Controls.Add(this.LabelAbout);
            this.Controls.Add(this.PicIcon);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAbout";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "关于";
            this.Load += new System.EventHandler(this.FrmAbout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox PicIcon;
		private System.Windows.Forms.Label LabelAbout;
		private System.Windows.Forms.LinkLabel LinkHomePage;
		private System.Windows.Forms.Button ButtonOk;
        private System.Windows.Forms.Label LabelCopy;
	}
}