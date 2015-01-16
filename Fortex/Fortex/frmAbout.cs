using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DiffPress {
  public partial class frmAbout : Form {
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
      if (keyData == Keys.Escape) {
        this.Close();
        return true;
      }
      return base.ProcessCmdKey(ref msg, keyData);
    }
    public frmAbout() {
      InitializeComponent();

    }
    int ix = -1;
    string[] names = new string[3] { "Асен Янков", "Николай Стоянов", "Георги Тошев" };
    private void timer1_Tick(object sender, EventArgs e) {
      if (++ix > 2)
        ix = 0;
      lblNames.Text = names[ix];
    }

    private void frmAbout_Load(object sender, EventArgs e) {
      txtInfo.Select(0, 0);
    }
  }
}
