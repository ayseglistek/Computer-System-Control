using System;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ComputerSystemControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DateTime thisDay = DateTime.Now;
            label2.Text = thisDay.ToString();
        }

        private void Form1_Load(object sender, EventArgs e) // Form yüklendiğinde çalışacak fonksiyon
        {
            SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;
        }

        static void SystemEvents_SessionSwitch(Object sender, SessionSwitchEventArgs e) // Event System tetiklemek için yazılan fonksiyon
        {
            DateTime thisDay = DateTime.Now; // Tarihi ve saati alır
            
            if (e.Reason == SessionSwitchReason.SessionLogoff)
            {
                SendToMail("Kullanıcı oturumdan oturumu kapatmış." + "\nTarih/Saat: " + thisDay.ToString(), "BILGILENDIRME"); // Mail gönderme fonksiyonu çağırıldı.
                MessageBox.Show("Mail başarılı bir şekilde gönderildi."); // Mail gönderildiğine dair bilgilendirme mesajı
            }
            if (e.Reason == SessionSwitchReason.SessionLogon)
            {
                SendToMail("Kullanıcı oturum açtı." + "\nTarih/Saat: " + thisDay.ToString(), "BILGILENDIRME"); // Mail gönderme fonksiyonu çağırıldı.
                MessageBox.Show("Mail başarılı bir şekilde gönderildi.");// Mail gönderildiğine dair bilgilendirme mesajı
            }
            if (e. Reason == SessionSwitchReason.SessionLock)
            {
                SendToMail("Oturum kilitlendi." + "\nTarih/Saat: " + thisDay.ToString(), "BILGILENDIRME"); // Mail gönderme fonksiyonu çağırıldı.
                MessageBox.Show("Mail başarılı bir şekilde gönderildi.");// Mail gönderildiğine dair bilgilendirme mesajı
            }

            if (e.Reason == SessionSwitchReason.SessionUnlock)
            {
                SendToMail("Oturumun kilidi açık."+ "\nTarih/Saat: " + thisDay.ToString(), "BILGILENDIRME"); // Mail gönderme fonksiyonu çağırıldı.
                MessageBox.Show("Mail başarılı bir şekilde gönderildi.");// Mail gönderildiğine dair bilgilendirme mesajı
            }
        }

        public static void SendToMail(string message, string subject) // Mail gönderme fonksiyonu
        {
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("firatsend23@gmail.com", "Qwerty123+456");
            MailMessage mm = new MailMessage("firatsend23@gmail.com", "firatsend23@gmail.com", subject, message);
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            client.Send(mm);
        }

    }
}
