using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using aUtils;
using ChartDirector;
using System.IO;

namespace DiffPress {
	public partial class frmChartDir : Form {
		CGlobal glob;
    string alarmExplanation;
    bool isAlarmTemp = false;
    bool isAlarmRH = false;
    Color colorControl;
    System.Data.DataSet dataset;
    

		public frmChartDir() {
      System.Diagnostics.Debug.WriteLine("Init Component 1");
			InitializeComponent();
      System.Diagnostics.Debug.WriteLine("Init Component 2");
		}
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
			if (keyData == Keys.Escape) {
				this.Close();
				return true;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}
		public void SetRef(ref CGlobal rfGl) {
      glob = rfGl;
     
    }
		private CDev _cdev=null;
		public CDev cdev {
			get{return _cdev;}
			set {
				_cdev = value;
        ucChartDir1.cdev = _cdev;
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
			//./this.UIThread(() => this.ShowVals());
		}

		private void frmChartDir_Load(object sender, EventArgs e) {
      System.Diagnostics.Debug.WriteLine("private void frmChartDir_Load(object sender, EventArgs e)");
      Control parent= this.Owner;
      if (parent != null) {
        glob = ((frmMain)parent).glob;
        ucChartDir1.cdev = cdev;
      }
      PopulateStaticLabels();
      //./InitChart();
      //PopulateGrid();
      glob.data.Changed += new ChangedEventHandler(data_Changed);
		}
    
    void PopulateStaticLabels() {
      
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
     #region SQLite Data
    void PopulateGridAlarm() {
      System.Data.DataSet ds = glob.data.GimiLast100AlarmsID(cdev.strID);
      if (ds == null) {
        return;
      }
      this.dgvAlarms.DataSource = ds.Tables[0].DefaultView;
      dataGridView1.Columns["dt"].HeaderText = "Date Time"; 
      dataGridView1.Columns["device"].HeaderText = "Device ID"; 
    }
    void PopulateGrid(System.Data.DataSet ds) {
      //DataSet ds = glob.data.GimitblMess(cdev.strID);
      
      if (ds == null) {
        return;
      }
      //this.UIThread(() => this.dataGridView1.DataSource = ds.Tables[0].DefaultView);
      /*
      ds.Tables[0].Columns["dt"].ColumnName = "Date Time";
      ds.Tables[0].Columns["device"].ColumnName = "Device ID";
      if (cdev.type == TypeDevice.RHT) {
        ds.Tables[0].Columns["val1"].ColumnName = "Temp";
        ds.Tables[0].Columns["val2"].ColumnName = "RH";
      } else {
        ds.Tables[0].Columns["val1"].ColumnName = "Pressure";
      } */
      this.dataGridView1.DataSource = ds.Tables[0].DefaultView;

      dataGridView1.Columns["dt"].HeaderText = "Date Time"; 
      dataGridView1.Columns["device"].HeaderText = "Device ID"; 
      if (cdev.type == TypeDevice.RHT) {
        dataGridView1.Columns["val1"].HeaderText = "Temp";
        dataGridView1.Columns["val2"].HeaderText = "RH";
      } else {
        dataGridView1.Columns["val1"].HeaderText = "Pressure";
      } 
      //UpdateChart(ds.Tables[0]);
   
    }
    #endregion
    void data_Changed(object sender, EventArgs e) {
      //PopulateGrid();
      ShowVals();
      ShowAlarms();
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
    }

   

    private void btnSelect_Click(object sender, EventArgs e) {
      dataset = glob.data.GimitblMess(cdev.type,cdev.strID, dtpStart.Value,dtpEnd.Value,(int)nudLimit.Value);
      /*if (dataset == null) {
        return;
      } */
      //this.UIThread(() => this.dataGridView1.DataSource = ds.Tables[0].DefaultView);
      PopulateGrid(dataset);
      ucChartDir1.UpdatePlot(dataset);
      PopulateGridAlarm();
      DataTable dt = MakeStat();
      dgvStatistic.DataSource = dt;
    }
    #region  Report
    string MakeImageSrcData(string filename) {
      FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
      byte[] filebytes = new byte[fs.Length];
      fs.Read(filebytes, 0, Convert.ToInt32(fs.Length));
      return "data:image/png;base64," +
        Convert.ToBase64String(filebytes, Base64FormattingOptions.None);
    }
    private string GimiImgTag(string imgPath) {
      string imghtml;
      imghtml = "<img src=\"" + MakeImageSrcData(imgPath) + "\"/>";
      return imghtml;
    }

    string MakeImageFromChart() {
      WinChartViewer viewChart = ucChartDir1.GimiChart();
      XYChart c = (XYChart)viewChart.Chart;
      if (c == null) {
        return "none";
      }
      byte[] filebytes = c.makeChart2(0);
      return "data:image/png;base64," +
        Convert.ToBase64String(filebytes, Base64FormattingOptions.None);
    }
    
    private string GimiImgChart() {
      string imghtml;
      //739, 414
      imghtml = "<img height='414' width='739' src=\"" + MakeImageFromChart() + "\"/>";
      return imghtml;
    }
    string PlotStartDate() {
      WinChartViewer viewChart = ucChartDir1.GimiChart();
      XYChart c = (XYChart)viewChart.Chart;
      if (c == null) {
        return "none";
      }
      
      double d = c.xAxis().getMinValue();
      DateTime dt = ChartDirector.Chart.NTime(d);
      return CUtils.GimiGlobalDateTime(dt);
    }
    string PlotEndtDate() {
      WinChartViewer viewChart = ucChartDir1.GimiChart();
      XYChart c = (XYChart)viewChart.Chart;
      if (c == null) {
        return "none";
      }
      double d = c.xAxis().getMaxValue();
      DateTime dt = ChartDirector.Chart.NTime(d);
      return CUtils.GimiGlobalDateTime(dt);
    }
    string TypeCurrDevice() {
      if (cdev.type == TypeDevice.RHT) {
        return "RH&T";
      }
      return "Diff.Pressure";
    }
    string AlarmTable() {
      string table = "<table  align='center'> \n";
      table += "<col width='230' >\n";
      table += "<col width='200'>\n";
      table += "<th>ID</th>";
      table += "<th>Date Time</th>";
      table += "<th>val</th>";
      table += "<th>Message</th>";

      DataView dv = (DataView)dgvAlarms.DataSource;
      
      DataTable dt = (DataTable)dv.Table;
      
      if (dt == null)
        return "none";

      foreach (DataRow dr in dt.Rows) {
        table += "<tr>";

        table += "<td align='center'>";
        table += dr["ID"];
        table += "</td>";

        table += "<td  align='center'>";
        table += dr["dt"];
        table += "</td>";

        table += "<td  align='center'>";
        table += dr["val"];
        table += "</td>";

        table += "<td  align='center'>";
        table += dr["mess"];
        table += "</td>";

        table += "</tr>";
      }

      table += "</table";
      return table;
    }
    string StatTable() {
      string table = "<table  align='center'> \n";
      table += "<col width='230' >\n";
      table += "<col width='200'>\n";
      table += "<th>name</th>";
      table += "<th>val</th>";


      DataTable dt = (DataTable)dgvStatistic.DataSource;
      
      if (dt == null)
        return "none";

      foreach (DataRow dr in dt.Rows) {
        table += "<tr>";
        table += "<td align='right'>";
        table += dr[0];
        table += "</td>";
        table += "<td  align='left'>";
        table += dr[1];
        table += "</td>";
        table += "</tr>";
      }

      table += "</table";
      return table;
    }
    string TableData() {
      if (dataset == null)
        return "none";
      if(cbIncludeDataTable.Checked == false)
        return "none";

      /*
       * 
       <table style="width:100%">
        <tr>
        <td>Jill</td>
        <td>Smith</td> 
      </tr>
      </table>*/
      string table = "<table  align='center'>";
      table += "<col width='230' >\n";
      table += "<col width='200'>\n";
      table += "<col width='200'>\n";

      table += "<th>DateTime</th>";
      if (cdev.type == TypeDevice.RHT) {
        table += "<th>Temp</th>";
        table += "<th>RH</th>";
      } else {
        table += "<th>Pressure</th>";
      }
      
      DataTable dt = dataset.Tables[0];
      if(dt == null)return "none";
      int count = dt.Rows.Count;
      DataRow r;
      DateTime dtv;
      double t,t2;
      for (int i = count - 1; i >= 0; --i) {
        //"<tr><td>Jill</td><td>Smith</td>  </tr> </table>"
        r = dt.Rows[i];
        table += "<tr>";
        table += "<td>";
        dtv = Convert.ToDateTime( r["dt"]);
        table += CUtils.GimiGlobalDateTime(dtv);
        table += "</td>";

        table += "<td>";
        t = Convert.ToDouble(r["val1"]);
        table += t.ToString("N1");
        table += "</td>";

        if (cdev.type == TypeDevice.RHT) {
          table += "<td>";
          t = Convert.ToDouble(r["val2"]);
          table += t.ToString("N1");
          table += "</td>";
        }
        table += "</tr>";
      } 
      //string table = "<table style='width:100%'><tr><td>Jill</td><td>Smith</td>  </tr> </table>";
      //string table = "<table style='width:100%'><tr><td>Jill</td><td>Smith</td>  </tr> </table>";
      table += "</table";
      return table;
    }
    private string SetOutputFile(string filter) {
      SaveFileDialog saveFileDialog1 = new SaveFileDialog();
      //saveFileDialog1.Filter = "html files|*.html|All files|*.*";
      saveFileDialog1.Filter = filter;
      saveFileDialog1.Title = "Generate Report File ";
      saveFileDialog1.AddExtension = true;
      saveFileDialog1.OverwritePrompt = true;
      saveFileDialog1.ShowDialog();

      // If the file name is not an empty string open it for saving.
      if (saveFileDialog1.FileName != "") {
        return saveFileDialog1.FileName;
      } else {
        return null;
      }
    }
    private void MakeReport() {
      string outputFile = SetOutputFile("html files|*.html|All files|*.*");
      if(outputFile == null)return;
      string pathTemplate = Application.StartupPath + @"\reportTemplate.html";
      string text = System.IO.File.ReadAllText(pathTemplate);
      text = text.Replace("<!--CurrDate-->",CUtils.GimiGlobalDateTime(DateTime.Now));
      text = text.Replace("<!--SensorName-->",cdev.name);
      text = text.Replace("<!--SensorID-->",cdev.strID);
      text = text.Replace("<!--SensorType-->",TypeCurrDevice());
      text = text.Replace("<!--StartDate-->",PlotStartDate());
      text = text.Replace("<!--EndDate-->",PlotEndtDate());
      text = text.Replace("<!--StatTable-->",StatTable());
      text = text.Replace("<!--AlarmTable-->",AlarmTable());
      text = text.Replace("<!--Plot-->",GimiImgChart());
      text = text.Replace("<!--DataTable-->",TableData());
      System.IO.File.WriteAllText(outputFile,text);
      System.Diagnostics.Process.Start(outputFile);
    }
    private void btnReport_Click(object sender, EventArgs e) {
      try{
        MakeReport();
      }catch(Exception ex){
        MessageBox.Show(ex.Message);
        glob.sqlite.LogMessage(ex.Message);
      }
    }
		#endregion
    #region CSV
    public static void CSVWriteDataTable(DataTable sourceTable, TextWriter writer, bool includeHeaders) {
      if (includeHeaders) {
        List<string> headerValues = new List<string>();
        foreach (DataColumn column in sourceTable.Columns) {
          headerValues.Add(QuoteValue(column.ColumnName));
        }

        writer.WriteLine(String.Join(",", headerValues.ToArray()));
      }

      string[] items = null;
      string line;
      foreach (DataRow row in sourceTable.Rows) {
        line = row["ID"] + "," + CUtils.GimiGlobalDateTime(Convert.ToDateTime(row["dt"]) ) + "," + row["val1"]+"," + row["val2"]; 
        //items = row.ItemArray.Select(o => QuoteValue(o.ToString())).ToArray();
        writer.WriteLine(line);
        //writer.WriteLine(String.Join(",", items));
      }

      writer.Flush();
    }
    private static string QuoteValue(string value) {
      return value;
      //./return String.Concat("\"", value.Replace("\"", "\"\""), "\"");
    }

    private void MakeCSV() {
      string outputFile = SetOutputFile("scv files|*.csv|All files|*.*");
      if(outputFile == null)return;
      if(dataset == null)return;
      if(dataset.Tables.Count == 0)return;

      using (StreamWriter writer = new StreamWriter(outputFile)) {
        CSVWriteDataTable(dataset.Tables[0], writer, true);
      }
    }
    private void button1_Click_1(object sender, EventArgs e) {
      MakeCSV();
    }
    #endregion
    private void SetArrayMath() {
      DataTable dt = dataset.Tables[0];
      
      
      
    }
    private DataTable MakeStat() {
      DataTable dt = new DataTable("Statistic");
      dt.Columns.Add("name", typeof(string));
      dt.Columns.Add("val", typeof(string));
      //-----------------------------
      if (ucChartDir1.dataSeriesA == null ) {
        return dt;
      }
      //-------- remove error codes
      int howMany = ucChartDir1.dataSeriesA.Length;
      ArrayList dts = new ArrayList();
      ArrayList vals1 = new ArrayList();
      ArrayList vals2 = new ArrayList();
      
      for (int i = 0; i < howMany; ++i) {
        if (ucChartDir1.dataSeriesA[i] > -20000 && ucChartDir1.dataSeriesB[i] > -20000) {
          dts.Add(ucChartDir1.timeStamps[i]);
          vals1.Add(ucChartDir1.dataSeriesA[i]);
          vals2.Add(ucChartDir1.dataSeriesB[i]);
        }
      }

      double[] d1 = vals1.ToArray(typeof(double)) as double[];
      double[] d2 = vals2.ToArray(typeof(double)) as double[];
      //double[] d1 = (double[])vals1.ToArray(typeof(double));



      //var arr1 = ucChartDir1.dataSeriesA.Where(e => e > -20000);
      //var arr2 = ucChartDir1.dataSeriesB.Where(e => e > -20000);

      ArrayMath armVal1 = new ArrayMath(d1);
      ArrayMath armVal2 = new ArrayMath(d2);
      
      // double[] arr1 = ucChartDir1.dataSeriesA.Select(e => e > -20000);

     
      //-----------------------------
      int ix;
      dt.Rows.Add("Sensor Name",cdev.name);
      dt.Rows.Add("Sensor ID", cdev.strID);
      dt.Rows.Add("Sensor Type", cdev.type.ToString());


      dt.Rows.Add("Start Date", CUtils.GimiGlobalDateTime((DateTime)dts[0]));
      dt.Rows.Add("End Date", CUtils.GimiGlobalDateTime((DateTime)dts[dts.Count - 1]));

      dt.Rows.Add("Number of records", dts.Count);

      if(cdev.type == TypeDevice.RHT){

        dt.Rows.Add("Max Temperature", armVal1.max());
        ix = armVal1.maxIndex();
        dt.Rows.Add("Max Temp. DateTime", dts[ix]);

        dt.Rows.Add("Min Temperature", armVal1.min());
        ix = armVal1.minIndex();
        dt.Rows.Add("Min Temp. DateTime", dts[ix]);

        dt.Rows.Add("Average Temperature", armVal1.avg().ToString("N1"));

        dt.Rows.Add("Max Humidity", armVal2.max());
        ix = armVal2.maxIndex();
        dt.Rows.Add("Max Hum. DateTime", dts[ix]);

        dt.Rows.Add("Min Humidity", armVal2.min());
        ix = armVal2.minIndex();
        dt.Rows.Add("Min Hum. DateTime", dts[ix]);

        dt.Rows.Add("Average Humidity", armVal2.avg().ToString("N1"));
        
        
      }else{
        dt.Rows.Add("Max Pressure", armVal1.max());
        ix = armVal1.maxIndex();
        dt.Rows.Add("Max Pressure. DateTime", dts[ix]);

        dt.Rows.Add("Min Pressure", armVal1.min());
        ix = armVal1.minIndex();
        dt.Rows.Add("Min Pressure. DateTime", dts[ix]);

        dt.Rows.Add("Average Pressure", armVal1.avg().ToString("N1"));

      }
            
      
      
      //./ArrayMath m = new ArrayMath(viewPortTimeStamps);

      return dt;
    }
    private void button1_Click(object sender, EventArgs e) {
      DataTable dt = MakeStat();
      dgvStatistic.DataSource = dt;
    }

    
    
    

	}
}
