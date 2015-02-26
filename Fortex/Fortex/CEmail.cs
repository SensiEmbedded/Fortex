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
  }
  public class CEmail {
    public CEmailSettings sett;
    private MailMessage ContructMailMessage(string toEmail) {
      MailMessage m = new MailMessage();
      //m.From = new MailAddress("control@fortex.bg", "RH&T Diff.Press. Control");
      m.From = new MailAddress(sett.fromEmail, "RH&T Diff.Press. Control");
      //m.To.Add(new MailAddress("assen@deltainst.com", "Display name To"));
      m.To.Add(new MailAddress(toEmail, "Display name To"));
      //m.CC.Add(new MailAddress("CC@yahoo.com", "Display name CC"));
      //similarly BCC
      m.Subject = "Test";
      m.Body = "This is a Test Mail";
      return m;
    }
    private SmtpClient ContructSmtpClient() {
      SmtpClient sc = new SmtpClient(); //SmtpClient configuration out of this scope
      sc.Host = "mail4.host.bg";
      sc.Port = 587;    
      //sc.Port = 25;    
      sc.DeliveryMethod = SmtpDeliveryMethod.Network;
      sc.UseDefaultCredentials = false;
      sc.Credentials = new System.Net.NetworkCredential("control@fortex.bg", "Control1!");
      sc.EnableSsl = true; // runtime encrypt the SMTP communications using SSL
      //sc.EnableSsl = false; // runtime encrypt the SMTP communications using 
      return sc;
    }
    public void SendEmail(string to) {
      SmtpClient smtpClient = ContructSmtpClient();
        MailMessage message = ContructMailMessage(to);
        smtpClient.SendCompleted += (s, ex) => {
          SmtpClient callbackClient = s as SmtpClient;
          MailMessage callbackMailMessage = ex.UserState as MailMessage;
          callbackClient.Dispose();
          callbackMailMessage.Dispose();
          MessageBox.Show("sent");
        };
        smtpClient.SendAsync(message, message);
    }
  }
}
