using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modbus.Device;
using System.IO.Ports;  //for serial port
using System.Windows.Forms;
using System.Threading; 


namespace DiffPress {
  
  public delegate int ReadDeviceDelegate();
  public delegate void AlarmOccured(int ixPressure,DevAlarms type);

  public enum DevStatus {
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
  public class CDev_RH_T {
    public CDevCommon cmn = new CDevCommon();
    private CGlobal gl;
    ushort startAddress = 1;
    ushort numofPoints = 4;
    ushort[] holdingregister = null;

    public CDev_RH_T(ref CGlobal gl) {
      this.gl = gl;
      cmn.slaveID = 1;
    
      cmn.ReadDevice = Read;
    }
    int Read() {
      return 1;
    }

  }
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
        //System.Diagnostics.Debug.WriteLine("KKKKKKKUUUUUUUUUUUUUUUUUUUUUURRRRRRRRRRRRRRRRR");
      }
    }
    void FireAlarmEvent(int ixPressure,DevAlarms type) {
      if (evAlarm != null) {
        evAlarm(ixPressure, type);
      } else {
        //System.Diagnostics.Debug.WriteLine("KKKKKKKUUUUUUUUUUUUUUUUUUUUUURRRRRRRRRRRRRRRRR");
      }
    }
    void TTTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e) {
      SetAlarms(5);
      SetAlarms(6);
      SetAlarms(7);
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
    
    //holdingregister = master.ReadHoldingRegisters(slaveID, startAddress, numofPoints);
    /// <summary>
    /// Vika se na vsiaka sekunda
    /// </summary>
    /// <param name="ix"></param>
    int[] demp = new int[8];
    void SetAlarms(int ix) {
      double alarmLo=0, alarmHi=0;
      double press = pressure[ix];

      
      switch (ix) {
        case 5:
          alarmLo = gl.g_wr.alarm1;
          break;
        case 6:
          alarmLo = gl.g_wr.alarm2_Low;
          alarmHi = gl.g_wr.alarm2_Hi;
          break;
        case 7:
          alarmLo = gl.g_wr.alarm3;
          break;
        default:
          alarmStatus[ix] = DevAlarms.None;  
          return;
      }
      if (alarmStatus[ix] == DevAlarms.Error) {
        return;
      }
      if (alarmStatus[ix] == DevAlarms.NotSet) {
        alarmStatus[ix] = DevAlarms.None;
        return;
      }
      if (ix == 5 || ix == 7) {
        // i dvete rabotiat kato dolna granica
        if (press < alarmLo) {
          if (demp[ix] < gl.g_wr.timeAlarm)
            demp[ix]++;	
        } else {
          if (demp[ix] > 0)
            demp[ix]--;		
        }
        if (demp[ix] >= gl.g_wr.timeAlarm) {
          alarmStatus[ix] = DevAlarms.Lo;
          if (alarmStatusLast[ix] == DevAlarms.None) {
            FireAlarmEvent(ix, DevAlarms.Lo);
            if (ix == 5) {
              gl.sqlite.LogMessage("Alarm: Pressure 1 bellow low limit.");
            } else {
              gl.sqlite.LogMessage("Alarm: Pressure 3 bellow low limit.");
            }
          }
        } else {
          if (demp[ix] == 0) {
            alarmStatus[ix] = DevAlarms.None;
            if (alarmStatusLast[ix] == DevAlarms.Lo) {
              FireAlarmEvent(ix, DevAlarms.None);
              if (ix == 5) {
                gl.sqlite.LogMessage("Pressure 1 enter in normal range.");
              } else {
                gl.sqlite.LogMessage("Pressure 3 enter in normal rangle.");
              }
            }
          }
        }
      }
      if (ix == 6) {
        //out of range tip na granica
        if (press < alarmLo) {
          if (demp[ix] < gl.g_wr.timeAlarm)
            demp[ix]++;	
        }
        if (press > alarmHi) {
          if (demp[ix] < gl.g_wr.timeAlarm)
            demp[ix]++;	
        }
        if (press >= alarmLo && press <= alarmHi) {
          if (demp[ix] > 0)
            demp[ix]--;		
        }

        if (demp[ix] >= gl.g_wr.timeAlarm) {
          alarmStatus[ix] = DevAlarms.OutOfRange;
          
          if (alarmStatusLast[ix] == DevAlarms.None) {
            FireAlarmEvent(ix, DevAlarms.OutOfRange);
            gl.sqlite.LogMessage("Alarm: Pressure 2 Out Of Range.");
          }
        } else {
          if (demp[ix] == 0) {
            alarmStatus[ix] = DevAlarms.None;
            if (alarmStatusLast[ix] == DevAlarms.OutOfRange) {
              FireAlarmEvent(ix, DevAlarms.None);
              gl.sqlite.LogMessage("Pressure 2 become in normal range.");
            }
          }
        }

      }
      alarmStatusLast[ix] = alarmStatus[ix];
    }
    
  }
  #endregion
  //----------------------------------------------------------------------------------------------------------------------------------
  public class CDevices {
    public CDev_Virtual devVir;
    public CDev_RH_T[] devsss = new CDev_RH_T[2];
    private CGlobal glob;
    private int order=0;
    
    public CDevices(ref CGlobal gl) {
      //devVir.cmn
      devVir = new CDev_Virtual(ref gl);
      devsss[0] = new CDev_RH_T(ref gl);
      devsss[1] = new CDev_RH_T(ref gl);
    }
    public void ReadNextDevice() {
      int rez = 0;
      order = 0;
      switch (order) {
        case 0:
            rez = devVir.cmn.ReadDevice();
          break;
        case 1:
          rez = devsss[0].cmn.ReadDevice();
          break;
        case 2:
          rez = devsss[1].cmn.ReadDevice();
          break;
      }
       
      if (++order > 2) order = 0;
      
    }
  }
}
