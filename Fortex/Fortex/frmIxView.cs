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
      txtID.Text = cdev.strID;
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
      dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
      dtpEnd.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23,59, 0);

    }
    private void SetRHTTypeControl() {
      grpBox1.Text = "Humidity (%)";
      grpBox2.Visible = true;
      grpBox2.Text = "Temperature (" + ((char)176).ToString() + "C)";
      pbDevices.Image = imageList1.Images[0];
      lblStaticVal1.Text = "Temp. (" + ((char)176).ToString() + "C)";
      lblStaticVal2.Text = "RH (%)";
      lblStaticVal1.Visible = true;
      lblStaticVal2.Visible = true;
    }
    private void SetPressureTypeControl() {
      grpBox1.Text = "Diff.Pressure (PA)";
      grpBox2.Visible = false;
      grpBox2.Text = "Temperature (" + ((char)176).ToString() + "C)";
      pbDevices.Image = imageList1.Images[1];
      lblStaticVal1.Text = "Diff.Pressure (PA)";
      lblStaticVal1.Visible = true;
      lblStaticVal2.Visible = false;
      lblVal2.Visible = false;
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
        lblVal1.Text = _cdev.val1.ToString("F1");
        lblVal2.Text = _cdev.val2.ToString("F1");
      } else {
        lblVal1.Text = err;
        lblVal2.Text = "";
      }
    }
    private void frmIxView_Load(object sender, EventArgs e) {
      Control parent= this.Owner;
      if (parent != null) {
        glob = ((frmMain)parent).glob;
      }
      PopulateStaticLabels();
      //PopulateGrid();
      glob.data.Changed += new ChangedEventHandler(data_Changed);
    }
    private bool blink;
    int timerGuiUpdate=0;
    private void timer1_Tick(object sender, EventArgs e) {
      blink = !blink;
      if (isAlarmTemp == false) {
        lblVal1.BackColor = colorControl;
      } else {
        if (blink == true) {
          lblVal1.BackColor = colorControl;
        } else {
          lblVal1.BackColor = Color.Red;
        }
      
      }
      if (isAlarmRH == false) {
        lblVal2.BackColor = colorControl;
      } else {
        if (blink == true) {
          lblVal2.BackColor = colorControl;
        } else {
          lblVal2.BackColor = Color.Red;
        }
      }
      if (++timerGuiUpdate < 5)
        return;
      timerGuiUpdate = 0;
      
      ShowVals();
      ShowAlarms();
      glob.data.InsertDataRow(cdev.strID, 12.3,32.1);
         
    }

    private void label3_Click(object sender, EventArgs e) {

    }

    private void txtName_TextChanged(object sender, EventArgs e) {

    }
    #region SQLite Data
    void data_Changed(object sender, EventArgs e) {
      //PopulateGrid();
    }
    void PopulateGrid() {
      DataSet ds = glob.data.GimitblMess(cdev.strID);
      if (ds == null) {
        return;
      }
      this.UIThread(() => this.dataGridView1.DataSource = ds.Tables[0].DefaultView);

    }
    #endregion

    private void btnSelect_Click(object sender, EventArgs e) {
      DataSet ds = glob.data.GimitblMess(cdev.type,cdev.strID, dtpStart.Value,dtpEnd.Value,(int)nudLimit.Value);
      if (ds == null) {
        return;
      }
      this.UIThread(() => this.dataGridView1.DataSource = ds.Tables[0].DefaultView);
    }
  }
}
