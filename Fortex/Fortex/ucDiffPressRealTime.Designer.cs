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
      this.lblUp = new System.Windows.Forms.Label();
      this.lblDiff = new System.Windows.Forms.Label();
      this.pbTemp = new System.Windows.Forms.ProgressBar();
      this.pbRH = new System.Windows.Forms.ProgressBar();
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
      this.lblDiff.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblDiff.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblDiff.ForeColor = System.Drawing.SystemColors.ActiveCaption;
      this.lblDiff.Location = new System.Drawing.Point(0, 54);
      this.lblDiff.Name = "lblDiff";
      this.lblDiff.Size = new System.Drawing.Size(84, 33);
      this.lblDiff.TabIndex = 7;
      this.lblDiff.Text = "--.-  ";
      this.lblDiff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // pbTemp
      // 
      this.pbTemp.Dock = System.Windows.Forms.DockStyle.Top;
      this.pbTemp.Location = new System.Drawing.Point(0, 43);
      this.pbTemp.Name = "pbTemp";
      this.pbTemp.Size = new System.Drawing.Size(84, 11);
      this.pbTemp.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
      this.pbTemp.TabIndex = 5;
      this.pbTemp.Value = 40;
      // 
      // pbRH
      // 
      this.pbRH.Dock = System.Windows.Forms.DockStyle.Top;
      this.pbRH.Location = new System.Drawing.Point(0, 32);
      this.pbRH.Name = "pbRH";
      this.pbRH.Size = new System.Drawing.Size(84, 11);
      this.pbRH.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
      this.pbRH.TabIndex = 4;
      this.pbRH.Value = 60;
      // 
      // ucDiffPressRealTime
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.lblDiff);
      this.Controls.Add(this.pbTemp);
      this.Controls.Add(this.pbRH);
      this.Controls.Add(this.lblUp);
      this.Name = "ucDiffPressRealTime";
      this.Size = new System.Drawing.Size(84, 178);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label lblUp;
    private System.Windows.Forms.Label lblDiff;
    private System.Windows.Forms.ProgressBar pbTemp;
    private System.Windows.Forms.ProgressBar pbRH;
  }
}
