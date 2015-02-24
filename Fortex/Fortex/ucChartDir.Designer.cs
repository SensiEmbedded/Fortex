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
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.cbShowLoAlarmsVal2 = new System.Windows.Forms.CheckBox();
      this.cbShowHiAlarmsVal2 = new System.Windows.Forms.CheckBox();
      this.cbShowLoAlarmsVal1 = new System.Windows.Forms.CheckBox();
      this.cbShowHiAlarmsVal1 = new System.Windows.Forms.CheckBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.nudUpper = new System.Windows.Forms.NumericUpDown();
      this.nudDown = new System.Windows.Forms.NumericUpDown();
      this.zoomOutPB = new System.Windows.Forms.RadioButton();
      this.zoomInPB = new System.Windows.Forms.RadioButton();
      this.pointerPB = new System.Windows.Forms.RadioButton();
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.winChartViewer1 = new ChartDirector.WinChartViewer();
      this.panel1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudUpper)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudDown)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.winChartViewer1)).BeginInit();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.groupBox2);
      this.panel1.Controls.Add(this.groupBox1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(126, 414);
      this.panel1.TabIndex = 0;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.cbShowLoAlarmsVal2);
      this.groupBox2.Controls.Add(this.cbShowHiAlarmsVal2);
      this.groupBox2.Controls.Add(this.cbShowLoAlarmsVal1);
      this.groupBox2.Controls.Add(this.cbShowHiAlarmsVal1);
      this.groupBox2.Location = new System.Drawing.Point(6, 211);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(116, 111);
      this.groupBox2.TabIndex = 51;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Alarms Show/Hide";
      // 
      // cbShowLoAlarmsVal2
      // 
      this.cbShowLoAlarmsVal2.AutoSize = true;
      this.cbShowLoAlarmsVal2.Location = new System.Drawing.Point(4, 88);
      this.cbShowLoAlarmsVal2.Name = "cbShowLoAlarmsVal2";
      this.cbShowLoAlarmsVal2.Size = new System.Drawing.Size(96, 17);
      this.cbShowLoAlarmsVal2.TabIndex = 3;
      this.cbShowLoAlarmsVal2.Text = "ShowLoAlarms";
      this.cbShowLoAlarmsVal2.UseVisualStyleBackColor = true;
      this.cbShowLoAlarmsVal2.CheckedChanged += new System.EventHandler(this.cbShowHiAlarmsVal1_CheckedChanged);
      // 
      // cbShowHiAlarmsVal2
      // 
      this.cbShowHiAlarmsVal2.AutoSize = true;
      this.cbShowHiAlarmsVal2.Location = new System.Drawing.Point(4, 65);
      this.cbShowHiAlarmsVal2.Name = "cbShowHiAlarmsVal2";
      this.cbShowHiAlarmsVal2.Size = new System.Drawing.Size(94, 17);
      this.cbShowHiAlarmsVal2.TabIndex = 2;
      this.cbShowHiAlarmsVal2.Text = "ShowHiAlarms";
      this.cbShowHiAlarmsVal2.UseVisualStyleBackColor = true;
      this.cbShowHiAlarmsVal2.CheckedChanged += new System.EventHandler(this.cbShowHiAlarmsVal1_CheckedChanged);
      // 
      // cbShowLoAlarmsVal1
      // 
      this.cbShowLoAlarmsVal1.AutoSize = true;
      this.cbShowLoAlarmsVal1.Location = new System.Drawing.Point(4, 44);
      this.cbShowLoAlarmsVal1.Name = "cbShowLoAlarmsVal1";
      this.cbShowLoAlarmsVal1.Size = new System.Drawing.Size(96, 17);
      this.cbShowLoAlarmsVal1.TabIndex = 1;
      this.cbShowLoAlarmsVal1.Text = "ShowLoAlarms";
      this.cbShowLoAlarmsVal1.UseVisualStyleBackColor = true;
      this.cbShowLoAlarmsVal1.CheckedChanged += new System.EventHandler(this.cbShowHiAlarmsVal1_CheckedChanged);
      // 
      // cbShowHiAlarmsVal1
      // 
      this.cbShowHiAlarmsVal1.AutoSize = true;
      this.cbShowHiAlarmsVal1.Location = new System.Drawing.Point(4, 24);
      this.cbShowHiAlarmsVal1.Name = "cbShowHiAlarmsVal1";
      this.cbShowHiAlarmsVal1.Size = new System.Drawing.Size(94, 17);
      this.cbShowHiAlarmsVal1.TabIndex = 0;
      this.cbShowHiAlarmsVal1.Text = "ShowHiAlarms";
      this.cbShowHiAlarmsVal1.UseVisualStyleBackColor = true;
      this.cbShowHiAlarmsVal1.CheckedChanged += new System.EventHandler(this.cbShowHiAlarmsVal1_CheckedChanged);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.nudUpper);
      this.groupBox1.Controls.Add(this.nudDown);
      this.groupBox1.Controls.Add(this.zoomOutPB);
      this.groupBox1.Controls.Add(this.zoomInPB);
      this.groupBox1.Controls.Add(this.pointerPB);
      this.groupBox1.Location = new System.Drawing.Point(3, 7);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(116, 189);
      this.groupBox1.TabIndex = 50;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Chart Control";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(9, 141);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(55, 13);
      this.label2.TabIndex = 52;
      this.label2.Text = "Y axis Min";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(9, 96);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(58, 13);
      this.label1.TabIndex = 51;
      this.label1.Text = "Y axis Max";
      // 
      // nudUpper
      // 
      this.nudUpper.Location = new System.Drawing.Point(10, 112);
      this.nudUpper.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.nudUpper.Minimum = new decimal(new int[] {
            20050,
            0,
            0,
            -2147483648});
      this.nudUpper.Name = "nudUpper";
      this.nudUpper.Size = new System.Drawing.Size(96, 20);
      this.nudUpper.TabIndex = 50;
      this.nudUpper.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
      this.nudUpper.ValueChanged += new System.EventHandler(this.nudUpper_ValueChanged);
      // 
      // nudDown
      // 
      this.nudDown.Location = new System.Drawing.Point(9, 157);
      this.nudDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.nudDown.Minimum = new decimal(new int[] {
            20050,
            0,
            0,
            -2147483648});
      this.nudDown.Name = "nudDown";
      this.nudDown.Size = new System.Drawing.Size(96, 20);
      this.nudDown.TabIndex = 49;
      this.nudDown.ValueChanged += new System.EventHandler(this.nudDown_ValueChanged);
      // 
      // zoomOutPB
      // 
      this.zoomOutPB.Appearance = System.Windows.Forms.Appearance.Button;
      this.zoomOutPB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.zoomOutPB.Image = ((System.Drawing.Image)(resources.GetObject("zoomOutPB.Image")));
      this.zoomOutPB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.zoomOutPB.Location = new System.Drawing.Point(7, 67);
      this.zoomOutPB.Name = "zoomOutPB";
      this.zoomOutPB.Size = new System.Drawing.Size(103, 24);
      this.zoomOutPB.TabIndex = 48;
      this.zoomOutPB.Text = "      Zoom Out";
      this.zoomOutPB.CheckedChanged += new System.EventHandler(this.zoomOutPB_CheckedChanged);
      // 
      // zoomInPB
      // 
      this.zoomInPB.Appearance = System.Windows.Forms.Appearance.Button;
      this.zoomInPB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.zoomInPB.Image = ((System.Drawing.Image)(resources.GetObject("zoomInPB.Image")));
      this.zoomInPB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.zoomInPB.Location = new System.Drawing.Point(7, 43);
      this.zoomInPB.Name = "zoomInPB";
      this.zoomInPB.Size = new System.Drawing.Size(103, 25);
      this.zoomInPB.TabIndex = 47;
      this.zoomInPB.Text = "      Zoom In";
      this.zoomInPB.CheckedChanged += new System.EventHandler(this.zoomInPB_CheckedChanged);
      // 
      // pointerPB
      // 
      this.pointerPB.Appearance = System.Windows.Forms.Appearance.Button;
      this.pointerPB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.pointerPB.Image = ((System.Drawing.Image)(resources.GetObject("pointerPB.Image")));
      this.pointerPB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.pointerPB.Location = new System.Drawing.Point(7, 18);
      this.pointerPB.Name = "pointerPB";
      this.pointerPB.Size = new System.Drawing.Size(103, 25);
      this.pointerPB.TabIndex = 46;
      this.pointerPB.Text = "      Pointer";
      this.pointerPB.CheckedChanged += new System.EventHandler(this.pointerPB_CheckedChanged);
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
      this.winChartViewer1.Location = new System.Drawing.Point(126, 0);
      this.winChartViewer1.Name = "winChartViewer1";
      this.winChartViewer1.ScrollDirection = ChartDirector.WinChartDirection.HorizontalVertical;
      this.winChartViewer1.Size = new System.Drawing.Size(660, 414);
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
      this.Size = new System.Drawing.Size(786, 414);
      this.Load += new System.EventHandler(this.ucChartDir_Load);
      this.panel1.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudUpper)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudDown)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.winChartViewer1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private ChartDirector.WinChartViewer winChartViewer1;
    private System.Windows.Forms.RadioButton pointerPB;
    private System.Windows.Forms.RadioButton zoomInPB;
    private System.Windows.Forms.RadioButton zoomOutPB;
    private System.Windows.Forms.ImageList imageList1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.CheckBox cbShowLoAlarmsVal1;
    private System.Windows.Forms.CheckBox cbShowHiAlarmsVal1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.CheckBox cbShowLoAlarmsVal2;
    private System.Windows.Forms.CheckBox cbShowHiAlarmsVal2;
    private System.Windows.Forms.NumericUpDown nudUpper;
    private System.Windows.Forms.NumericUpDown nudDown;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
  }
}
