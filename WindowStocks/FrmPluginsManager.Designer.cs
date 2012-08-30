namespace WindowStocks
{
    partial class FrmPluginsManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPluginsManager));
            this.LayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.LvMain = new System.Windows.Forms.ListView();
            this.ColName = new System.Windows.Forms.ColumnHeader();
            this.ColTarget = new System.Windows.Forms.ColumnHeader();
            this.ColKey = new System.Windows.Forms.ColumnHeader();
            this.ImgListLvMain = new System.Windows.Forms.ImageList(this.components);
            this.PanelButton = new System.Windows.Forms.Panel();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonDel = new System.Windows.Forms.Button();
            this.ButtonEdit = new System.Windows.Forms.Button();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.LayoutMain.SuspendLayout();
            this.PanelButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // LayoutMain
            // 
            this.LayoutMain.ColumnCount = 1;
            this.LayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutMain.Controls.Add(this.LvMain, 0, 0);
            this.LayoutMain.Controls.Add(this.PanelButton, 0, 1);
            this.LayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutMain.Location = new System.Drawing.Point(0, 0);
            this.LayoutMain.Name = "LayoutMain";
            this.LayoutMain.RowCount = 2;
            this.LayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.LayoutMain.Size = new System.Drawing.Size(392, 212);
            this.LayoutMain.TabIndex = 0;
            // 
            // LvMain
            // 
            this.LvMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColName,
            this.ColTarget,
            this.ColKey});
            this.LvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LvMain.FullRowSelect = true;
            this.LvMain.Location = new System.Drawing.Point(3, 3);
            this.LvMain.Name = "LvMain";
            this.LvMain.Size = new System.Drawing.Size(386, 166);
            this.LvMain.SmallImageList = this.ImgListLvMain;
            this.LvMain.TabIndex = 1;
            this.LvMain.UseCompatibleStateImageBehavior = false;
            this.LvMain.View = System.Windows.Forms.View.Details;
            this.LvMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LvMain_MouseDoubleClick);
            this.LvMain.SelectedIndexChanged += new System.EventHandler(this.LvMain_SelectedIndexChanged);
            this.LvMain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LvMain_KeyDown);
            // 
            // ColName
            // 
            this.ColName.Text = "外部工具名称";
            this.ColName.Width = 101;
            // 
            // ColTarget
            // 
            this.ColTarget.Text = "目标";
            this.ColTarget.Width = 175;
            // 
            // ColKey
            // 
            this.ColKey.Text = "快捷键";
            this.ColKey.Width = 86;
            // 
            // ImgListLvMain
            // 
            this.ImgListLvMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImgListLvMain.ImageStream")));
            this.ImgListLvMain.TransparentColor = System.Drawing.Color.Transparent;
            this.ImgListLvMain.Images.SetKeyName(0, "file_16x16.png");
            this.ImgListLvMain.Images.SetKeyName(1, "link_gif_16x16.gif");
            // 
            // PanelButton
            // 
            this.PanelButton.Controls.Add(this.ButtonCancel);
            this.PanelButton.Controls.Add(this.ButtonDel);
            this.PanelButton.Controls.Add(this.ButtonEdit);
            this.PanelButton.Controls.Add(this.ButtonAdd);
            this.PanelButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.PanelButton.Location = new System.Drawing.Point(29, 175);
            this.PanelButton.Name = "PanelButton";
            this.PanelButton.Size = new System.Drawing.Size(360, 34);
            this.PanelButton.TabIndex = 2;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(285, 6);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 25);
            this.ButtonCancel.TabIndex = 6;
            this.ButtonCancel.Text = "关闭(&C)";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ButtonDel
            // 
            this.ButtonDel.Enabled = false;
            this.ButtonDel.Location = new System.Drawing.Point(204, 6);
            this.ButtonDel.Name = "ButtonDel";
            this.ButtonDel.Size = new System.Drawing.Size(75, 25);
            this.ButtonDel.TabIndex = 5;
            this.ButtonDel.Text = "删除(&D)...";
            this.ButtonDel.UseVisualStyleBackColor = true;
            this.ButtonDel.Click += new System.EventHandler(this.ButtonDel_Click);
            // 
            // ButtonEdit
            // 
            this.ButtonEdit.Enabled = false;
            this.ButtonEdit.Location = new System.Drawing.Point(123, 6);
            this.ButtonEdit.Name = "ButtonEdit";
            this.ButtonEdit.Size = new System.Drawing.Size(75, 25);
            this.ButtonEdit.TabIndex = 4;
            this.ButtonEdit.Text = "编辑(&E)...";
            this.ButtonEdit.UseVisualStyleBackColor = true;
            this.ButtonEdit.Click += new System.EventHandler(this.ButtonEdit_Click);
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Location = new System.Drawing.Point(42, 6);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(75, 25);
            this.ButtonAdd.TabIndex = 3;
            this.ButtonAdd.Text = "添加(&A)...";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // FrmPluginsManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(392, 212);
            this.Controls.Add(this.LayoutMain);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "FrmPluginsManager";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "外部工具管理器";
            this.Load += new System.EventHandler(this.FrmPluginsManager_Load);
            this.LayoutMain.ResumeLayout(false);
            this.PanelButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel LayoutMain;
        private System.Windows.Forms.ListView LvMain;
        private System.Windows.Forms.ColumnHeader ColName;
        private System.Windows.Forms.ColumnHeader ColTarget;
        private System.Windows.Forms.ColumnHeader ColKey;
        private System.Windows.Forms.Panel PanelButton;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonEdit;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.Button ButtonDel;
        private System.Windows.Forms.ImageList ImgListLvMain;

    }
}