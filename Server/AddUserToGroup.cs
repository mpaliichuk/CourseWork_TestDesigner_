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
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class AddUserToGroup : Form
    {
        public AddUserToGroup()
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
        public AddUserToGroup(AddNewGroup fr)
        {
            InitializeComponent();
            InitializeDataGridViewUsers();
            newGroup = fr;
        }
        AddNewGroup newGroup = new AddNewGroup();
     
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    User userToGroup = new User() {Login= textBox1.Text,Password=textBox2.Text,FirstName=textBox4.Text,LastName=textBox5.Text,Description=textBox6.Text,IsAdmin=checkBox1.Checked};
            
        //    newGroup.usersToAddToGroup.Add(userToGroup);
        //    newGroup.bindingSource1.DataSource = newGroup.usersToAddToGroup;
        //    newGroup.bindingSource1.ResetBindings(false);
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
               // int selectedUserId = Convert.ToInt32((dataGridView1.SelectedRows[index].Cells[0].Value.ToString()));
                int selectedUserId = Convert.ToInt32(textBox3.Text);
                User user = repositoryUser.FindById(selectedUserId);
               // repositoryUser.Add(user);
                newGroup.usersToAddToGroup.Add(user);
                newGroup.bindingSource1.DataSource = newGroup.usersToAddToGroup;
                newGroup.bindingSource1.ResetBindings(false);
               // dataGridView1.DataSource = repositoryUser;
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int index;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            textBox1.Text = selectedRow.Cells[3].Value.ToString();
            textBox2.Text = selectedRow.Cells[4].Value.ToString();
            textBox4.Text = selectedRow.Cells[1].Value.ToString();
            textBox5.Text = selectedRow.Cells[2].Value.ToString();
            textBox6.Text = selectedRow.Cells[5].Value.ToString();
            textBox3.Text = selectedRow.Cells[0].Value.ToString();
            checkBox1.Checked = Convert.ToBoolean(selectedRow.Cells[6].Value);
        }
    }
}
