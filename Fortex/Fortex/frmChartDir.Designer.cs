namespace DiffPress {
  partial class frmChartDir {
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
      this.ucChartDir1 = new DiffPress.ucChartDir();
      this.SuspendLayout();
      // 
      // ucChartDir1
      // 
      this.ucChartDir1.cdev = null;
      this.ucChartDir1.Location = new System.Drawing.Point(10, 15);
      this.ucChartDir1.Name = "ucChartDir1";
      this.ucChartDir1.Size = new System.Drawing.Size(1084, 707);
      this.ucChartDir1.TabIndex = 47;
      // 
      // frmChartDir
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1112, 762);
      this.Controls.Add(this.ucChartDir1);
      this.Name = "frmChartDir";
      this.Text = "frmChartDir";
      this.Load += new System.EventHandler(this.frmChartDir_Load);
      this.ResumeLayout(false);

    }

    #endregion

    private ucChartDir ucChartDir1;
  }
}