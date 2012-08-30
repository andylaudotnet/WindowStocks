namespace WindowStocks.FrmSettings
{
    partial class FrmSTitleStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSTitleStock));
            this.GroupTitleStock = new System.Windows.Forms.GroupBox();
            this.NumTitleTime = new WindowStocks.NumericUpDownEx();
            this.NumTitleCount = new WindowStocks.NumericUpDownEx();
            this.LabelTitleTime = new System.Windows.Forms.Label();
            this.LabelTitleCount = new System.Windows.Forms.Label();
            this.TextTitleFormat = new System.Windows.Forms.TextBox();
            this.ComboTitleFormat = new System.Windows.Forms.ComboBox();
            this.LabelTitleFormat = new System.Windows.Forms.Label();
            this.RadioTitleReplace = new System.Windows.Forms.RadioButton();
            this.RadioTitleAppend = new System.Windows.Forms.RadioButton();
            this.GroupTitleStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumTitleTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumTitleCount)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupTitleStock
            // 
            this.GroupTitleStock.Controls.Add(this.NumTitleTime);
            this.GroupTitleStock.Controls.Add(this.NumTitleCount);
            this.GroupTitleStock.Controls.Add(this.LabelTitleTime);
            this.GroupTitleStock.Controls.Add(this.LabelTitleCount);
            this.GroupTitleStock.Controls.Add(this.TextTitleFormat);
            this.GroupTitleStock.Controls.Add(this.ComboTitleFormat);
            this.GroupTitleStock.Controls.Add(this.LabelTitleFormat);
            this.GroupTitleStock.Controls.Add(this.RadioTitleReplace);
            this.GroupTitleStock.Controls.Add(this.RadioTitleAppend);
            this.GroupTitleStock.Location = new System.Drawing.Point(12, 12);
            this.GroupTitleStock.Name = "GroupTitleStock";
            this.GroupTitleStock.Size = new System.Drawing.Size(414, 304);
            this.GroupTitleStock.TabIndex = 0;
            this.GroupTitleStock.TabStop = false;
            this.GroupTitleStock.Text = "标题栏行情";
            // 
            // NumTitleTime
            // 
            this.NumTitleTime.Location = new System.Drawing.Point(314, 60);
            this.NumTitleTime.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.NumTitleTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumTitleTime.Name = "NumTitleTime";
            this.NumTitleTime.Size = new System.Drawing.Size(44, 22);
            this.NumTitleTime.TabIndex = 6;
            this.NumTitleTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumTitleTime.ValueChanged += new System.EventHandler(this.NumTitleTime_ValueChanged);
            // 
            // NumTitleCount
            // 
            this.NumTitleCount.Location = new System.Drawing.Point(144, 60);
            this.NumTitleCount.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NumTitleCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumTitleCount.Name = "NumTitleCount";
            this.NumTitleCount.Size = new System.Drawing.Size(44, 22);
            this.NumTitleCount.TabIndex = 4;
            this.NumTitleCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumTitleCount.ValueChanged += new System.EventHandler(this.NumTitleCount_ValueChanged);
            // 
            // LabelTitleTime
            // 
            this.LabelTitleTime.AutoSize = true;
            this.LabelTitleTime.Location = new System.Drawing.Point(207, 62);
            this.LabelTitleTime.Name = "LabelTitleTime";
            this.LabelTitleTime.Size = new System.Drawing.Size(101, 14);
            this.LabelTitleTime.TabIndex = 5;
            this.LabelTitleTime.Text = "每次显示时间(秒)";
            // 
            // LabelTitleCount
            // 
            this.LabelTitleCount.AutoSize = true;
            this.LabelTitleCount.Location = new System.Drawing.Point(23, 62);
            this.LabelTitleCount.Name = "LabelTitleCount";
            this.LabelTitleCount.Size = new System.Drawing.Size(115, 14);
            this.LabelTitleCount.TabIndex = 3;
            this.LabelTitleCount.Text = "标题栏显示股票个数";
            // 
            // TextTitleFormat
            // 
            this.TextTitleFormat.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextTitleFormat.Location = new System.Drawing.Point(26, 137);
            this.TextTitleFormat.Multiline = true;
            this.TextTitleFormat.Name = "TextTitleFormat";
            this.TextTitleFormat.ReadOnly = true;
            this.TextTitleFormat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextTitleFormat.Size = new System.Drawing.Size(366, 146);
            this.TextTitleFormat.TabIndex = 9;
            this.TextTitleFormat.Text = resources.GetString("TextTitleFormat.Text");
            // 
            // ComboTitleFormat
            // 
            this.ComboTitleFormat.FormattingEnabled = true;
            this.ComboTitleFormat.Items.AddRange(new object[] {
            "    [{name}({code})    现价:{pcurr}    涨跌:{ud}/{udper}%    收益:{pl}/{plper}%]"});
            this.ComboTitleFormat.Location = new System.Drawing.Point(84, 104);
            this.ComboTitleFormat.MaxLength = 500;
            this.ComboTitleFormat.Name = "ComboTitleFormat";
            this.ComboTitleFormat.Size = new System.Drawing.Size(308, 22);
            this.ComboTitleFormat.TabIndex = 8;
            this.ComboTitleFormat.TextChanged += new System.EventHandler(this.ComboTitleFormat_TextChanged);
            // 
            // LabelTitleFormat
            // 
            this.LabelTitleFormat.AutoSize = true;
            this.LabelTitleFormat.Location = new System.Drawing.Point(23, 107);
            this.LabelTitleFormat.Name = "LabelTitleFormat";
            this.LabelTitleFormat.Size = new System.Drawing.Size(55, 14);
            this.LabelTitleFormat.TabIndex = 7;
            this.LabelTitleFormat.Text = "显示格式";
            // 
            // RadioTitleReplace
            // 
            this.RadioTitleReplace.AutoSize = true;
            this.RadioTitleReplace.Location = new System.Drawing.Point(199, 31);
            this.RadioTitleReplace.Name = "RadioTitleReplace";
            this.RadioTitleReplace.Size = new System.Drawing.Size(109, 18);
            this.RadioTitleReplace.TabIndex = 2;
            this.RadioTitleReplace.Text = "替换原窗口标题";
            this.RadioTitleReplace.UseVisualStyleBackColor = true;
            this.RadioTitleReplace.CheckedChanged += new System.EventHandler(this.RadioTitleReplace_CheckedChanged);
            // 
            // RadioTitleAppend
            // 
            this.RadioTitleAppend.AutoSize = true;
            this.RadioTitleAppend.Checked = true;
            this.RadioTitleAppend.Location = new System.Drawing.Point(26, 31);
            this.RadioTitleAppend.Name = "RadioTitleAppend";
            this.RadioTitleAppend.Size = new System.Drawing.Size(133, 18);
            this.RadioTitleAppend.TabIndex = 1;
            this.RadioTitleAppend.TabStop = true;
            this.RadioTitleAppend.Text = "追加在原窗口标题后";
            this.RadioTitleAppend.UseVisualStyleBackColor = true;
            this.RadioTitleAppend.CheckedChanged += new System.EventHandler(this.RadioTitleAppend_CheckedChanged);
            // 
            // FrmSTitleStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 328);
            this.Controls.Add(this.GroupTitleStock);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSTitleStock";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "FrmSGeneral";
            this.Load += new System.EventHandler(this.FrmSTitleStock_Load);
            this.GroupTitleStock.ResumeLayout(false);
            this.GroupTitleStock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumTitleTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumTitleCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupTitleStock;
        private System.Windows.Forms.Label LabelTitleTime;
        private System.Windows.Forms.Label LabelTitleCount;
        private System.Windows.Forms.TextBox TextTitleFormat;
        private System.Windows.Forms.ComboBox ComboTitleFormat;
        private System.Windows.Forms.Label LabelTitleFormat;
        private System.Windows.Forms.RadioButton RadioTitleReplace;
        private System.Windows.Forms.RadioButton RadioTitleAppend;
        private NumericUpDownEx NumTitleCount;
        private NumericUpDownEx NumTitleTime;


    }
}