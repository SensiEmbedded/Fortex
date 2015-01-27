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
    TimeOutDev = -20002,
    AddressExeptionDev = -20003,
    AdcErrDev = -20004,

    TimeOutMM = -20005,
    AddressExeptionMM = -20006,

    ComNotExist = -20007,
    ErrUnknown = -20008,
    
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
    private CGlobal gl;
    private System.Timers.Timer tmr = new System.Timers.Timer();
    public CDev(){
      tmr.Interval = 1000;
      tmr.Elapsed += new System.Timers.ElapsedEventHandler(tmr_Elapsed);
      tmr.Enabled = true;
    }
    public void SetRef(ref CGlobal gl){
      this.gl = gl;
    }
    void tmr_Elapsed(object sender, System.Timers.ElapsedEventArgs e) {
      
    }

    

    private double _val1;
    [Browsable(false)]
    public double val1 {get{ return _val1;} set {_val1 = value; FireChangeEvent();}}
    private double _val2;
    [Browsable(false)]
    public double val2 {get{ return _val2;} set {_val2 = value; FireChangeEvent();}}
    

    public TypeDevice type { get;set; }
    public string name {get;set;}
    public bool Enable { get;set;}
    public double alarmHiVal1 { get; set; }
    public double alarmLowVal1 { get;set; }
    public double alarmHiVal2 { get; set; }
    public double alarmLowVal2 { get;set; }

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
    private void CheckAlarms() {
      double alarmLo=0, alarmHi=0;

    }
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
      mmm[0] = new CDev_MMM(ref gl);
      mmm[1] = new CDev_MMM(ref gl);
      mmm[2] = new CDev_MMM(ref gl);
      mmm[0].cmn.slaveID = 1;
      mmm[1].cmn.slaveID = 2;
      mmm[2].cmn.slaveID = 3;
    
      
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
