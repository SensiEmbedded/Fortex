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
   
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
      if (keyData == Keys.Escape) {
        this.Close();
        return true;
      }
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void btnEdit_Click(object sender, EventArgs e) {
      CDev dev = glob.g_wr.floor1Devs[0];
      frmDevSett devs = new frmDevSett(dev);
      devs.ShowDialog();
    }

    private void floor1Populate() {
      ucDevSet[] ucs = new ucDevSet[32];
      for (int i = 0; i < 32; i++) {
        ucs[i] = new ucDevSet();
        ucs[i].SetRef(glob.g_wr.floor1Devs[i]);
        ucs[i].Dock = DockStyle.Left;
      }
      for (int i = 0; i < 32; i++) {
        pnlFloor1.Controls.Add(ucs[31-i]);
      } 
      ucs[0].Select(); // move scrollbar at the beging
    }
     private void floor2Populate() {
      ucDevSet[] ucs = new ucDevSet[32];
      for (int i = 0; i < 32; i++) {
        ucs[i] = new ucDevSet();
        ucs[i].SetRef(glob.g_wr.floor2Devs[i]);
        ucs[i].Dock = DockStyle.Left;
      }
      for (int i = 0; i < 32; i++) {
        pnlFloor2.Controls.Add(ucs[31-i]);
      } 
      ucs[0].Select(); // move scrollbar at the beging
    }
     private void floor3Populate() {
      ucDevSet[] ucs = new ucDevSet[32];
      for (int i = 0; i < 32; i++) {
        ucs[i] = new ucDevSet();
        ucs[i].SetRef(glob.g_wr.floor3Devs[i]);
        ucs[i].Dock = DockStyle.Left;
      }
      for (int i = 0; i < 32; i++) {
        pnlFloor3.Controls.Add(ucs[31-i]);
      } 
      ucs[0].Select(); // move scrollbar at the beging
    }
    private void frmDevsSett_Load(object sender, EventArgs e) {
      floor1Populate();
      floor2Populate();
      floor3Populate();
    }

    private void button1_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void button2_Click(object sender, EventArgs e) {
      if (glob.g_wr == null) {
        glob.g_wr = new CSer();
        glob.g_wr.SetDefaults();
      }

      glob.SaveSettings();
    }
  }
}
