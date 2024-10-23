namespace QuizServer.Domain.Quizzes;

public sealed record Title
{
    private Title(string value)
    {
        Value = value;
    }

    public string Value { get; private set; } = default!;

    public static Title Create(string value)
    {
        if (value.Length < 5)
        {
            throw new ArgumentException("Quiz baþlýðý 5 karakterden büyük olmalýdýr.");
        }

        if (value.Length > 200)
        {
            throw new ArgumentException("Quiz baþlýðý 200 karakterden küçük olmalýdýr.");
        }

        Title title = new(value);
        return title;
    }
}
