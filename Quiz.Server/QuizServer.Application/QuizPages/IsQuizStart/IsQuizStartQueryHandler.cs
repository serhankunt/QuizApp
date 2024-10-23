using MediatR;
using QuizServer.Domain.Quizzes;
using TS.Result;

namespace QuizServer.Application.QuizPages.IsQuizStart;

public class IsQuizStartQueryHandler(
    IQuizRepository quizRepository) : IRequestHandler<IsQuizStartQuery, Result<bool>>
{
    public async Task<Result<bool>> Handle(IsQuizStartQuery request, CancellationToken cancellationToken)
    {
        RoomNumber roomNumber = new(request.RoomNumber);
        Quiz? quiz = await quizRepository.GetByRoomNumberAsync(roomNumber, cancellationToken);

        if (quiz is null)
        {
            return Result<bool>.Failure("Quiz bulunamad�");
        }

        return quiz.IsStart.Value;
    }
}
