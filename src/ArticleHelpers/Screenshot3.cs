// Painting the borders of a custom control using WM_NCPAINT
// https://www.cyotek.com/blog/painting-the-borders-of-a-custom-control-using-wm-ncpaint

// Copyright © 2022 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

using System;
using System.Windows.Forms;
using static Cyotek.Demo.NonClientPaint.NativeMethods;

namespace Cyotek.Demo.NonClientPaint.ArticleHelpers
{
  internal class Screenshot3 : CustomEditControl
  {
    #region Public Constructors

    public Screenshot3()
    {
      this.UseVisualStyles = false;
      base.Text = "This example uses WM_NCPAINT to paint the non-client borders using the themes API.";
    }

    #endregion Public Constructors

    #region Protected Methods

    protected override void WmNcPaint(ref Message m)
    {
      int w;
      int h;
      IntPtr hdc;
      IntPtr hTheme;
      int partId;
      int stateId;

      GetClientRect(this.Handle, out RECT clientRect);
      GetWindowRect(this.Handle, out RECT windowRect);

      w = windowRect.right - windowRect.left;
      h = windowRect.bottom - windowRect.top;

      windowRect.right = w;
      windowRect.bottom = h;
      windowRect.left = 0;
      windowRect.top = 0;

      hdc = GetWindowDC(this.Handle);

      hTheme = OpenThemeData(this.Handle, "EDIT");
      partId = EP_EDITTEXT;
      stateId = this.Enabled
        ? ETS_NORMAL
        : ETS_DISABLED;

      ExcludeClipRect(hdc, (w - clientRect.right) / 2, (h - clientRect.bottom) / 2, clientRect.right, clientRect.bottom);

      if (IsThemeBackgroundPartiallyTransparent(hTheme, partId, stateId) != 0)
      {
        DrawThemeParentBackground(this.Handle, hdc, ref windowRect);
      }

      DrawThemeBackground(hTheme, hdc, partId, stateId, ref windowRect, IntPtr.Zero);

      CloseThemeData(hTheme);

      ReleaseDC(this.Handle, hdc);
    }

    #endregion Protected Methods
  }
}