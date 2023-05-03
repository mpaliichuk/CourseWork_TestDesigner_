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
                IGenericRepository<User> repositoryUser = work.Repository<User>();
                repositoryUser.Add(new User { Login = textBox1.Text,Password=textBox2.Text,FirstName=textBox4.Text,LastName=textBox5.Text,Description = textBox6.Text,IsAdmin=checkBox1.Checked,RegisterDate=DateTime.Now });
                dataGridView1.DataSource = repositoryUser;
            }
            //using (var users = new TestSystemContext())
            //{
              
            //}
                
                this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
