using MediatR;
using QuizServer.Domain.Dtos;
using QuizServer.Domain.Quizzes;
using QuizServer.Domain.Shared;
using TS.Result;

namespace QuizServer.Application.Quizzes.GetQuizById;

public class GetQuizByIdCommandHandler(IQuizRepository quizRepository) : IRequestHandler<GetQuizByIdCommand, Result<QuizDto>>
{
    public async Task<Result<QuizDto>> Handle(GetQuizByIdCommand request, CancellationToken cancellationToken)
    {
        Identity id = new(request.id);
        Quiz? quiz = await quizRepository.GetByIdAsync(id, cancellationToken);
        if (quiz is null)
        {
            return Result<QuizDto>.Failure("Quiz bulunamadý");
        }

        QuizDto quizDto = new(
            quiz.Id.Value,
            quiz.Title.Value,
            quiz.RoomNumber.Value);

        return quizDto;
    }
}
