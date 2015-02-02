using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using aUtils;

namespace DiffPress {
  public partial class frmIxView : Form {
    CGlobal glob;
    string alarmExplanation;
    bool isAlarmTemp = false;
    bool isAlarmRH = false;
    Color colorControl;

    public frmIxView() {
      InitializeComponent();
    }
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
      if (keyData == Keys.Escape) {
        this.Close();
        return true;
      }
      return base.ProcessCmdKey(ref msg, keyData);
    }
    
    private CDev _cdev=null;
    public CDev cdev {
      get{return _cdev;}
      set {
        _cdev = value;
        if (_cdev != null) {  
          _cdev.Changed +=new ChangedEventHandler(_cdev_Changed);
          _cdev.evAlarm += new AlarmOccured(_cdev_evAlarm);                                               
        }
      }
    }

    public void PrepareToDelete() {
      _cdev.Changed -= _cdev_Changed;
      _cdev.evAlarm -= _cdev_evAlarm;
      _cdev = null;
    }
    void _cdev_evAlarm(DevAlarms type,DevAlarms typeLast,string tag) {
      //./AnalizeAlarm(type,typeLast,tag); 
      
      System.Diagnostics.Debug.WriteLine("type:" +type.ToString());
      System.Diagnostics.Debug.WriteLine("typeLast:" +typeLast.ToString());
      System.Diagnostics.Debug.WriteLine("name:" + _cdev.name);
      System.Diagnostics.Debug.WriteLine("strID:" + _cdev.strID);
      System.Diagnostics.Debug.WriteLine("GuID:" + _cdev.InstanceID.ToString());

    }
    void _cdev_Changed(object sender, EventArgs e) {
      
      this.UIThread(() => this.ShowVals());
 
    }
    void PopulateStaticLabels() {
      lblAddr.Text = cdev.address.ToString();
      //cmbType.SelectedIndex = (int)cdev.type;
      txtType.Text = cdev.type.ToString();
      txtName.Text = cdev.name;
      txtDescr.Text = cdev.description;
      nudAlarmHiVal1.Value = (decimal)cdev.alarmHiVal1;
      nudAlarmLoVal1.Value = (decimal)cdev.alarmLowVal1;
      nudAlarmHiVal2.Value = (decimal)cdev.alarmHiVal2;
      nudAlarmLoVal2.Value = (decimal)cdev.alarmLowVal2;
      if (cdev.type == TypeDevice.RHT) {
        SetRHTTypeControl();
      } else {
        SetPressureTypeControl();
      }
      ucOnOff1.isOn  = cdev.Enable;
    }
    private void SetRHTTypeControl() {
      grpBox1.Text = "Humidity (%)";
      grpBox2.Visible = true;
      grpBox2.Text = "Temperature (" + ((char)176).ToString() + "C)";
      pbDevices.Image = imageList1.Images[0];
    }
    private void SetPressureTypeControl() {
      grpBox1.Text = "Diff.Pressure (PA)";
      grpBox2.Visible = false;
      grpBox2.Text = "Temperature (" + ((char)176).ToString() + "C)";
      pbDevices.Image = imageList1.Images[1];
    }
    private void ShowAlarms() {
      if (cdev == null)
        return;
      if (cdev.Enable == false)
        return;

      isAlarmTemp = (cdev.alarmStatus_LoVal1 != DevAlarms.None) ? true : false;
      isAlarmTemp = (cdev.alarmStatus_HiVal1 != DevAlarms.None) ? true : isAlarmTemp;
      isAlarmRH = (cdev.alarmStatus_LoVal2 != DevAlarms.None) ? true : false;
      isAlarmRH = (cdev.alarmStatus_HiVal2 != DevAlarms.None) ? true : isAlarmRH;
    }
    
    private void ShowVals() {
      if (cdev == null)
        return;
      string err = CDev.ShowErr(_cdev.val1);
      if ( err == null) {
        lblTemp.Text = _cdev.val1.ToString("F1");
        lblRH.Text = _cdev.val2.ToString("F1");
      } else {
        lblTemp.Text = err;
        lblRH.Text = "";
      }
    }
    

    private void frmIxView_Load(object sender, EventArgs e) {
      Control parent= this.Owner;
      if (parent != null) {
        glob = ((frmMain)parent).glob;
      }
      PopulateStaticLabels();
    }
    private bool blink;
    int timerGuiUpdate=0;
    private void timer1_Tick(object sender, EventArgs e) {
      blink = !blink;
      if (isAlarmTemp == false) {
        lblTemp.BackColor = colorControl;
      } else {
        if (blink == true) {
          lblTemp.BackColor = colorControl;
        } else {
          lblTemp.BackColor = Color.Red;
        }
      
      }
      if (isAlarmRH == false) {
        lblRH.BackColor = colorControl;
      } else {
        if (blink == true) {
          lblRH.BackColor = colorControl;
        } else {
          lblRH.BackColor = Color.Red;
        }
      }
      if (++timerGuiUpdate < 5)
        return;
      timerGuiUpdate = 0;
      
      ShowVals();
      ShowAlarms();
         
    }

    private void label3_Click(object sender, EventArgs e) {

    }

    private void txtName_TextChanged(object sender, EventArgs e) {

    }
  }
}
