using MediatR;
using QuizServer.Domain.QuizDetails;
using QuizServer.Domain.Quizzes;
using QuizServer.Domain.Shared;
using TS.Result;

namespace QuizServer.Application.QuizDetails.UpdateQuizDetail;

public class UpdateQuizDetailCommandHandler(
    IQuizDetailRepository quizDetailRepository) : IRequestHandler<UpdateQuizDetailCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateQuizDetailCommand request, CancellationToken cancellationToken)
    {
        Identity identity = new(request.Id);
        QuizDetail? quizDetail = await quizDetailRepository.GetByIdAsync(identity, cancellationToken);

        if (quizDetail is null)
        {
            return Result<string>.Failure("Quiz detay bulunamadý");
        }

        Title title = Title.Create(request.Title);
        Answer answerA = new(request.AnswerA);
        Answer answerB = new(request.AnswerB);
        Answer answerC = new(request.AnswerC);
        Answer answerD = new(request.AnswerD);

        CorrectAnswer correctAnswer = CorrectAnswer.FromName(request.CorrectAnswer);
        TimeOut timeOut = new(request.TimeOut);

        quizDetail.SetTitle(title);
        quizDetail.SetAnswerA(answerA);
        quizDetail.SetAnswerA(answerB);
        quizDetail.SetAnswerA(answerC);
        quizDetail.SetAnswerA(answerD);
        quizDetail.SetCorrectAnswer(correctAnswer);
        quizDetail.SetTimeOut(timeOut);

        await quizDetailRepository.UpdateAsync(quizDetail, cancellationToken);

        return Result<string>.Succeed("Güncelleme iþlemi baþarýyla tamamlandý");
    }
}
