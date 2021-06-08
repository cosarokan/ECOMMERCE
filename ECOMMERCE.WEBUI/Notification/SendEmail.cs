using System.Net;
using System.Net.Mail;

namespace ECOMMERCE.WEBUI.Notification
{
    public class SendEmail : INotification
    {
        public void SendMessage(string receiver, string receiversMessage)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress("");
            message.To.Add(new MailAddress(receiver));
            message.Subject = "Üyelik Aktivasyon";
            message.IsBodyHtml = true; //to make message body as html  
            message.Body = receiversMessage;
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com"; //for gmail host  
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new NetworkCredential("", "");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);
        }
    }
}
