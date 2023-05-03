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
    public partial class EditSelectedUser : Form
    {
        public EditSelectedUser()
        {
            InitializeComponent();
            InitializeDataGridViewEditUsers();

        }
  
        
        private void InitializeDataGridViewEditUsers()
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
                IGenericRepository<User> repositoryEditUser = work.Repository<User>();
                DataGridViewRow selectedRow = dataGridView1.Rows[index];
                User userEdit = repositoryEditUser.FindById(Convert.ToInt32(selectedRow.Cells[0].Value));
                userEdit.Login = textBox1.Text;
                userEdit.Password = textBox2.Text;
                userEdit.FirstName = textBox4.Text;
                userEdit.LastName = textBox5.Text;
                userEdit.Description = textBox6.Text;
                userEdit.IsAdmin = checkBox1.Checked;                
                repositoryEditUser.Update(userEdit);
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
            checkBox1.Checked = Convert.ToBoolean(selectedRow.Cells[6].Value);
        }
    }
}
