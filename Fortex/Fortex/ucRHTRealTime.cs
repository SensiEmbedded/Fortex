using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
      ShowTemp();
      ShowRH();
    }
    private void ShowTemp() {
      //176  degree symbol in Microsoft Sans Serif
      lblTemp.Text = _cdev.val1.ToString("F1") +" "+ ((char)176).ToString() + "C";
      System.Diagnostics.Debug.WriteLine(lblTemp.Text);
    }
    private void ShowRH() {
      lblRH.Text = _cdev.val2.ToString("F1") + " %";
    }
    private void timer1_Tick(object sender, EventArgs e) {
      //ShowTemp();
      //ShowRH();      
    }
  }
}
