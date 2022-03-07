// Painting the borders of a custom control using WM_NCPAINT
// https://www.cyotek.com/blog/painting-the-borders-of-a-custom-control-using-wm-ncpaint

// Copyright © 2022 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

using Cyotek.Demo.Windows.Forms;
using System.Windows.Forms;

namespace Cyotek.Demo.NonClientPaint
{
  internal static class Program
  {
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MainForm<CustomEditControl>()); // screenshot1
      //Application.Run(new MainForm<ArticleHelpers.Screenshot2>());
      //Application.Run(new MainForm<ArticleHelpers.Screenshot3>());
      //Application.Run(new MainForm<ArticleHelpers.Screenshot4>());
      //Application.Run(new MainForm<ArticleHelpers.Screenshot5>());
    }
  }
}