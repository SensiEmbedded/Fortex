using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;  //for serial port
using System.IO.Ports;  //for seria
using System.Data.SQLite;
using System.Data;
using aUtils;

namespace DiffPress {
  public class CSQLiteData {
    public event ChangedEventHandler Changed;
    private System.Timers.Timer tmr = new System.Timers.Timer(1000);
    int sample;
    public CSQLiteData(){
      CreateDataBase();
      //GenerateStaticMessageList();
      tmr.Elapsed += new System.Timers.ElapsedEventHandler(tmr_Elapsed);
      tmr.Enabled = true;
    }
    void tmr_Elapsed(object sender, System.Timers.ElapsedEventArgs e) {
      if (++sample > 10 /** 60*/) {
        sample = 0;
        //ClearOldMessages();
      }
    }
    void FireChangeEvent() {
      if (Changed != null) {
        Changed(this, new EventArgs());
      } else {
      }
    }
    #region DataBase CreateTable, InsertRow ,GimitblMess()

    void CreateDataBase() {
      string DB_NAME = Application.StartupPath + @"\data.db";
      if (File.Exists(DB_NAME) == true) {
        return;
      }
      string connString = String.Format("Data Source={0};New=True;Version=3", DB_NAME);
      SQLiteConnection sqlconn = new SQLiteConnection(connString);
      sqlconn.Open();
      sqlconn.Close();
      CreateTableData();
      CreateTableAlarm();
    }
    void CreateTableData() {
      //string sql = "CREATE TABLE tblMessages(ID INT PRIMARY KEY NOT NULL, dt datetime, mess TEXT);";
      string sql = "CREATE TABLE tblData(ID INTEGER PRIMARY KEY, dt datetime, device TEXT,val1 REAL,val2 REAL);";
      string DB_NAME = Application.StartupPath + @"\data.db";
      string connString = String.Format("Data Source={0};New=False;Version=3", DB_NAME);
      SQLiteConnection sqlconn = new SQLiteConnection(connString);
      sqlconn.Open();
      string CommandText = String.Format("{0}", sql);
      SQLiteCommand SQLiteCommand = new SQLiteCommand(CommandText, sqlconn);
      SQLiteCommand.ExecuteNonQuery();
      sqlconn.Close();
    }
    void CreateTableAlarm() {
      //string sql = "CREATE TABLE tblMessages(ID INT PRIMARY KEY NOT NULL, dt datetime, mess TEXT);";
      string sql = "CREATE TABLE tblAlarms(ID INTEGER PRIMARY KEY, dt datetime, device TEXT,val REAL,mess TEXT);";
      string DB_NAME = Application.StartupPath + @"\data.db";
      string connString = String.Format("Data Source={0};New=False;Version=3", DB_NAME);
      SQLiteConnection sqlconn = new SQLiteConnection(connString);
      sqlconn.Open();
      string CommandText = String.Format("{0}", sql);
      SQLiteCommand SQLiteCommand = new SQLiteCommand(CommandText, sqlconn);
      SQLiteCommand.ExecuteNonQuery();
      sqlconn.Close();
    }

    public void InsertAlarmRow(string device, double val,string mess) {
      string DB_NAME = Application.StartupPath + @"\data.db";
      string connString = String.Format("Data Source={0};New=False;Version=3", DB_NAME);
      //---------------------
      //"CREATE TABLE tblAlarms(ID INTEGER PRIMARY KEY, dt datetime, device TEXT,val REAL,mess TEXT);";
      SQLiteConnection sqlconn = new SQLiteConnection(connString);
      string queryString = "INSERT INTO tblAlarms (dt,device,val,mess) VALUES (?,?,?,?)";
      SQLiteCommand command = new SQLiteCommand(queryString);
      command.Parameters.Add(new SQLiteParameter("@dt", DateTime.Now));
      command.Parameters.Add(new SQLiteParameter("@device", device));
      command.Parameters.Add(new SQLiteParameter("@val", val));
      command.Parameters.Add(new SQLiteParameter("@mess", mess));
      try {
        sqlconn.Open();
        command.Connection = sqlconn;
        command.ExecuteNonQuery();
      } catch (Exception ex) {
        if (ex.Message.Contains("locked")) {
        }
      } finally {
        sqlconn.Close();
        command.Dispose();
        sqlconn.Dispose();
      }

    }

    public void InsertDataRow(string device, double val1, double val2) {
      string DB_NAME = Application.StartupPath + @"\data.db";
      string connString = String.Format("Data Source={0};New=False;Version=3", DB_NAME);
      //---------------------
      SQLiteConnection sqlconn = new SQLiteConnection(connString);
      string queryString = "INSERT INTO tblData (dt,device,val1,val2) VALUES (?,?,?,?)";
      SQLiteCommand command = new SQLiteCommand(queryString);
      command.Parameters.Add(new SQLiteParameter("@dt", DateTime.Now));
      command.Parameters.Add(new SQLiteParameter("@device", device));
      command.Parameters.Add(new SQLiteParameter("@val1", val1));
      command.Parameters.Add(new SQLiteParameter("@val2", val2));

      try {
        sqlconn.Open();
        command.Connection = sqlconn;
        command.ExecuteNonQuery();
      } catch (Exception ex) {
        if (ex.Message.Contains("locked")) {
        }
      } finally {
        sqlconn.Close();
        command.Dispose();
        sqlconn.Dispose();
      }
      //---------------------
      /*
      using (var connection = new SQLiteConnection(connString)) {
        string queryString = "INSERT INTO tblData (dt,device,val1,val2) VALUES (?,?,?,?)";
        using (var command = new SQLiteCommand(queryString, connection)) {
          command.Parameters.Add(new SQLiteParameter("@dt", DateTime.Now));
          command.Parameters.Add(new SQLiteParameter("@device", device));
          command.Parameters.Add(new SQLiteParameter("@val1", val1));
          command.Parameters.Add(new SQLiteParameter("@val2", val2));
          command.Connection.Open();
          command.ExecuteNonQuery();
        }
      } */
    }
    public void InsertDataRow2(string device,double val1,double val2) {
      string DB_NAME = Application.StartupPath + @"\data.db";
      string connString = String.Format("Data Source={0};New=False;Version=3", DB_NAME);
      SQLiteConnection sqlconn = new SQLiteConnection(connString);
      sqlconn.Open();
      //"CREATE TABLE tblData(ID INTEGER PRIMARY KEY, dt datetime, device TEXT,val REAL);"
      SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO tblData (dt,device,val1,val2) VALUES (?,?,?,?)", sqlconn);
      //insertSQL.Parameters.Add(book.Id);
      insertSQL.Parameters.Add(new SQLiteParameter("@dt", DateTime.Now));
      insertSQL.Parameters.Add(new SQLiteParameter("@device", device));
      insertSQL.Parameters.Add(new SQLiteParameter("@val1", val1));
      insertSQL.Parameters.Add(new SQLiteParameter("@val2", val2));

      try {
        insertSQL.ExecuteNonQuery();
      } catch (Exception ex) {
        if (ex.Message.Contains("no such table")) {
          CreateTableData();
          return;
        }
        throw new Exception(ex.Message);
      }
      sqlconn.Close();
      FireChangeEvent();
    }
    public DataSet GimitblMess(string id) {
      string DB_NAME = Application.StartupPath + @"\data.db";
      /*
      const string sql = @"SELECT * 
        FROM                                           
        (
             SELECT *
             FROM tblMess
             ORDER BY ID DESC
             LIMIT 3 
        ) T1
      ORDER BY ID";
        */
      string connString = String.Format("Data Source={0};New=False;Version=3", DB_NAME);
      string sql = "select * from tblData WHERE device = '"+ id + "' ORDER BY ID DESC LIMIT 100";
      //SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO tblData (dt,device,val) VALUES (?,?,?)", connString);

      SQLiteConnection conn = new SQLiteConnection(connString);

      try {
        conn.Open();
        DataSet ds = new DataSet();
        var da = new SQLiteDataAdapter(sql, conn);
        da.Fill(ds);
        //dataGridView1.DataSource = ds.Tables[0].DefaultView;
        return ds;
      } catch (Exception) {
        //throw;
      }
      return null;
    }
    private SQLiteCommand CreateRHCommand(string id, DateTime dtStart, DateTime dtEnd, int Limit) {
      string start = CUtils.GimiGlobalDateTime(dtStart);
      string end = CUtils.GimiGlobalDateTime(dtEnd);
      //(dt,device,val1,val2)
      string sql = "select ID,dt,device,val1,val2 from tblData WHERE device = @id AND dt BETWEEN @start and @end ORDER BY ID DESC LIMIT @limit";
      //string sql = "select * from tblData WHERE device = @id AND dt BETWEEN @start and @end ORDER BY ID DESC LIMIT @limit";
      SQLiteCommand selectSQL = new SQLiteCommand(sql);
      selectSQL.Parameters.AddWithValue("@id", id);
      selectSQL.Parameters.AddWithValue("@start", start);
      selectSQL.Parameters.AddWithValue("@end", end);
      selectSQL.Parameters.AddWithValue("@limit", Limit);
      return selectSQL;
    }
    private SQLiteCommand CreatePressureCommand(string id, DateTime dtStart, DateTime dtEnd, int Limit) {
      string start = CUtils.GimiGlobalDateTime(dtStart);
      string end = CUtils.GimiGlobalDateTime(dtEnd);
      //(dt,device,val1,val2)
      string sql = "select ID,dt,device,val1 from tblData WHERE device = @id AND dt BETWEEN @start and @end ORDER BY ID DESC LIMIT @limit";
      //string sql = "select * from tblData WHERE device = @id AND dt BETWEEN @start and @end ORDER BY ID DESC LIMIT @limit";
      SQLiteCommand selectSQL = new SQLiteCommand(sql);
      selectSQL.Parameters.AddWithValue("@id", id);
      selectSQL.Parameters.AddWithValue("@start", start);
      selectSQL.Parameters.AddWithValue("@end", end);
      selectSQL.Parameters.AddWithValue("@limit", Limit);
      return selectSQL;
    } 
    public DataSet GimitblMess(TypeDevice type, string id,DateTime dtStart,DateTime dtEnd,int Limit) {
      
      string DB_NAME = Application.StartupPath + @"\data.db";
      string start = CUtils.GimiGlobalDateTime(dtStart);
      string end = CUtils.GimiGlobalDateTime(dtEnd);
      string connString = String.Format("Data Source={0};New=False;Version=3", DB_NAME);
      SQLiteConnection sqlconn = new SQLiteConnection(connString);
      SQLiteCommand selectSQL;
      if (type == TypeDevice.RHT) {
        selectSQL = CreateRHCommand(id, dtStart, dtEnd, Limit);
      } else {
        selectSQL = CreatePressureCommand(id, dtStart, dtEnd, Limit);
      }
      
      try {
        sqlconn.Open();
        DataSet ds = new DataSet();
        selectSQL.Connection = sqlconn;
        selectSQL.ExecuteScalar();
        var da = new SQLiteDataAdapter(selectSQL);
        //var da = new SQLiteDataAdapter(sql, conn);
        da.Fill(ds);
        
        //dataGridView1.DataSource = ds.Tables[0].DefaultView;
        return ds;
      } catch (Exception ex) {
        System.Diagnostics.Debug.WriteLine(ex.Message);
        //throw;
      } finally {
        sqlconn.Close();
        selectSQL.Dispose();
        sqlconn.Dispose();
      }
      
      return null;
    }
    public int SelectLastID_Alarms() {
      string DB_NAME = Application.StartupPath + @"\data.db";
      
      string connString = String.Format("Data Source={0};New=False;Version=3", DB_NAME);
      SQLiteConnection sqlconn = new SQLiteConnection(connString);
      string sql = "SELECT Max(ID) FROM tblAlarms";
      //string sql = "select * from tblData WHERE device = @id AND dt BETWEEN @start and @end ORDER BY ID DESC LIMIT @limit";
      SQLiteCommand selectSQL = new SQLiteCommand(sql);
      int rezID;
      try {
        sqlconn.Open();
        selectSQL.Connection = sqlconn;
        selectSQL.ExecuteNonQuery();
        var da = new SQLiteDataAdapter(selectSQL);
        //var da = new SQLiteDataAdapter(sql, conn) ;
        DataSet ds = new DataSet();
        da.Fill(ds);
        //var da = new SQLiteDataAdapter(sql, conn);
        if (ds.Tables[0].Rows.Count == 1) {
          DataRow dr = ds.Tables[0].Rows[0];
          int r = Convert.ToInt32(dr[0]);
          return r;
        }
        return -1;
      } catch (Exception ex) {
        System.Diagnostics.Debug.WriteLine(ex.Message);
        //throw;
      } finally {
        sqlconn.Close();
        selectSQL.Dispose();
        sqlconn.Dispose();
      }
      
      return -1;
    }
    public DataSet GimiLast100Alarms() {
      
      string DB_NAME = Application.StartupPath + @"\data.db";
      
      string connString = String.Format("Data Source={0};New=False;Version=3", DB_NAME);
      SQLiteConnection sqlconn = new SQLiteConnection(connString);
      string sql = "select * FROM tblalarms ORDER BY ID DESC LIMIT 100";
      //string sql = "select * from tblData WHERE device = @id AND dt BETWEEN @start and @end ORDER BY ID DESC LIMIT @limit";
      SQLiteCommand selectSQL = new SQLiteCommand(sql);
      
      try {
        sqlconn.Open();
        DataSet ds = new DataSet();
        selectSQL.Connection = sqlconn;
        selectSQL.ExecuteScalar();
        var da = new SQLiteDataAdapter(selectSQL);
        //var da = new SQLiteDataAdapter(sql, conn);
        da.Fill(ds);
        
        //dataGridView1.DataSource = ds.Tables[0].DefaultView;
        return ds;
      } catch (Exception ex) {
        System.Diagnostics.Debug.WriteLine(ex.Message);
        //throw;
      } finally {
        sqlconn.Close();
        selectSQL.Dispose();
        sqlconn.Dispose();
      }
      
      return null;
    }
    #endregion
  }
}
