namespace DiffPress
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
          this.components = new System.ComponentModel.Container();
          System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
          System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
          System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
          System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
          this.pnlMenu = new System.Windows.Forms.Panel();
          this.grbStatus = new System.Windows.Forms.GroupBox();
          this.lblComm = new System.Windows.Forms.Label();
          this.label4 = new System.Windows.Forms.Label();
          this.lblRemain = new System.Windows.Forms.Label();
          this.label3 = new System.Windows.Forms.Label();
          this.groupBox2 = new System.Windows.Forms.GroupBox();
          this.pictureBox3 = new System.Windows.Forms.PictureBox();
          this.pictureBox2 = new System.Windows.Forms.PictureBox();
          this.label2 = new System.Windows.Forms.Label();
          this.label1 = new System.Windows.Forms.Label();
          this.groupBox1 = new System.Windows.Forms.GroupBox();
          this.blueClock1 = new MfgControl.AdvancedHMI.Controls.BlueClock();
          this.lblClock = new System.Windows.Forms.Label();
          this.pictureBox1 = new System.Windows.Forms.PictureBox();
          this.tmrBlink = new System.Windows.Forms.Timer(this.components);
          this.tmrUpdateGUI = new System.Windows.Forms.Timer(this.components);
          this.dataGridView1 = new System.Windows.Forms.DataGridView();
          this.label5 = new System.Windows.Forms.Label();
          this.pnlFloor1 = new System.Windows.Forms.Panel();
          this.line1 = new Unclassified.UI.Line();
          this.line3 = new Unclassified.UI.Line();
          this.line2 = new Unclassified.UI.Line();
          this.pnlMenu.SuspendLayout();
          this.grbStatus.SuspendLayout();
          this.groupBox2.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
          this.groupBox1.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
          this.SuspendLayout();
          // 
          // pnlMenu
          // 
          this.pnlMenu.AutoScroll = true;
          this.pnlMenu.BackColor = System.Drawing.Color.White;
          this.pnlMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          this.pnlMenu.Controls.Add(this.grbStatus);
          this.pnlMenu.Controls.Add(this.groupBox2);
          this.pnlMenu.Controls.Add(this.groupBox1);
          this.pnlMenu.Controls.Add(this.pictureBox1);
          this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
          this.pnlMenu.Location = new System.Drawing.Point(0, 0);
          this.pnlMenu.Name = "pnlMenu";
          this.pnlMenu.Size = new System.Drawing.Size(225, 733);
          this.pnlMenu.TabIndex = 42;
          // 
          // grbStatus
          // 
          this.grbStatus.Controls.Add(this.line1);
          this.grbStatus.Controls.Add(this.line3);
          this.grbStatus.Controls.Add(this.line2);
          this.grbStatus.Controls.Add(this.lblComm);
          this.grbStatus.Controls.Add(this.label4);
          this.grbStatus.Controls.Add(this.lblRemain);
          this.grbStatus.Controls.Add(this.label3);
          this.grbStatus.Location = new System.Drawing.Point(3, 385);
          this.grbStatus.Name = "grbStatus";
          this.grbStatus.Size = new System.Drawing.Size(210, 133);
          this.grbStatus.TabIndex = 48;
          this.grbStatus.TabStop = false;
          this.grbStatus.Text = "Status:";
          // 
          // lblComm
          // 
          this.lblComm.AutoSize = true;
          this.lblComm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
          this.lblComm.Location = new System.Drawing.Point(105, 74);
          this.lblComm.Name = "lblComm";
          this.lblComm.Size = new System.Drawing.Size(50, 13);
          this.lblComm.TabIndex = 3;
          this.lblComm.Text = "Not Set";
          // 
          // label4
          // 
          this.label4.AutoSize = true;
          this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
          this.label4.Location = new System.Drawing.Point(9, 73);
          this.label4.Name = "label4";
          this.label4.Size = new System.Drawing.Size(81, 13);
          this.label4.TabIndex = 2;
          this.label4.Text = "communication:";
          this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
          // 
          // lblRemain
          // 
          this.lblRemain.AutoSize = true;
          this.lblRemain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
          this.lblRemain.Location = new System.Drawing.Point(108, 31);
          this.lblRemain.Name = "lblRemain";
          this.lblRemain.Size = new System.Drawing.Size(16, 16);
          this.lblRemain.TabIndex = 3;
          this.lblRemain.Text = "0";
          // 
          // label3
          // 
          this.label3.AutoSize = true;
          this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
          this.label3.Location = new System.Drawing.Point(32, 21);
          this.label3.Name = "label3";
          this.label3.Size = new System.Drawing.Size(67, 39);
          this.label3.TabIndex = 2;
          this.label3.Text = "Time remain \r\nto write in\r\ntraceability:";
          this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
          // 
          // groupBox2
          // 
          this.groupBox2.Controls.Add(this.pictureBox3);
          this.groupBox2.Controls.Add(this.pictureBox2);
          this.groupBox2.Controls.Add(this.label2);
          this.groupBox2.Controls.Add(this.label1);
          this.groupBox2.Location = new System.Drawing.Point(3, 837);
          this.groupBox2.Name = "groupBox2";
          this.groupBox2.Size = new System.Drawing.Size(202, 264);
          this.groupBox2.TabIndex = 45;
          this.groupBox2.TabStop = false;
          this.groupBox2.Text = "Params";
          // 
          // pictureBox3
          // 
          this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
          this.pictureBox3.Image = global::DiffPress.Properties.Resources.FullScreen;
          this.pictureBox3.Location = new System.Drawing.Point(49, 22);
          this.pictureBox3.Name = "pictureBox3";
          this.pictureBox3.Size = new System.Drawing.Size(89, 77);
          this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
          this.pictureBox3.TabIndex = 41;
          this.pictureBox3.TabStop = false;
          this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
          // 
          // pictureBox2
          // 
          this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
          this.pictureBox2.Image = global::DiffPress.Properties.Resources.Wrench;
          this.pictureBox2.Location = new System.Drawing.Point(48, 140);
          this.pictureBox2.Name = "pictureBox2";
          this.pictureBox2.Size = new System.Drawing.Size(89, 77);
          this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
          this.pictureBox2.TabIndex = 41;
          this.pictureBox2.TabStop = false;
          this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
          // 
          // label2
          // 
          this.label2.AutoSize = true;
          this.label2.Font = new System.Drawing.Font("Comic Sans MS", 12F);
          this.label2.Location = new System.Drawing.Point(44, 102);
          this.label2.Name = "label2";
          this.label2.Size = new System.Drawing.Size(94, 23);
          this.label2.TabIndex = 43;
          this.label2.Text = "Full Screen";
          this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
          // 
          // label1
          // 
          this.label1.AutoSize = true;
          this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F);
          this.label1.Location = new System.Drawing.Point(44, 220);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(71, 23);
          this.label1.TabIndex = 43;
          this.label1.Text = "Settings";
          this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
          // 
          // groupBox1
          // 
          this.groupBox1.Controls.Add(this.blueClock1);
          this.groupBox1.Controls.Add(this.lblClock);
          this.groupBox1.Location = new System.Drawing.Point(4, 134);
          this.groupBox1.Name = "groupBox1";
          this.groupBox1.Size = new System.Drawing.Size(207, 235);
          this.groupBox1.TabIndex = 44;
          this.groupBox1.TabStop = false;
          this.groupBox1.Text = "Clock";
          // 
          // blueClock1
          // 
          this.blueClock1.Day = 29;
          this.blueClock1.DisplayDate = true;
          this.blueClock1.DisplaySecond = true;
          this.blueClock1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F);
          this.blueClock1.Hour = 12;
          this.blueClock1.Location = new System.Drawing.Point(31, 19);
          this.blueClock1.Minute = 0;
          this.blueClock1.Month = 7;
          this.blueClock1.Name = "blueClock1";
          this.blueClock1.Second = 0;
          this.blueClock1.Size = new System.Drawing.Size(138, 138);
          this.blueClock1.TabIndex = 42;
          this.blueClock1.Text = "lunch time";
          // 
          // lblClock
          // 
          this.lblClock.AutoSize = true;
          this.lblClock.Font = new System.Drawing.Font("Comic Sans MS", 12F);
          this.lblClock.Location = new System.Drawing.Point(44, 174);
          this.lblClock.Name = "lblClock";
          this.lblClock.Size = new System.Drawing.Size(31, 23);
          this.lblClock.TabIndex = 43;
          this.lblClock.Text = "---";
          this.lblClock.TextAlign = System.Drawing.ContentAlignment.TopCenter;
          // 
          // pictureBox1
          // 
          this.pictureBox1.Image = global::DiffPress.Properties.Resources.delta_logo_full;
          this.pictureBox1.Location = new System.Drawing.Point(8, 68);
          this.pictureBox1.Name = "pictureBox1";
          this.pictureBox1.Size = new System.Drawing.Size(189, 50);
          this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
          this.pictureBox1.TabIndex = 41;
          this.pictureBox1.TabStop = false;
          this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
          // 
          // tmrBlink
          // 
          this.tmrBlink.Enabled = true;
          this.tmrBlink.Interval = 500;
          this.tmrBlink.Tick += new System.EventHandler(this.tmrBlink_Tick);
          // 
          // tmrUpdateGUI
          // 
          this.tmrUpdateGUI.Enabled = true;
          this.tmrUpdateGUI.Interval = 500;
          this.tmrUpdateGUI.Tick += new System.EventHandler(this.tmrUpdateGUI_Tick);
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
          this.dataGridView1.Location = new System.Drawing.Point(815, 379);
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
          this.dataGridView1.Size = new System.Drawing.Size(788, 154);
          this.dataGridView1.TabIndex = 65;
          // 
          // label5
          // 
          this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
          this.label5.Location = new System.Drawing.Point(237, 15);
          this.label5.Name = "label5";
          this.label5.Size = new System.Drawing.Size(1658, 34);
          this.label5.TabIndex = 66;
          this.label5.Text = "Система за следене влажност, температура и надналягане в помещенията на Fortex Nu" +
              "traceuticals";
          this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
          // 
          // pnlFloor1
          // 
          this.pnlFloor1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
          this.pnlFloor1.AutoScroll = true;
          this.pnlFloor1.AutoScrollMargin = new System.Drawing.Size(100, 10);
          this.pnlFloor1.BackColor = System.Drawing.Color.Gainsboro;
          this.pnlFloor1.Location = new System.Drawing.Point(238, 62);
          this.pnlFloor1.Name = "pnlFloor1";
          this.pnlFloor1.Size = new System.Drawing.Size(1641, 219);
          this.pnlFloor1.TabIndex = 67;
          // 
          // line1
          // 
          this.line1.BorderColor = System.Drawing.SystemColors.ControlText;
          this.line1.Dark3dColor = System.Drawing.SystemColors.ControlDark;
          this.line1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
          this.line1.Light3dColor = System.Drawing.SystemColors.ControlLightLight;
          this.line1.Location = new System.Drawing.Point(100, 20);
          this.line1.Name = "line1";
          this.line1.Orientation = Unclassified.UI.LineOrientation.Vertical;
          this.line1.Size = new System.Drawing.Size(1, 98);
          this.line1.TabIndex = 5;
          this.line1.TabStop = false;
          // 
          // line3
          // 
          this.line3.BorderColor = System.Drawing.SystemColors.ControlText;
          this.line3.Dark3dColor = System.Drawing.SystemColors.ControlDark;
          this.line3.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
          this.line3.Light3dColor = System.Drawing.SystemColors.ControlLightLight;
          this.line3.Location = new System.Drawing.Point(9, 92);
          this.line3.Name = "line3";
          this.line3.Size = new System.Drawing.Size(188, 2);
          this.line3.TabIndex = 6;
          this.line3.TabStop = false;
          // 
          // line2
          // 
          this.line2.BorderColor = System.Drawing.SystemColors.ControlText;
          this.line2.Dark3dColor = System.Drawing.SystemColors.ControlDark;
          this.line2.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
          this.line2.Light3dColor = System.Drawing.SystemColors.ControlLightLight;
          this.line2.Location = new System.Drawing.Point(8, 70);
          this.line2.Name = "line2";
          this.line2.Size = new System.Drawing.Size(188, 2);
          this.line2.TabIndex = 6;
          this.line2.TabStop = false;
          // 
          // frmMain
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.AutoScroll = true;
          this.BackColor = System.Drawing.Color.White;
          this.ClientSize = new System.Drawing.Size(1370, 750);
          this.Controls.Add(this.pnlFloor1);
          this.Controls.Add(this.label5);
          this.Controls.Add(this.dataGridView1);
          this.Controls.Add(this.pnlMenu);
          this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
          this.Name = "frmMain";
          this.Text = "Differential Pressure";
          this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
          this.Load += new System.EventHandler(this.Form1_Load);
          this.pnlMenu.ResumeLayout(false);
          this.grbStatus.ResumeLayout(false);
          this.grbStatus.PerformLayout();
          this.groupBox2.ResumeLayout(false);
          this.groupBox2.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
          this.groupBox1.ResumeLayout(false);
          this.groupBox1.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
          this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Timer tmrBlink;
        private System.Windows.Forms.Timer tmrUpdateGUI;
        private MfgControl.AdvancedHMI.Controls.BlueClock blueClock1;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox grbStatus;
        private System.Windows.Forms.Label lblRemain;
        private System.Windows.Forms.Label label3;
        private Unclassified.UI.Line line1;
        private Unclassified.UI.Line line2;
        private Unclassified.UI.Line line3;
        private System.Windows.Forms.Label lblComm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlFloor1;
        
    }
}

