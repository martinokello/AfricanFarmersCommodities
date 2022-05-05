using ApplicationConstants;
using Microsoft.Extensions.Options;
using SimbaToursEastAfrica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SimbaToursEastAfrica.Services.EmailServices.Interfaces
{
    public enum EmailTemplate { InviteMessage, HotelBookingMessage, PackageBookingMessage, InvoiceMessage, WelcomeMessage, OffersMessage}
    public interface IMailService
    {
        IOptions<BusinessEmailDetails> BusinessEmailDetails { get; set; }

        void SendEmail(EmailDao mail);
        string GetTemplate(EmailTemplate template);
    }
}
