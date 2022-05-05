using Microsoft.Extensions.Options;
using SimbaToursEastAfrica.Domain.Models;
using SimbaToursEastAfrica.Services.EmailServices.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using ApplicationConstants;
using System.Net;

namespace SimbaToursEastAfrica.Services.EmailServices.Concretes
{
    public class EmailService : IMailService
    {
        public IOptions<ApplicationConstants.BusinessEmailDetails> _businessSmtpDetails;
        public EmailService(IOptions<ApplicationConstants.BusinessEmailDetails> businessSmtpDetails)
        {
            _businessSmtpDetails = businessSmtpDetails;
        }

        public IOptions<BusinessEmailDetails> BusinessEmailDetails {
            set { _businessSmtpDetails = value; }
            get { return _businessSmtpDetails; }
        }

        public string GetTemplate(EmailTemplate template)
        {
            throw new NotImplementedException();
        }

        public void SendEmail(EmailDao mail)
        {
            try
            {
                //Send Email:
                var networkCredentials = new NetworkCredential { UserName = _businessSmtpDetails.Value.NetworkUsername, Password = _businessSmtpDetails.Value.NetworkPassword };
                var smtpServer = new SmtpClient(_businessSmtpDetails.Value.SmtpServer);
                smtpServer.Credentials = networkCredentials;

                var mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(_businessSmtpDetails.Value.BusinessEmail);
                mailMessage.Body = mail.EmailBody;
                mailMessage.Subject = @"From " + mail.EmailFrom + " " + mail.EmailSubject;
                var memoryStream = new MemoryStream();
                var fileStream = new FileInfo("/images/attachement");

                if (mail.Attachment != null)
                {
                    var attachment = new Attachment(mail.Attachment.OpenReadStream(), mail.Attachment.FileName);
                    mailMessage.Attachments.Add(attachment);
                }
                mail.EmailTo += string.Format(";{0}", _businessSmtpDetails.Value.BusinessEmail);
                Array.ForEach<string>(mail.EmailTo.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries), (p) =>
                {
                    mailMessage.To.Add(p);
                });
                smtpServer.Send(mailMessage);
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
