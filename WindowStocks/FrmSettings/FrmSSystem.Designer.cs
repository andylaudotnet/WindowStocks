namespace WindowStocks.FrmSettings
{
    partial class FrmSSystem
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
            this.GroupTitleStock = new System.Windows.Forms.GroupBox();
            this.TextHotKey = new WindowStocks.KeyBox();
            this.CheckAutoStartMin = new System.Windows.Forms.CheckBox();
            this.CheckAutoStart = new System.Windows.Forms.CheckBox();
            this.LabelHotKey = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NumUpdateCycle = new WindowStocks.NumericUpDownEx();
            this.LabelUpdateCycle = new System.Windows.Forms.Label();
            this.GroupTitleStock.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpdateCycle)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupTitleStock
            // 
            this.GroupTitleStock.Controls.Add(this.TextHotKey);
            this.GroupTitleStock.Controls.Add(this.CheckAutoStartMin);
            this.GroupTitleStock.Controls.Add(this.CheckAutoStart);
            this.GroupTitleStock.Controls.Add(this.LabelHotKey);
            this.GroupTitleStock.Location = new System.Drawing.Point(12, 12);
            this.GroupTitleStock.Name = "GroupTitleStock";
            this.GroupTitleStock.Size = new System.Drawing.Size(414, 112);
            this.GroupTitleStock.TabIndex = 0;
            this.GroupTitleStock.TabStop = false;
            this.GroupTitleStock.Text = "系统设置";
            // 
            // TextHotKey
            // 
            this.TextHotKey.Location = new System.Drawing.Point(158, 34);
            this.TextHotKey.Name = "TextHotKey";
            this.TextHotKey.ShortKeyCode = System.Windows.Forms.Keys.None;
            this.TextHotKey.ShortKeyModifiers = System.Windows.Forms.Keys.None;
            this.TextHotKey.Size = new System.Drawing.Size(98, 22);
            this.TextHotKey.TabIndex = 2;
            this.TextHotKey.Leave += new System.EventHandler(this.TextHotKey_Leave);
            this.TextHotKey.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextHotKey_KeyUp);
            // 
            // CheckAutoStartMin
            // 
            this.CheckAutoStartMin.AutoSize = true;
            this.CheckAutoStartMin.Location = new System.Drawing.Point(158, 71);
            this.CheckAutoStartMin.Name = "CheckAutoStartMin";
            this.CheckAutoStartMin.Size = new System.Drawing.Size(98, 18);
            this.CheckAutoStartMin.TabIndex = 4;
            this.CheckAutoStartMin.Text = "启动时最小化";
            this.CheckAutoStartMin.UseVisualStyleBackColor = true;
            this.CheckAutoStartMin.CheckedChanged += new System.EventHandler(this.CheckAutoStartMin_CheckedChanged);
            // 
            // CheckAutoStart
            // 
            this.CheckAutoStart.AutoSize = true;
            this.CheckAutoStart.Location = new System.Drawing.Point(23, 71);
            this.CheckAutoStart.Name = "CheckAutoStart";
            this.CheckAutoStart.Size = new System.Drawing.Size(98, 18);
            this.CheckAutoStart.TabIndex = 3;
            this.CheckAutoStart.Text = "开机自动启动";
            this.CheckAutoStart.UseVisualStyleBackColor = true;
            this.CheckAutoStart.CheckedChanged += new System.EventHandler(this.CheckAutoStart_CheckedChanged);
            // 
            // LabelHotKey
            // 
            this.LabelHotKey.AutoSize = true;
            this.LabelHotKey.Location = new System.Drawing.Point(20, 37);
            this.LabelHotKey.Name = "LabelHotKey";
            this.LabelHotKey.Size = new System.Drawing.Size(132, 14);
            this.LabelHotKey.TabIndex = 1;
            this.LabelHotKey.Text = "显示/隐藏主界面快捷键";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.NumUpdateCycle);
            this.groupBox1.Controls.Add(this.LabelUpdateCycle);
            this.groupBox1.Location = new System.Drawing.Point(12, 130);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 74);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "网络";
            // 
            // NumUpdateCycle
            // 
            this.NumUpdateCycle.Location = new System.Drawing.Point(142, 31);
            this.NumUpdateCycle.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumUpdateCycle.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumUpdateCycle.Name = "NumUpdateCycle";
            this.NumUpdateCycle.Size = new System.Drawing.Size(60, 22);
            this.NumUpdateCycle.TabIndex = 7;
            this.NumUpdateCycle.ThousandsSeparator = true;
            this.NumUpdateCycle.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumUpdateCycle.ValueChanged += new System.EventHandler(this.NumUpdateCycle_ValueChanged);
            // 
            // LabelUpdateCycle
            // 
            this.LabelUpdateCycle.AutoSize = true;
            this.LabelUpdateCycle.Location = new System.Drawing.Point(11, 33);
            this.LabelUpdateCycle.Name = "LabelUpdateCycle";
            this.LabelUpdateCycle.Size = new System.Drawing.Size(125, 14);
            this.LabelUpdateCycle.TabIndex = 6;
            this.LabelUpdateCycle.Text = "价格数据更新速度(秒)";
            // 
            // FrmSSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 328);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GroupTitleStock);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSSystem";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "FrmSGeneral";
            this.Load += new System.EventHandler(this.FrmSSystem_Load);
            this.GroupTitleStock.ResumeLayout(false);
            this.GroupTitleStock.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpdateCycle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupTitleStock;
        private System.Windows.Forms.CheckBox CheckAutoStartMin;
        private System.Windows.Forms.CheckBox CheckAutoStart;
        private System.Windows.Forms.Label LabelHotKey;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LabelUpdateCycle;
        private NumericUpDownEx NumUpdateCycle;
        private KeyBox TextHotKey;


    }
}