namespace SubscriptionsSystem.Domain.Entities;

public class User : Entity
{
    public string Name { get; private set; }
    public string PasswordHash { get; private set; }
    public string PasswordSalt { get; private set; }
    public DateTime CreatedAtUtc { get; private set; }

    private User(int id, string name, string passwordHash, string passwordSalt, DateTime? createdAtUtc) : base(id)
    {
        Name = name;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
        CreatedAtUtc = createdAtUtc ?? DateTime.UtcNow;
    }

    public static User Create(int id, string name, string passwordHash, string passwordSalt, DateTime? createdAtUtc)
    {
        return new User(id, name, passwordHash, passwordSalt, createdAtUtc);
    }
}