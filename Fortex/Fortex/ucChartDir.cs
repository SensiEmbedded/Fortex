
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ChartDirector;



namespace DiffPress {
  public partial class ucChartDir : UserControl {
    CGlobal glob;
    public DateTime[] timeStamps;
		public double[] dataSeriesA;
		public double[] dataSeriesB;
		// The earliest date and the duration in seconds for horizontal scrolling
		private DateTime minDate;
		private double dateRange;
		
		// The vertical range of the chart for vertical scrolling
		private double maxValue;
		private double minValue;
		
		// The current visible duration of the view port in seconds
		private double currentDuration = 360 * 86400;
		// In this demo, the maximum zoom-in is set to 10 days
		//private double minDuration = 86400;
    private double minDuration = 30;
	
		// Will set to true at the end of initialization
		private bool hasFinishedInitialization = false;
    public Layer lay=null;

    public ucChartDir() {
      System.Diagnostics.Debug.WriteLine("ucChartDir() 1");
      InitializeComponent();
      System.Diagnostics.Debug.WriteLine("ucChartDir() 2");
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
			//./this.UIThread(() => this.ShowVals());
		}
    #region InitFunctions
    private void ucChartDir_Load(object sender, EventArgs e) {
      Control parent= this.Parent;

      if (parent.GetType() == typeof(frmChartDir)) {
        // v desiged time e neshto drugo
        frmChartDir frm = (frmChartDir)parent;
        glob = ((frmMain)frm.Owner).glob;
      }
      
			if (glob == null) {
				//glob = ((frmMain)parent).glob;
        return;
			}
      PopulateStaticLabels();
      //loadData();
      /*
      // In this demo, we obtain the horizontal scroll range from the actual data.
			minDate = timeStamps[0];
			dateRange = timeStamps[timeStamps.Length - 1].Subtract(minDate).TotalSeconds;

			// Set the winChartViewer to reflect the visible and minimum duration
			winChartViewer1.ZoomInWidthLimit = minDuration / dateRange;
            winChartViewer1.ViewPortWidth = currentDuration / dateRange;
			winChartViewer1.ViewPortLeft = 1 - winChartViewer1.ViewPortWidth;

			// Initially choose the pointer mode (drag to scroll mode)
			pointerPB.Checked = true;
			

			// Can update chart now
			hasFinishedInitialization = true;
       */ 
			
    }
    

    private void PopulateStaticLabels() {
      if(cdev == null)return;
      if (cdev.type == TypeDevice.RHT) {
        cbShowHiAlarmsVal1.Text = "Temp High";
        cbShowLoAlarmsVal1.Text = "Temp Low";
        cbShowHiAlarmsVal2.Text = "RH High";
        cbShowLoAlarmsVal2.Text = "RH Low";
        cbShowHiAlarmsVal2.Visible = true;
        cbShowLoAlarmsVal2.Visible = true;
      } else {
        cbShowHiAlarmsVal1.Text = "Press High";
        cbShowLoAlarmsVal1.Text = "Press Low";
        cbShowHiAlarmsVal2.Text = "---";
        cbShowLoAlarmsVal2.Text = "---";
        cbShowHiAlarmsVal2.Visible = false;
        cbShowLoAlarmsVal2.Visible = false;
      
      }
    }
    #endregion
    #region Chart
    public WinChartViewer GimiChart() {
      return winChartViewer1;
    }
    public bool SetDataSet(System.Data.DataSet ds) {
      if (ds == null) {
        return false;
      }
      double t = cdev.val1;
      double t2= cdev.val2;
      DateTime dtv;
      DataTable dt = ds.Tables[0];
      int count = dt.Rows.Count;

      if (count == 0) {
        timeStamps = null;
        dataSeriesA = null;
        dataSeriesB = null;
        return false;
      } 
      timeStamps = new DateTime[count];
      dataSeriesA = new double[count];
      dataSeriesB = new double[count];

      int ix = 0;
      
      DataRow r;
      for (int i = count - 1; i >= 0; --i) {
        r = dt.Rows[i];
        dtv = Convert.ToDateTime( r["dt"]);
        timeStamps[count-1-i] = dtv;
        t = Convert.ToDouble(r["val1"]);
        dataSeriesA[count-1-i] = t;
        //dataSeriesA[]
        if (cdev.type == TypeDevice.RHT) {
          t2 = Convert.ToDouble(r["val2"]);
          dataSeriesB[count-1-i] = t2;
        }
      } 
      /*
      foreach(DataRow dr in dt.Rows){
        dtv = Convert.ToDateTime( dr["dt"]);
        timeStamps[ix] = dtv;
        t = Convert.ToDouble(dr["val1"]);
        dataSeriesA[ix] = t;
        //dataSeriesA[]
        //./chart1.Series[0].Points.AddXY(dtv, t);
        if (cdev.type == TypeDevice.RHT) {
          t2 = Convert.ToDouble(dr["val2"]);
          dataSeriesB[ix] = t2;
          //./chart1.Series[1].Points.AddXY(dtv, t2);
        }
        ++ix;
        //System.Diagnostics.Debug.WriteLine(dr["dt"].ToString());
        //System.Diagnostics.Debug.WriteLine(dr["val1"].ToString());
      } */ 
      
      //ArrayMath a = new ArrayMath(timeStamps);
      
      return true;
    }

    private void winChartViewer1_ViewPortChanged(object sender, WinViewPortEventArgs e)
		{
			// Compute the view port start date and duration
			//./DateTime currentStartDate = minDate.AddSeconds(Math.Round(winChartViewer1.ViewPortLeft * dateRange));
			//./currentDuration = Math.Round(winChartViewer1.ViewPortWidth * dateRange);

			// Synchronize the startDate and duration controls
      /*
			// Synchronize the horizontal scroll bar with the WinChartViewer
			hScrollBar1.Enabled = winChartViewer1.ViewPortWidth < 1;
			hScrollBar1.LargeChange = (int)Math.Ceiling(winChartViewer1.ViewPortWidth * 
				(hScrollBar1.Maximum - hScrollBar1.Minimum));
			hScrollBar1.SmallChange = (int)Math.Ceiling(hScrollBar1.LargeChange * 0.1);
			hScrollBar1.Value = (int)Math.Round(winChartViewer1.ViewPortLeft *
				(hScrollBar1.Maximum - hScrollBar1.Minimum)) + hScrollBar1.Minimum;

			// Synchronize the vertical scroll bar with the WinChartViewer
			vScrollBar1.Enabled = winChartViewer1.ViewPortHeight < 1;
			vScrollBar1.LargeChange = (int)Math.Ceiling(winChartViewer1.ViewPortHeight * 
				(vScrollBar1.Maximum - vScrollBar1.Minimum));
			vScrollBar1.SmallChange = (int)Math.Ceiling(vScrollBar1.LargeChange * 0.1);
			vScrollBar1.Value = (int)Math.Round(winChartViewer1.ViewPortTop * 
				(vScrollBar1.Maximum - vScrollBar1.Minimum)) + vScrollBar1.Minimum;
        */
			// Update chart and image map if necessary
			if (e.NeedUpdateChart)
				drawChart(winChartViewer1);
			if (e.NeedUpdateImageMap)
				updateImageMap(winChartViewer1);
		}
    private void updateImageMap(WinChartViewer viewer)
		{
			// Include tool tip for the chart
			if (winChartViewer1.ImageMap == null){
				winChartViewer1.ImageMap = winChartViewer1.Chart.getHTMLImageMap("clickable", "",
					"title='[{dataSetName}] {x|yyyy mm dd \n hh:mm:ss}: value {value|2}'");
        
        //plotToolBarStandard1.Plot = 
			}
		}
    private void drawChart(WinChartViewer viewer) {

      DateTime viewPortStartDate = minDate.AddSeconds(Math.Round(viewer.ViewPortLeft * dateRange));
			DateTime viewPortEndDate = viewPortStartDate.AddSeconds(Math.Round(viewer.ViewPortWidth * dateRange));

      // Create an XYChart object 600 x 300 pixels in size, with pale blue (0xf0f0ff) 
			// background, black (000000) border, 1 pixel raised effect, and with a rounded frame.
			XYChart c = new XYChart(2*450, 2*250, 0xf0f0ff, 0, 1);
			c.setRoundedFrame(Chart.CColor(BackColor));
			
			// Set the plotarea at (52, 60) and of size 520 x 192 pixels. Use white (ffffff) 
			// background. Enable both horizontal and vertical grids by setting their colors to 
			// grey (cccccc). Set clipping mode to clip the data lines to the plot area.
			c.setPlotArea(42, 58, 2*450-50, 2*250 - 100, 0xffffff, -1, -1, 0xcccccc, 0xcccccc);
			c.setClipping();

			// Add a top title to the chart using 15 pts Times New Roman Bold Italic font, with a 
			// light blue (ccccff) background, black (000000) border, and a glass like raised effect.
      if (cdev.type == TypeDevice.RHT) {
        c.addTitle("RH & T recorded data", "Times New Roman Bold Italic", 10).setBackground(0xccccff, 0x0, Chart.glassEffect());
      } else {
        c.addTitle("Diff. Pressure recorded data", "Times New Roman Bold Italic", 10).setBackground(0xccccff, 0x0, Chart.glassEffect());
      }

			// Add a bottom title to the chart to show the date range of the axis, with a light blue 
			// (ccccff) background.
                          
      //c.addTitle2(Chart.Bottom, "From <*font=Arial Bold Italic*>" 
      //    + c.formatValue(viewPortStartDate, "{value|mmm dd, yyyy}") 
      //  + "<*/font*> to <*font=Arial Bold Italic*>" 
      //  + c.formatValue(viewPortEndDate, "{value|mmm dd, yyyy}") 
      //  + "<*/font*> (Duration <*font=Arial Bold Italic*>" 
      //  + Math.Round(viewPortEndDate.Subtract(viewPortStartDate).TotalSeconds / 86400.0)
      //  + "<*/font*> days)", "Arial Italic", 10).setBackground(0xccccff);
                            
			// Add a legend box at the top of the plot area with 9pts Arial Bold font with flow layout. 
			c.addLegend(50, 33, false, "Arial Bold", 9).setBackground(Chart.Transparent, Chart.Transparent);

			// Set axes width to 2 pixels
			c.yAxis().setWidth(2);
			c.xAxis().setWidth(2);
      c.xAxis().setLabelFormat("{value|yy/mm/dd \n hh:nn:ss}, ");
      
      
      //c.xAxis().setLabelGap(50);

			// Add a title to the y-axis
			//./c.yAxis().setTitle("RH(%) Temperature", "Arial Bold", 9);
      

			///////////////////////////////////////////////////////////////////////////////////////
			// Step 2 - Add data to chart
			///////////////////////////////////////////////////////////////////////////////////////
		
			// 
			// In this example, we represent the data by lines. You may modify the code below if 
			// you want to use other representations (areas, scatter plot, etc).
			//

			// Add a line layer for the lines, using a line width of 2 pixels
			Layer layer = c.addLineLayer2();
      lay = layer;
			layer.setLineWidth(2);

			// Now we add the 3 data series to a line layer, using the color red (ff0000), green
			// (00cc00) and blue (0000ff)
			layer.setXData(timeStamps);
			//layer.addDataSet( dataSeriesA , 0xff0000, "Temp");
			//layer.addDataSet(dataSeriesB, 0x00cc00, "RH");
      if (cdev.type == TypeDevice.RHT) {
        layer.addDataSet(dataSeriesA, 0xff0000, "Temp").setDataSymbol(Chart.DiamondSymbol, 7);
			  layer.addDataSet(dataSeriesB, 0x00cc00, "RH").setDataSymbol(Chart.SquareSymbol, 7);
      } else {
        layer.addDataSet(dataSeriesA, 0xff0000, "Pressure").setDataSymbol(Chart.DiamondSymbol, 7);
			  
      }
      
      
			///////////////////////////////////////////////////////////////////////////////////////
			// Step 3 - Set up x-axis scale
			///////////////////////////////////////////////////////////////////////////////////////
			
			// Set x-axis date scale to the view port date range. 
			c.xAxis().setDateScale(viewPortStartDate, viewPortEndDate);
      c.xAxis().setLabelStep(1);
      

			
			///////////////////////////////////////////////////////////////////////////////////////
			// Step 4 - Set up y-axis scale
			///////////////////////////////////////////////////////////////////////////////////////
			
      if ((viewer.ZoomDirection == WinChartDirection.Horizontal) || (minValue == maxValue)){
				// y-axis is auto-scaled - save the chosen y-axis scaled to support xy-zoom mode
				c.layout();
				minValue = c.yAxis().getMinValue();
				maxValue = c.yAxis().getMaxValue();
			}else{
				// xy-zoom mode - compute the actual axis scale in the view port 
        //maxValue = 110;
        //minValue = -20109;
				double axisLowerLimit =  maxValue - (maxValue - minValue) * (viewer.ViewPortTop + viewer.ViewPortHeight);
				double axisUpperLimit =  maxValue - (maxValue - minValue) * viewer.ViewPortTop;
				// *** use the following formula if you are using a log scale axis ***
				// double axisLowerLimit = maxValue * Math.Pow(minValue / maxValue, viewer.ViewPortTop + viewer.ViewPortHeight);
				// double axisUpperLimit = maxValue * Math.Pow(minValue / maxValue, viewer.ViewPortTop);
				// use the zoomed-in scale
				c.yAxis().setLinearScale(axisLowerLimit, axisUpperLimit);
				c.yAxis().setRounding(false, false);
			}
      ///////////////////////////////////////////////////////////////////////////////////////
			// Step - Make line for Alarm limits
			///////////////////////////////////////////////////////////////////////////////////////
      ShowAlarmsInChart(c);
      
			///////////////////////////////////////////////////////////////////////////////////////
			// Step 5 - Display the chart
			///////////////////////////////////////////////////////////////////////////////////////
      //./c.yAxis().setAutoScale();
			viewer.Chart = c;
      viewer.ZoomDirection = WinChartDirection.HorizontalVertical;
		  viewer.ScrollDirection = WinChartDirection.HorizontalVertical;
    }
    
    private void ShowRHAlarms(XYChart c){
      //Red temperatura, Green - RH
      double alTempHi = cdev.alarmHiTemp;
      double alTempLo = cdev.alarmLoTemp;
      double alRHHi = cdev.alarmHiRH;
      double alRHLo = cdev.alarmLoRH;

      Mark m = null;

      if (cbShowHiAlarmsVal1.Checked == true) {
        m = c.yAxis().addMark(alTempHi, 0xff0000, "AlarmTHi = " + alTempHi.ToString());
        m.setAlignment(Chart.Left);
        m.setBackground(0xffcccc);
      }
      if (cbShowLoAlarmsVal1.Checked == true) {
        m = c.yAxis().addMark(alTempLo, 0xff0000, "AlarmTLo = " + alTempLo.ToString());
        m.setAlignment(Chart.Left);
        m.setBackground(0xffcccc);
      }
      if (cbShowLoAlarmsVal2.Checked == true) {
        m = c.yAxis().addMark(alRHLo, 0x00ff00, "AlarmRhLo = " + alRHLo.ToString());
        m.setAlignment(Chart.Right);
        m.setBackground(0xccffcc);
      }
      if (cbShowHiAlarmsVal2.Checked == true) {
        m = c.yAxis().addMark(alRHHi, 0x00ff00, "AlarmRhHi = " + alRHHi.ToString());
        m.setAlignment(Chart.Right);
        m.setBackground(0xccffcc);
      }

    }
    private void ShowPressureAlarms(XYChart c){
      //Red temperatura, Green - RH
      double alDiffHi = cdev.alarmHiDiffPress;
      double alDiffLo = cdev.alarmLoDiffPress;
      
      Mark m = null;

      if (cbShowHiAlarmsVal1.Checked == true) {
        m = c.yAxis().addMark(alDiffHi, 0xff0000, "AlarmTHi = " + alDiffHi.ToString());
        m.setAlignment(Chart.Left);
        m.setBackground(0xffcccc);
      }
      if (cbShowLoAlarmsVal1.Checked == true) {
        m = c.yAxis().addMark(alDiffLo, 0xff0000, "AlarmTLo = " + alDiffLo.ToString());
        m.setAlignment(Chart.Left);
        m.setBackground(0xffcccc);
      }
      
    }
    private void ShowAlarmsInChart(XYChart c) {
      if(cdev == null )return;
      if (cdev.type == TypeDevice.RHT) {
        ShowRHAlarms(c);
      } else {
        ShowPressureAlarms(c);
      }
    }

   
    /// <summary>
		/// CheckChanged event for the pointerPB.
		/// </summary>
		private void pointerPB_CheckedChanged(object sender, System.EventArgs e)
		{
			pointerPB.BackColor = pointerPB.Checked ? Color.PaleGreen : pointerPB.Parent.BackColor;
			if (pointerPB.Checked)
				winChartViewer1.MouseUsage = WinChartMouseUsage.ScrollOnDrag;
		}

		/// <summary>
		/// CheckChanged event for the zoomInPB.
		/// </summary>
		private void zoomInPB_CheckedChanged(object sender, System.EventArgs e)
		{
			zoomInPB.BackColor = zoomInPB.Checked ? Color.PaleGreen : zoomInPB.Parent.BackColor;
			if (zoomInPB.Checked)
				winChartViewer1.MouseUsage = WinChartMouseUsage.ZoomIn;
		}

		/// <summary>
		/// CheckChanged event for the zoomOutPB.
		/// </summary>
		private void zoomOutPB_CheckedChanged(object sender, System.EventArgs e)
		{
			zoomOutPB.BackColor = zoomOutPB.Checked ? Color.PaleGreen : zoomOutPB.Parent.BackColor;
			if (zoomOutPB.Checked)
				winChartViewer1.MouseUsage = WinChartMouseUsage.ZoomOut;
		}

		/// <summary>
		/// CheckChanged event for the xZoomPB. Sets X-Zoom / Y-Axis auto-scaled mode.
		/// </summary>
		private void xZoomPB_CheckedChanged(object sender, System.EventArgs e)
		{
			
		}

		/// <summary>
		/// CheckChanged event for the xZoomPB. Set XY-Zoom mode.
		/// </summary>
		private void xyZoomPB_CheckedChanged(object sender, System.EventArgs e)
		{
		  // Horizontal and Vertical zooming and scrolling
		  winChartViewer1.ZoomDirection = WinChartDirection.HorizontalVertical;
		  winChartViewer1.ScrollDirection = WinChartDirection.HorizontalVertical;
		}
    /// <summary>
		/// Validate duration and updates WinChartViewer.ViewPortWidth to reflect the duration.
		/// </summary>
		private void validateDuration(string dur)
		{
			// Parse the duration text
			double newDuration = 0;
			try { newDuration = Double.Parse(dur) * 86400; } 
			catch {}

			// Duration too short or not numeric?
			if (newDuration < minDuration) 
				newDuration = minDuration;

			if (hasFinishedInitialization && (newDuration != currentDuration)){
				// Set the ViewPortWidth according to the new duration
				currentDuration = newDuration;
				winChartViewer1.ViewPortWidth = newDuration / dateRange;
				winChartViewer1.updateViewPort(true, false);
			}
		}
		#endregion
    public void UpdatePlot(System.Data.DataSet ds) {
      if (SetDataSet(ds) == false) {
        winChartViewer1.updateViewPort(true,true);
        return ;
      }
      minDate = timeStamps[0];
      minDate = minDate.AddSeconds(-10); 
			dateRange = timeStamps[timeStamps.Length - 1].Subtract(minDate).TotalSeconds;
      dateRange += 10;

      
      minValue = dataSeriesA.Min();
      maxValue = dataSeriesA.Max();
      double mn = dataSeriesB.Min();
      double mx = dataSeriesB.Max();
      if(minValue > mn)minValue=mn;
      if(maxValue < mx)maxValue=mx;
      minValue -= 2;
      maxValue += 2;
      if(minValue < -20000)minValue = -20050;//da se vizda po-hubavo

      maxValue = 100;//ebal sym go

      nudUpper.Value = (decimal)maxValue;
      nudDown.Value = (decimal)minValue;


      //minValue i maxValue sa Limiti na zoom-a

			// Set the winChartViewer to reflect the visible and minimum duration
			//./winChartViewer1.ZoomInWidthLimit = minDuration / dateRange;
      //winChartViewer1.ZoomInWidthLimit = 0.00001;
      //./winChartViewer1.ViewPortWidth = currentDuration / dateRange;
      //winChartViewer1.ViewPortWidth = 0.00001;
			//./winChartViewer1.ViewPortLeft = 1 - winChartViewer1.ViewPortWidth;

			// Initially choose the pointer mode (drag to scroll mode)
			pointerPB.Checked = true;
			// Can update chart now
			hasFinishedInitialization = true;
      //XYChart c = (XYChart)winChartViewer1.Chart;
      //MessageBox.Show( c.yAxis().getMinValue().ToString());
			winChartViewer1.updateViewPort(true, true);

    }

    private void cbShowHiAlarmsVal1_CheckedChanged(object sender, EventArgs e) {
      winChartViewer1.updateViewPort(true, true);
    }

    private void nudUpper_ValueChanged(object sender, EventArgs e) {
      maxValue = (double)nudUpper.Value;
      winChartViewer1.updateViewPort(true, true);
    }

    private void nudDown_ValueChanged(object sender, EventArgs e) {
      minValue = (double)nudDown.Value;
      winChartViewer1.updateViewPort(true, true);
    }

  }
}
