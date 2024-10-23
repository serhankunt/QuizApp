using MediatR;
using QuizServer.Domain.Quizzes;
using TS.Result;

namespace QuizServer.Application.Quizzes.ChangeQuizIsStart;

public class ChangeQuizIsStartCommandHandler(
    IQuizRepository quizRepository) : IRequestHandler<ChangeQuizIsStartCommand, Result<string>>
{
    public async Task<Result<string>> Handle(ChangeQuizIsStartCommand request, CancellationToken cancellationToken)
    {
        RoomNumber roomNumber = new(request.RoomNumber);
        Quiz? quiz = await quizRepository.GetByRoomNumberAsync(roomNumber, cancellationToken);

        if (quiz is null)
        {
            return Result<string>.Failure("Quiz bulunamad�");
        }

        IsStart isStart = new(false);
        quiz.ChangeIsStart(isStart);

        await quizRepository.UpdateAsync(quiz, cancellationToken);

        return "Oda m�sait hale getirildi";
    }
}
