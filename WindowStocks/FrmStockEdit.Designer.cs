namespace WindowStocks
{
	partial class FrmStockEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStockEdit));
            this.LabelName = new System.Windows.Forms.Label();
            this.LabelCode = new System.Windows.Forms.Label();
            this.LabelHoldCount = new System.Windows.Forms.Label();
            this.LabelHoldPrice = new System.Windows.Forms.Label();
            this.GroupAlarm = new System.Windows.Forms.GroupBox();
            this.ButtonRemove = new System.Windows.Forms.Button();
            this.RadioAnd = new System.Windows.Forms.RadioButton();
            this.RadioOr = new System.Windows.Forms.RadioButton();
            this.LabelRelation = new System.Windows.Forms.Label();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.NumNum2 = new System.Windows.Forms.NumericUpDown();
            this.ComboOperator = new System.Windows.Forms.ComboBox();
            this.ComboNum1 = new System.Windows.Forms.ComboBox();
            this.LabelConditions = new System.Windows.Forms.Label();
            this.ListConditions = new System.Windows.Forms.ListBox();
            this.NumHoldCount = new System.Windows.Forms.NumericUpDown();
            this.NumHoldPrice = new System.Windows.Forms.NumericUpDown();
            this.LabelCodeVal = new System.Windows.Forms.Label();
            this.LabelNameVal = new System.Windows.Forms.Label();
            this.CheckShowInTitleBar = new System.Windows.Forms.CheckBox();
            this.CheckAlarm = new System.Windows.Forms.CheckBox();
            this.ButtonOk = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.GroupAlarm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumNum2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumHoldCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumHoldPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelName
            // 
            this.LabelName.AutoSize = true;
            this.LabelName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelName.Location = new System.Drawing.Point(167, 9);
            this.LabelName.Name = "LabelName";
            this.LabelName.Size = new System.Drawing.Size(55, 14);
            this.LabelName.TabIndex = 2;
            this.LabelName.Text = "股票名称";
            // 
            // LabelCode
            // 
            this.LabelCode.AutoSize = true;
            this.LabelCode.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelCode.Location = new System.Drawing.Point(12, 9);
            this.LabelCode.Name = "LabelCode";
            this.LabelCode.Size = new System.Drawing.Size(55, 14);
            this.LabelCode.TabIndex = 0;
            this.LabelCode.Text = "股票代码";
            // 
            // LabelHoldCount
            // 
            this.LabelHoldCount.AutoSize = true;
            this.LabelHoldCount.Location = new System.Drawing.Point(12, 36);
            this.LabelHoldCount.Name = "LabelHoldCount";
            this.LabelHoldCount.Size = new System.Drawing.Size(55, 14);
            this.LabelHoldCount.TabIndex = 4;
            this.LabelHoldCount.Text = "持股数量";
            // 
            // LabelHoldPrice
            // 
            this.LabelHoldPrice.AutoSize = true;
            this.LabelHoldPrice.Location = new System.Drawing.Point(167, 36);
            this.LabelHoldPrice.Name = "LabelHoldPrice";
            this.LabelHoldPrice.Size = new System.Drawing.Size(55, 14);
            this.LabelHoldPrice.TabIndex = 6;
            this.LabelHoldPrice.Text = "持股成本";
            // 
            // GroupAlarm
            // 
            this.GroupAlarm.Controls.Add(this.ButtonRemove);
            this.GroupAlarm.Controls.Add(this.RadioAnd);
            this.GroupAlarm.Controls.Add(this.RadioOr);
            this.GroupAlarm.Controls.Add(this.LabelRelation);
            this.GroupAlarm.Controls.Add(this.ButtonAdd);
            this.GroupAlarm.Controls.Add(this.NumNum2);
            this.GroupAlarm.Controls.Add(this.ComboOperator);
            this.GroupAlarm.Controls.Add(this.ComboNum1);
            this.GroupAlarm.Controls.Add(this.LabelConditions);
            this.GroupAlarm.Controls.Add(this.ListConditions);
            this.GroupAlarm.Enabled = false;
            this.GroupAlarm.Location = new System.Drawing.Point(10, 89);
            this.GroupAlarm.Name = "GroupAlarm";
            this.GroupAlarm.Padding = new System.Windows.Forms.Padding(0);
            this.GroupAlarm.Size = new System.Drawing.Size(296, 190);
            this.GroupAlarm.TabIndex = 10;
            this.GroupAlarm.TabStop = false;
            // 
            // ButtonRemove
            // 
            this.ButtonRemove.Enabled = false;
            this.ButtonRemove.Location = new System.Drawing.Point(105, 58);
            this.ButtonRemove.Name = "ButtonRemove";
            this.ButtonRemove.Size = new System.Drawing.Size(87, 25);
            this.ButtonRemove.TabIndex = 15;
            this.ButtonRemove.Text = "移除∧(&R)";
            this.ButtonRemove.UseVisualStyleBackColor = true;
            this.ButtonRemove.Click += new System.EventHandler(this.ButtonRemove_Click);
            // 
            // RadioAnd
            // 
            this.RadioAnd.AutoSize = true;
            this.RadioAnd.Location = new System.Drawing.Point(92, 167);
            this.RadioAnd.Name = "RadioAnd";
            this.RadioAnd.Size = new System.Drawing.Size(49, 18);
            this.RadioAnd.TabIndex = 20;
            this.RadioAnd.TabStop = true;
            this.RadioAnd.Text = "并且";
            this.RadioAnd.UseVisualStyleBackColor = true;
            // 
            // RadioOr
            // 
            this.RadioOr.AutoSize = true;
            this.RadioOr.Location = new System.Drawing.Point(43, 167);
            this.RadioOr.Name = "RadioOr";
            this.RadioOr.Size = new System.Drawing.Size(49, 18);
            this.RadioOr.TabIndex = 19;
            this.RadioOr.TabStop = true;
            this.RadioOr.Text = "或者";
            this.RadioOr.UseVisualStyleBackColor = true;
            // 
            // LabelRelation
            // 
            this.LabelRelation.AutoSize = true;
            this.LabelRelation.Location = new System.Drawing.Point(7, 169);
            this.LabelRelation.Name = "LabelRelation";
            this.LabelRelation.Size = new System.Drawing.Size(31, 14);
            this.LabelRelation.TabIndex = 18;
            this.LabelRelation.Text = "关系";
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Location = new System.Drawing.Point(197, 58);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(87, 25);
            this.ButtonAdd.TabIndex = 16;
            this.ButtonAdd.Text = "添加∨(&A)";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // NumNum2
            // 
            this.NumNum2.DecimalPlaces = 2;
            this.NumNum2.Location = new System.Drawing.Point(197, 30);
            this.NumNum2.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.NumNum2.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
            this.NumNum2.Name = "NumNum2";
            this.NumNum2.Size = new System.Drawing.Size(86, 22);
            this.NumNum2.TabIndex = 14;
            this.NumNum2.Enter += new System.EventHandler(this.Num_Enter);
            // 
            // ComboOperator
            // 
            this.ComboOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboOperator.FormattingEnabled = true;
            this.ComboOperator.Items.AddRange(new object[] {
            "大于",
            "等于",
            "小于"});
            this.ComboOperator.Location = new System.Drawing.Point(134, 30);
            this.ComboOperator.Name = "ComboOperator";
            this.ComboOperator.Size = new System.Drawing.Size(58, 22);
            this.ComboOperator.TabIndex = 13;
            // 
            // ComboNum1
            // 
            this.ComboNum1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboNum1.FormattingEnabled = true;
            this.ComboNum1.Items.AddRange(new object[] {
            "股票价格",
            "涨跌额",
            "涨跌幅",
            "振幅",
            "换手率",
            "总现值",
            "收益",
            "收益率",
            "最高价",
            "最低价",
            "成交量",
            "成交额",
            "外盘",
            "内盘"});
            this.ComboNum1.Location = new System.Drawing.Point(43, 30);
            this.ComboNum1.Name = "ComboNum1";
            this.ComboNum1.Size = new System.Drawing.Size(85, 22);
            this.ComboNum1.TabIndex = 12;
            // 
            // LabelConditions
            // 
            this.LabelConditions.AutoSize = true;
            this.LabelConditions.Location = new System.Drawing.Point(6, 33);
            this.LabelConditions.Name = "LabelConditions";
            this.LabelConditions.Size = new System.Drawing.Size(31, 14);
            this.LabelConditions.TabIndex = 11;
            this.LabelConditions.Text = "条件";
            // 
            // ListConditions
            // 
            this.ListConditions.FormattingEnabled = true;
            this.ListConditions.ItemHeight = 14;
            this.ListConditions.Location = new System.Drawing.Point(10, 89);
            this.ListConditions.Name = "ListConditions";
            this.ListConditions.Size = new System.Drawing.Size(274, 74);
            this.ListConditions.TabIndex = 17;
            this.ListConditions.SelectedIndexChanged += new System.EventHandler(this.ListConditions_SelectedIndexChanged);
            // 
            // NumHoldCount
            // 
            this.NumHoldCount.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.NumHoldCount.Location = new System.Drawing.Point(73, 34);
            this.NumHoldCount.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.NumHoldCount.Name = "NumHoldCount";
            this.NumHoldCount.Size = new System.Drawing.Size(78, 22);
            this.NumHoldCount.TabIndex = 5;
            this.NumHoldCount.ThousandsSeparator = true;
            this.NumHoldCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumHoldCount.Enter += new System.EventHandler(this.Num_Enter);
            // 
            // NumHoldPrice
            // 
            this.NumHoldPrice.DecimalPlaces = 3;
            this.NumHoldPrice.Location = new System.Drawing.Point(228, 34);
            this.NumHoldPrice.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.NumHoldPrice.Name = "NumHoldPrice";
            this.NumHoldPrice.Size = new System.Drawing.Size(78, 22);
            this.NumHoldPrice.TabIndex = 7;
            this.NumHoldPrice.ThousandsSeparator = true;
            this.NumHoldPrice.Enter += new System.EventHandler(this.Num_Enter);
            // 
            // LabelCodeVal
            // 
            this.LabelCodeVal.AutoSize = true;
            this.LabelCodeVal.Location = new System.Drawing.Point(73, 9);
            this.LabelCodeVal.Name = "LabelCodeVal";
            this.LabelCodeVal.Size = new System.Drawing.Size(0, 14);
            this.LabelCodeVal.TabIndex = 1;
            // 
            // LabelNameVal
            // 
            this.LabelNameVal.AutoSize = true;
            this.LabelNameVal.ForeColor = System.Drawing.Color.Blue;
            this.LabelNameVal.Location = new System.Drawing.Point(225, 9);
            this.LabelNameVal.Name = "LabelNameVal";
            this.LabelNameVal.Size = new System.Drawing.Size(0, 14);
            this.LabelNameVal.TabIndex = 3;
            // 
            // CheckShowInTitleBar
            // 
            this.CheckShowInTitleBar.AutoSize = true;
            this.CheckShowInTitleBar.Location = new System.Drawing.Point(15, 62);
            this.CheckShowInTitleBar.Name = "CheckShowInTitleBar";
            this.CheckShowInTitleBar.Size = new System.Drawing.Size(224, 18);
            this.CheckShowInTitleBar.TabIndex = 8;
            this.CheckShowInTitleBar.Text = "在活动窗口标题栏显示该股票信息(&T)";
            this.CheckShowInTitleBar.UseVisualStyleBackColor = true;
            // 
            // CheckAlarm
            // 
            this.CheckAlarm.AutoSize = true;
            this.CheckAlarm.Location = new System.Drawing.Point(15, 86);
            this.CheckAlarm.Name = "CheckAlarm";
            this.CheckAlarm.Size = new System.Drawing.Size(96, 18);
            this.CheckAlarm.TabIndex = 9;
            this.CheckAlarm.Text = "股票预警(&W)";
            this.CheckAlarm.UseVisualStyleBackColor = true;
            this.CheckAlarm.CheckedChanged += new System.EventHandler(this.CheckAlarm_CheckdChanged);
            // 
            // ButtonOk
            // 
            this.ButtonOk.Location = new System.Drawing.Point(150, 285);
            this.ButtonOk.Name = "ButtonOk";
            this.ButtonOk.Size = new System.Drawing.Size(75, 25);
            this.ButtonOk.TabIndex = 21;
            this.ButtonOk.Text = "确定(&O)";
            this.ButtonOk.UseVisualStyleBackColor = true;
            this.ButtonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(231, 285);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 25);
            this.ButtonCancel.TabIndex = 22;
            this.ButtonCancel.Text = "取消(&C)";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // FrmStockEdit
            // 
            this.AcceptButton = this.ButtonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(320, 322);
            this.Controls.Add(this.CheckAlarm);
            this.Controls.Add(this.CheckShowInTitleBar);
            this.Controls.Add(this.LabelNameVal);
            this.Controls.Add(this.LabelCodeVal);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonOk);
            this.Controls.Add(this.NumHoldPrice);
            this.Controls.Add(this.NumHoldCount);
            this.Controls.Add(this.GroupAlarm);
            this.Controls.Add(this.LabelHoldPrice);
            this.Controls.Add(this.LabelHoldCount);
            this.Controls.Add(this.LabelCode);
            this.Controls.Add(this.LabelName);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmStockEdit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "编辑股票...";
            this.GroupAlarm.ResumeLayout(false);
            this.GroupAlarm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumNum2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumHoldCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumHoldPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label LabelName;
		private System.Windows.Forms.Label LabelCode;
		private System.Windows.Forms.Label LabelHoldCount;
		private System.Windows.Forms.Label LabelHoldPrice;
		private System.Windows.Forms.GroupBox GroupAlarm;
		private System.Windows.Forms.NumericUpDown NumHoldCount;
		private System.Windows.Forms.NumericUpDown NumHoldPrice;
		private System.Windows.Forms.Button ButtonOk;
		private System.Windows.Forms.Button ButtonCancel;
		private System.Windows.Forms.Button ButtonAdd;
		private System.Windows.Forms.NumericUpDown NumNum2;
		private System.Windows.Forms.ComboBox ComboOperator;
		private System.Windows.Forms.ComboBox ComboNum1;
		private System.Windows.Forms.Label LabelConditions;
		private System.Windows.Forms.ListBox ListConditions;
		private System.Windows.Forms.Label LabelCodeVal;
		private System.Windows.Forms.Label LabelNameVal;
		private System.Windows.Forms.RadioButton RadioAnd;
		private System.Windows.Forms.RadioButton RadioOr;
		private System.Windows.Forms.Label LabelRelation;
		private System.Windows.Forms.Button ButtonRemove;
		private System.Windows.Forms.CheckBox CheckShowInTitleBar;
		private System.Windows.Forms.CheckBox CheckAlarm;
	}
}