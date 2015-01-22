using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DiffPress {
  public partial class frmDevSett : Form {
    private CDev dev;
    public frmDevSett(CDev dev) {
      InitializeComponent();
      this.dev = dev;
      PopulateControls();
    }
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
      if (keyData == Keys.Escape) {
        this.Close();
        return true;
      }
      return base.ProcessCmdKey(ref msg, keyData);
    }
    private void PopulateControls() {
      lblAddr.Text = dev.address.ToString();
      cmbType.SelectedIndex = (int)dev.type;
      txtName.Text = dev.name;
      nudAlarmHi.Value = (decimal)dev.alarmHi;
      nudAlarmLo.Value = (decimal)dev.alarmLow;
      txtDescr.Text = dev.description;
      ucOnOff1.isOn  = dev.Enable ;
     
    }
    private void PopulateFromControl() {
      dev.type = (TypeDevice)cmbType.SelectedIndex;
      dev.name = txtName.Text;
      dev.alarmHi = (double)nudAlarmHi.Value;
      dev.alarmLow = (double)nudAlarmLo.Value;
      dev.description = txtDescr.Text;
      dev.Enable = ucOnOff1.isOn; 
      
    }
    private void btnOK_Click(object sender, EventArgs e) {
      PopulateFromControl();
      this.Close();
    }

    private void frmDevSett_Load(object sender, EventArgs e) {
      //picAlarm.Image = Image.FromFile("C:\myFile.???");
    }

    private void picAlarm_Click(object sender, EventArgs e) {

    }

    private void btnOK_Click_1(object sender, EventArgs e) {
      this.Close();
    }
  }
}
