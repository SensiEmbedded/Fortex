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
      this.lblTemp = new System.Windows.Forms.Label();
      this.lblRH = new System.Windows.Forms.Label();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.historyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.chartDirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // lblUp
      // 
      this.lblUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
      this.lblUp.ContextMenuStrip = this.contextMenuStrip1;
      this.lblUp.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblUp.ForeColor = System.Drawing.SystemColors.Desktop;
      this.lblUp.Location = new System.Drawing.Point(0, 0);
      this.lblUp.Name = "lblUp";
      this.lblUp.Size = new System.Drawing.Size(84, 32);
      this.lblUp.TabIndex = 0;
      this.lblUp.Text = "T °C\r\nRH %";
      this.lblUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.lblUp.Click += new System.EventHandler(this.ucRHTRealTime_Click);
      // 
      // lblTemp
      // 
      this.lblTemp.ContextMenuStrip = this.contextMenuStrip1;
      this.lblTemp.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblTemp.ForeColor = System.Drawing.SystemColors.ActiveCaption;
      this.lblTemp.Location = new System.Drawing.Point(0, 32);
      this.lblTemp.Name = "lblTemp";
      this.lblTemp.Size = new System.Drawing.Size(84, 33);
      this.lblTemp.TabIndex = 3;
      this.lblTemp.Text = "--.-";
      this.lblTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.lblTemp.Click += new System.EventHandler(this.ucRHTRealTime_Click);
      // 
      // lblRH
      // 
      this.lblRH.ContextMenuStrip = this.contextMenuStrip1;
      this.lblRH.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblRH.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblRH.ForeColor = System.Drawing.SystemColors.ActiveCaption;
      this.lblRH.Location = new System.Drawing.Point(0, 65);
      this.lblRH.Name = "lblRH";
      this.lblRH.Size = new System.Drawing.Size(84, 50);
      this.lblRH.TabIndex = 3;
      this.lblRH.Text = "--.-";
      this.lblRH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.lblRH.Click += new System.EventHandler(this.ucRHTRealTime_Click);
      // 
      // timer1
      // 
      this.timer1.Enabled = true;
      this.timer1.Interval = 1000;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.historyToolStripMenuItem,
            this.chartDirToolStripMenuItem});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
      // 
      // historyToolStripMenuItem
      // 
      this.historyToolStripMenuItem.Name = "historyToolStripMenuItem";
      this.historyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.historyToolStripMenuItem.Text = "History";
      this.historyToolStripMenuItem.Click += new System.EventHandler(this.historyToolStripMenuItem_Click);
      // 
      // chartDirToolStripMenuItem
      // 
      this.chartDirToolStripMenuItem.Name = "chartDirToolStripMenuItem";
      this.chartDirToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.chartDirToolStripMenuItem.Text = "Chart Dir";
      this.chartDirToolStripMenuItem.Click += new System.EventHandler(this.chartDirToolStripMenuItem_Click);
      // 
      // ucRHTRealTime
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.lblRH);
      this.Controls.Add(this.lblTemp);
      this.Controls.Add(this.lblUp);
      this.Name = "ucRHTRealTime";
      this.Size = new System.Drawing.Size(84, 115);
      this.Load += new System.EventHandler(this.ucRHTRealTime_Load);
      this.Click += new System.EventHandler(this.ucRHTRealTime_Click);
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label lblUp;
    private System.Windows.Forms.Label lblTemp;
    private System.Windows.Forms.Label lblRH;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem historyToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem chartDirToolStripMenuItem;
  }
}
