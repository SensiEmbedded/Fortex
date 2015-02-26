using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DiffPress {
  public partial class frmEmails : Form {
    CGlobal glob;
    public frmEmails() {
      InitializeComponent();
    }
    public void SetRef(ref CGlobal rfGl) {
      glob = rfGl;
      PopulateControls(glob.g_wr.emailSetts);
    }
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
      if (keyData == Keys.Escape) {
        this.Close();
        return true;
      }
      return base.ProcessCmdKey(ref msg, keyData);
    }

    void PopulateControls(CEmailSettings e){
      if(e == null)return;
      txtHost.Text = e.Host;
      txtPort.Text = e.Port.ToString();
      txtFrom.Text =  e.fromEmail;
      txtUser.Text = e.user;
      txtPassword.Text = e.pass;
      cbUseSSL.Checked =  e.useSsl;
    }
    bool ValidateControls() {
      foreach (Control c in groupBox1.Controls) {
        
        if( c.GetType() ==  typeof(System.Windows.Forms.TextBox)) {
          TextBox t = c as TextBox;
          if (t.Text == "") {
            return false;
          }
          
        } 
      }

      return true;
    }

    void ApplySettings(CEmailSettings e) {
      e.Host = txtHost.Text;
      e.Port = Convert.ToInt32( txtPort.Text);
      e.fromEmail = txtFrom.Text;
      e.user = txtUser.Text;
      e.pass = txtPassword.Text;
      e.useSsl = cbUseSSL.Checked;
    }
    void Send() {
      /*
      foreach (string customer in Customers) {
        SmtpClient smtpClient = ContructSmtpClient();
        MailMessage message = ContructMailMessage();
        smtpClient.SendCompleted += (s, ex) => {
          SmtpClient callbackClient = s as SmtpClient;
          MailMessage callbackMailMessage = ex.UserState as MailMessage;
          callbackClient.Dispose();
          callbackMailMessage.Dispose();
        };
        smtpClient.SendAsync(message, message);
      } */
    }
    private void btnSetDefaults_Click(object sender, EventArgs e) {
      DialogResult result1 = MessageBox.Show("This will erase all settings and set them to theirs defaults?",
      		"ВНИМАВАЙТЕ",
		      MessageBoxButtons.YesNo);
      if (result1 == System.Windows.Forms.DialogResult.Yes) {
        glob.g_wr.SetDefaultsEmail();
        PopulateControls(glob.g_wr.emailSetts);
      }
    }

    private void button1_Click(object sender, EventArgs e) {
      CEmail em = new CEmail();
      CEmailSettings set = glob.g_wr.emailSetts;
      em.sett = set;
      em.SendEmail(txtTestEmail.Text);
    }

    private void btnClose_Click(object sender, EventArgs e) {
      if (ValidateControls() == false) {
        DialogResult result1 = MessageBox.Show("There are empty fields. Are you sure wnat to close this dialog?",
          "ВНИМАВАЙТЕ",
          MessageBoxButtons.YesNo);
        if (result1 == System.Windows.Forms.DialogResult.Yes) {
          this.Close();
        }
      } else {
        this.Close();
      }
    }

    private void btnSave_Click(object sender, EventArgs e) {
      CEmailSettings em = glob.g_wr.emailSetts;
      if (em == null) {
        em = new CEmailSettings();
      }
      ApplySettings(em);
      glob.SaveSettings();
    }
  }
}
