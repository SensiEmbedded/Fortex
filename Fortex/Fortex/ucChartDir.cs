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
    private DateTime[] timeStamps;
		private double[] dataSeriesA;
		private double[] dataSeriesB;
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

    public ucChartDir() {
      InitializeComponent();
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
      System.Data.DataSet ds = glob.data.GimitblMess(cdev.type,cdev.strID, dtpStart.Value,dtpEnd.Value,(int)nudLimit.Value);
      SetDataSet(ds);
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
			winChartViewer1.updateViewPort(true, true);
    }
    #region Chart
    public bool SetDataSet(System.Data.DataSet ds) {
      if (ds == null) {
        return false;
      }
      double t = cdev.val1;
      double t2= cdev.val2;
      DateTime dtv;
      DataTable dt = ds.Tables[0];
      int count = dt.Rows.Count;

      if(count == 0)return false;
      timeStamps = new DateTime[count];
      dataSeriesA = new double[count];
      dataSeriesB = new double[count];

      int ix = 0;
      /*
      DataRow r;
      for (int i = count - 1; i >= 0; --i) {
        r = dt.Rows[i];
        dtv = Convert.ToDateTime( r["dt"]);
        timeStamps[i] = dtv;
        t = Convert.ToDouble(r["val1"]);
        dataSeriesA[i] = t;
        //dataSeriesA[]
        if (cdev.type == TypeDevice.RHT) {
          t2 = Convert.ToDouble(r["val2"]);
          dataSeriesB[i] = t2;
        }
      } */
      
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
      }  
      
      //ArrayMath a = new ArrayMath(timeStamps);
      
      return true;
    }

		private void loadData()
		{
			// In this demo, we allow scrolling for the last 5 years.
			DateTime lastDate = DateTime.Now.Date;
			DateTime firstDate = DateTime.Now.Date.AddYears(-5);

			// The initial view port is to show 1 year of data.
			currentDuration = lastDate.Subtract(DateTime.Now.Date.AddYears(-1)).TotalSeconds;

			//
			// Get the data and stores them in a memory buffer for fast scrolling / zooming. In 
			// this demo, we just use a random number generator. In practice, you may get the data
			// from a database or XML or by other means. (See the ChartDirector documentation on 
			// "Using Data Sources with ChartDirector" if you need some sample code on how to read
			// data from database to array variables.)
			//

			// Set up random number generator
			RanTable r = new RanTable(127, 4, lastDate.Subtract(firstDate).Days + 1);
			r.setDateCol(0, firstDate, 86400);
			r.setCol(1, 150, -10, 10);
			r.setCol(2, 200, -10, 10);
			r.setCol(3, 250, -10, 10);
			
			// Read random data into the data arrays
			timeStamps = Chart.NTime(r.getCol(0));
			dataSeriesA = r.getCol(1);
			dataSeriesB = r.getCol(2);
			
		}
    private void winChartViewer1_ViewPortChanged(object sender, WinViewPortEventArgs e)
		{
			// Compute the view port start date and duration
			DateTime currentStartDate = minDate.AddSeconds(Math.Round(winChartViewer1.ViewPortLeft * dateRange));
			currentDuration = Math.Round(winChartViewer1.ViewPortWidth * dateRange);

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
			if (winChartViewer1.ImageMap == null)
			{
				winChartViewer1.ImageMap = winChartViewer1.Chart.getHTMLImageMap("clickable", "",
					"title='[{dataSetName}] {x|mmm dd, yyyy}: USD {value|2}'");
        
        //plotToolBarStandard1.Plot = 
			}
		}
    private void drawChart(WinChartViewer viewer) {
      // Create an XYChart object 600 x 300 pixels in size, with pale blue (0xf0f0ff) 
			// background, black (000000) border, 1 pixel raised effect, and with a rounded frame.
			XYChart c = new XYChart(2*600, 2*300, 0xf0f0ff, 0, 1);
			c.setRoundedFrame(Chart.CColor(BackColor));
			
			// Set the plotarea at (52, 60) and of size 520 x 192 pixels. Use white (ffffff) 
			// background. Enable both horizontal and vertical grids by setting their colors to 
			// grey (cccccc). Set clipping mode to clip the data lines to the plot area.
			c.setPlotArea(52, 60, 2*600-80, 2*300 - 100, 0xffffff, -1, -1, 0xcccccc, 0xcccccc);
			c.setClipping();

			// Add a top title to the chart using 15 pts Times New Roman Bold Italic font, with a 
			// light blue (ccccff) background, black (000000) border, and a glass like raised effect.
			c.addTitle("RH & T recorded data", "Times New Roman Bold Italic", 10 ).setBackground(0xccccff, 0x0, Chart.glassEffect());

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

			// Add a title to the y-axis
			c.yAxis().setTitle("RH(%) Temperature", "Arial Bold", 9);

			///////////////////////////////////////////////////////////////////////////////////////
			// Step 2 - Add data to chart
			///////////////////////////////////////////////////////////////////////////////////////
		
			// 
			// In this example, we represent the data by lines. You may modify the code below if 
			// you want to use other representations (areas, scatter plot, etc).
			//

			// Add a line layer for the lines, using a line width of 2 pixels
			Layer layer = c.addLineLayer2();
			layer.setLineWidth(2);

			// Now we add the 3 data series to a line layer, using the color red (ff0000), green
			// (00cc00) and blue (0000ff)
			layer.setXData(timeStamps);
			layer.addDataSet( dataSeriesA , 0xff0000, "Temp");
			layer.addDataSet(dataSeriesB, 0x00cc00, "RH");
      
			

			///////////////////////////////////////////////////////////////////////////////////////
			// Step 3 - Set up x-axis scale
			///////////////////////////////////////////////////////////////////////////////////////
			
			// Set x-axis date scale to the view port date range. 
			//./c.xAxis().setDateScale(viewPortStartDate, viewPortEndDate);

			
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
        maxValue = 110;
        minValue = -20109;
				double axisLowerLimit =  maxValue - (maxValue - minValue) * (viewer.ViewPortTop + viewer.ViewPortHeight);
				double axisUpperLimit =  maxValue - (maxValue - minValue) * viewer.ViewPortTop;
				// *** use the following formula if you are using a log scale axis ***
				// double axisLowerLimit = maxValue * Math.Pow(minValue / maxValue, viewer.ViewPortTop + viewer.ViewPortHeight);
				// double axisUpperLimit = maxValue * Math.Pow(minValue / maxValue, viewer.ViewPortTop);
				// use the zoomed-in scale
				c.yAxis().setLinearScale(axisLowerLimit, axisUpperLimit);
				c.yAxis().setRounding(false, false);
			}
      Mark m = c.yAxis().addMark(70, 0xff0000, "Alarm = " + 70);
				m.setAlignment(Chart.Left);
				m.setBackground(0xffcccc);
			///////////////////////////////////////////////////////////////////////////////////////
			// Step 5 - Display the chart
			///////////////////////////////////////////////////////////////////////////////////////
      //./c.yAxis().setAutoScale();
			viewer.Chart = c;
      viewer.ZoomDirection = WinChartDirection.HorizontalVertical;
		  viewer.ScrollDirection = WinChartDirection.HorizontalVertical;
    }
    private void drawChartOld(WinChartViewer viewer)
		{ 
			//
			// In this demo, we copy the visible part of the data to a separate buffer for chart
			// plotting. 
			//
			// Note that if you only have a small amount of data (a few hundred data points), it
			// may be easier to just plot all data in any case (so the following copying code is 
			// not needed), and let ChartDirector "clip" the chart to the plot area. 
			//

			// Using ViewPortLeft and ViewPortWidth, get the start and end dates of the view port.
			DateTime viewPortStartDate = minDate.AddSeconds(Math.Round(viewer.ViewPortLeft * dateRange));
			DateTime viewPortEndDate = viewPortStartDate.AddSeconds(Math.Round(viewer.ViewPortWidth * dateRange));
				
			// Get the starting index of the array using the start date
			int startIndex = Array.BinarySearch(timeStamps, viewPortStartDate);
			if (startIndex < 0) 
				startIndex = (~startIndex) - 1;
			
			// Get the ending index of the array using the end date
			int endIndex = Array.BinarySearch(timeStamps, viewPortEndDate);
			if (endIndex < 0) 
				endIndex = ((~endIndex) < timeStamps.Length) ? ~endIndex : timeStamps.Length - 1;

			// Get the length
			int noOfPoints = endIndex - startIndex + 1;

			// Now, we can just copy the visible data we need into the view port data series
			DateTime[] viewPortTimeStamps = new DateTime[noOfPoints];
			double[] viewPortDataSeriesA = new double[noOfPoints];
			double[] viewPortDataSeriesB = new double[noOfPoints];
			
			Array.Copy(timeStamps, startIndex, viewPortTimeStamps, 0, noOfPoints);
			Array.Copy(dataSeriesA, startIndex, viewPortDataSeriesA, 0, noOfPoints);
			Array.Copy(dataSeriesB, startIndex, viewPortDataSeriesB, 0, noOfPoints);
			

      if (viewPortTimeStamps.Length >= 520)	{
				//
				// Zoomable chart with high zooming ratios often need to plot many thousands of 
				// points when fully zoomed out. However, it is usually not needed to plot more
				// data points than the resolution of the chart. Plotting too many points may cause
				// the points and the lines to overlap. So rather than increasing resolution, this 
				// reduces the clarity of the chart. So it is better to aggregate the data first if
				// there are too many points.
				//
				// In our current example, the chart only has 520 pixels in width and is using a 2
				// pixel line width. So if there are more than 520 data points, we aggregate the 
				// data using the ChartDirector aggregation utility method.
				//
				// If in your real application, you do not have too many data points, you may 
				// remove the following code altogether.
				//

				// Set up an aggregator to aggregate the data based on regular sized slots
				ArrayMath m = new ArrayMath(viewPortTimeStamps);
				m.selectRegularSpacing(viewPortTimeStamps.Length / 260);
				
				// For the timestamps, take the first timestamp on each slot
				viewPortTimeStamps = m.aggregate(viewPortTimeStamps, Chart.AggregateFirst);

				// For the data values, aggregate by taking the averages
				viewPortDataSeriesA = m.aggregate(viewPortDataSeriesA, Chart.AggregateAvg);
				viewPortDataSeriesB = m.aggregate(viewPortDataSeriesB, Chart.AggregateAvg);
				
			}

			//
			// Now we have obtained the data, we can plot the chart. 
			//

			///////////////////////////////////////////////////////////////////////////////////////
			// Step 1 - Configure overall chart appearance. 
			///////////////////////////////////////////////////////////////////////////////////////

			// Create an XYChart object 600 x 300 pixels in size, with pale blue (0xf0f0ff) 
			// background, black (000000) border, 1 pixel raised effect, and with a rounded frame.
			XYChart c = new XYChart(2*600, 2*300, 0xf0f0ff, 0, 1);
			c.setRoundedFrame(Chart.CColor(BackColor));
			
			// Set the plotarea at (52, 60) and of size 520 x 192 pixels. Use white (ffffff) 
			// background. Enable both horizontal and vertical grids by setting their colors to 
			// grey (cccccc). Set clipping mode to clip the data lines to the plot area.
			c.setPlotArea(52, 60, 2*600-80, 2*300 - 100, 0xffffff, -1, -1, 0xcccccc, 0xcccccc);
			c.setClipping();

			// Add a top title to the chart using 15 pts Times New Roman Bold Italic font, with a 
			// light blue (ccccff) background, black (000000) border, and a glass like raised effect.
			c.addTitle("RH & T recorded data", "Times New Roman Bold Italic", 10 ).setBackground(0xccccff, 0x0, Chart.glassEffect());

			// Add a bottom title to the chart to show the date range of the axis, with a light blue 
			// (ccccff) background.
      
			c.addTitle2(Chart.Bottom, "From <*font=Arial Bold Italic*>" 
		  		+ c.formatValue(viewPortStartDate, "{value|mmm dd, yyyy}") 
				+ "<*/font*> to <*font=Arial Bold Italic*>" 
				+ c.formatValue(viewPortEndDate, "{value|mmm dd, yyyy}") 
				+ "<*/font*> (Duration <*font=Arial Bold Italic*>" 
				+ Math.Round(viewPortEndDate.Subtract(viewPortStartDate).TotalSeconds / 86400.0)
				+ "<*/font*> days)", "Arial Italic", 10).setBackground(0xccccff);

			// Add a legend box at the top of the plot area with 9pts Arial Bold font with flow layout. 
			c.addLegend(50, 33, false, "Arial Bold", 9).setBackground(Chart.Transparent, Chart.Transparent);

			// Set axes width to 2 pixels
			c.yAxis().setWidth(2);
			c.xAxis().setWidth(2);

			// Add a title to the y-axis
			c.yAxis().setTitle("RH(%) Temperature", "Arial Bold", 9);

			///////////////////////////////////////////////////////////////////////////////////////
			// Step 2 - Add data to chart
			///////////////////////////////////////////////////////////////////////////////////////
		
			// 
			// In this example, we represent the data by lines. You may modify the code below if 
			// you want to use other representations (areas, scatter plot, etc).
			//

			// Add a line layer for the lines, using a line width of 2 pixels
			Layer layer = c.addLineLayer2();
			layer.setLineWidth(2);

			// Now we add the 3 data series to a line layer, using the color red (ff0000), green
			// (00cc00) and blue (0000ff)
			layer.setXData(viewPortTimeStamps);
			layer.addDataSet(viewPortDataSeriesA, 0xff0000, "Temp");
			layer.addDataSet(viewPortDataSeriesB, 0x00cc00, "RH");
			

			///////////////////////////////////////////////////////////////////////////////////////
			// Step 3 - Set up x-axis scale
			///////////////////////////////////////////////////////////////////////////////////////
			
			// Set x-axis date scale to the view port date range. 
			c.xAxis().setDateScale(viewPortStartDate, viewPortEndDate);

			//
			// In the current demo, the x-axis range can be from a few years to a few days. We can 
			// let ChartDirector auto-determine the date/time format. However, for more beautiful 
			// formatting, we set up several label formats to be applied at different conditions. 
			//
      /*
			// If all ticks are yearly aligned, then we use "yyyy" as the label format.
			c.xAxis().setFormatCondition("align", 360 * 86400);
			c.xAxis().setLabelFormat("{value|yyyy}");
			
			// If all ticks are monthly aligned, then we use "mmm yyyy" in bold font as the first 
			// label of a year, and "mmm" for other labels.
			c.xAxis().setFormatCondition("align", 30 * 86400);
			c.xAxis().setMultiFormat(Chart.StartOfYearFilter(), "<*font=bold*>{value|mmm yyyy}", 
				Chart.AllPassFilter(), "{value|mmm}");
			
			// If all ticks are daily algined, then we use "mmm dd<*br*>yyyy" in bold font as the 
			// first label of a year, and "mmm dd" in bold font as the first label of a month, and
			// "dd" for other labels.
			c.xAxis().setFormatCondition("align", 86400);
			c.xAxis().setMultiFormat(
				Chart.StartOfYearFilter(), "<*block,halign=left*><*font=bold*>{value|mmm dd<*br*>yyyy}", 
				Chart.StartOfMonthFilter(), "<*font=bold*>{value|mmm dd}");
			c.xAxis().setMultiFormat2(Chart.AllPassFilter(), "{value|dd}");

			// For all other cases (sub-daily ticks), use "hh:nn<*br*>mmm dd" for the first label of
			// a day, and "hh:nn" for other labels.
			c.xAxis().setFormatCondition("else");
			c.xAxis().setMultiFormat(Chart.StartOfDayFilter(), "<*font=bold*>{value|hh:nn<*br*>mmm dd}", 
				Chart.AllPassFilter(), "{value|hh:nn}");
			  */
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
			// Step 5 - Display the chart
			///////////////////////////////////////////////////////////////////////////////////////

			viewer.Chart = c;
      viewer.ZoomDirection = WinChartDirection.HorizontalVertical;
		  viewer.ScrollDirection = WinChartDirection.HorizontalVertical;
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

			if (hasFinishedInitialization && (newDuration != currentDuration))
			{
				// Set the ViewPortWidth according to the new duration
				currentDuration = newDuration;
				winChartViewer1.ViewPortWidth = newDuration / dateRange;
				winChartViewer1.updateViewPort(true, false);
			}
		}
		#endregion

    private void btnUpdate_Click(object sender, EventArgs e) {
      System.Data.DataSet ds = glob.data.GimitblMess(cdev.type,cdev.strID, dtpStart.Value,dtpEnd.Value,(int)nudLimit.Value);
      if (SetDataSet(ds) == false) {
        return ;
      }
      //./loadData();
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
      //XYChart c = (XYChart)winChartViewer1.Chart;
      //MessageBox.Show( c.yAxis().getMinValue().ToString());
			winChartViewer1.updateViewPort(true, true);
      //winChartViewer1.Chart.yAxis().setLinearScale(axisLowerLimit, axisUpperLimit);
    }

  }
}
