using DALTestSystemDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class AssignTest : Form
    {
        public AssignTest()
        {
            InitializeComponent();
            InitializeDataGridViewTests();
        }
        public List<Test> assignTest;
        private void InitializeDataGridViewTests()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<TestSystemContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;

            using (GenericUnitOfWork work = new GenericUnitOfWork(new TestSystemContext(options)))
            {
                IGenericRepository<Test> repositoryTests = work.Repository<Test>();
                dataGridView1.DataSource = repositoryTests.GetAll();
                assignTest = repositoryTests.GetAll().ToList();
            }
        }
        int userToAssign;
        public AssignTest(int userId)
        {
            InitializeComponent();
            this.userToAssign = userId;
            label1.Text = userId.ToString();
            InitializeDataGridViewTests();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<TestSystemContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;

            using (GenericUnitOfWork work = new GenericUnitOfWork(new TestSystemContext(options)))
            {
                IGenericRepository<UserTest> repositoryUserTest = work.Repository<UserTest>();
                IGenericRepository<User> repositoryUser = work.Repository<User>();
                IGenericRepository<Test> repositoryTest = work.Repository<Test>();
                User existingUser = work.Repository<User>().FindById(Convert.ToInt32(label1.Text));
                Test existingTest = work.Repository<Test>().FindById(index);
               
                //This info is stored in passedTest table in db

                UserTest toAdd = new UserTest()
                {
                    IsPassed = false,
                    IsTaked = false,
                    PointsGrade = 0,
                    TakedDate = null,
                    User = existingUser,
                    UserAnswers = null,
                    Test = existingTest
                };
                //existingUser.UserTests.Add(toAdd);
                repositoryUserTest.Add(toAdd);
                
                work.SaveChanges();
            }
            
            this.Close();









            //var builder = new ConfigurationBuilder();
            //builder.SetBasePath(Directory.GetCurrentDirectory());
            //builder.AddJsonFile("appsettings.json");
            //var config = builder.Build();
            //string connectionString = config.GetConnectionString("DefaultConnection");
            //var optionsBuilder = new DbContextOptionsBuilder<TestSystemContext>();
            //var options = optionsBuilder
            //    .UseSqlServer(connectionString)
            //    .Options;

            //using (GenericUnitOfWork work = new GenericUnitOfWork(new TestSystemContext(options)))
            //{
            //    IGenericRepository<Group> repositoryGroup = work.Repository<Group>();

            //    Group groupToAdd = new Group
            //    {
            //        Name = textBox1.Text,
            //        Description = textBox2.Text,
            //        IsAdminGroup = checkBox1.Checked
            //    };

            //    foreach (User user in usersToAddToGroup)
            //    {
            //        // Find the existing user in the database
            //        User existingUser = work.Repository<User>().FindById(user.Id);
            //        existingUser.Groups.Add(groupToAdd);

            //        // Add the existing user to the group
            //        groupToAdd.Users.Add(existingUser);
            //        //  groupToAdd.Users.Add(user);
            //    }

            //    repositoryGroup.Add(groupToAdd);

            //    //  work.SaveChanges(); // Save changes to the database

            //    dataGridView1.DataSource = repositoryGroup.GetAll();
            //}

            //this.Close();
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int index;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
           // DataGridViewRow selectedRow = dataGridView1.Rows[index];
         //   UserTest userTest = new UserTest();
            //Test newTest = new Test();
            //userTest.IsPassed = false;
            //userTest.IsTaked = false;
            //userTest.Test = newTest;
            //newTest.Title = selectedRow.Cells[1].Value.ToString();
            //newTest.Author = selectedRow.Cells[2].Value.ToString();
            //newTest.Description = selectedRow.Cells[3].Value.ToString();
            //newTest.Info = selectedRow.Cells[4].Value.ToString();
            //newTest.PassPercent = Convert.ToInt32(selectedRow.Cells[5].Value);
            //newTest.IsArchived = Convert.ToBoolean(selectedRow.Cells[5].Value);
            //newTest.LoadedDate = Convert.ToDateTime(selectedRow.Cells[6].Value);
            //newTest.Questions = selectedRow.Cells[8].Value.ToString();
            //textBox2.Text = selectedRow.Cells[4].Value.ToString();
            //textBox4.Text = selectedRow.Cells[1].Value.ToString();
            //textBox5.Text = selectedRow.Cells[2].Value.ToString();
            //textBox6.Text = selectedRow.Cells[5].Value.ToString();
            //checkBox1.Checked = Convert.ToBoolean(selectedRow.Cells[6].Value);


        }
    }
}
