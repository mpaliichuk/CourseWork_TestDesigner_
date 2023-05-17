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
    public partial class AddNewUser : Form
    {
        public AddNewUser()
        {
            InitializeComponent();
            InitializeDataGridViewUsers();
        }
        public void InitializeDataGridViewUsers()
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
                IGenericRepository<User> repositoryUsers = work.Repository<User>();
                dataGridView1.DataSource = repositoryUsers.GetAll();
            }
        }
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    var builder = new ConfigurationBuilder();
        //    builder.SetBasePath(Directory.GetCurrentDirectory());
        //    builder.AddJsonFile("appsettings.json");
        //    var config = builder.Build();
        //    string connectionString = config.GetConnectionString("DefaultConnection");
        //    var optionsBuilder = new DbContextOptionsBuilder<TestSystemContext>();
        //    var options = optionsBuilder.UseSqlServer(connectionString).Options;

        //    using (GenericUnitOfWork work = new GenericUnitOfWork(new TestSystemContext(options)))
        //    {
        //        IGenericRepository<Group> repositoryGroup = work.Repository<Group>();
        //        IGenericRepository<User> repositoryUser = work.Repository<User>();

        //        // Retrieve the selected user from the database
        //        int selectedUserId = int.Parse(dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString());
        //        User user = repositoryUser.FindById(selectedUserId);

        //        // Add the user to the group
        //        Group group = new Group
        //        {
        //            Name = "Group1",
        //            Description = "Desc2",
        //            IsAdminGroup = checkBox1.Checked
        //        };
        //        group.Users.Add(user);

        //        repositoryGroup.Add(group);
        //    }

        //    this.Close();
        //}
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
                IGenericRepository<User> repositoryUser = work.Repository<User>();
                repositoryUser.Add(new User { Login = textBox1.Text,Password=textBox2.Text,FirstName=textBox4.Text,LastName=textBox5.Text,Description = textBox6.Text,IsAdmin=checkBox1.Checked,RegisterDate=DateTime.Now });
                dataGridView1.DataSource = repositoryUser;
            }                
                this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
