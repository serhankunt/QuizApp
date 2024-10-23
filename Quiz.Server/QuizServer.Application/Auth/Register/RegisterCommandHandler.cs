using MediatR;
using QuizServer.Domain.Users;
using TS.Result;

namespace QuizServer.Application.Auth.Register;

public class RegisterCommandHandler(IUserRepository userRepository) : IRequestHandler<RegisterCommand, Result<string>>
{
    public async Task<Result<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        UserName userName = new(request.UserName);
        Password password = new(request.Password);

        var isUserNameExist = await userRepository.IsUserNameExistAsync(userName, cancellationToken);
        if (isUserNameExist)
        {
            return Result<string>.Failure("Kullanýcý adý daha önce kullanýldý");
        }

        User user = new(userName, password);

        bool result = await userRepository.CreateAsync(user, cancellationToken);
        if (!result)
        {
            return Result<string>.Failure("Bir sorun oluþtu");
        }

        return "Kullanýc kaydý baþarýlý bir þekilde oluþturuldu";
    }
}
