
using QuizServer.Domain.Dtos;

namespace QuizServer.Application.Services;

public interface ISignalService
{
    Task JoinQuizRoom(string roomNumber, QuizParticipant participant);
    Task SendParticipantInformationToWhoListener(string roomNumber, QuizParticipant participant);
}
