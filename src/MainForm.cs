// Painting the borders of a custom control using WM_NCPAINT
// https://www.cyotek.com/blog/painting-the-borders-of-a-custom-control-using-wm-ncpaint

// Copyright © 2022 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

using Cyotek.Demo.NonClientPaint;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cyotek.Demo.Windows.Forms
{
  internal partial class MainForm : BaseForm
  {
    #region Private Fields

    private CustomEditControl _demoControl;

    #endregion Private Fields

    #region Public Constructors

    public MainForm()
    {
      this.InitializeComponent();
    }

    #endregion Public Constructors

    #region Public Properties

    public CustomEditControl DemoControl
    {
      get => _demoControl;
      set
      {
        _demoControl = value;

        value.BackColor = SystemColors.Window;
        value.Dock = DockStyle.Fill;

        demoHost.Controls.Add(value);
      }
    }

    #endregion Public Properties

    #region Protected Methods

    protected override void OnShown(EventArgs e)
    {
      base.OnShown(e);

      if (_demoControl != null)
      {
        borderStyleComboBox.SelectedIndex = (int)_demoControl.BorderStyle;
      }
    }

    #endregion Protected Methods

    #region Private Methods

    private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      AboutDialog.ShowAboutDialog();
    }

    private void BorderStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      _demoControl.BorderStyle = (BorderStyle)borderStyleComboBox.SelectedIndex;
    }

    private void CyotekLinkToolStripStatusLabel_Click(object sender, EventArgs e)
    {
      AboutDialog.OpenCyotekHomePage();

      cyotekLinkToolStripStatusLabel.LinkVisited = true;
    }

    private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void InterceptCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      _demoControl.CustomBorders = interceptCheckBox.Checked;
    }

    private void VisualStylesCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      _demoControl.UseVisualStyles = visualStylesCheckBox.Checked;
    }

    #endregion Private Methods
  }
}