namespace WindowStocks
{
	partial class FrmFilter
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFilter));
			this.TextInput = new System.Windows.Forms.TextBox();
			this.LvStocks = new System.Windows.Forms.ListView();
			this.ColCode = new System.Windows.Forms.ColumnHeader();
			this.ColPinyin = new System.Windows.Forms.ColumnHeader();
			this.ColName = new System.Windows.Forms.ColumnHeader();
			this.ColArea = new System.Windows.Forms.ColumnHeader();
			this.ContextMenuStripMain = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.MiAdd = new System.Windows.Forms.ToolStripMenuItem();
			this.ButtonCancel = new System.Windows.Forms.Button();
			this.LabelInfo = new System.Windows.Forms.Label();
			this.ButtonAdd = new System.Windows.Forms.Button();
			this.LinkDownload = new System.Windows.Forms.LinkLabel();
			this.ContextMenuStripMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// TextInput
			// 
			this.TextInput.ForeColor = System.Drawing.SystemColors.InactiveCaption;
			this.TextInput.Location = new System.Drawing.Point(12, 12);
			this.TextInput.Name = "TextInput";
			this.TextInput.Size = new System.Drawing.Size(314, 22);
			this.TextInput.TabIndex = 0;
			this.TextInput.Text = "输入股票代码/名称/拼音(ALT + D)";
			this.TextInput.TextChanged += new System.EventHandler(this.TextInput_TextChanged);
			this.TextInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextInput_KeyDown);
			// 
			// LvStocks
			// 
			this.LvStocks.AllowColumnReorder = true;
			this.LvStocks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColCode,
            this.ColPinyin,
            this.ColName,
            this.ColArea});
			this.LvStocks.ContextMenuStrip = this.ContextMenuStripMain;
			this.LvStocks.FullRowSelect = true;
			this.LvStocks.HideSelection = false;
			this.LvStocks.Location = new System.Drawing.Point(12, 40);
			this.LvStocks.Name = "LvStocks";
			this.LvStocks.Size = new System.Drawing.Size(314, 239);
			this.LvStocks.TabIndex = 1;
			this.LvStocks.UseCompatibleStateImageBehavior = false;
			this.LvStocks.View = System.Windows.Forms.View.Details;
			this.LvStocks.SelectedIndexChanged += new System.EventHandler(this.LvStocks_SelectedIndexChanged);
			this.LvStocks.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LvStocks_KeyUp);
			this.LvStocks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LvStocks_KeyDown);
			// 
			// ColCode
			// 
			this.ColCode.Text = "股票代码";
			this.ColCode.Width = 80;
			// 
			// ColPinyin
			// 
			this.ColPinyin.Text = "简称/拼音";
			this.ColPinyin.Width = 90;
			// 
			// ColName
			// 
			this.ColName.Text = "股票名称";
			this.ColName.Width = 80;
			// 
			// ColArea
			// 
			this.ColArea.Text = "沪/深";
			this.ColArea.Width = 50;
			// 
			// ContextMenuStripMain
			// 
			this.ContextMenuStripMain.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ContextMenuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiAdd});
			this.ContextMenuStripMain.Name = "contextMenuStrip1";
			this.ContextMenuStripMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.ContextMenuStripMain.Size = new System.Drawing.Size(177, 26);
			// 
			// MiAdd
			// 
			this.MiAdd.Enabled = false;
			this.MiAdd.Name = "MiAdd";
			this.MiAdd.Size = new System.Drawing.Size(176, 22);
			this.MiAdd.Text = "加入我的股票(&A)...";
			this.MiAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
			// 
			// ButtonCancel
			// 
			this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.ButtonCancel.Location = new System.Drawing.Point(266, 285);
			this.ButtonCancel.Name = "ButtonCancel";
			this.ButtonCancel.Size = new System.Drawing.Size(60, 25);
			this.ButtonCancel.TabIndex = 4;
			this.ButtonCancel.Text = "取消(&C)";
			this.ButtonCancel.UseVisualStyleBackColor = true;
			this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
			// 
			// LabelInfo
			// 
			this.LabelInfo.AutoSize = true;
			this.LabelInfo.BackColor = System.Drawing.Color.Transparent;
			this.LabelInfo.ForeColor = System.Drawing.Color.Red;
			this.LabelInfo.Location = new System.Drawing.Point(121, 139);
			this.LabelInfo.Name = "LabelInfo";
			this.LabelInfo.Size = new System.Drawing.Size(0, 14);
			this.LabelInfo.TabIndex = 4;
			// 
			// ButtonAdd
			// 
			this.ButtonAdd.Enabled = false;
			this.ButtonAdd.Location = new System.Drawing.Point(150, 285);
			this.ButtonAdd.Name = "ButtonAdd";
			this.ButtonAdd.Size = new System.Drawing.Size(110, 25);
			this.ButtonAdd.TabIndex = 3;
			this.ButtonAdd.Text = "加入我的股票(&A)";
			this.ButtonAdd.UseVisualStyleBackColor = true;
			this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
			// 
			// LinkDownload
			// 
			this.LinkDownload.AutoSize = true;
			this.LinkDownload.Location = new System.Drawing.Point(6, 290);
			this.LinkDownload.Name = "LinkDownload";
			this.LinkDownload.Size = new System.Drawing.Size(91, 14);
			this.LinkDownload.TabIndex = 2;
			this.LinkDownload.TabStop = true;
			this.LinkDownload.Text = "获取最新股票...";
			this.LinkDownload.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkDownload_LinkClicked);
			// 
			// FrmFilter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.ButtonCancel;
			this.ClientSize = new System.Drawing.Size(338, 322);
			this.Controls.Add(this.LabelInfo);
			this.Controls.Add(this.LinkDownload);
			this.Controls.Add(this.LvStocks);
			this.Controls.Add(this.TextInput);
			this.Controls.Add(this.ButtonAdd);
			this.Controls.Add(this.ButtonCancel);
			this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmFilter";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "查找股票";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LvStocks_KeyDown);
			this.ContextMenuStripMain.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox TextInput;
		private System.Windows.Forms.ListView LvStocks;
		private System.Windows.Forms.ColumnHeader ColCode;
		private System.Windows.Forms.ColumnHeader ColPinyin;
		private System.Windows.Forms.ColumnHeader ColName;
		private System.Windows.Forms.ColumnHeader ColArea;
		private System.Windows.Forms.ContextMenuStrip ContextMenuStripMain;
		private System.Windows.Forms.ToolStripMenuItem MiAdd;
		private System.Windows.Forms.Button ButtonCancel;
		private System.Windows.Forms.Label LabelInfo;
		private System.Windows.Forms.Button ButtonAdd;
		private System.Windows.Forms.LinkLabel LinkDownload;
	}
}