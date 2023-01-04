using MimeKit;
using MailKit.Net.Smtp;
using TicketSeller.Models.Models;
using TicketSeller.Services.Services.IServices;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace TicketSeller.Services.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration _config;

    public EmailService(IConfiguration config)
    {
        _config = config;
    }

    public void SendConfirmationEmail(string[] receiverEmail, string emailSubject, int identityUserId, string confirmationToken)
    {
        EmailMessage emailMessage = new EmailMessage(receiverEmail, emailSubject, identityUserId, confirmationToken);

        MimeMessage message = CreateEmailMessage(emailMessage);

        Send(message);
    }

    private void Send(MimeMessage message)
    {
        using(var client = new SmtpClient())
        {
            var NetworkCredentials = new NetworkCredential(
                _config.GetValue<string>("EmailSettings:From"),
                _config.GetValue<string>("EmailSettings:Password")
                //"rafadevemail@gmail.com",
                //"yzqeffzlaerzfcui"
                );            
            try
            {
                client.Connect(
                    _config.GetValue<string>("EmailSettings:SmtpServer"),
                    _config.GetValue<int>("EmailSettings:Port"),
                    //"smtp.gmail.com",
                    //465,
                    true);
                client.AuthenticationMechanisms.Remove("XOUATH2");
                client.Authenticate(NetworkCredentials);
                client.Send(message);
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

    private MimeMessage CreateEmailMessage(EmailMessage emailMessage)
    {
        var from = _config.GetValue<string>("EmailSettings:From");
        MimeMessage newEmailMessage = new MimeMessage();
        newEmailMessage.From.Add(new MailboxAddress("reciver", from));
        newEmailMessage.To.AddRange(emailMessage.ReceiverEmail);
        newEmailMessage.Subject = emailMessage.Subject;
        newEmailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text)
        {
            Text = emailMessage.Content
        };
        return newEmailMessage;
    }
}
