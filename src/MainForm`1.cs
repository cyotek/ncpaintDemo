// Painting the borders of a custom control using WM_NCPAINT
// https://www.cyotek.com/blog/painting-the-borders-of-a-custom-control-using-wm-ncpaint

// Copyright © 2022 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

using Cyotek.Demo.NonClientPaint;
using System;

namespace Cyotek.Demo.Windows.Forms
{
  internal sealed class MainForm<T> : MainForm
    where T : CustomEditControl, new()
  {
    #region Protected Methods

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      this.DemoControl = new T();
    }

    #endregion Protected Methods
  }
}