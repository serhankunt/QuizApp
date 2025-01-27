using MediatR;
using QuizServer.Application.Services;
using QuizServer.Domain.Users;
using TS.Result;

namespace QuizServer.Application.Auth.Login;

public class LoginCommandHandler(
    IUserRepository userRepository,
    IJwtProvider jwtProvider) : IRequestHandler<LoginCommand, Result<string>>
{
    public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        UserName userName = new(request.UserName);
        Password password = new(request.Password);

        User? user = await userRepository.GetByUserNameAndPasswordAsync(userName, password, cancellationToken);

        if (user is null)
        {
            return Result<string>.Failure("Kullanıcı bulunamadı");
        }

        return jwtProvider.CreateToken(user);
    }
}
