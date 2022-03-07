// Painting the borders of a custom control using WM_NCPAINT
// https://www.cyotek.com/blog/painting-the-borders-of-a-custom-control-using-wm-ncpaint

// Copyright © 2022 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

using System;
using System.Runtime.InteropServices;

namespace Cyotek.Demo.NonClientPaint
{
  internal static class NativeMethods
  {
    #region Public Fields

    public const uint DCX_INTERSECTRGN = 0x00000080;

    public const int DCX_USESTYLE = 0x00010000;

    public const uint DCX_WINDOW = 0x00000001;

    public const int EP_EDITTEXT = 1;

    public const int ETS_DISABLED = 4;

    public const int ETS_FOCUSED = 5;

    public const int ETS_NORMAL = 1;

    public const int NULLREGION = 1;

    public const int RDW_FRAME = 0x400;

    public const int RDW_INVALIDATE = 0x1;

    public const int WM_NCCALCSIZE = 0x0083;

    public const int WM_NCPAINT = 0x0085;

    public const int WS_BORDER = 0x00800000;

    public const int WS_EX_CLIENTEDGE = 0x00000200;

    public const int WVR_HREDRAW = 0x0100;

    public const int WVR_REDRAW = WVR_HREDRAW | WVR_VREDRAW;

    public const int WVR_VREDRAW = 0x0200;

    #endregion Public Fields

    #region Public Methods

    [DllImport("uxtheme.dll")]
    public static extern int CloseThemeData(IntPtr hTheme);

    [DllImport("uxtheme.dll")]
    public static extern int DrawThemeBackground(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, ref RECT pRect, IntPtr pClipRect);

    [DllImport("uxtheme.dll")]
    public static extern int DrawThemeParentBackground(IntPtr hWnd, IntPtr hdc, ref RECT pRect);

    [DllImport("gdi32.dll")]
    public static extern int ExcludeClipRect(IntPtr hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);

    [DllImport("user32.dll")]
    public static extern IntPtr GetDCEx(IntPtr hWnd, IntPtr hrgnClip, uint flags);

    [DllImport("uxtheme.dll")]
    public static extern int GetThemeBackgroundContentRect(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, ref RECT pBoundingRect, out RECT pContentRect);

    [DllImport("user32.dll")]
    public static extern IntPtr GetWindowDC(IntPtr hWnd);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

    [DllImport("uxtheme.dll")]
    public static extern int IsThemeBackgroundPartiallyTransparent(IntPtr hTheme, int iPartId, int iStateId);

    [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
    public static extern IntPtr OpenThemeData(IntPtr hWnd, string classList);

    [DllImport("user32.dll")]
    public static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, int flags);

    [DllImport("user32.dll")]
    public static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDc);

    #endregion Public Methods

    #region Public Structs

    [StructLayout(LayoutKind.Sequential)]
    public struct NCCALCSIZE_PARAMS
    {
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
      public RECT[] rgrc;

      public WINDOWPOS lppos;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
      public int left;

      public int top;

      public int right;

      public int bottom;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WINDOWPOS
    {
      public IntPtr hwnd;

      public IntPtr hwndInsertAfter;

      public int x;

      public int y;

      public int cx;

      public int cy;

      public uint flags;
    }

    #endregion Public Structs
  }
}