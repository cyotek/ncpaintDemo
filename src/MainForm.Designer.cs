namespace Cyotek.Demo.Windows.Forms
{
  partial class MainForm
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.Windows.Forms.Label borderStyleLabel;
      System.Windows.Forms.Panel controlPanel;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.demoHost = new System.Windows.Forms.Panel();
      this.statusStrip = new System.Windows.Forms.StatusStrip();
      this.statusToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.widthToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.heightToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.cyotekLinkToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.menuStrip = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.borderStyleComboBox = new System.Windows.Forms.ComboBox();
      this.interceptCheckBox = new System.Windows.Forms.CheckBox();
      this.visualStylesCheckBox = new System.Windows.Forms.CheckBox();
      borderStyleLabel = new System.Windows.Forms.Label();
      controlPanel = new System.Windows.Forms.Panel();
      this.statusStrip.SuspendLayout();
      this.menuStrip.SuspendLayout();
      controlPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // borderStyleLabel
      // 
      borderStyleLabel.AutoSize = true;
      borderStyleLabel.Location = new System.Drawing.Point(-3, 0);
      borderStyleLabel.Name = "borderStyleLabel";
      borderStyleLabel.Size = new System.Drawing.Size(67, 13);
      borderStyleLabel.TabIndex = 0;
      borderStyleLabel.Text = "&Border Style:";
      // 
      // demoHost
      // 
      this.demoHost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.demoHost.Location = new System.Drawing.Point(21, 37);
      this.demoHost.Margin = new System.Windows.Forms.Padding(12);
      this.demoHost.Name = "demoHost";
      this.demoHost.Padding = new System.Windows.Forms.Padding(12);
      this.demoHost.Size = new System.Drawing.Size(376, 170);
      this.demoHost.TabIndex = 1;
      // 
      // statusStrip
      // 
      this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusToolStripStatusLabel,
            this.widthToolStripStatusLabel,
            this.heightToolStripStatusLabel,
            this.cyotekLinkToolStripStatusLabel});
      this.statusStrip.Location = new System.Drawing.Point(0, 219);
      this.statusStrip.Name = "statusStrip";
      this.statusStrip.Size = new System.Drawing.Size(624, 22);
      this.statusStrip.TabIndex = 3;
      // 
      // statusToolStripStatusLabel
      // 
      this.statusToolStripStatusLabel.Name = "statusToolStripStatusLabel";
      this.statusToolStripStatusLabel.Size = new System.Drawing.Size(506, 17);
      this.statusToolStripStatusLabel.Spring = true;
      this.statusToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // widthToolStripStatusLabel
      // 
      this.widthToolStripStatusLabel.Name = "widthToolStripStatusLabel";
      this.widthToolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
      // 
      // heightToolStripStatusLabel
      // 
      this.heightToolStripStatusLabel.Name = "heightToolStripStatusLabel";
      this.heightToolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
      // 
      // cyotekLinkToolStripStatusLabel
      // 
      this.cyotekLinkToolStripStatusLabel.IsLink = true;
      this.cyotekLinkToolStripStatusLabel.Name = "cyotekLinkToolStripStatusLabel";
      this.cyotekLinkToolStripStatusLabel.Size = new System.Drawing.Size(103, 17);
      this.cyotekLinkToolStripStatusLabel.Text = "www.cyotek.com";
      this.cyotekLinkToolStripStatusLabel.Click += new System.EventHandler(this.CyotekLinkToolStripStatusLabel_Click);
      // 
      // menuStrip
      // 
      this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
      this.menuStrip.Location = new System.Drawing.Point(0, 0);
      this.menuStrip.Name = "menuStrip";
      this.menuStrip.Size = new System.Drawing.Size(624, 25);
      this.menuStrip.TabIndex = 0;
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
      this.fileToolStripMenuItem.Text = "&File";
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
      this.exitToolStripMenuItem.Text = "E&xit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
      // 
      // helpToolStripMenuItem
      // 
      this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
      this.helpToolStripMenuItem.Text = "&Help";
      // 
      // aboutToolStripMenuItem
      // 
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
      this.aboutToolStripMenuItem.Text = "&About";
      this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
      // 
      // borderStyleComboBox
      // 
      this.borderStyleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.borderStyleComboBox.FormattingEnabled = true;
      this.borderStyleComboBox.Items.AddRange(new object[] {
            "None",
            "Fixed Single",
            "Fixed 3D"});
      this.borderStyleComboBox.Location = new System.Drawing.Point(0, 16);
      this.borderStyleComboBox.Name = "borderStyleComboBox";
      this.borderStyleComboBox.Size = new System.Drawing.Size(200, 21);
      this.borderStyleComboBox.TabIndex = 1;
      this.borderStyleComboBox.SelectedIndexChanged += new System.EventHandler(this.BorderStyleComboBox_SelectedIndexChanged);
      // 
      // interceptCheckBox
      // 
      this.interceptCheckBox.AutoSize = true;
      this.interceptCheckBox.Checked = true;
      this.interceptCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
      this.interceptCheckBox.Location = new System.Drawing.Point(0, 43);
      this.interceptCheckBox.Name = "interceptCheckBox";
      this.interceptCheckBox.Size = new System.Drawing.Size(144, 17);
      this.interceptCheckBox.TabIndex = 2;
      this.interceptCheckBox.Text = "&Intercept WM_NCPAINT";
      this.interceptCheckBox.UseVisualStyleBackColor = true;
      this.interceptCheckBox.CheckedChanged += new System.EventHandler(this.InterceptCheckBox_CheckedChanged);
      // 
      // visualStylesCheckBox
      // 
      this.visualStylesCheckBox.AutoSize = true;
      this.visualStylesCheckBox.Checked = true;
      this.visualStylesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
      this.visualStylesCheckBox.Location = new System.Drawing.Point(0, 66);
      this.visualStylesCheckBox.Name = "visualStylesCheckBox";
      this.visualStylesCheckBox.Size = new System.Drawing.Size(107, 17);
      this.visualStylesCheckBox.TabIndex = 3;
      this.visualStylesCheckBox.Text = "Use &Visual Styles";
      this.visualStylesCheckBox.UseVisualStyleBackColor = true;
      this.visualStylesCheckBox.CheckedChanged += new System.EventHandler(this.VisualStylesCheckBox_CheckedChanged);
      // 
      // controlPanel
      // 
      controlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      controlPanel.Controls.Add(borderStyleLabel);
      controlPanel.Controls.Add(this.visualStylesCheckBox);
      controlPanel.Controls.Add(this.borderStyleComboBox);
      controlPanel.Controls.Add(this.interceptCheckBox);
      controlPanel.Location = new System.Drawing.Point(412, 37);
      controlPanel.Name = "controlPanel";
      controlPanel.Size = new System.Drawing.Size(200, 100);
      controlPanel.TabIndex = 2;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(624, 241);
      this.Controls.Add(controlPanel);
      this.Controls.Add(this.statusStrip);
      this.Controls.Add(this.menuStrip);
      this.Controls.Add(this.demoHost);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = true;
      this.MinimizeBox = true;
      this.MinimumSize = new System.Drawing.Size(640, 280);
      this.Name = "MainForm";
      this.ShowIcon = true;
      this.ShowInTaskbar = true;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Cyotek Non-client Paint Demo";
      this.statusStrip.ResumeLayout(false);
      this.statusStrip.PerformLayout();
      this.menuStrip.ResumeLayout(false);
      this.menuStrip.PerformLayout();
      controlPanel.ResumeLayout(false);
      controlPanel.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.ToolStripStatusLabel statusToolStripStatusLabel;
    private System.Windows.Forms.ToolStripStatusLabel widthToolStripStatusLabel;
    private System.Windows.Forms.ToolStripStatusLabel heightToolStripStatusLabel;
    private System.Windows.Forms.ToolStripStatusLabel cyotekLinkToolStripStatusLabel;
    private System.Windows.Forms.MenuStrip menuStrip;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    private System.Windows.Forms.ComboBox borderStyleComboBox;
    private System.Windows.Forms.CheckBox interceptCheckBox;
    private System.Windows.Forms.Panel demoHost;
    private System.Windows.Forms.CheckBox visualStylesCheckBox;
  }
}