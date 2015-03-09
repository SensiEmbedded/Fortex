namespace DiffPress {
  partial class ucRHTRealTime {
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
      this.lblUp = new System.Windows.Forms.Label();
      this.lblTemp = new System.Windows.Forms.Label();
      this.lblRH = new System.Windows.Forms.Label();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.lblID = new System.Windows.Forms.Label();
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
      this.lblUp.Size = new System.Drawing.Size(84, 32);
      this.lblUp.TabIndex = 0;
      this.lblUp.Text = "T °C\r\nRH %";
      this.lblUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.lblUp.Click += new System.EventHandler(this.ucRHTRealTime_Click);
      // 
      // lblTemp
      // 
      this.lblTemp.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblTemp.ForeColor = System.Drawing.SystemColors.ActiveCaption;
      this.lblTemp.Location = new System.Drawing.Point(0, 32);
      this.lblTemp.Name = "lblTemp";
      this.lblTemp.Size = new System.Drawing.Size(84, 33);
      this.lblTemp.TabIndex = 3;
      this.lblTemp.Text = "--.-";
      this.lblTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.lblTemp.Click += new System.EventHandler(this.ucRHTRealTime_Click);
      // 
      // lblRH
      // 
      this.lblRH.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblRH.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblRH.ForeColor = System.Drawing.SystemColors.ActiveCaption;
      this.lblRH.Location = new System.Drawing.Point(0, 65);
      this.lblRH.Name = "lblRH";
      this.lblRH.Size = new System.Drawing.Size(84, 36);
      this.lblRH.TabIndex = 3;
      this.lblRH.Text = "--.-";
      this.lblRH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.lblRH.Click += new System.EventHandler(this.ucRHTRealTime_Click);
      // 
      // timer1
      // 
      this.timer1.Enabled = true;
      this.timer1.Interval = 1000;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // lblID
      // 
      this.lblID.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblID.Location = new System.Drawing.Point(0, 100);
      this.lblID.Name = "lblID";
      this.lblID.Size = new System.Drawing.Size(84, 15);
      this.lblID.TabIndex = 4;
      this.lblID.Text = "floor1.1";
      this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.lblID.DoubleClick += new System.EventHandler(this.lblID_DoubleClick);
      // 
      // ucRHTRealTime
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.lblID);
      this.Controls.Add(this.lblRH);
      this.Controls.Add(this.lblTemp);
      this.Controls.Add(this.lblUp);
      this.Name = "ucRHTRealTime";
      this.Size = new System.Drawing.Size(84, 115);
      this.Load += new System.EventHandler(this.ucRHTRealTime_Load);
      this.Click += new System.EventHandler(this.ucRHTRealTime_Click);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label lblUp;
    private System.Windows.Forms.Label lblTemp;
    private System.Windows.Forms.Label lblRH;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.Label lblID;
  }
}
