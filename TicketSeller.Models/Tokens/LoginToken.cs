namespace TicketSeller.Models.Tokens;

public class LoginToken
{
	public LoginToken(string value)
	{
		Value = value;
	}
    public string Value { get; }
}
