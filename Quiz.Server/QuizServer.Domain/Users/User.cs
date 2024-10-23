using QuizServer.Domain.Shared;

namespace QuizServer.Domain.Users;

public class User : Entity
{
    private User() { }

    public User(UserName userName, Password password)
    {
        UserName = userName;
        Password = password;
    }

    public UserName UserName { get; set; } = default!;
    public Password Password { get; set; } = default!;
}
