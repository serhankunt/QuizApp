using Microsoft.AspNetCore.SignalR;
using QuizServer.Domain.Dtos;

namespace QuizServer.Infrastructure.Hubs;

public class QuizHub : Hub
{
    public static HashSet<QuizTime> QuizTimes = new();
    public async Task JoinQuizRoomByParticipant(string roomNumber, string email, string userName)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, roomNumber.ToString());


    }
}
