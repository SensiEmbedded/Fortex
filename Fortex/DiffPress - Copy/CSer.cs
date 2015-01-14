using System;
using System.Collections;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
//using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;  //for serial port
using System.ComponentModel;

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
    /*
    [Category("technologic"), Description("Pressure1 Alarm Low Limit (PA)")]
    public double[] alarms {
      get;
      set;
    } */

    [Category("technologic"), Description("Pressure2 Alarm Low Limit (PA)")]
    public double alarm1 {
      get;
      set;
    }
    [Category("technologic"), Description("Pressure2 Alarm Low Limit (PA)")]
    public double alarm2_Hi {
      get;
      set;
    }
    [Category("technologic"), Description("Pressure2 Alarm Low Limit (PA)")]
    public double alarm2_Low {
      get;
      set;
    }
    [Category("technologic"), Description("Pressure3 Alarm Low Limit (PA)")]
    public double alarm3 {
      get;
      set;
    }
    [Category("technologic"), Description("Time (sec) presence alarm")]
    public int timeAlarm {
      get;
      set;
    }
    [Category("channelID"), Description("channelID1")]
    public Int32 channelIDDiffPRess1
    {
        get;
        set;
    }
    [Category("channelID"), Description("channelID2")]
    public Int32 channelIDDiffPRess2
    {
        get;
        set;
    }
    [Category("channelID"), Description("channelID3")]
    public Int32 channelIDDiffPRess3
    {
        get;
        set;
    }

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
      baudRate = 9600;
      portName = "COM3";
      timeOut = 500;
      retries = 2;
      updatems = 1000;
      fullScreen = false;
      sqlConnectionString = @"Server=qsen.corp.sensata.com;Database=assemtrace;User Id=thp;Password=thp;";
      writeInterval = 5*60;
      writeIfAlarm = true;
      writeWhenNormalize = true;
      channelIDDiffPRess1 = 1;
      channelIDDiffPRess2 = 2;
      channelIDDiffPRess3 = 3;
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
