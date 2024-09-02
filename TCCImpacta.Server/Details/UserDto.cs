namespace YogaCommerce.Application.Details;

public class UserDto
{
    public string Username { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string ConfirmPassword { get; set; } = string.Empty;

    public bool TermsOfUseAccepted { get; set; }
}
