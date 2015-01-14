using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace DiffPress{
  
  public class CGlobal{
    public CSer g_wr;
    public CComunication comm;
    
    public CSQLite sqlite;
    public CMSSQL  mssql;

    public CGlobal(){

      string path = Application.StartupPath + "\\CSer.xml";
      try {
        g_wr = CSer.DeserializeMe(path);
      } catch {
        //MessageBox.Show("Can't read properties from xml file 'CSer.xml'");
        g_wr = new CSer();
        g_wr.SetDefaults();
        CSer.SerializeMe(g_wr, path);
      }
      sqlite = new CSQLite();
      comm = new CComunication();
      mssql = new CMSSQL();
    }
    public void SaveSettings() {                    
      string path = Application.StartupPath + "\\CSer.xml";
      CSer.SerializeMe(g_wr, path);
    }
    
  }
}                            
                                                    