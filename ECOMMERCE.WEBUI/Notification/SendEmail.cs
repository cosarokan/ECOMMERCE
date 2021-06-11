using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Mail;

namespace ECOMMERCE.WEBUI.Notification
{
    public class SendEmail : INotification
    {
        private readonly IConfiguration _iConfig;
        public ILogger<SendEmail> _logger;
        public SendEmail(IConfiguration iConfig, ILogger<SendEmail> logger)
        {
            _iConfig = iConfig;
            _logger = logger;
        }

        public void SendMessage(string receiver, string receiversMessage)
        {
            try
            {
                string senderEmailAddress = _iConfig.GetSection("MailSettings:EmailAddress").Value;
                string password = _iConfig.GetSection("MailSettings:Password").Value;

                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(senderEmailAddress);
                message.To.Add(new MailAddress(receiver));
                message.Subject = "Üyelik Aktivasyon";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = receiversMessage;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(senderEmailAddress, password);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}
