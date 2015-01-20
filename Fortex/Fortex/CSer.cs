﻿using System;
using System.Collections;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
//using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;  //for serial port
using System.ComponentModel;

using System.Collections.Generic;


namespace DiffPress {
  [Serializable]
  public class CSer {
    //public string PortName;
    //public Parity parity;
    //public StopBits stopBits;
    //public int DataBits;
    //public int BaudRate;
    [Category("COM port"),Description("Parity")]
    public Parity parity { get; set; }

    [Category("COM port"), Description("Number of stop bits")]
    public StopBits stopBits { get; set; }

    [Category("COM port"), Description("number of data bits")]
    public int dataBits { get; set; }

    [Category("COM port"), Description("Baud rate,9600,14400,19200,38400,115200")]
    public int baudRate { get; set; }

    [Category("COM port"), Description("Name of the port COM1, COM2, COM3")]
    public string portName { get; set; }

    [Category("Communication"), Description("answer timeout (ms)")]
    public int timeOut { get; set; }

    [Category("Communication"), Description("how many times to ask")]
    public int retries { get; set; }

    [Category("Communication"), Description("Asking for data interval (ms)")]
    public int updatems {get;set; }

    [Category("technologic"), Description("Number of RH devices per floor")]
    public int[] rhPerFloor { get;set; }
    [Category("technologic"), Description("Number of DiffPress devices per floor")]
    public int[] diffPressPerFloor { get; set; }

    /*
    [Category("technologic"), Description("Pressure  Alarm (PA)")]
    public double[] alarmsDiffPres {  get;  set; }

    [Category("technologic"), Description("RH Alarms (%)")]
    public double[] alarmsRH_Hi { get; set; }
    [Category("technologic"), Description("Temperature Alarms Hi Limit(%)")]
    public double[] alarmsT_Hi { get; set; }
    [Category("technologic"), Description("Temperature Alarms Low Limit(%)")]
    public double[] alarmsT_Low { get; set;}
      */

    [Category("technologic"), Description("Floor1 Devices")]
    public CDev[] floor1Devs {get;set;}

    [Category("technologic"), Description("Floor2 Devices")]
    public CDev[] floor2Devs {get;set;}
    [Category("technologic"), Description("Floor3 Devices")]
    public CDev[] floor3Devs {get;set;}

    [Category("technologic"), Description("Time (sec) presence alarm")]
    public int timeAlarm { get; set;}

     [Category("appereance"), Description("Specifies something")]
    public bool fullScreen { get; set;}

    [Category("MS Server"), Description("Connection string to SENSATA traceabillity MS SQL")]
    public string sqlConnectionString { get; set; }

    [Category("MS Server"), Description("Write interval (sec)")]
    public int writeInterval {get;set;}

    [Category("MS Server"), Description("Write if Alarm appear regarding of write timer")]
    public bool writeIfAlarm {get; set;}

    [Category("MS Server"), Description("Write when alarm disappear (normalize).")]
    public bool writeWhenNormalize{get; set;}

    

    public void SetDefaults(){
      parity = Parity.None;
      stopBits = StopBits.One;
      dataBits = 8;
      baudRate = 19200;
      portName = "COM2";
      timeOut = 500;
      retries = 2;
      updatems = 1000;
      fullScreen = false;
      sqlConnectionString = @"Server=qsen.corp.sensata.com;Database=assemtrace;User Id=thp;Password=thp;";
      writeInterval = 5*60;
      writeIfAlarm = true;
      writeWhenNormalize = true;

      floor1Devs = new CDev[32];
      floor2Devs = new CDev[32];
      floor3Devs = new CDev[32];

      for (int i = 0; i < 32; ++i) {
        floor1Devs[i] = new CDev();
        floor2Devs[i] = new CDev();
        floor3Devs[i] = new CDev();
      }

      floor1Devs.ToList().ForEach(c => {c.Enable = false; c.type = TypeDevice.NotSet;});
      floor2Devs.ToList().ForEach(c => {c.Enable = false; c.type = TypeDevice.NotSet;});
      floor3Devs.ToList().ForEach(c => {c.Enable = false; c.type = TypeDevice.NotSet;});

          

      /*
      alarmsDiffPres = new double[32];
      alarmsRH_Hi = new double[64];
      alarmsT_Hi = new double[64];
      alarmsT_Low = new double[64];

      alarmsDiffPres.ToList().ForEach(c => c=20);
      alarmsRH_Hi.ToList().ForEach(c => c=60);
      alarmsT_Hi.ToList().ForEach(c => c=60);
      alarmsT_Low.ToList().ForEach(c => c = -10);
        */
    
      //alarms.ToList().ForEach(c => c = 12.3);
      //alarms[0] = 0.0;
      /*
      alarms.Select(c => {
        c = (double)1.23;
        return c;
      }).ToList();*/
    }
    
    #region Serialize Deserialize
    /// <summary>
    /// Serialize
    /// </summary>
    /// <param name="instan"></param>
    public static void SerializeMe(CSer instan, string path) {

      FileStream fs = null;
      XmlSerializer xs = new XmlSerializer(typeof(CSer));
      //fs = File.Open("CSer.xml", FileMode.Create, FileAccess.Write);
      fs = File.Open(path, FileMode.Create, FileAccess.Write);

      try {
        xs.Serialize(fs, instan);
      } finally {
        fs.Close();
      }
    }
    /// <summary>
    /// DeserializeMe
    /// </summary>
    public static CSer DeserializeMe(string path) {
      CSer itm;//= new CL.CSer();
      FileStream fsd = null;
      XmlSerializer xs = new XmlSerializer(typeof(CSer));
      //fsd = File.Open("CSer.xml", FileMode.Open, FileAccess.Read);
      fsd = File.Open(path, FileMode.Open, FileAccess.Read);

      try {
        itm = (CSer)xs.Deserialize(fsd);
      } finally {
        fsd.Close();

      }
      return itm;
    }
    #endregion
  }
}
