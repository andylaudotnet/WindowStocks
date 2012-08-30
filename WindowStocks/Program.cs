// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="NSnaiL">
//   Copyright (C) 2009 NSnaiL
// </copyright>
// <summary>
//   Defines the Program type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WindowStocks
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.IO;
	using System.Reflection;
	using System.Windows.Forms;

	public static class Program
	{
		#region Fields (11) 

		private static List<Stock> _AllStocks;
		private static UserData _UserData;
		internal static Config Config;
		internal readonly static string PathAppFolder;
		internal readonly static string PathApplication;
		internal readonly static string PathConfig;
		internal readonly static string PathStockSourceFile;
		internal readonly static string PathUserData;
		public const string ProductVersion = "1.6.0202";
		public const string ProductVersionAdditional = "beta";

		#endregion Fields 

		#region Constructors (1) 

		static Program()
		{
			//禁止多个实例
			if (Process.GetProcessesByName("WindowStocks").Length > 1) Environment.Exit(-1);

			PathApplication = Assembly.GetExecutingAssembly().Location;
			PathAppFolder = Path.GetDirectoryName(PathApplication);
			PathConfig = PathAppFolder + @"\Config_V1";
			PathUserData = PathAppFolder + @"\User_V1_1";
			PathStockSourceFile = PathAppFolder + @"\StocksSource_V1";

			StockSource = Stock.LoadStockSource(PathStockSourceFile);
			Config = Config.Load(PathConfig);
			UserData = UserData.Load(PathUserData);
		}

		#endregion Constructors 

		#region Properties (2) 

		internal static List<Stock> StockSource
		{
			get { return _AllStocks; }
			set { _AllStocks = value; }
		}

		internal static UserData UserData
		{
			get { return _UserData; }
			set { _UserData = value; }
		}

		#endregion Properties 

		#region Delegates and Events (1) 

		// Events (1) 

		internal static event EventHandler ConfigChanged;

		#endregion Delegates and Events 

		#region Methods (2) 

		// Private Methods (1) 

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		/// <param name="args">
		/// The args.
		/// </param>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			bool argsNull = args == null || args.Length == 0;
			FormWindowState state = FormWindowState.Normal;
			if (!argsNull) {

				switch (args[0]) {
					case "maximized":
						state = FormWindowState.Maximized;
						break;
					case "minimized":
						state = FormWindowState.Minimized;
						break;
					case "normal":
						state = FormWindowState.Normal;
						break;
					default:
						argsNull = true;
						break;
				}
			}

			if (argsNull)
				Application.Run(new FrmMain());
			else
				Application.Run(new FrmMain(state));
		}
		// Internal Methods (1) 

		internal static void ConfigChangedToggle(object sender, EventArgs e)
		{
			if (ConfigChanged != null)
				ConfigChanged(sender, e);
		}

		#endregion Methods 
	}
}
