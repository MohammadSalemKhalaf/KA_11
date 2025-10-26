using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace KA_11.PL.utils
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("mohammadkhalaf3hfg@gmail.com", "sjhn tkow ofnd tcrv\r\n")
            };

            return client.SendMailAsync(
                new MailMessage(from: "your.email@live.com",
                                to: email,
                                subject,
                                htmlMessage
                                )
                {IsBodyHtml = true });
        } 
    }
}
