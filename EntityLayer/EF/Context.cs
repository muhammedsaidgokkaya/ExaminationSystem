using EntityLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.EF
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=ExaminationSystem_SQL;Integrated Security=True");
        }
        public DbSet<Question> Question { get; set; }
        public DbSet<AnswerType> AnswerType { get; set; }
        public DbSet<AnswerValue> AnswerValue { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Quiz> Quiz { get; set; }
        public DbSet<QuizUser> QuizUser { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
    }
}
