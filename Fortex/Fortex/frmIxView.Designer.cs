namespace DiffPress {
  partial class frmIxView {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIxView));
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
      this.lblUp = new System.Windows.Forms.Label();
      this.lblVal2 = new System.Windows.Forms.Label();
      this.lblVal1 = new System.Windows.Forms.Label();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.lblAddr = new System.Windows.Forms.Label();
      this.txtDescr = new System.Windows.Forms.TextBox();
      this.txtName = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.txtType = new System.Windows.Forms.TextBox();
      this.grpBox2 = new System.Windows.Forms.GroupBox();
      this.nudAlarmLoVal2 = new System.Windows.Forms.NumericUpDown();
      this.label5 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.nudAlarmHiVal2 = new System.Windows.Forms.NumericUpDown();
      this.grpBox1 = new System.Windows.Forms.GroupBox();
      this.nudAlarmLoVal1 = new System.Windows.Forms.NumericUpDown();
      this.label6 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.nudAlarmHiVal1 = new System.Windows.Forms.NumericUpDown();
      this.pbDevices = new System.Windows.Forms.PictureBox();
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.label4 = new System.Windows.Forms.Label();
      this.lblStaticVal1 = new System.Windows.Forms.Label();
      this.lblStaticVal2 = new System.Windows.Forms.Label();
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.txtID = new System.Windows.Forms.TextBox();
      this.label9 = new System.Windows.Forms.Label();
      this.dtpStart = new System.Windows.Forms.DateTimePicker();
      this.dtpEnd = new System.Windows.Forms.DateTimePicker();
      this.btnSelect = new System.Windows.Forms.Button();
      this.label10 = new System.Windows.Forms.Label();
      this.label11 = new System.Windows.Forms.Label();
      this.nudLimit = new System.Windows.Forms.NumericUpDown();
      this.label12 = new System.Windows.Forms.Label();
      this.ucOnOff1 = new DiffPress.ucOnOff();
      this.grpBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudAlarmLoVal2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudAlarmHiVal2)).BeginInit();
      this.grpBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudAlarmLoVal1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudAlarmHiVal1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbDevices)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudLimit)).BeginInit();
      this.SuspendLayout();
      // 
      // lblUp
      // 
      this.lblUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
      this.lblUp.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblUp.ForeColor = System.Drawing.SystemColors.Desktop;
      this.lblUp.Location = new System.Drawing.Point(0, 0);
      this.lblUp.Name = "lblUp";
      this.lblUp.Size = new System.Drawing.Size(1171, 32);
      this.lblUp.TabIndex = 1;
      this.lblUp.Text = "T °C\r\nRH %";
      this.lblUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lblVal2
      // 
      this.lblVal2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblVal2.ForeColor = System.Drawing.SystemColors.HotTrack;
      this.lblVal2.Location = new System.Drawing.Point(149, 56);
      this.lblVal2.Name = "lblVal2";
      this.lblVal2.Size = new System.Drawing.Size(84, 33);
      this.lblVal2.TabIndex = 5;
      this.lblVal2.Text = "--.-";
      this.lblVal2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblVal1
      // 
      this.lblVal1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblVal1.ForeColor = System.Drawing.SystemColors.HotTrack;
      this.lblVal1.Location = new System.Drawing.Point(4, 60);
      this.lblVal1.Name = "lblVal1";
      this.lblVal1.Size = new System.Drawing.Size(84, 33);
      this.lblVal1.TabIndex = 4;
      this.lblVal1.Text = "--.-";
      this.lblVal1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // timer1
      // 
      this.timer1.Enabled = true;
      this.timer1.Interval = 1000;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // lblAddr
      // 
      this.lblAddr.AutoSize = true;
      this.lblAddr.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblAddr.Location = new System.Drawing.Point(10, 5);
      this.lblAddr.Name = "lblAddr";
      this.lblAddr.Size = new System.Drawing.Size(20, 24);
      this.lblAddr.TabIndex = 13;
      this.lblAddr.Text = "1";
      // 
      // txtDescr
      // 
      this.txtDescr.Location = new System.Drawing.Point(12, 232);
      this.txtDescr.Multiline = true;
      this.txtDescr.Name = "txtDescr";
      this.txtDescr.ReadOnly = true;
      this.txtDescr.Size = new System.Drawing.Size(281, 89);
      this.txtDescr.TabIndex = 2;
      // 
      // txtName
      // 
      this.txtName.Location = new System.Drawing.Point(11, 187);
      this.txtName.Name = "txtName";
      this.txtName.ReadOnly = true;
      this.txtName.Size = new System.Drawing.Size(280, 20);
      this.txtName.TabIndex = 1;
      this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(10, 215);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(35, 13);
      this.label2.TabIndex = 15;
      this.label2.Text = "Desc:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(10, 172);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(38, 13);
      this.label3.TabIndex = 16;
      this.label3.Text = "Name:";
      this.label3.Click += new System.EventHandler(this.label3_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(149, 116);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(34, 13);
      this.label1.TabIndex = 14;
      this.label1.Text = "Type:";
      // 
      // txtType
      // 
      this.txtType.Location = new System.Drawing.Point(149, 133);
      this.txtType.Name = "txtType";
      this.txtType.ReadOnly = true;
      this.txtType.Size = new System.Drawing.Size(132, 20);
      this.txtType.TabIndex = 0;
      // 
      // grpBox2
      // 
      this.grpBox2.Controls.Add(this.nudAlarmLoVal2);
      this.grpBox2.Controls.Add(this.label5);
      this.grpBox2.Controls.Add(this.label7);
      this.grpBox2.Controls.Add(this.nudAlarmHiVal2);
      this.grpBox2.Location = new System.Drawing.Point(189, 362);
      this.grpBox2.Name = "grpBox2";
      this.grpBox2.Size = new System.Drawing.Size(104, 112);
      this.grpBox2.TabIndex = 24;
      this.grpBox2.TabStop = false;
      this.grpBox2.Text = "val2";
      // 
      // nudAlarmLoVal2
      // 
      this.nudAlarmLoVal2.DecimalPlaces = 1;
      this.nudAlarmLoVal2.Location = new System.Drawing.Point(9, 83);
      this.nudAlarmLoVal2.Name = "nudAlarmLoVal2";
      this.nudAlarmLoVal2.ReadOnly = true;
      this.nudAlarmLoVal2.Size = new System.Drawing.Size(64, 20);
      this.nudAlarmLoVal2.TabIndex = 1;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(7, 15);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(58, 13);
      this.label5.TabIndex = 5;
      this.label5.Text = "AlarmHigh:";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(8, 66);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(56, 13);
      this.label7.TabIndex = 4;
      this.label7.Text = "AlarmLow:";
      // 
      // nudAlarmHiVal2
      // 
      this.nudAlarmHiVal2.DecimalPlaces = 1;
      this.nudAlarmHiVal2.Location = new System.Drawing.Point(8, 30);
      this.nudAlarmHiVal2.Name = "nudAlarmHiVal2";
      this.nudAlarmHiVal2.ReadOnly = true;
      this.nudAlarmHiVal2.Size = new System.Drawing.Size(64, 20);
      this.nudAlarmHiVal2.TabIndex = 0;
      // 
      // grpBox1
      // 
      this.grpBox1.Controls.Add(this.nudAlarmLoVal1);
      this.grpBox1.Controls.Add(this.label6);
      this.grpBox1.Controls.Add(this.label8);
      this.grpBox1.Controls.Add(this.nudAlarmHiVal1);
      this.grpBox1.Location = new System.Drawing.Point(9, 364);
      this.grpBox1.Name = "grpBox1";
      this.grpBox1.Size = new System.Drawing.Size(104, 112);
      this.grpBox1.TabIndex = 23;
      this.grpBox1.TabStop = false;
      this.grpBox1.Text = "val1";
      // 
      // nudAlarmLoVal1
      // 
      this.nudAlarmLoVal1.DecimalPlaces = 1;
      this.nudAlarmLoVal1.Location = new System.Drawing.Point(7, 79);
      this.nudAlarmLoVal1.Name = "nudAlarmLoVal1";
      this.nudAlarmLoVal1.ReadOnly = true;
      this.nudAlarmLoVal1.Size = new System.Drawing.Size(64, 20);
      this.nudAlarmLoVal1.TabIndex = 1;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(7, 17);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(58, 13);
      this.label6.TabIndex = 5;
      this.label6.Text = "AlarmHigh:";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(4, 63);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(56, 13);
      this.label8.TabIndex = 4;
      this.label8.Text = "AlarmLow:";
      // 
      // nudAlarmHiVal1
      // 
      this.nudAlarmHiVal1.DecimalPlaces = 1;
      this.nudAlarmHiVal1.Location = new System.Drawing.Point(8, 32);
      this.nudAlarmHiVal1.Name = "nudAlarmHiVal1";
      this.nudAlarmHiVal1.ReadOnly = true;
      this.nudAlarmHiVal1.Size = new System.Drawing.Size(64, 20);
      this.nudAlarmHiVal1.TabIndex = 0;
      // 
      // pbDevices
      // 
      this.pbDevices.Image = global::DiffPress.Properties.Resources.DTP_031;
      this.pbDevices.Location = new System.Drawing.Point(175, 485);
      this.pbDevices.Name = "pbDevices";
      this.pbDevices.Size = new System.Drawing.Size(120, 153);
      this.pbDevices.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pbDevices.TabIndex = 25;
      this.pbDevices.TabStop = false;
      // 
      // imageList1
      // 
      this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
      this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
      this.imageList1.Images.SetKeyName(0, "RH&T_final.png");
      this.imageList1.Images.SetKeyName(1, "DTP_031.png");
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(11, 483);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(80, 13);
      this.label4.TabIndex = 26;
      this.label4.Text = "On/Off Device:";
      // 
      // lblStaticVal1
      // 
      this.lblStaticVal1.AutoSize = true;
      this.lblStaticVal1.Location = new System.Drawing.Point(7, 47);
      this.lblStaticVal1.Name = "lblStaticVal1";
      this.lblStaticVal1.Size = new System.Drawing.Size(37, 13);
      this.lblStaticVal1.TabIndex = 28;
      this.lblStaticVal1.Text = "Temp:";
      // 
      // lblStaticVal2
      // 
      this.lblStaticVal2.AutoSize = true;
      this.lblStaticVal2.Location = new System.Drawing.Point(153, 44);
      this.lblStaticVal2.Name = "lblStaticVal2";
      this.lblStaticVal2.Size = new System.Drawing.Size(26, 13);
      this.lblStaticVal2.TabIndex = 29;
      this.lblStaticVal2.Text = "RH:";
      // 
      // dataGridView1
      // 
      this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      this.dataGridView1.ColumnHeadersHeight = 25;
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
      this.dataGridView1.Location = new System.Drawing.Point(318, 86);
      this.dataGridView1.Name = "dataGridView1";
      dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
      this.dataGridView1.RowHeadersWidth = 20;
      dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
      this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
      this.dataGridView1.RowTemplate.Height = 25;
      this.dataGridView1.Size = new System.Drawing.Size(833, 232);
      this.dataGridView1.TabIndex = 66;
      // 
      // txtID
      // 
      this.txtID.Location = new System.Drawing.Point(11, 133);
      this.txtID.Name = "txtID";
      this.txtID.ReadOnly = true;
      this.txtID.Size = new System.Drawing.Size(114, 20);
      this.txtID.TabIndex = 67;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(11, 117);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(58, 13);
      this.label9.TabIndex = 68;
      this.label9.Text = "Device ID:";
      // 
      // dtpStart
      // 
      this.dtpStart.CustomFormat = "yyyy-MM-dd HH:mm:ss";
      this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dtpStart.Location = new System.Drawing.Point(317, 56);
      this.dtpStart.Name = "dtpStart";
      this.dtpStart.Size = new System.Drawing.Size(151, 20);
      this.dtpStart.TabIndex = 69;
      // 
      // dtpEnd
      // 
      this.dtpEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
      this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dtpEnd.Location = new System.Drawing.Point(502, 56);
      this.dtpEnd.Name = "dtpEnd";
      this.dtpEnd.Size = new System.Drawing.Size(151, 20);
      this.dtpEnd.TabIndex = 70;
      // 
      // btnSelect
      // 
      this.btnSelect.Location = new System.Drawing.Point(805, 45);
      this.btnSelect.Name = "btnSelect";
      this.btnSelect.Size = new System.Drawing.Size(67, 31);
      this.btnSelect.TabIndex = 71;
      this.btnSelect.Text = "Refresh";
      this.btnSelect.UseVisualStyleBackColor = true;
      this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(317, 41);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(96, 13);
      this.label10.TabIndex = 72;
      this.label10.Text = "Start date and time";
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(500, 39);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(93, 13);
      this.label11.TabIndex = 73;
      this.label11.Text = "End date and time";
      // 
      // nudLimit
      // 
      this.nudLimit.Location = new System.Drawing.Point(691, 54);
      this.nudLimit.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
      this.nudLimit.Name = "nudLimit";
      this.nudLimit.Size = new System.Drawing.Size(94, 20);
      this.nudLimit.TabIndex = 74;
      this.nudLimit.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Location = new System.Drawing.Point(688, 36);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(68, 13);
      this.label12.TabIndex = 75;
      this.label12.Text = "Max records:";
      // 
      // ucOnOff1
      // 
      this.ucOnOff1.isOn = false;
      this.ucOnOff1.Location = new System.Drawing.Point(13, 504);
      this.ucOnOff1.Name = "ucOnOff1";
      this.ucOnOff1.ReadOnly = true;
      this.ucOnOff1.Size = new System.Drawing.Size(74, 132);
      this.ucOnOff1.TabIndex = 27;
      // 
      // frmIxView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(1171, 750);
      this.Controls.Add(this.label12);
      this.Controls.Add(this.nudLimit);
      this.Controls.Add(this.label11);
      this.Controls.Add(this.label10);
      this.Controls.Add(this.btnSelect);
      this.Controls.Add(this.dtpEnd);
      this.Controls.Add(this.dtpStart);
      this.Controls.Add(this.txtID);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.dataGridView1);
      this.Controls.Add(this.lblStaticVal2);
      this.Controls.Add(this.lblStaticVal1);
      this.Controls.Add(this.ucOnOff1);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.pbDevices);
      this.Controls.Add(this.grpBox2);
      this.Controls.Add(this.grpBox1);
      this.Controls.Add(this.txtType);
      this.Controls.Add(this.txtDescr);
      this.Controls.Add(this.txtName);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.lblAddr);
      this.Controls.Add(this.lblVal2);
      this.Controls.Add(this.lblVal1);
      this.Controls.Add(this.lblUp);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "frmIxView";
      this.Text = "Channel Current View";
      this.Load += new System.EventHandler(this.frmIxView_Load);
      this.grpBox2.ResumeLayout(false);
      this.grpBox2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudAlarmLoVal2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudAlarmHiVal2)).EndInit();
      this.grpBox1.ResumeLayout(false);
      this.grpBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudAlarmLoVal1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudAlarmHiVal1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbDevices)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudLimit)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblUp;
    private System.Windows.Forms.Label lblVal2;
    private System.Windows.Forms.Label lblVal1;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.Label lblAddr;
    private System.Windows.Forms.TextBox txtDescr;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtType;
    private System.Windows.Forms.GroupBox grpBox2;
    private System.Windows.Forms.NumericUpDown nudAlarmLoVal2;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.NumericUpDown nudAlarmHiVal2;
    private System.Windows.Forms.GroupBox grpBox1;
    private System.Windows.Forms.NumericUpDown nudAlarmLoVal1;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.NumericUpDown nudAlarmHiVal1;
    private System.Windows.Forms.PictureBox pbDevices;
    private System.Windows.Forms.ImageList imageList1;
    private ucOnOff ucOnOff1;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label lblStaticVal1;
    private System.Windows.Forms.Label lblStaticVal2;
    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.TextBox txtID;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.DateTimePicker dtpStart;
    private System.Windows.Forms.DateTimePicker dtpEnd;
    private System.Windows.Forms.Button btnSelect;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.NumericUpDown nudLimit;
    private System.Windows.Forms.Label label12;
  }
}