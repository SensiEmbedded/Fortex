namespace DiffPress {
  partial class frmAbout {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
      this.pbDelta = new System.Windows.Forms.PictureBox();
      this.pbFortex = new System.Windows.Forms.PictureBox();
      this.txtInfo = new System.Windows.Forms.TextBox();
      this.lblNames = new System.Windows.Forms.Label();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.label1 = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      ((System.ComponentModel.ISupportInitialize)(this.pbDelta)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbFortex)).BeginInit();
      this.SuspendLayout();
      // 
      // pbDelta
      // 
      this.pbDelta.Image = global::DiffPress.Properties.Resources.delta_logo_full;
      this.pbDelta.Location = new System.Drawing.Point(11, 15);
      this.pbDelta.Name = "pbDelta";
      this.pbDelta.Size = new System.Drawing.Size(195, 57);
      this.pbDelta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pbDelta.TabIndex = 43;
      this.pbDelta.TabStop = false;
      // 
      // pbFortex
      // 
      this.pbFortex.BackColor = System.Drawing.SystemColors.ActiveCaption;
      this.pbFortex.Image = global::DiffPress.Properties.Resources.logoFrotex;
      this.pbFortex.Location = new System.Drawing.Point(214, 14);
      this.pbFortex.Name = "pbFortex";
      this.pbFortex.Size = new System.Drawing.Size(191, 57);
      this.pbFortex.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pbFortex.TabIndex = 42;
      this.pbFortex.TabStop = false;
      // 
      // txtInfo
      // 
      this.txtInfo.Location = new System.Drawing.Point(11, 147);
      this.txtInfo.Multiline = true;
      this.txtInfo.Name = "txtInfo";
      this.txtInfo.ReadOnly = true;
      this.txtInfo.Size = new System.Drawing.Size(391, 146);
      this.txtInfo.TabIndex = 44;
      this.txtInfo.Text = resources.GetString("txtInfo.Text");
      // 
      // lblNames
      // 
      this.lblNames.AutoSize = true;
      this.lblNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblNames.Location = new System.Drawing.Point(84, 122);
      this.lblNames.Name = "lblNames";
      this.lblNames.Size = new System.Drawing.Size(77, 13);
      this.lblNames.TabIndex = 45;
      this.lblNames.Text = "Асен Янков";
      // 
      // timer1
      // 
      this.timer1.Enabled = true;
      this.timer1.Interval = 700;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 122);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(70, 13);
      this.label1.TabIndex = 46;
      this.label1.Text = "Разработка:";
      // 
      // groupBox1
      // 
      this.groupBox1.Location = new System.Drawing.Point(12, 91);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(393, 8);
      this.groupBox1.TabIndex = 47;
      this.groupBox1.TabStop = false;
      // 
      // frmAbout
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(420, 312);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.lblNames);
      this.Controls.Add(this.txtInfo);
      this.Controls.Add(this.pbDelta);
      this.Controls.Add(this.pbFortex);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.KeyPreview = true;
      this.Name = "frmAbout";
      this.Text = "About Fortex Software";
      this.Load += new System.EventHandler(this.frmAbout_Load);
      ((System.ComponentModel.ISupportInitialize)(this.pbDelta)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbFortex)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox pbFortex;
    private System.Windows.Forms.PictureBox pbDelta;
    private System.Windows.Forms.TextBox txtInfo;
    private System.Windows.Forms.Label lblNames;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.GroupBox groupBox1;
  }
}