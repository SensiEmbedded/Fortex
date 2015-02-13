using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Modbus.Device;
using System.IO;  //for serial port
using System.IO.Ports;  //for serial port
using System.Media;
using System.Threading;
using aUtils;

using System.Data.SQLite;


namespace DiffPress {

  public delegate void ChangedEventHandler(object sender, EventArgs e);
  

  public partial class frmMain : Form {
    public CGlobal glob = new CGlobal();
    int sample1s = 0;
    int sample2s = 0;
    int sample4s = 0;
    bool fullScreen = false;

    public frmMain() {
      InitializeComponent();
    }
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
      if (keyData == Keys.Escape) {
        this.Close();
        return true;
      }
      return base.ProcessCmdKey(ref msg, keyData);
    }
    private void Form1_Load(object sender, EventArgs e) {

      glob.comm.SetRef(ref glob);
      GoFullscreen(glob.g_wr.fullScreen);
      fullScreen = glob.g_wr.fullScreen;
      //ucValue1.SetRef(ref glob);
      //ucValue1.isOutOfRange = false;
      
      glob.sqlite.Changed += new ChangedEventHandler(sqlite_Changed);

      //string str = "basi basi";
      //str.AssenMethod();
      //lblTest.AssenMethod2();
      //this.AssenMethod2();
      //string fae = "sss";

      
      //  progressBar1.Increment(1);
        //Thread.Sleep(1000);
      PopulateAllFloors();
      glob.sqlite.LogMessage("Program started.");
     
      return;
    }

    

    

    
    //set AO
    /*
    private void AO_click(object sender, EventArgs e) {
      byte slaveID = 1;
      frmInputValue inputvalue = new frmInputValue();
      if (serialPort.IsOpen == true) {
        ushort index = ushort.Parse(((TextBox)sender).Tag.ToString());
        inputvalue.StringValue = ((TextBox)sender).Text;
        inputvalue.ShowDialog();
        if (inputvalue.DialogResult == DialogResult.OK) {
          double value = inputvalue.Value;
          ushort aovalue = (ushort)value;

          //use gain=20/32767, offset=0
          //ushort aovalue = (ushort)(value * 32767 / 20.0);
          master.WriteSingleRegister(slaveID, index, aovalue);
        }
      }
    } */

    private void tmrBlink_Tick(object sender, EventArgs e) {

    }

    void devVir_Changed(object sender, EventArgs e) {
      //this.UIThread(() => this.lblTest.Text = glob.comm.devs.devVir.pressure[5].ToString());
      this.UIThread(() => this.UpdateBarGraphs());
      
      //System.Diagnostics.Debug.WriteLine(DateTime.Now.ToString() + " from event " + glob.comm.devs.devVir.prDiffPress1.ToString());
    }
    
    private void UpdateClock() {
      lblClock.Text = aUtils.CUtils.GimiBGDateTimeForMainScreen();
      DateTime dt = DateTime.Now;
      blueClock1.Month = dt.Month;
      blueClock1.Day = dt.Day;
      blueClock1.Hour = dt.Hour;
      blueClock1.Minute = dt.Minute;
      blueClock1.Second = dt.Second;
    }
    
    private void UpdateBarGraphs() {
      //ucValue1.Update(5);
      //ucValue2.Update(6);
      //ucValue3.Update(7);
      
    }
    private void UpdateStatus() {
      /*
      //MS SQL Write
      lblRemain.Text = glob.mssql.TimeRemain().ToString();
      // Communication
      if (glob.comm.IsConnect() == false) {
        lblComm.Text = "Not Connected";
        lblComm.ForeColor = Color.Red;
      } else {
        //this.comm. cmn.status = DevStatus.TimeOut;
        if (glob.comm.devs.devVir.cmn.status == DevStatus.TimeOut) {
          lblComm.ForeColor = Color.Red;
          lblComm.Text = "TimeOut";
        } else {
          lblComm.ForeColor = Color.Black;
          lblComm.Text = "OK";
        }
        
      
      } */
    }
    int count;
    private void tmrUpdateGUI_Tick(object sender, EventArgs e) {
      //tick on every 500 ms


      if (++sample1s < 2) return;
      sample1s = 0;
      
      UpdateClock();
      //UpdateStatus();

      if (++sample2s < 2) return;
      sample2s = 0;
      
      UpdateBarGraphs();
      //TestChart();

      if (++sample4s < 2)
        return;
      sample4s = 0;
      
      /*
      if (glob.comm.devs.devVir.holdingregister != null) {
        System.Diagnostics.Debug.WriteLine(DateTime.Now.ToString() + " update hold=" + glob.comm.devs.devVir.holdingregister[1]);
      } */
      //System.Diagnostics.Debug.WriteLine("Form ThreadID=" + AppDomain.GetCurrentThreadId().ToString());

    }

    private void pictureBox2_Click(object sender, EventArgs e) {
      frmSett fr = new frmSett();
      fr.SetRef(ref glob);
      fr.ShowDialog();
      PopulateAllFloors();
    }
    private void GoFullscreen(bool fullscreen) {
      if (fullscreen) {
        this.WindowState = FormWindowState.Normal;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Bounds = Screen.PrimaryScreen.Bounds;
      } else {
        this.WindowState = FormWindowState.Maximized;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
      }
    }
    private void pictureBox3_Click(object sender, EventArgs e) {
      fullScreen = !fullScreen;
      GoFullscreen(fullScreen);
    }

    private void button1_Click(object sender, EventArgs e) {
      //propertyGrid1.SelectedObject = glob.comm.devs.devVir;
      //glob.sqlite.InsertRow();
      //PopulateGrid();
      //CreateTable();

      /*
      double[] d = new double[9];
      var hm = d.Select(x => x + 2);
      foreach (double dd in hm) {
        System.Diagnostics.Debug.WriteLine(dd);  
      } */
      /*
      var Alll = from cust in d  select cust;
      System.Diagnostics.Debug.WriteLine(Alll);
      foreach (double dd in Alll) {
        System.Diagnostics.Debug.WriteLine(dd);
      } */
    }   

    private void chart1_Click(object sender, EventArgs e) {

    }

    private void chbDiff1_CheckedChanged(object sender, EventArgs e) {
      
    }
    #region RealTime Panels
    private void PopulateAllFloors() {
      floor1Populate();
      floor2Populate();
      floor2_2Populate();
      floor3Populate();
    }
    private void RemoveControlsFromPanel(Panel pnl) {
      int howToRemove = pnl.Controls.Count;
      for(int i=0;i<howToRemove;++i){
        Control rt = pnl.Controls[0];
        if (rt.GetType() == typeof(ucRHTRealTime)) {
          ((ucRHTRealTime)rt).PrepareToDelete();
        }
        if (rt.GetType() == typeof(ucDiffPressRealTime)) {
          ((ucDiffPressRealTime)rt).PrepareToDelete();
        }
        //pnlFloor1.Controls[0].Dispose();
        pnl.Controls.RemoveAt(0);
      } 
    }
    private void AddControlToPanel(Panel pnl, List<Control> cntrs) {
      int howMany = cntrs.Count;
      for (int i = 0; i < howMany; i++) {
        cntrs[i].Dock = DockStyle.Left;
        pnl.Controls.Add(cntrs[howMany-1 - i]);
      } 
      cntrs[0].Select();
    }
    private List<Control> GimiListOfControls(CDev[] devs,int howMany) {
      if(howMany == 0)return null;
      List<Control> cntrs = new List<Control>(howMany);
      ucRHTRealTime rht = null;
      ucDiffPressRealTime diffpres = null;
      for (int i = 0; i < howMany; i++) {
        if (devs[i].type == TypeDevice.RHT) {
          rht = new ucRHTRealTime();
          rht.cdev = devs[i];
          cntrs.Add(rht);
        } else {
          diffpres = new ucDiffPressRealTime();
          diffpres.cdev = devs[i];
          cntrs.Add(diffpres);
        }
      }
      return cntrs;
    }
    private void floor1Populate() {
      int howMany = glob.g_wr.howManyDevsFloor1;
      if(howMany == 0)return;
      List<Control> cntrs = GimiListOfControls(glob.g_wr.floor1Devs,howMany);
      RemoveControlsFromPanel(pnlFloor1);      
      AddControlToPanel(pnlFloor1,cntrs);
    }
    private void floor2Populate() {
      int howMany = glob.g_wr.howManyDevsFloor2;
      if(howMany == 0)return;
      if(howMany > 19)howMany = 19;//drugite w pnlFloor2_2
      List<Control> cntrs = GimiListOfControls(glob.g_wr.floor2Devs,howMany);
      RemoveControlsFromPanel(pnlFloor2);
      AddControlToPanel(pnlFloor2,cntrs);
      
    }
    private void floor2_2Populate() {
      int howMany = glob.g_wr.howManyDevsFloor2;
      if(howMany == 0)return;
      if(howMany <= 19)return;//Prednite sa syzdadeni v pnlFloor2
      howMany -= 19;
      //Control[] cntrs = new Control[howMany];
      List<Control> cntrs = new List<Control>(howMany);
      ucRHTRealTime rht = null;
      ucDiffPressRealTime diffpres = null;
      for (int i = 0; i < howMany; i++) {
        if (glob.g_wr.floor2Devs[19+i].type == TypeDevice.RHT) {
          rht = new ucRHTRealTime();
          rht.cdev = glob.g_wr.floor2Devs[19+i];
          cntrs.Add(rht);
        } else {
          diffpres = new ucDiffPressRealTime();
          diffpres.cdev = glob.g_wr.floor2Devs[19+i];
          cntrs.Add(diffpres);
        }
      }
      RemoveControlsFromPanel(pnlFloor2_2);
      AddControlToPanel(pnlFloor2_2,cntrs);
      
    }
    private void floor3Populate() {
      int howMany = glob.g_wr.howManyDevsFloor3;
      if(howMany == 0)return;
      List<Control> cntrs = GimiListOfControls(glob.g_wr.floor3Devs,howMany);
      RemoveControlsFromPanel(pnlFloor3);
      AddControlToPanel(pnlFloor3,cntrs);
    }
    #endregion
    #region SQLite
    void sqlite_Changed(object sender, EventArgs e) {
      PopulateGrid();
    }
    void PopulateGrid() {
      DataSet ds = glob.sqlite.GimitblMess();
      if (ds == null) {
        return;
      }
      this.UIThread(() => this.dataGridView1.DataSource = ds.Tables[0].DefaultView);
      

      
    }
    #endregion

    private void pictureBox1_Click(object sender, EventArgs e) {
      frmAbout frm = new frmAbout();
      frm.ShowDialog();
    }

    private void label3_Click(object sender, EventArgs e) {
      
    }

    private void label6_Click(object sender, EventArgs e) {

    }

    private void pictureBox4_Click(object sender, EventArgs e) {
      frmChartDir frm = new frmChartDir();
      frm.ShowDialog(this);
    }
  }
}
