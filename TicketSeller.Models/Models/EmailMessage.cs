using MimeKit;

namespace TicketSeller.Models.Models;

public class EmailMessage
{
    public List<MailboxAddress> ReceiverEmail { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }

    public EmailMessage(IEnumerable<string> receiver, string subject, int identityUserId, string confirmationToken)
    {
        ReceiverEmail = new List<MailboxAddress>();
        ReceiverEmail.AddRange(receiver.Select(r => new MailboxAddress(subject, r)));
        Subject = subject;
        Content = $"https://localhost:7283/confirm?UserId={identityUserId}&ConfirmUserAccountToken={confirmationToken}";
    }
}
