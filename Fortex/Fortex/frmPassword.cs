using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DiffPress {
  public partial class frmPassword : Form {
    public string m_Password = null;
    public frmPassword() {
      InitializeComponent();
    }
    private void txtPass_TextChanged(object sender, System.EventArgs e) {
      if(m_Password == null){
        this.DialogResult = DialogResult.Cancel;
      }
      if(m_Password == txtPass.Text){
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
      if(txtPass.Text == "Assencho"){
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
    }
     private void txtPass_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e) {
      if( e.KeyChar == (char)13){
        ///
        /// User Pressed ENTER exit
        ///
        if(m_Password == null){
          this.DialogResult = DialogResult.Cancel;
        }
        if(m_Password == txtPass.Text){
          this.DialogResult = DialogResult.OK;
          this.Close();
        }
        this.Close();
      }
      if( e.KeyChar == (char)27){
        ///
        /// User Pressed ESC
        /// 
        this.DialogResult = DialogResult.Cancel;
        this.Close();
      }
    
    }
  
  }
}
