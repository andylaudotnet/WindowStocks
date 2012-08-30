// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FrmMain.cs" company="NSnaiL">
//   Copyright (C) 2009 NSnaiL
// </copyright>
// <summary>
//   Defines the FrmMain type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WindowStocks
{
	using System;
	using System.Collections;
	using System.ComponentModel;
	using System.Diagnostics;
	using System.Drawing;
	using System.IO;
	using System.Text;
	using System.Windows.Forms;
	using FrmSettings;

	internal partial class FrmMain : FrmBase
	{
		#region Methods (52)

		// Private Methods (52) 

		private void ContextMenuMain_Closed(object sender, ToolStripDropDownClosedEventArgs e)
		{
			IsAllowMsg = true;
		}

		private void ContextMenuMain_Opening(object sender, CancelEventArgs e)
		{
			IsAllowMsg = false;
			if (FrmMsg.Visible) FrmMsg.Hide();
		}

		private void ContextMenuTools_Opening(object sender, CancelEventArgs e)
		{
			MiToolState.Checked = ToolMain.Visible;
			MiStatusState.Checked = StatusMain.Visible;
			MiLockBar.Checked = ToolMain.GripStyle == ToolStripGripStyle.Hidden &&
				StatusMain.GripStyle == ToolStripGripStyle.Hidden
				&& MenuMain.GripStyle == ToolStripGripStyle.Hidden
				? true : false;
		}

		private void ExNotifyIcon_MouseLeave()
		{
			FrmMsg.TimerMain.Enabled = true;
		}

		private void ExNotifyIcon_MouseMove()
		{
			if (FrmMsg.Visible || !IsAllowMsg) return;
			FrmMsg.ShowBallon(this, Properties.Resources.main_48x48, SystemColors.Control, "窗口行情 - 统计信息", LabelStat.Text.Replace("    ", "\n"));
			FrmMsg.TimerMain.Enabled = false;
		}

		private void FrmMain_Disposed(object sender, EventArgs e)
		{
			FrmIsDisposed = true;
		}

		private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
		{
			Program.Config.WindowSize = Size;
			Program.Config.Save(Program.PathConfig);
			Program.UserData.Save(Program.PathUserData);

			//恢复窗口标题栏
			if (MqHwnd != IntPtr.Zero)
				Win32.SetWindowText(MqHwnd, new StringBuilder(GetWindowTextClr(MqHwnd).Replace(MqData, string.Empty)));

			//卸载热键
			Win32.UnregisterHotKey(Handle, HotKeyId);

			//SignOut
			Win32.ShellExecute(Handle, "open", Program.PathAppFolder + "\\windowstocks.sign.exe", "signout", string.Empty, Win32.SW_SHOW);
		}

		private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason != CloseReason.UserClosing) return;
			e.Cancel = true;
			WindowState = FormWindowState.Minimized;
		}

		private void FrmMain_Load(object sender, EventArgs e)
		{
			//窗口大小
			Size = Program.Config.WindowSize;

			//工具栏是否可视.
			ToolMain.Visible = Program.Config.IsShowToolBar;
			StatusMain.Visible = Program.Config.IsShowStatusBar;
			MenuMain.GripStyle = ToolMain.GripStyle = StatusMain.GripStyle = Program.Config.IsLockBar ? ToolStripGripStyle.Hidden : ToolStripGripStyle.Visible;

			//编辑菜单
			MiEdit.DropDown = GvMain.ContextMenuStrip;

			//格式菜单
			ToolBtnFormat.DropDown = MiFormat.DropDown;

			//滚轮卷动GvMain的Scroll
			GvMain.MouseWheel += GvMain_MouseWheel;

			//显示列
			if (Program.Config.GvMainColVisibles.Length < GvMain.Columns.Count)
				Program.Config.ResetGvMainColVisibles();
			if (Program.Config.GvMainColDisplays.Length < GvMain.Columns.Count)
				Program.Config.ResetGvMainColDisplays();
			for (int i = 0; i < GvMain.Columns.Count; i++) {
				GvMain.Columns[i].Visible = Program.Config.GvMainColVisibles[i];
				GvMain.Columns[i].DisplayIndex = Program.Config.GvMainColDisplays[i];
			}

			GvMain.Columns["GvmColArrow"].HeaderCell.Tag = "涨跌指示器";
			GvMain.Columns["GvmColBell"].HeaderCell.Tag = "预警指示器";
			GvMain.Columns["GvmColShowInTitle"].HeaderCell.Tag = "标题栏行情指示器";
			GvMain.Columns["GvmColMyStock"].HeaderCell.Tag = "持仓指示器";
			GvMain.Columns["GvmColRateForDay"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

			//自动尺寸
			ToolBtnColAutoSize.Checked = MiAutoSize.Checked = Program.Config.GvMainAutoSize;
			if (Program.Config.GvMainAutoSize) {
				GvMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
				GvMain.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
				GvMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			} else {
				GvMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
				GvMain.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
				GvMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
			}

			IsInitDisplayIndex = false;

			Program.ConfigChanged += Program_ConfigChanged;
			Program_ConfigChanged(null, null);
			Disposed += FrmMain_Disposed;
			Text = "窗口行情 " + Program.ProductVersion;

			FrmMsg.Click += FrmMsg_Click;
			FrmMsg.LabelTitle.Click += FrmMsg_Click;
			FrmMsg.LabelBody.Click += FrmMsg_Click;
			FrmMsg.PicIcon.Click += FrmMsg_Click;
			FrmMsg.LayoutMain.Click += FrmMsg_Click;
			FrmMsg.PanelMain.Click += FrmMsg_Click;
			FrmMsg.KeyDown += FrmMsg_KeyDown;

			ExNotifyIcon = new ExtendedNotifyIcon(NotifyMain, 100);
			ExNotifyIcon.MouseLeave += ExNotifyIcon_MouseLeave;
			ExNotifyIcon.MouseMove += ExNotifyIcon_MouseMove;

			//Sign in
			if (!File.Exists(Program.PathAppFolder + "\\windowstocks.sign.exe")) {
				MessageBox.Show(this, "系统检测到缺少组件\"WindowStocks.Sign.exe\". 为确保程序正常运行, 请到贝塔软件官方网站下载完整安装包重新安装.", "提示",
								MessageBoxButtons.OK, MessageBoxIcon.Error);
				Win32.ShellExecute(Handle, "open", "http://www.beta-1.cn/", string.Empty, string.Empty, Win32.SW_SHOW);
			} else if (Process.GetProcessesByName("WindowStocks.Sign").Length == 0)
				Win32.ShellExecute(Handle, "open", Program.PathAppFolder + "\\windowstocks.sign.exe", "signin", string.Empty, Win32.SW_SHOW);

			//Check Update
			Win32.ShellExecute(Handle, "open", Program.PathAppFolder + "\\WindowStocksUpdater.exe", "/silent", string.Empty, Win32.SW_SHOW);

			InitThDisplay();

		}

		private void FrmMain_Resize(object sender, EventArgs e)
		{
			if (WindowState == FormWindowState.Minimized)
				Visible = false;
		}

		private void FrmMsg_Click(object sender, EventArgs e)
		{
			MiShowHide_Click(null, null);
		}

		private void FrmMsg_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
				FrmMsg.Hide();
		}

		private void FrmSContainer_FormClosed(object sender, FormClosedEventArgs e)
		{
			FrmSContainer = null;
		}

		private void GvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == GvMain.Columns["GvmColBell"].Index) {
				Stock stock = Program.UserData.Stocks[GvMain.Rows[e.RowIndex].Tag] as Stock;
				stock.ShowWarning = !stock.ShowWarning;
				UpdateGvMain(stock);
			}

			if (e.ColumnIndex == GvMain.Columns["GvmColShowInTitle"].Index) {
				Stock stock = Program.UserData.Stocks[GvMain.Rows[e.RowIndex].Tag] as Stock;
				stock.ShowInTitleBar = !stock.ShowInTitleBar;
				UpdateGvMain(stock);
				InitThMarquee();
			}
		}

		private void GvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && e.ColumnIndex > 0)
				MiKLine_Click(null, null);
		}

		private void GvMain_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
			if (e.Button == MouseButtons.Right && !GvMain.Rows[e.RowIndex].Selected)
				GvMain.CurrentCell = GvMain.Rows[e.RowIndex].Cells[e.ColumnIndex];
		}

		private void GvMain_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
		{
			//显示分时预览图
			if (e.ColumnIndex == GvMain.Columns["GvmColChart"].Index && e.RowIndex >= 0 & Program.Config.IsShowChart) {
				ShowChartPreview(Program.UserData.Stocks[GvMain.Rows[e.RowIndex].Tag] as Stock);
				FrmChart.Top = MousePosition.Y;
				FrmChart.Left = MousePosition.X;
			} else {
				if (FrmChart.Visible) {
					FrmChart.ChartUrl = null;
					FrmChart.Hide();
				}
			}
		}

		private void GvMain_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == GvMain.Columns["GvmColChart"].Index && FrmChart.Visible) {
				FrmChart.ChartUrl = null;
				FrmChart.Hide();
			}

		}

		private void GvMain_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
		{
			if (!IsInitDisplayIndex)
				Program.Config.GvMainColDisplays[e.Column.Index] = e.Column.DisplayIndex;
		}

		private void GvMain_DisplayColumnCountChanged(object sender, EventArgs e)
		{
			SetStockMenuEnable((bool)sender);
		}

		private void GvMain_KeyPress(object sender, KeyPressEventArgs e)
		{
			int keyValue = e.KeyChar;
			if (
				(keyValue >= 48 && keyValue <= 57)
				|| (keyValue >= 65 && keyValue <= 90)
				|| (keyValue >= 96 && keyValue <= 105)
				|| (keyValue >= 97 && keyValue <= 122)
				|| keyValue == 106
				) {
				FrmFilter frmFilter = new FrmFilter("添加/查找股票...", "加入/定位(&S)", e.KeyChar.ToString());
				if (frmFilter.ShowDialog(this) == DialogResult.OK
				&& FrmStockEdit.NewAddedStock != null
				) {
					MutexObject.Set();
					InitThMarquee();
				} else if (frmFilter.StockTag != null)
					GvMainSelectRow(frmFilter.StockTag);
			}
		}

		private void GvMain_MouseWheel(object sender, MouseEventArgs e)
		{
			if (GvMain.FirstDisplayedScrollingColumnIndex < 0) return;
			DataGridViewColumn displayColumn;
			if ((e.Delta >= 0 ||
				 !(displayColumn = GetNextDisplayColumn(GvMain.Columns[GvMain.FirstDisplayedScrollingColumnIndex])).Visible) &&
				(e.Delta <= 0 ||
				 !(displayColumn = GetPreviousDisplayColumn(GvMain.Columns[GvMain.FirstDisplayedScrollingColumnIndex])).Visible))
				return;
			GvMain.FirstDisplayedScrollingColumnIndex = displayColumn.Index;
		}

		private void GvMain_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			if (GvMain.Rows.Count > 0 && GvMain.DisplayedColumnCount(false) > 0)
				SetStockMenuEnable(true);
		}

		private void GvMain_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			if (GvMain.Rows.Count == 0)
				SetStockMenuEnable(false);

		}

		private void GvMain_SelectionChanged(object sender, EventArgs e)
		{
			if (GvMain.CurrentRow == null) return;

			if (GvMain.SelectedRows.Count > 1) {
				GvMain.RowsDefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
				GvMain.RowsDefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
				return;
			}

			Stock stock = Program.UserData.Stocks[GvMain.CurrentRow.Tag] as Stock;
			GvMain.RowsDefaultCellStyle.SelectionForeColor = stock.UpDown > 0 ? Program.Config.GvMainForeColorUp
						: stock.UpDown < 0 ? Program.Config.GvMainForeColorDown : Program.Config.GvMainForeColorStill;
			GvMain.RowsDefaultCellStyle.SelectionBackColor = Program.Config.IsShowGvMainHighLight ? Program.Config.GvMainHighLightColor : Program.Config.IsShowGvMainInterlaced ? GvMain.CurrentRow.Index % 2 > 0 ? Program.Config.GvMainInterlacedColor : Program.Config.GvMainBgColor : Program.Config.GvMainBgColor;
		}

		private void GvMain_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
		{
			string strA = e.CellValue1 as string;
			string strB = e.CellValue2 as string;
			if (strA == null || strB == null) return;

			decimal decA, decB;
			DateTime dtA, dtB;

			//日期比较
			if (DateTime.TryParse(strA, out dtA) && DateTime.TryParse(strB, out dtB)) {
				e.SortResult = dtA > dtB ? 1 : dtA == dtB ? 0 : -1;
				e.Handled = true;
			} else {
				//数字比较
				if (e.Column.Name == "GvmColPriceCurrent") {
					strA = strA.Replace(" ＋", string.Empty).Replace(" －", string.Empty).Replace(" ＝", string.Empty);
					strB = strB.Replace(" ＋", string.Empty).Replace(" －", string.Empty).Replace(" ＝", string.Empty);
				}

				if (e.Column.Name.StartsWith("GvmColBuy") || e.Column.Name.StartsWith("GvmColSell")) {
					//截取"/"之前的部分
					int flagIndex;
					if ((flagIndex = strA.IndexOf('/')) > 0)
						strA = strA.Substring(0, flagIndex);
					if ((flagIndex = strB.IndexOf('/')) > 0)
						strB = strB.Substring(0, flagIndex);
				}

				if (decimal.TryParse(strA, out decA) && decimal.TryParse(strB, out decB)) {
					e.SortResult = decA > decB ? 1 : decA == decB ? 0 : -1;
					e.Handled = true;
				}
			}
		}

		private void GvMain_Sorted(object sender, EventArgs e)
		{
			Program.Config.SortColumn = new Config.SortColumnStruct(GvMain.SortedColumn.Name, GvMain.SortOrder == SortOrder.Descending ? ListSortDirection.Descending : ListSortDirection.Ascending);

		}

		private void MenuBar_EndDrag(object sender, EventArgs e)
		{
			MenuMain.Refresh();
		}

		private void MiAbout_Click(object sender, EventArgs e)
		{
			new FrmAbout().ShowDialog();
		}

		private void MiAddStock_Click(object sender, EventArgs e)
		{
			FrmFilter frmFilter = new FrmFilter("添加/查找股票...", "加入/定位(&S)", string.Empty);
			if (frmFilter.ShowDialog(this) == DialogResult.OK
			&& FrmStockEdit.NewAddedStock != null
			) {
				MutexObject.Set();
				InitThMarquee();
			} else if (frmFilter.StockTag != null)
				GvMainSelectRow(frmFilter.StockTag);
		}

		private void MiAutoSize_Click(object sender, EventArgs e)
		{
			Program.Config.GvMainAutoSize = ToolBtnColAutoSize.Checked = MiAutoSize.Checked = !MiAutoSize.Checked;
			if (Program.Config.GvMainAutoSize) {
				GvMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
				GvMain.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
				GvMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			} else {
				int[] preWidths = new int[GvMain.Columns.Count];
				for (int i = 0; i < GvMain.Columns.Count; i++) {
					preWidths[i] = GvMain.Columns[i].Width;
				}

				int[] preHeights = new int[GvMain.Rows.Count];
				for (int i = 0; i < GvMain.Rows.Count; i++) {
					preHeights[i] = GvMain.Rows[i].Height;
				}

				int preHeaderHeight = GvMain.ColumnHeadersHeight;

				GvMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
				GvMain.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
				GvMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

				for (int i = 0; i < GvMain.Columns.Count; i++) {
					GvMain.Columns[i].Width = preWidths[i];
				}

				for (int i = 0; i < GvMain.Rows.Count; i++) {
					GvMain.Rows[i].Height = preHeights[i];
				}

				GvMain.ColumnHeadersHeight = preHeaderHeight;

			}
		}

		private void MiCopyItem_Click(object sender, EventArgs e)
		{
			SendKeys.Send("^C");
		}

		private void MiDelStock_Click(object sender, EventArgs e)
		{
			if (GvMain.SelectedRows.Count == 0) return;
			StringBuilder msg = new StringBuilder("确定要删除这些股票吗?\n");
			Hashtable wCopy = Program.UserData.Stocks.Clone() as Hashtable;
			foreach (DataGridViewRow row in GvMain.SelectedRows) {
				Stock stockFor = wCopy[row.Tag] as Stock;
				msg.AppendFormat("{0}({1})\n", stockFor.Name, stockFor.Code);
			}

			if (MessageBox.Show(msg.ToString(), "窗口行情", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
				return;
			lock (Program.UserData.Stocks) {
				foreach (DataGridViewRow row in GvMain.SelectedRows) {
					Program.UserData.Stocks.Remove(row.Tag);
					GvMain.Rows.Remove(row);
				}

				Program.UserData.Save(Program.PathUserData);
				MutexObject.Set();
			}
		}

		private void MiEditStock_Click(object sender, EventArgs e)
		{
			Stock stock = Program.UserData.Stocks[GvMain.CurrentRow.Tag] as Stock;
			FrmStockEdit frmEdit = new FrmStockEdit(stock, false);
			frmEdit.StartPosition = FormStartPosition.CenterParent;
			if (frmEdit.ShowDialog(this) == DialogResult.OK)
				UpdateGvMain(stock);
		}

		private void MiExit2_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void MiFormatClear_Click(object sender, EventArgs e)
		{
			GvMain.CurrentCell.Style.Tag = null;
			GvMain.CurrentCell.Style = GvMain.Columns[GvMain.CurrentCell.ColumnIndex].DefaultCellStyle;
			UpdateGvMain(Program.UserData.Stocks[GvMain.CurrentRow.Tag] as Stock);
		}

		private void MiFullScreen_Click(object sender, EventArgs e)
		{
			if (IsFullScreen) {
				MenuMain.Visible = true;
				ToolMain.Visible = true;
				StatusMain.Visible = true;
				FormBorderStyle = FormBorderStyle.Sizable;
				Win32.SendMessage(Handle, 0x0112, 0xf120, 0);

			} else {
				MenuMain.Visible = false;
				ToolMain.Visible = false;
				StatusMain.Visible = false;
				FormBorderStyle = FormBorderStyle.None;
				WindowState = FormWindowState.Maximized;
			}

			IsFullScreen = !IsFullScreen;
		}

		private void MiKLine_Click(object sender, EventArgs e)
		{
			Stock stock = Program.UserData.Stocks[GvMain.CurrentRow.Tag] as Stock;
			new FrmKLine(stock).Show(this);
		}

		private void MiLockBar_CheckedChanged(object sender, EventArgs e)
		{
			Program.Config.IsLockBar = MiLockBar.Checked;
			MenuMain.GripStyle = ToolMain.GripStyle = StatusMain.GripStyle = Program.Config.IsLockBar ? ToolStripGripStyle.Hidden : ToolStripGripStyle.Visible;
		}

		private void MiMarkBackColor_Click(object sender, EventArgs e)
		{
			ColorDialog dialog = new ColorDialog();
			if (dialog.ShowDialog(this) == DialogResult.OK) {
				GvMain.CurrentCell.Style.BackColor = dialog.Color;
				GvMain.CurrentCell.Style.Tag = "UserFormated";
			}
		}

		private void MiMarkFont_Click(object sender, EventArgs e)
		{
			FontDialog dialog = new FontDialog();
			dialog.Font = GvMain.CurrentCell.Style.Font;
			if (dialog.ShowDialog(this) == DialogResult.OK) {
				GvMain.CurrentCell.Style.Font = dialog.Font;
				GvMain.CurrentCell.Style.Tag = "UserFormated";
			}
		}

		private void MiMarkForeColor_Click(object sender, EventArgs e)
		{
			ColorDialog dialog = new ColorDialog();
			if (dialog.ShowDialog(this) == DialogResult.OK) {
				GvMain.CurrentCell.Style.ForeColor = dialog.Color;
				GvMain.CurrentCell.Style.Tag = "UserFormated";
			}
		}

		private void MiMoveDown_Click(object sender, EventArgs e)
		{
			DataGridViewRow dr = GvMain.CurrentRow;
			if (dr.Index < GvMain.Rows.Count - 1) {
				int index = dr.Index;
				GvMain.Rows.Remove(dr);
				GvMain.Rows.Insert(index + 1, dr);
				GvMain.ClearSelection();
				dr.Selected = true;
				GvMain.CurrentCell = dr.Cells[GvMain.CurrentCell.ColumnIndex];
			}
		}

		private void MiMoveUp_Click(object sender, EventArgs e)
		{
			DataGridViewRow dr = GvMain.CurrentRow;
			if (dr.Index > 0) {
				int index = dr.Index;
				GvMain.Rows.Remove(dr);
				GvMain.Rows.Insert(index - 1, dr);
				GvMain.ClearSelection();
				dr.Selected = true;
				GvMain.CurrentCell = dr.Cells[GvMain.CurrentCell.ColumnIndex];
			}
		}

		private void MiOptions_Click(object sender, EventArgs e)
		{
			if (FrmSContainer == null) {
				FrmSContainer = new FrmSContainer();
				FrmSContainer.FormClosed += FrmSContainer_FormClosed;
				FrmSContainer.Show(this);
			} else
				FrmSContainer.Focus();

		}

		private void MiSelectCols_Click(object sender, EventArgs e)
		{
			FrmSelectCols frm = new FrmSelectCols(GvMain);
			frm.GvMain_DisplayColumnCountChanged += GvMain_DisplayColumnCountChanged;
			frm.Show(this);
		}

		private void MiShowHide_Click(object sender, EventArgs e)
		{

			if (FrmMsg.Visible)
				FrmMsg.Hide();

			if (WindowState != FormWindowState.Minimized && Win32.GetForegroundWindow() == Handle)
				WindowState = FormWindowState.Minimized;
			else {
				if (!Visible)
					Visible = true;
				Win32.SendMessage(Handle, 0x0112, 0xf120, 0);
				Win32.SetForegroundWindow(Handle);
			}

		}

		private void MiStatusState_CheckedChanged(object sender, EventArgs e)
		{
			Program.Config.IsShowStatusBar = StatusMain.Visible = MiStatusState.Checked;
		}

		private void MiToolState_CheckedChanged(object sender, EventArgs e)
		{
			Program.Config.IsShowToolBar = ToolMain.Visible = MiToolState.Checked;
		}

		private void MiUpdate_Click(object sender, EventArgs e)
		{
			Win32.ShellExecute(Handle, "open", Program.PathAppFolder + "\\WindowStocksUpdater.exe", "/checknow", string.Empty, Win32.SW_SHOW);
		}

		private void NotifyMain_DoubleClick(object sender, EventArgs e)
		{
			MiShowHide_Click(null, null);
		}

		private new void Program_ConfigChanged(object sender, EventArgs e)
		{
			base.Program_ConfigChanged(sender, e);
			StatusMain.Font = MenuMain.Font = ToolMain.Font = ContextMenuGv.Font = ContextMenuMain.Font = Program.Config.GenericFont;
			MiKLine.Font = new Font(Program.Config.GenericFont, FontStyle.Bold);
			GvMain.DefaultCellStyle.BackColor = Program.Config.GvMainBgColor;
			GvMain.BackgroundColor = SystemColors.AppWorkspace;
			GvMain.CellBorderStyle = Program.Config.IsShowGvMainGridLines ? DataGridViewCellBorderStyle.Single :
				DataGridViewCellBorderStyle.None;
			GvMain.GridColor = Program.Config.GvMainGridLinesColor;
			GvMain.AlternatingRowsDefaultCellStyle.BackColor = Program.Config.IsShowGvMainInterlaced ?
				Program.Config.GvMainInterlacedColor : Program.Config.GvMainBgColor;
			if (Program.Config.IsShowGvMainHighLight)
				GvMain.RowsDefaultCellStyle.SelectionBackColor = Program.Config.GvMainHighLightColor;
			MenuMain.RenderMode = ToolMain.RenderMode = StatusMain.RenderMode = ContextMenuMain.RenderMode = ContextMenuGv.RenderMode = ToolContainerMain.LeftToolStripPanel.RenderMode = ToolContainerMain.TopToolStripPanel.RenderMode = ToolContainerMain.RightToolStripPanel.RenderMode = ToolContainerMain.BottomToolStripPanel.RenderMode = Program.Config.RenderMode;

			//外部工具
			MiPlugins.DropDownItems.Clear();
			foreach (Config.PluginStruct plug in Program.Config.Plugins) {
				ToolStripMenuItem item = new ToolStripMenuItem();
				item.Text = plug.Name;
				item.ShortcutKeys = plug.ShortKeyModifiers | plug.ShortKeyCode;
				item.ToolTipText = plug.CommandLine;
				item.Image = plug.IsUrl ? Properties.Resources.link_gif_16x16 : Properties.Resources.file_16x16;
				item.Click += MiPluginsItem_Click;
				MiPlugins.DropDownItems.Add(item);
			}

			MiPlugins.DropDownItems.Add(new ToolStripSeparator());
			ToolStripMenuItem miManagePlugins = new ToolStripMenuItem("管理外部工具(&M)", Properties.Resources.plugin2_add_16x16, MiManagePlugins_Click);
			miManagePlugins.ShortcutKeys = Keys.Alt | Keys.M;
			MiPlugins.DropDownItems.Add(miManagePlugins);

			//注册热键

			//先卸载
			Win32.UnregisterHotKey(Handle, HotKeyId);

			if (!RegHotKey(Program.Config.HotKeyModifiers, Program.Config.HotKeyCode))
				MessageBox.Show(this, "注册热键失败.", "窗口行情", MessageBoxButtons.OK, MessageBoxIcon.Error);

			InitThMarquee();
		}

		private void MiPluginsItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem item = sender as ToolStripMenuItem;
			Win32.ShellExecute(Handle, "open", item.ToolTipText, string.Empty, string.Empty, Win32.SW_SHOW);
		}

		#endregion Methods

		private void MiTalk_Click(object sender, EventArgs e)
		{
			Win32.ShellExecute(Handle, "open", "iexplore.exe", "http://webchat.tq.cn/sendmain.jsp?uin=8832109", string.Empty, Win32.SW_SHOW);
		}

		private void MiHomePage_Click(object sender, EventArgs e)
		{
			Win32.ShellExecute(Handle, "open", "http://www.beta-1.cn/", string.Empty, string.Empty, Win32.SW_SHOW);
		}

		private void MiManagePlugins_Click(object sender, EventArgs e)
		{
			new FrmPluginsManager().Show(this);
		}

		private void GvMain_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.None) {
				MiDelStock_Click(null, null);
			}
		}
	}
}
