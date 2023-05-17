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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GetUserInfoFromDB();
        }

        public List<User> users = new List<User>();
        public string userLogin;
        private void GetUserInfoFromDB()
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
                users = repositoryUsers.GetAll().ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in users)
            {
                if(textBox1.Text == item.Login && textBox2.Text == item.Password)
                {
                    userLogin = textBox1.Text;
                    TestsForClient testsForClient = new TestsForClient(userLogin);
                    testsForClient.ShowDialog();
                }
                else
                {
                    label3.Text = "Incorrect login or password";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
