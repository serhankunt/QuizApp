using MediatR;
using QuizServer.Application.Services;
using QuizServer.Domain.Dtos;
using QuizServer.Domain.QuizDetails;
using QuizServer.Domain.Quizzes;
using TS.Result;

namespace QuizServer.Application.QuizPages.AnswerQuestion;

public class AnswerQuestionCommandHandler(
    IQuizDetailRepository quizDetailRepository,
    ISignalService signalRService) : IRequestHandler<AnswerQuestionCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(AnswerQuestionCommand request, CancellationToken cancellationToken)
    {
        RoomNumber roomNumber = new(request.RoomNumber);
        QuizDetail quizDetail = await quizDetailRepository.GetQuizDetailByQuestionNumberAsync(roomNumber, request.QuestionNumber, cancellationToken);

        var participants = Shared.QuizParticipants.Where(p => p.RoomNumber == request.RoomNumber.ToString()).ToList();

        QuizParticipant participant = participants.Where(p => p.Email == request.Email).First();

        bool response = false;

        CorrectAnswer correctAnswer = CorrectAnswer.FromName(request.Answer);
        if (quizDetail.CorrectAnswer == correctAnswer)
        {
            participant.Point += 1000 - (1000 / ((request.Time - quizDetail.TimeOut.Value + 2) * 10));

            return true;
        }

        await signalRService.SendParticipantInformationToWhoListener(request.RoomNumber.ToString(), participant);

        return response;

    }
}
