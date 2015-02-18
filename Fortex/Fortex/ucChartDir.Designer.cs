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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucChartDir));
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnUpdate = new System.Windows.Forms.Button();
      this.label12 = new System.Windows.Forms.Label();
      this.nudLimit = new System.Windows.Forms.NumericUpDown();
      this.label11 = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.dtpEnd = new System.Windows.Forms.DateTimePicker();
      this.dtpStart = new System.Windows.Forms.DateTimePicker();
      this.pointerPB = new System.Windows.Forms.RadioButton();
      this.zoomInPB = new System.Windows.Forms.RadioButton();
      this.zoomOutPB = new System.Windows.Forms.RadioButton();
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.winChartViewer1 = new ChartDirector.WinChartViewer();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudLimit)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.winChartViewer1)).BeginInit();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btnUpdate);
      this.panel1.Controls.Add(this.label12);
      this.panel1.Controls.Add(this.nudLimit);
      this.panel1.Controls.Add(this.label11);
      this.panel1.Controls.Add(this.label10);
      this.panel1.Controls.Add(this.dtpEnd);
      this.panel1.Controls.Add(this.dtpStart);
      this.panel1.Controls.Add(this.pointerPB);
      this.panel1.Controls.Add(this.zoomInPB);
      this.panel1.Controls.Add(this.zoomOutPB);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(151, 414);
      this.panel1.TabIndex = 0;
      // 
      // btnUpdate
      // 
      this.btnUpdate.Location = new System.Drawing.Point(13, 243);
      this.btnUpdate.Name = "btnUpdate";
      this.btnUpdate.Size = new System.Drawing.Size(120, 36);
      this.btnUpdate.TabIndex = 83;
      this.btnUpdate.Text = "button1";
      this.btnUpdate.UseVisualStyleBackColor = true;
      this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Location = new System.Drawing.Point(11, 193);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(68, 13);
      this.label12.TabIndex = 81;
      this.label12.Text = "Max records:";
      // 
      // nudLimit
      // 
      this.nudLimit.Location = new System.Drawing.Point(14, 211);
      this.nudLimit.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
      this.nudLimit.Name = "nudLimit";
      this.nudLimit.Size = new System.Drawing.Size(83, 20);
      this.nudLimit.TabIndex = 80;
      this.nudLimit.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(12, 145);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(93, 13);
      this.label11.TabIndex = 79;
      this.label11.Text = "End date and time";
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(12, 104);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(96, 13);
      this.label10.TabIndex = 78;
      this.label10.Text = "Start date and time";
      // 
      // dtpEnd
      // 
      this.dtpEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
      this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dtpEnd.Location = new System.Drawing.Point(14, 162);
      this.dtpEnd.Name = "dtpEnd";
      this.dtpEnd.Size = new System.Drawing.Size(120, 20);
      this.dtpEnd.TabIndex = 77;
      // 
      // dtpStart
      // 
      this.dtpStart.CustomFormat = "yyyy-MM-dd HH:mm:ss";
      this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dtpStart.Location = new System.Drawing.Point(12, 119);
      this.dtpStart.Name = "dtpStart";
      this.dtpStart.Size = new System.Drawing.Size(122, 20);
      this.dtpStart.TabIndex = 76;
      // 
      // pointerPB
      // 
      this.pointerPB.Appearance = System.Windows.Forms.Appearance.Button;
      this.pointerPB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.pointerPB.Image = ((System.Drawing.Image)(resources.GetObject("pointerPB.Image")));
      this.pointerPB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.pointerPB.Location = new System.Drawing.Point(11, 16);
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
      this.zoomInPB.Location = new System.Drawing.Point(11, 41);
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
      this.zoomOutPB.Location = new System.Drawing.Point(11, 65);
      this.zoomOutPB.Name = "zoomOutPB";
      this.zoomOutPB.Size = new System.Drawing.Size(120, 24);
      this.zoomOutPB.TabIndex = 48;
      this.zoomOutPB.Text = "      Zoom Out";
      this.zoomOutPB.CheckedChanged += new System.EventHandler(this.zoomOutPB_CheckedChanged);
      // 
      // imageList1
      // 
      this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
      this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
      this.imageList1.Images.SetKeyName(0, "");
      this.imageList1.Images.SetKeyName(1, "");
      this.imageList1.Images.SetKeyName(2, "");
      this.imageList1.Images.SetKeyName(3, "");
      this.imageList1.Images.SetKeyName(4, "");
      this.imageList1.Images.SetKeyName(5, "");
      this.imageList1.Images.SetKeyName(6, "");
      this.imageList1.Images.SetKeyName(7, "");
      this.imageList1.Images.SetKeyName(8, "");
      this.imageList1.Images.SetKeyName(9, "");
      this.imageList1.Images.SetKeyName(10, "");
      this.imageList1.Images.SetKeyName(11, "");
      this.imageList1.Images.SetKeyName(12, "");
      this.imageList1.Images.SetKeyName(13, "");
      // 
      // winChartViewer1
      // 
      this.winChartViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.winChartViewer1.ChartSizeMode = ChartDirector.WinChartSizeMode.StretchImage;
      this.winChartViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.winChartViewer1.Location = new System.Drawing.Point(151, 0);
      this.winChartViewer1.Name = "winChartViewer1";
      this.winChartViewer1.ScrollDirection = ChartDirector.WinChartDirection.HorizontalVertical;
      this.winChartViewer1.Size = new System.Drawing.Size(714, 414);
      this.winChartViewer1.TabIndex = 47;
      this.winChartViewer1.TabStop = false;
      this.winChartViewer1.ZoomDirection = ChartDirector.WinChartDirection.HorizontalVertical;
      this.winChartViewer1.ZoomInHeightLimit = 0.001D;
      this.winChartViewer1.ZoomInWidthLimit = 0.001D;
      this.winChartViewer1.ZoomOutRatio = 0.05D;
      this.winChartViewer1.ViewPortChanged += new ChartDirector.WinViewPortEventHandler(this.winChartViewer1_ViewPortChanged);
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
      this.panel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudLimit)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.winChartViewer1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private ChartDirector.WinChartViewer winChartViewer1;
    private System.Windows.Forms.RadioButton pointerPB;
    private System.Windows.Forms.RadioButton zoomInPB;
    private System.Windows.Forms.RadioButton zoomOutPB;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.NumericUpDown nudLimit;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.DateTimePicker dtpEnd;
    private System.Windows.Forms.DateTimePicker dtpStart;
    private System.Windows.Forms.Button btnUpdate;
    private System.Windows.Forms.ImageList imageList1;
  }
}
