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
    public ucRHTRealTime() {
      InitializeComponent();
    }
    private CDev _cdev=null;
    public CDev cdev {
      get{return _cdev;}
      set {
        _cdev = value;
        if (_cdev != null) {
          _cdev.Changed += new ChangedEventHandler(_cdev_Changed);
        
        }
        ShowTemp();
        ShowRH();
      }
    }
    void _cdev_Changed(object sender, EventArgs e) {
      this.UIThread(() => this.ShowRH());
      this.UIThread(() => this.ShowTemp());
      //ShowTemp();
      //ShowRH();
    }
    private bool ShowErr(double val) {
      int err = (int)val;
      switch (err) {
        case (int)DevErrorCodes.AdcErr:
          lblTemp.Text = "Adc";
          lblRH.Text = "Err";
          return false;
        case (int)DevErrorCodes.AddressExeption:
          lblTemp.Text = "Excep";
          lblRH.Text = "";
          return false;
        case (int)DevErrorCodes.ComNotExist:
          lblTemp.Text = "Err";
          lblRH.Text = "COM";
          return false;
        case (int)DevErrorCodes.ErrUnknown:
          lblTemp.Text = "Err";
          lblRH.Text = "";
          return false;
        case (int)DevErrorCodes.TimeOut:
          lblTemp.Text = "Time";
          lblRH.Text = "Out";
          return false;
      }
      return true;

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
    private void timer1_Tick(object sender, EventArgs e) {
      //ShowTemp();
      //ShowRH();      
    }

    private void lblTemp_Click(object sender, EventArgs e) {

    }
  }
}
