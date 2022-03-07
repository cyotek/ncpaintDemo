// Painting the borders of a custom control using WM_NCPAINT
// https://www.cyotek.com/blog/painting-the-borders-of-a-custom-control-using-wm-ncpaint

// Copyright © 2022 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static Cyotek.Demo.NonClientPaint.NativeMethods;

namespace Cyotek.Demo.NonClientPaint
{
  internal class CustomEditControl : Control
  {
    #region Private Fields

    private BorderStyle _borderStyle;

    private Rectangle _clientRect;

    private bool _customBorders;

    private bool _useVisualStyles;

    #endregion Private Fields

    #region Public Constructors

    public CustomEditControl()
    {
      base.DoubleBuffered = true;
      this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint, true);

      _borderStyle = BorderStyle.Fixed3D;
      _customBorders = true;
      _useVisualStyles = true;

      base.Text = "This control uses the WS_BORDER or WS_EX_CLIENTEDGE styles to apply a default border or \"frame\". It then intercepts the WM_NCPAINT message to draw these borders manually. If themes are enabled the WM_NCCALCSIZE message will be used to ensure the non-client area is sized according to the theme.";
    }

    #endregion Public Constructors

    #region Public Properties

    [Category("Appearance")]
    [DefaultValue(typeof(BorderStyle), "Fixed3D")]
    public BorderStyle BorderStyle
    {
      get => _borderStyle;
      set
      {
        if (_borderStyle != value)
        {
          _borderStyle = value;

          this.UpdateStyles();
        }
      }
    }

    [Category("Demo")]
    [DefaultValue(true)]
    public bool CustomBorders
    {
      get => _customBorders;
      set
      {
        _customBorders = value;

        this.UpdateStyles();
      }
    }

    [Category("Demo")]
    [DefaultValue(true)]
    public bool UseVisualStyles
    {
      get => _useVisualStyles;
      set
      {
        _useVisualStyles = value;

        this.InvalidateAll();
      }
    }

    #endregion Public Properties

    #region Protected Properties

    protected override CreateParams CreateParams
    {
      get
      {
        CreateParams createParams;

        createParams = base.CreateParams;
        createParams.ExStyle &= ~WS_EX_CLIENTEDGE;
        createParams.Style &= ~WS_BORDER;

        switch (_borderStyle)
        {
          case BorderStyle.Fixed3D:
            createParams.ExStyle |= WS_EX_CLIENTEDGE;
            break;

          case BorderStyle.FixedSingle:
            createParams.Style |= WS_BORDER;
            break;
        }

        return createParams;
      }
    }

    protected override Padding DefaultPadding => new Padding(12);

    #endregion Protected Properties

    #region Protected Methods

    protected override void OnEnter(EventArgs e)
    {
      base.OnEnter(e);

      this.InvalidateAll();
    }

    protected override void OnLeave(EventArgs e)
    {
      base.OnLeave(e);

      this.InvalidateAll();
    }

    protected override void OnPaddingChanged(EventArgs e)
    {
      base.OnPaddingChanged(e);

      this.Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      Size size;
      Padding padding;

      base.OnPaint(e);

      size = this.ClientSize;
      padding = this.Padding;

      TextRenderer.DrawText(e.Graphics, this.Text, this.Font, new Rectangle(padding.Left, padding.Top, size.Width - padding.Horizontal, size.Height - padding.Vertical), this.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter | TextFormatFlags.WordBreak | TextFormatFlags.ExpandTabs | TextFormatFlags.NoPrefix | TextFormatFlags.NoPadding);
    }

    protected override void OnTextChanged(EventArgs e)
    {
      base.OnTextChanged(e);

      this.Invalidate();
    }

    protected virtual void WmNcCalcSize(ref Message m)
    {
      System.Diagnostics.Debug.WriteLine(m.ToString());
      if (_borderStyle != 0 && this.RenderWithVisualStyles())
      {
        this.CalculateVisualStylesNonClientSize(ref m);
      }
      else
      {
        // if we aren't using visual styles, then there
        // isn't a need to manually calculate the
        // non-client region, so although we're doing
        // it for the purposes of this demo, we could
        // just call back and let windows handle it
        //base.WndProc(ref m);
        this.CalculateClassicNonClientSize(ref m);
      }
    }

    protected virtual void WmNcPaint(ref Message m)
    {
      System.Diagnostics.Debug.WriteLine(m.ToString());
      if (_borderStyle != BorderStyle.None)
      {
        IntPtr hdc;

        hdc = GetWindowDC(this.Handle);

        if (!(this.RenderWithVisualStyles() && this.PaintThemedBorder(hdc)))
        {
          this.PaintBorders(hdc);
        }

        ReleaseDC(this.Handle, hdc);
      }
    }

    protected override void WndProc(ref Message m)
    {
      if (_customBorders && (m.Msg == WM_NCPAINT || m.Msg == WM_NCCALCSIZE))
      {
        if (m.Msg == WM_NCPAINT)
        {
          this.WmNcPaint(ref m);
        }
        else
        {
          this.WmNcCalcSize(ref m);
        }
      }
      else
      {
        base.WndProc(ref m);
      }
    }

    #endregion Protected Methods

    #region Private Methods

    private void CalculateClassicNonClientSize(ref Message m)
    {
      int borderSize;

      borderSize = this.GetBorderSize();

      if (m.WParam == IntPtr.Zero)
      {
        RECT clientRect;

        clientRect = (RECT)Marshal.PtrToStructure(m.LParam, typeof(RECT));
        clientRect.left += borderSize;
        clientRect.top += borderSize;
        clientRect.right -= borderSize;
        clientRect.bottom -= borderSize;

        _clientRect = new Rectangle(borderSize, borderSize, clientRect.right - clientRect.left, clientRect.bottom - clientRect.top);

        Marshal.StructureToPtr(clientRect, m.LParam, false);
      }
      else
      {
        NCCALCSIZE_PARAMS parameters;
        RECT clientRect;

        parameters = (NCCALCSIZE_PARAMS)Marshal.PtrToStructure(m.LParam, typeof(NCCALCSIZE_PARAMS));

        clientRect = parameters.rgrc[0];
        clientRect.left += borderSize;
        clientRect.top += borderSize;
        clientRect.right -= borderSize;
        clientRect.bottom -= borderSize;

        _clientRect = new Rectangle(borderSize, borderSize, clientRect.right - clientRect.left, clientRect.bottom - clientRect.top);

        parameters.rgrc[0] = clientRect;

        Marshal.StructureToPtr(parameters, m.LParam, false);
      }
    }

    private void CalculateVisualStylesNonClientSize(ref Message m)
    {
      IntPtr hdc;
      IntPtr hTheme;
      int partId;
      int stateId;

      hdc = GetWindowDC(this.Handle);
      hTheme = OpenThemeData(this.Handle, "EDIT");
      partId = EP_EDITTEXT;
      stateId = this.GetVisualStyleState();

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

    private RECT GetAdjustedWindowRect()
    {
      GetWindowRect(this.Handle, out RECT windowRect);

      windowRect.right -= windowRect.left;
      windowRect.bottom -= windowRect.top;
      windowRect.left = 0;
      windowRect.top = 0;

      return windowRect;
    }

    private int GetBorderSize()
    {
      int borderSize;

      switch (_borderStyle)
      {
        case BorderStyle.None:
          borderSize = 0;
          break;

        case BorderStyle.FixedSingle:
          borderSize = 1;
          break;

        case BorderStyle.Fixed3D:
          borderSize = 2;
          break;

        default:
          borderSize = 0;
          break;
      }

      return borderSize;
    }

    private int GetVisualStyleState()
    {
      int state;

      if (this.Enabled)
      {
        state = this.Focused
                ? ETS_FOCUSED
                : ETS_NORMAL;
      }
      else
      {
        state = ETS_DISABLED;
      }

      return state;
    }

    private void InvalidateAll()
    {
      RedrawWindow(this.Handle, IntPtr.Zero, IntPtr.Zero, RDW_FRAME | RDW_INVALIDATE);
    }

    private void PaintBorders(IntPtr hdc)
    {
      RECT windowRect;

      windowRect = this.GetAdjustedWindowRect();

      using (Graphics g = Graphics.FromHdc(hdc))
      {
        Rectangle bounds;

        g.SetClip(_clientRect, CombineMode.Exclude);

        bounds = new Rectangle(0, 0, windowRect.right - 1, windowRect.bottom - 1);
        g.DrawRectangle(SystemPens.ControlDark, bounds);

        if (_borderStyle == BorderStyle.Fixed3D)
        {
          bounds.Inflate(-1, -1);
          using (Pen pen = new Pen(this.BackColor))
          {
            g.DrawRectangle(pen, bounds);
          }
        }
      }
    }

    private bool PaintThemedBorder(IntPtr hdc)
    {
      int partId;
      int stateId;
      RECT windowRect;
      IntPtr hTheme;
      int result;

      partId = EP_EDITTEXT;
      stateId = this.GetVisualStyleState();

      windowRect = this.GetAdjustedWindowRect();

      ExcludeClipRect(hdc, _clientRect.Left, _clientRect.Top, _clientRect.Right, _clientRect.Bottom);

      hTheme = OpenThemeData(this.Handle, "EDIT");

      if (IsThemeBackgroundPartiallyTransparent(hTheme, partId, stateId) != 0)
      {
        DrawThemeParentBackground(this.Handle, hdc, ref windowRect);
      }

      result = DrawThemeBackground(hTheme, hdc, partId, stateId, ref windowRect, IntPtr.Zero);

      CloseThemeData(hTheme);

      return result == 0;
    }

    private bool RenderWithVisualStyles()
    {
      return _useVisualStyles && Application.RenderWithVisualStyles;
    }

    #endregion Private Methods
  }
}