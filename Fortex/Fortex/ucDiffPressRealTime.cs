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
  public partial class ucDiffPressRealTime : UserControl {
    string alarmExplanation;
    bool isAlarmDiff = false;
    Font fontControlLarge;
    Font fontControlSmall;
    
    Color colorControl;
    public ucDiffPressRealTime() {
      InitializeComponent();
      colorControl = lblDiff.BackColor;
      fontControlLarge = lblDiff.Font;
      fontControlSmall =  new Font(fontControlLarge.FontFamily, 10);
    }
    private CDev _cdev=null;
    public CDev cdev {
      get{return _cdev;}
      set {
        _cdev = value;
        if (_cdev != null) {
          _cdev.Changed += new ChangedEventHandler(_cdev_Changed);
          _cdev.evAlarm += new AlarmOccured(_cdev_evAlarm);
        }
      }
    }
    public void PrepareToDelete() {
      _cdev.Changed -= _cdev_Changed;
      _cdev.evAlarm -= _cdev_evAlarm;
      _cdev = null;
    }
    void _cdev_Changed(object sender, EventArgs e) {
      this.UIThread(() => this.ShowVals());
    }
    void _cdev_evAlarm(DevAlarms type, DevAlarms typeLast, string tag) {
    }
    private void ShowAlarms() {
      if (cdev == null)
        return;
      if (cdev.Enable == false)
        return;
      isAlarmDiff = (cdev.alarmStatus_LoVal1 != DevAlarms.None) ? true : false;
      isAlarmDiff = (cdev.alarmStatus_HiVal1 != DevAlarms.None) ? true : isAlarmDiff;
    }
    private void ShowVals() {
      if (cdev == null) {
        lblDiff.Text = "OFF1";
        return;
      }
      if (cdev.Enable == false) {
        lblDiff.Text = "OFF";
        return;
      }
      string err = CDev.ShowErr(_cdev.val1);
      if ( err == null) {
        lblDiff.Text = _cdev.val1.ToString("F1");
        lblDiff.Font = fontControlLarge;
      } else {
        lblDiff.Font = fontControlSmall;
        lblDiff.Text = err;
      }
    }
    
    private bool blink;
    int timerGuiUpdate=0;
    private void timer1_Tick(object sender, EventArgs e) {
      blink = !blink;
      if (isAlarmDiff == false) {
        lblDiff.BackColor = colorControl;
      } else {
        if (blink == true) {
          lblDiff.BackColor = colorControl;
        } else {
          lblDiff.BackColor = Color.Red;
        }
      }
      
      if (++timerGuiUpdate < 5)
        return;
      timerGuiUpdate = 0;
      
      ShowVals();
      ShowAlarms();
    }

    private void ucDiffPressRealTime_Click(object sender, EventArgs e) {
      frmIxView frm = new frmIxView();
      frm.cdev = _cdev;
      frm.ShowDialog(this);
    }
     private void chartDirToolStripMenuItem_Click(object sender, EventArgs e) {
      frmChartDir frm = new frmChartDir();
      //frm.SetRef(ref glob);
      frm.cdev = _cdev;
      frm.ShowDialog(this);
    }

    private void historyToolStripMenuItem_Click(object sender, EventArgs e) {
      frmIxView frm = new frmIxView();
      frm.cdev = _cdev;
      frm.ShowDialog(this);
    }
  
  }
}
