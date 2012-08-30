// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Win32.cs" company="NSnaiL">
//   Copyright (C) 2009 NSnaiL
// </copyright>
// <summary>
//   Defines the Win32 type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WindowStocks
{
	using System;
	using System.Runtime.InteropServices;
	using System.Text;
	using System.Windows.Forms;

	public static class Win32
	{
		#region Fields (11)

		public const byte AC_SRC_ALPHA = 1;
		public const byte AC_SRC_OVER = 0;
		public const int CS_DROPSHADOW = 0x20000;
		public const int GCL_STYLE = -26;
		public const int GWL_EXSTYLE = -20;
		public const int GWL_STYLE = -16;
		public const int LWA_ALPHA = 0x2;
		public const int SB_HORZ = 0x00;
		public const int ULW_ALPHA = 2;
		public const uint WS_EX_LAYERED = 0x80000;
		public const int WS_EX_TRANSPARENT = 0x20;
		public const int SW_SHOW = 0x05;
		public const int SW_SHOWNORMAL = 0x01;

		#endregion Fields

		#region Methods (25)

		// Public Methods (25) 

		[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

		[DllImport("Kernel32.dll", SetLastError = true)]
		public static extern IntPtr CreateMutex(IntPtr lpMutexAttributes, int bInitialOwner, string lpName);

		[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern int DeleteDC(IntPtr hDC);

		[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern int DeleteObject(IntPtr hObj);

		[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr ExtCreateRegion(IntPtr lpXform, uint nCount, IntPtr rgnData);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern int GetClassLong(IntPtr hwnd, int nIndex);

		[DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr GetDC(IntPtr hWnd);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr GetForegroundWindow();

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool GetScrollRange(IntPtr hWnd, int nBar, ref int lpMinPos, ref int lpMaxPos);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern uint GetWindowLong(IntPtr hWnd, int nIndex);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

		[DllImport("Kernel32.dll", SetLastError = true)]
		public static extern IntPtr OpenMutex(uint dwDesiredAccess, int bInheritHandle, string lpName);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint control, Keys vk);

		[DllImport("user32.dll", ExactSpelling = true)]
		public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

		[DllImport("gdi32.dll", ExactSpelling = true)]
		public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObj);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool SetForegroundWindow(IntPtr hWnd);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern int SetLayeredWindowAttributes(IntPtr hWnd, int crKey, int bAlpha, int dwFlags);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedraw);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool SetScrollRange(IntPtr hWnd, int nBar, int lpMinPos, int lpMaxPos);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern uint SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool SetWindowText(IntPtr hWnd, StringBuilder lpString);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

		[DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern int UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pptSrc, int crKey, ref BLENDFUNCTION pblend, int dwFlags);

		[DllImport("shell32.dll", SetLastError = true)]
		public static extern IntPtr ShellExecute(IntPtr hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, int nShowCmd);

		#endregion Methods


		[StructLayout(LayoutKind.Sequential)]
		public struct Size
		{
			public int cx;
			public int cy;

			public Size(int x, int y)
			{
				cx = x;
				cy = y;
			}
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct BLENDFUNCTION
		{
			public byte BlendOp;
			public byte BlendFlags;
			public byte SourceConstantAlpha;
			public byte AlphaFormat;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Point
		{
			public int x;
			public int y;

			public Point(int x, int y)
			{
				this.x = x;
				this.y = y;
			}
		}
	}
}
