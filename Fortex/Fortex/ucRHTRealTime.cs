using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using aUtils;

namespace DiffPress {
  public partial class ucRHTRealTime : UserControl {
    string alarmExplanation;
    bool isAlarmTemp = false;
    bool isAlarmRH = false;
    Color colorControl;
    Font fontControlLarge;
    Font fontControlSmall;
    
    public ucRHTRealTime() {
      InitializeComponent();
      colorControl = lblTemp.BackColor;
      fontControlLarge = lblTemp.Font;
      fontControlSmall =  new Font(fontControlLarge.FontFamily, 10);
    }
    /*
    protected override void WndProc(ref Message m)
    {
      const int WM_NCHITTEST = 0x0084;
      const int HTTRANSPARENT = (-1);

      if (m.Msg == WM_NCHITTEST)
      {
          m.Result = (IntPtr)HTTRANSPARENT;
      }
      else
      {
          base.WndProc(ref m);
      }
    } */
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
      AnalizeAlarm(type,typeLast,tag); 
      //MessageBox.Show(type.ToString());
      System.Diagnostics.Debug.WriteLine("type:" +type.ToString());
      System.Diagnostics.Debug.WriteLine("typeLast:" +typeLast.ToString());
      System.Diagnostics.Debug.WriteLine("name:" + _cdev.name);
      System.Diagnostics.Debug.WriteLine("strID:" + _cdev.strID);
      System.Diagnostics.Debug.WriteLine("GuID:" + _cdev.InstanceID.ToString());

    }
    void _cdev_Changed(object sender, EventArgs e) {
      //this.UIThread(() => this.ShowRH());
      //this.UIThread(() => this.ShowTemp());
      this.UIThread(() => this.ShowVals());
 
    }
    private void AnalizeAlarm(DevAlarms type, DevAlarms typeLast, string tag) {
      if (type == DevAlarms.None) {
        alarmExplanation = "No Alarm Present.";
        if (tag == "val1") {
          isAlarmTemp = false;
        } else {
          isAlarmRH = false;
        }
        this.UIThread(() => toolTip1.SetToolTip(lblRH,alarmExplanation));
        this.UIThread(() => toolTip1.SetToolTip(lblTemp,alarmExplanation));
        return;
      }
      
      if (type == DevAlarms.Hi && tag == "val1") {
        alarmExplanation = "Temperature High Limit";
        this.UIThread(() => toolTip1.SetToolTip(lblTemp,alarmExplanation));
        isAlarmTemp = true;
        return;
      }
      if (type == DevAlarms.Lo && tag == "val1") {
        alarmExplanation = "Temperature Low Limit";
        this.UIThread(() => toolTip1.SetToolTip(lblTemp,alarmExplanation));
        isAlarmTemp = true;
        return;
      }
      if (type == DevAlarms.Hi && tag == "val2") {
        alarmExplanation = "Humidity High Limit";
        this.UIThread(() => toolTip1.SetToolTip(lblRH,alarmExplanation));
        isAlarmRH = true;
        return;
        //toolTip1.SetToolTip(lblRH,alarmExplanation);
      }
      if (type == DevAlarms.Lo && tag == "val2") {
        alarmExplanation = "Humidity Low Limit";
        this.UIThread(() => toolTip1.SetToolTip(lblRH,alarmExplanation));
        isAlarmRH = true;
        return;
      }
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

      if (cdev == null) {
        lblTemp.Text = "OFF1";
        lblRH.Text = "--.-";
        return;
      }
      if (cdev.Enable == false) {
        lblTemp.Text = "OFF";
        lblRH.Text = "--.-";
        return;
      }
      string err = CDev.ShowErr(_cdev.val1);
      if ( err == null) {
        lblTemp.Text = _cdev.val1.ToString("F1");
        lblRH.Text = _cdev.val2.ToString("F1");
        //lblTemp.Font = new Font(lblTemp.Font.FontFamily, 16);
        lblTemp.Font = fontControlLarge;
      } else {
        lblTemp.Font = fontControlSmall;
        lblTemp.Text = err;
        lblRH.Text = "";
      }
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
      //ShowTemp();
      //ShowRH();      
    }

    private void lblTemp_Click(object sender, EventArgs e) {

    }

    private void ucRHTRealTime_Click(object sender, EventArgs e) {
      
      frmIxView frm = new frmIxView();
      frm.cdev = _cdev;
      frm.ShowDialog(this);
    }

    private void ucRHTRealTime_Load(object sender, EventArgs e) {

    }
  }
}
