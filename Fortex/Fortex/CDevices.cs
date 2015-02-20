﻿using System;
using System.ComponentModel;
//for serial port

namespace DiffPress {
  
  public delegate int ReadDeviceDelegate();
  public delegate void AlarmOccured(DevAlarms type,DevAlarms typeLast,string tag);

  public enum DevStatus {
    //test v16.01.2015 9:40
    None,
    OK,
    AddressExeption,
    TimeOut,
    OtherErr
  };
  
  public enum DevErrorCodes {
    None,
    TimeOutDev = -20002,
    AddressExeptionDev = -20003,
    AdcErrDev = -20004,

    TimeOutMM = -20005,
    AddressExeptionMM = -20006,

    ComNotExist = -20007,
    ErrUnknown = -20008,
    
  };
  public enum DevAlarms {
    //NotSet,
    None,
    Lo,
    LoLo,
    Hi,
    HiHi,
    OutOfRange,
    Error
  };
  public enum DevTypeSQL {
    NotSet,
    Press1,
    Press2,
    Press3

  }
  //----------------------------------------------------------------------------------------------------------------------------------
  #region Devices Class definition
  
  public class CDevCommon {

    public byte slaveID { get; set; }
    public bool enable { get; set; }
    public DevStatus status { get; set; }  //0 - not init, 1-OK;2-TimeOut;3-Exeption
    public ReadDeviceDelegate ReadDevice;
    /*
    public static void SetErrors(float[] arr,DevErrorCodes code) {
      int max = arr.Length;
      for (int i = 0; i < max; ++i) {
        arr[i] = (float)code;
      }
    }
    public static void SetVals(object[] arr, object val){
      int max = arr.Length;
      for (int i = 0; i < max; ++i) {
        arr[i]  = (int)val;
      }
    } */
    /// <summary>
    ///   
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="arr"></param>
    /// <param name="val"></param>
    public static void SetVals2<T>(T[] arr, T val) {
       
      int max = arr.Length;
      for (int i = 0; i < max; ++i) {
        arr[i] = val;
      }
    }

  }
  //----------------------------------------------------------------------------------------------------------------------------------
  public class CDev_MMM {
    public CDevCommon cmn = new CDevCommon();
    private CGlobal gl;
    ushort startAddress = 100;
    ushort numofPoints = 0;
    ushort[] holdingregister = null;
    public CDev[] devs =  null;
    //public float[] data{get;set;}
    public event ChangedEventHandler Changed;
    void PointCDev() {
      string prefix = "";
      switch (cmn.slaveID) {
        case 1:
          devs =  gl.g_wr.floor1Devs;
          prefix = "floor1.";
          break;
        case 2:
          devs =  gl.g_wr.floor2Devs;
          prefix = "floor2.";
          break;
        case 3:
          devs =  gl.g_wr.floor3Devs;
          prefix = "floor3.";
          break;
        default:
          return;
      }
      int count = 0;
      foreach (CDev d in devs) {
        d.SetRef(ref gl);
        d.strID = prefix + (count+1).ToString();
        ++count;
      }
    }
    public CDev_MMM(ref CGlobal gl,int address) {
      this.cmn.slaveID = (byte)address;
      this.gl = gl;
      
      PointCDev();
      cmn.ReadDevice = Read;
    }
    void FireChangeEvent() {
      if (Changed != null) {
        Changed(this, new EventArgs());
      } 
    }
    ushort HowManyDevPerPloor() {
      ushort h = 0;
      switch (this.cmn.slaveID) {
        case 1:
          h = (ushort)gl.g_wr.howManyDevsFloor1;
          break;
        case 2:
          h = (ushort)gl.g_wr.howManyDevsFloor2;
          break;
        case 3:
          h = (ushort)gl.g_wr.howManyDevsFloor3;
          break;
      }
      return h;
    }
    int Read() {

      try {
        if (gl.comm.IsConnect() == false) {
          PopulateErrorCDevvArray(DevErrorCodes.ComNotExist);
          return 0;
        }
        holdingregister = null;
        numofPoints = HowManyDevPerPloor();
        numofPoints *= 2;
        if(numofPoints == 0 )return 0;
        holdingregister = gl.comm.master.ReadHoldingRegisters(cmn.slaveID, startAddress, numofPoints);
        this.cmn.status = DevStatus.None;
      } catch (TimeoutException to) {
        System.Diagnostics.Debug.WriteLine("-->Time Out.<--");
        this.cmn.status = DevStatus.TimeOut;
        gl.sqlite.LogMessage("Time Out Device");
        PopulateErrorCDevvArray(DevErrorCodes.TimeOutMM);
        //CDevCommon.SetVals2<float>(data, (float)DevErrorCodes.TimeOut);
        //CDevCommon.SetVals2<DevAlarms>(alarmStatus, DevAlarms.Error);
        //FireChangeEvent();
        return 0;
      } catch (Modbus.SlaveException se) {
        System.Diagnostics.Debug.WriteLine("-->slave exeption<--");
        gl.sqlite.LogMessage("Modbus Slave Excepton");
        this.cmn.status = DevStatus.AddressExeption;
        PopulateErrorCDevvArray(DevErrorCodes.AddressExeptionMM);
        //CDevCommon.SetVals2<float>(data, (float)DevErrorCodes.AddressExeption);
        //CDevCommon.SetVals2<DevAlarms>(alarmStatus, DevAlarms.Error);
        //FireChangeEvent();
        return 0;
      } catch (Exception ex) {
        gl.sqlite.LogMessage(ex.Message);
        System.Diagnostics.Debug.WriteLine("-->" + ex.Message + "<--");
        this.cmn.status = DevStatus.OtherErr;                               
        PopulateErrorCDevvArray(DevErrorCodes.ErrUnknown);
        //CDevCommon.SetVals2<float>(data, (float)DevErrorCodes.ErrUnknown);
        //CDevCommon.SetVals2<DevAlarms>(alarmStatus, DevAlarms.Error);
        //FireChangeEvent();
        return 0;
      }
      if (this.cmn.status == DevStatus.TimeOut) {
        gl.sqlite.LogMessage("Device came online.");
        
      } 
      this.cmn.status = DevStatus.OK;
      PopulateCDevArray(holdingregister);
      FireChangeEvent();
      return 1;
    }
    void PopulateErrorCDevvArray(DevErrorCodes err) {
      int howMany = devs.Length;
      for (int i = 0; i < howMany;++i ) {
        devs[i].val1 = (double)err;
        devs[i].val2 = (double)err;
      }

    } 
    void PopulateCDevArray(ushort[] holdingregister) {
      if (holdingregister == null) return;
      int howMany = holdingregister.Length;
      int reg1,reg2;
      //for (int i = 0; i < howMany; i += 2) {
      for (int i = 0; i < howMany / 2; ++i) {
        reg1 = (short)holdingregister[2*i];
        reg2 = (short)holdingregister[2*i+1];
        if (reg1 > -2000) {
          devs[i].val1 = (double)reg1 / 10.0;
          devs[i].val2 = (double)reg2 / 10.0;
        } else {
          //eroros
          devs[i].val1 = (double)reg1;
          devs[i].val2 = (double)reg2;
        }
      }
    }

  }
  //----------------------------------------------------------------------------------------------------------------------------------
  public class CDev{
    private CGlobal glob;
    //private System.Timers.Timer tmr = new System.Timers.Timer();
    private System.Windows.Forms.Timer tmr = new System.Windows.Forms.Timer();
    private int timerDB;
    public CDev(){
      tmr.Interval = 1000;
      //tmr.Elapsed += new System.Timers.ElapsedEventHandler(tmr_Elapsed);
      tmr.Tick += new EventHandler(tmr_Tick);
      tmr.Enabled = true;
      alarmStatus_HiVal1 = DevAlarms.None;
      alarmStatus_HiVal2 = DevAlarms.None;
      alarmStatus_LoVal1 = DevAlarms.None;
      alarmStatus_LoVal2= DevAlarms.None;
      alarmStatusLast_HiVal1 = DevAlarms.None;
      alarmStatusLast_HiVal2= DevAlarms.None;
      alarmStatusLast_LoVal1= DevAlarms.None;
      alarmStatusLast_LoVal2= DevAlarms.None;
      //System.Diagnostics.Debug.WriteLine("CDev Constructor called.");
      this.InstanceID = Guid.NewGuid();

    }

    void tmr_Tick(object sender, EventArgs e) {
      this.CheckAlarms();
      if (++timerDB > glob.g_wr.writeInterval) {
        timerDB = 0;
        Write2DB();
      }
    }
    public void SetRef(ref CGlobal gl){
      this.glob = gl;
    }
    void tmr_Elapsed(object sender, System.Timers.ElapsedEventArgs e) {
      
      /*this.CheckAlarms();
      if (++timerDB > glob.g_wr.writeInterval) {
        timerDB = 0;
        Write2DB();
      } */
    }
    #region Artificial Properties
    
    public double  RH {
      get {return val2;}
      set{val2 = value;}
    }
    public double  Temp {
      get {return val1;}
      set{val1 = value;}
    }
    public double  DiffPress {
      get {return val1;}
      set{val1 = value;}
    }

    public double  alarmHiTemp {
      get {return alarmHiVal1;}
      set{alarmHiVal1 = value;}
    }
    public double  alarmLoTemp {
      get {return alarmLowVal1;}
      set{alarmLowVal1 = value;}
    }
    public double  alarmHiRH {
      get {return alarmHiVal2;}
      set{alarmHiVal2 = value;}
    }
    public double  alarmLoRH {
      get {return alarmLowVal2;}
      set{alarmLowVal2 = value;}
    }
    public double  alarmHiDiffPress {
      get {return alarmHiVal1;}
      set{alarmHiVal1 = value;}
    }
    public double  alarmLoDiffPress {
      get {return alarmLowVal1;}
      set{alarmLowVal1 = value;}
    }
    #endregion
    private double _val1;
    [Browsable(false)]
    public double val1 {get{ return _val1;} set {_val1 = value; FireChangeEvent();}}
    private double _val2;
    [Browsable(false)]
    public double val2 {get{ return _val2;} set {_val2 = value; FireChangeEvent();}}
    
    [Browsable(false),NonSerialized]
    public string strID="not set";

    [Browsable(false),NonSerialized]
    public Guid InstanceID;


    public TypeDevice type { get;set; }
    public string name {get;set;}
    public bool Enable { get;set;}
    public double alarmHiVal1 { get; set; }
    public double alarmLowVal1 { get;set; }
    public double alarmHiVal2 { get; set; }
    public double alarmLowVal2 { get;set; }

    [Browsable(false),NonSerialized]
    public DevAlarms alarmStatus_HiVal1; //{ get; set; }

    [Browsable(false),NonSerialized]
    public DevAlarms alarmStatusLast_HiVal1;
    private int dempAlarm_HiVal1;

    [Browsable(false),NonSerialized]
    public DevAlarms alarmStatus_LoVal1;
    [Browsable(false),NonSerialized]
    public DevAlarms alarmStatusLast_LoVal1;
    private int dempAlarm_LoVal1;

    [Browsable(false),NonSerialized]
    public DevAlarms alarmStatus_HiVal2;
    [Browsable(false),NonSerialized]
    public DevAlarms alarmStatusLast_HiVal2;
    private int dempAlarm_HiVal2;

    [Browsable(false),NonSerialized]
    public DevAlarms alarmStatus_LoVal2;
    [Browsable(false),NonSerialized]
    public DevAlarms alarmStatusLast_LoVal2;
    private int dempAlarm_LoVal2;


    public int address { get;set; }
    public string description {get;set;}

    public event ChangedEventHandler Changed;
    public event AlarmOccured evAlarm;

    void FireChangeEvent() {
      if (Changed != null) {
        Changed(this, new EventArgs());
      } else {
        
      }
    }
    void FireAlarmEvent(DevAlarms type,DevAlarms typeLast,string tag) {
      if (evAlarm != null) {
        evAlarm(type,typeLast,tag);
      } else {
        
      }
    }
    public void Write2DB() {
      if (this.Enable == false)
        return;
      if (this.strID == "floor3.2") {
        System.Diagnostics.Debug.WriteLine(this.val1.ToString());
      }
      glob.data.InsertDataRow(this.strID, this.val1,this.val2);
    }
    public static string ShowErr(double val) {
      int err = (int)val;
      string strErr=null;
      switch (err) {
        case (int)DevErrorCodes.TimeOutDev:
          strErr = "Time\nOut";
          //lblRH.Text = "Out";
          break;
        case (int)DevErrorCodes.AddressExeptionDev:
          strErr = "Excep\nDev";
          break;
        case (int)DevErrorCodes.AdcErrDev:
          strErr = "Adc\nErr";
          break;
        case (int)DevErrorCodes.TimeOutMM:
          strErr = "Time\nOutMM";
          break;
        case (int)DevErrorCodes.AddressExeptionMM:
          strErr = "Excep\nMM";
          break;
        case (int)DevErrorCodes.ComNotExist:
          strErr = "Err\nCOM";
          
          break;
        case (int)DevErrorCodes.ErrUnknown:
          strErr = "Err";
          break;
      }
      return strErr;
      
    }
    #region Alarms
    
    private void CheckVal1AlarmsLo(int timeAlarm) {
      if (val1 <= alarmLowVal1) {
        if (dempAlarm_LoVal1 < timeAlarm)dempAlarm_LoVal1++;
      } else {
        if (dempAlarm_LoVal1 > 0) dempAlarm_LoVal1--;
      }
      if (dempAlarm_LoVal1 >= timeAlarm) {
        alarmStatus_LoVal1 = DevAlarms.Lo;

      } else {
        if (dempAlarm_LoVal1 == 0) {
          alarmStatus_LoVal1 = DevAlarms.None;
        }
      }
      if (alarmStatusLast_LoVal1 != alarmStatus_LoVal1) {
        FireAlarmEvent(alarmStatus_LoVal1,alarmStatusLast_LoVal1,"val1");
      }
      alarmStatusLast_LoVal1 = alarmStatus_LoVal1;
    }
    private void CheckVal1AlarmsHi(int timeAlarm) {
      if (val1 >= alarmHiVal1) {
        if (dempAlarm_HiVal1 < timeAlarm)dempAlarm_HiVal1++;
      } else {
        if (dempAlarm_HiVal1 > 0) dempAlarm_HiVal1--;
      }
      if (dempAlarm_HiVal1 >= timeAlarm) {
        alarmStatus_HiVal1 = DevAlarms.Hi;

      } else {
        if (dempAlarm_HiVal1 == 0) {
          alarmStatus_HiVal1 = DevAlarms.None;
        }
      }
      if (alarmStatusLast_HiVal1 != alarmStatus_HiVal1) {
        FireAlarmEvent(alarmStatus_HiVal1,alarmStatusLast_HiVal1,"val1");
      }
      alarmStatusLast_HiVal1 = alarmStatus_HiVal1;
    }

    private void CheckVal2AlarmsLo(int timeAlarm) {
      if (val2 <= alarmLowVal2) {
        if (dempAlarm_LoVal2 < timeAlarm)dempAlarm_LoVal2++;
      } else {
        if (dempAlarm_LoVal2 > 0) dempAlarm_LoVal2--;
      }
      if (dempAlarm_LoVal2 >= timeAlarm) {
        alarmStatus_LoVal2 = DevAlarms.Lo;

      } else {
        if (dempAlarm_LoVal2 == 0) {
          alarmStatus_LoVal2 = DevAlarms.None;
        }
      }
      if (alarmStatusLast_LoVal2 != alarmStatus_LoVal2) {
        FireAlarmEvent(alarmStatus_LoVal2,alarmStatusLast_LoVal2,"val2");
      }
      alarmStatusLast_LoVal2 = alarmStatus_LoVal2;
    }
    private void CheckVal2AlarmsHi(int timeAlarm) {
      if (val2 >= alarmHiVal2) {
        if (dempAlarm_HiVal2 < timeAlarm)dempAlarm_HiVal2++;
      } else {
        if (dempAlarm_HiVal2 > 0) dempAlarm_HiVal2--;
      }
      if (dempAlarm_HiVal2 >= timeAlarm) {
        alarmStatus_HiVal2 = DevAlarms.Hi;
      } else {
        if (dempAlarm_HiVal2 == 0) {
          alarmStatus_HiVal2 = DevAlarms.None;
        }
      }
      if (alarmStatusLast_HiVal2 != alarmStatus_HiVal2) {
        FireAlarmEvent(alarmStatus_HiVal2,alarmStatusLast_HiVal2,"val2");
      }
      alarmStatusLast_HiVal2 = alarmStatus_HiVal2;
    }
    private void ClearAlarms() {
      alarmStatusLast_LoVal1 = alarmStatus_LoVal1 = DevAlarms.None;
      alarmStatusLast_HiVal1 = alarmStatus_HiVal1 = DevAlarms.None;
      alarmStatusLast_LoVal2 = alarmStatus_LoVal2 = DevAlarms.None;
      alarmStatusLast_HiVal2 = alarmStatus_HiVal2 = DevAlarms.None;

    }
    private void CheckAlarms() {
      if(this.Enable == false){ClearAlarms(); return;}
      if(glob == null){ClearAlarms(); return;}
      if(val1 < -2000){ClearAlarms(); return;}
      if(val2 < -2000){ClearAlarms(); return;}

      int timeAlarm = glob.g_wr.timeAlarm;
      CheckVal1AlarmsLo(timeAlarm);
      CheckVal1AlarmsHi(timeAlarm);
      CheckVal2AlarmsLo(timeAlarm);
      CheckVal2AlarmsHi(timeAlarm);

    }
    #endregion
  }
  //----------------------------------------------------------------------------------------------------------------------------------
  public enum TypeDevice {RHT, DiffPress};
  
  //----------------------------------------------------------------------------------------------------------------------------------
  
    
  
  #endregion
  //----------------------------------------------------------------------------------------------------------------------------------
  public class CDevices {
    
    //public CDev_RH_T[] devsss = new CDev_RH_T[2];
    public CDev_MMM[] mmm = new CDev_MMM[3];
    private CGlobal glob;
    private int order=0;
    
    public CDevices(ref CGlobal gl) {
      //devVir.cmn
      mmm[0] = new CDev_MMM(ref gl,1);
      mmm[1] = new CDev_MMM(ref gl,2);
      mmm[2] = new CDev_MMM(ref gl,3);
      
    }
    public void ReadNextDevice() {
      int rez = 0;
      //order = 0;
      switch (order) {
        case 0:
          rez = mmm[0].cmn.ReadDevice(); //devVir.cmn.ReadDevice();
          break;
        case 1:
          rez = mmm[1].cmn.ReadDevice();
          break;
        case 2:
          rez = mmm[2].cmn.ReadDevice();
          break;
      }
       
      if (++order > 2) order = 0;
      
    }
    public TypeDevice GimiType(string strID) {

      foreach(CDev d in mmm[0].devs){
        if(d.strID == strID)return d.type;

      }
      foreach (CDev d in mmm[1].devs) {
        if (d.strID == strID)
          return d.type;

      }
      foreach (CDev d in mmm[1].devs) {
        if (d.strID == strID)
          return d.type;

      }

      return TypeDevice.RHT;
    }
  }
}
