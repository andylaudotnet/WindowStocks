namespace WindowStocks.FrmSettings
{
    partial class FrmSContainer
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("全局样式");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("股票列表");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("界面样式", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("标题栏行情");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("系统设置");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSContainer));
            this.LayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.TreeLeft = new System.Windows.Forms.TreeView();
            this.PanelRight = new System.Windows.Forms.Panel();
            this.PanelBottom = new System.Windows.Forms.Panel();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonApply = new System.Windows.Forms.Button();
            this.ButtonOk = new System.Windows.Forms.Button();
            this.LayoutMain.SuspendLayout();
            this.PanelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // LayoutMain
            // 
            this.LayoutMain.ColumnCount = 2;
            this.LayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.LayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutMain.Controls.Add(this.TreeLeft, 0, 0);
            this.LayoutMain.Controls.Add(this.PanelRight, 1, 0);
            this.LayoutMain.Controls.Add(this.PanelBottom, 0, 1);
            this.LayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutMain.Location = new System.Drawing.Point(0, 0);
            this.LayoutMain.Name = "LayoutMain";
            this.LayoutMain.RowCount = 2;
            this.LayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.LayoutMain.Size = new System.Drawing.Size(594, 374);
            this.LayoutMain.TabIndex = 0;
            // 
            // TreeLeft
            // 
            this.TreeLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeLeft.ItemHeight = 16;
            this.TreeLeft.Location = new System.Drawing.Point(10, 10);
            this.TreeLeft.Margin = new System.Windows.Forms.Padding(10);
            this.TreeLeft.Name = "TreeLeft";
            treeNode1.Name = "";
            treeNode1.Text = "全局样式";
            treeNode2.Name = "";
            treeNode2.Text = "股票列表";
            treeNode3.Name = "";
            treeNode3.Text = "界面样式";
            treeNode4.Name = "";
            treeNode4.Text = "标题栏行情";
            treeNode5.Name = "";
            treeNode5.Text = "系统设置";
            this.TreeLeft.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4,
            treeNode5});
            this.TreeLeft.Size = new System.Drawing.Size(130, 314);
            this.TreeLeft.TabIndex = 1;
            this.TreeLeft.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeLeft_AfterSelect);
            // 
            // PanelRight
            // 
            this.PanelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelRight.Location = new System.Drawing.Point(153, 3);
            this.PanelRight.Name = "PanelRight";
            this.PanelRight.Size = new System.Drawing.Size(438, 328);
            this.PanelRight.TabIndex = 2;
            // 
            // PanelBottom
            // 
            this.LayoutMain.SetColumnSpan(this.PanelBottom, 2);
            this.PanelBottom.Controls.Add(this.ButtonCancel);
            this.PanelBottom.Controls.Add(this.ButtonApply);
            this.PanelBottom.Controls.Add(this.ButtonOk);
            this.PanelBottom.Dock = System.Windows.Forms.DockStyle.Right;
            this.PanelBottom.Location = new System.Drawing.Point(303, 337);
            this.PanelBottom.Name = "PanelBottom";
            this.PanelBottom.Size = new System.Drawing.Size(288, 34);
            this.PanelBottom.TabIndex = 3;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(111, 3);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 25);
            this.ButtonCancel.TabIndex = 5;
            this.ButtonCancel.Text = "取消(&C)";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ButtonApply
            // 
            this.ButtonApply.Location = new System.Drawing.Point(192, 3);
            this.ButtonApply.Name = "ButtonApply";
            this.ButtonApply.Size = new System.Drawing.Size(75, 25);
            this.ButtonApply.TabIndex = 6;
            this.ButtonApply.Text = "应用(&A)";
            this.ButtonApply.UseVisualStyleBackColor = true;
            this.ButtonApply.Click += new System.EventHandler(this.ButtonApply_Click);
            // 
            // ButtonOk
            // 
            this.ButtonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonOk.Location = new System.Drawing.Point(30, 3);
            this.ButtonOk.Name = "ButtonOk";
            this.ButtonOk.Size = new System.Drawing.Size(75, 25);
            this.ButtonOk.TabIndex = 4;
            this.ButtonOk.Text = "确定(&O)";
            this.ButtonOk.UseVisualStyleBackColor = true;
            this.ButtonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // FrmSContainer
            // 
            this.AcceptButton = this.ButtonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(594, 374);
            this.Controls.Add(this.LayoutMain);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSContainer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选项";
            this.Load += new System.EventHandler(this.FrmSContainer_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmSContainer_FormClosed);
            this.LayoutMain.ResumeLayout(false);
            this.PanelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel LayoutMain;
        private System.Windows.Forms.TreeView TreeLeft;
        private System.Windows.Forms.Panel PanelRight;
        private System.Windows.Forms.Panel PanelBottom;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonApply;
        private System.Windows.Forms.Button ButtonOk;

    }
}