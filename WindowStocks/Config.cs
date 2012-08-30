// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Config.cs" company="NSnaiL">
//   Copyright (C) 2009 NSnaiL
// </copyright>
// <summary>
//   Defines the Config type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WindowStocks
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Windows.Forms;
    using Microsoft.Win32;
    using System.Globalization;
    using System.ComponentModel;

    [Serializable]
    internal class Config : Entity
    {
		#region Fields (33) 

        private string _AutoStartParam;
        private int _ChartTransparency;
        private Font _GenericFont;
        private bool _GvMainAutoSize;
        private Color _GvMainBgColor;
        private int[] _GvMainColDisplays;
        private bool[] _GvMainColVisibles;
        private Color _GvMainForeColorDown;
        private Color _GvMainForeColorStill;
        private Color _GvMainForeColorUp;
        private Color _GvMainGridLinesColor;
        private Color _GvMainHighLightColor;
        private Color _GvMainInterlacedColor;
        private Keys _HotKeyCode;
        private Keys _HotKeyModifiers;
        private bool _IsAutoStart;
        private bool _IsLockBar;
        private bool _IsReplaceWindowTitle;
        private bool _IsShowChart;
        private bool _IsShowGvMainGridLines;
        private bool _IsShowGvMainHighLight;
        private bool _IsShowGvMainInterlaced;
        private bool _IsShowStatusBar;
        private bool _IsShowToolBar;
        private string _KLineStyle;
        private ToolStripRenderMode _RenderMode;
        private SortColumnStruct _SortColumn;
        private int _UpdateCycle;
        private Size _WindowSize;
        private int _WindowTitleCount;
        private string _WindowTitleFormat;
        private int _WindowTitleShowTime;
        private List<PluginStruct> _Plugins;

		#endregion Fields 

		#region Constructors (1) 

        private Config()
        {
            AutoStartParam = string.Empty;
            IsAutoStart = true;
            ChartTransparency = 200;
            GenericFont = new Font(File.Exists(Directory.GetParent(Environment.SystemDirectory).FullName + @"\fonts\msyh.ttf") ? "微软雅黑" : "Tahoma", 9f);
            HotKeyCode = Keys.G;
            HotKeyModifiers = Keys.Alt;
            IsReplaceWindowTitle = false;
            IsShowChart = true;
            GvMainAutoSize = true;
            GvMainBgColor = Color.White;
            GvMainForeColorDown = Color.Green;
            GvMainForeColorStill = Color.Black;
            GvMainForeColorUp = Color.Red;
            IsShowGvMainGridLines = false;
            RenderMode = ToolStripRenderMode.System;
            WindowSize = new Size(800, 600);
            WindowTitleCount = 1;
            WindowTitleFormat = "    [{name}({code})    现价:{pcurr}    涨跌:{ud}/{udper}%    收益:{pl}/{plper}%]";
            WindowTitleShowTime = 3;
            UpdateCycle = 5;
            KLineStyle = "黑色";
            IsLockBar = false;
            IsShowStatusBar = true;
            IsShowToolBar = true;
            SortColumn = new SortColumnStruct("GvmColHoldCount", ListSortDirection.Descending);
            ResetGvMainColDisplays();
            ResetGvMainColVisibles();
            GvMainGridLinesColor = SystemColors.Control;
            GvMainHighLightColor = Color.LightYellow;
            GvMainInterlacedColor = Color.WhiteSmoke;
            IsShowGvMainHighLight = true;
            IsShowGvMainInterlaced = true;
            Plugins = new List<PluginStruct>();
            Plugins.Add(new PluginStruct("同花顺Flash行情系统", Keys.F12, Keys.None, true, "http://www.10jqka.com.cn/flash/"));
            Plugins.Add(new PluginStruct("大智慧Flash行情系统", Keys.None, Keys.None, true, "http://flashhq.gw.com.cn/main.html"));
        }

		#endregion Constructors 

		#region Properties (32) 

        public string AutoStartParam
        {
            get { return _AutoStartParam; }
            set { _AutoStartParam = value; }
        }

        public int ChartTransparency
        {
            get { return _ChartTransparency; }
            set { _ChartTransparency = value; }
        }

        public Font GenericFont
        {
            get { return _GenericFont; }
            set { _GenericFont = value; }
        }

        public bool GvMainAutoSize
        {
            get { return _GvMainAutoSize; }
            set { _GvMainAutoSize = value; }
        }

        public List<PluginStruct> Plugins
        {
            get { return _Plugins; }
            set { _Plugins = value; }
        }

        public Color GvMainBgColor
        {
            get { return _GvMainBgColor; }
            set { _GvMainBgColor = value; }
        }

        public int[] GvMainColDisplays
        {
            get { return _GvMainColDisplays; }
            set { _GvMainColDisplays = value; }
        }

        public bool[] GvMainColVisibles
        {
            get { return _GvMainColVisibles; }
            set { _GvMainColVisibles = value; }
        }

        public Color GvMainForeColorDown
        {
            get { return _GvMainForeColorDown; }
            set { _GvMainForeColorDown = value; }
        }

        public Color GvMainForeColorStill
        {
            get { return _GvMainForeColorStill; }
            set { _GvMainForeColorStill = value; }
        }

        public Color GvMainForeColorUp
        {
            get { return _GvMainForeColorUp; }
            set { _GvMainForeColorUp = value; }
        }

        public Color GvMainGridLinesColor
        {
            get { return _GvMainGridLinesColor; }
            set { _GvMainGridLinesColor = value; }
        }

        public Color GvMainHighLightColor
        {
            get { return _GvMainHighLightColor; }
            set { _GvMainHighLightColor = value; }
        }

        public Color GvMainInterlacedColor
        {
            get { return _GvMainInterlacedColor; }
            set { _GvMainInterlacedColor = value; }
        }

        public Keys HotKeyCode
        {
            get { return _HotKeyCode; }
            set { _HotKeyCode = value; }
        }

        public Keys HotKeyModifiers
        {
            get { return _HotKeyModifiers; }
            set { _HotKeyModifiers = value; }
        }

        public bool IsAutoStart
        {
            get { return _IsAutoStart; }
            set { _IsAutoStart = value; }
        }

        public bool IsLockBar
        {
            get { return _IsLockBar; }
            set { _IsLockBar = value; }
        }

        public bool IsReplaceWindowTitle
        {
            get { return _IsReplaceWindowTitle; }
            set { _IsReplaceWindowTitle = value; }
        }

        public bool IsShowChart
        {
            get { return _IsShowChart; }
            set { _IsShowChart = value; }
        }

        public bool IsShowGvMainGridLines
        {
            get { return _IsShowGvMainGridLines; }
            set { _IsShowGvMainGridLines = value; }
        }

        public bool IsShowGvMainHighLight
        {
            get { return _IsShowGvMainHighLight; }
            set { _IsShowGvMainHighLight = value; }
        }

        public bool IsShowGvMainInterlaced
        {
            get { return _IsShowGvMainInterlaced; }
            set { _IsShowGvMainInterlaced = value; }
        }

        public bool IsShowStatusBar
        {
            get { return _IsShowStatusBar; }
            set { _IsShowStatusBar = value; }
        }

        public bool IsShowToolBar
        {
            get { return _IsShowToolBar; }
            set { _IsShowToolBar = value; }
        }

        public string KLineStyle
        {
            get { return _KLineStyle; }
            set { _KLineStyle = value; }
        }

        public ToolStripRenderMode RenderMode
        {
            get { return _RenderMode; }
            set { _RenderMode = value; }
        }

        public SortColumnStruct SortColumn
        {
            get { return _SortColumn; }
            set { _SortColumn = value; }
        }

        public int UpdateCycle
        {
            get { return _UpdateCycle; }
            set { _UpdateCycle = value; }
        }

        public Size WindowSize
        {
            get { return _WindowSize; }
            set { _WindowSize = value; }
        }

        public int WindowTitleCount
        {
            get { return _WindowTitleCount; }
            set { _WindowTitleCount = value; }
        }

        public string WindowTitleFormat
        {
            get { return _WindowTitleFormat; }
            set { _WindowTitleFormat = value; }
        }

        public int WindowTitleShowTime
        {
            get { return _WindowTitleShowTime; }
            set { _WindowTitleShowTime = value; }
        }

		#endregion Properties 

		#region Methods (8) 

		// Public Methods (3) 

        public void ResetGvMainColDisplays()
        {
            GvMainColDisplays = new int[] {
			0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43
			};
        }

        public void ResetGvMainColVisibles()
        {
            GvMainColVisibles = new bool[] {
				true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true
			};
        }

        public void Save(string filePath)
        {
            Save(GetType(), filePath);
            try
            {
                if (IsAutoStart)
                {
                    string startString = string.Format("\"{0}\" {1}", Program.PathApplication, AutoStartParam);
                    if (GetStartString() != startString)
                        SetStartString(startString);
                }
                else
                    DeleteStartString();
            }
            catch (UnauthorizedAccessException)
            {
            }
        }
		// Private Methods (3) 

        private static void DeleteStartString()
        {
            using (RegistryKey regKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\", true))
            {
                regKey.DeleteValue("WindowStocks", false);
            }
        }

        private static string GetStartString()
        {
            return Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Run", "WindowStocks", string.Empty) as string;
        }

        private static void SetStartString(string startStr)
        {
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Run", "WindowStocks", startStr);
        }
		// Internal Methods (2) 

        internal Config DeepClone()
        {
            BinaryFormatter bSer = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bSer.Serialize(ms, this);
                ms.Seek(0, SeekOrigin.Begin);
                return bSer.Deserialize(ms) as Config;
            }
        }

        internal static Config Load(string filePath)
        {
            Config config = Load(new Config(), filePath);
            try
            {
                if (config.IsAutoStart)
                {
                    string startString = string.Format("\"{0}\" {1}", Program.PathApplication, config.AutoStartParam);
                    if (GetStartString() != startString)
                        SetStartString(startString);
                }
                else
                    DeleteStartString();
            }
            catch (UnauthorizedAccessException)
            {
            }

            return config;
        }

		#endregion Methods 


        [Serializable]
        public struct SortColumnStruct
        {
		#region Data Members (2) 

            public string ColumnName;
            public ListSortDirection Order;

		#endregion Data Members 

		#region Methods (1) 

            public SortColumnStruct(string columnName, ListSortDirection order)
            {
                ColumnName = columnName;
                Order = order;
            }

		#endregion Methods 
        }

        [Serializable]
        public struct PluginStruct
        {
            public string Name;
            public Keys ShortKeyCode;
            public Keys ShortKeyModifiers;
            public bool IsUrl;
            public string CommandLine;

            public PluginStruct(string name,Keys shortKeyCode,Keys shortKeyModifiers,bool isUrl, string commandLine)
            {
                Name = name;
                ShortKeyCode = shortKeyCode;
                ShortKeyModifiers = shortKeyModifiers;
                IsUrl = isUrl;
                CommandLine = commandLine;
            }

            public bool Equals(PluginStruct? obj)
            {
                if (obj == null || !obj.HasValue) return false;
                return (obj.Value.CommandLine == CommandLine
                    && obj.Value.IsUrl == IsUrl
                    && obj.Value.Name == Name
                    && obj.Value.ShortKeyCode == ShortKeyCode
                    && obj.Value.ShortKeyModifiers == ShortKeyModifiers);
            }
        }
    }
}
