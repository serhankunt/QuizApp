
namespace QuizServer.Domain.Dtos;

public sealed record QuizTime
{
    public QuizTime(string roomNumber, int time)
    {
        RoomNumber = roomNumber;
        Time = time;
    }

    public string RoomNumber { get; set; }
    public int Time { get; set; }
}