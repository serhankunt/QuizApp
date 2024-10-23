using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizServer.Domain.QuizDetails;
using QuizServer.Domain.Quizzes;
using QuizServer.Domain.Shared;

namespace QuizServer.Infrastructure.Configuration;

public class QuizDetailConfiguration : IEntityTypeConfiguration<QuizDetail>
{
    public void Configure(EntityTypeBuilder<QuizDetail> builder)
    {
        builder.Property(p => p.Id)
            .HasConversion(id => id.Value, value => new Identity(value));

        builder.Property(p => p.QuizId)
            .HasConversion(id => id.Value, value => new Identity(value));

        builder.Property(p => p.Title)
            .HasConversion(title => title.Value, value => Title.Create(value))
            .HasColumnType("varchar(200)");

        builder.Property(p => p.AnswerA)
            .HasConversion(answer => answer.Value, value => new Answer(value))
            .HasColumnType("varchar(100)");

        builder.Property(p => p.AnswerB)
            .HasConversion(answer => answer.Value, value => new Answer(value))
            .HasColumnType("varchar(100)");

        builder.Property(p => p.AnswerC)
            .HasConversion(answer => answer.Value, value => new Answer(value))
            .HasColumnType("varchar(100)");

        builder.Property(p => p.AnswerD)
            .HasConversion(answer => answer.Value, value => new Answer(value))
            .HasColumnType("varchar(100)");

        builder.Property(p => p.CorrectAnswer)
            .HasConversion(correctAnswer => correctAnswer.Value, value => CorrectAnswer.FromValue(value));

        builder.Property(p => p.TimeOut)
            .HasConversion(timeout => timeout.Value, value => new TimeOut(value));

    }
}
