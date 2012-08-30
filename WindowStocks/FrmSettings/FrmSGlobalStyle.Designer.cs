namespace WindowStocks.FrmSettings
{
    partial class FrmSGlobalStyle
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
            if (disposing && (components != null))
            {
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
            this.LabelGeneralFontVal = new System.Windows.Forms.Label();
            this.LabelGeneralFont = new System.Windows.Forms.Label();
            this.GroupGlobal = new System.Windows.Forms.GroupBox();
            this.ComboKLineStyle = new System.Windows.Forms.ComboBox();
            this.LabelKLineStyle = new System.Windows.Forms.Label();
            this.ComboRenderMode = new System.Windows.Forms.ComboBox();
            this.LabelRenderMode = new System.Windows.Forms.Label();
            this.GroupGlobal.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelGeneralFontVal
            // 
            this.LabelGeneralFontVal.AutoSize = true;
            this.LabelGeneralFontVal.BackColor = System.Drawing.Color.White;
            this.LabelGeneralFontVal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LabelGeneralFontVal.Location = new System.Drawing.Point(125, 90);
            this.LabelGeneralFontVal.Name = "LabelGeneralFontVal";
            this.LabelGeneralFontVal.Padding = new System.Windows.Forms.Padding(3);
            this.LabelGeneralFontVal.Size = new System.Drawing.Size(182, 22);
            this.LabelGeneralFontVal.TabIndex = 6;
            this.LabelGeneralFontVal.Text = "点击切换字体(Change fonts)...";
            this.LabelGeneralFontVal.Click += new System.EventHandler(this.LabelGeneralFontVal_Click);
            // 
            // LabelGeneralFont
            // 
            this.LabelGeneralFont.AutoSize = true;
            this.LabelGeneralFont.Location = new System.Drawing.Point(64, 90);
            this.LabelGeneralFont.Name = "LabelGeneralFont";
            this.LabelGeneralFont.Size = new System.Drawing.Size(55, 14);
            this.LabelGeneralFont.TabIndex = 5;
            this.LabelGeneralFont.Text = "程序字体";
            // 
            // GroupGlobal
            // 
            this.GroupGlobal.Controls.Add(this.ComboKLineStyle);
            this.GroupGlobal.Controls.Add(this.LabelKLineStyle);
            this.GroupGlobal.Controls.Add(this.LabelGeneralFontVal);
            this.GroupGlobal.Controls.Add(this.ComboRenderMode);
            this.GroupGlobal.Controls.Add(this.LabelGeneralFont);
            this.GroupGlobal.Controls.Add(this.LabelRenderMode);
            this.GroupGlobal.Location = new System.Drawing.Point(9, 12);
            this.GroupGlobal.Name = "GroupGlobal";
            this.GroupGlobal.Size = new System.Drawing.Size(417, 139);
            this.GroupGlobal.TabIndex = 0;
            this.GroupGlobal.TabStop = false;
            this.GroupGlobal.Text = "全局样式";
            // 
            // ComboKLineStyle
            // 
            this.ComboKLineStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboKLineStyle.FormattingEnabled = true;
            this.ComboKLineStyle.Items.AddRange(new object[] {
            "黑色",
            "白色"});
            this.ComboKLineStyle.Location = new System.Drawing.Point(125, 55);
            this.ComboKLineStyle.Name = "ComboKLineStyle";
            this.ComboKLineStyle.Size = new System.Drawing.Size(182, 22);
            this.ComboKLineStyle.TabIndex = 4;
            this.ComboKLineStyle.SelectedIndexChanged += new System.EventHandler(this.ComboKLineStyle_SelectedIndexChanged);
            // 
            // LabelKLineStyle
            // 
            this.LabelKLineStyle.AutoSize = true;
            this.LabelKLineStyle.Location = new System.Drawing.Point(28, 58);
            this.LabelKLineStyle.Name = "LabelKLineStyle";
            this.LabelKLineStyle.Size = new System.Drawing.Size(91, 14);
            this.LabelKLineStyle.TabIndex = 3;
            this.LabelKLineStyle.Text = "分时线/K线风格";
            // 
            // ComboRenderMode
            // 
            this.ComboRenderMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboRenderMode.FormattingEnabled = true;
            this.ComboRenderMode.Items.AddRange(new object[] {
            "System",
            "Professional",
            "ManagerRenderMode"});
            this.ComboRenderMode.Location = new System.Drawing.Point(125, 27);
            this.ComboRenderMode.Name = "ComboRenderMode";
            this.ComboRenderMode.Size = new System.Drawing.Size(182, 22);
            this.ComboRenderMode.TabIndex = 2;
            this.ComboRenderMode.SelectedIndexChanged += new System.EventHandler(this.ComboRenderMode_SelectedIndexChanged);
            // 
            // LabelRenderMode
            // 
            this.LabelRenderMode.AutoSize = true;
            this.LabelRenderMode.Location = new System.Drawing.Point(16, 30);
            this.LabelRenderMode.Name = "LabelRenderMode";
            this.LabelRenderMode.Size = new System.Drawing.Size(103, 14);
            this.LabelRenderMode.TabIndex = 1;
            this.LabelRenderMode.Text = "菜单和工具条风格";
            // 
            // FrmSGlobalStyle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 328);
            this.Controls.Add(this.GroupGlobal);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSGlobalStyle";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "FrmSGeneral";
            this.Load += new System.EventHandler(this.FrmSGlobalStyle_Load);
            this.GroupGlobal.ResumeLayout(false);
            this.GroupGlobal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LabelGeneralFontVal;
        private System.Windows.Forms.Label LabelGeneralFont;
        private System.Windows.Forms.GroupBox GroupGlobal;
        private System.Windows.Forms.ComboBox ComboKLineStyle;
        private System.Windows.Forms.Label LabelKLineStyle;
        private System.Windows.Forms.ComboBox ComboRenderMode;
        private System.Windows.Forms.Label LabelRenderMode;
    }
}