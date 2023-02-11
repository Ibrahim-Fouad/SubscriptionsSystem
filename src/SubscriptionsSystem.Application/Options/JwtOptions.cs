namespace SubscriptionsSystem.Application.Options;

public class JwtOptions
{
    public const string JwtConfigKey = "Jwt";
    public string Key { get; set; } = string.Empty;
    public int ExpirationInHours { get; set; }
}