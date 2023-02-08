namespace TicketSeller.Models.Stripe;
public class AddStripeCustomer 
{
    public string Email { get; set; }
    public string Name { get; set; }
    public StripeCard CreditCard { get; set; }
}
