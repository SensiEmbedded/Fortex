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
    ~ucRHTRealTime() {
      System.Diagnostics.Debug.WriteLine("Destructor called");
      
    }
    public ucRHTRealTime() {
      InitializeComponent();
      colorControl = lblTemp.BackColor;
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
      }
      if (type == DevAlarms.Lo && tag == "val1") {
        alarmExplanation = "Temperature Low Limit";
        this.UIThread(() => toolTip1.SetToolTip(lblTemp,alarmExplanation));
        isAlarmTemp = true;
      }
      if (type == DevAlarms.Hi && tag == "val2") {
        alarmExplanation = "Humidity High Limit";
        this.UIThread(() => toolTip1.SetToolTip(lblRH,alarmExplanation));
        isAlarmRH = true;
        //toolTip1.SetToolTip(lblRH,alarmExplanation);
      }
      if (type == DevAlarms.Lo && tag == "val2") {
        alarmExplanation = "Humidity Low Limit";
        this.UIThread(() => toolTip1.SetToolTip(lblRH,alarmExplanation));
        isAlarmRH = true;
      }
    }
    private bool ShowErr(double val) {
      int err = (int)val;
      switch (err) {
        case (int)DevErrorCodes.TimeOutDev:
          lblTemp.Text = "Time";
          lblRH.Text = "Out";
          return false;
        case (int)DevErrorCodes.AddressExeptionDev:
          lblTemp.Text = "Excep";
          lblRH.Text = "Dev";
          return false;
        case (int)DevErrorCodes.AdcErrDev:
          lblTemp.Text = "Adc";
          lblRH.Text = "Err";
          return false;
        case (int)DevErrorCodes.TimeOutMM:
          lblTemp.Text = "Time";
          lblRH.Text = "OutMM";
          return false;
        case (int)DevErrorCodes.AddressExeptionMM:
          lblTemp.Text = "Excep";
          lblRH.Text = "MM";
          return false;
        case (int)DevErrorCodes.ComNotExist:
          lblTemp.Text = "Err";
          lblRH.Text = "COM";
          return false;
        case (int)DevErrorCodes.ErrUnknown:
          lblTemp.Text = "Err";
          lblRH.Text = "";
          return false;
      }
      return true;

    }
    private void ShowVals() {
      if (ShowErr(_cdev.val1) == true) {
        lblTemp.Text = _cdev.val1.ToString("F1");
         lblRH.Text = _cdev.val2.ToString("F1");
      }
    }
    private void ShowTemp() {
      //176  degree symbol in Microsoft Sans Serif
      //lblTemp.Text = _cdev.val1.ToString("F1") +" "+ ((char)176).ToString() + "C";
      if (ShowErr(_cdev.val1) == true) {
        lblTemp.Text = _cdev.val1.ToString("F1");
        //lblDiff.Text = _cdev.val1.ToString("F1") + " PA";
      }
      
    }
    private void ShowRH() {
      if (ShowErr(_cdev.val1) == true) {
        lblRH.Text = _cdev.val2.ToString("F1");
        //lblDiff.Text = _cdev.val1.ToString("F1") + " PA";
      }
      
    }
    private bool blink;
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
      /*
      if ( glob.comm.devs.devVir.alarmStatus[index] == DevAlarms.None) {
        pnlBlink.BackColor = colorControl;
      } else {
        if (blink == true) {
          pnlBlink.BackColor = colorControl;
        } else {
          if (glob.comm.devs.devVir.alarmStatus[index] == DevAlarms.Error) {
            //adc err, no comminication error
            pnlBlink.BackColor = Color.BurlyWood;
          } else {
            //pressure error
            pnlBlink.BackColor = Color.Red;
          }
        }
      } */

      //ShowTemp();
      //ShowRH();      
    }

    private void lblTemp_Click(object sender, EventArgs e) {

    }
  }
}
