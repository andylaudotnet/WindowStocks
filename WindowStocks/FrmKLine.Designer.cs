namespace WindowStocks
{
	sealed partial class FrmKLine
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmKLine));
			this.FlashMain = new AxShockwaveFlashObjects.AxShockwaveFlash();
			this.LabelLoading = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.FlashMain)).BeginInit();
			this.SuspendLayout();
			// 
			// FlashMain
			// 
			this.FlashMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FlashMain.Enabled = true;
			this.FlashMain.Location = new System.Drawing.Point(0, 0);
			this.FlashMain.Name = "FlashMain";
			this.FlashMain.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("FlashMain.OcxState")));
			this.FlashMain.Size = new System.Drawing.Size(592, 372);
			this.FlashMain.TabIndex = 1;
			this.FlashMain.FlashCall += new AxShockwaveFlashObjects._IShockwaveFlashEvents_FlashCallEventHandler(this.FlashMain_FlashCall);
			this.FlashMain.FSCommand += new AxShockwaveFlashObjects._IShockwaveFlashEvents_FSCommandEventHandler(this.FlashMain_FSCommand);
			this.FlashMain.OnReadyStateChange += new AxShockwaveFlashObjects._IShockwaveFlashEvents_OnReadyStateChangeEventHandler(this.FlashMain_OnReadyStateChange);
			this.FlashMain.OnProgress += new AxShockwaveFlashObjects._IShockwaveFlashEvents_OnProgressEventHandler(this.FlashMain_OnProgress);
			// 
			// LabelLoading
			// 
			this.LabelLoading.BackColor = System.Drawing.Color.Transparent;
			this.LabelLoading.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LabelLoading.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelLoading.ForeColor = System.Drawing.Color.Red;
			this.LabelLoading.Location = new System.Drawing.Point(0, 0);
			this.LabelLoading.Name = "LabelLoading";
			this.LabelLoading.Size = new System.Drawing.Size(592, 372);
			this.LabelLoading.TabIndex = 2;
			this.LabelLoading.Text = "正在加载数据...";
			this.LabelLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// FrmKLine
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(592, 372);
			this.Controls.Add(this.LabelLoading);
			this.Controls.Add(this.FlashMain);
			this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmKLine";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "分时线/K线";
			this.Load += new System.EventHandler(this.FrmKLine_Load);
			((System.ComponentModel.ISupportInitialize)(this.FlashMain)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private AxShockwaveFlashObjects.AxShockwaveFlash FlashMain;
		private System.Windows.Forms.Label LabelLoading;



	}
}