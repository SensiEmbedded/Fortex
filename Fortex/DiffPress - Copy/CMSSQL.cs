using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace DiffPress {
  public class CRecord {
    public int stat;
    public float val;
    public DateTime dt;
    public Int32 type;
    public CRecord(float val, Int32 type)
    {
      this.val = val;
      this.type = type;
      dt = DateTime.Now;
    }
  }

  public class CMSSQL {
    private CGlobal gl;
    SqlConnection conn;
    private System.Timers.Timer tmr = new System.Timers.Timer(1000);
    public int sample;
    public List<CRecord> lst;

    public void SetRef(ref CGlobal gl) {
      this.gl = gl;
      lst = new List<CRecord>();
      gl.comm.devs.devVir.evAlarm += new AlarmOccured(devVir_evAlarm);
      tmr.Elapsed += new System.Timers.ElapsedEventHandler(tmr_Elapsed);
      tmr.Enabled = true;
    }

    void devVir_evAlarm(int ixPressure, DevAlarms type) {
      Int32 typeSQL = 0;
      switch (ixPressure) {
        case 5:
          //typeSQL = (int)DevTypeSQL.Press1;
          typeSQL =gl.g_wr.channelIDDiffPRess1;
          break;
        case 6:
          //typeSQL = (Int32)DevTypeSQL.Press2;
          typeSQL = gl.g_wr.channelIDDiffPRess2;
          break;
        case 7:
          //typeSQL = (Int32)DevTypeSQL.Press3;
          typeSQL = gl.g_wr.channelIDDiffPRess3;
          break;
      }
      if (type == DevAlarms.None) {
        //tova oznachave, che tochno se e normalizirala
        if (gl.g_wr.writeWhenNormalize == false)
          return;
      } else {
        if (gl.g_wr.writeIfAlarm == false)
          return;
      }
      float fl1 = gl.comm.devs.devVir.pressure[ixPressure];
      CRecord rec = new CRecord(fl1, typeSQL);
      lst.Add(rec);
    }
    void tmr_Elapsed(object sender, System.Timers.ElapsedEventArgs e) {
      if (++sample > gl.g_wr.writeInterval) {
        sample = 0;
        AddRecord2Array();
      }
      AnalizeStack();
    }
    void AddRecord2Array(){
      float fl1 = gl.comm.devs.devVir.pressure[5];
      float fl2 = gl.comm.devs.devVir.pressure[6];
      float fl3 = gl.comm.devs.devVir.pressure[7];
      fl1 = (float)(Math.Truncate((double)fl1 * 10.0) / 10.0);
      fl2 = (float)(Math.Truncate((double)fl2 * 10.0) / 10.0);
      fl3 = (float)(Math.Truncate((double)fl3 * 10.0) / 10.0);

      //CRecord rec1 = new CRecord(fl1, (int)DevTypeSQL.Press1);
      //CRecord rec2 = new CRecord(fl2, (int)DevTypeSQL.Press2);
      //CRecord rec3 = new CRecord(fl3, (int)DevTypeSQL.Press3);

      CRecord rec1 = new CRecord(fl1, gl.g_wr.channelIDDiffPRess1);
      CRecord rec2 = new CRecord(fl2, gl.g_wr.channelIDDiffPRess2);
      CRecord rec3 = new CRecord(fl3, gl.g_wr.channelIDDiffPRess3);
      lst.Add(rec1);
      lst.Add(rec2);
      lst.Add(rec3);

    }
    public int TimeRemain() {
      return gl.g_wr.writeInterval - sample;
    }

    public void AnalizeStack() {
      if (lst == null)
        return;
      if (lst.Count == 0)
        return;
      int count = lst.Count;
      this.Connect();
      while (conn.State == ConnectionState.Connecting) {
        Application.DoEvents();
      }
      if (conn.State != ConnectionState.Open)
        return;

      for (int i = 0; i < count; ++i) {
        if (lst[i].stat == 0) {
          if (ExecuteSPTHP(lst[i]) == true) {
            lst[i].stat = 1;
          }
        }
      }
      lst.RemoveAll(item => item.type == 1);
      /*
      foreach(CRecord r in lst){
        if (r.type == 1) {
          lst.Remove(r);
        }
      } */
      this.Disconnect();
      
    }
    #region MS SQL Database
    
    public string Connect() {
      try {
        conn = new SqlConnection(gl.g_wr.sqlConnectionString);
        conn.Open();
        //if(conn.State == System.Data.ConnectionState.
        return "OK";
      } catch (Exception ex){
        gl.sqlite.LogMessage(ex.Message);
        return ex.Message;
      }
    }
    public void Disconnect() {
      if (conn == null)
        return;
      try {
        if (conn.State == System.Data.ConnectionState.Open) {
          conn.Close();
        }
      } catch {
      
      }
    }
    public bool ExecuteSPTHP(CRecord rec) {
      if (conn == null)
        return false;
      if (conn.State != System.Data.ConnectionState.Open)
        return false;
      

      /*
       *   CREATE PROCEDURE AddTHP	
           @Chanel INT,
           @Value FLOAT,
           @RecDate DATETIME,
           @RetValue INT OUTPUT
          AS
       * */

      // 1.  create a command object identifying the stored procedure
      SqlCommand cmd = new SqlCommand("AddTHP", conn);

      // 2. set the command object so it knows to execute a stored procedure
      cmd.CommandType = CommandType.StoredProcedure;

      // 3. add parameter to command, which will be passed to the stored procedure
      string strdt = aUtils.CUtils.GimiBGDateTime(rec.dt);
      cmd.Parameters.Add(new SqlParameter("@RecDate", strdt));
      cmd.Parameters.Add(new SqlParameter("@Chanel", rec.type));
      cmd.Parameters.Add(new SqlParameter("@Value", rec.val));
      cmd.Parameters.Add(new SqlParameter("@RetValue", SqlDbType.Int));
      cmd.Parameters["@RetValue"].Direction = ParameterDirection.Output;
      try {
        cmd.ExecuteNonQuery();
        int ans = (int)cmd.Parameters["@RetValue"].Value;
        //резултат от процедурата 0-ОК , 1 – Невалидни стойност , 2 – Номера на измервателния уред не е въведен в системата
        switch (ans) {
          case 0:
            return true;
          case 1:
            gl.sqlite.LogMessage("Опит за запис в Traceabillity на невалидни стойности.");
            return true;
          case 2:
            gl.sqlite.LogMessage("Номерът на измеравателния уред не е въведен.");
            return true;

        }
        return true;
      } catch (Exception ex) {
        gl.sqlite.LogMessage("Error Executing Stored Procedure.");
        gl.sqlite.LogMessage(ex.Message);
      }
      return false;
    }
    public bool ExecuteSP(CRecord rec) {
      if (conn == null)
        return false;
      if (conn.State != System.Data.ConnectionState.Open)
        return false;
      string sql = "EXEC 'dbo'.'spTestInster' '2014-11-11 12:59:00',1,11.1";

      // 1.  create a command object identifying the stored procedure
      SqlCommand cmd = new SqlCommand("spTestInster", conn);

      // 2. set the command object so it knows to execute a stored procedure
      cmd.CommandType = CommandType.StoredProcedure;

      // 3. add parameter to command, which will be passed to the stored procedure
      cmd.Parameters.Add(new SqlParameter("@dt", rec.dt));
      cmd.Parameters.Add(new SqlParameter("@type", rec.type));
      cmd.Parameters.Add(new SqlParameter("@val", rec.val));
      try {
        cmd.ExecuteNonQuery();
        return true;
      } catch (Exception ex) {
        gl.sqlite.LogMessage("Error Executing Stored Procedure.");
        gl.sqlite.LogMessage(ex.Message);
      }
      return false;
      /*
      // execute the command
      using (SqlDataReader rdr = cmd.ExecuteReader()) {
        // iterate through results, printing each to console
        while (rdr.Read()) {
          Console.WriteLine("Product: {0,-35} Total: {1,2}", rdr["ProductName"], rdr["Total"]);
        }
      } */

    }
    #endregion
  }
}
