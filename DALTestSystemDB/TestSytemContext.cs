using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DALTestSystemDB
{
    public class TestSystemContext : DbContext
    {
        public TestSystemContext() : base()
        {

        }

        public TestSystemContext(DbContextOptions<TestSystemContext> options) : base(options)
        {
            Database.EnsureCreated();


        }
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<UserTest> PassedTests { get; set; }
        public DbSet<UserAnswer> PassedTestAnswers { get; set; }
        public DbSet<GroupUser> GroupUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(x => x.Login).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Password).IsRequired();
            modelBuilder.Entity<Group>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Test>().Property(x => x.Title).IsRequired();
            modelBuilder.Entity<Question>().Property(x => x.QuestionText).IsRequired();
            modelBuilder.Entity<Answer>().Property(x => x.AnswerText).IsRequired();

            // many to many
            //------------------
            // User <-> Group
            modelBuilder.Entity<User>().HasMany(x => x.Groups).WithMany(y => y.Users);
            modelBuilder.Entity<GroupUser>().HasKey(sc => new { sc.GroupsId, sc.UsersId});

            modelBuilder.Entity<GroupUser>()
            .HasOne<User>(sc => sc.User)
            .WithMany(s => s.GroupUsers)
            .HasForeignKey(sc => sc.UsersId);


            modelBuilder.Entity<GroupUser>()
                .HasOne<Group>(sc => sc.Group)
                .WithMany(s => s.GroupUsers)
                .HasForeignKey(sc => sc.GroupsId);
            // one to many
            //------------------
            // Test -> Question
            modelBuilder.Entity<Test>().HasMany(x => x.Questions).WithOne(y => y.Test);

            // Question -> Answer
            modelBuilder.Entity<Question>().HasMany(x => x.Answers).WithOne(y => y.Question);

            // User -> UserTest
            modelBuilder.Entity<User>().HasMany(x => x.UserTests).WithOne(y => y.User);

            // Test -> UserTest
            modelBuilder.Entity<Test>().HasMany(x => x.UserTests).WithOne(y => y.Test);


            // UserTest -> UserAnswer
            modelBuilder.Entity<UserTest>().HasMany(x => x.UserAnswers).WithOne(y => y.UserTest);

            // Answer -> UserAnswer
            modelBuilder.Entity<Answer>().HasMany(x => x.UserAnswers).WithOne(y => y.Answer);


            //Group admin = new Group() { Id = 1, Name = "Admins" };
            //modelBuilder.Entity<Group>().HasData(admin);

            //User adminUser = new User() {Id = 1, Login = "Admin", Password = "Admin" };
            //adminUser.Groups.Add(admin);
            //modelBuilder.Entity<User>().HasData(adminUser);



        }
    }
}
