namespace DiffPress {
  partial class ucDiffPressRealTime {
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
      this.lblDiff = new System.Windows.Forms.Label();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.SuspendLayout();
      // 
      // lblUp
      // 
      this.lblUp.BackColor = System.Drawing.Color.Olive;
      this.lblUp.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblUp.ForeColor = System.Drawing.SystemColors.Desktop;
      this.lblUp.Location = new System.Drawing.Point(0, 0);
      this.lblUp.Name = "lblUp";
      this.lblUp.Size = new System.Drawing.Size(84, 32);
      this.lblUp.TabIndex = 1;
      this.lblUp.Text = "Diff. Pressure-PA";
      this.lblUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lblDiff
      // 
      this.lblDiff.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblDiff.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblDiff.ForeColor = System.Drawing.SystemColors.ActiveCaption;
      this.lblDiff.Location = new System.Drawing.Point(0, 32);
      this.lblDiff.Name = "lblDiff";
      this.lblDiff.Size = new System.Drawing.Size(84, 83);
      this.lblDiff.TabIndex = 7;
      this.lblDiff.Text = "--.-  ";
      this.lblDiff.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      this.lblDiff.Click += new System.EventHandler(this.ucDiffPressRealTime_Click);
      // 
      // timer1
      // 
      this.timer1.Enabled = true;
      this.timer1.Interval = 1000;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // ucDiffPressRealTime
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.lblDiff);
      this.Controls.Add(this.lblUp);
      this.Name = "ucDiffPressRealTime";
      this.Size = new System.Drawing.Size(84, 115);
      this.Click += new System.EventHandler(this.ucDiffPressRealTime_Click);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label lblUp;
    private System.Windows.Forms.Label lblDiff;
    private System.Windows.Forms.Timer timer1;
  }
}
