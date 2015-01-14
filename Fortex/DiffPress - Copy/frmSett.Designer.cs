namespace DiffPress {
  partial class frmSett {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSett));
      this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
      this.button1 = new System.Windows.Forms.Button();
      this.btnClose = new System.Windows.Forms.Button();
      this.btnTestConnection = new System.Windows.Forms.Button();
      this.btnDefault = new System.Windows.Forms.Button();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.pictureBox4 = new System.Windows.Forms.PictureBox();
      this.pictureBox3 = new System.Windows.Forms.PictureBox();
      this.pictureBox2 = new System.Windows.Forms.PictureBox();
      this.button2 = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
      this.SuspendLayout();
      // 
      // propertyGrid1
      // 
      this.propertyGrid1.Location = new System.Drawing.Point(130, 12);
      this.propertyGrid1.Name = "propertyGrid1";
      this.propertyGrid1.Size = new System.Drawing.Size(792, 600);
      this.propertyGrid1.TabIndex = 41;
      // 
      // button1
      // 
      this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
      this.button1.Location = new System.Drawing.Point(12, 12);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(100, 62);
      this.button1.TabIndex = 42;
      this.button1.Text = "Save";
      this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // btnClose
      // 
      this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnClose.Location = new System.Drawing.Point(12, 86);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(100, 62);
      this.btnClose.TabIndex = 42;
      this.btnClose.Text = "Close";
      this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnClose.UseVisualStyleBackColor = true;
      this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
      // 
      // btnTestConnection
      // 
      this.btnTestConnection.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnTestConnection.Location = new System.Drawing.Point(13, 234);
      this.btnTestConnection.Name = "btnTestConnection";
      this.btnTestConnection.Size = new System.Drawing.Size(100, 62);
      this.btnTestConnection.TabIndex = 42;
      this.btnTestConnection.Text = "test \r\nSQL\r\nConn";
      this.btnTestConnection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnTestConnection.UseVisualStyleBackColor = true;
      this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
      // 
      // btnDefault
      // 
      this.btnDefault.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnDefault.Location = new System.Drawing.Point(13, 159);
      this.btnDefault.Name = "btnDefault";
      this.btnDefault.Size = new System.Drawing.Size(100, 62);
      this.btnDefault.TabIndex = 42;
      this.btnDefault.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnDefault.UseVisualStyleBackColor = true;
      this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
      // 
      // pictureBox1
      // 
      this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
      this.pictureBox1.Image = global::DiffPress.Properties.Resources.Save;
      this.pictureBox1.InitialImage = global::DiffPress.Properties.Resources.delta_logo_full;
      this.pictureBox1.Location = new System.Drawing.Point(21, 20);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(45, 47);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 43;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.Click += new System.EventHandler(this.button1_Click);
      // 
      // pictureBox4
      // 
      this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
      this.pictureBox4.Image = global::DiffPress.Properties.Resources._default;
      this.pictureBox4.InitialImage = global::DiffPress.Properties.Resources.delta_logo_full;
      this.pictureBox4.Location = new System.Drawing.Point(21, 165);
      this.pictureBox4.Name = "pictureBox4";
      this.pictureBox4.Size = new System.Drawing.Size(70, 47);
      this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox4.TabIndex = 43;
      this.pictureBox4.TabStop = false;
      this.pictureBox4.Click += new System.EventHandler(this.btnDefault_Click);
      // 
      // pictureBox3
      // 
      this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
      this.pictureBox3.Image = global::DiffPress.Properties.Resources.Database;
      this.pictureBox3.InitialImage = global::DiffPress.Properties.Resources.delta_logo_full;
      this.pictureBox3.Location = new System.Drawing.Point(21, 240);
      this.pictureBox3.Name = "pictureBox3";
      this.pictureBox3.Size = new System.Drawing.Size(45, 47);
      this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox3.TabIndex = 43;
      this.pictureBox3.TabStop = false;
      this.pictureBox3.Click += new System.EventHandler(this.btnTestConnection_Click);
      // 
      // pictureBox2
      // 
      this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
      this.pictureBox2.Image = global::DiffPress.Properties.Resources.Close;
      this.pictureBox2.InitialImage = global::DiffPress.Properties.Resources.delta_logo_full;
      this.pictureBox2.Location = new System.Drawing.Point(20, 92);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new System.Drawing.Size(45, 47);
      this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox2.TabIndex = 43;
      this.pictureBox2.TabStop = false;
      this.pictureBox2.Click += new System.EventHandler(this.btnClose_Click);
      // 
      // button2
      // 
      this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
      this.button2.Location = new System.Drawing.Point(15, 324);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(100, 62);
      this.button2.TabIndex = 42;
      this.button2.Text = "test \r\nSQL\r\nConn";
      this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // frmSett
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnClose;
      this.ClientSize = new System.Drawing.Size(934, 633);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.pictureBox4);
      this.Controls.Add(this.pictureBox3);
      this.Controls.Add(this.pictureBox2);
      this.Controls.Add(this.btnDefault);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.btnTestConnection);
      this.Controls.Add(this.btnClose);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.propertyGrid1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "frmSett";
      this.Text = "frmSett";
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PropertyGrid propertyGrid1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.PictureBox pictureBox2;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Button btnTestConnection;
    private System.Windows.Forms.PictureBox pictureBox3;
    private System.Windows.Forms.Button btnDefault;
    private System.Windows.Forms.PictureBox pictureBox4;
    private System.Windows.Forms.Button button2;
  }
}