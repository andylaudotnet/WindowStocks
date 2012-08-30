// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FrmMain.Functions.cs" company="NSnaiL">
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
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    using WindowStocks.FrmSettings;
    using System.IO;
    using System.Diagnostics;

    internal partial class FrmMain
    {
        #region Fields (17)

        private ExtendedNotifyIcon ExNotifyIcon;
        private readonly FrmChart FrmChart = new FrmChart();
        private bool FrmIsDisposed;
        private FrmBallon FrmMsg = new FrmBallon();
        private FrmSContainer FrmSContainer;
        private const int HotKeyId = 880326;
        private bool IsAllowMsg = true;
        private bool IsFirstShowStocks = true;
        private bool IsFullScreen;
        private bool IsInitDisplayIndex = true;
        private bool IsWebExpAutoRetry = false;
        private string MqData;
        private IntPtr MqHwnd = IntPtr.Zero;
        private StringBuilder MqTitle;
        private readonly AutoResetEvent MutexObject = new AutoResetEvent(true);
        /// <summary>
        /// 更新和显示数据线程
        /// </summary>
        private Thread ThDisplay;
        /// <summary>
        /// 活动窗口标题栏显示数据线程
        /// </summary>
        private Thread ThMarquee;

        #endregion Fields

        #region Constructors (2)

        internal FrmMain(FormWindowState state)
            : this()
        {
            WindowState = state;
        }

        internal FrmMain()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Delegates and Events (1)

        // Delegates (1) 

        /// <summary>
        /// test
        /// </summary>
        private delegate void InvokeDelegate();

        #endregion Delegates and Events

        #region Methods (18)

        // Protected Methods (1) 

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0312:	//这个是Window消息定义的	注册的热键消息
                    if (m.WParam.ToInt32() == HotKeyId) //如果是我们注册的那个热键
                        MiShowHide_Click(null, null);
                    break;
            }

            base.WndProc(ref m);
        }
        // Private Methods (17) 

        private void CalcStock(Stock stock, out decimal holdTotal, out decimal total, out decimal pl, out decimal plPer)
        {
            holdTotal = stock.HoldPrice * stock.HoldCount;
            total = stock.PriceCurrent * stock.HoldCount;
            pl = total - holdTotal;
            plPer = holdTotal > 0 ? Math.Round(pl / holdTotal * 100, 2) : 0;
        }

        private static Form GetControlForm(Control control)
        {
            return control.Parent == null ? (Form)control : GetControlForm(control.Parent);
        }

        private DataGridViewColumn GetNextDisplayColumn(DataGridViewColumn currentColumn)
        {
            if (currentColumn.DisplayIndex < GvMain.Columns.Count)
            {
                int nextDispIndex = currentColumn.DisplayIndex + 1;
                foreach (DataGridViewColumn col in GvMain.Columns)
                {
                    if (col.DisplayIndex == nextDispIndex)
                        return col.Visible ? col : GetNextDisplayColumn(col);
                }
            }
            return currentColumn;
        }

        private DataGridViewColumn GetPreviousDisplayColumn(DataGridViewColumn currentColumn)
        {
            if (currentColumn.DisplayIndex > 0)
            {
                int preDispIndex = currentColumn.DisplayIndex - 1;
                foreach (DataGridViewColumn col in GvMain.Columns)
                {
                    if (col.DisplayIndex == preDispIndex)
                        return col.Visible ? col : GetPreviousDisplayColumn(col);
                }
            }
            return currentColumn;
        }

        /// <summary>
        /// test
        /// </summary>
        /// <param name="windowHandle">
        /// The window handle.
        /// </param>
        /// <returns>
        /// test
        /// </returns>
        private static string GetWindowTextClr(IntPtr windowHandle)
        {
            StringBuilder temp = new StringBuilder(1000);
            Win32.GetWindowText(windowHandle, temp, 1000);
            return temp.ToString();
        }

        private void GvMainSelectRow(string rowTag)
        {
            if (GvMain.CurrentCell == null) return;
            GvMain.ClearSelection();
            foreach (DataGridViewRow row in GvMain.Rows)
            {
                if (row.Tag as string == rowTag)
                {
                    row.Selected = true;
                    GvMain.CurrentCell = row.Cells[GvMain.CurrentCell.ColumnIndex];
                }

            }
        }

        /// <summary>
        /// 初始化(更新和显示数据线程)
        /// </summary>
        private void InitThDisplay()
        {
            ThDisplay = new Thread(ProcDisplay);
            ThDisplay.IsBackground = true;
            ThDisplay.Start();
        }

        /// <summary>
        /// test
        /// </summary>
        private void InitThMarquee()
        {
            if (ThMarquee != null) return;
            ThMarquee = new Thread(ProcMarquee);
            ThMarquee.IsBackground = true;
            ThMarquee.Start();
        }

        /// <summary>
        /// test
        /// </summary>
        private void MarqueeResotre()
        {
            //恢复上次窗口的原标题
            if (MqHwnd != IntPtr.Zero)
                if (Program.Config.IsReplaceWindowTitle)
                {
                    if (MqTitle != null)
                        Win32.SetWindowText(MqHwnd, MqTitle);
                }
                else
                    Win32.SetWindowText(MqHwnd, new StringBuilder(GetWindowTextClr(MqHwnd).Replace(MqData, string.Empty)));
        }

        /// <summary>
        /// 更新和显示数据.
        /// </summary>
        private void ProcDisplay()
        {
            while (true)
            {
                if (Program.UserData.Stocks.Count > 0)
                {
                    //创建用户自选股票数组, 批量更新
                    Stock[] userStocks = Program.UserData.ToStockArray();
                    try
                    {
                        //锁定Stocks, 拒绝其他线程修改.
                        lock (Program.UserData.Stocks.SyncRoot)
                        {
                            bool[] result = Stock.UpdateStockData(userStocks);

                            //寻找更新不成功(无效)的股票, 将其从UserData中移除.
                            for (int j = 0; j < result.Length; j++)
                                if (!result[j])
                                {
                                    Program.UserData.Stocks.Remove(userStocks[j].Area + userStocks[j].Code);
                                    Program.UserData.Save(Program.PathUserData);
                                }

                            //获取Google Chart Icon
                            Stock.UpdateStockChartIcon(Program.UserData.ToStockArray());
                        }
                    }
                    catch (WebException)
                    {
                        //网络错误, 提示用户
                        if (FrmIsDisposed) return;
                        Invoke(new InvokeDelegate(delegate
                        {
                            if (IsWebExpAutoRetry || MessageBox.Show(this, "网络连接失败.", "窗口行情", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                            {
                                //自动重试设置为True
                                IsWebExpAutoRetry = true;
                                //重新初始化ThDisplay
                                InitThDisplay();
                            }
                            else Application.Exit();
                        }));
                        return;
                    }
                    catch {
                        //未处理的异常.
                    }

                    //更新GvMain
                    if (FrmIsDisposed) return;
                    Invoke(new InvokeDelegate(delegate
                    {
                        ShowStocks(Program.UserData.ToStockArray());
                    }));

                }
                else
                {
                    if (FrmIsDisposed) return;
                    Invoke(new InvokeDelegate(delegate
                    {
                        LabelStat.Text = "请按F3添加股票...";
                        if (LabelStat.Image != Properties.Resources.info_16x16)
                            LabelStat.Image = Properties.Resources.info_16x16;
                    }));
                }
                MutexObject.WaitOne(Program.Config.UpdateCycle * 1000, true);
            }
        }

        /// <summary>
        /// 标题栏行情显示.
        /// </summary>
        private void ProcMarquee()
        {
            while (true)
            {
                List<Stock> showStocksArray = new List<Stock>();

                foreach (DictionaryEntry de in Program.UserData.Stocks)
                {
                    Stock stockF = de.Value as Stock;
                    if (stockF.ShowInTitleBar)
                        showStocksArray.Add(stockF);
                }

                //如果所有Stock都设置为不在标题栏显示则退出ProcMaquree线程
                if (showStocksArray.Count == 0)
                {
                    ThMarquee = null;
                    MarqueeResotre();
                    return;
                }

                for (int i = 0; i < showStocksArray.Count; )
                {
                    //获取当前窗口句柄
                    IntPtr hWnd = Win32.GetForegroundWindow();
                    if (hWnd == IntPtr.Zero)
                        continue;

                    StringBuilder data = new StringBuilder();

                    for (int j = 0; j < Program.Config.WindowTitleCount; j++)
                    {
                        if (i + j >= showStocksArray.Count)
                            break;
                        Stock stock = showStocksArray[i + j];

                        decimal holdTotal;
                        decimal total;
                        decimal pl;
                        decimal plPer;
                        CalcStock(stock, out holdTotal, out total, out pl, out plPer);
                        data.Append(Program.Config.WindowTitleFormat
                            .Replace("{code}", stock.Code)
                            .Replace("{pinyin}", stock.Pinyin)
                            .Replace("{name}", stock.Name)
                            .Replace("{ratefd}", stock.RateForDay.RateString)
                            .Replace("{area}", stock.AreaChinese)
                            .Replace("{pclose}", stock.PriceClose.ToString("n2"))
                            .Replace("{popen}", stock.PriceOpen.ToString("n2"))
                            .Replace("{pcurr}", stock.PriceCurrent.ToString("n2"))
                            .Replace("{ud}", stock.UpDown.ToString("n2"))
                            .Replace("{udper}", stock.UpDownPer.ToString("n2"))
                            .Replace("{swing}", stock.Swing.ToString("n2"))
                            .Replace("{rate}", stock.TurnoverRate == null ? "0.00" : ((decimal)stock.TurnoverRate).ToString("n2"))
                            .Replace("{holdc}", stock.HoldCount.ToString("n0"))
                            .Replace("{holdp}", stock.HoldPrice.ToString("n2"))
                            .Replace("{holdt}", holdTotal.ToString("n2"))
                            .Replace("{total}", total.ToString("n2"))
                            .Replace("{pl}", pl.ToString("n2"))
                            .Replace("{plper}", plPer.ToString("n2"))
                            .Replace("{pmax}", stock.PriceMax.ToString("n2"))
                            .Replace("{pmin}", stock.PriceMin.ToString("n2"))
                            .Replace("{amount}", stock.BusinessAmount.ToString("n0"))
                            .Replace("{volume}", stock.BusinessQty.ToString("n0"))
                            .Replace("{outer}", stock.OuterVolume.ToString("n0"))
                            .Replace("{inner}", stock.InnerVolume.ToString("n0"))
                            .Replace("{b1}", stock.QtyBuy1.ToString("n0") + "/" + stock.PriceBuy1.ToString("n2"))
                            .Replace("{b2}", stock.QtyBuy2.ToString("n0") + "/" + stock.PriceBuy2.ToString("n2"))
                            .Replace("{b3}", stock.QtyBuy3.ToString("n0") + "/" + stock.PriceBuy3.ToString("n2"))
                            .Replace("{b4}", stock.QtyBuy4.ToString("n0") + "/" + stock.PriceBuy4.ToString("n2"))
                            .Replace("{b5}", stock.QtyBuy5.ToString("n0") + "/" + stock.PriceBuy5.ToString("n2"))
                            .Replace("{s1}", stock.QtySell1.ToString("n0") + "/" + stock.PriceSell1.ToString("n2"))
                            .Replace("{s2}", stock.QtySell2.ToString("n0") + "/" + stock.PriceSell2.ToString("n2"))
                            .Replace("{s3}", stock.QtySell3.ToString("n0") + "/" + stock.PriceSell3.ToString("n2"))
                            .Replace("{s4}", stock.QtySell4.ToString("n0") + "/" + stock.PriceSell4.ToString("n2"))
                            .Replace("{s5}", stock.QtySell5.ToString("n0") + "/" + stock.PriceSell5.ToString("n2"))
                            .Replace("{hlimit}", stock.HighLimit.ToString("n2"))
                            .Replace("{llimit}", stock.LowLimit.ToString("n2"))
                            .Replace("{date}", stock.UpdateTime.ToString("yyyy-MM-dd"))
                            .Replace("{time}", stock.UpdateTime.ToString("HH:mm:ss")));
                    }

                    i += Program.Config.WindowTitleCount;
                    if (data.Length == 0)
                        continue;

                    MarqueeResotre();

                    MqTitle = new StringBuilder(1000);
                    Win32.GetWindowText(hWnd, MqTitle, 1000);
                    MqHwnd = hWnd;
                    MqData = data.ToString();

                    Win32.SetWindowText(hWnd, Program.Config.IsReplaceWindowTitle ? data : new StringBuilder(MqTitle.ToString() + data));
                    Thread.Sleep(Program.Config.WindowTitleShowTime * 1000);
                }
            }
        }

        private bool RegHotKey(Keys hotKeyModifiers, Keys keyCode)
        {
            /*
             * 辅助键说明
             * None = 0,
             * Alt = 1,
             * crtl= 2,
             * Shift = 4,
             * Windows = 8
             */
            uint control = 0;
            if ((hotKeyModifiers & Keys.Control) == Keys.Control) control += 2;
            if ((hotKeyModifiers & Keys.Alt) == Keys.Alt) control += 1;
            if ((hotKeyModifiers & Keys.Shift) == Keys.Shift) control += 4;

            return Win32.RegisterHotKey(Handle, HotKeyId, control, keyCode);
        }

        private void SetStockMenuEnable(bool enable)
        {
            MiMoveDown.Enabled = MiMoveUp.Enabled = MiKLine.Enabled = MiEditStock.Enabled = MiCopyStock.Enabled = MiDelStock.Enabled = MiFormat.Enabled = ToolBtnCopyStock.Enabled = ToolBtnFormat.Enabled = ToolBtnDelete.Enabled = ToolBtnEdit.Enabled = ToolBtnMoveUp.Enabled = ToolBtnMoveDown.Enabled
                    = enable;
        }

        private void ShowChartPreview(Stock stock)
        {
            FrmChart.ChartUrl = string.Format(
                   "http://bdchart.hexun.com/stock/chart/bf/{0}/{1}.png?{2}", stock.Area == "sh" ? "0" : "1", stock.Code, new Random().NextDouble());
            FrmChart.MutexObject.Set();
            if (FrmChart.Visible) return;
            FrmChart.Show(this);
            GvMain.Focus();
        }

        private void ShowStocks(Stock[] stocks)
        {
            foreach (Stock stock in stocks)
            {
                //GvMain中还没有该股票, 添加.
                if (!UpdateGvMain(stock))
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.Tag = stock.Area + stock.Code;
                    GvMain.Rows.Add(row);
                    GvMain.ClearSelection();
                    if (GvMain.Rows[GvMain.Rows.Count - 1] != null && GvMain.CurrentCell != null)
                    {
                        GvMain.Rows[GvMain.Rows.Count - 1].Selected = true;
                        GvMain.CurrentCell = GvMain.Rows[GvMain.Rows.Count - 1].Cells[GvMain.CurrentCell.ColumnIndex];
                    }

                    //再次调用UpdateLvWish
                    UpdateGvMain(stock);
                }

                //预警显示
                ShowWarning(stock);
            }

            if (!IsFirstShowStocks) return;
            //排序列
            GvMain.Sort(GvMain.Columns[Program.Config.SortColumn.ColumnName], Program.Config.SortColumn.Order);
            IsFirstShowStocks = false;

        }

        private void ShowWarning(Stock stock)
        {
            if (!stock.ShowWarning)
                return;

            decimal holdTotal;
            decimal total;
            decimal pl;
            decimal plPer;
            CalcStock(stock, out holdTotal, out total, out pl, out plPer);

            //判断是否满足预警条件
            bool isContented = false;
            foreach (string s in stock.WarningConditions)
            {
                string[] s1 = s.Split(' ');
                decimal num1 = 0;
                decimal num2 = decimal.Parse(s1[2]);
                switch (s1[0])
                {
                    case "股票价格":
                        num1 = stock.PriceCurrent;
                        break;
                    case "涨跌额":
                        num1 = stock.UpDown;
                        break;
                    case "涨跌幅":
                        num1 = stock.UpDownPer;
                        break;
                    case "振幅":
                        num1 = stock.Swing;
                        break;
                    case "换手率":
                        num1 = stock.TurnoverRate ?? 0;
                        break;
                    case "总现值":
                        num1 = total;
                        break;
                    case "收益":
                        num1 = pl;
                        break;
                    case "收益率":
                        num1 = plPer;
                        break;
                    case "最高价":
                        num1 = stock.PriceMax;
                        break;
                    case "最低价":
                        num1 = stock.PriceMin;
                        break;
                    case "成交量":
                        num1 = stock.BusinessQty;
                        break;
                    case "成交额":
                        num1 = stock.BusinessAmount;
                        break;
                    case "外盘":
                        num1 = stock.OuterVolume;
                        break;
                    case "内盘":
                        num1 = stock.InnerVolume;
                        break;
                }

                //比较
                switch (s1[1])
                {
                    case "大于":
                        isContented = num1 > num2;
                        break;
                    case "小于":
                        isContented = num1 < num2;
                        break;
                    case "等于":
                        isContented = num1 == num2;
                        break;

                }

                if (stock.IsOrWarnCondi && isContented)
                    break;
            }

            //通过, 窗口提示
            if (!isContented) return;

            StringBuilder text = new StringBuilder();
            foreach (string item in stock.WarningConditions)
            {
                text.AppendFormat("{0}{1}{2} ", item, Environment.NewLine, stock.IsOrWarnCondi ? "或者" : "并且");
            }

            if (text.Length > 3)
                text = text.Remove(text.Length - 3, 3);

            FrmAlarm frmAlarm = new FrmAlarm();
            frmAlarm.Tag = stock.Area + stock.Code;
            if (frmAlarm.ShowAlarm(this, string.Format("{0}({1})已满足预警条件, 请注意!", stock.Name, stock.Code), text.ToString()) == DialogResult.OK)
            {
                if (!Visible)
                    MiShowHide_Click(null, null);
                GvMainSelectRow(stock.Area + stock.Code);
                UpdateGvMain(stock);
            }
        }

        private bool UpdateGvMain(Stock stock)
        {
            decimal holdTotal;
            decimal total;
            decimal pl;
            decimal plPer;
            CalcStock(stock, out holdTotal, out total, out pl, out plPer);

            bool isUpdate = false;
            foreach (DataGridViewRow row in GvMain.Rows)
            {
                if (row.Tag as string != stock.Area + stock.Code) continue;
                if (row.Cells["GvmColArrow"].Visible)
                    row.Cells["GvmColArrow"].Value = stock.UpDown > 0 ? Properties.Resources.arrow_up_16x16
                        : stock.UpDown < 0 ? Properties.Resources.arrow_down_16x16 : Properties.Resources.square_16x16;
                if (row.Cells["GvmColBell"].Visible)
                {
                    row.Cells["GvmColBell"].Value = stock.ShowWarning ? Properties.Resources.bell_on_16x16 : Properties.Resources.null_16x16;
                    row.Cells["GvmColBell"].ToolTipText = stock.ShowWarning ? "点击关闭股票预警" : "点击开启股票预警";
                }

                if (row.Cells["GvmColShowInTitle"].Visible)
                    row.Cells["GvmColShowInTitle"].Value = stock.ShowInTitleBar ? Properties.Resources.showintitle_on_16x16 : Properties.Resources.null_16x16;

                if (row.Cells["GvmColShowInTitle"].Visible)
                    row.Cells["GvmColShowInTitle"].ToolTipText = stock.ShowInTitleBar ? "点击关闭标题栏行情" : "点击开启标题栏行情";

                if (row.Cells["GvmColMyStock"].Visible)
                {
                    row.Cells["GvmColMyStock"].Value = stock.HoldCount > 0 ? Properties.Resources.gold_16x16 : Properties.Resources.null_16x16;
                    row.Cells["GvmColMyStock"].ToolTipText = stock.HoldCount > 0 ? string.Format("当前持有{0}股", stock.HoldCount.ToString("n0")) : "当前未持有此股票";
                }

                if (row.Cells["GvmColChart"].Visible && stock.ChartIcon != null)
                    row.Cells["GvmColChart"].Value = stock.ChartIcon;

                if (row.Cells["GvmColCode"].Visible)
                    row.Cells["GvmColCode"].Value = stock.Code;
                if (row.Cells["GvmColPinyin"].Visible)
                    row.Cells["GvmColPinyin"].Value = stock.Pinyin;
                if (row.Cells["GvmColName"].Visible)
                    row.Cells["GvmColName"].Value = stock.Name;
                if (row.Cells["GvmColRateForDay"].Visible)
                {
                    row.Cells["GvmColRateForDay"].Value = stock.RateForDay.RateString;
                    row.Cells["GvmColRateForDay"].ToolTipText = string.IsNullOrEmpty(stock.RateForDay.RateString) ? "暂无日评信息" : stock.RateForDay.RateDate.ToString("日评时间: yyyy-MM-dd");
                }
                if (row.Cells["GvmColMarket"].Visible)
                    row.Cells["GvmColMarket"].Value = stock.AreaChinese;
                if (row.Cells["GvmColPriceClose"].Visible)
                    row.Cells["GvmColPriceClose"].Value = stock.PriceClose;
                if (row.Cells["GvmColPriceOpen"].Visible)
                    row.Cells["GvmColPriceOpen"].Value = stock.PriceOpen;

                if (row.Cells["GvmColPriceCurrent"].Visible)
                {
                    if (row.Cells["GvmColPriceCurrent"].Value != null)
                    {
                        decimal priceCurrentOld = decimal.Parse(row.Cells["GvmColPriceCurrent"].Value.ToString().Replace(" ＋", "").Replace(" －", "").Replace(" ＝", ""));
                        row.Cells["GvmColPriceCurrent"].Value = stock.PriceCurrent > priceCurrentOld ? (stock.PriceCurrent.ToString() + " ＋") :
                            stock.PriceCurrent < priceCurrentOld ? (stock.PriceCurrent + " －") : (stock.PriceCurrent + " ＝");
                    }
                    else row.Cells["GvmColPriceCurrent"].Value = stock.PriceCurrent + " ＝";
                }
                if (row.Cells["GvmColUpDown"].Visible)
                    row.Cells["GvmColUpDown"].Value = stock.UpDown;
                if (row.Cells["GvmColUpDownPer"].Visible)
                    row.Cells["GvmColUpDownPer"].Value = stock.UpDownPer;
                if (row.Cells["GvmColHoldCount"].Visible)
                    row.Cells["GvmColHoldCount"].Value = stock.HoldCount;
                if (row.Cells["GvmColHoldPrice"].Visible)
                    row.Cells["GvmColHoldPrice"].Value = stock.HoldPrice;
                if (row.Cells["GvmColTotal"].Visible)
                    row.Cells["GvmColTotal"].Value = total;
                if (row.Cells["GvmColProfit"].Visible)
                    row.Cells["GvmColProfit"].Value = pl;
                if (row.Cells["GvmColProfitPer"].Visible)
                    row.Cells["GvmColProfitPer"].Value = plPer;
                if (row.Cells["GvmColMaxPrice"].Visible)
                    row.Cells["GvmColMaxPrice"].Value = stock.PriceMax;
                if (row.Cells["GvmColMinPrice"].Visible)
                    row.Cells["GvmColMinPrice"].Value = stock.PriceMin;
                if (row.Cells["GvmColBusinessAmount"].Visible)
                    row.Cells["GvmColBusinessAmount"].Value = stock.BusinessAmount;
                if (row.Cells["GvmColBusinessVolume"].Visible)
                    row.Cells["GvmColBusinessVolume"].Value = stock.BusinessQty;
                if (row.Cells["GvmColBuy1"].Visible)
                    row.Cells["GvmColBuy1"].Value = stock.QtyBuy1.ToString("n0") + "/" + stock.PriceBuy1;
                if (row.Cells["GvmColBuy2"].Visible)
                    row.Cells["GvmColBuy2"].Value = stock.QtyBuy2.ToString("n0") + "/" + stock.PriceBuy2;
                if (row.Cells["GvmColBuy3"].Visible)
                    row.Cells["GvmColBuy3"].Value = stock.QtyBuy3.ToString("n0") + "/" + stock.PriceBuy3;
                if (row.Cells["GvmColBuy4"].Visible)
                    row.Cells["GvmColBuy4"].Value = stock.QtyBuy4.ToString("n0") + "/" + stock.PriceBuy4;
                if (row.Cells["GvmColBuy5"].Visible)
                    row.Cells["GvmColBuy5"].Value = stock.QtyBuy5.ToString("n0") + "/" + stock.PriceBuy5;
                if (row.Cells["GvmColSell1"].Visible)
                    row.Cells["GvmColSell1"].Value = stock.QtySell1.ToString("n0") + "/" + stock.PriceSell1;
                if (row.Cells["GvmColSell2"].Visible)
                    row.Cells["GvmColSell2"].Value = stock.QtySell2.ToString("n0") + "/" + stock.PriceSell2;
                if (row.Cells["GvmColSell3"].Visible)
                    row.Cells["GvmColSell3"].Value = stock.QtySell3.ToString("n0") + "/" + stock.PriceSell3;
                if (row.Cells["GvmColSell4"].Visible)
                    row.Cells["GvmColSell4"].Value = stock.QtySell4.ToString("n0") + "/" + stock.PriceSell4;
                if (row.Cells["GvmColSell5"].Visible)
                    row.Cells["GvmColSell5"].Value = stock.QtySell5.ToString("n0") + "/" + stock.PriceSell5;
                if (row.Cells["GvmColDate"].Visible)
                    row.Cells["GvmColDate"].Value = stock.UpdateTime.ToString("yyyy-MM-dd");
                if (row.Cells["GvmColTime"].Visible)
                    row.Cells["GvmColTime"].Value = stock.UpdateTime.ToString("HH:mm:ss");
                if (row.Cells["GvmColSwing"].Visible)
                    row.Cells["GvmColSwing"].Value = stock.Swing;
                if (row.Cells["GvmColRate"].Visible)
                    row.Cells["GvmColRate"].Value = stock.TurnoverRate;
                if (row.Cells["GvmColHoldTotal"].Visible)
                    row.Cells["GvmColHoldTotal"].Value = holdTotal;
                if (row.Cells["GvmColOuter"].Visible)
                    row.Cells["GvmColOuter"].Value = stock.OuterVolume;
                if (row.Cells["GvmColInner"].Visible)
                    row.Cells["GvmColInner"].Value = stock.InnerVolume;
                if (row.Cells["GvmColHighLimit"].Visible)
                    row.Cells["GvmColHighLimit"].Value = stock.HighLimit;
                if (row.Cells["GvmColLowLimit"].Visible)
                    row.Cells["GvmColLowLimit"].Value = stock.LowLimit;
                if (row.Cells["GvmColPe"].Visible)
                    row.Cells["GvmColPe"].Value = stock.PriceEarning;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Style.Tag as string == "UserFormated") continue;

                    cell.Style.ForeColor = stock.UpDown > 0 ? Program.Config.GvMainForeColorUp
                        : stock.UpDown < 0 ? Program.Config.GvMainForeColorDown : Program.Config.GvMainForeColorStill;
                }
                isUpdate = true;
                break;
            }

            int upCount = 0;
            int downCount = 0;
            decimal totalAmount = 0;
            decimal totalHold = 0;
            decimal totalPl = 0;

            foreach (DictionaryEntry de in Program.UserData.Stocks)
            {
                decimal total1;
                decimal holdTotal1;
                decimal pl1;
                decimal plPer1;

                Stock sTemp = de.Value as Stock;
                CalcStock(sTemp, out holdTotal1, out total1, out pl1, out plPer1);


                if (sTemp.UpDown > 0)
                    upCount++;
                else if (sTemp.UpDown < 0)
                    downCount++;
                totalAmount += total1;
                totalPl += pl1;
                totalHold += holdTotal1;
            }

            LabelStat.Text = string.Format("股票: {0}    涨/跌: {1}/{2}    成本合计: {3}    累计现值: {4}    累计收益: {5}/{6}%", GvMain.Rows.Count, upCount, downCount, totalHold.ToString("c", CultureInfo.GetCultureInfo(0x0804)), totalAmount.ToString("c", CultureInfo.GetCultureInfo(0x0804)), totalPl.ToString("c", CultureInfo.GetCultureInfo(0x0804)), totalHold > 0 ? Math.Round(totalPl / totalHold * 100, 2).ToString("n2") : "0.00");
            if (LabelStat.Image != Properties.Resources.stat_16x16)
                LabelStat.Image = Properties.Resources.stat_16x16;

            return isUpdate;
        }

        #endregion Methods
    }
}
