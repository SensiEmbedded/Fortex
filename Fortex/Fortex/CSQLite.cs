using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;  //for serial port
using System.IO.Ports;  //for seria
using System.Data.SQLite;
using System.Data;


namespace DiffPress {
  public class CMess {

    public int stat;      
    public string alias;
    public string mess;
    public DateTime dt;
 
    public CMess(string alias, string mess) {
      this.alias = alias;
      this.mess = mess;
    }
    public CMess(string mess) {
      this.mess = mess;
      dt = DateTime.Now;
    }
  }
  public class CSQLite {
    public List<CMess> lstm;
    public event ChangedEventHandler Changed;
    private System.Timers.Timer tmr = new System.Timers.Timer(1000);
    int sample;
      
    public CSQLite(){
      //CreateDataBase();
      GenerateStaticMessageList();
      tmr.Elapsed += new System.Timers.ElapsedEventHandler(tmr_Elapsed);
      tmr.Enabled = true;
    }

    void tmr_Elapsed(object sender, System.Timers.ElapsedEventArgs e) {
      if (++sample > 10 /** 60*/) {
        sample = 0;
        ClearOldMessages();

      }
    }
    #region Message Related
    void GenerateStaticMessageList() {
      lstm = new List<CMess>();
      //lstm.Add(new CMess("progStart", "Program started."));
      //lstm.Add(new CMess("progClose", "Program closed."));
      //lstm.Add(new CMess("comOpen", "COM port has been opened."));
      //lstm.Add(new CMess("comCannotOpen", "Cannot open COM port."));
      //lstm.Add(new CMess("comPortNotExist", "COM port not exist."));
    }
    /// <summary>
    /// Vryshta true ako message go e imalo v steka.
    /// w OUT parametyra zapisva tekushtia index w steka na message
    /// </summary>
    bool AddMessage(string mess,out int oix) {
      int ix = -1;
      foreach (CMess m in lstm) {
        ++ix;
        if (m.mess == mess) {
          oix = ix;
          return true;
        }
      }
      lstm.Add(new CMess(mess));
      oix = lstm.Count - 1;
      return false;
    }
    void ClearOldMessages() {
      DateTime n = DateTime.Now;
      lstm.RemoveAll(item => (n - item.dt).TotalMinutes > 30);

      /*foreach (CMess m in lstm) {
        TimeSpan ts = DateTime.Now - m.dt;
        if (ts.TotalMinutes > 15) {
          // ako sa minali poveche ot 15 minuti
          m.stat = 0;
          
        }
      } */
    }
    public void LogMessage(string mess) {
      int ix = -1;

      bool r = AddMessage(mess,out ix);
      if (r == true) {
        //Ima go v steka => e zapisan v sql bazata
        return;
      }
      
      lstm[ix].stat = 1;
      InsertRow(mess);
    }
    #endregion
    void FireChangeEvent() {
      if (Changed != null) {
        Changed(this, new EventArgs());
      } else {
      }
    }
    void CreateDataBase() {

      string DB_NAME = Application.StartupPath + @"\log.db";
      if (File.Exists(DB_NAME) == true) {
        return;
      }
      string connString = String.Format("Data Source={0};New=True;Version=3", DB_NAME);
      SQLiteConnection sqlconn = new SQLiteConnection(connString);
      sqlconn.Open();
      sqlconn.Close();
      CreateTable();
    }
    void CreateTable() {
      //string sql = "CREATE TABLE tblMessages(ID INT PRIMARY KEY NOT NULL, dt datetime, mess TEXT);";
      string sql = "CREATE TABLE tblMess(ID INTEGER PRIMARY KEY, dt datetime, mess TEXT);";
      string DB_NAME = Application.StartupPath + @"\log.db";
      string connString = String.Format("Data Source={0};New=False;Version=3", DB_NAME);
      SQLiteConnection sqlconn = new SQLiteConnection(connString);
      sqlconn.Open();
      string CommandText = String.Format("{0}", sql);
      SQLiteCommand SQLiteCommand = new SQLiteCommand(CommandText, sqlconn);
      SQLiteCommand.ExecuteNonQuery();
      sqlconn.Close();
    }
    
    void InsertRow(string mess) {
      string DB_NAME = Application.StartupPath + @"\log.db";
      string connString = String.Format("Data Source={0};New=False;Version=3", DB_NAME);
      SQLiteConnection sqlconn = new SQLiteConnection(connString);
      sqlconn.Open();
      SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO tblMess (dt,mess) VALUES (?,?)", sqlconn);
      //insertSQL.Parameters.Add(book.Id);
      insertSQL.Parameters.Add(new SQLiteParameter("@dt", DateTime.Now));
      insertSQL.Parameters.Add(new SQLiteParameter("@mess", mess));

      try {
        insertSQL.ExecuteNonQuery();
      } catch (Exception ex) {
        throw new Exception(ex.Message);
      }
      sqlconn.Close();
      FireChangeEvent();
    }
    public DataSet GimitblMess() {
      string DB_NAME = Application.StartupPath + @"\log.db";
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
      const string sql = "select * from tblMess ORDER BY ID DESC LIMIT 100";
      string connString = String.Format("Data Source={0};New=False;Version=3", DB_NAME);
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
    
  }
}
