namespace WindowStocks.FrmSettings
{
    partial class FrmSDataGrid
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
            this.GroupStockList = new System.Windows.Forms.GroupBox();
            this.NumPreTransp = new WindowStocks.NumericUpDownEx();
            this.LabelHighLightVal = new System.Windows.Forms.Label();
            this.LabelBgColorVal = new System.Windows.Forms.Label();
            this.LabelLinesColorVal = new System.Windows.Forms.Label();
            this.LabelInterlacedVal = new System.Windows.Forms.Label();
            this.LabelStillColorVal = new System.Windows.Forms.Label();
            this.LabelDownColorVal = new System.Windows.Forms.Label();
            this.LabelUpColorVal = new System.Windows.Forms.Label();
            this.LabelPreTransp = new System.Windows.Forms.Label();
            this.CheckShowPreview = new System.Windows.Forms.CheckBox();
            this.LabelStillColor = new System.Windows.Forms.Label();
            this.LabelDownColor = new System.Windows.Forms.Label();
            this.LabelUpColor = new System.Windows.Forms.Label();
            this.LabelHighLight = new System.Windows.Forms.Label();
            this.LabelLinesColor = new System.Windows.Forms.Label();
            this.LabelBgColor = new System.Windows.Forms.Label();
            this.LabelInterlaced = new System.Windows.Forms.Label();
            this.CheckHighLight = new System.Windows.Forms.CheckBox();
            this.CheckInterlaced = new System.Windows.Forms.CheckBox();
            this.CheckShowLines = new System.Windows.Forms.CheckBox();
            this.GroupStockList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumPreTransp)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupStockList
            // 
            this.GroupStockList.Controls.Add(this.NumPreTransp);
            this.GroupStockList.Controls.Add(this.LabelHighLightVal);
            this.GroupStockList.Controls.Add(this.LabelBgColorVal);
            this.GroupStockList.Controls.Add(this.LabelLinesColorVal);
            this.GroupStockList.Controls.Add(this.LabelInterlacedVal);
            this.GroupStockList.Controls.Add(this.LabelStillColorVal);
            this.GroupStockList.Controls.Add(this.LabelDownColorVal);
            this.GroupStockList.Controls.Add(this.LabelUpColorVal);
            this.GroupStockList.Controls.Add(this.LabelPreTransp);
            this.GroupStockList.Controls.Add(this.CheckShowPreview);
            this.GroupStockList.Controls.Add(this.LabelStillColor);
            this.GroupStockList.Controls.Add(this.LabelDownColor);
            this.GroupStockList.Controls.Add(this.LabelUpColor);
            this.GroupStockList.Controls.Add(this.LabelHighLight);
            this.GroupStockList.Controls.Add(this.LabelLinesColor);
            this.GroupStockList.Controls.Add(this.LabelBgColor);
            this.GroupStockList.Controls.Add(this.LabelInterlaced);
            this.GroupStockList.Controls.Add(this.CheckHighLight);
            this.GroupStockList.Controls.Add(this.CheckInterlaced);
            this.GroupStockList.Controls.Add(this.CheckShowLines);
            this.GroupStockList.Location = new System.Drawing.Point(12, 12);
            this.GroupStockList.Name = "GroupStockList";
            this.GroupStockList.Size = new System.Drawing.Size(414, 237);
            this.GroupStockList.TabIndex = 0;
            this.GroupStockList.TabStop = false;
            this.GroupStockList.Text = "股票列表";
            // 
            // NumPreTransp
            // 
            this.NumPreTransp.Enabled = false;
            this.NumPreTransp.Location = new System.Drawing.Point(181, 201);
            this.NumPreTransp.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NumPreTransp.Name = "NumPreTransp";
            this.NumPreTransp.Size = new System.Drawing.Size(50, 22);
            this.NumPreTransp.TabIndex = 20;
            this.NumPreTransp.ValueChanged += new System.EventHandler(this.NumPreTransp_ValueChanged);
            // 
            // LabelHighLightVal
            // 
            this.LabelHighLightVal.BackColor = System.Drawing.Color.White;
            this.LabelHighLightVal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LabelHighLightVal.Enabled = false;
            this.LabelHighLightVal.Location = new System.Drawing.Point(199, 49);
            this.LabelHighLightVal.Name = "LabelHighLightVal";
            this.LabelHighLightVal.Size = new System.Drawing.Size(50, 20);
            this.LabelHighLightVal.TabIndex = 6;
            this.LabelHighLightVal.Click += new System.EventHandler(this.LabelHighLightVal_Click);
            // 
            // LabelBgColorVal
            // 
            this.LabelBgColorVal.BackColor = System.Drawing.Color.White;
            this.LabelBgColorVal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LabelBgColorVal.Location = new System.Drawing.Point(127, 102);
            this.LabelBgColorVal.Name = "LabelBgColorVal";
            this.LabelBgColorVal.Size = new System.Drawing.Size(50, 20);
            this.LabelBgColorVal.TabIndex = 11;
            this.LabelBgColorVal.Click += new System.EventHandler(this.LabelBgColorVal_Click);
            // 
            // LabelLinesColorVal
            // 
            this.LabelLinesColorVal.BackColor = System.Drawing.Color.White;
            this.LabelLinesColorVal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LabelLinesColorVal.Enabled = false;
            this.LabelLinesColorVal.Location = new System.Drawing.Point(199, 25);
            this.LabelLinesColorVal.Name = "LabelLinesColorVal";
            this.LabelLinesColorVal.Size = new System.Drawing.Size(50, 20);
            this.LabelLinesColorVal.TabIndex = 3;
            this.LabelLinesColorVal.Click += new System.EventHandler(this.LabelLinesColorVal_Click);
            // 
            // LabelInterlacedVal
            // 
            this.LabelInterlacedVal.BackColor = System.Drawing.Color.White;
            this.LabelInterlacedVal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LabelInterlacedVal.Enabled = false;
            this.LabelInterlacedVal.Location = new System.Drawing.Point(199, 73);
            this.LabelInterlacedVal.Name = "LabelInterlacedVal";
            this.LabelInterlacedVal.Size = new System.Drawing.Size(50, 20);
            this.LabelInterlacedVal.TabIndex = 9;
            this.LabelInterlacedVal.Click += new System.EventHandler(this.LabelInterlacedVal_Click);
            // 
            // LabelStillColorVal
            // 
            this.LabelStillColorVal.BackColor = System.Drawing.Color.White;
            this.LabelStillColorVal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LabelStillColorVal.Location = new System.Drawing.Point(127, 128);
            this.LabelStillColorVal.Name = "LabelStillColorVal";
            this.LabelStillColorVal.Size = new System.Drawing.Size(50, 20);
            this.LabelStillColorVal.TabIndex = 15;
            this.LabelStillColorVal.Click += new System.EventHandler(this.LabelStillColorVal_Click);
            // 
            // LabelDownColorVal
            // 
            this.LabelDownColorVal.BackColor = System.Drawing.Color.White;
            this.LabelDownColorVal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LabelDownColorVal.Location = new System.Drawing.Point(293, 128);
            this.LabelDownColorVal.Name = "LabelDownColorVal";
            this.LabelDownColorVal.Size = new System.Drawing.Size(50, 20);
            this.LabelDownColorVal.TabIndex = 17;
            this.LabelDownColorVal.Click += new System.EventHandler(this.LabelDownColorVal_Click);
            // 
            // LabelUpColorVal
            // 
            this.LabelUpColorVal.BackColor = System.Drawing.Color.White;
            this.LabelUpColorVal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LabelUpColorVal.Location = new System.Drawing.Point(293, 102);
            this.LabelUpColorVal.Name = "LabelUpColorVal";
            this.LabelUpColorVal.Size = new System.Drawing.Size(50, 20);
            this.LabelUpColorVal.TabIndex = 13;
            this.LabelUpColorVal.Click += new System.EventHandler(this.LabelUpColorVal_Click);
            // 
            // LabelPreTransp
            // 
            this.LabelPreTransp.AutoSize = true;
            this.LabelPreTransp.Enabled = false;
            this.LabelPreTransp.Location = new System.Drawing.Point(18, 203);
            this.LabelPreTransp.Name = "LabelPreTransp";
            this.LabelPreTransp.Size = new System.Drawing.Size(157, 14);
            this.LabelPreTransp.TabIndex = 19;
            this.LabelPreTransp.Text = "行情预览窗格透明度(0-255)";
            // 
            // CheckShowPreview
            // 
            this.CheckShowPreview.AutoSize = true;
            this.CheckShowPreview.Location = new System.Drawing.Point(21, 177);
            this.CheckShowPreview.Name = "CheckShowPreview";
            this.CheckShowPreview.Size = new System.Drawing.Size(278, 18);
            this.CheckShowPreview.TabIndex = 18;
            this.CheckShowPreview.Text = "鼠标移动到迷你行情上时显示实时行情预览窗格";
            this.CheckShowPreview.UseVisualStyleBackColor = true;
            this.CheckShowPreview.CheckedChanged += new System.EventHandler(this.CheckShowPreview_CheckedChanged);
            // 
            // LabelStillColor
            // 
            this.LabelStillColor.AutoSize = true;
            this.LabelStillColor.Location = new System.Drawing.Point(28, 129);
            this.LabelStillColor.Name = "LabelStillColor";
            this.LabelStillColor.Size = new System.Drawing.Size(91, 14);
            this.LabelStillColor.TabIndex = 14;
            this.LabelStillColor.Text = "平盘股票文字色";
            // 
            // LabelDownColor
            // 
            this.LabelDownColor.AutoSize = true;
            this.LabelDownColor.Location = new System.Drawing.Point(196, 129);
            this.LabelDownColor.Name = "LabelDownColor";
            this.LabelDownColor.Size = new System.Drawing.Size(91, 14);
            this.LabelDownColor.TabIndex = 16;
            this.LabelDownColor.Text = "下跌股票文字色";
            // 
            // LabelUpColor
            // 
            this.LabelUpColor.AutoSize = true;
            this.LabelUpColor.Location = new System.Drawing.Point(196, 103);
            this.LabelUpColor.Name = "LabelUpColor";
            this.LabelUpColor.Size = new System.Drawing.Size(91, 14);
            this.LabelUpColor.TabIndex = 12;
            this.LabelUpColor.Text = "上涨股票文字色";
            // 
            // LabelHighLight
            // 
            this.LabelHighLight.AutoSize = true;
            this.LabelHighLight.Enabled = false;
            this.LabelHighLight.Location = new System.Drawing.Point(150, 50);
            this.LabelHighLight.Name = "LabelHighLight";
            this.LabelHighLight.Size = new System.Drawing.Size(43, 14);
            this.LabelHighLight.TabIndex = 5;
            this.LabelHighLight.Text = "高亮色";
            // 
            // LabelLinesColor
            // 
            this.LabelLinesColor.AutoSize = true;
            this.LabelLinesColor.Enabled = false;
            this.LabelLinesColor.Location = new System.Drawing.Point(126, 26);
            this.LabelLinesColor.Name = "LabelLinesColor";
            this.LabelLinesColor.Size = new System.Drawing.Size(67, 14);
            this.LabelLinesColor.TabIndex = 2;
            this.LabelLinesColor.Text = "网格线颜色";
            // 
            // LabelBgColor
            // 
            this.LabelBgColor.AutoSize = true;
            this.LabelBgColor.Location = new System.Drawing.Point(18, 103);
            this.LabelBgColor.Name = "LabelBgColor";
            this.LabelBgColor.Size = new System.Drawing.Size(103, 14);
            this.LabelBgColor.TabIndex = 10;
            this.LabelBgColor.Text = "股票列表框背景色";
            // 
            // LabelInterlaced
            // 
            this.LabelInterlaced.AutoSize = true;
            this.LabelInterlaced.Enabled = false;
            this.LabelInterlaced.Location = new System.Drawing.Point(150, 74);
            this.LabelInterlaced.Name = "LabelInterlaced";
            this.LabelInterlaced.Size = new System.Drawing.Size(43, 14);
            this.LabelInterlaced.TabIndex = 8;
            this.LabelInterlaced.Text = "交错色";
            // 
            // CheckHighLight
            // 
            this.CheckHighLight.AutoSize = true;
            this.CheckHighLight.Location = new System.Drawing.Point(21, 49);
            this.CheckHighLight.Name = "CheckHighLight";
            this.CheckHighLight.Size = new System.Drawing.Size(86, 18);
            this.CheckHighLight.TabIndex = 4;
            this.CheckHighLight.Text = "当前行高亮";
            this.CheckHighLight.UseVisualStyleBackColor = true;
            this.CheckHighLight.CheckedChanged += new System.EventHandler(this.CheckHighLight_CheckedChanged);
            // 
            // CheckInterlaced
            // 
            this.CheckInterlaced.AutoSize = true;
            this.CheckInterlaced.Location = new System.Drawing.Point(21, 73);
            this.CheckInterlaced.Name = "CheckInterlaced";
            this.CheckInterlaced.Size = new System.Drawing.Size(98, 18);
            this.CheckInterlaced.TabIndex = 7;
            this.CheckInterlaced.Text = "隔行交错显示";
            this.CheckInterlaced.UseVisualStyleBackColor = true;
            this.CheckInterlaced.CheckedChanged += new System.EventHandler(this.CheckInterlaced_CheckedChanged);
            // 
            // CheckShowLines
            // 
            this.CheckShowLines.AutoSize = true;
            this.CheckShowLines.Location = new System.Drawing.Point(21, 25);
            this.CheckShowLines.Name = "CheckShowLines";
            this.CheckShowLines.Size = new System.Drawing.Size(86, 18);
            this.CheckShowLines.TabIndex = 1;
            this.CheckShowLines.Text = "显示网格线";
            this.CheckShowLines.UseVisualStyleBackColor = true;
            this.CheckShowLines.CheckedChanged += new System.EventHandler(this.CheckShowLines_CheckedChanged);
            // 
            // FrmSDataGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 328);
            this.Controls.Add(this.GroupStockList);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSDataGrid";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "FrmSGeneral";
            this.Load += new System.EventHandler(this.FrmSDataGrid_Load);
            this.GroupStockList.ResumeLayout(false);
            this.GroupStockList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumPreTransp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupStockList;
        private System.Windows.Forms.Label LabelPreTransp;
        private System.Windows.Forms.CheckBox CheckShowPreview;
        private System.Windows.Forms.Label LabelStillColor;
        private System.Windows.Forms.Label LabelDownColor;
        private System.Windows.Forms.Label LabelUpColor;
        private System.Windows.Forms.Label LabelInterlaced;
        private System.Windows.Forms.CheckBox CheckShowLines;
        private System.Windows.Forms.Label LabelUpColorVal;
        private System.Windows.Forms.Label LabelInterlacedVal;
        private System.Windows.Forms.CheckBox CheckInterlaced;
        private System.Windows.Forms.Label LabelHighLightVal;
        private System.Windows.Forms.Label LabelBgColorVal;
        private System.Windows.Forms.Label LabelLinesColor;
        private System.Windows.Forms.CheckBox CheckHighLight;
        private System.Windows.Forms.Label LabelLinesColorVal;
        private System.Windows.Forms.Label LabelHighLight;
        private System.Windows.Forms.Label LabelStillColorVal;
        private System.Windows.Forms.Label LabelBgColor;
        private System.Windows.Forms.Label LabelDownColorVal;
        private NumericUpDownEx NumPreTransp;

    }
}