namespace SubscriptionsSystem.Application.Exceptions.Users;

public class InvalidUsernameOrPasswordException : Exception
{
    public InvalidUsernameOrPasswordException() : base("Invalid username or password")
    {
    }

    public InvalidUsernameOrPasswordException(string message) : base(message)
    {
    }
}