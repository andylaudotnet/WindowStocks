namespace WindowStocks
{
    partial class FrmPluginsEdit
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
            this.GroupTarget = new System.Windows.Forms.GroupBox();
            this.ButtonBrowse = new System.Windows.Forms.Button();
            this.ComboTargetUrl = new System.Windows.Forms.ComboBox();
            this.ComboTargetProgram = new System.Windows.Forms.ComboBox();
            this.RadioTargetUrl = new System.Windows.Forms.RadioButton();
            this.RadioTargetProgram = new System.Windows.Forms.RadioButton();
            this.LabelPlugName = new System.Windows.Forms.Label();
            this.TextPlugName = new System.Windows.Forms.TextBox();
            this.LabelShortKey = new System.Windows.Forms.Label();
            this.ButtonOk = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.TextShortKey = new WindowStocks.KeyBox();
            this.GroupTarget.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupTarget
            // 
            this.GroupTarget.Controls.Add(this.ButtonBrowse);
            this.GroupTarget.Controls.Add(this.ComboTargetUrl);
            this.GroupTarget.Controls.Add(this.ComboTargetProgram);
            this.GroupTarget.Controls.Add(this.RadioTargetUrl);
            this.GroupTarget.Controls.Add(this.RadioTargetProgram);
            this.GroupTarget.Location = new System.Drawing.Point(12, 39);
            this.GroupTarget.Name = "GroupTarget";
            this.GroupTarget.Size = new System.Drawing.Size(369, 86);
            this.GroupTarget.TabIndex = 4;
            this.GroupTarget.TabStop = false;
            this.GroupTarget.Text = "设定目标";
            // 
            // ButtonBrowse
            // 
            this.ButtonBrowse.Location = new System.Drawing.Point(281, 19);
            this.ButtonBrowse.Name = "ButtonBrowse";
            this.ButtonBrowse.Size = new System.Drawing.Size(75, 23);
            this.ButtonBrowse.TabIndex = 7;
            this.ButtonBrowse.Text = "浏览(&B)...";
            this.ButtonBrowse.UseVisualStyleBackColor = true;
            this.ButtonBrowse.Click += new System.EventHandler(this.ButtonBrowse_Click);
            // 
            // ComboTargetUrl
            // 
            this.ComboTargetUrl.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ComboTargetUrl.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllUrl;
            this.ComboTargetUrl.Enabled = false;
            this.ComboTargetUrl.FormattingEnabled = true;
            this.ComboTargetUrl.Location = new System.Drawing.Point(85, 48);
            this.ComboTargetUrl.Name = "ComboTargetUrl";
            this.ComboTargetUrl.Size = new System.Drawing.Size(271, 22);
            this.ComboTargetUrl.TabIndex = 9;
            // 
            // ComboTargetProgram
            // 
            this.ComboTargetProgram.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ComboTargetProgram.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.ComboTargetProgram.FormattingEnabled = true;
            this.ComboTargetProgram.Location = new System.Drawing.Point(85, 19);
            this.ComboTargetProgram.Name = "ComboTargetProgram";
            this.ComboTargetProgram.Size = new System.Drawing.Size(190, 22);
            this.ComboTargetProgram.TabIndex = 6;
            // 
            // RadioTargetUrl
            // 
            this.RadioTargetUrl.AutoSize = true;
            this.RadioTargetUrl.Location = new System.Drawing.Point(30, 49);
            this.RadioTargetUrl.Name = "RadioTargetUrl";
            this.RadioTargetUrl.Size = new System.Drawing.Size(49, 18);
            this.RadioTargetUrl.TabIndex = 8;
            this.RadioTargetUrl.Text = "网址";
            this.RadioTargetUrl.UseVisualStyleBackColor = true;
            this.RadioTargetUrl.CheckedChanged += new System.EventHandler(this.RadioTargetUrl_CheckedChanged);
            // 
            // RadioTargetProgram
            // 
            this.RadioTargetProgram.AutoSize = true;
            this.RadioTargetProgram.Checked = true;
            this.RadioTargetProgram.Location = new System.Drawing.Point(6, 20);
            this.RadioTargetProgram.Name = "RadioTargetProgram";
            this.RadioTargetProgram.Size = new System.Drawing.Size(73, 18);
            this.RadioTargetProgram.TabIndex = 5;
            this.RadioTargetProgram.TabStop = true;
            this.RadioTargetProgram.Text = "本地文件";
            this.RadioTargetProgram.UseVisualStyleBackColor = true;
            this.RadioTargetProgram.CheckedChanged += new System.EventHandler(this.RadioTargetProgram_CheckedChanged);
            // 
            // LabelPlugName
            // 
            this.LabelPlugName.AutoSize = true;
            this.LabelPlugName.Location = new System.Drawing.Point(12, 10);
            this.LabelPlugName.Name = "LabelPlugName";
            this.LabelPlugName.Size = new System.Drawing.Size(55, 14);
            this.LabelPlugName.TabIndex = 0;
            this.LabelPlugName.Text = "工具名称";
            // 
            // TextPlugName
            // 
            this.TextPlugName.Location = new System.Drawing.Point(73, 7);
            this.TextPlugName.Name = "TextPlugName";
            this.TextPlugName.Size = new System.Drawing.Size(151, 22);
            this.TextPlugName.TabIndex = 1;
            // 
            // LabelShortKey
            // 
            this.LabelShortKey.AutoSize = true;
            this.LabelShortKey.Location = new System.Drawing.Point(251, 10);
            this.LabelShortKey.Name = "LabelShortKey";
            this.LabelShortKey.Size = new System.Drawing.Size(43, 14);
            this.LabelShortKey.TabIndex = 2;
            this.LabelShortKey.Text = "快捷键";
            // 
            // ButtonOk
            // 
            this.ButtonOk.Location = new System.Drawing.Point(225, 137);
            this.ButtonOk.Name = "ButtonOk";
            this.ButtonOk.Size = new System.Drawing.Size(75, 25);
            this.ButtonOk.TabIndex = 10;
            this.ButtonOk.Text = "确定(&O)";
            this.ButtonOk.UseVisualStyleBackColor = true;
            this.ButtonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(306, 137);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 25);
            this.ButtonCancel.TabIndex = 11;
            this.ButtonCancel.Text = "取消(&C)";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // TextShortKey
            // 
            this.TextShortKey.BackColor = System.Drawing.Color.White;
            this.TextShortKey.Location = new System.Drawing.Point(299, 7);
            this.TextShortKey.Name = "TextShortKey";
            this.TextShortKey.ReadOnly = true;
            this.TextShortKey.ShortKeyCode = System.Windows.Forms.Keys.None;
            this.TextShortKey.ShortKeyModifiers = System.Windows.Forms.Keys.None;
            this.TextShortKey.Size = new System.Drawing.Size(82, 22);
            this.TextShortKey.TabIndex = 3;
            // 
            // FrmPluginsEdit
            // 
            this.AcceptButton = this.ButtonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(394, 174);
            this.Controls.Add(this.TextShortKey);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonOk);
            this.Controls.Add(this.TextPlugName);
            this.Controls.Add(this.LabelShortKey);
            this.Controls.Add(this.LabelPlugName);
            this.Controls.Add(this.GroupTarget);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPluginsEdit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FrmPluginsEdit_Load);
            this.GroupTarget.ResumeLayout(false);
            this.GroupTarget.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupTarget;
        private System.Windows.Forms.Label LabelPlugName;
        private System.Windows.Forms.TextBox TextPlugName;
        private System.Windows.Forms.Label LabelShortKey;
        private System.Windows.Forms.Button ButtonBrowse;
        private System.Windows.Forms.ComboBox ComboTargetUrl;
        private System.Windows.Forms.ComboBox ComboTargetProgram;
        private System.Windows.Forms.RadioButton RadioTargetUrl;
        private System.Windows.Forms.RadioButton RadioTargetProgram;
        private System.Windows.Forms.Button ButtonOk;
        private System.Windows.Forms.Button ButtonCancel;
        private KeyBox TextShortKey;
    }
}