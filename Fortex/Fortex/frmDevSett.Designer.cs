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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDevSett));
      this.label6 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.cmbType = new System.Windows.Forms.ComboBox();
      this.txtName = new System.Windows.Forms.TextBox();
      this.nudAlarmHiVal1 = new System.Windows.Forms.NumericUpDown();
      this.nudAlarmLoVal1 = new System.Windows.Forms.NumericUpDown();
      this.lblAddr = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.txtDescr = new System.Windows.Forms.TextBox();
      this.grpBox1 = new System.Windows.Forms.GroupBox();
      this.grpBox2 = new System.Windows.Forms.GroupBox();
      this.nudAlarmLoVal2 = new System.Windows.Forms.NumericUpDown();
      this.label5 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.nudAlarmHiVal2 = new System.Windows.Forms.NumericUpDown();
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.pbDevices = new System.Windows.Forms.PictureBox();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.picAlarm = new System.Windows.Forms.PictureBox();
      this.button1 = new System.Windows.Forms.Button();
      this.btnOK = new System.Windows.Forms.Button();
      this.label9 = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.ucOnOff1 = new DiffPress.ucOnOff();
      this.label11 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.nudAlarmHiVal1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudAlarmLoVal1)).BeginInit();
      this.grpBox1.SuspendLayout();
      this.grpBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudAlarmLoVal2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudAlarmHiVal2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbDevices)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.picAlarm)).BeginInit();
      this.SuspendLayout();
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(9, 84);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(56, 13);
      this.label6.TabIndex = 4;
      this.label6.Text = "AlarmLow:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(7, 30);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(58, 13);
      this.label4.TabIndex = 5;
      this.label4.Text = "AlarmHigh:";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(341, 27);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(80, 13);
      this.label8.TabIndex = 6;
      this.label8.Text = "On/Off Device:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(4, 90);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(38, 13);
      this.label3.TabIndex = 3;
      this.label3.Text = "Name:";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(178, 55);
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
      this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cmbType.FormattingEnabled = true;
      this.cmbType.Items.AddRange(new object[] {
            "RH & T",
            "Diff Press"});
      this.cmbType.Location = new System.Drawing.Point(222, 48);
      this.cmbType.Name = "cmbType";
      this.cmbType.Size = new System.Drawing.Size(104, 21);
      this.cmbType.TabIndex = 0;
      this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
      // 
      // txtName
      // 
      this.txtName.Location = new System.Drawing.Point(44, 83);
      this.txtName.Name = "txtName";
      this.txtName.Size = new System.Drawing.Size(280, 20);
      this.txtName.TabIndex = 1;
      // 
      // nudAlarmHiVal1
      // 
      this.nudAlarmHiVal1.DecimalPlaces = 1;
      this.nudAlarmHiVal1.Location = new System.Drawing.Point(66, 25);
      this.nudAlarmHiVal1.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
      this.nudAlarmHiVal1.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            -2147483648});
      this.nudAlarmHiVal1.Name = "nudAlarmHiVal1";
      this.nudAlarmHiVal1.Size = new System.Drawing.Size(82, 20);
      this.nudAlarmHiVal1.TabIndex = 0;
      // 
      // nudAlarmLoVal1
      // 
      this.nudAlarmLoVal1.DecimalPlaces = 1;
      this.nudAlarmLoVal1.Location = new System.Drawing.Point(64, 79);
      this.nudAlarmLoVal1.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
      this.nudAlarmLoVal1.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            -2147483648});
      this.nudAlarmLoVal1.Name = "nudAlarmLoVal1";
      this.nudAlarmLoVal1.Size = new System.Drawing.Size(84, 20);
      this.nudAlarmLoVal1.TabIndex = 1;
      // 
      // lblAddr
      // 
      this.lblAddr.AutoSize = true;
      this.lblAddr.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblAddr.Location = new System.Drawing.Point(97, 50);
      this.lblAddr.Name = "lblAddr";
      this.lblAddr.Size = new System.Drawing.Size(20, 24);
      this.lblAddr.TabIndex = 13;
      this.lblAddr.Text = "1";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(9, 121);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(35, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "Desc:";
      // 
      // txtDescr
      // 
      this.txtDescr.Location = new System.Drawing.Point(43, 114);
      this.txtDescr.Multiline = true;
      this.txtDescr.Name = "txtDescr";
      this.txtDescr.Size = new System.Drawing.Size(281, 89);
      this.txtDescr.TabIndex = 2;
      // 
      // grpBox1
      // 
      this.grpBox1.Controls.Add(this.nudAlarmLoVal1);
      this.grpBox1.Controls.Add(this.label4);
      this.grpBox1.Controls.Add(this.label6);
      this.grpBox1.Controls.Add(this.nudAlarmHiVal1);
      this.grpBox1.Location = new System.Drawing.Point(359, 234);
      this.grpBox1.Name = "grpBox1";
      this.grpBox1.Size = new System.Drawing.Size(171, 141);
      this.grpBox1.TabIndex = 20;
      this.grpBox1.TabStop = false;
      this.grpBox1.Text = "val1";
      // 
      // grpBox2
      // 
      this.grpBox2.Controls.Add(this.nudAlarmLoVal2);
      this.grpBox2.Controls.Add(this.label5);
      this.grpBox2.Controls.Add(this.label7);
      this.grpBox2.Controls.Add(this.nudAlarmHiVal2);
      this.grpBox2.Location = new System.Drawing.Point(542, 232);
      this.grpBox2.Name = "grpBox2";
      this.grpBox2.Size = new System.Drawing.Size(171, 141);
      this.grpBox2.TabIndex = 21;
      this.grpBox2.TabStop = false;
      this.grpBox2.Text = "val2";
      // 
      // nudAlarmLoVal2
      // 
      this.nudAlarmLoVal2.DecimalPlaces = 1;
      this.nudAlarmLoVal2.Location = new System.Drawing.Point(64, 79);
      this.nudAlarmLoVal2.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
      this.nudAlarmLoVal2.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            -2147483648});
      this.nudAlarmLoVal2.Name = "nudAlarmLoVal2";
      this.nudAlarmLoVal2.Size = new System.Drawing.Size(84, 20);
      this.nudAlarmLoVal2.TabIndex = 1;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(7, 30);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(58, 13);
      this.label5.TabIndex = 5;
      this.label5.Text = "AlarmHigh:";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(9, 84);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(56, 13);
      this.label7.TabIndex = 4;
      this.label7.Text = "AlarmLow:";
      // 
      // nudAlarmHiVal2
      // 
      this.nudAlarmHiVal2.DecimalPlaces = 1;
      this.nudAlarmHiVal2.Location = new System.Drawing.Point(66, 25);
      this.nudAlarmHiVal2.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
      this.nudAlarmHiVal2.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            -2147483648});
      this.nudAlarmHiVal2.Name = "nudAlarmHiVal2";
      this.nudAlarmHiVal2.Size = new System.Drawing.Size(82, 20);
      this.nudAlarmHiVal2.TabIndex = 0;
      // 
      // imageList1
      // 
      this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
      this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
      this.imageList1.Images.SetKeyName(0, "RH&T_final.png");
      this.imageList1.Images.SetKeyName(1, "DTP_031.png");
      // 
      // pbDevices
      // 
      this.pbDevices.Image = global::DiffPress.Properties.Resources.DTP_031;
      this.pbDevices.Location = new System.Drawing.Point(477, 3);
      this.pbDevices.Name = "pbDevices";
      this.pbDevices.Size = new System.Drawing.Size(150, 192);
      this.pbDevices.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pbDevices.TabIndex = 22;
      this.pbDevices.TabStop = false;
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = global::DiffPress.Properties.Resources.HighLimit2;
      this.pictureBox1.Location = new System.Drawing.Point(186, 243);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(141, 121);
      this.pictureBox1.TabIndex = 17;
      this.pictureBox1.TabStop = false;
      // 
      // picAlarm
      // 
      this.picAlarm.Image = global::DiffPress.Properties.Resources.LowLimit2;
      this.picAlarm.Location = new System.Drawing.Point(27, 247);
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
      this.button1.Location = new System.Drawing.Point(12, 397);
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
      this.btnOK.Location = new System.Drawing.Point(96, 398);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(76, 40);
      this.btnOK.TabIndex = 16;
      this.btnOK.Text = "Cancel";
      this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click_1);
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(29, 226);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(83, 13);
      this.label9.TabIndex = 23;
      this.label9.Text = "Low Type Alarm";
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(187, 224);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(85, 13);
      this.label10.TabIndex = 24;
      this.label10.Text = "High Type Alarm";
      this.label10.Click += new System.EventHandler(this.label10_Click);
      // 
      // ucOnOff1
      // 
      this.ucOnOff1.isOn = false;
      this.ucOnOff1.Location = new System.Drawing.Point(343, 48);
      this.ucOnOff1.Name = "ucOnOff1";
      this.ucOnOff1.ReadOnly = false;
      this.ucOnOff1.Size = new System.Drawing.Size(74, 132);
      this.ucOnOff1.TabIndex = 19;
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(40, 56);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(58, 13);
      this.label11.TabIndex = 70;
      this.label11.Text = "Device ID:";
      // 
      // frmDevSett
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.WhiteSmoke;
      this.ClientSize = new System.Drawing.Size(952, 460);
      this.Controls.Add(this.lblAddr);
      this.Controls.Add(this.label11);
      this.Controls.Add(this.label10);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.pbDevices);
      this.Controls.Add(this.grpBox2);
      this.Controls.Add(this.grpBox1);
      this.Controls.Add(this.ucOnOff1);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.picAlarm);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.txtDescr);
      this.Controls.Add(this.txtName);
      this.Controls.Add(this.cmbType);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label1);
      this.Name = "frmDevSett";
      this.Text = "frmDevSett";
      this.Load += new System.EventHandler(this.frmDevSett_Load);
      ((System.ComponentModel.ISupportInitialize)(this.nudAlarmHiVal1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudAlarmLoVal1)).EndInit();
      this.grpBox1.ResumeLayout(false);
      this.grpBox1.PerformLayout();
      this.grpBox2.ResumeLayout(false);
      this.grpBox2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudAlarmLoVal2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudAlarmHiVal2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbDevices)).EndInit();
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
    private System.Windows.Forms.NumericUpDown nudAlarmHiVal1;
    private System.Windows.Forms.NumericUpDown nudAlarmLoVal1;
    private System.Windows.Forms.Label lblAddr;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.PictureBox picAlarm;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtDescr;
    private ucOnOff ucOnOff1;
    private System.Windows.Forms.GroupBox grpBox1;
    private System.Windows.Forms.GroupBox grpBox2;
    private System.Windows.Forms.NumericUpDown nudAlarmLoVal2;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.NumericUpDown nudAlarmHiVal2;
    private System.Windows.Forms.PictureBox pbDevices;
    private System.Windows.Forms.ImageList imageList1;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label11;
  }
}