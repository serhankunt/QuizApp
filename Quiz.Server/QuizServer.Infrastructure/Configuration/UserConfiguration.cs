using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizServer.Domain.Shared;
using QuizServer.Domain.Users;

namespace QuizServer.Infrastructure.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .Property(p => p.Id)
            .HasConversion(id => id.Value, value => new Identity(value));

        builder
            .Property(p => p.UserName)
            .HasConversion(userName => userName.Value, value => new UserName(value))
            .HasColumnType("varchar(50)");

        builder
            .Property(p => p.Password)
            .HasConversion(password => password.Value, value => new Password(value))
            .HasColumnType("varchar(10)");
    }
}
