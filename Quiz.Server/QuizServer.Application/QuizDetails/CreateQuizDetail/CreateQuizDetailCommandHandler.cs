using MediatR;
using QuizServer.Domain.QuizDetails;
using QuizServer.Domain.Quizzes;
using QuizServer.Domain.Shared;
using TS.Result;

namespace QuizServer.Application.QuizDetails.CreateQuizDetail;

public class CreateQuizDetailCommandHandler(
    IQuizDetailRepository quizDetailRepository) : IRequestHandler<CreateQuizDetailCommand, Result<string>>
{
    public Task<Result<string>> Handle(CreateQuizDetailCommand request, CancellationToken cancellationToken)
    {
        Identity quizId = new(request.QuizId);
        Title title = Title.Create(request.Title);
        Answer answerA = new(request.AnswerA);
        Answer answerB = new(request.AnswerB);
        Answer answerC = new(request.AnswerC);
        Answer answerD = new(request.AnswerD);

        CorrectAnswer correctAnswer = CorrectAnswer.FromName(request.CorrectAnswer);
        TimeOut timeOut = new(request.Timeout);

        QuizDetail quizDetail = new(quizId, title, answerA, answerB, answerC, answerD, correctAnswer, timeOut);
    }
}
