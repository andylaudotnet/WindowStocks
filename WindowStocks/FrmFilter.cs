// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FrmFilter.cs" company="NSnaiL">
//   Copyright (C) 2009 NSnaiL
// </copyright>
// <summary>
//   Defines the FrmFilter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WindowStocks
{
	using System;
	using System.Drawing;
	using System.Net;
	using System.Windows.Forms;

	internal sealed partial class FrmFilter : FrmBase
	{
		#region Fields (1) 

		internal string StockTag;

		#endregion Fields 

		#region Constructors (1) 

		internal FrmFilter(string title, string btnText, string fStr)
		{
			InitializeComponent();

			if (fStr.Length > 0) {
				TextInput.Text = fStr;
				TextInput.Focus();
				TextInput.SelectionStart = TextInput.Text.Length;
			}
			Text = title;
			ButtonAdd.Text = btnText;

			Program.ConfigChanged += Program_ConfigChanged;
			Program_ConfigChanged(null, null);
		}

		#endregion Constructors 

		#region Methods (9) 

		// Private Methods (9) 

		private void ButtonAdd_Click(object sender, EventArgs e)
		{
			if (LvStocks.SelectedItems.Count == 0)
				return;
			Stock selectedStock = Program.StockSource[(int)LvStocks.SelectedItems[0].Tag];
			//如果UserStocks中已包含, 则返回主界面, 并选择此Stock
			if (Program.UserData.Stocks.Contains(selectedStock.Area + selectedStock.Code)) {
				StockTag = selectedStock.Area + selectedStock.Code;
				Close();
				return;
			}
			selectedStock.ShowInTitleBar = true;
			FrmStockEdit frmEdit = new FrmStockEdit(selectedStock, true);
			frmEdit.Top = Top;
			frmEdit.Left = Left + Width;
			if (frmEdit.ShowDialog(this) != DialogResult.OK) return;
			DialogResult = DialogResult.OK;
			Close();
		}

		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void LinkDownload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (
				MessageBox.Show(this, "获取最新股票列表将花费一定时间(取决于您的网速), 是否继续?", "窗口行情", MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
				DialogResult.Yes) return;
			foreach (Control c in Controls)
				c.Enabled = false;
			LabelInfo.Text = "获取股票列表...";
			LabelInfo.Enabled = true;
			Application.DoEvents();
			try {
				MessageBox.Show(this, string.Format("成功获取{0}条股票数据.", Stock.DownloadStockSource(Program.PathStockSourceFile)), "窗口行情", MessageBoxButtons.OK, MessageBoxIcon.Information);
			} catch (WebException webExp) {
				MessageBox.Show(this, string.Format("获取失败, 网络错误({0}).", webExp.Status), "窗口行情", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			} finally {
				foreach (Control c in Controls)
					c.Enabled = true;
				LabelInfo.Text = string.Empty;
			}

			Program.StockSource = Stock.LoadStockSource(Program.PathStockSourceFile);
			LvStocks.Items.Clear();
		}

		private void LvStocks_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Alt && e.KeyCode == Keys.D) {
				TextInput.Focus();
				TextInput.SelectionStart = 0;
				TextInput.SelectionLength = TextInput.Text.Length;
			}
		}

		private void LvStocks_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter) ButtonAdd_Click(null, null);
		}

		private void LvStocks_SelectedIndexChanged(object sender, EventArgs e)
		{
			ButtonAdd.Enabled = MiAdd.Enabled = LvStocks.SelectedItems.Count > 0;

		}

        private new void Program_ConfigChanged(object sender, EventArgs e)
		{
            base.Program_ConfigChanged(sender, e);
			ContextMenuStripMain.RenderMode = Program.Config.RenderMode;
		}

		private void TextInput_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down) {
				LvStocks.Focus();
				if (LvStocks.Items.Count > 0)
					LvStocks.Items[0].Selected = true;
			}

			LvStocks_KeyDown(null, e);
		}

		private void TextInput_TextChanged(object sender, EventArgs e)
		{
			TextInput.ForeColor = SystemColors.WindowText;
			LvStocks.Items.Clear();
			ButtonAdd.Enabled = MiAdd.Enabled = false;
			for (int i = 0; i < Program.StockSource.Count; i++) {
				if (Program.StockSource[i].Code.StartsWith(TextInput.Text) || Program.StockSource[i].Name.StartsWith(TextInput.Text)

					|| Program.StockSource[i].Pinyin.StartsWith(TextInput.Text)) {
					ListViewItem item = new ListViewItem(
							new string[] {
								Program.StockSource[i].Code
								, Program.StockSource[i].Pinyin
								, Program.StockSource[i].Name
								, Program.StockSource[i].AreaChinese
							});
					item.Tag = i;
					LvStocks.Items.Add(item);
				}
			}

			if (LvStocks.Items.Count > 0) {
				foreach (ColumnHeader c in LvStocks.Columns)
					c.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

				//如果只有1个Item,则自动选中
				if (LvStocks.Items.Count == 1) {
					LvStocks.Focus();
					LvStocks.Items[0].Selected = true;
				}
			}
		}

		#endregion Methods 
	}
}
