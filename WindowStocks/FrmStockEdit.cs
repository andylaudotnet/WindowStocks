// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FrmEdit.cs" company="NSnaiL">
//   Copyright (C) 2009 NSnaiL
// </copyright>
// <summary>
//   Defines the FrmEdit type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WindowStocks
{
	using System;
	using System.Collections.Generic;
	using System.Windows.Forms;

	internal sealed partial class FrmStockEdit : FrmBase
	{
		#region Fields (3) 

		private static string _NewAddedStock;
		private readonly bool ActionIsAdd;
		private readonly Stock EditingStock;

		#endregion Fields 

		#region Constructors (1) 

		internal FrmStockEdit(Stock stockF, bool actionIsAdd)
		{
			NewAddedStock = null;

			InitializeComponent();
			ActionIsAdd = actionIsAdd;
			EditingStock = stockF;
			NumHoldCount.Value = EditingStock.HoldCount;
			NumHoldPrice.Value = (decimal)EditingStock.HoldPrice;
			LabelCodeVal.Text = EditingStock.Code;
			LabelNameVal.Text = EditingStock.Name;
			ComboNum1.SelectedIndex = 0;
			ComboOperator.SelectedIndex = 0;

			CheckShowInTitleBar.Checked = EditingStock.ShowInTitleBar;
			CheckAlarm.Checked = EditingStock.ShowWarning;
			CheckAlarm_CheckdChanged(null, null);

			if (EditingStock.WarningConditions != null)
				foreach (string s in EditingStock.WarningConditions)
					ListConditions.Items.Add(s);
			RadioAnd.Checked = !
				(RadioOr.Checked = EditingStock.IsOrWarnCondi ? true : false);

			Program.ConfigChanged += Program_ConfigChanged;
			Program_ConfigChanged(null, null);
		}

		#endregion Constructors 

		#region Properties (1) 

		internal static string NewAddedStock
		{
			get { return _NewAddedStock; }
			set { _NewAddedStock = value; }
		}

		#endregion Properties 

		#region Methods (7) 

		// Private Methods (7) 

		private void ButtonAdd_Click(object sender, EventArgs e)
		{
			ListConditions.Items.Add(string.Format("{0} {1} {2}", ComboNum1.Text, ComboOperator.Text, NumNum2.Value));
		}

		private void ButtonOk_Click(object sender, EventArgs e)
		{
			bool oldShowInTitleBar = EditingStock.ShowInTitleBar;
            
			EditingStock.HoldCount = (int)NumHoldCount.Value;
			EditingStock.HoldPrice = NumHoldPrice.Value;
			EditingStock.ShowInTitleBar = CheckShowInTitleBar.Checked;
			EditingStock.ShowWarning = CheckAlarm.Checked;
			EditingStock.IsOrWarnCondi = RadioOr.Checked ? true : false;
			EditingStock.WarningConditions = new List<string>();
			foreach (object item in ListConditions.Items)
				EditingStock.WarningConditions.Add(item.ToString());

			lock (Program.UserData.Stocks.SyncRoot) {
				if (ActionIsAdd) {
					if (Program.UserData.Stocks.ContainsKey(EditingStock.Area + EditingStock.Code)) {
						MessageBox.Show(string.Format("您已经添加过股票{0}({1})了.", EditingStock.Name, EditingStock.Code), "窗口行情", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						ButtonOk.DialogResult = DialogResult.Cancel;
					} else {
						Program.UserData.Stocks.Add(EditingStock.Area + EditingStock.Code, EditingStock);
						Program.UserData.Save(Program.PathUserData);
					}

					NewAddedStock = EditingStock.Name + "(" + EditingStock.Code + ")";
				} else {
					if (EditingStock.ShowInTitleBar &&
						!oldShowInTitleBar)
						Program.ConfigChangedToggle(null, null);
					Program.UserData.Save(Program.PathUserData);
				}
			}

			DialogResult = DialogResult.OK;
			Close();
		}

		private void ButtonRemove_Click(object sender, EventArgs e)
		{
			if (ListConditions.SelectedItems.Count == 0)
				return;
			for (int i = 0; i < ListConditions.SelectedItems.Count; i++)
				ListConditions.Items.Remove(ListConditions.SelectedItems[i]);
		}

		private void CheckAlarm_CheckdChanged(object sender, EventArgs e)
		{
			GroupAlarm.Enabled = CheckAlarm.Checked;
		}

		private void ListConditions_SelectedIndexChanged(object sender, EventArgs e)
		{
			ButtonRemove.Enabled = ListConditions.SelectedItems.Count > 0 ? true : false;
		}

		private void Num_Enter(object sender, EventArgs e)
		{
			NumericUpDown control = (NumericUpDown)sender;
			control.Select(0, control.Value.ToString("f" + control.DecimalPlaces).Length);
		}

		#endregion Methods 
	}
}
