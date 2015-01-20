using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DiffPress {
  public partial class frmDevsSett : Form {
    CGlobal glob;
    public frmDevsSett() {
      InitializeComponent();
      
    }
    public void SetRef(ref CGlobal rfGl) {
      glob = rfGl;
    }
    

    

    private void btnEdit_Click(object sender, EventArgs e) {
       CDev dev = glob.g_wr.floor1Devs[0];
      frmDevSett devs = new frmDevSett(dev);
      devs.ShowDialog();
    }
  }
}
