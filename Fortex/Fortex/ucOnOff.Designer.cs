namespace DiffPress {
  partial class ucOnOff {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucOnOff));
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.lblOnOff = new System.Windows.Forms.Label();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // imageList1
      // 
      this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
      this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
      this.imageList1.Images.SetKeyName(0, "on-off-switch-th.png");
      this.imageList1.Images.SetKeyName(1, "power-button-th.png");
      // 
      // lblOnOff
      // 
      this.lblOnOff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblOnOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblOnOff.Location = new System.Drawing.Point(2, 100);
      this.lblOnOff.Name = "lblOnOff";
      this.lblOnOff.Size = new System.Drawing.Size(69, 25);
      this.lblOnOff.TabIndex = 1;
      this.lblOnOff.Text = "Off";
      this.lblOnOff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // pictureBox1
      // 
      this.pictureBox1.Location = new System.Drawing.Point(1, 1);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(70, 99);
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
      // 
      // ucOnOff
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.lblOnOff);
      this.Controls.Add(this.pictureBox1);
      this.Name = "ucOnOff";
      this.Size = new System.Drawing.Size(74, 128);
      this.Load += new System.EventHandler(this.ucOnOff_Load);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.ImageList imageList1;
    private System.Windows.Forms.Label lblOnOff;
  }
}
