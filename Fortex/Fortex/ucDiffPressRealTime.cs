﻿using System;
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
    public ucDiffPressRealTime() {
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
        ShowDiffPress();
      }
    }
    void _cdev_Changed(object sender, EventArgs e) {
      this.UIThread(() => this.ShowDiffPress());
    }
    private bool ShowErr(double val) {
      int err = (int)val;
      
      switch (err) {
        case (int)DevErrorCodes.AdcErr:
          lblDiff.Text = "Adc\nErr";
          return false;
        case (int)DevErrorCodes.AddressExeption:
          lblDiff.Text = "Excep";
          return false;
        case (int)DevErrorCodes.ComNotExist:
          lblDiff.Text = "Err\nCOM";
          return false;
        case (int)DevErrorCodes.ErrUnknown:
          lblDiff.Text = "Err";
          return false;
        case (int)DevErrorCodes.TimeOut:
          lblDiff.Text = "Time\nOut";
          return false;
      }
      return true;

    }
    private void ShowDiffPress() {
      if (ShowErr(_cdev.val1) == true) {
        lblDiff.Text = _cdev.val1.ToString("F1");
        //lblDiff.Text = _cdev.val1.ToString("F1") + " PA";
      }
    }
    
    private void timer1_Tick(object sender, EventArgs e) {
    }
  }
}
