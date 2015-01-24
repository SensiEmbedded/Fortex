using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modbus.Device;
using System.IO.Ports;  //for serial port
using System.Windows.Forms;
using System.Threading;
using System.Xml.Serialization;
using System.ComponentModel;

namespace DiffPress {
  
  public delegate int ReadDeviceDelegate();
  public delegate void AlarmOccured(int ixPressure,DevAlarms type);

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
    AdcErr = -102,
    AddressExeption = -103,
    TimeOut = -104,
    ComNotExist = -105,
    ErrUnknown = -106
  };
  public enum DevAlarms {
    NotSet,
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
    CDev[] devs =  null;
    //public float[] data{get;set;}
    public event ChangedEventHandler Changed;
    void PointCDev() {
      switch (cmn.slaveID) {
        case 0:
          devs =  gl.g_wr.floor1Devs;
          break;
        case 1:
          devs =  gl.g_wr.floor2Devs;
          break;
        case 2:
          devs =  gl.g_wr.floor3Devs;
          break;
      }
    }
    public CDev_MMM(ref CGlobal gl) {
      this.gl = gl;
      cmn.ReadDevice = Read;
      PointCDev();
    }
    void FireChangeEvent() {
      if (Changed != null) {
        Changed(this, new EventArgs());
      } else {
        //System.Diagnostics.Debug.WriteLine("KKKKKKKUUUUUUUUUUUUUUUUUUUUUURRRRRRRRRRRRRRRRR");
      }
    }
    int Read() {
      try {
        holdingregister = null;
        numofPoints = (ushort)gl.g_wr.howManyDevsFloor1;
        numofPoints *= 2;
        holdingregister = gl.comm.master.ReadHoldingRegisters(cmn.slaveID, startAddress, numofPoints);
        this.cmn.status = DevStatus.None;
      } catch (TimeoutException to) {
        System.Diagnostics.Debug.WriteLine("-->Time Out.<--");
        this.cmn.status = DevStatus.TimeOut;
        gl.sqlite.LogMessage("Time Out Device");
        //CDevCommon.SetVals2<float>(data, (float)DevErrorCodes.TimeOut);
        //CDevCommon.SetVals2<DevAlarms>(alarmStatus, DevAlarms.Error);
        //FireChangeEvent();
        return 0;
      } catch (Modbus.SlaveException se) {
        System.Diagnostics.Debug.WriteLine("-->slave exeption<--");
        gl.sqlite.LogMessage("Modbus Slave Excepton");
        this.cmn.status = DevStatus.AddressExeption;
        //CDevCommon.SetVals2<float>(data, (float)DevErrorCodes.AddressExeption);
        //CDevCommon.SetVals2<DevAlarms>(alarmStatus, DevAlarms.Error);
        //FireChangeEvent();
        return 0;
      } catch (Exception ex) {
        gl.sqlite.LogMessage(ex.Message);
        System.Diagnostics.Debug.WriteLine("-->" + ex.Message + "<--");
        this.cmn.status = DevStatus.OtherErr;
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
      /*

      int count = 0;
      if (holdingregister != null) {
        foreach (ushort us in holdingregister) {
          //System.Diagnostics.Debug.WriteLine(us.ToString());
          if ((int)us == (int)DevErrorCodes.AdcErr) {
            data[count] = (float)DevErrorCodes.AdcErr;
          } else {
            data[count] = (float)us / (float)10.0;
          }
          ++count;
        }
      }
      if (numofPoints != count) {
        System.Diagnostics.Debug.WriteLine("-->Error in returned registers.<--");
        FireChangeEvent();
        return 0;
      } */

      //prDiffPress1[0] = (double)holdingregister[1];
      FireChangeEvent();
      return 1;
    }
    
    void PopulateCDevArray(ushort[] holdingregister) {
      if (holdingregister == null) return;
      int howMany = holdingregister.Length;
      ushort reg1,reg2;
      //for (int i = 0; i < howMany; i += 2) {
      for (int i = 0; i < howMany / 2; ++i) {
        reg1 = holdingregister[2*i];
        reg2 = holdingregister[2*i+1];
        if ((int)reg1 == (int)DevErrorCodes.AdcErr) {
           devs[i].val1 = (float)DevErrorCodes.AdcErr;
           devs[i].val2 = (float)DevErrorCodes.AdcErr;
        } else {
          devs[i].val1 = (float)reg1 / 10.0;
          devs[i].val2 = (float)reg2 / 10.0;
        }
      }
    }

  }
  //----------------------------------------------------------------------------------------------------------------------------------
  public class CDev{
    public CDev(){}
    private double _val1;
    [Browsable(false)]
    public double val1 {get{ return _val1;} set {_val1 = value; FireChangeEvent();}}
    private double _val2;
    [Browsable(false)]
    public double val2 {get{ return _val2;} set {_val2 = value; FireChangeEvent();}}
    

    public TypeDevice type { get;set; }
    public string name {get;set;}
    public bool Enable { get;set;}
    public double alarmHi { get; set; }
    public double alarmLow { get;set; }
    public int address { get;set; }
    public string description {get;set;}
    public event ChangedEventHandler Changed;
    void FireChangeEvent() {
      if (Changed != null) {
        Changed(this, new EventArgs());
      } else {
        //System.Diagnostics.Debug.WriteLine("KKKKKKKUUUUUUUUUUUUUUUUUUUUUURRRRRRRRRRRRRRRRR");
      }
    }

  }
  //----------------------------------------------------------------------------------------------------------------------------------
  public enum TypeDevice {RHT, DiffPress};
  
  //----------------------------------------------------------------------------------------------------------------------------------
  public class CDev_Virtual {
    public CDevCommon cmn = new CDevCommon();
    private CGlobal gl;
    public int errors = 0;
    ushort startAddress = 0;
    //ushort startAddress = 1;
    ushort numofPoints = 8;
    //ushort numofPoints = 2;
    public ushort[] holdingregister = new ushort[10];
    public float[] current  { get; set; } 
    public float[] pressure  { get; set; }
    public DevAlarms[] alarmStatus { get; set; }
    public DevAlarms[] alarmStatusLast { get; set; }

    int testis = 0;
    public event ChangedEventHandler Changed;
    public event AlarmOccured evAlarm;
    

    private static System.Threading.Timer timer;
    private System.Timers.Timer TTTimer = new System.Timers.Timer();

    
    public CDev_Virtual(ref CGlobal gl) {
      this.gl = gl;
      current = new float[8];
      pressure = new float[8];
      alarmStatus = new DevAlarms[8];
      alarmStatusLast = new DevAlarms[8];

      cmn.slaveID = 1;          
      cmn.ReadDevice = Read;
      this.TTTimer.Interval = 1000; //1 sec
      this.TTTimer.Elapsed += new System.Timers.ElapsedEventHandler(TTTimer_Elapsed);
      this.TTTimer.Start();
    }

    /*void TimeOutCallBack(object state) {
      timer.Change(Timeout.Infinite, Timeout.Infinite); //stops the timer
      System.Diagnostics.Debug.WriteLine("Com port TimeOut Call Back");
    }    
     
     */
    /// <summary>
    /// 
    /// </summary>
    void FireChangeEvent(){
      if (Changed != null) {
        Changed(this, new EventArgs());
      } else {
      }
    }
    void FireAlarmEvent(int ixPressure,DevAlarms type) {
      if (evAlarm != null) {
        evAlarm(ixPressure, type);
      } else {
      }
    }
    void TTTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e) {
      //SetAlarms(5);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    int Read() {
      //./timer = new System.Threading.Timer(TimeOutCallBack,null,30000,Timeout.Infinite);
      try {
        holdingregister = null;
        holdingregister = gl.comm.master.ReadHoldingRegisters(cmn.slaveID, startAddress, numofPoints);
        this.cmn.status = DevStatus.None;
      } catch (TimeoutException to) {
        System.Diagnostics.Debug.WriteLine("-->Time Out.<--");
        this.cmn.status = DevStatus.TimeOut;
        gl.sqlite.LogMessage("Time Out Device");
        ++errors;
        //CDevCommon.SetErrors(pressure,DevErrorCodes.TimeOut);
        //CDevCommon.SetVals(pressure, DevErrorCodes.TimeOut);
        CDevCommon.SetVals2<float>(pressure, (float)DevErrorCodes.TimeOut);
        CDevCommon.SetVals2<DevAlarms>(alarmStatus, DevAlarms.Error);
        FireChangeEvent();
        return 0;
      } catch (Modbus.SlaveException se) {
        System.Diagnostics.Debug.WriteLine("-->slave exeption<--");
        gl.sqlite.LogMessage("Modbus Slave Excepton");
        this.cmn.status = DevStatus.AddressExeption;
        ++errors;
        
        //CDevCommon.SetErrors(pressure, DevErrorCodes.AddressExeption);
        CDevCommon.SetVals2<float>(pressure, (float)DevErrorCodes.AddressExeption);
        CDevCommon.SetVals2<DevAlarms>(alarmStatus, DevAlarms.Error);
        FireChangeEvent();
        return 0;
      } catch (Exception ex) {
        gl.sqlite.LogMessage(ex.Message);
        System.Diagnostics.Debug.WriteLine("-->" + ex.Message + "<--");
        this.cmn.status = DevStatus.OtherErr;
        ++errors;
        //CDevCommon.SetErrors(pressure, DevErrorCodes.ErrUnknown);
        CDevCommon.SetVals2<float>(pressure, (float)DevErrorCodes.ErrUnknown);
        CDevCommon.SetVals2<DevAlarms>(alarmStatus, DevAlarms.Error);
        FireChangeEvent();
        return 0;
      }
      if (this.cmn.status == DevStatus.TimeOut) {
        gl.sqlite.LogMessage("Device came online.");
      }
      this.cmn.status = DevStatus.OK;
      int count = 0;
      if (holdingregister != null) {
        foreach (ushort us in holdingregister) {
          //System.Diagnostics.Debug.WriteLine(us.ToString());
          aUtils.CUtils.tag_Prava prava = new aUtils.CUtils.tag_Prava();
          prava.x1 = (float)0;
          prava.y1 = (float)0.0;
          prava.x2 = (float)0xFFFF;
          prava.y2 = (float)20.0;
          current[count] = aUtils.CUtils.PravaPrez2Tochki((float)us, prava);

          prava.x1 = (float)4;
          prava.y1 = (float)-100;
          prava.x2 = (float)20.0;
          prava.y2 = (float)100.0;
          pressure[count] = aUtils.CUtils.PravaPrez2Tochki(current[count], prava);

          if (current[count] < (float)3.5) {
            pressure[count] = (float)DevErrorCodes.AdcErr;
            alarmStatus[count] = DevAlarms.Error;
          } else {
            if (alarmStatus[count] == DevAlarms.Error) {
              alarmStatus[count] = DevAlarms.None;
            }
            //alarmStatus[count] = DevAlarms.None;
          }
          ++count;
        }
      }
      if (numofPoints != count) {
        System.Diagnostics.Debug.WriteLine("-->Error in returned registers.<--");
        FireChangeEvent();
        return 0;
      }
    
      //prDiffPress1[0] = (double)holdingregister[1];
      FireChangeEvent();
      
      //prDiffPress1 = ++testis;
      //System.Diagnostics.Debug.WriteLine(DateTime.Now.ToString() +  "Setted prDiff=" + prDiffPress1.ToString());
      //System.Diagnostics.Debug.WriteLine("RS ThreadID=" + AppDomain.GetCurrentThreadId().ToString());
      //gl.comm.master.Dispose();
      return 1;
    } 
    
    
    
  }
  #endregion
  //----------------------------------------------------------------------------------------------------------------------------------
  public class CDevices {
    public CDev_Virtual devVir;
    //public CDev_RH_T[] devsss = new CDev_RH_T[2];
    public CDev_MMM[] mmm = new CDev_MMM[3];
    private CGlobal glob;
    private int order=0;
    
    public CDevices(ref CGlobal gl) {
      //devVir.cmn
      mmm[0] = new CDev_MMM(ref gl);
      mmm[1] = new CDev_MMM(ref gl);
      mmm[2] = new CDev_MMM(ref gl);

      devVir = new CDev_Virtual(ref gl);
      
    }
    public void ReadNextDevice() {
      int rez = 0;
      order = 0;
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
  }
}
