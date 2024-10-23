using MediatR;
using QuizServer.Domain.Dtos;
using TS.Result;

namespace QuizServer.Application.QuizDetails.GetAllQuizDetailById;

public sealed record GetAllQuizDetailByQuizIdQuery(Guid QuizId) : IRequest<Result<List<QuizDetailDto>>>;
