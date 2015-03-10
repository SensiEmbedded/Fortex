using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net.Mime;

namespace DiffPress {
  public class CEmailSettings{
    public string Host { get; set; }
    public int Port { get; set; }
    public string fromEmail { get; set; }
    public string user { get; set; }
    public string pass { get; set; }
    public bool useSsl { get; set; }
    public bool useEmails { get; set; }

    private string[] _adresants =  new string[7];
    public string[] adresants {
      get {
        return _adresants;
      }
      set {
        _adresants = value;
      }
    }
    
  }
  public class CEmail {
    public CEmailSettings sett;
    CGlobal gl;
    public CEmail(ref CGlobal glob) {
      gl = glob;
    }
    private MailMessage ContructMailMessage(string toEmail) {
      MailMessage m = new MailMessage();
      //m.From = new MailAddress("control@fortex.bg", "RH&T Diff.Press. Control");
      m.From = new MailAddress(sett.fromEmail, "RH&T Diff.Press. Control");
      //m.To.Add(new MailAddress("assen@deltainst.com", "Display name To"));
      m.To.Add(new MailAddress(toEmail));
      //m.CC.Add(new MailAddress("CC@yahoo.com", "Display name CC"));
      //similarly BCC
      m.Subject = "Test";
      m.Body = "This is a Test Mail";
      return m;
    }
    private SmtpClient ContructSmtpClient() {
      SmtpClient sc = new SmtpClient(); //SmtpClient configuration out of this scope
      //sc.Host = "mail4.host.bg";
      sc.Host = sett.Host;
      sc.Port = sett.Port;    
      //sc.Port = 587;    
      //sc.Port = 25;    
      sc.DeliveryMethod = SmtpDeliveryMethod.Network;
      sc.UseDefaultCredentials = false;
      sc.Credentials = new System.Net.NetworkCredential(sett.user,sett.pass);
      //sc.Credentials = new System.Net.NetworkCredential("control@fortex.bg", "Control1!");
      //sc.EnableSsl = true; // runtime encrypt the SMTP communications using SSL
      sc.EnableSsl = sett.useSsl; // runtime encrypt the SMTP communications using SSL
      //sc.EnableSsl = false; // runtime encrypt the SMTP communications using 
      return sc;
    }
    public void SendEmailAsync(string to,bool isTest,string subject, string body) {
      try {

        SmtpClient smtpClient = ContructSmtpClient();
        MailMessage message = ContructMailMessage(to);
        message.Subject = subject;
        message.Body = body;
        smtpClient.SendCompleted += (s, ex) => {
          try {
            SmtpClient callbackClient = s as SmtpClient;
            MailMessage callbackMailMessage = ex.UserState as MailMessage;
            callbackClient.Dispose();
            callbackMailMessage.Dispose();
          }catch(Exception e){
            if (isTest == true) {
              MessageBox.Show("Err in sending email async:" + e.Message);
            } else {
              gl.sqlite.LogMessage("Err in sending email async:" + e.Message);
            }
          }
        };
        smtpClient.SendAsync(message, message);
      } catch (Exception ex) {
        if (isTest == true) {
          MessageBox.Show("Err in sending email async:" + ex.Message);
        } else {
          gl.sqlite.LogMessage("Err in sending email async:" + ex.Message);
        }
      }
    }
    public void Send2All(string subject, string body) {
      if(gl == null)return;
      if(gl.g_wr.emailSetts == null)return;
      if(gl.g_wr.emailSetts.adresants == null)return;
      if(gl.g_wr.emailSetts.useEmails == false)return;
      for (int i = 0; i < gl.g_wr.emailSetts.adresants.Length; ++i) {
        string add = gl.g_wr.emailSetts.adresants[i];
        if (add == "") {
          continue;
        }
        SendEmailAsync(add,false,subject,body);
      }
    }
    public void SendEmailSync(string to) {
      SmtpClient smtpClient = ContructSmtpClient();
      MailMessage message = ContructMailMessage(to);
      smtpClient.Send(message);

        /*smtpClient.SendCompleted += (s, ex) => {
          SmtpClient callbackClient = s as SmtpClient;
          MailMessage callbackMailMessage = ex.UserState as MailMessage;
          callbackClient.Dispose();
          callbackMailMessage.Dispose();
          MessageBox.Show("sent");
        };
        smtpClient.SendAsync(message, message);*/
    }
  }
}
