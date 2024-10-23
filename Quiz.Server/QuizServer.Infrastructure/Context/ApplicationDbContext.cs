using Microsoft.EntityFrameworkCore;
using QuizServer.Domain.QuizDetails;
using QuizServer.Domain.Quizzes;
using QuizServer.Domain.Users;

namespace QuizServer.Infrastructure.Context;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<QuizDetail> QuizDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DependencyInjection).Assembly);
    }
}
