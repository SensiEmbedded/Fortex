using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DiffPress {
  public partial class ucDevSet : UserControl {
    private CDev dev;
    //CGlobal glob;

    public ucDevSet() {
      InitializeComponent();
    }
    //public void SetRef(ref CGlobal rfGl) {
    //  glob = rfGl;
    //}
    public void SetRef(CDev dev) {
      this.dev = dev;
      PopulateControls();

    }
    private void PopulateControls() {
      lblName.Text = dev.name;
      lblType.Text = dev.type.ToString();
      lblEnable.Text = dev.Enable.ToString();
      lblAlarmLow.Text = dev.alarmLow.ToString("F1");
      lblAlarmHi.Text = dev.alarmHi.ToString("F1");
      lblAddr.Text = dev.address.ToString();
      if (dev.Enable == false) {
        this.BackColor = Color.Gray;
      } else {
        this.BackColor = Color.GhostWhite;
      }
    }

    private void btnEdit_Click(object sender, EventArgs e) {
      //CDev dev = glob.g_wr.floor1Devs[0];
      frmDevSett devs = new frmDevSett(dev);
      devs.ShowDialog();
      PopulateControls();
    }

    private void ucDevSet_Load(object sender, EventArgs e) {

    }
  }
}
