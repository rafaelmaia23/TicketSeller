namespace TicketSeller.Services.Services.IServices;

public interface IEmailService
{
    void SendConfirmationEmail(string[] receiverEmail, string emailSubject, int identityUserId, string confirmationToken);
}
