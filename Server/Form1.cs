using Microsoft.Extensions.Configuration;
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
using DALTestSystemDB;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeDataGridViewUsers();
            InitializeDataGridViewGroups();
        }

        private void InitializeDataGridViewGroups()
        {
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
            //    IGenericRepository<Group> repositoryGroups = work.Repository<Group>();
            //    dataGridView2.DataSource = repositoryGroups.GetAll();
            //}
        }

        public void InitializeDataGridViewUsers()
        {
            //using(var users = new TestSystemContext())
            //{
            //    dataGridView1.DataSource = users.Users.ToList();
            //}

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
               IGenericRepository<Group> repositoryGroup = work.Repository<Group>();
                repositoryGroup.Add(new Group {Name ="Students" });
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            e.Node.Tag = this.treeView1.SelectedNode.Name;
            activePanel.Visible = false;
            switch(e.Node.Tag)
            {
                case "General":
                    activePanel = panelGeneral;
                    break;
                case "Users":
                    activePanel = panelUsers;
                    break;
                case "Groups":
                    activePanel = panelGroups;
                    break;

            }
            activePanel.Dock = DockStyle.Fill;
            activePanel.Visible = true;
        }

        private void AddUserBtn_Click(object sender, EventArgs e)
        {
            AddNewUser addNewUser = new AddNewUser();
            addNewUser.ShowDialog();
        }

        private void EditUserBtn_Click(object sender, EventArgs e)
        {
            EditSelectedUser editSelectedUser = new EditSelectedUser();
            editSelectedUser.ShowDialog();
        }

        private void DeleteUserBtn_Click(object sender, EventArgs e)
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
                IGenericRepository<User> repoUser = work.Repository<User>();
                DataGridViewRow selectedRow = dataGridView1.Rows[index];
                var toDelete = repoUser.FindById(Convert.ToInt32(selectedRow.Cells[0].Value));
                repoUser.Remove(toDelete);
            }

        }
        int index;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
        }
    }
}
