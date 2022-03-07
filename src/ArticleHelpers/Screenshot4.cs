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
  internal class Screenshot4 : CustomEditControl
  {
    #region Private Fields

    private Rectangle _clientRect;

    #endregion Private Fields

    #region Public Constructors

    public Screenshot4()
    {
      this.UseVisualStyles = false;
      base.Text = "This example uses WM_NCCALCSIZE to set the non-client area with a varying size for each edge.";
    }

    #endregion Public Constructors

    #region Protected Properties

    protected override Padding DefaultPadding => new Padding(2, 4, 6, 8);

    #endregion Protected Properties

    #region Protected Methods

    protected override void WmNcCalcSize(ref Message m)
    {
      Padding padding;

      padding = this.Padding;

      if (m.WParam == IntPtr.Zero)
      {
        RECT clientRect;

        clientRect = (RECT)Marshal.PtrToStructure(m.LParam, typeof(RECT));
        clientRect.left += padding.Left;
        clientRect.top += padding.Top;
        clientRect.right -= padding.Right;
        clientRect.bottom -= padding.Bottom;

        Marshal.StructureToPtr(clientRect, m.LParam, false);

        _clientRect = new Rectangle(padding.Left, padding.Top, clientRect.right - clientRect.left, clientRect.bottom - clientRect.top);
      }
      else
      {
        NCCALCSIZE_PARAMS parameters;
        RECT clientRect;

        parameters = (NCCALCSIZE_PARAMS)Marshal.PtrToStructure(m.LParam, typeof(NCCALCSIZE_PARAMS));

        clientRect = parameters.rgrc[0];
        clientRect.left += padding.Left;
        clientRect.top += padding.Top;
        clientRect.right -= padding.Right;
        clientRect.bottom -= padding.Bottom;

        parameters.rgrc[0] = clientRect;

        Marshal.StructureToPtr(parameters, m.LParam, false);

        _clientRect = new Rectangle(padding.Left, padding.Top, clientRect.right - clientRect.left, clientRect.bottom - clientRect.top);
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