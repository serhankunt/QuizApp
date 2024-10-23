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
            throw new ArgumentException("Quiz ba�l��� 5 karakterden b�y�k olmal�d�r.");
        }

        if (value.Length > 200)
        {
            throw new ArgumentException("Quiz ba�l��� 200 karakterden k���k olmal�d�r.");
        }

        Title title = new(value);
        return title;
    }
}
