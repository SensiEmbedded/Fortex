namespace DiffPress {
  partial class frmSetMM {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetMM));
      this.btnReadAll = new System.Windows.Forms.Button();
      this.txtHowManyMM1 = new System.Windows.Forms.TextBox();
      this.txtHowManyMM2 = new System.Windows.Forms.TextBox();
      this.txtHowManyMM3 = new System.Windows.Forms.TextBox();
      this.btnSetMM1 = new System.Windows.Forms.Button();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.btnsetMM2 = new System.Windows.Forms.Button();
      this.btnSetMM3 = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btnReadAll
      // 
      this.btnReadAll.Location = new System.Drawing.Point(17, 200);
      this.btnReadAll.Name = "btnReadAll";
      this.btnReadAll.Size = new System.Drawing.Size(107, 51);
      this.btnReadAll.TabIndex = 0;
      this.btnReadAll.Text = "Read All";
      this.btnReadAll.UseVisualStyleBackColor = true;
      this.btnReadAll.Click += new System.EventHandler(this.btnReadAll_Click);
      // 
      // txtHowManyMM1
      // 
      this.txtHowManyMM1.Location = new System.Drawing.Point(358, 170);
      this.txtHowManyMM1.Name = "txtHowManyMM1";
      this.txtHowManyMM1.Size = new System.Drawing.Size(105, 20);
      this.txtHowManyMM1.TabIndex = 1;
      // 
      // txtHowManyMM2
      // 
      this.txtHowManyMM2.Location = new System.Drawing.Point(357, 206);
      this.txtHowManyMM2.Name = "txtHowManyMM2";
      this.txtHowManyMM2.Size = new System.Drawing.Size(105, 20);
      this.txtHowManyMM2.TabIndex = 1;
      // 
      // txtHowManyMM3
      // 
      this.txtHowManyMM3.Location = new System.Drawing.Point(357, 242);
      this.txtHowManyMM3.Name = "txtHowManyMM3";
      this.txtHowManyMM3.Size = new System.Drawing.Size(105, 20);
      this.txtHowManyMM3.TabIndex = 1;
      // 
      // btnSetMM1
      // 
      this.btnSetMM1.Location = new System.Drawing.Point(262, 170);
      this.btnSetMM1.Name = "btnSetMM1";
      this.btnSetMM1.Size = new System.Drawing.Size(68, 21);
      this.btnSetMM1.TabIndex = 2;
      this.btnSetMM1.Text = "Set MM1";
      this.btnSetMM1.UseVisualStyleBackColor = true;
      this.btnSetMM1.Click += new System.EventHandler(this.btnSetMM1_Click);
      // 
      // textBox1
      // 
      this.textBox1.ForeColor = System.Drawing.Color.Red;
      this.textBox1.Location = new System.Drawing.Point(15, 18);
      this.textBox1.Multiline = true;
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(640, 126);
      this.textBox1.TabIndex = 3;
      this.textBox1.Text = resources.GetString("textBox1.Text");
      // 
      // btnsetMM2
      // 
      this.btnsetMM2.Location = new System.Drawing.Point(263, 206);
      this.btnsetMM2.Name = "btnsetMM2";
      this.btnsetMM2.Size = new System.Drawing.Size(68, 21);
      this.btnsetMM2.TabIndex = 4;
      this.btnsetMM2.Text = "Set MM2";
      this.btnsetMM2.UseVisualStyleBackColor = true;
      this.btnsetMM2.Click += new System.EventHandler(this.btnsetMM2_Click);
      // 
      // btnSetMM3
      // 
      this.btnSetMM3.Location = new System.Drawing.Point(262, 242);
      this.btnSetMM3.Name = "btnSetMM3";
      this.btnSetMM3.Size = new System.Drawing.Size(68, 21);
      this.btnSetMM3.TabIndex = 5;
      this.btnSetMM3.Text = "Set MM3";
      this.btnSetMM3.UseVisualStyleBackColor = true;
      this.btnSetMM3.Click += new System.EventHandler(this.btnSetMM3_Click);
      // 
      // frmSetMM
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(699, 326);
      this.Controls.Add(this.btnSetMM3);
      this.Controls.Add(this.btnsetMM2);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.btnSetMM1);
      this.Controls.Add(this.txtHowManyMM3);
      this.Controls.Add(this.txtHowManyMM2);
      this.Controls.Add(this.txtHowManyMM1);
      this.Controls.Add(this.btnReadAll);
      this.Name = "frmSetMM";
      this.Text = "frmSetMM";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnReadAll;
    private System.Windows.Forms.TextBox txtHowManyMM1;
    private System.Windows.Forms.TextBox txtHowManyMM2;
    private System.Windows.Forms.TextBox txtHowManyMM3;
    private System.Windows.Forms.Button btnSetMM1;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Button btnsetMM2;
    private System.Windows.Forms.Button btnSetMM3;
  }
}