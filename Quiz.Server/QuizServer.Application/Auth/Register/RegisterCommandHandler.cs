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
            return Result<string>.Failure("Kullan�c� ad� daha �nce kullan�ld�");
        }

        User user = new(userName, password);

        bool result = await userRepository.CreateAsync(user, cancellationToken);
        if (!result)
        {
            return Result<string>.Failure("Bir sorun olu�tu");
        }

        return "Kullan�c kayd� ba�ar�l� bir �ekilde olu�turuldu";
    }
}
