using System;
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

    [Category("technologic"), Description("Number of devices per floor1 (RHT + DiffPRess)")]
    public int howManyDevsFloor1 { get;set; }
    [Category("technologic"), Description("Number of devices per floor2 (RHT + DiffPRess)")]
    public int howManyDevsFloor2 { get;set; }
    [Category("technologic"), Description("Number of devices per floor3 (RHT + DiffPRess)")]
    public int howManyDevsFloor3 { get;set; }
    

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

    [Category("technologic"), Description("alarm wav file")]
    public string alarmWavFile { get; set;}

    [Category("technologic"), Description("Play Sound when Alarm")]
    public bool alarmPlaySound { get; set;}

    [Category("appereance"), Description("Specifies something")]
    public bool fullScreen { get; set;}

    [Category("MS Server"),Browsable(false), Description("Connection string to SENSATA traceabillity MS SQL")]
    public string sqlConnectionString { get; set; }

    [Category("MS Server"), Description("Write interval (sec)")]
    public int writeInterval {get;set;}

    [Category("MS Server"), Description("Write if Alarm appear regarding of write timer")]
    public bool writeIfAlarm {get; set;}

    [Category("MS Server"), Description("Write when alarm disappear (normalize).")]
    public bool writeWhenNormalize{get; set;}

    //------ Email settings -------------
    [Category("Email Settings"),Browsable(false), Description("like mail4.host.bg")]
    public CEmailSettings emailSetts { get; set; }
    /*
    [Category("Email Settings"),Browsable(true), Description("like mail4.host.bg")]
    public string Host { get; set; }

    [Category("Email Settings"),Browsable(true), Description("ssl - 25; no ssl-587")]
    public int Port { get; set; }

    [Category("Email Settings"),Browsable(true), Description("control@fortex.bg")]
    public string fromEmail { get; set; }

    [Category("Email Settings"),Browsable(true), Description("control@fortex.bg")]
    public string user { get; set; }

    [Category("Email Settings"),Browsable(true), Description("")]
    public string pass { get; set; }

    [Category("Email Settings"),Browsable(true), Description("use SSL connection or not")]
    public bool useSsl { get; set; }
      */
    //-------------------------------------
    public void SetDefaultsEmail() {
      emailSetts = new CEmailSettings();
      emailSetts.Host = "mail4.host.bg";
      emailSetts.Port = 25;
      emailSetts.fromEmail = "control@fortex.bg";
      emailSetts.user = "control@fortex.bg";
      emailSetts.pass = "Control1!";
      emailSetts.useSsl = false;
    }


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
      timeAlarm = 10;

      howManyDevsFloor1 = 8;
      howManyDevsFloor2 = 8;
      howManyDevsFloor3 = 8;

      floor1Devs = new CDev[32];
      floor2Devs = new CDev[32];
      floor3Devs = new CDev[32];

      for (int i = 0; i < 32; ++i) {
        floor1Devs[i] = new CDev();
        floor2Devs[i] = new CDev();
        floor3Devs[i] = new CDev();

        floor1Devs[i].address = i+1;
        floor2Devs[i].address = i+1;
        floor3Devs[i].address = i+1;

      }

      alarmWavFile = "s1.wav";
      alarmPlaySound = true;

      floor1Devs.ToList().ForEach(c => {c.Enable = false; c.type = TypeDevice.RHT;});
      floor2Devs.ToList().ForEach(c => {c.Enable = false; c.type = TypeDevice.RHT;});
      floor3Devs.ToList().ForEach(c => {c.Enable = false; c.type = TypeDevice.RHT;});
      
      SetDefaultsEmail();

      /*Host = "mail4.host.bg";
      Port  = 25;
      fromEmail = "control@fortex.bg";
      user  = "control@fortex.bg";
      pass = "Control1!";
      useSsl  = false;
        */
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
