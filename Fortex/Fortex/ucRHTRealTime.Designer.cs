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
      this.pbRH = new System.Windows.Forms.ProgressBar();
      this.pbTemp = new System.Windows.Forms.ProgressBar();
      this.lblTemp = new System.Windows.Forms.Label();
      this.lblRH = new System.Windows.Forms.Label();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
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
      this.lblUp.Size = new System.Drawing.Size(116, 23);
      this.lblUp.TabIndex = 0;
      this.lblUp.Text = "RH&&T";
      this.lblUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // pbRH
      // 
      this.pbRH.Dock = System.Windows.Forms.DockStyle.Top;
      this.pbRH.Location = new System.Drawing.Point(0, 23);
      this.pbRH.Name = "pbRH";
      this.pbRH.Size = new System.Drawing.Size(116, 11);
      this.pbRH.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
      this.pbRH.TabIndex = 1;
      this.pbRH.Value = 60;
      // 
      // pbTemp
      // 
      this.pbTemp.Dock = System.Windows.Forms.DockStyle.Top;
      this.pbTemp.Location = new System.Drawing.Point(0, 34);
      this.pbTemp.Name = "pbTemp";
      this.pbTemp.Size = new System.Drawing.Size(116, 11);
      this.pbTemp.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
      this.pbTemp.TabIndex = 2;
      this.pbTemp.Value = 40;
      // 
      // lblTemp
      // 
      this.lblTemp.AutoSize = true;
      this.lblTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblTemp.ForeColor = System.Drawing.SystemColors.ActiveCaption;
      this.lblTemp.Location = new System.Drawing.Point(0, 61);
      this.lblTemp.Name = "lblTemp";
      this.lblTemp.Size = new System.Drawing.Size(101, 33);
      this.lblTemp.TabIndex = 3;
      this.lblTemp.Text = "--.- °C";
      this.lblTemp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // lblRH
      // 
      this.lblRH.AutoSize = true;
      this.lblRH.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblRH.ForeColor = System.Drawing.SystemColors.ActiveCaption;
      this.lblRH.Location = new System.Drawing.Point(0, 94);
      this.lblRH.Name = "lblRH";
      this.lblRH.Size = new System.Drawing.Size(93, 33);
      this.lblRH.TabIndex = 3;
      this.lblRH.Text = "--.- %";
      this.lblRH.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // timer1
      // 
      this.timer1.Enabled = true;
      this.timer1.Interval = 1000;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // ucRHTRealTime
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.lblRH);
      this.Controls.Add(this.lblTemp);
      this.Controls.Add(this.pbTemp);
      this.Controls.Add(this.pbRH);
      this.Controls.Add(this.lblUp);
      this.Name = "ucRHTRealTime";
      this.Size = new System.Drawing.Size(116, 214);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblUp;
    private System.Windows.Forms.ProgressBar pbRH;
    private System.Windows.Forms.ProgressBar pbTemp;
    private System.Windows.Forms.Label lblTemp;
    private System.Windows.Forms.Label lblRH;
    private System.Windows.Forms.Timer timer1;
  }
}
