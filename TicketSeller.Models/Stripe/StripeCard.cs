namespace TicketSeller.Models.Stripe;

public class StripeCard
{
    public string Name { get; set; }
    public string CardNumber { get; set; }
    public long ExpirationYear { get; set; }
    public long ExpirationMonth { get; set; }
    public string Cvc { get; set; }
}
