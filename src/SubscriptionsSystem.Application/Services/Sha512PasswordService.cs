using System.Security.Cryptography;
using System.Text;

namespace SubscriptionsSystem.Application.Services;

public static class Sha512PasswordService
{
    public static (string passwordHash, string passwordSalt) Generate(string password)
    {
        using var hmac = new HMACSHA512();
        var passwordSalt = Convert.ToBase64String(hmac.Key);
        var passwordHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
        return (passwordHash, passwordSalt);
    }

    public static bool ValidatePassword(string password, string passwordHash, string passwordSalt)
    {
        using var hmac = new HMACSHA512(Convert.FromBase64String(passwordSalt));
        var passwordGenerated = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

        return Convert.ToBase64String(passwordGenerated) == passwordHash;
    }
}