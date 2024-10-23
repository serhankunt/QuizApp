
namespace QuizServer.Domain.Dtos;

public sealed record QuizParticipant
{
    public QuizParticipant(string connectionId, string roomNumber, string email, string userName)
    {
        ConnectionId = connectionId;
        RoomNumber = roomNumber;
        Email = email;
        UserName = userName;
        Point = 0;
    }

    public string ConnectionId { get; set; }
    public string RoomNumber { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public int Point { get; set; }
}
