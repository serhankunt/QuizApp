using MediatR;
using QuizServer.Domain.Dtos;
using TS.Result;

namespace QuizServer.Application.QuizPages.GetQuizDetailByRoomNumberAndQuestioNumber;

public sealed record GetQuizDetailByRoomNumberAndQuestioNumberCommand(
    int RoomNumber,
    int QuestionNumber) : IRequest<Result<QuizDetailDto>>;
