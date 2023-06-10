using Microsoft.EntityFrameworkCore;
using Mathzalot.Models;

namespace Mathzalot
{
    public class MathzalotDbContext : DbContext
    {
        public MathzalotDbContext(DbContextOptions<MathzalotDbContext> options) : base(options)
        {
        }

        public DbSet<UserModel> Users {get; set;}
        // public DbSet<QuestionModel> Questions {get; set;}
        // public DbSet<GameRecordModel> GameRecords {get; set;}
        // public DbSet<RankModel> Ranks {get; set;}
        // public DbSet<DifficultyModel> Difficulties {get; set;}
    }
}