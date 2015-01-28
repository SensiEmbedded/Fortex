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
      nudAlarmHiVal1.Value = (decimal)dev.alarmHiVal1;
      nudAlarmLoVal1.Value = (decimal)dev.alarmLowVal1;
      nudAlarmHiVal2.Value = (decimal)dev.alarmHiVal2;
      nudAlarmLoVal2.Value = (decimal)dev.alarmLowVal2;
      txtDescr.Text = dev.description;
      ucOnOff1.isOn  = dev.Enable ;
     
    }
    private void PopulateFromControl() {
      dev.type = (TypeDevice)cmbType.SelectedIndex;
      dev.name = txtName.Text;
      dev.alarmHiVal1 = (double)nudAlarmHiVal1.Value;
      dev.alarmLowVal1 = (double)nudAlarmLoVal1.Value;
      dev.alarmHiVal2 = (double)nudAlarmHiVal2.Value;
      dev.alarmLowVal2 = (double)nudAlarmLoVal2.Value;
      dev.description = txtDescr.Text;
      dev.Enable = ucOnOff1.isOn; 
      
    }
    private void SetRHTTypeControl() {
      grpBox1.Text = "Humidity (%)";
      grpBox2.Visible = true;
      grpBox2.Text = "Temperature (" + ((char)176).ToString() + "C)";
    }
    private void SetPressureTypeControl() {
      grpBox1.Text = "Diff.Pressure (PA)";
      grpBox2.Visible = false;
      grpBox2.Text = "Temperature (" + ((char)176).ToString() + "C)";
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

    private void cmbType_SelectedIndexChanged(object sender, EventArgs e) {
      if (cmbType.SelectedIndex == 0) {
        SetRHTTypeControl();
      } else {
        SetPressureTypeControl();
      }
    }
  }
}
