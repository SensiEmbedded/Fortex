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

    private void frmDevsSett_Load(object sender, EventArgs e) {

      //ucDevSet uc = new ucDevSet();
      //uc.Dock = DockStyle.Left;
      //pnlFloor3.Controls.Add(uc);
      ucDevSet[] ucs = new ucDevSet[32];
      //pnlFloor1.AutoScroll = true;
      for (int i = 0; i < 32; i++) {
        ucs[i] = new ucDevSet();
        ucs[i].SetRef(glob.g_wr.floor1Devs[i]);
        //pnlFloor1.Controls.Add(ucs[i]);
        ucs[i].Dock = DockStyle.Left;
      }
      //pnlFloor1.Controls.Add(ucs[31-i]);
      
      for (int i = 0; i < 32; i++) {
        pnlFloor1.Controls.Add(ucs[31-i]);
      } 

      //pnlFloor1.Controls.AddRange(ucs);
      //flowLayoutPanel1.Controls.AddRange(ucs);
      //flowLayoutPanel1.VerticalScroll.Maximum = 0;
      //flowLayoutPanel1.HorizontalScroll.Visible = true;
      //flowLayoutPanel1.HorizontalScroll.Enabled = true;
      //flowLayoutPanel1.AutoScroll = true;
      
      //pnlFloor1.HorizontalScroll.Enabled = true;
      //pnlFloor1.HorizontalScroll.Visible = true;

    }
  }
}
