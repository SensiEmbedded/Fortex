using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modbus.Device;
using System.IO.Ports;  //for serial port
using System.Timers;
using System.Text.RegularExpressions;
using LibUsbDotNet.DeviceNotify;
using System.Windows.Forms;


namespace DiffPress {
  public class CComunication {
    public SerialPort serialPort = new SerialPort(); //create a new SerialPort object with default settings.
    public ModbusSerialMaster master;
    
    private static System.Timers.Timer aTimer;
    public CDevices devs;
    public static IDeviceNotifier UsbDeviceNotifier = DeviceNotifier.OpenDeviceNotifier();
    CGlobal glob;
    public void SetRef(ref CGlobal rfGl) {
      glob = rfGl;
      devs = new CDevices(ref rfGl);
      aTimer = new System.Timers.Timer(rfGl.g_wr.updatems);
      aTimer.Elapsed += new ElapsedEventHandler(aTimer_Elapsed);
      aTimer.Enabled = true;
      UsbDeviceNotifier.OnDeviceNotify += OnDeviceNotifyEvent;
    }
    private void OnDeviceNotifyEvent(object sender, DeviceNotifyEventArgs e) {
      // A Device system-level event has occured
      // Prolific device 
      //MessageBox.Show("Usb PID = " + e.Device.IdProduct.ToString() + " VID=" +);
      //string output = String.Format("Usb PID = {1}, VID={2},", e.Device.IdProduct, e.Device.IdVendor);
      //MessageBox.Show(e.Device.IdProduct.ToString() +" "+ e.Device.IdVendor.ToString());
      //MessageBox.Show(output);
      if (e.Device.IdProduct == 0x2303 && e.Device.IdVendor == 0x067B) {
        glob.sqlite.LogMessage("USB Device with vid=0x067B and pid=0x2303 has been plugged ot unplugged");
        if (e.EventType == EventType.DeviceRemoveComplete) {
          if (this.IsConnect() == true) {
            this.Diconnect();
            serialPort.Dispose();  
            return;
          }
        }
        if (e.EventType == EventType.DeviceArrival) {
          //System.Diagnostics.Debug.WriteLine(e.Device.IdProduct);
        }
      }

      //Vid:0x067B
      //Pid:0x2303
      
      

      

      //Console.WriteLine();
      //Console.Write("[Press any key to exit]");
    }

    void aTimer_Elapsed(object sender, ElapsedEventArgs e) {
      if (this.IsConnect() == false) {
        this.Connect();
        return;
      }
      devs.ReadNextDevice();
      
    }
    public void Connect() {
      CSer ser = glob.g_wr;
      serialPort.PortName = ser.portName;
      serialPort.BaudRate = ser.baudRate;
      serialPort.DataBits = ser.dataBits;
      serialPort.Parity = ser.parity;
      serialPort.StopBits = ser.stopBits;
      try {
        serialPort.Open();
        master = ModbusSerialMaster.CreateRtu(serialPort);
        master.Transport.Retries = ser.retries;   //don't have to do retries
        master.Transport.ReadTimeout = ser.timeOut; //milliseconds
        glob.sqlite.LogMessage("Serial port was successfully opened.");
        //Console.WriteLine(DateTime.Now.ToString() + " =>Open " + serialPort.PortName + " sucessfully!");
        //timer1.Enabled = true;
      } catch (System.IO.IOException exe) {
        glob.sqlite.LogMessage(exe.Message);
        //Console.WriteLine("Error: " + exe.Message);

        /*Match match = Regex.Match(exe.Message, @"The port 'COM\d{1,2}' does not exist", RegexOptions.IgnoreCase);
        if (match.Success) {
          // Finally, we get the Group value and display it.
          //string key = match.Groups[1].Value;
          Console.WriteLine("BrAVOOOOOOOOOOOOOOOOOO");
        } */
        if (exe.Message.Contains("does not exist")) {
          //Console.WriteLine("BrAVOOOOOOOOOOOOOOOOOO");

        }
        //The port 'COM3' does not exist
      } catch (Exception ex) {
        glob.sqlite.LogMessage(ex.Message);
        //Console.WriteLine("Error: " + ex.Message);
      }

    }
    public void Diconnect() {
      serialPort.Close();
    }
    public bool IsConnect() {
      return serialPort.IsOpen;
    }
  }
}
