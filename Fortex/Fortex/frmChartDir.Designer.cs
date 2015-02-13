namespace DiffPress {
  partial class frmChartDir {
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChartDir));
      this.startDate = new System.Windows.Forms.DateTimePicker();
      this.startDateLabel = new System.Windows.Forms.Label();
      this.durationLabel = new System.Windows.Forms.Label();
      this.zoomModeLabel = new System.Windows.Forms.Label();
      this.duration = new System.Windows.Forms.ComboBox();
      this.winChartViewer1 = new ChartDirector.WinChartViewer();
      this.xZoomPB = new System.Windows.Forms.RadioButton();
      this.xyZoomPB = new System.Windows.Forms.RadioButton();
      this.pointerPB = new System.Windows.Forms.RadioButton();
      this.zoomInPB = new System.Windows.Forms.RadioButton();
      this.zoomOutPB = new System.Windows.Forms.RadioButton();
      this.ucChartDir1 = new DiffPress.ucChartDir();
      ((System.ComponentModel.ISupportInitialize)(this.winChartViewer1)).BeginInit();
      this.SuspendLayout();
      // 
      // startDate
      // 
      this.startDate.CustomFormat = "";
      this.startDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.startDate.Location = new System.Drawing.Point(18, 229);
      this.startDate.Name = "startDate";
      this.startDate.Size = new System.Drawing.Size(112, 20);
      this.startDate.TabIndex = 40;
      this.startDate.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
      this.startDate.ValueChanged += new System.EventHandler(this.startDate_ValueChanged);
      // 
      // startDateLabel
      // 
      this.startDateLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.startDateLabel.Location = new System.Drawing.Point(18, 213);
      this.startDateLabel.Name = "startDateLabel";
      this.startDateLabel.Size = new System.Drawing.Size(72, 16);
      this.startDateLabel.TabIndex = 35;
      this.startDateLabel.Text = "Start Date";
      // 
      // durationLabel
      // 
      this.durationLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.durationLabel.Location = new System.Drawing.Point(18, 265);
      this.durationLabel.Name = "durationLabel";
      this.durationLabel.Size = new System.Drawing.Size(96, 16);
      this.durationLabel.TabIndex = 42;
      this.durationLabel.Text = "Duration (Days)";
      // 
      // zoomModeLabel
      // 
      this.zoomModeLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.zoomModeLabel.Location = new System.Drawing.Point(18, 133);
      this.zoomModeLabel.Name = "zoomModeLabel";
      this.zoomModeLabel.Size = new System.Drawing.Size(92, 16);
      this.zoomModeLabel.TabIndex = 43;
      this.zoomModeLabel.Text = "Zoom Mode";
      // 
      // duration
      // 
      this.duration.ForeColor = System.Drawing.SystemColors.WindowText;
      this.duration.ItemHeight = 13;
      this.duration.Items.AddRange(new object[] {
            "10",
            "20",
            "30",
            "60",
            "90",
            "180",
            "360",
            "720",
            "1080",
            "1440"});
      this.duration.Location = new System.Drawing.Point(18, 281);
      this.duration.MaxDropDownItems = 12;
      this.duration.Name = "duration";
      this.duration.Size = new System.Drawing.Size(112, 21);
      this.duration.TabIndex = 41;
      this.duration.Text = "60";
      // 
      // winChartViewer1
      // 
      this.winChartViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.winChartViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.winChartViewer1.ChartSizeMode = ChartDirector.WinChartSizeMode.StretchImage;
      this.winChartViewer1.Location = new System.Drawing.Point(166, 22);
      this.winChartViewer1.Name = "winChartViewer1";
      this.winChartViewer1.ScrollDirection = ChartDirector.WinChartDirection.HorizontalVertical;
      this.winChartViewer1.Size = new System.Drawing.Size(174, 75);
      this.winChartViewer1.TabIndex = 46;
      this.winChartViewer1.TabStop = false;
      this.winChartViewer1.ZoomDirection = ChartDirector.WinChartDirection.HorizontalVertical;
      this.winChartViewer1.ViewPortChanged += new ChartDirector.WinViewPortEventHandler(this.winChartViewer1_ViewPortChanged);
      // 
      // xZoomPB
      // 
      this.xZoomPB.Appearance = System.Windows.Forms.Appearance.Button;
      this.xZoomPB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.xZoomPB.Image = ((System.Drawing.Image)(resources.GetObject("xZoomPB.Image")));
      this.xZoomPB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.xZoomPB.Location = new System.Drawing.Point(15, 152);
      this.xZoomPB.Name = "xZoomPB";
      this.xZoomPB.Size = new System.Drawing.Size(120, 25);
      this.xZoomPB.TabIndex = 44;
      this.xZoomPB.Text = "      X Zoom / Y Auto";
      this.xZoomPB.CheckedChanged += new System.EventHandler(this.xZoomPB_CheckedChanged);
      // 
      // xyZoomPB
      // 
      this.xyZoomPB.Appearance = System.Windows.Forms.Appearance.Button;
      this.xyZoomPB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.xyZoomPB.Image = ((System.Drawing.Image)(resources.GetObject("xyZoomPB.Image")));
      this.xyZoomPB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.xyZoomPB.Location = new System.Drawing.Point(16, 178);
      this.xyZoomPB.Name = "xyZoomPB";
      this.xyZoomPB.Size = new System.Drawing.Size(120, 24);
      this.xyZoomPB.TabIndex = 45;
      this.xyZoomPB.Text = "      XY Zoom";
      this.xyZoomPB.CheckedChanged += new System.EventHandler(this.xyZoomPB_CheckedChanged);
      // 
      // pointerPB
      // 
      this.pointerPB.Appearance = System.Windows.Forms.Appearance.Button;
      this.pointerPB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.pointerPB.Image = ((System.Drawing.Image)(resources.GetObject("pointerPB.Image")));
      this.pointerPB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.pointerPB.Location = new System.Drawing.Point(14, 44);
      this.pointerPB.Name = "pointerPB";
      this.pointerPB.Size = new System.Drawing.Size(120, 25);
      this.pointerPB.TabIndex = 34;
      this.pointerPB.Text = "      Pointer";
      this.pointerPB.CheckedChanged += new System.EventHandler(this.pointerPB_CheckedChanged);
      // 
      // zoomInPB
      // 
      this.zoomInPB.Appearance = System.Windows.Forms.Appearance.Button;
      this.zoomInPB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.zoomInPB.Image = ((System.Drawing.Image)(resources.GetObject("zoomInPB.Image")));
      this.zoomInPB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.zoomInPB.Location = new System.Drawing.Point(14, 69);
      this.zoomInPB.Name = "zoomInPB";
      this.zoomInPB.Size = new System.Drawing.Size(120, 25);
      this.zoomInPB.TabIndex = 36;
      this.zoomInPB.Text = "      Zoom In";
      this.zoomInPB.CheckedChanged += new System.EventHandler(this.zoomInPB_CheckedChanged);
      // 
      // zoomOutPB
      // 
      this.zoomOutPB.Appearance = System.Windows.Forms.Appearance.Button;
      this.zoomOutPB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.zoomOutPB.Image = ((System.Drawing.Image)(resources.GetObject("zoomOutPB.Image")));
      this.zoomOutPB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.zoomOutPB.Location = new System.Drawing.Point(14, 93);
      this.zoomOutPB.Name = "zoomOutPB";
      this.zoomOutPB.Size = new System.Drawing.Size(120, 24);
      this.zoomOutPB.TabIndex = 37;
      this.zoomOutPB.Text = "      Zoom Out";
      this.zoomOutPB.CheckedChanged += new System.EventHandler(this.zoomOutPB_CheckedChanged);
      // 
      // ucChartDir1
      // 
      this.ucChartDir1.cdev = null;
      this.ucChartDir1.Location = new System.Drawing.Point(145, 133);
      this.ucChartDir1.Name = "ucChartDir1";
      this.ucChartDir1.Size = new System.Drawing.Size(616, 369);
      this.ucChartDir1.TabIndex = 47;
      // 
      // frmChartDir
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(773, 529);
      this.Controls.Add(this.ucChartDir1);
      this.Controls.Add(this.winChartViewer1);
      this.Controls.Add(this.xZoomPB);
      this.Controls.Add(this.xyZoomPB);
      this.Controls.Add(this.pointerPB);
      this.Controls.Add(this.startDate);
      this.Controls.Add(this.startDateLabel);
      this.Controls.Add(this.durationLabel);
      this.Controls.Add(this.zoomModeLabel);
      this.Controls.Add(this.duration);
      this.Controls.Add(this.zoomInPB);
      this.Controls.Add(this.zoomOutPB);
      this.Name = "frmChartDir";
      this.Text = "frmChartDir";
      this.Load += new System.EventHandler(this.frmChartDir_Load);
      ((System.ComponentModel.ISupportInitialize)(this.winChartViewer1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.RadioButton pointerPB;
    private System.Windows.Forms.DateTimePicker startDate;
    private System.Windows.Forms.Label startDateLabel;
    private System.Windows.Forms.Label durationLabel;
    private System.Windows.Forms.Label zoomModeLabel;
    private System.Windows.Forms.ComboBox duration;
    private System.Windows.Forms.RadioButton zoomInPB;
    private System.Windows.Forms.RadioButton zoomOutPB;
    private System.Windows.Forms.RadioButton xZoomPB;
    private System.Windows.Forms.RadioButton xyZoomPB;
    private ChartDirector.WinChartViewer winChartViewer1;
    private ucChartDir ucChartDir1;
  }
}