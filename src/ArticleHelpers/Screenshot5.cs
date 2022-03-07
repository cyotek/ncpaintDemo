// Painting the borders of a custom control using WM_NCPAINT
// https://www.cyotek.com/blog/painting-the-borders-of-a-custom-control-using-wm-ncpaint

// Copyright © 2022 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static Cyotek.Demo.NonClientPaint.NativeMethods;

namespace Cyotek.Demo.NonClientPaint.ArticleHelpers
{
  internal class Screenshot5 : CustomEditControl
  {
    #region Private Fields

    private Rectangle _clientRect;

    #endregion Private Fields

    #region Public Constructors

    public Screenshot5()
    {
      this.UseVisualStyles = false;
      base.Text = "This example uses GetThemeBackgroundContentRect to determine how big the border area needs to be.";
    }

    #endregion Public Constructors

    #region Protected Methods

    protected override void WmNcCalcSize(ref Message m)
    {
      if (this.BorderStyle != BorderStyle.None)
      {
        IntPtr hdc;
        IntPtr hTheme;
        int partId;
        int stateId;

        hdc = GetWindowDC(this.Handle);
        hTheme = OpenThemeData(this.Handle, "EDIT");
        partId = EP_EDITTEXT;

        stateId = this.Enabled
          ? ETS_NORMAL
          : ETS_DISABLED;

        if (m.WParam == IntPtr.Zero)
        {
          RECT clientRect;

          clientRect = (RECT)Marshal.PtrToStructure(m.LParam, typeof(RECT));

          GetThemeBackgroundContentRect(hTheme, hdc, partId, stateId, ref clientRect, out RECT adjustedClientRect);

          Marshal.StructureToPtr(adjustedClientRect, m.LParam, false);

          _clientRect = new Rectangle(adjustedClientRect.left - clientRect.left, adjustedClientRect.top - clientRect.top, (adjustedClientRect.right - adjustedClientRect.left) - (adjustedClientRect.left - clientRect.left), (adjustedClientRect.bottom - adjustedClientRect.top) - (adjustedClientRect.top - clientRect.top));
        }
        else
        {
          NCCALCSIZE_PARAMS parameters;
          RECT clientRect;

          parameters = (NCCALCSIZE_PARAMS)Marshal.PtrToStructure(m.LParam, typeof(NCCALCSIZE_PARAMS));

          clientRect = parameters.rgrc[0];

          GetThemeBackgroundContentRect(hTheme, hdc, partId, stateId, ref clientRect, out RECT adjustedClientRect);

          parameters.rgrc[0] = adjustedClientRect;

          Marshal.StructureToPtr(parameters, m.LParam, false);

          _clientRect = new Rectangle(adjustedClientRect.left - clientRect.left, adjustedClientRect.top - clientRect.top, (adjustedClientRect.right - adjustedClientRect.left) - (adjustedClientRect.left - clientRect.left), (adjustedClientRect.bottom - adjustedClientRect.top) - (adjustedClientRect.top - clientRect.top));
        }

        CloseThemeData(hTheme);

        ReleaseDC(this.Handle, hdc);
      }
    }

    protected override void WmNcPaint(ref Message m)
    {
      int w;
      int h;
      IntPtr hdc;

      GetWindowRect(this.Handle, out RECT windowRect);

      w = windowRect.right - windowRect.left;
      h = windowRect.bottom - windowRect.top;

      hdc = GetWindowDC(this.Handle);

      using (Graphics g = Graphics.FromHdc(hdc))
      {
        g.SetClip(_clientRect, CombineMode.Exclude);

        g.FillRectangle(Brushes.SeaGreen, 0, 0, w, h);
      }

      ReleaseDC(this.Handle, hdc);
    }

    #endregion Protected Methods
  }
}