using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;

namespace GameShop.Models.Service.Implementation;

public class GmailSender:IEmailSender
{
    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        //SmtpClient client = new SmtpClient
        //{
            //Port = 465,
            //Host = "smtp.gmail.com", //or another email sender provider
            //EnableSsl = true,
            //DeliveryMethod = SmtpDeliveryMethod.Network,
            //UseDefaultCredentials = false,
            //Credentials = new NetworkCredential("gameshop.kursproj@gmail.com", "_Password_05")
        //};
        //return client.SendMailAsync("gameshop.kursproj@gmail.com", email, subject, htmlMessage);
        
    }

    
}