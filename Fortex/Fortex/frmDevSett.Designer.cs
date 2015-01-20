namespace DiffPress {
  partial class frmDevSett {
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
      this.label6 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.cmbType = new System.Windows.Forms.ComboBox();
      this.txtName = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(29, 147);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(56, 13);
      this.label6.TabIndex = 4;
      this.label6.Text = "AlarmLow:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(29, 125);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(58, 13);
      this.label4.TabIndex = 5;
      this.label4.Text = "AlarmHigh:";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(40, 174);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(43, 13);
      this.label8.TabIndex = 6;
      this.label8.Text = "Enable:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(40, 69);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(38, 13);
      this.label3.TabIndex = 3;
      this.label3.Text = "Name:";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(45, 28);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(34, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Type:";
      // 
      // cmbType
      // 
      this.cmbType.AutoCompleteCustomSource.AddRange(new string[] {
            "Not Set",
            "RH & T",
            "Diff Press"});
      this.cmbType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cmbType.FormattingEnabled = true;
      this.cmbType.Items.AddRange(new object[] {
            "Not Set",
            "RH & T",
            "Diff Press"});
      this.cmbType.Location = new System.Drawing.Point(108, 27);
      this.cmbType.Name = "cmbType";
      this.cmbType.Size = new System.Drawing.Size(133, 21);
      this.cmbType.TabIndex = 7;
      this.cmbType.Text = "Not Set";
      // 
      // txtName
      // 
      this.txtName.Location = new System.Drawing.Point(108, 61);
      this.txtName.Name = "txtName";
      this.txtName.Size = new System.Drawing.Size(134, 20);
      this.txtName.TabIndex = 8;
      // 
      // frmDevSett
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(437, 352);
      this.Controls.Add(this.txtName);
      this.Controls.Add(this.cmbType);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label1);
      this.Name = "frmDevSett";
      this.Text = "frmDevSett";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox cmbType;
    private System.Windows.Forms.TextBox txtName;
  }
}