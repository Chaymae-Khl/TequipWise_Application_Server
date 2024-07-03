using MailKit.Net.Smtp;
using MimeKit;
using Org.BouncyCastle.Asn1.Pkcs;
using User.Managmenet.Service.Models;
using static System.Net.Mime.MediaTypeNames;

namespace User.Managmenet.Service.Services
{



    public class EmailService : IEMailService
    {
        private readonly EmailConfiguration _emailConfig;
        public EmailService(EmailConfiguration emailConfig) => _emailConfig = emailConfig;
        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);
            Send(emailMessage);
        }
        private MimeMessage CreateEmailMessage(Message message)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("TequipWisw Email Service",_emailConfig.From));
            email.To.AddRange(message.To);
            email.Subject = message.Subject;

            var builder = new BodyBuilder();

            if (message.IsHtml)
            {
                builder.HtmlBody = message.Content;
                // Attach images
                var img1 = builder.LinkedResources.Add(@"Templates\Images\logo.png");
                img1.ContentId = "logo.png";
                var img2 = builder.LinkedResources.Add(@"Templates\Images\Te-img.jpg");
                img2.ContentId = "Te-img.jpg";
           
            }
            else
            {
                builder.TextBody = message.Content;
            }

            email.Body = builder.ToMessageBody();

            using var client = new SmtpClient();
            try
            {
                client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_emailConfig.Username, _emailConfig.Password);

                client.Send(email);
            }
            catch (Exception ex)
            {
                // Handle exception
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
            return email;

        }

        private void Send(MimeMessage mailMessage)
        {
            using var client = new SmtpClient();
            try
            {
                client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_emailConfig.Username, _emailConfig.Password);
                client.Send(mailMessage);
            }
            catch
            {
                throw;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    

    }
}
