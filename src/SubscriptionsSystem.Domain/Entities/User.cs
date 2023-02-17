namespace SubscriptionsSystem.Domain.Entities;

public class User : AggregateRoot
{
    public string Username { get; private set; }
    public string PasswordHash { get; private set; }
    public string PasswordSalt { get; private set; }
    public DateTime CreatedAtUtc { get; private set; }

    private User(int id, string username, string passwordHash, string passwordSalt, DateTime createdAtUtc) : base(id)
    {
        Username = username;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
        CreatedAtUtc = createdAtUtc;
    }

    public static User Create(string username, string passwordHash, string passwordSalt)
    {
        return new User(0, username, passwordHash, passwordSalt, DateTime.UtcNow);
    }
}