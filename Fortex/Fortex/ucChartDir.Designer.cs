namespace DiffPress {
  partial class ucChartDir {
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucChartDir));
      this.panel1 = new System.Windows.Forms.Panel();
      this.winChartViewer1 = new ChartDirector.WinChartViewer();
      this.pointerPB = new System.Windows.Forms.RadioButton();
      this.zoomInPB = new System.Windows.Forms.RadioButton();
      this.zoomOutPB = new System.Windows.Forms.RadioButton();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.winChartViewer1)).BeginInit();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.pointerPB);
      this.panel1.Controls.Add(this.zoomInPB);
      this.panel1.Controls.Add(this.zoomOutPB);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(125, 414);
      this.panel1.TabIndex = 0;
      // 
      // winChartViewer1
      // 
      this.winChartViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.winChartViewer1.ChartSizeMode = ChartDirector.WinChartSizeMode.StretchImage;
      this.winChartViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.winChartViewer1.Location = new System.Drawing.Point(125, 0);
      this.winChartViewer1.Name = "winChartViewer1";
      this.winChartViewer1.ScrollDirection = ChartDirector.WinChartDirection.HorizontalVertical;
      this.winChartViewer1.Size = new System.Drawing.Size(740, 414);
      this.winChartViewer1.TabIndex = 47;
      this.winChartViewer1.TabStop = false;
      this.winChartViewer1.ZoomDirection = ChartDirector.WinChartDirection.HorizontalVertical;
      this.winChartViewer1.ViewPortChanged += new ChartDirector.WinViewPortEventHandler(this.winChartViewer1_ViewPortChanged);
      // 
      // pointerPB
      // 
      this.pointerPB.Appearance = System.Windows.Forms.Appearance.Button;
      this.pointerPB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.pointerPB.Image = ((System.Drawing.Image)(resources.GetObject("pointerPB.Image")));
      this.pointerPB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.pointerPB.Location = new System.Drawing.Point(1, 128);
      this.pointerPB.Name = "pointerPB";
      this.pointerPB.Size = new System.Drawing.Size(120, 25);
      this.pointerPB.TabIndex = 46;
      this.pointerPB.Text = "      Pointer";
      this.pointerPB.CheckedChanged += new System.EventHandler(this.pointerPB_CheckedChanged);
      // 
      // zoomInPB
      // 
      this.zoomInPB.Appearance = System.Windows.Forms.Appearance.Button;
      this.zoomInPB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.zoomInPB.Image = ((System.Drawing.Image)(resources.GetObject("zoomInPB.Image")));
      this.zoomInPB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.zoomInPB.Location = new System.Drawing.Point(1, 153);
      this.zoomInPB.Name = "zoomInPB";
      this.zoomInPB.Size = new System.Drawing.Size(120, 25);
      this.zoomInPB.TabIndex = 47;
      this.zoomInPB.Text = "      Zoom In";
      this.zoomInPB.CheckedChanged += new System.EventHandler(this.zoomInPB_CheckedChanged);
      // 
      // zoomOutPB
      // 
      this.zoomOutPB.Appearance = System.Windows.Forms.Appearance.Button;
      this.zoomOutPB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.zoomOutPB.Image = ((System.Drawing.Image)(resources.GetObject("zoomOutPB.Image")));
      this.zoomOutPB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.zoomOutPB.Location = new System.Drawing.Point(1, 177);
      this.zoomOutPB.Name = "zoomOutPB";
      this.zoomOutPB.Size = new System.Drawing.Size(120, 24);
      this.zoomOutPB.TabIndex = 48;
      this.zoomOutPB.Text = "      Zoom Out";
      this.zoomOutPB.CheckedChanged += new System.EventHandler(this.zoomOutPB_CheckedChanged);
      // 
      // ucChartDir
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.winChartViewer1);
      this.Controls.Add(this.panel1);
      this.Name = "ucChartDir";
      this.Size = new System.Drawing.Size(865, 414);
      this.Load += new System.EventHandler(this.ucChartDir_Load);
      this.panel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.winChartViewer1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private ChartDirector.WinChartViewer winChartViewer1;
    private System.Windows.Forms.RadioButton pointerPB;
    private System.Windows.Forms.RadioButton zoomInPB;
    private System.Windows.Forms.RadioButton zoomOutPB;
  }
}
