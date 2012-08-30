// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Stock.cs" company="NSnaiL">
//   Copyright (C) 2009 NSnaiL
// </copyright>
// <summary>
//   Defines the Stock type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WindowStocks
{
	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Net;
	using System.Text;
	using System.Text.RegularExpressions;

	[Serializable]
	public class Stock
	{
		#region Fields (57)

		private string _Area;
		private decimal _Benefit;
		private decimal _BenefitPer;
		private decimal _BusinessAmount;
		private long _BusinessQty;
		[NonSerialized]
		private Image _ChartIcon;
		private string _Code;
		private string _GoogleCompanyId;
		private decimal _HighLimit;
		private long _HoldCount;
		private decimal _HoldPrice;
		private int _InnerVolume;
		private bool _IsOrWarnCondi;
		private decimal _LowLimit;
		private string _Name;
		private int _OuterVolume;
		private string _Pinyin;
		private decimal _PriceBuy1;
		private decimal _PriceBuy2;
		private decimal _PriceBuy3;
		private decimal _PriceBuy4;
		private decimal _PriceBuy5;
		private decimal _PriceClose;
		private decimal _PriceCurrent;
		private decimal? _PriceEarning;
		private decimal _PriceMax;
		private decimal _PriceMin;
		private decimal _PriceOpen;
		private decimal _PriceSell1;
		private decimal _PriceSell2;
		private decimal _PriceSell3;
		private decimal _PriceSell4;
		private decimal _PriceSell5;
		private long _QtyBuy1;
		private long _QtyBuy2;
		private long _QtyBuy3;
		private long _QtyBuy4;
		private long _QtyBuy5;
		private long _QtySell1;
		private long _QtySell2;
		private long _QtySell3;
		private long _QtySell4;
		private long _QtySell5;
		private RateForDayStruct _RateForDay;
		private RunningStruct[] _RunningList;
		private bool _ShowInTitleBar;
		private bool _ShowWarning;
		private decimal _Swing;
		private decimal? _TurnoverRate;
		private DateTime _UpdateTime;
		private decimal _UpDown;
		private decimal _UpDownPer;
		private List<string> _WarningConditions;
		//Google Chart Icon 查询URL
		private const string ChartIconUrl = "http://www.google.cn/finance/chart?cht=s&p=1d&cid=";
		//GoogleCompanyId查询URL
		private const string GoogleComUrl = "http://www.google.cn/finance/match?matchtype=matchall&q=";
		//千股日评URL
		private const string RateForDayUrl = "http://vip.stock.finance.sina.com.cn/quotes_service/api/json_v2.php/CN_QGQPService.getQgqpByOne?symbolstr=";
		//个股行情数据更新URL
		private const string StockDataUrl = "http://qt.gtimg.cn/?r={0}&q=";

		#endregion Fields

		#region Properties (54)

		public string Area
		{
			get { return _Area; }
			set { _Area = value; }
		}

		public string AreaChinese
		{
			get { return Area == "sh" ? "上海" : Area == "sz" ? "深圳" : string.Empty; }
		}

		public decimal Benefit
		{
			get { return _Benefit; }
			set { _Benefit = value; }
		}

		public decimal BenefitPer
		{
			get { return _BenefitPer; }
			set { _BenefitPer = value; }
		}

		public decimal BusinessAmount
		{
			get { return _BusinessAmount; }
			set { _BusinessAmount = value; }
		}

		public long BusinessQty
		{
			get { return _BusinessQty; }
			set { _BusinessQty = value; }
		}

		public Image ChartIcon
		{
			get { return _ChartIcon; }
			set { _ChartIcon = value; }
		}

		public string Code
		{
			get { return _Code; }
			set { _Code = value; }
		}

		public string GoogleCompanyId
		{
			get { return _GoogleCompanyId; }
			set { _GoogleCompanyId = value; }
		}

		public decimal HighLimit
		{
			get { return _HighLimit; }
			set { _HighLimit = value; }
		}

		public long HoldCount
		{
			get { return _HoldCount; }
			set { _HoldCount = value; }
		}

		public decimal HoldPrice
		{
			get { return _HoldPrice; }
			set { _HoldPrice = value; }
		}

		public int InnerVolume
		{
			get { return _InnerVolume; }
			set { _InnerVolume = value; }
		}

		public bool IsOrWarnCondi
		{
			get { return _IsOrWarnCondi; }
			set { _IsOrWarnCondi = value; }
		}

		public decimal LowLimit
		{
			get { return _LowLimit; }
			set { _LowLimit = value; }
		}

		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		public int OuterVolume
		{
			get { return _OuterVolume; }
			set { _OuterVolume = value; }
		}

		public string Pinyin
		{
			get { return _Pinyin; }
			set { _Pinyin = value; }
		}

		public decimal PriceBuy1
		{
			get { return _PriceBuy1; }
			set { _PriceBuy1 = value; }
		}

		public decimal PriceBuy2
		{
			get { return _PriceBuy2; }
			set { _PriceBuy2 = value; }
		}

		public decimal PriceBuy3
		{
			get { return _PriceBuy3; }
			set { _PriceBuy3 = value; }
		}

		public decimal PriceBuy4
		{
			get { return _PriceBuy4; }
			set { _PriceBuy4 = value; }
		}

		public decimal PriceBuy5
		{
			get { return _PriceBuy5; }
			set { _PriceBuy5 = value; }
		}

		public decimal PriceClose
		{
			get { return _PriceClose; }
			set { _PriceClose = value; }
		}

		public decimal PriceCurrent
		{
			get { return _PriceCurrent; }
			set { _PriceCurrent = value; }
		}

		public decimal? PriceEarning
		{
			get { return _PriceEarning; }
			set { _PriceEarning = value; }
		}

		public decimal PriceMax
		{
			get { return _PriceMax; }
			set { _PriceMax = value; }
		}

		public decimal PriceMin
		{
			get { return _PriceMin; }
			set { _PriceMin = value; }
		}

		public decimal PriceOpen
		{
			get { return _PriceOpen; }
			set { _PriceOpen = value; }
		}

		public decimal PriceSell1
		{
			get { return _PriceSell1; }
			set { _PriceSell1 = value; }
		}

		public decimal PriceSell2
		{
			get { return _PriceSell2; }
			set { _PriceSell2 = value; }
		}

		public decimal PriceSell3
		{
			get { return _PriceSell3; }
			set { _PriceSell3 = value; }
		}

		public decimal PriceSell4
		{
			get { return _PriceSell4; }
			set { _PriceSell4 = value; }
		}

		public decimal PriceSell5
		{
			get { return _PriceSell5; }
			set { _PriceSell5 = value; }
		}

		public long QtyBuy1
		{
			get { return _QtyBuy1; }
			set { _QtyBuy1 = value; }
		}

		public long QtyBuy2
		{
			get { return _QtyBuy2; }
			set { _QtyBuy2 = value; }
		}

		public long QtyBuy3
		{
			get { return _QtyBuy3; }
			set { _QtyBuy3 = value; }
		}

		public long QtyBuy4
		{
			get { return _QtyBuy4; }
			set { _QtyBuy4 = value; }
		}

		public long QtyBuy5
		{
			get { return _QtyBuy5; }
			set { _QtyBuy5 = value; }
		}

		public long QtySell1
		{
			get { return _QtySell1; }
			set { _QtySell1 = value; }
		}

		public long QtySell2
		{
			get { return _QtySell2; }
			set { _QtySell2 = value; }
		}

		public long QtySell3
		{
			get { return _QtySell3; }
			set { _QtySell3 = value; }
		}

		public long QtySell4
		{
			get { return _QtySell4; }
			set { _QtySell4 = value; }
		}

		public long QtySell5
		{
			get { return _QtySell5; }
			set { _QtySell5 = value; }
		}

		public RateForDayStruct RateForDay
		{
			get { return _RateForDay; }
			set { _RateForDay = value; }
		}

		public RunningStruct[] RunningList
		{
			get { return _RunningList; }
			set { _RunningList = value; }
		}

		public bool ShowInTitleBar
		{
			get { return _ShowInTitleBar; }
			set { _ShowInTitleBar = value; }
		}

		public bool ShowWarning
		{
			get { return _ShowWarning; }
			set { _ShowWarning = value; }
		}

		public decimal Swing
		{
			get { return _Swing; }
			set { _Swing = value; }
		}

		public decimal? TurnoverRate
		{
			get { return _TurnoverRate; }
			set { _TurnoverRate = value; }
		}

		public DateTime UpdateTime
		{
			get { return _UpdateTime; }
			set { _UpdateTime = value; }
		}

		public decimal UpDown
		{
			get { return _UpDown; }
			set { _UpDown = value; }
		}

		public decimal UpDownPer
		{
			get { return _UpDownPer; }
			set { _UpDownPer = value; }
		}

		public List<string> WarningConditions
		{
			get { return _WarningConditions; }
			set { _WarningConditions = value; }
		}

		#endregion Properties

		#region Methods (7)

		// Public Methods (7) 

		public static int DownloadStockSource(string filePath)
		{
			string html = new WebClient().DownloadString("http://stock.finance.qq.com/cgi-bin/sstock/ggcx");
			Regex regex =
				new Regex(
					"<tr><td align='center' bgcolor='#FFFFFF'><strong></strong>(.*?)</td><td align='center' bgcolor='#FFFFFF'><a href='.*?' target='_blank' class='lcblue'> (.*?) </a></td><td align='center' bgcolor='#FFFFFF'> (.*?)-(.*?) </td></tr>");
			MatchCollection mc = regex.Matches(html);
			if (mc.Count == 0) return 0;
			int gotCount = 0;
			using (Stream s = File.Open(filePath, FileMode.Truncate, FileAccess.Write)) {
				foreach (Match m in mc) {
					if (m.Groups[1].Value.Contains("&")) continue;
					byte[] bytes =
						Encoding.UTF8.GetBytes(string.Format("{0}\t{1}\t{2}\t{3}{4}", m.Groups[3].Value, m.Groups[1].Value, m.Groups[2].Value, m.Groups[4].Value == "深圳" ? "sz" : "sh", Environment.NewLine));
					s.Write(bytes, 0, bytes.Length);
					gotCount++;
				}
			}

			return gotCount;
		}

		public string GetGoogleCompanyId()
		{
			WebClient wc = new WebClient();
			wc.Encoding = Encoding.UTF8;
			string html = wc.DownloadString(GoogleComUrl + Code);
			Match m;
			return ((m = new Regex(string.Format("\"e\":\"{0}\", \"id\":\"(.*?)\"", Area == "sh" ? "SHA" : "SHE")).Match(html)).Success) ? m.Groups[1].Value : null;
		}

		public RateForDayStruct GetRateForDay()
		{
			WebClient wc = new WebClient();
			wc.Encoding = Encoding.GetEncoding(936);
			RateForDayStruct structRtn = new RateForDayStruct();
			Match m;
			if ((m = new Regex(string.Format("date:\"(.*?)\",{0}:\"(.*?)\"", Area + Code)).Match(wc.DownloadString(RateForDayUrl + Area + Code))).Success) {
				structRtn.RateDate = DateTime.Parse(m.Groups[1].Value);
				structRtn.RateString = m.Groups[2].Value;
				structRtn.RequestTime = DateTime.Now;
			}
			return structRtn;
		}

		public static List<Stock> LoadStockSource(string lstFile)
		{
			List<Stock> stocks = new List<Stock>();
			using (StreamReader reader = new StreamReader(File.Open(lstFile, FileMode.Open, FileAccess.Read), Encoding.UTF8)) {
				string line;
				while ((line = reader.ReadLine()) != null) {
					if (line.Length == 0) continue;
					string[] splits = line.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
					if (splits.Length != 4) continue;
					Stock stock = new Stock();
					stock.Code = splits[0];
					stock.Pinyin = splits[1];
					stock.Name = splits[2];
					stock.Area = splits[3];
					stocks.Add(stock);
				}
			}

			return stocks;
		}

		public override string ToString()
		{
			return string.Format("{0} - {1}", Code, Name);
		}

		public static void UpdateStockChartIcon(Stock[] stockList)
		{
			WebClient wc = new WebClient();

			//构造查询URL
			StringBuilder reqUrl = new StringBuilder(ChartIconUrl);
			foreach (Stock s in stockList)
				if (s.GoogleCompanyId != null)
					reqUrl.Append(s.GoogleCompanyId + ",");

			//获取Chart图片
			byte[] chartBytes = wc.DownloadData(reqUrl.ToString());
			using (MemoryStream ms = new MemoryStream(chartBytes)) {
				using (Image img = Bitmap.FromStream(ms)) {
					for (int i = 0, j = 0; i < stockList.Length; i++) {
						if (stockList[i].GoogleCompanyId != null) {
							Bitmap bmp = new Bitmap(50, 15, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

							//裁剪Chart图片
							using (Graphics g = Graphics.FromImage(bmp)) {
								g.DrawImage(img, 0, 0, new Rectangle(0, j, 50, 15), GraphicsUnit.Pixel);
								j += 15;
							}
							stockList[i]._ChartIcon = bmp;

						} else
							stockList[i]._ChartIcon = Properties.Resources.nomini;
					}
				}
			}
		}

		public static bool[] UpdateStockData(Stock[] stockList)
		{
			if (stockList.Length == 0) return new bool[] { false };

			bool[] ret = new bool[stockList.Length];
			WebClient wc = new WebClient();

			//构造查询URL
			StringBuilder reqUrl = new StringBuilder(string.Format(StockDataUrl, new Random().NextDouble()));
			for (int i = 0; i < stockList.Length; i++)
				reqUrl.Append(stockList[i].Area + stockList[i].Code + ",");
			reqUrl = reqUrl.Remove(reqUrl.Length - 1, 1);

			//查询数据
			wc.Encoding = Encoding.GetEncoding(936);
			string dataStr = wc.DownloadString(reqUrl.ToString());
			string[] dataStrLines = dataStr.Split(new char[] { ';', '\n' }, StringSplitOptions.RemoveEmptyEntries);

			//更新数据
			for (int i = 0; i < stockList.Length; i++) {
				Regex regex = new Regex(string.Format("v_{0}=\"(.*?)\"", stockList[i].Area + stockList[i].Code));
				Match m = regex.Match(dataStrLines[i]);
				string[] dataSplit;
				if (!m.Success || (dataSplit = m.Groups[1].Value.Split('~')).Length < 51) {
					ret[i] = false;
					continue;
				}
				stockList[i].PriceCurrent = Convert.ToDecimal(dataSplit[3]);
				stockList[i].PriceClose = Convert.ToDecimal(dataSplit[4]);
				stockList[i].PriceOpen = Convert.ToDecimal(dataSplit[5]);
				stockList[i].OuterVolume = Convert.ToInt32(dataSplit[7]);
				stockList[i].InnerVolume = Convert.ToInt32(dataSplit[8]);
				stockList[i].PriceBuy1 = Convert.ToDecimal(dataSplit[9]);
				stockList[i].QtyBuy1 = Convert.ToInt32(dataSplit[10]);
				stockList[i].PriceBuy2 = Convert.ToDecimal(dataSplit[11]);
				stockList[i].QtyBuy2 = Convert.ToInt32(dataSplit[12]);
				stockList[i].PriceBuy3 = Convert.ToDecimal(dataSplit[13]);
				stockList[i].QtyBuy3 = Convert.ToInt32(dataSplit[14]);
				stockList[i].PriceBuy4 = Convert.ToDecimal(dataSplit[15]);
				stockList[i].QtyBuy4 = Convert.ToInt32(dataSplit[16]);
				stockList[i].PriceBuy5 = Convert.ToDecimal(dataSplit[17]);
				stockList[i].QtyBuy5 = Convert.ToInt32(dataSplit[18]);
				stockList[i].PriceSell1 = Convert.ToDecimal(dataSplit[19]);
				stockList[i].QtySell1 = Convert.ToInt32(dataSplit[20]);
				stockList[i].PriceSell2 = Convert.ToDecimal(dataSplit[21]);
				stockList[i].QtySell2 = Convert.ToInt32(dataSplit[22]);
				stockList[i].PriceSell3 = Convert.ToDecimal(dataSplit[23]);
				stockList[i].QtySell3 = Convert.ToInt32(dataSplit[24]);
				stockList[i].PriceSell4 = Convert.ToDecimal(dataSplit[25]);
				stockList[i].QtySell4 = Convert.ToInt32(dataSplit[26]);
				stockList[i].PriceSell5 = Convert.ToDecimal(dataSplit[27]);
				stockList[i].QtySell5 = Convert.ToInt32(dataSplit[28]);

				//逐笔
				string[] runnings = dataSplit[29].Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
				stockList[i].RunningList = new RunningStruct[runnings.Length];
				for (int j = 0; j < runnings.Length; j++) {
					string[] runnings2 = runnings[j].Split(new char[] { '/' });
					stockList[i].RunningList[j].Time = Convert.ToDateTime(runnings2[0]);
					stockList[i].RunningList[j].Price = Convert.ToDecimal(runnings2[1]);
					stockList[i].RunningList[j].Volume = Convert.ToInt32(runnings2[2]);
					stockList[i].RunningList[j].IsBuy = runnings2[3] == "B" ? true : false;
				}

				DateTime updateTime = DateTime.ParseExact(dataSplit[30], "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
				stockList[i].UpdateTime = updateTime;

				stockList[i].UpDown = Convert.ToDecimal(dataSplit[31]);
				stockList[i].UpDownPer = Convert.ToDecimal(dataSplit[32]);

				stockList[i].PriceMax = Convert.ToDecimal(dataSplit[33]);
				stockList[i].PriceMin = Convert.ToDecimal(dataSplit[34]);
				stockList[i].BusinessQty = Convert.ToInt64(dataSplit[36]);
				stockList[i].BusinessAmount = Convert.ToDecimal(dataSplit[37]);

				decimal turnoverRate;
				stockList[i].TurnoverRate = decimal.TryParse(dataSplit[38], out turnoverRate) ? turnoverRate as decimal? : null;

				decimal priceEarning;
				stockList[i].PriceEarning = decimal.TryParse(dataSplit[39], out priceEarning) ? priceEarning as decimal? : null;

				stockList[i].Swing = Convert.ToDecimal(dataSplit[43]);
				stockList[i].HighLimit = Convert.ToDecimal(dataSplit[47]);
				stockList[i].LowLimit = Convert.ToDecimal(dataSplit[48]);

				//更新GoogleCompanyId;
				if (stockList[i].GoogleCompanyId == null)
					stockList[i].GoogleCompanyId = stockList[i].GetGoogleCompanyId();

				//更新RateForDay
				if (stockList[i].RateForDay.RequestTime < DateTime.Now.Date)
					stockList[i].RateForDay = stockList[i].GetRateForDay();
				ret[i] = true;
			}
			return ret;
		}

		#endregion Methods


		[Serializable]
		public struct RunningStruct
		{
			#region Data Members (4)

			public bool IsBuy;
			public decimal Price;
			public DateTime Time;
			public int Volume;

			#endregion Data Members
		}
		[Serializable]
		public struct RateForDayStruct
		{
			#region Data Members (3)

			public DateTime RateDate;
			public string RateString;
			public DateTime RequestTime;

			#endregion Data Members
		}
	}
}
