
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace QuestionAnswerPortal.Models
{
    public class DbHelper : DbContext
    {
        public DbSet<Questions> Question { get; set; }
        public DbSet<Answers> Answer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=FAQPortal.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map table names
            modelBuilder.Entity<Questions>().ToTable("Questions");
            modelBuilder.Entity<Questions>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.QuestionText).IsUnique();
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.Status).HasDefaultValue(true);
            });

            modelBuilder.Entity<Answers>().ToTable("Answers");
            modelBuilder.Entity<Answers>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.Status).HasDefaultValue(true);
            });

            base.OnModelCreating(modelBuilder);
        }
        //public static string connectionString = @"Data Source=.\QuestionAnswerPortalDb.db;Version=3";
        //private static void SaveQuestion(dynamic question)
        //{
        //    using(IDbConnection con = new SQLiteConnection(connectionString))
        //    {

        //    }
        //}

        public static List<Questions> CreateDb()
        {
            using (var dbContext = new DbHelper())
            {
                if (!dbContext.Question.Any())
                {
                    //dbContext.Question.AddRange(new Questions[]
                    //    {
                    //         new Questions{ Id=1, QuestionText="Blog 1"},
                    //         new Questions{ Id=2, QuestionText="Blog 2"},
                    //         new Questions{ Id=3, QuestionText="Blog 3"}
                    //    });
                    //dbContext.SaveChanges();
                }
                List<Questions> questions = new List<Questions>();
                foreach (var ques in dbContext.Question)
                {
                    questions.Add(ques);
                }
                return questions;
            }
        }
    }
}
