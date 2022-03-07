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
using System.Windows.Forms;
using static Cyotek.Demo.NonClientPaint.NativeMethods;

namespace Cyotek.Demo.NonClientPaint.ArticleHelpers
{
  internal class Screenshot2 : CustomEditControl
  {
    #region Public Constructors

    public Screenshot2()
    {
      this.UseVisualStyles = false;
      base.Text = "This example uses WM_NCPAINT to perform custom painting of the non-client borders.";
    }

    #endregion Public Constructors

    #region Protected Methods

    protected override void WmNcPaint(ref Message m)
    {
      int w;
      int h;
      Rectangle clip;
      IntPtr hdc;

      GetClientRect(this.Handle, out RECT clientRect);
      GetWindowRect(this.Handle, out RECT windowRect);

      w = windowRect.right - windowRect.left;
      h = windowRect.bottom - windowRect.top;

      clip = new Rectangle((w - clientRect.right) / 2, (h - clientRect.bottom) / 2, clientRect.right, clientRect.bottom);

      hdc = GetWindowDC(this.Handle);

      using (Graphics g = Graphics.FromHdc(hdc))
      {
        g.SetClip(clip, CombineMode.Exclude);

        g.FillRectangle(Brushes.SeaGreen, 0, 0, w, h);
      }

      ReleaseDC(this.Handle, hdc);
    }

    #endregion Protected Methods
  }
}