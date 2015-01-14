namespace DiffPress {
  partial class ucValue {
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
      this.digitalPanelMeterBlue1 = new MfgControl.AdvancedHMI.Controls.DigitalPanelMeterBlue();
      this.tmrBlink = new System.Windows.Forms.Timer(this.components);
      this.lblDown = new System.Windows.Forms.Label();
      this.lblUp = new System.Windows.Forms.Label();
      this.lblMiddle = new System.Windows.Forms.Label();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.pnlBlink = new System.Windows.Forms.Panel();
      this.lblStatus = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.lblAlarmLimit1 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.lblAlarmLimit2 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.lblAlarmType = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.pnlBlink.SuspendLayout();
      this.SuspendLayout();
      // 
      // digitalPanelMeterBlue1
      // 
      this.digitalPanelMeterBlue1.DecimalPosition = 0;
      this.digitalPanelMeterBlue1.ForeColor = System.Drawing.Color.Black;
      this.digitalPanelMeterBlue1.Location = new System.Drawing.Point(8, 8);
      this.digitalPanelMeterBlue1.Maximum = 100D;
      this.digitalPanelMeterBlue1.Minimum = -110D;
      this.digitalPanelMeterBlue1.Name = "digitalPanelMeterBlue1";
      this.digitalPanelMeterBlue1.Resolution = new decimal(new int[] {
            1,
            0,
            0,
            65536});
      this.digitalPanelMeterBlue1.Size = new System.Drawing.Size(243, 137);
      this.digitalPanelMeterBlue1.TabIndex = 60;
      this.digitalPanelMeterBlue1.Text = "Differential Pressure 1";
      this.digitalPanelMeterBlue1.Value = 50D;
      this.digitalPanelMeterBlue1.ValueScaleFactor = 1D;
      // 
      // tmrBlink
      // 
      this.tmrBlink.Interval = 500;
      this.tmrBlink.Tick += new System.EventHandler(this.tmrBlink_Tick);
      // 
      // lblDown
      // 
      this.lblDown.AutoSize = true;
      this.lblDown.Location = new System.Drawing.Point(6, 229);
      this.lblDown.Name = "lblDown";
      this.lblDown.Size = new System.Drawing.Size(34, 13);
      this.lblDown.TabIndex = 63;
      this.lblDown.Text = "-100 -";
      this.lblDown.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // lblUp
      // 
      this.lblUp.AutoSize = true;
      this.lblUp.Location = new System.Drawing.Point(8, -1);
      this.lblUp.Name = "lblUp";
      this.lblUp.Size = new System.Drawing.Size(31, 13);
      this.lblUp.TabIndex = 63;
      this.lblUp.Text = "100 -";
      this.lblUp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // lblMiddle
      // 
      this.lblMiddle.AutoSize = true;
      this.lblMiddle.Location = new System.Drawing.Point(19, 115);
      this.lblMiddle.Name = "lblMiddle";
      this.lblMiddle.Size = new System.Drawing.Size(19, 13);
      this.lblMiddle.TabIndex = 63;
      this.lblMiddle.Text = "0 -";
      this.lblMiddle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // pictureBox1
      // 
      this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pictureBox1.Location = new System.Drawing.Point(38, 2);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(30, 240);
      this.pictureBox1.TabIndex = 67;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
      // 
      // pnlBlink
      // 
      this.pnlBlink.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pnlBlink.Controls.Add(this.digitalPanelMeterBlue1);
      this.pnlBlink.Location = new System.Drawing.Point(71, 89);
      this.pnlBlink.Name = "pnlBlink";
      this.pnlBlink.Size = new System.Drawing.Size(260, 152);
      this.pnlBlink.TabIndex = 68;
      // 
      // lblStatus
      // 
      this.lblStatus.AutoSize = true;
      this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblStatus.Location = new System.Drawing.Point(201, 67);
      this.lblStatus.Name = "lblStatus";
      this.lblStatus.Size = new System.Drawing.Size(59, 16);
      this.lblStatus.TabIndex = 69;
      this.lblStatus.Text = "Not Set";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label1.Location = new System.Drawing.Point(108, 67);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(86, 16);
      this.label1.TabIndex = 69;
      this.label1.Text = "Alarm Status:";
      // 
      // lblAlarmLimit1
      // 
      this.lblAlarmLimit1.AutoSize = true;
      this.lblAlarmLimit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblAlarmLimit1.Location = new System.Drawing.Point(201, 28);
      this.lblAlarmLimit1.Name = "lblAlarmLimit1";
      this.lblAlarmLimit1.Size = new System.Drawing.Size(59, 16);
      this.lblAlarmLimit1.TabIndex = 69;
      this.lblAlarmLimit1.Text = "Not Set";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label3.Location = new System.Drawing.Point(79, 29);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(115, 16);
      this.label3.TabIndex = 69;
      this.label3.Text = "Alarm Limit 1 (PA):";
      // 
      // lblAlarmLimit2
      // 
      this.lblAlarmLimit2.AutoSize = true;
      this.lblAlarmLimit2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblAlarmLimit2.Location = new System.Drawing.Point(201, 48);
      this.lblAlarmLimit2.Name = "lblAlarmLimit2";
      this.lblAlarmLimit2.Size = new System.Drawing.Size(59, 16);
      this.lblAlarmLimit2.TabIndex = 69;
      this.lblAlarmLimit2.Text = "Not Set";
      this.lblAlarmLimit2.Click += new System.EventHandler(this.lblAlarmLimit2_Click);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label4.Location = new System.Drawing.Point(79, 49);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(115, 16);
      this.label4.TabIndex = 69;
      this.label4.Text = "Alarm Limit 2 (PA):";
      this.label4.Click += new System.EventHandler(this.label4_Click);
      // 
      // lblAlarmType
      // 
      this.lblAlarmType.AutoSize = true;
      this.lblAlarmType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblAlarmType.Location = new System.Drawing.Point(201, 9);
      this.lblAlarmType.Name = "lblAlarmType";
      this.lblAlarmType.Size = new System.Drawing.Size(59, 16);
      this.lblAlarmType.TabIndex = 69;
      this.lblAlarmType.Text = "Not Set";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label5.Location = new System.Drawing.Point(113, 10);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(81, 16);
      this.label5.TabIndex = 69;
      this.label5.Text = "Alarm Type:";
      // 
      // ucValue
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.lblAlarmType);
      this.Controls.Add(this.lblAlarmLimit2);
      this.Controls.Add(this.lblAlarmLimit1);
      this.Controls.Add(this.lblStatus);
      this.Controls.Add(this.pnlBlink);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.lblMiddle);
      this.Controls.Add(this.lblUp);
      this.Controls.Add(this.lblDown);
      this.Name = "ucValue";
      this.Size = new System.Drawing.Size(335, 245);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.pnlBlink.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private MfgControl.AdvancedHMI.Controls.DigitalPanelMeterBlue digitalPanelMeterBlue1;
    private System.Windows.Forms.Timer tmrBlink;
    private System.Windows.Forms.Label lblDown;
    private System.Windows.Forms.Label lblUp;
    private System.Windows.Forms.Label lblMiddle;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Panel pnlBlink;
    private System.Windows.Forms.Label lblStatus;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label lblAlarmLimit1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label lblAlarmLimit2;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label lblAlarmType;
    private System.Windows.Forms.Label label5;
    
  
  }
}
