using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DiffPress {
  public partial class frmSetMM : Form {
    CGlobal glob;
    public frmSetMM() {
      InitializeComponent();
    }
    public void SetRef(ref CGlobal rfGl) {
      glob = rfGl;
    }
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
      if (keyData == Keys.Escape) {
        this.Close();
        return true;
      }
      return base.ProcessCmdKey(ref msg, keyData);
    }
    void ReadMM(byte addr,TextBox lbl) {
      ushort[] holdingregister = null;
      //holdingregister = gl.comm.master.ReadHoldingRegisters(cmn.slaveID, startAddress, numofPoints);
      try {
        holdingregister = glob.comm.master.ReadHoldingRegisters(addr, 1, 1);
        lbl.Text = holdingregister[0].ToString();
      } catch(Exception exs) {
        MessageBox.Show(exs.Message);
      }
    }
    
    private void btnReadAll_Click(object sender, EventArgs e) {
      ReadMM(1,txtHowManyMM1);
      ReadMM(2,txtHowManyMM2);
      ReadMM(3,txtHowManyMM3);

    }
    void SetMM(TextBox txt,byte addr){
      ushort[] data = new ushort[1];
      string t = txt.Text;
      try {
        ushort s = Convert.ToUInt16(t);
        if (s > 32) {
          MessageBox.Show("Не повече от 32");
          return;
        }
        if (s < 0) {
          MessageBox.Show("Отрицателен брой??");
          return;
        }
        data[0] = s;
        glob.comm.master.WriteMultipleRegisters(addr,1,data);
      }catch(Exception  ex){
        MessageBox.Show(ex.Message);
      }
    }
    private void btnSetMM1_Click(object sender, EventArgs e) {
      SetMM(txtHowManyMM1,1);
    }

    private void btnsetMM2_Click(object sender, EventArgs e) {
      SetMM(txtHowManyMM2,2);
    }

    private void btnSetMM3_Click(object sender, EventArgs e) {
      SetMM(txtHowManyMM3,3);
    }
  }
}
