using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace DiffPress {
  public partial class frmEmails : Form {
    CGlobal glob;
     private static List<System.Windows.Forms.TextBox> tbs = new List<TextBox>();
    public frmEmails() {
      InitializeComponent();
      tbs.Add(txtEmail1);
      tbs.Add(txtEmail2);
      tbs.Add(txtEmail3);
      tbs.Add(txtEmail4);
      tbs.Add(txtEmail5);
      tbs.Add(txtEmail6);
      tbs.Add(txtEmail7);
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
    
   
      
    void PopulateAdresants(CEmailSettings e){
      for (int i = 0; i < e.adresants.Length; ++i) {
        tbs[i].Text = e.adresants[i];
      }
    }
    void PopulateControls(CEmailSettings e){
      if(e == null)return;
      txtHost.Text = e.Host;
      txtPort.Text = e.Port.ToString();
      txtFrom.Text =  e.fromEmail;
      txtUser.Text = e.user;
      txtPassword.Text = e.pass;
      cbUseSSL.Checked =  e.useSsl;
      cbUseEmails.Checked = e.useEmails;
      PopulateAdresants(e);
      PopulateSoundRadioButton();
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

    void ApplyAdresants(CEmailSettings e) {
      for (int i = 0; i < e.adresants.Length; ++i) {
        e.adresants[i] = tbs[i].Text;
      }
    }
    void ApplySettings(CEmailSettings e) {
      e.Host = txtHost.Text;
      e.Port = Convert.ToInt32( txtPort.Text);
      e.fromEmail = txtFrom.Text;
      e.user = txtUser.Text;
      e.pass = txtPassword.Text;
      e.useSsl = cbUseSSL.Checked;
      e.useEmails = cbUseEmails.Checked;
      ApplyAdresants(e);
      ApplySoundWavFile();
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

    private void btnSyncSend_Click(object sender, EventArgs e) {

      CEmail em = new CEmail(ref glob);
      CEmailSettings set = glob.g_wr.emailSetts;
      em.sett = set;
      em.SendEmailSync(txtTestEmail.Text);
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
      ApplySoundWavFile();
      glob.SaveSettings();
    }

    private void btnTest_Click(object sender, EventArgs e) {
      CEmail em = new CEmail(ref glob);
      CEmailSettings set = glob.g_wr.emailSetts;
      em.sett = set;
      em.SendEmailAsync(txtTestEmail.Text, true);
    }

    private void btnApply_Click(object sender, EventArgs e) {
      CEmailSettings em = glob.g_wr.emailSetts;
      if (em == null) {
        em = new CEmailSettings();
      }
      ApplySettings(em);
    }

    private void label4_Click(object sender, EventArgs e) {

    }

    private void txtUser_TextChanged(object sender, EventArgs e) {
        
    }

    private void button1_Click(object sender, EventArgs e) {
      CEmail em = new CEmail(ref glob);
      CEmailSettings set = glob.g_wr.emailSetts;
      em.sett = set;
      em.Send2All();
    }
    #region Sound
    private void PopulateSoundRadioButton() {
      if(glob == null)return;
      if(glob.g_wr.alarmWavFile == "")return;
      cbUseSound.Checked = glob.g_wr.alarmPlaySound;
      if (glob.g_wr.alarmWavFile == "s1.wav") {
        rbSound1.Checked = true;
        return;
      }
      if (glob.g_wr.alarmWavFile == "s2.wav") {
        rbSound2.Checked = true;
        return;
      }
      if (glob.g_wr.alarmWavFile == "s3.wav") {
        rbSound3.Checked = true;
        return;
      }
      if (glob.g_wr.alarmWavFile == "s4.wav") {
        rbSound4.Checked = true;
        return;
      }

    }
    private void ApplySoundWavFile() {
      if (rbSound1.Checked == true) {
        glob.g_wr.alarmWavFile =  "s1.wav";
      }
      if (rbSound2.Checked == true) {
        glob.g_wr.alarmWavFile =  "s2.wav";
      }
      if (rbSound3.Checked == true) {
        glob.g_wr.alarmWavFile =  "s3.wav";
      }
      if (rbSound4.Checked == true) {
        glob.g_wr.alarmWavFile =  "s4.wav";
      }
      glob.g_wr.alarmPlaySound = cbUseSound.Checked;

      string pathWavFile = Application.StartupPath + @"\" + glob.g_wr.alarmWavFile;
      glob.sound.SetWavFile(pathWavFile);
      glob.sound.SetAlarmEnable(glob.g_wr.alarmPlaySound);
    }
    private void btnPlaySound_Click(object sender, EventArgs e) {
      System.Media.SoundPlayer player = null;
      if (rbSound1.Checked == true) {
        player = new System.Media.SoundPlayer( Application.StartupPath + @"\s1.wav");
      }
      if (rbSound2.Checked == true) {
        player = new System.Media.SoundPlayer( Application.StartupPath + @"\s2.wav");
      }
      if (rbSound3.Checked == true) {
        player = new System.Media.SoundPlayer( Application.StartupPath + @"\s3.wav");
      }
      if (rbSound4.Checked == true) {
        player = new System.Media.SoundPlayer( Application.StartupPath + @"\s4.wav");
      }
      //System.Media.SystemSounds.Asterisk.Play();
      
      if (player != null) {
        //player.PlayLooping();
        player.Play();
      }
      #endregion
      //DialogResult r = MessageBox.Show("aaaa","oooo",MessageBoxButtons.OKCancel);
      //if (r == System.Windows.Forms.DialogResult.OK) {
      //  player.Stop();
      //}
      
    }
  }
}
