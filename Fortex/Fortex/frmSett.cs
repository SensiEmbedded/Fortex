using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DiffPress {
  public partial class frmSett : Form {
    CGlobal glob;
    public frmSett() {
      InitializeComponent();
    }
    public void SetRef(ref CGlobal rfGl) {
      glob = rfGl;
      propertyGrid1.SelectedObject = glob.g_wr;
    }
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
      if (keyData == Keys.Escape) {
        this.Close();
        return true;
      }
      return base.ProcessCmdKey(ref msg, keyData);
    }
    private void button1_Click(object sender, EventArgs e) {
      if (glob.g_wr == null) {
        glob.g_wr = new CSer();
        glob.g_wr.SetDefaults();
      }

      glob.SaveSettings();
    }

    private void btnClose_Click(object sender, EventArgs e) {
      this.Close();
    }
    
    private void btnDefault_Click(object sender, EventArgs e) {
      frmPassword frm = new frmPassword();
      frm.m_Password = "aa";
      if (frm.ShowDialog() == DialogResult.OK) {
        frmSetMM dlg  = new frmSetMM();
        dlg.SetRef(ref glob);
        dlg.ShowDialog();
      }
    }

    private void btnSetDevices_Click(object sender, EventArgs e) {
       frmDevsSett devs = new frmDevsSett();
      devs.SetRef(ref glob);
      devs.ShowDialog();
    }
  }
}
