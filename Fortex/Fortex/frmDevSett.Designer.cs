namespace DiffPress {
  partial class frmDevSett {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDevSett));
      this.label6 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.cmbType = new System.Windows.Forms.ComboBox();
      this.txtName = new System.Windows.Forms.TextBox();
      this.nudAlarmHi = new System.Windows.Forms.NumericUpDown();
      this.nudAlarmLo = new System.Windows.Forms.NumericUpDown();
      this.cmbEnable = new System.Windows.Forms.ComboBox();
      this.lblAddr = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.picAlarm = new System.Windows.Forms.PictureBox();
      this.button1 = new System.Windows.Forms.Button();
      this.btnOK = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.nudAlarmHi)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudAlarmLo)).BeginInit();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.picAlarm)).BeginInit();
      this.SuspendLayout();
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(29, 121);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(56, 13);
      this.label6.TabIndex = 4;
      this.label6.Text = "AlarmLow:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(187, 125);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(58, 13);
      this.label4.TabIndex = 5;
      this.label4.Text = "AlarmHigh:";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(171, 16);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(43, 13);
      this.label8.TabIndex = 6;
      this.label8.Text = "Enable:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(62, 87);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(38, 13);
      this.label3.TabIndex = 3;
      this.label3.Text = "Name:";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(67, 55);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(34, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Type:";
      // 
      // cmbType
      // 
      this.cmbType.AutoCompleteCustomSource.AddRange(new string[] {
            "Not Set",
            "RH & T",
            "Diff Press"});
      this.cmbType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cmbType.FormattingEnabled = true;
      this.cmbType.Items.AddRange(new object[] {
            "Not Set",
            "RH & T",
            "Diff Press"});
      this.cmbType.Location = new System.Drawing.Point(108, 48);
      this.cmbType.Name = "cmbType";
      this.cmbType.Size = new System.Drawing.Size(218, 21);
      this.cmbType.TabIndex = 7;
      this.cmbType.Text = "Not Set";
      // 
      // txtName
      // 
      this.txtName.Location = new System.Drawing.Point(108, 82);
      this.txtName.Name = "txtName";
      this.txtName.Size = new System.Drawing.Size(216, 20);
      this.txtName.TabIndex = 8;
      // 
      // nudAlarmHi
      // 
      this.nudAlarmHi.DecimalPlaces = 1;
      this.nudAlarmHi.Location = new System.Drawing.Point(246, 120);
      this.nudAlarmHi.Name = "nudAlarmHi";
      this.nudAlarmHi.Size = new System.Drawing.Size(82, 20);
      this.nudAlarmHi.TabIndex = 14;
      // 
      // nudAlarmLo
      // 
      this.nudAlarmLo.DecimalPlaces = 1;
      this.nudAlarmLo.Location = new System.Drawing.Point(84, 116);
      this.nudAlarmLo.Name = "nudAlarmLo";
      this.nudAlarmLo.Size = new System.Drawing.Size(84, 20);
      this.nudAlarmLo.TabIndex = 14;
      // 
      // cmbEnable
      // 
      this.cmbEnable.FormattingEnabled = true;
      this.cmbEnable.Items.AddRange(new object[] {
            "Enable",
            "Disable"});
      this.cmbEnable.Location = new System.Drawing.Point(237, 11);
      this.cmbEnable.Name = "cmbEnable";
      this.cmbEnable.Size = new System.Drawing.Size(90, 21);
      this.cmbEnable.TabIndex = 15;
      this.cmbEnable.Text = "Disable";
      // 
      // lblAddr
      // 
      this.lblAddr.AutoSize = true;
      this.lblAddr.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblAddr.Location = new System.Drawing.Point(11, 12);
      this.lblAddr.Name = "lblAddr";
      this.lblAddr.Size = new System.Drawing.Size(20, 24);
      this.lblAddr.TabIndex = 13;
      this.lblAddr.Text = "1";
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.lblAddr);
      this.groupBox1.Location = new System.Drawing.Point(3, 1);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(41, 46);
      this.groupBox1.TabIndex = 18;
      this.groupBox1.TabStop = false;
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = global::DiffPress.Properties.Resources.HighLimit2;
      this.pictureBox1.Location = new System.Drawing.Point(189, 146);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(141, 121);
      this.pictureBox1.TabIndex = 17;
      this.pictureBox1.TabStop = false;
      // 
      // picAlarm
      // 
      this.picAlarm.Image = global::DiffPress.Properties.Resources.LowLimit2;
      this.picAlarm.Location = new System.Drawing.Point(30, 150);
      this.picAlarm.Name = "picAlarm";
      this.picAlarm.Size = new System.Drawing.Size(141, 116);
      this.picAlarm.TabIndex = 17;
      this.picAlarm.TabStop = false;
      this.picAlarm.Click += new System.EventHandler(this.picAlarm_Click);
      // 
      // button1
      // 
      this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
      this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.button1.Location = new System.Drawing.Point(15, 315);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(68, 40);
      this.button1.TabIndex = 16;
      this.button1.Text = "OK ";
      this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // btnOK
      // 
      this.btnOK.Image = global::DiffPress.Properties.Resources.Cancel;
      this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnOK.Location = new System.Drawing.Point(99, 316);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(76, 40);
      this.btnOK.TabIndex = 16;
      this.btnOK.Text = "Cancel";
      this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click_1);
      // 
      // frmDevSett
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.WhiteSmoke;
      this.ClientSize = new System.Drawing.Size(351, 388);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.picAlarm);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.cmbEnable);
      this.Controls.Add(this.nudAlarmLo);
      this.Controls.Add(this.nudAlarmHi);
      this.Controls.Add(this.txtName);
      this.Controls.Add(this.cmbType);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label1);
      this.Name = "frmDevSett";
      this.Text = "frmDevSett";
      this.Load += new System.EventHandler(this.frmDevSett_Load);
      ((System.ComponentModel.ISupportInitialize)(this.nudAlarmHi)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudAlarmLo)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.picAlarm)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox cmbType;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.NumericUpDown nudAlarmHi;
    private System.Windows.Forms.NumericUpDown nudAlarmLo;
    private System.Windows.Forms.ComboBox cmbEnable;
    private System.Windows.Forms.Label lblAddr;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.PictureBox picAlarm;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button button1;
  }
}