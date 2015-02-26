namespace DiffPress {
  partial class frmEmails {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmails));
      this.txtHost = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.pictureBox5 = new System.Windows.Forms.PictureBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtPort = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.txtFrom = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.txtUser = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.txtPassword = new System.Windows.Forms.TextBox();
      this.cbUseSSL = new System.Windows.Forms.CheckBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.btnSetDefaults = new System.Windows.Forms.Button();
      this.btnTest = new System.Windows.Forms.Button();
      this.pictureBox2 = new System.Windows.Forms.PictureBox();
      this.btnClose = new System.Windows.Forms.Button();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.btnSave = new System.Windows.Forms.Button();
      this.txtTestEmail = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // txtHost
      // 
      this.txtHost.Location = new System.Drawing.Point(13, 41);
      this.txtHost.Name = "txtHost";
      this.txtHost.Size = new System.Drawing.Size(111, 20);
      this.txtHost.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(13, 24);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(29, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Host";
      // 
      // pictureBox5
      // 
      this.pictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.pictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
      this.pictureBox5.Image = global::DiffPress.Properties.Resources.email;
      this.pictureBox5.InitialImage = global::DiffPress.Properties.Resources.delta_logo_full;
      this.pictureBox5.Location = new System.Drawing.Point(660, 7);
      this.pictureBox5.Name = "pictureBox5";
      this.pictureBox5.Size = new System.Drawing.Size(46, 47);
      this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox5.TabIndex = 47;
      this.pictureBox5.TabStop = false;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(13, 66);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(26, 13);
      this.label2.TabIndex = 49;
      this.label2.Text = "Port";
      // 
      // txtPort
      // 
      this.txtPort.Location = new System.Drawing.Point(13, 83);
      this.txtPort.Name = "txtPort";
      this.txtPort.Size = new System.Drawing.Size(111, 20);
      this.txtPort.TabIndex = 48;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(13, 109);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(57, 13);
      this.label3.TabIndex = 51;
      this.label3.Text = "From email";
      // 
      // txtFrom
      // 
      this.txtFrom.Location = new System.Drawing.Point(13, 126);
      this.txtFrom.Name = "txtFrom";
      this.txtFrom.Size = new System.Drawing.Size(111, 20);
      this.txtFrom.TabIndex = 50;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(13, 159);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(27, 13);
      this.label4.TabIndex = 53;
      this.label4.Text = "user";
      // 
      // txtUser
      // 
      this.txtUser.Location = new System.Drawing.Point(13, 176);
      this.txtUser.Name = "txtUser";
      this.txtUser.Size = new System.Drawing.Size(111, 20);
      this.txtUser.TabIndex = 52;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(13, 209);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(53, 13);
      this.label5.TabIndex = 55;
      this.label5.Text = "Password";
      // 
      // txtPassword
      // 
      this.txtPassword.Location = new System.Drawing.Point(13, 226);
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.Size = new System.Drawing.Size(111, 20);
      this.txtPassword.TabIndex = 54;
      // 
      // cbUseSSL
      // 
      this.cbUseSSL.AutoSize = true;
      this.cbUseSSL.Location = new System.Drawing.Point(13, 268);
      this.cbUseSSL.Name = "cbUseSSL";
      this.cbUseSSL.Size = new System.Drawing.Size(68, 17);
      this.cbUseSSL.TabIndex = 57;
      this.cbUseSSL.Text = "Use SSL";
      this.cbUseSSL.UseVisualStyleBackColor = true;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.btnSetDefaults);
      this.groupBox1.Controls.Add(this.cbUseSSL);
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Controls.Add(this.txtPassword);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Controls.Add(this.txtUser);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.txtFrom);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.txtPort);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.txtHost);
      this.groupBox1.Location = new System.Drawing.Point(3, 6);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(154, 357);
      this.groupBox1.TabIndex = 58;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Email Settings";
      // 
      // btnSetDefaults
      // 
      this.btnSetDefaults.Location = new System.Drawing.Point(9, 314);
      this.btnSetDefaults.Name = "btnSetDefaults";
      this.btnSetDefaults.Size = new System.Drawing.Size(75, 29);
      this.btnSetDefaults.TabIndex = 58;
      this.btnSetDefaults.Text = "Set Defaults";
      this.btnSetDefaults.UseVisualStyleBackColor = true;
      this.btnSetDefaults.Click += new System.EventHandler(this.btnSetDefaults_Click);
      // 
      // btnTest
      // 
      this.btnTest.Location = new System.Drawing.Point(240, 177);
      this.btnTest.Name = "btnTest";
      this.btnTest.Size = new System.Drawing.Size(70, 40);
      this.btnTest.TabIndex = 59;
      this.btnTest.Text = "Test\r\nSend email";
      this.btnTest.UseVisualStyleBackColor = true;
      this.btnTest.Click += new System.EventHandler(this.button1_Click);
      // 
      // pictureBox2
      // 
      this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
      this.pictureBox2.Image = global::DiffPress.Properties.Resources.Close;
      this.pictureBox2.InitialImage = global::DiffPress.Properties.Resources.delta_logo_full;
      this.pictureBox2.Location = new System.Drawing.Point(16, 432);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new System.Drawing.Size(45, 47);
      this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox2.TabIndex = 61;
      this.pictureBox2.TabStop = false;
      // 
      // btnClose
      // 
      this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnClose.Location = new System.Drawing.Point(7, 424);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(117, 62);
      this.btnClose.TabIndex = 60;
      this.btnClose.Text = "Close";
      this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnClose.UseVisualStyleBackColor = true;
      this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
      // 
      // pictureBox1
      // 
      this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
      this.pictureBox1.Image = global::DiffPress.Properties.Resources.Save;
      this.pictureBox1.InitialImage = global::DiffPress.Properties.Resources.delta_logo_full;
      this.pictureBox1.Location = new System.Drawing.Point(169, 431);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(45, 47);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 63;
      this.pictureBox1.TabStop = false;
      // 
      // btnSave
      // 
      this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnSave.Location = new System.Drawing.Point(161, 425);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(117, 62);
      this.btnSave.TabIndex = 62;
      this.btnSave.Text = "Save";
      this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
      // 
      // txtTestEmail
      // 
      this.txtTestEmail.Location = new System.Drawing.Point(318, 191);
      this.txtTestEmail.Name = "txtTestEmail";
      this.txtTestEmail.Size = new System.Drawing.Size(168, 20);
      this.txtTestEmail.TabIndex = 64;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(317, 172);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(58, 13);
      this.label6.TabIndex = 59;
      this.label6.Text = "Test email:";
      // 
      // frmEmails
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(711, 505);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.txtTestEmail);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.btnSave);
      this.Controls.Add(this.pictureBox2);
      this.Controls.Add(this.btnClose);
      this.Controls.Add(this.btnTest);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.pictureBox5);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "frmEmails";
      this.Text = "Email Settings";
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtHost;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.PictureBox pictureBox5;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtPort;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtFrom;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtUser;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.CheckBox cbUseSSL;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button btnSetDefaults;
    private System.Windows.Forms.Button btnTest;
    private System.Windows.Forms.PictureBox pictureBox2;
    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.TextBox txtTestEmail;
    private System.Windows.Forms.Label label6;
  }
}