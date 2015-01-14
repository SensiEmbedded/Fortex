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
    CGlobal glob = new CGlobal();
    int sample1s = 0;
    int sample2s = 0;
    int sample4s = 0;
    bool fullScreen = false;
    
    

    public frmMain() {
      InitializeComponent();
    }
    
    private void Form1_Load(object sender, EventArgs e) {

      glob.comm.SetRef(ref glob);
      glob.comm.devs.devVir.Changed += new ChangedEventHandler(devVir_Changed);
      glob.mssql.SetRef(ref glob);

      GoFullscreen(glob.g_wr.fullScreen);
      fullScreen = glob.g_wr.fullScreen;
      ucValue1.SetRef(ref glob);
      ucValue2.SetRef(ref glob);
      ucValue3.SetRef(ref glob);
      ucValue1.isOutOfRange = false;
      ucValue2.isOutOfRange = true;
      ucValue3.isOutOfRange = false;
      glob.sqlite.Changed += new ChangedEventHandler(sqlite_Changed);

      //string str = "basi basi";
      //str.AssenMethod();
      //lblTest.AssenMethod2();
      //this.AssenMethod2();
      //string fae = "sss";

      
      //  progressBar1.Increment(1);
        //Thread.Sleep(1000);
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
    private void UpdateChart(){
      DateTime baseDate = DateTime.Today;

      double t = glob.comm.devs.devVir.pressure[5];
      double t2= glob.comm.devs.devVir.pressure[6];
      double t3 = glob.comm.devs.devVir.pressure[7];
      chart1.Series[0].Points.AddXY(DateTime.Now, t);
      chart1.Series[1].Points.AddXY(DateTime.Now, t2);
      chart1.Series[2].Points.AddXY(DateTime.Now, t3);
      if (count < 50) {
       ++count;
     } else {
       chart1.Series[0].Points.RemoveAt(0);
       chart1.Series[1].Points.RemoveAt(0);
       chart1.Series[2].Points.RemoveAt(0);
     }
      // Adjust Y & X axis scale
      chart1.ResetAutoValues();
      // Redraw chart
      chart1.Invalidate();
    }
    Random rnd = new Random();
    int count = 0;
    private void TestChart() {
      DateTime baseDate = DateTime.Today;

      int t = rnd.Next(100);
      int t2 = rnd.Next(100);
      int t3 = rnd.Next(100);

     //if (count >= 2 && count <= 5) {
      // chart1.DataManipulator.InsertEmptyPoints(1,System.Windows.Forms.DataVisualization.Charting.IntervalType.Days, "DiffPress1");
       
     //}else{
      chart1.Series[0].Points.AddXY(DateTime.Now, t);
      chart1.Series[1].Points.AddXY(DateTime.Now, t2);
      chart1.Series[2].Points.AddXY(DateTime.Now, t3);
     //}

     if (count < 100) {
       ++count;
     } else {
       chart1.Series[0].Points.RemoveAt(0);
       chart1.Series[1].Points.RemoveAt(0);
       chart1.Series[2].Points.RemoveAt(0);
     }
     

      // Adjust Y & X axis scale
      chart1.ResetAutoValues();

      // Redraw chart
      chart1.Invalidate();
      
    }
    private void UpdateBarGraphs() {
      ucValue1.Update(5);
      ucValue2.Update(6);
      ucValue3.Update(7);
      
    }
    private void UpdateStatus() {
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
        
      
      }
    }
    private void tmrUpdateGUI_Tick(object sender, EventArgs e) {
      //tick on every 500 ms


      if (++sample1s < 2) return;
      sample1s = 0;
      
      UpdateClock();
      UpdateStatus();

      if (++sample2s < 2) return;
      sample2s = 0;
      UpdateChart();
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
      chart1.Series[0].Enabled = chbDiff1.Checked;
      chart1.Series[1].Enabled = chbDiff2.Checked;
      chart1.Series[2].Enabled = chbDiff3.Checked;
    }
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
  }
}
