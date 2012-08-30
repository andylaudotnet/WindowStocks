// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FrmChart.cs" company="NSnaiL">
//   Copyright (C) 2009 NSnaiL
// </copyright>
// <summary>
//   Defines the FrmChart type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WindowStocks
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Threading;
    using System.Windows.Forms;

    internal sealed partial class FrmChart : FrmBase
    {
		#region Fields (2) 

        private static string _ChartUrl;
        internal readonly AutoResetEvent MutexObject = new AutoResetEvent(true);

		#endregion Fields 

		#region Constructors (1) 

        internal FrmChart()
        {
            InitializeComponent();

            // 使窗口有鼠标穿透功能
            Win32.GetWindowLong(Handle, Win32.GWL_EXSTYLE);
            Win32.SetWindowLong(Handle, Win32.GWL_EXSTYLE, Win32.WS_EX_TRANSPARENT | Win32.WS_EX_LAYERED);

            SetBits();
            Thread procChart = new Thread(ProcChart);
            procChart.IsBackground = true;
            procChart.Start();
            Program.ConfigChanged += Program_ConfigChanged;
            Program_ConfigChanged(null, null);

        }

		#endregion Constructors 

		#region Properties (2) 

        internal static string ChartUrl
        {
            get { return _ChartUrl; }
            set { _ChartUrl = value; }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cParms = base.CreateParams;
                cParms.ExStyle |= 0x00080000; // WS_EX_LAYERED
                return cParms;
            }
        }

		#endregion Properties 

		#region Delegates and Events (1) 

		// Delegates (1) 

        private delegate void InvokeDelegate();

		#endregion Delegates and Events 

		#region Methods (3) 

		// Private Methods (3) 

        private void ProcChart()
        {
            while (true)
            {
                if (ChartUrl != null && (Owner == null || Owner.WindowState != FormWindowState.Minimized))
                {
                    try
                    {
                        byte[] chartBytes = new WebClient().DownloadData(ChartUrl);
                        using (MemoryStream s = new MemoryStream(chartBytes))
                        {
                            using (Image lineChart = Image.FromStream(s))
                            {
                                using (Bitmap bitmap = new Bitmap(Properties.Resources.frmchatbg, Width, Height))
                                {
                                    using (Graphics g = Graphics.FromImage(bitmap))
                                    {
                                        g.DrawImage(lineChart, 15, 15);
                                        BackgroundImage = bitmap;
                                        SetBits();

                                    }
                                }
                            }
                        }
                    }
                    catch
                    {
                        using (Bitmap bitmap = new Bitmap(Properties.Resources.frmchatbg, Width, Height))
                        {
                            using (Graphics g = Graphics.FromImage(bitmap))
                            {
                                g.DrawImage(Properties.Resources.chart_bad, 15, 15, Properties.Resources.chart_bad.Width, Properties.Resources.chart_bad.Height);
                                BackgroundImage = bitmap;
                                SetBits();
                            }
                        }
                    }
                }


                MutexObject.WaitOne(20000, true);
            }
        }

        private new void Program_ConfigChanged(object sender, EventArgs e)
        {
            base.Program_ConfigChanged(sender, e);
            MutexObject.Set();
        }

        private void SetBits()
        {
            if (BackgroundImage == null || !Image.IsCanonicalPixelFormat(BackgroundImage.PixelFormat) || !Image.IsAlphaPixelFormat(BackgroundImage.PixelFormat)) return;
            IntPtr oldBits = IntPtr.Zero;
            IntPtr screenDC = Win32.GetDC(IntPtr.Zero);
            IntPtr hBitmap = IntPtr.Zero;
            IntPtr memDc = Win32.CreateCompatibleDC(screenDC);

            try
            {
                Win32.Point topLoc = new Win32.Point(Left, Top);
                Win32.Size bitMapSize = new Win32.Size(Width, Height);
                Win32.BLENDFUNCTION blendFunc = new Win32.BLENDFUNCTION();
                Win32.Point srcLoc = new Win32.Point(0, 0);
                using (Bitmap bitmap = new Bitmap(BackgroundImage, Width, Height))
                {
                    hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));
                }

                oldBits = Win32.SelectObject(memDc, hBitmap);

                blendFunc.BlendOp = Win32.AC_SRC_OVER;
                blendFunc.SourceConstantAlpha = (byte)Program.Config.ChartTransparency;
                blendFunc.AlphaFormat = Win32.AC_SRC_ALPHA;
                blendFunc.BlendFlags = 0;
                Invoke(new InvokeDelegate(delegate
                {
                    Win32.UpdateLayeredWindow(Handle, screenDC, ref topLoc, ref bitMapSize, memDc, ref srcLoc, 0, ref blendFunc, Win32.ULW_ALPHA);
                }));

            }
            finally
            {
                if (hBitmap != IntPtr.Zero)
                {
                    Win32.SelectObject(memDc, oldBits);
                    Win32.DeleteObject(hBitmap);
                }

                Win32.ReleaseDC(IntPtr.Zero, screenDC);
                Win32.DeleteDC(memDc);
            }
        }

		#endregion Methods 
    }
}
