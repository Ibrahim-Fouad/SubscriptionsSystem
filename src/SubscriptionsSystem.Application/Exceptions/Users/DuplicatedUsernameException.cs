namespace SubscriptionsSystem.Application.Exceptions.Users;

public class DuplicatedUsernameException : Exception
{
    public DuplicatedUsernameException() : base("Username you have provided is already exists.")
    {
    }

    public DuplicatedUsernameException(string username) : base(
        $"Username '{username}' you have provided is already exists.")
    {
    }
}